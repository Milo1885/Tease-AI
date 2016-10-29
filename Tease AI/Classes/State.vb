Option Explicit On

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace My

	Partial Friend Class MyApplication
		Friend Session As New SessionState
	End Class
	''' <summary>
	''' Class to store/serialize and deserialize all nessecary session(!) informations.
	''' </summary>
	''' <remarks>
	''' After loading from file, the object needs to be set and activated! 
	''' </remarks>
	<Serializable>
	Public Class SessionState
		'TODO-Next: Clode Cleanup

#Region "------------------------------------------- Data -----------------------------------------------"
		Public Property Chat As String

		Public randomizer As New Random
		Public ScriptOperator As String
		<Obsolete("Only used in Supend/resmue. Don not use anymore")>
		Public ScriptCompare As String

		Public Property DomTyping As Boolean

		Public Property CheckYes As Boolean
		Public Property CheckNo As Boolean

		Public Property Playlist As Boolean
		Public Property PlaylistFile As New List(Of String)
		Public Property PlaylistCurrent As Integer



		Public Property Responding As Boolean

		Public Property StrokeTauntVal As Integer = -1
		Public Property FileText As String
		Public Property TempStrokeTauntVal As Integer
		Public Property TempFileText As String

		Public Property TeaseTick As Integer

		Public Property StrokeTauntCount As Integer
		Public Property TauntTextTotal As Integer
		Public Property TauntLines As New List(Of String)
		Public Property StrokeFilter As Boolean

		Public ScriptTick As Integer
		Public StringLength As Integer
		Public FileGoto As String
		Public SkipGotoLine As Boolean

		Public ChatString As String
		Public DomTask As String = "@SystemMessage <b>Tease AI has been reset</b>"
		Public DomChat As String = "@SystemMessage <b>Tease AI has been reset</b>"
		Public TypeDelay As Integer
		Public TempVal As Integer
		Public NullResponse As Boolean

		Public TagCount As Integer
		Public LocalTagCount As Integer

		Public TaskFile As String
		Public TaskText As String
		Public TaskTextDir As String


		Public ResponseFile As String
		Public ResponseLine As Integer

		Public CBTCockActive As Boolean
		Public CBTBallsActive As Boolean

		Public CBTCockFlag As Boolean
		Public CBTBallsFlag As Boolean

		Public CBTBallsFirst As Boolean = True
		Public CBTCockFirst As Boolean = True

		Public CBTBallsCount As Integer
		Public CBTCockCount As Integer

		Public TasksCount As Integer = "0"

		Public GotoDommeLevel As Boolean

		Public DommeMood As Integer

		Public AFK As Boolean


		Public HypnoGen As Boolean
		Public Induction As Boolean
		Public TempHypno As String

		Public StrokeTick As Integer
		Public StrokeTauntTick As Integer



		Public StrokeTimeTotal As Integer
		Public HoldEdgeTime As Integer
		Public HoldEdgeTimeTotal As Integer

		Public EdgeTauntInt As Integer

		Public DelayTick As Integer

		Public DomTypeCheck As Boolean
		Public TypeToggle As Boolean
		Public IsTyping As Boolean
		Public SubWroteLast As Boolean = False
		Public YesOrNo As Boolean = False
		Public GotoFlag As Boolean

		Public CBT As Boolean

		Public RunningScript As Boolean

		Public BeforeTease As Boolean
		Public SubStroking As Boolean = False
		Public SubEdging As Boolean = False
		Public SubHoldingEdge As Boolean = False
		Public EndTease As Boolean

		Public ShowModule As Boolean = False
		Public ModuleEnd As Boolean

		Public DivideText As Boolean

		Public HoldEdgeTick As Integer
		Public HoldEdgeChance As Integer

		Public EdgeHold As Boolean
		Public EdgeNoHold As Boolean
		Public EdgeToRuin As Boolean
		Public EdgeToRuinSecret As Boolean = True
		Public LongEdge As Boolean

		Public AskedToGiveUp As Boolean
		Public AskedToGiveUpSection As Boolean
		Public SubGaveUp As Boolean
		Public AskedToSpeedUp As Boolean = False
		Public AskedToSlowDown As Boolean = False

		<Obsolete("Only used in Supend/Resume")>
		Public ThoughtEnd As Boolean
		<Obsolete("Used in #VTLenth but delivers a wrong value.")>
		Public VTLength As Integer


		Public DommeVideo As Boolean
		Public VideoType As String = "General"
		Public CensorshipGame As Boolean
		Public CensorshipTick As Integer
		Public CensorDuration As String
		Public AvoidTheEdgeGame As Boolean
		Public AvoidTheEdgeTick As Integer
		Public AvoidTheEdgeTimerTick As Integer
		Public AvoidTheEdgeDuration As String
		Public AvoidTheEdgeStroking As Boolean
		Public AtECountdown As Integer

		Public VTPath As String
		Public NoVideo As Boolean
		Public NoSpecialVideo As Boolean
		Public VideoCheck As Boolean
		Public VideoTease As Boolean

		Public RLGLGame As Boolean
		Public RLGLStroking As Boolean
		Public RLGLTick As Integer
		Public RedLight As Boolean
		Public RLGLTauntTick As Integer

		Public RandomizerVideo As Boolean
		Public RandomizerVideoTease As Boolean

		Public ScriptVideoTease As String
		Public ScriptVideoTeaseFlag As Boolean

		Public VideoTauntTick As Integer


		Public SlideshowLoaded As Boolean
		<Obsolete("Only used in Supend/resume")>
		Public GlitterImageAV As String = IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) & "\Images\Glitter\01.jpg"
		<Obsolete("Only used in Supend/resume")>
		Public GlitterTempColor As String

		Public UpdatesTick As Integer = 120
		Public UpdatingPost As Boolean
		Public UpdateStage As Integer
		Public UpdateStageTick As Integer
		Public StatusText As String
		Public ContactNumber As Integer
		Public ContactTick As Integer

		<Obsolete("Only used in Supend/resume. Only once set to false")>
		Public ContactFlag As Boolean
		Public StatusText1 As String
		Public StatusText2 As String
		Public StatusText3 As String

		Public StatusChance1 As Integer
		Public StatusChance2 As Integer
		Public StatusChance3 As Integer

		Public Update1 As Boolean
		Public Update2 As Boolean
		Public Update3 As Boolean

		Public GetFolder As String
		Public FileCount As Integer
		''' <summary>
		''' The highest accessible address in List. Same as:<see cref="_ImageFileNames"/>.Count - 1 
		''' </summary>
		<Obsolete("Duplicate Data! Use _ImageFileNames.count -1 instead")>
		Public FileCountMax As Integer
		Public _ImageFileNames As New List(Of String)
		<Obsolete("Not used anymore. Or change Filecount to this one, to enhance readablility")>
		Public _CurrentImage As Integer = -1
		Public WithTeaseImgDir As String
		<Obsolete("Belongs to frmSettings.")>
		Public ApproveImage As Integer = 0
		<Obsolete("Not used anymore.")>
		Public WIExit As Boolean
		<Obsolete("Non threadsafe duplicate of My.Settings.RecentSlideshows. Use this instead.")>
		Public RecentSlideshows As New List(Of String)
		<Obsolete("Read data using MainPictureBox.ImageLocation. Set data using ShowImage(String, Boolean) in future releases.")>
		Public MainPictureImage As String
		Public DomPic As String

		Public LockImage As Boolean
		Public LockVideo As Boolean

		Public LocalTagImageList As New List(Of String)

		<Obsolete("Not used anymore. Never set, but once resetted.")>
		Public Crazy As Boolean
		<Obsolete("Not used anymore. Never set, but once resetted.")>
		Public Vulgar As Boolean
		<Obsolete("Not used anymore. Never set, but once resetted.")>
		Public Supremacist As Boolean

		<Obsolete("Overrides the User.Config Settings on resumse Session. Not really nice.")>
		Public CockSize As Integer
		Public PetName As String

		Public TauntText As String
		Public ScriptCount As Integer
		Public TempScriptCount As Integer
		Public TauntTextCount As Integer

		Public SlideshowTimerTick As Integer





		Public LastScriptCountdown As Integer
		Public LastScript As Boolean

		Public JustShowedBlogImage As Boolean = False

		Public SaidHello As Boolean = False

		<Obsolete("Unused variable. Set often to some values, but Metronome uses StrokePace and the the CheckBoxValue in Metronome app")>
		Public StopMetronome As Boolean = True

		Public AvgEdgeStroking As Integer
		Public AvgEdgeNoTouch As Integer
		Public EdgeCountTick As Integer
		Public AvgEdgeStrokingFlag As Boolean
		Public AvgEdgeCount As Integer
		Public AvgEdgeCountRest As Integer
		Public EdgeTickCheck As Integer

		Public EdgeNOT As Boolean

		Public AlreadyStrokingEdge As Boolean

		Public WritingTaskLinesAmount As Integer
		Public WritingTaskLinesWritten As Integer
		Public WritingTaskLinesRemaining As Integer
		Public WritingTaskMistakesAllowed As Integer
		Public WritingTaskMistakesMade As Integer
		Public WritingTaskFlag As Boolean = False

		Public FirstRound As Boolean
		Public StartStrokingCount As Integer = 0
		<Obsolete("Not used anymore.")>
		Public TeaseJOI As Boolean
		Public TeaseVideo As Boolean

		<Obsolete("List is splitted up into BoobList and AssList")>
		Public TnAList As New List(Of String)
		Public BoobList As New List(Of String)
		Public AssList As New List(Of String)
		Public AssImage As Boolean = False
		Public BoobImage As Boolean = False

		Public FoundTag As String = "Null"
		Public TagGarment As String = "NULL"
		Public TagUnderwear As String = "NULL"
		Public TagTattoo As String = "NULL"
		Public TagSexToy As String = "NULL"
		Public TagFurniture As String = "NULL"

		Public BookmarkModule As Boolean = False
		Public BookmarkModuleFile As String
		Public BookmarkModuleLine As Integer
		Public BookmarkLink As Boolean = False
		Public BookmarkLinkFile As String
		Public BookmarkLinkLine As Integer

		Public WaitTick As Integer





		Public OrgasmDenied As Boolean
		Public OrgasmAllowed As Boolean
		Public OrgasmRuined As Boolean
		Public LastOrgasmType As String = ""

		<Obsolete("Not used anymore.")>
		Public StupidTick As Integer
		<Obsolete("Not used anymore.")>
		Public StupidFlag As Boolean

		Public CaloriesConsumed As Integer
		Public CaloriesGoal As Integer

		Public GoldTokens As Integer
		Public SilverTokens As Integer
		Public BronzeTokens As Integer

		Public EdgeFound As Boolean

		Public OrgasmYesNo As Boolean = False
		<Obsolete("Not used anymore.")>
		Public VTFlag As Boolean

		Public DomPersonality As String = String.Empty
		Public UpdateList As New List(Of String)

		Public GlitterDocument As String

		Public CustomSlideshow As Boolean
		<Obsolete("Not used anymore.")>
		Public CustomSlideshowTick As Integer
		Public CustomSlideshowList As New List(Of String)
		Public ImageString As String

		Public RapidFire As Boolean

		Public GlitterTease As Boolean
		Public AddContactTick As Integer

		Public Property SlideshowDomme As Slideshow
		<System.ComponentModel.Category("Contact1")>
		Public Property SlideshowContact1 As Slideshow
		Public Property SlideshowContact2 As Slideshow
		Public Property SlideshowContact3 As Slideshow

		'Public Contact1Pics As New List(Of String)
		'Public Contact2Pics As New List(Of String)
		'Public Contact3Pics As New List(Of String)
		'Public Contact1PicsCount As Integer
		'Public Contact2PicsCount As Integer
		'Public Contact3PicsCount As Integer
		Public Group As String = "D"

		Public CustomTask As Boolean
		Public CustomTaskFirst As Boolean = True
		Public CustomTaskText As String
		Public CustomTaskTextFirst As String
		Public CustomTaskActive As Boolean

		Public SubtitleCount As Integer
		Public VidFile As String


		Public RiskyDeal As Boolean
		Public RiskyEdges As Boolean
		Public RiskyDelay As Boolean
		Public FinalRiskyPick As Boolean

		Public SysMes As Boolean
		Public EmoMes As Boolean

		Public Contact1Edge As Boolean
		Public Contact2Edge As Boolean
		Public Contact3Edge As Boolean

		Public Contact1Stroke As Boolean
		Public Contact2Stroke As Boolean
		Public Contact3Stroke As Boolean

		Public ReturnFileText As String
		Public ReturnStrokeTauntVal As String
		Public ReturnSubState As String
		Public ReturnFlag As Boolean

		Public SessionEdges As Integer

		Public WindowCheck As Boolean

		Public StrokeFaster As Boolean
		Public StrokeFastest As Boolean
		Public StrokeSlower As Boolean
		Public StrokeSlowest As Boolean

		Public InputFlag As Boolean
		Public InputString As String

		Public RapidCode As Boolean

		Public CorrectedTypo As Boolean
		Public CorrectedWord As String

		Public DoNotDisturb As Boolean

		Public TypoSwitch As Integer = 1
		Public TyposDisabled As Boolean

		Public EdgeHoldSeconds As Integer
		Public EdgeHoldFlag As Boolean

		''' <summary>
		''' Addresses the current CustomSlideshow image.
		''' </summary>
		Public SlideshowInt As Integer
		Public JustShowedSlideshowImage As Boolean

		Public RandomSlideshowCategory As String

		Public ResetFlag As Boolean

		Public DommeTags As Boolean
		Public ThemeSettings As Boolean

		Public InputIcon As Boolean

		Public ApplyingTheme As Boolean
		Public AdjustingWindow As Boolean

		Public SplitContainerHeight As Integer

		Public DommeImageFound As Boolean

		Public LocalImageFound As Boolean
		Public LocalImageListCheck As Boolean

		Public CBTBothActive As Boolean
		Public CBTBothFlag As Boolean
		Public CBTBothCount As Integer
		Public CBTBothFirst As Boolean = True



		Public StrokePace As Integer = 0

		Public GeneralTime As String = "Afternoon"

		Public NewDommeSlideshow As Boolean
		Public OriginalDommeSlideshow As String

		Public TimeoutTick As Integer

		Public DommeImageSTR As String
		Public LocalImageSTR As String
		''' <summary>
		''' This Variable contains the Path of origin of the displayed Image. CheckDommeTag() uses 
		''' this string to get the curremt ImageData for the DommeTagApp.
		''' </summary>
		Public ImageLocation As String = ""

		Public ResponseYes As String
		Public ResponseNo As String

		Public SetModule As String = ""
		Public SetLink As String = ""
		Public SetModuleGoto As String = ""
		Public SetLinkGoto As String = ""


		Public OrgasmRestricted As Boolean

		Public FollowUp As String = ""

		Public WorshipMode As Boolean = False
		Public WorshipTarget As String = ""

		Public LongHold As Boolean = False
		Public ExtremeHold As Boolean = False
		Public LongTaunts As Boolean



		Public MiniScript As Boolean = False
		Public MiniScriptText As String
		Public MiniTauntVal As Integer
		Public MiniTimerCheck As Boolean


		Public JumpVideo As Boolean
		Public VideoTick As Integer

		Public EdgeGoto As Boolean = False
		Public EdgeMessage As Boolean = False
		Public EdgeVideo As Boolean = False

		Public EdgeMessageText As String
		Public EdgeGotoLine As String

		Public MultipleEdges As Boolean
		Public MultipleEdgesAmount As Integer
		Public MultipleEdgesInterval As Integer
		Public MultipleEdgesTick As Integer
		Public MultipleEdgesMetronome As String = ""

		Public YesGoto As Boolean = False
		Public YesVideo As Boolean = False
		Public NoGoto As Boolean = False
		Public NoVideo_Mode As Boolean = False
		Public CameGoto As Boolean = False
		Public CameVideo As Boolean = False
		Public CameMessage As Boolean = False
		Public CameMessageText As String
		Public RuinedGoto As Boolean = False
		Public RuinedVideo As Boolean = False
		Public RuinedMessage As Boolean = False
		Public RuinedMessageText As String
		Public YesGotoLine As String
		Public NoGotoLine As String
		Public CameGotoLine As String
		Public RuinedGotoLine As String

		''' <summary>
		''' Set to true if the sub is on the edge and the domme had decided to not to stop stroking.
		''' </summary>
		''' <remarks>
		''' Uses following vocabulary Files:
		''' #SYS_TauntEdging.txt when the taunting begins.
		''' #SYS_TauntEdgingAsked.txt if the sub continues to tell he's on the edge.
		''' </remarks>
		Public TauntEdging As Boolean = False

		Public Modes As New Dictionary(Of String, Mode)(System.StringComparer.OrdinalIgnoreCase)

		Public WritingTaskCurrentTime As Single

