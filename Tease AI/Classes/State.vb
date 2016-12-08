'===========================================================================================
'
'                                   SessionState-Class
'
'
' This File contains a Class to store all nessesary informations about a session.
'
' This Class is Version-Tolerant Serializable!
'
' Please take a look at: https://msdn.microsoft.com/en-us/library/ms229752(v=vs.110).aspx
'===========================================================================================
Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.IO
Imports System.Runtime.Serialization

''' <summary>
''' Class to store/serialize and deserialize all nessecary session(!) informations.
''' </summary>
''' <remarks>
''' After loading from file, the object needs to be set and activated!  
''' <para></para>
''' To ensure compatiblity between versions, new added fields have to be marked as 
''' <see cref="OptionalFieldAttribute"/>. The inital value if an old version is loaded, 
''' without that field, has to be set in <see cref="SessionState.onDeserialized_FixFields(StreamingContext)"/>.
''' For more inforations take a look at: https://msdn.microsoft.com/en-us/library/ms733734(v=vs.110).aspx
''' </remarks>
<Serializable>
Public Class SessionState
	Implements IDisposable
	'TODO-Next: Clode Cleanup

#Region "------------------------------------------- Data -----------------------------------------------"
	Const EditorGenericStringList As String = "System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"

	Public Property DomPersonality As String

	Public Property Chat As String

	Public Property randomizer As New Random
	Public Property ScriptOperator As String

	Public Property DomTyping As Boolean

	Public Property CheckYes As Boolean
	Public Property CheckNo As Boolean

	Public Property Playlist As Boolean
	<Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property PlaylistFile As New List(Of String)
	Public Property PlaylistCurrent As Integer


	Public Property TeaseTick As Integer
	Public Property Responding As Boolean

	Public Property StrokeTauntVal As Integer = -1
	<Category("Video")> Public Property TempStrokeTauntVal As Integer
	<Category("Video")> Public Property TempFileText As String

	''' <summary>Gets or sets the current TauntFile path.</summary>
	<Category("Taunts")> <Description("Path of current Taunt-file")>
	Public Property TauntText As String

	''' <summary>Gets or sets the length of a taunt group.</summary>
	<Category("Taunts")> <Description("Current line group size.")>
	Public Property StrokeTauntCount As Integer

	''' <summary> Duplicate of <see cref="TauntLines"/>.Count </summary>
	<Category("Taunts")> <Browsable(False)>
	<Obsolete("Obsolete as of v0.54.5.1. Left for version tolerance.", True)>
	Public Property TauntTextTotal As Integer

	''' <summary>Gets or sets the current taunt lines. </summary>
	<Category("Taunts")> <Description("Current taunt lines.")>
	<Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property TauntLines As New List(Of String)

	<Category("Taunts")> <[ReadOnly](True)>
	<Description("Indicates if taunt filtering is active")>
	Public Property StrokeFilter As Boolean

	''' <summary> Gets or Sets the current taunt line index. </summary>
	<Category("Taunts")> <Description("The current taunt line index.")>
	Public Property TauntTextCount As Integer


	<Category("Script")> Public Property FileText As String
	<Category("Script")> Public Property ScriptTick As Integer
	<Category("Script")> Public Property StringLength As Integer
	<Category("Script")> Public Property FileGoto As String
	<Category("Script")> Public Property SkipGotoLine As Boolean

	Public Property ChatString As String
	<Description("Used for regular talk.")>
	Public Property DomTask As String = "Null"
	<Description("Used for responses.")>
	Public Property DomChat As String = "Null"
	Public Property TypeDelay As Integer
	Public Property TempVal As Integer
	Public Property NullResponse As Boolean

	Public Property TaskFile As String
	Public Property TaskText As String
	Public Property TaskTextDir As String


	Public Property ResponseFile As String
	Public Property ResponseLine As Integer


	<Category("CBT")> Public Property CBTBothActive As Boolean
	<Category("CBT")> Public Property CBTBothFlag As Boolean
	<Category("CBT")> Public Property CBTBothFirst As Boolean = True

	<Category("CBT")> Public Property CBTCockActive As Boolean
	<Category("CBT")> Public Property CBTBallsActive As Boolean

	<Category("CBT")> Public Property CBTCockFlag As Boolean
	<Category("CBT")> Public Property CBTBallsFlag As Boolean

	<Category("CBT")> Public Property CBTBallsFirst As Boolean = True
	<Category("CBT")> Public Property CBTCockFirst As Boolean = True

	<Category("CBT")> Public Property CBTBallsCount As Integer
	<Category("CBT")> Public Property CBTCockCount As Integer

	Public Property TasksCount As Integer = 0

	Public Property GotoDommeLevel As Boolean

	Public Property DommeMood As Integer = -1

	Public Property AFK As Boolean


	Public Property HypnoGen As Boolean
	Public Property Induction As Boolean
	Public Property TempHypno As String

	Public Property StrokeTick As Integer
	''' <summary> Gets or sets time until next taunt.</summary>
	<Category("Taunts")> <Description("Time until next taunt")>
	Public Property StrokeTauntTick As Integer



	Public Property StrokeTimeTotal As Integer
	Public Property HoldEdgeTime As Integer
	Public Property HoldEdgeTimeTotal As Integer

	Public Property EdgeTauntInt As Integer

	Public Property DomTypeCheck As Boolean
	Public Property TypeToggle As Boolean
	Public Property IsTyping As Boolean
	Public Property SubWroteLast As Boolean = False
	<Description("True if sub has been asked a Yes/No Question.")>
	Public Property YesOrNo As Boolean = False
	Public Property GotoFlag As Boolean

	''' <summary>Gets or Sets if a taunt demanded CBT.</summary>
	<Category("Taunts")> <Description("Indicates if a taunt demanded CBT. CBT-Tasks are taken from ""[Personality Path]\CBT\CBT.txt"". The calling line in Taunt-file is completly replaced.")>
	Public Property CBT As Boolean

	Public Property RunningScript As Boolean

	Public Property BeforeTease As Boolean
	Public Property SubStroking As Boolean = False
	Public Property SubEdging As Boolean = False
	Public Property SubHoldingEdge As Boolean = False
	Public Property EndTease As Boolean

	Public Property ShowModule As Boolean = False
	Public Property ModuleEnd As Boolean

	Public Property DivideText As Boolean

	Public Property HoldEdgeTick As Integer
	Public Property HoldEdgeChance As Integer

	Public Property EdgeHold As Boolean
	Public Property EdgeNoHold As Boolean
	Public Property EdgeToRuin As Boolean
	Public Property EdgeToRuinSecret As Boolean = True
	Public Property LongEdge As Boolean

	<Obsolete("Set to true but never used.")>
	Public Property AskedToGiveUp As Boolean
	Public Property AskedToGiveUpSection As Boolean
	Public Property SubGaveUp As Boolean
	Public Property AskedToSpeedUp As Boolean = False
	Public Property AskedToSlowDown As Boolean = False


	<Category("Video")> Public Property LockVideo As Boolean
	<Category("Video")> Public Property DommeVideo As Boolean
	<Category("Video")> Public Property JumpVideo As Boolean
	<Category("Video")> Public Property NoSpecialVideo As Boolean
	<Category("Video")> Public Property RandomizerVideo As Boolean
	<Category("Video")> Public Property RandomizerVideoTease As Boolean
	<Category("Video")> Public Property ScriptVideoTease As String
	<Category("Video")> Public Property ScriptVideoTeaseFlag As Boolean
	<Category("Video")> Public Property VideoCheck As Boolean
	<Category("Video")> Public Property VideoTauntTick As Integer
	<Category("Video")> Public Property VideoTease As Boolean
	<Category("Video")> Public Property VideoTick As Integer
	<Category("Video")> Public Property VideoType As String = "General"
	<Category("Video")> Public Property VidFile As String
	<Category("Video")> Public Property VTPath As String
	<Category("Video")> <Obsolete("Used in #VTLenth but delivers a wrong value.")>
	Public Property VTLength As Integer
	<Category("Video - Avoid the Edge")> Public Property AtECountdown As Integer
	<Category("Video - Avoid the Edge")> Public Property AvoidTheEdgeGame As Boolean
	<Category("Video - Avoid the Edge")> Public Property AvoidTheEdgeStroking As Boolean
	<Category("Video - Avoid the Edge")> Public Property AvoidTheEdgeTick As Integer
	<Category("Video - Censorship")> Public Property CensorshipGame As Boolean
	<Category("Video - Censorship")> Public Property CensorshipTick As Integer
	<Category("Video - Red light green light")> Public Property RedLight As Boolean
	<Category("Video - Red light green light")> Public Property RLGLGame As Boolean
	<Category("Video - Red light green light")> Public Property RLGLTauntTick As Integer
	<Category("Video - Red light green light")> Public Property RLGLTick As Integer
	<Category("Video")> <Obsolete("Never set to TRUE")> Public Property NoVideo As Boolean

	<Category("Glitter")> <Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property UpdateList As New List(Of String)

	<Category("Glitter")> Public Property UpdatesTick As Integer = 120
	<Category("Glitter")> Public Property UpdatingPost As Boolean
	<Category("Glitter")> Public Property UpdateStage As Integer
	<Category("Glitter")> Public Property UpdateStageTick As Integer
	<Category("Glitter")> Public Property StatusText As String
	<Category("Glitter")> Public Property ContactNumber As Integer

	<Category("Glitter")> Public Property StatusText1 As String
	<Category("Glitter")> Public Property StatusText2 As String
	<Category("Glitter")> Public Property StatusText3 As String

	<Category("Glitter")> Public Property StatusChance1 As Integer
	<Category("Glitter")> Public Property StatusChance2 As Integer
	<Category("Glitter")> Public Property StatusChance3 As Integer

	<Category("Glitter")> Public Property Update1 As Boolean
	<Category("Glitter")> Public Property Update2 As Boolean
	<Category("Glitter")> Public Property Update3 As Boolean


	<Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property LocalTagImageList As New List(Of String)

	Public Property PetName As String
	''' <summary>Stores the number of taunt files, to determine taunt size.</summary>
	<Obsolete("Obsolete as of v0.54.5.1. Left for version tolerance.")>
	<Category("Taunts")> <Browsable(False)>
	Public Property ScriptCount As Integer
	<Category("Taunts")> Public Property TempScriptCount As Integer

	Public Property SlideshowTimerTick As Integer





	Public Property LastScriptCountdown As Integer
	Public Property LastScript As Boolean

	Public Property SaidHello As Boolean = False


	Public Property AvgEdgeStroking As Integer
	Public Property AvgEdgeNoTouch As Integer
	Public Property EdgeCountTick As Integer
	Public Property AvgEdgeStrokingFlag As Boolean
	Public Property AvgEdgeCount As Integer
	Public Property AvgEdgeCountRest As Integer
	Public Property EdgeTickCheck As Integer

	Public Property EdgeNOT As Boolean

	Public Property AlreadyStrokingEdge As Boolean

	<Category("WritingTask")> Public Property WritingTaskLinesAmount As Integer
	<Category("WritingTask")> Public Property WritingTaskLinesWritten As Integer
	<Category("WritingTask")> Public Property WritingTaskLinesRemaining As Integer
	<Category("WritingTask")> Public Property WritingTaskMistakesAllowed As Integer
	<Category("WritingTask")> Public Property WritingTaskMistakesMade As Integer
	<Category("WritingTask")> Public Property WritingTaskFlag As Boolean = False
	<Category("WritingTask")> Public Property WritingTaskCurrentTime As Single

	Public Property FirstRound As Boolean
	Public Property StartStrokingCount As Integer = 0
	<Obsolete("Not used anymore.")>
	Public TeaseJOI As Boolean
	Public Property TeaseVideo As Boolean

	<Category("Games - TnA")> <Description("This list contains all boob-images of TNA game.")>
	<Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property BoobList As New List(Of String)
	<Category("Games - TnA")> <Description("This list contains all butt-images of TNA game.")>
	<Editor(EditorGenericStringList, GetType(UITypeEditor))>
	Public Property AssList As New List(Of String)
	<Category("Games - TnA")> Public Property AssImage As Boolean = False
	<Category("Games - TnA")> Public Property BoobImage As Boolean = False

#Region "Tags:  all deprecated"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property FoundTag As String = "Null"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property TagGarment As String = "NULL"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property TagUnderwear As String = "NULL"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property TagTattoo As String = "NULL"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property TagSexToy As String = "NULL"

	<Category("Tags")> <Browsable(False)>
	<Obsolete("Deprecated as of v0.54.5.1. Left for serialization version tolerance.", True)>
	Public Property TagFurniture As String = "NULL"

#End Region ' Tags

	<Category("Bookmark")> Public Property BookmarkModule As Boolean = False
	<Category("Bookmark")> Public Property BookmarkModuleFile As String
	<Category("Bookmark")> Public Property BookmarkModuleLine As Integer
	<Category("Bookmark")> Public Property BookmarkLink As Boolean = False
	<Category("Bookmark")> Public Property BookmarkLinkFile As String
	<Category("Bookmark")> Public Property BookmarkLinkLine As Integer

	Public Property WaitTick As Integer





	Public Property OrgasmDenied As Boolean
	Public Property OrgasmAllowed As Boolean
	Public Property OrgasmRuined As Boolean
	Public Property LastOrgasmType As String = ""

	Public Property CaloriesConsumed As Integer
	Public Property CaloriesGoal As Integer

	<Category("Tokens")> <[ReadOnly](True)> Public Property GoldTokens As Integer
	<Category("Tokens")> <[ReadOnly](True)> Public Property SilverTokens As Integer
	<Category("Tokens")> <[ReadOnly](True)> Public Property BronzeTokens As Integer

	Public Property EdgeFound As Boolean

	Public Property OrgasmYesNo As Boolean = False

	<Category("Images")> <Description("Determines if the custom slideshow should run.")>
	Public Property CustomSlideEnabled As Boolean
	<Category("Images")> <Description("Stores all images and genre informations for CustomSlideshow")>
	Public Property CustomSlideshow As New CustomSlideshow
	<Obsolete("Obsolete as of v0.54.5.1. Left for version tolerance.", True)>
	<Category("Images")> <Browsable(False)> Public Property DommeImageFound As Boolean

	<Category("Images")>
	<Obsolete("DommeImageSTR is obsolete. Do not implement in new code.")>
	Public Property DommeImageSTR As String

	<Obsolete("Obsolete as of v0.54.5.1. Left for version tolerance.", True)>
	<Category("Images")> <Browsable(False)> Public Property DomPic As String
	<Obsolete("JustShowedBlogImage is obsolete. Do not implement in new code.")>
	<Category("Images")> Public Property JustShowedBlogImage As Boolean = False
	<Category("Images")> Public Property JustShowedSlideshowImage As Boolean = False
	<Category("Images")> Public Property LockImage As Boolean
	<Category("Images")> Public Property RandomSlideshowCategory As String
	<Category("Images")> <Description("True if main slideshow is loaded.")>
	Public Property SlideshowLoaded As Boolean
	<Category("Images")> Public Property SlideshowMain As ContactData
	<Category("Images")> Public Property SlideshowContact1 As ContactData
	<Category("Images")> Public Property SlideshowContact2 As ContactData
	<Category("Images")> Public Property SlideshowContact3 As ContactData

	<Category("Custom Task")> Public Property CustomTask As Boolean
	<Category("Custom Task")> Public Property CustomTaskFirst As Boolean = True
	<Category("Custom Task")> Public Property CustomTaskText As String
	<Category("Custom Task")> Public Property CustomTaskTextFirst As String
	<Category("Custom Task")> Public Property CustomTaskActive As Boolean


	<Category("Risky Pick")> Public Property RiskyDeal As Boolean
	<Category("Risky Pick")> Public Property RiskyEdges As Boolean
	<Category("Risky Pick")> Public Property RiskyDelay As Boolean

	Public Property SysMes As Boolean
	Public Property EmoMes As Boolean

	Public Property Group As String = "D"
	Public Property GlitterTease As Boolean
	Public Property AddContactTick As Integer

	Public Property Contact1Edge As Boolean
	Public Property Contact2Edge As Boolean
	Public Property Contact3Edge As Boolean

	Public Property Contact1Stroke As Boolean
	Public Property Contact2Stroke As Boolean
	Public Property Contact3Stroke As Boolean

	Public Property ReturnFileText As String
	Public Property ReturnStrokeTauntVal As String
	Public Property ReturnSubState As String
	Public Property returnFlag As Boolean

	Public Property SessionEdges As Integer


	Public Property StrokeFaster As Boolean
	Public Property StrokeFastest As Boolean
	Public Property StrokeSlower As Boolean
	Public Property StrokeSlowest As Boolean

	Public Property InputFlag As Boolean
	Public Property InputString As String

	Public Property RapidCode As Boolean
	Public Property RapidFire As Boolean

	<Category("Typos")> Public Property CorrectedTypo As Boolean
	<Category("Typos")> Public Property CorrectedWord As String
	<Category("Typos")> Public Property TypoSwitch As Integer = 1
	<Category("Typos")> Public Property TyposDisabled As Boolean

	<Description("True if Interrupts are disabled.")> Public Property DoNotDisturb As Boolean

	Public Property EdgeHoldSeconds As Integer
	<Obsolete("Never set to true")>
	Public EdgeHoldFlag As Boolean


	Public Property InputIcon As Boolean




	Public Property StrokePace As Integer = 0

	Public Property GeneralTime As String

	Public Property TimeoutTick As Integer

	''' <summary>
	''' This Variable contains the Path of origin of the displayed Image. CheckDommeTag() uses 
	''' this string to get the curremt ImageData for the DommeTagApp.
	''' </summary>
	<Category("Images")> Public Property ImageLocation As String = ""

	Public Property ResponseYes As String
	Public Property ResponseNo As String

	Public Property SetModule As String = ""
	Public Property SetLink As String = ""
	Public Property SetModuleGoto As String = ""
	Public Property SetLinkGoto As String = ""


	Public Property OrgasmRestricted As Boolean

	Public Property FollowUp As String = ""

	Public Property WorshipMode As Boolean = False
	Public Property WorshipTarget As String = ""

	Public Property LongHold As Boolean = False
	Public Property ExtremeHold As Boolean = False
	<Obsolete("LongTaunts-Member is not used right now.")>
	Public LongTaunts As Boolean



	<Category("MiniScript")> Public Property MiniScript As Boolean = False
	<Category("MiniScript")> Public Property MiniScriptText As String
	<Category("MiniScript")> Public Property MiniTauntVal As Integer
	<Category("MiniScript")> Public Property MiniTimerCheck As Boolean


	Public Property EdgeGoto As Boolean = False
	Public Property EdgeMessage As Boolean = False
	Public Property EdgeVideo As Boolean = False

	Public Property EdgeMessageText As String
	Public Property EdgeGotoLine As String

	<Category("Multiple Edges")> Public Property MultipleEdges As Boolean
	<Category("Multiple Edges")> Public Property MultipleEdgesAmount As Integer
	<Category("Multiple Edges")> Public Property MultipleEdgesInterval As Integer
	<Category("Multiple Edges")> Public Property MultipleEdgesTick As Integer
	<Category("Multiple Edges")> Public Property MultipleEdgesMetronome As String = ""

	Public Property YesGoto As Boolean = False
	Public Property YesVideo As Boolean = False
	Public Property NoGoto As Boolean = False
	Public Property NoVideo_Mode As Boolean = False
	Public Property CameGoto As Boolean = False
	Public Property CameVideo As Boolean = False
	Public Property CameMessage As Boolean = False
	Public Property CameMessageText As String
	Public Property RuinedGoto As Boolean = False
	Public Property RuinedVideo As Boolean = False
	Public Property RuinedMessage As Boolean = False
	Public Property RuinedMessageText As String
	Public Property YesGotoLine As String
	Public Property NoGotoLine As String
	Public Property CameGotoLine As String
	Public Property RuinedGotoLine As String

	''' <summary>
	''' Set to true if the sub is on the edge and the domme had decided to not to stop stroking.
	''' </summary>
	''' <remarks>
	''' Uses following vocabulary Files:
	''' #SYS_TauntEdging.txt when the taunting begins.
	''' #SYS_TauntEdgingAsked.txt if the sub continues to tell he's on the edge.
	''' </remarks>
	<Description("If True stroking continues when sub is on edge.")>
	Public Property TauntEdging As Boolean = False

	Public Property Modes As New Dictionary(Of String, Mode)(System.StringComparer.OrdinalIgnoreCase)

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

	<NonSerialized> <OptionalField> Friend Files As New FileClass(Me)
	<NonSerialized> <OptionalField> Friend Folders As New FoldersClass(Me)
	<OptionalField> Friend CallReturns As New Stack()

	<NonSerialized> Dim ActivationForm As Form1

#Region "------------------------------------- Constructors----------------------------------------------"

	''' <summary>
	''' Creates a new unactivaed instance.
	''' </summary>
	Sub New()
		InitializeComponent()
	End Sub
	''' <summary>
	''' Creates a new instance and activates it on the given Form.
	''' </summary>
	''' <param name="ActivationForm">The Form on which to apply the session.</param>
	Sub New(ByVal ActivationForm As Form1)
		InitializeComponent()
		Activate(ActivationForm)
	End Sub

	Private Sub InitializeComponent()
		randomizer = New Random()

		DomPersonality = My.Settings.DomPersonality

		StrokeTimeTotal = My.Settings.StrokeTimeTotal

		HoldEdgeTimeTotal = My.Settings.HoldEdgeTimeTotal

		GoldTokens = If(My.Settings.GoldTokens > 0, My.Settings.GoldTokens, 0)
		SilverTokens = If(My.Settings.SilverTokens > 0, My.Settings.SilverTokens, 0)
		BronzeTokens = If(My.Settings.BronzeTokens > 0, My.Settings.BronzeTokens, 0)

		AvgEdgeStroking = My.Settings.AvgEdgeStroking
		AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
		AvgEdgeCount = My.Settings.AvgEdgeCount
		AvgEdgeCountRest = My.Settings.AvgEdgeCountRest

		DommeMood = randomizer.Next(My.Settings.DomMoodMin, My.Settings.DomMoodMax + 1)

		SlideshowMain = New ContactData(ContactType.Domme)
		SlideshowContact1 = New ContactData(ContactType.Contact1)
		SlideshowContact2 = New ContactData(ContactType.Contact2)
		SlideshowContact3 = New ContactData(ContactType.Contact3)

		CaloriesConsumed = My.Settings.CaloriesConsumed

	End Sub

