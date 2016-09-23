
Imports System.Xml.Serialization

<Serializable()> _
<System.Xml.Serialization.XmlRoot("RewriteRule")> _
Public Class SaveState

	Public Chat As String
	Public randomizer As New Random
	Public ScriptOperator As String
	Public ScriptCompare As String
	Public DomTyping As Boolean
	Public CheckYes As Boolean
	Public CheckNo As Boolean
	Public Playlist As Boolean
	Public PlaylistFile As New List(Of String)
	Public PlaylistCurrent As Integer
	Public FormLoading As Boolean = True
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
	Public TasksCount As Integer
	Public GotoDommeLevel As Boolean
	Public DommeMood As Integer
	Public AFK As Boolean
	Public HypnoGen As Boolean
	Public Induction As Boolean
	Public TempHypno As String
	Public StrokeTick As Integer
	Public StrokeTauntTick As Integer
	Public StrokePace As Integer
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
	Public GlitterImageAV As String
	Public GlitterTempColor As String
	Public UpdatesTick As Integer
	Public UpdatingPost As Boolean
	Public UpdateStage As Integer
	Public UpdateStageTick As Integer
	Public StatusText As String
	Public ContactNumber As Integer
	Public ContactTick As Integer
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
	Public FileCountMax As Integer
	Public _ImageFileNames As New List(Of String)
	Public _CurrentImage As Integer
	Public WithTeaseImgDir As String
	Public ApproveImage As Integer
	Public WIExit As Boolean
	Public RecentSlideshows As New List(Of String)
	Public MainPictureImage As String
	Public DomPic As String
	Public LockImage As Boolean
	Public LockVideo As Boolean
	Public LocalTagImageList As New List(Of String)
	Public Crazy As Boolean
	Public Vulgar As Boolean
	Public Supremacist As Boolean
	Public CockSize As Integer
	Public PetName As String
	Public TauntText As String
	Public ScriptCount As Integer
	Public TempScriptCount As Integer
	Public TauntTextCount As Integer
	Public SlideshowTimerTick As Integer
	Public WebImage As String
	Public WebImageLines As New List(Of String)
	Public WebImageLine As Integer
	Public WebImageLineTotal As Integer
	Public WebImagePath As String
	Public LastScriptCountdown As Integer
	Public LastScript As Boolean
	Public JustShowedBlogImage As Boolean
	Public SaidHello As Boolean
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
	Public TnAList As New List(Of String)
	Public BoobList As New List(Of String)
	Public AssList As New List(Of String)
	Public AssImage As Boolean = False
	Public BoobImage As Boolean = False
	Public FoundTag As String
	Public TagGarment As String
	Public TagUnderwear As String
	Public TagTattoo As String
	Public TagSexToy As String
	Public TagFurniture As String
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
	Public LastOrgasmType As String
	Public StupidTick As Integer
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
	Public Group As String
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
	Public GeneralTime As String
	Public NewDommeSlideshow As Boolean
	Public OriginalDommeSlideshow As String
	Public TimeoutTick As Integer
	Public DommeImageSTR As String
	Public LocalImageSTR As String
	Public ImageLocation As String
	Public ResponseYes As String
	Public ResponseNo As String
	Public SetModule As String
	Public SetLink As String
	Public SetModuleGoto As String
	Public SetLinkGoto As String
	Public OrgasmRestricted As Boolean
	Public FollowUp As String
	Public WorshipMode As Boolean
	Public WorshipTarget As String
	Public LongHold As Boolean
	Public ExtremeHold As Boolean
	Public LongTaunts As Boolean
	Public LazyEdit1 As Boolean
	Public LazyEdit2 As Boolean
	Public LazyEdit3 As Boolean
	Public LazyEdit4 As Boolean
	Public LazyEdit5 As Boolean
	Public FormFinishedLoading As Boolean = False
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
	Public MultipleEdgesMetronome As String
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
	Public TauntEdging As Boolean
	Public WritingTaskCurrentTime As Single



	Public Sub New()
	End Sub


	Public Sub New(
	ByVal NEW_Chat As String,
	 ByVal NEW_ScriptOperator As String,
	 ByVal NEW_ScriptCompare As String,
	 ByVal NEW_DomTyping As Boolean,
	 ByVal NEW_CheckYes As Boolean,
	 ByVal NEW_CheckNo As Boolean,
	 ByVal NEW_Playlist As Boolean,
	 ByVal NEW_PlaylistFile As List(Of String),
	 ByVal NEW_PlaylistCurrent As Integer,
	 ByVal NEW_FormLoading As Boolean,
	 ByVal NEW_Responding As Boolean,
	 ByVal NEW_StrokeTauntVal As Integer,
	 ByVal NEW_FileText As String,
	 ByVal NEW_TempStrokeTauntVal As Integer,
	 ByVal NEW_TempFileText As String,
	 ByVal NEW_TeaseTick As Integer,
	 ByVal NEW_StrokeTauntCount As Integer,
	 ByVal NEW_TauntTextTotal As Integer,
	 ByVal NEW_TauntLines As List(Of String),
	 ByVal NEW_StrokeFilter As Boolean,
	 ByVal NEW_ScriptTick As Integer,
	 ByVal NEW_StringLength As Integer,
	 ByVal NEW_FileGoto As String,
	 ByVal NEW_SkipGotoLine As Boolean,
	 ByVal NEW_ChatString As String,
	 ByVal NEW_DomTask As String,
	 ByVal NEW_DomChat As String,
	 ByVal NEW_TypeDelay As Integer,
	 ByVal NEW_TempVal As Integer,
	 ByVal NEW_NullResponse As Boolean,
	 ByVal NEW_TagCount As Integer,
	 ByVal NEW_LocalTagCount As Integer,
	 ByVal NEW_TaskFile As String,
	 ByVal NEW_TaskText As String,
	 ByVal NEW_TaskTextDir As String,
	 ByVal NEW_ResponseFile As String,
	 ByVal NEW_ResponseLine As Integer,
	 ByVal NEW_CBTCockActive As Boolean,
	 ByVal NEW_CBTBallsActive As Boolean,
	 ByVal NEW_CBTCockFlag As Boolean,
	 ByVal NEW_CBTBallsFlag As Boolean,
	 ByVal NEW_CBTBallsFirst As Boolean,
	 ByVal NEW_CBTCockFirst As Boolean,
	 ByVal NEW_CBTBallsCount As Integer,
	 ByVal NEW_CBTCockCount As Integer,
	 ByVal NEW_TasksCount As Integer,
	 ByVal NEW_GotoDommeLevel As Boolean,
	 ByVal NEW_DommeMood As Integer,
	 ByVal NEW_AFK As Boolean,
	 ByVal NEW_HypnoGen As Boolean,
	 ByVal NEW_Induction As Boolean,
	 ByVal NEW_TempHypno As String,
	 ByVal NEW_StrokeTick As Integer,
	 ByVal NEW_StrokeTauntTick As Integer,
	 ByVal NEW_StrokePace As Integer,
	 ByVal NEW_StrokeTimeTotal As Integer,
	 ByVal NEW_HoldEdgeTime As Integer,
	 ByVal NEW_HoldEdgeTimeTotal As Integer,
	 ByVal NEW_EdgeTauntInt As Integer,
	 ByVal NEW_DelayTick As Integer,
	 ByVal NEW_DomTypeCheck As Boolean,
	 ByVal NEW_TypeToggle As Boolean,
	 ByVal NEW_IsTyping As Boolean,
	 ByVal NEW_SubWroteLast As Boolean,
	 ByVal NEW_YesOrNo As Boolean,
	 ByVal NEW_GotoFlag As Boolean,
	 ByVal NEW_CBT As Boolean,
	 ByVal NEW_RunningScript As Boolean,
	 ByVal NEW_BeforeTease As Boolean,
	 ByVal NEW_SubStroking As Boolean,
	 ByVal NEW_SubEdging As Boolean,
	 ByVal NEW_SubHoldingEdge As Boolean,
	 ByVal NEW_EndTease As Boolean,
	 ByVal NEW_ShowModule As Boolean,
	 ByVal NEW_ModuleEnd As Boolean,
	 ByVal NEW_DivideText As Boolean,
	 ByVal NEW_HoldEdgeTick As Integer,
	 ByVal NEW_HoldEdgeChance As Integer,
	 ByVal NEW_EdgeHold As Boolean,
	 ByVal NEW_EdgeNoHold As Boolean,
	 ByVal NEW_EdgeToRuin As Boolean,
	 ByVal NEW_EdgeToRuinSecret As Boolean,
	 ByVal NEW_LongEdge As Boolean,
	 ByVal NEW_AskedToGiveUp As Boolean,
	 ByVal NEW_AskedToGiveUpSection As Boolean,
	 ByVal NEW_SubGaveUp As Boolean,
	 ByVal NEW_AskedToSpeedUp As Boolean,
	 ByVal NEW_AskedToSlowDown As Boolean,
	 ByVal NEW_ThoughtEnd As Boolean,
	 ByVal NEW_VTLength As Integer,
	 ByVal NEW_DommeVideo As Boolean,
	 ByVal NEW_VideoType As String,
	 ByVal NEW_CensorshipGame As Boolean,
	 ByVal NEW_CensorshipTick As Integer,
	 ByVal NEW_CensorDuration As String,
	 ByVal NEW_AvoidTheEdgeGame As Boolean,
	 ByVal NEW_AvoidTheEdgeTick As Integer,
	 ByVal NEW_AvoidTheEdgeTimerTick As Integer,
	 ByVal NEW_AvoidTheEdgeDuration As String,
	 ByVal NEW_AvoidTheEdgeStroking As Boolean,
	 ByVal NEW_AtECountdown As Integer,
	 ByVal NEW_VTPath As String,
	 ByVal NEW_NoVideo As Boolean,
	 ByVal NEW_NoSpecialVideo As Boolean,
	 ByVal NEW_VideoCheck As Boolean,
	 ByVal NEW_VideoTease As Boolean,
	 ByVal NEW_RLGLGame As Boolean,
	 ByVal NEW_RLGLStroking As Boolean,
	 ByVal NEW_RLGLTick As Integer,
	 ByVal NEW_RedLight As Boolean,
	 ByVal NEW_RLGLTauntTick As Integer,
	 ByVal NEW_RandomizerVideo As Boolean,
	 ByVal NEW_RandomizerVideoTease As Boolean,
	 ByVal NEW_ScriptVideoTease As String,
	 ByVal NEW_ScriptVideoTeaseFlag As Boolean,
	 ByVal NEW_VideoTauntTick As Integer,
	 ByVal NEW_SlideshowLoaded As Boolean,
	 ByVal NEW_GlitterImageAV As String,
	 ByVal NEW_GlitterTempColor As String,
	 ByVal NEW_UpdatesTick As Integer,
	 ByVal NEW_UpdatingPost As Boolean,
	 ByVal NEW_UpdateStage As Integer,
	 ByVal NEW_UpdateStageTick As Integer,
	 ByVal NEW_StatusText As String,
	 ByVal NEW_ContactNumber As Integer,
	 ByVal NEW_ContactTick As Integer,
	 ByVal NEW_ContactFlag As Boolean,
	 ByVal NEW_StatusText1 As String,
	 ByVal NEW_StatusText2 As String,
	 ByVal NEW_StatusText3 As String,
	 ByVal NEW_StatusChance1 As Integer,
	 ByVal NEW_StatusChance2 As Integer,
	 ByVal NEW_StatusChance3 As Integer,
	 ByVal NEW_Update1 As Boolean,
	 ByVal NEW_Update2 As Boolean,
	 ByVal NEW_Update3 As Boolean,
	 ByVal NEW_GetFolder As String,
	 ByVal NEW_FileCount As Integer,
	 ByVal NEW_FileCountMax As Integer,
	 ByVal NEW__ImageFileNames As List(Of String),
	 ByVal NEW__CurrentImage As Integer,
	 ByVal NEW_WithTeaseImgDir As String,
	 ByVal NEW_ApproveImage As Integer,
	 ByVal NEW_WIExit As Boolean,
	 ByVal NEW_RecentSlideshows As List(Of String),
	 ByVal NEW_MainPictureImage As String,
	 ByVal NEW_DomPic As String,
	 ByVal NEW_LockImage As Boolean,
	 ByVal NEW_LockVideo As Boolean,
	 ByVal NEW_LocalTagImageList As List(Of String),
	 ByVal NEW_Crazy As Boolean,
	 ByVal NEW_Vulgar As Boolean,
	 ByVal NEW_Supremacist As Boolean,
	 ByVal NEW_CockSize As Integer,
	 ByVal NEW_PetName As String,
	 ByVal NEW_TauntText As String,
	 ByVal NEW_ScriptCount As Integer,
	 ByVal NEW_TempScriptCount As Integer,
	 ByVal NEW_TauntTextCount As Integer,
	 ByVal NEW_SlideshowTimerTick As Integer,
	 ByVal NEW_WebImage As String,
	 ByVal NEW_WebImageLines As List(Of String),
	 ByVal NEW_WebImageLine As Integer,
	 ByVal NEW_WebImageLineTotal As Integer,
	 ByVal NEW_WebImagePath As String,
	 ByVal NEW_LastScriptCountdown As Integer,
	 ByVal NEW_LastScript As Boolean,
	 ByVal NEW_JustShowedBlogImage As Boolean,
	 ByVal NEW_SaidHello As Boolean,
	 ByVal NEW_StopMetronome As Boolean,
	 ByVal NEW_AvgEdgeStroking As Integer,
	 ByVal NEW_AvgEdgeNoTouch As Integer,
	 ByVal NEW_EdgeCountTick As Integer,
	 ByVal NEW_AvgEdgeStrokingFlag As Boolean,
	 ByVal NEW_AvgEdgeCount As Integer,
	 ByVal NEW_AvgEdgeCountRest As Integer,
	 ByVal NEW_EdgeTickCheck As Integer,
	 ByVal NEW_EdgeNOT As Boolean,
	 ByVal NEW_AlreadyStrokingEdge As Boolean,
	 ByVal NEW_WritingTaskLinesAmount As Integer,
	 ByVal NEW_WritingTaskLinesWritten As Integer,
	 ByVal NEW_WritingTaskLinesRemaining As Integer,
	 ByVal NEW_WritingTaskMistakesAllowed As Integer,
	 ByVal NEW_WritingTaskMistakesMade As Integer,
	 ByVal NEW_WritingTaskFlag As Boolean,
	 ByVal NEW_FirstRound As Boolean,
	 ByVal NEW_StartStrokingCount As Integer,
	 ByVal NEW_TeaseJOI As Boolean,
	 ByVal NEW_TeaseVideo As Boolean,
	 ByVal NEW_TnAList As List(Of String),
	 ByVal NEW_BoobList As List(Of String),
	 ByVal NEW_AssList As List(Of String),
	 ByVal NEW_AssImage As Boolean,
	 ByVal NEW_BoobImage As Boolean,
	 ByVal NEW_FoundTag As String,
	 ByVal NEW_TagGarment As String,
	 ByVal NEW_TagUnderwear As String,
	 ByVal NEW_TagTattoo As String,
	 ByVal NEW_TagSexToy As String,
	 ByVal NEW_TagFurniture As String,
	 ByVal NEW_BookmarkModule As Boolean,
	 ByVal NEW_BookmarkModuleFile As String,
	 ByVal NEW_BookmarkModuleLine As Integer,
	 ByVal NEW_BookmarkLink As Boolean,
	 ByVal NEW_BookmarkLinkFile As String,
	 ByVal NEW_BookmarkLinkLine As Integer,
	 ByVal NEW_WaitTick As Integer,
	 ByVal NEW_OrgasmDenied As Boolean,
	 ByVal NEW_OrgasmAllowed As Boolean,
	 ByVal NEW_OrgasmRuined As Boolean,
	 ByVal NEW_LastOrgasmType As String,
	 ByVal NEW_StupidTick As Integer,
	 ByVal NEW_StupidFlag As Boolean,
	 ByVal NEW_CaloriesConsumed As Integer,
	 ByVal NEW_CaloriesGoal As Integer,
	 ByVal NEW_GoldTokens As Integer,
	 ByVal NEW_SilverTokens As Integer,
	 ByVal NEW_BronzeTokens As Integer,
	 ByVal NEW_EdgeFound As Boolean,
	 ByVal NEW_OrgasmYesNo As Boolean,
	 ByVal NEW_VTFlag As Boolean,
	 ByVal NEW_DomPersonality As String,
	 ByVal NEW_UpdateList As List(Of String),
	 ByVal NEW_GlitterDocument As String,
	 ByVal NEW_CustomSlideshow As Boolean,
	 ByVal NEW_CustomSlideshowTick As Integer,
	 ByVal NEW_CustomSlideshowList As List(Of String),
	 ByVal NEW_ImageString As String,
	 ByVal NEW_RapidFire As Boolean,
	 ByVal NEW_GlitterTease As Boolean,
	 ByVal NEW_AddContactTick As Integer,
	 ByVal NEW_Contact1Pics As List(Of String),
	 ByVal NEW_Contact2Pics As List(Of String),
	 ByVal NEW_Contact3Pics As List(Of String),
	 ByVal NEW_Contact1PicsCount As Integer,
	 ByVal NEW_Contact2PicsCount As Integer,
	 ByVal NEW_Contact3PicsCount As Integer,
	 ByVal NEW_Group As String,
	 ByVal NEW_CustomTask As Boolean,
	 ByVal NEW_CustomTaskFirst As Boolean,
	 ByVal NEW_CustomTaskText As String,
	 ByVal NEW_CustomTaskTextFirst As String,
	 ByVal NEW_CustomTaskActive As Boolean,
	 ByVal NEW_SubtitleCount As Integer,
	 ByVal NEW_VidFile As String,
	 ByVal NEW_RiskyDeal As Boolean,
	 ByVal NEW_RiskyEdges As Boolean,
	 ByVal NEW_RiskyDelay As Boolean,
	 ByVal NEW_FinalRiskyPick As Boolean,
	 ByVal NEW_SysMes As Boolean,
	 ByVal NEW_EmoMes As Boolean,
	 ByVal NEW_Contact1Edge As Boolean,
	 ByVal NEW_Contact2Edge As Boolean,
	 ByVal NEW_Contact3Edge As Boolean,
	 ByVal NEW_Contact1Stroke As Boolean,
	 ByVal NEW_Contact2Stroke As Boolean,
	 ByVal NEW_Contact3Stroke As Boolean,
	 ByVal NEW_ReturnFileText As String,
	 ByVal NEW_ReturnStrokeTauntVal As String,
	 ByVal NEW_ReturnSubState As String,
	 ByVal NEW_ReturnFlag As Boolean,
	 ByVal NEW_SessionEdges As Integer,
	 ByVal NEW_WindowCheck As Boolean,
	 ByVal NEW_StrokeFaster As Boolean,
	 ByVal NEW_StrokeFastest As Boolean,
	 ByVal NEW_StrokeSlower As Boolean,
	 ByVal NEW_StrokeSlowest As Boolean,
	 ByVal NEW_InputFlag As Boolean,
	 ByVal NEW_InputString As String,
	 ByVal NEW_RapidCode As Boolean,
	 ByVal NEW_CorrectedTypo As Boolean,
	 ByVal NEW_CorrectedWord As String,
	 ByVal NEW_DoNotDisturb As Boolean,
	 ByVal NEW_TypoSwitch As Integer,
	 ByVal NEW_TyposDisabled As Boolean,
	 ByVal NEW_EdgeHoldSeconds As Integer,
	 ByVal NEW_EdgeHoldFlag As Boolean,
	 ByVal NEW_SlideshowInt As Integer,
	 ByVal NEW_JustShowedSlideshowImage As Boolean,
	 ByVal NEW_RandomSlideshowCategory As String,
	 ByVal NEW_ResetFlag As Boolean,
	 ByVal NEW_DommeTags As Boolean,
	 ByVal NEW_ThemeSettings As Boolean,
	 ByVal NEW_InputIcon As Boolean,
	 ByVal NEW_ApplyingTheme As Boolean,
	 ByVal NEW_AdjustingWindow As Boolean,
	 ByVal NEW_SplitContainerHeight As Integer,
	 ByVal NEW_DommeImageFound As Boolean,
	 ByVal NEW_LocalImageFound As Boolean,
	 ByVal NEW_LocalImageListCheck As Boolean,
	 ByVal NEW_CBTBothActive As Boolean,
	 ByVal NEW_CBTBothFlag As Boolean,
	 ByVal NEW_CBTBothCount As Integer,
	 ByVal NEW_CBTBothFirst As Boolean,
	 ByVal NEW_GeneralTime As String,
	 ByVal NEW_NewDommeSlideshow As Boolean,
	 ByVal NEW_OriginalDommeSlideshow As String,
	 ByVal NEW_TimeoutTick As Integer,
	 ByVal NEW_DommeImageSTR As String,
	 ByVal NEW_LocalImageSTR As String,
	 ByVal NEW_ImageLocation As String,
	 ByVal NEW_ResponseYes As String,
	 ByVal NEW_ResponseNo As String,
	 ByVal NEW_SetModule As String,
	 ByVal NEW_SetLink As String,
	 ByVal NEW_SetModuleGoto As String,
	 ByVal NEW_SetLinkGoto As String,
	 ByVal NEW_OrgasmRestricted As Boolean,
	 ByVal NEW_FollowUp As String,
	 ByVal NEW_WorshipMode As Boolean,
	 ByVal NEW_WorshipTarget As String,
	 ByVal NEW_LongHold As Boolean,
	 ByVal NEW_ExtremeHold As Boolean,
	 ByVal NEW_LongTaunts As Boolean,
	 ByVal NEW_LazyEdit1 As Boolean,
	 ByVal NEW_LazyEdit2 As Boolean,
	 ByVal NEW_LazyEdit3 As Boolean,
	 ByVal NEW_LazyEdit4 As Boolean,
	 ByVal NEW_LazyEdit5 As Boolean,
	 ByVal NEW_FormFinishedLoading As Boolean,
	 ByVal NEW_MiniScript As Boolean,
	 ByVal NEW_MiniScriptText As String,
	 ByVal NEW_MiniTauntVal As Integer,
	 ByVal NEW_MiniTimerCheck As Boolean,
	 ByVal NEW_JumpVideo As Boolean,
	 ByVal NEW_VideoTick As Integer,
	 ByVal NEW_EdgeGoto As Boolean,
	 ByVal NEW_EdgeMessage As Boolean,
	 ByVal NEW_EdgeVideo As Boolean,
	 ByVal NEW_EdgeMessageText As String,
	 ByVal NEW_EdgeGotoLine As String,
	 ByVal NEW_MultipleEdges As Boolean,
	 ByVal NEW_MultipleEdgesAmount As Integer,
	 ByVal NEW_MultipleEdgesInterval As Integer,
	 ByVal NEW_MultipleEdgesTick As Integer,
	 ByVal NEW_MultipleEdgesMetronome As String,
	 ByVal NEW_YesGoto As Boolean,
	 ByVal NEW_YesVideo As Boolean,
	 ByVal NEW_NoGoto As Boolean,
	 ByVal NEW_NoVideo_Mode As Boolean,
	 ByVal NEW_CameGoto As Boolean,
	 ByVal NEW_CameVideo As Boolean,
	 ByVal NEW_CameMessage As Boolean,
	 ByVal NEW_CameMessageText As String,
	 ByVal NEW_RuinedGoto As Boolean,
	 ByVal NEW_RuinedVideo As Boolean,
	 ByVal NEW_RuinedMessage As Boolean,
	 ByVal NEW_RuinedMessageText As String,
	 ByVal NEW_YesGotoLine As String,
	 ByVal NEW_NoGotoLine As String,
	 ByVal NEW_CameGotoLine As String,
	 ByVal NEW_RuinedGotoLine As String,
	 ByVal NEW_TauntEdging As Boolean,
	 ByVal NEW_WritingTaskCurrentTime As Single)

		Chat = NEW_Chat
		ScriptOperator = NEW_ScriptOperator
		ScriptCompare = NEW_ScriptCompare
		DomTyping = NEW_DomTyping
		CheckYes = NEW_CheckYes
		CheckNo = NEW_CheckNo
		Playlist = NEW_Playlist
		PlaylistFile = NEW_PlaylistFile
		PlaylistCurrent = NEW_PlaylistCurrent
		FormLoading = NEW_FormLoading
		Responding = NEW_Responding
		StrokeTauntVal = NEW_StrokeTauntVal
		FileText = NEW_FileText
		TempStrokeTauntVal = NEW_TempStrokeTauntVal
		TempFileText = NEW_TempFileText
		TeaseTick = NEW_TeaseTick
		StrokeTauntCount = NEW_StrokeTauntCount
		TauntTextTotal = NEW_TauntTextTotal
		TauntLines = NEW_TauntLines
		StrokeFilter = NEW_StrokeFilter
		ScriptTick = NEW_ScriptTick
		StringLength = NEW_StringLength
		FileGoto = NEW_FileGoto
		SkipGotoLine = NEW_SkipGotoLine
		ChatString = NEW_ChatString
		DomTask = NEW_DomTask
		DomChat = NEW_DomChat
		TypeDelay = NEW_TypeDelay
		TempVal = NEW_TempVal
		NullResponse = NEW_NullResponse
		TagCount = NEW_TagCount
		LocalTagCount = NEW_LocalTagCount
		TaskFile = NEW_TaskFile
		TaskText = NEW_TaskText
		TaskTextDir = NEW_TaskTextDir
		ResponseFile = NEW_ResponseFile
		ResponseLine = NEW_ResponseLine
		CBTCockActive = NEW_CBTCockActive
		CBTBallsActive = NEW_CBTBallsActive
		CBTCockFlag = NEW_CBTCockFlag
		CBTBallsFlag = NEW_CBTBallsFlag
		CBTBallsFirst = NEW_CBTBallsFirst
		CBTCockFirst = NEW_CBTCockFirst
		CBTBallsCount = NEW_CBTBallsCount
		CBTCockCount = NEW_CBTCockCount
		TasksCount = NEW_TasksCount
		GotoDommeLevel = NEW_GotoDommeLevel
		DommeMood = NEW_DommeMood
		AFK = NEW_AFK
		HypnoGen = NEW_HypnoGen
		Induction = NEW_Induction
		TempHypno = NEW_TempHypno
		StrokeTick = NEW_StrokeTick
		StrokeTauntTick = NEW_StrokeTauntTick
		StrokePace = NEW_StrokePace
		StrokeTimeTotal = NEW_StrokeTimeTotal
		HoldEdgeTime = NEW_HoldEdgeTime
		HoldEdgeTimeTotal = NEW_HoldEdgeTimeTotal
		EdgeTauntInt = NEW_EdgeTauntInt
		DelayTick = NEW_DelayTick
		DomTypeCheck = NEW_DomTypeCheck
		TypeToggle = NEW_TypeToggle
		IsTyping = NEW_IsTyping
		SubWroteLast = NEW_SubWroteLast
		YesOrNo = NEW_YesOrNo
		GotoFlag = NEW_GotoFlag
		CBT = NEW_CBT
		RunningScript = NEW_RunningScript
		BeforeTease = NEW_BeforeTease
		SubStroking = NEW_SubStroking
		SubEdging = NEW_SubEdging
		SubHoldingEdge = NEW_SubHoldingEdge
		EndTease = NEW_EndTease
		ShowModule = NEW_ShowModule
		ModuleEnd = NEW_ModuleEnd
		DivideText = NEW_DivideText
		HoldEdgeTick = NEW_HoldEdgeTick
		HoldEdgeChance = NEW_HoldEdgeChance
		EdgeHold = NEW_EdgeHold
		EdgeNoHold = NEW_EdgeNoHold
		EdgeToRuin = NEW_EdgeToRuin
		EdgeToRuinSecret = NEW_EdgeToRuinSecret
		LongEdge = NEW_LongEdge
		AskedToGiveUp = NEW_AskedToGiveUp
		AskedToGiveUpSection = NEW_AskedToGiveUpSection
		SubGaveUp = NEW_SubGaveUp
		AskedToSpeedUp = NEW_AskedToSpeedUp
		AskedToSlowDown = NEW_AskedToSlowDown
		ThoughtEnd = NEW_ThoughtEnd
		VTLength = NEW_VTLength
		DommeVideo = NEW_DommeVideo
		VideoType = NEW_VideoType
		CensorshipGame = NEW_CensorshipGame
		CensorshipTick = NEW_CensorshipTick
		CensorDuration = NEW_CensorDuration
		AvoidTheEdgeGame = NEW_AvoidTheEdgeGame
		AvoidTheEdgeTick = NEW_AvoidTheEdgeTick
		AvoidTheEdgeTimerTick = NEW_AvoidTheEdgeTimerTick
		AvoidTheEdgeDuration = NEW_AvoidTheEdgeDuration
		AvoidTheEdgeStroking = NEW_AvoidTheEdgeStroking
		AtECountdown = NEW_AtECountdown
		VTPath = NEW_VTPath
		NoVideo = NEW_NoVideo
		NoSpecialVideo = NEW_NoSpecialVideo
		VideoCheck = NEW_VideoCheck
		VideoTease = NEW_VideoTease
		RLGLGame = NEW_RLGLGame
		RLGLStroking = NEW_RLGLStroking
		RLGLTick = NEW_RLGLTick
		RedLight = NEW_RedLight
		RLGLTauntTick = NEW_RLGLTauntTick
		RandomizerVideo = NEW_RandomizerVideo
		RandomizerVideoTease = NEW_RandomizerVideoTease
		ScriptVideoTease = NEW_ScriptVideoTease
		ScriptVideoTeaseFlag = NEW_ScriptVideoTeaseFlag
		VideoTauntTick = NEW_VideoTauntTick
		SlideshowLoaded = NEW_SlideshowLoaded
		GlitterImageAV = NEW_GlitterImageAV
		GlitterTempColor = NEW_GlitterTempColor
		UpdatesTick = NEW_UpdatesTick
		UpdatingPost = NEW_UpdatingPost
		UpdateStage = NEW_UpdateStage
		UpdateStageTick = NEW_UpdateStageTick
		StatusText = NEW_StatusText
		ContactNumber = NEW_ContactNumber
		ContactTick = NEW_ContactTick
		ContactFlag = NEW_ContactFlag
		StatusText1 = NEW_StatusText1
		StatusText2 = NEW_StatusText2
		StatusText3 = NEW_StatusText3
		StatusChance1 = NEW_StatusChance1
		StatusChance2 = NEW_StatusChance2
		StatusChance3 = NEW_StatusChance3
		Update1 = NEW_Update1
		Update2 = NEW_Update2
		Update3 = NEW_Update3
		GetFolder = NEW_GetFolder
		FileCount = NEW_FileCount
		FileCountMax = NEW_FileCountMax
		_ImageFileNames = NEW__ImageFileNames
		_CurrentImage = NEW__CurrentImage
		WithTeaseImgDir = NEW_WithTeaseImgDir
		ApproveImage = NEW_ApproveImage
		WIExit = NEW_WIExit
		RecentSlideshows = NEW_RecentSlideshows
		MainPictureImage = NEW_MainPictureImage
		DomPic = NEW_DomPic
		LockImage = NEW_LockImage
		LockVideo = NEW_LockVideo
		LocalTagImageList = NEW_LocalTagImageList
		Crazy = NEW_Crazy
		Vulgar = NEW_Vulgar
		Supremacist = NEW_Supremacist
		CockSize = NEW_CockSize
		PetName = NEW_PetName
		TauntText = NEW_TauntText
		ScriptCount = NEW_ScriptCount
		TempScriptCount = NEW_TempScriptCount
		TauntTextCount = NEW_TauntTextCount
		SlideshowTimerTick = NEW_SlideshowTimerTick
		WebImage = NEW_WebImage
		WebImageLines = NEW_WebImageLines
		WebImageLine = NEW_WebImageLine
		WebImageLineTotal = NEW_WebImageLineTotal
		WebImagePath = NEW_WebImagePath
		LastScriptCountdown = NEW_LastScriptCountdown
		LastScript = NEW_LastScript
		JustShowedBlogImage = NEW_JustShowedBlogImage
		SaidHello = NEW_SaidHello
		StopMetronome = NEW_StopMetronome
		AvgEdgeStroking = NEW_AvgEdgeStroking
		AvgEdgeNoTouch = NEW_AvgEdgeNoTouch
		EdgeCountTick = NEW_EdgeCountTick
		AvgEdgeStrokingFlag = NEW_AvgEdgeStrokingFlag
		AvgEdgeCount = NEW_AvgEdgeCount
		AvgEdgeCountRest = NEW_AvgEdgeCountRest
		EdgeTickCheck = NEW_EdgeTickCheck
		EdgeNOT = NEW_EdgeNOT
		AlreadyStrokingEdge = NEW_AlreadyStrokingEdge
		WritingTaskLinesAmount = NEW_WritingTaskLinesAmount
		WritingTaskLinesWritten = NEW_WritingTaskLinesWritten
		WritingTaskLinesRemaining = NEW_WritingTaskLinesRemaining
		WritingTaskMistakesAllowed = NEW_WritingTaskMistakesAllowed
		WritingTaskMistakesMade = NEW_WritingTaskMistakesMade
		WritingTaskFlag = NEW_WritingTaskFlag
		FirstRound = NEW_FirstRound
		StartStrokingCount = NEW_StartStrokingCount
		TeaseJOI = NEW_TeaseJOI
		TeaseVideo = NEW_TeaseVideo
		TnAList = NEW_TnAList
		BoobList = NEW_BoobList
		AssList = NEW_AssList
		AssImage = NEW_AssImage
		BoobImage = NEW_BoobImage
		FoundTag = NEW_FoundTag
		TagGarment = NEW_TagGarment
		TagUnderwear = NEW_TagUnderwear
		TagTattoo = NEW_TagTattoo
		TagSexToy = NEW_TagSexToy
		TagFurniture = NEW_TagFurniture
		BookmarkModule = NEW_BookmarkModule
		BookmarkModuleFile = NEW_BookmarkModuleFile
		BookmarkModuleLine = NEW_BookmarkModuleLine
		BookmarkLink = NEW_BookmarkLink
		BookmarkLinkFile = NEW_BookmarkLinkFile
		BookmarkLinkLine = NEW_BookmarkLinkLine
		WaitTick = NEW_WaitTick
		OrgasmDenied = NEW_OrgasmDenied
		OrgasmAllowed = NEW_OrgasmAllowed
		OrgasmRuined = NEW_OrgasmRuined
		LastOrgasmType = NEW_LastOrgasmType
		StupidTick = NEW_StupidTick
		StupidFlag = NEW_StupidFlag
		CaloriesConsumed = NEW_CaloriesConsumed
		CaloriesGoal = NEW_CaloriesGoal
		GoldTokens = NEW_GoldTokens
		SilverTokens = NEW_SilverTokens
		BronzeTokens = NEW_BronzeTokens
		EdgeFound = NEW_EdgeFound
		OrgasmYesNo = NEW_OrgasmYesNo
		VTFlag = NEW_VTFlag
		DomPersonality = NEW_DomPersonality
		UpdateList = NEW_UpdateList
		GlitterDocument = NEW_GlitterDocument
		CustomSlideshow = NEW_CustomSlideshow
		CustomSlideshowTick = NEW_CustomSlideshowTick
		CustomSlideshowList = NEW_CustomSlideshowList
		ImageString = NEW_ImageString
		RapidFire = NEW_RapidFire
		GlitterTease = NEW_GlitterTease
		AddContactTick = NEW_AddContactTick
		Contact1Pics = NEW_Contact1Pics
		Contact2Pics = NEW_Contact2Pics
		Contact3Pics = NEW_Contact3Pics
		Contact1PicsCount = NEW_Contact1PicsCount
		Contact2PicsCount = NEW_Contact2PicsCount
		Contact3PicsCount = NEW_Contact3PicsCount
		Group = NEW_Group
		CustomTask = NEW_CustomTask
		CustomTaskFirst = NEW_CustomTaskFirst
		CustomTaskText = NEW_CustomTaskText
		CustomTaskTextFirst = NEW_CustomTaskTextFirst
		CustomTaskActive = NEW_CustomTaskActive
		SubtitleCount = NEW_SubtitleCount
		VidFile = NEW_VidFile
		RiskyDeal = NEW_RiskyDeal
		RiskyEdges = NEW_RiskyEdges
		RiskyDelay = NEW_RiskyDelay
		FinalRiskyPick = NEW_FinalRiskyPick
		SysMes = NEW_SysMes
		EmoMes = NEW_EmoMes
		Contact1Edge = NEW_Contact1Edge
		Contact2Edge = NEW_Contact2Edge
		Contact3Edge = NEW_Contact3Edge
		Contact1Stroke = NEW_Contact1Stroke
		Contact2Stroke = NEW_Contact2Stroke
		Contact3Stroke = NEW_Contact3Stroke
		ReturnFileText = NEW_ReturnFileText
		ReturnStrokeTauntVal = NEW_ReturnStrokeTauntVal
		ReturnSubState = NEW_ReturnSubState
		ReturnFlag = NEW_ReturnFlag
		SessionEdges = NEW_SessionEdges
		WindowCheck = NEW_WindowCheck
		StrokeFaster = NEW_StrokeFaster
		StrokeFastest = NEW_StrokeFastest
		StrokeSlower = NEW_StrokeSlower
		StrokeSlowest = NEW_StrokeSlowest
		InputFlag = NEW_InputFlag
		InputString = NEW_InputString
		RapidCode = NEW_RapidCode
		CorrectedTypo = NEW_CorrectedTypo
		CorrectedWord = NEW_CorrectedWord
		DoNotDisturb = NEW_DoNotDisturb
		TypoSwitch = NEW_TypoSwitch
		TyposDisabled = NEW_TyposDisabled
		EdgeHoldSeconds = NEW_EdgeHoldSeconds
		EdgeHoldFlag = NEW_EdgeHoldFlag
		SlideshowInt = NEW_SlideshowInt
		JustShowedSlideshowImage = NEW_JustShowedSlideshowImage
		RandomSlideshowCategory = NEW_RandomSlideshowCategory
		ResetFlag = NEW_ResetFlag
		DommeTags = NEW_DommeTags
		ThemeSettings = NEW_ThemeSettings
		InputIcon = NEW_InputIcon
		ApplyingTheme = NEW_ApplyingTheme
		AdjustingWindow = NEW_AdjustingWindow
		SplitContainerHeight = NEW_SplitContainerHeight
		DommeImageFound = NEW_DommeImageFound
		LocalImageFound = NEW_LocalImageFound
		LocalImageListCheck = NEW_LocalImageListCheck
		CBTBothActive = NEW_CBTBothActive
		CBTBothFlag = NEW_CBTBothFlag
		CBTBothCount = NEW_CBTBothCount
		CBTBothFirst = NEW_CBTBothFirst
		GeneralTime = NEW_GeneralTime
		NewDommeSlideshow = NEW_NewDommeSlideshow
		OriginalDommeSlideshow = NEW_OriginalDommeSlideshow
		TimeoutTick = NEW_TimeoutTick
		DommeImageSTR = NEW_DommeImageSTR
		LocalImageSTR = NEW_LocalImageSTR
		ImageLocation = NEW_ImageLocation
		ResponseYes = NEW_ResponseYes
		ResponseNo = NEW_ResponseNo
		SetModule = NEW_SetModule
		SetLink = NEW_SetLink
		SetModuleGoto = NEW_SetModuleGoto
		SetLinkGoto = NEW_SetLinkGoto
		OrgasmRestricted = NEW_OrgasmRestricted
		FollowUp = NEW_FollowUp
		WorshipMode = NEW_WorshipMode
		WorshipTarget = NEW_WorshipTarget
		LongHold = NEW_LongHold
		ExtremeHold = NEW_ExtremeHold
		LongTaunts = NEW_LongTaunts
		LazyEdit1 = NEW_LazyEdit1
		LazyEdit2 = NEW_LazyEdit2
		LazyEdit3 = NEW_LazyEdit3
		LazyEdit4 = NEW_LazyEdit4
		LazyEdit5 = NEW_LazyEdit5
		FormFinishedLoading = NEW_FormFinishedLoading
		MiniScript = NEW_MiniScript
		MiniScriptText = NEW_MiniScriptText
		MiniTauntVal = NEW_MiniTauntVal
		MiniTimerCheck = NEW_MiniTimerCheck
		JumpVideo = NEW_JumpVideo
		VideoTick = NEW_VideoTick
		EdgeGoto = NEW_EdgeGoto
		EdgeMessage = NEW_EdgeMessage
		EdgeVideo = NEW_EdgeVideo
		EdgeMessageText = NEW_EdgeMessageText
		EdgeGotoLine = NEW_EdgeGotoLine
		MultipleEdges = NEW_MultipleEdges
		MultipleEdgesAmount = NEW_MultipleEdgesAmount
		MultipleEdgesInterval = NEW_MultipleEdgesInterval
		MultipleEdgesTick = NEW_MultipleEdgesTick
		MultipleEdgesMetronome = NEW_MultipleEdgesMetronome
		YesGoto = NEW_YesGoto
		YesVideo = NEW_YesVideo
		NoGoto = NEW_NoGoto
		NoVideo_Mode = NEW_NoVideo_Mode
		CameGoto = NEW_CameGoto
		CameVideo = NEW_CameVideo
		CameMessage = NEW_CameMessage
		CameMessageText = NEW_CameMessageText
		RuinedGoto = NEW_RuinedGoto
		RuinedVideo = NEW_RuinedVideo
		RuinedMessage = NEW_RuinedMessage
		RuinedMessageText = NEW_RuinedMessageText
		YesGotoLine = NEW_YesGotoLine
		NoGotoLine = NEW_NoGotoLine
		CameGotoLine = NEW_CameGotoLine
		RuinedGotoLine = NEW_RuinedGotoLine
		TauntEdging = NEW_TauntEdging
		WritingTaskCurrentTime = NEW_WritingTaskCurrentTime


	End Sub




End Class