#Region "----------------------------------- Only for Serialization -------------------------------------"

#Region "----------------------------------------- Form1.WMP --------------------------------------------"

		Public serialized_WMP_Visible As Boolean
		Public serialized_WMP_URL As String
		Public serialized_WMP_Position As Double
		Public serialized_WMP_Playstate As Long

#End Region ' Form1.WWMP

#Region "-----------------------------------------Form1.Timers-------------------------------------------"

		'===============================================================================
		'							Timer enable states
		'===============================================================================
		Public AudibleMetronome_enabled As Boolean = False
		Public AvoidTheEdge_enabled As Boolean = False
		Public AvoidTheEdgeResume_enabled As Boolean = False
		Public AvoidTheEdgeTaunts_enabled As Boolean = False
		Public CensorshipTimer_enabled As Boolean = False
		Public Contact1Timer_enabled As Boolean = False
		Public Contact2Timer_enabled As Boolean = False
		Public Contact3Timer_enabled As Boolean = False
		Public ContactTimer_enabled As Boolean = False
		Public CustomSlideshowTimer_enabled As Boolean = False
		Public DelayTimer_enabled As Boolean = False
		Public EdgeCountTimer_enabled As Boolean = False
		Public EdgeTauntTimer_enabled As Boolean = False
		Public HoldEdgeTauntTimer_enabled As Boolean = False
		Public HoldEdgeTimer_enabled As Boolean = False
		Public IsTypingTimer_enabled As Boolean = True
		Public RLGLTauntTimer_enabled As Boolean = False
		Public RLGLTimer_enabled As Boolean = False
		Public SendTimer_enabled As Boolean = False
		Public SlideshowTimer_enabled As Boolean = False
		Public StrokeTauntTimer_enabled As Boolean = False
		Public StrokeTimer_enabled As Boolean = False
		Public StrokeTimeTotalTimer_enabled As Boolean = True
		Public StupidTimer_enabled As Boolean = False
		Public TeaseTimer_enabled As Boolean = False
		Public Timer1_enabled As Boolean = False
		Public TnASlides_enabled As Boolean = False
		Public UpdateStageTimer_enabled As Boolean = False
		Public UpdatesTimer_enabled As Boolean = True
		Public VideoTauntTimer_enabled As Boolean = False
		Public WaitTimer_enabled As Boolean = False
		Public WMPTimer_enabled As Boolean = True

		'===============================================================================
		'							Timer intervals
		'===============================================================================
		Public AudibleMetronome_Interval As Integer = 30
		Public AvoidTheEdge_Interval As Integer = 1000
		Public AvoidTheEdgeResume_Interval As Integer = 1000
		Public AvoidTheEdgeTaunts_Interval As Integer = 1000
		Public CensorshipTimer_Interval As Integer = 1000
		Public Contact1Timer_Interval As Integer = 1000
		Public Contact2Timer_Interval As Integer = 1000
		Public Contact3Timer_Interval As Integer = 1000
		Public ContactTimer_Interval As Integer = 1000
		Public CustomSlideshowTimer_Interval As Integer = 1000
		Public DelayTimer_Interval As Integer = 1000
		Public EdgeCountTimer_Interval As Integer = 1000
		Public EdgeTauntTimer_Interval As Integer = 1000
		Public HoldEdgeTauntTimer_Interval As Integer = 1000
		Public HoldEdgeTimer_Interval As Integer = 1000
		Public IsTypingTimer_Interval As Integer = 110
		Public RLGLTauntTimer_Interval As Integer = 1000
		Public RLGLTimer_Interval As Integer = 1000
		Public SendTimer_Interval As Integer = 110
		Public SlideshowTimer_Interval As Integer = 1000
		Public StrokeTauntTimer_Interval As Integer = 1000
		Public StrokeTimer_Interval As Integer = 1000
		Public StrokeTimeTotalTimer_Interval As Integer = 1000
		Public StupidTimer_Interval As Integer = 300
		Public TeaseTimer_Interval As Integer = 1000
		Public Timer1_Interval As Integer = 110
		Public TnASlides_Interval As Integer = 334
		Public UpdateStageTimer_Interval As Integer = 1000
		Public UpdatesTimer_Interval As Integer = 1000
		Public VideoTauntTimer_Interval As Integer = 1000
		Public WaitTimer_Interval As Integer = 1000
		Public WMPTimer_Interval As Integer = 1000

