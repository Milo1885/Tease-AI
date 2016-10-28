Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports Runtime.Serialization.Formatters.Binary
Namespace My

	Partial Friend Class MyApplication
		Friend Session As New SessionState
	End Class
	''' <summary>
	''' Class to store/serialize and deserialize all nessecary session(!) informations.
	''' </summary>
	<Serializable>
	Public Class SessionState

		Public Property Chat As String

		Public Property SlideshowDomme As Slideshow
		Public Property SlideshowContact1 As Slideshow
		Public Property SlideshowContact2 As Slideshow
		Public Property SlideshowContact3 As Slideshow

		Public randomizer As New Random
		Public ScriptOperator As String
		<Obsolete("Only used in Supend/resmue. Don not use anymore")>
		Public ScriptCompare As String

		Public DomTyping As Boolean

		Public CheckYes As Boolean
		Public CheckNo As Boolean

		Public Playlist As Boolean
		Public PlaylistFile As New List(Of String)
		Public PlaylistCurrent As Integer



		Public Responding As Boolean

		Public StrokeTauntVal As Integer
		Public FileText As String
		Public TempStrokeTauntVal As Integer
		Public TempFileText As String

		Public TeaseTick As Integer

		Public StrokeTauntCount As Integer
		Public TauntTextTotal As Integer
		Public TauntLines As New List(Of String)
		Public StrokeFilter As Boolean

		Public ScriptTick As Integer
		Public StringLength As Integer
		Public FileGoto As String
		Public SkipGotoLine As Boolean

		Public ChatString As String
		Public DomTask As String
		Public DomChat As String
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

		Public CBTBallsFirst As Boolean
		Public CBTCockFirst As Boolean

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
		Public SubWroteLast As Boolean
		Public YesOrNo As Boolean
		Public GotoFlag As Boolean

		Public CBT As Boolean

		Public RunningScript As Boolean

		Public BeforeTease As Boolean
		Public SubStroking As Boolean
		Public SubEdging As Boolean
		Public SubHoldingEdge As Boolean
		Public EndTease As Boolean

		Public ShowModule As Boolean
		Public ModuleEnd As Boolean

		Public DivideText As Boolean

		Public HoldEdgeTick As Integer
		Public HoldEdgeChance As Integer

		Public EdgeHold As Boolean
		Public EdgeNoHold As Boolean
		Public EdgeToRuin As Boolean
		Public EdgeToRuinSecret As Boolean
		Public LongEdge As Boolean

		Public AskedToGiveUp As Boolean
		Public AskedToGiveUpSection As Boolean
		Public SubGaveUp As Boolean
		Public AskedToSpeedUp As Boolean
		Public AskedToSlowDown As Boolean

		<Obsolete("Only used in Supend/Resume")>
		Public ThoughtEnd As Boolean

		Public VTLength As Integer

		Public DommeVideo As Boolean
		Public VideoType As String
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

		Public UpdatesTick As Integer
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

		Public JustShowedBlogImage As Boolean

		Public SaidHello As Boolean

		<Obsolete("Unused variable. Set often to some values, but Metronome uses StrokePace and the the CheckBoxValue in Metronome app")>
		Public StopMetronome As Boolean

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
		Public WritingTaskFlag As Boolean

		Public FirstRound As Boolean
		Public StartStrokingCount As Integer

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

		Public BookmarkModule As Boolean
		Public BookmarkModuleFile As String
		Public BookmarkModuleLine As Integer
		Public BookmarkLink As Boolean
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

		Public OrgasmYesNo As Boolean

		Public VTFlag As Boolean

		Public Shared DomPersonality As String
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
		Public Contact1Pics As New List(Of String)
		Public Contact2Pics As New List(Of String)
		Public Contact3Pics As New List(Of String)
		Public Contact1PicsCount As Integer
		Public Contact2PicsCount As Integer
		Public Contact3PicsCount As Integer
		Public Group As String = "D"

		Public CustomTask As Boolean
		Public CustomTaskFirst As Boolean
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
		Public CBTBothFirst As Boolean


		Public Event StrokePaceChanged(ByVal Pace As Integer)

		Public StrokePace As Integer

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
		Public ImageLocation As String

		Public ResponseYes As String
		Public ResponseNo As String

		Public SetModule As String = ""
		Public SetLink As String = ""
		Public SetModuleGoto As String = ""
		Public SetLinkGoto As String = ""


		Public OrgasmRestricted As Boolean

		Public FollowUp As String = ""

		Public WorshipMode As Boolean
		Public WorshipTarget As String = ""

		Public LongHold As Boolean
		Public ExtremeHold As Boolean
		Public LongTaunts As Boolean



		Public MiniScript As Boolean
		Public MiniScriptText As String
		Public MiniTauntVal As Integer
		Public MiniTimerCheck As Boolean


		Public JumpVideo As Boolean
		Public VideoTick As Integer

		Public EdgeGoto As Boolean
		Public EdgeMessage As Boolean
		Public EdgeVideo As Boolean

		Public EdgeMessageText As String
		Public EdgeGotoLine As String

		Public MultipleEdges As Boolean
		Public MultipleEdgesAmount As Integer
		Public MultipleEdgesInterval As Integer
		Public MultipleEdgesTick As Integer
		Public MultipleEdgesMetronome As String = ""

		Public YesGoto As Boolean
		Public YesVideo As Boolean
		Public NoGoto As Boolean
		Public NoVideo_Mode As Boolean
		Public CameGoto As Boolean
		Public CameVideo As Boolean
		Public CameMessage As Boolean
		Public CameMessageText As String
		Public RuinedGoto As Boolean
		Public RuinedVideo As Boolean
		Public RuinedMessage As Boolean
		Public RuinedMessageText As String
		Public YesGotoLine As String
		Public NoGotoLine As String
		Public CameGotoLine As String
		Public RuinedGotoLine As String




		Public _
			Timer1_enabled,
			SendTimer_enabled,
			IsTypingTimer_enabled,
			StrokeTimer_enabled,
			StrokeTauntTimer_enabled,
			DelayTimer_enabled,
			CensorshipTimer_enabled,
			AudibleMetronome_enabled,
			ContactTimer_enabled,
			CustomSlideshowTimer_enabled,
			RLGLTimer_enabled,
			StrokeTimeTotalTimer_enabled,
			EdgeCountTimer_enabled,
			TnASlides_enabled,
			SlideshowTimer_enabled,
			WaitTimer_enabled,
			StupidTimer_enabled,
			VideoTauntTimer_enabled,
			RLGLTauntTimer_enabled,
			AvoidTheEdgeTaunts_enabled,
			TeaseTimer_enabled,
			UpdatesTimer_enabled,
			AvoidTheEdge_enabled,
			AvoidTheEdgeResume_enabled,
			EdgeTauntTimer_enabled,
			HoldEdgeTimer_enabled,
			HoldEdgeTauntTimer_enabled,
			Contact1Timer_enabled,
			Contact2Timer_enabled,
			Contact3Timer_enabled,
			UpdateStageTimer_enabled,
			WMPTimer_enabled As Boolean


		''' <summary>
		''' Set to true if the sub is on the edge and the domme had decided to not to stop stroking.
		''' </summary>
		''' <remarks>
		''' Uses following vocabulary Files:
		''' #SYS_TauntEdging.txt when the taunting begins.
		''' #SYS_TauntEdgingAsked.txt if the sub continues to tell he's on the edge.
		''' </remarks>
		Public TauntEdging As Boolean

		Public Modes As New Dictionary(Of String, Mode)(System.StringComparer.OrdinalIgnoreCase)

		Public WritingTaskCurrentTime As Single

		Sub New() : End Sub

		<NonSerialized>
		Dim _Activator As Form1 = Nothing

		Friend Sub activate(ByVal Activator As Form1)
			_Activator = Activator
			With Activator
				.Timer1.Enabled = Timer1_enabled
				.SendTimer.Enabled = SendTimer_enabled
				.IsTypingTimer.Enabled = IsTypingTimer_enabled
				.StrokeTimer.Enabled = StrokeTimer_enabled
				.StrokeTauntTimer.Enabled = StrokeTauntTimer_enabled
				.DelayTimer.Enabled = DelayTimer_enabled
				.CensorshipTimer.Enabled = CensorshipTimer_enabled
				.AudibleMetronome.Enabled = AudibleMetronome_enabled
				.ContactTimer.Enabled = ContactTimer_enabled
				.CustomSlideshowTimer.Enabled = CustomSlideshowTimer_enabled
				.RLGLTimer.Enabled = RLGLTimer_enabled
				.StrokeTimeTotalTimer.Enabled = StrokeTimeTotalTimer_enabled
				.EdgeCountTimer.Enabled = EdgeCountTimer_enabled
				.TnASlides.Enabled = TnASlides_enabled
				.SlideshowTimer.Enabled = SlideshowTimer_enabled
				.WaitTimer.Enabled = WaitTimer_enabled
				.StupidTimer.Enabled = StupidTimer_enabled
				.VideoTauntTimer.Enabled = VideoTauntTimer_enabled
				.RLGLTauntTimer.Enabled = RLGLTauntTimer_enabled
				.AvoidTheEdgeTaunts.Enabled = AvoidTheEdgeTaunts_enabled
				.TeaseTimer.Enabled = TeaseTimer_enabled
				.UpdatesTimer.Enabled = UpdatesTimer_enabled
				.AvoidTheEdge.Enabled = AvoidTheEdge_enabled
				.AvoidTheEdgeResume.Enabled = AvoidTheEdgeResume_enabled
				.EdgeTauntTimer.Enabled = EdgeTauntTimer_enabled
				.HoldEdgeTimer.Enabled = HoldEdgeTimer_enabled
				.HoldEdgeTauntTimer.Enabled = HoldEdgeTauntTimer_enabled
				.Contact1Timer.Enabled = Contact1Timer_enabled
				.Contact2Timer.Enabled = Contact2Timer_enabled
				.Contact3Timer.Enabled = Contact3Timer_enabled
				.UpdateStageTimer.Enabled = UpdateStageTimer_enabled
				.WMPTimer.Enabled = WMPTimer_enabled

				If SlideshowLoaded = True And File.Exists(_ImageFileNames(FileCount)) Then
					.ShowImage(_ImageFileNames(FileCount), True)
				End If

				.ChatText.DocumentText = Chat
				.ChatText2.DocumentText = Chat
				.ChatReadyState()

				.StrokePace = StrokePace

			End With

		End Sub

		Friend Sub Store(ByVal filepath As String)
			Dim stream As FileStream = Nothing
			Try
				If _Activator Is Nothing Then _Activator = My.Application.ApplicationContext.MainForm
				With _Activator
					Timer1_enabled = .Timer1.Enabled
					SendTimer_enabled = .SendTimer.Enabled
					IsTypingTimer_enabled = .IsTypingTimer.Enabled
					StrokeTimer_enabled = .StrokeTimer.Enabled
					StrokeTauntTimer_enabled = .StrokeTauntTimer.Enabled
					DelayTimer_enabled = .DelayTimer.Enabled
					CensorshipTimer_enabled = .CensorshipTimer.Enabled
					AudibleMetronome_enabled = .AudibleMetronome.Enabled
					ContactTimer_enabled = .ContactTimer.Enabled
					CustomSlideshowTimer_enabled = .CustomSlideshowTimer.Enabled
					RLGLTimer_enabled = .RLGLTimer.Enabled
					StrokeTimeTotalTimer_enabled = .StrokeTimeTotalTimer.Enabled
					EdgeCountTimer_enabled = .EdgeCountTimer.Enabled
					TnASlides_enabled = .TnASlides.Enabled
					SlideshowTimer_enabled = .SlideshowTimer.Enabled
					WaitTimer_enabled = .WaitTimer.Enabled
					StupidTimer_enabled = .StupidTimer.Enabled
					VideoTauntTimer_enabled = .VideoTauntTimer.Enabled
					RLGLTauntTimer_enabled = .RLGLTauntTimer.Enabled
					AvoidTheEdgeTaunts_enabled = .AvoidTheEdgeTaunts.Enabled
					TeaseTimer_enabled = .TeaseTimer.Enabled
					UpdatesTimer_enabled = .UpdatesTimer.Enabled
					AvoidTheEdge_enabled = .AvoidTheEdge.Enabled
					AvoidTheEdgeResume_enabled = .AvoidTheEdgeResume.Enabled
					EdgeTauntTimer_enabled = .EdgeTauntTimer.Enabled
					HoldEdgeTimer_enabled = .HoldEdgeTimer.Enabled
					HoldEdgeTauntTimer_enabled = .HoldEdgeTauntTimer.Enabled
					Contact1Timer_enabled = .Contact1Timer.Enabled
					Contact2Timer_enabled = .Contact2Timer.Enabled
					Contact3Timer_enabled = .Contact3Timer.Enabled
					UpdateStageTimer_enabled = .UpdateStageTimer.Enabled
					WMPTimer_enabled = .WMPTimer.Enabled
				End With

				stream = File.Create(filepath)
				Dim formatter As New BinaryFormatter()
				Console.WriteLine("Serializing vector")
				formatter.Serialize(stream, Me)
			Catch ex As Exception
				Throw
			Finally
				If stream IsNot Nothing Then stream.Close()
			End Try
		End Sub

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

	End Class

End Namespace