#End Region ' Constructors

#Region "---------------------------------- IDisposable Interface ---------------------------------------"

	<NonSerialized> Dim _IsDisposed As Boolean = False

	Public ReadOnly Property IsDisposed As Boolean
		Get
			Return _IsDisposed
		End Get
	End Property

	Private Sub Dispose() Implements IDisposable.Dispose
		_IsDisposed = True
	End Sub

#End Region ' IDisposable

	Public Function Clone() As SessionState
		Return DirectCast(Me.MemberwiseClone(), SessionState)
	End Function

#Region "--------------------------------- Serialization Callbacks --------------------------------------"

	''' <summary>
	''' This Method is started after deserialization. It is used to fix issues with optional fields.
	''' To ensure future compatiblity, all additional added members in SessioState-Class have to be marked
	''' as optional and initialized using this method.
	''' </summary>
	''' <param name="sc"></param>
	<OnDeserialized>
	Sub onDeserialized_FixFields(sc As StreamingContext)
		' Marked as <NonSerialized> <OptionalField> have to be initialized on every deserialization.
		If Files Is Nothing Then Files = New FileClass(Me)
		If Folders Is Nothing Then Folders = New FoldersClass(Me)
		If CallReturns Is Nothing Then CallReturns = New Stack()
		If returnFlag Then
			Dim oldReturn = New StackedCallReturn(Me)
			oldReturn.ReturnFileText = Me.ReturnFileText
			oldReturn.ReturnState = Me.ReturnSubState
			oldReturn.ReturnStrokeTauntVal = CInt(Me.ReturnStrokeTauntVal)
			CallReturns.Push(oldReturn)
		End If
	End Sub