#End Region ' Form1.Timers

#Region "--------------------------------------- Flags/Variables ----------------------------------------"

		Public serialized_Flags As List(Of String) = New List(Of String)
		Public serialized_FlagsTemp As List(Of String) = New List(Of String)
		Public serialized_Variables As New Dictionary(Of String, String)

#End Region ' Flags/Variables

#End Region ' Only for Serialization

#End Region ' DataSection

#Region "------------------------------------- Constructors----------------------------------------------"

		''' <summary>
		''' Creates a new unactivaed instance.
		''' </summary>
		Sub New() : End Sub

		''' <summary>
		''' Creates a new instance and activates it on the given Form.
		''' </summary>
		''' <param name="ActivationForm">The Form on which to apply the session.</param>
		Sub New(ByVal ActivationForm As Form1)
			activate(ActivationForm)
		End Sub

#End Region ' Constructors

#Region "----------------------------------------- Paths ------------------------------------------------"
		''' <summary>
		''' Returns the Path for the selected personality. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personality. Ends with Backslash!</returns>
		Friend ReadOnly Property PersonalityPath As String
			Get
				Return String.Format("{0}\Scripts\{1}\",
									  Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location),
									  DomPersonality)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities flags. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities flags. Ends with Backslash!</returns>
		Friend ReadOnly Property PersonalityFlagPath As String
			Get
				Return String.Format("{0}System\Flags\", PersonalityPath)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities temporary flags. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities temporary flags. Ends with Backslash!</returns>
		Friend ReadOnly Property PersonalityFlagTempPath As String
			Get
				Return String.Format("{0}Temp\", PersonalityFlagPath)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities variables. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities variables. Ends with Backslash!</returns>
		Friend ReadOnly Property PersonalityVariablesPath As String
			Get
				Return String.Format("{0}System\Variables\", PersonalityPath)
			End Get
		End Property

#End Region ' Paths

		Friend Sub activate(ByVal ActivationForm As Form1)
			With ActivationForm
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Disable Timers to avoid Exceptions
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				.AudibleMetronome.Enabled = False
				.AvoidTheEdge.Enabled = False
				.AvoidTheEdgeResume.Enabled = False
				.AvoidTheEdgeTaunts.Enabled = False
				.CensorshipTimer.Enabled = False
				.Contact1Timer.Enabled = False
				.Contact2Timer.Enabled = False
				.Contact3Timer.Enabled = False
				.ContactTimer.Enabled = False
				.CustomSlideshowTimer.Enabled = False
				.DelayTimer.Enabled = False
				.EdgeCountTimer.Enabled = False
				.EdgeTauntTimer.Enabled = False
				.HoldEdgeTauntTimer.Enabled = False
				.HoldEdgeTimer.Enabled = False
				.IsTypingTimer.Enabled = False
				.RLGLTauntTimer.Enabled = False
				.RLGLTimer.Enabled = False
				.SendTimer.Enabled = False
				.SlideshowTimer.Enabled = False
				.StrokeTauntTimer.Enabled = False
				.StrokeTimer.Enabled = False
				.StrokeTimeTotalTimer.Enabled = False
				.StupidTimer.Enabled = False
				.TeaseTimer.Enabled = False
				.Timer1.Enabled = False
				.TnASlides.Enabled = False
				.UpdateStageTimer.Enabled = False
				.UpdatesTimer.Enabled = False
				.VideoTauntTimer.Enabled = False
				.WaitTimer.Enabled = False
				.WMPTimer.Enabled = False



				.ssh = Me

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Set Domme Personality
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If DomPersonality = String.Empty Then
					DomPersonality = Settings.DomPersonality
				End If

				If .dompersonalitycombobox.Items.Contains(DomPersonality) = False Then
					Throw New Exception("The personality """ & DomPersonality & """ was not found.")
				Else
					.dompersonalitycombobox.SelectedItem = DomPersonality
				End If

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Restore Variables 
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If serialized_Variables.Count > 0 Then
					If Directory.Exists(PersonalityVariablesPath) = False Then
						Directory.CreateDirectory(PersonalityVariablesPath)
					Else
						For Each fn As String In Directory.GetFiles(PersonalityVariablesPath)
							File.Delete(fn)
						Next
					End If

					For Each fn As String In serialized_Variables.Keys
						Computer.FileSystem.WriteAllText(PersonalityVariablesPath & fn,
														serialized_Variables(fn), False)
					Next
				End If

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Restore flags 
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If serialized_Flags.Count > 0 Then
					If Directory.Exists(PersonalityFlagPath) = False Then
						Directory.CreateDirectory(PersonalityFlagPath)
					Else
						For Each fn As String In Directory.GetFiles(PersonalityFlagPath)
							File.Delete(fn)
						Next
					End If

					For Each fn As String In serialized_Flags
						Using fs As New FileStream(PersonalityFlagPath & fn,
												   FileMode.Create) : End Using
					Next
				End If
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'						Restore temporary flags 
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If serialized_FlagsTemp.Count > 0 Then
					If Directory.Exists(PersonalityFlagTempPath) = False Then
						Directory.CreateDirectory(PersonalityFlagTempPath)
					Else
						For Each fn As String In Directory.GetFiles(PersonalityFlagTempPath)
							File.Delete(fn)
						Next
					End If

					For Each fn As String In serialized_FlagsTemp
						Using fs As New FileStream(PersonalityFlagTempPath & fn,
												   FileMode.Create) : End Using
					Next
				End If
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'								Set Slideshows
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If SlideshowDomme Is Nothing Then SlideshowDomme = New Slideshow(ContactType.Domme)
				If SlideshowContact1 Is Nothing Then SlideshowContact1 = New Slideshow(ContactType.Contact1)
				If SlideshowContact2 Is Nothing Then SlideshowContact2 = New Slideshow(ContactType.Contact2)
				If SlideshowContact3 Is Nothing Then SlideshowContact3 = New Slideshow(ContactType.Contact3)

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Set Picturebox & WMP
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If isURL(ImageLocation) Then
					.ShowImage(ImageLocation, True)
				ElseIf File.Exists(ImageLocation) Then
					.ShowImage(ImageLocation, True)
				ElseIf SlideshowLoaded = True And _ImageFileNames.Count > 0 AndAlso File.Exists(_ImageFileNames(FileCount)) Then
					.ShowImage(_ImageFileNames(FileCount), True)
				Else
					.ClearMainPictureBox()
				End If

				.mainPictureBox.Visible = Not serialized_WMP_Visible
				.DomWMP.Visible = serialized_WMP_Visible
				.DomWMP.URL = serialized_WMP_URL
				.DomWMP.Ctlcontrols.currentPosition = serialized_WMP_Position

				If serialized_WMP_Playstate = 1 Then
					.DomWMP.Ctlcontrols.stop()
				ElseIf serialized_WMP_Playstate = 2 Then
					.DomWMP.Ctlcontrols.pause()
				ElseIf serialized_WMP_Playstate = 3 Then
					.DomWMP.Ctlcontrols.play()
				End If
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Set Chat and StrokePace
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

				.ChatText.DocumentText = Chat
				.ChatText2.DocumentText = Chat
				.ChatReadyState()

				' To update the threadsafe Metronome StrokePace 
				' Only needs to be done on activation
				.StrokePace = StrokePace

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'								Set Timer Intervals
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				.AudibleMetronome.Interval = AudibleMetronome_Interval
				.AvoidTheEdge.Interval = AvoidTheEdge_Interval
				.AvoidTheEdgeResume.Interval = AvoidTheEdgeResume_Interval
				.AvoidTheEdgeTaunts.Interval = AvoidTheEdgeTaunts_Interval
				.CensorshipTimer.Interval = CensorshipTimer_Interval
				.Contact1Timer.Interval = Contact1Timer_Interval
				.Contact2Timer.Interval = Contact2Timer_Interval
				.Contact3Timer.Interval = Contact3Timer_Interval
				.ContactTimer.Interval = ContactTimer_Interval
				.CustomSlideshowTimer.Interval = CustomSlideshowTimer_Interval
				.DelayTimer.Interval = DelayTimer_Interval
				.EdgeCountTimer.Interval = EdgeCountTimer_Interval
				.EdgeTauntTimer.Interval = EdgeTauntTimer_Interval
				.HoldEdgeTauntTimer.Interval = HoldEdgeTauntTimer_Interval
				.HoldEdgeTimer.Interval = HoldEdgeTimer_Interval
				.IsTypingTimer.Interval = IsTypingTimer_Interval
				.RLGLTauntTimer.Interval = RLGLTauntTimer_Interval
				.RLGLTimer.Interval = RLGLTimer_Interval
				.SendTimer.Interval = SendTimer_Interval
				.SlideshowTimer.Interval = SlideshowTimer_Interval
				.StrokeTauntTimer.Interval = StrokeTauntTimer_Interval
				.StrokeTimer.Interval = StrokeTimer_Interval
				.StrokeTimeTotalTimer.Interval = StrokeTimeTotalTimer_Interval
				.StupidTimer.Interval = StupidTimer_Interval
				.TeaseTimer.Interval = TeaseTimer_Interval
				.Timer1.Interval = Timer1_Interval
				.TnASlides.Interval = TnASlides_Interval
				.UpdateStageTimer.Interval = UpdateStageTimer_Interval
				.UpdatesTimer.Interval = UpdatesTimer_Interval
				.VideoTauntTimer.Interval = VideoTauntTimer_Interval
				.WaitTimer.Interval = WaitTimer_Interval
				.WMPTimer.Interval = WMPTimer_Interval

				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'							Set Timer EnableStates
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				.AudibleMetronome.Enabled = AudibleMetronome_enabled
				.AvoidTheEdge.Enabled = AvoidTheEdge_enabled
				.AvoidTheEdgeResume.Enabled = AvoidTheEdgeResume_enabled
				.AvoidTheEdgeTaunts.Enabled = AvoidTheEdgeTaunts_enabled
				.CensorshipTimer.Enabled = CensorshipTimer_enabled
				.Contact1Timer.Enabled = Contact1Timer_enabled
				.Contact2Timer.Enabled = Contact2Timer_enabled
				.Contact3Timer.Enabled = Contact3Timer_enabled
				.ContactTimer.Enabled = ContactTimer_enabled
				.CustomSlideshowTimer.Enabled = CustomSlideshowTimer_enabled
				.DelayTimer.Enabled = DelayTimer_enabled
				.EdgeCountTimer.Enabled = EdgeCountTimer_enabled
				.EdgeTauntTimer.Enabled = EdgeTauntTimer_enabled
				.HoldEdgeTauntTimer.Enabled = HoldEdgeTauntTimer_enabled
				.HoldEdgeTimer.Enabled = HoldEdgeTimer_enabled
				.IsTypingTimer.Enabled = IsTypingTimer_enabled
				.RLGLTauntTimer.Enabled = RLGLTauntTimer_enabled
				.RLGLTimer.Enabled = RLGLTimer_enabled
				.SendTimer.Enabled = SendTimer_enabled
				.SlideshowTimer.Enabled = SlideshowTimer_enabled
				.StrokeTauntTimer.Enabled = StrokeTauntTimer_enabled
				.StrokeTimer.Enabled = StrokeTimer_enabled
				.StrokeTimeTotalTimer.Enabled = StrokeTimeTotalTimer_enabled
				.StupidTimer.Enabled = StupidTimer_enabled
				.TeaseTimer.Enabled = TeaseTimer_enabled
				.Timer1.Enabled = Timer1_enabled
				.TnASlides.Enabled = TnASlides_enabled
				.UpdateStageTimer.Enabled = UpdateStageTimer_enabled
				.UpdatesTimer.Enabled = UpdatesTimer_enabled
				.VideoTauntTimer.Enabled = VideoTauntTimer_enabled
				.WaitTimer.Enabled = WaitTimer_enabled
				.WMPTimer.Enabled = WMPTimer_enabled


			End With

		End Sub

		Public Function Clone() As SessionState
			Return DirectCast(Me.MemberwiseClone(), SessionState)
		End Function

#Region "------------------------------------serialize/deserialize---------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Stores a running session to disk. 
		''' </summary>
		''' <param name="filepath">The Filepath to store to.</param>
		''' <param name="serializeForm">The Form to gather informations(Timer-States etc.) from.</param>
		''' <exception cref="Exception">Rethrows all exceptions.</exception>
		Friend Sub Store(ByVal filepath As String, ByVal serializeForm As Form1)
			Dim stream As FileStream = Nothing
			Try
				With serializeForm
					DomPersonality = .dompersonalitycombobox.SelectedItem

					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					'							Get Timer EnableStates
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					AudibleMetronome_enabled = .AudibleMetronome.Enabled
					AvoidTheEdge_enabled = .AvoidTheEdge.Enabled
					AvoidTheEdgeResume_enabled = .AvoidTheEdgeResume.Enabled
					AvoidTheEdgeTaunts_enabled = .AvoidTheEdgeTaunts.Enabled
					CensorshipTimer_enabled = .CensorshipTimer.Enabled
					Contact1Timer_enabled = .Contact1Timer.Enabled
					Contact2Timer_enabled = .Contact2Timer.Enabled
					Contact3Timer_enabled = .Contact3Timer.Enabled
					ContactTimer_enabled = .ContactTimer.Enabled
					CustomSlideshowTimer_enabled = .CustomSlideshowTimer.Enabled
					DelayTimer_enabled = .DelayTimer.Enabled
					EdgeCountTimer_enabled = .EdgeCountTimer.Enabled
					EdgeTauntTimer_enabled = .EdgeTauntTimer.Enabled
					HoldEdgeTauntTimer_enabled = .HoldEdgeTauntTimer.Enabled
					HoldEdgeTimer_enabled = .HoldEdgeTimer.Enabled
					IsTypingTimer_enabled = .IsTypingTimer.Enabled
					RLGLTauntTimer_enabled = .RLGLTauntTimer.Enabled
					RLGLTimer_enabled = .RLGLTimer.Enabled
					SendTimer_enabled = .SendTimer.Enabled
					SlideshowTimer_enabled = .SlideshowTimer.Enabled
					StrokeTauntTimer_enabled = .StrokeTauntTimer.Enabled
					StrokeTimer_enabled = .StrokeTimer.Enabled
					StrokeTimeTotalTimer_enabled = .StrokeTimeTotalTimer.Enabled
					StupidTimer_enabled = .StupidTimer.Enabled
					TeaseTimer_enabled = .TeaseTimer.Enabled
					Timer1_enabled = .Timer1.Enabled
					TnASlides_enabled = .TnASlides.Enabled
					UpdateStageTimer_enabled = .UpdateStageTimer.Enabled
					UpdatesTimer_enabled = .UpdatesTimer.Enabled
					VideoTauntTimer_enabled = .VideoTauntTimer.Enabled
					WaitTimer_enabled = .WaitTimer.Enabled
					WMPTimer_enabled = .WMPTimer.Enabled
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					'								Get Timer Intervals
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					AudibleMetronome_Interval = .AudibleMetronome.Interval
					AvoidTheEdge_Interval = .AvoidTheEdge.Interval
					AvoidTheEdgeResume_Interval = .AvoidTheEdgeResume.Interval
					AvoidTheEdgeTaunts_Interval = .AvoidTheEdgeTaunts.Interval
					CensorshipTimer_Interval = .CensorshipTimer.Interval
					Contact1Timer_Interval = .Contact1Timer.Interval
					Contact2Timer_Interval = .Contact2Timer.Interval
					Contact3Timer_Interval = .Contact3Timer.Interval
					ContactTimer_Interval = .ContactTimer.Interval
					CustomSlideshowTimer_Interval = .CustomSlideshowTimer.Interval
					DelayTimer_Interval = .DelayTimer.Interval
					EdgeCountTimer_Interval = .EdgeCountTimer.Interval
					EdgeTauntTimer_Interval = .EdgeTauntTimer.Interval
					HoldEdgeTauntTimer_Interval = .HoldEdgeTauntTimer.Interval
					HoldEdgeTimer_Interval = .HoldEdgeTimer.Interval
					IsTypingTimer_Interval = .IsTypingTimer.Interval
					RLGLTauntTimer_Interval = .RLGLTauntTimer.Interval
					RLGLTimer_Interval = .RLGLTimer.Interval
					SendTimer_Interval = .SendTimer.Interval
					SlideshowTimer_Interval = .SlideshowTimer.Interval
					StrokeTauntTimer_Interval = .StrokeTauntTimer.Interval
					StrokeTimer_Interval = .StrokeTimer.Interval
					StrokeTimeTotalTimer_Interval = .StrokeTimeTotalTimer.Interval
					StupidTimer_Interval = .StupidTimer.Interval
					TeaseTimer_Interval = .TeaseTimer.Interval
					Timer1_Interval = .Timer1.Interval
					TnASlides_Interval = .TnASlides.Interval
					UpdateStageTimer_Interval = .UpdateStageTimer.Interval
					UpdatesTimer_Interval = .UpdatesTimer.Interval
					VideoTauntTimer_Interval = .VideoTauntTimer.Interval
					WaitTimer_Interval = .WaitTimer.Interval
					WMPTimer_Interval = .WMPTimer.Interval

					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					'								Get WMP-Data
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					serialized_WMP_Visible = .DomWMP.Visible
					serialized_WMP_URL = .DomWMP.URL
					serialized_WMP_Playstate = .DomWMP.playState
					serialized_WMP_Position = .DomWMP.Ctlcontrols.currentPosition

					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					'								Get Flags
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					If serialized_Flags Is Nothing Then _
						serialized_Flags = New List(Of String)

					serialized_Flags.Clear()

					If Directory.Exists(PersonalityFlagPath) Then
						For Each fn As String In Directory.GetFiles(PersonalityFlagPath)
							serialized_Flags.Add(Path.GetFileName(fn))
						Next
					End If

					' Get temporary Flags
					If serialized_FlagsTemp Is Nothing Then _
						serialized_FlagsTemp = New List(Of String)
					serialized_FlagsTemp.Clear()

					If Directory.Exists(PersonalityFlagTempPath) Then
						For Each fn As String In Directory.GetFiles(PersonalityFlagTempPath)
							serialized_FlagsTemp.Add(fn)
						Next
					End If

					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					'								Get Variables
					'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
					If serialized_Variables Is Nothing Then _
						serialized_Variables = New Dictionary(Of String, String)

					serialized_Variables.Clear()

					If Directory.Exists(PersonalityVariablesPath) Then
						For Each fn As String In Directory.GetFiles(PersonalityVariablesPath)
							Dim val As String = TxtReadLine(fn)
							serialized_Variables.Add(Path.GetFileName(fn), val)
						Next
					End If


				End With

				stream = File.Create(filepath)
				Dim formatter As New BinaryFormatter()
				formatter.Serialize(stream, Me)
			Catch ex As Exception
				Throw
			Finally
				If stream IsNot Nothing Then stream.Close()
			End Try
		End Sub
		''' =========================================================================================================
		''' <summary>
		''' Loads a stored session from the given path. To start the session call <see cref="activate(Form1)"/>.
		''' </summary>
		''' <param name="filepath">The filepath to load the stored <see cref="SessionEdges"/> from.</param>
		''' <returns>Returns the stored deserialized unactivated(!) sessionState-Object.</returns>
		''' <exception cref="Exception">Rethrows all exceptions.</exception>
		Shared Function Load(ByVal filepath As String) As SessionState
			Dim stream As FileStream = Nothing
			Try
				' Restore from file
				stream = File.OpenRead(filepath)
				Dim formatter As New BinaryFormatter()
				stream = File.OpenRead(filepath)
				Return formatter.Deserialize(stream)
			Catch ex As Exception
				Throw
			Finally
				If stream IsNot Nothing Then stream.Close()
			End Try
		End Function
		''' =========================================================================================================
		''' <summary>
		''' Loads and activates a stored session from the given path.
		''' </summary>
		''' <param name="filepath">The path to load the state from.</param>
		''' <param name="ActivationForm">The form to activate the session on.</param>
		''' <exception cref="Exception">Rethrows all exceptions.</exception>
		Shared Sub Load(ByVal filepath As String, ByVal ActivationForm As Form1)
			Try
				Dim tmpState As SessionState = Load(filepath)
				tmpState.activate(ActivationForm)
			Catch ex As Exception
				Throw
			End Try
		End Sub

	End Class
#End Region 'serialize/deserialize
End Namespace

