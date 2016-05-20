
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
	Public DomColor As String
	Public SubColor As String
	Public StrokeTick As Integer
	Public StrokeTauntTick As Integer
	Public StrokePaceRight As Boolean
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
	Public RefreshVideoTotal As Integer
	Public GlitterImageAV As String
	Public GlitterNCDomme As String
	Public GlitterNC1 As String
	Public GlitterNC2 As String
	Public GlitterNC3 As String
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
	Public TempDick As String
	Public PetName As String
	Public PetName2 As String
	Public TauntText As String
	Public ScriptCount As Integer
	Public TempScriptCount As Integer
	Public TauntTextCount As Integer
	Public StartIndex As Integer
	Public EndIndex As Integer
	Public SlideshowTimerTick As Integer
	Public ReadBlog As String
	Public ReadBlogRate As String
	Public SearchImageBlog As Boolean
	Public FoundString As String
	Public WebImage As String
	Public WebImageLines As New List(Of String)
	Public WebImageLine As Integer
	Public WebImageLineTotal As Integer
	Public WebImagePath As String
	Public ReaderString As String
	Public ReaderStringTotal As Integer
	Public StrokePaceInt As Integer
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
	Public PBImage As String
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
	Public TauntEdgingAsked As Boolean
	Public WritingTaskCurrentTime As Single



	Public Sub New()
	End Sub


	Public Sub New( _
	ByVal NEW_Chat As String, _
	 ByVal NEW_ScriptOperator As String, _
	 ByVal NEW_ScriptCompare As String, _
	 ByVal NEW_DomTyping As Boolean, _
	 ByVal NEW_CheckYes As Boolean, _
	 ByVal NEW_CheckNo As Boolean, _
	 ByVal NEW_Playlist As Boolean, _
	 ByVal NEW_PlaylistFile As List(Of String), _
	 ByVal NEW_PlaylistCurrent As Integer, _
	 ByVal NEW_FormLoading As Boolean, _
	 ByVal NEW_Responding As Boolean, _
	 ByVal NEW_StrokeTauntVal As Integer, _
	 ByVal NEW_FileText As String, _
	 ByVal NEW_TempStrokeTauntVal As Integer, _
	 ByVal NEW_TempFileText As String, _
	 ByVal NEW_TeaseTick As Integer, _
	 ByVal NEW_StrokeTauntCount As Integer, _
	 ByVal NEW_TauntTextTotal As Integer, _
	 ByVal NEW_TauntLines As List(Of String), _
	 ByVal NEW_StrokeFilter As Boolean, _
	 ByVal NEW_ScriptTick As Integer, _
	 ByVal NEW_StringLength As Integer, _
	 ByVal NEW_FileGoto As String, _
	 ByVal NEW_SkipGotoLine As Boolean, _
	 ByVal NEW_ChatString As String, _
	 ByVal NEW_DomTask As String, _
	 ByVal NEW_DomChat As String, _
	 ByVal NEW_TypeDelay As Integer, _
	 ByVal NEW_TempVal As Integer, _
	 ByVal NEW_NullResponse As Boolean, _
	 ByVal NEW_TagCount As Integer, _
	 ByVal NEW_LocalTagCount As Integer, _
	 ByVal NEW_TaskFile As String, _
	 ByVal NEW_TaskText As String, _
	 ByVal NEW_TaskTextDir As String, _
	 ByVal NEW_ResponseFile As String, _
	 ByVal NEW_ResponseLine As Integer, _
	 ByVal NEW_CBTCockActive As Boolean, _
	 ByVal NEW_CBTBallsActive As Boolean, _
	 ByVal NEW_CBTCockFlag As Boolean, _
	 ByVal NEW_CBTBallsFlag As Boolean, _
	 ByVal NEW_CBTBallsFirst As Boolean, _
	 ByVal NEW_CBTCockFirst As Boolean, _
	 ByVal NEW_CBTBallsCount As Integer, _
	 ByVal NEW_CBTCockCount As Integer, _
	 ByVal NEW_TasksCount As Integer, _
	 ByVal NEW_GotoDommeLevel As Boolean, _
	 ByVal NEW_DommeMood As Integer, _
	 ByVal NEW_AFK As Boolean, _
	 ByVal NEW_HypnoGen As Boolean, _
	 ByVal NEW_Induction As Boolean, _
	 ByVal NEW_TempHypno As String, _
	 ByVal NEW_DomColor As String, _
	 ByVal NEW_SubColor As String, _
	 ByVal NEW_StrokeTick As Integer, _
	 ByVal NEW_StrokeTauntTick As Integer, _
	 ByVal NEW_StrokePaceRight As Boolean, _
	 ByVal NEW_StrokePace As Integer, _
	 ByVal NEW_StrokeTimeTotal As Integer, _
	 ByVal NEW_HoldEdgeTime As Integer, _
	 ByVal NEW_HoldEdgeTimeTotal As Integer, _
	 ByVal NEW_EdgeTauntInt As Integer, _
	 ByVal NEW_DelayTick As Integer, _
	 ByVal NEW_DomTypeCheck As Boolean, _
	 ByVal NEW_TypeToggle As Boolean, _
	 ByVal NEW_IsTyping As Boolean, _
	 ByVal NEW_SubWroteLast As Boolean, _
	 ByVal NEW_YesOrNo As Boolean, _
	 ByVal NEW_GotoFlag As Boolean, _
	 ByVal NEW_CBT As Boolean, _
	 ByVal NEW_RunningScript As Boolean, _
	 ByVal NEW_BeforeTease As Boolean, _
	 ByVal NEW_SubStroking As Boolean, _
	 ByVal NEW_SubEdging As Boolean, _
	 ByVal NEW_SubHoldingEdge As Boolean, _
	 ByVal NEW_EndTease As Boolean, _
	 ByVal NEW_ShowModule As Boolean, _
	 ByVal NEW_ModuleEnd As Boolean, _
	 ByVal NEW_DivideText As Boolean, _
	 ByVal NEW_HoldEdgeTick As Integer, _
	 ByVal NEW_HoldEdgeChance As Integer, _
	 ByVal NEW_EdgeHold As Boolean, _
	 ByVal NEW_EdgeNoHold As Boolean, _
	 ByVal NEW_EdgeToRuin As Boolean, _
	 ByVal NEW_EdgeToRuinSecret As Boolean, _
	 ByVal NEW_LongEdge As Boolean, _
	 ByVal NEW_AskedToGiveUp As Boolean, _
	 ByVal NEW_AskedToGiveUpSection As Boolean, _
	 ByVal NEW_SubGaveUp As Boolean, _
	 ByVal NEW_AskedToSpeedUp As Boolean, _
	 ByVal NEW_AskedToSlowDown As Boolean, _
	 ByVal NEW_ThoughtEnd As Boolean, _
	 ByVal NEW_VTLength As Integer, _
	 ByVal NEW_DommeVideo As Boolean, _
	 ByVal NEW_VideoType As String, _
	 ByVal NEW_CensorshipGame As Boolean, _
	 ByVal NEW_CensorshipTick As Integer, _
	 ByVal NEW_CensorDuration As String, _
	 ByVal NEW_AvoidTheEdgeGame As Boolean, _
	 ByVal NEW_AvoidTheEdgeTick As Integer, _
	 ByVal NEW_AvoidTheEdgeTimerTick As Integer, _
	 ByVal NEW_AvoidTheEdgeDuration As String, _
	 ByVal NEW_AvoidTheEdgeStroking As Boolean, _
	 ByVal NEW_AtECountdown As Integer, _
	 ByVal NEW_VTPath As String, _
	 ByVal NEW_NoVideo As Boolean, _
	 ByVal NEW_NoSpecialVideo As Boolean, _
	 ByVal NEW_VideoCheck As Boolean, _
	 ByVal NEW_VideoTease As Boolean, _
	 ByVal NEW_RLGLGame As Boolean, _
	 ByVal NEW_RLGLStroking As Boolean, _
	 ByVal NEW_RLGLTick As Integer, _
	 ByVal NEW_RedLight As Boolean, _
	 ByVal NEW_RLGLTauntTick As Integer, _
	 ByVal NEW_RandomizerVideo As Boolean, _
	 ByVal NEW_RandomizerVideoTease As Boolean, _
	 ByVal NEW_ScriptVideoTease As String, _
	 ByVal NEW_ScriptVideoTeaseFlag As Boolean, _
	 ByVal NEW_VideoTauntTick As Integer, _
	 ByVal NEW_SlideshowLoaded As Boolean, _
	 ByVal NEW_RefreshVideoTotal As Integer, _
	 ByVal NEW_GlitterImageAV As String, _
	 ByVal NEW_GlitterNCDomme As String, _
	 ByVal NEW_GlitterNC1 As String, _
	 ByVal NEW_GlitterNC2 As String, _
	 ByVal NEW_GlitterNC3 As String, _
	 ByVal NEW_GlitterTempColor As String, _
	 ByVal NEW_UpdatesTick As Integer, _
	 ByVal NEW_UpdatingPost As Boolean, _
	 ByVal NEW_UpdateStage As Integer, _
	 ByVal NEW_UpdateStageTick As Integer, _
	 ByVal NEW_StatusText As String, _
	 ByVal NEW_ContactNumber As Integer, _
	 ByVal NEW_ContactTick As Integer, _
	 ByVal NEW_ContactFlag As Boolean, _
	 ByVal NEW_StatusText1 As String, _
	 ByVal NEW_StatusText2 As String, _
	 ByVal NEW_StatusText3 As String, _
	 ByVal NEW_StatusChance1 As Integer, _
	 ByVal NEW_StatusChance2 As Integer, _
	 ByVal NEW_StatusChance3 As Integer, _
	 ByVal NEW_Update1 As Boolean, _
	 ByVal NEW_Update2 As Boolean, _
	 ByVal NEW_Update3 As Boolean, _
	 ByVal NEW_GetFolder As String, _
	 ByVal NEW_FileCount As Integer, _
	 ByVal NEW_FileCountMax As Integer, _
	 ByVal NEW__ImageFileNames As List(Of String), _
	 ByVal NEW__CurrentImage As Integer, _
	 ByVal NEW_WithTeaseImgDir As String, _
	 ByVal NEW_ApproveImage As Integer, _
	 ByVal NEW_WIExit As Boolean, _
	 ByVal NEW_RecentSlideshows As List(Of String), _
	 ByVal NEW_MainPictureImage As String, _
	 ByVal NEW_DomPic As String, _
	 ByVal NEW_LockImage As Boolean, _
	 ByVal NEW_LockVideo As Boolean, _
	 ByVal NEW_LocalTagImageList As List(Of String), _
	 ByVal NEW_Crazy As Boolean, _
	 ByVal NEW_Vulgar As Boolean, _
	 ByVal NEW_Supremacist As Boolean, _
	 ByVal NEW_CockSize As Integer, _
	 ByVal NEW_TempDick As String, _
	 ByVal NEW_PetName As String, _
	 ByVal NEW_PetName2 As String, _
	 ByVal NEW_TauntText As String, _
	 ByVal NEW_ScriptCount As Integer, _
	 ByVal NEW_TempScriptCount As Integer, _
	 ByVal NEW_TauntTextCount As Integer, _
	 ByVal NEW_StartIndex As Integer, _
	 ByVal NEW_EndIndex As Integer, _
	 ByVal NEW_SlideshowTimerTick As Integer, _
	 ByVal NEW_ReadBlog As String, _
	 ByVal NEW_ReadBlogRate As String, _
	 ByVal NEW_SearchImageBlog As Boolean, _
	 ByVal NEW_FoundString As String, _
	 ByVal NEW_WebImage As String, _
	 ByVal NEW_WebImageLines As List(Of String), _
	 ByVal NEW_WebImageLine As Integer, _
	 ByVal NEW_WebImageLineTotal As Integer, _
	 ByVal NEW_WebImagePath As String, _
	 ByVal NEW_ReaderString As String, _
	 ByVal NEW_ReaderStringTotal As Integer, _
	 ByVal NEW_StrokePaceInt As Integer, _
	 ByVal NEW_LastScriptCountdown As Integer, _
	 ByVal NEW_LastScript As Boolean, _
	 ByVal NEW_JustShowedBlogImage As Boolean, _
	 ByVal NEW_SaidHello As Boolean, _
	 ByVal NEW_StopMetronome As Boolean, _
	 ByVal NEW_AvgEdgeStroking As Integer, _
	 ByVal NEW_AvgEdgeNoTouch As Integer, _
	 ByVal NEW_EdgeCountTick As Integer, _
	 ByVal NEW_AvgEdgeStrokingFlag As Boolean, _
	 ByVal NEW_AvgEdgeCount As Integer, _
	 ByVal NEW_AvgEdgeCountRest As Integer, _
	 ByVal NEW_EdgeTickCheck As Integer, _
	 ByVal NEW_EdgeNOT As Boolean, _
	 ByVal NEW_AlreadyStrokingEdge As Boolean, _
	 ByVal NEW_WritingTaskLinesAmount As Integer, _
	 ByVal NEW_WritingTaskLinesWritten As Integer, _
	 ByVal NEW_WritingTaskLinesRemaining As Integer, _
	 ByVal NEW_WritingTaskMistakesAllowed As Integer, _
	 ByVal NEW_WritingTaskMistakesMade As Integer, _
	 ByVal NEW_WritingTaskFlag As Boolean, _
	 ByVal NEW_FirstRound As Boolean, _
	 ByVal NEW_StartStrokingCount As Integer, _
	 ByVal NEW_TeaseJOI As Boolean, _
	 ByVal NEW_TeaseVideo As Boolean, _
	 ByVal NEW_TnAList As List(Of String), _
	 ByVal NEW_BoobList As List(Of String), _
	 ByVal NEW_AssList As List(Of String), _
	 ByVal NEW_AssImage As Boolean, _
	 ByVal NEW_BoobImage As Boolean, _
	 ByVal NEW_FoundTag As String, _
	 ByVal NEW_TagGarment As String, _
	 ByVal NEW_TagUnderwear As String, _
	 ByVal NEW_TagTattoo As String, _
	 ByVal NEW_TagSexToy As String, _
	 ByVal NEW_TagFurniture As String, _
	 ByVal NEW_BookmarkModule As Boolean, _
	 ByVal NEW_BookmarkModuleFile As String, _
	 ByVal NEW_BookmarkModuleLine As Integer, _
	 ByVal NEW_BookmarkLink As Boolean, _
	 ByVal NEW_BookmarkLinkFile As String, _
	 ByVal NEW_BookmarkLinkLine As Integer, _
	 ByVal NEW_WaitTick As Integer, _
	 ByVal NEW_OrgasmDenied As Boolean, _
	 ByVal NEW_OrgasmAllowed As Boolean, _
	 ByVal NEW_OrgasmRuined As Boolean, _
	 ByVal NEW_LastOrgasmType As String, _
	 ByVal NEW_StupidTick As Integer, _
	 ByVal NEW_StupidFlag As Boolean, _
	 ByVal NEW_CaloriesConsumed As Integer, _
	 ByVal NEW_CaloriesGoal As Integer, _
	 ByVal NEW_GoldTokens As Integer, _
	 ByVal NEW_SilverTokens As Integer, _
	 ByVal NEW_BronzeTokens As Integer, _
	 ByVal NEW_EdgeFound As Boolean, _
	 ByVal NEW_OrgasmYesNo As Boolean, _
	 ByVal NEW_VTFlag As Boolean, _
	 ByVal NEW_DomPersonality As String, _
	 ByVal NEW_UpdateList As List(Of String), _
	 ByVal NEW_GlitterDocument As String, _
	 ByVal NEW_CustomSlideshow As Boolean, _
	 ByVal NEW_CustomSlideshowTick As Integer, _
	 ByVal NEW_CustomSlideshowList As List(Of String), _
	 ByVal NEW_ImageString As String, _
	 ByVal NEW_RapidFire As Boolean, _
	 ByVal NEW_GlitterTease As Boolean, _
	 ByVal NEW_AddContactTick As Integer, _
	 ByVal NEW_Contact1Pics As List(Of String), _
	 ByVal NEW_Contact2Pics As List(Of String), _
	 ByVal NEW_Contact3Pics As List(Of String), _
	 ByVal NEW_Contact1PicsCount As Integer, _
	 ByVal NEW_Contact2PicsCount As Integer, _
	 ByVal NEW_Contact3PicsCount As Integer, _
	 ByVal NEW_Group As String, _
	 ByVal NEW_CustomTask As Boolean, _
	 ByVal NEW_CustomTaskFirst As Boolean, _
	 ByVal NEW_CustomTaskText As String, _
	 ByVal NEW_CustomTaskTextFirst As String, _
	 ByVal NEW_CustomTaskActive As Boolean, _
	 ByVal NEW_SubtitleCount As Integer, _
	 ByVal NEW_VidFile As String, _
	 ByVal NEW_RiskyDeal As Boolean, _
	 ByVal NEW_RiskyEdges As Boolean, _
	 ByVal NEW_RiskyDelay As Boolean, _
	 ByVal NEW_FinalRiskyPick As Boolean, _
	 ByVal NEW_SysMes As Boolean, _
	 ByVal NEW_EmoMes As Boolean, _
	 ByVal NEW_Contact1Edge As Boolean, _
	 ByVal NEW_Contact2Edge As Boolean, _
	 ByVal NEW_Contact3Edge As Boolean, _
	 ByVal NEW_Contact1Stroke As Boolean, _
	 ByVal NEW_Contact2Stroke As Boolean, _
	 ByVal NEW_Contact3Stroke As Boolean, _
	 ByVal NEW_ReturnFileText As String, _
	 ByVal NEW_ReturnStrokeTauntVal As String, _
	 ByVal NEW_ReturnSubState As String, _
	 ByVal NEW_ReturnFlag As Boolean, _
	 ByVal NEW_SessionEdges As Integer, _
	 ByVal NEW_WindowCheck As Boolean, _
	 ByVal NEW_StrokeFaster As Boolean, _
	 ByVal NEW_StrokeFastest As Boolean, _
	 ByVal NEW_StrokeSlower As Boolean, _
	 ByVal NEW_StrokeSlowest As Boolean, _
	 ByVal NEW_InputFlag As Boolean, _
	 ByVal NEW_InputString As String, _
	 ByVal NEW_RapidCode As Boolean, _
	 ByVal NEW_CorrectedTypo As Boolean, _
	 ByVal NEW_CorrectedWord As String, _
	 ByVal NEW_DoNotDisturb As Boolean, _
	 ByVal NEW_TypoSwitch As Integer, _
	 ByVal NEW_TyposDisabled As Boolean, _
	 ByVal NEW_EdgeHoldSeconds As Integer, _
	 ByVal NEW_EdgeHoldFlag As Boolean, _
	 ByVal NEW_SlideshowInt As Integer, _
	 ByVal NEW_JustShowedSlideshowImage As Boolean, _
	 ByVal NEW_RandomSlideshowCategory As String, _
	 ByVal NEW_ResetFlag As Boolean, _
	 ByVal NEW_DommeTags As Boolean, _
	 ByVal NEW_ThemeSettings As Boolean, _
	 ByVal NEW_InputIcon As Boolean, _
	 ByVal NEW_ApplyingTheme As Boolean, _
	 ByVal NEW_AdjustingWindow As Boolean, _
	 ByVal NEW_SplitContainerHeight As Integer, _
	 ByVal NEW_DommeImageFound As Boolean, _
	 ByVal NEW_LocalImageFound As Boolean, _
	 ByVal NEW_LocalImageListCheck As Boolean, _
	 ByVal NEW_CBTBothActive As Boolean, _
	 ByVal NEW_CBTBothFlag As Boolean, _
	 ByVal NEW_CBTBothCount As Integer, _
	 ByVal NEW_CBTBothFirst As Boolean, _
	 ByVal NEW_GeneralTime As String, _
	 ByVal NEW_NewDommeSlideshow As Boolean, _
	 ByVal NEW_OriginalDommeSlideshow As String, _
	 ByVal NEW_TimeoutTick As Integer, _
	 ByVal NEW_PBImage As String, _
	 ByVal NEW_DommeImageSTR As String, _
	 ByVal NEW_LocalImageSTR As String, _
	 ByVal NEW_ImageLocation As String, _
	 ByVal NEW_ResponseYes As String, _
	 ByVal NEW_ResponseNo As String, _
	 ByVal NEW_SetModule As String, _
	 ByVal NEW_SetLink As String, _
	 ByVal NEW_SetModuleGoto As String, _
	 ByVal NEW_SetLinkGoto As String, _
	 ByVal NEW_OrgasmRestricted As Boolean, _
	 ByVal NEW_FollowUp As String, _
	 ByVal NEW_WorshipMode As Boolean, _
	 ByVal NEW_WorshipTarget As String, _
	 ByVal NEW_LongHold As Boolean, _
	 ByVal NEW_ExtremeHold As Boolean, _
	 ByVal NEW_LongTaunts As Boolean, _
	 ByVal NEW_LazyEdit1 As Boolean, _
	 ByVal NEW_LazyEdit2 As Boolean, _
	 ByVal NEW_LazyEdit3 As Boolean, _
	 ByVal NEW_LazyEdit4 As Boolean, _
	 ByVal NEW_LazyEdit5 As Boolean, _
	 ByVal NEW_FormFinishedLoading As Boolean, _
	 ByVal NEW_MiniScript As Boolean, _
	 ByVal NEW_MiniScriptText As String, _
	 ByVal NEW_MiniTauntVal As Integer, _
	 ByVal NEW_MiniTimerCheck As Boolean, _
	 ByVal NEW_JumpVideo As Boolean, _
	 ByVal NEW_VideoTick As Integer, _
	 ByVal NEW_EdgeGoto As Boolean, _
	 ByVal NEW_EdgeMessage As Boolean, _
	 ByVal NEW_EdgeVideo As Boolean, _
	 ByVal NEW_EdgeMessageText As String, _
	 ByVal NEW_EdgeGotoLine As String, _
	 ByVal NEW_MultipleEdges As Boolean, _
	 ByVal NEW_MultipleEdgesAmount As Integer, _
	 ByVal NEW_MultipleEdgesInterval As Integer, _
	 ByVal NEW_MultipleEdgesTick As Integer, _
	 ByVal NEW_MultipleEdgesMetronome As String, _
	 ByVal NEW_YesGoto As Boolean, _
	 ByVal NEW_YesVideo As Boolean, _
	 ByVal NEW_NoGoto As Boolean, _
	 ByVal NEW_NoVideo_Mode As Boolean, _
	 ByVal NEW_CameGoto As Boolean, _
	 ByVal NEW_CameVideo As Boolean, _
	 ByVal NEW_CameMessage As Boolean, _
	 ByVal NEW_CameMessageText As String, _
	 ByVal NEW_RuinedGoto As Boolean, _
	 ByVal NEW_RuinedVideo As Boolean, _
	 ByVal NEW_RuinedMessage As Boolean, _
	 ByVal NEW_RuinedMessageText As String, _
	 ByVal NEW_YesGotoLine As String, _
	 ByVal NEW_NoGotoLine As String, _
	 ByVal NEW_CameGotoLine As String, _
	 ByVal NEW_RuinedGotoLine As String, _
	 ByVal NEW_TauntEdging As Boolean, _
	 ByVal NEW_TauntEdgingAsked As Boolean, _
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
		DomColor = NEW_DomColor
		SubColor = NEW_SubColor
		StrokeTick = NEW_StrokeTick
		StrokeTauntTick = NEW_StrokeTauntTick
		StrokePaceRight = NEW_StrokePaceRight
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
		RefreshVideoTotal = NEW_RefreshVideoTotal
		GlitterImageAV = NEW_GlitterImageAV
		GlitterNCDomme = NEW_GlitterNCDomme
		GlitterNC1 = NEW_GlitterNC1
		GlitterNC2 = NEW_GlitterNC2
		GlitterNC3 = NEW_GlitterNC3
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
		TempDick = NEW_TempDick
		PetName = NEW_PetName
		PetName2 = NEW_PetName2
		TauntText = NEW_TauntText
		ScriptCount = NEW_ScriptCount
		TempScriptCount = NEW_TempScriptCount
		TauntTextCount = NEW_TauntTextCount
		StartIndex = NEW_StartIndex
		EndIndex = NEW_EndIndex
		SlideshowTimerTick = NEW_SlideshowTimerTick
		ReadBlog = NEW_ReadBlog
		ReadBlogRate = NEW_ReadBlogRate
		SearchImageBlog = NEW_SearchImageBlog
		FoundString = NEW_FoundString
		WebImage = NEW_WebImage
		WebImageLines = NEW_WebImageLines
		WebImageLine = NEW_WebImageLine
		WebImageLineTotal = NEW_WebImageLineTotal
		WebImagePath = NEW_WebImagePath
		ReaderString = NEW_ReaderString
		ReaderStringTotal = NEW_ReaderStringTotal
		StrokePaceInt = NEW_StrokePaceInt
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
		PBImage = NEW_PBImage
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
		TauntEdgingAsked = NEW_TauntEdgingAsked
		WritingTaskCurrentTime = NEW_WritingTaskCurrentTime


	End Sub




End Class
