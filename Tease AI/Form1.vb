Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Speech.Synthesis
Imports System.Speech.AudioFormat
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions


Public Class Form1
	'blah
	Public Chat As String
	Public randomizer As New Random
	Public ScriptOperator As String
	Public ScriptCompare As String

	Public DomTyping As Boolean

	Dim CheckYes As Boolean
	Dim CheckNo As Boolean

	Public Playlist As Boolean
	Public PlaylistFile As New List(Of String)
	Public PlaylistCurrent As Integer

	Public SubInChastity As Boolean

	' Github Patch  Public FormLoading As Boolean
	Public FormLoading As Boolean = True

	Dim RandomDelay As Integer
	Dim Responding As Boolean

	Dim ScriptLineVal As Integer
	Public StrokeTauntVal As Integer
	Dim ThoughtTauntVal As Integer
	Dim ModuleTauntVal As Integer
	Public FileText As String
	Public TempStrokeTauntVal As Integer
	Public TempFileText As String
	Dim ModText As String

	Public TeaseTick As Integer

	Dim StrokeTauntCount As Integer
	Dim TauntTextTotal As Integer
	Dim TauntLines As New List(Of String)
	Dim StrokeFilter As Boolean

	Public ScriptTick As Integer
	Dim StringLength As Integer
	Public FileGoto As String
	Public SkipGotoLine As Boolean

	Dim HandleScriptText As String
	Dim ChatString As String
	Public DomTask As String
	Public DomChat As String
	Dim TypeDelay As Integer
	Dim TempVal As Integer
	Dim NullResponse As Boolean

	Dim CleanFlag As Boolean

	Dim DebugAwarenessLine As String

	Public TagCount As Integer
	Public LocalTagCount As Integer

	Dim OrgasmResult As String
	Dim BeggedOrgasmDecision As Boolean
	Public TeaseOver As Boolean


	Dim TaskFile As String
	Dim TaskText As String
	Dim TaskTextDir As String


	Dim ResponseFile As String
	Dim ResponseLine As Integer

	Dim CBTCockActive As Boolean
	Dim CBTBallsActive As Boolean

	Dim CBTCockFlag As Boolean
	Dim CBTBallsFlag As Boolean

	Dim CBTBallsFirst As Boolean
	Dim CBTCockFirst As Boolean

	Dim CBTBallsCount As Integer
	Dim CBTCockCount As Integer

	Dim ThoughtCount As Integer

	Dim GotoDommeLevel As Boolean

	Dim DommeMood As Integer

	Public AFK As Boolean


	Public HypnoGen As Boolean
	Public Induction As Boolean
	Public TempHypno As String

	Public DomColor As String
	Public SubColor As String

	Dim StrokeCycle As Integer

	Public StrokeTick As Integer
	Public StrokeTauntTick As Integer
	Public StrokePaceRight As Boolean
	Public StrokePace As Integer
	Public AudibleTick As Integer

	Dim StrokeTimeTotal As Integer
	Dim HoldEdgeTime As Integer
	Dim HoldEdgeTimeTotal As Integer

	Public EdgeTauntInt As Integer

	Dim DelayTick As Integer
	Dim DelayFlag As Boolean

	Dim PreCleanString As String

	Public DomTypeCheck As Boolean
	Dim TypeToggle As Boolean
	Dim IsTyping As Boolean
	Dim SubWroteLast As Boolean
	Dim YesOrNo As Boolean
	Dim GotoFlag As Boolean
	Dim LoopAnswer As Boolean

	Dim CBT As Boolean
	Dim NoEdge As Boolean

	Dim RunningScript As Boolean
	Dim RePound As Boolean

	Public BeforeTease As Boolean
	Public SubStroking As Boolean
	Dim SubEdging As Boolean
	Dim SubHoldingEdge As Boolean
	Dim SubCBT As Boolean
	Dim EndTease As Boolean

	Dim ShowThought As Boolean
	Dim ShowEdgeThought As Boolean
	Public ShowModule As Boolean
	Dim ModuleEnd As Boolean

	Dim DivideText As Boolean

	Public HoldEdgeTick As Integer
	Dim HoldEdgeChance As Integer

	Dim EdgeHold As Boolean
	Dim EdgeNoHold As Boolean
	Dim EdgeToRuin As Boolean
	Dim EdgeToRuinSecret As Boolean
	Dim LongEdge As Boolean

	Dim AskedToGiveUp As Boolean
	Dim AskedToGiveUpSection As Boolean
	Dim SubGaveUp As Boolean
	Dim AskedToSpeedUp As Boolean
	Dim AskedToSlowDown As Boolean

	Dim ThoughtEnd As Boolean

	Dim VTLength As Integer

	Dim DommeVideo As Boolean
	Dim VideoType As String
	Public CensorshipGame As Boolean
	Public CensorshipTick As Integer
	Dim CensorDuration As String
	Public AvoidTheEdgeGame As Boolean
	Public AvoidTheEdgeTick As Integer
	Dim AvoidTheEdgeTimerTick As Integer
	Dim AvoidTheEdgeDuration As String
	Public AvoidTheEdgeStroking As Boolean
	Dim AtECountdown As Integer

	Public VTPath As String
	Public NoVideo As Boolean
	Public NoSpecialVideo As Boolean
	Public VideoCheck As Boolean
	Public VideoTease As Boolean

	Public RLGLGame As Boolean
	Dim RLGLStroking As Boolean
	Public RLGLTick As Integer
	Dim RedLight As Boolean
	Dim RLGLTauntTick As Integer

	Public RandomizerVideo As Boolean
	Public RandomizerVideoTease As Boolean

	Public ScriptVideoTease As String
	Public ScriptVideoTeaseFlag As Boolean

	Dim VideoTauntTick As Integer


	Public SlideshowLoaded As Boolean
	Public RefreshVideoTotal As Integer

	Dim GlitterImageAV As String = Application.StartupPath & "\Images\Glitter\01.jpg"
	Public GlitterNCDomme As String
	Public GlitterNC1 As String
	Public GlitterNC2 As String
	Public GlitterNC3 As String
	Dim GlitterTempColor As String
	Public UpdatesTick As Integer
	Dim UpdatingPost As Boolean
	Dim UpdateStage As Integer
	Dim UpdateStageTick As Integer
	Public StatusText As String
	Dim ContactNumber As Integer
	Dim ContactTick As Integer
	Dim ContactFlag As Boolean
	Dim StatusText1 As String
	Dim StatusText2 As String
	Dim StatusText3 As String

	Dim StatusChance1 As Integer
	Dim StatusChance2 As Integer
	Dim StatusChance3 As Integer

	Dim Update1 As Boolean
	Dim Update2 As Boolean
	Dim Update3 As Boolean

	Dim LastSuccessfulImage As Integer
	Dim GetFolder As String
	Dim FileCount As Integer
	Dim FileCountMax As Integer
	Private _ImageFileNames As New List(Of String)
	Private _CurrentImage As Integer = -1
	Dim WithTeaseImgDir As String
	Public ApproveImage As Integer = 0
	Public WIExit As Boolean
	Public RecentSlideshows As New List(Of String)
	Dim MainPictureImage As String
	Public DomPic As String

	Dim LockImage As Boolean

	Dim LocalTagImageList As New List(Of String)

	Dim Crazy As Boolean
	Dim Vulgar As Boolean
	Dim Supremacist As Boolean


	Public CockSize As Integer
	Dim TempDick As String
	Dim PetName As String
	Dim PetName2 As String

	Dim TauntText As String
	Dim ScriptCount As Integer
	Dim TempScriptCount As Integer
	Dim TauntTextCount As Integer

	Dim StartIndex As Integer
	Dim EndIndex As Integer

	Public SlideshowTimerTick As Integer

	Dim ReadBlog As String
	Dim ReadBlogRate As String
	Dim SearchImageBlog As Boolean
	Dim FoundString As String
	Public WebImage As String

	Public WebImageFile As StreamReader
	Public WebImageLines As New List(Of String)
	Public WebImageLine As Integer
	Public WebImageLineTotal As Integer
	Public WebImagePath As String


	Dim ImageUrlFilePath As String
	Dim ImageUrlFileIndex As Integer


	Dim ReaderString As String
	Dim ReaderStringTotal As Integer

	Public StrokePaceInt As Integer

	Dim LastScriptCountdown As Integer
	Dim LastScript As Boolean

	Dim JustShowedBlogImage As Boolean

	Public SaidHello As Boolean

	Public StopMetronome As Boolean

	Public AvgEdgeStroking As Integer
	Public AvgEdgeNoTouch As Integer
	Public EdgeCountTick As Integer
	Public AvgEdgeStrokingFlag As Boolean
	Public AvgEdgeCount As Integer
	Public AvgEdgeCountRest As Integer
	Dim EdgeTickCheck As Integer

	Dim EdgeNOT As Boolean

	Public AlreadyStrokingEdge As Boolean

	Dim WritingTaskLinesAmount As Integer
	Dim WritingTaskLinesWritten As Integer
	Dim WritingTaskLinesRemaining As Integer
	Dim WritingTaskMistakesAllowed As Integer
	Dim WritingTaskMistakesMade As Integer
	Dim WritingTaskFlag As Boolean

	Dim FirstRound As Boolean
	Public StartStrokingCount As Integer

	Dim TeaseJOI As Boolean
	Dim TeaseVideo As Boolean

	Dim TnAPath As String
	Dim TnAList As New List(Of String)
	Dim BoobList As New List(Of String)
	Dim AssList As New List(Of String)
	Dim AssImage As Boolean
	Dim BoobImage As Boolean



	Dim FoundTag As String = "Null"
	Dim TagGarment As String = "NULL"
	Dim TagUnderwear As String = "NULL"
	Dim TagTattoo As String = "NULL"
	Dim TagSexToy As String = "NULL"
	Dim TagFurniture As String = "NULL"

	Public ImportKeyword As Boolean

	Dim BookmarkModule As Boolean
	Dim BookmarkModuleFile As String
	Dim BookmarkModuleLine As Integer
	Dim BookmarkLink As Boolean
	Dim BookmarkLinkFile As String
	Dim BookmarkLinkLine As Integer

	Dim WaitTick As Integer

	Public synth As New SpeechSynthesizer
	Public synth2 As New SpeechSynthesizer



	Dim OrgasmDenied As Boolean
	Dim OrgasmAllowed As Boolean
	Dim OrgasmRuined As Boolean
	Dim LastOrgasmType As String = ""

	Dim StupidTick As Integer
	Dim StupidFlag As Boolean

	Public CaloriesConsumed As Integer
	Public CaloriesGoal As Integer

	Public GoldTokens As Integer
	Public SilverTokens As Integer
	Public BronzeTokens As Integer

	Dim EdgeFound As Boolean

	Dim OrgasmYesNo As Boolean

	Public VTFlag As Boolean

	Public Shared DomPersonality As String
	Public UpdateList As New List(Of String)

	Public GlitterDocument As String

	Dim CustomSlideshow As Boolean
	Dim CustomSlideshowTick As Integer
	Dim CustomSlideshowList As New List(Of String)
	Dim ImageString As String

	Dim RapidFire As Boolean

	Public GlitterTease As Boolean
	Dim AddContactTick As Integer
	Public Contact1Pics As New List(Of String)
	Public Contact2Pics As New List(Of String)
	Public Contact3Pics As New List(Of String)
	Public Contact1PicsCount As Integer
	Public Contact2PicsCount As Integer
	Public Contact3PicsCount As Integer
	Public Group As String = "D"

	Dim CustomTask As Boolean
	Dim CustomTaskFirst As Boolean
	Dim CustomTaskText As String
	Dim CustomTaskTextFirst As String
	Dim CustomTaskActive As Boolean

	Dim SubtitleCount As Integer
	Dim VidFile As String


	Public RiskyDeal As Boolean
	Public RiskyEdges As Boolean
	Public RiskyDelay As Boolean
	Public FinalRiskyPick As Boolean

	Public TempGif As Image
	Dim resized As Image

	Dim SysMes As Boolean
	Dim EmoMes As Boolean

	Dim Contact1Edge As Boolean
	Dim Contact2Edge As Boolean
	Dim Contact3Edge As Boolean

	Dim Contact1Stroke As Boolean
	Dim Contact2Stroke As Boolean
	Dim Contact3Stroke As Boolean

	Dim ReturnFileText As String
	Dim ReturnStrokeTauntVal As String
	Dim ReturnSubState As String
	Dim ReturnFlag As Boolean

	Public SessionEdges As Integer

	Dim WindowCheck As Boolean

	Dim StrokeFaster As Boolean
	Dim StrokeFastest As Boolean
	Dim StrokeSlower As Boolean
	Dim StrokeSlowest As Boolean

	Dim InputFlag As Boolean
	Dim InputString As String

	Dim RapidCode As Boolean

	Dim CorrectedTypo As Boolean
	Dim CorrectedWord As String

	Public DoNotDisturb As Boolean

	Dim TypoSwitch As Integer = 1
	Dim TyposDisabled As Boolean

	Public EdgeHoldSeconds As Integer
	Public EdgeHoldFlag As Boolean

	Public SlideshowInt As Integer
	Dim JustShowedSlideshowImage As Boolean

	Public DeleteLocalImageFilePath As String
	Dim RandomSlideshowCategory As String

	Dim ResetFlag As Boolean

	Dim DommeTags As Boolean
	Dim ThemeSettings As Boolean

	Dim InputIcon As Boolean

	Public ApplyingTheme As Boolean
	Public AdjustingWindow As Boolean

	Dim SplitContainerHeight As Integer

	Dim DommeImageFound As Boolean
	''' <summary>
	''' Variable Deprected. Remove from Suspend and Resume Session needed. 
	''' But check for Incompatibilty first.
	''' </summary>
	Dim DommeImageListCheck As Boolean

	Dim LocalImageFound As Boolean
	Dim LocalImageListCheck As Boolean

	Dim CBTBothActive As Boolean
	Dim CBTBothFlag As Boolean
	Dim CBTBothCount As Integer
	Dim CBTBothFirst As Boolean

	Public MetroThread As Thread
	Dim MetroGet As Integer

	Dim GeneralTime As String = "Afternoon"

	Dim NewDommeSlideshow As Boolean
	Dim OriginalDommeSlideshow As String

	Dim TimeoutTick As Integer

	Public ImageThread As Thread
	Dim PBImage As String
	Dim DommeImageSTR As String
	Dim LocalImageSTR As String
	''' <summary>
	''' This Variable contains the Path of origin of the displayed Image. CheckDommeTag() uses 
	''' this string to get the curremt ImageData for the DommeTagApp.
	''' </summary>
	Dim ImageLocation As String

	Public ResponseThread As Thread

	Dim ResponseYes As String
	Dim ResponseNo As String

	Dim SetModule As String = ""
	Dim SetLink As String = ""
	Dim SetModuleGoto As String = ""
	Dim SetLinkGoto As String = ""


	Public OrgasmRestricted As Boolean

	Dim FollowUp As String = ""

	Dim WorshipMode As Boolean
	Dim WorshipTarget As String = ""

	Dim LongHold As Boolean
	Dim ExtremeHold As Boolean
	Dim LongTaunts As Boolean
	Dim ExtremeTaunts As Boolean

	Dim LazyEdit1 As Boolean
	Dim LazyEdit2 As Boolean
	Dim LazyEdit3 As Boolean
	Dim LazyEdit4 As Boolean
	Dim LazyEdit5 As Boolean

	Dim CurrentImage As String

	Dim FormFinishedLoading As Boolean = False

	Dim MiniScript As Boolean
	Dim MiniScriptText As String
	Dim MiniTauntVal As Integer
	Dim MiniTimerCheck As Boolean

	Dim PreLoadImage As Boolean
	Dim CachedImage As Image
	Dim CachedImage2 As Image

	Dim JumpVideo As Boolean
	Dim VideoTick As Integer

	Dim EdgeGoto As Boolean
	Dim EdgeMessage As Boolean
	Dim EdgeVideo As Boolean

	Dim EdgeMessageText As String
	Dim EdgeGotoLine As String

	Dim MultipleEdges As Boolean
	Dim MultipleEdgesAmount As Integer
	Dim MultipleEdgesInterval As Integer
	Dim MultipleEdgesTick As Integer
	Dim MultipleEdgesMetronome As String = ""

	Dim YesGoto As Boolean
	Dim YesVideo As Boolean
	Dim NoGoto As Boolean
	Dim NoVideo_Mode As Boolean
	Dim CameGoto As Boolean
	Dim CameVideo As Boolean
	Dim CameMessage As Boolean
	Dim CameMessageText As String
	Dim RuinedGoto As Boolean
	Dim RuinedVideo As Boolean
	Dim RuinedMessage As Boolean
	Dim RuinedMessageText As String
	Dim YesGotoLine As String
	Dim NoGotoLine As String
	Dim CameGotoLine As String
	Dim RuinedGotoLine As String

	Dim TauntEdging As Boolean
	Dim TauntEdgingSession As Boolean
	Dim TauntEdgingAsked As Boolean

	Private Const DISABLE_SOUNDS As Integer = 21
	Private Const SET_FEATURE_ON_PROCESS As Integer = 2

	Private Const MyFormWd As Long = 5000
	Private Const MyFormHt As Long = 6000

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









	Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed



		mainPictureBox.Image = Nothing
		Debug.Print("Here?")

		UpdatesTimer.Stop()
		StrokeTimeTotalTimer.Stop()
		StopEverything()

		'ScriptTimer.Stop()
		'StrokeTimer.Stop()



		'If BeforeTease = False And My.Settings.Sys_SubLeftEarly <> 0 Then My.Settings.Sys_SubLeftEarlyTotal += 1

		If BeforeTease = False And Val(GetVariable("SYS_SubLeftEarly")) <> 0 Then SetVariable("SYS_SubLeftEarlyTotal", Val(GetVariable("SYS_SubLeftEarlyTotal")) + 1)

		My.Settings.Save()


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

	End Sub






	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

		Debug.Print("Form 2 Opened")



		FormLoading = True

		FrmSplash.Show()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking orgasm limit..."     ' 1
		FrmSplash.Refresh()

		If My.Settings.OrgasmLockDate = Nothing Then My.Settings.OrgasmLockDate = FormatDateTime(Now, DateFormat.ShortDate)
		My.Settings.Save()
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

		StopMetronome = True



		StrokeTimeTotal = My.Settings.StrokeTimeTotal
		StrokeTimeTotalTimer.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Calculating total stroke time..."
		FrmSplash.Refresh()

		Dim STT As TimeSpan = TimeSpan.FromSeconds(StrokeTimeTotal)
		FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)


		DomTask = "Null"
		DomChat = "Null"

		CBTBallsFirst = True
		CBTCockFirst = True
		CBTBothFirst = True
		CustomTaskFirst = True

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

		RecentSlideshows.Clear()

		For Each comboitem As String In My.Settings.RecentSlideshows
			RecentSlideshows.Add(comboitem)
		Next

		Chat = ""
		IsTypingTimer.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking local videos..."
		FrmSplash.Refresh()

		FrmSettings.LblVideoHardCore.Text = My.Settings.VideoHardcore
		FrmSettings.LblVideoSoftCore.Text = My.Settings.VideoSoftcore
		FrmSettings.LblVideoLesbian.Text = My.Settings.VideoLesbian
		FrmSettings.LblVideoBlowjob.Text = My.Settings.VideoBlowjob
		FrmSettings.LblVideoFemdom.Text = My.Settings.VideoFemdom
		FrmSettings.LblVideoFemsub.Text = My.Settings.VideoFemsub
		FrmSettings.LblVideoJOI.Text = My.Settings.VideoJOI
		FrmSettings.LblVideoCH.Text = My.Settings.VideoCH
		FrmSettings.LblVideoGeneral.Text = My.Settings.VideoGeneral

		FrmSettings.LblVideoHardCoreD.Text = My.Settings.VideoHardcoreD
		FrmSettings.LblVideoSoftCoreD.Text = My.Settings.VideoSoftcoreD
		FrmSettings.LblVideoLesbianD.Text = My.Settings.VideoLesbianD
		FrmSettings.LblVideoBlowjobD.Text = My.Settings.VideoBlowjobD
		FrmSettings.LblVideoFemdomD.Text = My.Settings.VideoFemdomD
		FrmSettings.LblVideoFemsubD.Text = My.Settings.VideoFemsubD
		FrmSettings.LblVideoJOID.Text = My.Settings.VideoJOID
		FrmSettings.LblVideoCHD.Text = My.Settings.VideoCHD
		FrmSettings.LblVideoGeneralD.Text = My.Settings.VideoGeneralD

		If My.Settings.CBHardcore = True Then FrmSettings.CBVideoHardcore.Checked = True
		If My.Settings.CBSoftcore = True Then FrmSettings.CBVideoSoftCore.Checked = True
		If My.Settings.CBLesbian = True Then FrmSettings.CBVideoLesbian.Checked = True
		If My.Settings.CBBlowjob = True Then FrmSettings.CBVideoBlowjob.Checked = True
		If My.Settings.CBFemdom = True Then FrmSettings.CBVideoFemdom.Checked = True
		If My.Settings.CBFemsub = True Then FrmSettings.CBVideoFemsub.Checked = True
		If My.Settings.CBJOI = True Then FrmSettings.CBVideoJOI.Checked = True
		If My.Settings.CBCH = True Then FrmSettings.CBVideoCH.Checked = True
		If My.Settings.CBGeneral = True Then FrmSettings.CBVideoGeneral.Checked = True

		If My.Settings.CBHardcoreD = True Then FrmSettings.CBVideoHardcoreD.Checked = True
		If My.Settings.CBSoftcoreD = True Then FrmSettings.CBVideoSoftCoreD.Checked = True
		If My.Settings.CBLesbianD = True Then FrmSettings.CBVideoLesbianD.Checked = True
		If My.Settings.CBBlowjobD = True Then FrmSettings.CBVideoBlowjobD.Checked = True
		If My.Settings.CBFemdomD = True Then FrmSettings.CBVideoFemdomD.Checked = True
		If My.Settings.CBFemsubD = True Then FrmSettings.CBVideoFemsubD.Checked = True
		If My.Settings.CBJOID = True Then FrmSettings.CBVideoJOID.Checked = True
		If My.Settings.CBCHD = True Then FrmSettings.CBVideoCHD.Checked = True
		If My.Settings.CBGeneralD = True Then FrmSettings.CBVideoGeneralD.Checked = True

		If My.Settings.NBCensorShowMin > 0 Then FrmSettings.NBCensorShowMin.Value = My.Settings.NBCensorShowMin
		If My.Settings.NBCensorShowMax > 0 Then FrmSettings.NBCensorShowMax.Value = My.Settings.NBCensorShowMax
		If My.Settings.NBCensorHideMin > 0 Then FrmSettings.NBCensorHideMin.Value = My.Settings.NBCensorHideMin
		If My.Settings.NBCensorHideMax > 0 Then FrmSettings.NBCensorHideMax.Value = My.Settings.NBCensorHideMax

		If My.Settings.CBCensorConstant = True Then FrmSettings.CBCensorConstant.Checked = True

		HardCoreVideoTotal()
		SoftcoreVideoTotal()
		LesbianVideoTotal()
		BlowjobVideoTotal()
		FemdomVideoTotal()
		FemsubVideoTotal()
		JOIVideoTotal()
		CHVideoTotal()
		GeneralVideoTotal()

		HardcoreDVideoTotal()
		SoftcoreDVideoTotal()
		LesbianDVideoTotal()
		BlowjobDVideoTotal()
		FemdomDVideoTotal()
		FemsubDVideoTotal()
		JOIDVideoTotal()
		CHDVideoTotal()
		GeneralDVideoTotal()

		VideoType = "General"

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

		UpdatesTick = 120
		UpdatesTimer.Start()

		GlitterNC1 = "DeepPink"
		GlitterNC2 = "Green"
		GlitterNC3 = "Firebrick"

		Me.ActiveControl = Me.chatBox



		If My.Settings.GlitterSN <> "" Then FrmSettings.TBGlitterShortName.Text = My.Settings.GlitterSN
		If My.Settings.Glitter1 <> "" Then FrmSettings.TBGlitter1.Text = My.Settings.Glitter1
		If My.Settings.Glitter2 <> "" Then FrmSettings.TBGlitter2.Text = My.Settings.Glitter2
		If My.Settings.Glitter3 <> "" Then FrmSettings.TBGlitter3.Text = My.Settings.Glitter3

		If My.Settings.GlitterNCDomme <> "" Then
			GlitterNCDomme = My.Settings.GlitterNCDomme
			FrmSettings.LBLGlitterNCDomme.ForeColor = My.Settings.GlitterNCDommeColor
		End If

		If My.Settings.GlitterNC1 <> "" Then
			GlitterNC1 = My.Settings.GlitterNC1
			FrmSettings.LBLGlitterNC1.ForeColor = My.Settings.GlitterNC1Color
		End If

		If My.Settings.GlitterNC2 <> "" Then
			GlitterNC2 = My.Settings.GlitterNC2
			FrmSettings.LBLGlitterNC2.ForeColor = My.Settings.GlitterNC2Color
		End If

		If My.Settings.GlitterNC3 <> "" Then
			GlitterNC3 = My.Settings.GlitterNC3
			FrmSettings.LBLGlitterNC3.ForeColor = My.Settings.GlitterNC3Color
		End If

		If My.Settings.DomColor <> "" Then
			DomColor = My.Settings.DomColor
			FrmSettings.LBLDomColor.ForeColor = My.Settings.DomColorColor
		End If

		If My.Settings.SubColor <> "" Then
			SubColor = My.Settings.SubColor
			FrmSettings.LBLSubColor.ForeColor = My.Settings.SubColorColor
		End If

		If My.Settings.GlitterDSlider <> 0 Then FrmSettings.GlitterSlider.Value = My.Settings.GlitterDSlider
		If My.Settings.Glitter1Slider <> 0 Then FrmSettings.GlitterSlider1.Value = My.Settings.Glitter1Slider
		If My.Settings.Glitter2Slider <> 0 Then FrmSettings.GlitterSlider2.Value = My.Settings.Glitter2Slider
		If My.Settings.Glitter3Slider <> 0 Then FrmSettings.GlitterSlider3.Value = My.Settings.Glitter3Slider



		FrmSettings.CBGlitterFeed.Checked = My.Settings.CBGlitterFeed
		FrmSettings.CBGlitterFeedScripts.Checked = My.Settings.CBGlitterFeedScripts
		FrmSettings.CBGlitterFeedOff.Checked = My.Settings.CBGlitterFeedOff

		If FrmSettings.CBGlitterFeed.Checked = False And FrmSettings.CBGlitterFeedScripts.Checked = False And FrmSettings.CBGlitterFeedOff.Checked = False Then
			FrmSettings.CBGlitterFeedOff.Checked = True
		End If

		If My.Settings.CBGlitter1 = True Then
			FrmSettings.CBGlitter1.Checked = True
		Else
			FrmSettings.CBGlitter1.Checked = False
		End If
		If My.Settings.CBGlitter2 = True Then
			FrmSettings.CBGlitter2.Checked = True
		Else
			FrmSettings.CBGlitter2.Checked = False
		End If
		If My.Settings.CBGlitter3 = True Then
			FrmSettings.CBGlitter3.Checked = True
		Else
			FrmSettings.CBGlitter3.Checked = False
		End If


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


		If My.Settings.CBBoobSubDir = True Then FrmSettings.CBBoobSubDir.Checked = True
		If My.Settings.CBButtSubDir = True Then FrmSettings.CBButtSubDir.Checked = True

		FrmSettings.LBLBoobPath.Text = My.Settings.LBLBoobPath
		FrmSettings.LBLBoobURL.Text = My.Settings.LBLBoobURL
		FrmSettings.LBLButtPath.Text = My.Settings.LBLButtPath
		FrmSettings.LBLButtURL.Text = My.Settings.LBLButtURL


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

		HoldEdgeTimeTotal = My.Settings.HoldEdgeTimeTotal

		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Initializing Games window..."
		FrmSplash.Refresh()


		Try
			RefreshCards()
		Catch
		End Try

		GoldTokens = My.Settings.GoldTokens
		SilverTokens = My.Settings.SilverTokens
		BronzeTokens = My.Settings.BronzeTokens

		If My.Settings.Patch45Tokens = False Then
			BronzeTokens += 100
			My.Settings.Patch45Tokens = True
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
		End If

		If BronzeTokens < 0 Then
			BronzeTokens = 0
			My.Settings.Save()
		End If

		If SilverTokens < 0 Then
			SilverTokens = 0
			My.Settings.Save()
		End If

		If GoldTokens < 0 Then
			GoldTokens = 0
			My.Settings.Save()
		End If


		StrokePaceInt = 1
		StrokePaceRight = True
		StrokePaceTimer.Start()



		DommeMood = randomizer.Next(5, 8)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking previous orgasms..."
		FrmSplash.Refresh()

		If My.Settings.LastOrgasm = Nothing Then
			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
			My.Settings.Save()
		End If

		FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm.ToString()

		If My.Settings.LastRuined = Nothing Then
			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
			My.Settings.Save()
		End If

		FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined.ToString()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking current date..."
		FrmSplash.Refresh()

		If CompareDates(My.Settings.DateStamp) <> 0 Then

			Dim LoginChance As Integer = randomizer.Next(1, 101)
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
			BronzeTokens += LoginAmt
			SaveTokens()
		End If

		Debug.Print("Break here?")


		If CompareDates(My.Settings.WishlistDate) <> 0 Then
			My.Settings.ClearWishlist = False
			My.Settings.Save()
		End If
		Debug.Print("Test?")

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Calculating average edge information..."
		FrmSplash.Refresh()

		AvgEdgeStroking = My.Settings.AvgEdgeStroking
		AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
		AvgEdgeCount = My.Settings.AvgEdgeCount
		AvgEdgeCountRest = My.Settings.AvgEdgeCountRest



		If My.Settings.AvgEdgeCount > 4 Then
			Dim TS1 As TimeSpan = TimeSpan.FromSeconds(AvgEdgeStroking)
			FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
		Else
			FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
		End If


		If My.Settings.AvgEdgeCountRest > 4 Then
			Dim TS2 As TimeSpan = TimeSpan.FromSeconds(AvgEdgeNoTouch)
			FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
		Else
			FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
		End If

		Debug.Print("Form Load PictureStrip")
		PictureStrip.Items(0).Enabled = False
		PictureStrip.Items(1).Enabled = False
		PictureStrip.Items(2).Enabled = False
		PictureStrip.Items(3).Enabled = False
		PictureStrip.Items(4).Enabled = False
		PictureStrip.Items(5).Enabled = False

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Domme Personality..."
		FrmSplash.Refresh()

		DomPersonality = dompersonalitycombobox.Text

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

		GetContact1Pics()
		GetContact2Pics()
		GetContact3Pics()

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

		ResetFlag = True
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

		CaloriesConsumed = My.Settings.CaloriesConsumed

		If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
			' Read the given File, convert List(of String) to Array and add it to ListboxItems.
			LBCalorie.Items.AddRange(Txt2List(Application.StartupPath & "\System\VitalSub\CalorieItems.txt").ToArray)
			LBLCalorie.Text = CaloriesConsumed
		Else
			CaloriesConsumed = 0
			My.Settings.CaloriesConsumed = 0
			My.Settings.Save()
			LBLCalorie.Text = CaloriesConsumed
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

		MetroThread = New Thread(AddressOf MetronomeTick)
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
				OrgasmRestricted = False
			Else
				OrgasmRestricted = True
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

		Debug.Print("Form1 Loading Finished")

	End Sub

	Public Sub ResetButton()

		ScriptTimer.Stop()

		Dim TempDate As String
		Dim TempDateNow As DateTime = DateTime.Now

		TempDate = TempDateNow.ToString("MM.dd.yyyy hhmm")

		SaveChatLog(TempDate)

		DomTask = "@SystemMessage <b>Tease AI has been reset</b>"
		DomChat = "@SystemMessage <b>Tease AI has been reset</b>"

		StrokePace = 0

		If Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\") Then
			My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\", FileIO.DeleteDirectoryOption.DeleteAllContents)
		End If

		System.IO.Directory.CreateDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\")

		StopMetronome = True



		CBTBallsFirst = True
		CBTCockFirst = True
		CBTBothFirst = True
		CustomTaskFirst = True

		VideoType = "General"

		UpdatesTick = 120
		UpdatesTimer.Start()

		GlitterNC1 = "DeepPink"
		GlitterNC2 = "Green"
		GlitterNC3 = "Firebrick"

		Me.ActiveControl = Me.chatBox

		StrokePaceInt = 1
		StrokePaceRight = True
		StrokePaceTimer.Start()

		DommeMood = randomizer.Next(5, 8)

		Debug.Print("Reset PictureStrip")
		PictureStrip.Items(0).Enabled = False
		PictureStrip.Items(1).Enabled = False
		PictureStrip.Items(2).Enabled = False
		PictureStrip.Items(3).Enabled = False
		PictureStrip.Items(4).Enabled = False
		PictureStrip.Items(5).Enabled = False

		JustShowedBlogImage = False

		SaidHello = False
		SubWroteLast = False
		WritingTaskFlag = False

		OrgasmYesNo = False

		ShowModule = False
		BookmarkLink = False
		BookmarkModule = False
		YesOrNo = False

		StartStrokingCount = 0


		StrokeTauntVal = -1

		EdgeToRuinSecret = True








		TeaseTimer.Stop()

		DeleteVariable("SYS_StrokeRound")

		mainPictureBox.Image = Nothing
		SlideshowLoaded = False

		FrmSettings.domlevelNumBox.Value = My.Settings.DomLevel
		FrmSettings.NBEmpathy.Value = My.Settings.DomEmpathy

		' Github Patch
		BTNPlaylist.Enabled = True

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
			My.Settings.Save()
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
			My.Settings.Save()
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
			My.Settings.Save()
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
			My.Settings.Save()
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
			My.Settings.Save()
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If


		If TimeoutTimer.Enabled = True Then TimeoutTimer.Stop()

		If dompersonalitycombobox.Items.Count < 1 Then
			MessageBox.Show(Me, "No domme Personalities were found! Please install at least one Personality directory in the Scripts folder before using this part of the program.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ChatString = chatBox.Text

		If ChatString = "" Then ChatString = ChatBox2.Text

		If CBShortcuts.Checked = True Then

			If UCase(ChatString) = UCase(TBShortYes.Text) Then ChatString = "Yes " & FrmSettings.TBHonorific.Text
			If UCase(ChatString) = UCase(TBShortNo.Text) Then ChatString = "No " & FrmSettings.TBHonorific.Text
			If UCase(ChatString) = UCase(TBShortEdge.Text) Then ChatString = "On the edge"
			If UCase(ChatString) = UCase(TBShortSpeedUp.Text) Then ChatString = "Let me speed up"
			If UCase(ChatString) = UCase(TBShortSlowDown.Text) Then ChatString = "Let me slow down"
			If UCase(ChatString) = UCase(TBShortStop.Text) Then ChatString = "Let me stop"
			If UCase(ChatString) = UCase(TBShortStroke.Text) Then ChatString = "May I start stroking?"
			If UCase(ChatString) = UCase(TBShortCum.Text) Then ChatString = "Please let me cum!"
			If UCase(ChatString) = UCase(TBShortGreet.Text) Then ChatString = "Hello " & FrmSettings.TBHonorific.Text
			If UCase(ChatString) = UCase(TBShortSafeword.Text) Then ChatString = FrmSettings.TBSafeword.Text

		End If


		chatBox.Text = ""
		ChatBox2.Text = ""

		If ChatString.Substring(0, 1) = "@" Then

			If ChatString = "@" Then

				Chat = "<font face=""Cambria"" size=""2"" color=""Green"">" & Chat & ChatString.Replace("@", "") & "::: TYPO ::: <br>::: FileText = " & FileText & " ::: LineVal = " & StrokeTauntVal & "<br>::: TauntText = " & TauntText & " ::: LineVal = " & TauntTextCount & "<br>::: ResponseFile = " & ResponseFile & " ::: LineVal = " & ResponseLine & "<br></font>"
			Else
				Chat = "<font face=""Cambria"" size=""2"" color=""Green"">" & Chat & ChatString.Replace("@", "") & " :::  <br>::: FileText = " & FileText & " ::: LineVal = " & StrokeTauntVal & "<br>::: TauntText = " & TauntText & " ::: LineVal = " & TauntTextCount & "<br>::: ResponseFile = " & ResponseFile & " ::: LineVal = " & ResponseLine & "<br></font>"
			End If

			Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
			ChatText.DocumentText = Chat
			While ChatText.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ChatText2.DocumentText = Chat
			While ChatText2.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ScrollChatDown()

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
			Chat = Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
		End If

		If WritingTaskFlag = True Then GoTo WritingTaskLine

		Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

		If SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then

			Chat = "<body style=""word-wrap:break-word;"">" & Chat & "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""" & TextColor & """>" & ChatString & "<br></font></body>"
			Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
			ChatText.DocumentText = Chat
			While ChatText.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ChatText2.DocumentText = Chat
			While ChatText2.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ScrollChatDown()


		Else

			Chat = "<body style=""word-wrap:break-word;"">" & Chat & "<font face=""Cambria"" size=""3"" font color=""" &
				SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""" & TextColor & """>" & ChatString & "<br></font></body>"
			Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
			ChatText.DocumentText = Chat
			While ChatText.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ChatText2.DocumentText = Chat
			While ChatText2.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ScrollChatDown()

		End If



		ScrollChatDown()

		If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

		If IsTyping = True Then

			ChatText.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
			While ChatText.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ChatText2.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
			While ChatText2.ReadyState <> WebBrowserReadyState.Complete
				Application.DoEvents()
			End While
			ScrollChatDown()
		End If



		SubWroteLast = True




		'If frmApps.CBDebugAwareness.Checked = True Then GoTo DebugAwareness



		If SaidHello = False Then
			If UCase(ChatString).Contains("TASK") Then
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
					If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
						LoadDommeImageFolder()
					End If
					BeforeTease = True
					SaidHello = True
					SubEdging = False
					SubHoldingEdge = False
					FileText = TaskList(randomizer.Next(0, TaskList.Count))
					LockImage = False
					If SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						DommeSlideshowToolStripMenuItem.Enabled = True
					End If
					StrokeTauntVal = -1
					ScriptTick = 3
					ScriptTimer.Start()
					ShowModule = False
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

				If UCase(ChatString).Contains(UCase(SplitParts(i))) Then


					If FrmSettings.CBHonorificInclude.Checked = True Then

						If WordExists(UCase(ChatString), UCase(FrmSettings.TBHonorific.Text)) = False Then

							'If InStr(UCase(ChatString), (UCase(FrmSettings.TBHonorific.Text))) = 0 Then
							'If Not UCase(ChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
							DomChat = SplitParts(i) & " what?"
							If FrmSettings.LCaseCheckBox.Checked = False Then
								Dim DomU As String = UCase(DomChat.Substring(0, 1))
								DomChat = DomChat.Remove(0, 1)
								DomChat = DomU & DomChat
							End If
							TypingDelay()
							Return
						End If




						If FrmSettings.CBHonorificCapitalized.Checked = True Then
							If WordExists(ChatString, Capitalize(FrmSettings.TBHonorific.Text)) = False Then
								'If Not ChatString.Contains(FrmSettings.TBHonorific.Text) Then
								DomChat = "#CapitalizeHonorific"
								TypingDelay()
								Return
							End If
						End If
					End If

					Debug.Print("CHeck")

					SaidHello = True
					BeforeTease = True



					If FrmSettings.CBTeaseLengthDD.Checked = True Then


						If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60


					Else

						TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)

					End If


					TeaseTimer.Start()

					If PlaylistFile.Count = 0 Then GoTo NoPlaylistStartFile

					If Playlist = False Or PlaylistFile(0).Contains("Random Start") Then

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
								FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start_CHASTITY.txt"
							Else
								FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start.txt"
							End If
						Else
							FileText = StartList(randomizer.Next(0, StartList.Count))
						End If

					Else
						Debug.Print("Start situation found")
						If PlaylistFile(0).Contains("Regular-TeaseAI-Script") Then
							FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Start\" & PlaylistFile(0)
							FileText = FileText.Replace(" Regular-TeaseAI-Script", "")
							FileText = FileText & ".txt"
						Else
							FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Start\" & PlaylistFile(0) & ".txt"
						End If
					End If

					If Playlist = True Then PlaylistCurrent += 1
					LastScriptCountdown = randomizer.Next(3, 5 * FrmSettings.domlevelNumBox.Value)

					If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
						LoadDommeImageFolder()
					End If


					StrokeTauntVal = -1
					ScriptTick = 3
					ScriptTimer.Start()


				End If


			Next

		End If




		If SaidHello = False Then Return

		If UCase(ChatString) = UCase(FrmSettings.TBSafeword.Text) Then


			Dim SafeList As New List(Of String)

			For Each SafeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				SafeList.Add(SafeFile)
			Next

			If SafeList.Count > 0 Then
				StopEverything()
				FileText = SafeList(randomizer.Next(0, SafeList.Count))
				ShowModule = True
				StrokeTauntVal = -1
				ScriptTick = 2
				ScriptTimer.Start()
			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			Return
		End If

		If UCase(ChatString).Contains(UCase("stop")) Then TnASlides.Stop()

		' If UCase(ChatString).Contains(UCase("stop")) Then
		'If CustomSlideshow = True Then CustomSlideshowTimer.Stop()
		'End If


WritingTaskLine:

		If WritingTaskFlag = True Then


			If ChatString = LBLWritingTaskText.Text Then

				WritingTaskLinesWritten += 1
				WritingTaskLinesRemaining -= 1

				LBLLinesWritten.Text = WritingTaskLinesWritten
				LBLLinesRemaining.Text = WritingTaskLinesRemaining

				If SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then
					Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
					Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & Chat & ChatString & "<br></font>"
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

				Else
					Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
					Chat = Chat & "<font face=""Cambria"" size=""3"" font color=""" &
				SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ChatString & "<br></font>"

					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

				End If

				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				If IsTyping = True Then

					ChatText.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"

					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While

					ChatText2.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"

					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()
				End If

				chatBox.Text = ""
				ChatBox2.Text = ""

				SubWroteLast = True


				If WritingTaskLinesRemaining = 0 Then
					WritingTaskFlag = False
					chatBox.ShortcutsEnabled = True
					ChatBox2.ShortcutsEnabled = True
					ScriptTick = 3
					ScriptTimer.Start()
				End If


			Else

				If SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then

					Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & Chat & "</font><font color=""#FF0000"">" & ChatString & "<br></font>"
					Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

				Else

					Chat = Chat & "<font face=""Cambria"" size=""3"" font color=""" &
				SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#FF0000"">" & ChatString & "<br></font>"
					Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

				End If

				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				If IsTyping = True Then

					ChatText.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()
				End If

				SubWroteLast = True

				WritingTaskMistakesMade += 1
				LBLMistakesMade.Text = WritingTaskMistakesMade

				If WritingTaskMistakesMade = WritingTaskMistakesAllowed Then
					WritingTaskFlag = False
					'FrmWritingTask.Visible = False
					chatBox.ShortcutsEnabled = True
					ChatBox2.ShortcutsEnabled = True
					SkipGotoLine = True
					FileGoto = "Failed Writing Task"
					GetGoto()
					ScriptTick = 4
					ScriptTimer.Start()
				End If


			End If

		End If

		If AFK = True Then Return

		' Previous Commas





		Dim EdgeList As New List(Of String)
		EdgeList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeKEY.txt")



		Dim EdgeCheck As String = ChatString

		Dim EdgeString As String

		Debug.Print("EdgeFOund 1 = " & EdgeFound)

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
					EdgeNOT = True
					Exit For
				End If
			End If
			If UCase(EdgeString) = UCase(EdgeCheck) Then
				EdgeFound = True
				Exit For
			End If
		Next

		Debug.Print("EdgeFOund 2 = " & EdgeFound)

		If EdgeFound = True And My.Settings.Chastity = False Then



			Debug.Print("EdgeFOund = True Called")

			EdgeFound = False



			If TauntEdging = True Or TauntEdgingSession = True Then
				If TauntEdgingAsked = True Then
					DomChat = "#SYS_TauntEdgingAsked"
					TypingDelay()
				Else
					TauntEdgingAsked = True
					DomChat = "#SYS_TauntEdging"
					TypingDelay()
				End If
				Return
			End If


			If EdgeVideo = True Then
				SessionEdges += 1
				EdgeVideo = False
				TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				FileGoto = EdgeGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If

			If EdgeGoto = True Then
				SessionEdges += 1
				EdgeGoto = False
				FileGoto = EdgeGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If

			If EdgeMessage = True Then
				SessionEdges += 1
				EdgeMessage = False
				ChatString = EdgeMessageText
				GoTo DebugAwareness
			End If

			'EdgeMessageYesNo = EdgeArray(1)

			If SubHoldingEdge = True Then
				Debug.Print("EdgeFOund = SubHoldingedge")
				DomChat = " #YoureAlreadySupposedToBeClose"
				TypingDelay()
				Return
			End If

			SetVariable("SYS_EdgeTotal", Val(GetVariable("SYS_EdgeTotal") + 1))

			If RLGLGame = True Then
				Debug.Print("EdgeFOund = RLGL")
				DomChat = "#TryToHoldIt"
				TypingDelay()
				Return
			End If


			If AvoidTheEdgeStroking = True Then

				Debug.Print("EdgeFOund = ATE")

				AvoidTheEdgeTaunts.Stop()

				AvoidTheEdgeStroking = False
				VideoTease = False

				Dim ATEList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Avoid The Edge\Scripts\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					ATEList.Add(foundFile)
				Next

				If ATEList.Count < 1 Then
					MessageBox.Show(Me, "No Avoid The Edge scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If

				DomWMP.Ctlcontrols.pause()

				StrokeTauntVal = -1
				FileText = ATEList(randomizer.Next(0, ATEList.Count))

				ScriptTick = 2
				ScriptTimer.Start()
				Return
			End If


			If SubEdging = True Then

				Debug.Print("EdgeFOund = SubEdging")

				EdgeCountTimer.Stop()

				If MultipleEdges = True Then
					MultipleEdgesAmount -= 1
					SessionEdges += 1

					If MultipleEdgesAmount < 1 Then

						MultipleEdges = False

					Else

						EdgeCountTimer.Stop()
						DomChat = "#SYS_MultipleEdgesStop"
						If Contact1Edge = True Then DomChat = "@Contact1 #SYS_MultipleEdgesStop"
						If Contact2Edge = True Then DomChat = "@Contact2 #SYS_MultipleEdgesStop"
						If Contact3Edge = True Then DomChat = "@Contact3 #SYS_MultipleEdgesStop"
						TypingDelay()
						MultipleEdgesTick = MultipleEdgesInterval
						MultipleEdgesTimer.Start()
						MultipleEdgesMetronome = "STOP"
						Return

					End If


				End If

				If SubStroking = True Then
					AvgEdgeCount += 1
					If AvgEdgeStroking = 0 Then
						AvgEdgeStroking = EdgeCountTick
					Else
						AvgEdgeStroking = (AvgEdgeStroking + EdgeCountTick) / AvgEdgeCount
					End If
					My.Settings.AvgEdgeStroking = AvgEdgeStroking
					My.Settings.AvgEdgeCount = AvgEdgeCount
				Else
					AvgEdgeCountRest += 1
					If AvgEdgeNoTouch = 0 Then
						AvgEdgeNoTouch = EdgeCountTick
					Else
						AvgEdgeNoTouch = (AvgEdgeNoTouch + EdgeCountTick) / AvgEdgeCountRest
					End If
					My.Settings.AvgEdgeNoTouch = AvgEdgeNoTouch
					My.Settings.AvgEdgeCountRest = AvgEdgeCountRest
				End If

				My.Settings.Save()

				If My.Settings.AvgEdgeCount > 4 Then
					AvgEdgeStroking = My.Settings.AvgEdgeStroking
					Dim TS1 As TimeSpan = TimeSpan.FromSeconds(AvgEdgeStroking)
					FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
				Else
					FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
				End If

				If My.Settings.AvgEdgeCountRest > 4 Then
					AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
					Dim TS2 As TimeSpan = TimeSpan.FromSeconds(AvgEdgeNoTouch)
					FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
				Else
					FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
				End If

				If FrmSettings.domlevelNumBox.Value = 1 Then HoldEdgeChance = 20
				If FrmSettings.domlevelNumBox.Value = 2 Then HoldEdgeChance = 25
				If FrmSettings.domlevelNumBox.Value = 3 Then HoldEdgeChance = 30
				If FrmSettings.domlevelNumBox.Value = 4 Then HoldEdgeChance = 40
				If FrmSettings.domlevelNumBox.Value = 5 Then HoldEdgeChance = 50

				Dim HoldEdgeInt As Integer = randomizer.Next(1, 101)

				If EdgeHold = True Then HoldEdgeInt = 0
				If EdgeNoHold = True Then HoldEdgeInt = 1000


				Debug.Print("HoldEdgeInt = " & HoldEdgeInt)

				EdgeHold = False
				EdgeNoHold = False



				If HoldEdgeInt < HoldEdgeChance Then

					Debug.Print("EdgeFOund = HOldtheedge")

					DomTypeCheck = True
					SubEdging = False
					SubStroking = False
					SubHoldingEdge = True
					EdgeTauntTimer.Stop()
					DomChat = "#HoldTheEdge"
					If Contact1Edge = True Then
						DomChat = "@Contact1 #HoldTheEdge"
						' Github Patch Contact1Edge = False
					End If
					If Contact2Edge = True Then
						DomChat = "@Contact2 #HoldTheEdge"
						' github Patch Contact2Edge = False
					End If
					If Contact3Edge = True Then
						DomChat = "@Contact3 #HoldTheEdge"
						' github patch Contact3Edge = False
					End If
					TypingDelay()


					If EdgeHoldFlag = False Then

						HoldEdgeTick = HoldEdgeChance

						Dim HoldEdgeMin As Integer
						Dim HoldEdgeMax As Integer

						HoldEdgeMin = FrmSettings.NBHoldTheEdgeMin.Value
						If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

						HoldEdgeMax = FrmSettings.NBHoldTheEdgeMax.Value
						If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60


						If ExtremeHold = True Then
							HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
						End If

						If LongHold = True Then
							HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
						End If

						If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

						HoldEdgeTick = randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)

						If HoldEdgeTick < 10 Then HoldEdgeTick = 10

					Else

						HoldEdgeTick = EdgeHoldSeconds
						EdgeHoldFlag = False

					End If

					HoldEdgeTime = 0

					HoldEdgeTimer.Start()
					HoldEdgeTauntTimer.Start()
					Return

				Else

					If EdgeToRuin = True Or OrgasmRuined = True Then
						LastOrgasmType = "RUINED"
						OrgasmRuined = False
						GoTo RuinedOrgasm
					End If

					If OrgasmAllowed = True Then
						LastOrgasmType = "ALLOWED"
						OrgasmAllowed = False
						GoTo AllowedOrgasm
					End If


					Debug.Print("Ruined Orgasm skipped")

					If OrgasmDenied = True Then

						LastOrgasmType = "DENIED"

						If FrmSettings.CBDomDenialEnds.Checked = False Then

							Dim RepeatChance As Integer = randomizer.Next(0, 101)

							If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Then
								SubEdging = False
								SubStroking = False
								EdgeTauntTimer.Stop()

								Dim RepeatList As New List(Of String)

								For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
									RepeatList.Add(foundFile)
								Next

								If RepeatList.Count < 1 Then GoTo NoRepeatFiles


								If FrmSettings.CBTeaseLengthDD.Checked = True Then
									If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
									If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
									If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
									If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
									If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
								Else
									TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
								End If
								TeaseTimer.Start()

								OrgasmYesNo = False

								'Github Patch
								YesOrNo = False

								'ShowModule = True
								StrokeTauntVal = -1
								FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
								ScriptTick = 2
								ScriptTimer.Start()
								OrgasmDenied = False
								OrgasmYesNo = False
								Return
							End If

						End If


					End If

NoRepeatFiles:

					DomTypeCheck = True
					OrgasmYesNo = False
					SubEdging = False
					SubStroking = False
					EdgeTauntTimer.Stop()
					DomChat = "#StopStrokingEdge"
					If Contact1Edge = True Then
						DomChat = "@Contact1 #StopStrokingEdge"
						Contact1Edge = False
					End If
					If Contact2Edge = True Then
						DomChat = "@Contact2 #StopStrokingEdge"
						Contact2Edge = False
					End If
					If Contact3Edge = True Then
						DomChat = "@Contact3 #StopStrokingEdge"
						Contact3Edge = False
					End If
					TypingDelay()
					Return

				End If

RuinedOrgasm:

				My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
				My.Settings.Save()
				FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

				If FrmSettings.CBDomOrgasmEnds.Checked = False And OrgasmRuined = True Then

					Dim RepeatChance As Integer = randomizer.Next(0, 101)

					If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Then

						SubEdging = False
						SubStroking = False
						EdgeToRuin = False
						EdgeToRuinSecret = True
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
						Else
							TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						OrgasmYesNo = False

						'Github Patch
						YesOrNo = False

						'ShowModule = True
						StrokeTauntVal = -1
						FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
						ScriptTick = 2
						ScriptTimer.Start()
						OrgasmRuined = False
						OrgasmYesNo = False
						Return
					End If

				End If



NoRepeatRFiles:


				DomTypeCheck = True
				SubEdging = False
				SubStroking = False
				EdgeToRuin = False
				EdgeToRuinSecret = True
				EdgeTauntTimer.Stop()
				OrgasmYesNo = False
				DomChat = "#RuinYourOrgasm"
				If Contact1Edge = True Then
					DomChat = "@Contact1 #RuinYourOrgasm"
					Contact1Edge = False
				End If
				If Contact2Edge = True Then
					DomChat = "@Contact2 #RuinYourOrgasm"
					Contact2Edge = False
				End If
				If Contact3Edge = True Then
					DomChat = "@Contact3 #RuinYourOrgasm"
					Contact3Edge = False
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


						SubEdging = False
						SubStroking = False
						EdgeTauntTimer.Stop()
						OrgasmYesNo = False

						'Github Patch
						YesOrNo = False

						'ShowModule = True
						StrokeTauntVal = -1
						FileText = NoCumList(randomizer.Next(0, NoCumList.Count))
						ScriptTick = 2
						ScriptTimer.Start()
						Return
					End If


					My.Settings.OrgasmsRemaining -= 1

					My.Settings.Save()

				End If

NoNoCumFiles:

				My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
				My.Settings.Save()
				FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

				If FrmSettings.CBDomOrgasmEnds.Checked = False Then

					Dim RepeatChance As Integer = randomizer.Next(0, 101)

					If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Then
						SubEdging = False
						SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
						Else
							TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						OrgasmYesNo = False

						'Github Patch
						YesOrNo = False

						'ShowModule = True
						StrokeTauntVal = -1
						FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
						ScriptTick = 2
						ScriptTimer.Start()
						OrgasmAllowed = False
						OrgasmYesNo = False
						Return
					End If

				End If



NoRepeatOFiles:








				DomTypeCheck = True
				SubEdging = False
				SubStroking = False
				'OrgasmAllowed = False
				EdgeTauntTimer.Stop()
				OrgasmYesNo = False
				DomChat = "#CumForMe"
				If Contact1Edge = True Then
					DomChat = "@Contact1 #CumForMe"
					Contact1Edge = False
				End If
				If Contact2Edge = True Then
					DomChat = "@Contact2 #CumForMe"
					Contact2Edge = False
				End If
				If Contact3Edge = True Then
					DomChat = "@Contact3 #CumForMe"
					Contact3Edge = False
				End If
				TypingDelay()
				Return


			End If



			If SubStroking = True Then

				Dim TauntStop As Integer = randomizer.Next(1, 101)

				If TauntStop <= FrmSettings.NBTauntEdging.Value Then

					FirstRound = False
					'ShowModule = True
					StrokeTauntTimer.Stop()
					StrokeTimer.Stop()


					If BookmarkModule = True Then
						DomTypeCheck = True
						SubEdging = False
						SubStroking = False
						DomChat = "#StopStrokingEdge"
						If Contact1Edge = True Then
							DomChat = "@Contact1 #StopStrokingEdge"
							Contact1Edge = False
						End If
						If Contact2Edge = True Then
							DomChat = "@Contact2 #StopStrokingEdge"
							Contact2Edge = False
						End If
						If Contact3Edge = True Then
							DomChat = "@Contact3 #StopStrokingEdge"
							Contact3Edge = False
						End If
						TypingDelay()

						Do
							Application.DoEvents()
						Loop Until DomTypeCheck = False

						BookmarkModule = False
						FileText = BookmarkModuleFile
						StrokeTauntVal = BookmarkModuleLine
						RunFileText()
						Return
					End If

					RunModuleScript(True)

				Else

					TauntEdging = True
					TauntEdgingAsked = True

					DomChat = "#SYS_TauntEdging"
					TypingDelay()


				End If



			End If


			Return

		End If


		If EdgeFound = True And My.Settings.Chastity = True Then
			EdgeFound = False
			EdgeNOT = True
		End If






DebugAwareness:



		If InputFlag = True And DomTypeCheck = False Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & InputString, ChatString, False)
			InputFlag = False
		End If

		' Remove commas and apostrophes from user's entered text
		ChatString = ChatString.Replace(",", "")
		ChatString = ChatString.Replace("'", "")
		ChatString = ChatString.Replace(".", "")


		If UCase(ChatString) = UCase("CAME") Or UCase(ChatString) = UCase("I CAME") Or UCase(ChatString) = UCase("JUST CAME") Or UCase(ChatString) = UCase("I JUST CAME") Then
			If CameMessage = True Then
				CameMessage = False
				ChatString = CameMessageText
			End If
		End If

		If UCase(ChatString) = UCase("RUINED") Or UCase(ChatString) = UCase("I RUINED") Or UCase(ChatString) = UCase("RUINED IT") Or UCase(ChatString) = UCase("I RUINED IT") Then
			If RuinedMessage = True Then
				RuinedMessage = False
				ChatString = RuinedMessageText
			End If
		End If


		' If the domme is waiting for a response, go straight to this sub-routine instead
		If YesOrNo = True And SubEdging = True Then GoTo EdgeSkip
		If YesOrNo = True And SubHoldingEdge = True Then GoTo EdgeSkip

		If YesOrNo = True And OrgasmYesNo = False And DomTypeCheck = False Then
			YesOrNoQuestions()
			Return
		End If



EdgeSkip:

		Debug.Print("Before Dom Response, YesOrNo = " & YesOrNo)

		DomResponse()

		'CalculateResponse()

	End Sub

	Public Sub DomResponse()

		Debug.Print("DomResponse Called")


		If EdgeNOT = True Then
			EdgeNOT = False
			ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeNOT.txt")
			GoTo FoundResponse
		End If





		'If BeforeTease = True And CBDebugAwareness.Checked = False Then Return

		Dim CheckResponse As String = UCase(ChatString)
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
			If CameGoto = True Then
				CameGoto = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					YesOrNo = False
					InputFlag = False
				End If
				FileGoto = CameGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If
			If CameVideo = True Then
				CameVideo = False
				TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				FileGoto = CameGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If


		If UCase(CheckResponse) = UCase("RUINED") Or UCase(CheckResponse) = UCase("I RUINED") Or UCase(CheckResponse) = UCase("RUINED IT") Or UCase(CheckResponse) = UCase("I RUINED IT") Then
			If RuinedGoto = True Then
				RuinedGoto = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					YesOrNo = False
					InputFlag = False
				End If
				FileGoto = RuinedGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If
			If RuinedVideo = True Then
				RuinedVideo = False
				TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				FileGoto = RuinedGotoLine
				SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If




		ResponseFile = ""

		Dim YesSplit As String = FrmSettings.TBYes.Text

		Do
			YesSplit = YesSplit.Replace("  ", " ")
			YesSplit = YesSplit.Replace(" ,", ",")
			YesSplit = YesSplit.Replace(", ", ",")
			YesSplit = YesSplit.Replace("'", "")
		Loop Until Not YesSplit.Contains("  ") And Not YesSplit.Contains(", ") And Not YesSplit.Contains(" ,") And Not YesSplit.Contains("'")

		If YesGoto = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					YesGoto = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						YesOrNo = False
						InputFlag = False
					End If
					FileGoto = YesGotoLine
					SkipGotoLine = True
					GetGoto()
				End If
			Next
			If YesGoto = False Then Return
		End If

		If YesVideo = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					YesVideo = False
					TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					FileGoto = YesGotoLine
					SkipGotoLine = True
					GetGoto()
				End If
			Next
			If YesVideo = False Then Return
		End If

		If ResponseYes <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponseYes & ".txt") Then

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
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponseYes & ".txt"
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

		If NoGoto = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					NoGoto = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						YesOrNo = False
						InputFlag = False
					End If
					FileGoto = NoGotoLine
					SkipGotoLine = True
					GetGoto()
				End If
			Next
			If NoGoto = False Then Return
		End If

		If NoVideo_Mode = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					NoVideo_Mode = False
					TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					FileGoto = NoGotoLine
					SkipGotoLine = True
					GetGoto()
				End If
			Next
			If NoVideo_Mode = False Then Return
		End If

		If ResponseNo <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponseNo & ".txt") Then

			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponseNo & ".txt"
					GoTo FoundResponse
					Exit For
				End If
			Next
		End If

		If BeforeTease = False Then
			If UCase(CheckResponse).Contains(UCase("I cum")) Or UCase(CheckResponse).Contains(UCase("me cum")) Or UCase(CheckResponse).Contains(UCase("I have an orgasm")) _
			 Or UCase(CheckResponse).Contains(UCase("me have an orgasm")) Then
				If TeaseTick > 0 Then
					ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\BegToCum.txt")
					If My.Settings.Chastity = False And OrgasmRestricted = False Then TeaseTick = TeaseTick / 2
					Debug.Print("LastScriptCountdown = " & LastScriptCountdown)
					If TeaseTick < 1 And Playlist = False And OrgasmRestricted = False Then
						StrokeTimer.Stop()
						StrokeTauntTimer.Stop()
						EdgeTauntTimer.Stop()
						SubStroking = False
						SubEdging = False
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


				DebugAwarenessLine = "Domme does not recognize this statement"

				For i As Integer = 0 To SysKeyList.Count - 1

					SysKeyList(i) = SysKeyList(i).Replace(",", "")
					SysKeyList(i) = SysKeyList(i).Replace("'", "")
					SysKeyList(i) = SysKeyList(i).Replace("!", "")
					SysKeyList(i) = SysKeyList(i).Replace("?", "")
					SysKeyList(i) = SysKeyList(i).Replace(".", "")
					SysKeyList(i) = SysKeyList(i).Replace("*", "")
					SysKeyList(i) = SysKeyList(i).Replace("  ", " ")

					If UCase(CheckResponse) = UCase(SysKeyList(i)) Then
						ResponseFile = foundFile
						ResponseFile = ResponseFile.Replace("KEY", "")
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ResponseFile = ResponseFile.Replace(".txt", "NOT.txt")
						' Read the first line of the given file.
						DebugAwarenessLine = TxtReadLine(ResponseFile)
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
					ResponseFile = foundFile
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
						ResponseFile = foundFile
						ResponseFile = ResponseFile.Replace("KEY", "")
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ResponseFile = ResponseFile.Replace(".txt", "NOT.txt")
						' Read the first line of the given file.
						DebugAwarenessLine = TxtReadLine(ResponseFile)
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
						ResponseFile = foundFile
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
					ResponseFile = foundFile
					If Not UCase(CheckResponse).Contains(CheckResponseArray(j)) Then
						ResponseFile = ""
						Exit For
					End If
				Next

				If ResponseFile <> "" Then GoTo FoundResponse

			Next

		Next



		If CBTCockFlag = True Or CBTBallsFlag = True Or CBTBothFlag = True Or CustomTask = True Then
			Dim CBTStop As Integer = randomizer.Next(1, 101)
			If CBTStop < 30 Then
				CBTCockFlag = False
				CBTBallsFlag = False
				CBTBothFlag = False
				CustomTask = False
				CBTBallsFirst = True
				CBTCockFirst = True
				CBTBothFirst = True
				CustomTaskFirst = True
				ScriptTick = 3
				ScriptTimer.Start()
			End If
		End If

		If CBTCockFlag = True Then
			CBTCock()
		End If

		If CBTBallsFlag = True Then
			CBTBalls()
		End If

		If CBTBothFlag = True Then
			CBTBoth()
		End If

		If CustomTask = True Then
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
			TempScriptCount = 0
			If FrmSettings.SliderSTF.Value = 1 Then StrokeTauntTick = randomizer.Next(120, 241)
			If FrmSettings.SliderSTF.Value = 2 Then StrokeTauntTick = randomizer.Next(75, 121)
			If FrmSettings.SliderSTF.Value = 3 Then StrokeTauntTick = randomizer.Next(45, 76)
			If FrmSettings.SliderSTF.Value = 4 Then StrokeTauntTick = randomizer.Next(25, 46)
			If FrmSettings.SliderSTF.Value = 5 Then StrokeTauntTick = randomizer.Next(15, 26)
		End If

		DomChat = ResponseClean(DomChat)

		If DomChat = "NULL" Then
			DomChat = ""
			Return
		End If

		'Debug.Print("DoNotDisturb = " & DoNotDisturb)
		'Debug.Print("DomChat = " & DomChat)

		If DoNotDisturb = True Then
			If DomChat.Contains("@Interrupt") Or DomChat.Contains("@Call(") Or DomChat.Contains("@CallRandom(") Then
				DomChat = "#SYS_InterruptsOff"
			End If
		End If




		TypingDelay()


	End Sub

	Public Function ResponseClean(ByVal CleanResponse As String) As String

		'TODO: Add Errorhandling.
		Dim DomResponse As New StreamReader(ResponseFile)
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

		If BeforeTease = True Then
			SubState = "Before Tease"
			GoTo FoundState
		End If

		If FirstRound = True Then
			SubState = "First Round"
			GoTo FoundState
		End If

		If EndTease = True Then
			SubState = "After Tease"
			GoTo FoundState
		End If

		If CBTCockFlag = True Then
			SubState = "CBT Cock"
			GoTo FoundState
		End If

		If CBTBallsFlag = True Or CBTBothFlag = True Then
			SubState = "CBT Balls"
			GoTo FoundState
		End If

		If SubHoldingEdge = True Then
			SubState = "Sub Holding Edge"
			GoTo FoundState
		End If

		If SubEdging = True Then
			SubState = "Sub Edging"
			GoTo FoundState
		End If

		If SubStroking = True Then
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


		Dim DomResponseAll As New StreamReader(ResponseFile)

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

		DomResponseAll.Close()
		DomResponseAll.Dispose()

		' ###########

		If DRLines.Count < 1 Then
			CleanResponse = "NULL"
			GoTo NullSkip
		End If



		Try
			DRLines = FilterList(DRLines)
			ResponseLine = randomizer.Next(0, DRLines.Count)
			CleanResponse = DRLines(ResponseLine)
		Catch
			CleanResponse = "ERROR: Tease AI did not return a valid Response line"
		End Try


		Responding = True

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

		TempChatString = UCase(ChatString)

		If CBT = True Then
			If InStr(UCase(TempChatString), UCase("done")) <> 0 Or InStr(UCase(TempChatString), UCase("finish")) <> 0 Then
				YesOrNo = False
				CBT = False
				Return
			Else
				DomChat = "Hurry up and tell me when you're done"
				TypingDelay()
				Return
			End If
		End If

		Dim dir As String

		If MiniScript = True Then
			dir = MiniScriptText
		Else
			dir = FileText
		End If



		Dim AcceptLine As Integer

		' Read all lines of File
		Dim lines As List(Of String) = Txt2List(dir)
		Dim line As Integer

		If MiniScript = True Then
			line = MiniTauntVal
		Else
			line = StrokeTauntVal
		End If

		AcceptLine = 0

		Dim TempLineVal As Integer
		Do
			line += 1
			AcceptLine += 1
		Loop Until InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0


		TempLineVal = line

		If MiniScript = True Then
			line = MiniTauntVal
		Else
			line = StrokeTauntVal
		End If

		Dim CheckLines As String


		Do
			line += 1

			CheckLines = lines(line)


			CheckYes = False
			CheckNo = False

			If UCase(CheckLines).Contains(UCase("[yes]")) Then CheckYes = True
			If UCase(CheckLines).Contains(UCase("[no]")) Then CheckNo = True


			Dim Splits As String() = CheckLines.Split(New Char() {"]"c})
			Splits(0) = Splits(0).Replace("[", "")

			Dim ChatReplace As String = CheckLines.Replace("[" & Splits(0) & "]", "")

			If CheckYes = True Then Splits(0) = FrmSettings.TBYes.Text
			If CheckNo = True Then Splits(0) = FrmSettings.TBNo.Text



			Do
				Splits(0) = Splits(0).Replace("  ", " ")
				Splits(0) = Splits(0).Replace(" ,", ",")
				Splits(0) = Splits(0).Replace(", ", ",")
				Splits(0) = Splits(0).Replace("'", "")
			Loop Until Not Splits(0).Contains("  ") And Not Splits(0).Contains(", ") And Not Splits(0).Contains(" ,") And Not Splits(0).Contains("'")

			Dim SplitParts As String() = Splits(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1

				If UCase(TempChatString) = (UCase(SplitParts(i))) Then

					If CheckYes = True Or CheckNo = True Then
						If FrmSettings.CBHonorificInclude.Checked = True Then
							If Not UCase(TempChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
								DomChat = SplitParts(i) & " what?"
								If FrmSettings.LCaseCheckBox.Checked = False Then
									Dim DomU As String = UCase(DomChat.Substring(0, 1))
									DomChat = DomChat.Remove(0, 1)
									DomChat = DomU & DomChat
								End If
								TypingDelay()
								Return
							End If
							If FrmSettings.CBHonorificCapitalized.Checked = True Then
								If Not ChatString.Contains(FrmSettings.TBHonorific.Text) Then
									DomChat = "#DomHonorific"
									TypingDelay()
									Return
								End If
							End If
						End If
					End If

					'Splits(0) = ""
					'DomChat = Join(Splits, "]")
					DomChat = ChatReplace

					' DomChat = Splits(1)
					GoTo FoundAnswer
				End If
			Next

		Loop Until InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0

		If MiniScript = True Then
			line = MiniTauntVal
		Else
			line = StrokeTauntVal
		End If

		Do
			line += 1

			CheckLines = lines(line)

			CheckYes = False
			CheckNo = False

			If UCase(CheckLines).Contains(UCase("[yes]")) Then CheckYes = True
			If UCase(CheckLines).Contains(UCase("[no]")) Then CheckNo = True



			Dim Splits As String() = CheckLines.Split(New Char() {"]"c})
			Splits(0) = Splits(0).Replace("[", "")

			Dim ChatReplace As String = CheckLines.Replace("[" & Splits(0) & "]", "")

			If CheckYes = True Then Splits(0) = FrmSettings.TBYes.Text
			If CheckNo = True Then Splits(0) = FrmSettings.TBNo.Text

			Do
				Splits(0) = Splits(0).Replace("  ", " ")
				Splits(0) = Splits(0).Replace(" ,", ",")
				Splits(0) = Splits(0).Replace(", ", ",")
				Splits(0) = Splits(0).Replace("'", "")
			Loop Until Not Splits(0).Contains("  ") And Not Splits(0).Contains(", ") And Not Splits(0).Contains(" ,") And Not Splits(0).Contains("'")

			Dim SplitParts As String() = Splits(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1


				If UCase(TempChatString).Contains(UCase(SplitParts(i))) Then

					If CheckYes = True Or CheckNo = True Then
						If FrmSettings.CBHonorificInclude.Checked = True Then
							If Not UCase(TempChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
								DomChat = SplitParts(i) & " what?"
								If FrmSettings.LCaseCheckBox.Checked = False Then
									Dim DomU As String = UCase(DomChat.Substring(0, 1))
									DomChat = DomChat.Remove(0, 1)
									DomChat = DomU & DomChat
								End If
								TypingDelay()
								Return
							End If
							If FrmSettings.CBHonorificCapitalized.Checked = True Then
								If Not ChatString.Contains(FrmSettings.TBHonorific.Text) Then
									DomChat = "#CapitalizeHonorific"
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

					DomChat = ChatReplace

					'DomChat = Splits(1)
					GoTo FoundAnswer
				End If
			Next

		Loop Until InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0

		GoTo NothingFound

FoundAnswer:

		If DomChat.Contains("@NullResponse") Then NullResponse = True
		If DomChat.Contains("@LoopAnswer") Then GoTo LoopAnswer

		YesOrNo = False
		YesOrNoLanguageCheck()



		If MiniScript = True Then
			If GotoFlag = False Then MiniTauntVal = TempLineVal
		Else
			If GotoFlag = False Then StrokeTauntVal = TempLineVal
		End If

		TypingDelay()

		Return


NothingFound:

		If InStr(UCase(lines(line)), UCase("DifferentAnswer")) <> 0 Then

DifferentAnswer:
			DomChat = lines(line)
			DomChat = DomChat.Replace("@DifferentAnswer ", "")

LoopAnswer:
			DomChat = DomChat.Replace("@LoopAnswer", "")
			' CleanParse()
			TypingDelay()
			Return
		End If


		If InStr(UCase(lines(line)), UCase("AcceptAnswer")) <> 0 Then
AcceptAnswer:
			DomChat = lines(TempLineVal)
			' TimedAnswerTimer.Stop()

			DomChat = DomChat.Replace("@AcceptAnswer ", "")
			ScriptTimer.Start()
			YesOrNo = False

			YesOrNoLanguageCheck()

			If GotoFlag = False Then


				If MiniScript = True Then
					MiniTauntVal = TempLineVal
				Else
					StrokeTauntVal = TempLineVal
				End If

			End If
			TypingDelay()
			Return
		End If



	End Sub

	Public Sub YesOrNoLanguageCheck()


		If InStr(UCase(DomChat), UCase("@Goto(")) <> 0 Then
			GetGotoChat()
		End If

	End Sub

	Public Sub GetGotoChat()



		GotoFlag = True

		'DomTypeCheck = True

		'Debug.Print("GetGotoChat() Chat FileText = " & FileText)


		If InStr(UCase(DomChat), UCase("@Goto")) <> 0 Then

			DomTypeCheck = True

			Dim TempGoto As String = DomChat & " some garbage"
			Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
			TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
			TempGoto = TempGoto.Split(")")(0)
			FileGoto = TempGoto

			Dim StripGoto As String = FileGoto

			If TempGoto.Contains(",") Then
				TempGoto = TempGoto.Replace(", ", ",")
				Dim GotoSplit As String() = TempGoto.Split(",")
				Dim GotoTemp As Integer = randomizer.Next(0, GotoSplit.Count)
				FileGoto = GotoSplit(GotoTemp)
			End If

			Dim GotoText As String

			If MiniScript = True Then
				GotoText = MiniScriptText
			Else
				GotoText = FileText
			End If

			If File.Exists(GotoText) Then
				' Read all lines of File
				Dim gotolines As List(Of String) = Txt2List(GotoText)
				Dim gotoline As Integer

				If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
				If FileGoto.Substring(0, 1) <> "(" Then FileGoto = "(" & FileGoto & ")"
				Debug.Print(FileGoto)

				DomChat = DomChat.Replace("@Goto" & StripGoto, "")
				Do
					gotoline += 1

					Debug.Print("FileGoto = " & FileGoto)
					Debug.Print("GotoLine = " & gotolines(gotoline))

					'github patch begin
					'Loop Until InStr(gotolines(gotoline), FileGoto) <> 0 And InStr(gotolines(gotoline), "@Goto") = 0 And InStr(gotolines(gotoline), "@CheckFlag") = 0 _
					'And InStr(gotolines(gotoline), "@SetFlag") = 0 And InStr(gotolines(gotoline), "@TempFlag") = 0 And InStr(gotolines(gotoline), "@Chance") = 0 And InStr(gotolines(gotoline), "@GotoDommeLevel") = 0 _
					'And InStr(gotolines(gotoline), "Then(") = 0 And InStr(gotolines(gotoline), "@GoodMood(") = 0 And InStr(gotolines(gotoline), "@BadMood(") = 0 And InStr(gotolines(gotoline), "@NeutralMood(") = 0
					'github patch end

				Loop Until gotolines(gotoline).StartsWith(FileGoto) And InStr(gotolines(gotoline), "@Goto") = 0 And InStr(gotolines(gotoline), "@CheckFlag") = 0 And InStr(gotolines(gotoline), "@TempFlag") = 0 _
				And InStr(gotolines(gotoline), "@SetFlag") = 0 And InStr(gotolines(gotoline), "@Chance") = 0 And InStr(gotolines(gotoline), "@GotoDommeLevel") = 0 _
				And InStr(gotolines(gotoline), "Then(") = 0 And InStr(gotolines(gotoline), "@GoodMood(") = 0 And InStr(gotolines(gotoline), "@BadMood(") = 0 And InStr(gotolines(gotoline), "@NeutralMood(") = 0 'And InStr(gotolines(gotoline), "@GotoDommeApathy") = 0


				'Debug.Print("GetGotoChat() Final gotolines(gotoline) = " & (gotolines(gotoline)))

				'If ShowThought = True Or ShowEdgeThought = True Then
				StrokeTauntVal = gotoline

				If MiniScript = True Then
					MiniTauntVal = gotoline
				Else
					StrokeTauntVal = gotoline
				End If
				'ThoughtTauntVal = gotoline
				'Else
				'   If ShowModule = True Then
				'ModuleTauntVal = gotoline
				'Else
				'   StrokeTauntVal = gotoline
				'End If
				'End If



				'Debug.Print("GetGotoChat() StrokeTauntVal = " & StrokeTauntVal)


			End If

		End If


	End Sub


	Public Sub ScriptTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles ScriptTimer.Tick

		FrmSettings.LBLDebugScriptTime.Text = ScriptTick
		'Debug.Print("ScriptTick = " & ScriptTick)

		If DomTyping = True Then Return
		If YesOrNo = True Then Return

		'If ChatText.IsBusy Then Return

		If WaitTimer.Enabled = True Or DomTypeCheck = True Then Return

		'Debug.Print("ScriptTimer Substroking = " & SubStroking)
		'Debug.Print("ScriptTimer StrokePaceTimer = " & StrokePaceTimer.Enabled)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If playingStatus() Then
			If ScriptTick < 4 Then Return
		End If


		If DomTypeCheck = True And ScriptTick < 4 Then Return
		If chatBox.Text <> "" And ScriptTick < 4 Then Return
		If ChatBox2.Text <> "" And ScriptTick < 4 Then Return


		ScriptTick -= 1
		' Debug.Print("ScriptTick = " & ScriptTick)
		If ScriptTick < 1 Then



			ScriptTick = randomizer.Next(4, 7)

			RunFileText()


		End If




	End Sub

	Public Sub CBTBalls()
		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If CBTBallsFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			CBTBallsCount += 1
		End If

		' Read all Lines of the given File.
		Dim BallList As List(Of String) = Txt2List(File2Read)

		Try
			BallList = FilterList(BallList)
			DomTask = BallList(randomizer.Next(0, BallList.Count))
		Catch
			DomTask = "ERROR: Tease AI did not return a valid @CBTBalls line"
		End Try

		CBTBallsFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTCock()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If CBTCockFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim CockList As List(Of String) = Txt2List(File2Read)

		Try
			CockList = FilterList(CockList)
			DomTask = CockList(randomizer.Next(0, CockList.Count))
		Catch
			DomTask = "ERROR: Tease AI did not return a valid @CBTCock line"
		End Try

		CBTCockFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTBoth()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			CBTBallsCount += 1
			CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim BothList As List(Of String) = Txt2List(File2Read)

		File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			CBTBallsCount += 1
			CBTCockCount += 1
		End If

		' Read all Lines of the given file and append to List.
		BothList.AddRange(Txt2List(File2Read))

		Try
			BothList = FilterList(BothList)
			DomTask = BothList(randomizer.Next(0, BothList.Count))
		Catch
			DomTask = "ERROR: Tease AI did not return a valid @CBT line"
		End Try

		CBTBothFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub RunCustomTask()

		Dim File2Read As String = CustomTaskTextFirst

		If CustomTaskFirst = False Then
			File2Read = CustomTaskText
		End If

		' Read all Lines of the given File.
		Dim CustomList As List(Of String) = Txt2List(File2Read)

		Try
			CustomList = FilterList(CustomList)
			DomTask = CustomList(randomizer.Next(0, CustomList.Count))
		Catch
			DomTask = "ERROR: Tease AI did not return a valid Custom Task line"
		End Try

		CustomTaskFirst = False

		TypingDelayGeneric()

	End Sub


	Public Sub RunFileText()


		'Debug.Print("ReturnFlag = " & ReturnFlag)

		'If ReturnFlag = True Then GoTo ReturnCalled

		Debug.Print("SaidHello = " & SaidHello)
		If SaidHello = False Then Return

		'Debug.Print("TeaseOver = " & TeaseOver)
		If TeaseOver = True Then Return

		'Debug.Print("CBTCockFlag = " & CBTCockFlag)
		'Debug.Print("CBTBallsFlag = " & CBTBallsFlag)
		If CBTCockFlag = True Or CBTBallsFlag = True Or CBTBothFlag = True Or CustomTask = True Then Return

		'Debug.Print("WritingTaskFlag = " & WritingTaskFlag)
		If WritingTaskFlag = True Then Return

		'Debug.Print("TeaseVideo = " & TeaseVideo)
		If TeaseVideo = True Then Return


		'If SearchImageBlog = True Then Return

		If RiskyDelay = True Then Return

		If InputFlag = True Then Return

		If MiniScript = True Then GoTo ReturnCalled

		If CensorshipGame = True Or RLGLGame = True Or AvoidTheEdgeStroking = True Or SubEdging = True Or SubHoldingEdge = True Then Return

		If MultipleEdges = True Then Return

		'Debug.Print("RunFileText " & StrokeTauntVal)

ReturnCalled:

		Dim lines As New List(Of String)

		If MiniScript = True Then
			MiniTauntVal += 1
			lines = Txt2List(MiniScriptText)
			Try
				If MiniTauntVal < lines.Count Then
					If lines(MiniTauntVal).Substring(0, 1) = "(" Then
						Do
							MiniTauntVal += 1
						Loop Until lines(MiniTauntVal).Substring(0, 1) <> "("
					End If
				End If
			Catch
			End Try

		Else
			StrokeTauntVal += 1
			lines = Txt2List(FileText)
			Try
				If StrokeTauntVal < lines.Count - 1 Then
					If lines(StrokeTauntVal).Substring(0, 1) = "(" Then
						Do
							StrokeTauntVal += 1
						Loop Until lines(StrokeTauntVal).Substring(0, 1) <> "("
					End If
				End If
			Catch
			End Try

		End If





		Try
			If RunningScript = False And AvoidTheEdgeGame = False And ReturnFlag = False Then
				Debug.Print("End Check StrokeTauntVal = " & StrokeTauntVal)


				If MiniScript = True Then
					If lines(MiniTauntVal) = "@End" Then
						MiniScript = False
						If MiniTimerCheck = True Then
							ScriptTick = 3
							ScriptTimer.Start()
						Else
							ScriptTimer.Stop()
						End If
						Return
					End If
				Else
					If Not StrokeTauntVal > lines.Count - 1 Then
						If lines(StrokeTauntVal) = "@End" Then
							If ShowModule = True Then ModuleEnd = True
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


		If ModuleEnd = True And AvoidTheEdgeGame = False Then
			Debug.Print("Module End Called?")
			ScriptTimer.Stop()
			ModuleEnd = False
			ShowModule = False

			'DelayFlag = True
			'DelayTick = randomizer.Next(3, 6)

			'DelayTimer.Start()

			'Do
			'Application.DoEvents()
			'Loop Until DelayFlag = False

			'LastScriptCountdown -= 1
			'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

			If Playlist = True Then
				Debug.Print("Playlist True - StrokeTimer")
				If PlaylistCurrent = PlaylistFile.Count - 1 Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			Else
				If TeaseTick < 1 And BookmarkModule = False Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			End If
			Return
		End If

		If StrokeTimer.Enabled = True And MiniScript = False Then Return

		'If ShowThought = False And ShowEdgeThought = False And ShowModule = False Then HandleScriptText = FileText
		'If ShowThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\Thoughts.txt")
		'If ShowEdgeThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\EdgeThoughts.txt")
		'If ShowModule = True Then HandleScriptText = ModText

		Debug.Print("CHeck")

		Debug.Print(FileText)

		Dim InvalidFilter As Boolean = False

		Dim CheckText As String

		If MiniScript = True Then
			CheckText = MiniScriptText
		Else
			CheckText = FileText
		End If

		'If File.Exists(HandleScriptText) Then
		If File.Exists(CheckText) Then
			'Debug.Print(StrokeTauntVal)
			'Dim ioFile As New StreamReader(HandleScriptText)
			Dim lines As List(Of String) = Txt2List(CheckText)
			Dim line As Integer

			'line = ScriptLineVal

			If MiniScript = True Then
				line = MiniTauntVal
			Else
				line = StrokeTauntVal
			End If



			Debug.Print("CHeck")

			If lines(line).Contains("@CockSmall") And FrmSettings.CockSizeNumBox.Value >= FrmSettings.NBAvgCockMin.Value Then InvalidFilter = True
			If lines(line).Contains("@CockLarge") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then InvalidFilter = True
			If lines(line).Contains("@CockAverage") Then
				If FrmSettings.CockSizeNumBox.Value < FrmSettings.NBAvgCockMin.Value Or FrmSettings.CockSizeNumBox.Value > FrmSettings.NBAvgCockMax.Value Then InvalidFilter = True
			End If

			If lines(line).Contains("@Crazy") And FrmSettings.crazyCheckBox.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@Vulgar") And FrmSettings.vulgarCheckBox.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@Supremacist") And FrmSettings.supremacistCheckBox.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@Sadistic") And FrmSettings.sadisticCheckBox.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@Degrading") And FrmSettings.degradingCheckBox.Checked = False Then InvalidFilter = True

			If lines(line).Contains("@AlwaysAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text <> "Always Allows" Then InvalidFilter = True
			If lines(line).Contains("@OftenAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text <> "Often Allows" Then InvalidFilter = True
			If lines(line).Contains("@SometimesAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text <> "Sometimes Allows" Then InvalidFilter = True
			If lines(line).Contains("@RarelyAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text <> "Rarely Allows" Then InvalidFilter = True
			If lines(line).Contains("@NeverAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text <> "Never Allows" Then InvalidFilter = True

			If lines(line).Contains("@AlwaysRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Always Ruins" Then InvalidFilter = True
			If lines(line).Contains("@OftenRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Often Ruins" Then InvalidFilter = True
			If lines(line).Contains("@SometimesRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Sometimes Ruins" Then InvalidFilter = True
			If lines(line).Contains("@RarelyRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Rarely Ruins" Then InvalidFilter = True
			If lines(line).Contains("@NeverRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Never Ruins" Then InvalidFilter = True

			If lines(line).Contains("@NotAlwaysAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then InvalidFilter = True
			If lines(line).Contains("@NotNeverAllowsOrgasm") And FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then InvalidFilter = True
			If lines(line).Contains("@NotAlwaysRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then InvalidFilter = True
			If lines(line).Contains("@NotNeverRuinsOrgasm") And FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then InvalidFilter = True

			If lines(line).Contains("@AllowsOrgasm(") Then
				If FilterCheck(GetParentheses(lines(line), "@AllowsOrgasm("), FrmSettings.alloworgasmComboBox) = False Then InvalidFilter = True
				'If GetOrgasmChance(GetParentheses(lines(line), "@AllowsOrgasm(")) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@RuinsOrgasm(") Then
				If FilterCheck(GetParentheses(lines(line), "@RuinsOrgasm("), FrmSettings.ruinorgasmComboBox) = False Then InvalidFilter = True
				'If GetRuinChance(GetParentheses(lines(line), "@RuinsOrgasm(")) = False Then InvalidFilter = True
			End If


			If lines(line).Contains("@DommeLevel1") And FrmSettings.domlevelNumBox.Value <> 1 Then InvalidFilter = True
			If lines(line).Contains("@DommeLevel2") And FrmSettings.domlevelNumBox.Value <> 2 Then InvalidFilter = True
			If lines(line).Contains("@DommeLevel3") And FrmSettings.domlevelNumBox.Value <> 3 Then InvalidFilter = True
			If lines(line).Contains("@DommeLevel4") And FrmSettings.domlevelNumBox.Value <> 4 Then InvalidFilter = True
			If lines(line).Contains("@DommeLevel5") And FrmSettings.domlevelNumBox.Value <> 5 Then InvalidFilter = True

			If lines(line).Contains("@DommeLevel(") Then
				If FilterCheck(GetParentheses(lines(line), "@DommeLevel("), FrmSettings.domlevelNumBox) = False Then InvalidFilter = True
				'If GetDommeLevel(GetParentheses(lines(line), "@DommeLevel(")) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@ApathyLevel1") And FrmSettings.NBEmpathy.Value <> 1 Then InvalidFilter = True
			If lines(line).Contains("@ApathyLevel2") And FrmSettings.NBEmpathy.Value <> 2 Then InvalidFilter = True
			If lines(line).Contains("@ApathyLevel3") And FrmSettings.NBEmpathy.Value <> 3 Then InvalidFilter = True
			If lines(line).Contains("@ApathyLevel4") And FrmSettings.NBEmpathy.Value <> 4 Then InvalidFilter = True
			If lines(line).Contains("@ApathyLevel5") And FrmSettings.NBEmpathy.Value <> 5 Then InvalidFilter = True

			If lines(line).Contains("@ApathyLevel(") Then
				If FilterCheck(GetParentheses(lines(line), "@ApathyLevel("), FrmSettings.NBEmpathy) = False Then InvalidFilter = True
				'If GetDommeApathy(GetParentheses(lines(line), "@ApathyLevel(")) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@Stroking") And SubStroking = False Then InvalidFilter = True
			If lines(line).Contains("@Edging") And SubEdging = False Then InvalidFilter = True
			If lines(line).Contains("@HoldingTheEdge") And SubHoldingEdge = False Then InvalidFilter = True

			If lines(line).Contains("@NotStroking") And SubStroking = True Then InvalidFilter = True
			If lines(line).Contains("@NotEdging") And SubEdging = True Then InvalidFilter = True
			If lines(line).Contains("@NotHoldingTheEdge") And SubHoldingEdge = True Then InvalidFilter = True

			If lines(line).Contains("@SelfYoung") And FrmSettings.domageNumBox.Value > FrmSettings.NBSelfAgeMin.Value - 1 Then InvalidFilter = True
			If lines(line).Contains("@SelfOld") And FrmSettings.domageNumBox.Value < FrmSettings.NBSelfAgeMax.Value + 1 Then InvalidFilter = True
			If lines(line).Contains("@SubYoung") And FrmSettings.subAgeNumBox.Value > FrmSettings.NBSubAgeMin.Value - 1 Then InvalidFilter = True
			If lines(line).Contains("@SubOld") And FrmSettings.subAgeNumBox.Value < FrmSettings.NBSubAgeMax.Value + 1 Then InvalidFilter = True

			If lines(line).Contains("@ACup") And FrmSettings.boobComboBox.Text <> "A" Then InvalidFilter = True
			If lines(line).Contains("@BCup") And FrmSettings.boobComboBox.Text <> "B" Then InvalidFilter = True
			If lines(line).Contains("@CCup") And FrmSettings.boobComboBox.Text <> "C" Then InvalidFilter = True
			If lines(line).Contains("@DCup") And FrmSettings.boobComboBox.Text <> "D" Then InvalidFilter = True
			If lines(line).Contains("@DDCup") And FrmSettings.boobComboBox.Text <> "DD" Then InvalidFilter = True
			If lines(line).Contains("@DDD+Cup") And FrmSettings.boobComboBox.Text <> "DDD+" Then InvalidFilter = True

			If lines(line).Contains("@Cup(") Then
				If FilterCheck(GetParentheses(lines(line), "@Cup("), FrmSettings.boobComboBox) = False Then InvalidFilter = True
				'If GetCup(GetParentheses(lines(line), "@Cup(")) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@DomBirthday") And FrmSettings.NBDomBirthdayMonth.Value <> Month(Date.Now) And FrmSettings.NBDomBirthdayDay.Value <> DateAndTime.Day(Date.Now) Then InvalidFilter = True
			If lines(line).Contains("@SubBirthday") And FrmSettings.NBBirthdayMonth.Value <> Month(Date.Now) And FrmSettings.NBBirthdayDay.Value <> DateAndTime.Day(Date.Now) Then InvalidFilter = True
			If lines(line).Contains("@ValentinesDay") And Month(Date.Now) <> 2 And DateAndTime.Day(Date.Now) <> 14 Then InvalidFilter = True
			If lines(line).Contains("@ChristmasEve") And Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 24 Then InvalidFilter = True
			If lines(line).Contains("@ChristmasDay") And Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 25 Then InvalidFilter = True
			If lines(line).Contains("@NewYearsEve") And Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 31 Then InvalidFilter = True
			If lines(line).Contains("@NewYearsDay") And Month(Date.Now) <> 1 And DateAndTime.Day(Date.Now) <> 1 Then InvalidFilter = True

			If lines(line).Contains("@FirstRound") And FirstRound = False Then InvalidFilter = True
			If lines(line).Contains("@NotFirstRound") And FirstRound = True Then InvalidFilter = True
			If lines(line).Contains("@StrokeSpeedMax") And StrokePace < NBMaxPace.Value Then InvalidFilter = True
			If lines(line).Contains("@StrokeSpeedMin") And StrokePace < NBMinPace.Value Then InvalidFilter = True

			If lines(line).Contains("@LongEdge") And LongEdge = False Then InvalidFilter = True
			If lines(line).Contains("@InterruptLongEdge") And LongEdge = False And FrmSettings.CBLongEdgeInterrupts.Checked = False Then InvalidFilter = True

			If lines(line).Contains("@1MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 60 Or HoldEdgeTime > 119 Then InvalidFilter = True
			End If
			If lines(line).Contains("@2MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 120 Or HoldEdgeTime > 179 Then InvalidFilter = True
			End If
			If lines(line).Contains("@3MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 180 Or HoldEdgeTime > 239 Then InvalidFilter = True
			End If
			If lines(line).Contains("@4MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 240 Or HoldEdgeTime > 299 Then InvalidFilter = True
			End If
			If lines(line).Contains("@5MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 300 Or HoldEdgeTime > 599 Then InvalidFilter = True
			End If
			If lines(line).Contains("@10MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 600 Or HoldEdgeTime > 899 Then InvalidFilter = True
			End If
			If lines(line).Contains("@15MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 900 Or HoldEdgeTime > 1799 Then InvalidFilter = True
			End If
			If lines(line).Contains("@30MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 1800 Or HoldEdgeTime > 2699 Then InvalidFilter = True
			End If
			If lines(line).Contains("@45MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 2700 Or HoldEdgeTime > 3599 Then InvalidFilter = True
			End If
			If lines(line).Contains("@60MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 3600 Then InvalidFilter = True
			End If

			If lines(line).Contains("@EdgeHeld(") Then
				Dim EdgeFlag As String = GetParentheses(lines(line), "@EdgeHeld(")
				If EdgeFlag.Contains(",") Then
					EdgeFlag = FixCommas(EdgeFlag)
					Dim EdgeArray As String() = EdgeFlag.Split(",")
					If HoldEdgeTime < Val(EdgeArray(0)) * 60 Or HoldEdgeTime > Val(EdgeArray(1)) * 60 Then InvalidFilter = True
				Else
					If Val(EdgeFlag) * 60 > HoldEdgeTime Then InvalidFilter = True
				End If
			End If

			If lines(line).Contains("@CBTLevel1") And FrmSettings.CBTSlider.Value <> 1 Then InvalidFilter = True
			If lines(line).Contains("@CBTLevel2") And FrmSettings.CBTSlider.Value <> 2 Then InvalidFilter = True
			If lines(line).Contains("@CBTLevel3") And FrmSettings.CBTSlider.Value <> 3 Then InvalidFilter = True
			If lines(line).Contains("@CBTLevel4") And FrmSettings.CBTSlider.Value <> 4 Then InvalidFilter = True
			If lines(line).Contains("@CBTLevel5") And FrmSettings.CBTSlider.Value <> 5 Then InvalidFilter = True

			If lines(line).Contains("@SubCircumcised") And FrmSettings.CBSubCircumcised.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@SubNotCircumcised") And FrmSettings.CBSubCircumcised.Checked = True Then InvalidFilter = True
			If lines(line).Contains("@SubPierced") And FrmSettings.CBSubPierced.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@SubNotPierced") And FrmSettings.CBSubPierced.Checked = True Then InvalidFilter = True

			If lines(line).Contains("@BeforeTease") And BeforeTease = False Then InvalidFilter = True
			'If lines(line).Contains("@OrgasmDenied") And OrgasmDenied = False Then InvalidFilter = True
			'If lines(line).Contains("@OrgasmAllowed") And OrgasmAllowed = False Then InvalidFilter = True
			'If lines(line).Contains("@OrgasmRuined") And OrgasmRuined = False Then InvalidFilter = True

			If lines(line).Contains("@OrgasmDenied") And LastOrgasmType <> "DENIED" Then InvalidFilter = True
			If lines(line).Contains("@OrgasmAllowed") And LastOrgasmType <> "ALLOWED" Then InvalidFilter = True
			If lines(line).Contains("@OrgasmRuined") And LastOrgasmType <> "RUINED" Then InvalidFilter = True

			If lines(line).Contains("@InChastity") And My.Settings.Chastity = False Then InvalidFilter = True
			If lines(line).Contains("@HasChastity") And FrmSettings.CBOwnChastity.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@NotInChastity") And My.Settings.Chastity = True Then InvalidFilter = True
			If lines(line).Contains("@DoesNotHaveChastity") And FrmSettings.CBOwnChastity.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@ChastityPA") And FrmSettings.CBChastityPA.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@ChastitySpikes") And FrmSettings.CBChastitySpikes.Checked = False Then InvalidFilter = True

			'If lines(line).Contains("@VitalSub") And CBVitalSub.Checked = False Then InvalidFilter = True
			'If lines(line).Contains("@VitalSubAssignment") And CBVitalSubDomTask.Checked = False Then InvalidFilter = True

			If lines(line).Contains("@RuinTaunt") And EdgeToRuinSecret = True Then InvalidFilter = True

			If lines(line).Contains("@CockTorture") And FrmSettings.CBCBTCock.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@BallTorture") And FrmSettings.CBCBTBalls.Checked = False Then InvalidFilter = True
			If lines(line).Contains("@BallTorture0") And CBTBallsCount <> 0 Then InvalidFilter = True
			If lines(line).Contains("@BallTorture1") And CBTBallsCount <> 1 Then InvalidFilter = True
			If lines(line).Contains("@BallTorture2") And CBTBallsCount <> 2 Then InvalidFilter = True
			If lines(line).Contains("@BallTorture3") And CBTBallsCount <> 3 Then InvalidFilter = True
			If lines(line).Contains("@BallTorture4+") And CBTBallsCount < 4 Then InvalidFilter = True
			If lines(line).Contains("@CockTorture0") And CBTCockCount <> 0 Then InvalidFilter = True
			If lines(line).Contains("@CockTorture1") And CBTCockCount <> 1 Then InvalidFilter = True
			If lines(line).Contains("@CockTorture2") And CBTCockCount <> 2 Then InvalidFilter = True
			If lines(line).Contains("@CockTorture3") And CBTCockCount <> 3 Then InvalidFilter = True
			If lines(line).Contains("@CockTorture4+") And CBTCockCount < 4 Then InvalidFilter = True


			If lines(line).Contains("@Flag(") Then
				Dim WriteFlag As String = lines(line)
				Dim WriteStart As Integer
				WriteStart = WriteFlag.IndexOf("@Flag(") + 6
				WriteFlag = WriteFlag.Substring(WriteStart, WriteFlag.Length - WriteStart)
				WriteFlag = WriteFlag.Split(")")(0)
				WriteFlag = WriteFlag.Replace("@Flag(", "")
				If Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) And
				 Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then
					InvalidFilter = True
				End If
			End If

			If lines(line).Contains("@NotFlag(") Then
				Dim WriteFlag As String = lines(line)
				Dim WriteStart As Integer
				WriteStart = WriteFlag.IndexOf("@NotFlag(") + 9
				WriteFlag = WriteFlag.Substring(WriteStart, WriteFlag.Length - WriteStart)
				WriteFlag = WriteFlag.Split(")")(0)
				WriteFlag = WriteFlag.Replace("@NotFlag(", "")
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) Or
				 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then
					InvalidFilter = True
				End If
			End If

			If lines(line).Contains("@Variable[") Then
				If CheckVariable(lines(line)) = False Then InvalidFilter = True
			End If

			'If lines(line).Contains("@CheckDate(") Then
			'If CheckDateList(lines(line)) = False Then InvalidFilter = True
			'End If

			If lines(line).Contains("@Morning") And GeneralTime <> "Morning" Then InvalidFilter = True
			If lines(line).Contains("@Afternoon") And GeneralTime <> "Afternoon" Then InvalidFilter = True
			If lines(line).Contains("@Night") And GeneralTime <> "Night" Then InvalidFilter = True

			If lines(line).Contains("@GoodMood") And Not lines(line).Contains("@GoodMood(") And DommeMood <= FrmSettings.NBDomMoodMax.Value Then InvalidFilter = True
			If lines(line).Contains("@BadMood") And Not lines(line).Contains("@BadMood(") And DommeMood >= FrmSettings.NBDomMoodMin.Value Then InvalidFilter = True
			If lines(line).Contains("@NeutralMood") And Not lines(line).Contains("@NeutralMood(") Then
				If DommeMood > FrmSettings.NBDomMoodMax.Value Or DommeMood < FrmSettings.NBDomMoodMin.Value Then InvalidFilter = True
			End If

			If lines(line).Contains("@OrgasmRestricted") And OrgasmRestricted = False Then InvalidFilter = True
			If lines(line).Contains("@OrgasmNotRestricted") And OrgasmRestricted = True Then InvalidFilter = True

			If lines(line).Contains("@Month(") Then
				If GetMatch(lines(line), "@Month(", DateAndTime.Now.Month) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@Day(") Then
				If GetMatch(lines(line), "@Day(", DateAndTime.Now.Day) = False Then InvalidFilter = True
			End If

			If lines(line).Contains("@Info") Then InvalidFilter = True

			If InvalidFilter = True Then
				InvalidFilter = False
				RunFileText()
				Return
			End If

			If lines(line) = "@End" Then
				If RiskyEdges = True Then RiskyEdges = False
				If LastScript = True Then
					LastScript = False
					EndTease = True
				End If
				If HypnoGen = True Then
					If Induction = True Then
						Induction = False
						StrokeTauntVal = -1
						FileText = TempHypno
						ScriptTick = 1
						ScriptTimer.Start()
						Return
					End If
					HypnoGen = False
					AFK = False
					DomWMP.Ctlcontrols.stop()
					BTNHypnoGenStart.Text = "Guide Me!"
				End If
				If ReturnFlag = True Then
					ReturnFlag = False
					FileText = ReturnFileText
					StrokeTauntVal = ReturnStrokeTauntVal


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

					If ReturnSubState = "Stroking" Then
						If My.Settings.Chastity = True Then
							'DomTask = "Now as I was saying @StartTaunts"
							DomTask = "#Return_Chastity"
							TypingDelayGeneric()
						Else
							If SubStroking = False Then
								'DomTask = "Get back to stroking @StartStroking"
								DomTask = "#Return_Stroking"
								TypingDelayGeneric()
							Else
								StrokeTimer.Start()
								StrokeTauntTimer.Start()
							End If
						End If
					End If
					If ReturnSubState = "Edging" Then

						If SubEdging = False Then
							'DomTask = "Start getting yourself to the edge again @Edge"
							DomTask = "#Return_Edging"
							'SubStroking = True
							TypingDelayGeneric()
						Else
							EdgeTauntTimer.Start()
							EdgeCountTimer.Start()
						End If
					End If
					If ReturnSubState = "Holding The Edge" Then
						If SubEdging = False Then
							'DomTask = "Start getting yourself to the edge again @EdgeHold"
							DomTask = "#Return_Holding"
							'SubStroking = True
							TypingDelayGeneric()
						Else
							HoldEdgeTimer.Start()
							HoldEdgeTauntTimer.Start()
						End If
					End If
					If ReturnSubState = "CBTBalls" Then
						'DomTask = "Now let's get back to busting those #Balls @CBTBalls"
						DomTask = "#Return_CBTBalls"
						CBTBallsFirst = False
						TypingDelayGeneric()
					End If
					If ReturnSubState = "CBTCock" Then
						'DomTask = "Now let's get back to abusing that #Cock @CBTCock"
						DomTask = "#Return_CBTCock"
						CBTCockFirst = False
						TypingDelayGeneric()
					End If
					If ReturnSubState = "Rest" Then
						DomTypeCheck = True
						ScriptTick = 5
						ScriptTimer.Start()
						'DomTask = "Now as I was saying"
						DomTask = "#Return_Rest"
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

			If lines(line + 1).Substring(0, 1) = "[" Then
				YesOrNo = True
				ScriptTimer.Stop()
			End If



			Debug.Print("CHeck")





			DomTask = (lines(line).Trim)





			StringLength = 1



			DomTask = DomTask.Replace("#SubName", subName.Text)

			DomTask = DomTask.Replace("#VTLength", VTLength / 60)


			If InStr(DomTask, "@CockSizeSmall") <> 0 Then DivideText = True


			If DomTask.Contains("@SearchImageBlogAgain") Then

				SearchImageBlog = True
				GetBlogImage()

			End If


			If DomTask.Contains("@SearchImageBlog") And Not DomTask.Contains("@SearchImageBlogAgain") Then

				SearchImageBlog = True
				GetBlogImage()

			End If


			'If InStr(UCase(DomTask), UCase("@Goto")) <> 0 And InStr(UCase(DomTask), UCase("@GotoDommeLevel")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeOrgasm")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeRuin")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeApathy")) = 0 And InStr(UCase(DomTask), UCase("@GotoSlideshow")) = 0 Then
			If DomTask.Contains("@Goto(") Then
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

			Debug.Print("TempVal = " & TempVal)
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

			If DomTask.Contains("@ShowTaggedImage") Then JustShowedBlogImage = True

			If DomTask.Contains("@NullResponse") Then NullResponse = True

			If HypnoGen = True Then

				If CBHypnoGenSlideshow.Checked = True Then

					If LBHypnoGenSlideshow.SelectedItem = "Boobs" Then DomTask = DomTask & " @ShowBoobsImage"
					If LBHypnoGenSlideshow.SelectedItem = "Butts" Then DomTask = DomTask & " @ShowButtImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hardcore" Then DomTask = DomTask & " @ShowHardcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Softcore" Then DomTask = DomTask & " @ShowSoftcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lesbian" Then DomTask = DomTask & " @ShowLesbianImage"
					If LBHypnoGenSlideshow.SelectedItem = "Blowjob" Then DomTask = DomTask & " @ShowBlowjobImage"
					If LBHypnoGenSlideshow.SelectedItem = "Femdom" Then DomTask = DomTask & " @ShowFemdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lezdom" Then DomTask = DomTask & " @ShowLezdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hentai" Then DomTask = DomTask & " @ShowHentaiImage"
					If LBHypnoGenSlideshow.SelectedItem = "Gay" Then DomTask = DomTask & " @ShowGayImage"
					If LBHypnoGenSlideshow.SelectedItem = "Maledom" Then DomTask = DomTask & " @ShowMaledomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Captions" Then DomTask = DomTask & " @ShowCaptionsImage"
					If LBHypnoGenSlideshow.SelectedItem = "General" Then DomTask = DomTask & " @ShowGeneralImage"
					If LBHypnoGenSlideshow.SelectedItem = "Tagged" Then DomTask = DomTask & " @ShowTaggedImage @Tag" & TBHypnoGenImageTag.Text



				End If

			End If


			If DomTask <> "" Then
				TypingDelayGeneric()
			Else
				RunFileText()
			End If


		End If

	End Sub

	Public Sub GetGoto()



		GotoFlag = True
		'Debug.Print("DomTask = " & DomTask)
		'DomTypeCheck = True

		'Debug.Print("SkipGotoLine = " & SkipGotoLine)

		Dim StripGoto As String

		If GotoDommeLevel = True Or SkipGotoLine = True Then
			StripGoto = FileGoto
			GoTo SkipGotoSearch
		End If



		Dim TempGoto As String = DomTask & " some garbage"
		Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
		TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
		TempGoto = TempGoto.Split(")")(0)
		FileGoto = TempGoto


		StripGoto = FileGoto




		If TempGoto.Contains(",") Then
			Debug.Print("Multiple Goto")
			TempGoto = TempGoto.Replace(", ", ",")
			Dim GotoSplit As String() = TempGoto.Split(",")
			Dim GotoTemp As Integer = randomizer.Next(0, GotoSplit.Count)
			FileGoto = GotoSplit(GotoTemp)
			Debug.Print("FileGoto = " & FileGoto)
		End If


SkipGotoSearch:

		'Debug.Print("GetGoto() Domtask R2 = " & FileGoto)


		Dim GotoText As String

		If MiniScript = True Then
			GotoText = MiniScriptText
		Else
			GotoText = FileText
		End If


		'TODO: Add Errorhandling.
		If File.Exists(GotoText) Then
			' Read all lines of the given file.
			Dim gotolines As List(Of String) = Txt2List(GotoText)
			Dim CountGotoLines As Integer = gotolines.Count

			If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
			If FileGoto.Substring(0, 1) <> "(" Then FileGoto = "(" & FileGoto & ")"
			Debug.Print(FileGoto)
			Debug.Print(StripGoto)
			DomTask = DomTask.Replace("@Goto" & StripGoto, "")

			'If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"

			'DomTask = DomTask.Replace("@Goto" & StripGoto, "")
			Debug.Print("StripGoto = " & StripGoto)

			Debug.Print("FileGoto = " & FileGoto)

			Dim gotoline As Integer = 0
			Do
				gotoline += 1
				If GotoDommeLevel = True And gotoline = CountGotoLines Then
					FileGoto = "(DommeLevel)"
					GoTo SkipGotoSearch
				End If
				'Loop Until gotolines(gotoline) = FileGoto

				'github patch begin
				'Loop Until InStr(gotolines(gotoline), FileGoto) <> 0 And InStr(gotolines(gotoline), "@Goto") = 0 And InStr(gotolines(gotoline), "@CheckFlag") = 0 And InStr(gotolines(gotoline), "@TempFlag") = 0 _
				'And InStr(gotolines(gotoline), "@SetFlag") = 0 And InStr(gotolines(gotoline), "@Chance") = 0 And InStr(gotolines(gotoline), "@GotoDommeLevel") = 0 _
				'And InStr(gotolines(gotoline), "Then(") = 0 And InStr(gotolines(gotoline), "@GoodMood(") = 0 And InStr(gotolines(gotoline), "@BadMood(") = 0 And InStr(gotolines(gotoline), "@NeutralMood(") = 0 'And InStr(gotolines(gotoline), "@GotoDommeApathy") = 0
				'github patch end

			Loop Until gotolines(gotoline).StartsWith(FileGoto) And InStr(gotolines(gotoline), "@CheckFlag") = 0 And InStr(gotolines(gotoline), "@TempFlag") = 0 _
			And InStr(gotolines(gotoline), "@SetFlag") = 0 And InStr(gotolines(gotoline), "@Chance") = 0 And InStr(gotolines(gotoline), "@GotoDommeLevel") = 0 _
			And InStr(gotolines(gotoline), "Then(") = 0 And InStr(gotolines(gotoline), "@GoodMood(") = 0 And InStr(gotolines(gotoline), "@BadMood(") = 0 And InStr(gotolines(gotoline), "@NeutralMood(") = 0 'And InStr(gotolines(gotoline), "@GotoDommeApathy") = 0




			' If ShowThought = True Or ShowEdgeThought = True Then


			If MiniScript = True Then
				MiniTauntVal = gotoline
			Else
				StrokeTauntVal = gotoline
			End If


			'  ThoughtTauntVal = gotoline
			'Else
			'   If ShowModule = True Then
			'ModuleTauntVal = gotoline
			'Else
			'   StrokeTauntVal = gotoline
			'End If
			'End If

			'Debug.Print("GetGoto() Task GotoLine  = " & gotoline)
		End If
		' End If


		GotoDommeLevel = False
		SkipGotoLine = False




	End Sub

	Public Sub TypingDelay()

		'Debug.Print("Typing Delay Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			DomChat = OfflineConversion(DomChat)
		End If
		TypeDelay = StringLength
		If TypeDelay > 60 Then TypeDelay = 60
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or RapidCode = True = True Then TypeDelay = 0
		SendTimer.Start()


	End Sub

	Public Sub TypingDelayGeneric()
		'Debug.Print("Typing Delay Generic Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			DomTask = OfflineConversion(DomTask)
		End If
		TypeDelay = StringLength
		If TypeDelay > 60 Then TypeDelay = 60
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or RapidCode = True = True Then TypeDelay = 0
		If HypnoGen = True And CBHypnoGenNoText.Checked = True Then TypeDelay = 0
		Timer1.Start()

	End Sub

	Private Sub Timer1_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles Timer1.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		DomTyping = True
		Dim ShowPicture As Boolean = False

		If DomTypeCheck = False Then
			DomTask = CheckPreLoad(DomTask)
		End If


		' Let the program know that the domme is currently typing
		DomTypeCheck = True




		If CBHypnoGenNoText.Checked = True And HypnoGen = True Then NullResponse = True
		If DomTask.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()

		'Debug.Print("Nullresponse = " & NullResponse)
		If DomTask.Contains("@NullResponse") Then
			NullResponse = True
		Else
			RapidCode = False
		End If


		If Not Group.Contains("D") And Not DomTask.Contains("@Contact1") And Not DomTask.Contains("@Contact2") And Not DomTask.Contains("@Contact3") Then
			Dim GroupList As New List(Of String)
			GroupList.Clear()
			If Group.Contains("1") Then GroupList.Add("@Contact1 ")
			If Group.Contains("2") Then GroupList.Add("@Contact2 ")
			If Group.Contains("3") Then GroupList.Add("@Contact3 ")
			DomTask = DomTask & GroupList(randomizer.Next(0, GroupList.Count))
		End If


		If NullResponse = True Then
			Timer1.Stop()
			GoTo NullResponse
		End If

		'Debug.Print("CBHypnoGenNoText.Enabled = " & CBHypnoGenNoText.Enabled)
		'Debug.Print("HypnoGen = " & HypnoGen)

		' Debug.Print("TypeToggle = " & TypeToggle)
		'Debug.Print("TypeDelay = " & TypeDelay)


		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If TypeToggle = 0 Then
			'Debug.Print("TypeDelay = " & TypeDelay)
			If TypeDelay > 0 Then
				TypeDelay -= 1
			Else
				Timer1.Stop()
				'Debug.Print("NullCommand DomTask = " & DomTask)
				If RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				If NullResponse = False Then
					IsTyping = True
					Dim TypingName As String = domName.Text
					If DomTask.Contains("@Contact1") Then TypingName = FrmSettings.TBGlitter1.Text
					If DomTask.Contains("@Contact2") Then TypingName = FrmSettings.TBGlitter2.Text
					If DomTask.Contains("@Contact3") Then TypingName = FrmSettings.TBGlitter3.Text
					'If TypingName <> domName.Text Then JustShowedBlogImage = True

					If DomTask.Contains("@EmoteMessage") Then EmoMes = True

					If DomTask.Contains("@SystemMessage") Then
						SysMes = True
						TypeDelay = 0
						GoTo SkipIsTyping
					End If

					' If FrmSettings.CBWebtease.Checked = True Then GoTo SkipIsTyping


					If FrmSettings.CBWebtease.Checked = True Then

						ChatText.DocumentText = Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While


					Else

						ChatText.DocumentText = Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ScrollChatDown()

					End If


SkipIsTyping:

				End If




				TypeToggle = 1
				StringLength = DomTask.Length
				If DivideText = True Then
					StringLength /= 3
					DivideText = False
				End If
				If RLGLGame = True Then StringLength = 0
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or RapidCode = True Then StringLength = 0
				If HypnoGen = True And CBHypnoGenNoText.Checked = True Then StringLength = 0
				TypingDelayGeneric()
			End If

		Else

			If TypeDelay > 0 Then
				TypeDelay -= 1
				If DomTask.Contains("@SystemMessage") Then TypeDelay = 0

			Else
				TypeToggle = 0
				Timer1.Stop()
				IsTyping = False
				If RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

				ResponseYes = ""
				ResponseNo = ""

				' If PreCleanString.Contains("#") Then GoTo PoundLoop

				' DomTask = PreCleanString


				If DomTask.Contains("@ShowHardcoreImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowSoftcoreImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowLesbianImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowBlowjobImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowFemdomImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowLezdomImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowHentaiImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowGayImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowMaledomImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowCaptionsImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowGeneralImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowLocalImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@ShowBlogImage") Then JustShowedBlogImage = True
				If DomTask.Contains("@NewBlogImage") Then JustShowedBlogImage = True

				If DomTask.Contains("@SlideshowFirst") Then JustShowedSlideshowImage = True
				If DomTask.Contains("@SlideshowNext") Then JustShowedSlideshowImage = True
				If DomTask.Contains("@SlideshowPrevious") Then JustShowedSlideshowImage = True
				If DomTask.Contains("@SlideshowLast") Then JustShowedSlideshowImage = True



				'Debug.Print("TeaseRadio = " & FrmSettings.teaseRadio.Checked)
				'Debug.Print("JustShowedBlogImage = " & JustShowedBlogImage)
				'Debug.Print("TeaseVideo  = " & TeaseVideo)
				'Debug.Print("DomTask = " & DomTask)
				'Debug.Print("NullResponse = " & NullResponse)
				'Debug.Print("SlideshowLoaded = " & SlideshowLoaded)
				'Debug.Print("SubStroking = " & SubStroking)
				'Debug.Print("SubEdging  = " & SubEdging)
				'Debug.Print("SubHoldingEdge = " & SubHoldingEdge)



				If GlitterTease = True And JustShowedBlogImage = False Then GoTo TryNextWithTease


				If FrmSettings.teaseRadio.Checked = True And JustShowedBlogImage = False And TeaseVideo = False And Not DomTask.Contains("@NewBlogImage") And NullResponse = False _
					And SlideshowLoaded = True And Not DomTask.Contains("@ShowButtImage") And Not DomTask.Contains("@ShowBoobsImage") And Not DomTask.Contains("@ShowButtsImage") _
					And Not DomTask.Contains("@ShowBoobsImage") And LockImage = False And CustomSlideshow = False And RapidFire = False _
					And UCase(DomTask) <> "<B>TEASE AI HAS BEEN RESET</B>" And JustShowedSlideshowImage = False Then
					If SubStroking = False Or SubEdging = True Or SubHoldingEdge = True Then
						' Begin Next Button

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:

						Dim TeaseDirection As Integer = randomizer.Next(1, 101)

						'Debug.Print("TeaseDirection = " & TeaseDirection)

						If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

							FileCount -= 1
							If FileCount < 0 Then
								FileCount = 0
							End If

							If DomTask.Contains("@Contact1") Then
								Contact1PicsCount -= 1
								If Contact1PicsCount < 0 Then
									Contact1PicsCount = 0
								End If
							End If

							If DomTask.Contains("@Contact2") Then
								Contact2PicsCount -= 1
								If Contact2PicsCount < 0 Then
									Contact2PicsCount = 0
								End If
							End If

							If DomTask.Contains("@Contact3") Then
								Contact3PicsCount -= 1
								If Contact3PicsCount < 0 Then
									Contact3PicsCount = 0
								End If
							End If

						Else


							FileCount += 1
							If FileCount > FileCountMax Then
								If FrmSettings.CBNewSlideshow.Checked = True Then
									NewDommeSlideshow = True
									OriginalDommeSlideshow = _ImageFileNames(0)
									LoadDommeImageFolder()
									NewDommeSlideshow = False
									DomPic = _ImageFileNames(FileCount)
								Else
									FileCount = FileCountMax
								End If
							End If

							If DomTask.Contains("@Contact1") Then
								Contact1PicsCount += 1
								Try
									If Contact1PicsCount > Contact1Pics.Count - 1 Then
										Contact1PicsCount = Contact1Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If DomTask.Contains("@Contact2") Then
								Contact2PicsCount += 1
								Try
									If Contact2PicsCount > Contact2Pics.Count - 1 Then
										Contact2PicsCount = Contact2Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If DomTask.Contains("@Contact3") Then
								Contact3PicsCount += 1
								Try
									If Contact3PicsCount > Contact3Pics.Count - 1 Then
										Contact3PicsCount = Contact3Pics.Count - 1
									End If
								Catch
								End Try
							End If

						End If

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

						If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryNextWithTease

						DomPic = _ImageFileNames(FileCount)

						If DomTask.Contains("@Contact1") Then
							Try
								DomPic = Contact1Pics(Contact1PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

						If DomTask.Contains("@Contact2") Then
							Try
								DomPic = Contact2Pics(Contact2PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

						If DomTask.Contains("@Contact3") Then
							Try
								DomPic = Contact3Pics(Contact3PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

					End If
					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					' github patch If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

					If FrmSettings.CBSlideshowRandom.Checked = True Then
						FileCount = randomizer.Next(0, FileCountMax + 1)
						If Contact1Pics.Count > 0 Then Contact1PicsCount = randomizer.Next(0, Contact1Pics.Count - 1)
						If Contact2Pics.Count > 0 Then Contact2PicsCount = randomizer.Next(0, Contact2Pics.Count - 1)
						If Contact3Pics.Count > 0 Then Contact3PicsCount = randomizer.Next(0, Contact3Pics.Count - 1)
					End If


					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					ShowPicture = True

					' End Next Button
					'On Error GoTo TryNextWithTease
					'On Error Resume Next
					' End Next Button
				End If



NullResponse:


				If DomTask.Contains("@WritingTask(") Then
					Dim WriteFlag As String = GetParentheses(DomTask, "@WritingTask(")
					DomTask = DomTask.Replace(WriteFlag, PoundClean(WriteFlag))
				End If

				If DomTask.Contains("@Contact1") Or DomTask.Contains("@Contact2") Or DomTask.Contains("@Contact3") Then SubWroteLast = True

				Dim TypeName As String = domName.Text
				Dim TypeColor As String = DomColor
				Dim TypeFont As String = FrmSettings.FontComboBoxD.Text
				Dim TypeSize As String = FrmSettings.NBFontSizeD.Value
				Dim LineSpeaker As String = ""
				If DomTask.Contains("@Contact1") Then
					TypeName = FrmSettings.TBGlitter1.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC1.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact1 "
				End If
				If DomTask.Contains("@Contact2") Then
					TypeName = FrmSettings.TBGlitter2.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC2.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact2 "
				End If
				If DomTask.Contains("@Contact3") Then
					TypeName = FrmSettings.TBGlitter3.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC3.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact3 "
				End If


				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					Dim EmoteArray() As String = Split(DomTask)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					DomTask = Join(EmoteArray)
				End If

				'SaveBlogImage.Text = ""

				'If RiskyDeal = True Then Me.Focus()

				Dim LoopBuffer As Integer = 0



				Do
					LoopBuffer += 1

					Debug.Print("############################### DomTask = " & DomTask)

					DomTask = DomTask.Replace("#Null", "")
					DomTask = PoundClean(DomTask)
					If DomTask.Contains("@EmoteMessage") Then EmoMes = True
					DomTask = CommandClean(DomTask)
					DomTask = StripCommands(DomTask)
					DomTask = DomTask.Replace("#Null", "")
					DomTask = PoundClean(DomTask)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not DomTask.Contains("#") And Not DomTask.Contains("@")




				'Debug.Print("NullResponse = " & NullResponse)
				If CBHypnoGenNoText.Checked = True And HypnoGen = True Then GoTo HypNoResponse
				If NullResponse = True Then GoTo NoResponse

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


				If DomTask.Contains("(") And DomTask.Contains(")") Then
					Dim ParenReg As RegularExpressions.Regex
					ParenReg = New RegularExpressions.Regex("\(([^\)]*)\)")
					DomTask = DomTask.Replace(ParenReg.Match(DomTask).Value(), "")
				End If

				' Github Patch If SysMes = False And EmoMes = False Then
				If SysMes = False And EmoMes = False And Not DomTask = "" Then

					Try
						Dim UCASELine As String = UCase(DomTask.Substring(0, 1))
						DomTask = DomTask.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try


					If FrmSettings.LCaseCheckBox.Checked = True Then DomTask = LCase(DomTask)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(DomTask)
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
						DomTask = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then DomTask = DomTask.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then DomTask = DomTask.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then DomTask = DomTask.Replace(".", "")

					' Try
					'DomTask = DomTask.Replace("*", FrmSettings.domemoteComboBox.Text.Substring(0, 1))
					'Catch
					'End Try

					Dim EmoToggle As Boolean = True
					For i As Integer = DomTask.Length - 1 To 0 Step -1
						If DomTask.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								DomTask = DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								DomTask = DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					DomTask = DomTask.Replace(":d", ":D")
					DomTask = DomTask.Replace(": d", ": D")


					'Typo Test

					Try

						Dim RestoreDomTask As String = DomTask

						If Not DomTask.Substring(0, 1) = FrmSettings.TBEmote.Text.Substring(0, 1) And Not DomTask.Contains("<") And YesOrNo = False And TypoSwitch <> 0 And TyposDisabled = False _
							And FrmSettings.TTSCheckBox.Checked = False Then

							Dim TypoChance As Integer = randomizer.Next(0, 101)

							If TypoChance < FrmSettings.NBTypoChance.Value Or TypoSwitch = 2 Then

								Try

									Dim TypoString As String

									Dim TypoSplit As String() = DomTask.Split(" ")

									TempVal = randomizer.Next(0, TypoSplit.Count)

									CorrectedWord = TypoSplit(TempVal)

									CorrectedWord = CorrectedWord.Replace(",", "")
									CorrectedWord = CorrectedWord.Replace(".", "")
									CorrectedWord = CorrectedWord.Replace("!", "")
									CorrectedWord = CorrectedWord.Replace("?", "")

									TypoString = "w d s f x"


									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "a" Then TypoString = "q w s z x"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "b" Then TypoString = "f v g h n"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "c" Then TypoString = "x d f v b"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "d" Then TypoString = "s c f x e"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "e" Then TypoString = "s r w 3 d"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "f" Then TypoString = "d r g v c"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "g" Then TypoString = "f t b h y"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "h" Then TypoString = "g b n u j"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "i" Then TypoString = "o u j k l"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "j" Then TypoString = "k u i n h"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "k" Then TypoString = "j m , l i"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "l" Then TypoString = "; p . , i"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "m" Then TypoString = "n j k , l"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "n" Then TypoString = "b h j k m"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "o" Then TypoString = "p 0 i k ;"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "p" Then TypoString = "[ - o ; l"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "q" Then TypoString = "1 w s a 2"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "r" Then TypoString = "4 5 t f d"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "s" Then TypoString = "w d a z x"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "t" Then TypoString = "5 6 g y r"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "u" Then TypoString = "y 7 j i k"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "v" Then TypoString = "c f g h b"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "w" Then TypoString = "2 a e q s"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "x" Then TypoString = "z s d f c"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "y" Then TypoString = "t 7 h u g"
									If LCase(TypoSplit(TempVal).Substring(0, 1)) = "z" Then TypoString = "a s x d c"


									Dim UpperChance As Integer = randomizer.Next(0, 101)
									If UpperChance < 26 Then TypoString = UCase(TypoString)



									Dim GetTypo As String() = TypoString.Split(" ")

									Dim MadeTypo As String = GetTypo(randomizer.Next(0, GetTypo.Count))


									Dim DoubleChance As Integer = randomizer.Next(0, 101)
									If DoubleChance < 11 Then MadeTypo = MadeTypo & LCase(GetTypo(randomizer.Next(0, GetTypo.Count)))


									TypoSplit(TempVal) = TypoSplit(TempVal).Remove(0, 1)

									Dim SpaceChance As Integer = randomizer.Next(0, 101)
									If SpaceChance < 7 Then
										TypoSplit(TempVal) = MadeTypo & " " & TypoSplit(TempVal)
									Else
										TypoSplit(TempVal) = MadeTypo & TypoSplit(TempVal)

									End If

									DomTask = Join(TypoSplit)

									CorrectedTypo = True

								Catch

									DomTask = RestoreDomTask
									CorrectedTypo = False
								End Try

							End If

						End If

						TypoSwitch = 1

					Catch
					End Try


				End If

				DomTask = DomTask.Replace("ATSYMBOL", "@")
				DomTask = DomTask.Replace("atsymbol", "@")

				If InputIcon = True Then
					' github patch DomTask = DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					DomTask = DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png"" title=""This icon means your Domme will remember your answer!""/>"
					InputIcon = False
				End If

				DomTask = DomTask.Replace(" a a", " an a")
				DomTask = DomTask.Replace(" a e", " an e")
				DomTask = DomTask.Replace(" a i", " an i")
				DomTask = DomTask.Replace(" a o", " an o")
				DomTask = DomTask.Replace(" a u", " an u")

				DomTask = DomTask.Replace(" an uni", " a uni")
				DomTask = DomTask.Replace(" an utensil", " a utensil")
				DomTask = DomTask.Replace(" an ukulele", " a ukulele")
				DomTask = DomTask.Replace(" an use", " a use")
				DomTask = DomTask.Replace(" an urethra", " a urethra")
				DomTask = DomTask.Replace(" an urine", " a urine")
				DomTask = DomTask.Replace(" an usual", " a usual")
				DomTask = DomTask.Replace(" an utility", " a utility")
				DomTask = DomTask.Replace(" an uterus", " a uterus")
				DomTask = DomTask.Replace(" an utopia", " a utopia")


				Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

				If NullResponse = False And DomTask <> "" Then

					If UCase(DomTask) = "<B>TEASE AI HAS BEEN RESET</B>" Then DomTask = "<b>Tease AI has been reset</b>"


					If SysMes = True Then
						Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & DomTask & "</b><br></font></body>"
						SysMes = False
						ChatText.DocumentText = Chat
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ScrollChatDown()
						GoTo EndSysMes
					End If

					If EmoMes = True Then
						Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""" &
		   TypeColor & """><b><i>" & DomTask & "</i></b><br></font></body>"
						EmoMes = False
						ChatText.DocumentText = Chat
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ScrollChatDown()
						GoTo EndSysMes
					End If

					' Add timestamps to domme response if the option is checked in the menu
					If FrmSettings.timestampCheckBox.Checked = True And FrmSettings.CBWebtease.Checked = False Then
						Chat = Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
					End If



					If SubWroteLast = False And FrmSettings.shownamesCheckBox.Checked = False Then


						If FrmSettings.CBWebtease.Checked = True Then
							Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						  TextColor & """><center>" & DomTask & "</center><br></font></body>"
						Else
							Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						  TextColor & """>" & Chat & DomTask & "<br></font></body>"
						End If


						ChatText.DocumentText = Chat
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ScrollChatDown()

						If RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
				TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomTask & "<br></font></body>"


					Else


						If FrmSettings.CBWebtease.Checked = True Then
							Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
					TextColor & """><center>" & DomTask & "</center><br></font></body>"
						Else
							Chat = "<body style=""word-wrap:break-word;"">" & Chat & "<font face=""Cambria"" size=""3"" font color=""" &
	  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomTask & "<br></font></body>"
						End If





						TypeToggle = 0
						ChatText.DocumentText = Chat
						While ChatText.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ChatText2.DocumentText = Chat
						While ChatText2.ReadyState <> WebBrowserReadyState.Complete
							Application.DoEvents()
						End While
						ScrollChatDown()

						If RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
				TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomTask & "<br></font></body>"

					End If

EndSysMes:



					ScrollChatDown()

					If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

					' Dsplay the next picture in the slideshow as the domme responds if "With Tease" radio button is checked



					SubWroteLast = False

				End If

				If PreLoadImage = True Or JustShowedBlogImage = True Then GoTo HypNoResponse


				If ShowPicture = True Or DommeImageFound = True Then



					Try
						If RiskyDeal = True Then
							' ######################## Risky Pick #########################
							FrmCardList.PBRiskyPic.Image = Image.FromFile(DomPic)
						ElseIf DommeImageFound = True Then
							' ######################## Domme Tags #########################
							ShowImage(DommeImageSTR, True)
							DommeImageFound = False
						ElseIf LocalImageFound = True Then
							' ######################## Local Img. #########################
							ShowImage(LocalImageSTR, True)
							LocalImageFound = False
						Else
							' ######################## Slideshow ##########################
							ShowImage(DomPic, True)
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
					Debug.Print(DomTask)
					DomTask = StripFormat(DomTask)

					mciSendString("CLOSE Speech1", String.Empty, 0, 0)
					mciSendString("CLOSE Echo1", String.Empty, 0, 0)

					Dim SpeechDir As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\TempWav.wav"

					synth2.SelectVoice(FrmSettings.TTSComboBox.Text)
					synth2.SetOutputToWaveFile(SpeechDir, New SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono))
					synth2.Speak(DomTask)
					synth2.SetOutputToNull()

					SpeechDir = GetShortPathName(SpeechDir)

					mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Speech1", String.Empty, 0, 0)
					mciSendString("PLAY Speech1 FROM 0", String.Empty, 0, 0)


					If CBHypnoGenPhase.Checked And HypnoGen = True Then
						Delay(0.4)
						mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Echo1", String.Empty, 0, 0)
						mciSendString("PLAY Echo1 FROM 0", String.Empty, 0, 0)
					End If

				End If

NoResponse:

				If PreLoadImage = True Then
					DisplayImage()
				End If

				Try
					If mainPictureBox.Visible = True Then
						If ImageLocation.Contains("/") Then
							Debug.Print("Timer1 PictureStrip")
							PictureStrip.Items(0).Enabled = True
							PictureStrip.Items(1).Enabled = True
							PictureStrip.Items(2).Enabled = True
							PictureStrip.Items(3).Enabled = True
							PictureStrip.Items(4).Enabled = True
							PictureStrip.Items(5).Enabled = True
						Else
							Debug.Print("Timer1 PictureStrip")
							PictureStrip.Items(0).Enabled = True
							PictureStrip.Items(1).Enabled = False
							PictureStrip.Items(2).Enabled = False
							PictureStrip.Items(3).Enabled = False
							PictureStrip.Items(4).Enabled = False
							PictureStrip.Items(5).Enabled = False
						End If
					End If
				Catch
					PictureStrip.Items(0).Enabled = False
					PictureStrip.Items(1).Enabled = False
					PictureStrip.Items(2).Enabled = False
					PictureStrip.Items(3).Enabled = False
					PictureStrip.Items(4).Enabled = False
					PictureStrip.Items(5).Enabled = False
				End Try


				If CorrectedTypo = True Then
					CorrectedTypo = False
					'DomTask = "*" & CorrectedWord
					DomTask = LineSpeaker & "*" & CorrectedWord
					TypingDelayGeneric()
					Return
				End If

				StrokeSpeedCheck()

				If SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If RLGLGame = True And RedLight = False Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused) Then
						DomWMP.Ctlcontrols.play()


						AskedToSpeedUp = False
						AskedToSlowDown = False
						SubStroking = True
						SubEdging = False
						SubHoldingEdge = False
						StopMetronome = False
						StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
						StrokePace = 50 * Math.Round(StrokePace / 50)
						StrokePaceTimer.Interval = StrokePace
						RLGLTauntTick = randomizer.Next(20, 31)
						' VideoTauntTick = randomizer.Next(20, 31)
						RLGLTauntTimer.Start()

					End If
				End If

				If RLGLGame = True And RedLight = True Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
						DomWMP.Ctlcontrols.pause()
						SubStroking = False
						StopMetronome = True
						StrokePace = 0
						'VideoTauntTimer.Stop()
					End If
				End If



				NullResponse = False

				If FollowUp <> "" Then
					DomTask = FollowUp
					Debug.Print("FollowUp DomTask = " & DomTask)
					FollowUp = ""
					TypingDelayGeneric()
					Exit Sub
				End If

				DomTypeCheck = False
				DomTyping = False
				'StringLength = 20
				StringLength = randomizer.Next(8, 16)

				If SubStroking = False Then StopMetronome = True
				If SubHoldingEdge = True Then
					StrokePace = 0
				End If
				'Debug.Print("End of DomTask #######################################################################################################################")
				'JustShowedBlogImage = False

				If TempScriptCount = 0 Then
					JustShowedBlogImage = False
					JustShowedSlideshowImage = False
				End If


				If CBTCockActive = True Then
					CBTCockActive = False
					CBTCock()
				End If

				If CBTBallsActive = True Then
					CBTBallsActive = False
					CBTBalls()
				End If

				If CBTBothActive = True Then
					CBTBothActive = False
					CBTBoth()
				End If

				If CustomTaskActive = True Then
					CustomTaskActive = False
					RunCustomTask()
				End If

				If YesOrNo = False Then
					If RapidCode = True Then
						RunFileText()
					Else
						ScriptTick = randomizer.Next(4, 7)
						If RapidFire = True Then ScriptTick = 1
						If RiskyDeal = True Then ScriptTick = 2
						ScriptTimer.Start()
					End If
				End If

				If YesOrNo = True And RiskyDeal = True Then
					FrmCardList.BTNPickIt.Visible = True
					FrmCardList.BTNRiskIt.Visible = True
					FrmCardList.HighlightCaseLabelsOffer()

				End If

				GotoFlag = False


				If SubGaveUp = True Then

					SubGaveUp = False

					AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = SubStroking
					Dim WasEdging As Boolean = SubEdging
					Dim WasHolding As Boolean = SubHoldingEdge

					StopEverything()
					ModuleEnd = False
					ShowModule = False

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



					If ReturnFlag Then
						ShowModule = True
						ScriptTimer.Start()
					ElseIf TeaseTick < 1 And Playlist = False Then
						StrokeTauntVal = -1
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						StrokeTauntVal = -1
						RunModuleScript(False)
					Else
						StrokeTauntVal = -1
						RunLinkScript()
					End If



				End If



			End If
		End If

	End Sub

	Private Function playingStatus() As Boolean

		Dim retval As Integer
		Dim returnData As String = Space(128)

		'retval = mciSendString("status Speech1 mode", returnData, 128, 0)

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

	Private Sub SendTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles SendTimer.Tick

		If DomChat.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()
		If DomChat.Contains("@NullResponse") Then
			NullResponse = True
		Else
			RapidCode = False
		End If

		If DomTypeCheck = False Then
			DomTask = CheckPreLoad(DomTask)
		End If


		If Not Group.Contains("D") And Not DomChat.Contains("@Contact1") And Not DomChat.Contains("@Contact2") And Not DomChat.Contains("@Contact3") Then
			Dim GroupList As New List(Of String)
			GroupList.Clear()
			If Group.Contains("1") Then GroupList.Add("@Contact1 ")
			If Group.Contains("2") Then GroupList.Add("@Contact2 ")
			If Group.Contains("3") Then GroupList.Add("@Contact3 ")
			DomChat = DomChat & GroupList(randomizer.Next(0, GroupList.Count))
		End If

		If NullResponse = True Then
			SendTimer.Stop()
			GoTo NullResponseLine
		End If

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		Dim ShowPicture As Boolean = False

		' Let the program know that the domme is currently typing
		DomTypeCheck = True

		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If TypeToggle = 0 Then
			If TypeDelay > 0 Then
				TypeDelay -= 1
			Else

				SendTimer.Stop()

				If RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				IsTyping = True
				Dim TypingName As String = domName.Text
				If DomChat.Contains("@Contact1") Then TypingName = FrmSettings.TBGlitter1.Text
				If DomChat.Contains("@Contact2") Then TypingName = FrmSettings.TBGlitter2.Text
				If DomChat.Contains("@Contact3") Then TypingName = FrmSettings.TBGlitter3.Text

				If DomChat.Contains("@EmoteMessage") Then EmoMes = True

				If DomChat.Contains("@SystemMessage") Then
					SysMes = True
					TypeDelay = 0
					GoTo SkipIsTyping
				End If

				If FrmSettings.CBWebtease.Checked = True Then

					ChatText.DocumentText = Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While


				Else

					ChatText.DocumentText = Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

				End If





SkipIsTyping:

				TypeToggle = 1
				StringLength = DomChat.Length
				If DivideText = True Then
					StringLength /= 3
					DivideText = False
				End If
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or RapidCode = True Then StringLength = 0
				TypingDelay()
			End If

		Else

			If TypeDelay > 0 Then
				TypeDelay -= 1
				If DomChat.Contains("@SystemMessage") Then TypeDelay = 0
			Else
				TypeToggle = 0
				SendTimer.Stop()
				IsTyping = False

				ResponseYes = ""
				ResponseNo = ""

				If RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

NullResponseLine:



				If GlitterTease = True And JustShowedBlogImage = False Then GoTo TryNextWithTease

				If DomChat.Contains("@ShowHardcoreImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowSoftcoreImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowLesbianImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowBlowjobImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowFemdomImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowLezdomImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowHentaiImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowGayImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowMaledomImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowCaptionsImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowGeneralImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowLocalImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@ShowBlogImage") Then JustShowedBlogImage = True
				If DomChat.Contains("@NewBlogImage") Then JustShowedBlogImage = True

				If DomChat.Contains("@SlideshowFirst") Then JustShowedSlideshowImage = True
				If DomChat.Contains("@SlideshowNext") Then JustShowedSlideshowImage = True
				If DomChat.Contains("@SlideshowPrevious") Then JustShowedSlideshowImage = True
				If DomChat.Contains("@SlideshowLast") Then JustShowedSlideshowImage = True



				If FrmSettings.teaseRadio.Checked = True And JustShowedBlogImage = False And TeaseVideo = False And Not DomTask.Contains("@NewBlogImage") And NullResponse = False _
					And SlideshowLoaded = True And Not DomChat.Contains("@ShowButtImage") And Not DomChat.Contains("@ShowBoobsImage") And Not DomChat.Contains("@ShowButtsImage") _
					And Not DomChat.Contains("@ShowBoobImage") And LockImage = False And CustomSlideshow = False And RapidFire = False _
					And UCase(DomChat) <> "<B>TEASE AI HAS BEEN RESET</B>" And JustShowedSlideshowImage = False Then
					If SubStroking = False Or SubEdging = True Or SubHoldingEdge = True Then
						' Begin Next Button

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:

						Dim TeaseDirection As Integer = randomizer.Next(1, 101)

						'Debug.Print("TeaseDirection = " & TeaseDirection)

						If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

							FileCount -= 1
							If FileCount < 0 Then
								FileCount = 0
							End If

							If DomTask.Contains("@Contact1") Then
								Contact1PicsCount -= 1
								If Contact1PicsCount < 0 Then
									Contact1PicsCount = 0
								End If
							End If

							If DomTask.Contains("@Contact2") Then
								Contact2PicsCount -= 1
								If Contact2PicsCount < 0 Then
									Contact2PicsCount = 0
								End If
							End If

							If DomTask.Contains("@Contact3") Then
								Contact3PicsCount -= 1
								If Contact3PicsCount < 0 Then
									Contact3PicsCount = 0
								End If
							End If

						Else


							FileCount += 1
							If FileCount > FileCountMax Then
								If FrmSettings.CBNewSlideshow.Checked = True Then
									NewDommeSlideshow = True
									OriginalDommeSlideshow = _ImageFileNames(0)
									LoadDommeImageFolder()
									NewDommeSlideshow = False
									DomPic = _ImageFileNames(FileCount)
								Else
									FileCount = FileCountMax
								End If
							End If

							If DomTask.Contains("@Contact1") Then
								Contact1PicsCount += 1
								Try
									If Contact1PicsCount > Contact1Pics.Count - 1 Then
										Contact1PicsCount = Contact1Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If DomTask.Contains("@Contact2") Then
								Contact2PicsCount += 1
								Try
									If Contact2PicsCount > Contact2Pics.Count - 1 Then
										Contact2PicsCount = Contact2Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If DomTask.Contains("@Contact3") Then
								Contact3PicsCount += 1
								Try
									If Contact3PicsCount > Contact3Pics.Count - 1 Then
										Contact3PicsCount = Contact3Pics.Count - 1
									End If
								Catch
								End Try
							End If

						End If

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

						If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryNextWithTease

						DomPic = _ImageFileNames(FileCount)

						If DomChat.Contains("@Contact1") Then
							Try
								DomPic = Contact1Pics(Contact1PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

						If DomChat.Contains("@Contact2") Then
							Try
								DomPic = Contact2Pics(Contact2PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

						If DomChat.Contains("@Contact3") Then
							Try
								DomPic = Contact3Pics(Contact3PicsCount)
							Catch
								DomPic = _ImageFileNames(FileCount)
							End Try
						End If

					End If
					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					' github patch If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

					If FrmSettings.CBSlideshowRandom.Checked = True Then
						If Contact1Pics.Count > 0 Then Contact1PicsCount = randomizer.Next(0, Contact1Pics.Count - 1)
						If Contact2Pics.Count > 0 Then Contact2PicsCount = randomizer.Next(0, Contact2Pics.Count - 1)
						If Contact3Pics.Count > 0 Then Contact3PicsCount = randomizer.Next(0, Contact3Pics.Count - 1)
					End If


					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					ShowPicture = True

					' End Next Button
					'On Error GoTo TryNextWithTease
					'On Error Resume Next
					' End Next Button
				End If

				If DomChat.Contains("@WritingTask(") Then
					Dim WriteFlag As String = GetParentheses(DomChat, "@WritingTask(")
					DomChat = DomChat.Replace(WriteFlag, PoundClean(WriteFlag))
				End If

				If DomChat.Contains("@Contact1") Or DomChat.Contains("@Contact2") Or DomChat.Contains("@Contact3") Then SubWroteLast = True

				Dim TypeName As String = domName.Text
				Dim TypeColor As String = DomColor
				Dim TypeFont As String = FrmSettings.FontComboBoxD.Text
				Dim TypeSize As String = FrmSettings.NBFontSizeD.Value
				If DomChat.Contains("@Contact1") Then
					TypeName = FrmSettings.TBGlitter1.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC1.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If
				If DomChat.Contains("@Contact2") Then
					TypeName = FrmSettings.TBGlitter2.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC2.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If
				If DomChat.Contains("@Contact3") Then
					TypeName = FrmSettings.TBGlitter3.Text
					TypeColor = Color2Html(FrmSettings.LBLGlitterNC3.ForeColor)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If


				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					Dim EmoteArray() As String = Split(DomChat)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					DomChat = Join(EmoteArray)
				End If


				Dim LoopBuffer As Integer = 0

				Do

					LoopBuffer += 1

					DomChat = DomChat.Replace("#Null", "")
					DomChat = PoundClean(DomChat)
					DomChat = CommandClean(DomChat)
					DomChat = StripCommands(DomChat)
					DomChat = DomChat.Replace("#Null", "")
					DomChat = PoundClean(DomChat)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not DomChat.Contains("#") And Not DomChat.Contains("@")



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

				If SysMes = False And EmoMes = False Then

					Try
						Dim UCASELine As String = UCase(DomChat.Substring(0, 1))
						DomChat = DomChat.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try

					If FrmSettings.LCaseCheckBox.Checked = True Then DomChat = LCase(DomChat)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(DomChat)
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
						DomChat = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then DomChat = DomChat.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then DomChat = DomChat.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then DomChat = DomChat.Replace(".", "")

					Dim EmoToggle As Boolean = True
					For i As Integer = DomChat.Length - 1 To 0 Step -1
						If DomChat.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								DomChat = DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								DomChat = DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					DomChat = DomChat.Replace(":d", ":D")
					DomChat = DomChat.Replace(": d", ": D")

				End If

				DomChat = DomChat.Replace("ATSYMBOL", "@")
				DomChat = DomChat.Replace("atsymbol", "@")

				If InputIcon = True Then
					DomChat = DomChat & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					InputIcon = False
				End If

				DomChat = DomChat.Replace(" a a", " an a")
				DomChat = DomChat.Replace(" a e", " an e")
				DomChat = DomChat.Replace(" a i", " an i")
				DomChat = DomChat.Replace(" a o", " an o")
				DomChat = DomChat.Replace(" a u", " an u")

				DomChat = DomChat.Replace(" an uni", " a uni")
				DomChat = DomChat.Replace(" an utensil", " a utensil")
				DomChat = DomChat.Replace(" an ukulele", " a ukulele")
				DomChat = DomChat.Replace(" an use", " a use")
				DomChat = DomChat.Replace(" an urethra", " a urethra")
				DomChat = DomChat.Replace(" an urine", " a urine")
				DomChat = DomChat.Replace(" an usual", " a usual")
				DomChat = DomChat.Replace(" an utility", " a utility")
				DomChat = DomChat.Replace(" an uterus", " a uterus")
				DomChat = DomChat.Replace(" an utopia", " a utopia")

				If NullResponse = True Or DomChat = "" Or DomChat Is Nothing Then GoTo NullResponseLine2

				If UCase(DomChat) = "<B>TEASE AI HAS BEEN RESET</B>" Then DomChat = "<b>Tease AI has been reset</b>"

				Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

				If SysMes = True Then
					Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & DomChat & "</b><br></font></body>"
					SysMes = False
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()
					GoTo EndSysMes
				End If

				If EmoMes = True Then
					Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""" &
			  TypeColor & """><b><i>" & DomChat & "</i></b><br></font></body>"
					EmoMes = False
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()
					GoTo EndSysMes
				End If

				' Add timestamps to domme response if the option is checked in the menu
				If FrmSettings.timestampCheckBox.Checked = True And FrmSettings.CBWebtease.Checked = False Then
					Chat = Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
				End If

				'Debug.Print("DomChat = " & DomChat)

				If SubWroteLast = False And FrmSettings.shownamesCheckBox.Checked = False Then


					If FrmSettings.CBWebtease.Checked = True Then
						Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						  TextColor & """><center>" & DomChat & "</center><br></font></body>"
					Else
						Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						 TextColor & """>" & Chat & DomChat & "<br></font></body>"
					End If


					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

					If RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
			  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomChat & "<br></font></body>"

				Else

					If FrmSettings.CBWebtease.Checked = True Then
						Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						 TextColor & """><center>" & DomChat & "</center><br></font></body>"
					Else
						Chat = "<body style=""word-wrap:break-word;"">" & Chat & "<font face=""Cambria"" size=""3"" font color=""" &
				TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomChat & "<br></font></body>"
					End If

					TypeToggle = 0
					ChatText.DocumentText = Chat
					While ChatText.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ChatText2.DocumentText = Chat
					While ChatText2.ReadyState <> WebBrowserReadyState.Complete
						Application.DoEvents()
					End While
					ScrollChatDown()

					If RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
			  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & DomChat & "<br></font></body>"

				End If

EndSysMes:



				ScrollChatDown()


				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				SubWroteLast = False

				If ShowPicture = True Or DommeImageFound = True Then


					Try
						If RiskyDeal = True Then
							' ######################## Risky Pick #########################
							FrmCardList.PBRiskyPic.Image = Image.FromFile(DomPic)
						ElseIf DommeImageFound = True Then
							' ######################## Domme Tags #########################
							ShowImage(DommeImageSTR, True)
							DommeImageFound = False
						ElseIf LocalImageFound = True Then
							' ######################## Local Img. #########################
							ShowImage(LocalImageSTR, True)
							LocalImageFound = False
						Else
							' ######################## Slideshow ##########################
							ShowImage(DomPic, True)
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
					DomChat = StripFormat(DomChat)
					synth.SelectVoice(FrmSettings.TTSComboBox.Text)
					synth.Speak(DomChat)
				End If

NullResponseLine2:

				If MultipleEdgesMetronome = "STOP" Then
					MultipleEdgesMetronome = ""
					StrokePace = 0
					SubStroking = False
					SubEdging = False
					DeactivateWebToy()
				End If

				If MultipleEdgesMetronome = "START" Then
					MultipleEdgesMetronome = ""
					EdgePace()
					SubStroking = True
					SubEdging = True
					ActivateWebToy()
					DisableContactStroke()
				End If

				Try
					If mainPictureBox.Visible = True Then
						If ImageLocation.Contains("/") Then
							Debug.Print("Timer1 PictureStrip")
							PictureStrip.Items(0).Enabled = True
							PictureStrip.Items(1).Enabled = True
							PictureStrip.Items(2).Enabled = True
							PictureStrip.Items(3).Enabled = True
							PictureStrip.Items(4).Enabled = True
							PictureStrip.Items(5).Enabled = True
						Else
							Debug.Print("Timer1 PictureStrip")
							PictureStrip.Items(0).Enabled = True
							PictureStrip.Items(1).Enabled = False
							PictureStrip.Items(2).Enabled = False
							PictureStrip.Items(3).Enabled = False
							PictureStrip.Items(4).Enabled = False
							PictureStrip.Items(5).Enabled = False
						End If
					End If
				Catch
					PictureStrip.Items(0).Enabled = False
					PictureStrip.Items(1).Enabled = False
					PictureStrip.Items(2).Enabled = False
					PictureStrip.Items(3).Enabled = False
					PictureStrip.Items(4).Enabled = False
					PictureStrip.Items(5).Enabled = False
				End Try


				StrokeSpeedCheck()

				If SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If SubHoldingEdge = True Then
					StrokePace = 0
				End If

				'Debug.Print("NullResponse = " & NullResponse)

				NullResponse = False

				If FollowUp <> "" Then
					DomChat = FollowUp
					FollowUp = ""
					TypingDelay()
					Exit Sub
				End If

				DomTypeCheck = False
				'StringLength = 20
				StringLength = randomizer.Next(8, 16)

				If SubStroking = False Then StopMetronome = True

				If TempScriptCount = 0 Then
					JustShowedBlogImage = False
					JustShowedSlideshowImage = False
				End If


				If CBTCockActive = True Then CBTCockActive = False
				If CBTBallsActive = True Then CBTBallsActive = False
				If CBTBothActive = True Then CBTBothActive = False



				If CBTCockFlag = True Or CBTBallsFlag = True Or CBTBothFlag = True Or CustomTask = True Then
					Dim CBTStop As Integer = randomizer.Next(1, 101)
					'Debug.Print("CBTSTop = " & CBTStop)
					If CBTStop < 30 Then
						CBTCockFlag = False
						CBTBallsFlag = False
						CBTBothFlag = False
						CustomTask = False
						CBTBallsFirst = True
						CBTCockFirst = True
						CBTBothFirst = True
						CustomTaskFirst = True
					End If
				End If

				If CBTCockFlag = True Then
					CBTCock()
				End If

				If CBTBallsFlag = True Then
					CBTBalls()
				End If

				If CBTBothFlag = True Then
					CBTBoth()
				End If

				If CustomTask = True Then
					RunCustomTask()
				End If

				If YesOrNo = False And Responding = False Then
					ScriptTick = randomizer.Next(4, 7)
					If RiskyDeal = True Then ScriptTick = 2
					ScriptTimer.Start()
				End If

				Responding = False

				If SubGaveUp = True Then

					SubGaveUp = False

					AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = SubStroking
					Dim WasEdging As Boolean = SubEdging
					Dim WasHolding As Boolean = SubHoldingEdge

					StopEverything()
					ModuleEnd = False
					ShowModule = False

					'DelayFlag = True
					'DelayTick = randomizer.Next(3, 6)

					'DelayTimer.Start()

					'Do
					'Application.DoEvents()
					'Loop Until DelayFlag = False

					LastScriptCountdown -= 1
					'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

					'FrmSettings.LBLOrgasmCountdown.Text = LastScriptCountdown

					If ReturnFlag Then
						ShowModule = True
						ScriptTimer.Start()
					ElseIf TeaseTick < 1 And Playlist = False Then
						StrokeTauntVal = -1
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						StrokeTauntVal = -1
						RunModuleScript(False)
					Else
						StrokeTauntVal = -1
						RunLinkScript()
					End If

				End If
			End If
		End If

	End Sub




#Region " Images "

	Private Sub browsefolderButton_Click(sender As System.Object, e As System.EventArgs) Handles browsefolderButton.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			GetFolder = FolderBrowserDialog1.SelectedPath

			RecentSlideshows.Add(GetFolder)

			Do Until RecentSlideshows.Count < 11
				RecentSlideshows.Remove(RecentSlideshows(0))
			Loop

			'Debug.Print(RecentSlideshows(0))

			ImageFolderComboBox.Items.Clear()

			For Each comboitem As String In RecentSlideshows
				ImageFolderComboBox.Items.Add(comboitem)
			Next

			ImageFolderComboBox.Text = GetFolder

			My.Settings.RecentSlideshows.Add(GetFolder)

			My.Settings.RecentSlideshows.Clear()

			For i As Integer = 0 To RecentSlideshows.Count - 1
				My.Settings.RecentSlideshows.Add(RecentSlideshows(i))
			Next

			My.Settings.Save()

			SlideshowLoaded = True

			' domVLC.playlist.pause()
			' domVLC.Visible = False
			DomWMP.Visible = False
			DomWMP.Ctlcontrols.pause()
			mainPictureBox.Visible = True
			'programsettingsPanel.Visible = False
			FrmSettings.timedRadio.Enabled = True
			FrmSettings.teaseRadio.Enabled = True




			'imgfolderTextBox.Text = GetFolder

			FileCount = 0
			FileCountMax = -1
			_ImageFileNames.Clear()


			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			'Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)

			Dim files As String()

			If FrmSettings.CBSlideshowSubDir.Checked = True Then
				files = myDirectory.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)
			Else
				files = myDirectory.GetFiles(GetFolder, "*.*")
			End If

			' Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*")
			Array.Sort(files)

			' For Each fi As String In files
			'If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
			'_ImageFileNames.AddRange(files)
			'End If
			'   Next

			Dim TestCOUnt As Integer = 0
			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					TestCOUnt += 1
					'Debug.Print("fi = " & fi)
					_ImageFileNames.Add(fi)
				End If
			Next

			' If FrmSettings.CBSlideshowSubDir.Checked = True Then
			'FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg", SearchOption.AllDirectories).Count
			'Else
			'   FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg").Count
			'  FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png").Count
			' FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif").Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp").Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg").Count
			'End If

			FileCountMax = _ImageFileNames.Count - 1

			'Debug.Print("FileCOuntMax = " & FileCountMax)


			If FileCountMax < 0 Then
				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			End If

			' Begin Next Button
			FileCount = 0

			'ClearMainPictureBox()


			If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

			ShowImage(_ImageFileNames(FileCount))



			nextButton.Enabled = True
			previousButton.Enabled = True
			DommeSlideshowToolStripMenuItem.Enabled = True

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
				SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
				SlideshowTimer.Start()
			End If
			' End Next Button
		End If

	End Sub

	Private Sub imagesNextButton_Click(sender As System.Object, e As System.EventArgs) Handles nextButton.Click
		' Begin Next Button

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If SlideshowLoaded = False Or TeaseVideo = True Then Return


TryNext:
		FileCount += 1
		'Debug.Print("Filecount = " & FileCount)
		'Debug.Print("FileCOuntMax = " & FileCountMax)
		If FileCount > FileCountMax Then
			FileCount = 0
		End If

		If File.Exists(_ImageFileNames(FileCount)) Then
		Else
			ClearMainPictureBox()
			Return
		End If

		If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryNext


		' ClearMainPictureBox()

		If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)



		Try
			ShowImage(_ImageFileNames(FileCount))

			JustShowedBlogImage = False

		Catch
			GoTo TryNext
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
		' End Next Button
		'On Error GoTo TryNext
		'On Error Resume Next

	End Sub

	Private Sub imagesPreviousButton_Click(sender As System.Object, e As System.EventArgs) Handles previousButton.Click

		' Begin Previous Button

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If


		If SlideshowLoaded = False Or TeaseVideo = True Then Return

TryPrevious:
		FileCount -= 1
		'Debug.Print("Filecount = " & FileCount)
		'Debug.Print("FileCOuntMax = " & FileCountMax)

		If FileCount < 0 Then
			FileCount = FileCountMax
		End If

		If File.Exists(_ImageFileNames(FileCount)) Then
		Else
			ClearMainPictureBox()
			Return
		End If

		If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryPrevious

		If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)


		Try
			ShowImage(_ImageFileNames(FileCount))


			JustShowedBlogImage = False
		Catch
			GoTo TryPrevious
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
		'On Error GoTo TryPrevious
		'On Error Resume Next
	End Sub






#End Region

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


	Private Sub StrokeTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles StrokeTimer.Tick


		If InputFlag = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		If DomTypeCheck = True And StrokeTick < 5 Then Return
		If chatBox.Text <> "" And StrokeTick < 5 Then Return
		If ChatBox2.Text <> "" And StrokeTick < 5 Then Return
		If MiniScript = True And StrokeTick < 5 Then Return
		If FollowUp <> "" And StrokeTick < 5 Then Return


		If FrmSettings.CBDebugTauntsEndless.Checked = True And StrokeTick < 5 Then Return

		StrokeTick -= 1
		FrmSettings.LBLCycleDebugCountdown.Text = StrokeTick

		FrmSettings.LBLDebugStrokeTime.Text = StrokeTick
		'Debug.Print("StrokeTick = " & StrokeTick)

		If StrokeTick < 4 And TempScriptCount > 0 Then StrokeTick += 1

		If StrokeTick < 1 Then

			FirstRound = False

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()

			If RunningScript = True Then
				ScriptTick = 3
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

			StrokeTick -= 1
			Debug.Print("Threaded StrokeTick = " & StrokeTick)
SkipTick:

			Thread.Sleep(1000)

		Loop Until StrokeTick = 0

		If StrokeTick = 0 Then

			FirstRound = False

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()

			If RunningScript = True Then
				ScriptTick = 3
				ScriptTimer.Start()
			Else

				RunModuleScript(False)

			End If


		End If



	End Sub


	Private Sub StrokeTauntTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles StrokeTauntTimer.Tick

		If MiniScript = True Then Return
		If InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And StrokeTauntTick < 6 Then Return
		If chatBox.Text <> "" And StrokeTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And StrokeTauntTick < 6 Then Return








		StrokeTauntTick -= 1

		FrmSettings.LBLDebugStrokeTauntTime.Text = StrokeTauntTick
		'Debug.Print("StrokeTauntTick = " & StrokeTauntTick)

		If StrokeTauntTick = 0 Then

			' TauntText = Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\StrokeTaunts.txt"

			If TempScriptCount = 0 Then



				'Debug.Print("TempScriptCount = 0")

				If FrmSettings.teaseRadio.Checked = True And JustShowedBlogImage = False And TeaseVideo = False And Not DomTask.Contains("@NewBlogImage") And SlideshowLoaded = True And CustomSlideshow = False And RapidFire = False Then
					'If FrmSettings.teaseRadio.Checked = True And JustShowedBlogImage = False And TeaseVideo = False And Not DomTask.Contains("@NewBlogImage") Then
TryNextWithTease:

					Dim TeaseDirection As Integer = randomizer.Next(1, 101)

					If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

						FileCount -= 1

						If FileCount < 0 Then
							FileCount = 0
						End If

					Else


						FileCount += 1
						If FileCount > FileCountMax Then
							If FrmSettings.CBNewSlideshow.Checked = True Then
								NewDommeSlideshow = True
								OriginalDommeSlideshow = _ImageFileNames(0)
								LoadDommeImageFolder()
								NewDommeSlideshow = False
								DomPic = _ImageFileNames(FileCount)
							Else
								FileCount = FileCountMax
							End If
						End If

					End If

					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryNextWithTease

					DomPic = _ImageFileNames(FileCount)

					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)



				End If


				'BlankLineLoop:

				Dim TauntFile As String
				TauntFile = "StrokeTaunts"
				If My.Settings.Chastity = True Then TauntFile = "ChastityTaunts"
				If GlitterTease = True Then TauntFile = "GlitterTaunts"
				' ### Debug
				'TauntFile = "StrokeTaunts"

				TauntTextCount = 0
				ScriptCount = 0
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\", FileIO.SearchOption.SearchTopLevelOnly, TauntFile & "_*.txt")
					ScriptCount += 1
				Next

				'Dim LinScript As Integer
				' LinSelected = False

				'For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Linear Taunts", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				'LinScript += 1
				'Next

				Dim TauntTempVal As Integer = randomizer.Next(1, 101)

				'If LinScript = 0 Then

				If TauntTempVal < 45 Then
					TauntTempVal = 1
				Else
					TauntTempVal = randomizer.Next(1, ScriptCount + 1)
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
				StrokeTauntCount = TauntTempVal
				ScriptCount = 0
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\", FileIO.SearchOption.SearchTopLevelOnly, TauntFile & "_*.txt")
					ScriptCount += 1
					If TauntTempVal = ScriptCount Then TauntText = foundFile
				Next
				ScriptCount = TauntTempVal
				'End If

			End If

			'Debug.Print("ScriptCount = " & ScriptCount)

			'Debug.Print("TempScriptCOunt = " & TempScriptCount)





			' ##############################################################################################################






			If TempScriptCount = 0 Then 'And LinSelected = False Then

				' Uneseccary for txt2List creates a new List(of ) instance.
				TauntLines.Clear()
				' Read all lines of given File.
				TauntLines = Txt2List(TauntText)
				TauntTextTotal = TauntLines.Count

				TauntTextTotal -= 1

				StrokeFilter = True



				Try
					TauntLines = FilterList(TauntLines)
				Catch
					DomTask = "ERROR: Tease AI did not return a valid Taunt"
				End Try

				StrokeFilter = False

				TauntTextTotal = TauntLines.Count

				'Debug.Print("TauntTextTotal = " & TauntTextTotal)


			End If




			'##############################################################################################################



			If TempScriptCount = 0 Then ' And LinSelected = False Then
				'Debug.Print("Equal called")
				TempScriptCount = ScriptCount
				TauntTextTotal /= ScriptCount
				TauntTextCount = randomizer.Next(0, TauntTextTotal) * ScriptCount
				If FrmSettings.CBDebugTaunts.Checked = True Then TauntTextCount = 0
			Else
				'Debug.Print("Not equal called")
				TauntTextCount += 1
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

			TempScriptCount -= 1




			'Debug.Print("TauntTextCount = " & TauntTextCount)




			Try
				DomTask = TauntLines(TauntTextCount)
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Taunt"
			End Try


			If FrmSettings.CBDebugTaunts.Checked = True Then
				DomTask = ""
				If TauntTextCount = 0 Then DomTask = FrmSettings.TBDebugTaunts1.Text
				If TauntTextCount = 1 Then DomTask = FrmSettings.TBDebugTaunts2.Text
				If TauntTextCount = 2 Then DomTask = FrmSettings.TBDebugTaunts3.Text
				If DomTask = "" Then DomTask = "@SystemMessage ERROR: Debug field is currently blank"
			End If

			If DomTask.Contains("@ShowTaggedImage") Then JustShowedBlogImage = True

			'If DomTask = "" Then GoTo BlankLineLoop

			If InStr(UCase(DomTask), UCase("@CBT")) <> 0 Then
				CBTScript()
			Else
				TypingDelayGeneric()
			End If



			If TempScriptCount = 0 Then
				If FrmSettings.SliderSTF.Value = 1 Then StrokeTauntTick = randomizer.Next(120, 241)
				If FrmSettings.SliderSTF.Value = 2 Then StrokeTauntTick = randomizer.Next(75, 121)
				If FrmSettings.SliderSTF.Value = 3 Then StrokeTauntTick = randomizer.Next(45, 76)
				If FrmSettings.SliderSTF.Value = 4 Then StrokeTauntTick = randomizer.Next(25, 46)
				If FrmSettings.SliderSTF.Value = 5 Then StrokeTauntTick = randomizer.Next(15, 26)
				'StrokeTauntTick = randomizer.Next(11, 21)
			Else
				StrokeTauntTick = randomizer.Next(5, 9)
			End If






		End If





	End Sub

	Public Sub CBTScript()

		Dim CBTAmount As Integer

		CBT = True
		YesOrNo = True
		Dim CBTCount As Integer

		Dim lines As List(Of String) = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBT.txt")
		CBTCount += lines.Count

		CBTCount = randomizer.Next(0, CBTCount)

		DomTask = lines(CBTCount)

		CBTAmount = randomizer.Next(1, 6) * 2 * FrmSettings.domlevelNumBox.Value
		DomTask = DomTask.Replace("#CBTAmount", CBTAmount)

		TypingDelayGeneric()


	End Sub



	Private Sub DelayTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles DelayTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DelayTick < 10 And chatBox.Text <> "" Then Return
		If DelayTick < 10 And ChatBox2.Text <> "" Then Return
		If DelayTick < 3 And DomTypeCheck = True Then Return

		DelayTick -= 1

		If DelayTick < 1 Then
			DelayTimer.Stop()
			DelayFlag = False
		End If


	End Sub

#Region "----------------------------------------------------- Video-Files ----------------------------------------------------"

	Public Sub RandomVideo()
		' Reset retentive global variables
		NoVideo = False
		DommeVideo = False

		Dim __dom As Random = New Random()
		Dim __domVideo As String
		Dim __TotalFiles As New List(Of String)

		'======================================================================================
		'									Genre Videos
		'======================================================================================
		If FrmSettings.CBVideoHardcore.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoHardCore.Text))

		If FrmSettings.CBVideoSoftCore.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoSoftCore.Text))

		If FrmSettings.CBVideoLesbian.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoLesbian.Text))

		If FrmSettings.CBVideoBlowjob.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoBlowjob.Text))

		If FrmSettings.CBVideoFemdom.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoFemdom.Text))

		If FrmSettings.CBVideoFemsub.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoFemsub.Text))

		If NoSpecialVideo = True Then GoTo SkipSpecial

		If ScriptVideoTeaseFlag = True Then
			If ScriptVideoTease = "Censorship Sucks" Or ScriptVideoTease = "Avoid The Edge" Or ScriptVideoTease = "RLGL" Then GoTo SkipSpecial
		End If

		If RandomizerVideo = True Then GoTo SkipSpecial

		'======================================================================================
		'								Special - Videos
		'======================================================================================
		If FrmSettings.CBVideoJOI.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoJOI.Text))

		If FrmSettings.CBVideoCH.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoCH.Text))

SkipSpecial:
		'======================================================================================
		'									General Videos
		'======================================================================================
		If FrmSettings.CBVideoGeneral.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoGeneral.Text))

		'======================================================================================
		'									Domme - Videos
		'======================================================================================
		If FrmSettings.CBVideoHardcoreD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoHardCoreD.Text))

		If FrmSettings.CBVideoSoftCoreD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoSoftCoreD.Text))

		If FrmSettings.CBVideoLesbianD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoLesbianD.Text))

		If FrmSettings.CBVideoBlowjobD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoBlowjobD.Text))

		If FrmSettings.CBVideoFemdomD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoFemdomD.Text))

		If FrmSettings.CBVideoFemsubD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoFemsubD.Text))

		If NoSpecialVideo = True Then GoTo SkipSpecialD
		If ScriptVideoTeaseFlag = True Then
			If ScriptVideoTease = "Censorship Sucks" Or ScriptVideoTease = "Avoid The Edge" Or ScriptVideoTease = "RLGL" Then GoTo SkipSpecialD
		End If

		If RandomizerVideo = True Then GoTo SkipSpecialD

		'======================================================================================
		'								Domme - Special - Videos
		'======================================================================================
		If FrmSettings.CBVideoJOID.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoJOID.Text))

		If FrmSettings.CBVideoCHD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoCHD.Text))

SkipSpecialD:
		'======================================================================================
		'								Domme - General Videos
		'======================================================================================
		If FrmSettings.CBVideoGeneralD.Checked = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoGeneralD.Text))



		If __TotalFiles.Count = 0 Then Exit Sub

		If VideoCheck = True Then Exit Sub

GetAnotherRandomVideo:

		__domVideo = __TotalFiles(__dom.Next(0, __TotalFiles.Count - 1))

		If __domVideo = "" Then GoTo GetAnotherRandomVideo

		'@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Debug Line @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		If Debugger.IsAttached AndAlso 1 = 2 Then _
			__TotalFiles.ForEach(Sub(x) Debug.Print("RndVideoCheck: " & x))


		If FrmSettings.CBVideoHardcore.Checked = True And InStr(__domVideo, FrmSettings.LblVideoHardCore.Text) <> 0 Then VideoType = "Hardcore"
		If FrmSettings.CBVideoSoftCore.Checked = True And InStr(__domVideo, FrmSettings.LblVideoSoftCore.Text) <> 0 Then VideoType = "Softcore"
		If FrmSettings.CBVideoLesbian.Checked = True And InStr(__domVideo, FrmSettings.LblVideoLesbian.Text) <> 0 Then VideoType = "Lesbian"
		If FrmSettings.CBVideoBlowjob.Checked = True And InStr(__domVideo, FrmSettings.LblVideoBlowjob.Text) <> 0 Then VideoType = "Blowjob"
		If FrmSettings.CBVideoFemdom.Checked = True And InStr(__domVideo, FrmSettings.LblVideoFemdom.Text) <> 0 Then VideoType = "Femdom"
		If FrmSettings.CBVideoFemsub.Checked = True And InStr(__domVideo, FrmSettings.LblVideoFemsub.Text) <> 0 Then VideoType = "Femsub"
		If FrmSettings.CBVideoJOI.Checked = True And InStr(__domVideo, FrmSettings.LblVideoJOI.Text) <> 0 Then VideoType = "JOI"
		If FrmSettings.CBVideoCH.Checked = True And InStr(__domVideo, FrmSettings.LblVideoCH.Text) <> 0 Then VideoType = "CH"
		If FrmSettings.CBVideoGeneral.Checked = True And InStr(__domVideo, FrmSettings.LblVideoGeneral.Text) <> 0 Then VideoType = "General"


		If FrmSettings.CBVideoHardcoreD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoHardCoreD.Text) <> 0 Then
			VideoType = "HardcoreD"
			DommeVideo = True
		End If
		If FrmSettings.CBVideoSoftCoreD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoSoftCoreD.Text) <> 0 Then
			VideoType = "SoftcoreD"
			DommeVideo = True
		End If
		If FrmSettings.CBVideoLesbianD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoLesbianD.Text) <> 0 Then
			VideoType = "LesbianD"
			DommeVideo = True
		End If

		If FrmSettings.CBVideoBlowjobD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoBlowjobD.Text) <> 0 Then
			VideoType = "BlowjobD"
			DommeVideo = True
		End If
		If FrmSettings.CBVideoFemdomD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoFemdomD.Text) <> 0 Then
			VideoType = "FemdomD"
			DommeVideo = True
		End If
		If FrmSettings.CBVideoFemsubD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoFemsubD.Text) <> 0 Then
			VideoType = "FemsubD"
			DommeVideo = True
		End If

		If FrmSettings.CBVideoJOID.Checked = True And InStr(__domVideo, FrmSettings.LblVideoJOID.Text) <> 0 Then
			VideoType = "JOID"
			DommeVideo = True
		End If

		If FrmSettings.CBVideoCHD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoCHD.Text) <> 0 Then
			VideoType = "CHD"
			DommeVideo = True
		End If

		If FrmSettings.CBVideoGeneralD.Checked = True And InStr(__domVideo, FrmSettings.LblVideoGeneralD.Text) <> 0 Then
			VideoType = "GeneralD"
			DommeVideo = True
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



		If JumpVideo = True Then
			Do
				Application.DoEvents()
			Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

			VideoJump2Random(Nothing, Nothing)

		End If

		JumpVideo = False
	End Sub



	Friend Sub PlayRandomJOI()
		'ISSUE: there is no control, if a Domme-Video or a Regular JOI is played.
		'ISSUE: Redundant Code
		Dim JOIVideos As New List(Of String)
		JOIVideos.Clear()

		If FrmSettings.LblVideoJOITotal.Text <> "0" And FrmSettings.CBVideoJOI.Checked = True Then

			JOIVideos.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoJOI.Text,
														 System.IO.SearchOption.AllDirectories))
		End If

		If FrmSettings.LblVideoJOITotalD.Text <> "0" And FrmSettings.CBVideoJOID.Checked = True Then
			JOIVideos.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoJOI.Text,
														 System.IO.SearchOption.AllDirectories))
		End If

		If JOIVideos.Count < 1 Then
			'ISSUE: This Message will occur during running Scripts!
			MessageBox.Show(Me, "No JOI Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If TeaseVideo = True Then RunFileText()
			TeaseVideo = False
			Return
		End If

		Dim JOIVideoLine As Integer = randomizer.Next(0, JOIVideos.Count)

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

		If FrmSettings.LblVideoCHTotal.Text <> "0" And FrmSettings.CBVideoCH.Checked = True Then
			CHVideos.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoCH.Text))
		End If
		If FrmSettings.LblVideoCHTotalD.Text <> "0" And FrmSettings.CBVideoCHD.Checked = True Then
			CHVideos.AddRange(myDirectory.GetFilesVideo(FrmSettings.LblVideoCHD.Text))
		End If

		If CHVideos.Count < 1 Then
			'ISSUE: This Message will occur during running Scripts!
			MessageBox.Show(Me, "No CH Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If TeaseVideo = True Then RunFileText()
			TeaseVideo = False
			Return
		End If

		Dim CHVideoLine As Integer = randomizer.Next(0, CHVideos.Count)

		DomWMP.Visible = True
		DomWMP.stretchToFit = True

		mainPictureBox.Visible = False

		DomWMP.URL = CHVideos(CHVideoLine)


	End Sub


#Region "----------------------------------------------------- Video-Totals ---------------------------------------------------"

	Public Sub HardCoreVideoTotal()
		FrmSettings.LblVideoHardCoreTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoHardCore.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoHardCoreTotal.Text)
	End Sub

	Public Sub SoftcoreVideoTotal()
		FrmSettings.LblVideoSoftCoreTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoSoftCore.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoSoftCoreTotal.Text)
	End Sub

	Public Sub LesbianVideoTotal()
		FrmSettings.LblVideoLesbianTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoLesbian.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoLesbianTotal.Text)
	End Sub

	Public Sub BlowjobVideoTotal()
		FrmSettings.LblVideoBlowjobTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoBlowjob.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoBlowjobTotal.Text)
	End Sub

	Public Sub FemdomVideoTotal()
		FrmSettings.LblVideoFemdomTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoFemdom.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoFemdomTotal.Text)
	End Sub

	Public Sub FemsubVideoTotal()
		FrmSettings.LblVideoFemsubTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoFemsub.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoFemsubTotal.Text)
	End Sub

	Public Sub JOIVideoTotal()
		FrmSettings.LblVideoJOITotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoJOI.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoJOITotal.Text)
	End Sub

	Public Sub CHVideoTotal()
		FrmSettings.LblVideoCHTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoCH.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoCHTotal.Text)
	End Sub

	Public Sub GeneralVideoTotal()
		FrmSettings.LblVideoGeneralTotal.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoGeneral.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoGeneralTotal.Text)
	End Sub

	Public Sub HardcoreDVideoTotal()
		FrmSettings.LblVideoHardCoreTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoHardCoreD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoHardCoreTotalD.Text)
	End Sub


	Public Sub SoftcoreDVideoTotal()
		FrmSettings.LblVideoSoftCoreTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoSoftCoreD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoSoftCoreTotalD.Text)
	End Sub


	Public Sub LesbianDVideoTotal()
		FrmSettings.LblVideoLesbianTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoLesbianD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoLesbianTotalD.Text)
	End Sub


	Public Sub BlowjobDVideoTotal()
		FrmSettings.LblVideoBlowjobTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoBlowjobD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoBlowjobTotalD.Text)
	End Sub

	Public Sub FemdomDVideoTotal()
		FrmSettings.LblVideoFemdomTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoFemdomD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoFemdomTotalD.Text)
	End Sub


	Public Sub FemsubDVideoTotal()
		FrmSettings.LblVideoFemsubTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoFemsubD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoFemsubTotalD.Text)
	End Sub


	Public Sub JOIDVideoTotal()
		FrmSettings.LblVideoJOITotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoJOID.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoJOITotalD.Text)
	End Sub


	Public Sub CHDVideoTotal()
		FrmSettings.LblVideoCHTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoCHD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoCHTotalD.Text)
	End Sub


	Public Sub GeneralDVideoTotal()
		FrmSettings.LblVideoGeneralTotalD.Text = myDirectory.GetFilesVideo(FrmSettings.LblVideoGeneralD.Text).Count
		RefreshVideoTotal += CInt(FrmSettings.LblVideoGeneralTotalD.Text)
	End Sub

#End Region

#End Region


	Private Sub SettingsButton_Click(sender As System.Object, e As System.EventArgs) Handles SettingsButton.Click
		If FrmSettings.Visible = True Then
			FrmSettings.Visible = False
			SettingsButton.Text = "Open Settings Menu"
		Else
			FrmSettings.Visible = True
			SettingsButton.Text = "Close Settings Menu"
		End If
	End Sub



	Public Sub CensorshipTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles CensorshipTimer.Tick


		If MiniScript = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And CensorshipTick < 6 Then Return
		If chatBox.Text <> "" And CensorshipTick < 6 Then Return
		If ChatBox2.Text <> "" And CensorshipTick < 6 Then Return
		If FollowUp <> "" And CensorshipTick < 6 Then Return

		CensorshipTick -= 1


		If CensorshipTick < 1 Then


			Dim CensorLineTemp As Integer = randomizer.Next(1, 101)


			Dim CensorVideo As String

			If FrmSettings.CBCensorConstant.Checked = True Then GoTo CensorConstant

			If CensorshipBar.Visible = True Then
				CensorshipBar.Visible = False
				CensorshipTick = randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)

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
					CensorshipBarY2 = randomizer.Next(200, DomWMP.Height / 2)
				Catch
					CensorshipBarY2 = 100
				End Try

				CensorshipBar.Height = CensorshipBarY2
				CensorshipBar.Width = CensorshipBarY2 * 2.6

				'QnD-BUGFIX: if CensorshipBar.Width > DomWMP.Width then ArgumentOutOfRangeException 
				CensorshipBarX = randomizer.Next(5, If(CensorshipBar.Width > DomWMP.Width, DomWMP.Width, DomWMP.Width - CensorshipBar.Width + 1))
				CensorshipBarY = randomizer.Next(5, If(CensorshipBar.Height > DomWMP.Height, DomWMP.Height, DomWMP.Height - CensorshipBar.Height + 1))
				CensorshipBar.Location = New Point(CensorshipBarX, CensorshipBarY)



				CensorshipBar.Visible = False
				CensorshipBar.Visible = True

				CensorshipTick = randomizer.Next(FrmSettings.NBCensorShowMin.Value, FrmSettings.NBCensorShowMax.Value + 1)

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
				CensorLine = randomizer.Next(0, lines.Count)
				DomTask = lines(CensorLine)
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Censorship Sucks line"
			End Try

			TypingDelayGeneric()

		End If

	End Sub


	Public Sub RLGLTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles RLGLTimer.Tick
		' Check all Conditions before starting scripts.
		If MiniScript = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And RLGLTick < 6 Then Return
		If chatBox.Text <> "" And RLGLTick < 6 Then Return
		If ChatBox2.Text <> "" And RLGLTick < 6 Then Return
		If FollowUp <> "" And RLGLTick < 6 Then Return

		' Decrement TickCounter if Game is running.
		If RLGLGame = True Then RLGLTick -= 1

		' Run scripts only if time is over.
		If RLGLTick < 1 Then
			' Swap the BooleanValue
			RedLight = Not RedLight
			' Turn off TauntTimer when State is red.
			If RedLight Then RLGLTauntTimer.Stop()

			' Declare list to read
			Dim tempList As List(Of String)

			' Read File according to state and set the next timer-tick-duration.
			If RedLight Then
				'################################## RED - Light ##################################
				tempList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Red Light.txt")
				RLGLTick = randomizer.Next(FrmSettings.NBRedLightMin.Value, FrmSettings.NBRedLightMax.Value + 1)
			Else
				'################################## Green - Light ################################
				tempList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Green Light.txt")
				RLGLTick = randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
			End If

			Try
				tempList = FilterList(tempList)
				DomTask = tempList(randomizer.Next(0, tempList.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid RLGL line"
			End Try

			TypingDelayGeneric()
		End If
	End Sub





	Private Sub domName_Leave(sender As System.Object, e As System.EventArgs) Handles domName.Leave
		My.Settings.DomName = domName.Text
		My.Settings.Save()
	End Sub
	Private Sub subName_Leave(sender As System.Object, e As System.EventArgs) Handles subName.Leave
		My.Settings.SubName = subName.Text
		My.Settings.Save()
	End Sub


	Public Sub StatusUpdatePost()


		UpdatingPost = True


		If UpdateStage > 0 Then GoTo StatusUpdateBegin

		StatusText = UpdateList(randomizer.Next(0, UpdateList.Count))

		For i As Integer = 0 To UpdateList.Count - 1
			Debug.Print(i & ". " & UpdateList(i))
		Next
		Debug.Print("STatusText = " & StatusText)
		Debug.Print("Clear stage 1")

		' Read all lines of the given File.
		Dim lines As List(Of String) = Txt2List(StatusText)


		For i As Integer = lines.Count - 1 To 0 Step -1
			If lines(i) = "" Or lines(i) Is Nothing Then
				lines.Remove(lines(i))
			End If
		Next

		StatusText = lines(0)
		Debug.Print("HEre?")
		' Github Patch  StatusText = PoundClean(StatusText)

		Dim LoopBuffer As Integer = 0
		Do
			LoopBuffer += 1

			StatusText = PoundClean(StatusText)

			If LoopBuffer > 4 Then Exit Do

		Loop Until Not DomTask.Contains("#")


		Dim AtArray() As String = Split(StatusText)
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
		StatusText = Join(AtArray)

		Dim DPic As String = My.Settings.GlitterAV
		DPic = "file://" & DPic
		DPic = DPic.Replace("\", "/")
		Debug.Print(DPic)

		Dim StatusName As String


		Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

		StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 48; height: 48; border: 0;"" src=""" & DPic & """> <font face=""Cambria"" size=""3"" color=""" & GlitterNCDomme & """><b>" & domName.Text & "</b></font> <br><font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br><br>"
		StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & StatusText & "</font><br><br>"

		'Debug.Print(GlitterImageAV)
		Debug.Print("Clear Stage 2")




		Dim StatusLines1 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines1.Add(lines(i))
		Next
		ContactNumber = 1

		' For i As Integer = StatusLines1.Count - 1 To 0 Step -1
		'If StatusLines1(i) = "" Or StatusLines1(i) Is Nothing Then
		'StatusLines1.Remove(StatusLines1(i))
		'End If
		'Next

		StatusLines1 = StatusClean(StatusLines1)



		StatusText1 = StatusLines1(randomizer.Next(0, StatusLines1.Count))

		Dim StatusLines2 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines2.Add(lines(i))
		Next
		ContactNumber = 2

		' For i As Integer = StatusLines2.Count - 1 To 0 Step -1
		'If StatusLines2(i) = "" Or StatusLines2(i) Is Nothing Then
		'StatusLines2.Remove(StatusLines2(i))
		'End If
		'Next

		StatusLines2 = StatusClean(StatusLines2)




		Do
			StatusText2 = StatusLines2(randomizer.Next(0, StatusLines2.Count))
		Loop Until StatusText2 <> StatusText1


		Dim StatusLines3 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines3.Add(lines(i))
		Next
		ContactNumber = 3

		'For i As Integer = StatusLines3.Count - 1 To 0 Step -1
		'If StatusLines3(i) = "" Or StatusLines3(i) Is Nothing Then
		'StatusLines3.Remove(StatusLines3(i))
		'End If
		'Next

		StatusLines3 = StatusClean(StatusLines3)

		Do
			StatusText3 = StatusLines3(randomizer.Next(0, StatusLines3.Count))
		Loop Until StatusText3 <> StatusText2 And StatusText3 <> StatusText1

		''Debug.Print("StatusLine = " & StatusLine)




		StatusText1 = StatusText1.Replace("#ShortName", FrmSettings.TBGlitterShortName.Text)
		StatusText2 = StatusText2.Replace("#ShortName", FrmSettings.TBGlitterShortName.Text)
		StatusText3 = StatusText3.Replace("#ShortName", FrmSettings.TBGlitterShortName.Text)

		StatusText1 = StatusText1.Replace("#SubName", subName.Text)
		StatusText2 = StatusText2.Replace("#SubName", subName.Text)
		StatusText3 = StatusText3.Replace("#SubName", subName.Text)

		StatusText1 = PoundClean(StatusText1)
		StatusText2 = PoundClean(StatusText2)
		StatusText3 = PoundClean(StatusText3)

		'GoTo TestSkip

		Dim AtArray1() As String = Split(StatusText1)
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
		StatusText1 = Join(AtArray1)

		Dim AtArray2() As String = Split(StatusText2)
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
		StatusText2 = Join(AtArray2)

		Dim AtArray3() As String = Split(StatusText3)
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
		StatusText3 = Join(AtArray3)

		'TestSkip:

		Update1 = False
		Update2 = False
		Update3 = False

		StatusChance1 = randomizer.Next(1, 101)
		StatusChance2 = randomizer.Next(1, 101)
		StatusChance3 = randomizer.Next(1, 101)

		UpdateStageTick = randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		UpdateStage = 1
		Return


StatusUpdateBegin:

		If Update1 = True And Update2 = True And Update3 = True Then GoTo StatusUpdateEnd

		'ContactTick = randomizer.Next(10, 21)
		'ContactFlag = True
		'ContactTimer.Start()

		'Do
		'Application.DoEvents()
		'Loop Until ContactFlag = False

		'Delay(RandomDelay)

ReRoll:

		TempVal = randomizer.Next(1, 4)
		'Debug.Print("TempVal = " & TempVal)

		If TempVal = 1 Then
			If Update1 = False Then
				GoTo StatusUpdate1
			Else
				GoTo ReRoll
			End If
		End If

		If TempVal = 2 Then
			If Update2 = False Then
				GoTo StatusUpdate2
			Else
				GoTo ReRoll
			End If
		End If

		If TempVal = 3 Then
			If Update3 = False Then
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

		If StatusChance1 < FrmSettings.GlitterSlider1.Value * 10 And FrmSettings.CBGlitter1.Checked = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S1Pic & """> <font face=""Cambria"" size=""3"" color=""" & GlitterNC1 & """><b>" & FrmSettings.TBGlitter1.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & StatusText1 & "</font><br><br>"


		End If

		Update1 = True

		UpdateStageTick = randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return
		'GoTo StatusUpdateBegin

StatusUpdate2:

		Dim S2Pic As String = My.Settings.GlitterAV2
		S2Pic = "file://" & S2Pic
		S2Pic = S2Pic.Replace("\", "/")
		Debug.Print(S2Pic)

		TextColor = Color2Html(My.Settings.ChatTextColor)

		If StatusChance2 < FrmSettings.GlitterSlider2.Value * 10 And FrmSettings.CBGlitter2.Checked = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S2Pic & """> <font face=""Cambria"" size=""3"" color=""" & GlitterNC2 & """><b>" & FrmSettings.TBGlitter2.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & StatusText2 & "</font><br><br>"


		End If

		Update2 = True
		UpdateStageTick = randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return

		'GoTo StatusUpdateBegin

StatusUpdate3:

		Dim S3Pic As String = My.Settings.GlitterAV3
		S3Pic = "file://" & S3Pic
		S3Pic = S3Pic.Replace("\", "/")
		Debug.Print(S3Pic)

		TextColor = Color2Html(My.Settings.ChatTextColor)

		If StatusChance3 < FrmSettings.GlitterSlider3.Value * 10 And FrmSettings.CBGlitter3.Checked = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S3Pic & """> <font face=""Cambria"" size=""3"" color=""" & GlitterNC3 & """><b>" & FrmSettings.TBGlitter3.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & StatusText3 & "</font><br><br>"


		End If

		Update3 = True

		UpdateStageTick = randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return
		'GoTo StatusUpdateBegin

StatusUpdateEnd:

		UpdateStage = 0

		' Github Patch 'StatusText = "Null" & Environment.NewLine & "Null" & Environment.NewLine & "Null" & Environment.NewLine & "Null" & Environment.NewLine

		UpdatingPost = False


	End Sub

	Public Function StatusClean(ByVal ListClean As List(Of String)) As List(Of String)



		ListClean.Add("### BUFFER LINE ###")
		Debug.Print("ListClean.Count = " & ListClean.Count)

		If ContactNumber = 1 Then
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

		If ContactNumber = 2 Then
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

		If ContactNumber = 3 Then
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
			If ContactNumber = 1 Then DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 1"
			If ContactNumber = 2 Then DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 2"
			If ContactNumber = 3 Then DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 3"
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
			My.Settings.Save()
		End If
	End Sub

	Private Sub UpdatesTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles UpdatesTimer.Tick

		'Debug.Print("updates tick = " & UpdatesTick)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If FrmSettings.CBGlitterFeed.Checked = True And UpdatingPost = False Then

			UpdatesTick -= 1

			If UpdatesTick < 1 Then

				UpdatesTick = 1080 / FrmSettings.GlitterSlider.Value

				UpdateList.Clear()

				If FrmSettings.CBTease.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Tease\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBEgotist.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Egotist\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBTrivia.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Trivia\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBDaily.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Daily\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBCustom1.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Custom 1\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBCustom2.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Custom 2\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						UpdateList.Add(foundFile)
					Next
				End If

				If UpdateList.Count < 1 Then
					FrmSettings.CBGlitterFeed.Checked = False
					'MessageBox.Show(Me, "Tease AI attempted to create a Glitter update, but no files were found! Please make sure at least one category containing Glitter txt files has been selected.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MessageBox.Show(Me, "Tease AI attempted to create a Glitter update, but no files were found! Please make sure at least one category containing Glitter txt files has been selected." & Environment.NewLine _
					& Environment.NewLine & "Glitter feed has been automatically disabled.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If



				StatusUpdatePost()



			End If

		End If
	End Sub





	Private Sub MediaButton_Click(sender As System.Object, e As System.EventArgs) Handles MediaButton.Click

		If SplitContainer1.Panel2.Height < 68 Then Return

		If PNLMediaBar.Visible = True Then
			PNLMediaBar.Visible = False
			MediaButton.Text = "Show Media Panel"
			'ChatText.Location = New Point(0, 0)
			'ChatText.Height = ChatText.Height + 29

			browsefolderButton.Visible = False
			previousButton.Visible = False
			nextButton.Visible = False
			BTNLoadVideo.Visible = False
			BTNVideoControls.Visible = False

		Else

			PNLMediaBar.Visible = True
			MediaButton.Text = "Hide Media Panel"
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
						TempText = TextArray(randomizer.Next(0, TextArray.Count))
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
						TempText = TextArray(randomizer.Next(0, TextArray.Count))
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

		StringClean = StringClean.Replace("#DomMood", DommeMood)

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

		StringClean = StringClean.Replace("#ShortName", FrmSettings.TBGlitterShortName.Text)

		StringClean = StringClean.Replace("#GlitterContact1", FrmSettings.TBGlitter1.Text)
		StringClean = StringClean.Replace("#Contact1", FrmSettings.TBGlitter1.Text)
		StringClean = StringClean.Replace("#GlitterContact2", FrmSettings.TBGlitter2.Text)
		StringClean = StringClean.Replace("#Contact2", FrmSettings.TBGlitter2.Text)
		StringClean = StringClean.Replace("#GlitterContact3", FrmSettings.TBGlitter3.Text)
		StringClean = StringClean.Replace("#Contact3", FrmSettings.TBGlitter3.Text)

		StringClean = StringClean.Replace("#CBTCockCount", CBTCockCount)
		StringClean = StringClean.Replace("#CBTBallsCount", CBTBallsCount)

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

			RandInt = randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			RandInt = 100 * Math.Round(RandInt / 100)
			StringClean = StringClean.Replace("#RandomRound100(" & OriginalFlag & ")", RandInt)

		End If

		If StringClean.Contains("#RandomRound10(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound10(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			RandInt = 10 * Math.Round(RandInt / 10)
			StringClean = StringClean.Replace("#RandomRound10(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#RandomRound5(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound5(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			RandInt = 5 * Math.Round(RandInt / 5)
			StringClean = StringClean.Replace("#RandomRound5(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#Random(") Then

			Dim RandomFlag As String = GetParentheses(StringClean, "#Random(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
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



		Dim PetNameVal As Integer = randomizer.Next(1, 5)

		If PetNameVal = 1 Then PetName = FrmSettings.petnameBox3.Text
		If PetNameVal = 2 Then PetName = FrmSettings.petnameBox4.Text
		If PetNameVal = 3 Then PetName = FrmSettings.petnameBox5.Text
		If PetNameVal = 4 Then PetName = FrmSettings.petnameBox6.Text

		If DommeMood < FrmSettings.NBDomMoodMin.Value Then
			PetNameVal = randomizer.Next(1, 3)
			If PetNameVal = 1 Then PetName = FrmSettings.petnameBox7.Text
			If PetNameVal = 2 Then PetName = FrmSettings.petnameBox8.Text
		End If


		If DommeMood > FrmSettings.NBDomMoodMax.Value Then
			PetNameVal = randomizer.Next(1, 3)
			If PetNameVal = 1 Then PetName = FrmSettings.petnameBox1.Text
			If PetNameVal = 2 Then PetName = FrmSettings.petnameBox2.Text
		End If


		StringClean = StringClean.Replace("#PetName", PetName)

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

		If AssImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Ass")
		If BoobImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Boobs")

		If StringClean.Contains("#RANDNumberLow") Then
			' ### Number between 3-5 , 5-25
			TempVal = randomizer.Next(1, 6) * FrmSettings.domlevelNumBox.Value
			If TempVal > 10 Then TempVal = 5 * Math.Round(TempVal / 5)
			If TempVal < 3 Then TempVal = 3
			StringClean = StringClean.Replace("#RNDNumberLow", TempVal)
		End If


		If StringClean.Contains("#RANDNumberHigh") Then
			' ### Number between 5-25 , 25-100
			TempVal = randomizer.Next(5, 21) * FrmSettings.domlevelNumBox.Value
			If TempVal > 10 Then TempVal = 5 * Math.Round(TempVal / 5)
			StringClean = StringClean.Replace("#RNDNumberHigh", TempVal)
		End If


		If StringClean.Contains("#RANDNumber") Then
			' ### Number between 3-10 , 5-50
			TempVal = randomizer.Next(1, 11) * FrmSettings.domlevelNumBox.Value
			If TempVal > 10 Then TempVal = 5 * Math.Round(TempVal / 5)
			If TempVal < 3 Then TempVal = 3
			StringClean = StringClean.Replace("#RNDNumber", TempVal)
		End If



		'If PreCleanString.Contains("@CockSizeSmall") Then
		'If FrmSettings.CockSizeNumBox.Value < 6 Then
		'StartIndex = PreCleanString.IndexOf("@CockSizeSmall") + 13
		'EndIndex = PreCleanString.IndexOf("@CockSizeMedium", StartIndex)
		'PreCleanString = PreCleanString.Substring(StartIndex, EndIndex - StartIndex).Trim
		'PreCleanString = PreCleanString.Remove(0, 2)
		'End If
		'If FrmSettings.CockSizeNumBox.Value > 5 And FrmSettings.CockSizeNumBox.Value < 9 Then
		'StartIndex = PreCleanString.IndexOf("@CockSizeMedium") + 14
		'EndIndex = PreCleanString.IndexOf("@CockSizeLarge", StartIndex)
		'PreCleanString = PreCleanString.Substring(StartIndex, EndIndex - StartIndex).Trim
		'PreCleanString = PreCleanString.Remove(0, 2)
		'End If
		'If FrmSettings.CockSizeNumBox.Value > 8 Then
		'StartIndex = PreCleanString.IndexOf("@CockSizeLarge") + 13
		'EndIndex = PreCleanString.IndexOf("@CockSizeEnd", StartIndex)
		'PreCleanString = PreCleanString.Substring(StartIndex, EndIndex - StartIndex).Trim
		'PreCleanString = PreCleanString.Remove(0, 2)
		'End If
		'End If


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

		StringClean = StringClean.Replace("#BronzeTokens", BronzeTokens)
		StringClean = StringClean.Replace("#SilverTokens", SilverTokens)
		StringClean = StringClean.Replace("#GoldTokens", GoldTokens)

		StringClean = StringClean.Replace("#SessionEdges", SessionEdges)
		StringClean = StringClean.Replace("#SessionCBTCock", CBTCockCount)
		StringClean = StringClean.Replace("#SessionCBTBalls", CBTBallsCount)

		'StringClean = StringClean.Replace("#Sys_SubLeftEarly", My.Settings.Sys_SubLeftEarly)
		'StringClean = StringClean.Replace("#Sys_SubLeftEarlyTotal", My.Settings.Sys_SubLeftEarlyTotal)

		StringClean = StringClean.Replace("#SlideshowCount", CustomSlideshowList.Count - 1)
		StringClean = StringClean.Replace("#SlideshowCurrent", SlideshowInt)
		StringClean = StringClean.Replace("#SlideshowRemaining", (CustomSlideshowList.Count - 1) - SlideshowInt)

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


		If StringClean.Contains("#RandomSlideshowCategory") Then StringClean = StringClean.Replace("#RandomSlideshowCategory", RandomSlideshowCategory)


		If StringClean.Contains("#LocalImageCount") Then

			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			For i As Integer = 1 To 11
				CheckString = "NULL"
				CheckBoolean = False
				If i = 1 And FrmSettings.CBIHardcore.Checked = True And Directory.Exists(FrmSettings.LBLIHardcore.Text) Then CheckString = FrmSettings.LBLIHardcore.Text
				If i = 2 And FrmSettings.CBISoftcore.Checked = True And Directory.Exists(FrmSettings.LBLISoftcore.Text) Then CheckString = FrmSettings.LBLISoftcore.Text
				If i = 3 And FrmSettings.CBILesbian.Checked = True And Directory.Exists(FrmSettings.LBLILesbian.Text) Then CheckString = FrmSettings.LBLILesbian.Text
				If i = 4 And FrmSettings.CBIBlowjob.Checked = True And Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then CheckString = FrmSettings.LBLIBlowjob.Text
				If i = 5 And FrmSettings.CBIFemdom.Checked = True And Directory.Exists(FrmSettings.LBLIFemdom.Text) Then CheckString = FrmSettings.LBLIFemdom.Text
				If i = 6 And FrmSettings.CBILezdom.Checked = True And Directory.Exists(FrmSettings.LBLILezdom.Text) Then CheckString = FrmSettings.LBLILezdom.Text
				If i = 7 And FrmSettings.CBIHentai.Checked = True And Directory.Exists(FrmSettings.LBLIHentai.Text) Then CheckString = FrmSettings.LBLIHentai.Text
				If i = 8 And FrmSettings.CBIGay.Checked = True And Directory.Exists(FrmSettings.LBLIGay.Text) Then CheckString = FrmSettings.LBLIGay.Text
				If i = 9 And FrmSettings.CBIMaledom.Checked = True And Directory.Exists(FrmSettings.LBLIMaledom.Text) Then CheckString = FrmSettings.LBLIMaledom.Text
				If i = 10 And FrmSettings.CBICaptions.Checked = True And Directory.Exists(FrmSettings.LBLICaptions.Text) Then CheckString = FrmSettings.LBLICaptions.Text
				If i = 11 And FrmSettings.CBIGeneral.Checked = True And Directory.Exists(FrmSettings.LBLIGeneral.Text) Then CheckString = FrmSettings.LBLIGeneral.Text

				If i = 1 And FrmSettings.CBIHardcoreSD.Checked = True Then CheckBoolean = True
				If i = 2 And FrmSettings.CBISoftcoreSD.Checked = True Then CheckBoolean = True
				If i = 3 And FrmSettings.CBILesbianSD.Checked = True Then CheckBoolean = True
				If i = 4 And FrmSettings.CBIBlowjobSD.Checked = True Then CheckBoolean = True
				If i = 5 And FrmSettings.CBIFemdomSD.Checked = True Then CheckBoolean = True
				If i = 6 And FrmSettings.CBILezdomSD.Checked = True Then CheckBoolean = True
				If i = 7 And FrmSettings.CBIHentaiSD.Checked = True Then CheckBoolean = True
				If i = 8 And FrmSettings.CBIGaySD.Checked = True Then CheckBoolean = True
				If i = 9 And FrmSettings.CBIMaledomSD.Checked = True Then CheckBoolean = True
				If i = 10 And FrmSettings.CBICaptionsSD.Checked = True Then CheckBoolean = True
				If i = 11 And FrmSettings.CBIGeneralSD.Checked = True Then CheckBoolean = True


				If Not CheckString = "NULL" Then
					If CheckBoolean = True Then
						files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(CheckString, "*.*")
					End If
					Array.Sort(files)
					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							LocalList.Add(fi)
						End If
					Next
				End If
			Next

			StringClean = StringClean.Replace("#LocalImageCount", LocalList.Count)

		End If



		If StringClean.Contains("#HardcoreImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIHardcore.Checked = True And Directory.Exists(FrmSettings.LBLIHardcore.Text) Then CheckString = FrmSettings.LBLIHardcore.Text
			If FrmSettings.CBIHardcoreSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#HardcoreImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#SoftcoreImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBISoftcore.Checked = True And Directory.Exists(FrmSettings.LBLISoftcore.Text) Then CheckString = FrmSettings.LBLISoftcore.Text
			If FrmSettings.CBISoftcoreSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#SoftcoreImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#LesbianImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBILesbian.Checked = True And Directory.Exists(FrmSettings.LBLILesbian.Text) Then CheckString = FrmSettings.LBLILesbian.Text
			If FrmSettings.CBILesbianSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#LesbianImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#BlowjobImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIBlowjob.Checked = True And Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then CheckString = FrmSettings.LBLIBlowjob.Text
			If FrmSettings.CBIBlowjobSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#BlowjobImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#FemdomImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIFemdom.Checked = True And Directory.Exists(FrmSettings.LBLIFemdom.Text) Then CheckString = FrmSettings.LBLIFemdom.Text
			If FrmSettings.CBIFemdomSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#FemdomImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#LezdomImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBILezdom.Checked = True And Directory.Exists(FrmSettings.LBLILezdom.Text) Then CheckString = FrmSettings.LBLILezdom.Text
			If FrmSettings.CBILezdomSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#LezdomImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#HentaiImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIHentai.Checked = True And Directory.Exists(FrmSettings.LBLIHentai.Text) Then CheckString = FrmSettings.LBLIHentai.Text
			If FrmSettings.CBIHentaiSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#HentaiImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#GayImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIGay.Checked = True And Directory.Exists(FrmSettings.LBLIGay.Text) Then CheckString = FrmSettings.LBLIGay.Text
			If FrmSettings.CBIGaySD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#GayImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#MaledomImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIMaledom.Checked = True And Directory.Exists(FrmSettings.LBLIMaledom.Text) Then CheckString = FrmSettings.LBLIMaledom.Text
			If FrmSettings.CBIMaledomSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#MaledomImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#CaptionsImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBICaptions.Checked = True And Directory.Exists(FrmSettings.LBLICaptions.Text) Then CheckString = FrmSettings.LBLICaptions.Text
			If FrmSettings.CBICaptionsSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#CaptionsImageCount", LocalList.Count)
		End If

		If StringClean.Contains("#GeneralImageCount") Then
			Dim CheckString As String
			Dim CheckBoolean As Boolean
			Dim LocalList As New List(Of String)
			LocalList.Clear()
			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()
			CheckString = "NULL"
			CheckBoolean = False
			If FrmSettings.CBIGeneral.Checked = True And Directory.Exists(FrmSettings.LBLIGeneral.Text) Then CheckString = FrmSettings.LBLIGeneral.Text
			If FrmSettings.CBIGeneralSD.Checked = True Then CheckBoolean = True
			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If
				Array.Sort(files)
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next
			End If
			StringClean = StringClean.Replace("#GeneralImageCount", LocalList.Count)
		End If


		If StringClean.Contains("#LikedImageCount") Then
			Try
				Dim LikeList As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\LikedImageURLs.txt")
				StringClean = StringClean.Replace("#LikedImageCount", LikeList.Count)
			Catch
				StringClean = StringClean.Replace("#LikedImageCount", "0")
			End Try

		End If

		If StringClean.Contains("#DislikedImageCount") Then
			Try
				Dim DislikeList As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")
				StringClean = StringClean.Replace("#DislikedImageCount", DislikeList.Count)
			Catch
				StringClean = StringClean.Replace("#DislikedImageCount", "0")
			End Try

		End If


		StringClean = StringClean.Replace("#CurrentImage", CurrentImage)

		Return StringClean


	End Function


	Public Function PoundClean(ByVal StringClean As String) As String

		'Debug.Print("StringClean = " & StringClean)

		'DeepClean:


		StringClean = SysKeywordClean(StringClean)

		Debug.Print("PoundClean System Keyword Checkpoint")



		FoundTag = "NULL"

		Try
			If File.Exists(_ImageFileNames(FileCount)) Then MainPictureImage = Path.GetDirectoryName(_ImageFileNames(FileCount))
		Catch
		End Try

		'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
		If File.Exists(MainPictureImage & "\ImageTags.txt") Then
			' Read all lines of the given file.
			Dim TagList As List(Of String) = Txt2List(MainPictureImage & "\ImageTags.txt")

			'If SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And domVLC.Visible = False Then
			If SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And DomWMP.Visible = False Then
				Try
					For t As Integer = 0 To TagList.Count - 1
						'Debug.Print("TagList(t) = " & TagList(t))
						If TagList(t).Contains(Path.GetFileName(_ImageFileNames(FileCount))) Then
							FoundTag = TagList(t)
							Dim FoundTagSplit As String() = Split(FoundTag)
							For j As Integer = 0 To FoundTagSplit.Length - 1
								If FoundTagSplit(j).Contains("TagGarment") Then
									TagGarment = FoundTagSplit(j).Replace("TagGarment", "")
									TagGarment = TagGarment.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagUnderwear") Then
									TagUnderwear = FoundTagSplit(j).Replace("TagUnderwear", "")
									TagUnderwear = TagUnderwear.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagTattoo") Then
									TagTattoo = FoundTagSplit(j).Replace("TagTattoo", "")
									TagTattoo = TagTattoo.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagSexToy") Then
									TagSexToy = FoundTagSplit(j).Replace("TagSexToy", "")
									TagSexToy = TagSexToy.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagFurniture") Then
									TagFurniture = FoundTagSplit(j).Replace("TagFurniture", "")
									TagFurniture = TagFurniture.Replace("-", " ")
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

		StringClean = StringClean.Replace("#TagGarment", TagGarment)
		StringClean = StringClean.Replace("#TagUnderwear", TagUnderwear)
		StringClean = StringClean.Replace("#TagTattoo", TagTattoo)
		StringClean = StringClean.Replace("#TagSexToy", TagSexToy)
		StringClean = StringClean.Replace("#TagFurniture", TagFurniture)


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

						Dim ioFile As New StreamReader(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\" & PoundArray(i) & ".txt")
						Dim lines As New List(Of String)
						Dim PoundLine As Integer
						PoundLine = -1

						While ioFile.Peek <> -1
							PoundLine += 1
							lines.Add(ioFile.ReadLine())
							'Debug.Print("iofile.readline = " & lines(PoundLine))
							If lines(PoundLine) = "" Then
								lines.Remove(PoundLine)
								PoundLine -= 1
							End If
						End While

						ioFile.Close()
						ioFile.Dispose()




						Try
							lines = FilterList(lines)
							Crazy = False
							Vulgar = False
							Supremacist = False
							Dim PoundVal As Integer = randomizer.Next(0, lines.Count)
							'Debug.Print("PoundLine = " & PoundLine)
							'Debug.Print("PoundVal = " & PoundVal)
							StringClean = StringClean.Replace(PoundArray(i), lines(PoundVal))
						Catch
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

						'MsgBox("""" & PoundArray(i) & ".txt"" was not found in """ & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\. Please verify the file is in the correct folder and that " _
						'& "the Vocabulary word is spelled correctly in the script.", , "Error!")

						StringClean = StringClean.Replace(PoundArray(i), "<font color=""red"">" & PoundArray(i) & "</font>")
						'StringClean = StringClean.Replace(PoundArray(i), PoundArray(i).Replace("#", ""))

						Debug.Print("dafuq?")
						Debug.Print(StringClean)
						'GoTo BadVocabBreak

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

	Public Function CommandClean(ByVal StringClean As String) As String

		Debug.Print("Stringclean Intro = " & StringClean)

RinseLatherRepeat:


		If StringClean.Contains("@DommeTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DommeTag(")
			' Try to get a Domme Image for the given Tags.
			DommeImageSTR = GetDommeImage(TagFlag)
			' Check the Result 
			If DommeImageSTR <> "" Then DommeImageFound = True
			' Clean the Text.
			StringClean = StringClean.Replace("@DommeTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@DomTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DomTag(")
			' Try to get a Domme Image for the given Tags.
			DommeImageSTR = GetDommeImage(TagFlag)
			' Check the Result 
			If DommeImageSTR <> "" Then DommeImageFound = True Else DommeImageFound = False
			StringClean = StringClean.Replace("@DomTag(" & TagFlag & ")", "")
		End If

		' The @LockImages Commnd prevents the Domme Slideshow from moving forward or back when set to "Tease" or "Timed". Manual operation of Domme Slideshow images is still allowed,
		' and pictures displayed through other means will still work. Images are automatically unlocked whenever Tease AI moves into a Link script, an End script, any Interrupt occurs
		' (including Long Edge and Start Stroking) or when the sub gives up.

		If StringClean.Contains("@LockImages") Then
			LockImage = True
			nextButton.Enabled = False
			previousButton.Enabled = False
			DommeSlideshowToolStripMenuItem.Enabled = False
			StringClean = StringClean.Replace("@LockImages", "")
		End If

		' The @UnlockImages Command allows the Domme Slideshow to resume functioning as normal.

		If StringClean.Contains("@UnlockImages") Then
			If SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True
			End If
			LockImage = False
			StringClean = StringClean.Replace("@UnlockImages", "")
		End If

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

			TempVal = randomizer.Next(1, 101)

			Dim ChanceString As String = StringClean.Substring(TSStartIndex + 2, StringClean.Length - (TSStartIndex + 2)).Trim

			Dim ChanceSplit As String() = Split(ChanceString, ")")


			Debug.Print("CHanceCheck = " & "@Chance" & ChanceVal & ChanceSplit(0) & ")")
			StringClean = StringClean.Replace("@Chance" & ChanceVal & ChanceSplit(0) & ")", "")

			If TempVal <= ChanceVal Then

				FileGoto = ChanceSplit(0) & ")"
				SkipGotoLine = True

				If YesOrNo = True Then
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
							SkipGotoLine = True
							FileGoto = FlagArray(1)
							GetGoto()
						End If

					Else

						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & CheckFlag) Or
							File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & CheckFlag) Then
							SkipGotoLine = True
							FileGoto = CheckFlag
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

							CreateTempFlag(FlagArray(x))

						Next

					Else

						CreateTempFlag(TempFlag)

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

		' The @CheckDate() Command checks a previously saved Variable created with the @SetDate() Command and goes to the specified line if the current time and date is on or after the date in the Variable.
		' Correct format is @CheckDate(VarName, Goto Line) . For example, @CheckDate(NoPorn, Look At Porn Again) will go to the line (Look At Porn Again) if the current time and date has passed the value set
		' for the Variable "NoPorn" by @SetDate()


		If StringClean.Contains("@CheckDate(") Then

			Dim CheckArray As String() = StringClean.Split(")")

			For i As Integer = 0 To CheckArray.Count - 1

				If CheckArray(i).Contains("@CheckDate(") Then

					'CheckArray(i) = CheckArray(i) & "]"

					Dim CheckFlag As String = GetParentheses(CheckArray(i), "@CheckDate(")
					Dim OriginalCheck As String = CheckFlag

					CheckFlag = FixCommas(CheckFlag)

					Dim DateArray() As String = CheckFlag.Split(",")

					If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & DateArray(0)) Then

						Debug.Print(GetDate(DateArray(0)))

						If DateArray.Count = 2 Then
							If CompareDatesWithTime(GetDate(DateArray(0))) <> 1 Then
								SkipGotoLine = True
								FileGoto = DateArray(1).Replace(")", "")
								GetGoto()
							End If
						End If

						If DateArray.Count = 3 Then

							Dim DDiff As Integer

							Debug.Print("GetDate(DateArray(0) = " & GetDate(DateArray(0)))

							If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
							If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

							Debug.Print("DDiff = " & DDiff)
							Debug.Print("Val(DateArray(1)) = " & Val(DateArray(1)))

							If DDiff >= Val(DateArray(1)) Then
								SkipGotoLine = True
								FileGoto = DateArray(2).Replace(")", "")
								GetGoto()
							End If

						End If


						If DateArray.Count = 4 Then

							Dim DDiff As Integer
							Dim DDiff2 As Integer

							If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
							If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
							If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

							If UCase(DateArray(2)).Contains("SECOND") Then DDiff2 = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
							If UCase(DateArray(2)).Contains("MINUTE") Then DDiff2 = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
							If UCase(DateArray(2)).Contains("HOUR") Then DDiff2 = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
							If UCase(DateArray(2)).Contains("DAY") Then DDiff2 = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
							If UCase(DateArray(2)).Contains("WEEK") Then DDiff2 = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
							If UCase(DateArray(2)).Contains("MONTH") Then DDiff2 = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
							If UCase(DateArray(2)).Contains("YEAR") Then DDiff2 = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

							If DDiff >= Val(DateArray(1)) And DDiff2 <= Val(DateArray(2)) Then
								SkipGotoLine = True
								FileGoto = DateArray(3).Replace(")", "")
								GetGoto()
							End If

						End If

					End If

					' CheckArray(i) = CheckArray(i).Replace("@CheckDate(" & OriginalCheck, "")

					StringClean = StringClean.Replace("@CheckDate(" & OriginalCheck & ")", "")

				End If

			Next

			'  StringClean = Join(CheckArray, Nothing)

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

					ScriptOperator = "Null"
					If ChangeOperator.Contains("+") Then ScriptOperator = "Add"
					If ChangeOperator.Contains("-") Then ScriptOperator = "Subtract"
					If ChangeOperator.Contains("*") Then ScriptOperator = "Multiply"
					If ChangeOperator.Contains("/") Then ScriptOperator = "Divide"

					Dim ChangeVal As Integer = 0

					If ScriptOperator = "Add" Then ChangeVal = Val1 + Val2
					If ScriptOperator = "Subtract" Then ChangeVal = Val1 - Val2
					If ScriptOperator = "Multiply" Then ChangeVal = Val1 * Val2
					If ScriptOperator = "Divide" Then ChangeVal = Val1 / Val2

					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVar, ChangeVal, False)

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
						'Debug.Print("@SetVar SCSetVar(i) = " & SCIfVar(i))
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
						'Debug.Print("@SetVar SCSetVar Joined StringClean = " & StringClean)
						Exit For
					End If
				Next

				SCGotVar = SCGotVar.Replace("@If[", "")
				Dim SCGotVarSplit As String() = Split(SCGotVar, "]", 2)

				Dim Val1 As Integer = -18855881
				Dim Str1 As String = SCGotVarSplit(0)

				Debug.Print("SCGotVarSplit(0)= " & SCGotVarSplit(0))

				If IsNumeric(Str1) = True Then

					Debug.Print("InNumeric Called")

					Val1 = Val(SCGotVarSplit(0))

				Else

					Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & SCGotVarSplit(0)
					'Debug.Print("VarCheck = " & VarCheck)
					'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
					If File.Exists(VarCheck) Then
						'Debug.Print("VarCheck Exists")
						Dim StrCheck As String = TxtReadLine(VarCheck)

						Debug.Print("StrChec = " & StrCheck)

						If IsNumeric(StrCheck) = True Then
							Val1 = Val(StrCheck)
						Else
							Str1 = StrCheck
						End If
					End If

				End If

				Debug.Print("Val1 = " & Val1)

				'Debug.Print("@SetVar VarDifference = " & Val1)

				'Debug.Print("@SetVar Val = " & Val1)
				SCGotVarSplit(0) = ""

				SCGotVar = Join(SCGotVarSplit)
				'Debug.Print("@SetVar SCGotVar = " & SCGotVar)

				SCGotVarSplit = Split(SCGotVar, "[", 2)
				SCGotVarSplit(0) = SCGotVarSplit(0).Replace(" ", "")
				'Debug.Print("@SetVar SCGotVarSplit = " & SCGotVarSplit(0))

				ScriptCompare = "Null"

				If SCGotVarSplit(0) = "=" Or SCGotVarSplit(0) = "==" Then ScriptCompare = "="
				If SCGotVarSplit(0) = "<>" Then ScriptCompare = "<>"
				If SCGotVarSplit(0) = ">" Then ScriptCompare = ">"
				If SCGotVarSplit(0) = "<" Then ScriptCompare = "<"
				If SCGotVarSplit(0) = ">=" Then ScriptCompare = ">="
				If SCGotVarSplit(0) = "<=" Then ScriptCompare = "<="

				'Debug.Print("Script Compare = " & ScriptCompare)

				SCGotVarSplit(0) = ""

				SCGotVar = Join(SCGotVarSplit)
				'Debug.Print("@SetVar SCGotVar = " & SCGotVar)

				Do Until SCGotVar.Substring(0, 1) <> " "
					SCGotVar = SCGotVar.Remove(0, 1)
				Loop

				'Debug.Print("@SetVar SCGotVar = " & SCGotVar)

				SCGotVarSplit = Split(SCGotVar, "]", 2)
				SCGotVarSplit(0) = SCGotVarSplit(0).Replace(" ", "")
				'Debug.Print("@SetVar SCGotVarSplit(0) = " & SCGotVarSplit(0))
				SCGotVarSplit(1) = SCGotVarSplit(1).Replace("Then", "")
				'Debug.Print("@SetVar SCGotVarSplit(1) = " & SCGotVarSplit(1))


				Dim Val2 As Integer = -18855881
				Dim Str2 As String = SCGotVarSplit(0)

				Debug.Print("SCGotVarSplit(0)= " & SCGotVarSplit(0))

				If IsNumeric(Str2) = True Then

					Debug.Print("InNumeric Called")

					Val2 = Val(SCGotVarSplit(0))

				Else

					Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & SCGotVarSplit(0)
					'Debug.Print("VarCheck = " & VarCheck)
					'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
					If File.Exists(VarCheck) Then
						'Debug.Print("VarCheck Exists")
						' Read the first line of the given file.
						Dim StrCheck As String = TxtReadLine(VarCheck)
						Debug.Print("StrChec = " & StrCheck)
						If IsNumeric(StrCheck) = True Then
							Val2 = Val(StrCheck)
						Else
							Str2 = StrCheck
						End If
					End If

				End If

				Debug.Print("Val2 = " & Val2)


				Dim CompareCheck As String = "Null"

				If Val1 = -18855881 Or Val2 = -18855881 Then

					Debug.Print("Compare strings called")

					Debug.Print("Str1 = " & Str1)
					Debug.Print("Str2 = " & Str2)


					If ScriptCompare = "=" Then
						If UCase(Str1) = UCase(Str2) Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<>" Then
						If UCase(Str1) <> UCase(Str2) Then CompareCheck = SCGotVarSplit(1)
					End If

				Else

					Debug.Print("Compare integers called")

					If ScriptCompare = "=" Then
						If Val1 = Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<>" Then
						If Val1 <> Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = ">" Then
						If Val1 > Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<" Then
						If Val1 < Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = ">=" Then
						If Val1 >= Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<=" Then
						If Val1 <= Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

				End If

				'Debug.Print("CompareCheck = " & CompareCheck)

				If CompareCheck <> "Null" Then
					FileGoto = CompareCheck
					SkipGotoLine = True
					GetGoto()
				End If

			Loop Until Not StringClean.Contains("@If")

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

		' The @InputVar[] stops script progression and waits for the user to input his next message. Whatever the user types next will be saved as a Variable named whatever you specify in the brackets.
		' For example, if the script's line was "What's your favorite food? @InputVar[FavoriteFood]", and the user typed "lo mein", then "lo mein" would be saved as the Variable "FavoriteFood". If the
		' user has checked "Show Icon During Input Questions" in the General Settings tab, then the domme's question will be accompanied by a small question mark icon to let the user know that their next
		' response will be saved verbatim. @InputVar[] will pause Linear Scripts, as well as countdowns and taunts for Stroking, Edging and Holding The Edge.

		If StringClean.Contains("@InputVar[") Then

			InputString = GetParentheses(StringClean, "@InputVar[").Replace("]", "")
			InputFlag = True
			If FrmSettings.CBInputIcon.Checked = True Then InputIcon = True

			StringClean = StringClean.Replace("@InputVar[" & InputString & "]", "")

		End If


		' The @DislikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Disliked" list located in [Tease AI Root Directory]\Images\System\DislikedImageURLS.txt

		If StringClean.Contains("@DislikeBlogImage") Then

			If ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@DislikeBlogImage", "")
			End If

		End If

		' The @LikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Liked" list located in [Tease AI Root Directory]\Images\System\LikedImageURLS.txt

		If StringClean.Contains("@LikeBlogImage") Then

			If ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@LikeBlogImage", "")
			End If

		End If


		If StringClean.Contains("@ShowLikedImage") Then
			If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then

				Dim LikeList As New List(Of String)

				LikeList = Txt2List(Application.StartupPath & "\Images\System\LikedImageURLs.txt")

				If LikeList.Count = 0 Then
					FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
				Else
					FoundString = LikeList(randomizer.Next(0, LikeList.Count))
				End If
				ShowGotImage()
			End If
			StringClean = StringClean.Replace("@ShowLikedImage", "")
		End If

		If StringClean.Contains("@ShowDislikedImage") Then
			If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then

				Dim DislikeList As New List(Of String)

				DislikeList = Txt2List(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")

				If DislikeList.Count = 0 Then
					FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
				Else
					FoundString = DislikeList(randomizer.Next(0, DislikeList.Count))
				End If
				ShowGotImage()
			End If
			StringClean = StringClean.Replace("@ShowDislikedImage", "")
		End If

		If StringClean.Contains("@ShowBlogImage") Then
			GetBlogImage()
			StringClean = StringClean.Replace("@ShowBlogImage", "")
		End If

		If StringClean.Contains("@ShowLocalImage") Then
			GetLocalImage()
			StringClean = StringClean.Replace("@ShowLocalImage", "")
		End If

		If StringClean.Contains("@ShowImage[") Then


			Dim ImageToShow As String = GetParentheses(StringClean, "@ShowImage[")

			If ImageToShow.Contains("://") Then

				Try
					ShowImage(ImageToShow)
					JustShowedBlogImage = True
				Catch
				End Try

				GoTo ShowedBlogImage

			End If

			ImageToShow = ImageToShow.Replace("/", "\")

			If ImageToShow.Contains(":\") Then

				If File.Exists(ImageToShow) Then
					Try
						ShowImage(ImageToShow)
						JustShowedBlogImage = True
					Catch
						ClearMainPictureBox()
						MessageBox.Show(Me, ImageToShow & " could not be accessed!" & Environment.NewLine & Environment.NewLine & "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				Else
					MessageBox.Show(Me, Path.GetFileName(ImageToShow) & " was not found in " & Path.GetDirectoryName(ImageToShow) & "!" & Environment.NewLine & Environment.NewLine &
									"Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If


				GoTo ShowedBlogImage

			Else

				ImageToShow = Application.StartupPath & "\Images\" & ImageToShow
				ImageToShow = ImageToShow.Replace("\\", "\")

			End If



			'ClearMainPictureBox()

			If ImageToShow.Contains("*") Then

				Dim ImageList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(ImageToShow), FileIO.SearchOption.SearchTopLevelOnly, Path.GetFileName(ImageToShow))
					ImageList.Add(foundFile)
				Next

				If ImageList.Count > 0 Then
					ShowImage(ImageList(randomizer.Next(0, ImageList.Count)))
					JustShowedBlogImage = True
				Else
					ClearMainPictureBox()
					MessageBox.Show(Me, "No images matching " & Path.GetFileName(ImageToShow) & " were found in " & Path.GetDirectoryName(ImageToShow) & "!" & Environment.NewLine & Environment.NewLine &
							   "Please make sure that valid files exist and that the wildcards are applied correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			Else

				Try
					ShowImage(ImageToShow)
					JustShowedBlogImage = True
				Catch
					ClearMainPictureBox()
					MessageBox.Show(Me, ImageToShow & " could not be accessed!" & Environment.NewLine & Environment.NewLine & "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try

			End If

ShowedBlogImage:

			StringClean = StringClean.Replace("@ShowImage[" & ImageToShow & "]", "")

		End If


		If StringClean.Contains("@ShowImage") And Not StringClean.Contains("@ShowImage[") Then
			TempVal = randomizer.Next(1, 101)
			If TempVal < 51 Then
				GetBlogImage()
			Else
				GetLocalImage()
			End If
			StringClean = StringClean.Replace("@ShowImage", "")
		End If

		Debug.Print("SubStroking = " & SubStroking)
		Debug.Print("SubEdging = " & SubEdging)
		Debug.Print("SubHoldingEdge = " & SubHoldingEdge)

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘┴└─

		If StringClean.Contains("@StrokeFaster") Then
			StrokeFaster = True
			StringClean = StringClean.Replace("@StrokeFaster", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘┴└─

		If StringClean.Contains("@StrokeSlower") Then
			StrokeSlower = True
			StringClean = StringClean.Replace("@StrokeSlower", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeFastest") Then
			StrokeFastest = True
			StringClean = StringClean.Replace("@StrokeFastest", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeSlowest") Then
			StrokeSlowest = True
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
			If StringClean.Contains("@Contact1") Then Contact1Stroke = True
			If StringClean.Contains("@Contact2") Then Contact2Stroke = True
			If StringClean.Contains("@Contact3") Then Contact3Stroke = True
			AskedToGiveUpSection = False
			AskedToSpeedUp = False
			AskedToSlowDown = False
			BeforeTease = False
			SubStroking = True
			ShowModule = False
			'StrokeCycle = -1
			If StartStrokingCount = 0 Then FirstRound = True
			'If FirstRound = True Then My.Settings.Sys_SubLeftEarly += 1
			If FirstRound = True Then SetVariable("SYS_SubLeftEarly", Val(GetVariable("SYS_SubLeftEarly")) + 1)
			My.Settings.Save()
			StartStrokingCount += 1
			StopMetronome = False
			StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)

			If WorshipMode = True Then
				StrokePace = NBMinPace.Value
				StrokeSlowest = True
			End If

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then StrokeTick = randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then StrokeTick = randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then StrokeTick = randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then StrokeTick = randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then StrokeTick = randomizer.Next(5, 11) * 60

				If WorshipMode = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then StrokeTick = 180
					If FrmSettings.domlevelNumBox.Value = 2 Then StrokeTick = 240
					If FrmSettings.domlevelNumBox.Value = 3 Then StrokeTick = 360
					If FrmSettings.domlevelNumBox.Value = 4 Then StrokeTick = 480
					If FrmSettings.domlevelNumBox.Value = 5 Then StrokeTick = 600
				End If

			Else
				StrokeTick = randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				If WorshipMode = True Then StrokeTick = FrmSettings.NBTauntCycleMax.Value * 60
			End If



			StrokeTauntTick = randomizer.Next(11, 21)
			'StrokeThread = New Thread(AddressOf StrokeLoop)
			'StrokeThread.IsBackground = True
			'StrokeThread.SetApartmentState(ApartmentState.STA)
			'StrokeThread.Start()
			StrokeTimer.Start()
			StrokeTauntTimer.Start()
			StringClean = StringClean.Replace("@StartStroking", "")
		End If

		If StringClean.Contains("@StartTaunts") Then
			AskedToGiveUpSection = False
			AskedToSpeedUp = False
			AskedToSlowDown = False
			BeforeTease = False
			SubStroking = True
			ShowModule = False
			'StrokeCycle = -1
			If StartStrokingCount = 0 Then FirstRound = True
			StartStrokingCount += 1
			' github patch StrokePace = 0
			' github patch StrokePaceTimer.Interval = StrokePace
			StopMetronome = False

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then StrokeTick = randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then StrokeTick = randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then StrokeTick = randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then StrokeTick = randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then StrokeTick = randomizer.Next(5, 11) * 60
			Else
				StrokeTick = randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
			End If
			StrokeTauntTick = randomizer.Next(11, 21)
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
			If Contact1Stroke = True Then
				StringClean = StringClean & "@Contact1"
				Contact1Stroke = False
			End If
			If Contact2Stroke = True Then
				StringClean = StringClean & "@Contact2"
				Contact2Stroke = False
			End If
			If Contact3Stroke = True Then
				StringClean = StringClean & "@Contact3"
				Contact3Stroke = False
			End If
			AskedToSpeedUp = False
			AskedToSlowDown = False
			SubStroking = False
			SubEdging = False
			SubHoldingEdge = False
			WorshipMode = False
			WorshipTarget = ""
			LongHold = False
			ExtremeHold = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			StrokePace = 0
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopStroking", "")
		End If

		If StringClean.Contains("@StopTaunts") Then
			AskedToSpeedUp = False
			AskedToSlowDown = False
			SubStroking = False
			SubEdging = False
			SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopTaunts", "")
		End If


		If StringClean.Contains("@LongHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@LongHold("))
			TempVal = randomizer.Next(0, 101)
			If TempVal <= HoldInt Then LongHold = True

			StringClean = StringClean.Replace("@LongHold(" & GetParentheses(StringClean, "@LongHold(") & ")", "")
		End If

		If StringClean.Contains("@ExtremeHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@ExtremeHold("))
			TempVal = randomizer.Next(0, 101)
			If TempVal <= HoldInt Then ExtremeHold = True

			StringClean = StringClean.Replace("@ExtremeHold(" & GetParentheses(StringClean, "@ExtremeHold(") & ")", "")
		End If

		If StringClean.Contains("@LongHold") Then
			LongHold = True
			StringClean = StringClean.Replace("@LongHold", "")
		End If

		If StringClean.Contains("@ExtremeHold") Then
			ExtremeHold = True
			StringClean = StringClean.Replace("@ExtremeHold", "")
		End If

		If StringClean.Contains("@MultipleEdges(") Then

			If StringClean.Contains("@Edg") Then

				Dim EdgeFlag As String = GetParentheses(StringClean, "@MultipleEdges(")
				EdgeFlag = FixCommas(EdgeFlag)
				Dim EdgeArray As String() = EdgeFlag.Split(",")

				If EdgeArray.Count = 3 Then

					If randomizer.Next(1, 101) < Val(EdgeArray(2)) Then
						MultipleEdges = True
						MultipleEdgesAmount = Val(EdgeArray(0))
						MultipleEdgesInterval = Val(EdgeArray(1))
					End If

				Else

					MultipleEdges = True
					MultipleEdgesAmount = Val(EdgeArray(0))
					MultipleEdgesInterval = Val(EdgeArray(1))

				End If

			End If

			StringClean = StringClean.Replace("@MultipleEdges(" & GetParentheses(StringClean, "@MultipleEdges(") & ")", "")

		End If


		If StringClean.Contains("@Edge(") Then

			ContactEdgeCheck(StringClean)

			Edge()

			If GetMatch(StringClean, "@Edge(", "Hold") = True Then EdgeHold = True
			If GetMatch(StringClean, "@Edge(", "NoHold") = True Then EdgeNoHold = True
			If EdgeHold = True And EdgeNoHold = True Then EdgeHold = False

			If GetMatch(StringClean, "@Edge(", "Orgasm") = True Then OrgasmAllowed = True

			If GetMatch(StringClean, "@Edge(", "Ruin") = True Then OrgasmRuined = True

			If OrgasmAllowed = True And OrgasmRuined = True Then OrgasmRuined = False

			If GetMatch(StringClean, "@Edge(", "RuinTaunts") = True Then
				If EdgeToRuin = True Then EdgeToRuinSecret = False
			End If

			If GetMatch(StringClean, "@Edge(", "LongHold") = True Then
				EdgeHold = True
				LongHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "ExtremeHold") = True Then
				EdgeHold = True
				ExtremeHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "HoldTaunts") = True Then
				If LongHold = True Then LongTaunts = True
				If ExtremeHold = True Then ExtremeTaunts = True
			End If

		End If



		If StringClean.Contains("@EdgeMode(") Then

			Dim EdgeFlag As String = GetParentheses(StringClean, "@EdgeMode(")
			EdgeFlag = FixCommas(EdgeFlag)
			Dim EdgeArray As String() = EdgeFlag.Split(",")

			If UCase(EdgeArray(0)).Contains("GOTO") Then
				EdgeGoto = True
				EdgeGotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("MESSAGE") Then
				EdgeMessage = True
				EdgeMessageText = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("VIDEO") Then
				EdgeVideo = True
				EdgeGotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("NORMAL") Then
				EdgeGoto = False
				EdgeMessage = False
				EdgeVideo = False
			End If

			StringClean = StringClean.Replace("@EdgeMode(" & GetParentheses(StringClean, "@EdgeMode(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeToRuin = True
			EdgeToRuinSecret = False
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

				EdgeHoldSeconds = randomizer.Next(Edge1, Edge2 + 1)

			Else

				EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("M") Then EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("H") Then EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			EdgeToRuin = True
			EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret(" & GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(") & ")", "")
		End If



		If StringClean.Contains("@EdgeToRuinHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			EdgeToRuin = True
			EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeToRuinSecret = False
			EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeNoHold = True
			EdgeToRuin = True
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

				EdgeHoldSeconds = randomizer.Next(Edge1, Edge2 + 1)

			Else

				EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("M") Then EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("H") Then EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			EdgeToRuin = True

			StringClean = StringClean.Replace("@EdgeToRuinHold(" & GetParentheses(StringClean, "@EdgeToRuinHold(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinHold", "")
		End If

		If StringClean.Contains("@EdgeToRuin") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuin", "")
		End If

		If StringClean.Contains("@EdgeNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeNoHold = True
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

				EdgeHoldSeconds = randomizer.Next(Edge1, Edge2 + 1)

			Else

				EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("M") Then EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("H") Then EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True


			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold(" & GetParentheses(StringClean, "@EdgeHold(") & ")", "")

		End If


		If StringClean.Contains("@EdgeHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold", "")
		End If

		If StringClean.Contains("@Edge") Then
			ContactEdgeCheck(StringClean)
			Edge()
			StringClean = StringClean.Replace("@Edge", "")
		End If

		If StringClean.Contains("@CBTBalls") Then
			If FrmSettings.CBCBTBalls.Checked = True Then
				CBTBallsActive = True
				CBTBallsFlag = True
			End If
			StringClean = StringClean.Replace("@CBTBalls", "")
		End If

		If StringClean.Contains("@CBTCock") Then
			If FrmSettings.CBCBTCock.Checked = True Then
				CBTCockActive = True
				CBTCockFlag = True
			End If
			StringClean = StringClean.Replace("@CBTCock", "")
		End If

		If StringClean.Contains("@CBT") And Not StringClean.Contains("@CBTLevel") Then

			If FrmSettings.CBCBTCock.Checked = True And FrmSettings.CBCBTBalls.Checked = True Then
				CBTBothActive = True
				CBTBothFlag = True
			End If

			StringClean = StringClean.Replace("@CBT", "")
		End If


		' The @CustomTask() Command works similarly to @CBTBalls and @CBTCock. It allows the user to have the domme run custom instructions from scripts located in Custom\Tasks. For example,
		' @CustomTask(Spanking) would pull its first instruction from Custom\Tasks\Spanking_First.txt, and all subsequent instructions would be pulled from Custom\Tasks\Spanking.txt.

		If StringClean.Contains("@CustomTask(") Then

			Dim CustomFlag As String = GetParentheses(StringClean, "@CustomTask(")

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomFlag & "_First.txt") And
			 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomFlag & ".txt") Then
				CustomTask = True
				CustomTaskActive = True
				CustomTaskText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomFlag & ".txt"
				CustomTaskTextFirst = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomFlag & "_First.txt"
			End If

			StringClean = StringClean.Replace("@CustomTask(" & CustomFlag & ")", "")

		End If


		If StringClean.Contains("@DecideOrgasm") Then

			OrgasmDenied = False
			OrgasmAllowed = False
			OrgasmRuined = False

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
				FileGoto = RuinGoto
				OrgasmRuined = True
				GoTo OrgasmDecided
			End If

			Dim OrgasmInt As Integer = randomizer.Next(1, 101)
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
				FileGoto = DenyGoto
				OrgasmDenied = True
				GoTo OrgasmDecided
			End If

			Dim RuinInt As Integer = randomizer.Next(1, 101)
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
				FileGoto = AllowGoto
				OrgasmAllowed = True
			Else
				FileGoto = RuinGoto
				OrgasmRuined = True
			End If

OrgasmDecided:

			SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@DecideOrgasm", "")
		End If


		If StringClean.Contains("@OrgasmRuin") Then
			FileGoto = "Orgasm Ruin"
			OrgasmRuined = True
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmRuin", "")
		End If

		If StringClean.Contains("@OrgasmDeny") Then
			FileGoto = "Orgasm Deny"
			OrgasmDenied = True
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmDeny", "")
		End If

		If StringClean.Contains("@OrgasmAllow") Then
			FileGoto = "Orgasm Allow"
			OrgasmAllowed = True
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmAllow", "")
		End If



		' The @Glitter Command allows to specify a specfic script from the domme's Apps\Glitter\Script directory, which will then immediately play out in the Glitter app. For example, @Glitter(About to Ruin)
		' would run the Glitter script in Apps\Glitter\Script\About to Ruin.txt.

		If StringClean.Contains("@Glitter(") Then

			' GitHub Patch: Dim GlitterFlag As Integer = GetParentheses(StringClean, "@Glitter(")
			Dim GlitterFlag As String = GetParentheses(StringClean, "@Glitter(")

			If FrmSettings.CBGlitterFeedOff.Checked = False And UpdatingPost = False Then
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Script\" & GlitterFlag & ".txt") And UpdatingPost = False Then
					UpdateList.Clear()
					UpdateList.Add(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Script\" & GlitterFlag & ".txt")
					StatusUpdatePost()
				End If
			End If

			StringClean = StringClean.Replace("@Glitter(" & GlitterFlag & ")", "")

		End If



		If StringClean.Contains("@WritingTask(") Then

			WritingTaskFlag = True

			Dim WTTempString As String() = Split(StringClean, "@WritingTask(", 2)
			Dim WTTemp As String() = Split(WTTempString(1), ")")
			LBLWritingTaskText.Text = WTTemp(0)
			LBLWritingTaskText.Text = StripCommands(LBLWritingTaskText.Text)
			LBLWritingTaskText.Text = StripFormat(LBLWritingTaskText.Text)
			LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace("  ", " ")

			Dim WritingTaskVal As Integer = Val(LBLWritingTaskText.Text)
			'Debug.Print("WritingTaskVal = " & WritingTaskVal)

			If WritingTaskVal = 0 Then
				WritingTaskLinesAmount = randomizer.Next(FrmSettings.NBWritingTaskMin.Value, FrmSettings.NBWritingTaskMax.Value)
				WritingTaskLinesAmount = 5 * Math.Round(WritingTaskLinesAmount / 5)
			Else
				WritingTaskLinesAmount = WritingTaskVal
				LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace(WritingTaskVal, "")
			End If


			LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times:"
			LBLWritingTask.Text = LBLWritingTask.Text.Replace("line 1 times", "line 1 time")
			LBLLinesWritten.Text = "0"
			LBLLinesRemaining.Text = WritingTaskLinesAmount


			' Dim WTTempString As String() = Split(StringClean, "@WritingTask(", 2)
			' Dim WTTemp As String() = Split(WTTempString(1), ")" 1)

			' LBLWritingTaskText.Text = WTTemp(0)

			If PNLWritingTask.Visible = False Then
				CloseApp()
				OpenApp()
				PNLWritingTask.Visible = True
			End If
			WritingTaskMistakesAllowed = randomizer.Next(3, 11)
			LBLMistakesAllowed.Text = WritingTaskMistakesAllowed
			LBLMistakesMade.Text = "0"
			StringClean = StringClean.Replace("@WritingTask", "")
			LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times."
			WritingTaskLinesRemaining = WritingTaskLinesAmount
			WritingTaskLinesWritten = 0
			WritingTaskMistakesMade = 0
			chatBox.ShortcutsEnabled = False
			ChatBox2.ShortcutsEnabled = False

		End If

		If StringClean.Contains("@CheckJOIVideo") Then

			If Directory.Exists(FrmSettings.LblVideoJOI.Text) Or Directory.Exists(FrmSettings.LblVideoJOID.Text) Then
				If FrmSettings.LblVideoJOITotal.Text <> "0" Or FrmSettings.LblVideoJOITotalD.Text <> "0" Then
				Else
					SkipGotoLine = True
					FileGoto = "No JOI Found"
					GetGoto()
				End If
			Else
				SkipGotoLine = True
				FileGoto = "No JOI Found"
				GetGoto()
			End If

			StringClean = StringClean.Replace("@CheckJOIVideo", "")

		End If


		If StringClean.Contains("@PlayJOIVideo") Then

			If Directory.Exists(FrmSettings.LblVideoJOI.Text) Or Directory.Exists(FrmSettings.LblVideoJOID.Text) Then

				TeaseVideo = True
				PlayRandomJOI()
			End If

			StringClean = StringClean.Replace("@PlayJOIVideo", "")

		End If

		If StringClean.Contains("@PlayCHVideo") Then

			If Directory.Exists(FrmSettings.LblVideoCH.Text) Or Directory.Exists(FrmSettings.LblVideoCH.Text) Then

				TeaseVideo = True
				PlayRandomCH()
			End If

			StringClean = StringClean.Replace("@PlayCHVideo", "")

		End If




		If StringClean.Contains("@GiveUpCheck") Then


			If AskedToGiveUpSection = True Then

				If SubGaveUp = True Then
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREHASH.txt"
				Else
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREPEAT.txt"
				End If
				'StringClean = ResponseClean(StringClean)

			Else

				AskedToGiveUpSection = True
				AskedToGiveUp = True

				Dim GiveUpCheck As Integer

				If FrmSettings.NBEmpathy.Value = 1 Then GiveUpCheck = 0
				If FrmSettings.NBEmpathy.Value = 2 Then GiveUpCheck = 25
				If FrmSettings.NBEmpathy.Value = 3 Then GiveUpCheck = 50
				If FrmSettings.NBEmpathy.Value = 4 Then GiveUpCheck = 75
				If FrmSettings.NBEmpathy.Value = 5 Then GiveUpCheck = 1000

				Dim GiveUpVal As Integer = randomizer.Next(1, 101)

				'If GiveUpVal > GiveUpCheck Then
				If GiveUpVal > GiveUpCheck And Not LastScript Then
					' you can give up
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpALLOWED.txt"
					LockImage = False
					If SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						DommeSlideshowToolStripMenuItem.Enabled = True
					End If
					SubGaveUp = True
					FirstRound = False
				Else
					' you can't give up
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpDENIED.txt"
				End If



			End If

			StringClean = ResponseClean(StringClean)

		End If


		If StringClean.Contains("@EndTease") Then
			SetVariable("SYS_SubLeftEarly", 0)
			'My.Settings.Sys_SubLeftEarly = 0
			'My.Settings.Save()
			StopEverything()
			ResetButton()
			ResetFlag = True
			ResumeSession()
			StringClean = StringClean.Replace("@EndTease", "")
		End If

		If StringClean.Contains("@FinishTease") Then
			TeaseTick = 0
			StringClean = StringClean.Replace("@FinishTease", "")
		End If

		If StringClean.Contains("@ShowButtImage") Or StringClean.Contains("@ShowButtsImage") Then
			JustShowedBlogImage = True
			GetTnAList()
			'ClearMainPictureBox()

			Dim ButtPic As String

			Try
				ButtPic = AssList(randomizer.Next(0, AssList.Count))
			Catch
				ButtPic = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			End Try


			If ButtPic.Contains("\") Then
				ShowImage(ButtPic)
				'ImageLocation = ButtPic
				'PBImage = ButtPic
				'ImageThread.Start()
				'DisplayImage(Image.FromFile(ButtPic))
				'mainPictureBox.Image = Image.FromFile(ButtPic)
				DeleteLocalImageFilePath = ButtPic
			Else
				ShowImage(ButtPic)
				' ImageLocation = ButtPic
				'PBImage = ButtPic
				'ImageThread.Start()
				'mainPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(ButtPic)))
			End If

			CurrentImage = ButtPic

			StringClean = StringClean.Replace("@ShowButtImage", "")
			StringClean = StringClean.Replace("@ShowButtsImage", "")
		End If

		If StringClean.Contains("@ShowBoobsImage") Or StringClean.Contains("@ShowBoobImage") Then
			JustShowedBlogImage = True
			GetTnAList()
			'ClearMainPictureBox()

			Dim BoobPic As String

			Try
				BoobPic = BoobList(randomizer.Next(0, BoobList.Count))
			Catch
				BoobPic = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			End Try

			'Dim BoobPic As String = BoobList(randomizer.Next(0, BoobList.Count))

			If BoobPic.Contains("\") Then
				ShowImage(BoobPic)
				'ImageLocation = BoobPic
				'PBImage = _ImageFileNames(BoobPic)
				'ImageThread.Start()
				'DisplayImage(Image.FromFile(BoobPic))
				'mainPictureBox.Image = Image.FromFile(BoobPic)
				DeleteLocalImageFilePath = BoobPic
			Else
				ShowImage(BoobPic)
				'ImageLocation = BoobPic
				'PBImage = _ImageFileNames(BoobPic)
				'ImageThread.Start()
				'DisplayImage(New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(BoobPic))))
				'mainPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(BoobPic)))
			End If

			CurrentImage = BoobPic

			StringClean = StringClean.Replace("@ShowBoobsImage", "")
			StringClean = StringClean.Replace("@ShowBoobImage", "")
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

		If StringClean.Contains("@ShowHardcoreImage") Then
			CheckLocalImage(FrmSettings.LBLIHardcore.Text, FrmSettings.CBIHardcoreSD.Checked)
			StringClean = StringClean.Replace("@ShowHardcoreImage", "")
		End If

		If StringClean.Contains("@ShowSoftcoreImage") Then
			CheckLocalImage(FrmSettings.LBLISoftcore.Text, FrmSettings.CBISoftcoreSD.Checked)
			StringClean = StringClean.Replace("@ShowSoftcoreImage", "")
		End If

		If StringClean.Contains("@ShowLesbianImage") Then
			CheckLocalImage(FrmSettings.LBLILesbian.Text, FrmSettings.CBILesbianSD.Checked)
			StringClean = StringClean.Replace("@ShowLesbianImage", "")
		End If

		If StringClean.Contains("@ShowBlowjobImage") Then
			CheckLocalImage(FrmSettings.LBLIBlowjob.Text, FrmSettings.CBIBlowjobSD.Checked)
			StringClean = StringClean.Replace("@ShowBlowjobImage", "")
		End If

		If StringClean.Contains("@ShowFemdomImage") Then
			CheckLocalImage(FrmSettings.LBLIFemdom.Text, FrmSettings.CBIFemdomSD.Checked)
			StringClean = StringClean.Replace("@ShowFemdomImage", "")
		End If

		If StringClean.Contains("@ShowLezdomImage") Then
			CheckLocalImage(FrmSettings.LBLILezdom.Text, FrmSettings.CBILezdomSD.Checked)
			StringClean = StringClean.Replace("@ShowLezdomImage", "")
		End If

		If StringClean.Contains("@ShowHentaiImage") Then
			CheckLocalImage(FrmSettings.LBLIHentai.Text, FrmSettings.CBIHentaiSD.Checked)
			StringClean = StringClean.Replace("@ShowHentaiImage", "")
		End If

		If StringClean.Contains("@ShowGayImage") Then
			CheckLocalImage(FrmSettings.LBLIGay.Text, FrmSettings.CBIGaySD.Checked)
			StringClean = StringClean.Replace("@ShowGayImage", "")
		End If

		If StringClean.Contains("@ShowMaledomImage") Then
			CheckLocalImage(FrmSettings.LBLIMaledom.Text, FrmSettings.CBIMaledomSD.Checked)
			StringClean = StringClean.Replace("@ShowMaledomImage", "")
		End If

		If StringClean.Contains("@ShowCaptionsImage") Then
			CheckLocalImage(FrmSettings.LBLICaptions.Text, FrmSettings.CBICaptionsSD.Checked)
			StringClean = StringClean.Replace("@ShowCaptionsImage", "")
		End If

		If StringClean.Contains("@ShowGeneralImage") Then
			CheckLocalImage(FrmSettings.LBLIGeneral.Text, FrmSettings.CBIGeneralSD.Checked)
			StringClean = StringClean.Replace("@ShowGeneralImage", "")
		End If

		If StringClean.Contains("@InterruptLongEdge") Then

			Dim EdgeList As New List(Of String)

			For Each EdgeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				'Debug.Print("EdgeFile = " & EdgeFile)
				EdgeList.Add(EdgeFile)
			Next

			'Debug.Print("EdgeList.Count = " & EdgeList.Count)

			If EdgeList.Count > 0 Then

				SubEdging = False
				SubHoldingEdge = False
				EdgeTauntTimer.Stop()
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				FileText = EdgeList(randomizer.Next(0, EdgeList.Count))
				LockImage = False
				MiniScript = False
				If SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					DommeSlideshowToolStripMenuItem.Enabled = True
				End If
				StrokeTauntVal = -1
				ScriptTick = 3
				ScriptTimer.Start()
				ShowModule = True

			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one LongEdge_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@InterruptLongEdge", "")
			JustShowedBlogImage = True
		End If

		If StringClean.Contains("@InterruptStartStroking") Then

			If CensorshipGame = True Or AvoidTheEdgeGame = True Or RLGLGame = True Then
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

				CBTCockFlag = False
				CBTBallsFlag = False
				CBTBothFlag = False
				CustomTask = False
				SubEdging = False
				SubHoldingEdge = False
				EdgeTauntTimer.Stop()
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				FileText = StrokeList(randomizer.Next(0, StrokeList.Count))
				LockImage = False
				If SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					DommeSlideshowToolStripMenuItem.Enabled = True
				End If
				StrokeTauntVal = -1
				ScriptTick = 3
				ScriptTimer.Start()
				ShowModule = True
				MiniScript = False

			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Stroking!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one StartStroking_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@InterruptStartStroking", "")
			JustShowedBlogImage = True
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

				FirstRound = False
				CBTCockFlag = False
				CBTBallsFlag = False
				CBTBothFlag = False
				CustomTask = False
				SubEdging = False
				SubHoldingEdge = False
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

				FileText = InterruptClean
				LockImage = False
				If SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					DommeSlideshowToolStripMenuItem.Enabled = True
				End If
				StrokeTauntVal = -1
				ScriptTick = 3
				ScriptTimer.Start()
				ShowModule = True

				MiniScript = False

			Else
				MessageBox.Show(Me, InterruptS(0) & ".txt was not found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@Interrupt(" & InterruptS(0) & ")", "")
			'Debug.Print("StringClean INterrupt Remove = " & "@Interrupt(" & InterruptS(0) & ")")
			JustShowedBlogImage = True
		End If

		If StringClean.Contains("@BookmarkModule") Then
			BookmarkModule = True
			BookmarkModuleFile = FileText
			BookmarkModuleLine = StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkModule", "")
		End If

		If StringClean.Contains("@BookmarkLink") Then
			BookmarkLink = True
			BookmarkLinkFile = FileText
			BookmarkLinkLine = StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkLink", "")
		End If

		If StringClean.Contains("@AFKOn") Then
			AFK = True
			StringClean = StringClean.Replace("@AFKOn", "")
		End If

		If StringClean.Contains("@AFKOff") Then
			AFK = False
			StringClean = StringClean.Replace("@AFKOff", "")
		End If

		If StringClean.Contains("@Wait(") Then

			Dim WaitFlag As String = GetParentheses(StringClean, "Wait(")
			Dim WaitSeconds As Integer = Val(WaitFlag)

			If UCase(WaitFlag).Contains("M") Then WaitSeconds *= 60
			If UCase(WaitFlag).Contains("H") Then WaitSeconds *= 3600

			WaitTick = WaitSeconds
			WaitTimer.Start()

			StringClean = StringClean.Replace("@Wait(" & WaitFlag & ")", "")

		End If



		If StringClean.Contains("@ShowTaggedImage") Then

			'Debug.Print("ShowTaggedImage StringClean ^^^^^^^^^^^^^^^^^^^^^^ = " & StringClean)

			'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
			If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
				' Read all lines of the given file.
				LocalTagImageList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")

				For i As Integer = LocalTagImageList.Count - 1 To 0 Step -1
					Dim LocalCheck As String() = Split(LocalTagImageList(i))
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
					If Not File.Exists(LocalString) Then LocalTagImageList.Remove(LocalTagImageList(i))
				Next
			End If


			If StringClean.Contains("@Tag") Then
				Dim TSplit As String() = Split(StringClean)
				For i As Integer = 0 To TSplit.Length - 1
					If TSplit(i).Contains("@Tag") Then
						Dim TString As String = TSplit(i).Replace("@Tag", "")
						For j As Integer = LocalTagImageList.Count - 1 To 0 Step -1
							If Not LocalTagImageList(j).Contains(TString) Then LocalTagImageList.RemoveAt(j)
						Next
					End If
				Next
			End If

			For i As Integer = 0 To LocalTagImageList.Count - 1
				'Debug.Print(i & ". " & LocalTagImageList(i))
			Next

			' github patch begin

			'Dim TagSplit As String() = Split(LocalTagImageList(randomizer.Next(0, LocalTagImageList.Count)))
			'FoundString = TagSplit(0) & " "

			'If Not LCase(FoundString).Contains(".jpg ") Or Not LCase(FoundString).Contains(".jpeg ") Or Not LCase(FoundString).Contains(".png ") Or Not LCase(FoundString).Contains(".bmp ") Or Not LCase(FoundString).Contains(".gif ") Then
			'Dim FSLoop As Integer = 1
			'Do Until LCase(FoundString).Contains(".jpg ") Or LCase(FoundString).Contains(".jpeg ") Or LCase(FoundString).Contains(".png ") Or LCase(FoundString).Contains(".bmp ") Or LCase(FoundString).Contains(".gif ")
			'FoundString = FoundString & TagSplit(FSLoop) & " "
			'FSLoop += 1
			'Loop
			'githib patch end


			If LocalTagImageList.Count = 0 Then
				FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			Else
				Dim TagSplit As String() = Split(LocalTagImageList(randomizer.Next(0, LocalTagImageList.Count)))
				FoundString = TagSplit(0) & " "

				If Not LCase(FoundString).Contains(".jpg ") Or Not LCase(FoundString).Contains(".jpeg ") Or Not LCase(FoundString).Contains(".png ") Or Not LCase(FoundString).Contains(".bmp ") Or Not LCase(FoundString).Contains(".gif ") Then
					Dim FSLoop As Integer = 1
					Do Until LCase(FoundString).Contains(".jpg ") Or LCase(FoundString).Contains(".jpeg ") Or LCase(FoundString).Contains(".png ") Or LCase(FoundString).Contains(".bmp ") Or LCase(FoundString).Contains(".gif ")
						FoundString = FoundString & TagSplit(FSLoop) & " "
						FSLoop += 1
					Loop
				End If
			End If

			JustShowedBlogImage = True

			'ClearMainPictureBox()

			ShowImage(FoundString)
			'ImageLocation = FoundString
			'PBImage = FoundString
			'ImageThread.Start()
			'DisplayImage(Image.FromFile(FoundString))
			'mainPictureBox.Image = Image.FromFile(FoundString)
			DeleteLocalImageFilePath = FoundString




			StringClean = StringClean.Replace("@ShowTaggedImage", "")

		End If



		If StringClean.Contains("@SendDailyTasks") Then
			CreateTaskLetter()
			StringClean = StringClean.Replace("@SendDailyTasks", "")
		End If

		If StringClean.Contains("@EdgingHold") Then

			DomTypeCheck = True
			SubEdging = False
			SubStroking = False
			SubHoldingEdge = True
			EdgeTauntTimer.Stop()
			'DomChat = "#HoldTheEdge"
			'TypingDelay()

			HoldEdgeTick = HoldEdgeChance

			Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
			If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

			Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
			If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

			If ExtremeHold = True Then
				HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
			End If

			If LongHold = True Then
				HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
			End If


			If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

			HoldEdgeTick = randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
			If HoldEdgeTick < 10 Then HoldEdgeTick = 10

			HoldEdgeTime = 0

			HoldEdgeTimer.Start()
			HoldEdgeTauntTimer.Start()

			Do
				Application.DoEvents()
			Loop Until DomTypeCheck = False


			StringClean = StringClean.Replace("@EdgingHold", "")
		End If

		If StringClean.Contains("@EdgingStop") Then

			DomTypeCheck = True
			SubEdging = False
			SubStroking = False
			EdgeTauntTimer.Stop()
			'DomChat = "#StopStrokingEdge"
			'TypingDelay()

			Do
				Application.DoEvents()
			Loop Until DomTypeCheck = False

			StringClean = StringClean.Replace("@EdgingStop", "")
		End If

		'Github Patch  If StringClean.Contains("@EdgingDecide") Then
		If StringClean.Contains("@DecideEdge") Then

			TempVal = randomizer.Next(0, 101)

			If TempVal < 51 Then

				DomTypeCheck = True
				SubEdging = False
				SubStroking = False
				SubHoldingEdge = True
				EdgeTauntTimer.Stop()
				StrokePace = 0
				DomChat = "#HoldTheEdge"
				If Contact1Stroke = True Then
					DomChat = "@Contact1 #HoldTheEdge"
					' Github Patch Contact1Stroke = False
				End If
				If Contact2Stroke = True Then
					DomChat = "@Contact2 #HoldTheEdge"
					' Github Patch Contact2Stroke = False
				End If
				If Contact3Stroke = True Then
					DomChat = "@Contact3 #HoldTheEdge"
					' Github Patch Contact3Stroke = False
				End If
				TypingDelay()

				HoldEdgeTick = HoldEdgeChance

				Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
				If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

				Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
				If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

				If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

				HoldEdgeTick = randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If HoldEdgeTick < 10 Then HoldEdgeTick = 10

				HoldEdgeTime = 0

				HoldEdgeTimer.Start()
				HoldEdgeTauntTimer.Start()

			Else

				DomTypeCheck = True
				SubEdging = False
				SubStroking = False
				EdgeTauntTimer.Stop()
				DomChat = "#StopStrokingEdge"
				If Contact1Stroke = True Then
					DomChat = "@Contact1 #StopStrokingEdge"
					Contact1Stroke = False
				End If
				If Contact2Stroke = True Then
					DomChat = "@Contact2 #StopStrokingEdge"
					Contact2Stroke = False
				End If
				If Contact3Stroke = True Then
					DomChat = "@Contact3 #StopStrokingEdge"
					Contact3Stroke = False
				End If
				TypingDelay()

			End If

			Do
				Application.DoEvents()
			Loop Until DomTypeCheck = False


			StringClean = StringClean.Replace("@DecideEdge", "")
		End If

		If StringClean.Contains("@CheckVideo") Then
			VideoCheck = True
			RandomVideo()
			If NoVideo = True Then
				FileGoto = "(No Videos Found)"
			Else
				FileGoto = "(Videos Found)"
			End If
			VideoCheck = False
			NoVideo = False
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckVideo", "")
		End If

		If StringClean.Contains("@PlayCensorshipSucks") Then

			RandomVideo()

			If NoVideo = False Then
				ScriptVideoTease = "Censorship Sucks"
				ScriptVideoTeaseFlag = True
				ScriptVideoTeaseFlag = False
				CensorshipGame = True
				VideoTease = True
				CensorshipTick = randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
				CensorshipTimer.Start()
			End If

			StringClean = StringClean.Replace("@PlayCensorshipSucks", "")
		End If

		If StringClean.Contains("@ChastityOn") Then
			My.Settings.Chastity = True
			My.Settings.Save()
			FrmSettings.LBLChastityState.Text = "ON"
			FrmSettings.LBLChastityState.ForeColor = Color.Green
			StringClean = StringClean.Replace("@ChastityOn", "")
		End If

		If StringClean.Contains("@ChastityOff") Then
			My.Settings.Chastity = False
			My.Settings.Save()
			FrmSettings.LBLChastityState.Text = "OFF"
			FrmSettings.LBLChastityState.ForeColor = Color.Red
			StringClean = StringClean.Replace("@ChastityOff", "")
		End If

		If StringClean.Contains("@VitalSubAssignment") Then
			' Read all lines of the given file.
			Dim AssignList As List(Of String) = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\VitalSub\Assignments.txt")

			Dim TempAssign As String

			Try
				AssignList = FilterList(AssignList)
				TempAssign = AssignList(randomizer.Next(0, AssignList.Count))
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
			My.Settings.Save()
			StringClean = StringClean.Replace("@VitalSubAssignment", "")
		End If

		If StringClean.Contains("@DeleteLocalImage") Then

			Debug.Print("FoundString = " & FoundString)

			Try
				mainPictureBox.Image.Dispose()
			Catch
			End Try
			mainPictureBox.Image = Nothing
			mainPictureBox.Refresh()
			ShowImage(Application.StartupPath & "\Images\System\Black.jpg")
			'ImageLocation = Application.StartupPath & "\Images\System\Black.jpg"
			'PBImage =
			'ImageThread.Start()
			'DisplayImage(Image.FromFile())
			'mainPictureBox.Image = Image.FromFile(Application.StartupPath & "\Images\System\Black.jpg")

			Debug.Print("DeleteLocalImageFilePath = " & DeleteLocalImageFilePath)

			If FrmSettings.CBDomDel.Checked = True Then
				Try
					My.Computer.FileSystem.DeleteFile(DeleteLocalImageFilePath)
				Catch
				End Try
			End If


			StringClean = StringClean.Replace("@DeleteLocalImage", "")
		End If

		If StringClean.Contains("@AddTokens(") Then

			Dim TokenFlag As String = GetParentheses(StringClean, "@AddTokens(")
			TokenFlag = FixCommas(TokenFlag)
			Dim TokenAdd As Integer

			If TokenFlag.Contains(",") Then
				Dim TokenArray As String() = TokenFlag.Split(",")
				For i As Integer = 0 To TokenArray.Count - 1
					TokenAdd = Val(TokenArray(i))
					If UCase(TokenArray(i)).Contains("B") Then BronzeTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("S") Then SilverTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("G") Then GoldTokens += TokenAdd
				Next
			Else
				TokenAdd = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then BronzeTokens += TokenAdd
				If UCase(TokenFlag).Contains("S") Then SilverTokens += TokenAdd
				If UCase(TokenFlag).Contains("G") Then GoldTokens += TokenAdd
			End If

			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.SilverTokens = SilverTokens
			My.Settings.GoldTokens = GoldTokens

			My.Settings.Save()

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
					If UCase(TokenArray(i)).Contains("B") Then BronzeTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("S") Then SilverTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("G") Then GoldTokens -= TokenRemove
				Next
			Else
				TokenRemove = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then BronzeTokens -= TokenRemove
				If UCase(TokenFlag).Contains("S") Then SilverTokens -= TokenRemove
				If UCase(TokenFlag).Contains("G") Then GoldTokens -= TokenRemove
			End If

			If BronzeTokens < 0 Then BronzeTokens = 0
			If SilverTokens < 0 Then SilverTokens = 0
			If GoldTokens < 0 Then GoldTokens = 0

			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.SilverTokens = SilverTokens
			My.Settings.GoldTokens = GoldTokens

			My.Settings.Save()

			StringClean = StringClean.Replace("@RemoveTokens(" & TokenFlag & ")", "")

		End If

		If StringClean.Contains("@Add1Token") Then
			BronzeTokens += 1
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 1 Bronze token!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add1Token", "")
		End If

		If StringClean.Contains("@Add3Tokens") Then
			BronzeTokens += 3
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 3 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add3Tokens", "")
		End If

		If StringClean.Contains("@Add5Tokens") Then
			BronzeTokens += 5
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			StringClean = StringClean.Replace("@Add5Tokens", "")
			MessageBox.Show(Me, domName.Text & " has given you 5 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If

		If StringClean.Contains("@Add10Tokens") Then
			BronzeTokens += 10
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 10 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add10Tokens", "")
		End If

		If StringClean.Contains("@Add25Tokens") Then
			BronzeTokens += 25
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 25 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add25Tokens", "")
		End If

		If StringClean.Contains("@Add50Tokens") Then
			BronzeTokens += 50
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 50 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Add100Tokens") Then
			BronzeTokens += 100
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Remove100Tokens") Then
			BronzeTokens -= 100
			My.Settings.BronzeTokens = BronzeTokens
			My.Settings.Save()
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has taken 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@@Remove100Tokens", "")
		End If


		If StringClean.Contains("@PlayAvoidTheEdge") Then
			' #### Reboot

			RandomVideo()

			If NoVideo = False Then

				ScriptTimer.Stop()
				SubStroking = True
				TempStrokeTauntVal = StrokeTauntVal
				TempFileText = FileText
				ScriptVideoTease = "Avoid The Edge"
				ScriptVideoTeaseFlag = True
				AvoidTheEdgeStroking = True
				AvoidTheEdgeGame = True
				ScriptVideoTeaseFlag = False
				VideoTease = True
				StartStrokingCount += 1
				StopMetronome = False
				StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				StrokePaceTimer.Interval = StrokePace
				StrokePaceTimer.Start()
				AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
				AvoidTheEdgeTaunts.Start()

			End If

			StringClean = StringClean.Replace("@PlayAvoidTheEdge", "")
		End If

		If StringClean.Contains("@ResumeAvoidTheEdge") Then
			DomWMP.Ctlcontrols.play()
			ScriptTimer.Stop()
			AvoidTheEdgeStroking = True
			SubStroking = True
			StartStrokingCount += 1
			StopMetronome = False
			VideoTease = True
			StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)
			StrokePaceTimer.Interval = StrokePace
			StrokePaceTimer.Start()
			AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
			AvoidTheEdgeTaunts.Start()
			StringClean = StringClean.Replace("@ResumeAvoidTheEdge", "")
		End If

		If StringClean.Contains("@PlayRedLightGreenLight") Then
			' #### Reboot

			RandomVideo()

			If NoVideo = False Then

				ScriptTimer.Stop()
				SubStroking = True
				TempStrokeTauntVal = StrokeTauntVal
				TempFileText = FileText
				ScriptVideoTease = "RLGL"
				ScriptVideoTeaseFlag = True
				'AvoidTheEdgeStroking = True
				RLGLGame = True

				ScriptVideoTeaseFlag = False
				VideoTease = True
				RLGLTick = randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
				RLGLTimer.Start()
				StartStrokingCount += 1
				StopMetronome = False
				StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				StrokePaceTimer.Interval = StrokePace
				StrokePaceTimer.Start()
				'VideoTauntTick = randomizer.Next(20, 31)
				'VideoTauntTimer.Start()

			End If
			StringClean = StringClean.Replace("@PlayRedLightGreenLight", "")
		End If

		If StringClean.Contains("@PlayVideo[") Then

			Dim VideoFlag As String = GetParentheses(StringClean, "@PlayVideo[")
			Dim VideoClean As String

			If StringClean.Contains("@JumpVideo") Then
				JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			If VideoFlag.Contains(":\") Then
				VideoClean = VideoFlag

				If File.Exists(VideoClean) Then
					DomWMP.URL = VideoClean
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					TeaseVideo = True

					If JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					JumpVideo = False

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
					DomWMP.URL = VideoList(randomizer.Next(0, VideoList.Count))
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					TeaseVideo = True

					If JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					JumpVideo = False
				Else
					MessageBox.Show(Me, "No videos matching " & Path.GetFileName(VideoClean) & " were found in " & Path.GetDirectoryName(VideoClean) & "!" & Environment.NewLine & Environment.NewLine &
					  "Please make sure that valid files exist and that the wildcards are applied correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			Else

				If File.Exists(VideoClean) Then
					DomWMP.URL = VideoClean
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					TeaseVideo = True

					If JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					JumpVideo = False

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
					DomWMP.URL = AudioList(randomizer.Next(0, AudioList.Count))
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
				JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			RandomizerVideo = True
			RandomVideo()

			If NoVideo = False Then
				TeaseVideo = True
				VideoTick = VidInt
				VideoTimer.Start()
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If





		If StringClean.Contains("@PlayVideo") Then

			If StringClean.Contains("@JumpVideo") Then
				JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			RandomizerVideo = True
			RandomVideo()

			If NoVideo = False Then
				TeaseVideo = True
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If

		If StringClean.Contains("@JumpVideo") Then

			If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VidLow As Integer = VideoLength * 0.4
				Dim VidHigh As Integer = VideoLength * 0.9
				Dim VidPoint As Integer = randomizer.Next(VidLow, VidHigh)

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
					StrokeSeconds = randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				StrokeTick += StrokeSeconds
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
					StrokeSeconds = randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				StrokeTick -= StrokeSeconds
				If StrokeTick < 0 Then StrokeTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveStrokeTime(" & OriginalFlag & ")", "")
		End If



		If StringClean.Contains("@AddStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				If FrmSettings.CBTauntCycleDD.Checked = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then StrokeTick += randomizer.Next(1, 3) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then StrokeTick += randomizer.Next(1, 4) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then StrokeTick += randomizer.Next(3, 6) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then StrokeTick += randomizer.Next(4, 8) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then StrokeTick += randomizer.Next(5, 11) * 60
				Else
					StrokeTick += randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				End If
			End If
			StringClean = StringClean.Replace("@AddStrokeTime", "")
		End If

		If StringClean.Contains("@RemoveStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				StrokeTick -= StrokeTick / 2
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
					HoldEdgeSeconds = randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				HoldEdgeTick += HoldEdgeSeconds
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
					HoldEdgeSeconds = randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				HoldEdgeTick -= HoldEdgeSeconds
				If HoldEdgeTick < 5 Then HoldEdgeTick = 5
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

				HoldEdgeTick += randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If HoldEdgeTick < 10 Then HoldEdgeTick = 10
			End If
			StringClean = StringClean.Replace("@AddEdgeHoldTime", "")
		End If

		If StringClean.Contains("@RemoveEdgeHoldTime") Then
			If HoldEdgeTimer.Enabled = True Then
				HoldEdgeTick = HoldEdgeTick / 2
				If HoldEdgeTick < 10 Then HoldEdgeTick = 10
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
					TeaseSeconds = randomizer.Next(Tease1, Tease2 + 1)
				Else
					TeaseSeconds = Val(TeaseFlag)
					If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600
				End If
				TeaseTick += TeaseSeconds
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
					TeaseSeconds = randomizer.Next(Tease1, Tease2 + 1)
				Else
					TeaseSeconds = Val(TeaseFlag)
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600
				End If
				TeaseTick -= TeaseSeconds
				If TeaseTick < 5 Then TeaseTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@AddTeaseTime") Then
			If TeaseTimer.Enabled = True Then
				If FrmSettings.CBTeaseLengthDD.Checked = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick += randomizer.Next(10, 16) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick += randomizer.Next(15, 21) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick += randomizer.Next(20, 31) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick += randomizer.Next(30, 46) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick += randomizer.Next(45, 61) * 60
				Else
					TeaseTick += randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
				End If
			End If
			StringClean = StringClean.Replace("@AddTeaseTime", "")
		End If

		If StringClean.Contains("@RemoveTeaseTime") Then
			If TeaseTimer.Enabled = True Then
				TeaseTick = TeaseTick / 2
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime", "")
		End If

		If StringClean.Contains("@PlaylistOff") Then
			Playlist = False
			StringClean = StringClean.Replace("@PlaylistOff", "")
		End If

		If StringClean.Contains("@UpdateOrgasm") Then
			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)

			'Github Patch
			If My.Settings.OrgasmsLocked = True Then My.Settings.OrgasmsRemaining -= 1

			My.Settings.Save()
			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm
			StringClean = StringClean.Replace("@UpdateOrgasm", "")
		End If

		If StringClean.Contains("@UpdateRuined") Then
			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)

			' GithubPatch
			If My.Settings.OrgasmsLocked = True Then My.Settings.OrgasmsRemaining -= 1

			My.Settings.Save()
			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined
			StringClean = StringClean.Replace("@UpdateRuined", "")
		End If

		If StringClean.Contains("@Slideshow(") Then

			Dim SlideFlag As String = StringClean

			Dim SlideStart As Integer

			SlideStart = SlideFlag.IndexOf("@Slideshow(") + 11
			SlideFlag = SlideFlag.Substring(SlideStart, SlideFlag.Length - SlideStart)
			SlideFlag = SlideFlag.Split(")")(0)
			SlideFlag = SlideFlag.Replace("@Slideshow(", "")

			CustomSlideshowList.Clear()

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			If LCase(SlideFlag).Contains("hardcore") Then
				Try
					If FrmSettings.CBIHardcoreSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("softcore") Then
				Try
					If FrmSettings.CBISoftcoreSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("lesbian") Then
				Try
					If FrmSettings.CBILesbianSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("blowjob") Then
				Try
					If FrmSettings.CBIBlowjobSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("femdom") Then
				Try
					If FrmSettings.CBIFemdomSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("lezdom") Then
				Try
					If FrmSettings.CBILezdomSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("hentai") Then
				Try
					If FrmSettings.CBIHentaiSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("gay") Then
				Try
					If FrmSettings.CBIGaySD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIGay.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIGay.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("maledom") Then
				Try
					If FrmSettings.CBIMaledomSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("captions") Then
				Try
					If FrmSettings.CBICaptionsSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("general") Then
				Try
					If FrmSettings.CBIGeneralSD.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("boob") Then
				Try
					If FrmSettings.CBBoobSubDir.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLBoobPath.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLBoobPath.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If

			If LCase(SlideFlag).Contains("butt") Then
				Try
					If FrmSettings.CBButtSubDir.Checked = True Then
						files = myDirectory.GetFiles(FrmSettings.LBLButtPath.Text, "*.*", SearchOption.AllDirectories)
					Else
						files = myDirectory.GetFiles(FrmSettings.LBLButtPath.Text, "*.*")
					End If

					Array.Sort(files)

					For Each fi As String In files
						If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
							CustomSlideshowList.Add(fi)
						End If
					Next
				Catch
				End Try
			End If


			CustomSlideshowTimer.Interval = 1000
			If LCase(SlideFlag).Contains("slow") Then CustomSlideshowTimer.Interval = 5000
			If LCase(SlideFlag).Contains("fast") Then CustomSlideshowTimer.Interval = 500


			StringClean = StringClean.Replace("@Slideshow(" & SlideFlag & ")", "")


		End If

		If StringClean.Contains("@SlideshowOn") Then
			If CustomSlideshowList.Count > 0 Then
				CustomSlideshow = True
				CustomSlideshowTimer.Start()
			End If
			StringClean = StringClean.Replace("@SlideshowOn", "")
		End If

		If StringClean.Contains("@SlideshowOff") Then
			CustomSlideshow = False
			CustomSlideshowTimer.Stop()
			StringClean = StringClean.Replace("@SlideshowOff", "")
		End If

		If StringClean.Contains("@SlideshowFirst") Then
			SlideshowInt = 0
			CustomSlideshow = True
			If Not mainPictureBox Is Nothing Then
				ClearMainPictureBox()
				Do
					Application.DoEvents()
				Loop Until mainPictureBox.Image Is Nothing
			End If
			mainPictureBox.BackgroundImage = Nothing
			mainPictureBox.Refresh()
			ShowImage(CustomSlideshowList(SlideshowInt))
			'ImageLocation = CustomSlideshowList(SlideshowInt)
			'PBImage =
			'ImageThread.Start()
			'DisplayImage(Image.FromFile())
			'mainPictureBox.Image = Image.FromFile(CustomSlideshowList(SlideshowInt))
			DeleteLocalImageFilePath = CustomSlideshowList(SlideshowInt)
			StringClean = StringClean.Replace("@SlideshowFirst", "")
		End If

		If StringClean.Contains("@SlideshowLast") Then
			SlideshowInt = CustomSlideshowList.Count - 1
			CustomSlideshow = True
			If Not mainPictureBox Is Nothing Then
				ClearMainPictureBox()
				Do
					Application.DoEvents()
				Loop Until mainPictureBox.Image Is Nothing
			End If
			mainPictureBox.BackgroundImage = Nothing
			mainPictureBox.Refresh()
			ShowImage(CustomSlideshowList(SlideshowInt))
			'ImageLocation = CustomSlideshowList(SlideshowInt)
			'PBImage = CustomSlideshowList(SlideshowInt)
			'ImageThread.Start()
			'DisplayImage(Image.FromFile())
			'mainPictureBox.Image = Image.FromFile(CustomSlideshowList(SlideshowInt))
			DeleteLocalImageFilePath = CustomSlideshowList(SlideshowInt)
			StringClean = StringClean.Replace("@SlideshowLast", "")
		End If

		If StringClean.Contains("@SlideshowNext") Then
			SlideshowInt += 1
			If SlideshowInt > CustomSlideshowList.Count - 1 Then SlideshowInt = CustomSlideshowList.Count - 1
			CustomSlideshow = True
			If Not mainPictureBox Is Nothing Then
				ClearMainPictureBox()
				Do
					Application.DoEvents()
				Loop Until mainPictureBox.Image Is Nothing
			End If
			mainPictureBox.BackgroundImage = Nothing
			mainPictureBox.Refresh()
			ShowImage(CustomSlideshowList(SlideshowInt))
			'ImageLocation = CustomSlideshowList(SlideshowInt)
			'PBImage = CustomSlideshowList(SlideshowInt)
			'ImageThread.Start()
			'DisplayImage(Image.FromFile())
			'mainPictureBox.Image = Image.FromFile(CustomSlideshowList(SlideshowInt))
			DeleteLocalImageFilePath = CustomSlideshowList(SlideshowInt)
			StringClean = StringClean.Replace("@SlideshowNext", "")
		End If

		If StringClean.Contains("@SlideshowPrevious") Then
			SlideshowInt -= 1
			If SlideshowInt < 0 Then SlideshowInt = 0
			CustomSlideshow = True
			If Not mainPictureBox Is Nothing Then
				ClearMainPictureBox()
				Do
					Application.DoEvents()
				Loop Until mainPictureBox.Image Is Nothing
			End If
			mainPictureBox.BackgroundImage = Nothing
			mainPictureBox.Refresh()
			ShowImage(CustomSlideshowList(SlideshowInt))
			'ImageLocation = CustomSlideshowList(SlideshowInt)
			'PBImage = CustomSlideshowList(SlideshowInt)
			'ImageThread.Start()
			'DisplayImage(Image.FromFile())
			'mainPictureBox.Image = Image.FromFile(CustomSlideshowList(SlideshowInt))
			DeleteLocalImageFilePath = CustomSlideshowList(SlideshowInt)
			StringClean = StringClean.Replace("@SlideshowPrevious", "")
		End If


		If StringClean.Contains("@GotoSlideshow") Then
			If ImageString.Contains(FrmSettings.LBLIHardcore.Text) Then FileGoto = "Hardcore"
			If ImageString.Contains(FrmSettings.LBLISoftcore.Text) Then FileGoto = "Softcore"
			If ImageString.Contains(FrmSettings.LBLILesbian.Text) Then FileGoto = "Lesbian"
			If ImageString.Contains(FrmSettings.LBLIBlowjob.Text) Then FileGoto = "Blowjob"
			If ImageString.Contains(FrmSettings.LBLIFemdom.Text) Then FileGoto = "Femdom"
			If ImageString.Contains(FrmSettings.LBLILezdom.Text) Then FileGoto = "Lezdom"
			If ImageString.Contains(FrmSettings.LBLIHentai.Text) Then FileGoto = "Hentai"
			If ImageString.Contains(FrmSettings.LBLIGay.Text) Then FileGoto = "Gay"
			If ImageString.Contains(FrmSettings.LBLIMaledom.Text) Then FileGoto = "Maledom"
			If ImageString.Contains(FrmSettings.LBLICaptions.Text) Then FileGoto = "Captions"
			If ImageString.Contains(FrmSettings.LBLIGeneral.Text) Then FileGoto = "General"
			If ImageString.Contains(FrmSettings.LBLBoobPath.Text) Then FileGoto = "Boobs"
			If ImageString.Contains(FrmSettings.LBLButtPath.Text) Then FileGoto = "Butts"

			Debug.Print("GotoSlideshow called, FileGoto = " & FileGoto)

			SkipGotoLine = True
			GetGoto()


			StringClean = StringClean.Replace("@GotoSlideshow", "")
		End If

		If StringClean.Contains("@RapidTextOn") Or StringClean.Contains("@RTOn") Then
			RapidFire = True
			StringClean = StringClean.Replace("@RapidTextOn", "")
			StringClean = StringClean.Replace("@RTOn", "")
		End If

		If StringClean.Contains("@RapidTextOff") Or StringClean.Contains("@RTOff") Then
			RapidFire = False
			StringClean = StringClean.Replace("@RapidTextOff", "")
			StringClean = StringClean.Replace("@RTOff", "")
		End If

		If StringClean.Contains("@AddContact1") Or StringClean.Contains("@RemoveContact1") Then
			AddContactTick = 2
			Contact1Timer.Start()
			StringClean = StringClean.Replace("@AddContact1", "")
			StringClean = StringClean.Replace("@RemoveContact1", "")
		End If

		If StringClean.Contains("@AddContact2") Or StringClean.Contains("@RemoveContact2") Then
			AddContactTick = 2
			Contact2Timer.Start()
			StringClean = StringClean.Replace("@AddContact2", "")
			StringClean = StringClean.Replace("@RemoveContact2", "")
		End If

		If StringClean.Contains("@AddContact3") Or StringClean.Contains("@RemoveContact3") Then
			AddContactTick = 2
			Contact3Timer.Start()
			StringClean = StringClean.Replace("@AddContact3", "")
			StringClean = StringClean.Replace("@RemoveContact3", "")
		End If

		If StringClean.Contains("@AddDomme") Or StringClean.Contains("@RemoveDomme") Then
			AddContactTick = 2
			DommeTimer.Start()
			StringClean = StringClean.Replace("@AddDomme", "")
			StringClean = StringClean.Replace("@RemoveDomme", "")
		End If


		If StringClean.Contains("@NullResponse") Then
			NullResponse = True
			StringClean = StringClean.Replace("@NullResponse", "")
			'Debug.Print("NullResponse Called")
		End If

VTSkip:

		If StringClean.Contains("@SpeedUpCheck") Then

			If AskedToSpeedUp = True Then
				ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace < 201 Then
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpMAX.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpALLOWED.txt"

					Else

						' you can't speed up
						AskedToSpeedUp = True
						ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SpeedUpCheck", "")
			GoTo RinseLatherRepeat
		End If


		If StringClean.Contains("@SlowDownCheck") Then

			If AskedToSpeedUp = True Then
				ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace > 999 Then
					ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownMIN.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownALLOWED.txt"

					Else

						' you can't speed up
						AskedToSpeedUp = True
						ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SlowDownCheck", "")
			GoTo RinseLatherRepeat

		End If


		If StringClean.Contains("@PlayRiskyPick") Then
			RiskyDeal = True
			'FrmCardList.RiskyRound += 1
			FrmCardList.TCGames.SelectTab(2)
			FrmCardList.Show()
			FrmCardList.Focus()
			FrmCardList.InitializeRiskyDeal()
			StringClean = StringClean.Replace("@PlayRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@ChooseRiskyPick") Then
			RiskyDelay = True
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
			BronzeTokens += FrmCardList.TokensPaid
			FrmCardList.LBLRiskTokens.Text = BronzeTokens
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
				FileGoto = "(Risky Game)"
			Else
				FileGoto = "(Risky Tease)"
			End If
			FrmCardList.RiskyState = False
			SkipGotoLine = True
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


			ReturnFileText = FileText
			ReturnStrokeTauntVal = StrokeTauntVal
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
			StrokePaceTimer.Stop()
			AvoidTheEdgeTaunts.Stop()
			RLGLTauntTimer.Stop()
			VideoTauntTimer.Stop()
			EdgeCountTimer.Stop()

			CBTBallsActive = False
			CBTBallsFlag = False
			CBTCockActive = False
			CBTCockFlag = False
			CBTBothActive = False
			CBTBothFlag = False
			CustomTaskActive = False

			If Not SubGaveUp Then
				SubEdging = False
				SubHoldingEdge = False
			End If

			'StopEverything()
			ReturnFlag = True


			Dim CheckFlag As String = GetParentheses(StringClean, "@CallReturn(")
			Dim CallReplace As String = CheckFlag

			If CheckFlag.Contains(",") Then

				CheckFlag = FixCommas(CheckFlag)

				Dim CallSplit As String() = CheckFlag.Split(",")
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
				FileGoto = CallSplit(1)
				SkipGotoLine = True
				GetGoto()

			Else

				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
				StrokeTauntVal = -1

			End If
			ScriptTick = 2
			ScriptTimer.Start()

			StringClean = StringClean.Replace("@CallReturn(" & CallReplace & ")", "")

		End If

		If StringClean.Contains("@Call(") Then

			Dim CheckFlag As String = GetParentheses(StringClean, "@Call(")
			Dim CallReplace As String = CheckFlag

			If CheckFlag.Contains(",") Then

				CheckFlag = FixCommas(CheckFlag)

				Dim CallSplit As String() = CheckFlag.Split(",")
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
				FileGoto = CallSplit(1)
				SkipGotoLine = True
				GetGoto()

			Else

				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
				StrokeTauntVal = -1

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
					FileText = RandomFile(randomizer.Next(0, RandomFile.Count))
					StrokeTauntVal = -1
				End If
			End If
			StringClean = StringClean.Replace("@CallRandom(" & CallReplace & ")", "")
		End If


		If StringClean.Contains("@RapidCodeOn") Then
			RapidCode = True
			StringClean = StringClean.Replace("@RapidCodeOn", "")
		End If

		If StringClean.Contains("@RapidCodeOff") Then
			RapidCode = False
			StringClean = StringClean.Replace("@RapidCodeOff", "")
		End If

		If StringClean.Contains("@InterruptsOff") Then
			DoNotDisturb = True
			StringClean = StringClean.Replace("@InterruptsOff", "")
		End If

		If StringClean.Contains("@InterruptsOn") Then
			DoNotDisturb = False
			StringClean = StringClean.Replace("@InterruptsOn", "")
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

		'If StringClean.Contains("@DeleteVar[") Then
		'Debug.Print("DeleteVar called")
		'Dim WriteFlag As String = GetParentheses(StringClean, "@DeleteVar[")
		'If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & WriteFlag) Then _
		'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & WriteFlag)
		'StringClean = StringClean.Replace("@DeleteVar[" & WriteFlag & "]", "")
		'End If

		If StringClean.Contains("@NoTypo") Then
			TypoSwitch = 0
			StringClean = StringClean.Replace("@NoTypo", "")
		End If

		If StringClean.Contains("@ForceTypo") Then
			TypoSwitch = 2
			StringClean = StringClean.Replace("@ForceTypo", "")
		End If

		If StringClean.Contains("@TyposOff") Then
			TyposDisabled = True
			StringClean = StringClean.Replace("@TyposOff", "")
		End If

		If StringClean.Contains("@TyposOn") Then
			TyposDisabled = False
			StringClean = StringClean.Replace("@TyposOn", "")
		End If

		If StringClean.Contains("@PornAllowedOff") Then
			CreateFlag("SYS_NoPornAllowed")
			StringClean = StringClean.Replace("@NoPornAllowed", "")
		End If

		If StringClean.Contains("@PornAllowedOn") Then
			DeleteFlag("SYS_NoPornAllowed")
			StringClean = StringClean.Replace("@PornAllowed", "")
		End If




		If StringClean.Contains("@ImageTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@ImageTag(")
			GetLocalImage(TagFlag)
			StringClean = StringClean.Replace("@ImageTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@GoodMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@GoodMood(")

			If DommeMood > FrmSettings.NBDomMoodMax.Value Then
				FileGoto = MoodFlag
				SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@GoodMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@BadMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@BadMood(")

			If DommeMood < FrmSettings.NBDomMoodMin.Value Then
				FileGoto = MoodFlag
				SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@BadMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@NeutralMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@NeutralMood(")

			If DommeMood >= FrmSettings.NBDomMoodMin.Value And DommeMood <= FrmSettings.NBDomMoodMax.Value Then
				FileGoto = MoodFlag
				SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@NeutralMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@MoodUp") Then
			DommeMood += 1
			If DommeMood > 10 Then DommeMood = 10
			StringClean = StringClean.Replace("@MoodUp", "")
		End If

		If StringClean.Contains("@MoodDown") Then
			DommeMood -= 1
			If DommeMood < 1 Then DommeMood = 1
			StringClean = StringClean.Replace("@MoodDown", "")
		End If

		If StringClean.Contains("@MoodBest") Then
			DommeMood = 10
			StringClean = StringClean.Replace("@MoodBest", "")
		End If

		If StringClean.Contains("@MoodWorst") Then
			DommeMood = 1
			StringClean = StringClean.Replace("@MoodWorst", "")
		End If

		If StringClean.Contains("@NewDommeSlideshow") Then
			NewDommeSlideshow = True
			OriginalDommeSlideshow = _ImageFileNames(0)
			LoadDommeImageFolder()
			NewDommeSlideshow = False
			DomPic = _ImageFileNames(FileCount)
			StringClean = StringClean.Replace("@NewDommeSlideshow", "")
		End If

		If StringClean.Contains("@Timeout(") Then

			Dim TimeFlag As String = GetParentheses(StringClean, "@Timeout(")
			Dim OriginalFlag As String = TimeFlag

			TimeFlag = FixCommas(TimeFlag)

			Dim TimeArray As String() = TimeFlag.Split(",")

			FileGoto = TimeArray(1)
			TimeoutTick = Val(TimeArray(0))
			TimeoutTimer.Start()

			StringClean = StringClean.Replace("@Timeout(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@BallTorture+1") Then
			CBTBallsCount += 1
			StringClean = StringClean.Replace("@BallTorture+1", "")
		End If

		If StringClean.Contains("@CockTorture+1") Then
			CBTCockCount += 1
			StringClean = StringClean.Replace("@CockTorture+1", "")
		End If


		If StringClean.Contains("@EndTaunts") Then
			StrokeTick = 0
			StringClean = StringClean.Replace("@EndTaunts", "")
		End If


		If StringClean.Contains("@ResponseYes(") Then
			ResponseYes = GetParentheses(StringClean, "@ResponseYes(")
			StringClean = StringClean.Replace("@ResponseYes(" & GetParentheses(StringClean, "@ResponseYes(") & ")", "")
		End If

		If StringClean.Contains("@ResponseNo(") Then
			ResponseNo = GetParentheses(StringClean, "@ResponseNo(")
			StringClean = StringClean.Replace("@ResponseNo(" & GetParentheses(StringClean, "@ResponseNo(") & ")", "")
		End If


		If StringClean.Contains("@SetModule(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetModule(")

			If TempMod.Contains(",") Then
				TempMod = FixCommas(TempMod)
				Dim TempArray As String() = TempMod.Split(",")
				TempMod = TempArray(0)
				SetModuleGoto = TempArray(1)

			End If


			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt") Then
				SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt") Then
				SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt"
			End If

			If SetModule = "" Then SetModuleGoto = ""

			StringClean = StringClean.Replace("@SetModule(" & GetParentheses(StringClean, "@SetModule(") & ")", "")
		End If

		If StringClean.Contains("@SetLink(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetLink(")
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt") Then
				SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt") Then
				SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt"
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

				Dim TotalSeconds As Integer = randomizer.Next(Seconds1, Seconds2 + 1)

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
			OrgasmRestricted = True
			StringClean = StringClean.Replace("@RestrictOrgasm(" & GetParentheses(StringClean, "@RestrictOrgasm(") & ")", "")
		End If

		If StringClean.Contains("@RestrictOrgasm") Then
			OrgasmRestricted = True
			StringClean = StringClean.Replace("@RestrictOrgasm", "")
		End If



		If StringClean.Contains("@FollowUp(") And FollowUp = "" Then
			FollowUp = GetParentheses(StringClean, "@FollowUp(")
			StringClean = StringClean.Replace("@FollowUp(" & FollowUp & ")", "")
		End If


		If StringClean.Contains("@FollowUp") And FollowUp = "" Then

			Dim TSStartIndex As Integer
			Dim TSEndIndex As Integer

			TSStartIndex = StringClean.IndexOf("@FollowUp") + 9
			TSEndIndex = StringClean.IndexOf("@FollowUp") + 11

			Dim FollowVal As Integer = Val(StringClean.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim)

			TempVal = randomizer.Next(1, 101)

			If TempVal <= FollowVal Then FollowUp = GetParentheses(StringClean, "@FollowUp" & FollowVal & "(")

			StringClean = StringClean.Replace("@FollowUp" & FollowVal & "(" & FollowUp & ")", "")

		End If

		If StringClean.Contains("@Worship(") Then
			Dim WorshipTemp As String = GetParentheses(StringClean, "@Worship(")
			Debug.Print("Worship Paren = " & WorshipTemp)
			If UCase(WorshipTemp) = "ASS" Then WorshipTarget = "Ass"
			If UCase(WorshipTemp) = "BOOBS" Then WorshipTarget = "Boobs"
			If UCase(WorshipTemp) = "PUSSY" Then WorshipTarget = "Pussy"
			WorshipMode = True
			StringClean = StringClean.Replace("@Worship(" & GetParentheses(StringClean, "@Worship(") & ")", "")
		End If

		If StringClean.Contains("@WorshipOn") Then
			WorshipMode = True
			StringClean = StringClean.Replace("@WorshipOn", "")
		End If

		If StringClean.Contains("@WorshipOff") Then
			WorshipMode = False
			WorshipTarget = ""
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
			WorshipTarget = ""
			StringClean = StringClean.Replace("@ClearWorship", "")
		End If




		If StringClean.Contains("@DecreaseOrgasmChance") Then

			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then FrmSettings.alloworgasmComboBox.Text = "Never Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then FrmSettings.alloworgasmComboBox.Text = "Rarely Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then FrmSettings.alloworgasmComboBox.Text = "Often Allows"

			My.Settings.OrgasmAllow = FrmSettings.alloworgasmComboBox.Text
			My.Settings.Save()

			StringClean = StringClean.Replace("@DecreaseOrgasmChance", "")
		End If

		If StringClean.Contains("@IncreaseOrgasmChance") Then

			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then FrmSettings.alloworgasmComboBox.Text = "Always Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then FrmSettings.alloworgasmComboBox.Text = "Often Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then FrmSettings.alloworgasmComboBox.Text = "Rarely Allows"

			My.Settings.OrgasmAllow = FrmSettings.alloworgasmComboBox.Text
			My.Settings.Save()

			StringClean = StringClean.Replace("@IncreaseOrgasmChance", "")
		End If

		If StringClean.Contains("@DecreaseRuinChance") Then

			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Never Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Often Ruins"

			My.Settings.OrgasmRuin = FrmSettings.ruinorgasmComboBox.Text
			My.Settings.Save()

			StringClean = StringClean.Replace("@DecreaseRuinChance", "")
		End If

		If StringClean.Contains("@IncreaseRuinChance") Then

			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Always Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Often Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins"

			My.Settings.OrgasmRuin = FrmSettings.ruinorgasmComboBox.Text
			My.Settings.Save()

			StringClean = StringClean.Replace("@IncreaseRuinChance", "")
		End If



		If StringClean.Contains("@MiniScript(") Then

			Dim MiniTemp As String = GetParentheses(StringClean, "@MiniScript(")


			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\MiniScripts\" & MiniTemp & ".txt") Then ' And MiniScript = False Then
				MiniScript = True
				MiniScriptText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\MiniScripts\" & MiniTemp & ".txt"
				MiniTauntVal = -1
				MiniTimerCheck = ScriptTimer.Enabled
				ScriptTick = 2
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
					SkipGotoLine = True
					FileGoto = FileArray(1)
					GetGoto()
				End If

				If Not File.Exists(FileArray(0)) And FileArray.Count = 3 Then
					SkipGotoLine = True
					FileGoto = FileArray(2)
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
				YesGoto = True
				YesGotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("VIDEO") Then
				YesVideo = True
				YesGotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("NORMAL") Then
				YesGoto = False
				YesVideo = False
			End If

			StringClean = StringClean.Replace("@YesMode(" & GetParentheses(StringClean, "@YesMode(") & ")", "")
		End If

		If StringClean.Contains("@NoMode(") Then

			Dim NoFlag As String = GetParentheses(StringClean, "@NoMode(")
			NoFlag = FixCommas(NoFlag)
			Dim NoArray As String() = NoFlag.Split(",")

			If UCase(NoArray(0)).Contains("GOTO") Then
				NoGoto = True
				NoGotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("VIDEO") Then
				NoVideo_Mode = True
				NoGotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("NORMAL") Then
				NoGoto = False
				NoVideo_Mode = False
			End If

			StringClean = StringClean.Replace("@NoMode(" & GetParentheses(StringClean, "@NoMode(") & ")", "")
		End If

		If StringClean.Contains("@CameMode(") Then

			Dim CameFlag As String = GetParentheses(StringClean, "@CameMode(")
			CameFlag = FixCommas(CameFlag)
			Dim CameArray As String() = CameFlag.Split(",")

			If UCase(CameArray(0)).Contains("GOTO") Then
				CameGoto = True
				CameGotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("MESSAGE") Then
				CameMessage = True
				CameMessageText = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("VIDEO") Then
				CameVideo = True
				CameGotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("NORMAL") Then
				CameGoto = False
				CameMessage = False
				CameVideo = False
			End If

			StringClean = StringClean.Replace("@CameMode(" & GetParentheses(StringClean, "@CameMode(") & ")", "")
		End If

		If StringClean.Contains("@RuinedMode(") Then

			Dim RuinedFlag As String = GetParentheses(StringClean, "@RuinedMode(")
			RuinedFlag = FixCommas(RuinedFlag)
			Dim RuinedArray As String() = RuinedFlag.Split(",")

			If UCase(RuinedArray(0)).Contains("GOTO") Then
				RuinedGoto = True
				RuinedGotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("MESSAGE") Then
				RuinedMessage = True
				RuinedMessageText = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("VIDEO") Then
				RuinedVideo = True
				RuinedGotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("NORMAL") Then
				RuinedGoto = False
				RuinedMessage = False
				RuinedVideo = False
			End If

			StringClean = StringClean.Replace("@RuinedMode(" & GetParentheses(StringClean, "@RuinedMode(") & ")", "")
		End If

		If StringClean.Contains("@ClearModes") Then
			ClearModes()
			StringClean = StringClean.Replace("@ClearModes", "")
		End If


		If StringClean.Contains("@CurrentImage") Then StringClean = StringClean.Replace("@CurrentImage", CurrentImage)

		If StringClean.Contains("@Debug") Then

			'Dim wy As Long = DateDiff(DateInterval.Day, Val(GetVariable("TB_AFKSlideshow")), Date.Now)

			MsgBox(DateDiff(DateInterval.Hour, GetDate("TB_AFKSlideshow"), Now))



			'MsgBox(GetVariable("Sys_EndTotal") & " less than 30? " & CheckVariable("@Variable[Sys_EndTotal]<[30] blah blah blah"))
			StringClean = StringClean.Replace("@Debug", "")
		End If


		If StringClean.Contains("@GotoDommeOrgasm") Then

			'Debug.Print("GotoDommeOrgasmCalled")


			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then FileGoto = "(Never Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then FileGoto = "(Rarely Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then FileGoto = "(Sometimes Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then FileGoto = "(Often Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then FileGoto = "(Always Allows)"

			'Debug.Print(FileGoto)

			SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeOrgasm", "")

		End If

		If StringClean.Contains("@GotoDommeRuin") Then

			Debug.Print("GotoDommeRuinedCalled")


			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then FileGoto = "(Never Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then FileGoto = "(Rarely Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then FileGoto = "(Sometimes Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then FileGoto = "(Often Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then FileGoto = "(Always Ruins)"

			'Debug.Print(FileGoto)

			SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeRuin", "")

		End If

		If StringClean.Contains("@GotoDommeApathy") Then

			'Debug.Print("GotoDommeApathyCalled")


			If FrmSettings.NBEmpathy.Value = 1 Then FileGoto = "(ApathyLevel1)"
			If FrmSettings.NBEmpathy.Value = 2 Then FileGoto = "(ApathyLevel2)"
			If FrmSettings.NBEmpathy.Value = 3 Then FileGoto = "(ApathyLevel3)"
			If FrmSettings.NBEmpathy.Value = 4 Then FileGoto = "(ApathyLevel4)"
			If FrmSettings.NBEmpathy.Value = 5 Then FileGoto = "(ApathyLevel5)"

			'Debug.Print(FileGoto)

			SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeApathy", "")

		End If

		If StringClean.Contains("@GotoDommeLevel") Then

			If FrmSettings.domlevelNumBox.Value = 1 Then FileGoto = "(DommeLevel1)"
			If FrmSettings.domlevelNumBox.Value = 2 Then FileGoto = "(DommeLevel2)"
			If FrmSettings.domlevelNumBox.Value = 3 Then FileGoto = "(DommeLevel3)"
			If FrmSettings.domlevelNumBox.Value = 4 Then FileGoto = "(DommeLevel4)"
			If FrmSettings.domlevelNumBox.Value = 5 Then FileGoto = "(DommeLevel5)"

			'Debug.Print(FileGoto)

			SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeLevel", "")

		End If


		'If StringClean.Contains("@CheckBnB") Then
		'If FrmSettings.CBEnableBnB.Checked = False Then
		'FileGoto = "(No BnB)"
		'SkipGotoLine = True
		'GetGoto()
		'End If
		'StringClean = StringClean.Replace("@CheckBnB", "")
		'End If






		' @TnAFastSlides is a defunct Command that has been replaced by the options available with the @Slideshow function

		If StringClean.Contains("@TnAFastSlides") Or StringClean.Contains("@TnASlowSlides") Or StringClean.Contains("@TnASlides") Then

			' FrmSettings.offRadio.Checked = True
			TnAList.Clear()

			If StringClean.Contains("@TnAFastSlides") Then TnASlides.Interval = 334
			If StringClean.Contains("@TnASlides") Then TnASlides.Interval = 1000
			If StringClean.Contains("@TnASlowSlides") Then TnASlides.Interval = 5000


			'Debug.Print("TNAFASTSLIDES CALLED")

			GetTnAList()

			'Debug.Print("TNALIST.COUNT = " & TnAList.Count)

			'Debug.Print("CALLING TNAFASTLIDES.START")
			TnASlides.Start()
			StringClean = StringClean.Replace("@TnAFastSlides", "")
			StringClean = StringClean.Replace("@TnASlowSlides", "")
			StringClean = StringClean.Replace("@TnASlides", "")
		End If

		If StringClean.Contains("@CheckTnA") Then
			TnASlides.Stop()

			'Debug.Print("@CheckTnA called ::: AssImage = " & AssImage & " ::: BoobImage = " & BoobImage)
			If AssImage = True Then FileGoto = "(Butt)"
			If BoobImage = True Then FileGoto = "(Boobs)"
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckTnA", "")
		End If

		If StringClean.Contains("@StopTnA") Then
			TnASlides.Stop()
			StringClean = StringClean.Replace("@StopTnA", "")
		End If


		' The @NewBlogImage Command is a defunct Command that has been replaced by @ShowBlogImage

		If StringClean.Contains("@NewBlogImage") Then
			GetBlogImage()
			StringClean = StringClean.Replace("@NewBlogImage", "")
			'Debug.Print("Is this being called?")
		End If


		If StringClean.Contains("@CheckStrokingState") Then
			'If SubStroking = True Then
			If SubStroking = True Or SubEdging = True Or SubHoldingEdge = True Then
				FileGoto = "(Sub Stroking)"
			Else
				FileGoto = "(Sub Not Stroking)"
			End If
			SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckStrokingState", "")
		End If

		'The @SetGroup Command is a defunct Command that was created when implementing new Glitter features. It has no use in the current build of Tease AI.

		If StringClean.Contains("@SetGroup(") Then

			Dim WF As String = UCase(GetParentheses(StringClean, "@SetGroup("))

			If WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then Group = "D"
			If WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then Group = "D1"
			If WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then Group = "D12"
			If WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then Group = "D13"
			If WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then Group = "D23"
			If WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then Group = "D123"

			If Not WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then Group = "1"
			If Not WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then Group = "12"
			If Not WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then Group = "123"

			If WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then Group = "D2"
			If Not WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then Group = "2"
			If Not WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then Group = "23"

			If WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then Group = "D3"
			If Not WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then Group = "3"
			If Not WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then Group = "13"

			StringClean = StringClean.Replace("@SetGroup(" & WF & ")", "")

		End If

		Debug.Print("Command Clean Complete")

		Return StringClean

	End Function


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

	Public Function CreateFlag(ByVal FlagDir As String)

		Dim FlagCreate As FileStream = File.Create(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir)
		FlagCreate.Close()
		FlagCreate.Dispose()


	End Function

	Public Function CreateTempFlag(ByVal FlagDir As String)

		Dim FlagCreate As FileStream = File.Create(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir)
		FlagCreate.Close()
		FlagCreate.Dispose()


	End Function


	Public Function DeleteFlag(ByVal FlagDir As String)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir) Then _
					My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir) Then _
		 My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir)


	End Function

	Public Function FlagExists(ByVal FlagDir As String) As Boolean

		Dim CheckFlag As Boolean

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir) Or
			File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir) Then
			CheckFlag = True
		Else
			CheckFlag = False
		End If

		Return CheckFlag

	End Function

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

		ScriptOperator = "Null"
		If ChangeOperator.Contains("+") Then ScriptOperator = "Add"
		If ChangeOperator.Contains("-") Then ScriptOperator = "Subtract"
		If ChangeOperator.Contains("*") Then ScriptOperator = "Multiply"
		If ChangeOperator.Contains("/") Then ScriptOperator = "Divide"

		Dim ChangeVal As Integer = 0

		If ScriptOperator = "Add" Then ChangeVal = Val1 + Val2
		If ScriptOperator = "Subtract" Then ChangeVal = Val1 - Val2
		If ScriptOperator = "Multiply" Then ChangeVal = Val1 * Val2
		If ScriptOperator = "Divide" Then ChangeVal = Val1 / Val2

		My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVar, ChangeVal, False)

	End Function

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

	Public Function CheckVariable(ByVal VarCheckList As String) As Boolean

		Dim VarCompare As Boolean = False


		Dim VarSplit As String() = Split(VarCheckList)

		For i As Integer = 0 To VarSplit.Count - 1

			Dim SCGotVar As String = "Null"

			If VarSplit(i).Contains("@Variable[") Then



				SCGotVar = VarSplit(i).Replace("@Variable[", "")
				Dim SCGotVarSplit As String() = Split(SCGotVar, "]", 2)

				Debug.Print("SCGotVars = " & SCGotVarSplit(0) & SCGotVarSplit(1))

				Dim Val1 As Integer = -18855881
				Dim Str1 As String = SCGotVarSplit(0)

				Debug.Print("SCGotVarSplit(0)= " & SCGotVarSplit(0))

				If IsNumeric(Str1) = True Then

					Debug.Print("InNumeric Called")

					Val1 = Val(SCGotVarSplit(0))

				Else

					Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & SCGotVarSplit(0)
					'Debug.Print("VarCheck = " & VarCheck)
					'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
					If File.Exists(VarCheck) Then
						'Debug.Print("VarCheck Exists")
						Dim StrCheck As String = TxtReadLine(VarCheck)

						Debug.Print("StrChec = " & StrCheck)

						If IsNumeric(StrCheck) = True Then
							Val1 = Val(StrCheck)
						Else
							Str1 = StrCheck
						End If


					End If

				End If

				Debug.Print("Val1 = " & Val1)

				'Debug.Print("@SetVar VarDifference = " & Val1)

				'Debug.Print("@SetVar Val = " & Val1)
				SCGotVarSplit(0) = ""

				SCGotVar = Join(SCGotVarSplit)
				'Debug.Print("@SetVar SCGotVar = " & SCGotVar)

				SCGotVarSplit = Split(SCGotVar, "[", 2)
				SCGotVarSplit(0) = SCGotVarSplit(0).Replace(" ", "")
				'Debug.Print("@SetVar SCGotVarSplit = " & SCGotVarSplit(0))

				ScriptCompare = "Null"

				If SCGotVarSplit(0) = "=" Or SCGotVarSplit(0) = "==" Then ScriptCompare = "="
				If SCGotVarSplit(0) = "<>" Then ScriptCompare = "<>"
				If SCGotVarSplit(0) = ">" Then ScriptCompare = ">"
				If SCGotVarSplit(0) = "<" Then ScriptCompare = "<"
				If SCGotVarSplit(0) = ">=" Then ScriptCompare = ">="
				If SCGotVarSplit(0) = "<=" Then ScriptCompare = "<="



				SCGotVarSplit(0) = ""

				SCGotVar = Join(SCGotVarSplit)






				SCGotVarSplit = Split(SCGotVar, "]", 2)
				SCGotVarSplit(0) = SCGotVarSplit(0).Replace(" ", "")





				Dim Val2 As Integer = -18855881
				Dim Str2 As String = SCGotVarSplit(0)

				Debug.Print("SCGotVarSplit(0)= " & SCGotVarSplit(0))

				If IsNumeric(Str2) = True Then

					Debug.Print("InNumeric Called")

					Val2 = Val(SCGotVarSplit(0))

				Else

					Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & SCGotVarSplit(0)
					'TODO: Remove unsecure IO.Access to file, for there is no DirectoryCheck.
					If File.Exists(VarCheck) Then
						Dim StrCheck As String = TxtReadLine(VarCheck)
						Debug.Print("StrChec = " & StrCheck)
						If IsNumeric(StrCheck) = True Then
							Val2 = Val(StrCheck)
						Else
							Str2 = StrCheck
						End If
					End If

				End If

				Debug.Print("Val2 = " & Val2)


				Dim CompareCheck As String = "Null"

				If Val1 = -18855881 Or Val2 = -18855881 Then

					Debug.Print("Compare strings called")

					Debug.Print("Str1 = " & Str1)
					Debug.Print("Str2 = " & Str2)


					If ScriptCompare = "=" Then
						If UCase(Str1) = UCase(Str2) Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<>" Then
						If UCase(Str1) <> UCase(Str2) Then CompareCheck = SCGotVarSplit(1)
					End If

				Else

					Debug.Print("Compare integers called")

					If ScriptCompare = "=" Then
						If Val1 = Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<>" Then
						If Val1 <> Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = ">" Then
						If Val1 > Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<" Then
						If Val1 < Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = ">=" Then
						If Val1 >= Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

					If ScriptCompare = "<=" Then
						If Val1 <= Val2 Then CompareCheck = SCGotVarSplit(1)
					End If

				End If



				If CompareCheck <> "Null" Then VarCompare = True

			End If
		Next


		Return VarCompare


	End Function

	Public Function CheckDateList(ByVal DateString As String) As Boolean

		Dim DateCheck As Boolean = False

		Dim DateFlag As String = GetParentheses(DateString, "@CheckDate(")


		If DateFlag.Contains(",") Then

			DateFlag = FixCommas(DateFlag)

			Dim DateArray() As String = DateFlag.Split(",")
			Dim DDiff As Integer = 18855881
			Dim DDiff2 As Integer = 18855881

			If DateArray.Count = 2 Then

				If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
				If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

				If DDiff >= Val(DateArray(1)) Then DateCheck = True

			End If

			If DateArray.Count = 3 Then

				If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
				If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
				If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

				If UCase(DateArray(2)).Contains("SECOND") Then DDiff2 = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
				If UCase(DateArray(2)).Contains("MINUTE") Then DDiff2 = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
				If UCase(DateArray(2)).Contains("HOUR") Then DDiff2 = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
				If UCase(DateArray(2)).Contains("DAY") Then DDiff2 = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
				If UCase(DateArray(2)).Contains("WEEK") Then DDiff2 = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
				If UCase(DateArray(2)).Contains("MONTH") Then DDiff2 = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
				If UCase(DateArray(2)).Contains("YEAR") Then DDiff2 = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

				If DDiff >= Val(DateArray(1)) And DDiff2 <= Val(DateArray(2)) Then DateCheck = True

			End If

		Else

			If CompareDatesWithTime(GetDate(DateFlag)) <> 1 Then DateCheck = True

		End If


		'If DDiff >= Val(DateArray(1)) Then DateCheck = True

		'If Not DateArray(2) Is Nothing And DateCheck = True Then

		'FileGoto = DateArray(2)
		'SkipGotoLine = True
		'GetGoto()

		'End If

		Return DateCheck

	End Function

	Public Function GetParentheses(ByVal ParenCheck As String, ByVal CommandCheck As String) As String



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

		Dim ParenEnd As Integer = ParenFlag.IndexOf(ParenType, ParenStart)
		If ParenEnd = -1 Then ParenEnd = ParenFlag.Length
		ParenFlag = ParenFlag.Substring(ParenStart, ParenEnd - ParenStart)

		ParenFlag = ParenFlag.Split(")")(0)
		'ParenFlag = ParenFlag.Split(ParenType)(0)
		ParenFlag = ParenFlag.Replace(ParenType, "")
		Debug.Print("ParenFlag = " & ParenFlag)

		Return ParenFlag


	End Function

	Public Function FixCommas(ByVal CommaString) As String

		CommaString = CommaString.replace(", ", ",")
		CommaString = CommaString.replace(" ,", ",")

		Return CommaString

	End Function

	Public Function GetEdgeHoldMinutes(ByVal HoldTime As Integer) As Boolean

		Dim HoldEdgeCheck As Boolean = False

		If HoldEdgeTime >= HoldTime * 60 Then HoldEdgeCheck = True

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
			Dim __targetFolder As String = Path.GetDirectoryName(_ImageFileNames(FileCount))

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
							Throw New Exception("No DommeImage found for Tags: '" & ___DomTag_Base & "' in directory: '" & __targetFolder & "'")
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
							Dim ___FileDist As Integer = _ImageFileNames.IndexOf(__targetFolder & "\" & ___ForFile) - FileCount
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
						If randomizer.Next(0, 100) <= 99 Then GoTo Skip_RandomFile ' 1% can be a nice surprise
						'########################+####### Get random Image ###############################
						___FileName = ___FoundFiles.Item(randomizer.Next(0, ___FoundFiles.Count - 1))
Skip_RandomFile:
						If File.Exists(__targetFolder & "\" & ___FileName) Then
                            ' File Found: Return absolute path
                            Return DirectCast(__targetFolder & "\" & ___FileName, String)
						Else
                            '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                            '                           Try-Finding-Another File
                            '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                            ' File not Found: Get next in List
                            'SUGGESTION: Build in a Debug-Window, so the User can review such "Erros", without beeing interrupted (ôÔ).
                            Debug.Print(String.Format(
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
            'SUGGESTION: Build in a Debug-Window, so the User can review such "Erros", without beeing interrupted (ôÔ).
            Debug.Print(ex.Message)
			Return ""
		End Try
	End Function

	Public Function GetLocalImage(ByVal LocTag As String) As Boolean

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

				Dim PicArray As String() = TaggedList(randomizer.Next(0, TaggedList.Count)).Split
				Dim PicDir As String = ""

				For p As Integer = 0 To PicArray.Count - 1
					PicDir = PicDir & PicArray(p) & " "
					If UCase(PicDir).Contains(".JPG") Or UCase(PicDir).Contains(".JPEG") Or UCase(PicDir).Contains(".PNG") Or UCase(PicDir).Contains(".BMP") Or UCase(PicDir).Contains(".GIF") Then Exit For
				Next

				If LocalImageListCheck = False Then
					'LocalImage = Image.FromFile(PicDir)
					LocalImageSTR = PicDir
					DeleteLocalImageFilePath = PicDir
				End If

				LocalImageFound = True


			Else

				LocalImageFound = False

			End If

		End If



		Return LocalImageFound

	End Function


	Public Function ContactEdgeCheck(ByVal EdgeCheck As String)
		If EdgeCheck.Contains("@Contact1") Then Contact1Edge = True
		If EdgeCheck.Contains("@Contact2") Then Contact2Edge = True
		If EdgeCheck.Contains("@Contact3") Then Contact3Edge = True
	End Function

	Public Sub DisableContactStroke()
		Contact1Stroke = False
		Contact2Stroke = False
		Contact3Stroke = False
	End Sub

	Public Sub GetSubState()

		ReturnSubState = "Rest"
		If SubStroking = True Then ReturnSubState = "Stroking"
		If SubEdging = True Then ReturnSubState = "Edging"
		If SubHoldingEdge = True Then ReturnSubState = "Holding The Edge"
		If CBTBallsFlag = True Or CBTBothFlag = True Then ReturnSubState = "CBTBalls"
		If CBTCockFlag = True Then ReturnSubState = "CBTCock"
		If CensorshipGame = True Then ReturnSubState = "Censorship Sucks"
		If AvoidTheEdgeGame = True Then ReturnSubState = "Avoid The Edge"
		If RLGLGame = True Then ReturnSubState = "RLGL"



	End Sub


	Public Sub EdgePace()

		StrokePace = randomizer.Next(NBMaxPace.Value, NBMaxPace.Value + 151)
		If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value
		StrokePace = 50 * Math.Round(StrokePace / 50)

	End Sub




	Public Sub ShowGotImage()

		'Debug.Print("ShowGotImage Called")
		'Debug.Print("FoundString = " & FoundString)
		JustShowedBlogImage = True


		' ClearMainPictureBox()

		If FoundString.Contains("/") Then
			Try
				ShowImage(FoundString, True)
				'ImageLocation = FoundString
				'PBImage = FoundString
				'ImageThread.Start()
				'DisplayImage(Image.FromFile())
				'DisplayImage(New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(FoundString))))
				'mainPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(FoundString)))
			Catch
				ClearMainPictureBox()
				MessageBox.Show(Me, "Failed to load image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		Else
			ShowImage(FoundString, True)
			'ImageLocation = FoundString
			'PBImage = FoundString
			'ImageThread.Start()
			'mainPictureBox.Image = Image.FromFile(FoundString)
			DeleteLocalImageFilePath = FoundString
		End If




	End Sub

	Public Function FilterList(ByVal ListClean As List(Of String)) As List(Of String)

		ListClean.Add("### BUFFER LINE ###")

		'For i As Integer = 0 To ListClean.Count - 1
		'Debug.Print(i & ". " & ListClean(i))
		'Next

		FoundTag = "NULL"

		Try
			If File.Exists(_ImageFileNames(FileCount)) Then MainPictureImage = Path.GetDirectoryName(_ImageFileNames(FileCount))
		Catch
		End Try

		'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
		If File.Exists(MainPictureImage & "\ImageTags.txt") Then
			' Read all lines of the given file.
			Dim TagList As List(Of String) = Txt2List(MainPictureImage & "\ImageTags.txt")


			'If SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And domVLC.Visible = False Then
			If SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And DomWMP.Visible = False Then
				Try
					For t As Integer = 0 To TagList.Count - 1
						'Debug.Print("TagList(t) = " & TagList(t))
						If TagList(t).Contains(Path.GetFileName(_ImageFileNames(FileCount))) Then
							FoundTag = TagList(t)
							Dim FoundTagSplit As String() = Split(FoundTag)
							For j As Integer = 0 To FoundTagSplit.Length - 1
								If FoundTagSplit(j).Contains("TagGarment") Then
									TagGarment = FoundTagSplit(j).Replace("TagGarment", "")
									TagGarment = TagGarment.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagUnderwear") Then
									TagUnderwear = FoundTagSplit(j).Replace("TagUnderwear", "")
									TagUnderwear = TagUnderwear.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagTattoo") Then
									TagTattoo = FoundTagSplit(j).Replace("TagTattoo", "")
									TagTattoo = TagTattoo.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagSexToy") Then
									TagSexToy = FoundTagSplit(j).Replace("TagSexToy", "")
									TagSexToy = TagSexToy.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagFurniture") Then
									TagFurniture = FoundTagSplit(j).Replace("TagFurniture", "")
									TagFurniture = TagFurniture.Replace("-", " ")
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







		Dim PoundCount As Integer = ListClean.Count
		Dim PoundLine As Integer = PoundCount

		Debug.Print("Begin FilterTest")






		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Crazy") Then
				If FrmSettings.crazyCheckBox.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@Crazy", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Vulgar") Then
				If FrmSettings.vulgarCheckBox.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@Vulgar", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Supremacist") Then
				If FrmSettings.supremacistCheckBox.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@Supremacist", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Sadistic") Then
				If FrmSettings.sadisticCheckBox.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Degrading") Then
				If FrmSettings.degradingCheckBox.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel(") Then
				If FilterCheck(GetParentheses(ListClean(PoundCount), "@DommeLevel("), FrmSettings.domlevelNumBox) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel1") Then
				If FrmSettings.domlevelNumBox.Value <> 1 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DommeLevel1", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel2") Then
				If FrmSettings.domlevelNumBox.Value <> 2 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DommeLevel2", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel3") Then
				If FrmSettings.domlevelNumBox.Value <> 3 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DommeLevel3", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel4") Then
				If FrmSettings.domlevelNumBox.Value <> 4 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DommeLevel4", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DommeLevel5") Then
				If FrmSettings.domlevelNumBox.Value <> 5 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DommeLevel5", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SelfYoung") Then
				If FrmSettings.domageNumBox.Value > FrmSettings.NBSelfAgeMin.Value - 1 Then 'Or DommeVideo = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SelfYoung") Then
				If VideoTease = True Or TeaseVideo = True Then
					If DommeVideo = False Then
						If StrokeFilter = True Then
							For i As Integer = 0 To StrokeTauntCount - 1
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							Next
						Else
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						End If
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SelfOld") Then
				If FrmSettings.domageNumBox.Value < FrmSettings.NBSelfAgeMax.Value + 1 Then 'Or DommeVideo = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SelfOld") Then
				If VideoTease = True Or TeaseVideo = True Then
					If DommeVideo = False Then
						If StrokeFilter = True Then
							For i As Integer = 0 To StrokeTauntCount - 1
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							Next
						Else
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						End If
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Cup(") Then
				If FilterCheck(GetParentheses(ListClean(PoundCount), "@Cup("), FrmSettings.boobComboBox) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ACup") Then
				If FrmSettings.boobComboBox.Text <> "A" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@ACup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BCup") Then
				If FrmSettings.boobComboBox.Text <> "B" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@BCup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CCup") Then
				If FrmSettings.boobComboBox.Text <> "C" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@CCup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DCup") Then
				If FrmSettings.boobComboBox.Text <> "D" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DCup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DDCup") Then
				If FrmSettings.boobComboBox.Text <> "DD" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DDCup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DDD+Cup") Then
				If FrmSettings.boobComboBox.Text <> "DDD+" Or JustShowedBlogImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@DDD+Cup", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockSmall") Then
				If FrmSettings.CockSizeNumBox.Value >= FrmSettings.NBAvgCockMin.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@CockSmall", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockLarge") Then
				If FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@CockLarge", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockAverage") Then
				If FrmSettings.CockSizeNumBox.Value < FrmSettings.NBAvgCockMin.Value Or FrmSettings.CockSizeNumBox.Value > FrmSettings.NBAvgCockMax.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@CockLarge", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubYoung") Then
				If FrmSettings.subAgeNumBox.Value >= FrmSettings.NBSubAgeMin.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@SubYoung", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubOld") Then
				If FrmSettings.subAgeNumBox.Value <= FrmSettings.NBSubAgeMax.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@SubOld", "")
			End If
		Loop Until PoundCount = 0



		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubBirthday") Then
				If FrmSettings.NBBirthdayMonth.Value <> Month(Date.Now) And FrmSettings.NBBirthdayDay.Value <> DateAndTime.Day(Date.Now) Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@SubBirthday", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ValentinesDay") Then
				If Month(Date.Now) <> 2 And DateAndTime.Day(Date.Now) <> 14 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@ValentinesDay", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ChristmasEve") Then
				If Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 24 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@ChristmasEve", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ChristmasDay") Then
				If Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 25 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@ChristmasDay", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NewYearsEve") Then
				If Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 31 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NewYearsEve", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NewYearsDay") Then
				If Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 25 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NewYearsDay", "")
			End If
		Loop Until PoundCount = 0





		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagFace") Then
				If Not FoundTag.Contains("TagFace") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Face")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagFace", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagBoobs") Then
				If Not FoundTag.Contains("TagBoobs") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Boobs")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagBoobs", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagPussy") Then
				If Not FoundTag.Contains("TagPussy") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Pussy")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagPussy", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagAss") Then
				If Not FoundTag.Contains("TagAss") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Ass")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagAss", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagFeet") Then
				If Not FoundTag.Contains("TagFeet") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains FullBody")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagFeet", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagLegs") Then
				If Not FoundTag.Contains("TagLegs") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagLegs")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagLegs", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagMasturbating") Then
				If Not FoundTag.Contains("TagMasturbating") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Masturbating")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagMasturbating", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagSucking") Then
				If Not FoundTag.Contains("TagSucking") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Sucking")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagSucking", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagFullyDressed") Then
				If Not FoundTag.Contains("TagFullyDressed") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains FullyDressed")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagFullyDressed", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagHalfDressed") Then
				If Not FoundTag.Contains("TagHalfDressed") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains HalfDressed")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagHalfDressed", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagGarmentCovering") Then
				If Not FoundTag.Contains("TagGarmentCovering") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagGarmentCovering")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagGarmentCovering", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagHandsCovering") Then
				If Not FoundTag.Contains("TagHandsCovering") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagHandsCovering")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagHandsCovering", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagNaked") Then
				If Not FoundTag.Contains("TagNaked") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Naked")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagNaked", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagSideView") Then
				If Not FoundTag.Contains("TagSideView") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains Normal")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagNormal", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagCloseUp") Then
				If Not FoundTag.Contains("TagCloseUp") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains CloseUp")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagCloseUp", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagPiercing") Then
				If Not FoundTag.Contains("TagPiercing") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagPiercing")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagPiercing", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagSmiling") Then
				If Not FoundTag.Contains("TagSmiling") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagPiercing")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagPiercing", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagGlaring") Then
				If Not FoundTag.Contains("TagGlaring") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagPiercing")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagPiercing", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagGarment") Then
				If Not FoundTag.Contains("TagGarment") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagGarment")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagGarment", TagGarment)
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagUnderwear") Then
				If Not FoundTag.Contains("TagUnderwear") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagUnderwear")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagUnderwear", TagUnderwear)
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagTattoo") Then
				If Not FoundTag.Contains("TagTattoo") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagTattoo")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagTattoo", TagTattoo)
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagSexToy") Then
				If Not FoundTag.Contains("TagSexToy") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagSexToy")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagSexToy", TagSexToy)
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@TagFurniture") Then
				If Not FoundTag.Contains("TagFurniture") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				Else
					'Debug.Print("FoundTag Contains TagFurniture")
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@TagFurniture", TagFurniture)
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@FirstRound") Then
				If FirstRound = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@FirstRound", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotFirstRound") Then
				If FirstRound = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@FirstRound", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@StrokeSpeedMax") Then
				If StrokePace < NBMaxPace.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@StrokeSpeedMax", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@StrokeSpeedMin") Then
				If StrokePace > NBMinPace.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@StrokeSpeedMin", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@StrokeFaster") Or ListClean(PoundCount).Contains("@StrokeFastest") Then
				If StrokePace = NBMaxPace.Value Or WorshipMode = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@StrokeSpeedMax", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@StrokeSlower") Or ListClean(PoundCount).Contains("@StrokeSlowest") Then
				If StrokePace = NBMinPace.Value Or WorshipMode = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				'ListClean(PoundCount) = ListClean(PoundCount).Replace("@StrokeSpeedMax", "")
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@AllowsOrgasm(") Then
				If FilterCheck(GetParentheses(ListClean(PoundCount), "@AllowsOrgasm("), FrmSettings.alloworgasmComboBox) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@AlwaysAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@AlwaysAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text <> "Always Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@AlwaysAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OftenAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text <> "Often Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@OftenAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SometimesAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text <> "Sometimes Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@SometimesAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@RarelyAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text <> "Rarely Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@RarelyAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NeverAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text <> "Never Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NeverAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@RuinsOrgasm(") Then
				If FilterCheck(GetParentheses(ListClean(PoundCount), "@RuinsOrgasm("), FrmSettings.ruinorgasmComboBox) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@AlwaysAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@AlwaysRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text <> "Always Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@AlwaysRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OftenRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text <> "Often Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@OftenRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SometimesRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text <> "Sometimes Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@SometimesRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@RarelyRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text <> "Rarely Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@RarelyRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NeverRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text <> "Never Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NeverRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotAlwaysAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NotAlwaysAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotNeverAllowsOrgasm") Then
				If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NotNeverAllowsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotAlwaysRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NotAlwaysRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotNeverRuinsOrgasm") Then
				If FrmSettings.ruinorgasmComboBox.Text = "Never Allows" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@NotNeverRuinsOrgasm", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@LongEdge") Then
				If LongEdge = False Or FrmSettings.CBLongEdgeTaunts.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@LongEdge", "")
            End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@InterruptLongEdge") Then
				If LongEdge = False Or FrmSettings.CBLongEdgeInterrupts.Checked = False Or TeaseTick < 1 Or RiskyEdges = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
                'ListClean(PoundCount) = ListClean(PoundCount).Replace("@InterruptLongEdge", "")
            End If
		Loop Until PoundCount = 0



		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowHardcoreImage") Then
				If CheckGenreImage("Hardcore") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowSoftcoreImage") Then
				If CheckGenreImage("Softcore") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLesbianImage") Then
				If CheckGenreImage("Lesbian") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowBlowjobImage") Then
				If CheckGenreImage("Blowjob") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowFemdomImage") Then
				If CheckGenreImage("Femdom") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLezdomImage") Then
				If CheckGenreImage("Lezdom") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowHentaiImage") Then
				If CheckGenreImage("Hentai") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowGayImage") Then
				If CheckGenreImage("Gay") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowMaledomImage") Then
				If CheckGenreImage("Maledom") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowCaptionsImage") Then
				If CheckGenreImage("Captions") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowGeneralImage") Then
				If CheckGenreImage("General") = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0






		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowBlogImage") Or ListClean(PoundCount).Contains("@NewBlogImage") Then
				If FrmSettings.URLFileList.CheckedItems.Count = 0 Or CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or LockImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLocalImage") Then
				If FrmSettings.CBIHardcore.Checked = False And FrmSettings.CBISoftcore.Checked = False And FrmSettings.CBILesbian.Checked = False And FrmSettings.CBIBlowjob.Checked = False And
					 FrmSettings.CBIFemdom.Checked = False And FrmSettings.CBILezdom.Checked = False And FrmSettings.CBIHentai.Checked = False And FrmSettings.CBIGay.Checked = False And
					 FrmSettings.CBIMaledom.Checked = False And FrmSettings.CBICaptions.Checked = False And FrmSettings.CBIGeneral.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLocalImage") Then
				If FlagExists("SYS_NoPornAllowed") = True Or LockImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowButtImage") Or ListClean(PoundCount).Contains("@ShowButtsImage") Then
				If Not Directory.Exists(FrmSettings.LBLButtPath.Text) And Not File.Exists(FrmSettings.LBLButtURL.Text) Or FlagExists("SYS_NoPornAllowed") = True Or LockImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowBoobsImage") Or ListClean(PoundCount).Contains("@ShowBoobImage") Then
				If Not Directory.Exists(FrmSettings.LBLBoobPath.Text) And Not File.Exists(FrmSettings.LBLBoobURL.Text) Or FlagExists("SYS_NoPornAllowed") = True Or LockImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLocalImage") Or ListClean(PoundCount).Contains("@ShowButtImage") Or ListClean(PoundCount).Contains("@ShowBoobsImage") Or ListClean(PoundCount).Contains("@ShowButtsImage") Or ListClean(PoundCount).Contains("@ShowBoobsImage") Then
				If CustomSlideshow = True Or LockImage = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@EdgeHeld(") Then
				Dim EdgeFail As Boolean = False
				Dim EdgeFlag As String = GetParentheses(ListClean(PoundCount), "@EdgeHeld(")
				If EdgeFlag.Contains(",") Then
					EdgeFlag = FixCommas(EdgeFlag)
					Dim EdgeArray As String() = EdgeFlag.Split(",")
					If HoldEdgeTime < Val(EdgeArray(0)) * 60 Or HoldEdgeTime > Val(EdgeArray(1)) * 60 Then EdgeFail = True
				Else
					If Val(EdgeFlag) * 60 > HoldEdgeTime Then EdgeFail = True
				End If
				If EdgeFail = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@1MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 60 Or HoldEdgeTime > 119 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@2MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 120 Or HoldEdgeTime > 179 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@3MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 180 Or HoldEdgeTime > 239 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@4MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 240 Or HoldEdgeTime > 299 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@5MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 300 Or HoldEdgeTime > 599 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@10MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 600 Or HoldEdgeTime > 899 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@15MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 900 Or HoldEdgeTime > 1799 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@30MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 1800 Or HoldEdgeTime > 2699 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@45MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 2700 Or HoldEdgeTime > 3599 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@60MinuteHold") Then
				If SubHoldingEdge = False Or HoldEdgeTime < 3600 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CBTLevel1") Then
				If FrmSettings.CBTSlider.Value <> 1 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CBTLevel2") Then
				If FrmSettings.CBTSlider.Value <> 2 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CBTLevel3") Then
				If FrmSettings.CBTSlider.Value <> 3 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CBTLevel4") Then
				If FrmSettings.CBTSlider.Value <> 4 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CBTLevel5") Then
				If FrmSettings.CBTSlider.Value <> 5 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubCircumcised") Then
				If FrmSettings.CBSubCircumcised.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubNotCircumcised") Then
				If FrmSettings.CBSubCircumcised.Checked = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubPierced") Then
				If FrmSettings.CBSubPierced.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubNotPierced") Then
				If FrmSettings.CBSubPierced.Checked = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		LocalTagImageList.Clear()


		'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
		If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
			' Read all lines of given file.
			LocalTagImageList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")

			'If Not supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then


			For i As Integer = LocalTagImageList.Count - 1 To 0 Step -1
				Dim LocalCheck As String() = Split(LocalTagImageList(i))
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
				If Not File.Exists(LocalString) Then LocalTagImageList.Remove(LocalTagImageList(i))
			Next

			'Do
			'ListCountTotal += 1
			'Debug.Print("LocalTagImageList(i) = &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&" & LocalTagImageList(ListCountTotal))
			'If LocalTagImageList(ListCountTotal) = "" Or LocalTagImageList(ListCountTotal) Is Nothing Then
			'LocalTagImageList.Remove(LocalTagImageList(ListCountTotal))
			'ListCount -= 1
			'End If
			'Loop Until ListCountTotal = ListCount
		End If

		For i As Integer = 0 To LocalTagImageList.Count - 1
			'Debug.Print(i & ": LocalTagImageList(i) = " & LocalTagImageList(i))
		Next

		'ListCountTotal = -1
		Dim TagCount As Integer = 0

		For i As Integer = ListClean.Count - 1 To 0 Step -1
			TagCount = 0
			If ListClean(i).Contains("@ShowTaggedImage") And ListClean(i).Contains("@Tag") Then
				Dim TSplit As String() = Split(ListClean(i))
				For j As Integer = 0 To TSplit.Length - 1
					If TSplit(j).Contains("@Tag") Then
						Dim TString As String = TSplit(j).Replace("@Tag", "")
						For k As Integer = LocalTagImageList.Count - 1 To 0 Step -1
							If LocalTagImageList(k).Contains(TString) Then TagCount += 1
						Next
						If TagCount = 0 Then
							If StrokeFilter = True Then
								For l As Integer = 0 To StrokeTauntCount - 1
									ListClean.RemoveAt(i)
									PoundLine -= 1
								Next
							Else
								ListClean.RemoveAt(i)
								PoundLine -= 1
							End If
							Exit For
						End If
						TagCount = 0
					End If
				Next
			End If
		Next

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowTaggedImage") Then
				If LocalTagImageList.Count = 0 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BeforeTease") Then
				If BeforeTease = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OrgasmDenied") Then
				If LastOrgasmType <> "DENIED" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OrgasmAllowed") Then
				If LastOrgasmType <> "ALLOWED" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OrgasmRuined") Then
				If LastOrgasmType <> "RUINED" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel(") Then
				If FilterCheck(GetParentheses(ListClean(PoundCount), "@ApathyLevel("), FrmSettings.NBEmpathy) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel1") Then
				If FrmSettings.NBEmpathy.Value <> 1 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel2") Then
				If FrmSettings.NBEmpathy.Value <> 2 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel3") Then
				If FrmSettings.NBEmpathy.Value <> 3 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel4") Then
				If FrmSettings.NBEmpathy.Value <> 4 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ApathyLevel5") Then
				If FrmSettings.NBEmpathy.Value <> 5 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@InChastity") Then
				If My.Settings.Chastity = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotInChastity") Then
				If My.Settings.Chastity = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@HasChastity") Then
				If FrmSettings.CBOwnChastity.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@DoesNotHaveChastity") Then
				If FrmSettings.CBOwnChastity.Checked = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ChastityPA") Then
				If FrmSettings.CBChastityPA.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ChastitySpikes") Then
				If FrmSettings.CBChastitySpikes.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VitalSub") Then
				If CBVitalSub.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VitalSubAssignment") Then
				If CBVitalSub.Checked = False Or CBVitalSubDomTask.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@RuinTaunt") Then
				If EdgeToRuin = False Or EdgeToRuinSecret = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowLikedImage") Then
				If Not File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ShowDislikedImage") Then
				If Not File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoHardcore") Then
				If VideoTease = False Or VideoType <> "Hardcore" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoSoftcore") Then
				If VideoTease = False Or VideoType <> "Softcore" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoLesbian") Then
				If VideoTease = False Or VideoType <> "Lesbian" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoBlowjob") Then
				If VideoTease = False Or VideoType <> "Blowjob" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoFemdom") Then
				If VideoTease = False Or VideoType <> "Femdom" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoFemsub") Then
				If VideoTease = False Or VideoType <> "Femsub" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoGeneral") Then
				If VideoTease = False Or VideoType <> "General" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoHardcoreDomme") Then
				If VideoTease = False Or VideoType <> "HardcoreD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoSoftcoreDomme") Then
				If VideoTease = False Or VideoType <> "SoftcoreD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoLesbianDomme") Then
				If VideoTease = False Or VideoType <> "LesbianD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoBlowjobDomme") Then
				If VideoTease = False Or VideoType <> "BlowjobD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoFemdomDomme") Then
				If VideoTease = False Or VideoType <> "FemdomD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoFemsubDomme") Then
				If VideoTease = False Or VideoType <> "FemsubD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@VideoGeneralDomme") Then
				If VideoTease = False Or VideoType <> "GeneralD" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture") Then
				If FrmSettings.CBCBTCock.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture") Then
				If FrmSettings.CBCBTBalls.Checked = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture0") Then
				If CBTBallsCount <> 0 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture1") Then
				If CBTBallsCount <> 1 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture2") Then
				If CBTBallsCount <> 2 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture3") Then
				If CBTBallsCount <> 3 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BallTorture4+") Then
				If CBTBallsCount < 4 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture0") Then
				If CBTCockCount <> 0 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture1") Then
				If CBTCockCount <> 1 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture2") Then
				If CBTCockCount <> 2 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture3") Then
				If CBTCockCount <> 3 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CockTorture4+") Then
				If CBTCockCount < 4 Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		If SubStroking = False Or StrokeTauntCount = 1 Then

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Contact1") Then
					If GlitterTease = False Or Not Group.Contains("1") Then
						If StrokeFilter = True Then
							For i As Integer = 0 To StrokeTauntCount - 1
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							Next
						Else
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Contact2") Then
					If GlitterTease = False Or Not Group.Contains("2") Then
						If StrokeFilter = True Then
							For i As Integer = 0 To StrokeTauntCount - 1
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							Next
						Else
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Contact3") Then
					If GlitterTease = False Or Not Group.Contains("3") Then
						If StrokeFilter = True Then
							For i As Integer = 0 To StrokeTauntCount - 1
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							Next
						Else
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						End If
					End If
				End If
			Loop Until PoundCount = 0

		Else

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If GroupCheck(0).Contains("D") Then
						If GlitterTease = False Or Not Group.Contains("D") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If GroupCheck(0).Contains("1") Then
						If GlitterTease = False Or Not Group.Contains("1") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If GroupCheck(0).Contains("2") Then
						If GlitterTease = False Or Not Group.Contains("2") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If GroupCheck(0).Contains("3") Then
						If GlitterTease = False Or Not Group.Contains("3") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0




			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If Group.Contains("D") Then
						If GlitterTease = False Or Not GroupCheck(0).Contains("D") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If Group.Contains("1") Then
						If GlitterTease = False Or Not GroupCheck(0).Contains("1") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If Group.Contains("2") Then
						If GlitterTease = False Or Not GroupCheck(0).Contains("2") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0

			PoundCount = PoundLine
			Do
				Application.DoEvents()
				PoundCount -= 1
				If ListClean(PoundCount).Contains("@Group(") Then
					Dim GroupCheck As String() = ListClean(PoundCount).Split(")")
					If Group.Contains("3") Then
						If GlitterTease = False Or Not GroupCheck(0).Contains("3") Then
							If StrokeFilter = True Then
								For i As Integer = 0 To StrokeTauntCount - 1
									ListClean.Remove(ListClean(PoundCount))
									PoundLine -= 1
								Next
							Else
								ListClean.Remove(ListClean(PoundCount))
								PoundLine -= 1
							End If
						End If
					End If
				End If
			Loop Until PoundCount = 0



		End If



		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Flag(") Then
				Dim WriteFlag As String = ListClean(PoundCount)
				Dim WriteStart As Integer
				WriteStart = WriteFlag.IndexOf("@Flag(") + 6
				WriteFlag = WriteFlag.Substring(WriteStart, WriteFlag.Length - WriteStart)
				WriteFlag = WriteFlag.Split(")")(0)
				WriteFlag = WriteFlag.Replace("@Flag(", "")
				If Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) And
					 Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotFlag(") Then
				Dim WriteFlag As String = ListClean(PoundCount)
				Dim WriteStart As Integer
				WriteStart = WriteFlag.IndexOf("@NotFlag(") + 9
				WriteFlag = WriteFlag.Substring(WriteStart, WriteFlag.Length - WriteStart)
				WriteFlag = WriteFlag.Split(")")(0)
				WriteFlag = WriteFlag.Replace("@NotFlag(", "")
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) Or
					 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Variable[") Then
				If CheckVariable(ListClean(PoundCount)) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		' The @CheckDate() Command Filter allows you to remove lines if the current date doesn't fall within a specified amount of time of a previously set date. 
		'The correct format is @CheckDate(DateVariableName, Amount of Time)
		' For example, @CheckDate(SYS_FirstRun, 2 Weeks) would only be added to the pool of possible lines if the current date is two weeks or more away from the date saved in SYS_FirstRun.
		' To specify time interval, you can use Seconds, Minutes, Hours, Days, Weeks, Months or Years. Capitalization and pluralization do not matter.

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@CheckDate(") Then
				If CheckDateList(ListClean(PoundCount)) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
				ListClean(PoundCount) = ListClean(PoundCount).Replace("@CheckDate(" & GetParentheses(ListClean(PoundCount), "@CheckDate(") & ")", "")
			End If
		Loop Until PoundCount = 0





		PoundCount = PoundLine
		Do
			' Application.DoEvents()
			PoundCount -= 1
			'Debug.Print("Check ListClean(PoundCount) = " & ListClean(PoundCount))
			If ListClean(PoundCount).Contains("@DommeTag(") Then
				If GetDommeImage(GetParentheses(ListClean(PoundCount), "@DommeTag(")) <> "" Or LockImage = True Then
					'Debug.Print("DommImageFalse")
					'Debug.Print("StrokeFilter = " & StrokeFilter)
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							'Debug.Print("StrokeTauntCount - 1 = " & StrokeTauntCount - 1)
							'Debug.Print("ListClean(PoundCount) = " & ListClean(PoundCount))
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						'Debug.Print("DommImageTrue")
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
					'Debug.Print("DommImageFalseFinished")
				End If
			End If
		Loop Until PoundCount = 0


		Debug.Print("Filter Test Bookmark Reached")


		LocalImageListCheck = True

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ImageTag(") Then
				If GetLocalImage(ListClean(PoundCount)) = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		LocalImageListCheck = False
		LocalImageFound = False

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Stroking") Or ListClean(PoundCount).Contains("@SubStroking") Then
				If SubStroking = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotStroking") Or ListClean(PoundCount).Contains("@SubNotStroking") Then
				If SubStroking = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Edging") Or ListClean(PoundCount).Contains("@SubEdging") Then
				If SubEdging = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotEdging") Or ListClean(PoundCount).Contains("@SubNotEdging") Then
				If SubEdging = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@HoldingTheEdge") Or ListClean(PoundCount).Contains("@SubHoldingTheEdge") Then
				If SubHoldingEdge = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NotHoldingTheEdge") Or ListClean(PoundCount).Contains("@SubNotHoldingTheEdge") Then
				If SubHoldingEdge = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Morning") Then
				If GeneralTime <> "Morning" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Afternoon") Then
				If GeneralTime <> "Afternoon" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Night") Then
				If GeneralTime <> "Night" Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@GoodMood") Then
				If DommeMood <= FrmSettings.NBDomMoodMax.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BadMood") Then
				If DommeMood >= FrmSettings.NBDomMoodMin.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@NeutralMood") Then
				If DommeMood > FrmSettings.NBDomMoodMax.Value Or DommeMood < FrmSettings.NBDomMoodMin.Value Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SetModule(") Then
				If SetModule <> "" Or BookmarkModule = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OrgasmRestricted") Then
				If OrgasmRestricted = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@OrgasmNotRestricted") Then
				If OrgasmRestricted = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0


		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubWorshipping") Then
				If WorshipMode = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@SubNotWorshipping") Then
				If WorshipMode = True Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@LongHold") Then
				If LongHold = False Or SubHoldingEdge = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@ExtremeHold") Then
				If ExtremeHold = False Or SubHoldingEdge = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@AssWorship") Then
				If WorshipTarget <> "Ass" Or WorshipMode = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@BoobWorship") Then
				If WorshipTarget <> "Boobs" Or WorshipMode = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@PussyWorship") Then
				If WorshipTarget <> "Pussy" Or WorshipMode = False Then
					If StrokeFilter = True Then
						For i As Integer = 0 To StrokeTauntCount - 1
							ListClean.Remove(ListClean(PoundCount))
							PoundLine -= 1
						Next
					Else
						ListClean.Remove(ListClean(PoundCount))
						PoundLine -= 1
					End If
				End If
			End If
		Loop Until PoundCount = 0

		'If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then

		'Debug.Print("LocalTagImageList.Count = " & LocalTagImageList.Count)

		PoundCount = PoundLine
		Do
			Application.DoEvents()
			PoundCount -= 1
			If ListClean(PoundCount).Contains("@Info") Then
				ListClean.Remove(ListClean(PoundCount))
				PoundLine -= 1
			End If
		Loop Until PoundCount = 0

		ListClean.Remove(ListClean(ListClean.Count - 1))

		For i As Integer = 0 To ListClean.Count - 1
			Debug.Print(ListClean(i))
		Next

		'For i As Integer = 0 To ListClean.Count - 1
		'Debug.Print("AFTER " & i & ". " & ListClean(i))
		'Next

		'Dim ListReturn As String = ListClean(randomizer.Next(0, ListClean.Count - 1))

		For x As Integer = 0 To ListClean.Count - 1
			ListClean(x) = ListClean(x).Replace("#TagGarment", TagGarment.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagUnderwear", TagUnderwear.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagTattoo", TagTattoo.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagSexToy", TagSexToy.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagFurniture", TagFurniture.Replace("-", " "))
			'ListClean(x) = ListClean(x).Replace("-", " ")
		Next

		Debug.Print("Filter List Complete")

		Return ListClean

	End Function

#Region "---------------------------------------------------- Chatbox ---------------------------------------------------------"

	Private Sub ChatText_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles ChatText.DocumentCompleted
		ScrollChatDown()
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

	Public Sub GetTnAList()

		BoobList.Clear()
		AssList.Clear()


		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim files As String()


		If FrmSettings.CBIButts.Checked = True And FrmSettings.CBURLButts.Checked = True Then
			If randomizer.Next(1, 101) < 51 Then
				GoTo LocalButt
			Else
				GoTo OnlineButt
			End If
		End If

		If FrmSettings.CBIButts.Checked = True Then GoTo LocalButt
		If FrmSettings.CBURLButts.Checked = True Then GoTo OnlineButt

		GoTo GetBoobs

LocalButt:


		If Directory.Exists(FrmSettings.LBLButtPath.Text) Then

			If FrmSettings.CBButtSubDir.Checked = True Then
				files = myDirectory.GetFiles(FrmSettings.LBLButtPath.Text, "*.*", SearchOption.AllDirectories)
			Else
				files = myDirectory.GetFiles(FrmSettings.LBLButtPath.Text, "*.*")
			End If

			Array.Sort(files)

			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					AssList.Add(fi)
				End If
			Next

		End If

		GoTo GetBoobs

OnlineButt:

		AssList = Txt2List(FrmSettings.LBLButtURL.Text)


GetBoobs:

		If FrmSettings.CBIBoobs.Checked = True And FrmSettings.CBURLBoobs.Checked = True Then
			If randomizer.Next(1, 101) < 51 Then
				GoTo LocalBoobs
			Else
				GoTo OnlineBoobs
			End If
		End If

		If FrmSettings.CBIBoobs.Checked = True Then GoTo LocalBoobs
		If FrmSettings.CBURLBoobs.Checked = True Then GoTo OnlineBoobs

		GoTo FinishTNA

LocalBoobs:


		If Directory.Exists(FrmSettings.LBLBoobPath.Text) Then

			If FrmSettings.CBBoobSubDir.Checked = True Then
				files = myDirectory.GetFiles(FrmSettings.LBLBoobPath.Text, "*.*", SearchOption.AllDirectories)
			Else
				files = myDirectory.GetFiles(FrmSettings.LBLBoobPath.Text, "*.*")
			End If

			Array.Sort(files)

			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					BoobList.Add(fi)
				End If
			Next

		End If

		GoTo FinishTNA

OnlineBoobs:

		BoobList = Txt2List(FrmSettings.LBLBoobURL.Text)

FinishTNA:




	End Sub

	Private Sub AvoidTheEdge_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles AvoidTheEdge.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And AvoidTheEdgeTick < 6 Then Return
		If FollowUp <> "" And AvoidTheEdgeTick < 6 Then Return

		AvoidTheEdgeTick -= 1

		If AvoidTheEdgeTick < 1 Then



			Dim AvoidTheEdgeVideo As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdge.txt"
			If DommeVideo = True Then AvoidTheEdgeVideo = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdgeD.txt"

			Dim AvoidTheEdgeLineStart As Integer
			Dim AvoidTheEdgeLineEnd As Integer


			If File.Exists(AvoidTheEdgeVideo) Then
			Else
				If DommeVideo = True Then
					MsgBox("AvoidTheEdgeD.txt is missing!", , "Error!")
				Else
					MsgBox("AvoidTheEdge.txt is missing!", , "Error!")
				End If
				Return
			End If



			If AvoidTheEdgeStroking = False Then


				'CensorshipTick = randomizer.Next(NBCensorHideMin.Value, NBCensorHideMax.Value + 1)

				AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

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
						If VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[StrokingEnd]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
					End While

				End Using

			Else






				AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

				Using ioFileB As New StreamReader(AvoidTheEdgeVideo)
					Dim linesB As New List(Of String)
					Dim TempAvoidTheEdgeLine As Integer

					TempAvoidTheEdgeLine = -1
					While ioFileB.Peek <> -1
						TempAvoidTheEdgeLine += 1
						linesB.Add(ioFileB.ReadLine())
						If VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
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

			AvoidTheEdgeLine = randomizer.Next(AvoidTheEdgeLineStart + 1, AvoidTheEdgeLineEnd)

			DomTask = lines(AvoidTheEdgeLine)

			TypingDelayGeneric()




		End If

	End Sub

	Private Sub AvoidTheEdgeResume_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles AvoidTheEdgeResume.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And AtECountdown < 6 Then Return
		If chatBox.Text <> "" And AtECountdown < 6 Then Return
		If ChatBox2.Text <> "" And AtECountdown < 6 Then Return

		AtECountdown -= 1
		'Debug.Print("AtECountdown = " & AtECountdown)

		If AtECountdown < 1 Then
			AvoidTheEdgeResume.Stop()

			FileGoto = "NoAvoidTheEdgeInstructions"
			SkipGotoLine = True
			GetGoto()
			'domVLC.playlist.play()
			DomWMP.Ctlcontrols.play()
			HandleScripts()
			ScriptTimer.Start()


		End If


	End Sub








	Private Sub SaveBlogImage_Click_2(sender As System.Object, e As System.EventArgs) Handles SaveBlogImage.Click


		If mainPictureBox.Visible = True Then
			DomWMP.Visible = True
			mainPictureBox.Visible = False
		Else
			mainPictureBox.Visible = True
			DomWMP.Visible = False
		End If

	End Sub


	Public Sub GetBlogImage()

		If FrmSettings.URLFileList.CheckedItems.Count = 0 Then
			GetLocalImage()
			Return
		End If

AlreadySeen:



		Dim URLList As New List(Of String)
		URLList.Clear()


		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			URLList.Add(foundFile.Replace(".txt", ""))
		Next


		For i As Integer = FrmSettings.URLFileList.Items.Count - 1 To 0 Step -1
			For j As Integer = URLList.Count - 1 To 0 Step -1
				If FrmSettings.URLFileList.GetItemChecked(i) = False And FrmSettings.URLFileList.Items(i) = URLList(j).Replace(Application.StartupPath & "\Images\System\URL Files\", "") Then
					URLList.Remove(URLList(j))
					Exit For
				End If
			Next
		Next





		Debug.Print("URLList.COunt = " & URLList.Count)
		For i As Integer = 0 To URLList.Count - 1
			Debug.Print(i & " " & URLList(i))
		Next

		'Debug.Print("URLList Count = " & URLList.Count)

		ImageUrlFilePath = URLList(randomizer.Next(0, URLList.Count)) & ".txt"

		Debug.Print(ImageUrlFilePath)

		' Read all lines of given file.
		Dim linesGB As List(Of String) = Txt2List(ImageUrlFilePath)

		Do
			ImageUrlFileIndex = randomizer.Next(0, linesGB.Count)
			FoundString = linesGB(ImageUrlFileIndex)
		Loop Until FoundString <> ""

		Debug.Print("FoundString = " & FoundString)

		'  If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
		'Dim ImageRepeat() As String = Filter(System.IO.File.ReadAllLines(Application.StartupPath & "\Images\System\DislikedImageURLs.txt"), FoundString)
		'If Not UBound(ImageRepeat) = -1 Then GoTo AlreadySeen
		'End If
		'If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
		'Dim ImageRepeat2() As String = Filter(System.IO.File.ReadAllLines(Application.StartupPath & "\Images\System\LikedImageURLs.txt"), FoundString)
		'If Not UBound(ImageRepeat2) = -1 Then GoTo AlreadySeen
		'End If


		ClearMainPictureBox()




		Try

			JustShowedBlogImage = True


			If FoundString.Contains("/") Then
				Try
					ShowImage(FoundString, True)
					'ImageLocation = FoundString
					'DisplayImage(FoundString)
					'ImageThread.Start()
					'mainPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(FoundString)))
				Catch
					ClearMainPictureBox()
					MessageBox.Show(Me, "Failed to load image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End Try
			Else
				ShowImage(FoundString, True)
				'ImageLocation = FoundString
				'PBImage = FoundString
				'ImageThread.Start()
				'mainPictureBox.Image = Image.FromFile(FoundString)
				DeleteLocalImageFilePath = FoundString
			End If

			CurrentImage = FoundString

			mainPictureBox.Refresh()


			If FrmSettings.CBBlogImageWindow.Checked = True Then
				WebImage = FoundString
				Do Until Not WebImage.Contains("/")
					WebImage = WebImage.Remove(0, 1)
				Loop
				If Not File.Exists(Application.StartupPath & "\Images\Session Images\" & WebImage) Then
					Try
						My.Computer.Network.DownloadFile(FoundString, Application.StartupPath & "\Images\Session Images\" & WebImage)
						FrmSettings.CalculateSessionImages()
					Catch
					End Try
				Else
					Debug.Print("Session Image already exists")
				End If

			End If

			Try
				GC.Collect()
			Catch ex As Exception

			End Try

			Debug.Print("Blog Image PictureStrip")
			PictureStrip.Items(0).Enabled = True
			PictureStrip.Items(1).Enabled = True
			PictureStrip.Items(2).Enabled = True
			PictureStrip.Items(3).Enabled = True
			PictureStrip.Items(4).Enabled = True
			PictureStrip.Items(5).Enabled = True

		Catch
			GetLocalImage()
			Return
		End Try




	End Sub


	Public Sub GetLocalImage()


		Dim CheckString As String
		Dim CheckBoolean As Boolean
		Dim LocalList As New List(Of String)
		LocalList.Clear()

		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim files As String()

		For i As Integer = 1 To 11
			CheckString = "NULL"
			CheckBoolean = False
			If i = 1 And FrmSettings.CBIHardcore.Checked = True And Directory.Exists(FrmSettings.LBLIHardcore.Text) Then CheckString = FrmSettings.LBLIHardcore.Text
			If i = 2 And FrmSettings.CBISoftcore.Checked = True And Directory.Exists(FrmSettings.LBLISoftcore.Text) Then CheckString = FrmSettings.LBLISoftcore.Text
			If i = 3 And FrmSettings.CBILesbian.Checked = True And Directory.Exists(FrmSettings.LBLILesbian.Text) Then CheckString = FrmSettings.LBLILesbian.Text
			If i = 4 And FrmSettings.CBIBlowjob.Checked = True And Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then CheckString = FrmSettings.LBLIBlowjob.Text
			If i = 5 And FrmSettings.CBIFemdom.Checked = True And Directory.Exists(FrmSettings.LBLIFemdom.Text) Then CheckString = FrmSettings.LBLIFemdom.Text
			If i = 6 And FrmSettings.CBILezdom.Checked = True And Directory.Exists(FrmSettings.LBLILezdom.Text) Then CheckString = FrmSettings.LBLILezdom.Text
			If i = 7 And FrmSettings.CBIHentai.Checked = True And Directory.Exists(FrmSettings.LBLIHentai.Text) Then CheckString = FrmSettings.LBLIHentai.Text
			If i = 8 And FrmSettings.CBIGay.Checked = True And Directory.Exists(FrmSettings.LBLIGay.Text) Then CheckString = FrmSettings.LBLIGay.Text
			If i = 9 And FrmSettings.CBIMaledom.Checked = True And Directory.Exists(FrmSettings.LBLIMaledom.Text) Then CheckString = FrmSettings.LBLIMaledom.Text
			If i = 10 And FrmSettings.CBICaptions.Checked = True And Directory.Exists(FrmSettings.LBLICaptions.Text) Then CheckString = FrmSettings.LBLICaptions.Text
			If i = 11 And FrmSettings.CBIGeneral.Checked = True And Directory.Exists(FrmSettings.LBLIGeneral.Text) Then CheckString = FrmSettings.LBLIGeneral.Text

			If i = 1 And FrmSettings.CBIHardcoreSD.Checked = True Then CheckBoolean = True
			If i = 2 And FrmSettings.CBISoftcoreSD.Checked = True Then CheckBoolean = True
			If i = 3 And FrmSettings.CBILesbianSD.Checked = True Then CheckBoolean = True
			If i = 4 And FrmSettings.CBIBlowjobSD.Checked = True Then CheckBoolean = True
			If i = 5 And FrmSettings.CBIFemdomSD.Checked = True Then CheckBoolean = True
			If i = 6 And FrmSettings.CBILezdomSD.Checked = True Then CheckBoolean = True
			If i = 7 And FrmSettings.CBIHentaiSD.Checked = True Then CheckBoolean = True
			If i = 8 And FrmSettings.CBIGaySD.Checked = True Then CheckBoolean = True
			If i = 9 And FrmSettings.CBIMaledomSD.Checked = True Then CheckBoolean = True
			If i = 10 And FrmSettings.CBICaptionsSD.Checked = True Then CheckBoolean = True
			If i = 11 And FrmSettings.CBIGeneralSD.Checked = True Then CheckBoolean = True


			If Not CheckString = "NULL" Then
				If CheckBoolean = True Then
					files = myDirectory.GetFiles(CheckString, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(CheckString, "*.*")
				End If

				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalList.Add(fi)
					End If
				Next

			End If

		Next

		If LocalList.Count = 0 Then
			FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
		Else
			Do
				FoundString = LocalList(randomizer.Next(0, LocalList.Count))
			Loop Until FoundString <> ""
		End If


		JustShowedBlogImage = True

		Debug.Print("Local Image PictureStrip")
		PictureStrip.Items(0).Enabled = True
		PictureStrip.Items(1).Enabled = False
		PictureStrip.Items(2).Enabled = False
		PictureStrip.Items(3).Enabled = True
		PictureStrip.Items(4).Enabled = True
		PictureStrip.Items(5).Enabled = False



		ClearMainPictureBox()

		' ### 0000000000000000000

		ShowImage(FoundString)
		'ImageLocation = FoundString
		'PBImage = FoundString
		'ImageThread.Start()
		'DisplayImage(Image.FromFile(FoundString))
		'mainPictureBox.Image = Image.FromFile(FoundString)
		DeleteLocalImageFilePath = FoundString
		CurrentImage = FoundString

		'If UCase(FoundString).Contains(".GIF") Then

		'Debug.Print("GIF Found")

		'If FoundString.Contains("\") Then
		'TempGif = Image.FromFile(FoundString)
		'End If

		'If FoundString.Contains("/") Then
		'mainPictureBox.Image.Dispose()
		'mainPictureBox.Image = Nothing

		'If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif") Then
		'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif")
		'End If
		'My.Computer.Network.DownloadFile(FoundString, Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif")
		'TempGif = Image.FromFile(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif")
		'End If

		'mainPictureBox.Image = TempGif
		'Else
		'Debug.Print("Gif Not found")
		'mainPictureBox.Load(FoundString)
		'TempGif.Dispose()
		'If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif") Then
		'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Temp\Temp.gif")
		'End If
		'End If


		Try
			GC.Collect()
		Catch
		End Try
		'mainPictureBox.Load(FoundString)




	End Sub


	Public Sub RunModuleScript(IsEdging As Boolean)

		ShowModule = True

		TauntEdging = False
		TauntEdgingAsked = False

		AskedToGiveUpSection = False
		Dim ModuleList As New List(Of String)
		ModuleList.Clear()

		Dim ChastityModuleCheck As String = "*.txt"
		If My.Settings.Chastity = True And Not IsEdging Then
			AskedToSpeedUp = False
			AskedToSlowDown = False
			SubStroking = False
			SubEdging = False
			SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ChastityModuleCheck = "*_CHASTITY.txt"
		End If

		If PlaylistFile.Count = 0 Then GoTo NoPlaylistModuleFile

		If Playlist = False Or PlaylistFile(PlaylistCurrent).Contains("Random Module") Then


NoPlaylistModuleFile:

			If SetModule <> "" Then

				FileText = SetModule
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
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_CHASTITY.txt"
					ElseIf IsEdging Then
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_EDGING.txt"
					Else
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module.txt"
					End If
				Else
					FileText = ModuleList(randomizer.Next(0, ModuleList.Count))
				End If
			End If

		Else
			If PlaylistFile(PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & PlaylistFile(PlaylistCurrent)
				FileText = FileText.Replace(" Regular-TeaseAI-Script", "")
				FileText = FileText & ".txt"
			Else
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Modules\" & PlaylistFile(PlaylistCurrent) & ".txt"
			End If

		End If

		SetModule = ""

		DomTask = DomTask.Replace("@Module", "")


		If SetModuleGoto <> "" Then
			FileGoto = SetModuleGoto
			SkipGotoLine = True
			GetGoto()
			SetModuleGoto = ""
		Else
			StrokeTauntVal = -1
		End If

		If Playlist = True Then PlaylistCurrent = 1

		If Not IsEdging Then

			If Playlist = True Then BookmarkModule = False

			If BookmarkModule = True Then
				BookmarkModule = False
				FileText = BookmarkModuleFile
				StrokeTauntVal = BookmarkModuleLine
			End If

			ScriptTick = 3

		Else
			ScriptTick = 4
		End If

		ScriptTimer.Start()
	End Sub



	Public Sub RunLinkScript()

		Debug.Print("RunLinkScript() Called")

		ClearModes()

		If PlaylistFile.Count = 0 Then GoTo NoPlaylistLinkFile

		If Playlist = False Or PlaylistFile(PlaylistCurrent).Contains("Random Link") Then



NoPlaylistLinkFile:


			Debug.Print("SetLink = " & SetLink)


			If SetLink <> "" Then
				Debug.Print("SetLink Called")
				FileText = SetLink
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
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link_CHASTITY.txt"
					Else
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link.txt"
					End If
				Else
					FileText = LinkList(randomizer.Next(0, LinkList.Count))
				End If

			End If

		Else
			Debug.Print("Playlist Link Called")
			If PlaylistFile(PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Link\" & PlaylistFile(PlaylistCurrent)
				FileText = FileText.Replace(" Regular-TeaseAI-Script", "")
				FileText = FileText & ".txt"
			Else
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Link\" & PlaylistFile(PlaylistCurrent) & ".txt"
			End If

		End If

		SetLink = ""
		Debug.Print("SetLink = " & SetLink)


		If WorshipMode = False Then
			LockImage = False
			If SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True
			End If
		End If


		If SetLinkGoto <> "" Then
			FileGoto = SetLinkGoto
			SkipGotoLine = True
			GetGoto()
			SetLinkGoto = ""
		Else
			StrokeTauntVal = -1
		End If


		If Playlist = True Then PlaylistCurrent += 1
		If Playlist = True Then BookmarkLink = False

		If BookmarkLink = True Then
			BookmarkLink = False
			FileText = BookmarkLinkFile
			StrokeTauntVal = BookmarkLinkLine
		End If

		Debug.Print("Link FileText Called")


		ScriptTick = 3
		ScriptTimer.Start()


	End Sub

	Public Function GetSysVar(ByVal GetVar As String) As String

		Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & GetVar
		Dim VarValue As String
		'TODO: Remove unsecure IO.Access to file, for there is no DirectoryCheck.
		If File.Exists(VarCheck) Then
			VarValue = TxtReadLine(VarCheck)
		Else
			VarValue = "0"
		End If

		Return VarValue

	End Function

	Public Sub RunLastScript()

		ClearModes()

		'My.Settings.Sys_SubLeftEarly = 0

		'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Variables\SYS_SubLeftEarly", "0", False)

		SetVariable("SYS_SubLeftEarly", 0)

		SetVariable("SYS_EndTotal", Val(GetVariable("SYS_EndTotal")) + 1)


		'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Variables\SYS_EndTotal", Val(GetVariable("SYS_EndTotal")) + 1, False)


		My.Settings.Save()

		'Debug.Print("RunLastScript() Called")

		If PlaylistFile.Count = 0 Then GoTo NoPlaylistEndFile

		If Playlist = False Or PlaylistFile(PlaylistCurrent).Contains("Random End") Then

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

						If OrgasmRestricted = True Then
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
					FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_CHASTITY.txt"
				Else
					If OrgasmRestricted = True Then
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
					Else
						FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End.txt"
					End If
				End If
			Else
				FileText = EndList(randomizer.Next(0, EndList.Count))
			End If

		Else
			If PlaylistFile(PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\End\" & PlaylistFile(PlaylistCurrent)
				FileText = FileText.Replace(" Regular-TeaseAI-Script", "")
				FileText = FileText & ".txt"
			Else
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\End\" & PlaylistFile(PlaylistCurrent) & ".txt"
			End If
		End If

		If WorshipMode = False Then
			If SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True
			End If
			LockImage = False
		End If


		StrokeTauntVal = -1

		LastScript = True


		ScriptTick = 3
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

				If OrgasmRestricted = False Then

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

			If OrgasmRestricted = False Then
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_BEG.txt"
			Else
				FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
			End If
		Else
			FileText = EndList(randomizer.Next(0, EndList.Count))
		End If

		LockImage = False
		If SlideshowLoaded = True Then
			nextButton.Enabled = True
			previousButton.Enabled = True
			DommeSlideshowToolStripMenuItem.Enabled = True
		End If

		StrokeTauntVal = -1
		ScriptTick = 4
		ScriptTimer.Start()
		LastScript = True

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
		StrokePaceTimer.Stop()
		AvoidTheEdgeTaunts.Stop()
		RLGLTauntTimer.Stop()
		VideoTauntTimer.Stop()
		EdgeCountTimer.Stop()

		SubStroking = False
		SubEdging = False
		SubHoldingEdge = False
		AskedToSpeedUp = False
		AskedToSlowDown = False

		WorshipMode = False
		WorshipTarget = ""
		LongHold = False
		ExtremeHold = False

		MiniScript = False

		ClearModes()


		If FrmSettings.TBWebStop.Text <> "" Then
			Try
				FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
			Catch
			End Try
		End If

		StrokePace = 0

	End Sub


	Private Sub EdgeTauntTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles EdgeTauntTimer.Tick

		If MultipleEdgesTimer.Enabled = True Then Return
		If MiniScript = True Then Return
		If InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And EdgeTauntInt < 6 Then Return

		FrmSettings.LBLDebugEdgeTauntTime.Text = EdgeTauntInt

		'Debug.Print("EdgeTauntIn = " & EdgeTauntInt)

		EdgeTauntInt -= 1

		If EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\Edge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\GroupEdge.txt"
			End If

			'Read all lines of the given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				DomTask = ETLines(randomizer.Next(0, ETLines.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Edge Taunt"
			End Try

			TypingDelayGeneric()

			EdgeTauntInt = randomizer.Next(30, 46)

		End If

	End Sub



	Private Sub HoldEdgeTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles HoldEdgeTimer.Tick

		If MiniScript = True Then Return

		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		HoldEdgeTime += 1
		HoldEdgeTimeTotal += 1

		My.Settings.HoldEdgeTimeTotal = HoldEdgeTimeTotal
		My.Settings.Save()

		If InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return


		'If DomTyping = True Then Return
		If DomTypeCheck = True And HoldEdgeTick < 4 Then Return
		If chatBox.Text <> "" And HoldEdgeTick < 4 Then Return
		If ChatBox2.Text <> "" And HoldEdgeTick < 4 Then Return
		If FollowUp <> "" And HoldEdgeTick < 4 Then Return

		HoldEdgeTick -= 1

		FrmSettings.LBLDebugHoldEdgeTime.Text = HoldEdgeTick
		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		If HoldEdgeTick < 1 Then

			'stop
			LongHold = False
			ExtremeHold = False
			WorshipMode = False
			WorshipTarget = ""

			'If OrgasmAllowed = True Then GoTo AllowedOrgasm
			'If EdgeToRuin = True Or OrgasmRuined = True Then GoTo RuinedOrgasm

			If EdgeToRuin = True Or OrgasmRuined = True Then
				LastOrgasmType = "RUINED"
				OrgasmRuined = False
				GoTo RuinedOrgasm
			End If

			If OrgasmAllowed = True Then
				LastOrgasmType = "ALLOWED"
				OrgasmAllowed = False
				GoTo AllowedOrgasm
			End If

			If OrgasmDenied = True Then

				LastOrgasmType = "DENIED"

				If FrmSettings.CBDomDenialEnds.Checked = False Then

					Dim RepeatChance As Integer = randomizer.Next(0, 101)

					If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Then
						SubEdging = False
						SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatFiles

						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
						Else
							TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If

						TeaseTimer.Start()

						'ShowModule = True
						StrokeTauntVal = -1
						FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
						ScriptTick = 2
						ScriptTimer.Start()
						OrgasmDenied = False
						OrgasmYesNo = False
						Return
					End If

				End If


			End If

NoRepeatFiles:

			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			SubHoldingEdge = False
			SubStroking = False
			OrgasmYesNo = False
			DomTask = "#StopStroking"
			If Contact1Edge = True Then
				DomTask = "@Contact1 #StopStroking"
				Contact1Edge = False
			End If
			If Contact2Edge = True Then
				DomTask = "@Contact2 #StopStroking"
				Contact2Edge = False
			End If
			If Contact3Edge = True Then
				DomTask = "@Contact3 #StopStroking"
				Contact3Edge = False
			End If
			TypingDelayGeneric()
			Return

RuinedOrgasm:

			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
			My.Settings.Save()
			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

			If FrmSettings.CBDomOrgasmEnds.Checked = False And OrgasmRuined = True Then

				Dim RepeatChance As Integer = randomizer.Next(0, 101)

				If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Then

					EdgeTauntTimer.Stop()
					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					SubHoldingEdge = False
					SubStroking = False
					EdgeToRuin = False
					EdgeToRuinSecret = True

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
					Else
						TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					StrokeTauntVal = -1
					FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
					ScriptTick = 2
					ScriptTimer.Start()
					OrgasmRuined = False
					OrgasmYesNo = False
					Return
				End If

			End If



NoRepeatRFiles:



			DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			SubHoldingEdge = False
			SubStroking = False
			EdgeToRuin = False
			EdgeToRuinSecret = True
			OrgasmYesNo = False
			DomChat = "#RuinYourOrgasm"
			If Contact1Edge = True Then
				DomChat = "@Contact1 #RuinYourOrgasm"
				Contact1Edge = False
			End If
			If Contact2Edge = True Then
				DomChat = "@Contact2 #RuinYourOrgasm"
				Contact2Edge = False
			End If
			If Contact3Edge = True Then
				DomChat = "@Contact3 #RuinYourOrgasm"
				Contact3Edge = False
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
					SubHoldingEdge = False
					SubStroking = False
					OrgasmYesNo = False
					'ShowModule = True
					StrokeTauntVal = -1
					FileText = NoCumList(randomizer.Next(0, NoCumList.Count))
					ScriptTick = 2
					ScriptTimer.Start()
					Return
				End If


				My.Settings.OrgasmsRemaining -= 1

				My.Settings.Save()

			End If

NoNoCumFiles:


			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
			My.Settings.Save()
			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

			If FrmSettings.CBDomOrgasmEnds.Checked = False Then

				Dim RepeatChance As Integer = randomizer.Next(0, 101)

				If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Then

					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					SubHoldingEdge = False
					SubStroking = False
					EdgeToRuin = False
					EdgeToRuinSecret = True
					EdgeTauntTimer.Stop()

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then TeaseTick = randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then TeaseTick = randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then TeaseTick = randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then TeaseTick = randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then TeaseTick = randomizer.Next(45, 61) * 60
					Else
						TeaseTick = randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					StrokeTauntVal = -1
					FileText = RepeatList(randomizer.Next(0, RepeatList.Count))
					ScriptTick = 2
					ScriptTimer.Start()
					OrgasmAllowed = False
					OrgasmYesNo = False
					Return
				End If

			End If



NoRepeatOFiles:


			DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			SubHoldingEdge = False
			SubStroking = False
			OrgasmYesNo = False
			'OrgasmAllowed = False
			DomChat = "#CumForMe"
			If Contact1Edge = True Then
				DomChat = "@Contact1 #CumForMe"
				Contact1Edge = False
			End If
			If Contact2Edge = True Then
				DomChat = "@Contact2 #CumForMe"
				Contact2Edge = False
			End If
			If Contact3Edge = True Then
				DomChat = "@Contact3 #CumForMe"
				Contact3Edge = False
			End If
			TypingDelay()
			Return

		End If

	End Sub

	Private Sub HoldEdgeTauntTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles HoldEdgeTauntTimer.Tick

		If MiniScript = True Then Return
		If InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And EdgeTauntInt < 6 Then Return

		EdgeTauntInt -= 1

		If EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\HoldTheEdge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\GroupHoldTheEdge.txt"
			End If

			' Read all lines of given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				DomTask = ETLines(randomizer.Next(0, ETLines.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Hold the Edge Taunt"
			End Try

			TypingDelayGeneric()

			EdgeTauntInt = randomizer.Next(15, 31)


		End If

	End Sub









	Public Sub CreateTaskLetter()


		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Greeting.txt"
		TaskText = ""

		'Read all lines of the given file.
		Dim TaskLines As List(Of String) = Txt2List(TaskFile)
		Dim TaskEntry As String

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try

		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Intro.txt"

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

		If GeneralTime = "Afternoon" Then GoTo Afternoon
		If GeneralTime = "Night" Then GoTo Night

		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_1.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()


		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_1-2.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

Afternoon:


		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_2.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()


		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_2-3.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

Night:

		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_3.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Outro.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

		TaskFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Signature.txt"

		TaskLines.Clear()

		'Read all lines of the given file.
		TaskLines = Txt2List(TaskFile)

		Try
			TaskLines = FilterList(TaskLines)
			TaskEntry = TaskLines(randomizer.Next(0, TaskLines.Count))
		Catch
			TaskEntry = "ERROR: Tease AI did not return a valid Task line"
		End Try
		PoundClean(TaskEntry)

		TaskText = TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine
		CleanTaskText()
		TaskLines.Clear()

		If FrmSettings.CBHonorificInclude.Checked = True Then
			TaskText = TaskText & FrmSettings.TBHonorific.Text & " " & domName.Text
		Else
			TaskText = TaskText & domName.Text
		End If


		'TaskText = PoundClean(TaskText)

		Dim AtArray2() As String = Split(TaskText)
		For i As Integer = 0 To AtArray2.Length - 1
			'If AtArray(i) = "" Then GoTo AtBreak
			If AtArray2(i) = "" Then GoTo AtNext
			If AtArray2(i).Contains("#") Then
				AtArray2(i) = PoundClean(AtArray2(i))
			End If
AtNext:

		Next

		TaskText = Join(AtArray2)


		Dim TextLines() As String = TaskText.Split(Environment.NewLine)
		Dim TextTemp As String
		For x As Integer = 0 To TextLines.Count - 1
			Dim AtArray() As String = Split(TextLines(x))
			For i As Integer = 0 To AtArray.Length - 1
				If AtArray(i).Contains("@") Then AtArray(i) = ""
			Next
			TextLines(x) = Join(AtArray)
			If TextLines(x).Substring(0, 1) = " " Then
				Do
					TextLines(x) = TextLines(x).Remove(0, 1)
				Loop Until Not TextLines(x).Substring(0, 1) = " "

			End If
			TextTemp = TextTemp & TextLines(x) & Environment.NewLine
			'TextLines(x) = Join(AtArray)
		Next

		TaskText = TextTemp






		Dim TempDate As String
		Dim TempDateNow As DateTime = DateTime.Now

		TempDate = TempDateNow.ToString("M dd")

		TaskTextDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Received Files\Tasks for " & TempDate & ".txt"
		My.Computer.FileSystem.WriteAllText(TaskTextDir, TaskText, False)


		LBLFileTransfer.Text = domName.Text & " is sending you a file!"
		PNLFileTransfer.Visible = True

		StupidTimer.Start()




	End Sub


	Public Sub CleanTaskText()

		Dim i As Integer

		If TaskText.Contains("#TaskEdges") Then
			Do
				i = randomizer.Next(5, 21) * FrmSettings.domlevelNumBox.Value
				i = 5 * Math.Round(i / 5)
				TaskText = TaskText.Replace("#TaskEdges", i)
			Loop Until Not TaskText.Contains("#TaskEdges")
		End If

		If TaskText.Contains("#TaskStrokes") Then
			Do
				i = randomizer.Next(50, 201) * FrmSettings.domlevelNumBox.Value
				i = 10 * Math.Round(i / 10)
				TaskText = TaskText.Replace("#TaskStrokes", i)
			Loop Until Not TaskText.Contains("#TaskStrokes")
		End If

		If TaskText.Contains("#TaskHours") Then
			Do
				i = randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1) + FrmSettings.domlevelNumBox.Value
				TaskText = TaskText.Replace("#TaskHours", i)
			Loop Until Not TaskText.Contains("#TaskHours")
		End If

		If TaskText.Contains("#TaskMinutes") Then
			Do
				i = randomizer.Next(5, 13) * FrmSettings.domlevelNumBox.Value
				TaskText = TaskText.Replace("#TaskMinutes", i)
			Loop Until Not TaskText.Contains("#TaskMinutes")
		End If

		If TaskText.Contains("#TaskSeconds") Then
			Do
				i = randomizer.Next(10, 30) * FrmSettings.domlevelNumBox.Value * randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1)
				TaskText = TaskText.Replace("#TaskSeconds", i)
			Loop Until Not TaskText.Contains("#TaskSeconds")
		End If

		If TaskText.Contains("#TaskAmountLarge") Then
			Do
				i = (randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value) * 2
				i = 5 * Math.Round(i / 5)
				TaskText = TaskText.Replace("#TaskAmountLarge", i)
			Loop Until Not TaskText.Contains("#TaskAmountLarge")
		End If

		If TaskText.Contains("#TaskAmountSmall") Then
			Do
				i = (randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value) / 2
				i = 5 * Math.Round(i / 5)
				TaskText = TaskText.Replace("#TaskAmountSmall", i)
			Loop Until Not TaskText.Contains("#TaskAmountSmall")
		End If

		If TaskText.Contains("#TaskAmount") Then
			Do
				i = randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value
				i = 5 * Math.Round(i / 5)
				TaskText = TaskText.Replace("#TaskAmount", i)
			Loop Until Not TaskText.Contains("#TaskAmount")
		End If






	End Sub


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

		ShellExecute(TaskTextDir)

		PNLFileTransfer.Visible = False
		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False
		LBLFileTransfer.Text = domName.Text & " is sending you a file!"
		PBFileTransfer.Value = 0

	End Sub



	Private Sub SlideshowTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles SlideshowTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If SlideshowLoaded = False Or FrmSettings.timedRadio.Checked = False Or TeaseVideo = True Or LockImage = True Or JustShowedBlogImage = True Or CustomSlideshow = True Then Return

		SlideshowTimerTick -= 1

		If SlideshowTimerTick < 1 Then

TryNext:
			FileCount += 1
			'Debug.Print("Filecount = " & FileCount)
			'Debug.Print("FileCOuntMax = " & FileCountMax)
			FileCount += 1
			If FileCount > FileCountMax Then
				If FrmSettings.CBNewSlideshow.Checked = True Then
					NewDommeSlideshow = True
					OriginalDommeSlideshow = _ImageFileNames(0)
					LoadDommeImageFolder()
					NewDommeSlideshow = False
					DomPic = _ImageFileNames(FileCount)
				Else
					FileCount = 0
				End If
			End If

			If File.Exists(_ImageFileNames(FileCount)) Then
			Else
				ClearMainPictureBox()
				Return
			End If

			If _ImageFileNames(FileCount).Contains(".db") Then GoTo TryNext



			If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)


			Try
				ShowImage(_ImageFileNames(FileCount))
				JustShowedBlogImage = False
				JustShowedSlideshowImage = True

			Catch
				GoTo TryNext
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

			SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
		End If

	End Sub

	Public Sub GetEdgeTickCheck()

		If AlreadyStrokingEdge = True Then

			If AvgEdgeCount < 5 Then
				EdgeTickCheck = 60
			Else
				EdgeTickCheck = AvgEdgeStroking
			End If

		Else

			If AvgEdgeCountRest < 5 Then
				EdgeTickCheck = 300
			Else
				EdgeTickCheck = AvgEdgeNoTouch
			End If

		End If

	End Sub



	Private Sub EdgeCountTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles EdgeCountTimer.Tick
		EdgeCountTick += 1









		If FrmSettings.CBEdgeUseAvg.Checked = True Then
			If EdgeCountTick > EdgeTickCheck Then LongEdge = True
		Else
			If EdgeCountTick > FrmSettings.NBLongEdge.Value * 60 Then LongEdge = True
		End If




		Dim m As Integer = TimeSpan.FromSeconds(EdgeCountTick).Minutes
		Dim s As Integer = TimeSpan.FromSeconds(EdgeCountTick).Seconds


		Dim TST As TimeSpan = TimeSpan.FromSeconds(EdgeCountTick)

		''Debug.Print("{0:c} : {1:c}", TST.Minutes, TST.Seconds)



		'Debug.Print("EdgeCountTick = " & String.Format("{0:00}:{1:00}", TST.Minutes, TST.Seconds))
	End Sub

	Private Sub StrokeTimeTotalTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles StrokeTimeTotalTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If SubStroking = False Then Return

		StrokeTimeTotal += 1
		'Debug.Print("StrokeTimeTotal = " & StrokeTimeTotal)

		My.Settings.StrokeTimeTotal = StrokeTimeTotal
		My.Settings.Save()

		Dim STT As TimeSpan = TimeSpan.FromSeconds(StrokeTimeTotal)

		'LBLStrokeTimeTotal.Text = String.Format("{0:000} D {1:00} H {2:00} M {3:00} S", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)
		FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)


	End Sub






	Private Sub TnAFastSlides_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles TnASlides.Tick

		Dim TnARandom As Integer = randomizer.Next(1, 101)

		'ClearMainPictureBox()
		'QnD-BUGFIX: Booblist was empty at this point. 
		If BoobList.Count = 0 Or AssList.Count = 0 Then GetTnAList()

		If TnARandom < 51 Then
			Dim BoobString As String = BoobList(randomizer.Next(0, BoobList.Count))
			ShowImage(BoobString)
			DeleteLocalImageFilePath = FoundString

			BoobImage = True
			AssImage = False

		Else
			Dim ButtString As String = AssList(randomizer.Next(0, AssList.Count))
			ShowImage(ButtString)
			DeleteLocalImageFilePath = FoundString

			BoobImage = False
			AssImage = True

		End If



		''Debug.Print("TNAFASTSLIDES CALLED")


	End Sub












	Private Sub ImageFolderComboBox_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ImageFolderComboBox.MouseWheel
		Dim mwe As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
		mwe.Handled = True
	End Sub

	Private Sub ImageFolderComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ImageFolderComboBox.SelectedIndexChanged



		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If



		If My.Computer.FileSystem.DirectoryExists(ImageFolderComboBox.Text) Then

			SlideshowLoaded = True

			'domVLC.playlist.pause()
			'domVLC.Visible = False
			DomWMP.Visible = False
			DomWMP.Ctlcontrols.pause()
			mainPictureBox.Visible = True
			'programsettingsPanel.Visible = False


			FrmSettings.timedRadio.Enabled = True
			FrmSettings.teaseRadio.Enabled = True

			FileCount = 0
			FileCountMax = -1
			_ImageFileNames.Clear()

			GetFolder = ImageFolderComboBox.Text

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			'Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)

			Dim files As String()

			If FrmSettings.CBSlideshowSubDir.Checked = True Then
				files = myDirectory.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)
			Else
				files = myDirectory.GetFiles(GetFolder, "*.*")
			End If


			' Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*")
			Array.Sort(files)
			' For Each fi As String In files
			'If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
			'_ImageFileNames.AddRange(files)
			'End If
			'   Next

			Dim TestCOUnt As Integer = 0
			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					TestCOUnt += 1
					'Debug.Print("fi = " & fi)
					_ImageFileNames.Add(fi)
				End If
			Next

			' If FrmSettings.CBSlideshowSubDir.Checked = True Then
			'FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp", SearchOption.AllDirectories).Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg", SearchOption.AllDirectories).Count
			'Else
			'   FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg").Count
			'  FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png").Count
			' FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif").Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp").Count
			'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg").Count
			'End If

			FileCountMax = _ImageFileNames.Count - 1

			'Debug.Print("FileCOuntMax = " & FileCountMax)

			' If FileCountMax = -1 Then
			If FileCountMax < 1 Then
				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Exit Sub
			End If


			' Begin Next Button
			FileCount = 0

			'ClearMainPictureBox()



			If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

			ShowImage(_ImageFileNames(FileCount))
			JustShowedBlogImage = False

			nextButton.Enabled = True
			previousButton.Enabled = True
			DommeSlideshowToolStripMenuItem.Enabled = True

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
				SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
				SlideshowTimer.Start()
			End If

		Else

			ImageFolderComboBox.Text = "Not a valid directory"

		End If






	End Sub



	Private Sub ImageFolderComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ImageFolderComboBox.KeyPress



		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If e.KeyChar = Convert.ToChar(13) Then

			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)

			If My.Computer.FileSystem.DirectoryExists(ImageFolderComboBox.Text) Then

				GetFolder = ImageFolderComboBox.Text

				RecentSlideshows.Add(GetFolder)

				Do Until RecentSlideshows.Count < 11
					RecentSlideshows.Remove(RecentSlideshows(0))
				Loop

				'Debug.Print(RecentSlideshows(0))

				ImageFolderComboBox.Items.Clear()

				For Each comboitem As String In RecentSlideshows
					ImageFolderComboBox.Items.Add(comboitem)
				Next

				ImageFolderComboBox.Text = GetFolder

				My.Settings.RecentSlideshows.Add(GetFolder)

				My.Settings.RecentSlideshows.Clear()

				For i As Integer = 0 To RecentSlideshows.Count - 1
					My.Settings.RecentSlideshows.Add(RecentSlideshows(i))
				Next

				My.Settings.Save()


				SlideshowLoaded = True

				' domVLC.playlist.pause()
				'domVLC.Visible = False
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.pause()
				mainPictureBox.Visible = True
				'programsettingsPanel.Visible = False


				FrmSettings.timedRadio.Enabled = True
				FrmSettings.teaseRadio.Enabled = True

				FileCount = 0
				FileCountMax = -1
				_ImageFileNames.Clear()



				Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
				'Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)

				Dim files As String()

				If FrmSettings.CBSlideshowSubDir.Checked = True Then
					files = myDirectory.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)
				Else
					files = myDirectory.GetFiles(GetFolder, "*.*")
				End If


				' Dim files As String() = DirectoryExt.GetFiles(GetFolder, "*.*")
				Array.Sort(files)

				' For Each fi As String In files
				'If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
				'_ImageFileNames.AddRange(files)
				'End If
				'   Next

				Dim TestCOUnt As Integer = 0
				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						TestCOUnt += 1
						'Debug.Print("fi = " & fi)
						_ImageFileNames.Add(fi)
					End If
				Next

				' If FrmSettings.CBSlideshowSubDir.Checked = True Then
				'FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg", SearchOption.AllDirectories).Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png", SearchOption.AllDirectories).Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif", SearchOption.AllDirectories).Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp", SearchOption.AllDirectories).Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg", SearchOption.AllDirectories).Count
				'Else
				'   FileCountMax = DirectoryExt.GetFiles(GetFolder, "*.jpg").Count
				'  FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.png").Count
				' FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.gif").Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.bmp").Count
				'FileCountMax += DirectoryExt.GetFiles(GetFolder, "*.jpeg").Count
				'End If

				FileCountMax = _ImageFileNames.Count - 1

				'Debug.Print("FileCOuntMax = " & FileCountMax)

				' If FileCountMax = -1 Then
				If FileCountMax < 1 Then
					MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If


				' Begin Next Button
				FileCount = 0

				'ClearMainPictureBox()



				If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

				ShowImage(_ImageFileNames(FileCount))
				JustShowedBlogImage = False


				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True

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
					SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
					SlideshowTimer.Start()
				End If

			Else

				ImageFolderComboBox.Text = "Not a valid directory"

			End If



		End If


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

			EdgeVideo = False
			YesVideo = False
			NoVideo_Mode = False
			CameVideo = False
			RuinedVideo = False



			DomWMP.currentPlaylist.clear()


			If CensorshipGame = True Then
				CensorshipTimer.Stop()
				CensorshipBar.Visible = False
				CensorshipGame = False
				VideoTease = False
				mainPictureBox.Visible = True
				DomWMP.Visible = False



				If RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					SaidHello = False
					RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				RunFileText()
			End If

			If AvoidTheEdgeGame = True Then

				TeaseVideo = False
				AvoidTheEdgeGame = False
				AvoidTheEdgeStroking = False
				AvoidTheEdgeTaunts.Stop()
				VideoTease = False
				SubStroking = False


				Debug.Print("TempStrokeTauntVal = " & TempStrokeTauntVal)
				Debug.Print("TempFileText = " & TempFileText)


				If RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					SaidHello = False
					RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				StrokeTauntVal = TempStrokeTauntVal
				FileText = TempFileText

				ScriptTick = 2
				ScriptTimer.Start()

				'RunFileText()



				mainPictureBox.Visible = True
				DomWMP.Visible = False


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

			If RLGLGame = True Then
				RLGLTimer.Stop()
				RLGLTauntTimer.Stop()
				RLGLGame = False
				VideoTease = False
				SubStroking = False


				If RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					SaidHello = False
					RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				ScriptTick = 1
				ScriptTimer.Start()
				mainPictureBox.Visible = True
				DomWMP.Visible = False

				Return
			End If


			If TeaseVideo = True Then
				TeaseVideo = False
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.pause()
				mainPictureBox.Visible = True
				RunFileText()
			End If



		End If

	End Sub

	Private Sub WMPTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles WMPTimer.Tick


		If DomWMP.currentPlaylist.count <> 0 Then
			Try
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VideoRemaining As Integer = Math.Floor(DomWMP.currentMedia.duration - DomWMP.Ctlcontrols.currentPosition)

				Debug.Print("Video Length = " & VideoLength)
				Debug.Print("Video Remaining = " & VideoRemaining)
			Catch
			End Try
		End If





		If DomTypeCheck = True Or DomWMP.playState = WMPLib.WMPPlayState.wmppsStopped Or DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused Then Return

		'Debug.Print("New movie loaded: " & DomWMP.URL.ToString)

		VidFile = Path.GetFileName(DomWMP.URL.ToString)

		Dim VidSplit As String() = VidFile.Split(".")
		VidFile = ""
		For i As Integer = 0 To VidSplit.Count - 2
			VidFile = VidFile + VidSplit(i)
		Next
		'Debug.Print(VidFile)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & VidFile & ".txt") Then
			Dim SubCheck As String()
			Dim PlayPos As Integer
			Dim WMPPos As Integer = Math.Ceiling(DomWMP.Ctlcontrols.currentPosition)

			Dim SubList As New List(Of String)
			SubList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & VidFile & ".txt")

			If Not SubList Is Nothing Then
				For i As Integer = 0 To SubList.Count - 1
					SubCheck = SubList(i).Split("]")
					SubCheck(0) = SubCheck(0).Replace("[", "")
					Dim SubCheck2 As String() = SubCheck(0).Split(":")

					PlayPos = SubCheck2(0) * 3600
					PlayPos += SubCheck2(1) * 60
					PlayPos += SubCheck2(2)

					If WMPPos = PlayPos Then
						DomTask = SubCheck(1)
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
		My.Settings.Save()

	End Sub


	Private Sub WaitTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles WaitTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If DomTypeCheck = True Or YesOrNo = True Then Return

		'Debug.Print("WaitTick = " & WaitTick)

		WaitTick -= 1

		If WaitTick < 1 Then
			WaitTimer.Stop()
			ScriptTick = 1
		End If


	End Sub

	Private Sub StupidTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles StupidTimer.Tick

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

		'Dim GoldReader As New StreamReader(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Apps\Cards\Gold.txt")
		'Dim GoldList As New List(Of String)

		'While GoldReader.Peek <> -1
		'GoldList.Add(GoldReader.ReadLine())
		'End While

		'GoldReader.Close()
		'GoldReader.Dispose()

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

		'FrmCardList.GoldP1.Load(My.Settings.GP1)
		'FrmCardList.GoldP2.Load(My.Settings.GP2)
		'FrmCardList.GoldP3.Load(My.Settings.GP3)
		'FrmCardList.GoldP4.Load(My.Settings.GP4)
		'FrmCardList.GoldP5.Load(My.Settings.GP5)
		'FrmCardList.GoldP6.Load(My.Settings.GP6)

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


		'FrmCardList.SilverP1.Load(My.Settings.SP1)
		'FrmCardList.SilverP2.Load(My.Settings.SP2)
		'FrmCardList.SilverP3.Load(My.Settings.SP3)
		'FrmCardList.SilverP4.Load(My.Settings.SP4)
		'FrmCardList.SilverP5.Load(My.Settings.SP5)
		'FrmCardList.SilverP6.Load(My.Settings.SP6)

		FrmCardList.BronzeN1.Text = FrmSettings.BN1.Text
		FrmCardList.BronzeN2.Text = FrmSettings.BN2.Text
		FrmCardList.BronzeN3.Text = FrmSettings.BN3.Text
		FrmCardList.BronzeN4.Text = FrmSettings.BN4.Text
		FrmCardList.BronzeN5.Text = FrmSettings.BN5.Text
		FrmCardList.BronzeN6.Text = FrmSettings.BN6.Text

		'FrmCardList.BronzeP1.Load(My.Settings.BP1)
		FrmCardList.BronzeP1.Image = Image.FromFile(My.Settings.BP1)
		FrmCardList.BronzeP2.Image = Image.FromFile(My.Settings.BP2)
		FrmCardList.BronzeP3.Image = Image.FromFile(My.Settings.BP3)
		FrmCardList.BronzeP4.Image = Image.FromFile(My.Settings.BP4)
		FrmCardList.BronzeP5.Image = Image.FromFile(My.Settings.BP5)
		FrmCardList.BronzeP6.Image = Image.FromFile(My.Settings.BP6)
		'FrmCardList.BronzeP2.Load(My.Settings.BP2)
		'FrmCardList.BronzeP3.Load(My.Settings.BP3)
		'FrmCardList.BronzeP4.Load(My.Settings.BP4)
		'FrmCardList.BronzeP5.Load(My.Settings.BP5)
		'FrmCardList.BronzeP6.Load(My.Settings.BP6)









	End Sub








	Public Sub SaveTokens()

		My.Settings.BronzeTokens = BronzeTokens
		My.Settings.SilverTokens = SilverTokens
		My.Settings.GoldTokens = GoldTokens
		My.Settings.Save()

	End Sub

















	Private Sub VideoTauntTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles VideoTauntTimer.Tick

		If MiniScript = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And VideoTauntTick < 6 Then Return
		If chatBox.Text <> "" And VideoTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And VideoTauntTick < 6 Then Return

		VideoTauntTick -= 1


		If VideoTauntTick < 1 Then

			Dim FrequencyTemp As Integer = randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				VideoTauntTick = randomizer.Next(20, 31)
				Return
			End If

			Dim VTDir As String

			If RLGLGame = True Then VTDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Taunts.txt"
			'TODO: Prevent File.Exits() with String.Empty
			If Not File.Exists(VTDir) Then Return

			' Read all lines of the given file.
			Dim VTList As List(Of String) = Txt2List(VTDir)

			Try
				VTList = FilterList(VTList)
				If VTList.Count < 1 Then Return
				DomTask = VTList(randomizer.Next(0, VTList.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try

			TypingDelayGeneric()



			VideoTauntTick = randomizer.Next(20, 31)


		End If









	End Sub

	Private Sub TeaseTimer_Disposed(sender As Object, e As System.EventArgs) Handles TeaseTimer.Disposed

	End Sub

	Private Sub TeaseTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles TeaseTimer.Tick


		FrmSettings.LBLDebugTeaseTime.Text = TeaseTick
		'Debug.Print("TeaseTick = " & TeaseTick)

		TeaseTick -= 1

		If TeaseTick < 1 Then TeaseTimer.Stop()



	End Sub

	Public Sub RLGLTauntTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles RLGLTauntTimer.Tick

		If MiniScript = True Then Return

		If DomTyping = True Then Return
		If DomTypeCheck = True And RLGLTauntTick < 6 Then Return
		If chatBox.Text <> "" And RLGLTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And RLGLTauntTick < 6 Then Return

		RLGLTauntTick -= 1


		If RLGLTauntTick < 1 Then

			Dim FrequencyTemp As Integer = randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				RLGLTauntTick = randomizer.Next(20, 31)
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
				DomTask = VTList(randomizer.Next(0, VTList.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try
			TypingDelayGeneric()



			RLGLTauntTick = randomizer.Next(20, 31)


		End If



	End Sub

	Private Sub AvoidTheEdgeTaunts_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles AvoidTheEdgeTaunts.Tick


		If DomTyping = True Then Return
		If DomTypeCheck = True And AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And AvoidTheEdgeTick < 6 Then Return



		AvoidTheEdgeTick -= 1


		If AvoidTheEdgeTick < 1 Then

			Dim FrequencyTemp As Integer = randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				AvoidTheEdgeTick = randomizer.Next(20, 31)
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
				DomTask = VTList(randomizer.Next(0, VTList.Count))
			Catch
				DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try
			TypingDelayGeneric()



			AvoidTheEdgeTick = randomizer.Next(20, 31)


		End If


	End Sub

	Public Function SaveImage(ByVal BlogPath As String)

		If BlogPath = "Hardcore" Then BlogPath = FrmSettings.LBLIHardcore.Text
		If BlogPath = "Softcore" Then BlogPath = FrmSettings.LBLISoftcore.Text
		If BlogPath = "Lesbian" Then BlogPath = FrmSettings.LBLILesbian.Text
		If BlogPath = "Blowjob" Then BlogPath = FrmSettings.LBLIBlowjob.Text
		If BlogPath = "Femdom" Then BlogPath = FrmSettings.LBLIFemdom.Text
		If BlogPath = "Lezdom" Then BlogPath = FrmSettings.LBLILezdom.Text
		If BlogPath = "Hentai" Then BlogPath = FrmSettings.LBLIHentai.Text
		If BlogPath = "Gay" Then BlogPath = FrmSettings.LBLIGay.Text
		If BlogPath = "Maledom" Then BlogPath = FrmSettings.LBLIMaledom.Text
		If BlogPath = "Captions" Then BlogPath = FrmSettings.LBLICaptions.Text
		If BlogPath = "General" Then BlogPath = FrmSettings.LBLIGeneral.Text
		If BlogPath = "Boobs" Then BlogPath = FrmSettings.LBLBoobPath.Text
		If BlogPath = "Butt" Then BlogPath = FrmSettings.LBLButtPath.Text


		If Directory.Exists(BlogPath) Then

			WebImage = ImageLocation

			Do Until Not WebImage.Contains("/")
				WebImage = WebImage.Remove(0, 1)
			Loop

			Debug.Print(BlogPath & "\" & WebImage)

			If File.Exists(BlogPath & "\" & WebImage) Then

				Dim Result As Integer = MessageBox.Show(Me, WebImage & " already exists in this directory!" & Environment.NewLine & Environment.NewLine &
													 "Do you wish to overwrite?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
				If Result = DialogResult.Yes Then
					My.Computer.FileSystem.DeleteFile(BlogPath & "\" & WebImage)
					My.Computer.Network.DownloadFile(FoundString, BlogPath & "\" & WebImage)
				End If

			Else

				My.Computer.Network.DownloadFile(FoundString, BlogPath & "\" & WebImage)

			End If

		End If


	End Function


#Region "-------------------------------------------------- MainPictureBox ----------------------------------------------------"

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

		Dim FetchContainer As New ImageFetchObject
		FetchContainer.ImageLocation = ImageToShow

		If FrmSettings.CBBlogImageWindow.Checked = True _
		Then FetchContainer.SaveImageDirectory = Application.StartupPath & " \ Images \ Session Images\" _
		Else FetchContainer.SaveImageDirectory = ""

		BWimageFetcher.RunWorkerAsync(FetchContainer, True)


		If WaitToFinish Then BWimageFetcher.WaitToFinish()

	End Sub

	Private Sub mainPictureBox_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles mainPictureBox.LoadCompleted
		ImageLocation = mainPictureBox.ImageLocation
		CheckDommeTags()
		Debug.Print("ImageLoadCOmpleted")
	End Sub

	Private Sub mainPictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mainPictureBox.MouseDown
		If e.Button = MouseButtons.Right Then
			PictureStrip.Show(CType(sender, Control), e.Location)
		End If
	End Sub

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
		If e.Cancelled Then Exit Sub
		If e.Error IsNot Nothing Then Exit Sub

		If TypeOf e.Result Is ImageFetchObject Then
			Dim FetchResult As ImageFetchObject = e.Result
			Dim OldImage As Image = mainPictureBox.Image
			Dim NewImage As Bitmap = FetchResult.FetchedImage.Clone

			mainPictureBox.Image = NewImage
			mainPictureBox.Refresh()
			mainPictureBox.Invalidate()

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

#End Region ' MainPictureBox

#Region "-------------------------------------------------- PictureStrip ------------------------------------------------------"

	Private Sub ToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click

		My.Computer.Clipboard.SetText(ImageLocation)

	End Sub

	Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click



		SaveFileDialog1.Filter = "jpegs|*.jpg|gifs|*.gif|pngs|*.png|Bitmaps|*.bmp"
		SaveFileDialog1.FilterIndex = 1
		SaveFileDialog1.RestoreDirectory = True

		WebImage = FoundString
		Do Until Not WebImage.Contains("/")
			WebImage = WebImage.Remove(0, 1)
		Loop

		SaveFileDialog1.FileName = WebImage

		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

			My.Computer.Network.DownloadFile(FoundString, SaveFileDialog1.FileName)

		End If


	End Sub

	Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click

		If FoundString <> "" Then
			If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & FoundString, True)
			Else
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", FoundString, True)
			End If
			PictureStrip.Items(3).Enabled = False
		End If


	End Sub

	Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click

		If FoundString <> "" Then

			If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & FoundString, True)
			Else
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", FoundString, True)
			End If
			PictureStrip.Items(4).Enabled = False
		End If

	End Sub

	Private Sub RemoveFromUrlFile_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click

		'For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
		Debug.Print(ImageUrlFilePath)
		' Read all lines of the given file.
		Dim RemoveList As List(Of String) = Txt2List(ImageUrlFilePath)

		'For i As Integer = RemoveList.Count - 1 To 0 Step -1
		Debug.Print(RemoveList(ImageUrlFileIndex))
		Debug.Print("foundstring = " & FoundString)
		'If RemoveList(i) = FoundString Then
		'Debug.Print("MMMMMMMMMMMMMMMMMMMMMMMAAAAAAAAAAAAAAAAATTTTTTTTTTTTTTTTCCCCCCCCCCCCCCHHHHHHHHHHHHHHHHH")
		RemoveList.Remove(RemoveList(ImageUrlFileIndex))
		'End If
		'Next

		If File.Exists(ImageUrlFilePath) Then My.Computer.FileSystem.DeleteFile(ImageUrlFilePath)

		Debug.Print(RemoveList.Count)

		For i As Integer = 0 To RemoveList.Count - 1
			If File.Exists(ImageUrlFilePath) Then
				My.Computer.FileSystem.WriteAllText(ImageUrlFilePath, Environment.NewLine & RemoveList(i), True)
			Else
				My.Computer.FileSystem.WriteAllText(ImageUrlFilePath, RemoveList(i), True)
			End If
		Next
		'Next

		PictureStrip.Items(5).Enabled = False

	End Sub

#Region "-------------------------------------------------- Save Blog Image ---------------------------------------------------"

	Private Sub HardcoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HardcoreToolStripMenuItem.Click
		SaveImage("Hardcore")
	End Sub
	Private Sub SoftcoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SoftcoreToolStripMenuItem.Click
		SaveImage("Softcore")
	End Sub
	Private Sub LesbianToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LesbianToolStripMenuItem.Click
		SaveImage("Lesbian")
	End Sub
	Private Sub BlowjobToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BlowjobToolStripMenuItem.Click
		SaveImage("Blowjob")
	End Sub
	Private Sub FemdomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FemdomToolStripMenuItem.Click
		SaveImage("Femdom")
	End Sub
	Private Sub LezdomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LezdomToolStripMenuItem.Click
		SaveImage("Lezdom")
	End Sub
	Private Sub HentaiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HentaiToolStripMenuItem.Click
		SaveImage("Hentai")
	End Sub
	Private Sub GayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GayToolStripMenuItem.Click
		SaveImage("Gay")
	End Sub
	Private Sub MaledomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MaledomToolStripMenuItem.Click
		SaveImage("Maledom")
	End Sub
	Private Sub CaptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CaptionsToolStripMenuItem.Click
		SaveImage("Captions")
	End Sub
	Private Sub GeneralToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles GeneralToolStripMenuItem1.Click
		SaveImage("General")
	End Sub
	Private Sub BoobsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BoobsToolStripMenuItem.Click
		SaveImage("Boobs")
	End Sub
	Private Sub ButtsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ButtsToolStripMenuItem.Click
		SaveImage("Butt")
	End Sub

#End Region

#Region "-------------------------------------------------- DommeSlideshow ----------------------------------------------------"

	Private Sub GoToLastImageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GoToLastImageToolStripMenuItem.Click


		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If


		If SlideshowLoaded = False Or TeaseVideo = True Or LockImage = True Then Return

		FileCount = FileCountMax

		ClearMainPictureBox()

		Try
			ShowImage(_ImageFileNames(FileCount))
			JustShowedBlogImage = False
		Catch

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

	End Sub

	Private Sub GoToFirstImageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GoToFirstImageToolStripMenuItem.Click


		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If


		If SlideshowLoaded = False Or TeaseVideo = True Or LockImage = True Then Return

		FileCount = 0

		ClearMainPictureBox()


		Try
			ShowImage(_ImageFileNames(FileCount))

			JustShowedBlogImage = False
		Catch

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



	End Sub

	Private Sub LoadNewSlideshowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadNewSlideshowToolStripMenuItem.Click

		NewDommeSlideshow = True
		OriginalDommeSlideshow = _ImageFileNames(0)
		LoadDommeImageFolder()
		NewDommeSlideshow = False
		DomPic = _ImageFileNames(FileCount)

	End Sub

#End Region

#End Region


	Private Sub ContactTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles ContactTimer.Tick
		ContactTick -= 1


		If ContactTick < 1 Then
			ContactTimer.Stop()
			ContactFlag = False
		End If

	End Sub


















	Public Sub LoadDommeImageFolder()


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

		GetFolder = GreetFolder(randomizer.Next(0, GreetFolder.Count))

		SlideshowLoaded = True

		DomWMP.Visible = False
		DomWMP.Ctlcontrols.pause()
		mainPictureBox.Visible = True

		FrmSettings.timedRadio.Enabled = True
		FrmSettings.teaseRadio.Enabled = True

		FileCount = 0
		FileCountMax = -1
		_ImageFileNames.Clear()


		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"


		Dim files As String()

		If FrmSettings.CBSlideshowSubDir.Checked = True Then
			files = myDirectory.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)
		Else
			files = myDirectory.GetFiles(GetFolder, "*.*")
		End If


		Array.Sort(files)



		Dim TestCOUnt As Integer = 0
		For Each fi As String In files
			If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
				TestCOUnt += 1
				_ImageFileNames.Add(fi)
			End If
		Next

		FileCountMax = _ImageFileNames.Count - 1



		If FileCountMax < 0 Then
			MessageBox.Show(Me, "There are no images in the specified Domme Image folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		FileCount = 0


		If NewDommeSlideshow = True Then
			NewSlideshowAttempts += 1
			If _ImageFileNames(0) = OriginalDommeSlideshow And NewSlideshowAttempts < 6 Then GoTo GetDommeSlideshow
		End If



		If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

		ShowImage(_ImageFileNames(FileCount))
		JustShowedBlogImage = False

		nextButton.Enabled = True
		previousButton.Enabled = True
		DommeSlideshowToolStripMenuItem.Enabled = True

		If RiskyDeal = True Then FrmCardList.PBRiskyPic.Image = Image.FromFile(_ImageFileNames(FileCount))


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
			SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
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

	Public Sub ClearMainPictureBox()



		If Not mainPictureBox Is Nothing Then
			Try
				mainPictureBox.Image.Dispose()
				mainPictureBox.Image = Nothing
				GC.Collect()
			Catch
			End Try
		End If



	End Sub

	''' =========================================================================================================
	''' <summary>
	''' Reads a TextFile to a generic List(of String).
	''' </summary>
	''' <param name="GetText">The Filepath to read.</param>
	''' <returns>A List(of String) containing all Lines of the given File. Returns 
	''' "Nothing" if the specified file doesn't exists.</returns>
	''' <remarks>This Method will create the given DirectoryStructure for the given
	''' Filepath if it doesn't exists.</remarks>
	Public Shared Function Txt2List(ByVal GetText As String) As List(Of String)

		' check if the given Directory Exits, otherwise a IO.DirectoryNotFound Exception occurs.
		If Directory.Exists(Path.GetDirectoryName(GetText)) = False Then
			Directory.CreateDirectory(Path.GetDirectoryName(GetText))
		End If

		If File.Exists(GetText) Then
			Using TextReader As New StreamReader(GetText)
				Dim TextList As New List(Of String)
				TextList.Clear()
				While TextReader.Peek <> -1
					TextList.Add(TextReader.ReadLine())
				End While
				Return TextList
			End Using
		End If
		Return Nothing
	End Function


	Public Shared Function TxtReadLine(ByVal GetText As String) As String

		' check if the given Directory Exits, otherwise a IO.DirectoryNotFound Exception occurs.
		If Directory.Exists(Path.GetDirectoryName(GetText)) = False Then
			Directory.CreateDirectory(Path.GetDirectoryName(GetText))
		End If

		If File.Exists(GetText) Then
			Using TextReader As New StreamReader(GetText)
				Return TextReader.ReadLine
			End Using
		End If
		Return Nothing
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


	Private Sub CustomSlideshowTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles CustomSlideshowTimer.Tick

		ImageString = CustomSlideshowList(randomizer.Next(0, CustomSlideshowList.Count))
		DeleteLocalImageFilePath = ImageString

		Try
			ShowImage(ImageString, True)
		Catch ex As Exception
			Exit Sub

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

	Public Sub GetContact1Pics()

		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim ContactPics As String()
		Dim ContactFolder As String

		Dim Contact1Folder As New List(Of String)
		Contact1Folder.Clear()
		Contact1Pics.Clear()
		If Directory.Exists(FrmSettings.LBLContact1ImageDir.Text) Then
			For Each Dir As String In myDirectory.GetDirectories(FrmSettings.LBLContact1ImageDir.Text)
				Try
					Contact1Folder.Add(Dir)
				Catch
				End Try
			Next

			If Contact1Folder.Count < 1 Then
				MessageBox.Show(Me, "There are no directories in the specified Contact 1 Images Directory folder." & Environment.NewLine & Environment.NewLine &
				"Please make sure the Contact 1 Images Directory points to a location containing at least one subdirectory of images.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			If Contact1Folder.Count <> 0 Then

				ContactFolder = Contact1Folder(randomizer.Next(0, Contact1Folder.Count))

				ContactPics = myDirectory.GetFiles(ContactFolder, "*.*")
				Array.Sort(ContactPics)


				For Each fi As String In ContactPics
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						Contact1Pics.Add(fi)
					End If
				Next

				If Contact1Pics.Count < 0 Then
					MessageBox.Show(Me, "There are no images in the specified Contact 1 Image folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If


			End If
		End If

		Contact1PicsCount = -1

	End Sub

	Public Sub GetContact2Pics()

		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim ContactPics As String()
		Dim ContactFolder As String

		Dim Contact2Folder As New List(Of String)
		Contact2Folder.Clear()
		Contact2Pics.Clear()
		If Directory.Exists(FrmSettings.LBLContact2ImageDir.Text) Then
			For Each Dir As String In myDirectory.GetDirectories(FrmSettings.LBLContact2ImageDir.Text)
				Try
					Contact2Folder.Add(Dir)
				Catch
				End Try
			Next

			If Contact2Folder.Count < 1 Then
				MessageBox.Show(Me, "There are no directories in the specified Contact 2 Images Directory folder." & Environment.NewLine & Environment.NewLine &
			 "Please make sure the Contact 2 Images Directory points to a location containing at least one subdirectory of images.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			If Contact2Folder.Count <> 0 Then

				ContactFolder = Contact2Folder(randomizer.Next(0, Contact2Folder.Count))

				ContactPics = myDirectory.GetFiles(ContactFolder, "*.*")
				Array.Sort(ContactPics)


				For Each fi As String In ContactPics
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						Contact2Pics.Add(fi)
					End If
				Next

				If Contact2Pics.Count < 0 Then
					MessageBox.Show(Me, "There are no images in the specified Contact 2 Image folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If

			End If
		End If

		Contact2PicsCount = -1

	End Sub

	Public Sub GetContact3Pics()

		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim ContactPics As String()
		Dim ContactFolder As String

		Dim Contact3Folder As New List(Of String)
		Contact3Folder.Clear()
		Contact3Pics.Clear()
		If Directory.Exists(FrmSettings.LBLContact3ImageDir.Text) Then
			For Each Dir As String In myDirectory.GetDirectories(FrmSettings.LBLContact3ImageDir.Text)
				Try
					Contact3Folder.Add(Dir)
				Catch
				End Try
			Next


			If Contact3Folder.Count < 1 Then
				MessageBox.Show(Me, "There are no directories in the specified Contact 3 Images Directory folder." & Environment.NewLine & Environment.NewLine &
	   "Please make sure the Contact 3 Images Directory points to a location containing at least one subdirectory of images.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			If Contact3Folder.Count <> 0 Then

				ContactFolder = Contact3Folder(randomizer.Next(0, Contact3Folder.Count))

				ContactPics = myDirectory.GetFiles(ContactFolder, "*.*")
				Array.Sort(ContactPics)


				For Each fi As String In ContactPics
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						Contact3Pics.Add(fi)
					End If
				Next

				If Contact3Pics.Count < 0 Then
					MessageBox.Show(Me, "There are no images in the specified Contact 3 Image folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If

			End If
		End If

		Contact3PicsCount = -1

	End Sub


	Private Sub Contact1Timer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles Contact1Timer.Tick

		AddContactTick -= 1

		If AddContactTick < 1 Then
			Contact1Timer.Stop()
			If Not Group.Contains("1") Then
				Group = Group & "1"
				GlitterTease = True
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter1.Text & " has joined the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			Else
				Group = Group.Replace("1", "")
				If Group = "D" Then GlitterTease = False
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter1.Text & " has left the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			End If
		End If

	End Sub

	Private Sub Contact2Timer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles Contact2Timer.Tick

		AddContactTick -= 1

		If AddContactTick < 1 Then
			Contact2Timer.Stop()
			If Not Group.Contains("2") Then
				Group = Group & "2"
				GlitterTease = True
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter2.Text & " has joined the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			Else
				Group = Group.Replace("2", "")
				If Group = "D" Then GlitterTease = False
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter2.Text & " has left the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			End If
		End If

	End Sub

	Private Sub Contact3Timer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles Contact3Timer.Tick

		AddContactTick -= 1

		If AddContactTick < 1 Then
			Contact3Timer.Stop()
			If Not Group.Contains("3") Then
				Group = Group & "3"
				GlitterTease = True
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter3.Text & " has joined the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			Else
				Group = Group.Replace("3", "")
				If Group = "D" Then GlitterTease = False
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter3.Text & " has left the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			End If
		End If

	End Sub

#End Region

	Private Sub DommeTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles DommeTimer.Tick

		AddContactTick -= 1

		If AddContactTick < 1 Then
			DommeTimer.Stop()
			If Not Group.Contains("D") Then
				Group = Group & "D"
				If Group = "D" Then GlitterTease = False
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & domName.Text & " has joined the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			Else
				Group = Group.Replace("D", "")
				GlitterTease = True
				Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & Chat & "<font color=""SteelBlue""><b>" & domName.Text & " has left the chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = Chat
				While ChatText.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ChatText2.DocumentText = Chat
				While ChatText2.ReadyState <> WebBrowserReadyState.Complete
					Application.DoEvents()
				End While
				ScrollChatDown()
			End If
		End If

	End Sub

	Private Sub UpdateStageTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles UpdateStageTimer.Tick
		UpdateStageTick -= 1
		If UpdateStageTick < 1 Then
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
		SettingsList.Add("ScriptOperator: " & ScriptOperator)
		SettingsList.Add("ScriptCompare: " & ScriptCompare)
		SettingsList.Add("DomTyping: " & DomTyping)
		SettingsList.Add("CheckYes: " & CheckYes)
		SettingsList.Add("CheckNo: " & CheckNo)
		SettingsList.Add("Playlist: " & Playlist)

		SettingsList.Add("PlaylistCurrent: " & PlaylistCurrent)
		SettingsList.Add("SubInChastity: " & SubInChastity)
		' Github Patch SettingsList.Add("FormLoading: " & FormLoading)
		SettingsList.Add("FormLoading: " & False)
		SettingsList.Add("RandomDelay: " & RandomDelay)
		SettingsList.Add("Responding: " & Responding)
		SettingsList.Add("ScriptLineVal: " & ScriptLineVal)
		SettingsList.Add("StrokeTauntVal: " & StrokeTauntVal)
		SettingsList.Add("ThoughtTauntVal: " & ThoughtTauntVal)
		SettingsList.Add("ModuleTauntVal: " & ModuleTauntVal)
		SettingsList.Add("FileText: " & FileText)
		SettingsList.Add("TempStrokeTauntVal: " & TempStrokeTauntVal)
		SettingsList.Add("TempFileText: " & TempFileText)
		SettingsList.Add("ModText: " & ModText)
		SettingsList.Add("TeaseTick: " & TeaseTick)
		SettingsList.Add("StrokeTauntCount: " & StrokeTauntCount)
		SettingsList.Add("TauntTextTotal: " & TauntTextTotal)
		'SettingsList.Add("TauntLines: " & TauntLines)
		SettingsList.Add("StrokeFilter: " & StrokeFilter)
		SettingsList.Add("ScriptTick: " & ScriptTick)
		SettingsList.Add("StringLength: " & StringLength)
		SettingsList.Add("FileGoto: " & FileGoto)
		SettingsList.Add("SkipGotoLine: " & SkipGotoLine)
		SettingsList.Add("HandleScriptText: " & HandleScriptText)
		SettingsList.Add("ChatString: " & ChatString)
		SettingsList.Add("DomTask: " & DomTask)
		SettingsList.Add("DomChat: " & DomChat)
		SettingsList.Add("TypeDelay: " & TypeDelay)
		SettingsList.Add("TempVal: " & TempVal)
		SettingsList.Add("NullResponse: " & NullResponse)
		SettingsList.Add("CleanFlag: " & CleanFlag)
		SettingsList.Add("DebugAwarenessLine: " & DebugAwarenessLine)
		SettingsList.Add("TagCount: " & TagCount)
		SettingsList.Add("LocalTagCount: " & LocalTagCount)
		SettingsList.Add("OrgasmResult: " & OrgasmResult)
		SettingsList.Add("BeggedOrgasmDecision: " & BeggedOrgasmDecision)
		SettingsList.Add("TeaseOver: " & TeaseOver)
		SettingsList.Add("TaskFile: " & TaskFile)
		SettingsList.Add("TaskText: " & TaskText)
		SettingsList.Add("TaskTextDir: " & TaskTextDir)
		SettingsList.Add("ResponseFile: " & ResponseFile)
		SettingsList.Add("ResponseLine: " & ResponseLine)
		SettingsList.Add("CBTCockActive: " & CBTCockActive)
		SettingsList.Add("CBTBallsActive: " & CBTBallsActive)
		SettingsList.Add("CBTCockFlag: " & CBTCockFlag)
		SettingsList.Add("CBTBallsFlag: " & CBTBallsFlag)
		SettingsList.Add("CBTBallsFirst: " & CBTBallsFirst)
		SettingsList.Add("CBTCockFirst: " & CBTCockFirst)
		SettingsList.Add("CBTBallsCount: " & CBTBallsCount)
		SettingsList.Add("CBTCockCount: " & CBTCockCount)
		SettingsList.Add("ThoughtCount: " & ThoughtCount)
		SettingsList.Add("GotoDommeLevel: " & GotoDommeLevel)
		SettingsList.Add("DommeMood: " & DommeMood)
		SettingsList.Add("AFK: " & AFK)
		SettingsList.Add("HypnoGen: " & HypnoGen)
		SettingsList.Add("Induction: " & Induction)
		SettingsList.Add("TempHypno: " & TempHypno)
		SettingsList.Add("DomColor: " & DomColor)
		SettingsList.Add("SubColor: " & SubColor)
		SettingsList.Add("StrokeCycle: " & StrokeCycle)
		SettingsList.Add("StrokeTick: " & StrokeTick)
		SettingsList.Add("StrokeTauntTick: " & StrokeTauntTick)
		SettingsList.Add("StrokePaceRight: " & StrokePaceRight)
		SettingsList.Add("StrokePace: " & StrokePace)
		SettingsList.Add("AudibleTick: " & AudibleTick)
		SettingsList.Add("StrokeTimeTotal: " & StrokeTimeTotal)
		SettingsList.Add("HoldEdgeTime: " & HoldEdgeTime)
		SettingsList.Add("HoldEdgeTimeTotal: " & HoldEdgeTimeTotal)
		SettingsList.Add("EdgeTauntInt: " & EdgeTauntInt)
		SettingsList.Add("DelayTick: " & DelayTick)
		SettingsList.Add("DelayFlag: " & DelayFlag)
		SettingsList.Add("PreCleanString: " & PreCleanString)
		SettingsList.Add("DomTypeCheck: " & DomTypeCheck)
		SettingsList.Add("TypeToggle: " & TypeToggle)
		SettingsList.Add("IsTyping: " & IsTyping)
		SettingsList.Add("SubWroteLast: " & SubWroteLast)
		SettingsList.Add("YesOrNo: " & YesOrNo)
		SettingsList.Add("GotoFlag: " & GotoFlag)
		SettingsList.Add("LoopAnswer: " & LoopAnswer)
		SettingsList.Add("CBT: " & CBT)
		SettingsList.Add("NoEdge: " & NoEdge)
		SettingsList.Add("RunningScript: " & RunningScript)
		SettingsList.Add("RePound: " & RePound)
		SettingsList.Add("BeforeTease: " & BeforeTease)
		SettingsList.Add("SubStroking: " & SubStroking)
		SettingsList.Add("SubEdging: " & SubEdging)
		SettingsList.Add("SubHoldingEdge: " & SubHoldingEdge)
		SettingsList.Add("SubCBT: " & SubCBT)
		SettingsList.Add("EndTease: " & EndTease)
		SettingsList.Add("ShowThought: " & ShowThought)
		SettingsList.Add("ShowEdgeThought: " & ShowEdgeThought)
		SettingsList.Add("ShowModule: " & ShowModule)
		SettingsList.Add("ModuleEnd: " & ModuleEnd)
		SettingsList.Add("DivideText: " & DivideText)
		SettingsList.Add("HoldEdgeTick: " & HoldEdgeTick)
		SettingsList.Add("HoldEdgeChance: " & HoldEdgeChance)
		SettingsList.Add("EdgeHold: " & EdgeHold)
		SettingsList.Add("EdgeNoHold: " & EdgeNoHold)
		SettingsList.Add("EdgeToRuin: " & EdgeToRuin)
		SettingsList.Add("EdgeToRuinSecret: " & EdgeToRuinSecret)
		SettingsList.Add("LongEdge: " & LongEdge)
		SettingsList.Add("AskedToGiveUp: " & AskedToGiveUp)
		SettingsList.Add("AskedToGiveUpSection: " & AskedToGiveUpSection)
		SettingsList.Add("SubGaveUp: " & SubGaveUp)
		SettingsList.Add("AskedToSpeedUp: " & AskedToSpeedUp)
		SettingsList.Add("AskedToSlowDown: " & AskedToSlowDown)
		SettingsList.Add("ThoughtEnd: " & ThoughtEnd)
		SettingsList.Add("VTLength: " & VTLength)
		SettingsList.Add("DommeVideo: " & DommeVideo)
		SettingsList.Add("VideoType: " & VideoType)
		SettingsList.Add("CensorshipGame: " & CensorshipGame)
		SettingsList.Add("CensorshipTick: " & CensorshipTick)
		SettingsList.Add("CensorDuration: " & CensorDuration)
		SettingsList.Add("AvoidTheEdgeGame: " & AvoidTheEdgeGame)
		SettingsList.Add("AvoidTheEdgeTick: " & AvoidTheEdgeTick)
		SettingsList.Add("AvoidTheEdgeTimerTick: " & AvoidTheEdgeTimerTick)
		SettingsList.Add("AvoidTheEdgeDuration: " & AvoidTheEdgeDuration)
		SettingsList.Add("AvoidTheEdgeStroking: " & AvoidTheEdgeStroking)
		SettingsList.Add("AtECountdown: " & AtECountdown)
		SettingsList.Add("VTPath: " & VTPath)
		SettingsList.Add("NoVideo: " & NoVideo)
		SettingsList.Add("NoSpecialVideo: " & NoSpecialVideo)
		SettingsList.Add("VideoCheck: " & VideoCheck)
		SettingsList.Add("VideoTease: " & VideoTease)
		SettingsList.Add("RLGLGame: " & RLGLGame)
		SettingsList.Add("RLGLStroking: " & RLGLStroking)
		SettingsList.Add("RLGLTick: " & RLGLTick)
		SettingsList.Add("RedLight: " & RedLight)
		SettingsList.Add("RLGLTauntTick: " & RLGLTauntTick)
		SettingsList.Add("RandomizerVideo: " & RandomizerVideo)
		SettingsList.Add("RandomizerVideoTease: " & RandomizerVideoTease)
		SettingsList.Add("ScriptVideoTease: " & ScriptVideoTease)
		SettingsList.Add("ScriptVideoTeaseFlag: " & ScriptVideoTeaseFlag)
		SettingsList.Add("VideoTauntTick: " & VideoTauntTick)
		SettingsList.Add("SlideshowLoaded: " & SlideshowLoaded)
		SettingsList.Add("RefreshVideoTotal: " & RefreshVideoTotal)
		SettingsList.Add("GlitterImageAV: " & GlitterImageAV)
		SettingsList.Add("GlitterNCDomme: " & GlitterNCDomme)
		SettingsList.Add("GlitterNC1: " & GlitterNC1)
		SettingsList.Add("GlitterNC2: " & GlitterNC2)
		SettingsList.Add("GlitterNC3: " & GlitterNC3)
		SettingsList.Add("GlitterTempColor: " & GlitterTempColor)
		SettingsList.Add("UpdatesTick: " & UpdatesTick)
		SettingsList.Add("UpdatingPost: " & UpdatingPost)
		SettingsList.Add("UpdateStage: " & UpdateStage)
		SettingsList.Add("UpdateStageTick: " & UpdateStageTick)
		SettingsList.Add("StatusText: " & StatusText)
		SettingsList.Add("ContactNumber: " & ContactNumber)
		SettingsList.Add("ContactTick: " & ContactTick)
		SettingsList.Add("ContactFlag: " & ContactFlag)
		SettingsList.Add("StatusText1: " & StatusText1)
		SettingsList.Add("StatusText2: " & StatusText2)
		SettingsList.Add("StatusText3: " & StatusText3)
		SettingsList.Add("StatusChance1: " & StatusChance1)
		SettingsList.Add("StatusChance2: " & StatusChance2)
		SettingsList.Add("StatusChance3: " & StatusChance3)
		SettingsList.Add("Update1: " & Update1)
		SettingsList.Add("Update2: " & Update2)
		SettingsList.Add("Update3: " & Update3)
		SettingsList.Add("LastSuccessfulImage: " & LastSuccessfulImage)
		SettingsList.Add("GetFolder: " & GetFolder)
		SettingsList.Add("FileCount: " & FileCount)
		SettingsList.Add("FileCountMax: " & FileCountMax)
		'SettingsList.Add("_ImageFileNames: " & _ImageFileNames)
		SettingsList.Add("_CurrentImage: " & _CurrentImage)
		SettingsList.Add("WithTeaseImgDir: " & WithTeaseImgDir)
		SettingsList.Add("ApproveImage: " & ApproveImage)
		SettingsList.Add("WIExit: " & WIExit)
		'SettingsList.Add("RecentSlideshows: " & RecentSlideshows)
		SettingsList.Add("MainPictureImage: " & MainPictureImage)
		SettingsList.Add("DomPic: " & DomPic)
		SettingsList.Add("LockImage: " & LockImage)
		'SettingsList.Add("LocalTagImageList: " & LocalTagImageList)
		SettingsList.Add("Crazy: " & Crazy)
		SettingsList.Add("Vulgar: " & Vulgar)
		SettingsList.Add("Supremacist: " & Supremacist)
		SettingsList.Add("CockSize: " & CockSize)
		SettingsList.Add("TempDick: " & TempDick)
		SettingsList.Add("PetName: " & PetName)
		SettingsList.Add("PetName2: " & PetName2)
		SettingsList.Add("TauntText: " & TauntText)
		SettingsList.Add("ScriptCount: " & ScriptCount)
		SettingsList.Add("TempScriptCount: " & TempScriptCount)
		SettingsList.Add("TauntTextCount: " & TauntTextCount)
		SettingsList.Add("StartIndex: " & StartIndex)
		SettingsList.Add("EndIndex: " & EndIndex)
		SettingsList.Add("SlideshowTimerTick: " & SlideshowTimerTick)
		SettingsList.Add("ReadBlog: " & ReadBlog)
		SettingsList.Add("ReadBlogRate: " & ReadBlogRate)
		SettingsList.Add("SearchImageBlog: " & SearchImageBlog)
		SettingsList.Add("FoundString: " & FoundString)
		SettingsList.Add("WebImage: " & WebImage)
		'SettingsList.Add("WebImageLines: " & WebImageLines)
		SettingsList.Add("WebImageLine: " & WebImageLine)
		SettingsList.Add("WebImageLineTotal: " & WebImageLineTotal)
		SettingsList.Add("WebImagePath: " & WebImagePath)
		SettingsList.Add("ImageUrlFilePath: " & ImageUrlFilePath)
		SettingsList.Add("ImageUrlFileIndex: " & ImageUrlFileIndex)
		SettingsList.Add("ReaderString: " & ReaderString)
		SettingsList.Add("ReaderStringTotal: " & ReaderStringTotal)
		SettingsList.Add("StrokePaceInt: " & StrokePaceInt)
		SettingsList.Add("LastScriptCountdown: " & LastScriptCountdown)
		SettingsList.Add("LastScript: " & LastScript)
		SettingsList.Add("JustShowedBlogImage: " & JustShowedBlogImage)
		SettingsList.Add("SaidHello: " & SaidHello)
		SettingsList.Add("StopMetronome: " & StopMetronome)
		SettingsList.Add("AvgEdgeStroking: " & AvgEdgeStroking)
		SettingsList.Add("AvgEdgeNoTouch: " & AvgEdgeNoTouch)
		SettingsList.Add("EdgeCountTick: " & EdgeCountTick)
		SettingsList.Add("AvgEdgeStrokingFlag: " & AvgEdgeStrokingFlag)
		SettingsList.Add("AvgEdgeCount: " & AvgEdgeCount)
		SettingsList.Add("AvgEdgeCountRest: " & AvgEdgeCountRest)
		SettingsList.Add("EdgeTickCheck: " & EdgeTickCheck)
		SettingsList.Add("EdgeNOT: " & EdgeNOT)
		SettingsList.Add("AlreadyStrokingEdge: " & AlreadyStrokingEdge)
		SettingsList.Add("WritingTaskLinesAmount: " & WritingTaskLinesAmount)
		SettingsList.Add("WritingTaskLinesWritten: " & WritingTaskLinesWritten)
		SettingsList.Add("WritingTaskLinesRemaining: " & WritingTaskLinesRemaining)
		SettingsList.Add("WritingTaskMistakesAllowed: " & WritingTaskMistakesAllowed)
		SettingsList.Add("WritingTaskMistakesMade: " & WritingTaskMistakesMade)
		SettingsList.Add("WritingTaskFlag: " & WritingTaskFlag)
		SettingsList.Add("FirstRound: " & FirstRound)
		SettingsList.Add("StartStrokingCount: " & StartStrokingCount)
		SettingsList.Add("TeaseJOI: " & TeaseJOI)
		SettingsList.Add("TeaseVideo: " & TeaseVideo)
		SettingsList.Add("TnAPath: " & TnAPath)
		'SettingsList.Add("TnAList: " & TnAList)
		'SettingsList.Add("BoobList: " & BoobList)
		'SettingsList.Add("AssList: " & AssList)
		SettingsList.Add("AssImage: " & AssImage)
		SettingsList.Add("BoobImage: " & BoobImage)
		SettingsList.Add("FoundTag: " & FoundTag)
		SettingsList.Add("TagGarment: " & TagGarment)
		SettingsList.Add("TagUnderwear: " & TagUnderwear)
		SettingsList.Add("TagTattoo: " & TagTattoo)
		SettingsList.Add("TagSexToy: " & TagSexToy)
		SettingsList.Add("TagFurniture: " & TagFurniture)
		SettingsList.Add("ImportKeyword: " & ImportKeyword)
		SettingsList.Add("BookmarkModule: " & BookmarkModule)
		SettingsList.Add("BookmarkModuleFile: " & BookmarkModuleFile)
		SettingsList.Add("BookmarkModuleLine: " & BookmarkModuleLine)
		SettingsList.Add("BookmarkLink: " & BookmarkLink)
		SettingsList.Add("BookmarkLinkFile: " & BookmarkLinkFile)
		SettingsList.Add("BookmarkLinkLine: " & BookmarkLinkLine)
		SettingsList.Add("WaitTick: " & WaitTick)
		SettingsList.Add("OrgasmDenied: " & OrgasmDenied)
		SettingsList.Add("OrgasmAllowed: " & OrgasmAllowed)
		SettingsList.Add("OrgasmRuined: " & OrgasmRuined)
		SettingsList.Add("StupidTick: " & StupidTick)
		SettingsList.Add("StupidFlag: " & StupidFlag)
		SettingsList.Add("CaloriesConsumed: " & CaloriesConsumed)
		SettingsList.Add("CaloriesGoal: " & CaloriesGoal)
		SettingsList.Add("GoldTokens: " & GoldTokens)
		SettingsList.Add("SilverTokens: " & SilverTokens)
		SettingsList.Add("BronzeTokens: " & BronzeTokens)
		SettingsList.Add("EdgeFound: " & EdgeFound)
		SettingsList.Add("OrgasmYesNo: " & OrgasmYesNo)
		SettingsList.Add("VTFlag: " & VTFlag)
		SettingsList.Add("DomPersonality: " & DomPersonality)
		'SettingsList.Add("UpdateList: " & UpdateList)
		SettingsList.Add("GlitterDocument: " & GlitterDocument)
		SettingsList.Add("CustomSlideshow: " & CustomSlideshow)
		SettingsList.Add("CustomSlideshowTick: " & CustomSlideshowTick)
		'SettingsList.Add("CustomSlideshowList: " & CustomSlideshowList)
		SettingsList.Add("ImageString: " & ImageString)
		SettingsList.Add("RapidFire: " & RapidFire)
		SettingsList.Add("GlitterTease: " & GlitterTease)
		SettingsList.Add("AddContactTick: " & AddContactTick)
		'SettingsList.Add("Contact1Pics: " & Contact1Pics)
		'SettingsList.Add("Contact2Pics: " & Contact2Pics)
		'SettingsList.Add("Contact3Pics: " & Contact3Pics)
		SettingsList.Add("Contact1PicsCount: " & Contact1PicsCount)
		SettingsList.Add("Contact2PicsCount: " & Contact2PicsCount)
		SettingsList.Add("Contact3PicsCount: " & Contact3PicsCount)
		SettingsList.Add("Group: " & Group)
		SettingsList.Add("CustomTask: " & CustomTask)
		SettingsList.Add("CustomTaskFirst: " & CustomTaskFirst)
		SettingsList.Add("CustomTaskText: " & CustomTaskText)
		SettingsList.Add("CustomTaskTextFirst: " & CustomTaskTextFirst)
		SettingsList.Add("CustomTaskActive: " & CustomTaskActive)
		SettingsList.Add("SubtitleCount: " & SubtitleCount)
		SettingsList.Add("VidFile: " & VidFile)

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
		SettingsList.Add("StrokePaceTimer Enabled: " & StrokePaceTimer.Enabled)
		SettingsList.Add("EdgeTauntTimer Enabled: " & EdgeTauntTimer.Enabled)
		SettingsList.Add("HoldEdgeTimer Enabled: " & HoldEdgeTimer.Enabled)
		SettingsList.Add("HoldEdgeTauntTimer Enabled: " & HoldEdgeTauntTimer.Enabled)
		SettingsList.Add("Contact1Timer Enabled: " & Contact1Timer.Enabled)
		SettingsList.Add("Contact2Timer Enabled: " & Contact2Timer.Enabled)
		SettingsList.Add("Contact3Timer Enabled: " & Contact3Timer.Enabled)
		SettingsList.Add("UpdateStageTimer Enabled: " & UpdateStageTimer.Enabled)
		SettingsList.Add("WMPTimer Enabled: " & WMPTimer.Enabled)

		'SettingsList.Add("PlaylistFile: " & PlaylistFile)

		SettingsList.Add("Chat: " & Chat)

		If mainPictureBox.Visible = True Then
			SettingsList.Add("MainWindow: Image")
		Else
			SettingsList.Add("MainWindow: Video")
		End If

		SettingsList.Add("DomWMP URL: " & DomWMP.URL)
		SettingsList.Add("DomWMP Position: " & DomWMP.Ctlcontrols.currentPosition)
		SettingsList.Add("DomWMP PlayState: " & DomWMP.playState)

		SettingsList.Add("RiskyDeal: " & RiskyDeal)
		SettingsList.Add("RiskyEdges: " & RiskyEdges)
		SettingsList.Add("RiskyDelay: " & RiskyDelay)
		SettingsList.Add("FinalRiskyPick: " & FinalRiskyPick)

		SettingsList.Add("SysMes: " & SysMes)
		SettingsList.Add("EmoMes: " & EmoMes)

		SettingsList.Add("Contact1Edge: " & Contact1Edge)
		SettingsList.Add("Contact2Edge: " & Contact2Edge)
		SettingsList.Add("Contact3Edge: " & Contact3Edge)

		SettingsList.Add("Contact1Stroke: " & Contact1Stroke)
		SettingsList.Add("Contact2Stroke: " & Contact2Stroke)
		SettingsList.Add("Contact3Stroke: " & Contact3Stroke)

		SettingsList.Add("ReturnFileText: " & ReturnFileText)
		SettingsList.Add("ReturnStrokeTauntVal: " & ReturnStrokeTauntVal)
		SettingsList.Add("ReturnSubState: " & ReturnSubState)
		SettingsList.Add("ReturnFlag: " & ReturnFlag)

		SettingsList.Add("SessionEdges: " & SessionEdges)
		SettingsList.Add("WindowCheck: " & WindowCheck)
		SettingsList.Add("StrokeFaster: " & StrokeFaster)
		SettingsList.Add("StrokeFastest: " & StrokeFastest)
		SettingsList.Add("StrokeSlower: " & StrokeSlower)
		SettingsList.Add("StrokeSlowest: " & StrokeSlowest)

		SettingsList.Add("InputFlag: " & InputFlag)
		SettingsList.Add("InputString: " & InputString)
		SettingsList.Add("RapidCode: " & RapidCode)
		SettingsList.Add("CorrectedTypo: " & CorrectedTypo)
		SettingsList.Add("CorrectedWord: " & CorrectedWord)
		SettingsList.Add("DoNotDisturb: " & DoNotDisturb)
		SettingsList.Add("TypoSwitch: " & TypoSwitch)
		SettingsList.Add("TyposDisabled: " & TyposDisabled)
		SettingsList.Add("EdgeHoldSeconds: " & EdgeHoldSeconds)
		SettingsList.Add("EdgeHoldFlag: " & EdgeHoldFlag)
		SettingsList.Add("SlideshowInt: " & SlideshowInt)
		SettingsList.Add("JustShowedSlideshowImage: " & JustShowedSlideshowImage)
		SettingsList.Add("DeleteLocalImageFilePath: " & DeleteLocalImageFilePath)
		SettingsList.Add("RandomSlideshowCategory: " & RandomSlideshowCategory)
		SettingsList.Add("ResetFlag: " & ResetFlag)
		SettingsList.Add("DommeTags: " & DommeTags)
		SettingsList.Add("ThemeSettings: " & ThemeSettings)
		SettingsList.Add("InputIcon: " & InputIcon)
		SettingsList.Add("ApplyingTheme: " & ApplyingTheme)
		SettingsList.Add("AdjustingWindow: " & AdjustingWindow)
		SettingsList.Add("SplitContainerHeight: " & SplitContainerHeight)
		SettingsList.Add("DommeImageFound: " & DommeImageFound)
		SettingsList.Add("DommeImageListCheck: " & DommeImageListCheck)
		SettingsList.Add("LocalImageFound: " & LocalImageFound)
		SettingsList.Add("LocalImageListCheck: " & LocalImageListCheck)
		SettingsList.Add("CBTBothActive: " & CBTBothActive)
		SettingsList.Add("CBTBothFlag: " & CBTBothFlag)
		SettingsList.Add("CBTBothCount: " & CBTBothCount)
		SettingsList.Add("CBTBothFirst: " & CBTBothFirst)
		SettingsList.Add("MetroGet: " & MetroGet)
		SettingsList.Add("GeneralTime: " & GeneralTime)
		SettingsList.Add("NewDommeSlideshow: " & NewDommeSlideshow)
		SettingsList.Add("OriginalDommeSlideshow: " & OriginalDommeSlideshow)
		SettingsList.Add("TimeoutTick: " & TimeoutTick)
		SettingsList.Add("PBImage: " & PBImage)
		SettingsList.Add("DommeImageSTR: " & DommeImageSTR)
		SettingsList.Add("LocalImageSTR: " & LocalImageSTR)
		SettingsList.Add("ImageLocation: " & ImageLocation)



		' WMPLib.WMPPlayState.wmppsStopped)

		Dim SettingsString As String = ""

		For i As Integer = 0 To SettingsList.Count - 1
			SettingsString = SettingsString & SettingsList(i)
			If i <> SettingsList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
		Next

		Dim ResumeState As String
		Dim ResumePrefix As String

		If ResetFlag = False Then
			ResumeState = "SavedState.txt"
			ResumePrefix = "Sus"
		Else
			ResumeState = "ResetState.txt"
			ResumePrefix = "Res"
		End If

		My.Computer.FileSystem.WriteAllText(SettingsPath & ResumeState, SettingsString, False)

		If PlaylistFile.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To PlaylistFile.Count - 1
				SettingsString = SettingsString & PlaylistFile(i)
				If i <> PlaylistFile.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "PlayListFile.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "PlayListFile.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "PlayListFile.txt")
		End If

		If TauntLines.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To TauntLines.Count - 1
				SettingsString = SettingsString & TauntLines(i)
				If i <> TauntLines.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "TauntLines.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "TauntLines.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "TauntLines.txt")
		End If

		If _ImageFileNames.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To _ImageFileNames.Count - 1
				SettingsString = SettingsString & _ImageFileNames(i)
				If i <> _ImageFileNames.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "_ImageFileNames.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "_ImageFileNames.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "_ImageFileNames.txt")
		End If

		If RecentSlideshows.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To RecentSlideshows.Count - 1
				SettingsString = SettingsString & RecentSlideshows(i)
				If i <> RecentSlideshows.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "RecentSlideshows.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "RecentSlideshows.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "RecentSlideshows.txt")
		End If

		If LocalTagImageList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To LocalTagImageList.Count - 1
				SettingsString = SettingsString & LocalTagImageList(i)
				If i <> LocalTagImageList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "LocalTagImageList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "LocalTagImageList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "LocalTagImageList.txt")
		End If

		If WebImageLines.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To WebImageLines.Count - 1
				SettingsString = SettingsString & WebImageLines(i)
				If i <> WebImageLines.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "WebImageLines.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "WebImageLines.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "WebImageLines.txt")
		End If

		If TnAList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To TnAList.Count - 1
				SettingsString = SettingsString & TnAList(i)
				If i <> TnAList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "TnAList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "TnAList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "TnAList.txt")
		End If

		If BoobList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To BoobList.Count - 1
				SettingsString = SettingsString & BoobList(i)
				If i <> BoobList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "BoobList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "BoobList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "BoobList.txt")
		End If

		If AssList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To AssList.Count - 1
				SettingsString = SettingsString & AssList(i)
				If i <> AssList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "AssList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "AssList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "AssList.txt")
		End If

		If UpdateList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To UpdateList.Count - 1
				SettingsString = SettingsString & UpdateList(i)
				If i <> UpdateList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "UpdateList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "UpdateList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "UpdateList.txt")
		End If

		If CustomSlideshowList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To CustomSlideshowList.Count - 1
				SettingsString = SettingsString & CustomSlideshowList(i)
				If i <> CustomSlideshowList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "CustomSlideshowList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "CustomSlideshowList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "CustomSlideshowList.txt")
		End If

		If Contact1Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To Contact1Pics.Count - 1
				SettingsString = SettingsString & Contact1Pics(i)
				If i <> Contact1Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact1Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact1Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact1Pics.txt")
		End If

		If Contact2Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To Contact2Pics.Count - 1
				SettingsString = SettingsString & Contact2Pics(i)
				If i <> Contact2Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact2Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact2Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact2Pics.txt")
		End If

		If Contact3Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To Contact3Pics.Count - 1
				SettingsString = SettingsString & Contact3Pics(i)
				If i <> Contact3Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact3Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact3Pics.txt")
		End If

		ResetFlag = False


	End Sub

	Public Sub ResumeSession()

		Dim SettingsPath As String = Application.StartupPath & "\System\"
		Dim SettingsList As New List(Of String)

		Dim ResumeState As String
		Dim ResumePrefix As String

		If ResetFlag = False Then
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

		ScriptOperator = SettingsList(1).Replace("ScriptOperator: ", "")
		ScriptCompare = SettingsList(2).Replace("ScriptCompare: ", "")
		DomTyping = SettingsList(3).Replace("DomTyping: ", "")
		CheckYes = SettingsList(4).Replace("CheckYes: ", "")
		CheckNo = SettingsList(5).Replace("CheckNo: ", "")
		Playlist = SettingsList(6).Replace("Playlist: ", "")
		PlaylistCurrent = SettingsList(7).Replace("PlaylistCurrent: ", "")
		SubInChastity = SettingsList(8).Replace("SubInChastity: ", "")
		FormLoading = SettingsList(9).Replace("FormLoading: ", "")
		RandomDelay = SettingsList(10).Replace("RandomDelay: ", "")
		Responding = SettingsList(11).Replace("Responding: ", "")
		ScriptLineVal = SettingsList(12).Replace("ScriptLineVal: ", "")
		StrokeTauntVal = SettingsList(13).Replace("StrokeTauntVal: ", "")
		ThoughtTauntVal = SettingsList(14).Replace("ThoughtTauntVal: ", "")
		ModuleTauntVal = SettingsList(15).Replace("ModuleTauntVal: ", "")
		FileText = SettingsList(16).Replace("FileText: ", "")
		TempStrokeTauntVal = SettingsList(17).Replace("TempStrokeTauntVal: ", "")
		TempFileText = SettingsList(18).Replace("TempFileText: ", "")
		ModText = SettingsList(19).Replace("ModText: ", "")
		TeaseTick = SettingsList(20).Replace("TeaseTick: ", "")
		StrokeTauntCount = SettingsList(21).Replace("StrokeTauntCount: ", "")
		TauntTextTotal = SettingsList(22).Replace("TauntTextTotal: ", "")
		StrokeFilter = SettingsList(23).Replace("StrokeFilter: ", "")
		ScriptTick = SettingsList(24).Replace("ScriptTick: ", "")
		StringLength = SettingsList(25).Replace("StringLength: ", "")
		FileGoto = SettingsList(26).Replace("FileGoto: ", "")
		SkipGotoLine = SettingsList(27).Replace("SkipGotoLine: ", "")
		HandleScriptText = SettingsList(28).Replace("HandleScriptText: ", "")
		ChatString = SettingsList(29).Replace("ChatString: ", "")
		DomTask = SettingsList(30).Replace("DomTask: ", "")
		DomChat = SettingsList(31).Replace("DomChat: ", "")
		TypeDelay = SettingsList(32).Replace("TypeDelay: ", "")
		TempVal = SettingsList(33).Replace("TempVal: ", "")
		NullResponse = SettingsList(34).Replace("NullResponse: ", "")
		CleanFlag = SettingsList(35).Replace("CleanFlag: ", "")
		DebugAwarenessLine = SettingsList(36).Replace("DebugAwarenessLine: ", "")
		TagCount = SettingsList(37).Replace("TagCount: ", "")
		LocalTagCount = SettingsList(38).Replace("LocalTagCount: ", "")
		OrgasmResult = SettingsList(39).Replace("OrgasmResult: ", "")
		BeggedOrgasmDecision = SettingsList(40).Replace("BeggedOrgasmDecision: ", "")
		TeaseOver = SettingsList(41).Replace("TeaseOver: ", "")
		TaskFile = SettingsList(42).Replace("TaskFile: ", "")
		TaskText = SettingsList(43).Replace("TaskText: ", "")
		TaskTextDir = SettingsList(44).Replace("TaskTextDir: ", "")
		ResponseFile = SettingsList(45).Replace("ResponseFile: ", "")
		ResponseLine = SettingsList(46).Replace("ResponseLine: ", "")
		CBTCockActive = SettingsList(47).Replace("CBTCockActive: ", "")
		CBTBallsActive = SettingsList(48).Replace("CBTBallsActive: ", "")
		CBTCockFlag = SettingsList(49).Replace("CBTCockFlag: ", "")
		CBTBallsFlag = SettingsList(50).Replace("CBTBallsFlag: ", "")
		CBTBallsFirst = SettingsList(51).Replace("CBTBallsFirst: ", "")
		CBTCockFirst = SettingsList(52).Replace("CBTCockFirst: ", "")
		CBTBallsCount = SettingsList(53).Replace("CBTBallsCount: ", "")
		CBTCockCount = SettingsList(54).Replace("CBTCockCount: ", "")
		ThoughtCount = SettingsList(55).Replace("ThoughtCount: ", "")
		GotoDommeLevel = SettingsList(56).Replace("GotoDommeLevel: ", "")
		DommeMood = SettingsList(57).Replace("DommeMood: ", "")
		AFK = SettingsList(58).Replace("AFK: ", "")
		HypnoGen = SettingsList(59).Replace("HypnoGen: ", "")
		Induction = SettingsList(60).Replace("Induction: ", "")
		TempHypno = SettingsList(61).Replace("TempHypno: ", "")
		DomColor = SettingsList(62).Replace("DomColor: ", "")
		SubColor = SettingsList(63).Replace("SubColor: ", "")
		StrokeCycle = SettingsList(64).Replace("StrokeCycle: ", "")
		StrokeTick = SettingsList(65).Replace("StrokeTick: ", "")
		StrokeTauntTick = SettingsList(66).Replace("StrokeTauntTick: ", "")
		StrokePaceRight = SettingsList(67).Replace("StrokePaceRight: ", "")
		StrokePace = SettingsList(68).Replace("StrokePace: ", "")
		AudibleTick = SettingsList(69).Replace("AudibleTick: ", "")
		StrokeTimeTotal = SettingsList(70).Replace("StrokeTimeTotal: ", "")
		HoldEdgeTime = SettingsList(71).Replace("HoldEdgeTime: ", "")
		HoldEdgeTimeTotal = SettingsList(72).Replace("HoldEdgeTimeTotal: ", "")
		EdgeTauntInt = SettingsList(73).Replace("EdgeTauntInt: ", "")
		DelayTick = SettingsList(74).Replace("DelayTick: ", "")
		DelayFlag = SettingsList(75).Replace("DelayFlag: ", "")
		PreCleanString = SettingsList(76).Replace("PreCleanString: ", "")
		DomTypeCheck = SettingsList(77).Replace("DomTypeCheck: ", "")
		TypeToggle = SettingsList(78).Replace("TypeToggle: ", "")
		IsTyping = SettingsList(79).Replace("IsTyping: ", "")
		SubWroteLast = SettingsList(80).Replace("SubWroteLast: ", "")
		YesOrNo = SettingsList(81).Replace("YesOrNo: ", "")
		GotoFlag = SettingsList(82).Replace("GotoFlag: ", "")
		LoopAnswer = SettingsList(83).Replace("LoopAnswer: ", "")
		CBT = SettingsList(84).Replace("CBT: ", "")
		NoEdge = SettingsList(85).Replace("NoEdge: ", "")
		RunningScript = SettingsList(86).Replace("RunningScript: ", "")
		RePound = SettingsList(87).Replace("RePound: ", "")
		BeforeTease = SettingsList(88).Replace("BeforeTease: ", "")
		SubStroking = SettingsList(89).Replace("SubStroking: ", "")
		SubEdging = SettingsList(90).Replace("SubEdging: ", "")
		SubHoldingEdge = SettingsList(91).Replace("SubHoldingEdge: ", "")
		SubCBT = SettingsList(92).Replace("SubCBT: ", "")
		EndTease = SettingsList(93).Replace("EndTease: ", "")
		ShowThought = SettingsList(94).Replace("ShowThought: ", "")
		ShowEdgeThought = SettingsList(95).Replace("ShowEdgeThought: ", "")
		ShowModule = SettingsList(96).Replace("ShowModule: ", "")
		ModuleEnd = SettingsList(97).Replace("ModuleEnd: ", "")
		DivideText = SettingsList(98).Replace("DivideText: ", "")
		HoldEdgeTick = SettingsList(99).Replace("HoldEdgeTick: ", "")
		HoldEdgeChance = SettingsList(100).Replace("HoldEdgeChance: ", "")
		EdgeHold = SettingsList(101).Replace("EdgeHold: ", "")
		EdgeNoHold = SettingsList(102).Replace("EdgeNoHold: ", "")
		EdgeToRuin = SettingsList(103).Replace("EdgeToRuin: ", "")
		EdgeToRuinSecret = SettingsList(104).Replace("EdgeToRuinSecret: ", "")
		LongEdge = SettingsList(105).Replace("LongEdge: ", "")
		AskedToGiveUp = SettingsList(106).Replace("AskedToGiveUp: ", "")
		AskedToGiveUpSection = SettingsList(107).Replace("AskedToGiveUpSection: ", "")
		SubGaveUp = SettingsList(108).Replace("SubGaveUp: ", "")
		AskedToSpeedUp = SettingsList(109).Replace("AskedToSpeedUp: ", "")
		AskedToSlowDown = SettingsList(110).Replace("AskedToSlowDown: ", "")
		ThoughtEnd = SettingsList(111).Replace("ThoughtEnd: ", "")
		VTLength = SettingsList(112).Replace("VTLength: ", "")
		DommeVideo = SettingsList(113).Replace("DommeVideo: ", "")
		VideoType = SettingsList(114).Replace("VideoType: ", "")
		CensorshipGame = SettingsList(115).Replace("CensorshipGame: ", "")
		CensorshipTick = SettingsList(116).Replace("CensorshipTick: ", "")
		CensorDuration = SettingsList(117).Replace("CensorDuration: ", "")
		AvoidTheEdgeGame = SettingsList(118).Replace("AvoidTheEdgeGame: ", "")
		AvoidTheEdgeTick = SettingsList(119).Replace("AvoidTheEdgeTick: ", "")
		AvoidTheEdgeTimerTick = SettingsList(120).Replace("AvoidTheEdgeTimerTick: ", "")
		AvoidTheEdgeDuration = SettingsList(121).Replace("AvoidTheEdgeDuration: ", "")
		AvoidTheEdgeStroking = SettingsList(122).Replace("AvoidTheEdgeStroking: ", "")
		AtECountdown = SettingsList(123).Replace("AtECountdown: ", "")
		VTPath = SettingsList(124).Replace("VTPath: ", "")
		NoVideo = SettingsList(125).Replace("NoVideo: ", "")
		NoSpecialVideo = SettingsList(126).Replace("NoSpecialVideo: ", "")
		VideoCheck = SettingsList(127).Replace("VideoCheck: ", "")
		VideoTease = SettingsList(128).Replace("VideoTease: ", "")
		RLGLGame = SettingsList(129).Replace("RLGLGame: ", "")
		RLGLStroking = SettingsList(130).Replace("RLGLStroking: ", "")
		RLGLTick = SettingsList(131).Replace("RLGLTick: ", "")
		RedLight = SettingsList(132).Replace("RedLight: ", "")
		RLGLTauntTick = SettingsList(133).Replace("RLGLTauntTick: ", "")
		RandomizerVideo = SettingsList(134).Replace("RandomizerVideo: ", "")
		RandomizerVideoTease = SettingsList(135).Replace("RandomizerVideoTease: ", "")
		ScriptVideoTease = SettingsList(136).Replace("ScriptVideoTease: ", "")
		ScriptVideoTeaseFlag = SettingsList(137).Replace("ScriptVideoTeaseFlag: ", "")
		VideoTauntTick = SettingsList(138).Replace("VideoTauntTick: ", "")
		SlideshowLoaded = SettingsList(139).Replace("SlideshowLoaded: ", "")
		RefreshVideoTotal = SettingsList(140).Replace("RefreshVideoTotal: ", "")
		GlitterImageAV = SettingsList(141).Replace("GlitterImageAV: ", "")
		GlitterNCDomme = SettingsList(142).Replace("GlitterNCDomme: ", "")
		GlitterNC1 = SettingsList(143).Replace("GlitterNC1: ", "")
		GlitterNC2 = SettingsList(144).Replace("GlitterNC2: ", "")
		GlitterNC3 = SettingsList(145).Replace("GlitterNC3: ", "")
		GlitterTempColor = SettingsList(146).Replace("GlitterTempColor: ", "")
		UpdatesTick = SettingsList(147).Replace("UpdatesTick: ", "")
		UpdatingPost = SettingsList(148).Replace("UpdatingPost: ", "")
		UpdateStage = SettingsList(149).Replace("UpdateStage: ", "")
		UpdateStageTick = SettingsList(150).Replace("UpdateStageTick: ", "")
		StatusText = SettingsList(151).Replace("StatusText: ", "")
		ContactNumber = SettingsList(152).Replace("ContactNumber: ", "")
		ContactTick = SettingsList(153).Replace("ContactTick: ", "")
		ContactFlag = SettingsList(154).Replace("ContactFlag: ", "")
		StatusText1 = SettingsList(155).Replace("StatusText1: ", "")
		StatusText2 = SettingsList(156).Replace("StatusText2: ", "")
		StatusText3 = SettingsList(157).Replace("StatusText3: ", "")
		StatusChance1 = SettingsList(158).Replace("StatusChance1: ", "")
		StatusChance2 = SettingsList(159).Replace("StatusChance2: ", "")
		StatusChance3 = SettingsList(160).Replace("StatusChance3: ", "")
		Update1 = SettingsList(161).Replace("Update1: ", "")
		Update2 = SettingsList(162).Replace("Update2: ", "")
		Update3 = SettingsList(163).Replace("Update3: ", "")
		LastSuccessfulImage = SettingsList(164).Replace("LastSuccessfulImage: ", "")
		GetFolder = SettingsList(165).Replace("GetFolder: ", "")
		FileCount = SettingsList(166).Replace("FileCount: ", "")
		FileCountMax = SettingsList(167).Replace("FileCountMax: ", "")
		_CurrentImage = SettingsList(168).Replace("_CurrentImage: ", "")
		WithTeaseImgDir = SettingsList(169).Replace("WithTeaseImgDir: ", "")
		ApproveImage = SettingsList(170).Replace("ApproveImage: ", "")
		WIExit = SettingsList(171).Replace("WIExit: ", "")
		MainPictureImage = SettingsList(172).Replace("MainPictureImage: ", "")
		DomPic = SettingsList(173).Replace("DomPic: ", "")
		LockImage = SettingsList(174).Replace("LockImage: ", "")
		Crazy = SettingsList(175).Replace("Crazy: ", "")
		Vulgar = SettingsList(176).Replace("Vulgar: ", "")
		Supremacist = SettingsList(177).Replace("Supremacist: ", "")
		CockSize = SettingsList(178).Replace("CockSize: ", "")
		TempDick = SettingsList(179).Replace("TempDick: ", "")
		PetName = SettingsList(180).Replace("PetName: ", "")
		PetName2 = SettingsList(181).Replace("PetName2: ", "")
		TauntText = SettingsList(182).Replace("TauntText: ", "")
		ScriptCount = SettingsList(183).Replace("ScriptCount: ", "")
		TempScriptCount = SettingsList(184).Replace("TempScriptCount: ", "")
		TauntTextCount = SettingsList(185).Replace("TauntTextCount: ", "")
		StartIndex = SettingsList(186).Replace("StartIndex: ", "")
		EndIndex = SettingsList(187).Replace("EndIndex: ", "")
		SlideshowTimerTick = SettingsList(188).Replace("SlideshowTimerTick: ", "")
		ReadBlog = SettingsList(189).Replace("ReadBlog: ", "")
		ReadBlogRate = SettingsList(190).Replace("ReadBlogRate: ", "")
		SearchImageBlog = SettingsList(191).Replace("SearchImageBlog: ", "")
		FoundString = SettingsList(192).Replace("FoundString: ", "")
		WebImage = SettingsList(193).Replace("WebImage: ", "")
		WebImageLine = SettingsList(194).Replace("WebImageLine: ", "")
		WebImageLineTotal = SettingsList(195).Replace("WebImageLineTotal: ", "")
		WebImagePath = SettingsList(196).Replace("WebImagePath: ", "")
		ImageUrlFilePath = SettingsList(197).Replace("ImageUrlFilePath: ", "")
		ImageUrlFileIndex = SettingsList(198).Replace("ImageUrlFileIndex: ", "")
		ReaderString = SettingsList(199).Replace("ReaderString: ", "")
		ReaderStringTotal = SettingsList(200).Replace("ReaderStringTotal: ", "")
		StrokePaceInt = SettingsList(201).Replace("StrokePaceInt: ", "")
		LastScriptCountdown = SettingsList(202).Replace("LastScriptCountdown: ", "")
		LastScript = SettingsList(203).Replace("LastScript: ", "")
		JustShowedBlogImage = SettingsList(204).Replace("JustShowedBlogImage: ", "")
		SaidHello = SettingsList(205).Replace("SaidHello: ", "")
		StopMetronome = SettingsList(206).Replace("StopMetronome: ", "")
		AvgEdgeStroking = SettingsList(207).Replace("AvgEdgeStroking: ", "")
		AvgEdgeNoTouch = SettingsList(208).Replace("AvgEdgeNoTouch: ", "")
		EdgeCountTick = SettingsList(209).Replace("EdgeCountTick: ", "")
		AvgEdgeStrokingFlag = SettingsList(210).Replace("AvgEdgeStrokingFlag: ", "")
		AvgEdgeCount = SettingsList(211).Replace("AvgEdgeCount: ", "")
		AvgEdgeCountRest = SettingsList(212).Replace("AvgEdgeCountRest: ", "")
		EdgeTickCheck = SettingsList(213).Replace("EdgeTickCheck: ", "")
		EdgeNOT = SettingsList(214).Replace("EdgeNOT: ", "")
		AlreadyStrokingEdge = SettingsList(215).Replace("AlreadyStrokingEdge: ", "")
		WritingTaskLinesAmount = SettingsList(216).Replace("WritingTaskLinesAmount: ", "")
		WritingTaskLinesWritten = SettingsList(217).Replace("WritingTaskLinesWritten: ", "")
		WritingTaskLinesRemaining = SettingsList(218).Replace("WritingTaskLinesRemaining: ", "")
		WritingTaskMistakesAllowed = SettingsList(219).Replace("WritingTaskMistakesAllowed: ", "")
		WritingTaskMistakesMade = SettingsList(220).Replace("WritingTaskMistakesMade: ", "")
		WritingTaskFlag = SettingsList(221).Replace("WritingTaskFlag: ", "")
		FirstRound = SettingsList(222).Replace("FirstRound: ", "")
		StartStrokingCount = SettingsList(223).Replace("StartStrokingCount: ", "")
		TeaseJOI = SettingsList(224).Replace("TeaseJOI: ", "")
		TeaseVideo = SettingsList(225).Replace("TeaseVideo: ", "")
		TnAPath = SettingsList(226).Replace("TnAPath: ", "")
		AssImage = SettingsList(227).Replace("AssImage: ", "")
		BoobImage = SettingsList(228).Replace("BoobImage: ", "")
		FoundTag = SettingsList(229).Replace("FoundTag: ", "")
		TagGarment = SettingsList(230).Replace("TagGarment: ", "")
		TagUnderwear = SettingsList(231).Replace("TagUnderwear: ", "")
		TagTattoo = SettingsList(232).Replace("TagTattoo: ", "")
		TagSexToy = SettingsList(233).Replace("TagSexToy: ", "")
		TagFurniture = SettingsList(234).Replace("TagFurniture: ", "")
		ImportKeyword = SettingsList(235).Replace("ImportKeyword: ", "")
		BookmarkModule = SettingsList(236).Replace("BookmarkModule: ", "")
		BookmarkModuleFile = SettingsList(237).Replace("BookmarkModuleFile: ", "")
		BookmarkModuleLine = SettingsList(238).Replace("BookmarkModuleLine: ", "")
		BookmarkLink = SettingsList(239).Replace("BookmarkLink: ", "")
		BookmarkLinkFile = SettingsList(240).Replace("BookmarkLinkFile: ", "")
		BookmarkLinkLine = SettingsList(241).Replace("BookmarkLinkLine: ", "")
		WaitTick = SettingsList(242).Replace("WaitTick: ", "")
		OrgasmDenied = SettingsList(243).Replace("OrgasmDenied: ", "")
		OrgasmAllowed = SettingsList(244).Replace("OrgasmAllowed: ", "")
		OrgasmRuined = SettingsList(245).Replace("OrgasmRuined: ", "")
		StupidTick = SettingsList(246).Replace("StupidTick: ", "")
		StupidFlag = SettingsList(247).Replace("StupidFlag: ", "")
		CaloriesConsumed = SettingsList(248).Replace("CaloriesConsumed: ", "")
		CaloriesGoal = SettingsList(249).Replace("CaloriesGoal: ", "")
		GoldTokens = SettingsList(250).Replace("GoldTokens: ", "")
		SilverTokens = SettingsList(251).Replace("SilverTokens: ", "")
		BronzeTokens = SettingsList(252).Replace("BronzeTokens: ", "")
		EdgeFound = SettingsList(253).Replace("EdgeFound: ", "")
		OrgasmYesNo = SettingsList(254).Replace("OrgasmYesNo: ", "")
		VTFlag = SettingsList(255).Replace("VTFlag: ", "")
		DomPersonality = SettingsList(256).Replace("DomPersonality: ", "")
		GlitterDocument = SettingsList(257).Replace("GlitterDocument: ", "")
		CustomSlideshow = SettingsList(258).Replace("CustomSlideshow: ", "")
		CustomSlideshowTick = SettingsList(259).Replace("CustomSlideshowTick: ", "")
		ImageString = SettingsList(260).Replace("ImageString: ", "")
		RapidFire = SettingsList(261).Replace("RapidFire: ", "")
		GlitterTease = SettingsList(262).Replace("GlitterTease: ", "")
		AddContactTick = SettingsList(263).Replace("AddContactTick: ", "")
		Contact1PicsCount = SettingsList(264).Replace("Contact1PicsCount: ", "")
		Contact2PicsCount = SettingsList(265).Replace("Contact2PicsCount: ", "")
		Contact3PicsCount = SettingsList(266).Replace("Contact3PicsCount: ", "")
		Group = SettingsList(267).Replace("Group: ", "")
		CustomTask = SettingsList(268).Replace("CustomTask: ", "")
		CustomTaskFirst = SettingsList(269).Replace("CustomTaskFirst: ", "")
		CustomTaskText = SettingsList(270).Replace("CustomTaskText: ", "")
		CustomTaskTextFirst = SettingsList(271).Replace("CustomTaskTextFirst: ", "")
		CustomTaskActive = SettingsList(272).Replace("CustomTaskActive: ", "")
		SubtitleCount = SettingsList(273).Replace("SubtitleCount: ", "")
		VidFile = SettingsList(274).Replace("VidFile: ", "")

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
		StrokePaceTimer.Enabled = SettingsList(299).Replace("StrokePaceTimer Enabled: ", "")
		EdgeTauntTimer.Enabled = SettingsList(300).Replace("EdgeTauntTimer Enabled: ", "")
		HoldEdgeTimer.Enabled = SettingsList(301).Replace("HoldEdgeTimer Enabled: ", "")
		HoldEdgeTauntTimer.Enabled = SettingsList(302).Replace("HoldEdgeTauntTimer Enabled: ", "")
		Contact1Timer.Enabled = SettingsList(303).Replace("Contact1Timer Enabled: ", "")
		Contact2Timer.Enabled = SettingsList(304).Replace("Contact2Timer Enabled: ", "")
		Contact3Timer.Enabled = SettingsList(305).Replace("Contact3Timer Enabled: ", "")
		UpdateStageTimer.Enabled = SettingsList(306).Replace("UpdateStageTimer Enabled: ", "")
		WMPTimer.Enabled = SettingsList(307).Replace("WMPTimer Enabled: ", "")
		Chat = SettingsList(308).Replace("Chat: ", "")

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


		RiskyDeal = SettingsList(313).Replace("RiskyDeal: ", "")
		RiskyEdges = SettingsList(314).Replace("RiskyEdges: ", "")
		RiskyDelay = SettingsList(315).Replace("RiskyDelay: ", "")
		FinalRiskyPick = SettingsList(316).Replace("FinalRiskyPick: ", "")
		SysMes = SettingsList(317).Replace("SysMes: ", "")
		EmoMes = SettingsList(318).Replace("EmoMes: ", "")
		Contact1Edge = SettingsList(319).Replace("Contact1Edge: ", "")
		Contact2Edge = SettingsList(320).Replace("Contact2Edge: ", "")
		Contact3Edge = SettingsList(321).Replace("Contact3Edge: ", "")
		Contact1Stroke = SettingsList(322).Replace("Contact1Stroke: ", "")
		Contact2Stroke = SettingsList(323).Replace("Contact2Stroke: ", "")
		Contact3Stroke = SettingsList(324).Replace("Contact3Stroke: ", "")
		ReturnFileText = SettingsList(325).Replace("ReturnFileText: ", "")
		ReturnStrokeTauntVal = SettingsList(326).Replace("ReturnStrokeTauntVal: ", "")
		ReturnSubState = SettingsList(327).Replace("ReturnSubState: ", "")
		ReturnFlag = SettingsList(328).Replace("ReturnFlag: ", "")

		SessionEdges = SettingsList(329).Replace("SessionEdges: ", "")
		WindowCheck = SettingsList(330).Replace("WindowCheck: ", "")
		StrokeFaster = SettingsList(331).Replace("StrokeFaster: ", "")
		StrokeFastest = SettingsList(332).Replace("StrokeFastest: ", "")
		StrokeSlower = SettingsList(333).Replace("StrokeSlower: ", "")
		StrokeSlowest = SettingsList(334).Replace("StrokeSlowest: ", "")


		InputFlag = SettingsList(335).Replace("InputFlag: ", "")
		InputString = SettingsList(336).Replace("InputString: ", "")
		RapidCode = SettingsList(337).Replace("RapidCode: ", "")
		CorrectedTypo = SettingsList(338).Replace("CorrectedTypo: ", "")
		CorrectedWord = SettingsList(339).Replace("CorrectedWord: ", "")
		DoNotDisturb = SettingsList(340).Replace("DoNotDisturb: ", "")
		TypoSwitch = SettingsList(341).Replace("TypoSwitch: ", "")
		TyposDisabled = SettingsList(342).Replace("TyposDisabled: ", "")
		EdgeHoldSeconds = SettingsList(343).Replace("EdgeHoldSeconds: ", "")
		EdgeHoldFlag = SettingsList(344).Replace("EdgeHoldFlag: ", "")
		SlideshowInt = SettingsList(345).Replace("SlideshowInt: ", "")
		JustShowedSlideshowImage = SettingsList(346).Replace("JustShowedSlideshowImage: ", "")
		DeleteLocalImageFilePath = SettingsList(347).Replace("DeleteLocalImageFilePath: ", "")
		RandomSlideshowCategory = SettingsList(348).Replace("RandomSlideshowCategory: ", "")
		ResetFlag = SettingsList(349).Replace("ResetFlag: ", "")
		DommeTags = SettingsList(350).Replace("DommeTags: ", "")
		ThemeSettings = SettingsList(351).Replace("ThemeSettings: ", "")
		InputIcon = SettingsList(352).Replace("InputIcon: ", "")
		ApplyingTheme = SettingsList(353).Replace("ApplyingTheme: ", "")
		AdjustingWindow = SettingsList(354).Replace("AdjustingWindow: ", "")
		SplitContainerHeight = SettingsList(355).Replace("SplitContainerHeight: ", "")
		DommeImageFound = SettingsList(356).Replace("DommeImageFound: ", "")
		DommeImageListCheck = SettingsList(357).Replace("DommeImageListCheck: ", "")
		LocalImageFound = SettingsList(358).Replace("LocalImageFound: ", "")
		LocalImageListCheck = SettingsList(359).Replace("LocalImageListCheck: ", "")
		CBTBothActive = SettingsList(360).Replace("CBTBothActive: ", "")
		CBTBothFlag = SettingsList(361).Replace("CBTBothFlag: ", "")
		CBTBothCount = SettingsList(362).Replace("CBTBothCount: ", "")
		CBTBothFirst = SettingsList(363).Replace("CBTBothFirst: ", "")
		MetroGet = SettingsList(364).Replace("MetroGet: ", "")
		GeneralTime = SettingsList(365).Replace("GeneralTime: ", "")
		NewDommeSlideshow = SettingsList(366).Replace("NewDommeSlideshow: ", "")
		OriginalDommeSlideshow = SettingsList(367).Replace("OriginalDommeSlideshow: ", "")
		TimeoutTick = SettingsList(368).Replace("TimeoutTick: ", "")
		PBImage = SettingsList(369).Replace("PBImage: ", "")
		DommeImageSTR = SettingsList(370).Replace("DommeImageSTR: ", "")
		LocalImageSTR = SettingsList(371).Replace("LocalImageSTR: ", "")
		ImageLocation = SettingsList(372).Replace("ImageLocation: ", "")


		If File.Exists(SettingsPath & ResumePrefix & "PlayListFile.txt") Then PlaylistFile = Txt2List(SettingsPath & ResumePrefix & "PlayListFile.txt")
		If File.Exists(SettingsPath & ResumePrefix & "TauntLines.txt") Then TauntLines = Txt2List(SettingsPath & ResumePrefix & "TauntLines.txt")
		If File.Exists(SettingsPath & ResumePrefix & "_ImageFileNames.txt") Then _ImageFileNames = Txt2List(SettingsPath & ResumePrefix & "_ImageFileNames.txt")
		If File.Exists(SettingsPath & ResumePrefix & "RecentSlideshows.txt") Then RecentSlideshows = Txt2List(SettingsPath & ResumePrefix & "RecentSlideshows.txt")
		If File.Exists(SettingsPath & ResumePrefix & "LocalTagImageList.txt") Then LocalTagImageList = Txt2List(SettingsPath & ResumePrefix & "LocalTagImageList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "WebImageLines.txt") Then WebImageLines = Txt2List(SettingsPath & ResumePrefix & "WebImageLines.txt")
		If File.Exists(SettingsPath & ResumePrefix & "TnAList.txt") Then TnAList = Txt2List(SettingsPath & ResumePrefix & "TnAList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "BoobList.txt") Then BoobList = Txt2List(SettingsPath & ResumePrefix & "BoobList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "AssList.txt") Then AssList = Txt2List(SettingsPath & ResumePrefix & "AssList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "UpdateList.txt") Then UpdateList = Txt2List(SettingsPath & ResumePrefix & "UpdateList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "CustomSlideshowList.txt") Then CustomSlideshowList = Txt2List(SettingsPath & ResumePrefix & "CustomSlideshowList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact1Pics.txt") Then Contact1Pics = Txt2List(SettingsPath & ResumePrefix & "Contact1Pics.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact2Pics.txt") Then Contact2Pics = Txt2List(SettingsPath & ResumePrefix & "Contact2Pics.txt")
		' Github Patch If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then Contact3Pics = Txt2List(SettingsPath & "Contact3Pics.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then Contact3Pics = Txt2List(SettingsPath & ResumePrefix & "Contact3Pics.txt")

		If SlideshowLoaded = True Then
			If File.Exists(_ImageFileNames(FileCount)) Then
				PBImage = _ImageFileNames(FileCount)
				' Github Patch ImageThread.Start()
				DisplayImage()
			End If
		End If

		ChatText.DocumentText = Chat
		While ChatText.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ChatText2.DocumentText = Chat
		While ChatText2.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ScrollChatDown()



		ScrollChatDown()

		ResetFlag = False

	End Sub

#End Region 'Session Supend/Reset

#Region "------------------------------------------------------ MenuStuff -----------------------------------------------------"

#Region "-------------------------------------------------------- File --------------------------------------------------------"

	Private Sub dompersonalitycombobox_LostFocus(sender As Object, e As System.EventArgs) Handles dompersonalitycombobox.LostFocus
		My.Settings.DomPersonality = dompersonalitycombobox.Text
		My.Settings.Save()
	End Sub

	Private Sub dompersonalitycombobox_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dompersonalitycombobox.SelectedIndexChanged
		If FormLoading = False Then

			My.Settings.DomPersonality = dompersonalitycombobox.Text
			My.Settings.Save()

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

		If SaidHello = False Then
			MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If


		If File.Exists(Application.StartupPath & "\System\SavedState.txt") Then
			Dim Result As Integer = MessageBox.Show(Me, "A previous saved state already exists!" & Environment.NewLine & Environment.NewLine &
												   "Do you wish to overwrite it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.No Then
				Return
			End If
		End If

		Try
			SuspendSession()
		Catch
			MessageBox.Show(Me, "An error occurred and the state did not save correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try

		MessageBox.Show(Me, "Session state has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub

	Private Sub ResumeSessionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResumeSessionToolStripMenuItem.Click

		If Not File.Exists(Application.StartupPath & "\System\" & "SavedState.txt") Then
			MessageBox.Show(Me, "SavedState.txt could not be found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		If SaidHello = True Then
			Dim Result As Integer = MessageBox.Show(Me, "Resuming a previous state will cause you to lose your progress in this session!" & Environment.NewLine & Environment.NewLine &
												   "Do you wish to proceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.No Then
				Return
			End If
		End If

		ResumeSession()

	End Sub

	Private Sub ResetSessionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResetSessionToolStripMenuItem.Click

		If SaidHello = False Then
			MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		StopEverything()
		ResetButton()

		ResetFlag = True
		ResumeSession()

		If DomTypeCheck = False Then
			DomTask = "<b>Tease AI has been reset</b>"
			TypingDelayGeneric()
		End If

	End Sub

	Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click,
																									ExitToolStripMenuItem1.Click
		Me.Close()
		Me.Dispose()
	End Sub

#End Region

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

	Private Sub DommeTagsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DommeTagsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(5)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub LocalTagsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LocalTagsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(6)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub URLFilesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles URLFilesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(7)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub VideoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VideoToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(8)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub AppsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AppsToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(9)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub RangesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RangesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(11)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ModdingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ModdingToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(12)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub MiscToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MiscToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(13)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

#End Region

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
				LBLWishlistBronze.Text = BronzeTokens
				LBLWishlistSilver.Text = SilverTokens
				LBLWishlistGold.Text = GoldTokens
				LBLWishListText.Text = ""



				Dim WishDir As String = WishList(randomizer.Next(0, WishList.Count))

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
					If GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & domName.Text
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					If SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & domName.Text
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If



				My.Settings.WishlistDate = FormatDateTime(Now, DateFormat.ShortDate)

				My.Settings.Save()






			Else



				LBLWishlistDom.Text = domName.Text & "'s Wishlist"
				LBLWishlistDate.Text = FormatDateTime(Now, DateFormat.ShortDate).ToString()
				LBLWishlistBronze.Text = BronzeTokens
				LBLWishlistSilver.Text = SilverTokens
				LBLWishlistGold.Text = GoldTokens


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
					If GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "????? Gold"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					Debug.Print("Silver Caled PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP")
					If SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "???? Silver"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

			End If







			LBLWishlistBronze.Text = BronzeTokens
			LBLWishlistSilver.Text = SilverTokens
			LBLWishlistGold.Text = GoldTokens

			If WishlistCostGold.Visible = True Then
				If GoldTokens >= Val(LBLWishlistCost.Text) Then
					BTNWishlist.Text = "Purchase for " & domName.Text
					BTNWishlist.Enabled = True
				Else
					BTNWishlist.Text = "Not Enough Tokens!"
					BTNWishlist.Enabled = False
				End If
			End If

			If WishlistCostSilver.Visible = True Then
				Debug.Print("Silver Called")
				If SilverTokens >= Val(LBLWishlistCost.Text) Then
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

#End Region

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

#End Region

#Region "----------------------------------------------------- Interface ------------------------------------------------------"

	Private Sub SwitchSidesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SwitchSidesToolStripMenuItem1.Click
		If My.Settings.MirrorWindows = False Then
			My.Settings.MirrorWindows = True
		Else
			My.Settings.MirrorWindows = False
		End If

		My.Settings.Save()
		AdjustWindow()
	End Sub

	Private Sub SideChatToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SideChatToolStripMenuItem1.Click
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
		My.Settings.Save()
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
		My.Settings.Save()
	End Sub

	Private Sub ThemesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ThemesToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(10)
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
		My.Settings.Save()

	End Sub

	Private Sub DefaultImageSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DefaultImageSizeToolStripMenuItem.Click
		If SplitContainer1.Height > 430 Then SplitContainer1.SplitterDistance = SplitContainer1.Height - 252
	End Sub

#End Region

#Region "------------------------------------------------------- Tools --------------------------------------------------------"

	Private Sub CommandGuideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CommandGuideToolStripMenuItem.Click
		If Form10.Visible = False Then Form10.Show()
		Form10.Focus()
	End Sub

	Private Sub AIBoxesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AIBoxesToolStripMenuItem.Click
		If Form9.Visible = False Then Form9.Show()
		Form9.Focus()
	End Sub

#End Region

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

#End Region

	Private Sub RunScriptToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunScriptToolStripMenuItem.Click

		If OpenScriptDialog.ShowDialog() = DialogResult.OK Then

			StrokeTauntVal = -1

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			FileText = OpenScriptDialog.FileName
			BeforeTease = False
			ShowModule = True
			SaidHello = True
			ScriptTick = 1
			ScriptTimer.Start()

			ApplyThemeColor()

		End If

	End Sub

	Private Sub DebugMenuToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DebugMenuToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(14)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub RefreshRandomizerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshRandomizerToolStripMenuItem.Click
		randomizer = New Random(System.DateTime.Now.Ticks Mod System.Int32.MaxValue)
	End Sub

	Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(15)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

#End Region

	Private Sub Form1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
		If SplitContainer1.Width + 270 > Me.Width Then AdjustWindow()
	End Sub

	Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

		Debug.Print("Resize Called")
		Debug.Print(Me.WindowState)
		Debug.Print(Me.WindowCheck)

		Select Case Me.WindowState

			Case FormWindowState.Maximized
				Debug.Print("Maximized")
				WindowCheck = True
				AdjustWindow()

			Case FormWindowState.Normal And WindowCheck = True
				Debug.Print("Resized From Maximized")
				WindowCheck = False
				AdjustWindow()

		End Select
	End Sub

	Private Sub Form1_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

		Debug.Print(Me.Width & " " & Me.Height)

		AdjustWindow()

		SplitContainer1.Width = Me.Width - 296

		My.Settings.WindowHeight = Me.Height
		My.Settings.WindowWidth = Me.Width
		My.Settings.Save()

	End Sub

	Public Sub AdjustWindow()


		'Test

		SuspendLayout()

		AdjustingWindow = True

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
		Debug.Print("SplitContainerHeight = " & SplitContainerHeight)

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

		AdjustingWindow = False

		'If My.Settings.SplitterPosition <> 0 Then SplitContainer1.SplitterDistance = My.Settings.SplitterPosition

		' SplitContainer1.Height = Me.Height - 83

		ResumeLayout()


	End Sub

	Private Sub SplitContainer1_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved

		If FormLoading = True Then Return

		If ApplyingTheme = False And AdjustingWindow = False Then

			If PNLMediaBar.Visible = True Then
				ChatText.Location = New Point(2, 33)
				ChatText.Height = SplitContainer1.Panel2.Height - 67
			Else
				ChatText.Location = New Point(2, 0)
				ChatText.Height = SplitContainer1.Panel2.Height - 68
			End If

			PNLChatBox.Location = New Point(2, SplitContainer1.Panel2.Height - 32)
			PNLHope.Location = New Point(SplitContainer1.Width - 314, PNLChatBox.Location.Y)

			SplitContainerHeight = SplitContainer1.Panel2.Height

			My.Settings.SplitterPosition = SplitContainer1.Height - SplitContainer1.Panel1.Height
			My.Settings.Save()

			Debug.Print("SplitContainer1.Height = " & SplitContainer1.Height)
			Debug.Print("SplitContainer1.Panel1.Height = " & SplitContainer1.Panel1.Height)
			Debug.Print("SplitContainer1.Panel2.Height = " & SplitContainer1.Panel2.Height)
			Debug.Print("SplitContainer1.SplitterDistance = " & SplitContainer1.SplitterDistance)
			Debug.Print("SplitContainerHeight = " & SplitContainerHeight)




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


		If SplitContainer1.Panel2.Height < 68 And MediaButton.Text = "Hide Media Panel" Then
			PNLMediaBar.Visible = False
			browsefolderButton.Visible = False
			previousButton.Visible = False
			nextButton.Visible = False
			BTNLoadVideo.Visible = False
			BTNVideoControls.Visible = False
		End If

		If SplitContainer1.Panel2.Height < 68 Then
			MediaButton.Enabled = False
		Else
			MediaButton.Enabled = True
		End If

		If SplitContainer1.Panel2.Height > 67 And MediaButton.Text = "Hide Media Panel" Then
			PNLMediaBar.Visible = True
			browsefolderButton.Visible = True
			previousButton.Visible = True
			nextButton.Visible = True
			BTNLoadVideo.Visible = True
			BTNVideoControls.Visible = True
		End If


		If FormLoading = False And FormFinishedLoading = True Then
			My.Settings.SplitterDistance = SplitContainer1.SplitterDistance
			My.Settings.Save()

		End If

		If ApplyingTheme = False And AdjustingWindow = False Then AdjustWindow()

		ScrollChatDown()




		Debug.Print("SplitContainer1.SplitterDistance = " & SplitContainer1.SplitterDistance)



	End Sub






	Private Sub TeaseAIClock_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles TeaseAIClock.Tick

		LBLTime.Text = Format(Now, "h:mm")
		LBLAMPM.Text = Format(Now, "tt")
		LBLDate.Text = Format(Now, "Long Date")

		'Debug.Print("Current day = " & Format(Now, "dd"))

		' Debug.Print(Format(Now, "MM/dd/yyyy"))

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_WakeUp") Then

			Dim Dates As String
			Dates = FormatDateTime(Now, DateFormat.ShortDate) & " " & GetTime("SYS_WakeUp")

			Dim DDiff As Integer
			DDiff = DateDiff(DateInterval.Hour, CDate(Dates), Now)

			'Debug.Print(DDiff)
			'Debug.Print(GetTime("SYS_WakeUp"))

			GeneralTime = "Night"
			If DDiff > -1 And DDiff < 5 Then GeneralTime = "Morning"
			If DDiff > 4 And DDiff < 12 Then GeneralTime = "Afternoon"
			If DDiff < -13 Then GeneralTime = "Afternoon"

			'Debug.Print(GeneralTime)
		End If


		' #DEBUG

		'Debug.Print("LockImage = " & LockImage)
		'Debug.Print("WorshipMode = " & WorshipMode)
		'Debug.Print("WorshipTarget = " & WorshipTarget)
		'Debug.Print("My.Settings.SplitterDistance = " & My.Settings.SplitterDistance)



	End Sub

	Public Sub StrokeSpeedCheck()

		If StrokeFaster = True Then
			If SubStroking = True And SubEdging = False And SubHoldingEdge = False Then
				Debug.Print("Stroke Faster")
				Dim Stroke123 As Integer = randomizer.Next(1, 4)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace - Stroke123
				If StrokePace < NBMaxPace.Value Then StrokePace = NBMaxPace.Value

			End If
			StrokeFaster = False
		End If

		If StrokeSlower = True Then
			If SubStroking = True And SubEdging = False And SubHoldingEdge = False Then
				Debug.Print("Stroke Slower")
				Dim Stroke123 As Integer = randomizer.Next(1, 4)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace + Stroke123
				If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value

			End If
			StrokeSlower = False
		End If

		If StrokeFastest = True Then
			If SubStroking = True And SubEdging = False And SubHoldingEdge = False Then
				Debug.Print("Stroke Fastest")
				StrokePace = NBMaxPace.Value

			End If
			StrokeFastest = False
		End If

		If StrokeSlowest = True Then
			If SubStroking = True And SubEdging = False And SubHoldingEdge = False Then
				Debug.Print("Stroke Slowest")
				StrokePace = NBMinPace.Value

			End If
			StrokeSlowest = False
		End If

	End Sub

	Public Sub ApplyThemeColor()

		ApplyingTheme = True

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

		MediaButton.BackColor = My.Settings.ButtonColor
		SaveBlogImage.BackColor = My.Settings.ButtonColor
		SettingsButton.BackColor = My.Settings.ButtonColor

		browsefolderButton.ForeColor = My.Settings.TextColor
		PNLMediaBar.ForeColor = My.Settings.TextColor
		PNLHope.ForeColor = My.Settings.TextColor
		PNLChatBox.ForeColor = My.Settings.TextColor
		PNLChatBox2.ForeColor = My.Settings.TextColor

		previousButton.ForeColor = My.Settings.TextColor
		nextButton.ForeColor = My.Settings.TextColor
		BTNLoadVideo.ForeColor = My.Settings.TextColor
		BTNVideoControls.ForeColor = My.Settings.TextColor

		MediaButton.ForeColor = My.Settings.TextColor
		SaveBlogImage.ForeColor = My.Settings.TextColor
		SettingsButton.ForeColor = My.Settings.TextColor

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
		Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & Chat & "</body>"
		ChatText.DocumentText = Chat
		While ChatText.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ChatText2.DocumentText = Chat
		While ChatText2.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ScrollChatDown()

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

		ApplyingTheme = False


        'TabControl1.DefaultBackColor = My.Settings.BackgroundColor

    End Sub












	Public Sub OpenApp()

		PNLTabs.Height = Me.Height - 429

		AdjustWindow()

	End Sub

	Public Sub CloseApp()

		PNLDomTagBTN.Visible = False
		StatusUpdates.Visible = False
		ChatText2.Visible = False
		PNLChatBox2.Visible = False
		PNLLazySub.Visible = False
		PNLLazySub2.Visible = False
		PNLAppRandomizer.Visible = False
		PNLPlaylist.Visible = False
		PNLWritingTask.Visible = False
		PNLWishList.Visible = False
		PNLHypnoGen.Visible = False
		AppPanelVitalSub.Visible = False
		PNLMetronome.Visible = False

		SideChatToolStripMenuItem1.Checked = False

		PNLTabs.Height = 0

		AdjustWindow()
	End Sub

#Region "------------------------------------------------------- Apps ---------------------------------------------------------"

#Region "--------------------------------------------------- DommeTag APP -----------------------------------------------------"

#Region "------------------------------------------------- Regular Buttons-----------------------------------------------------"

	Private Sub Face_Click(sender As System.Object, e As System.EventArgs) Handles Face.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Then Return
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
		If SlideshowLoaded = False Or TBGarment.Focused = False Then Return
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
		If SlideshowLoaded = False Or TBUnderwear.Focused = False Then Return
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
		If SlideshowLoaded = False Or TBTattoo.Focused = False Then Return
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
		If SlideshowLoaded = False Or TBSexToy.Focused = False Then Return
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
		If SlideshowLoaded = False Or TBFurniture.Focused = False Then Return
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
		Dim TagFile As String = Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt"

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			Dim FoundFile As Boolean = False

			For i As Integer = 0 To TagList.Count - 1
				If TagList(i).Contains(Path.GetFileName(ImageLocation)) Then
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

			If FoundFile = False Then TagList.Add(Path.GetFileName(ImageLocation) & " " & DomTag & Custom)

			If TagList.Count > 0 Then
				Dim SettingsString As String = ""
				For i As Integer = 0 To TagList.Count - 1
					SettingsString = SettingsString & TagList(i)
					If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
				Next
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt", SettingsString, False)
			End If

		ElseIf Path.GetDirectoryName(_ImageFileNames(FileCount)) = Path.GetDirectoryName(ImageLocation)
			' Only Create new file for the loaded Slidshow. This Prevents URL-Image-Tagging.
			My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt", Path.GetFileName(ImageLocation) & " " & DomTag & Custom, True)

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
		Dim TagFile As String = Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt"
		Debug.Print("TagFile = " & TagFile)

		Debug.Print("DomTag & Custom = " & DomTag & Custom)

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			For i As Integer = TagList.Count - 1 To 0 Step -1
				If TagList(i).Contains(Path.GetFileName(ImageLocation)) Then
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
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt", SettingsString, False)
			Else
				If File.Exists(Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt") Then My.Computer.FileSystem.DeleteFile(Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt")
			End If

		End If




	End Function


	''' <summary>
	''' <para>In Order to Work, this function has to be called AFTER an Image has been loaded into the 
	''' <see cref="Form1.mainPictureBox">PictureBox</see>. Everthing else doesn't work properly.</para>
	''' <para>Right now there are only two working non-UI-Freezing posibilities: The Imagebox 
	''' LoadCompleted-Event and PBImageThread. In PBImageThread an Invoke is required!</para>
	''' This Function uses the <see cref="form1.ImageLocation">ImageLocation</see> Variable to get the
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


		Dim tmpFileName As String = Path.GetFileName(ImageLocation)

		Dim TagFile As String = Path.GetDirectoryName(ImageLocation) & "\ImageTags.txt"

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


#End Region

#Region "------------------------------------------------------ Lazy-Sub-------------------------------------------------------"

	Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles BTNStop.Click
		chatBox.Text = "Let me stop"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNYes_Click(sender As System.Object, e As System.EventArgs) Handles BTNYes.Click
		Try
			chatBox.Text = "Yes " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Yes"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNNo_Click(sender As System.Object, e As System.EventArgs) Handles BTNNo.Click
		Try
			chatBox.Text = "No " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "No"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNEdge_Click(sender As System.Object, e As System.EventArgs) Handles BTNEdge.Click
		chatBox.Text = "On the edge"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSpeedUp_Click(sender As System.Object, e As System.EventArgs) Handles BTNSpeedUp.Click
		chatBox.Text = "Let me speed up"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSlowDown_Click(sender As System.Object, e As System.EventArgs) Handles BTNSlowDown.Click
		chatBox.Text = "Let me slow down"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNStroke_Click(sender As System.Object, e As System.EventArgs) Handles BTNStroke.Click
		chatBox.Text = "May I start stroking?"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNAskToCum_Click(sender As System.Object, e As System.EventArgs) Handles BTNAskToCum.Click
		chatBox.Text = "Please let me cum!"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNGreeting_Click(sender As System.Object, e As System.EventArgs) Handles BTNGreeting.Click

		If SaidHello = True Then
			LockImage = False
			If SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True
			End If
			RapidFire = False
			Return
		End If

		Try
			chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNSafeword_Click(sender As System.Object, e As System.EventArgs) Handles BTNSafeword.Click
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
			My.Settings.Save()
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
			My.Settings.Save()
		End If
	End Sub

	Private Sub TBShortYes_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortYes.LostFocus
		My.Settings.ShortYes = TBShortYes.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortNo_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortNo.LostFocus
		My.Settings.ShortNo = TBShortNo.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortEdge_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortEdge.LostFocus
		My.Settings.ShortEdge = TBShortEdge.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortSpeedUp_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSpeedUp.LostFocus
		My.Settings.ShortSpeedUp = TBShortSpeedUp.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortSlowDown_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSlowDown.LostFocus
		My.Settings.ShortSlowDown = TBShortSlowDown.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortStop_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortStop.LostFocus
		My.Settings.ShortStop = TBShortStop.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortStroke_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortStroke.LostFocus
		My.Settings.ShortStroke = TBShortStroke.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortCum_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortCum.LostFocus
		My.Settings.ShortCum = TBShortCum.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortGreet_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortGreet.LostFocus
		My.Settings.ShortGreet = TBShortGreet.Text
		My.Settings.Save()
	End Sub

	Private Sub TBShortSafeword_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSafeword.LostFocus
		My.Settings.ShortSafeword = TBShortSafeword.Text
		My.Settings.Save()
	End Sub

	Private Sub BTNLS1_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS1.Click


		If BTNLS1.Text <> "" Then
			chatBox.Text = BTNLS1.Text
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

#End Region

#Region "-------------------------------------------------- Randomizer-App ----------------------------------------------------"

	Private Sub BTNRandomBlog_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomBlog.Click
		GetBlogImage()
	End Sub

	Private Sub BTNRandomLocal_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomLocal.Click
		GetLocalImage()
	End Sub

	Private Sub BTNRandomVideo_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomVideo.Click
		RandomizerVideo = True
		RandomVideo()
		RandomizerVideo = False
	End Sub

	Private Sub BTNRandomJOI_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomJOI.Click
		PlayRandomJOI()
	End Sub

	Private Sub BTNRandomCS_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomCS.Click
		SaidHello = True
		RandomizerVideoTease = True

		ScriptVideoTease = "Censorship Sucks"
		ScriptVideoTeaseFlag = True
		RandomVideo()
		ScriptVideoTeaseFlag = False
		CensorshipGame = True
		VideoTease = True
		CensorshipTick = randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
		CensorshipTimer.Start()
	End Sub

	Private Sub BTNRandomAtE_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomAtE.Click

		SaidHello = True
		RandomizerVideoTease = True

		ScriptTimer.Stop()
		SubStroking = True
		TempStrokeTauntVal = StrokeTauntVal
		TempFileText = FileText
		ScriptVideoTease = "Avoid The Edge"
		ScriptVideoTeaseFlag = True
		AvoidTheEdgeStroking = True
		AvoidTheEdgeGame = True
		RandomVideo()
		ScriptVideoTeaseFlag = False
		VideoTease = True
		StartStrokingCount += 1
		StopMetronome = False
		StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		StrokePaceTimer.Interval = StrokePace
		StrokePaceTimer.Start()
		AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
		AvoidTheEdgeTaunts.Start()

	End Sub

	Private Sub BTNRandomRLGL_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomRLGL.Click

		SaidHello = True
		RandomizerVideoTease = True

		ScriptTimer.Stop()
		SubStroking = True
		ScriptVideoTease = "RLGL"
		ScriptVideoTeaseFlag = True
		'AvoidTheEdgeStroking = True
		RLGLGame = True
		RandomVideo()
		ScriptVideoTeaseFlag = False
		VideoTease = True
		RLGLTick = randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
		RLGLTimer.Start()
		StartStrokingCount += 1
		StopMetronome = False
		StrokePace = randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		StrokePaceTimer.Interval = StrokePace
		StrokePaceTimer.Start()
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
			Dim VidPoint As Integer = randomizer.Next(VidLow, VidHigh)

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

		If SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to begin a Playlist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Playlist = True
		'SaidHello = True

		PlaylistFile = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\" & LBPlaylist.SelectedItem & ".txt")
		PlaylistFile = StripBlankLines(PlaylistFile)
		PlaylistCurrent = 0
		Try
			chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()

		BTNPlaylist.Enabled = False
	End Sub

	Private Sub BTNWishlist_Click(sender As System.Object, e As System.EventArgs) Handles BTNWishlist.Click

		If SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with your domme to use this feature!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Debug.Print(WishlistCostSilver.Visible)
		Debug.Print(Val(LBLWishlistCost.Text))

		If WishlistCostSilver.Visible = True And SilverTokens >= Val(LBLWishlistCost.Text) Then

			SilverTokens -= Val(LBLWishlistCost.Text)
			My.Settings.SilverTokens = SilverTokens

			'LBLWishListText.Text = "You purchased this item for " & domName.Text & " on " & CDate(DateString) & "."
			'My.Settings.WishlistNote = LBLWishListText.Text

			My.Settings.ClearWishlist = True

			My.Settings.Save()

			WishlistCostGold.Visible = False
			WishlistCostSilver.Visible = False
			LBLWishlistBronze.Text = BronzeTokens
			LBLWishlistSilver.Text = SilverTokens
			LBLWishlistGold.Text = GoldTokens
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

			SaidHello = True
			ShowModule = True

			FileText = SilverList(randomizer.Next(0, SilverList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			StrokeTauntVal = -1
			ScriptTick = 2
			ScriptTimer.Start()
			Return

		End If


		If WishlistCostGold.Visible = True And GoldTokens >= Val(LBLWishlistCost.Text) Then

			GoldTokens -= Val(LBLWishlistCost.Text)
			My.Settings.GoldTokens = GoldTokens

			My.Settings.ClearWishlist = True

			My.Settings.Save()

			Dim GoldList As New List(Of String)

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Wishlist\Gold Rewards\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				GoldList.Add(foundFile)
			Next

			If GoldList.Count < 1 Then
				MessageBox.Show(Me, "No Gold Reward scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			SaidHello = True
			ShowModule = True

			FileText = GoldList(randomizer.Next(0, GoldList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			StrokeTauntVal = -1
			ScriptTick = 2
			ScriptTimer.Start()

		End If


	End Sub

#End Region

#Region "------------------------------------------------- Hypno-Guide App ----------------------------------------------------"

	Private Sub BTNHypnoGenStart_Click(sender As System.Object, e As System.EventArgs) Handles BTNHypnoGenStart.Click



		If HypnoGen = False Then

			If CBHypnoGenInduction.Checked = True Then
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt") Then
					Induction = True
					FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt"
				Else
					MessageBox.Show(Me, "Please select a valid Hypno Induction File or deselect the Induction option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
			End If



			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt") Then
				If Induction = False Then
					FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				Else
					TempHypno = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				End If
			Else
				MessageBox.Show(Me, "Please select a valid Hypno File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			StrokeTauntVal = -1
			ScriptTick = 1
			ScriptTimer.Start()
			Dim HypnoTrack As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\" & ComboBoxHypnoGenTrack.SelectedItem
			If File.Exists(HypnoTrack) Then DomWMP.URL = HypnoTrack
			HypnoGen = True
			AFK = True
			SaidHello = True

			BTNHypnoGenStart.Text = "End Session"

		Else

			mciSendString("CLOSE Speech1", String.Empty, 0, 0)
			mciSendString("CLOSE Echo1", String.Empty, 0, 0)
			DomWMP.Ctlcontrols.stop()

			ScriptTimer.Stop()
			StrokeTauntVal = -1
			HypnoGen = False
			Induction = False
			AFK = False
			SaidHello = False

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
			CaloriesConsumed += TBCalorieAmount.Text
			LBLCalorie.Text = CaloriesConsumed
			My.Settings.CaloriesConsumed = CaloriesConsumed
			TBCalorieItem.Text = ""
			TBCalorieAmount.Text = ""
			My.Settings.Save()
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
			CaloriesConsumed += TempCal
			LBLCalorie.Text = CaloriesConsumed
			My.Settings.CaloriesConsumed = CaloriesConsumed
			My.Settings.Save()
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
		My.Settings.Save()
	End Sub

	Private Sub LBCalorie_DoubleClick(sender As Object, e As System.EventArgs) Handles LBCalorie.DoubleClick


		Dim CalorieString As String = LBCalorie.SelectedItem
		CalorieString = CalorieString.Replace(" Calories", "")
		Dim CalorieSplit As String() = Split(CalorieString)
		Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
		CaloriesConsumed -= TempCal
		LBLCalorie.Text = CaloriesConsumed
		My.Settings.CaloriesConsumed = CaloriesConsumed
		My.Settings.Save()
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
		If SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to make VitalSub reports!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		SaidHello = True
		TeaseOver = False


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
			CaloriesConsumed = 0
			My.Settings.CaloriesConsumed = 0
			My.Settings.Save()

			FileText = VitalList(randomizer.Next(0, VitalList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			StrokeTauntVal = -1
			ScriptTick = 3
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
			My.Settings.Save()
		End If
	End Sub

#End Region ' Vital Sub

	Public Sub MetronomeTick()

		' Begin GitHub Patch
		'Do
		'If StrokePace <> 0 And CBMetronome.Checked = True Then
		'My.Computer.Audio.Stop()
		'My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\metronome.wav")
		'Thread.Sleep(StrokePace)
		'End If
		'Loop
		' End GitHub Patch

		Do
			If StrokePace > 0 Then
				If CBMetronome.Checked Then
					My.Computer.Audio.Stop()
					My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\metronome.wav")
					Thread.Sleep(StrokePace)
				End If
			Else
				Threading.Thread.Sleep(1000)
			End If

		Loop

	End Sub

#Region "-------------------------------------------------- Metronome-App -----------------------------------------------------"

	Private Sub BTNMetroPreview1_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroPreview1.Click
		If SubStroking = False Then StrokePace = NBMaxPace.Value
	End Sub

	Private Sub BTNMetroPreview2_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroPreview2.Click
		If SubStroking = False Then StrokePace = NBMinPace.Value
	End Sub

	Private Sub BTNMetroStop1_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroStop1.Click
		If SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub BTNMetroStop2_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroStop2.Click
		If SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub NBMaxPace_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBMaxPace.ValueChanged
		If FormLoading = False Then
			If NBMaxPace.Value > NBMinPace.Value - 50 Then NBMaxPace.Value = NBMinPace.Value - 50
			If SubStroking = False Then StrokePace = NBMaxPace.Value
			My.Settings.MaxPace = NBMaxPace.Value
			My.Settings.Save()
		End If
	End Sub

	Private Sub NBMinPace_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBMinPace.ValueChanged
		If FormLoading = False Then
			If NBMinPace.Value < NBMaxPace.Value + 50 Then NBMinPace.Value = NBMaxPace.Value + 50
			If SubStroking = False Then StrokePace = NBMinPace.Value
			My.Settings.MinPace = NBMinPace.Value
			My.Settings.Save()
		End If
	End Sub

	Private Sub TimeoutTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles TimeoutTimer.Tick

		Debug.Print("TimeoutTick = " & TimeoutTick)

		If chatBox.Text <> "" And TimeoutTick < 3 Then Return
		If ChatBox2.Text <> "" And TimeoutTick < 3 Then Return

		TimeoutTick -= 1

		If TimeoutTick < 1 Then

			TimeoutTimer.Stop()
			YesOrNo = False
			InputFlag = False

			SkipGotoLine = True
			GetGoto()

			RunFileText()

		End If

	End Sub

	Private Sub CBMetronome_LostFocus(sender As Object, e As System.EventArgs) Handles CBMetronome.LostFocus
		My.Settings.MetroOn = CBMetronome.Checked
		My.Settings.Save()
	End Sub

#End Region

#Region "---------------------------------------------------- LazySub-AV ------------------------------------------------------"

	Private Sub Button7_Click_1(sender As System.Object, e As System.EventArgs) Handles Button7.Click
		chatBox.Text = "Let me stop"
		sendButton.PerformClick()
	End Sub

	Private Sub Button2_Click_3(sender As System.Object, e As System.EventArgs) Handles Button2.Click
		Try
			chatBox.Text = "Yes " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Yes"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub Button3_Click_2(sender As System.Object, e As System.EventArgs) Handles Button3.Click
		Try
			chatBox.Text = "No " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "No"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
		chatBox.Text = "On the edge"
		sendButton.PerformClick()
	End Sub

	Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
		chatBox.Text = "Let me speed up"
		sendButton.PerformClick()
	End Sub

	Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs) Handles Button5.Click
		chatBox.Text = "Let me slow down"
		sendButton.PerformClick()
	End Sub

	Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
		chatBox.Text = "May I start stroking?"
		sendButton.PerformClick()
	End Sub

	Private Sub Button9_Click_2(sender As System.Object, e As System.EventArgs) Handles Button9.Click
		chatBox.Text = "Please let me cum!"
		sendButton.PerformClick()
	End Sub

	Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
		If SaidHello = True Then
			LockImage = False
			RapidFire = False
			If SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				DommeSlideshowToolStripMenuItem.Enabled = True
			End If
			Return
		End If

		Try
			chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
		Try
			chatBox.Text = FrmSettings.TBSafeword.Text
		Catch
			chatBox.Text = "@Error"
		End Try

		sendButton.PerformClick()
	End Sub

#End Region

#End Region ' Apps

	Private Sub ChatText_Resize(sender As Object, e As EventArgs) Handles ChatText.Resize
		If PNLMediaBar.Visible = True Then
			ChatText.Location = New Point(2, 33)
			ChatText.Height = SplitContainer1.Panel2.Height - 67
		Else
			ChatText.Location = New Point(2, 0)
			ChatText.Height = SplitContainer1.Panel2.Height - 34
		End If
	End Sub


	Public Sub ShowImage(ByVal ImageToShow As String)

		PBImage = ImageToShow
		ImageLocation = ImageToShow
		ImageThread = New Thread(AddressOf DisplayImage) With {.Name = "ImageThread"}
		ImageThread.IsBackground = True
		ImageThread.Start()

	End Sub

	Public Sub CalculateResponse()


		ResponseThread = New Thread(AddressOf DomResponse) With {.Name = "ResponseThread"}
		ResponseThread.IsBackground = True
		ResponseThread.Start()

	End Sub

	''' <summary>
	''' Invokes included! This function should be used in a thread.
	''' </summary>
	Private Sub DisplayImage()

		If FormLoading = True Then Return
		If PBImage = "" And PreLoadImage = False Then Return

		Control.CheckForIllegalCrossThreadCalls = False


		Dim OldImage As Image = mainPictureBox.Image

		If PreLoadImage = True Then

			If Not CachedImage2 Is Nothing Then
				mainPictureBox.Image = CachedImage2
				SaveSessionImage(CachedImage2)
				If Not CachedImage Is Nothing Then CachedImage.Dispose()
			Else
				mainPictureBox.Image = CachedImage
				SaveSessionImage(CachedImage)
			End If
			PreLoadImage = False

		Else
			If PBImage.Contains("/") And PBImage.Contains("://") Then
				Try
					' Load the Image.
					mainPictureBox.Image = New Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(PBImage)))
				Catch ex As Net.WebException
					Exit Sub
				End Try
			Else
				mainPictureBox.Image = Image.FromFile(PBImage)
			End If

			If Not CachedImage Is Nothing Then CachedImage.Dispose()
			If Not CachedImage2 Is Nothing Then CachedImage2.Dispose()

		End If



		Try
			Me.UIThread(Sub() LBLImageInfo.Text = ImageLocation)
		Catch
			LBLImageInfo.Text = "Error!"
		End Try

		If Not OldImage Is Nothing Then
			OldImage.Dispose()
		End If
		GC.Collect()

		Me.Invoke(New Action(AddressOf CheckDommeTags))

		If Me.InvokeRequired Then
			Debug.Print("PBImageThread --- On different Thread")
		Else
			Debug.Print("PBImageThread --- On UI-Thread")
		End If


	End Sub

	Public Function CacheImage(ByVal OnlineImage As String) As String

		Dim ImageToCache As String = ""

		If OnlineImage = "Blog" Then

			Dim URLList As New List(Of String)
			URLList.Clear()
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				URLList.Add(foundFile.Replace(".txt", ""))
			Next

			If URLList.Count < 1 Then
				Return ImageToCache
				Exit Function
			End If

			For i As Integer = FrmSettings.URLFileList.Items.Count - 1 To 0 Step -1
				For j As Integer = URLList.Count - 1 To 0 Step -1
					If FrmSettings.URLFileList.GetItemChecked(i) = False And FrmSettings.URLFileList.Items(i) = URLList(j).Replace(Application.StartupPath & "\Images\System\URL Files\", "") Then
						URLList.Remove(URLList(j))
						Exit For
					End If
				Next
			Next

			If URLList.Count < 1 Then
				Return ImageToCache
				Exit Function
			End If

			ImageUrlFilePath = URLList(randomizer.Next(0, URLList.Count)) & ".txt"

			Dim linesGB As New List(Of String)
			linesGB = Txt2List(ImageUrlFilePath)

			Do
				ImageUrlFileIndex = randomizer.Next(0, linesGB.Count)
				FoundString = linesGB(ImageUrlFileIndex)
			Loop Until FoundString <> ""

			ImageToCache = FoundString

		End If

		If OnlineImage = "Butt" Then
			GetTnAList()
			Try
				ImageToCache = AssList(randomizer.Next(0, AssList.Count))
			Catch
				If FrmSettings.CBIButts.Checked = True Then
					ImageToCache = (Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg")
				Else
					ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
				End If
			End Try
		End If

		If OnlineImage = "Boobs" Then
			GetTnAList()
			Try
				ImageToCache = BoobList(randomizer.Next(0, BoobList.Count))
			Catch
				If FrmSettings.CBIBoobs.Checked = True Then
					ImageToCache = (Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg")
				Else
					ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
				End If
			End Try
		End If

		If OnlineImage = "Hardcore" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.HardcoreURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Softcore" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.SoftcoreURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Lesbian" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.LesbianURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Blowjob" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.BlowjobURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Femdom" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.FemdomURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Lezdom" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.LezdomURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Hentai" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.HentaiURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Gay" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.GayURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Maledom" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.MaledomURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "Captions" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.CaptionsURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If OnlineImage = "General" Then
			Try
				Dim PicList As New List(Of String)
				PicList = Txt2List(My.Settings.GeneralURLFile)
				ImageToCache = PicList(randomizer.Next(0, PicList.Count))
			Catch
				ImageToCache = (Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg")
			End Try
		End If

		If ImageToCache = "" Then
			Return ImageToCache
			Exit Function
		End If


		PreLoadImage = True

		If CachedImage Is Nothing Then
			CachedImage = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(ImageToCache)))
		Else
			CachedImage2 = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(ImageToCache)))
		End If

		ImageLocation = ImageToCache
		Return ImageToCache


	End Function

	Private Sub VideoTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles VideoTimer.Tick

		VideoTick -= 1

		If VideoTick < 1 Then
			VideoTimer.Stop()
			DomWMP.Ctlcontrols.stop()
		End If


	End Sub

	Private Sub MultipleEdgesTimer_Tick(sender As teaseAI_Timer, e As System.EventArgs) Handles MultipleEdgesTimer.Tick

		If DomTypeCheck = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		MultipleEdgesTick -= 1

		If MultipleEdgesTick < 1 Then

			MultipleEdgesTimer.Stop()

			DomChat = "#SYS_MultipleEdgesStart"
			If Contact1Edge = True Then DomChat = "@Contact1 #SYS_MultipleEdgesStart"
			If Contact2Edge = True Then DomChat = "@Contact2 #SYS_MultipleEdgesStart"
			If Contact3Edge = True Then DomChat = "@Contact3 #SYS_MultipleEdgesStart"
			TypingDelay()

			MultipleEdgesMetronome = "START"

			EdgeCountTick = 0
			EdgeCountTimer.Start()

		End If

	End Sub

	Public Function OfflineConversion(ByVal OffString As String) As String

		' Ixnay on the Wordplay

		OffString = OffString.Replace("@ShowBlogImage", "@ShowLocalImage")

		If FrmSettings.CBIButts.Checked = False Then
			OffString = OffString.Replace("@ShowButtImage", "")
			OffString = OffString.Replace("@ShowButtsImage", "")
		End If

		If FrmSettings.CBIBoobs.Checked = False Then
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

		EdgeGoto = False
		YesGoto = False
		NoGoto = False
		CameGoto = False
		RuinedGoto = False
		EdgeVideo = False
		YesVideo = False
		NoVideo_Mode = False
		CameVideo = False
		RuinedVideo = False
		EdgeMessage = False
		CameMessage = False
		RuinedMessage = False

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

	Private Sub OldDommeTagsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OldDommeTagsToolStripMenuItem.Click
		Form8.Show()
	End Sub

	Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
		nextButton.PerformClick()
	End Sub

	Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
		previousButton.PerformClick()
	End Sub

	Public Sub Edge()

		If SubStroking = True Then AlreadyStrokingEdge = True
		GetEdgeTickCheck()
		SubStroking = True
		LongEdge = False
		AskedToSpeedUp = False
		AskedToSlowDown = False
		EdgeCountTick = 0
		EdgeCountTimer.Start()
		SubEdging = True
		EdgeTauntInt = randomizer.Next(30, 46)
		EdgeTauntTimer.Start()
		If OrgasmAllowed = True Or OrgasmDenied = True Or OrgasmRuined = True Then OrgasmYesNo = True
		EdgePace()
		ActivateWebToy()
		DisableContactStroke()
		SessionEdges += 1

	End Sub

	Public Function CheckPreLoad(ByVal StringClean As String) As String


		If StringClean.Contains("@ShowBlogImage") Then
			If CacheImage("Blog") <> "" Then
				JustShowedBlogImage = True
				StringClean = StringClean.Replace("@ShowBlogImage", "")
			Else
				StringClean = StringClean.Replace("@ShowBlogImage", "@ShowLocalImage")
			End If

			Return StringClean
		End If

		If StringClean.Contains("@ShowButtImage") Or StringClean.Contains("@ShowButtsImage") Then

			If FrmSettings.CBURLButts.Checked = False Then Return StringClean
			If FrmSettings.CBIButts.Checked = True And FrmSettings.CBURLButts.Checked = False Then Return StringClean
			If FrmSettings.CBIButts.Checked = True And FrmSettings.CBURLButts.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If

			JustShowedBlogImage = True
			CacheImage("Butt")
			StringClean = StringClean.Replace("@ShowButtImage", "")
			StringClean = StringClean.Replace("@ShowButtsImage", "")

		End If

		If StringClean.Contains("@ShowBoobImage") Or StringClean.Contains("@ShowBoobsImage") Then

			If FrmSettings.CBURLBoobs.Checked = False Then Return StringClean
			If FrmSettings.CBIBoobs.Checked = True And FrmSettings.CBURLBoobs.Checked = False Then Return StringClean
			If FrmSettings.CBIBoobs.Checked = True And FrmSettings.CBURLBoobs.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If

			JustShowedBlogImage = True
			CacheImage("Boobs")
			StringClean = StringClean.Replace("@ShowBoobImage", "")
			StringClean = StringClean.Replace("@ShowBoobsImage", "")

		End If

		If StringClean.Contains("@ShowHardcoreImage") Then
			If FrmSettings.CBURLHardcore.Checked = False Then Return StringClean
			If FrmSettings.CBIHardcore.Checked = True And FrmSettings.CBURLHardcore.Checked = False Then Return StringClean
			If FrmSettings.CBIHardcore.Checked = True And FrmSettings.CBURLHardcore.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Hardcore")
			StringClean = StringClean.Replace("@ShowHardcoreImage", "")
		End If

		If StringClean.Contains("@ShowSoftcoreImage") Then
			If FrmSettings.CBURLSoftcore.Checked = False Then Return StringClean
			If FrmSettings.CBISoftcore.Checked = True And FrmSettings.CBURLSoftcore.Checked = False Then Return StringClean
			If FrmSettings.CBISoftcore.Checked = True And FrmSettings.CBURLSoftcore.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Softcore")
			StringClean = StringClean.Replace("@ShowSoftcoreImage", "")
		End If

		If StringClean.Contains("@ShowLesbianImage") Then
			If FrmSettings.CBURLLesbian.Checked = False Then Return StringClean
			If FrmSettings.CBILesbian.Checked = True And FrmSettings.CBURLLesbian.Checked = False Then Return StringClean
			If FrmSettings.CBILesbian.Checked = True And FrmSettings.CBURLLesbian.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Lesbian")
			StringClean = StringClean.Replace("@ShowLesbianImage", "")
		End If

		If StringClean.Contains("@ShowBlowjobImage") Then
			If FrmSettings.CBURLBlowjob.Checked = False Then Return StringClean
			If FrmSettings.CBIBlowjob.Checked = True And FrmSettings.CBURLBlowjob.Checked = False Then Return StringClean
			If FrmSettings.CBIBlowjob.Checked = True And FrmSettings.CBURLBlowjob.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Blowjob")
			StringClean = StringClean.Replace("@ShowBlowjobImage", "")
		End If

		If StringClean.Contains("@ShowFemdomImage") Then
			If FrmSettings.CBURLFemdom.Checked = False Then Return StringClean
			If FrmSettings.CBIFemdom.Checked = True And FrmSettings.CBURLFemdom.Checked = False Then Return StringClean
			If FrmSettings.CBIFemdom.Checked = True And FrmSettings.CBURLFemdom.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Femdom")
			StringClean = StringClean.Replace("@ShowFemdomImage", "")
		End If

		If StringClean.Contains("@ShowLezdomImage") Then
			If FrmSettings.CBURLLezdom.Checked = False Then Return StringClean
			If FrmSettings.CBILezdom.Checked = True And FrmSettings.CBURLLezdom.Checked = False Then Return StringClean
			If FrmSettings.CBILezdom.Checked = True And FrmSettings.CBURLLezdom.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Lezdom")
			StringClean = StringClean.Replace("@ShowLezdomImage", "")
		End If

		If StringClean.Contains("@ShowHentaiImage") Then
			If FrmSettings.CBURLHentai.Checked = False Then Return StringClean
			If FrmSettings.CBIHentai.Checked = True And FrmSettings.CBURLHentai.Checked = False Then Return StringClean
			If FrmSettings.CBIHentai.Checked = True And FrmSettings.CBURLHentai.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Hentai")
			StringClean = StringClean.Replace("@ShowHentaiImage", "")
		End If

		If StringClean.Contains("@ShowGayImage") Then
			If FrmSettings.CBURLGay.Checked = False Then Return StringClean
			If FrmSettings.CBIGay.Checked = True And FrmSettings.CBURLGay.Checked = False Then Return StringClean
			If FrmSettings.CBIGay.Checked = True And FrmSettings.CBURLGay.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Gay")
			StringClean = StringClean.Replace("@ShowGayImage", "")
		End If

		If StringClean.Contains("@ShowMaledomImage") Then
			If FrmSettings.CBURLMaledom.Checked = False Then Return StringClean
			If FrmSettings.CBIMaledom.Checked = True And FrmSettings.CBURLMaledom.Checked = False Then Return StringClean
			If FrmSettings.CBIMaledom.Checked = True And FrmSettings.CBURLMaledom.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Maledom")
			StringClean = StringClean.Replace("@ShowMaledomImage", "")
		End If

		If StringClean.Contains("@ShowCaptionsImage") Then
			If FrmSettings.CBURLCaptions.Checked = False Then Return StringClean
			If FrmSettings.CBICaptions.Checked = True And FrmSettings.CBURLCaptions.Checked = False Then Return StringClean
			If FrmSettings.CBICaptions.Checked = True And FrmSettings.CBURLCaptions.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("Captions")
			StringClean = StringClean.Replace("@ShowCaptionsImage", "")
		End If

		If StringClean.Contains("@ShowGeneralImage") Then
			If FrmSettings.CBURLGeneral.Checked = False Then Return StringClean
			If FrmSettings.CBIGeneral.Checked = True And FrmSettings.CBURLGeneral.Checked = False Then Return StringClean
			If FrmSettings.CBIGeneral.Checked = True And FrmSettings.CBURLGeneral.Checked = True Then
				If randomizer.Next(1, 101) < 51 Then Return StringClean
			End If
			JustShowedBlogImage = True
			CacheImage("General")
			StringClean = StringClean.Replace("@ShowGeneralImage", "")
		End If

		Return StringClean

	End Function


	Public Sub CheckLocalImage(ByVal dir As String, ByVal subdir As Boolean)


		Dim PornList As New List(Of String)
		PornList.Clear()
		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim files As String()
		Try
			If subdir = True Then
				files = myDirectory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
			Else
				files = myDirectory.GetFiles(dir, "*.*")
			End If

			Array.Sort(files)

			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					PornList.Add(fi)
				End If
			Next

			If PornList.Count = 0 Then
				FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			Else
				Do
					FoundString = PornList(randomizer.Next(0, PornList.Count))
				Loop Until FoundString <> ""
			End If
		Catch
			FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
		End Try


		 ShowGotImage()

	End Sub

	Public Function CheckGenreImage(ByVal Genre As String) As Boolean

		If CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or LockImage = True Then Return False

		If Genre = "Hardcore" Then
			If FrmSettings.CBIHardcore.Checked = False And FrmSettings.CBURLHardcore.Checked = False Then Return False
			If FrmSettings.CBIHardcore.Checked And Not Directory.Exists(FrmSettings.LBLIHardcore.Text) Then Return False
			If FrmSettings.CBURLHardcore.Checked And Not File.Exists(FrmSettings.LBLURLHardcore.Text) Then Return False
		End If

		If Genre = "Softcore" Then
			If FrmSettings.CBISoftcore.Checked = False And FrmSettings.CBURLSoftcore.Checked = False Then Return False
			If FrmSettings.CBISoftcore.Checked And Not Directory.Exists(FrmSettings.LBLISoftcore.Text) Then Return False
			If FrmSettings.CBURLSoftcore.Checked And Not File.Exists(FrmSettings.LBLURLSoftcore.Text) Then Return False
		End If

		If Genre = "Lesbian" Then
			If FrmSettings.CBILesbian.Checked = False And FrmSettings.CBURLLesbian.Checked = False Then Return False
			If FrmSettings.CBILesbian.Checked And Not Directory.Exists(FrmSettings.LBLILesbian.Text) Then Return False
			If FrmSettings.CBURLLesbian.Checked And Not File.Exists(FrmSettings.LBLURLLesbian.Text) Then Return False
		End If

		If Genre = "Blowjob" Then
			If FrmSettings.CBIBlowjob.Checked = False And FrmSettings.CBURLBlowjob.Checked = False Then Return False
			If FrmSettings.CBIBlowjob.Checked And Not Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then Return False
			If FrmSettings.CBURLBlowjob.Checked And Not File.Exists(FrmSettings.LBLURLBlowjob.Text) Then Return False
		End If

		If Genre = "Femdom" Then
			If FrmSettings.CBIFemdom.Checked = False And FrmSettings.CBURLFemdom.Checked = False Then Return False
			If FrmSettings.CBIFemdom.Checked And Not Directory.Exists(FrmSettings.LBLIFemdom.Text) Then Return False
			If FrmSettings.CBURLFemdom.Checked And Not File.Exists(FrmSettings.LBLURLFemdom.Text) Then Return False
		End If

		If Genre = "Lezdom" Then
			If FrmSettings.CBILezdom.Checked = False And FrmSettings.CBURLLezdom.Checked = False Then Return False
			If FrmSettings.CBILezdom.Checked And Not Directory.Exists(FrmSettings.LBLILezdom.Text) Then Return False
			If FrmSettings.CBURLLezdom.Checked And Not File.Exists(FrmSettings.LBLURLLezdom.Text) Then Return False
		End If

		If Genre = "Hentai" Then
			If FrmSettings.CBIHentai.Checked = False And FrmSettings.CBURLHentai.Checked = False Then Return False
			If FrmSettings.CBIHentai.Checked And Not Directory.Exists(FrmSettings.LBLIHentai.Text) Then Return False
			If FrmSettings.CBURLHentai.Checked And Not File.Exists(FrmSettings.LBLURLHentai.Text) Then Return False
		End If

		If Genre = "Gay" Then
			If FrmSettings.CBIGay.Checked = False And FrmSettings.CBURLGay.Checked = False Then Return False
			If FrmSettings.CBIGay.Checked And Not Directory.Exists(FrmSettings.LBLIGay.Text) Then Return False
			If FrmSettings.CBURLGay.Checked And Not File.Exists(FrmSettings.LBLURLGay.Text) Then Return False
		End If

		If Genre = "Maledom" Then
			If FrmSettings.CBIMaledom.Checked = False And FrmSettings.CBURLMaledom.Checked = False Then Return False
			If FrmSettings.CBIMaledom.Checked And Not Directory.Exists(FrmSettings.LBLIMaledom.Text) Then Return False
			If FrmSettings.CBURLMaledom.Checked And Not File.Exists(FrmSettings.LBLURLMaledom.Text) Then Return False
		End If

		If Genre = "Captions" Then
			If FrmSettings.CBICaptions.Checked = False And FrmSettings.CBURLCaptions.Checked = False Then Return False
			If FrmSettings.CBICaptions.Checked And Not Directory.Exists(FrmSettings.LBLICaptions.Text) Then Return False
			If FrmSettings.CBURLCaptions.Checked And Not File.Exists(FrmSettings.LBLURLCaptions.Text) Then Return False
		End If

		If Genre = "General" Then
			If FrmSettings.CBIGeneral.Checked = False And FrmSettings.CBURLGeneral.Checked = False Then Return False
			If FrmSettings.CBIGeneral.Checked And Not Directory.Exists(FrmSettings.LBLIGeneral.Text) Then Return False
			If FrmSettings.CBURLGeneral.Checked And Not File.Exists(FrmSettings.LBLURLGeneral.Text) Then Return False
		End If


		Return True

	End Function

	Public Sub SaveSessionImage(ByVal SessionImage As Image)

		If FrmSettings.CBBlogImageWindow.Checked = True Then
			Dim ImageFlag As String = ImageLocation

			'Skip all local Files.
			If ImageFlag.Contains("/") And ImageFlag.Contains("://") Then
				Do Until Not ImageFlag.Contains("/")
					ImageFlag = ImageFlag.Remove(0, 1)
				Loop

				If Not File.Exists(Application.StartupPath & "\Images\Session Images\" & ImageFlag) Then
					SessionImage.Save(Application.StartupPath & "\Images\Session Images\" & ImageFlag)
					FrmSettings.CalculateSessionImages()
				Else
					Debug.Print("Session Image already exists")
				End If
			End If
		End If
	End Sub


End Class