#End Region

#Region "----------------------------------- Get/Set Form1 Data -----------------------------------------"

	''' <summary>
	''' Stores a running session to disk. 
	''' </summary>
	''' <param name="serializeForm">The Form to gather informations(Timer-States etc.) from.</param>
	''' <exception cref="Exception">Rethrows all exceptions.</exception>
	''' <remarks>This function is invoked on the given Form's UI-Thread.</remarks>
	Sub FetchFormData(ByVal serializeForm As Form1)
		If serializeForm IsNot Nothing _
		AndAlso serializeForm.InvokeRequired Then
			' Calling from another Thread -> Invoke on controls UI-Thread
			Dim Act As Action(Of Form1) = Sub(s1) FetchFormData(s1)
			serializeForm.Invoke(Act)
			Exit Sub
		End If
		' Called from Controls UI-Thread -> Execute Code.


		With serializeForm
			DomPersonality = .dompersonalitycombobox.SelectedItem.ToString

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Get Timer EnableStates
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			AvoidTheEdge_enabled = .AvoidTheEdge.Enabled
			AvoidTheEdgeResume_enabled = .AvoidTheEdgeResume.Enabled
			AvoidTheEdgeTaunts_enabled = .AvoidTheEdgeTaunts.Enabled
			CensorshipTimer_enabled = .CensorshipTimer.Enabled
			Contact1Timer_enabled = .Contact1Timer.Enabled
			Contact2Timer_enabled = .Contact2Timer.Enabled
			Contact3Timer_enabled = .Contact3Timer.Enabled
			CustomSlideshowTimer_enabled = .CustomSlideshowTimer.Enabled
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
			AvoidTheEdge_Interval = .AvoidTheEdge.Interval
			AvoidTheEdgeResume_Interval = .AvoidTheEdgeResume.Interval
			AvoidTheEdgeTaunts_Interval = .AvoidTheEdgeTaunts.Interval
			CensorshipTimer_Interval = .CensorshipTimer.Interval
			Contact1Timer_Interval = .Contact1Timer.Interval
			Contact2Timer_Interval = .Contact2Timer.Interval
			Contact3Timer_Interval = .Contact3Timer.Interval
			CustomSlideshowTimer_Interval = .CustomSlideshowTimer.Interval
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

			If Directory.Exists(Folders.Flags) Then
				For Each fn As String In Directory.GetFiles(Folders.Flags)
					serialized_Flags.Add(Path.GetFileName(fn))
				Next
			End If

			' Get temporary Flags
			If serialized_FlagsTemp Is Nothing Then _
							serialized_FlagsTemp = New List(Of String)
			serialized_FlagsTemp.Clear()

			If Directory.Exists(Folders.TempFlags) Then
				For Each fn As String In Directory.GetFiles(Folders.TempFlags)
					serialized_FlagsTemp.Add(Path.GetFileName(fn))
				Next
			End If

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'								Get Variables
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If serialized_Variables Is Nothing Then _
							serialized_Variables = New Dictionary(Of String, String)

			serialized_Variables.Clear()

			If Directory.Exists(Folders.Variables) Then
				For Each fn As String In Directory.GetFiles(Folders.Variables)
					Dim val As String = TxtReadLine(fn)
					serialized_Variables.Add(Path.GetFileName(fn), val)
				Next
			End If


		End With


	End Sub

	''' <summary>
	''' Activates the current SessionState.
	''' </summary>
	''' <param name="activateForm">The Form to start the session on.</param>
	Friend Sub Activate(ByVal activateForm As Form1)
		' Check if InvokeIsRequired
		If activateForm IsNot Nothing _
		AndAlso activateForm.InvokeRequired Then
			' Calling from another Thread -> Invoke on controls UI-Thread
			Dim Act As Action(Of Form1) = Sub(s1) Activate(s1)
			activateForm.Invoke(Act)
		End If
		' Called from Controls UI-Thread -> Execute Code.

		ActivationForm = activateForm

		With activateForm
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Disable Timers to avoid Exceptions
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			.AvoidTheEdge.Enabled = False
			.AvoidTheEdgeResume.Enabled = False
			.AvoidTheEdgeTaunts.Enabled = False
			.CensorshipTimer.Enabled = False
			.Contact1Timer.Enabled = False
			.Contact2Timer.Enabled = False
			.Contact3Timer.Enabled = False
			.CustomSlideshowTimer.Enabled = False
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

			If .ssh IsNot Nothing Then .ssh.Dispose()
			.ssh = Me

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Set Domme Personality
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If DomPersonality = String.Empty Then
				DomPersonality = My.Settings.DomPersonality
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
				If Directory.Exists(Folders.Variables) = False Then
					Directory.CreateDirectory(Folders.Variables)
				Else
					For Each fn As String In Directory.GetFiles(Folders.Variables)
						File.Delete(fn)
					Next
				End If

				For Each fn As String In serialized_Variables.Keys
					My.Computer.FileSystem.WriteAllText(Folders.Variables & fn,
													serialized_Variables(fn), False)
				Next
			End If

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Restore flags 
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If serialized_Flags.Count > 0 Then
				If Directory.Exists(Folders.Flags) = False Then
					Directory.CreateDirectory(Folders.Flags)
				Else
					For Each fn As String In Directory.GetFiles(Folders.Flags)
						File.Delete(fn)
					Next
				End If

				For Each fn As String In serialized_Flags
					Using fs As New FileStream(Folders.Flags & fn,
											   FileMode.Create) : End Using
				Next
			End If
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'						Restore temporary flags 
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If Directory.Exists(Folders.TempFlags) = False Then
				Directory.CreateDirectory(Folders.TempFlags)
			Else
				For Each fn As String In Directory.GetFiles(Folders.TempFlags)
					File.Delete(fn)
				Next
			End If

			If serialized_FlagsTemp.Count > 0 Then
				For Each fn As String In serialized_FlagsTemp
					Using fs As New FileStream(Folders.TempFlags & fn,
											   FileMode.Create) : End Using
				Next
			End If
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'								Set Slideshows
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If SlideshowMain Is Nothing Then SlideshowMain = New ContactData(ContactType.Domme)
			If SlideshowContact1 Is Nothing Then SlideshowContact1 = New ContactData(ContactType.Contact1)
			If SlideshowContact2 Is Nothing Then SlideshowContact2 = New ContactData(ContactType.Contact2)
			If SlideshowContact3 Is Nothing Then SlideshowContact3 = New ContactData(ContactType.Contact3)

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Set Picturebox & WMP
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If isURL(ImageLocation) Then
				.ShowImage(ImageLocation, True)
			ElseIf File.Exists(ImageLocation) Then
				.ShowImage(ImageLocation, True)
			ElseIf SlideshowLoaded = True And SlideshowMain.ImageList.Count > 0 AndAlso File.Exists(SlideshowMain.CurrentImage) Then
				.ShowImage(SlideshowMain.CurrentImage, True)
			Else
				.ClearMainPictureBox()
			End If

			.mainPictureBox.Visible = Not serialized_WMP_Visible
			.DomWMP.Visible = serialized_WMP_Visible
			.DomWMP.URL = serialized_WMP_URL
			.DomWMP.Ctlcontrols.currentPosition = serialized_WMP_Position

			If serialized_WMP_Playstate <= 1 Then
				.DomWMP.Ctlcontrols.stop()
			ElseIf serialized_WMP_Playstate = 2 Then
				Dim sw As New Stopwatch
				sw.Start()

				Do Until .DomWMP.playState = WMPPlayState.wmppsPlaying Or sw.ElapsedMilliseconds > 5000
					Application.DoEvents()
				Loop

				.DomWMP.Ctlcontrols.pause()
			ElseIf serialized_WMP_Playstate = 3 Then
				.DomWMP.Ctlcontrols.play()
			End If

			' Hide Cencorshipbar , if no game is running 
			If CensorshipGame = True Or CensorshipTimer_enabled = False Then .CensorshipBar.Visible = False

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
			.AvoidTheEdge.Interval = AvoidTheEdge_Interval
			.AvoidTheEdgeResume.Interval = AvoidTheEdgeResume_Interval
			.AvoidTheEdgeTaunts.Interval = AvoidTheEdgeTaunts_Interval
			.CensorshipTimer.Interval = CensorshipTimer_Interval
			.Contact1Timer.Interval = Contact1Timer_Interval
			.Contact2Timer.Interval = Contact2Timer_Interval
			.Contact3Timer.Interval = Contact3Timer_Interval
			.CustomSlideshowTimer.Interval = CustomSlideshowTimer_Interval
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
			.AvoidTheEdge.Enabled = AvoidTheEdge_enabled
			.AvoidTheEdgeResume.Enabled = AvoidTheEdgeResume_enabled
			.AvoidTheEdgeTaunts.Enabled = AvoidTheEdgeTaunts_enabled
			.CensorshipTimer.Enabled = CensorshipTimer_enabled
			.Contact1Timer.Enabled = Contact1Timer_enabled
			.Contact2Timer.Enabled = Contact2Timer_enabled
			.Contact3Timer.Enabled = Contact3Timer_enabled
			.CustomSlideshowTimer.Enabled = CustomSlideshowTimer_enabled
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

#End Region ' Get/Set Data

	''' <summary>
	''' Loads and activates a stored session from the given path.
	''' </summary>
	''' <param name="filepath">The path to load the state from.</param>
	''' <param name="setActive">The form to activate the session on.</param>
	''' <exception cref="Exception">Rethrows all exceptions.</exception>
	''' <remarks>This function is invoked on the <see cref="ActivationForm"/>'s UI-Thread.</remarks>
	Friend Sub Load(ByVal filepath As String, ByVal setActive As Boolean)
		Try
			' Check if InvokeIsRequired
			If setActive = True _
			AndAlso ActivationForm IsNot Nothing _
			AndAlso ActivationForm.InvokeRequired Then
				' Calling from another Thread -> Invoke on controls UI-Thread
				Dim Act As Action(Of String, Boolean) = Sub(s1, s2) Load(s1, s2)
				ActivationForm.Invoke(Act)
				Exit Sub
			End If
			' Called from Controls UI-Thread -> Execute Code.

			If setActive AndAlso ActivationForm Is Nothing Then _
			Throw New InvalidOperationException("It is impossible to reactivate a not activated session.")


			Dim tmpState As SessionState = DirectCast(BinaryDeserialize(filepath), SessionState)

			If setActive Then tmpState.Activate(ActivationForm)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	''' <summary>
	''' Stores the SessionState to disk.
	''' </summary>
	''' <param name="filePath">The filepath to store the object to.</param>
	Friend Sub Save(ByVal filePath As String)
		Try
			If ActivationForm IsNot Nothing Then FetchFormData(ActivationForm)

			BinarySerialize(Me, filePath)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	''' <summary>
	''' Resets the current session. Basically it disposes the current <see cref="SessionState"/>-instance
	''' and applies a new <see cref="SessionState"/>-instance to <see cref="Form1.ssh"/>.
	''' <para></para>
	''' After calling this method you have to update your object references.
	''' </summary>
	''' <returns>True if the sesstion state has been activated.</returns>
	''' <remarks>
	''' If the current session is activated, the function is invoked on <see cref="ActivationForm"/>'s 
	''' UI-Thread.</remarks>
	Public Function Reset() As Boolean
		' Check if InvokeIsRequired
		If ActivationForm IsNot Nothing _
		AndAlso ActivationForm.InvokeRequired Then
			' Calling from another Thread -> Invoke on controls UI-Thread
			Return CType(ActivationForm.UIThread(AddressOf Reset), Boolean)
		End If
		' Called from Controls UI-Thread -> Execute Code.

		Dispose()

		If ActivationForm IsNot Nothing Then
			ActivationForm.ssh = New SessionState(ActivationForm)
			Return True
		Else
			Return False
		End If
	End Function

End Class

