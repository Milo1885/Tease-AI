<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSettings
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
Me.SettingsPanel = New System.Windows.Forms.Panel()
Me.SettingsTabs = New System.Windows.Forms.TabControl()
Me.TabPage1 = New System.Windows.Forms.TabPage()
Me.PNLGeneralSettings = New System.Windows.Forms.Panel()
Me.GroupBox3 = New System.Windows.Forms.GroupBox()
Me.BTNValidateSystemFiles = New System.Windows.Forms.Button()
Me.GroupBox2 = New System.Windows.Forms.GroupBox()
Me.TbxRandomImageDir = New System.Windows.Forms.TextBox()
Me.CBRandomDomme = New System.Windows.Forms.CheckBox()
Me.BtnRandomImageDir = New System.Windows.Forms.Button()
Me.BtnImportSettings = New System.Windows.Forms.Button()
Me.LblImportSettings = New System.Windows.Forms.Label()
Me.GroupBox64 = New System.Windows.Forms.GroupBox()
Me.CBMuteMedia = New System.Windows.Forms.CheckBox()
Me.GBDommeImages = New System.Windows.Forms.GroupBox()
Me.slideshowNumBox = New System.Windows.Forms.NumericUpDown()
Me.teaseRadio = New System.Windows.Forms.RadioButton()
Me.CBNewSlideshow = New System.Windows.Forms.CheckBox()
Me.offRadio = New System.Windows.Forms.RadioButton()
Me.BTNDomImageDir = New System.Windows.Forms.Button()
Me.timedRadio = New System.Windows.Forms.RadioButton()
Me.TbxDomImageDir = New System.Windows.Forms.TextBox()
Me.GBGeneralTextToSpeech = New System.Windows.Forms.GroupBox()
Me.LBLVRate = New System.Windows.Forms.Label()
Me.Label93 = New System.Windows.Forms.Label()
Me.LBLVVolume = New System.Windows.Forms.Label()
Me.Label68 = New System.Windows.Forms.Label()
Me.SliderVRate = New System.Windows.Forms.TrackBar()
Me.SliderVVolume = New System.Windows.Forms.TrackBar()
Me.TTSCheckBox = New System.Windows.Forms.CheckBox()
Me.TTSComboBox = New System.Windows.Forms.ComboBox()
Me.GBSafeword = New System.Windows.Forms.GroupBox()
Me.LBLSafeword = New System.Windows.Forms.Label()
Me.TBSafeword = New System.Windows.Forms.TextBox()
Me.GBGeneralSystem = New System.Windows.Forms.GroupBox()
Me.CBAuditStartup = New System.Windows.Forms.CheckBox()
Me.CBDomDel = New System.Windows.Forms.CheckBox()
Me.CBSettingsPause = New System.Windows.Forms.CheckBox()
Me.CBSaveChatlogExit = New System.Windows.Forms.CheckBox()
Me.CBAutosaveChatlog = New System.Windows.Forms.CheckBox()
Me.GBGeneralImages = New System.Windows.Forms.GroupBox()
Me.CBImageInfo = New System.Windows.Forms.CheckBox()
Me.CBSlideshowRandom = New System.Windows.Forms.CheckBox()
Me.landscapeCheckBox = New System.Windows.Forms.CheckBox()
Me.CBBlogImageWindow = New System.Windows.Forms.CheckBox()
Me.CBSlideshowSubDir = New System.Windows.Forms.CheckBox()
Me.PictureBox2 = New System.Windows.Forms.PictureBox()
Me.GBGeneralSettings = New System.Windows.Forms.GroupBox()
Me.CBWebtease = New System.Windows.Forms.CheckBox()
Me.GBSubFont = New System.Windows.Forms.GroupBox()
Me.BTNSubColor = New System.Windows.Forms.Button()
Me.LBLSubColor = New System.Windows.Forms.Label()
Me.NBFontSize = New System.Windows.Forms.NumericUpDown()
Me.Label2 = New System.Windows.Forms.Label()
Me.FontComboBox = New System.Windows.Forms.ComboBox()
Me.GBDommeFont = New System.Windows.Forms.GroupBox()
Me.BTNDomColor = New System.Windows.Forms.Button()
Me.LBLDomColor = New System.Windows.Forms.Label()
Me.FontComboBoxD = New System.Windows.Forms.ComboBox()
Me.NBFontSizeD = New System.Windows.Forms.NumericUpDown()
Me.Label7 = New System.Windows.Forms.Label()
Me.CBInputIcon = New System.Windows.Forms.CheckBox()
Me.typeinstantlyCheckBox = New System.Windows.Forms.CheckBox()
Me.timestampCheckBox = New System.Windows.Forms.CheckBox()
Me.shownamesCheckBox = New System.Windows.Forms.CheckBox()
Me.LBLGeneralSettings = New System.Windows.Forms.Label()
Me.TabPage2 = New System.Windows.Forms.TabPage()
Me.Panel3 = New System.Windows.Forms.Panel()
Me.GBGiveUp = New System.Windows.Forms.GroupBox()
Me.giveupCheckBox = New System.Windows.Forms.CheckBox()
Me.BTNLoadDomSet = New System.Windows.Forms.Button()
Me.BTNSaveDomSet = New System.Windows.Forms.Button()
Me.Label127 = New System.Windows.Forms.Label()
Me.Label126 = New System.Windows.Forms.Label()
Me.PictureBox4 = New System.Windows.Forms.PictureBox()
Me.GBDomTypingStyle = New System.Windows.Forms.GroupBox()
Me.TBEmoteEnd = New System.Windows.Forms.TextBox()
Me.Label67 = New System.Windows.Forms.Label()
Me.TBEmote = New System.Windows.Forms.TextBox()
Me.NBTypoChance = New System.Windows.Forms.NumericUpDown()
Me.Label66 = New System.Windows.Forms.Label()
Me.CBMeMyMine = New System.Windows.Forms.CheckBox()
Me.GroupBox63 = New System.Windows.Forms.GroupBox()
Me.LCaseCheckBox = New System.Windows.Forms.CheckBox()
Me.apostropheCheckBox = New System.Windows.Forms.CheckBox()
Me.periodCheckBox = New System.Windows.Forms.CheckBox()
Me.commaCheckBox = New System.Windows.Forms.CheckBox()
Me.Label64 = New System.Windows.Forms.Label()
Me.GBDomRanges = New System.Windows.Forms.GroupBox()
Me.NBDomMoodMax = New System.Windows.Forms.NumericUpDown()
Me.NBDomMoodMin = New System.Windows.Forms.NumericUpDown()
Me.Label37 = New System.Windows.Forms.Label()
Me.Label39 = New System.Windows.Forms.Label()
Me.NBSubAgeMax = New System.Windows.Forms.NumericUpDown()
Me.NBSubAgeMin = New System.Windows.Forms.NumericUpDown()
Me.Label31 = New System.Windows.Forms.Label()
Me.Label36 = New System.Windows.Forms.Label()
Me.NBSelfAgeMax = New System.Windows.Forms.NumericUpDown()
Me.NBSelfAgeMin = New System.Windows.Forms.NumericUpDown()
Me.Label21 = New System.Windows.Forms.Label()
Me.Label22 = New System.Windows.Forms.Label()
Me.NBAvgCockMax = New System.Windows.Forms.NumericUpDown()
Me.NBAvgCockMin = New System.Windows.Forms.NumericUpDown()
Me.Label23 = New System.Windows.Forms.Label()
Me.Label30 = New System.Windows.Forms.Label()
Me.GBDomStats = New System.Windows.Forms.GroupBox()
Me.Label128 = New System.Windows.Forms.Label()
Me.LBLEmpathy = New System.Windows.Forms.Label()
Me.NBEmpathy = New System.Windows.Forms.NumericUpDown()
Me.Label83 = New System.Windows.Forms.Label()
Me.NBDomBirthdayDay = New System.Windows.Forms.NumericUpDown()
Me.TBDomEyeColor = New System.Windows.Forms.TextBox()
Me.TBDomHairColor = New System.Windows.Forms.TextBox()
Me.domageNumBox = New System.Windows.Forms.NumericUpDown()
Me.Label47 = New System.Windows.Forms.Label()
Me.Label76 = New System.Windows.Forms.Label()
Me.NBDomBirthdayMonth = New System.Windows.Forms.NumericUpDown()
Me.Label84 = New System.Windows.Forms.Label()
Me.CBDomTattoos = New System.Windows.Forms.CheckBox()
Me.CBDomFreckles = New System.Windows.Forms.CheckBox()
Me.domhairlengthComboBox = New System.Windows.Forms.ComboBox()
Me.Label10 = New System.Windows.Forms.Label()
Me.dompubichairComboBox = New System.Windows.Forms.ComboBox()
Me.Label9 = New System.Windows.Forms.Label()
Me.boobComboBox = New System.Windows.Forms.ComboBox()
Me.DomLevelDescLabel = New System.Windows.Forms.Label()
Me.domlevelNumBox = New System.Windows.Forms.NumericUpDown()
Me.Label43 = New System.Windows.Forms.Label()
Me.Label44 = New System.Windows.Forms.Label()
Me.Label45 = New System.Windows.Forms.Label()
Me.Label46 = New System.Windows.Forms.Label()
Me.GBDomPersonality = New System.Windows.Forms.GroupBox()
Me.degradingCheckBox = New System.Windows.Forms.CheckBox()
Me.sadisticCheckBox = New System.Windows.Forms.CheckBox()
Me.supremacistCheckBox = New System.Windows.Forms.CheckBox()
Me.vulgarCheckBox = New System.Windows.Forms.CheckBox()
Me.crazyCheckBox = New System.Windows.Forms.CheckBox()
Me.CFNMCheckBox = New System.Windows.Forms.CheckBox()
Me.GBDomOrgasms = New System.Windows.Forms.GroupBox()
Me.CBLockOrgasmChances = New System.Windows.Forms.CheckBox()
Me.orgasmlockrandombutton = New System.Windows.Forms.Button()
Me.CBDomOrgasmEnds = New System.Windows.Forms.CheckBox()
Me.Label16 = New System.Windows.Forms.Label()
Me.Label12 = New System.Windows.Forms.Label()
Me.orgasmsperlockButton = New System.Windows.Forms.Button()
Me.orgasmsperComboBox = New System.Windows.Forms.ComboBox()
Me.orgasmsperLabel = New System.Windows.Forms.Label()
Me.limitcheckbox = New System.Windows.Forms.CheckBox()
Me.orgasmsPerNumBox = New System.Windows.Forms.NumericUpDown()
Me.CBDomDenialEnds = New System.Windows.Forms.CheckBox()
Me.alloworgasmComboBox = New System.Windows.Forms.ComboBox()
Me.ruinorgasmComboBox = New System.Windows.Forms.ComboBox()
Me.GBDomPetNames = New System.Windows.Forms.GroupBox()
Me.Label74 = New System.Windows.Forms.Label()
Me.petnameBox7 = New System.Windows.Forms.TextBox()
Me.petnameBox8 = New System.Windows.Forms.TextBox()
Me.petnameBox1 = New System.Windows.Forms.TextBox()
Me.Label15 = New System.Windows.Forms.Label()
Me.petnameBox4 = New System.Windows.Forms.TextBox()
Me.petnameBox6 = New System.Windows.Forms.TextBox()
Me.petnameBox2 = New System.Windows.Forms.TextBox()
Me.Label11 = New System.Windows.Forms.Label()
Me.petnameBox5 = New System.Windows.Forms.TextBox()
Me.petnameBox3 = New System.Windows.Forms.TextBox()
Me.Label54 = New System.Windows.Forms.Label()
Me.TabPage10 = New System.Windows.Forms.TabPage()
Me.Panel2 = New System.Windows.Forms.Panel()
Me.GroupBox22 = New System.Windows.Forms.GroupBox()
Me.NBWritingTaskMax = New System.Windows.Forms.NumericUpDown()
Me.NBWritingTaskMin = New System.Windows.Forms.NumericUpDown()
Me.Label75 = New System.Windows.Forms.Label()
Me.Label77 = New System.Windows.Forms.Label()
Me.GroupBox45 = New System.Windows.Forms.GroupBox()
Me.LBLCBTSlider = New System.Windows.Forms.Label()
Me.CBCBTBalls = New System.Windows.Forms.CheckBox()
Me.CBCBTCock = New System.Windows.Forms.CheckBox()
Me.CBTSlider = New System.Windows.Forms.TrackBar()
Me.GroupBox35 = New System.Windows.Forms.GroupBox()
Me.GroupBoxSorry = New System.Windows.Forms.GroupBox()
Me.TBSorry = New System.Windows.Forms.TextBox()
Me.GroupBox39 = New System.Windows.Forms.GroupBox()
Me.CBHonorificInclude = New System.Windows.Forms.CheckBox()
Me.CBHonorificCapitalized = New System.Windows.Forms.CheckBox()
Me.TBHonorific = New System.Windows.Forms.TextBox()
Me.GroupBox38 = New System.Windows.Forms.GroupBox()
Me.TBNo = New System.Windows.Forms.TextBox()
Me.GroupBox37 = New System.Windows.Forms.GroupBox()
Me.TBYes = New System.Windows.Forms.TextBox()
Me.GroupBox36 = New System.Windows.Forms.GroupBox()
Me.TBGreeting = New System.Windows.Forms.TextBox()
Me.GroupBox13 = New System.Windows.Forms.GroupBox()
Me.Label34 = New System.Windows.Forms.Label()
Me.TimeBoxWakeUp = New System.Windows.Forms.DateTimePicker()
Me.GroupBox7 = New System.Windows.Forms.GroupBox()
Me.LBLMaxExtremeHold = New System.Windows.Forms.Label()
Me.LBLMinExtremeHold = New System.Windows.Forms.Label()
Me.NBExtremeHoldMin = New System.Windows.Forms.NumericUpDown()
Me.Label133 = New System.Windows.Forms.Label()
Me.NBExtremeHoldMax = New System.Windows.Forms.NumericUpDown()
Me.LBLMaxLongHold = New System.Windows.Forms.Label()
Me.Label78 = New System.Windows.Forms.Label()
Me.LBLMinLongHold = New System.Windows.Forms.Label()
Me.NBLongHoldMin = New System.Windows.Forms.NumericUpDown()
Me.Label129 = New System.Windows.Forms.Label()
Me.NBLongHoldMax = New System.Windows.Forms.NumericUpDown()
Me.LBLMaxHold = New System.Windows.Forms.Label()
Me.Label79 = New System.Windows.Forms.Label()
Me.NBLongEdge = New System.Windows.Forms.NumericUpDown()
Me.LBLMinHold = New System.Windows.Forms.Label()
Me.CBEdgeUseAvg = New System.Windows.Forms.CheckBox()
Me.CBLongEdgeInterrupts = New System.Windows.Forms.CheckBox()
Me.NBHoldTheEdgeMin = New System.Windows.Forms.NumericUpDown()
Me.Label55 = New System.Windows.Forms.Label()
Me.Label81 = New System.Windows.Forms.Label()
Me.Label5 = New System.Windows.Forms.Label()
Me.NBHoldTheEdgeMax = New System.Windows.Forms.NumericUpDown()
Me.CBLongEdgeTaunts = New System.Windows.Forms.CheckBox()
Me.Label131 = New System.Windows.Forms.Label()
Me.PictureBox12 = New System.Windows.Forms.PictureBox()
Me.GroupBox32 = New System.Windows.Forms.GroupBox()
Me.LBLSubBdayFormat = New System.Windows.Forms.Label()
Me.CBChastitySpikes = New System.Windows.Forms.CheckBox()
Me.CBOwnChastity = New System.Windows.Forms.CheckBox()
Me.CBChastityPA = New System.Windows.Forms.CheckBox()
Me.CBHimHer = New System.Windows.Forms.CheckBox()
Me.CBBallsToPussy = New System.Windows.Forms.CheckBox()
Me.CBCockToClit = New System.Windows.Forms.CheckBox()
Me.NBBirthdayDay = New System.Windows.Forms.NumericUpDown()
Me.CBSubCircumcised = New System.Windows.Forms.CheckBox()
Me.CBSubPierced = New System.Windows.Forms.CheckBox()
Me.TBSubEyeColor = New System.Windows.Forms.TextBox()
Me.TBSubHairColor = New System.Windows.Forms.TextBox()
Me.Label63 = New System.Windows.Forms.Label()
Me.LBLSubInches = New System.Windows.Forms.Label()
Me.subAgeNumBox = New System.Windows.Forms.NumericUpDown()
Me.NBBirthdayMonth = New System.Windows.Forms.NumericUpDown()
Me.LBLSubCockSize = New System.Windows.Forms.Label()
Me.CockSizeNumBox = New System.Windows.Forms.NumericUpDown()
Me.LBLSubEye = New System.Windows.Forms.Label()
Me.LBLSubHair = New System.Windows.Forms.Label()
Me.LBLSubBirthday = New System.Windows.Forms.Label()
Me.LBLSubAge = New System.Windows.Forms.Label()
Me.Label70 = New System.Windows.Forms.Label()
Me.TabPage16 = New System.Windows.Forms.TabPage()
Me.Panel9 = New System.Windows.Forms.Panel()
Me.BTNScriptAvailable = New System.Windows.Forms.Button()
Me.BTNScriptNone = New System.Windows.Forms.Button()
Me.BTNScriptAll = New System.Windows.Forms.Button()
Me.BTNScriptOpen = New System.Windows.Forms.Button()
Me.LBLScriptReq = New System.Windows.Forms.Label()
Me.GroupBox31 = New System.Windows.Forms.GroupBox()
Me.RTBScriptReq = New System.Windows.Forms.RichTextBox()
Me.TCScripts = New System.Windows.Forms.TabControl()
Me.TabPage21 = New System.Windows.Forms.TabPage()
Me.CLBStartList = New System.Windows.Forms.CheckedListBox()
Me.TabPage17 = New System.Windows.Forms.TabPage()
Me.CLBModuleList = New System.Windows.Forms.CheckedListBox()
Me.TabPage18 = New System.Windows.Forms.TabPage()
Me.CLBLinkList = New System.Windows.Forms.CheckedListBox()
Me.TabPage19 = New System.Windows.Forms.TabPage()
Me.CLBEndList = New System.Windows.Forms.CheckedListBox()
Me.GroupBox42 = New System.Windows.Forms.GroupBox()
Me.RTBScriptDesc = New System.Windows.Forms.RichTextBox()
Me.PictureBox1 = New System.Windows.Forms.PictureBox()
Me.GroupBox43 = New System.Windows.Forms.GroupBox()
Me.Label98 = New System.Windows.Forms.Label()
Me.Label104 = New System.Windows.Forms.Label()
Me.TabPage7 = New System.Windows.Forms.TabPage()
Me.TabControl4 = New System.Windows.Forms.TabControl()
Me.TpImagesUrlFiles = New System.Windows.Forms.TabPage()
Me.CBURLPreview = New System.Windows.Forms.CheckBox()
Me.GroupBox66 = New System.Windows.Forms.GroupBox()
Me.PBURLPreview = New System.Windows.Forms.PictureBox()
Me.BTNURLFilesAll = New System.Windows.Forms.Button()
Me.BTNURLFilesNone = New System.Windows.Forms.Button()
Me.URLFileList = New System.Windows.Forms.CheckedListBox()
Me.TpImagesGenre = New System.Windows.Forms.TabPage()
Me.GrbImageUrlFiles = New System.Windows.Forms.GroupBox()
Me.TlpImageUrls = New System.Windows.Forms.TableLayoutPanel()
Me.BtnImageUrlButt = New System.Windows.Forms.Button()
Me.BtnImageUrlBoobs = New System.Windows.Forms.Button()
Me.BtnImageUrlBlowjob = New System.Windows.Forms.Button()
Me.BtnImageUrlCaptions = New System.Windows.Forms.Button()
Me.BtnImageUrlHentai = New System.Windows.Forms.Button()
Me.BtnImageUrlGay = New System.Windows.Forms.Button()
Me.BtnImageUrlGeneral = New System.Windows.Forms.Button()
Me.BtnImageUrlHardcore = New System.Windows.Forms.Button()
Me.BtnImageUrlLesbian = New System.Windows.Forms.Button()
Me.BtnImageUrlLezdom = New System.Windows.Forms.Button()
Me.BtnImageUrlMaledom = New System.Windows.Forms.Button()
Me.BtnImageUrlFemdom = New System.Windows.Forms.Button()
Me.BtnImageUrlSoftcore = New System.Windows.Forms.Button()
Me.ChbImageUrlHardcore = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlButts = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlMaledom = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlGay = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlSoftcore = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlBoobs = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlLesbian = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlBlowjob = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlCaptions = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlGeneral = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlFemdom = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlHentai = New System.Windows.Forms.CheckBox()
Me.ChbImageUrlLezdom = New System.Windows.Forms.CheckBox()
Me.TxbImageUrlBlowjob = New System.Windows.Forms.TextBox()
Me.TxbImageUrlSoftcore = New System.Windows.Forms.TextBox()
Me.TxbImageUrlLezdom = New System.Windows.Forms.TextBox()
Me.TxbImageUrlFemdom = New System.Windows.Forms.TextBox()
Me.TxbImageUrlHardcore = New System.Windows.Forms.TextBox()
Me.TxbImageUrlHentai = New System.Windows.Forms.TextBox()
Me.TxbImageUrlGay = New System.Windows.Forms.TextBox()
Me.TxbImageUrlLesbian = New System.Windows.Forms.TextBox()
Me.TxbImageUrlMaledom = New System.Windows.Forms.TextBox()
Me.TxbImageUrlCaptions = New System.Windows.Forms.TextBox()
Me.TxbImageUrlGeneral = New System.Windows.Forms.TextBox()
Me.TxbImageUrlBoobs = New System.Windows.Forms.TextBox()
Me.TxbImageUrlButts = New System.Windows.Forms.TextBox()
Me.GbxImagesGenre = New System.Windows.Forms.GroupBox()
Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
Me.BTNIHardcore = New System.Windows.Forms.Button()
Me.TbxIHardcore = New System.Windows.Forms.TextBox()
Me.CBIHardcoreSD = New System.Windows.Forms.CheckBox()
Me.CBIHardcore = New System.Windows.Forms.CheckBox()
Me.CBISoftcore = New System.Windows.Forms.CheckBox()
Me.TbxISoftcore = New System.Windows.Forms.TextBox()
Me.CBButtSubDir = New System.Windows.Forms.CheckBox()
Me.CBISoftcoreSD = New System.Windows.Forms.CheckBox()
Me.CBBoobSubDir = New System.Windows.Forms.CheckBox()
Me.CBILezdomSD = New System.Windows.Forms.CheckBox()
Me.CBIGeneralSD = New System.Windows.Forms.CheckBox()
Me.CBILesbianSD = New System.Windows.Forms.CheckBox()
Me.CBICaptionsSD = New System.Windows.Forms.CheckBox()
Me.CBILesbian = New System.Windows.Forms.CheckBox()
Me.CBIMaledomSD = New System.Windows.Forms.CheckBox()
Me.CBIBlowjob = New System.Windows.Forms.CheckBox()
Me.CBIGaySD = New System.Windows.Forms.CheckBox()
Me.CBIHentaiSD = New System.Windows.Forms.CheckBox()
Me.CBIBlowjobSD = New System.Windows.Forms.CheckBox()
Me.CBIFemdomSD = New System.Windows.Forms.CheckBox()
Me.TbxIButts = New System.Windows.Forms.TextBox()
Me.CBIFemdom = New System.Windows.Forms.CheckBox()
Me.TbxILesbian = New System.Windows.Forms.TextBox()
Me.BTNISoftcore = New System.Windows.Forms.Button()
Me.CBILezdom = New System.Windows.Forms.CheckBox()
Me.TbxIBoobs = New System.Windows.Forms.TextBox()
Me.CBIHentai = New System.Windows.Forms.CheckBox()
Me.TbxIBlowjob = New System.Windows.Forms.TextBox()
Me.CBIGay = New System.Windows.Forms.CheckBox()
Me.TbxIGeneral = New System.Windows.Forms.TextBox()
Me.CBIMaledom = New System.Windows.Forms.CheckBox()
Me.TbxIFemdom = New System.Windows.Forms.TextBox()
Me.BTNILesbian = New System.Windows.Forms.Button()
Me.TbxICaptions = New System.Windows.Forms.TextBox()
Me.CBICaptions = New System.Windows.Forms.CheckBox()
Me.TbxILezdom = New System.Windows.Forms.TextBox()
Me.TbxIMaledom = New System.Windows.Forms.TextBox()
Me.BTNButtPath = New System.Windows.Forms.Button()
Me.TbxIHentai = New System.Windows.Forms.TextBox()
Me.CBIGeneral = New System.Windows.Forms.CheckBox()
Me.TbxIGay = New System.Windows.Forms.TextBox()
Me.CBIBoobs = New System.Windows.Forms.CheckBox()
Me.CBIButts = New System.Windows.Forms.CheckBox()
Me.BTNIBlowjob = New System.Windows.Forms.Button()
Me.BTNIFemdom = New System.Windows.Forms.Button()
Me.BTNBoobPath = New System.Windows.Forms.Button()
Me.BTNILezdom = New System.Windows.Forms.Button()
Me.BTNIHentai = New System.Windows.Forms.Button()
Me.BTNIGay = New System.Windows.Forms.Button()
Me.BTNIMaledom = New System.Windows.Forms.Button()
Me.BTNICaptions = New System.Windows.Forms.Button()
Me.BTNIGeneral = New System.Windows.Forms.Button()
Me.TabPage33 = New System.Windows.Forms.TabPage()
Me.TabControl5 = New System.Windows.Forms.TabControl()
Me.TabPage34 = New System.Windows.Forms.TabPage()
Me.CBTagSeeThrough = New System.Windows.Forms.RadioButton()
Me.CBTagAllFours = New System.Windows.Forms.CheckBox()
Me.CBTagGlaring = New System.Windows.Forms.CheckBox()
Me.CBTagSmiling = New System.Windows.Forms.CheckBox()
Me.TBTagDir = New System.Windows.Forms.TextBox()
Me.CBTagPiercing = New System.Windows.Forms.CheckBox()
Me.CBTagLegs = New System.Windows.Forms.CheckBox()
Me.TBTagFurniture = New System.Windows.Forms.TextBox()
Me.CBTagFurniture = New System.Windows.Forms.CheckBox()
Me.TBTagSexToy = New System.Windows.Forms.TextBox()
Me.CBTagSexToy = New System.Windows.Forms.CheckBox()
Me.TBTagTattoo = New System.Windows.Forms.TextBox()
Me.CBTagTattoo = New System.Windows.Forms.CheckBox()
Me.TBTagUnderwear = New System.Windows.Forms.TextBox()
Me.CBTagUnderwear = New System.Windows.Forms.CheckBox()
Me.TBTagGarment = New System.Windows.Forms.TextBox()
Me.CBTagGarment = New System.Windows.Forms.CheckBox()
Me.Label72 = New System.Windows.Forms.Label()
Me.CBTagHandsCovering = New System.Windows.Forms.RadioButton()
Me.CBTagGarmentCovering = New System.Windows.Forms.RadioButton()
Me.CBTagCloseUp = New System.Windows.Forms.CheckBox()
Me.CBTagNaked = New System.Windows.Forms.RadioButton()
Me.CBTagSideView = New System.Windows.Forms.CheckBox()
Me.BTNTagPrevious = New System.Windows.Forms.Button()
Me.CBTagHalfDressed = New System.Windows.Forms.RadioButton()
Me.BTNTagNext = New System.Windows.Forms.Button()
Me.CBTagFullyDressed = New System.Windows.Forms.RadioButton()
Me.LBLTagCount = New System.Windows.Forms.Label()
Me.CBTagSucking = New System.Windows.Forms.CheckBox()
Me.CBTagMasturbating = New System.Windows.Forms.CheckBox()
Me.CBTagFeet = New System.Windows.Forms.CheckBox()
Me.CBTagBoobs = New System.Windows.Forms.CheckBox()
Me.CBTagAss = New System.Windows.Forms.CheckBox()
Me.CBTagPussy = New System.Windows.Forms.CheckBox()
Me.BTNTagSave = New System.Windows.Forms.Button()
Me.BTNTagDir = New System.Windows.Forms.Button()
Me.ImageTagPictureBox = New System.Windows.Forms.PictureBox()
Me.CBTagFace = New System.Windows.Forms.CheckBox()
Me.TabPage35 = New System.Windows.Forms.TabPage()
Me.GroupBox55 = New System.Windows.Forms.GroupBox()
Me.CBTagNurse = New System.Windows.Forms.CheckBox()
Me.CBTagSchoolgirl = New System.Windows.Forms.CheckBox()
Me.CBTagMaid = New System.Windows.Forms.CheckBox()
Me.CBTagTeacher = New System.Windows.Forms.CheckBox()
Me.CBTagSuperhero = New System.Windows.Forms.CheckBox()
Me.GroupBox53 = New System.Windows.Forms.GroupBox()
Me.CBTagTrap = New System.Windows.Forms.CheckBox()
Me.CBTagTentacles = New System.Windows.Forms.CheckBox()
Me.CBTagMonsterGirl = New System.Windows.Forms.CheckBox()
Me.CBTagBukkake = New System.Windows.Forms.CheckBox()
Me.CBTagGanguro = New System.Windows.Forms.CheckBox()
Me.CBTagBodyWriting = New System.Windows.Forms.CheckBox()
Me.CBTagMahouShoujo = New System.Windows.Forms.CheckBox()
Me.CBTagBakunyuu = New System.Windows.Forms.CheckBox()
Me.CBTagAhegao = New System.Windows.Forms.CheckBox()
Me.CBTagShibari = New System.Windows.Forms.CheckBox()
Me.GroupBox49 = New System.Windows.Forms.GroupBox()
Me.CBTagBodyMouth = New System.Windows.Forms.CheckBox()
Me.CBTagBodyAss = New System.Windows.Forms.CheckBox()
Me.CBTagBodyFace = New System.Windows.Forms.CheckBox()
Me.CBTagBodyLegs = New System.Windows.Forms.CheckBox()
Me.CBTagBodyBalls = New System.Windows.Forms.CheckBox()
Me.CBTagBodyCock = New System.Windows.Forms.CheckBox()
Me.CBTagBodyFeet = New System.Windows.Forms.CheckBox()
Me.CBTagBodyNipples = New System.Windows.Forms.CheckBox()
Me.CBTagBodyPussy = New System.Windows.Forms.CheckBox()
Me.CBTagBodyTits = New System.Windows.Forms.CheckBox()
Me.CBTagBodyFingers = New System.Windows.Forms.CheckBox()
Me.GroupBox46 = New System.Windows.Forms.GroupBox()
Me.CBTagMultiSub = New System.Windows.Forms.CheckBox()
Me.CBTagMultiDom = New System.Windows.Forms.CheckBox()
Me.CBTagFemdom = New System.Windows.Forms.CheckBox()
Me.CBTag2M = New System.Windows.Forms.CheckBox()
Me.CBTagFutadom = New System.Windows.Forms.CheckBox()
Me.CBTagFemsub = New System.Windows.Forms.CheckBox()
Me.CBTag2Futa = New System.Windows.Forms.CheckBox()
Me.CBTagMaledom = New System.Windows.Forms.CheckBox()
Me.CBTag3M = New System.Windows.Forms.CheckBox()
Me.CBTagFutasub = New System.Windows.Forms.CheckBox()
Me.CBTag3Futa = New System.Windows.Forms.CheckBox()
Me.CBTagMalesub = New System.Windows.Forms.CheckBox()
Me.CBTag2F = New System.Windows.Forms.CheckBox()
Me.CBTag1Futa = New System.Windows.Forms.CheckBox()
Me.CBTag1M = New System.Windows.Forms.CheckBox()
Me.CBTag1F = New System.Windows.Forms.CheckBox()
Me.CBTag3F = New System.Windows.Forms.CheckBox()
Me.GroupBox54 = New System.Windows.Forms.GroupBox()
Me.CBTagTattoos = New System.Windows.Forms.CheckBox()
Me.CBTagAnalToy = New System.Windows.Forms.CheckBox()
Me.CBTagDomme = New System.Windows.Forms.CheckBox()
Me.CBTagPocketPussy = New System.Windows.Forms.CheckBox()
Me.CBTagWatersports = New System.Windows.Forms.CheckBox()
Me.CBTagStockings = New System.Windows.Forms.CheckBox()
Me.CBTagCumshot = New System.Windows.Forms.CheckBox()
Me.CBTagCumEating = New System.Windows.Forms.CheckBox()
Me.CBTagVibrator = New System.Windows.Forms.CheckBox()
Me.CBTagDildo = New System.Windows.Forms.CheckBox()
Me.CBTagKissing = New System.Windows.Forms.CheckBox()
Me.GroupBox51 = New System.Windows.Forms.GroupBox()
Me.CBTagBallTorture = New System.Windows.Forms.CheckBox()
Me.CBTagGag = New System.Windows.Forms.CheckBox()
Me.CBTagBlindfold = New System.Windows.Forms.CheckBox()
Me.CBTagWhipping = New System.Windows.Forms.CheckBox()
Me.CBTagCockTorture = New System.Windows.Forms.CheckBox()
Me.CBTagElectro = New System.Windows.Forms.CheckBox()
Me.CBTagHotWax = New System.Windows.Forms.CheckBox()
Me.CBTagClamps = New System.Windows.Forms.CheckBox()
Me.CBTagStrapon = New System.Windows.Forms.CheckBox()
Me.CBTagSpanking = New System.Windows.Forms.CheckBox()
Me.CBTagNeedles = New System.Windows.Forms.CheckBox()
Me.GroupBox50 = New System.Windows.Forms.GroupBox()
Me.CBTagRimming = New System.Windows.Forms.CheckBox()
Me.CBTagFacesitting = New System.Windows.Forms.CheckBox()
Me.CBTagMissionary = New System.Windows.Forms.CheckBox()
Me.CBTagMasturbation = New System.Windows.Forms.CheckBox()
Me.CBTagRCowgirl = New System.Windows.Forms.CheckBox()
Me.CBTagFingering = New System.Windows.Forms.CheckBox()
Me.CBTagGangbang = New System.Windows.Forms.CheckBox()
Me.CBTagBlowjob = New System.Windows.Forms.CheckBox()
Me.CBTagDP = New System.Windows.Forms.CheckBox()
Me.CBTagHandjob = New System.Windows.Forms.CheckBox()
Me.CBTagStanding = New System.Windows.Forms.CheckBox()
Me.CBTagFootjob = New System.Windows.Forms.CheckBox()
Me.CBTagCowgirl = New System.Windows.Forms.CheckBox()
Me.CBTagDoggyStyle = New System.Windows.Forms.CheckBox()
Me.CBTagTitjob = New System.Windows.Forms.CheckBox()
Me.CBTagCunnilingus = New System.Windows.Forms.CheckBox()
Me.CBTagAnalSex = New System.Windows.Forms.CheckBox()
Me.GroupBox48 = New System.Windows.Forms.GroupBox()
Me.CBTagArtwork = New System.Windows.Forms.CheckBox()
Me.CBTagOutdoors = New System.Windows.Forms.CheckBox()
Me.CBTagPOV = New System.Windows.Forms.CheckBox()
Me.CBTagHardcore = New System.Windows.Forms.CheckBox()
Me.CBTagTD = New System.Windows.Forms.CheckBox()
Me.CBTagGay = New System.Windows.Forms.CheckBox()
Me.CBTagBath = New System.Windows.Forms.CheckBox()
Me.CBTagBisexual = New System.Windows.Forms.CheckBox()
Me.CBTagCFNM = New System.Windows.Forms.CheckBox()
Me.CBTagLesbian = New System.Windows.Forms.CheckBox()
Me.CBTagSoloFuta = New System.Windows.Forms.CheckBox()
Me.CBTagSM = New System.Windows.Forms.CheckBox()
Me.CBTagBondage = New System.Windows.Forms.CheckBox()
Me.CBTagSoloM = New System.Windows.Forms.CheckBox()
Me.CBTagSoloF = New System.Windows.Forms.CheckBox()
Me.CBTagChastity = New System.Windows.Forms.CheckBox()
Me.CBTagShower = New System.Windows.Forms.CheckBox()
Me.TBLocalTagDir = New System.Windows.Forms.TextBox()
Me.BTNLocalTagPrevious = New System.Windows.Forms.Button()
Me.BTNLocalTagNext = New System.Windows.Forms.Button()
Me.LBLLocalTagCount = New System.Windows.Forms.Label()
Me.BTNLocalTagSave = New System.Windows.Forms.Button()
Me.BTNLocalTagDir = New System.Windows.Forms.Button()
Me.TabPage11 = New System.Windows.Forms.TabPage()
Me.Panel7 = New System.Windows.Forms.Panel()
Me.BTNWIContinue = New System.Windows.Forms.Button()
Me.BTNWIAddandContinue = New System.Windows.Forms.Button()
Me.BTNWICancel = New System.Windows.Forms.Button()
Me.CBWIReview = New System.Windows.Forms.CheckBox()
Me.BTNWIBrowse = New System.Windows.Forms.Button()
Me.TBWIDirectory = New System.Windows.Forms.TextBox()
Me.BTNWIDisliked = New System.Windows.Forms.Button()
Me.BTNWILiked = New System.Windows.Forms.Button()
Me.BTNWIRemove = New System.Windows.Forms.Button()
Me.CBWISaveToDisk = New System.Windows.Forms.CheckBox()
Me.PictureBox5 = New System.Windows.Forms.PictureBox()
Me.WebImageProgressBar = New System.Windows.Forms.ProgressBar()
Me.BTNWICreateURL = New System.Windows.Forms.Button()
Me.LBLWebImageCount = New System.Windows.Forms.Label()
Me.BTNWISave = New System.Windows.Forms.Button()
Me.BTNWIOpenURL = New System.Windows.Forms.Button()
Me.BTNWIPrevious = New System.Windows.Forms.Button()
Me.BTNWINext = New System.Windows.Forms.Button()
Me.WebPictureBox = New System.Windows.Forms.PictureBox()
Me.Label71 = New System.Windows.Forms.Label()
Me.TpVideoSettings = New System.Windows.Forms.TabPage()
Me.PnlVideoSettings = New System.Windows.Forms.Panel()
Me.PbBannerVideoSettings = New System.Windows.Forms.PictureBox()
Me.BTNRefreshVideos = New System.Windows.Forms.Button()
Me.GbxVideoGeneralD = New System.Windows.Forms.GroupBox()
Me.LblVideoGeneralTotalD = New System.Windows.Forms.Label()
Me.TxbVideoGeneralD = New System.Windows.Forms.TextBox()
Me.BTNVideoGeneralD = New System.Windows.Forms.Button()
Me.CBVideoGeneralD = New System.Windows.Forms.CheckBox()
Me.GbxVideoSpecialD = New System.Windows.Forms.GroupBox()
Me.LblVideoCHTotalD = New System.Windows.Forms.Label()
Me.LblVideoJOITotalD = New System.Windows.Forms.Label()
Me.TxbVideoCHD = New System.Windows.Forms.TextBox()
Me.TxbVideoJOID = New System.Windows.Forms.TextBox()
Me.BTNVideoCHD = New System.Windows.Forms.Button()
Me.BTNVideoJOID = New System.Windows.Forms.Button()
Me.CBVideoJOID = New System.Windows.Forms.CheckBox()
Me.CBVideoCHD = New System.Windows.Forms.CheckBox()
Me.GbxVideoGenreD = New System.Windows.Forms.GroupBox()
Me.LblVideoFemsubTotalD = New System.Windows.Forms.Label()
Me.TxbVideoFemsubD = New System.Windows.Forms.TextBox()
Me.LblVideoFemdomTotalD = New System.Windows.Forms.Label()
Me.TxbVideoFemdomD = New System.Windows.Forms.TextBox()
Me.TxbVideoBlowjobD = New System.Windows.Forms.TextBox()
Me.LblVideoBlowjobTotalD = New System.Windows.Forms.Label()
Me.TxbVideoLesbianD = New System.Windows.Forms.TextBox()
Me.TxbVideoSoftCoreD = New System.Windows.Forms.TextBox()
Me.LblVideoLesbianTotalD = New System.Windows.Forms.Label()
Me.TxbVideoHardCoreD = New System.Windows.Forms.TextBox()
Me.BTNVideoFemSubD = New System.Windows.Forms.Button()
Me.LblVideoSoftCoreTotalD = New System.Windows.Forms.Label()
Me.BTNVideoFemDomD = New System.Windows.Forms.Button()
Me.BTNVideoBlowjobD = New System.Windows.Forms.Button()
Me.LblVideoHardCoreTotalD = New System.Windows.Forms.Label()
Me.BTNVideoLesbianD = New System.Windows.Forms.Button()
Me.BTNVideoSoftCoreD = New System.Windows.Forms.Button()
Me.BTNVideoHardCoreD = New System.Windows.Forms.Button()
Me.CBVideoHardcoreD = New System.Windows.Forms.CheckBox()
Me.CBVideoSoftCoreD = New System.Windows.Forms.CheckBox()
Me.CBVideoLesbianD = New System.Windows.Forms.CheckBox()
Me.CBVideoBlowjobD = New System.Windows.Forms.CheckBox()
Me.CBVideoFemsubD = New System.Windows.Forms.CheckBox()
Me.CBVideoFemdomD = New System.Windows.Forms.CheckBox()
Me.GbxVideoDescription = New System.Windows.Forms.GroupBox()
Me.VideoDescriptionLabel = New System.Windows.Forms.Label()
Me.GbxVideoGeneral = New System.Windows.Forms.GroupBox()
Me.LblVideoGeneralTotal = New System.Windows.Forms.Label()
Me.TxbVideoGeneral = New System.Windows.Forms.TextBox()
Me.BTNVideoGeneral = New System.Windows.Forms.Button()
Me.CBVideoGeneral = New System.Windows.Forms.CheckBox()
Me.GbxVideoSpecial = New System.Windows.Forms.GroupBox()
Me.LblVideoCHTotal = New System.Windows.Forms.Label()
Me.LblVideoJOITotal = New System.Windows.Forms.Label()
Me.TxbVideoCH = New System.Windows.Forms.TextBox()
Me.TxbVideoJOI = New System.Windows.Forms.TextBox()
Me.BTNVideoCH = New System.Windows.Forms.Button()
Me.BTNVideoJOI = New System.Windows.Forms.Button()
Me.CBVideoJOI = New System.Windows.Forms.CheckBox()
Me.CBVideoCH = New System.Windows.Forms.CheckBox()
Me.GbxVideoGenre = New System.Windows.Forms.GroupBox()
Me.LblVideoFemsubTotal = New System.Windows.Forms.Label()
Me.TxbVideoFemsub = New System.Windows.Forms.TextBox()
Me.LblVideoFemdomTotal = New System.Windows.Forms.Label()
Me.TxbVideoFemdom = New System.Windows.Forms.TextBox()
Me.TxbVideoBlowjob = New System.Windows.Forms.TextBox()
Me.LblVideoBlowjobTotal = New System.Windows.Forms.Label()
Me.TxbVideoLesbian = New System.Windows.Forms.TextBox()
Me.TxbVideoSoftCore = New System.Windows.Forms.TextBox()
Me.LblVideoLesbianTotal = New System.Windows.Forms.Label()
Me.TxbVideoHardCore = New System.Windows.Forms.TextBox()
Me.BTNVideoFemSub = New System.Windows.Forms.Button()
Me.LblVideoSoftCoreTotal = New System.Windows.Forms.Label()
Me.BTNVideoFemDom = New System.Windows.Forms.Button()
Me.BTNVideoBlowjob = New System.Windows.Forms.Button()
Me.LblVideoHardCoreTotal = New System.Windows.Forms.Label()
Me.BTNVideoLesbian = New System.Windows.Forms.Button()
Me.BTNVideoSoftCore = New System.Windows.Forms.Button()
Me.BTNVideoHardCore = New System.Windows.Forms.Button()
Me.CBVideoHardcore = New System.Windows.Forms.CheckBox()
Me.CBVideoSoftCore = New System.Windows.Forms.CheckBox()
Me.CBVideoLesbian = New System.Windows.Forms.CheckBox()
Me.CBVideoBlowjob = New System.Windows.Forms.CheckBox()
Me.CBVideoFemsub = New System.Windows.Forms.CheckBox()
Me.CBVideoFemdom = New System.Windows.Forms.CheckBox()
Me.LblVideoHeader = New System.Windows.Forms.Label()
Me.TabPage20 = New System.Windows.Forms.TabPage()
Me.TabControl1 = New System.Windows.Forms.TabControl()
Me.TabPage22 = New System.Windows.Forms.TabPage()
Me.PNLGlitter = New System.Windows.Forms.Panel()
Me.GroupBox14 = New System.Windows.Forms.GroupBox()
Me.Label170 = New System.Windows.Forms.Label()
Me.alwaysNewSlideshow = New System.Windows.Forms.CheckBox()
Me.RandomHonorific = New System.Windows.Forms.TextBox()
Me.GroupBox4 = New System.Windows.Forms.GroupBox()
Me.LBLCurrentDomme = New System.Windows.Forms.Label()
Me.BTNDomChangeContact1 = New System.Windows.Forms.Button()
Me.BTNDomChangeRandom = New System.Windows.Forms.Button()
Me.BTNDomChangeContact3 = New System.Windows.Forms.Button()
Me.BTNDomChangeContact2 = New System.Windows.Forms.Button()
Me.BTNDomChangeDomme = New System.Windows.Forms.Button()
Me.Button15 = New System.Windows.Forms.Button()
Me.Button16 = New System.Windows.Forms.Button()
Me.Label121 = New System.Windows.Forms.Label()
Me.Label122 = New System.Windows.Forms.Label()
Me.GBGlitterD = New System.Windows.Forms.GroupBox()
Me.GrbGlitterfeed = New System.Windows.Forms.GroupBox()
Me.CBGlitterFeedScripts = New System.Windows.Forms.RadioButton()
Me.CBGlitterFeed = New System.Windows.Forms.RadioButton()
Me.CBGlitterFeedOff = New System.Windows.Forms.RadioButton()
Me.BTNGlitterD = New System.Windows.Forms.Button()
Me.LBLGlitterNCDomme = New System.Windows.Forms.Label()
Me.LBLGlitterSlider = New System.Windows.Forms.Label()
Me.CBCustom2 = New System.Windows.Forms.CheckBox()
Me.GlitterSlider = New System.Windows.Forms.TrackBar()
Me.CBCustom1 = New System.Windows.Forms.CheckBox()
Me.CBDaily = New System.Windows.Forms.CheckBox()
Me.CBTrivia = New System.Windows.Forms.CheckBox()
Me.TBGlitterShortName = New System.Windows.Forms.TextBox()
Me.CBEgotist = New System.Windows.Forms.CheckBox()
Me.CBTease = New System.Windows.Forms.CheckBox()
Me.GlitterAV = New System.Windows.Forms.PictureBox()
Me.GBGlitter1 = New System.Windows.Forms.GroupBox()
Me.Label167 = New System.Windows.Forms.Label()
Me.G1Honorific = New System.Windows.Forms.TextBox()
Me.BtnContact1ImageDirClear = New System.Windows.Forms.Button()
Me.BtnContact1ImageDir = New System.Windows.Forms.Button()
Me.TbxContact1ImageDir = New System.Windows.Forms.TextBox()
Me.BTNGlitter1 = New System.Windows.Forms.Button()
Me.LBLGlitterNC1 = New System.Windows.Forms.Label()
Me.LBLGlitterSlider1 = New System.Windows.Forms.Label()
Me.GlitterSlider1 = New System.Windows.Forms.TrackBar()
Me.CBGlitter1 = New System.Windows.Forms.CheckBox()
Me.TBGlitter1 = New System.Windows.Forms.TextBox()
Me.GlitterAV1 = New System.Windows.Forms.PictureBox()
Me.GBGlitter3 = New System.Windows.Forms.GroupBox()
Me.Label168 = New System.Windows.Forms.Label()
Me.G3Honorific = New System.Windows.Forms.TextBox()
Me.BtnContact3ImageDirClear = New System.Windows.Forms.Button()
Me.BtnContact3ImageDir = New System.Windows.Forms.Button()
Me.TbxContact3ImageDir = New System.Windows.Forms.TextBox()
Me.BTNGlitter3 = New System.Windows.Forms.Button()
Me.LBLGlitterNC3 = New System.Windows.Forms.Label()
Me.LBLGlitterSlider3 = New System.Windows.Forms.Label()
Me.GlitterSlider3 = New System.Windows.Forms.TrackBar()
Me.CBGlitter3 = New System.Windows.Forms.CheckBox()
Me.TBGlitter3 = New System.Windows.Forms.TextBox()
Me.GlitterAV3 = New System.Windows.Forms.PictureBox()
Me.GBGlitter2 = New System.Windows.Forms.GroupBox()
Me.Label169 = New System.Windows.Forms.Label()
Me.G2Honorific = New System.Windows.Forms.TextBox()
Me.BtnContact2ImageDirClear = New System.Windows.Forms.Button()
Me.BtnContact2ImageDir = New System.Windows.Forms.Button()
Me.TbxContact2ImageDir = New System.Windows.Forms.TextBox()
Me.BTNGlitter2 = New System.Windows.Forms.Button()
Me.LBLGlitterNC2 = New System.Windows.Forms.Label()
Me.LBLGlitterSlider2 = New System.Windows.Forms.Label()
Me.GlitterSlider2 = New System.Windows.Forms.TrackBar()
Me.CBGlitter2 = New System.Windows.Forms.CheckBox()
Me.TBGlitter2 = New System.Windows.Forms.TextBox()
Me.GlitterAV2 = New System.Windows.Forms.PictureBox()
Me.TpGames = New System.Windows.Forms.TabPage()
Me.CBIncludeGifs = New System.Windows.Forms.CheckBox()
Me.LblCardsSetupNote = New System.Windows.Forms.Label()
Me.CBGameSounds = New System.Windows.Forms.CheckBox()
Me.GbxCardsGold = New System.Windows.Forms.GroupBox()
Me.GN6 = New System.Windows.Forms.TextBox()
Me.GP6 = New System.Windows.Forms.PictureBox()
Me.GN2 = New System.Windows.Forms.TextBox()
Me.GP2 = New System.Windows.Forms.PictureBox()
Me.GP5 = New System.Windows.Forms.PictureBox()
Me.GN1 = New System.Windows.Forms.TextBox()
Me.GP1 = New System.Windows.Forms.PictureBox()
Me.GN5 = New System.Windows.Forms.TextBox()
Me.GN3 = New System.Windows.Forms.TextBox()
Me.GP3 = New System.Windows.Forms.PictureBox()
Me.GP4 = New System.Windows.Forms.PictureBox()
Me.GN4 = New System.Windows.Forms.TextBox()
Me.GbxCardsBackground = New System.Windows.Forms.GroupBox()
Me.CardBack = New System.Windows.Forms.PictureBox()
Me.GbxCardsBronze = New System.Windows.Forms.GroupBox()
Me.BN6 = New System.Windows.Forms.TextBox()
Me.BN3 = New System.Windows.Forms.TextBox()
Me.BP3 = New System.Windows.Forms.PictureBox()
Me.BP6 = New System.Windows.Forms.PictureBox()
Me.BN2 = New System.Windows.Forms.TextBox()
Me.BN5 = New System.Windows.Forms.TextBox()
Me.BP5 = New System.Windows.Forms.PictureBox()
Me.BP2 = New System.Windows.Forms.PictureBox()
Me.BN1 = New System.Windows.Forms.TextBox()
Me.BN4 = New System.Windows.Forms.TextBox()
Me.BP4 = New System.Windows.Forms.PictureBox()
Me.BP1 = New System.Windows.Forms.PictureBox()
Me.GbxCardsSilver = New System.Windows.Forms.GroupBox()
Me.SN6 = New System.Windows.Forms.TextBox()
Me.SP6 = New System.Windows.Forms.PictureBox()
Me.SN2 = New System.Windows.Forms.TextBox()
Me.SP2 = New System.Windows.Forms.PictureBox()
Me.SN1 = New System.Windows.Forms.TextBox()
Me.SP5 = New System.Windows.Forms.PictureBox()
Me.SP1 = New System.Windows.Forms.PictureBox()
Me.SN5 = New System.Windows.Forms.TextBox()
Me.SN3 = New System.Windows.Forms.TextBox()
Me.SN4 = New System.Windows.Forms.TextBox()
Me.SP3 = New System.Windows.Forms.PictureBox()
Me.SP4 = New System.Windows.Forms.PictureBox()
Me.TabPage6 = New System.Windows.Forms.TabPage()
Me.Panel10 = New System.Windows.Forms.Panel()
Me.TBWishlistComment = New System.Windows.Forms.TextBox()
Me.Label32 = New System.Windows.Forms.Label()
Me.TBWishlistItem = New System.Windows.Forms.TextBox()
Me.radioGold = New System.Windows.Forms.RadioButton()
Me.Label42 = New System.Windows.Forms.Label()
Me.radioSilver = New System.Windows.Forms.RadioButton()
Me.TBWishlistURL = New System.Windows.Forms.TextBox()
Me.NBWishlistCost = New System.Windows.Forms.NumericUpDown()
Me.Label48 = New System.Windows.Forms.Label()
Me.Label73 = New System.Windows.Forms.Label()
Me.Label107 = New System.Windows.Forms.Label()
Me.BTNWishlistCreate = New System.Windows.Forms.Button()
Me.Label18 = New System.Windows.Forms.Label()
Me.PNLWishList = New System.Windows.Forms.Panel()
Me.WishlistCostSilver = New System.Windows.Forms.PictureBox()
Me.LBLWishListText = New System.Windows.Forms.Label()
Me.LBLWishlistCost = New System.Windows.Forms.Label()
Me.WishlistCostGold = New System.Windows.Forms.PictureBox()
Me.LBLWishListName = New System.Windows.Forms.Label()
Me.WishlistPreview = New System.Windows.Forms.PictureBox()
Me.TabPage26 = New System.Windows.Forms.TabPage()
Me.Panel12 = New System.Windows.Forms.Panel()
Me.GroupBox9 = New System.Windows.Forms.GroupBox()
Me.Button32 = New System.Windows.Forms.Button()
Me.Button31 = New System.Windows.Forms.Button()
Me.PictureBox10 = New System.Windows.Forms.PictureBox()
Me.GroupBox5 = New System.Windows.Forms.GroupBox()
Me.CBTransparentTime = New System.Windows.Forms.CheckBox()
Me.LBLDateTimeColor2 = New System.Windows.Forms.Label()
Me.Label137 = New System.Windows.Forms.Label()
Me.Label138 = New System.Windows.Forms.Label()
Me.LBLDateBackColor2 = New System.Windows.Forms.Label()
Me.LBLTextColor = New System.Windows.Forms.Label()
Me.LBLChatWindowColor2 = New System.Windows.Forms.Label()
Me.LBLTextColor2 = New System.Windows.Forms.Label()
Me.LBLChatTextColor = New System.Windows.Forms.Label()
Me.LBLBackColor2 = New System.Windows.Forms.Label()
Me.LBLButtonColor = New System.Windows.Forms.Label()
Me.LBLChatWindowColor = New System.Windows.Forms.Label()
Me.LBLBackColor = New System.Windows.Forms.Label()
Me.LBLChatTextColor2 = New System.Windows.Forms.Label()
Me.LBLButtonColor2 = New System.Windows.Forms.Label()
Me.GroupBox11 = New System.Windows.Forms.GroupBox()
Me.Label144 = New System.Windows.Forms.Label()
Me.GroupBox1 = New System.Windows.Forms.GroupBox()
Me.CBFlipBack = New System.Windows.Forms.CheckBox()
Me.PBBackgroundPreview = New System.Windows.Forms.PictureBox()
Me.Button17 = New System.Windows.Forms.Button()
Me.CBStretchBack = New System.Windows.Forms.CheckBox()
Me.Button18 = New System.Windows.Forms.Button()
Me.Label164 = New System.Windows.Forms.Label()
Me.TabPage4 = New System.Windows.Forms.TabPage()
Me.Panel6 = New System.Windows.Forms.Panel()
Me.GroupBox69 = New System.Windows.Forms.GroupBox()
Me.TypesSpeedVal = New System.Windows.Forms.Label()
Me.TypeSpeedLabel = New System.Windows.Forms.Label()
Me.TimedWriting = New System.Windows.Forms.CheckBox()
Me.TypeSpeedSlider = New System.Windows.Forms.TrackBar()
Me.GroupBox68 = New System.Windows.Forms.GroupBox()
Me.NBTasksMax = New System.Windows.Forms.NumericUpDown()
Me.NBTasksMin = New System.Windows.Forms.NumericUpDown()
Me.Label165 = New System.Windows.Forms.Label()
Me.Label166 = New System.Windows.Forms.Label()
Me.GroupBox67 = New System.Windows.Forms.GroupBox()
Me.Label161 = New System.Windows.Forms.Label()
Me.NBTaskCBTTimeMax = New System.Windows.Forms.NumericUpDown()
Me.NBTaskCBTTimeMin = New System.Windows.Forms.NumericUpDown()
Me.Label162 = New System.Windows.Forms.Label()
Me.Label163 = New System.Windows.Forms.Label()
Me.Label158 = New System.Windows.Forms.Label()
Me.NBTaskEdgeHoldTimeMax = New System.Windows.Forms.NumericUpDown()
Me.NBTaskEdgeHoldTimeMin = New System.Windows.Forms.NumericUpDown()
Me.Label159 = New System.Windows.Forms.Label()
Me.Label160 = New System.Windows.Forms.Label()
Me.NBTaskEdgesMax = New System.Windows.Forms.NumericUpDown()
Me.NBTaskEdgesMin = New System.Windows.Forms.NumericUpDown()
Me.Label119 = New System.Windows.Forms.Label()
Me.Label157 = New System.Windows.Forms.Label()
Me.Label151 = New System.Windows.Forms.Label()
Me.NBTaskStrokingTimeMax = New System.Windows.Forms.NumericUpDown()
Me.NBTaskStrokingTimeMin = New System.Windows.Forms.NumericUpDown()
Me.Label154 = New System.Windows.Forms.Label()
Me.Label155 = New System.Windows.Forms.Label()
Me.NBTaskStrokesMax = New System.Windows.Forms.NumericUpDown()
Me.NBTaskStrokesMin = New System.Windows.Forms.NumericUpDown()
Me.Label146 = New System.Windows.Forms.Label()
Me.Label149 = New System.Windows.Forms.Label()
Me.GroupBox10 = New System.Windows.Forms.GroupBox()
Me.Label112 = New System.Windows.Forms.Label()
Me.NBNextImageChance = New System.Windows.Forms.NumericUpDown()
Me.Label6 = New System.Windows.Forms.Label()
Me.GroupBox57 = New System.Windows.Forms.GroupBox()
Me.Label139 = New System.Windows.Forms.Label()
Me.NBTauntEdging = New System.Windows.Forms.NumericUpDown()
Me.LBLVtf = New System.Windows.Forms.Label()
Me.LBLStf = New System.Windows.Forms.Label()
Me.SliderSTF = New System.Windows.Forms.TrackBar()
Me.TauntSlider = New System.Windows.Forms.TrackBar()
Me.Label106 = New System.Windows.Forms.Label()
Me.CBTauntCycleDD = New System.Windows.Forms.CheckBox()
Me.CBTeaseLengthDD = New System.Windows.Forms.CheckBox()
Me.Label103 = New System.Windows.Forms.Label()
Me.NBTauntCycleMax = New System.Windows.Forms.NumericUpDown()
Me.Label105 = New System.Windows.Forms.Label()
Me.Label101 = New System.Windows.Forms.Label()
Me.NBTauntCycleMin = New System.Windows.Forms.NumericUpDown()
Me.Label102 = New System.Windows.Forms.Label()
Me.Label97 = New System.Windows.Forms.Label()
Me.NBTeaseLengthMax = New System.Windows.Forms.NumericUpDown()
Me.Label99 = New System.Windows.Forms.Label()
Me.Label96 = New System.Windows.Forms.Label()
Me.NBTeaseLengthMin = New System.Windows.Forms.NumericUpDown()
Me.Label95 = New System.Windows.Forms.Label()
Me.Label49 = New System.Windows.Forms.Label()
Me.Label141 = New System.Windows.Forms.Label()
Me.GBRangeRuinChance = New System.Windows.Forms.GroupBox()
Me.Label90 = New System.Windows.Forms.Label()
Me.NBRuinSometimes = New System.Windows.Forms.NumericUpDown()
Me.Label91 = New System.Windows.Forms.Label()
Me.Label92 = New System.Windows.Forms.Label()
Me.NBRuinRarely = New System.Windows.Forms.NumericUpDown()
Me.NBRuinOften = New System.Windows.Forms.NumericUpDown()
Me.CBRangeRuin = New System.Windows.Forms.CheckBox()
Me.GroupBox17 = New System.Windows.Forms.GroupBox()
Me.GroupBox19 = New System.Windows.Forms.GroupBox()
Me.Label110 = New System.Windows.Forms.Label()
Me.Label111 = New System.Windows.Forms.Label()
Me.NBGreenLightMax = New System.Windows.Forms.NumericUpDown()
Me.NBGreenLightMin = New System.Windows.Forms.NumericUpDown()
Me.NBRedLightMax = New System.Windows.Forms.NumericUpDown()
Me.Label26 = New System.Windows.Forms.Label()
Me.NBRedLightMin = New System.Windows.Forms.NumericUpDown()
Me.Label28 = New System.Windows.Forms.Label()
Me.Label27 = New System.Windows.Forms.Label()
Me.Label29 = New System.Windows.Forms.Label()
Me.GroupBox18 = New System.Windows.Forms.GroupBox()
Me.Label108 = New System.Windows.Forms.Label()
Me.Label109 = New System.Windows.Forms.Label()
Me.NBCensorShowMin = New System.Windows.Forms.NumericUpDown()
Me.NBCensorHideMax = New System.Windows.Forms.NumericUpDown()
Me.NBCensorHideMin = New System.Windows.Forms.NumericUpDown()
Me.CBCensorConstant = New System.Windows.Forms.CheckBox()
Me.Label25 = New System.Windows.Forms.Label()
Me.Label20 = New System.Windows.Forms.Label()
Me.Label19 = New System.Windows.Forms.Label()
Me.Label24 = New System.Windows.Forms.Label()
Me.NBCensorShowMax = New System.Windows.Forms.NumericUpDown()
Me.GBRangeOrgasmChance = New System.Windows.Forms.GroupBox()
Me.Label89 = New System.Windows.Forms.Label()
Me.NBAllowSometimes = New System.Windows.Forms.NumericUpDown()
Me.Label86 = New System.Windows.Forms.Label()
Me.Label82 = New System.Windows.Forms.Label()
Me.NBAllowRarely = New System.Windows.Forms.NumericUpDown()
Me.NBAllowOften = New System.Windows.Forms.NumericUpDown()
Me.CBRangeOrgasm = New System.Windows.Forms.CheckBox()
Me.PictureBox8 = New System.Windows.Forms.PictureBox()
Me.Label38 = New System.Windows.Forms.Label()
Me.TabPage13 = New System.Windows.Forms.TabPage()
Me.TabControl2 = New System.Windows.Forms.TabControl()
Me.TabPage27 = New System.Windows.Forms.TabPage()
Me.TBPlaylistSave = New System.Windows.Forms.TextBox()
Me.BTNPlaylistCtrlZ = New System.Windows.Forms.Button()
Me.RadioPlaylistRegScripts = New System.Windows.Forms.RadioButton()
Me.RadioPlaylistScripts = New System.Windows.Forms.RadioButton()
Me.BTNPlaylistEnd = New System.Windows.Forms.Button()
Me.BTNPlaylistClearAll = New System.Windows.Forms.Button()
Me.BTNPlaylistSave = New System.Windows.Forms.Button()
Me.Button7 = New System.Windows.Forms.Button()
Me.WBPlaylist = New System.Windows.Forms.WebBrowser()
Me.Label80 = New System.Windows.Forms.Label()
Me.LBLPlaylIstLink = New System.Windows.Forms.Label()
Me.LBLPlaylistModule = New System.Windows.Forms.Label()
Me.LBLPLaylistStart = New System.Windows.Forms.Label()
Me.LBPlaylist = New System.Windows.Forms.ListBox()
Me.TabPage14 = New System.Windows.Forms.TabPage()
Me.LBLKeywordPreview = New System.Windows.Forms.Label()
Me.Label88 = New System.Windows.Forms.Label()
Me.TBKeywordPreview = New System.Windows.Forms.TextBox()
Me.Button37 = New System.Windows.Forms.Button()
Me.Button50 = New System.Windows.Forms.Button()
Me.Button22 = New System.Windows.Forms.Button()
Me.TBKeyWords = New System.Windows.Forms.TextBox()
Me.LBKeyWords = New System.Windows.Forms.ListBox()
Me.RTBKeyWords = New System.Windows.Forms.RichTextBox()
Me.TabPage24 = New System.Windows.Forms.TabPage()
Me.Button9 = New System.Windows.Forms.Button()
Me.RTBResponsesKEY = New System.Windows.Forms.RichTextBox()
Me.Button4 = New System.Windows.Forms.Button()
Me.Button5 = New System.Windows.Forms.Button()
Me.TBResponses = New System.Windows.Forms.TextBox()
Me.LBResponses = New System.Windows.Forms.ListBox()
Me.RTBResponses = New System.Windows.Forms.RichTextBox()
Me.TabPage8 = New System.Windows.Forms.TabPage()
Me.RTBVideoMod = New System.Windows.Forms.RichTextBox()
Me.GroupBox29 = New System.Windows.Forms.GroupBox()
Me.Label51 = New System.Windows.Forms.Label()
Me.BTNVideoModClear = New System.Windows.Forms.Button()
Me.GroupBox28 = New System.Windows.Forms.GroupBox()
Me.CBVTType = New System.Windows.Forms.ComboBox()
Me.BTNVideoModLoad = New System.Windows.Forms.Button()
Me.GroupBox30 = New System.Windows.Forms.GroupBox()
Me.LBVidScript = New System.Windows.Forms.ListBox()
Me.BTNVideoModSave = New System.Windows.Forms.Button()
Me.TabPage15 = New System.Windows.Forms.TabPage()
Me.Label62 = New System.Windows.Forms.Label()
Me.Label61 = New System.Windows.Forms.Label()
Me.Label57 = New System.Windows.Forms.Label()
Me.Label58 = New System.Windows.Forms.Label()
Me.Label60 = New System.Windows.Forms.Label()
Me.TBGlitModFileName = New System.Windows.Forms.TextBox()
Me.GroupBox34 = New System.Windows.Forms.GroupBox()
Me.Label52 = New System.Windows.Forms.Label()
Me.RTBGlitModDommePost = New System.Windows.Forms.RichTextBox()
Me.Button26 = New System.Windows.Forms.Button()
Me.Label56 = New System.Windows.Forms.Label()
Me.RTBGlitModResponses = New System.Windows.Forms.RichTextBox()
Me.LBGlitModScripts = New System.Windows.Forms.ListBox()
Me.LBLGlitModScriptCount = New System.Windows.Forms.Label()
Me.LBLGlitModDomType = New System.Windows.Forms.Label()
Me.Button29 = New System.Windows.Forms.Button()
Me.CBGlitModType = New System.Windows.Forms.ComboBox()
Me.Label59 = New System.Windows.Forms.Label()
Me.Label50 = New System.Windows.Forms.Label()
Me.TabPage25 = New System.Windows.Forms.TabPage()
Me.Panel11 = New System.Windows.Forms.Panel()
Me.GroupBox62 = New System.Windows.Forms.GroupBox()
Me.RBGerman = New System.Windows.Forms.RadioButton()
Me.RBEnglish = New System.Windows.Forms.RadioButton()
Me.GroupBox33 = New System.Windows.Forms.GroupBox()
Me.BTNOfflineMode = New System.Windows.Forms.Button()
Me.LBLOfflineMode = New System.Windows.Forms.Label()
Me.Label140 = New System.Windows.Forms.Label()
Me.Button11 = New System.Windows.Forms.Button()
Me.LBLChastityState = New System.Windows.Forms.Label()
Me.Label120 = New System.Windows.Forms.Label()
Me.GroupBox8 = New System.Windows.Forms.GroupBox()
Me.CBOutputErrors = New System.Windows.Forms.CheckBox()
Me.GroupBox27 = New System.Windows.Forms.GroupBox()
Me.Button6 = New System.Windows.Forms.Button()
Me.LBLSesSpace = New System.Windows.Forms.Label()
Me.Button3 = New System.Windows.Forms.Button()
Me.LBLSesFiles = New System.Windows.Forms.Label()
Me.Label125 = New System.Windows.Forms.Label()
Me.Label124 = New System.Windows.Forms.Label()
Me.GroupBox20 = New System.Windows.Forms.GroupBox()
Me.BTNURLFileReplace = New System.Windows.Forms.Button()
Me.Label87 = New System.Windows.Forms.Label()
Me.TBURLFileWith = New System.Windows.Forms.TextBox()
Me.Label118 = New System.Windows.Forms.Label()
Me.Label85 = New System.Windows.Forms.Label()
Me.TBURLFileReplace = New System.Windows.Forms.TextBox()
Me.Label53 = New System.Windows.Forms.Label()
Me.Label8 = New System.Windows.Forms.Label()
Me.Button1 = New System.Windows.Forms.Button()
Me.BTNMaintenanceScripts = New System.Windows.Forms.Button()
Me.BTNMaintenanceRefresh = New System.Windows.Forms.Button()
Me.Label117 = New System.Windows.Forms.Label()
Me.Label116 = New System.Windows.Forms.Label()
Me.PBCurrent = New System.Windows.Forms.ProgressBar()
Me.BTNMaintenanceCancel = New System.Windows.Forms.Button()
Me.PBMaintenance = New System.Windows.Forms.ProgressBar()
Me.LBLMaintenance = New System.Windows.Forms.Label()
Me.BTNMaintenanceRebuild = New System.Windows.Forms.Button()
Me.GroupBox15 = New System.Windows.Forms.GroupBox()
Me.Label115 = New System.Windows.Forms.Label()
Me.TBWebStop = New System.Windows.Forms.TextBox()
Me.TBWebStart = New System.Windows.Forms.TextBox()
Me.Label114 = New System.Windows.Forms.Label()
Me.WebToy = New System.Windows.Forms.WebBrowser()
Me.PictureBox9 = New System.Windows.Forms.PictureBox()
Me.Label148 = New System.Windows.Forms.Label()
Me.TabPage28 = New System.Windows.Forms.TabPage()
Me.TabControl3 = New System.Windows.Forms.TabControl()
Me.TabPage29 = New System.Windows.Forms.TabPage()
Me.Label143 = New System.Windows.Forms.Label()
Me.LBLDebugScriptTime = New System.Windows.Forms.Label()
Me.BTNDebugHoldEdgeTimer = New System.Windows.Forms.Button()
Me.GroupBox26 = New System.Windows.Forms.GroupBox()
Me.LBLCycleDebugCountdown = New System.Windows.Forms.Label()
Me.Button19 = New System.Windows.Forms.Button()
Me.BTNDebugTauntsClear = New System.Windows.Forms.Button()
Me.TBDebugTaunts3 = New System.Windows.Forms.TextBox()
Me.TBDebugTaunts2 = New System.Windows.Forms.TextBox()
Me.TBDebugTaunts1 = New System.Windows.Forms.TextBox()
Me.RBDebugTaunts3 = New System.Windows.Forms.RadioButton()
Me.RBDebugTaunts2 = New System.Windows.Forms.RadioButton()
Me.RBDebugTaunts1 = New System.Windows.Forms.RadioButton()
Me.CBDebugTauntsEndless = New System.Windows.Forms.CheckBox()
Me.CBDebugTaunts = New System.Windows.Forms.CheckBox()
Me.BTNDebugStrokeTauntTimer = New System.Windows.Forms.Button()
Me.LBLDebugHoldEdgeTime = New System.Windows.Forms.Label()
Me.Label145 = New System.Windows.Forms.Label()
Me.BTNDebugStrokeTime = New System.Windows.Forms.Button()
Me.BTNDebugEdgeTauntTimer = New System.Windows.Forms.Button()
Me.LBLDebugTeaseTime = New System.Windows.Forms.Label()
Me.LBLDebugStrokeTime = New System.Windows.Forms.Label()
Me.LBLDebugEdgeTauntTime = New System.Windows.Forms.Label()
Me.BTNDebugTeaseTimer = New System.Windows.Forms.Button()
Me.Label142 = New System.Windows.Forms.Label()
Me.Label150 = New System.Windows.Forms.Label()
Me.Label152 = New System.Windows.Forms.Label()
Me.LBLDebugStrokeTauntTime = New System.Windows.Forms.Label()
Me.Label147 = New System.Windows.Forms.Label()
Me.TabPage30 = New System.Windows.Forms.TabPage()
Me.Button33 = New System.Windows.Forms.Button()
Me.Button24 = New System.Windows.Forms.Button()
Me.TabPage5 = New System.Windows.Forms.TabPage()
Me.Panel5 = New System.Windows.Forms.Panel()
Me.Label130 = New System.Windows.Forms.Label()
Me.Label123 = New System.Windows.Forms.Label()
Me.Label69 = New System.Windows.Forms.Label()
Me.Label113 = New System.Windows.Forms.Label()
Me.Label40 = New System.Windows.Forms.Label()
Me.Label35 = New System.Windows.Forms.Label()
Me.Label33 = New System.Windows.Forms.Label()
Me.Label17 = New System.Windows.Forms.Label()
Me.Label3 = New System.Windows.Forms.Label()
Me.PictureBox3 = New System.Windows.Forms.PictureBox()
Me.Label41 = New System.Windows.Forms.Label()
Me.BtnRandomImageDirClear = New System.Windows.Forms.Button()
Me.GroupBox47 = New System.Windows.Forms.GroupBox()
Me.GroupBox41 = New System.Windows.Forms.GroupBox()
Me.Button34 = New System.Windows.Forms.Button()
Me.GroupBox40 = New System.Windows.Forms.GroupBox()
Me.GroupBox44 = New System.Windows.Forms.GroupBox()
Me.Label100 = New System.Windows.Forms.Label()
Me.GroupBox6 = New System.Windows.Forms.GroupBox()
Me.Label4 = New System.Windows.Forms.Label()
Me.LBLAvgEdgeStroking = New System.Windows.Forms.Label()
Me.LBLStrokeTimeTotal = New System.Windows.Forms.Label()
Me.Label94 = New System.Windows.Forms.Label()
Me.LBLLastRuined = New System.Windows.Forms.Label()
Me.Label65 = New System.Windows.Forms.Label()
Me.LBLAvgEdgeNoTouch = New System.Windows.Forms.Label()
Me.LBLLastOrgasm = New System.Windows.Forms.Label()
Me.Label14 = New System.Windows.Forms.Label()
Me.GroupBox21 = New System.Windows.Forms.GroupBox()
Me.Label153 = New System.Windows.Forms.Label()
Me.LBLRangeSettingsDescription = New System.Windows.Forms.Label()
Me.Label156 = New System.Windows.Forms.Label()
Me.GroupBox12 = New System.Windows.Forms.GroupBox()
Me.LBLSubSettingsDescription = New System.Windows.Forms.Label()
Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
Me.GetColor = New System.Windows.Forms.ColorDialog()
Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
Me.WebImageFileDialog = New System.Windows.Forms.OpenFileDialog()
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
Me.OpenScriptDialog = New System.Windows.Forms.OpenFileDialog()
Me.OpenSettingsDialog = New System.Windows.Forms.OpenFileDialog()
Me.SaveSettingsDialog = New System.Windows.Forms.SaveFileDialog()
Me.TTDir = New System.Windows.Forms.ToolTip(Me.components)
Me.GroupBox65 = New System.Windows.Forms.GroupBox()
Me.Label136 = New System.Windows.Forms.Label()
Me.Label134 = New System.Windows.Forms.Label()
Me.Label132 = New System.Windows.Forms.Label()
Me.TrackBar1 = New System.Windows.Forms.TrackBar()
Me.ComboBox1 = New System.Windows.Forms.ComboBox()
Me.CheckBox1 = New System.Windows.Forms.CheckBox()
Me.Label135 = New System.Windows.Forms.Label()
Me.TrackBar2 = New System.Windows.Forms.TrackBar()
Me.TxbImgUrlHardcore = New System.Windows.Forms.TextBox()
Me.TextBox2 = New System.Windows.Forms.TextBox()
Me.Label171 = New System.Windows.Forms.Label()
Me.BWURLFiles = New Tease_AI.URL_Files.URL_File_BGW()
Me.SettingsPanel.SuspendLayout
Me.SettingsTabs.SuspendLayout
Me.TabPage1.SuspendLayout
Me.PNLGeneralSettings.SuspendLayout
Me.GroupBox3.SuspendLayout
Me.GroupBox2.SuspendLayout
Me.GroupBox64.SuspendLayout
Me.GBDommeImages.SuspendLayout
CType(Me.slideshowNumBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBGeneralTextToSpeech.SuspendLayout
CType(Me.SliderVRate,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SliderVVolume,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBSafeword.SuspendLayout
Me.GBGeneralSystem.SuspendLayout
Me.GBGeneralImages.SuspendLayout
CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBGeneralSettings.SuspendLayout
Me.GBSubFont.SuspendLayout
CType(Me.NBFontSize,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBDommeFont.SuspendLayout
CType(Me.NBFontSizeD,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage2.SuspendLayout
Me.Panel3.SuspendLayout
Me.GBGiveUp.SuspendLayout
CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBDomTypingStyle.SuspendLayout
CType(Me.NBTypoChance,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox63.SuspendLayout
Me.GBDomRanges.SuspendLayout
CType(Me.NBDomMoodMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBDomMoodMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBSubAgeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBSubAgeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBSelfAgeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBSelfAgeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBAvgCockMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBAvgCockMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBDomStats.SuspendLayout
CType(Me.NBEmpathy,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBDomBirthdayDay,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.domageNumBox,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBDomBirthdayMonth,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.domlevelNumBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBDomPersonality.SuspendLayout
Me.GBDomOrgasms.SuspendLayout
CType(Me.orgasmsPerNumBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBDomPetNames.SuspendLayout
Me.TabPage10.SuspendLayout
Me.Panel2.SuspendLayout
Me.GroupBox22.SuspendLayout
CType(Me.NBWritingTaskMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBWritingTaskMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox45.SuspendLayout
CType(Me.CBTSlider,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox35.SuspendLayout
Me.GroupBoxSorry.SuspendLayout
Me.GroupBox39.SuspendLayout
Me.GroupBox38.SuspendLayout
Me.GroupBox37.SuspendLayout
Me.GroupBox36.SuspendLayout
Me.GroupBox13.SuspendLayout
Me.GroupBox7.SuspendLayout
CType(Me.NBExtremeHoldMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBExtremeHoldMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBLongHoldMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBLongHoldMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBLongEdge,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBHoldTheEdgeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBHoldTheEdgeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.PictureBox12,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox32.SuspendLayout
CType(Me.NBBirthdayDay,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.subAgeNumBox,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBBirthdayMonth,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.CockSizeNumBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage16.SuspendLayout
Me.Panel9.SuspendLayout
Me.GroupBox31.SuspendLayout
Me.TCScripts.SuspendLayout
Me.TabPage21.SuspendLayout
Me.TabPage17.SuspendLayout
Me.TabPage18.SuspendLayout
Me.TabPage19.SuspendLayout
Me.GroupBox42.SuspendLayout
CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox43.SuspendLayout
Me.TabPage7.SuspendLayout
Me.TabControl4.SuspendLayout
Me.TpImagesUrlFiles.SuspendLayout
Me.GroupBox66.SuspendLayout
CType(Me.PBURLPreview,System.ComponentModel.ISupportInitialize).BeginInit
Me.TpImagesGenre.SuspendLayout
Me.GrbImageUrlFiles.SuspendLayout
Me.TlpImageUrls.SuspendLayout
Me.GbxImagesGenre.SuspendLayout
Me.TableLayoutPanel1.SuspendLayout
Me.TabPage33.SuspendLayout
Me.TabControl5.SuspendLayout
Me.TabPage34.SuspendLayout
CType(Me.ImageTagPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage35.SuspendLayout
Me.GroupBox55.SuspendLayout
Me.GroupBox53.SuspendLayout
Me.GroupBox49.SuspendLayout
Me.GroupBox46.SuspendLayout
Me.GroupBox54.SuspendLayout
Me.GroupBox51.SuspendLayout
Me.GroupBox50.SuspendLayout
Me.GroupBox48.SuspendLayout
Me.TabPage11.SuspendLayout
Me.Panel7.SuspendLayout
CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.WebPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
Me.TpVideoSettings.SuspendLayout
Me.PnlVideoSettings.SuspendLayout
CType(Me.PbBannerVideoSettings,System.ComponentModel.ISupportInitialize).BeginInit
Me.GbxVideoGeneralD.SuspendLayout
Me.GbxVideoSpecialD.SuspendLayout
Me.GbxVideoGenreD.SuspendLayout
Me.GbxVideoDescription.SuspendLayout
Me.GbxVideoGeneral.SuspendLayout
Me.GbxVideoSpecial.SuspendLayout
Me.GbxVideoGenre.SuspendLayout
Me.TabPage20.SuspendLayout
Me.TabControl1.SuspendLayout
Me.TabPage22.SuspendLayout
Me.PNLGlitter.SuspendLayout
Me.GroupBox14.SuspendLayout
Me.GroupBox4.SuspendLayout
Me.GBGlitterD.SuspendLayout
Me.GrbGlitterfeed.SuspendLayout
CType(Me.GlitterSlider,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GlitterAV,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBGlitter1.SuspendLayout
CType(Me.GlitterSlider1,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GlitterAV1,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBGlitter3.SuspendLayout
CType(Me.GlitterSlider3,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GlitterAV3,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBGlitter2.SuspendLayout
CType(Me.GlitterSlider2,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GlitterAV2,System.ComponentModel.ISupportInitialize).BeginInit
Me.TpGames.SuspendLayout
Me.GbxCardsGold.SuspendLayout
CType(Me.GP6,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GP2,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GP5,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GP1,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GP3,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.GP4,System.ComponentModel.ISupportInitialize).BeginInit
Me.GbxCardsBackground.SuspendLayout
CType(Me.CardBack,System.ComponentModel.ISupportInitialize).BeginInit
Me.GbxCardsBronze.SuspendLayout
CType(Me.BP3,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.BP6,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.BP5,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.BP2,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.BP4,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.BP1,System.ComponentModel.ISupportInitialize).BeginInit
Me.GbxCardsSilver.SuspendLayout
CType(Me.SP6,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SP2,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SP5,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SP1,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SP3,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SP4,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage6.SuspendLayout
Me.Panel10.SuspendLayout
CType(Me.NBWishlistCost,System.ComponentModel.ISupportInitialize).BeginInit
Me.PNLWishList.SuspendLayout
CType(Me.WishlistCostSilver,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.WishlistCostGold,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.WishlistPreview,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage26.SuspendLayout
Me.Panel12.SuspendLayout
Me.GroupBox9.SuspendLayout
CType(Me.PictureBox10,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox5.SuspendLayout
Me.GroupBox11.SuspendLayout
Me.GroupBox1.SuspendLayout
CType(Me.PBBackgroundPreview,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage4.SuspendLayout
Me.Panel6.SuspendLayout
Me.GroupBox69.SuspendLayout
CType(Me.TypeSpeedSlider,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox68.SuspendLayout
CType(Me.NBTasksMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTasksMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox67.SuspendLayout
CType(Me.NBTaskCBTTimeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskCBTTimeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskEdgeHoldTimeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskEdgeHoldTimeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskEdgesMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskEdgesMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskStrokingTimeMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskStrokingTimeMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskStrokesMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTaskStrokesMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox10.SuspendLayout
CType(Me.NBNextImageChance,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox57.SuspendLayout
CType(Me.NBTauntEdging,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.SliderSTF,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.TauntSlider,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTauntCycleMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTauntCycleMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTeaseLengthMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBTeaseLengthMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBRangeRuinChance.SuspendLayout
CType(Me.NBRuinSometimes,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBRuinRarely,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBRuinOften,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox17.SuspendLayout
Me.GroupBox19.SuspendLayout
CType(Me.NBGreenLightMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBGreenLightMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBRedLightMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBRedLightMin,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox18.SuspendLayout
CType(Me.NBCensorShowMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBCensorHideMax,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBCensorHideMin,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBCensorShowMax,System.ComponentModel.ISupportInitialize).BeginInit
Me.GBRangeOrgasmChance.SuspendLayout
CType(Me.NBAllowSometimes,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBAllowRarely,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.NBAllowOften,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.PictureBox8,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage13.SuspendLayout
Me.TabControl2.SuspendLayout
Me.TabPage27.SuspendLayout
Me.TabPage14.SuspendLayout
Me.TabPage24.SuspendLayout
Me.TabPage8.SuspendLayout
Me.GroupBox29.SuspendLayout
Me.GroupBox28.SuspendLayout
Me.GroupBox30.SuspendLayout
Me.TabPage15.SuspendLayout
Me.GroupBox34.SuspendLayout
Me.TabPage25.SuspendLayout
Me.Panel11.SuspendLayout
Me.GroupBox62.SuspendLayout
Me.GroupBox33.SuspendLayout
Me.GroupBox8.SuspendLayout
Me.GroupBox27.SuspendLayout
Me.GroupBox20.SuspendLayout
Me.GroupBox15.SuspendLayout
CType(Me.PictureBox9,System.ComponentModel.ISupportInitialize).BeginInit
Me.TabPage28.SuspendLayout
Me.TabControl3.SuspendLayout
Me.TabPage29.SuspendLayout
Me.GroupBox26.SuspendLayout
Me.TabPage30.SuspendLayout
Me.TabPage5.SuspendLayout
Me.Panel5.SuspendLayout
CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox47.SuspendLayout
Me.GroupBox41.SuspendLayout
Me.GroupBox44.SuspendLayout
Me.GroupBox6.SuspendLayout
Me.GroupBox21.SuspendLayout
Me.GroupBox12.SuspendLayout
Me.GroupBox65.SuspendLayout
CType(Me.TrackBar1,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.TrackBar2,System.ComponentModel.ISupportInitialize).BeginInit
Me.SuspendLayout
'
'SettingsPanel
'
Me.SettingsPanel.BackColor = System.Drawing.Color.LightGray
Me.SettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SettingsPanel.Controls.Add(Me.SettingsTabs)
Me.SettingsPanel.Location = New System.Drawing.Point(-8, -19)
Me.SettingsPanel.Name = "SettingsPanel"
Me.SettingsPanel.Size = New System.Drawing.Size(735, 484)
Me.SettingsPanel.TabIndex = 94
'
'SettingsTabs
'
Me.SettingsTabs.Controls.Add(Me.TabPage1)
Me.SettingsTabs.Controls.Add(Me.TabPage2)
Me.SettingsTabs.Controls.Add(Me.TabPage10)
Me.SettingsTabs.Controls.Add(Me.TabPage16)
Me.SettingsTabs.Controls.Add(Me.TabPage7)
Me.SettingsTabs.Controls.Add(Me.TabPage33)
Me.SettingsTabs.Controls.Add(Me.TabPage11)
Me.SettingsTabs.Controls.Add(Me.TpVideoSettings)
Me.SettingsTabs.Controls.Add(Me.TabPage20)
Me.SettingsTabs.Controls.Add(Me.TabPage26)
Me.SettingsTabs.Controls.Add(Me.TabPage4)
Me.SettingsTabs.Controls.Add(Me.TabPage13)
Me.SettingsTabs.Controls.Add(Me.TabPage25)
Me.SettingsTabs.Controls.Add(Me.TabPage28)
Me.SettingsTabs.Controls.Add(Me.TabPage5)
Me.SettingsTabs.Location = New System.Drawing.Point(3, 15)
Me.SettingsTabs.Name = "SettingsTabs"
Me.SettingsTabs.SelectedIndex = 0
Me.SettingsTabs.Size = New System.Drawing.Size(728, 474)
Me.SettingsTabs.TabIndex = 0
'
'TabPage1
'
Me.TabPage1.BackColor = System.Drawing.Color.Silver
Me.TabPage1.Controls.Add(Me.PNLGeneralSettings)
Me.TabPage1.Location = New System.Drawing.Point(4, 22)
Me.TabPage1.Name = "TabPage1"
Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage1.Size = New System.Drawing.Size(720, 448)
Me.TabPage1.TabIndex = 0
Me.TabPage1.Text = "General"
'
'PNLGeneralSettings
'
Me.PNLGeneralSettings.BackColor = System.Drawing.Color.LightGray
Me.PNLGeneralSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.PNLGeneralSettings.Controls.Add(Me.GroupBox3)
Me.PNLGeneralSettings.Controls.Add(Me.GroupBox2)
Me.PNLGeneralSettings.Controls.Add(Me.BtnImportSettings)
Me.PNLGeneralSettings.Controls.Add(Me.LblImportSettings)
Me.PNLGeneralSettings.Controls.Add(Me.GroupBox64)
Me.PNLGeneralSettings.Controls.Add(Me.GBDommeImages)
Me.PNLGeneralSettings.Controls.Add(Me.GBGeneralTextToSpeech)
Me.PNLGeneralSettings.Controls.Add(Me.GBSafeword)
Me.PNLGeneralSettings.Controls.Add(Me.GBGeneralSystem)
Me.PNLGeneralSettings.Controls.Add(Me.GBGeneralImages)
Me.PNLGeneralSettings.Controls.Add(Me.PictureBox2)
Me.PNLGeneralSettings.Controls.Add(Me.GBGeneralSettings)
Me.PNLGeneralSettings.Controls.Add(Me.LBLGeneralSettings)
Me.PNLGeneralSettings.Location = New System.Drawing.Point(6, 6)
Me.PNLGeneralSettings.Name = "PNLGeneralSettings"
Me.PNLGeneralSettings.Size = New System.Drawing.Size(708, 437)
Me.PNLGeneralSettings.TabIndex = 0
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.BTNValidateSystemFiles)
Me.GroupBox3.Location = New System.Drawing.Point(7, 365)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(211, 65)
Me.GroupBox3.TabIndex = 184
Me.GroupBox3.TabStop = false
Me.GroupBox3.Text = "System Files"
'
'BTNValidateSystemFiles
'
Me.BTNValidateSystemFiles.BackColor = System.Drawing.Color.LightGray
Me.BTNValidateSystemFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNValidateSystemFiles.ForeColor = System.Drawing.Color.Black
Me.BTNValidateSystemFiles.Location = New System.Drawing.Point(10, 26)
Me.BTNValidateSystemFiles.Name = "BTNValidateSystemFiles"
Me.BTNValidateSystemFiles.Size = New System.Drawing.Size(190, 22)
Me.BTNValidateSystemFiles.TabIndex = 183
Me.BTNValidateSystemFiles.Text = "Validate All System Files"
Me.BTNValidateSystemFiles.UseVisualStyleBackColor = false
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.TbxRandomImageDir)
Me.GroupBox2.Controls.Add(Me.CBRandomDomme)
Me.GroupBox2.Controls.Add(Me.BtnRandomImageDir)
Me.GroupBox2.Location = New System.Drawing.Point(224, 313)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(210, 117)
Me.GroupBox2.TabIndex = 183
Me.GroupBox2.TabStop = false
Me.GroupBox2.Text = "Random Domme"
'
'TbxRandomImageDir
'
Me.TbxRandomImageDir.BackColor = System.Drawing.Color.LightGray
Me.TbxRandomImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxRandomImageDir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "RandomImageDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxRandomImageDir.Location = New System.Drawing.Point(10, 50)
Me.TbxRandomImageDir.Name = "TbxRandomImageDir"
Me.TbxRandomImageDir.ReadOnly = true
Me.TbxRandomImageDir.Size = New System.Drawing.Size(190, 20)
Me.TbxRandomImageDir.TabIndex = 185
Me.TbxRandomImageDir.Text = "No Path Selected"
'
'CBRandomDomme
'
Me.CBRandomDomme.AutoSize = true
Me.CBRandomDomme.Location = New System.Drawing.Point(10, 83)
Me.CBRandomDomme.Name = "CBRandomDomme"
Me.CBRandomDomme.Size = New System.Drawing.Size(191, 17)
Me.CBRandomDomme.TabIndex = 184
Me.CBRandomDomme.Text = "Always Start With Random Domme"
Me.CBRandomDomme.UseVisualStyleBackColor = true
'
'BtnRandomImageDir
'
Me.BtnRandomImageDir.BackColor = System.Drawing.Color.LightGray
Me.BtnRandomImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnRandomImageDir.ForeColor = System.Drawing.Color.Black
Me.BtnRandomImageDir.Location = New System.Drawing.Point(10, 21)
Me.BtnRandomImageDir.Name = "BtnRandomImageDir"
Me.BtnRandomImageDir.Size = New System.Drawing.Size(190, 22)
Me.BtnRandomImageDir.TabIndex = 182
Me.BtnRandomImageDir.Text = "Set Random Domme Directory"
Me.BtnRandomImageDir.UseVisualStyleBackColor = false
'
'BtnImportSettings
'
Me.BtnImportSettings.BackColor = System.Drawing.Color.Transparent
Me.BtnImportSettings.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Export
Me.BtnImportSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.BtnImportSettings.FlatAppearance.BorderSize = 0
Me.BtnImportSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BtnImportSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.BtnImportSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BtnImportSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnImportSettings.ForeColor = System.Drawing.Color.Black
Me.BtnImportSettings.Location = New System.Drawing.Point(669, 14)
Me.BtnImportSettings.Name = "BtnImportSettings"
Me.BtnImportSettings.Size = New System.Drawing.Size(30, 26)
Me.BtnImportSettings.TabIndex = 158
Me.BtnImportSettings.UseVisualStyleBackColor = false
'
'LblImportSettings
'
Me.LblImportSettings.AutoSize = true
Me.LblImportSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblImportSettings.ForeColor = System.Drawing.Color.Black
Me.LblImportSettings.Location = New System.Drawing.Point(664, 0)
Me.LblImportSettings.Name = "LblImportSettings"
Me.LblImportSettings.Size = New System.Drawing.Size(35, 13)
Me.LblImportSettings.TabIndex = 159
Me.LblImportSettings.Text = "import"
Me.LblImportSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox64
'
Me.GroupBox64.BackColor = System.Drawing.Color.LightGray
Me.GroupBox64.Controls.Add(Me.CBMuteMedia)
Me.GroupBox64.ForeColor = System.Drawing.Color.Black
Me.GroupBox64.Location = New System.Drawing.Point(440, 258)
Me.GroupBox64.Name = "GroupBox64"
Me.GroupBox64.Size = New System.Drawing.Size(259, 49)
Me.GroupBox64.TabIndex = 157
Me.GroupBox64.TabStop = false
Me.GroupBox64.Text = "Media Options"
'
'CBMuteMedia
'
Me.CBMuteMedia.AutoSize = true
Me.CBMuteMedia.Checked = Global.Tease_AI.My.MySettings.Default.MuteMedia
Me.CBMuteMedia.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "MuteMedia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBMuteMedia.ForeColor = System.Drawing.Color.Black
Me.CBMuteMedia.Location = New System.Drawing.Point(7, 21)
Me.CBMuteMedia.Name = "CBMuteMedia"
Me.CBMuteMedia.Size = New System.Drawing.Size(241, 17)
Me.CBMuteMedia.TabIndex = 6
Me.CBMuteMedia.TabStop = false
Me.CBMuteMedia.Text = "Mute Video and Audio Played in Media Player"
Me.CBMuteMedia.UseVisualStyleBackColor = true
'
'GBDommeImages
'
Me.GBDommeImages.BackColor = System.Drawing.Color.LightGray
Me.GBDommeImages.Controls.Add(Me.slideshowNumBox)
Me.GBDommeImages.Controls.Add(Me.teaseRadio)
Me.GBDommeImages.Controls.Add(Me.CBNewSlideshow)
Me.GBDommeImages.Controls.Add(Me.offRadio)
Me.GBDommeImages.Controls.Add(Me.BTNDomImageDir)
Me.GBDommeImages.Controls.Add(Me.timedRadio)
Me.GBDommeImages.Controls.Add(Me.TbxDomImageDir)
Me.GBDommeImages.ForeColor = System.Drawing.Color.Black
Me.GBDommeImages.Location = New System.Drawing.Point(224, 179)
Me.GBDommeImages.Name = "GBDommeImages"
Me.GBDommeImages.Size = New System.Drawing.Size(210, 128)
Me.GBDommeImages.TabIndex = 156
Me.GBDommeImages.TabStop = false
Me.GBDommeImages.Text = "Slideshow Options"
'
'slideshowNumBox
'
Me.slideshowNumBox.BackColor = System.Drawing.Color.White
Me.slideshowNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.slideshowNumBox.ForeColor = System.Drawing.Color.Black
Me.slideshowNumBox.Location = New System.Drawing.Point(93, 20)
Me.slideshowNumBox.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
Me.slideshowNumBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.slideshowNumBox.Name = "slideshowNumBox"
Me.slideshowNumBox.Size = New System.Drawing.Size(47, 20)
Me.slideshowNumBox.TabIndex = 20
Me.slideshowNumBox.Value = New Decimal(New Integer() {30, 0, 0, 0})
'
'teaseRadio
'
Me.teaseRadio.AutoSize = true
Me.teaseRadio.Checked = true
Me.teaseRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.teaseRadio.ForeColor = System.Drawing.Color.Black
Me.teaseRadio.Location = New System.Drawing.Point(149, 21)
Me.teaseRadio.Name = "teaseRadio"
Me.teaseRadio.Size = New System.Drawing.Size(55, 17)
Me.teaseRadio.TabIndex = 21
Me.teaseRadio.TabStop = true
Me.teaseRadio.Text = "Tease"
Me.teaseRadio.UseVisualStyleBackColor = true
'
'CBNewSlideshow
'
Me.CBNewSlideshow.AutoSize = true
Me.CBNewSlideshow.Checked = true
Me.CBNewSlideshow.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBNewSlideshow.ForeColor = System.Drawing.Color.Black
Me.CBNewSlideshow.Location = New System.Drawing.Point(4, 100)
Me.CBNewSlideshow.Name = "CBNewSlideshow"
Me.CBNewSlideshow.Size = New System.Drawing.Size(200, 17)
Me.CBNewSlideshow.TabIndex = 18
Me.CBNewSlideshow.TabStop = false
Me.CBNewSlideshow.Text = "Load New Slideshow When Finished"
Me.CBNewSlideshow.UseVisualStyleBackColor = true
'
'offRadio
'
Me.offRadio.AutoSize = true
Me.offRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.offRadio.ForeColor = System.Drawing.Color.Black
Me.offRadio.Location = New System.Drawing.Point(6, 21)
Me.offRadio.Name = "offRadio"
Me.offRadio.Size = New System.Drawing.Size(60, 17)
Me.offRadio.TabIndex = 18
Me.offRadio.Text = "Manual"
Me.offRadio.UseVisualStyleBackColor = true
'
'BTNDomImageDir
'
Me.BTNDomImageDir.BackColor = System.Drawing.Color.LightGray
Me.BTNDomImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomImageDir.ForeColor = System.Drawing.Color.Black
Me.BTNDomImageDir.Location = New System.Drawing.Point(10, 45)
Me.BTNDomImageDir.Name = "BTNDomImageDir"
Me.BTNDomImageDir.Size = New System.Drawing.Size(190, 22)
Me.BTNDomImageDir.TabIndex = 17
Me.BTNDomImageDir.Text = "Set Domme Images Directory"
Me.BTNDomImageDir.UseVisualStyleBackColor = false
'
'timedRadio
'
Me.timedRadio.AutoSize = true
Me.timedRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.timedRadio.ForeColor = System.Drawing.Color.Black
Me.timedRadio.Location = New System.Drawing.Point(72, 23)
Me.timedRadio.Name = "timedRadio"
Me.timedRadio.Size = New System.Drawing.Size(14, 13)
Me.timedRadio.TabIndex = 19
Me.timedRadio.UseVisualStyleBackColor = true
'
'TbxDomImageDir
'
Me.TbxDomImageDir.BackColor = System.Drawing.Color.LightGray
Me.TbxDomImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxDomImageDir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "DomImageDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxDomImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxDomImageDir.ForeColor = System.Drawing.Color.Black
Me.TbxDomImageDir.Location = New System.Drawing.Point(10, 73)
Me.TbxDomImageDir.Name = "TbxDomImageDir"
Me.TbxDomImageDir.ReadOnly = true
Me.TbxDomImageDir.Size = New System.Drawing.Size(190, 20)
Me.TbxDomImageDir.TabIndex = 0
Me.TbxDomImageDir.Text = Global.Tease_AI.My.MySettings.Default.DomImageDir
'
'GBGeneralTextToSpeech
'
Me.GBGeneralTextToSpeech.BackColor = System.Drawing.Color.LightGray
Me.GBGeneralTextToSpeech.Controls.Add(Me.LBLVRate)
Me.GBGeneralTextToSpeech.Controls.Add(Me.Label93)
Me.GBGeneralTextToSpeech.Controls.Add(Me.LBLVVolume)
Me.GBGeneralTextToSpeech.Controls.Add(Me.Label68)
Me.GBGeneralTextToSpeech.Controls.Add(Me.SliderVRate)
Me.GBGeneralTextToSpeech.Controls.Add(Me.SliderVVolume)
Me.GBGeneralTextToSpeech.Controls.Add(Me.TTSCheckBox)
Me.GBGeneralTextToSpeech.Controls.Add(Me.TTSComboBox)
Me.GBGeneralTextToSpeech.ForeColor = System.Drawing.Color.Black
Me.GBGeneralTextToSpeech.Location = New System.Drawing.Point(440, 313)
Me.GBGeneralTextToSpeech.Name = "GBGeneralTextToSpeech"
Me.GBGeneralTextToSpeech.Size = New System.Drawing.Size(259, 117)
Me.GBGeneralTextToSpeech.TabIndex = 0
Me.GBGeneralTextToSpeech.TabStop = false
Me.GBGeneralTextToSpeech.Text = "Text to Speech"
'
'LBLVRate
'
Me.LBLVRate.Location = New System.Drawing.Point(202, 52)
Me.LBLVRate.Name = "LBLVRate"
Me.LBLVRate.Size = New System.Drawing.Size(45, 13)
Me.LBLVRate.TabIndex = 158
Me.LBLVRate.Text = "100"
Me.LBLVRate.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Label93
'
Me.Label93.AutoSize = true
Me.Label93.Location = New System.Drawing.Point(141, 52)
Me.Label93.Name = "Label93"
Me.Label93.Size = New System.Drawing.Size(33, 13)
Me.Label93.TabIndex = 157
Me.Label93.Text = "Rate:"
'
'LBLVVolume
'
Me.LBLVVolume.Location = New System.Drawing.Point(75, 52)
Me.LBLVVolume.Name = "LBLVVolume"
Me.LBLVVolume.Size = New System.Drawing.Size(45, 13)
Me.LBLVVolume.TabIndex = 33
Me.LBLVVolume.Text = "100"
Me.LBLVVolume.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Label68
'
Me.Label68.AutoSize = true
Me.Label68.Location = New System.Drawing.Point(14, 52)
Me.Label68.Name = "Label68"
Me.Label68.Size = New System.Drawing.Size(45, 13)
Me.Label68.TabIndex = 32
Me.Label68.Text = "Volume:"
'
'SliderVRate
'
Me.SliderVRate.Location = New System.Drawing.Point(133, 68)
Me.SliderVRate.Minimum = -10
Me.SliderVRate.Name = "SliderVRate"
Me.SliderVRate.Size = New System.Drawing.Size(120, 45)
Me.SliderVRate.TabIndex = 31
'
'SliderVVolume
'
Me.SliderVVolume.Location = New System.Drawing.Point(6, 68)
Me.SliderVVolume.Maximum = 100
Me.SliderVVolume.Name = "SliderVVolume"
Me.SliderVVolume.Size = New System.Drawing.Size(120, 45)
Me.SliderVVolume.TabIndex = 30
Me.SliderVVolume.Value = 50
'
'TTSCheckBox
'
Me.TTSCheckBox.AutoSize = true
Me.TTSCheckBox.ForeColor = System.Drawing.Color.Black
Me.TTSCheckBox.Location = New System.Drawing.Point(10, 21)
Me.TTSCheckBox.Name = "TTSCheckBox"
Me.TTSCheckBox.Size = New System.Drawing.Size(59, 17)
Me.TTSCheckBox.TabIndex = 28
Me.TTSCheckBox.TabStop = false
Me.TTSCheckBox.Text = "Enable"
Me.TTSCheckBox.UseVisualStyleBackColor = true
'
'TTSComboBox
'
Me.TTSComboBox.BackColor = System.Drawing.SystemColors.Window
Me.TTSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.TTSComboBox.ForeColor = System.Drawing.SystemColors.WindowText
Me.TTSComboBox.FormattingEnabled = true
Me.TTSComboBox.Location = New System.Drawing.Point(71, 19)
Me.TTSComboBox.Name = "TTSComboBox"
Me.TTSComboBox.Size = New System.Drawing.Size(178, 21)
Me.TTSComboBox.TabIndex = 29
Me.TTSComboBox.TabStop = false
'
'GBSafeword
'
Me.GBSafeword.BackColor = System.Drawing.Color.LightGray
Me.GBSafeword.Controls.Add(Me.LBLSafeword)
Me.GBSafeword.Controls.Add(Me.TBSafeword)
Me.GBSafeword.ForeColor = System.Drawing.Color.Black
Me.GBSafeword.Location = New System.Drawing.Point(440, 179)
Me.GBSafeword.Name = "GBSafeword"
Me.GBSafeword.Size = New System.Drawing.Size(259, 74)
Me.GBSafeword.TabIndex = 0
Me.GBSafeword.TabStop = false
Me.GBSafeword.Text = "Safeword"
'
'LBLSafeword
'
Me.LBLSafeword.Location = New System.Drawing.Point(17, 42)
Me.LBLSafeword.Name = "LBLSafeword"
Me.LBLSafeword.Size = New System.Drawing.Size(225, 29)
Me.LBLSafeword.TabIndex = 0
Me.LBLSafeword.Text = "Enter a safeword that will stop all activity until the domme is sure you're able "& _ 
    "to continue."
Me.LBLSafeword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TBSafeword
'
Me.TBSafeword.Location = New System.Drawing.Point(17, 19)
Me.TBSafeword.Name = "TBSafeword"
Me.TBSafeword.Size = New System.Drawing.Size(225, 20)
Me.TBSafeword.TabIndex = 27
Me.TBSafeword.Text = "red"
Me.TBSafeword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GBGeneralSystem
'
Me.GBGeneralSystem.Controls.Add(Me.CBAuditStartup)
Me.GBGeneralSystem.Controls.Add(Me.CBDomDel)
Me.GBGeneralSystem.Controls.Add(Me.CBSettingsPause)
Me.GBGeneralSystem.Controls.Add(Me.CBSaveChatlogExit)
Me.GBGeneralSystem.Controls.Add(Me.CBAutosaveChatlog)
Me.GBGeneralSystem.Location = New System.Drawing.Point(440, 33)
Me.GBGeneralSystem.Name = "GBGeneralSystem"
Me.GBGeneralSystem.Size = New System.Drawing.Size(259, 140)
Me.GBGeneralSystem.TabIndex = 0
Me.GBGeneralSystem.TabStop = false
Me.GBGeneralSystem.Text = "System"
'
'CBAuditStartup
'
Me.CBAuditStartup.AutoSize = true
Me.CBAuditStartup.ForeColor = System.Drawing.Color.Black
Me.CBAuditStartup.Location = New System.Drawing.Point(7, 19)
Me.CBAuditStartup.Name = "CBAuditStartup"
Me.CBAuditStartup.Size = New System.Drawing.Size(137, 17)
Me.CBAuditStartup.TabIndex = 26
Me.CBAuditStartup.TabStop = false
Me.CBAuditStartup.Text = "Audit Scripts on Startup"
Me.CBAuditStartup.UseVisualStyleBackColor = true
'
'CBDomDel
'
Me.CBDomDel.AutoSize = true
Me.CBDomDel.ForeColor = System.Drawing.Color.Black
Me.CBDomDel.Location = New System.Drawing.Point(7, 110)
Me.CBDomDel.Name = "CBDomDel"
Me.CBDomDel.Size = New System.Drawing.Size(197, 17)
Me.CBDomDel.TabIndex = 27
Me.CBDomDel.TabStop = false
Me.CBDomDel.Text = "Allow Domme to Delete Local Media"
Me.CBDomDel.UseVisualStyleBackColor = true
'
'CBSettingsPause
'
Me.CBSettingsPause.AutoSize = true
Me.CBSettingsPause.ForeColor = System.Drawing.Color.Black
Me.CBSettingsPause.Location = New System.Drawing.Point(7, 41)
Me.CBSettingsPause.Name = "CBSettingsPause"
Me.CBSettingsPause.Size = New System.Drawing.Size(244, 17)
Me.CBSettingsPause.TabIndex = 22
Me.CBSettingsPause.TabStop = false
Me.CBSettingsPause.Text = "Pause Program When Settings Menu is Visible"
Me.CBSettingsPause.UseVisualStyleBackColor = true
'
'CBSaveChatlogExit
'
Me.CBSaveChatlogExit.AutoSize = true
Me.CBSaveChatlogExit.Checked = true
Me.CBSaveChatlogExit.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBSaveChatlogExit.ForeColor = System.Drawing.Color.Black
Me.CBSaveChatlogExit.Location = New System.Drawing.Point(7, 87)
Me.CBSaveChatlogExit.Name = "CBSaveChatlogExit"
Me.CBSaveChatlogExit.Size = New System.Drawing.Size(162, 17)
Me.CBSaveChatlogExit.TabIndex = 25
Me.CBSaveChatlogExit.TabStop = false
Me.CBSaveChatlogExit.Text = "Save Unique Chatlog on Exit"
Me.CBSaveChatlogExit.UseVisualStyleBackColor = true
'
'CBAutosaveChatlog
'
Me.CBAutosaveChatlog.AutoSize = true
Me.CBAutosaveChatlog.Checked = true
Me.CBAutosaveChatlog.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBAutosaveChatlog.ForeColor = System.Drawing.Color.Black
Me.CBAutosaveChatlog.Location = New System.Drawing.Point(7, 64)
Me.CBAutosaveChatlog.Name = "CBAutosaveChatlog"
Me.CBAutosaveChatlog.Size = New System.Drawing.Size(110, 17)
Me.CBAutosaveChatlog.TabIndex = 24
Me.CBAutosaveChatlog.TabStop = false
Me.CBAutosaveChatlog.Text = "Autosave Chatlog"
Me.CBAutosaveChatlog.UseVisualStyleBackColor = true
'
'GBGeneralImages
'
Me.GBGeneralImages.Controls.Add(Me.CBImageInfo)
Me.GBGeneralImages.Controls.Add(Me.CBSlideshowRandom)
Me.GBGeneralImages.Controls.Add(Me.landscapeCheckBox)
Me.GBGeneralImages.Controls.Add(Me.CBBlogImageWindow)
Me.GBGeneralImages.Controls.Add(Me.CBSlideshowSubDir)
Me.GBGeneralImages.Location = New System.Drawing.Point(224, 33)
Me.GBGeneralImages.Name = "GBGeneralImages"
Me.GBGeneralImages.Size = New System.Drawing.Size(210, 140)
Me.GBGeneralImages.TabIndex = 0
Me.GBGeneralImages.TabStop = false
Me.GBGeneralImages.Text = "Images"
'
'CBImageInfo
'
Me.CBImageInfo.AutoSize = true
Me.CBImageInfo.ForeColor = System.Drawing.Color.Black
Me.CBImageInfo.Location = New System.Drawing.Point(6, 110)
Me.CBImageInfo.Name = "CBImageInfo"
Me.CBImageInfo.Size = New System.Drawing.Size(147, 17)
Me.CBImageInfo.TabIndex = 16
Me.CBImageInfo.TabStop = false
Me.CBImageInfo.Text = "Display Image Information"
Me.CBImageInfo.UseVisualStyleBackColor = true
'
'CBSlideshowRandom
'
Me.CBSlideshowRandom.AutoSize = true
Me.CBSlideshowRandom.ForeColor = System.Drawing.Color.Black
Me.CBSlideshowRandom.Location = New System.Drawing.Point(6, 64)
Me.CBSlideshowRandom.Name = "CBSlideshowRandom"
Me.CBSlideshowRandom.Size = New System.Drawing.Size(202, 17)
Me.CBSlideshowRandom.TabIndex = 14
Me.CBSlideshowRandom.TabStop = false
Me.CBSlideshowRandom.Text = "Display Slideshow Pictures Randomly"
Me.CBSlideshowRandom.UseVisualStyleBackColor = true
'
'landscapeCheckBox
'
Me.landscapeCheckBox.AutoSize = true
Me.landscapeCheckBox.ForeColor = System.Drawing.Color.Black
Me.landscapeCheckBox.Location = New System.Drawing.Point(6, 87)
Me.landscapeCheckBox.Name = "landscapeCheckBox"
Me.landscapeCheckBox.Size = New System.Drawing.Size(153, 17)
Me.landscapeCheckBox.TabIndex = 15
Me.landscapeCheckBox.TabStop = false
Me.landscapeCheckBox.Text = "Stretch Landscape Images"
Me.landscapeCheckBox.UseVisualStyleBackColor = true
'
'CBBlogImageWindow
'
Me.CBBlogImageWindow.AutoSize = true
Me.CBBlogImageWindow.Checked = true
Me.CBBlogImageWindow.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBBlogImageWindow.ForeColor = System.Drawing.Color.Black
Me.CBBlogImageWindow.Location = New System.Drawing.Point(6, 18)
Me.CBBlogImageWindow.Name = "CBBlogImageWindow"
Me.CBBlogImageWindow.Size = New System.Drawing.Size(178, 17)
Me.CBBlogImageWindow.TabIndex = 12
Me.CBBlogImageWindow.TabStop = false
Me.CBBlogImageWindow.Text = "Save Blog Images From Session"
Me.CBBlogImageWindow.UseVisualStyleBackColor = true
'
'CBSlideshowSubDir
'
Me.CBSlideshowSubDir.AutoSize = true
Me.CBSlideshowSubDir.Checked = true
Me.CBSlideshowSubDir.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBSlideshowSubDir.ForeColor = System.Drawing.Color.Black
Me.CBSlideshowSubDir.Location = New System.Drawing.Point(6, 41)
Me.CBSlideshowSubDir.Name = "CBSlideshowSubDir"
Me.CBSlideshowSubDir.Size = New System.Drawing.Size(187, 17)
Me.CBSlideshowSubDir.TabIndex = 13
Me.CBSlideshowSubDir.TabStop = false
Me.CBSlideshowSubDir.Text = "Slideshow Includes Subdirectories"
Me.CBSlideshowSubDir.UseVisualStyleBackColor = true
'
'PictureBox2
'
Me.PictureBox2.BackColor = System.Drawing.Color.LightGray
Me.PictureBox2.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox2.Location = New System.Drawing.Point(9, 6)
Me.PictureBox2.Name = "PictureBox2"
Me.PictureBox2.Size = New System.Drawing.Size(160, 19)
Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox2.TabIndex = 148
Me.PictureBox2.TabStop = false
'
'GBGeneralSettings
'
Me.GBGeneralSettings.BackColor = System.Drawing.Color.LightGray
Me.GBGeneralSettings.Controls.Add(Me.CBWebtease)
Me.GBGeneralSettings.Controls.Add(Me.GBSubFont)
Me.GBGeneralSettings.Controls.Add(Me.GBDommeFont)
Me.GBGeneralSettings.Controls.Add(Me.CBInputIcon)
Me.GBGeneralSettings.Controls.Add(Me.typeinstantlyCheckBox)
Me.GBGeneralSettings.Controls.Add(Me.timestampCheckBox)
Me.GBGeneralSettings.Controls.Add(Me.shownamesCheckBox)
Me.GBGeneralSettings.ForeColor = System.Drawing.Color.Black
Me.GBGeneralSettings.Location = New System.Drawing.Point(7, 33)
Me.GBGeneralSettings.Name = "GBGeneralSettings"
Me.GBGeneralSettings.Size = New System.Drawing.Size(211, 326)
Me.GBGeneralSettings.TabIndex = 0
Me.GBGeneralSettings.TabStop = false
Me.GBGeneralSettings.Text = "Chat Window"
'
'CBWebtease
'
Me.CBWebtease.AutoSize = true
Me.CBWebtease.ForeColor = System.Drawing.Color.Black
Me.CBWebtease.Location = New System.Drawing.Point(6, 110)
Me.CBWebtease.Name = "CBWebtease"
Me.CBWebtease.Size = New System.Drawing.Size(105, 17)
Me.CBWebtease.TabIndex = 5
Me.CBWebtease.TabStop = false
Me.CBWebtease.Text = "Webtease Mode"
Me.CBWebtease.UseVisualStyleBackColor = true
'
'GBSubFont
'
Me.GBSubFont.Controls.Add(Me.BTNSubColor)
Me.GBSubFont.Controls.Add(Me.LBLSubColor)
Me.GBSubFont.Controls.Add(Me.NBFontSize)
Me.GBSubFont.Controls.Add(Me.Label2)
Me.GBSubFont.Controls.Add(Me.FontComboBox)
Me.GBSubFont.Location = New System.Drawing.Point(6, 219)
Me.GBSubFont.Name = "GBSubFont"
Me.GBSubFont.Size = New System.Drawing.Size(200, 77)
Me.GBSubFont.TabIndex = 0
Me.GBSubFont.TabStop = false
Me.GBSubFont.Text = "Sub Font Settings"
'
'BTNSubColor
'
Me.BTNSubColor.BackColor = System.Drawing.Color.LightGray
Me.BTNSubColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNSubColor.ForeColor = System.Drawing.Color.Black
Me.BTNSubColor.Location = New System.Drawing.Point(6, 19)
Me.BTNSubColor.Name = "BTNSubColor"
Me.BTNSubColor.Size = New System.Drawing.Size(110, 25)
Me.BTNSubColor.TabIndex = 8
Me.BTNSubColor.Text = "Sub Name Color"
Me.BTNSubColor.UseVisualStyleBackColor = false
'
'LBLSubColor
'
Me.LBLSubColor.BackColor = System.Drawing.Color.White
Me.LBLSubColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLSubColor.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "SubColorColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLSubColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubColor.ForeColor = Global.Tease_AI.My.MySettings.Default.SubColorColor
Me.LBLSubColor.Location = New System.Drawing.Point(120, 20)
Me.LBLSubColor.Name = "LBLSubColor"
Me.LBLSubColor.Size = New System.Drawing.Size(72, 23)
Me.LBLSubColor.TabIndex = 0
Me.LBLSubColor.Text = "Preview"
Me.LBLSubColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBFontSize
'
Me.NBFontSize.BackColor = System.Drawing.Color.White
Me.NBFontSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBFontSize.ForeColor = System.Drawing.Color.Black
Me.NBFontSize.Location = New System.Drawing.Point(147, 47)
Me.NBFontSize.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBFontSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBFontSize.Name = "NBFontSize"
Me.NBFontSize.Size = New System.Drawing.Size(45, 20)
Me.NBFontSize.TabIndex = 11
Me.NBFontSize.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label2
'
Me.Label2.BackColor = System.Drawing.Color.Transparent
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label2.ForeColor = System.Drawing.Color.Black
Me.Label2.Location = New System.Drawing.Point(117, 45)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(30, 20)
Me.Label2.TabIndex = 63
Me.Label2.Text = "Size:"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'FontComboBox
'
Me.FontComboBox.FormattingEnabled = true
Me.FontComboBox.Location = New System.Drawing.Point(6, 46)
Me.FontComboBox.Name = "FontComboBox"
Me.FontComboBox.Size = New System.Drawing.Size(110, 21)
Me.FontComboBox.TabIndex = 9
'
'GBDommeFont
'
Me.GBDommeFont.Controls.Add(Me.BTNDomColor)
Me.GBDommeFont.Controls.Add(Me.LBLDomColor)
Me.GBDommeFont.Controls.Add(Me.FontComboBoxD)
Me.GBDommeFont.Controls.Add(Me.NBFontSizeD)
Me.GBDommeFont.Controls.Add(Me.Label7)
Me.GBDommeFont.Location = New System.Drawing.Point(6, 142)
Me.GBDommeFont.Name = "GBDommeFont"
Me.GBDommeFont.Size = New System.Drawing.Size(200, 77)
Me.GBDommeFont.TabIndex = 0
Me.GBDommeFont.TabStop = false
Me.GBDommeFont.Text = "Domme Font Settings"
'
'BTNDomColor
'
Me.BTNDomColor.BackColor = System.Drawing.Color.LightGray
Me.BTNDomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomColor.ForeColor = System.Drawing.Color.Black
Me.BTNDomColor.Location = New System.Drawing.Point(6, 19)
Me.BTNDomColor.Name = "BTNDomColor"
Me.BTNDomColor.Size = New System.Drawing.Size(110, 25)
Me.BTNDomColor.TabIndex = 5
Me.BTNDomColor.Text = "Domme Name Color"
Me.BTNDomColor.UseVisualStyleBackColor = false
'
'LBLDomColor
'
Me.LBLDomColor.BackColor = System.Drawing.Color.White
Me.LBLDomColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLDomColor.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "DomColorColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLDomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLDomColor.ForeColor = Global.Tease_AI.My.MySettings.Default.DomColorColor
Me.LBLDomColor.Location = New System.Drawing.Point(120, 20)
Me.LBLDomColor.Name = "LBLDomColor"
Me.LBLDomColor.Size = New System.Drawing.Size(72, 23)
Me.LBLDomColor.TabIndex = 0
Me.LBLDomColor.Text = "Preview"
Me.LBLDomColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'FontComboBoxD
'
Me.FontComboBoxD.FormattingEnabled = true
Me.FontComboBoxD.Location = New System.Drawing.Point(6, 46)
Me.FontComboBoxD.Name = "FontComboBoxD"
Me.FontComboBoxD.Size = New System.Drawing.Size(110, 21)
Me.FontComboBoxD.TabIndex = 6
'
'NBFontSizeD
'
Me.NBFontSizeD.BackColor = System.Drawing.Color.White
Me.NBFontSizeD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBFontSizeD.ForeColor = System.Drawing.Color.Black
Me.NBFontSizeD.Location = New System.Drawing.Point(147, 47)
Me.NBFontSizeD.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBFontSizeD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBFontSizeD.Name = "NBFontSizeD"
Me.NBFontSizeD.Size = New System.Drawing.Size(45, 20)
Me.NBFontSizeD.TabIndex = 7
Me.NBFontSizeD.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label7
'
Me.Label7.BackColor = System.Drawing.Color.Transparent
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label7.ForeColor = System.Drawing.Color.Black
Me.Label7.Location = New System.Drawing.Point(117, 45)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(30, 20)
Me.Label7.TabIndex = 172
Me.Label7.Text = "Size:"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'CBInputIcon
'
Me.CBInputIcon.AutoSize = true
Me.CBInputIcon.Checked = true
Me.CBInputIcon.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBInputIcon.ForeColor = System.Drawing.Color.Black
Me.CBInputIcon.Location = New System.Drawing.Point(6, 87)
Me.CBInputIcon.Name = "CBInputIcon"
Me.CBInputIcon.Size = New System.Drawing.Size(188, 17)
Me.CBInputIcon.TabIndex = 4
Me.CBInputIcon.TabStop = false
Me.CBInputIcon.Text = "Show Icon During Input Questions"
Me.CBInputIcon.UseVisualStyleBackColor = true
'
'typeinstantlyCheckBox
'
Me.typeinstantlyCheckBox.AutoSize = true
Me.typeinstantlyCheckBox.ForeColor = System.Drawing.Color.Black
Me.typeinstantlyCheckBox.Location = New System.Drawing.Point(6, 64)
Me.typeinstantlyCheckBox.Name = "typeinstantlyCheckBox"
Me.typeinstantlyCheckBox.Size = New System.Drawing.Size(136, 17)
Me.typeinstantlyCheckBox.TabIndex = 3
Me.typeinstantlyCheckBox.TabStop = false
Me.typeinstantlyCheckBox.Text = "Domme Types Instantly"
Me.typeinstantlyCheckBox.UseVisualStyleBackColor = true
'
'timestampCheckBox
'
Me.timestampCheckBox.AutoSize = true
Me.timestampCheckBox.Checked = true
Me.timestampCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
Me.timestampCheckBox.ForeColor = System.Drawing.Color.Black
Me.timestampCheckBox.Location = New System.Drawing.Point(6, 18)
Me.timestampCheckBox.Name = "timestampCheckBox"
Me.timestampCheckBox.Size = New System.Drawing.Size(112, 17)
Me.timestampCheckBox.TabIndex = 1
Me.timestampCheckBox.TabStop = false
Me.timestampCheckBox.Text = "Show Timestamps"
Me.timestampCheckBox.UseVisualStyleBackColor = true
'
'shownamesCheckBox
'
Me.shownamesCheckBox.AutoSize = true
Me.shownamesCheckBox.Checked = true
Me.shownamesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
Me.shownamesCheckBox.ForeColor = System.Drawing.Color.Black
Me.shownamesCheckBox.Location = New System.Drawing.Point(6, 41)
Me.shownamesCheckBox.Name = "shownamesCheckBox"
Me.shownamesCheckBox.Size = New System.Drawing.Size(125, 17)
Me.shownamesCheckBox.TabIndex = 2
Me.shownamesCheckBox.TabStop = false
Me.shownamesCheckBox.Text = "Always Show Names"
Me.shownamesCheckBox.UseVisualStyleBackColor = true
'
'LBLGeneralSettings
'
Me.LBLGeneralSettings.BackColor = System.Drawing.Color.Transparent
Me.LBLGeneralSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGeneralSettings.ForeColor = System.Drawing.Color.Black
Me.LBLGeneralSettings.Location = New System.Drawing.Point(7, 6)
Me.LBLGeneralSettings.Name = "LBLGeneralSettings"
Me.LBLGeneralSettings.Size = New System.Drawing.Size(692, 21)
Me.LBLGeneralSettings.TabIndex = 0
Me.LBLGeneralSettings.Text = "General Settings"
Me.LBLGeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage2
'
Me.TabPage2.BackColor = System.Drawing.Color.Silver
Me.TabPage2.Controls.Add(Me.Panel3)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage2.Size = New System.Drawing.Size(720, 448)
Me.TabPage2.TabIndex = 1
Me.TabPage2.Text = "Domme"
'
'Panel3
'
Me.Panel3.BackColor = System.Drawing.Color.LightGray
Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel3.Controls.Add(Me.GBGiveUp)
Me.Panel3.Controls.Add(Me.BTNLoadDomSet)
Me.Panel3.Controls.Add(Me.BTNSaveDomSet)
Me.Panel3.Controls.Add(Me.Label127)
Me.Panel3.Controls.Add(Me.Label126)
Me.Panel3.Controls.Add(Me.PictureBox4)
Me.Panel3.Controls.Add(Me.GBDomTypingStyle)
Me.Panel3.Controls.Add(Me.GBDomRanges)
Me.Panel3.Controls.Add(Me.GBDomStats)
Me.Panel3.Controls.Add(Me.GBDomPersonality)
Me.Panel3.Controls.Add(Me.GBDomOrgasms)
Me.Panel3.Controls.Add(Me.GBDomPetNames)
Me.Panel3.Controls.Add(Me.Label54)
Me.Panel3.Location = New System.Drawing.Point(6, 6)
Me.Panel3.Name = "Panel3"
Me.Panel3.Size = New System.Drawing.Size(708, 437)
Me.Panel3.TabIndex = 93
'
'GBGiveUp
'
Me.GBGiveUp.Controls.Add(Me.giveupCheckBox)
Me.GBGiveUp.Location = New System.Drawing.Point(440, 230)
Me.GBGiveUp.Name = "GBGiveUp"
Me.GBGiveUp.Size = New System.Drawing.Size(259, 63)
Me.GBGiveUp.TabIndex = 42
Me.GBGiveUp.TabStop = false
Me.GBGiveUp.Text = "Script Behavior"
'
'giveupCheckBox
'
Me.giveupCheckBox.AutoSize = true
Me.giveupCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.giveupCheckBox.ForeColor = System.Drawing.Color.Black
Me.giveupCheckBox.Location = New System.Drawing.Point(15, 26)
Me.giveupCheckBox.Name = "giveupCheckBox"
Me.giveupCheckBox.Size = New System.Drawing.Size(210, 17)
Me.giveupCheckBox.TabIndex = 38
Me.giveupCheckBox.Text = "Continue Current Script After Giving Up"
Me.giveupCheckBox.UseVisualStyleBackColor = true
'
'BTNLoadDomSet
'
Me.BTNLoadDomSet.BackColor = System.Drawing.Color.LightGray
Me.BTNLoadDomSet.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Export
Me.BTNLoadDomSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.BTNLoadDomSet.FlatAppearance.BorderSize = 0
Me.BTNLoadDomSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BTNLoadDomSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.BTNLoadDomSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BTNLoadDomSet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNLoadDomSet.ForeColor = System.Drawing.Color.Black
Me.BTNLoadDomSet.Location = New System.Drawing.Point(671, 11)
Me.BTNLoadDomSet.Name = "BTNLoadDomSet"
Me.BTNLoadDomSet.Size = New System.Drawing.Size(30, 26)
Me.BTNLoadDomSet.TabIndex = 150
Me.BTNLoadDomSet.UseVisualStyleBackColor = false
'
'BTNSaveDomSet
'
Me.BTNSaveDomSet.BackColor = System.Drawing.Color.LightGray
Me.BTNSaveDomSet.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Save
Me.BTNSaveDomSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.BTNSaveDomSet.FlatAppearance.BorderSize = 0
Me.BTNSaveDomSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BTNSaveDomSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.BTNSaveDomSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BTNSaveDomSet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNSaveDomSet.ForeColor = System.Drawing.Color.Black
Me.BTNSaveDomSet.Location = New System.Drawing.Point(636, 8)
Me.BTNSaveDomSet.Name = "BTNSaveDomSet"
Me.BTNSaveDomSet.Size = New System.Drawing.Size(30, 26)
Me.BTNSaveDomSet.TabIndex = 151
Me.BTNSaveDomSet.UseVisualStyleBackColor = false
'
'Label127
'
Me.Label127.AutoSize = true
Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label127.ForeColor = System.Drawing.Color.Black
Me.Label127.Location = New System.Drawing.Point(670, -3)
Me.Label127.Name = "Label127"
Me.Label127.Size = New System.Drawing.Size(27, 13)
Me.Label127.TabIndex = 153
Me.Label127.Text = "load"
Me.Label127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label126
'
Me.Label126.AutoSize = true
Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label126.ForeColor = System.Drawing.Color.Black
Me.Label126.Location = New System.Drawing.Point(636, -3)
Me.Label126.Name = "Label126"
Me.Label126.Size = New System.Drawing.Size(30, 13)
Me.Label126.TabIndex = 152
Me.Label126.Text = "save"
Me.Label126.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'PictureBox4
'
Me.PictureBox4.BackColor = System.Drawing.Color.LightGray
Me.PictureBox4.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox4.Location = New System.Drawing.Point(9, 6)
Me.PictureBox4.Name = "PictureBox4"
Me.PictureBox4.Size = New System.Drawing.Size(160, 19)
Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox4.TabIndex = 149
Me.PictureBox4.TabStop = false
'
'GBDomTypingStyle
'
Me.GBDomTypingStyle.Controls.Add(Me.TBEmoteEnd)
Me.GBDomTypingStyle.Controls.Add(Me.Label67)
Me.GBDomTypingStyle.Controls.Add(Me.TBEmote)
Me.GBDomTypingStyle.Controls.Add(Me.NBTypoChance)
Me.GBDomTypingStyle.Controls.Add(Me.Label66)
Me.GBDomTypingStyle.Controls.Add(Me.CBMeMyMine)
Me.GBDomTypingStyle.Controls.Add(Me.GroupBox63)
Me.GBDomTypingStyle.Controls.Add(Me.Label64)
Me.GBDomTypingStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.GBDomTypingStyle.ForeColor = System.Drawing.Color.Black
Me.GBDomTypingStyle.Location = New System.Drawing.Point(7, 299)
Me.GBDomTypingStyle.Name = "GBDomTypingStyle"
Me.GBDomTypingStyle.Size = New System.Drawing.Size(427, 124)
Me.GBDomTypingStyle.TabIndex = 138
Me.GBDomTypingStyle.TabStop = false
Me.GBDomTypingStyle.Text = "Typing Style"
'
'TBEmoteEnd
'
Me.TBEmoteEnd.BackColor = System.Drawing.Color.White
Me.TBEmoteEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBEmoteEnd.ForeColor = System.Drawing.Color.Black
Me.TBEmoteEnd.Location = New System.Drawing.Point(115, 91)
Me.TBEmoteEnd.Name = "TBEmoteEnd"
Me.TBEmoteEnd.Size = New System.Drawing.Size(84, 23)
Me.TBEmoteEnd.TabIndex = 155
Me.TBEmoteEnd.Text = "*"
Me.TBEmoteEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label67
'
Me.Label67.AutoSize = true
Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label67.ForeColor = System.Drawing.Color.Black
Me.Label67.Location = New System.Drawing.Point(237, 77)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(42, 13)
Me.Label67.TabIndex = 169
Me.Label67.Text = "Typo %"
Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TBEmote
'
Me.TBEmote.BackColor = System.Drawing.Color.White
Me.TBEmote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBEmote.ForeColor = System.Drawing.Color.Black
Me.TBEmote.Location = New System.Drawing.Point(9, 91)
Me.TBEmote.Name = "TBEmote"
Me.TBEmote.Size = New System.Drawing.Size(85, 23)
Me.TBEmote.TabIndex = 154
Me.TBEmote.Text = "*"
Me.TBEmote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'NBTypoChance
'
Me.NBTypoChance.Location = New System.Drawing.Point(238, 94)
Me.NBTypoChance.Name = "NBTypoChance"
Me.NBTypoChance.Size = New System.Drawing.Size(44, 20)
Me.NBTypoChance.TabIndex = 168
Me.NBTypoChance.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'Label66
'
Me.Label66.AutoSize = true
Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label66.ForeColor = System.Drawing.Color.Black
Me.Label66.Location = New System.Drawing.Point(322, 77)
Me.Label66.Name = "Label66"
Me.Label66.Size = New System.Drawing.Size(52, 13)
Me.Label66.TabIndex = 44
Me.Label66.Text = "Pronouns"
Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBMeMyMine
'
Me.CBMeMyMine.AutoSize = true
Me.CBMeMyMine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBMeMyMine.ForeColor = System.Drawing.Color.Black
Me.CBMeMyMine.Location = New System.Drawing.Point(325, 97)
Me.CBMeMyMine.Name = "CBMeMyMine"
Me.CBMeMyMine.Size = New System.Drawing.Size(88, 17)
Me.CBMeMyMine.TabIndex = 40
Me.CBMeMyMine.Text = "Me/My/Mine"
Me.CBMeMyMine.UseVisualStyleBackColor = true
'
'GroupBox63
'
Me.GroupBox63.Controls.Add(Me.LCaseCheckBox)
Me.GroupBox63.Controls.Add(Me.apostropheCheckBox)
Me.GroupBox63.Controls.Add(Me.periodCheckBox)
Me.GroupBox63.Controls.Add(Me.commaCheckBox)
Me.GroupBox63.Location = New System.Drawing.Point(9, 15)
Me.GroupBox63.Name = "GroupBox63"
Me.GroupBox63.Size = New System.Drawing.Size(407, 48)
Me.GroupBox63.TabIndex = 41
Me.GroupBox63.TabStop = false
Me.GroupBox63.Text = "Remove"
'
'LCaseCheckBox
'
Me.LCaseCheckBox.AutoSize = true
Me.LCaseCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LCaseCheckBox.ForeColor = System.Drawing.Color.Black
Me.LCaseCheckBox.Location = New System.Drawing.Point(16, 19)
Me.LCaseCheckBox.Name = "LCaseCheckBox"
Me.LCaseCheckBox.Size = New System.Drawing.Size(88, 17)
Me.LCaseCheckBox.TabIndex = 38
Me.LCaseCheckBox.Text = "Capitalization"
Me.LCaseCheckBox.UseVisualStyleBackColor = true
'
'apostropheCheckBox
'
Me.apostropheCheckBox.AutoSize = true
Me.apostropheCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.apostropheCheckBox.ForeColor = System.Drawing.Color.Black
Me.apostropheCheckBox.Location = New System.Drawing.Point(116, 19)
Me.apostropheCheckBox.Name = "apostropheCheckBox"
Me.apostropheCheckBox.Size = New System.Drawing.Size(85, 17)
Me.apostropheCheckBox.TabIndex = 39
Me.apostropheCheckBox.Text = "Apostrophes"
Me.apostropheCheckBox.UseVisualStyleBackColor = true
'
'periodCheckBox
'
Me.periodCheckBox.AutoSize = true
Me.periodCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.periodCheckBox.ForeColor = System.Drawing.Color.Black
Me.periodCheckBox.Location = New System.Drawing.Point(316, 19)
Me.periodCheckBox.Name = "periodCheckBox"
Me.periodCheckBox.Size = New System.Drawing.Size(61, 17)
Me.periodCheckBox.TabIndex = 37
Me.periodCheckBox.Text = "Periods"
Me.periodCheckBox.UseVisualStyleBackColor = true
'
'commaCheckBox
'
Me.commaCheckBox.AutoSize = true
Me.commaCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.commaCheckBox.ForeColor = System.Drawing.Color.Black
Me.commaCheckBox.Location = New System.Drawing.Point(216, 19)
Me.commaCheckBox.Name = "commaCheckBox"
Me.commaCheckBox.Size = New System.Drawing.Size(66, 17)
Me.commaCheckBox.TabIndex = 36
Me.commaCheckBox.Text = "Commas"
Me.commaCheckBox.UseVisualStyleBackColor = true
'
'Label64
'
Me.Label64.AutoSize = true
Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label64.ForeColor = System.Drawing.Color.Black
Me.Label64.Location = New System.Drawing.Point(8, 77)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(79, 13)
Me.Label64.TabIndex = 43
Me.Label64.Text = "Emote Symbols"
Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GBDomRanges
'
Me.GBDomRanges.Controls.Add(Me.NBDomMoodMax)
Me.GBDomRanges.Controls.Add(Me.NBDomMoodMin)
Me.GBDomRanges.Controls.Add(Me.Label37)
Me.GBDomRanges.Controls.Add(Me.Label39)
Me.GBDomRanges.Controls.Add(Me.NBSubAgeMax)
Me.GBDomRanges.Controls.Add(Me.NBSubAgeMin)
Me.GBDomRanges.Controls.Add(Me.Label31)
Me.GBDomRanges.Controls.Add(Me.Label36)
Me.GBDomRanges.Controls.Add(Me.NBSelfAgeMax)
Me.GBDomRanges.Controls.Add(Me.NBSelfAgeMin)
Me.GBDomRanges.Controls.Add(Me.Label21)
Me.GBDomRanges.Controls.Add(Me.Label22)
Me.GBDomRanges.Controls.Add(Me.NBAvgCockMax)
Me.GBDomRanges.Controls.Add(Me.NBAvgCockMin)
Me.GBDomRanges.Controls.Add(Me.Label23)
Me.GBDomRanges.Controls.Add(Me.Label30)
Me.GBDomRanges.Location = New System.Drawing.Point(440, 299)
Me.GBDomRanges.Name = "GBDomRanges"
Me.GBDomRanges.Size = New System.Drawing.Size(259, 124)
Me.GBDomRanges.TabIndex = 148
Me.GBDomRanges.TabStop = false
Me.GBDomRanges.Text = "Ranges"
'
'NBDomMoodMax
'
Me.NBDomMoodMax.Location = New System.Drawing.Point(200, 19)
Me.NBDomMoodMax.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
Me.NBDomMoodMax.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
Me.NBDomMoodMax.Name = "NBDomMoodMax"
Me.NBDomMoodMax.Size = New System.Drawing.Size(44, 20)
Me.NBDomMoodMax.TabIndex = 168
Me.NBDomMoodMax.Value = New Decimal(New Integer() {8, 0, 0, 0})
'
'NBDomMoodMin
'
Me.NBDomMoodMin.Location = New System.Drawing.Point(134, 19)
Me.NBDomMoodMin.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
Me.NBDomMoodMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBDomMoodMin.Name = "NBDomMoodMin"
Me.NBDomMoodMin.Size = New System.Drawing.Size(44, 20)
Me.NBDomMoodMin.TabIndex = 167
Me.NBDomMoodMin.Value = New Decimal(New Integer() {6, 0, 0, 0})
'
'Label37
'
Me.Label37.BackColor = System.Drawing.Color.Transparent
Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label37.ForeColor = System.Drawing.Color.Black
Me.Label37.Location = New System.Drawing.Point(184, 19)
Me.Label37.Name = "Label37"
Me.Label37.Size = New System.Drawing.Size(10, 17)
Me.Label37.TabIndex = 166
Me.Label37.Text = "-"
Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label39
'
Me.Label39.BackColor = System.Drawing.Color.Transparent
Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label39.ForeColor = System.Drawing.Color.Black
Me.Label39.Location = New System.Drawing.Point(12, 19)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(116, 17)
Me.Label39.TabIndex = 165
Me.Label39.Text = "Domme Mood Index:"
Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBSubAgeMax
'
Me.NBSubAgeMax.Location = New System.Drawing.Point(200, 94)
Me.NBSubAgeMax.Maximum = New Decimal(New Integer() {98, 0, 0, 0})
Me.NBSubAgeMax.Minimum = New Decimal(New Integer() {29, 0, 0, 0})
Me.NBSubAgeMax.Name = "NBSubAgeMax"
Me.NBSubAgeMax.Size = New System.Drawing.Size(44, 20)
Me.NBSubAgeMax.TabIndex = 164
Me.NBSubAgeMax.Value = New Decimal(New Integer() {49, 0, 0, 0})
'
'NBSubAgeMin
'
Me.NBSubAgeMin.Location = New System.Drawing.Point(134, 94)
Me.NBSubAgeMin.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
Me.NBSubAgeMin.Minimum = New Decimal(New Integer() {19, 0, 0, 0})
Me.NBSubAgeMin.Name = "NBSubAgeMin"
Me.NBSubAgeMin.Size = New System.Drawing.Size(44, 20)
Me.NBSubAgeMin.TabIndex = 163
Me.NBSubAgeMin.Value = New Decimal(New Integer() {28, 0, 0, 0})
'
'Label31
'
Me.Label31.BackColor = System.Drawing.Color.Transparent
Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label31.ForeColor = System.Drawing.Color.Black
Me.Label31.Location = New System.Drawing.Point(184, 94)
Me.Label31.Name = "Label31"
Me.Label31.Size = New System.Drawing.Size(10, 17)
Me.Label31.TabIndex = 162
Me.Label31.Text = "-"
Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label36
'
Me.Label36.BackColor = System.Drawing.Color.Transparent
Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label36.ForeColor = System.Drawing.Color.Black
Me.Label36.Location = New System.Drawing.Point(12, 94)
Me.Label36.Name = "Label36"
Me.Label36.Size = New System.Drawing.Size(113, 17)
Me.Label36.TabIndex = 161
Me.Label36.Text = "Sub Age Perception:"
Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBSelfAgeMax
'
Me.NBSelfAgeMax.Location = New System.Drawing.Point(200, 69)
Me.NBSelfAgeMax.Maximum = New Decimal(New Integer() {98, 0, 0, 0})
Me.NBSelfAgeMax.Minimum = New Decimal(New Integer() {29, 0, 0, 0})
Me.NBSelfAgeMax.Name = "NBSelfAgeMax"
Me.NBSelfAgeMax.Size = New System.Drawing.Size(44, 20)
Me.NBSelfAgeMax.TabIndex = 156
Me.NBSelfAgeMax.Value = New Decimal(New Integer() {49, 0, 0, 0})
'
'NBSelfAgeMin
'
Me.NBSelfAgeMin.Location = New System.Drawing.Point(134, 69)
Me.NBSelfAgeMin.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
Me.NBSelfAgeMin.Minimum = New Decimal(New Integer() {19, 0, 0, 0})
Me.NBSelfAgeMin.Name = "NBSelfAgeMin"
Me.NBSelfAgeMin.Size = New System.Drawing.Size(44, 20)
Me.NBSelfAgeMin.TabIndex = 155
Me.NBSelfAgeMin.Value = New Decimal(New Integer() {28, 0, 0, 0})
'
'Label21
'
Me.Label21.BackColor = System.Drawing.Color.Transparent
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label21.ForeColor = System.Drawing.Color.Black
Me.Label21.Location = New System.Drawing.Point(184, 69)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(10, 17)
Me.Label21.TabIndex = 154
Me.Label21.Text = "-"
Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label22
'
Me.Label22.BackColor = System.Drawing.Color.Transparent
Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label22.ForeColor = System.Drawing.Color.Black
Me.Label22.Location = New System.Drawing.Point(12, 69)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(116, 17)
Me.Label22.TabIndex = 153
Me.Label22.Text = "Self Age Perception:"
Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBAvgCockMax
'
Me.NBAvgCockMax.Location = New System.Drawing.Point(200, 44)
Me.NBAvgCockMax.Maximum = New Decimal(New Integer() {14, 0, 0, 0})
Me.NBAvgCockMax.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
Me.NBAvgCockMax.Name = "NBAvgCockMax"
Me.NBAvgCockMax.Size = New System.Drawing.Size(44, 20)
Me.NBAvgCockMax.TabIndex = 152
Me.NBAvgCockMax.Value = New Decimal(New Integer() {8, 0, 0, 0})
'
'NBAvgCockMin
'
Me.NBAvgCockMin.Location = New System.Drawing.Point(134, 44)
Me.NBAvgCockMin.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
Me.NBAvgCockMin.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
Me.NBAvgCockMin.Name = "NBAvgCockMin"
Me.NBAvgCockMin.Size = New System.Drawing.Size(44, 20)
Me.NBAvgCockMin.TabIndex = 151
Me.NBAvgCockMin.Value = New Decimal(New Integer() {6, 0, 0, 0})
'
'Label23
'
Me.Label23.BackColor = System.Drawing.Color.Transparent
Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label23.ForeColor = System.Drawing.Color.Black
Me.Label23.Location = New System.Drawing.Point(184, 44)
Me.Label23.Name = "Label23"
Me.Label23.Size = New System.Drawing.Size(10, 17)
Me.Label23.TabIndex = 150
Me.Label23.Text = "-"
Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label30
'
Me.Label30.BackColor = System.Drawing.Color.Transparent
Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label30.ForeColor = System.Drawing.Color.Black
Me.Label30.Location = New System.Drawing.Point(12, 44)
Me.Label30.Name = "Label30"
Me.Label30.Size = New System.Drawing.Size(116, 17)
Me.Label30.TabIndex = 149
Me.Label30.Text = "Average Dick Size:"
Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GBDomStats
'
Me.GBDomStats.BackColor = System.Drawing.Color.LightGray
Me.GBDomStats.Controls.Add(Me.Label128)
Me.GBDomStats.Controls.Add(Me.LBLEmpathy)
Me.GBDomStats.Controls.Add(Me.NBEmpathy)
Me.GBDomStats.Controls.Add(Me.Label83)
Me.GBDomStats.Controls.Add(Me.NBDomBirthdayDay)
Me.GBDomStats.Controls.Add(Me.TBDomEyeColor)
Me.GBDomStats.Controls.Add(Me.TBDomHairColor)
Me.GBDomStats.Controls.Add(Me.domageNumBox)
Me.GBDomStats.Controls.Add(Me.Label47)
Me.GBDomStats.Controls.Add(Me.Label76)
Me.GBDomStats.Controls.Add(Me.NBDomBirthdayMonth)
Me.GBDomStats.Controls.Add(Me.Label84)
Me.GBDomStats.Controls.Add(Me.CBDomTattoos)
Me.GBDomStats.Controls.Add(Me.CBDomFreckles)
Me.GBDomStats.Controls.Add(Me.domhairlengthComboBox)
Me.GBDomStats.Controls.Add(Me.Label10)
Me.GBDomStats.Controls.Add(Me.dompubichairComboBox)
Me.GBDomStats.Controls.Add(Me.Label9)
Me.GBDomStats.Controls.Add(Me.boobComboBox)
Me.GBDomStats.Controls.Add(Me.DomLevelDescLabel)
Me.GBDomStats.Controls.Add(Me.domlevelNumBox)
Me.GBDomStats.Controls.Add(Me.Label43)
Me.GBDomStats.Controls.Add(Me.Label44)
Me.GBDomStats.Controls.Add(Me.Label45)
Me.GBDomStats.Controls.Add(Me.Label46)
Me.GBDomStats.ForeColor = System.Drawing.Color.Black
Me.GBDomStats.Location = New System.Drawing.Point(18, 33)
Me.GBDomStats.Name = "GBDomStats"
Me.GBDomStats.Size = New System.Drawing.Size(171, 263)
Me.GBDomStats.TabIndex = 62
Me.GBDomStats.TabStop = false
Me.GBDomStats.Text = "Stats/Appearance"
'
'Label128
'
Me.Label128.AutoSize = true
Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label128.Location = New System.Drawing.Point(125, 68)
Me.Label128.Name = "Label128"
Me.Label128.Size = New System.Drawing.Size(38, 13)
Me.Label128.TabIndex = 156
Me.Label128.Text = "mm/dd"
Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLEmpathy
'
Me.LBLEmpathy.Location = New System.Drawing.Point(113, 41)
Me.LBLEmpathy.Name = "LBLEmpathy"
Me.LBLEmpathy.Size = New System.Drawing.Size(55, 13)
Me.LBLEmpathy.TabIndex = 157
Me.LBLEmpathy.Text = "Moderate"
Me.LBLEmpathy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBEmpathy
'
Me.NBEmpathy.BackColor = System.Drawing.Color.White
Me.NBEmpathy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBEmpathy.ForeColor = System.Drawing.Color.Black
Me.NBEmpathy.Location = New System.Drawing.Point(73, 38)
Me.NBEmpathy.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBEmpathy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBEmpathy.Name = "NBEmpathy"
Me.NBEmpathy.Size = New System.Drawing.Size(38, 20)
Me.NBEmpathy.TabIndex = 156
Me.NBEmpathy.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label83
'
Me.Label83.BackColor = System.Drawing.Color.Transparent
Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label83.ForeColor = System.Drawing.Color.Black
Me.Label83.Location = New System.Drawing.Point(6, 37)
Me.Label83.Name = "Label83"
Me.Label83.Size = New System.Drawing.Size(60, 17)
Me.Label83.TabIndex = 158
Me.Label83.Text = "Apathy:"
Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBDomBirthdayDay
'
Me.NBDomBirthdayDay.BackColor = System.Drawing.Color.White
Me.NBDomBirthdayDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBDomBirthdayDay.ForeColor = System.Drawing.Color.Black
Me.NBDomBirthdayDay.Location = New System.Drawing.Point(125, 83)
Me.NBDomBirthdayDay.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
Me.NBDomBirthdayDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBDomBirthdayDay.Name = "NBDomBirthdayDay"
Me.NBDomBirthdayDay.Size = New System.Drawing.Size(38, 20)
Me.NBDomBirthdayDay.TabIndex = 152
Me.NBDomBirthdayDay.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'TBDomEyeColor
'
Me.TBDomEyeColor.BackColor = System.Drawing.Color.White
Me.TBDomEyeColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBDomEyeColor.ForeColor = System.Drawing.Color.Black
Me.TBDomEyeColor.Location = New System.Drawing.Point(73, 155)
Me.TBDomEyeColor.Name = "TBDomEyeColor"
Me.TBDomEyeColor.Size = New System.Drawing.Size(89, 23)
Me.TBDomEyeColor.TabIndex = 154
Me.TBDomEyeColor.Text = "green"
'
'TBDomHairColor
'
Me.TBDomHairColor.BackColor = System.Drawing.Color.White
Me.TBDomHairColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBDomHairColor.ForeColor = System.Drawing.Color.Black
Me.TBDomHairColor.Location = New System.Drawing.Point(73, 105)
Me.TBDomHairColor.Name = "TBDomHairColor"
Me.TBDomHairColor.Size = New System.Drawing.Size(89, 23)
Me.TBDomHairColor.TabIndex = 153
Me.TBDomHairColor.Text = "brown"
'
'domageNumBox
'
Me.domageNumBox.BackColor = System.Drawing.Color.White
Me.domageNumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.domageNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.domageNumBox.ForeColor = System.Drawing.Color.Black
Me.domageNumBox.Location = New System.Drawing.Point(73, 61)
Me.domageNumBox.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.domageNumBox.Minimum = New Decimal(New Integer() {18, 0, 0, 0})
Me.domageNumBox.Name = "domageNumBox"
Me.domageNumBox.Size = New System.Drawing.Size(38, 20)
Me.domageNumBox.TabIndex = 27
Me.domageNumBox.Value = New Decimal(New Integer() {21, 0, 0, 0})
'
'Label47
'
Me.Label47.BackColor = System.Drawing.Color.Transparent
Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label47.ForeColor = System.Drawing.Color.Black
Me.Label47.Location = New System.Drawing.Point(6, 60)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(63, 17)
Me.Label47.TabIndex = 138
Me.Label47.Text = "Age:"
Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label76
'
Me.Label76.AutoSize = true
Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label76.ForeColor = System.Drawing.Color.Black
Me.Label76.Location = New System.Drawing.Point(113, 87)
Me.Label76.Name = "Label76"
Me.Label76.Size = New System.Drawing.Size(12, 13)
Me.Label76.TabIndex = 151
Me.Label76.Text = "/"
Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBDomBirthdayMonth
'
Me.NBDomBirthdayMonth.BackColor = System.Drawing.Color.White
Me.NBDomBirthdayMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBDomBirthdayMonth.ForeColor = System.Drawing.Color.Black
Me.NBDomBirthdayMonth.Location = New System.Drawing.Point(73, 83)
Me.NBDomBirthdayMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
Me.NBDomBirthdayMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBDomBirthdayMonth.Name = "NBDomBirthdayMonth"
Me.NBDomBirthdayMonth.Size = New System.Drawing.Size(38, 20)
Me.NBDomBirthdayMonth.TabIndex = 149
Me.NBDomBirthdayMonth.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label84
'
Me.Label84.BackColor = System.Drawing.Color.Transparent
Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label84.ForeColor = System.Drawing.Color.Black
Me.Label84.Location = New System.Drawing.Point(6, 84)
Me.Label84.Name = "Label84"
Me.Label84.Size = New System.Drawing.Size(60, 17)
Me.Label84.TabIndex = 150
Me.Label84.Text = "Birthday:"
Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'CBDomTattoos
'
Me.CBDomTattoos.AutoSize = true
Me.CBDomTattoos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBDomTattoos.ForeColor = System.Drawing.Color.Black
Me.CBDomTattoos.Location = New System.Drawing.Point(13, 237)
Me.CBDomTattoos.Name = "CBDomTattoos"
Me.CBDomTattoos.Size = New System.Drawing.Size(62, 17)
Me.CBDomTattoos.TabIndex = 148
Me.CBDomTattoos.Text = "Tattoos"
Me.CBDomTattoos.UseVisualStyleBackColor = true
'
'CBDomFreckles
'
Me.CBDomFreckles.AutoSize = true
Me.CBDomFreckles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBDomFreckles.ForeColor = System.Drawing.Color.Black
Me.CBDomFreckles.Location = New System.Drawing.Point(88, 237)
Me.CBDomFreckles.Name = "CBDomFreckles"
Me.CBDomFreckles.Size = New System.Drawing.Size(66, 17)
Me.CBDomFreckles.TabIndex = 147
Me.CBDomFreckles.Text = "Freckles"
Me.CBDomFreckles.UseVisualStyleBackColor = true
'
'domhairlengthComboBox
'
Me.domhairlengthComboBox.BackColor = System.Drawing.Color.White
Me.domhairlengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.domhairlengthComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.domhairlengthComboBox.ForeColor = System.Drawing.Color.Black
Me.domhairlengthComboBox.FormattingEnabled = true
Me.domhairlengthComboBox.Items.AddRange(New Object() {"Shaved", "Buzz cut", "Short", "Medium", "Long", "Very Long"})
Me.domhairlengthComboBox.Location = New System.Drawing.Point(73, 132)
Me.domhairlengthComboBox.Name = "domhairlengthComboBox"
Me.domhairlengthComboBox.Size = New System.Drawing.Size(89, 21)
Me.domhairlengthComboBox.TabIndex = 145
'
'Label10
'
Me.Label10.BackColor = System.Drawing.Color.Transparent
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label10.ForeColor = System.Drawing.Color.Black
Me.Label10.Location = New System.Drawing.Point(6, 133)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(78, 17)
Me.Label10.TabIndex = 146
Me.Label10.Text = "Hair Length:"
Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'dompubichairComboBox
'
Me.dompubichairComboBox.BackColor = System.Drawing.Color.White
Me.dompubichairComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.dompubichairComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.dompubichairComboBox.ForeColor = System.Drawing.Color.Black
Me.dompubichairComboBox.FormattingEnabled = true
Me.dompubichairComboBox.Items.AddRange(New Object() {"Shaved", "Sparse", "Trimmed", "Natural", "Hairy"})
Me.dompubichairComboBox.Location = New System.Drawing.Point(73, 208)
Me.dompubichairComboBox.Name = "dompubichairComboBox"
Me.dompubichairComboBox.Size = New System.Drawing.Size(89, 21)
Me.dompubichairComboBox.TabIndex = 143
'
'Label9
'
Me.Label9.BackColor = System.Drawing.Color.Transparent
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label9.ForeColor = System.Drawing.Color.Black
Me.Label9.Location = New System.Drawing.Point(6, 209)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(63, 17)
Me.Label9.TabIndex = 144
Me.Label9.Text = "Pubic Hair:"
Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'boobComboBox
'
Me.boobComboBox.BackColor = System.Drawing.Color.White
Me.boobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.boobComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.boobComboBox.ForeColor = System.Drawing.Color.Black
Me.boobComboBox.FormattingEnabled = true
Me.boobComboBox.Items.AddRange(New Object() {"A", "B", "C", "D", "DD", "DDD+"})
Me.boobComboBox.Location = New System.Drawing.Point(73, 182)
Me.boobComboBox.Name = "boobComboBox"
Me.boobComboBox.Size = New System.Drawing.Size(89, 21)
Me.boobComboBox.TabIndex = 2
'
'DomLevelDescLabel
'
Me.DomLevelDescLabel.Location = New System.Drawing.Point(112, 18)
Me.DomLevelDescLabel.Name = "DomLevelDescLabel"
Me.DomLevelDescLabel.Size = New System.Drawing.Size(55, 13)
Me.DomLevelDescLabel.TabIndex = 42
Me.DomLevelDescLabel.Text = "Tease"
Me.DomLevelDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'domlevelNumBox
'
Me.domlevelNumBox.BackColor = System.Drawing.Color.White
Me.domlevelNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.domlevelNumBox.ForeColor = System.Drawing.Color.Black
Me.domlevelNumBox.Location = New System.Drawing.Point(73, 15)
Me.domlevelNumBox.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
Me.domlevelNumBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.domlevelNumBox.Name = "domlevelNumBox"
Me.domlevelNumBox.Size = New System.Drawing.Size(38, 20)
Me.domlevelNumBox.TabIndex = 41
Me.domlevelNumBox.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label43
'
Me.Label43.BackColor = System.Drawing.Color.Transparent
Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label43.ForeColor = System.Drawing.Color.Black
Me.Label43.Location = New System.Drawing.Point(6, 183)
Me.Label43.Name = "Label43"
Me.Label43.Size = New System.Drawing.Size(63, 17)
Me.Label43.TabIndex = 142
Me.Label43.Text = "Cup Size:"
Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label44
'
Me.Label44.BackColor = System.Drawing.Color.Transparent
Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label44.ForeColor = System.Drawing.Color.Black
Me.Label44.Location = New System.Drawing.Point(6, 158)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(63, 17)
Me.Label44.TabIndex = 141
Me.Label44.Text = "Eye Color:"
Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label45
'
Me.Label45.BackColor = System.Drawing.Color.Transparent
Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label45.ForeColor = System.Drawing.Color.Black
Me.Label45.Location = New System.Drawing.Point(6, 108)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(78, 17)
Me.Label45.TabIndex = 140
Me.Label45.Text = "Hair Color:"
Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label46
'
Me.Label46.BackColor = System.Drawing.Color.Transparent
Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label46.ForeColor = System.Drawing.Color.Black
Me.Label46.Location = New System.Drawing.Point(6, 15)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(46, 17)
Me.Label46.TabIndex = 139
Me.Label46.Text = "Level:"
Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GBDomPersonality
'
Me.GBDomPersonality.Controls.Add(Me.degradingCheckBox)
Me.GBDomPersonality.Controls.Add(Me.sadisticCheckBox)
Me.GBDomPersonality.Controls.Add(Me.supremacistCheckBox)
Me.GBDomPersonality.Controls.Add(Me.vulgarCheckBox)
Me.GBDomPersonality.Controls.Add(Me.crazyCheckBox)
Me.GBDomPersonality.Controls.Add(Me.CFNMCheckBox)
Me.GBDomPersonality.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.GBDomPersonality.ForeColor = System.Drawing.Color.Black
Me.GBDomPersonality.Location = New System.Drawing.Point(184, 30)
Me.GBDomPersonality.Name = "GBDomPersonality"
Me.GBDomPersonality.Size = New System.Drawing.Size(250, 67)
Me.GBDomPersonality.TabIndex = 131
Me.GBDomPersonality.TabStop = false
Me.GBDomPersonality.Text = "Personality"
'
'degradingCheckBox
'
Me.degradingCheckBox.AutoSize = true
Me.degradingCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.degradingCheckBox.ForeColor = System.Drawing.Color.Black
Me.degradingCheckBox.Location = New System.Drawing.Point(79, 43)
Me.degradingCheckBox.Name = "degradingCheckBox"
Me.degradingCheckBox.Size = New System.Drawing.Size(75, 17)
Me.degradingCheckBox.TabIndex = 40
Me.degradingCheckBox.Text = "Degrading"
Me.degradingCheckBox.UseVisualStyleBackColor = true
'
'sadisticCheckBox
'
Me.sadisticCheckBox.AutoSize = true
Me.sadisticCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.sadisticCheckBox.ForeColor = System.Drawing.Color.Black
Me.sadisticCheckBox.Location = New System.Drawing.Point(11, 43)
Me.sadisticCheckBox.Name = "sadisticCheckBox"
Me.sadisticCheckBox.Size = New System.Drawing.Size(63, 17)
Me.sadisticCheckBox.TabIndex = 39
Me.sadisticCheckBox.Text = "Sadistic"
Me.sadisticCheckBox.UseVisualStyleBackColor = true
'
'supremacistCheckBox
'
Me.supremacistCheckBox.AutoSize = true
Me.supremacistCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.supremacistCheckBox.ForeColor = System.Drawing.Color.Black
Me.supremacistCheckBox.Location = New System.Drawing.Point(155, 20)
Me.supremacistCheckBox.Name = "supremacistCheckBox"
Me.supremacistCheckBox.Size = New System.Drawing.Size(84, 17)
Me.supremacistCheckBox.TabIndex = 38
Me.supremacistCheckBox.Text = "Supremacist"
Me.supremacistCheckBox.UseVisualStyleBackColor = true
'
'vulgarCheckBox
'
Me.vulgarCheckBox.AutoSize = true
Me.vulgarCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.vulgarCheckBox.ForeColor = System.Drawing.Color.Black
Me.vulgarCheckBox.Location = New System.Drawing.Point(79, 20)
Me.vulgarCheckBox.Name = "vulgarCheckBox"
Me.vulgarCheckBox.Size = New System.Drawing.Size(56, 17)
Me.vulgarCheckBox.TabIndex = 37
Me.vulgarCheckBox.Text = "Vulgar"
Me.vulgarCheckBox.UseVisualStyleBackColor = true
'
'crazyCheckBox
'
Me.crazyCheckBox.AutoSize = true
Me.crazyCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.crazyCheckBox.ForeColor = System.Drawing.Color.Black
Me.crazyCheckBox.Location = New System.Drawing.Point(11, 20)
Me.crazyCheckBox.Name = "crazyCheckBox"
Me.crazyCheckBox.Size = New System.Drawing.Size(52, 17)
Me.crazyCheckBox.TabIndex = 36
Me.crazyCheckBox.Text = "Crazy"
Me.crazyCheckBox.UseVisualStyleBackColor = true
'
'CFNMCheckBox
'
Me.CFNMCheckBox.AutoSize = true
Me.CFNMCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CFNMCheckBox.ForeColor = System.Drawing.Color.Black
Me.CFNMCheckBox.Location = New System.Drawing.Point(155, 43)
Me.CFNMCheckBox.Name = "CFNMCheckBox"
Me.CFNMCheckBox.Size = New System.Drawing.Size(56, 17)
Me.CFNMCheckBox.TabIndex = 41
Me.CFNMCheckBox.Text = "CFNM"
Me.CFNMCheckBox.UseVisualStyleBackColor = true
'
'GBDomOrgasms
'
Me.GBDomOrgasms.Controls.Add(Me.CBLockOrgasmChances)
Me.GBDomOrgasms.Controls.Add(Me.orgasmlockrandombutton)
Me.GBDomOrgasms.Controls.Add(Me.CBDomOrgasmEnds)
Me.GBDomOrgasms.Controls.Add(Me.Label16)
Me.GBDomOrgasms.Controls.Add(Me.Label12)
Me.GBDomOrgasms.Controls.Add(Me.orgasmsperlockButton)
Me.GBDomOrgasms.Controls.Add(Me.orgasmsperComboBox)
Me.GBDomOrgasms.Controls.Add(Me.orgasmsperLabel)
Me.GBDomOrgasms.Controls.Add(Me.limitcheckbox)
Me.GBDomOrgasms.Controls.Add(Me.orgasmsPerNumBox)
Me.GBDomOrgasms.Controls.Add(Me.CBDomDenialEnds)
Me.GBDomOrgasms.Controls.Add(Me.alloworgasmComboBox)
Me.GBDomOrgasms.Controls.Add(Me.ruinorgasmComboBox)
Me.GBDomOrgasms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.GBDomOrgasms.ForeColor = System.Drawing.Color.Black
Me.GBDomOrgasms.Location = New System.Drawing.Point(440, 30)
Me.GBDomOrgasms.Name = "GBDomOrgasms"
Me.GBDomOrgasms.Size = New System.Drawing.Size(259, 194)
Me.GBDomOrgasms.TabIndex = 132
Me.GBDomOrgasms.TabStop = false
Me.GBDomOrgasms.Text = "Orgasms"
'
'CBLockOrgasmChances
'
Me.CBLockOrgasmChances.Checked = Global.Tease_AI.My.MySettings.Default.LockOrgasmChances
Me.CBLockOrgasmChances.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "LockOrgasmChances", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBLockOrgasmChances.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBLockOrgasmChances.ForeColor = System.Drawing.Color.Black
Me.CBLockOrgasmChances.Location = New System.Drawing.Point(15, 73)
Me.CBLockOrgasmChances.Name = "CBLockOrgasmChances"
Me.CBLockOrgasmChances.Size = New System.Drawing.Size(237, 24)
Me.CBLockOrgasmChances.TabIndex = 146
Me.CBLockOrgasmChances.Text = "Orgasm Chance Locked when Tease Starts"
Me.CBLockOrgasmChances.UseVisualStyleBackColor = true
'
'orgasmlockrandombutton
'
Me.orgasmlockrandombutton.BackColor = System.Drawing.Color.LightGray
Me.orgasmlockrandombutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.orgasmlockrandombutton.ForeColor = System.Drawing.Color.Black
Me.orgasmlockrandombutton.Location = New System.Drawing.Point(134, 161)
Me.orgasmlockrandombutton.Name = "orgasmlockrandombutton"
Me.orgasmlockrandombutton.Size = New System.Drawing.Size(110, 21)
Me.orgasmlockrandombutton.TabIndex = 145
Me.orgasmlockrandombutton.Text = "Lock Random"
Me.orgasmlockrandombutton.UseVisualStyleBackColor = false
'
'CBDomOrgasmEnds
'
Me.CBDomOrgasmEnds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBDomOrgasmEnds.ForeColor = System.Drawing.Color.Black
Me.CBDomOrgasmEnds.Location = New System.Drawing.Point(145, 95)
Me.CBDomOrgasmEnds.Name = "CBDomOrgasmEnds"
Me.CBDomOrgasmEnds.Size = New System.Drawing.Size(104, 37)
Me.CBDomOrgasmEnds.TabIndex = 144
Me.CBDomOrgasmEnds.Text = "Orgasm Always Ends Tease"
Me.CBDomOrgasmEnds.UseVisualStyleBackColor = true
'
'Label16
'
Me.Label16.BackColor = System.Drawing.Color.Transparent
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label16.ForeColor = System.Drawing.Color.Black
Me.Label16.Location = New System.Drawing.Point(12, 47)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(87, 17)
Me.Label16.TabIndex = 142
Me.Label16.Text = "Ruins Orgasms:"
Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label12
'
Me.Label12.BackColor = System.Drawing.Color.Transparent
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label12.ForeColor = System.Drawing.Color.Black
Me.Label12.Location = New System.Drawing.Point(12, 19)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(87, 17)
Me.Label12.TabIndex = 141
Me.Label12.Text = "Allows Orgasms:"
Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'orgasmsperlockButton
'
Me.orgasmsperlockButton.BackColor = System.Drawing.Color.LightGray
Me.orgasmsperlockButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.orgasmsperlockButton.ForeColor = System.Drawing.Color.Black
Me.orgasmsperlockButton.Location = New System.Drawing.Point(15, 161)
Me.orgasmsperlockButton.Name = "orgasmsperlockButton"
Me.orgasmsperlockButton.Size = New System.Drawing.Size(110, 21)
Me.orgasmsperlockButton.TabIndex = 97
Me.orgasmsperlockButton.Text = "Lock Selected"
Me.orgasmsperlockButton.UseVisualStyleBackColor = false
'
'orgasmsperComboBox
'
Me.orgasmsperComboBox.BackColor = System.Drawing.Color.White
Me.orgasmsperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.orgasmsperComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.orgasmsperComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.orgasmsperComboBox.ForeColor = System.Drawing.Color.Black
Me.orgasmsperComboBox.FormattingEnabled = true
Me.orgasmsperComboBox.Items.AddRange(New Object() {"Week", "2 Weeks", "Month", "2 Months", "3 Months", "6 Months", "9 Months", "Year", "2 Years", "3 Years", "5 Years", "10 Years", "25 Years", "Lifetime"})
Me.orgasmsperComboBox.Location = New System.Drawing.Point(143, 133)
Me.orgasmsperComboBox.Name = "orgasmsperComboBox"
Me.orgasmsperComboBox.Size = New System.Drawing.Size(101, 21)
Me.orgasmsperComboBox.TabIndex = 43
'
'orgasmsperLabel
'
Me.orgasmsperLabel.AutoSize = true
Me.orgasmsperLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.orgasmsperLabel.ForeColor = System.Drawing.Color.Black
Me.orgasmsperLabel.Location = New System.Drawing.Point(115, 137)
Me.orgasmsperLabel.Name = "orgasmsperLabel"
Me.orgasmsperLabel.Size = New System.Drawing.Size(22, 13)
Me.orgasmsperLabel.TabIndex = 42
Me.orgasmsperLabel.Text = "per"
Me.orgasmsperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'limitcheckbox
'
Me.limitcheckbox.AutoSize = true
Me.limitcheckbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.limitcheckbox.ForeColor = System.Drawing.Color.Black
Me.limitcheckbox.Location = New System.Drawing.Point(15, 135)
Me.limitcheckbox.Name = "limitcheckbox"
Me.limitcheckbox.Size = New System.Drawing.Size(47, 17)
Me.limitcheckbox.TabIndex = 39
Me.limitcheckbox.Text = "Limit"
Me.limitcheckbox.UseVisualStyleBackColor = true
'
'orgasmsPerNumBox
'
Me.orgasmsPerNumBox.BackColor = System.Drawing.Color.White
Me.orgasmsPerNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.orgasmsPerNumBox.ForeColor = System.Drawing.Color.Black
Me.orgasmsPerNumBox.Location = New System.Drawing.Point(68, 134)
Me.orgasmsPerNumBox.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.orgasmsPerNumBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.orgasmsPerNumBox.Name = "orgasmsPerNumBox"
Me.orgasmsPerNumBox.Size = New System.Drawing.Size(41, 20)
Me.orgasmsPerNumBox.TabIndex = 41
Me.orgasmsPerNumBox.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'CBDomDenialEnds
'
Me.CBDomDenialEnds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBDomDenialEnds.ForeColor = System.Drawing.Color.Black
Me.CBDomDenialEnds.Location = New System.Drawing.Point(15, 95)
Me.CBDomDenialEnds.Name = "CBDomDenialEnds"
Me.CBDomDenialEnds.Size = New System.Drawing.Size(94, 37)
Me.CBDomDenialEnds.TabIndex = 38
Me.CBDomDenialEnds.Text = "Denial Always Ends Tease"
Me.CBDomDenialEnds.UseVisualStyleBackColor = true
'
'alloworgasmComboBox
'
Me.alloworgasmComboBox.BackColor = System.Drawing.Color.White
Me.alloworgasmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.alloworgasmComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.alloworgasmComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.alloworgasmComboBox.ForeColor = System.Drawing.Color.Black
Me.alloworgasmComboBox.FormattingEnabled = true
Me.alloworgasmComboBox.Items.AddRange(New Object() {"Never Allows", "Rarely Allows", "Sometimes Allows", "Often Allows", "Always Allows"})
Me.alloworgasmComboBox.Location = New System.Drawing.Point(98, 18)
Me.alloworgasmComboBox.Name = "alloworgasmComboBox"
Me.alloworgasmComboBox.Size = New System.Drawing.Size(146, 21)
Me.alloworgasmComboBox.TabIndex = 1
'
'ruinorgasmComboBox
'
Me.ruinorgasmComboBox.BackColor = System.Drawing.Color.White
Me.ruinorgasmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ruinorgasmComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.ruinorgasmComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.ruinorgasmComboBox.ForeColor = System.Drawing.Color.Black
Me.ruinorgasmComboBox.FormattingEnabled = true
Me.ruinorgasmComboBox.Items.AddRange(New Object() {"Never Ruins", "Rarely Ruins", "Sometimes Ruins", "Often Ruins", "Always Ruins"})
Me.ruinorgasmComboBox.Location = New System.Drawing.Point(98, 46)
Me.ruinorgasmComboBox.Name = "ruinorgasmComboBox"
Me.ruinorgasmComboBox.Size = New System.Drawing.Size(146, 21)
Me.ruinorgasmComboBox.TabIndex = 2
'
'GBDomPetNames
'
Me.GBDomPetNames.BackColor = System.Drawing.Color.LightGray
Me.GBDomPetNames.Controls.Add(Me.Label74)
Me.GBDomPetNames.Controls.Add(Me.petnameBox7)
Me.GBDomPetNames.Controls.Add(Me.petnameBox8)
Me.GBDomPetNames.Controls.Add(Me.petnameBox1)
Me.GBDomPetNames.Controls.Add(Me.Label15)
Me.GBDomPetNames.Controls.Add(Me.petnameBox4)
Me.GBDomPetNames.Controls.Add(Me.petnameBox6)
Me.GBDomPetNames.Controls.Add(Me.petnameBox2)
Me.GBDomPetNames.Controls.Add(Me.Label11)
Me.GBDomPetNames.Controls.Add(Me.petnameBox5)
Me.GBDomPetNames.Controls.Add(Me.petnameBox3)
Me.GBDomPetNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.GBDomPetNames.ForeColor = System.Drawing.Color.Black
Me.GBDomPetNames.Location = New System.Drawing.Point(184, 103)
Me.GBDomPetNames.Name = "GBDomPetNames"
Me.GBDomPetNames.Size = New System.Drawing.Size(250, 190)
Me.GBDomPetNames.TabIndex = 134
Me.GBDomPetNames.TabStop = false
Me.GBDomPetNames.Text = "Pet Names"
'
'Label74
'
Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label74.ForeColor = System.Drawing.Color.Black
Me.Label74.Location = New System.Drawing.Point(8, 14)
Me.Label74.Name = "Label74"
Me.Label74.Size = New System.Drawing.Size(233, 13)
Me.Label74.TabIndex = 45
Me.Label74.Text = "Great Mood"
Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'petnameBox7
'
Me.petnameBox7.BackColor = System.Drawing.Color.White
Me.petnameBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox7.ForeColor = System.Drawing.Color.Black
Me.petnameBox7.Location = New System.Drawing.Point(8, 154)
Me.petnameBox7.Name = "petnameBox7"
Me.petnameBox7.Size = New System.Drawing.Size(114, 23)
Me.petnameBox7.TabIndex = 13
Me.petnameBox7.Text = "bitch boy"
Me.petnameBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'petnameBox8
'
Me.petnameBox8.BackColor = System.Drawing.Color.White
Me.petnameBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox8.ForeColor = System.Drawing.Color.Black
Me.petnameBox8.Location = New System.Drawing.Point(128, 154)
Me.petnameBox8.Name = "petnameBox8"
Me.petnameBox8.Size = New System.Drawing.Size(113, 22)
Me.petnameBox8.TabIndex = 14
Me.petnameBox8.Text = "slut"
Me.petnameBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'petnameBox1
'
Me.petnameBox1.BackColor = System.Drawing.Color.White
Me.petnameBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox1.ForeColor = System.Drawing.Color.Black
Me.petnameBox1.Location = New System.Drawing.Point(8, 32)
Me.petnameBox1.Name = "petnameBox1"
Me.petnameBox1.Size = New System.Drawing.Size(114, 23)
Me.petnameBox1.TabIndex = 7
Me.petnameBox1.Text = "stroker"
Me.petnameBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label15.ForeColor = System.Drawing.Color.Black
Me.Label15.Location = New System.Drawing.Point(8, 136)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(233, 13)
Me.Label15.TabIndex = 44
Me.Label15.Text = "Bad Mood"
Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'petnameBox4
'
Me.petnameBox4.BackColor = System.Drawing.Color.White
Me.petnameBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox4.ForeColor = System.Drawing.Color.Black
Me.petnameBox4.Location = New System.Drawing.Point(128, 81)
Me.petnameBox4.Name = "petnameBox4"
Me.petnameBox4.Size = New System.Drawing.Size(113, 23)
Me.petnameBox4.TabIndex = 10
Me.petnameBox4.Text = "loser"
Me.petnameBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'petnameBox6
'
Me.petnameBox6.BackColor = System.Drawing.Color.White
Me.petnameBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox6.ForeColor = System.Drawing.Color.Black
Me.petnameBox6.Location = New System.Drawing.Point(128, 107)
Me.petnameBox6.Name = "petnameBox6"
Me.petnameBox6.Size = New System.Drawing.Size(113, 23)
Me.petnameBox6.TabIndex = 12
Me.petnameBox6.Text = "pet"
Me.petnameBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'petnameBox2
'
Me.petnameBox2.BackColor = System.Drawing.Color.White
Me.petnameBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox2.ForeColor = System.Drawing.Color.Black
Me.petnameBox2.Location = New System.Drawing.Point(128, 32)
Me.petnameBox2.Name = "petnameBox2"
Me.petnameBox2.Size = New System.Drawing.Size(114, 23)
Me.petnameBox2.TabIndex = 8
Me.petnameBox2.Text = "wanker"
Me.petnameBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label11.ForeColor = System.Drawing.Color.Black
Me.Label11.Location = New System.Drawing.Point(5, 63)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(239, 13)
Me.Label11.TabIndex = 43
Me.Label11.Text = "Neutral Mood"
Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'petnameBox5
'
Me.petnameBox5.BackColor = System.Drawing.Color.White
Me.petnameBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox5.ForeColor = System.Drawing.Color.Black
Me.petnameBox5.Location = New System.Drawing.Point(8, 107)
Me.petnameBox5.Name = "petnameBox5"
Me.petnameBox5.Size = New System.Drawing.Size(114, 23)
Me.petnameBox5.TabIndex = 11
Me.petnameBox5.Text = "baby"
Me.petnameBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'petnameBox3
'
Me.petnameBox3.BackColor = System.Drawing.Color.White
Me.petnameBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.petnameBox3.ForeColor = System.Drawing.Color.Black
Me.petnameBox3.Location = New System.Drawing.Point(8, 81)
Me.petnameBox3.Name = "petnameBox3"
Me.petnameBox3.Size = New System.Drawing.Size(114, 23)
Me.petnameBox3.TabIndex = 9
Me.petnameBox3.Text = "slave"
Me.petnameBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label54
'
Me.Label54.BackColor = System.Drawing.Color.Transparent
Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label54.ForeColor = System.Drawing.Color.Black
Me.Label54.Location = New System.Drawing.Point(7, 6)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(692, 21)
Me.Label54.TabIndex = 49
Me.Label54.Text = "Domme Settings"
Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage10
'
Me.TabPage10.BackColor = System.Drawing.Color.Silver
Me.TabPage10.Controls.Add(Me.Panel2)
Me.TabPage10.Location = New System.Drawing.Point(4, 22)
Me.TabPage10.Name = "TabPage10"
Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage10.Size = New System.Drawing.Size(720, 448)
Me.TabPage10.TabIndex = 9
Me.TabPage10.Text = "Sub"
'
'Panel2
'
Me.Panel2.BackColor = System.Drawing.Color.LightGray
Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel2.Controls.Add(Me.GroupBox22)
Me.Panel2.Controls.Add(Me.GroupBox45)
Me.Panel2.Controls.Add(Me.GroupBox6)
Me.Panel2.Controls.Add(Me.GroupBox35)
Me.Panel2.Controls.Add(Me.GroupBox13)
Me.Panel2.Controls.Add(Me.GroupBox7)
Me.Panel2.Controls.Add(Me.PictureBox12)
Me.Panel2.Controls.Add(Me.GroupBox32)
Me.Panel2.Controls.Add(Me.Label70)
Me.Panel2.Location = New System.Drawing.Point(6, 6)
Me.Panel2.Name = "Panel2"
Me.Panel2.Size = New System.Drawing.Size(708, 437)
Me.Panel2.TabIndex = 94
'
'GroupBox22
'
Me.GroupBox22.BackColor = System.Drawing.Color.LightGray
Me.GroupBox22.Controls.Add(Me.NBWritingTaskMax)
Me.GroupBox22.Controls.Add(Me.NBWritingTaskMin)
Me.GroupBox22.Controls.Add(Me.Label75)
Me.GroupBox22.Controls.Add(Me.Label77)
Me.GroupBox22.ForeColor = System.Drawing.Color.Black
Me.GroupBox22.Location = New System.Drawing.Point(440, 388)
Me.GroupBox22.Name = "GroupBox22"
Me.GroupBox22.Size = New System.Drawing.Size(259, 39)
Me.GroupBox22.TabIndex = 158
Me.GroupBox22.TabStop = false
Me.GroupBox22.Text = "Writing Tasks"
'
'NBWritingTaskMax
'
Me.NBWritingTaskMax.Increment = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBWritingTaskMax.Location = New System.Drawing.Point(200, 13)
Me.NBWritingTaskMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
Me.NBWritingTaskMax.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBWritingTaskMax.Name = "NBWritingTaskMax"
Me.NBWritingTaskMax.Size = New System.Drawing.Size(44, 20)
Me.NBWritingTaskMax.TabIndex = 168
Me.NBWritingTaskMax.Value = New Decimal(New Integer() {20, 0, 0, 0})
'
'NBWritingTaskMin
'
Me.NBWritingTaskMin.Increment = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBWritingTaskMin.Location = New System.Drawing.Point(134, 13)
Me.NBWritingTaskMin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
Me.NBWritingTaskMin.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBWritingTaskMin.Name = "NBWritingTaskMin"
Me.NBWritingTaskMin.Size = New System.Drawing.Size(44, 20)
Me.NBWritingTaskMin.TabIndex = 167
Me.NBWritingTaskMin.Value = New Decimal(New Integer() {10, 0, 0, 0})
'
'Label75
'
Me.Label75.BackColor = System.Drawing.Color.Transparent
Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label75.ForeColor = System.Drawing.Color.Black
Me.Label75.Location = New System.Drawing.Point(184, 13)
Me.Label75.Name = "Label75"
Me.Label75.Size = New System.Drawing.Size(10, 17)
Me.Label75.TabIndex = 166
Me.Label75.Text = "-"
Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label77
'
Me.Label77.BackColor = System.Drawing.Color.Transparent
Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label77.ForeColor = System.Drawing.Color.Black
Me.Label77.Location = New System.Drawing.Point(12, 15)
Me.Label77.Name = "Label77"
Me.Label77.Size = New System.Drawing.Size(126, 17)
Me.Label77.TabIndex = 165
Me.Label77.Tag = ""
Me.Label77.Text = "Line Amount Range:"
Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox45
'
Me.GroupBox45.BackColor = System.Drawing.Color.LightGray
Me.GroupBox45.Controls.Add(Me.LBLCBTSlider)
Me.GroupBox45.Controls.Add(Me.CBCBTBalls)
Me.GroupBox45.Controls.Add(Me.CBCBTCock)
Me.GroupBox45.Controls.Add(Me.CBTSlider)
Me.GroupBox45.ForeColor = System.Drawing.Color.Black
Me.GroupBox45.Location = New System.Drawing.Point(440, 332)
Me.GroupBox45.Name = "GroupBox45"
Me.GroupBox45.Size = New System.Drawing.Size(259, 50)
Me.GroupBox45.TabIndex = 155
Me.GroupBox45.TabStop = false
Me.GroupBox45.Text = "CBT"
'
'LBLCBTSlider
'
Me.LBLCBTSlider.BackColor = System.Drawing.Color.Transparent
Me.LBLCBTSlider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLCBTSlider.ForeColor = System.Drawing.Color.Black
Me.LBLCBTSlider.Location = New System.Drawing.Point(134, 30)
Me.LBLCBTSlider.Name = "LBLCBTSlider"
Me.LBLCBTSlider.Size = New System.Drawing.Size(110, 17)
Me.LBLCBTSlider.TabIndex = 168
Me.LBLCBTSlider.Text = "CBT Level: 3"
Me.LBLCBTSlider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBCBTBalls
'
Me.CBCBTBalls.Location = New System.Drawing.Point(69, 13)
Me.CBCBTBalls.Name = "CBCBTBalls"
Me.CBCBTBalls.Size = New System.Drawing.Size(66, 31)
Me.CBCBTBalls.TabIndex = 1
Me.CBCBTBalls.Text = "Ball Torture"
Me.CBCBTBalls.UseVisualStyleBackColor = true
'
'CBCBTCock
'
Me.CBCBTCock.Location = New System.Drawing.Point(9, 13)
Me.CBCBTCock.Name = "CBCBTCock"
Me.CBCBTCock.Size = New System.Drawing.Size(68, 31)
Me.CBCBTCock.TabIndex = 0
Me.CBCBTCock.Text = "Cock Torture"
Me.CBCBTCock.UseVisualStyleBackColor = true
'
'CBTSlider
'
Me.CBTSlider.AutoSize = false
Me.CBTSlider.LargeChange = 1
Me.CBTSlider.Location = New System.Drawing.Point(134, 13)
Me.CBTSlider.Maximum = 5
Me.CBTSlider.Minimum = 1
Me.CBTSlider.Name = "CBTSlider"
Me.CBTSlider.Size = New System.Drawing.Size(110, 25)
Me.CBTSlider.TabIndex = 166
Me.CBTSlider.Value = 3
'
'GroupBox35
'
Me.GroupBox35.BackColor = System.Drawing.Color.LightGray
Me.GroupBox35.Controls.Add(Me.GroupBoxSorry)
Me.GroupBox35.Controls.Add(Me.GroupBox39)
Me.GroupBox35.Controls.Add(Me.GroupBox38)
Me.GroupBox35.Controls.Add(Me.GroupBox37)
Me.GroupBox35.Controls.Add(Me.GroupBox36)
Me.GroupBox35.ForeColor = System.Drawing.Color.Black
Me.GroupBox35.Location = New System.Drawing.Point(440, 30)
Me.GroupBox35.Name = "GroupBox35"
Me.GroupBox35.Size = New System.Drawing.Size(259, 296)
Me.GroupBox35.TabIndex = 154
Me.GroupBox35.TabStop = false
Me.GroupBox35.Text = "Key Phrases"
'
'GroupBoxSorry
'
Me.GroupBoxSorry.Controls.Add(Me.TBSorry)
Me.GroupBoxSorry.Location = New System.Drawing.Point(6, 158)
Me.GroupBoxSorry.Name = "GroupBoxSorry"
Me.GroupBoxSorry.Size = New System.Drawing.Size(247, 46)
Me.GroupBoxSorry.TabIndex = 3
Me.GroupBoxSorry.TabStop = false
Me.GroupBoxSorry.Tag = ""
Me.GroupBoxSorry.Text = "Sorry"
'
'TBSorry
'
Me.TBSorry.Location = New System.Drawing.Point(9, 16)
Me.TBSorry.Name = "TBSorry"
Me.TBSorry.Size = New System.Drawing.Size(229, 20)
Me.TBSorry.TabIndex = 0
Me.TBSorry.Text = "sorry, apologize, excuse"
'
'GroupBox39
'
Me.GroupBox39.Controls.Add(Me.CBHonorificInclude)
Me.GroupBox39.Controls.Add(Me.CBHonorificCapitalized)
Me.GroupBox39.Controls.Add(Me.TBHonorific)
Me.GroupBox39.Location = New System.Drawing.Point(6, 206)
Me.GroupBox39.Name = "GroupBox39"
Me.GroupBox39.Size = New System.Drawing.Size(247, 82)
Me.GroupBox39.TabIndex = 3
Me.GroupBox39.TabStop = false
Me.GroupBox39.Tag = ""
Me.GroupBox39.Text = "Honorific"
'
'CBHonorificInclude
'
Me.CBHonorificInclude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBHonorificInclude.ForeColor = System.Drawing.Color.Black
Me.CBHonorificInclude.Location = New System.Drawing.Point(9, 39)
Me.CBHonorificInclude.Name = "CBHonorificInclude"
Me.CBHonorificInclude.Size = New System.Drawing.Size(234, 21)
Me.CBHonorificInclude.TabIndex = 40
Me.CBHonorificInclude.Text = "Honorific Must Be Included w/ Key Phrases"
Me.CBHonorificInclude.UseVisualStyleBackColor = true
'
'CBHonorificCapitalized
'
Me.CBHonorificCapitalized.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBHonorificCapitalized.ForeColor = System.Drawing.Color.Black
Me.CBHonorificCapitalized.Location = New System.Drawing.Point(9, 60)
Me.CBHonorificCapitalized.Name = "CBHonorificCapitalized"
Me.CBHonorificCapitalized.Size = New System.Drawing.Size(179, 21)
Me.CBHonorificCapitalized.TabIndex = 39
Me.CBHonorificCapitalized.Text = "Honorific Must Be Capitalized"
Me.CBHonorificCapitalized.UseVisualStyleBackColor = true
'
'TBHonorific
'
Me.TBHonorific.Location = New System.Drawing.Point(9, 16)
Me.TBHonorific.Name = "TBHonorific"
Me.TBHonorific.Size = New System.Drawing.Size(229, 20)
Me.TBHonorific.TabIndex = 0
Me.TBHonorific.Text = "Mistress"
'
'GroupBox38
'
Me.GroupBox38.Controls.Add(Me.TBNo)
Me.GroupBox38.Location = New System.Drawing.Point(6, 110)
Me.GroupBox38.Name = "GroupBox38"
Me.GroupBox38.Size = New System.Drawing.Size(247, 46)
Me.GroupBox38.TabIndex = 2
Me.GroupBox38.TabStop = false
Me.GroupBox38.Tag = ""
Me.GroupBox38.Text = "No"
'
'TBNo
'
Me.TBNo.Location = New System.Drawing.Point(9, 16)
Me.TBNo.Name = "TBNo"
Me.TBNo.Size = New System.Drawing.Size(229, 20)
Me.TBNo.TabIndex = 0
Me.TBNo.Text = "no, nah, nope"
'
'GroupBox37
'
Me.GroupBox37.Controls.Add(Me.TBYes)
Me.GroupBox37.Location = New System.Drawing.Point(6, 62)
Me.GroupBox37.Name = "GroupBox37"
Me.GroupBox37.Size = New System.Drawing.Size(247, 46)
Me.GroupBox37.TabIndex = 1
Me.GroupBox37.TabStop = false
Me.GroupBox37.Tag = ""
Me.GroupBox37.Text = "Yes"
'
'TBYes
'
Me.TBYes.Location = New System.Drawing.Point(9, 16)
Me.TBYes.Name = "TBYes"
Me.TBYes.Size = New System.Drawing.Size(229, 20)
Me.TBYes.TabIndex = 0
Me.TBYes.Text = "yes, yeah, yep, yup, sure, of course, absolutely, you know it"
'
'GroupBox36
'
Me.GroupBox36.Controls.Add(Me.TBGreeting)
Me.GroupBox36.Location = New System.Drawing.Point(6, 14)
Me.GroupBox36.Name = "GroupBox36"
Me.GroupBox36.Size = New System.Drawing.Size(247, 46)
Me.GroupBox36.TabIndex = 0
Me.GroupBox36.TabStop = false
Me.GroupBox36.Tag = ""
Me.GroupBox36.Text = "Greeting"
'
'TBGreeting
'
Me.TBGreeting.Location = New System.Drawing.Point(9, 16)
Me.TBGreeting.Name = "TBGreeting"
Me.TBGreeting.Size = New System.Drawing.Size(229, 20)
Me.TBGreeting.TabIndex = 0
Me.TBGreeting.Text = "hello, hi, hey, heya, good morning, good afternoon, good evening"
'
'GroupBox13
'
Me.GroupBox13.BackColor = System.Drawing.Color.LightGray
Me.GroupBox13.Controls.Add(Me.Label34)
Me.GroupBox13.Controls.Add(Me.TimeBoxWakeUp)
Me.GroupBox13.ForeColor = System.Drawing.Color.Black
Me.GroupBox13.Location = New System.Drawing.Point(239, 388)
Me.GroupBox13.Name = "GroupBox13"
Me.GroupBox13.Size = New System.Drawing.Size(195, 39)
Me.GroupBox13.TabIndex = 157
Me.GroupBox13.TabStop = false
Me.GroupBox13.Text = "Routine"
'
'Label34
'
Me.Label34.BackColor = System.Drawing.Color.Transparent
Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label34.ForeColor = System.Drawing.Color.Black
Me.Label34.Location = New System.Drawing.Point(12, 15)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(83, 17)
Me.Label34.TabIndex = 140
Me.Label34.Text = "Wake Up Time:"
Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TimeBoxWakeUp
'
Me.TimeBoxWakeUp.Format = System.Windows.Forms.DateTimePickerFormat.Time
Me.TimeBoxWakeUp.Location = New System.Drawing.Point(92, 13)
Me.TimeBoxWakeUp.Name = "TimeBoxWakeUp"
Me.TimeBoxWakeUp.ShowUpDown = true
Me.TimeBoxWakeUp.Size = New System.Drawing.Size(97, 20)
Me.TimeBoxWakeUp.TabIndex = 0
'
'GroupBox7
'
Me.GroupBox7.Controls.Add(Me.LBLMaxExtremeHold)
Me.GroupBox7.Controls.Add(Me.LBLMinExtremeHold)
Me.GroupBox7.Controls.Add(Me.NBExtremeHoldMin)
Me.GroupBox7.Controls.Add(Me.Label133)
Me.GroupBox7.Controls.Add(Me.NBExtremeHoldMax)
Me.GroupBox7.Controls.Add(Me.LBLMaxLongHold)
Me.GroupBox7.Controls.Add(Me.Label78)
Me.GroupBox7.Controls.Add(Me.LBLMinLongHold)
Me.GroupBox7.Controls.Add(Me.NBLongHoldMin)
Me.GroupBox7.Controls.Add(Me.Label129)
Me.GroupBox7.Controls.Add(Me.NBLongHoldMax)
Me.GroupBox7.Controls.Add(Me.LBLMaxHold)
Me.GroupBox7.Controls.Add(Me.Label79)
Me.GroupBox7.Controls.Add(Me.NBLongEdge)
Me.GroupBox7.Controls.Add(Me.LBLMinHold)
Me.GroupBox7.Controls.Add(Me.CBEdgeUseAvg)
Me.GroupBox7.Controls.Add(Me.CBLongEdgeInterrupts)
Me.GroupBox7.Controls.Add(Me.NBHoldTheEdgeMin)
Me.GroupBox7.Controls.Add(Me.Label55)
Me.GroupBox7.Controls.Add(Me.Label81)
Me.GroupBox7.Controls.Add(Me.Label5)
Me.GroupBox7.Controls.Add(Me.NBHoldTheEdgeMax)
Me.GroupBox7.Controls.Add(Me.CBLongEdgeTaunts)
Me.GroupBox7.Controls.Add(Me.Label131)
Me.GroupBox7.Location = New System.Drawing.Point(7, 201)
Me.GroupBox7.Name = "GroupBox7"
Me.GroupBox7.Size = New System.Drawing.Size(226, 226)
Me.GroupBox7.TabIndex = 152
Me.GroupBox7.TabStop = false
Me.GroupBox7.Text = "Edging"
'
'LBLMaxExtremeHold
'
Me.LBLMaxExtremeHold.AutoSize = true
Me.LBLMaxExtremeHold.Location = New System.Drawing.Point(173, 128)
Me.LBLMaxExtremeHold.Name = "LBLMaxExtremeHold"
Me.LBLMaxExtremeHold.Size = New System.Drawing.Size(43, 13)
Me.LBLMaxExtremeHold.TabIndex = 192
Me.LBLMaxExtremeHold.Text = "minutes"
Me.LBLMaxExtremeHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLMinExtremeHold
'
Me.LBLMinExtremeHold.AutoSize = true
Me.LBLMinExtremeHold.Location = New System.Drawing.Point(173, 106)
Me.LBLMinExtremeHold.Name = "LBLMinExtremeHold"
Me.LBLMinExtremeHold.Size = New System.Drawing.Size(43, 13)
Me.LBLMinExtremeHold.TabIndex = 190
Me.LBLMinExtremeHold.Text = "minutes"
Me.LBLMinExtremeHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBExtremeHoldMin
'
Me.NBExtremeHoldMin.Location = New System.Drawing.Point(128, 104)
Me.NBExtremeHoldMin.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBExtremeHoldMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBExtremeHoldMin.Name = "NBExtremeHoldMin"
Me.NBExtremeHoldMin.Size = New System.Drawing.Size(44, 20)
Me.NBExtremeHoldMin.TabIndex = 189
Me.NBExtremeHoldMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'Label133
'
Me.Label133.BackColor = System.Drawing.Color.Transparent
Me.Label133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label133.ForeColor = System.Drawing.Color.Black
Me.Label133.Location = New System.Drawing.Point(6, 105)
Me.Label133.Name = "Label133"
Me.Label133.Size = New System.Drawing.Size(119, 17)
Me.Label133.TabIndex = 187
Me.Label133.Text = "Min Extreme Hold Time:"
Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBExtremeHoldMax
'
Me.NBExtremeHoldMax.Location = New System.Drawing.Point(128, 126)
Me.NBExtremeHoldMax.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBExtremeHoldMax.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
Me.NBExtremeHoldMax.Name = "NBExtremeHoldMax"
Me.NBExtremeHoldMax.Size = New System.Drawing.Size(44, 20)
Me.NBExtremeHoldMax.TabIndex = 188
Me.NBExtremeHoldMax.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'LBLMaxLongHold
'
Me.LBLMaxLongHold.AutoSize = true
Me.LBLMaxLongHold.Location = New System.Drawing.Point(173, 84)
Me.LBLMaxLongHold.Name = "LBLMaxLongHold"
Me.LBLMaxLongHold.Size = New System.Drawing.Size(43, 13)
Me.LBLMaxLongHold.TabIndex = 186
Me.LBLMaxLongHold.Text = "minutes"
Me.LBLMaxLongHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label78
'
Me.Label78.BackColor = System.Drawing.Color.Transparent
Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label78.ForeColor = System.Drawing.Color.Black
Me.Label78.Location = New System.Drawing.Point(6, 83)
Me.Label78.Name = "Label78"
Me.Label78.Size = New System.Drawing.Size(113, 17)
Me.Label78.TabIndex = 185
Me.Label78.Text = "Max Long Hold Time:"
Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLMinLongHold
'
Me.LBLMinLongHold.AutoSize = true
Me.LBLMinLongHold.Location = New System.Drawing.Point(173, 62)
Me.LBLMinLongHold.Name = "LBLMinLongHold"
Me.LBLMinLongHold.Size = New System.Drawing.Size(43, 13)
Me.LBLMinLongHold.TabIndex = 184
Me.LBLMinLongHold.Text = "minutes"
Me.LBLMinLongHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBLongHoldMin
'
Me.NBLongHoldMin.Location = New System.Drawing.Point(128, 60)
Me.NBLongHoldMin.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBLongHoldMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBLongHoldMin.Name = "NBLongHoldMin"
Me.NBLongHoldMin.Size = New System.Drawing.Size(44, 20)
Me.NBLongHoldMin.TabIndex = 183
Me.NBLongHoldMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'Label129
'
Me.Label129.BackColor = System.Drawing.Color.Transparent
Me.Label129.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label129.ForeColor = System.Drawing.Color.Black
Me.Label129.Location = New System.Drawing.Point(6, 61)
Me.Label129.Name = "Label129"
Me.Label129.Size = New System.Drawing.Size(113, 17)
Me.Label129.TabIndex = 181
Me.Label129.Text = "Min Long Hold Time:"
Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBLongHoldMax
'
Me.NBLongHoldMax.Location = New System.Drawing.Point(128, 82)
Me.NBLongHoldMax.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBLongHoldMax.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
Me.NBLongHoldMax.Name = "NBLongHoldMax"
Me.NBLongHoldMax.Size = New System.Drawing.Size(44, 20)
Me.NBLongHoldMax.TabIndex = 182
Me.NBLongHoldMax.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'LBLMaxHold
'
Me.LBLMaxHold.AutoSize = true
Me.LBLMaxHold.Location = New System.Drawing.Point(173, 40)
Me.LBLMaxHold.Name = "LBLMaxHold"
Me.LBLMaxHold.Size = New System.Drawing.Size(43, 13)
Me.LBLMaxHold.TabIndex = 180
Me.LBLMaxHold.Text = "minutes"
Me.LBLMaxHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label79
'
Me.Label79.BackColor = System.Drawing.Color.Transparent
Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label79.ForeColor = System.Drawing.Color.Black
Me.Label79.Location = New System.Drawing.Point(6, 39)
Me.Label79.Name = "Label79"
Me.Label79.Size = New System.Drawing.Size(113, 17)
Me.Label79.TabIndex = 178
Me.Label79.Text = "Max Hold Edge Time:"
Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBLongEdge
'
Me.NBLongEdge.Location = New System.Drawing.Point(128, 148)
Me.NBLongEdge.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.NBLongEdge.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBLongEdge.Name = "NBLongEdge"
Me.NBLongEdge.Size = New System.Drawing.Size(44, 20)
Me.NBLongEdge.TabIndex = 152
Me.NBLongEdge.Value = New Decimal(New Integer() {120, 0, 0, 0})
'
'LBLMinHold
'
Me.LBLMinHold.AutoSize = true
Me.LBLMinHold.Location = New System.Drawing.Point(173, 18)
Me.LBLMinHold.Name = "LBLMinHold"
Me.LBLMinHold.Size = New System.Drawing.Size(47, 13)
Me.LBLMinHold.TabIndex = 177
Me.LBLMinHold.Text = "seconds"
Me.LBLMinHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBEdgeUseAvg
'
Me.CBEdgeUseAvg.AutoSize = true
Me.CBEdgeUseAvg.Location = New System.Drawing.Point(9, 170)
Me.CBEdgeUseAvg.Name = "CBEdgeUseAvg"
Me.CBEdgeUseAvg.Size = New System.Drawing.Size(185, 17)
Me.CBEdgeUseAvg.TabIndex = 174
Me.CBEdgeUseAvg.Text = "Use Avg Edge Time as Threshold"
Me.CBEdgeUseAvg.UseVisualStyleBackColor = true
'
'CBLongEdgeInterrupts
'
Me.CBLongEdgeInterrupts.Checked = true
Me.CBLongEdgeInterrupts.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBLongEdgeInterrupts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBLongEdgeInterrupts.ForeColor = System.Drawing.Color.Black
Me.CBLongEdgeInterrupts.Location = New System.Drawing.Point(9, 204)
Me.CBLongEdgeInterrupts.Name = "CBLongEdgeInterrupts"
Me.CBLongEdgeInterrupts.Size = New System.Drawing.Size(177, 21)
Me.CBLongEdgeInterrupts.TabIndex = 169
Me.CBLongEdgeInterrupts.Text = "Allow Long Edge Interrupts"
Me.CBLongEdgeInterrupts.UseVisualStyleBackColor = true
'
'NBHoldTheEdgeMin
'
Me.NBHoldTheEdgeMin.Location = New System.Drawing.Point(128, 16)
Me.NBHoldTheEdgeMin.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBHoldTheEdgeMin.Name = "NBHoldTheEdgeMin"
Me.NBHoldTheEdgeMin.Size = New System.Drawing.Size(44, 20)
Me.NBHoldTheEdgeMin.TabIndex = 176
Me.NBHoldTheEdgeMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'Label55
'
Me.Label55.BackColor = System.Drawing.Color.Transparent
Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label55.ForeColor = System.Drawing.Color.Black
Me.Label55.Location = New System.Drawing.Point(7, 149)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(116, 17)
Me.Label55.TabIndex = 170
Me.Label55.Text = "Long Edge Threshold:"
Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label81
'
Me.Label81.BackColor = System.Drawing.Color.Transparent
Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label81.ForeColor = System.Drawing.Color.Black
Me.Label81.Location = New System.Drawing.Point(6, 17)
Me.Label81.Name = "Label81"
Me.Label81.Size = New System.Drawing.Size(113, 17)
Me.Label81.TabIndex = 153
Me.Label81.Text = "Min Hold Edge Time:"
Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label5
'
Me.Label5.AutoSize = true
Me.Label5.Location = New System.Drawing.Point(174, 151)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(43, 13)
Me.Label5.TabIndex = 175
Me.Label5.Text = "minutes"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'NBHoldTheEdgeMax
'
Me.NBHoldTheEdgeMax.Location = New System.Drawing.Point(128, 38)
Me.NBHoldTheEdgeMax.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
Me.NBHoldTheEdgeMax.Name = "NBHoldTheEdgeMax"
Me.NBHoldTheEdgeMax.Size = New System.Drawing.Size(44, 20)
Me.NBHoldTheEdgeMax.TabIndex = 155
Me.NBHoldTheEdgeMax.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'CBLongEdgeTaunts
'
Me.CBLongEdgeTaunts.Checked = true
Me.CBLongEdgeTaunts.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBLongEdgeTaunts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBLongEdgeTaunts.ForeColor = System.Drawing.Color.Black
Me.CBLongEdgeTaunts.Location = New System.Drawing.Point(9, 186)
Me.CBLongEdgeTaunts.Name = "CBLongEdgeTaunts"
Me.CBLongEdgeTaunts.Size = New System.Drawing.Size(163, 21)
Me.CBLongEdgeTaunts.TabIndex = 172
Me.CBLongEdgeTaunts.Text = "Allow Long Edge Taunts"
Me.CBLongEdgeTaunts.UseVisualStyleBackColor = true
'
'Label131
'
Me.Label131.BackColor = System.Drawing.Color.Transparent
Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label131.ForeColor = System.Drawing.Color.Black
Me.Label131.Location = New System.Drawing.Point(6, 127)
Me.Label131.Name = "Label131"
Me.Label131.Size = New System.Drawing.Size(128, 17)
Me.Label131.TabIndex = 191
Me.Label131.Text = "Max Extreme Hold Time:"
Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'PictureBox12
'
Me.PictureBox12.BackColor = System.Drawing.Color.LightGray
Me.PictureBox12.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox12.Location = New System.Drawing.Point(9, 6)
Me.PictureBox12.Name = "PictureBox12"
Me.PictureBox12.Size = New System.Drawing.Size(160, 19)
Me.PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox12.TabIndex = 149
Me.PictureBox12.TabStop = false
'
'GroupBox32
'
Me.GroupBox32.BackColor = System.Drawing.Color.LightGray
Me.GroupBox32.Controls.Add(Me.LBLSubBdayFormat)
Me.GroupBox32.Controls.Add(Me.CBChastitySpikes)
Me.GroupBox32.Controls.Add(Me.CBOwnChastity)
Me.GroupBox32.Controls.Add(Me.CBChastityPA)
Me.GroupBox32.Controls.Add(Me.CBHimHer)
Me.GroupBox32.Controls.Add(Me.CBBallsToPussy)
Me.GroupBox32.Controls.Add(Me.CBCockToClit)
Me.GroupBox32.Controls.Add(Me.NBBirthdayDay)
Me.GroupBox32.Controls.Add(Me.CBSubCircumcised)
Me.GroupBox32.Controls.Add(Me.CBSubPierced)
Me.GroupBox32.Controls.Add(Me.TBSubEyeColor)
Me.GroupBox32.Controls.Add(Me.TBSubHairColor)
Me.GroupBox32.Controls.Add(Me.Label63)
Me.GroupBox32.Controls.Add(Me.LBLSubInches)
Me.GroupBox32.Controls.Add(Me.subAgeNumBox)
Me.GroupBox32.Controls.Add(Me.NBBirthdayMonth)
Me.GroupBox32.Controls.Add(Me.LBLSubCockSize)
Me.GroupBox32.Controls.Add(Me.CockSizeNumBox)
Me.GroupBox32.Controls.Add(Me.LBLSubEye)
Me.GroupBox32.Controls.Add(Me.LBLSubHair)
Me.GroupBox32.Controls.Add(Me.LBLSubBirthday)
Me.GroupBox32.Controls.Add(Me.LBLSubAge)
Me.GroupBox32.ForeColor = System.Drawing.Color.Black
Me.GroupBox32.Location = New System.Drawing.Point(7, 30)
Me.GroupBox32.Name = "GroupBox32"
Me.GroupBox32.Size = New System.Drawing.Size(427, 165)
Me.GroupBox32.TabIndex = 62
Me.GroupBox32.TabStop = false
Me.GroupBox32.Text = "Personal Information"
'
'LBLSubBdayFormat
'
Me.LBLSubBdayFormat.AutoSize = true
Me.LBLSubBdayFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubBdayFormat.Location = New System.Drawing.Point(125, 22)
Me.LBLSubBdayFormat.Name = "LBLSubBdayFormat"
Me.LBLSubBdayFormat.Size = New System.Drawing.Size(38, 13)
Me.LBLSubBdayFormat.TabIndex = 161
Me.LBLSubBdayFormat.Text = "mm/dd"
Me.LBLSubBdayFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBChastitySpikes
'
Me.CBChastitySpikes.AutoSize = true
Me.CBChastitySpikes.Enabled = false
Me.CBChastitySpikes.Location = New System.Drawing.Point(191, 140)
Me.CBChastitySpikes.Name = "CBChastitySpikes"
Me.CBChastitySpikes.Size = New System.Drawing.Size(179, 17)
Me.CBChastitySpikes.TabIndex = 4
Me.CBChastitySpikes.Text = "Chastity Device Contains Spikes"
Me.CBChastitySpikes.UseVisualStyleBackColor = true
'
'CBOwnChastity
'
Me.CBOwnChastity.AutoSize = true
Me.CBOwnChastity.Location = New System.Drawing.Point(191, 90)
Me.CBOwnChastity.Name = "CBOwnChastity"
Me.CBOwnChastity.Size = New System.Drawing.Size(171, 17)
Me.CBOwnChastity.TabIndex = 5
Me.CBOwnChastity.Text = "Own Device a Chastity Device"
Me.CBOwnChastity.UseVisualStyleBackColor = true
'
'CBChastityPA
'
Me.CBChastityPA.AutoSize = true
Me.CBChastityPA.Enabled = false
Me.CBChastityPA.Location = New System.Drawing.Point(191, 115)
Me.CBChastityPA.Name = "CBChastityPA"
Me.CBChastityPA.Size = New System.Drawing.Size(195, 17)
Me.CBChastityPA.TabIndex = 3
Me.CBChastityPA.Text = "Chastity Device Requires a Piercing"
Me.CBChastityPA.UseVisualStyleBackColor = true
'
'CBHimHer
'
Me.CBHimHer.AutoSize = true
Me.CBHimHer.Location = New System.Drawing.Point(191, 65)
Me.CBHimHer.Name = "CBHimHer"
Me.CBHimHer.Size = New System.Drawing.Size(219, 17)
Me.CBHimHer.TabIndex = 3
Me.CBHimHer.Text = "Replace Male Glitter Pronouns to Female"
Me.CBHimHer.UseVisualStyleBackColor = true
'
'CBBallsToPussy
'
Me.CBBallsToPussy.AutoSize = true
Me.CBBallsToPussy.Location = New System.Drawing.Point(191, 40)
Me.CBBallsToPussy.Name = "CBBallsToPussy"
Me.CBBallsToPussy.Size = New System.Drawing.Size(193, 17)
Me.CBBallsToPussy.TabIndex = 160
Me.CBBallsToPussy.Text = "Replace #Balls with #BallsToPussy"
Me.CBBallsToPussy.UseVisualStyleBackColor = true
'
'CBCockToClit
'
Me.CBCockToClit.AutoSize = true
Me.CBCockToClit.Location = New System.Drawing.Point(191, 15)
Me.CBCockToClit.Name = "CBCockToClit"
Me.CBCockToClit.Size = New System.Drawing.Size(185, 17)
Me.CBCockToClit.TabIndex = 159
Me.CBCockToClit.Text = "Replace #Cock with #CockToClit"
Me.CBCockToClit.UseVisualStyleBackColor = true
'
'NBBirthdayDay
'
Me.NBBirthdayDay.BackColor = System.Drawing.Color.White
Me.NBBirthdayDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBBirthdayDay.ForeColor = System.Drawing.Color.Black
Me.NBBirthdayDay.Location = New System.Drawing.Point(125, 37)
Me.NBBirthdayDay.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
Me.NBBirthdayDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBBirthdayDay.Name = "NBBirthdayDay"
Me.NBBirthdayDay.Size = New System.Drawing.Size(38, 20)
Me.NBBirthdayDay.TabIndex = 144
Me.NBBirthdayDay.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'CBSubCircumcised
'
Me.CBSubCircumcised.AutoSize = true
Me.CBSubCircumcised.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBSubCircumcised.ForeColor = System.Drawing.Color.Black
Me.CBSubCircumcised.Location = New System.Drawing.Point(9, 138)
Me.CBSubCircumcised.Name = "CBSubCircumcised"
Me.CBSubCircumcised.Size = New System.Drawing.Size(83, 17)
Me.CBSubCircumcised.TabIndex = 157
Me.CBSubCircumcised.Text = "Circumcised"
Me.CBSubCircumcised.UseVisualStyleBackColor = true
'
'CBSubPierced
'
Me.CBSubPierced.AutoSize = true
Me.CBSubPierced.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBSubPierced.ForeColor = System.Drawing.Color.Black
Me.CBSubPierced.Location = New System.Drawing.Point(98, 138)
Me.CBSubPierced.Name = "CBSubPierced"
Me.CBSubPierced.Size = New System.Drawing.Size(62, 17)
Me.CBSubPierced.TabIndex = 156
Me.CBSubPierced.Text = "Pierced"
Me.CBSubPierced.UseVisualStyleBackColor = true
'
'TBSubEyeColor
'
Me.TBSubEyeColor.BackColor = System.Drawing.Color.White
Me.TBSubEyeColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBSubEyeColor.ForeColor = System.Drawing.Color.Black
Me.TBSubEyeColor.Location = New System.Drawing.Point(73, 87)
Me.TBSubEyeColor.Name = "TBSubEyeColor"
Me.TBSubEyeColor.Size = New System.Drawing.Size(89, 23)
Me.TBSubEyeColor.TabIndex = 155
Me.TBSubEyeColor.Text = "brown"
'
'TBSubHairColor
'
Me.TBSubHairColor.BackColor = System.Drawing.Color.White
Me.TBSubHairColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBSubHairColor.ForeColor = System.Drawing.Color.Black
Me.TBSubHairColor.Location = New System.Drawing.Point(73, 60)
Me.TBSubHairColor.Name = "TBSubHairColor"
Me.TBSubHairColor.Size = New System.Drawing.Size(89, 23)
Me.TBSubHairColor.TabIndex = 154
Me.TBSubHairColor.Text = "brown"
'
'Label63
'
Me.Label63.AutoSize = true
Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label63.ForeColor = System.Drawing.Color.Black
Me.Label63.Location = New System.Drawing.Point(113, 41)
Me.Label63.Name = "Label63"
Me.Label63.Size = New System.Drawing.Size(12, 13)
Me.Label63.TabIndex = 143
Me.Label63.Text = "/"
Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLSubInches
'
Me.LBLSubInches.AutoSize = true
Me.LBLSubInches.Location = New System.Drawing.Point(118, 118)
Me.LBLSubInches.Name = "LBLSubInches"
Me.LBLSubInches.Size = New System.Drawing.Size(38, 13)
Me.LBLSubInches.TabIndex = 124
Me.LBLSubInches.Text = "inches"
Me.LBLSubInches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'subAgeNumBox
'
Me.subAgeNumBox.BackColor = System.Drawing.Color.White
Me.subAgeNumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.subAgeNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.subAgeNumBox.ForeColor = System.Drawing.Color.Black
Me.subAgeNumBox.Location = New System.Drawing.Point(73, 14)
Me.subAgeNumBox.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.subAgeNumBox.Minimum = New Decimal(New Integer() {18, 0, 0, 0})
Me.subAgeNumBox.Name = "subAgeNumBox"
Me.subAgeNumBox.Size = New System.Drawing.Size(38, 20)
Me.subAgeNumBox.TabIndex = 27
Me.subAgeNumBox.Value = New Decimal(New Integer() {21, 0, 0, 0})
'
'NBBirthdayMonth
'
Me.NBBirthdayMonth.BackColor = System.Drawing.Color.White
Me.NBBirthdayMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.NBBirthdayMonth.ForeColor = System.Drawing.Color.Black
Me.NBBirthdayMonth.Location = New System.Drawing.Point(73, 37)
Me.NBBirthdayMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
Me.NBBirthdayMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBBirthdayMonth.Name = "NBBirthdayMonth"
Me.NBBirthdayMonth.Size = New System.Drawing.Size(38, 20)
Me.NBBirthdayMonth.TabIndex = 41
Me.NBBirthdayMonth.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'LBLSubCockSize
'
Me.LBLSubCockSize.BackColor = System.Drawing.Color.Transparent
Me.LBLSubCockSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubCockSize.ForeColor = System.Drawing.Color.Black
Me.LBLSubCockSize.Location = New System.Drawing.Point(6, 114)
Me.LBLSubCockSize.Name = "LBLSubCockSize"
Me.LBLSubCockSize.Size = New System.Drawing.Size(63, 17)
Me.LBLSubCockSize.TabIndex = 142
Me.LBLSubCockSize.Text = "Cock Size:"
Me.LBLSubCockSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'CockSizeNumBox
'
Me.CockSizeNumBox.BackColor = System.Drawing.Color.White
Me.CockSizeNumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CockSizeNumBox.ForeColor = System.Drawing.Color.Black
Me.CockSizeNumBox.Location = New System.Drawing.Point(73, 114)
Me.CockSizeNumBox.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
Me.CockSizeNumBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.CockSizeNumBox.Name = "CockSizeNumBox"
Me.CockSizeNumBox.Size = New System.Drawing.Size(38, 20)
Me.CockSizeNumBox.TabIndex = 123
Me.CockSizeNumBox.Value = New Decimal(New Integer() {5, 0, 0, 0})
'
'LBLSubEye
'
Me.LBLSubEye.BackColor = System.Drawing.Color.Transparent
Me.LBLSubEye.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubEye.ForeColor = System.Drawing.Color.Black
Me.LBLSubEye.Location = New System.Drawing.Point(6, 90)
Me.LBLSubEye.Name = "LBLSubEye"
Me.LBLSubEye.Size = New System.Drawing.Size(63, 17)
Me.LBLSubEye.TabIndex = 141
Me.LBLSubEye.Text = "Eye Color"
Me.LBLSubEye.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLSubHair
'
Me.LBLSubHair.BackColor = System.Drawing.Color.Transparent
Me.LBLSubHair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubHair.ForeColor = System.Drawing.Color.Black
Me.LBLSubHair.Location = New System.Drawing.Point(6, 63)
Me.LBLSubHair.Name = "LBLSubHair"
Me.LBLSubHair.Size = New System.Drawing.Size(78, 17)
Me.LBLSubHair.TabIndex = 140
Me.LBLSubHair.Text = "Hair Color"
Me.LBLSubHair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLSubBirthday
'
Me.LBLSubBirthday.BackColor = System.Drawing.Color.Transparent
Me.LBLSubBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubBirthday.ForeColor = System.Drawing.Color.Black
Me.LBLSubBirthday.Location = New System.Drawing.Point(6, 37)
Me.LBLSubBirthday.Name = "LBLSubBirthday"
Me.LBLSubBirthday.Size = New System.Drawing.Size(60, 17)
Me.LBLSubBirthday.TabIndex = 139
Me.LBLSubBirthday.Text = "Birthday:"
Me.LBLSubBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLSubAge
'
Me.LBLSubAge.BackColor = System.Drawing.Color.Transparent
Me.LBLSubAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubAge.ForeColor = System.Drawing.Color.Black
Me.LBLSubAge.Location = New System.Drawing.Point(6, 15)
Me.LBLSubAge.Name = "LBLSubAge"
Me.LBLSubAge.Size = New System.Drawing.Size(63, 17)
Me.LBLSubAge.TabIndex = 138
Me.LBLSubAge.Text = "Age:"
Me.LBLSubAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label70
'
Me.Label70.BackColor = System.Drawing.Color.Transparent
Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label70.ForeColor = System.Drawing.Color.Black
Me.Label70.Location = New System.Drawing.Point(7, 6)
Me.Label70.Name = "Label70"
Me.Label70.Size = New System.Drawing.Size(692, 21)
Me.Label70.TabIndex = 49
Me.Label70.Text = "Sub Settings"
Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage16
'
Me.TabPage16.BackColor = System.Drawing.Color.Silver
Me.TabPage16.Controls.Add(Me.Panel9)
Me.TabPage16.Location = New System.Drawing.Point(4, 22)
Me.TabPage16.Name = "TabPage16"
Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage16.Size = New System.Drawing.Size(720, 448)
Me.TabPage16.TabIndex = 14
Me.TabPage16.Text = "Scripts"
'
'Panel9
'
Me.Panel9.BackColor = System.Drawing.Color.LightGray
Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel9.Controls.Add(Me.BTNScriptAvailable)
Me.Panel9.Controls.Add(Me.BTNScriptNone)
Me.Panel9.Controls.Add(Me.BTNScriptAll)
Me.Panel9.Controls.Add(Me.BTNScriptOpen)
Me.Panel9.Controls.Add(Me.LBLScriptReq)
Me.Panel9.Controls.Add(Me.GroupBox31)
Me.Panel9.Controls.Add(Me.TCScripts)
Me.Panel9.Controls.Add(Me.GroupBox42)
Me.Panel9.Controls.Add(Me.PictureBox1)
Me.Panel9.Controls.Add(Me.GroupBox43)
Me.Panel9.Controls.Add(Me.Label104)
Me.Panel9.Location = New System.Drawing.Point(6, 6)
Me.Panel9.Name = "Panel9"
Me.Panel9.Size = New System.Drawing.Size(708, 437)
Me.Panel9.TabIndex = 94
'
'BTNScriptAvailable
'
Me.BTNScriptAvailable.Location = New System.Drawing.Point(204, 294)
Me.BTNScriptAvailable.Name = "BTNScriptAvailable"
Me.BTNScriptAvailable.Size = New System.Drawing.Size(100, 23)
Me.BTNScriptAvailable.TabIndex = 160
Me.BTNScriptAvailable.Text = "Select Available"
Me.BTNScriptAvailable.UseVisualStyleBackColor = true
'
'BTNScriptNone
'
Me.BTNScriptNone.Location = New System.Drawing.Point(108, 294)
Me.BTNScriptNone.Name = "BTNScriptNone"
Me.BTNScriptNone.Size = New System.Drawing.Size(75, 23)
Me.BTNScriptNone.TabIndex = 159
Me.BTNScriptNone.Text = "Select None"
Me.BTNScriptNone.UseVisualStyleBackColor = true
'
'BTNScriptAll
'
Me.BTNScriptAll.Location = New System.Drawing.Point(13, 294)
Me.BTNScriptAll.Name = "BTNScriptAll"
Me.BTNScriptAll.Size = New System.Drawing.Size(75, 23)
Me.BTNScriptAll.TabIndex = 158
Me.BTNScriptAll.Text = "Select All"
Me.BTNScriptAll.UseVisualStyleBackColor = true
'
'BTNScriptOpen
'
Me.BTNScriptOpen.Location = New System.Drawing.Point(624, 294)
Me.BTNScriptOpen.Name = "BTNScriptOpen"
Me.BTNScriptOpen.Size = New System.Drawing.Size(75, 23)
Me.BTNScriptOpen.TabIndex = 157
Me.BTNScriptOpen.Text = "Open Script"
Me.BTNScriptOpen.UseVisualStyleBackColor = true
'
'LBLScriptReq
'
Me.LBLScriptReq.BackColor = System.Drawing.Color.LightGray
Me.LBLScriptReq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLScriptReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLScriptReq.ForeColor = System.Drawing.Color.Green
Me.LBLScriptReq.Location = New System.Drawing.Point(314, 292)
Me.LBLScriptReq.Name = "LBLScriptReq"
Me.LBLScriptReq.Size = New System.Drawing.Size(300, 27)
Me.LBLScriptReq.TabIndex = 156
Me.LBLScriptReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox31
'
Me.GroupBox31.Controls.Add(Me.RTBScriptReq)
Me.GroupBox31.Location = New System.Drawing.Point(314, 169)
Me.GroupBox31.Name = "GroupBox31"
Me.GroupBox31.Size = New System.Drawing.Size(385, 110)
Me.GroupBox31.TabIndex = 155
Me.GroupBox31.TabStop = false
Me.GroupBox31.Text = "Requirements"
'
'RTBScriptReq
'
Me.RTBScriptReq.Location = New System.Drawing.Point(6, 16)
Me.RTBScriptReq.Name = "RTBScriptReq"
Me.RTBScriptReq.ReadOnly = true
Me.RTBScriptReq.Size = New System.Drawing.Size(373, 85)
Me.RTBScriptReq.TabIndex = 0
Me.RTBScriptReq.Text = ""
'
'TCScripts
'
Me.TCScripts.Controls.Add(Me.TabPage21)
Me.TCScripts.Controls.Add(Me.TabPage17)
Me.TCScripts.Controls.Add(Me.TabPage18)
Me.TCScripts.Controls.Add(Me.TabPage19)
Me.TCScripts.Location = New System.Drawing.Point(9, 31)
Me.TCScripts.Name = "TCScripts"
Me.TCScripts.SelectedIndex = 0
Me.TCScripts.Size = New System.Drawing.Size(299, 248)
Me.TCScripts.TabIndex = 154
'
'TabPage21
'
Me.TabPage21.BackColor = System.Drawing.Color.Silver
Me.TabPage21.Controls.Add(Me.CLBStartList)
Me.TabPage21.Location = New System.Drawing.Point(4, 22)
Me.TabPage21.Name = "TabPage21"
Me.TabPage21.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage21.Size = New System.Drawing.Size(291, 222)
Me.TabPage21.TabIndex = 4
Me.TabPage21.Text = "Start"
'
'CLBStartList
'
Me.CLBStartList.FormattingEnabled = true
Me.CLBStartList.Location = New System.Drawing.Point(4, 4)
Me.CLBStartList.Name = "CLBStartList"
Me.CLBStartList.Size = New System.Drawing.Size(283, 214)
Me.CLBStartList.Sorted = true
Me.CLBStartList.TabIndex = 155
'
'TabPage17
'
Me.TabPage17.BackColor = System.Drawing.Color.Silver
Me.TabPage17.Controls.Add(Me.CLBModuleList)
Me.TabPage17.Location = New System.Drawing.Point(4, 22)
Me.TabPage17.Name = "TabPage17"
Me.TabPage17.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage17.Size = New System.Drawing.Size(291, 222)
Me.TabPage17.TabIndex = 5
Me.TabPage17.Text = "Modules"
'
'CLBModuleList
'
Me.CLBModuleList.FormattingEnabled = true
Me.CLBModuleList.Location = New System.Drawing.Point(4, 4)
Me.CLBModuleList.Name = "CLBModuleList"
Me.CLBModuleList.Size = New System.Drawing.Size(283, 214)
Me.CLBModuleList.Sorted = true
Me.CLBModuleList.TabIndex = 156
'
'TabPage18
'
Me.TabPage18.BackColor = System.Drawing.Color.Silver
Me.TabPage18.Controls.Add(Me.CLBLinkList)
Me.TabPage18.Location = New System.Drawing.Point(4, 22)
Me.TabPage18.Name = "TabPage18"
Me.TabPage18.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage18.Size = New System.Drawing.Size(291, 222)
Me.TabPage18.TabIndex = 6
Me.TabPage18.Text = "Link"
'
'CLBLinkList
'
Me.CLBLinkList.FormattingEnabled = true
Me.CLBLinkList.Location = New System.Drawing.Point(4, 4)
Me.CLBLinkList.Name = "CLBLinkList"
Me.CLBLinkList.Size = New System.Drawing.Size(283, 214)
Me.CLBLinkList.Sorted = true
Me.CLBLinkList.TabIndex = 156
'
'TabPage19
'
Me.TabPage19.BackColor = System.Drawing.Color.Silver
Me.TabPage19.Controls.Add(Me.CLBEndList)
Me.TabPage19.Location = New System.Drawing.Point(4, 22)
Me.TabPage19.Name = "TabPage19"
Me.TabPage19.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage19.Size = New System.Drawing.Size(291, 222)
Me.TabPage19.TabIndex = 7
Me.TabPage19.Text = "End"
'
'CLBEndList
'
Me.CLBEndList.FormattingEnabled = true
Me.CLBEndList.Location = New System.Drawing.Point(4, 4)
Me.CLBEndList.Name = "CLBEndList"
Me.CLBEndList.Size = New System.Drawing.Size(283, 214)
Me.CLBEndList.Sorted = true
Me.CLBEndList.TabIndex = 156
'
'GroupBox42
'
Me.GroupBox42.Controls.Add(Me.RTBScriptDesc)
Me.GroupBox42.Location = New System.Drawing.Point(314, 53)
Me.GroupBox42.Name = "GroupBox42"
Me.GroupBox42.Size = New System.Drawing.Size(385, 110)
Me.GroupBox42.TabIndex = 153
Me.GroupBox42.TabStop = false
Me.GroupBox42.Text = "Description"
'
'RTBScriptDesc
'
Me.RTBScriptDesc.Location = New System.Drawing.Point(6, 16)
Me.RTBScriptDesc.Name = "RTBScriptDesc"
Me.RTBScriptDesc.ReadOnly = true
Me.RTBScriptDesc.Size = New System.Drawing.Size(373, 85)
Me.RTBScriptDesc.TabIndex = 0
Me.RTBScriptDesc.Text = ""
'
'PictureBox1
'
Me.PictureBox1.BackColor = System.Drawing.Color.LightGray
Me.PictureBox1.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox1.Location = New System.Drawing.Point(9, 6)
Me.PictureBox1.Name = "PictureBox1"
Me.PictureBox1.Size = New System.Drawing.Size(160, 19)
Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox1.TabIndex = 151
Me.PictureBox1.TabStop = false
'
'GroupBox43
'
Me.GroupBox43.BackColor = System.Drawing.Color.LightGray
Me.GroupBox43.Controls.Add(Me.Label98)
Me.GroupBox43.ForeColor = System.Drawing.Color.Black
Me.GroupBox43.Location = New System.Drawing.Point(7, 331)
Me.GroupBox43.Name = "GroupBox43"
Me.GroupBox43.Size = New System.Drawing.Size(692, 92)
Me.GroupBox43.TabIndex = 65
Me.GroupBox43.TabStop = false
Me.GroupBox43.Text = "Description"
'
'Label98
'
Me.Label98.BackColor = System.Drawing.Color.Transparent
Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label98.ForeColor = System.Drawing.Color.Black
Me.Label98.Location = New System.Drawing.Point(6, 16)
Me.Label98.Name = "Label98"
Me.Label98.Size = New System.Drawing.Size(680, 73)
Me.Label98.TabIndex = 62
Me.Label98.Text = resources.GetString("Label98.Text")
Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label104
'
Me.Label104.BackColor = System.Drawing.Color.Transparent
Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label104.ForeColor = System.Drawing.Color.Black
Me.Label104.Location = New System.Drawing.Point(7, 6)
Me.Label104.Name = "Label104"
Me.Label104.Size = New System.Drawing.Size(692, 21)
Me.Label104.TabIndex = 49
Me.Label104.Text = "Script Selection"
Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage7
'
Me.TabPage7.BackColor = System.Drawing.Color.Silver
Me.TabPage7.Controls.Add(Me.TabControl4)
Me.TabPage7.Location = New System.Drawing.Point(4, 22)
Me.TabPage7.Name = "TabPage7"
Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage7.Size = New System.Drawing.Size(720, 448)
Me.TabPage7.TabIndex = 11
Me.TabPage7.Text = "Images"
'
'TabControl4
'
Me.TabControl4.Controls.Add(Me.TpImagesUrlFiles)
Me.TabControl4.Controls.Add(Me.TpImagesGenre)
Me.TabControl4.Location = New System.Drawing.Point(6, 6)
Me.TabControl4.Name = "TabControl4"
Me.TabControl4.SelectedIndex = 0
Me.TabControl4.Size = New System.Drawing.Size(708, 437)
Me.TabControl4.TabIndex = 154
'
'TpImagesUrlFiles
'
Me.TpImagesUrlFiles.BackColor = System.Drawing.Color.LightGray
Me.TpImagesUrlFiles.Controls.Add(Me.CBURLPreview)
Me.TpImagesUrlFiles.Controls.Add(Me.GroupBox66)
Me.TpImagesUrlFiles.Controls.Add(Me.BTNURLFilesAll)
Me.TpImagesUrlFiles.Controls.Add(Me.BTNURLFilesNone)
Me.TpImagesUrlFiles.Controls.Add(Me.URLFileList)
Me.TpImagesUrlFiles.Location = New System.Drawing.Point(4, 22)
Me.TpImagesUrlFiles.Name = "TpImagesUrlFiles"
Me.TpImagesUrlFiles.Padding = New System.Windows.Forms.Padding(3)
Me.TpImagesUrlFiles.Size = New System.Drawing.Size(700, 411)
Me.TpImagesUrlFiles.TabIndex = 0
Me.TpImagesUrlFiles.Text = "URL Files"
'
'CBURLPreview
'
Me.CBURLPreview.AutoSize = true
Me.CBURLPreview.Checked = true
Me.CBURLPreview.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBURLPreview.Location = New System.Drawing.Point(344, 323)
Me.CBURLPreview.Name = "CBURLPreview"
Me.CBURLPreview.Size = New System.Drawing.Size(240, 17)
Me.CBURLPreview.TabIndex = 163
Me.CBURLPreview.Text = "Show Previews When A URL File is Selected"
Me.CBURLPreview.UseVisualStyleBackColor = true
'
'GroupBox66
'
Me.GroupBox66.Controls.Add(Me.PBURLPreview)
Me.GroupBox66.Location = New System.Drawing.Point(344, 3)
Me.GroupBox66.Name = "GroupBox66"
Me.GroupBox66.Size = New System.Drawing.Size(350, 309)
Me.GroupBox66.TabIndex = 162
Me.GroupBox66.TabStop = false
Me.GroupBox66.Text = "Example Preview"
'
'PBURLPreview
'
Me.PBURLPreview.BackColor = System.Drawing.Color.Black
Me.PBURLPreview.Location = New System.Drawing.Point(6, 19)
Me.PBURLPreview.Name = "PBURLPreview"
Me.PBURLPreview.Size = New System.Drawing.Size(338, 284)
Me.PBURLPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
Me.PBURLPreview.TabIndex = 0
Me.PBURLPreview.TabStop = false
'
'BTNURLFilesAll
'
Me.BTNURLFilesAll.Location = New System.Drawing.Point(344, 348)
Me.BTNURLFilesAll.Name = "BTNURLFilesAll"
Me.BTNURLFilesAll.Size = New System.Drawing.Size(75, 23)
Me.BTNURLFilesAll.TabIndex = 160
Me.BTNURLFilesAll.Text = "Select All"
Me.BTNURLFilesAll.UseVisualStyleBackColor = true
'
'BTNURLFilesNone
'
Me.BTNURLFilesNone.Location = New System.Drawing.Point(344, 380)
Me.BTNURLFilesNone.Name = "BTNURLFilesNone"
Me.BTNURLFilesNone.Size = New System.Drawing.Size(75, 23)
Me.BTNURLFilesNone.TabIndex = 161
Me.BTNURLFilesNone.Text = "Select None"
Me.BTNURLFilesNone.UseVisualStyleBackColor = true
'
'URLFileList
'
Me.URLFileList.CheckOnClick = true
Me.URLFileList.FormattingEnabled = true
Me.URLFileList.Location = New System.Drawing.Point(6, 9)
Me.URLFileList.Name = "URLFileList"
Me.URLFileList.Size = New System.Drawing.Size(332, 394)
Me.URLFileList.Sorted = true
Me.URLFileList.TabIndex = 154
'
'TpImagesGenre
'
Me.TpImagesGenre.BackColor = System.Drawing.Color.LightGray
Me.TpImagesGenre.Controls.Add(Me.GrbImageUrlFiles)
Me.TpImagesGenre.Controls.Add(Me.GbxImagesGenre)
Me.TpImagesGenre.Location = New System.Drawing.Point(4, 22)
Me.TpImagesGenre.Name = "TpImagesGenre"
Me.TpImagesGenre.Padding = New System.Windows.Forms.Padding(3)
Me.TpImagesGenre.Size = New System.Drawing.Size(700, 411)
Me.TpImagesGenre.TabIndex = 1
Me.TpImagesGenre.Text = "Genre Images"
'
'GrbImageUrlFiles
'
Me.GrbImageUrlFiles.Controls.Add(Me.TlpImageUrls)
Me.GrbImageUrlFiles.Location = New System.Drawing.Point(383, 8)
Me.GrbImageUrlFiles.Name = "GrbImageUrlFiles"
Me.GrbImageUrlFiles.Size = New System.Drawing.Size(311, 400)
Me.GrbImageUrlFiles.TabIndex = 1
Me.GrbImageUrlFiles.TabStop = false
Me.GrbImageUrlFiles.Text = "URL Files"
'
'TlpImageUrls
'
Me.TlpImageUrls.BackColor = System.Drawing.Color.LightGray
Me.TlpImageUrls.ColumnCount = 3
Me.TlpImageUrls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TlpImageUrls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TlpImageUrls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlButt, 1, 13)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlBoobs, 1, 12)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlBlowjob, 1, 4)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlCaptions, 1, 10)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlHentai, 1, 7)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlGay, 1, 8)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlGeneral, 1, 11)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlHardcore, 1, 0)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlLesbian, 1, 2)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlLezdom, 1, 6)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlMaledom, 1, 9)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlFemdom, 1, 5)
Me.TlpImageUrls.Controls.Add(Me.BtnImageUrlSoftcore, 1, 1)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlHardcore, 0, 0)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlButts, 0, 13)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlMaledom, 0, 9)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlGay, 0, 8)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlSoftcore, 0, 1)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlBoobs, 0, 12)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlLesbian, 0, 2)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlBlowjob, 0, 4)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlCaptions, 0, 10)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlGeneral, 0, 11)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlFemdom, 0, 5)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlHentai, 0, 7)
Me.TlpImageUrls.Controls.Add(Me.ChbImageUrlLezdom, 0, 6)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlBlowjob, 2, 4)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlSoftcore, 2, 1)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlLezdom, 2, 6)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlFemdom, 2, 5)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlHardcore, 2, 0)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlHentai, 2, 7)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlGay, 2, 8)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlLesbian, 2, 2)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlMaledom, 2, 9)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlCaptions, 2, 10)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlGeneral, 2, 11)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlBoobs, 2, 12)
Me.TlpImageUrls.Controls.Add(Me.TxbImageUrlButts, 2, 13)
Me.TlpImageUrls.Dock = System.Windows.Forms.DockStyle.Fill
Me.TlpImageUrls.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
Me.TlpImageUrls.Location = New System.Drawing.Point(3, 16)
Me.TlpImageUrls.Name = "TlpImageUrls"
Me.TlpImageUrls.RowCount = 14
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TlpImageUrls.Size = New System.Drawing.Size(305, 381)
Me.TlpImageUrls.TabIndex = 0
'
'BtnImageUrlButt
'
Me.BtnImageUrlButt.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlButt.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold)
Me.BtnImageUrlButt.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlButt.Location = New System.Drawing.Point(76, 348)
Me.BtnImageUrlButt.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlButt.Name = "BtnImageUrlButt"
Me.BtnImageUrlButt.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlButt.TabIndex = 38
Me.BtnImageUrlButt.Text = "1"
Me.BtnImageUrlButt.UseVisualStyleBackColor = false
'
'BtnImageUrlBoobs
'
Me.BtnImageUrlBoobs.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlBoobs.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold)
Me.BtnImageUrlBoobs.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlBoobs.Location = New System.Drawing.Point(76, 319)
Me.BtnImageUrlBoobs.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlBoobs.Name = "BtnImageUrlBoobs"
Me.BtnImageUrlBoobs.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlBoobs.TabIndex = 35
Me.BtnImageUrlBoobs.Text = "1"
Me.BtnImageUrlBoobs.UseVisualStyleBackColor = false
'
'BtnImageUrlBlowjob
'
Me.BtnImageUrlBlowjob.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlBlowjob.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlBlowjob.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlBlowjob.Location = New System.Drawing.Point(76, 87)
Me.BtnImageUrlBlowjob.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlBlowjob.Name = "BtnImageUrlBlowjob"
Me.BtnImageUrlBlowjob.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlBlowjob.TabIndex = 11
Me.BtnImageUrlBlowjob.Text = "1"
Me.BtnImageUrlBlowjob.UseVisualStyleBackColor = false
'
'BtnImageUrlCaptions
'
Me.BtnImageUrlCaptions.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlCaptions.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlCaptions.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlCaptions.Location = New System.Drawing.Point(76, 261)
Me.BtnImageUrlCaptions.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlCaptions.Name = "BtnImageUrlCaptions"
Me.BtnImageUrlCaptions.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlCaptions.TabIndex = 29
Me.BtnImageUrlCaptions.Text = "1"
Me.BtnImageUrlCaptions.UseVisualStyleBackColor = false
'
'BtnImageUrlHentai
'
Me.BtnImageUrlHentai.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlHentai.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlHentai.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlHentai.Location = New System.Drawing.Point(76, 174)
Me.BtnImageUrlHentai.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlHentai.Name = "BtnImageUrlHentai"
Me.BtnImageUrlHentai.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlHentai.TabIndex = 20
Me.BtnImageUrlHentai.Text = "1"
Me.BtnImageUrlHentai.UseVisualStyleBackColor = false
'
'BtnImageUrlGay
'
Me.BtnImageUrlGay.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlGay.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlGay.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlGay.Location = New System.Drawing.Point(76, 203)
Me.BtnImageUrlGay.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlGay.Name = "BtnImageUrlGay"
Me.BtnImageUrlGay.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlGay.TabIndex = 23
Me.BtnImageUrlGay.Text = "1"
Me.BtnImageUrlGay.UseVisualStyleBackColor = false
'
'BtnImageUrlGeneral
'
Me.BtnImageUrlGeneral.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlGeneral.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlGeneral.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlGeneral.Location = New System.Drawing.Point(76, 290)
Me.BtnImageUrlGeneral.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlGeneral.Name = "BtnImageUrlGeneral"
Me.BtnImageUrlGeneral.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlGeneral.TabIndex = 32
Me.BtnImageUrlGeneral.Text = "1"
Me.BtnImageUrlGeneral.UseVisualStyleBackColor = false
'
'BtnImageUrlHardcore
'
Me.BtnImageUrlHardcore.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlHardcore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlHardcore.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlHardcore.Location = New System.Drawing.Point(76, 0)
Me.BtnImageUrlHardcore.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlHardcore.Name = "BtnImageUrlHardcore"
Me.BtnImageUrlHardcore.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlHardcore.TabIndex = 1
Me.BtnImageUrlHardcore.Text = "1"
Me.BtnImageUrlHardcore.UseVisualStyleBackColor = false
'
'BtnImageUrlLesbian
'
Me.BtnImageUrlLesbian.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlLesbian.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlLesbian.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlLesbian.Location = New System.Drawing.Point(76, 58)
Me.BtnImageUrlLesbian.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlLesbian.Name = "BtnImageUrlLesbian"
Me.BtnImageUrlLesbian.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlLesbian.TabIndex = 8
Me.BtnImageUrlLesbian.Text = "1"
Me.BtnImageUrlLesbian.UseVisualStyleBackColor = false
'
'BtnImageUrlLezdom
'
Me.BtnImageUrlLezdom.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlLezdom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlLezdom.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlLezdom.Location = New System.Drawing.Point(76, 145)
Me.BtnImageUrlLezdom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlLezdom.Name = "BtnImageUrlLezdom"
Me.BtnImageUrlLezdom.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlLezdom.TabIndex = 17
Me.BtnImageUrlLezdom.Text = "1"
Me.BtnImageUrlLezdom.UseVisualStyleBackColor = false
'
'BtnImageUrlMaledom
'
Me.BtnImageUrlMaledom.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlMaledom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlMaledom.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlMaledom.Location = New System.Drawing.Point(76, 232)
Me.BtnImageUrlMaledom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlMaledom.Name = "BtnImageUrlMaledom"
Me.BtnImageUrlMaledom.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlMaledom.TabIndex = 26
Me.BtnImageUrlMaledom.Text = "1"
Me.BtnImageUrlMaledom.UseVisualStyleBackColor = false
'
'BtnImageUrlFemdom
'
Me.BtnImageUrlFemdom.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlFemdom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlFemdom.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlFemdom.Location = New System.Drawing.Point(76, 116)
Me.BtnImageUrlFemdom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlFemdom.Name = "BtnImageUrlFemdom"
Me.BtnImageUrlFemdom.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlFemdom.TabIndex = 14
Me.BtnImageUrlFemdom.Text = "1"
Me.BtnImageUrlFemdom.UseVisualStyleBackColor = false
'
'BtnImageUrlSoftcore
'
Me.BtnImageUrlSoftcore.BackColor = System.Drawing.Color.LightGray
Me.BtnImageUrlSoftcore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BtnImageUrlSoftcore.ForeColor = System.Drawing.Color.Black
Me.BtnImageUrlSoftcore.Location = New System.Drawing.Point(76, 29)
Me.BtnImageUrlSoftcore.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BtnImageUrlSoftcore.Name = "BtnImageUrlSoftcore"
Me.BtnImageUrlSoftcore.Size = New System.Drawing.Size(34, 28)
Me.BtnImageUrlSoftcore.TabIndex = 5
Me.BtnImageUrlSoftcore.Text = "1"
Me.BtnImageUrlSoftcore.UseVisualStyleBackColor = false
'
'ChbImageUrlHardcore
'
Me.ChbImageUrlHardcore.AutoSize = true
Me.ChbImageUrlHardcore.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileHardcoreEnabled
Me.ChbImageUrlHardcore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileHardcoreEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlHardcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlHardcore.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlHardcore.Location = New System.Drawing.Point(3, 3)
Me.ChbImageUrlHardcore.Name = "ChbImageUrlHardcore"
Me.ChbImageUrlHardcore.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlHardcore.TabIndex = 0
Me.ChbImageUrlHardcore.Text = "Hardcore"
Me.ChbImageUrlHardcore.UseVisualStyleBackColor = true
'
'ChbImageUrlButts
'
Me.ChbImageUrlButts.AutoSize = true
Me.ChbImageUrlButts.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileButtEnabled
Me.ChbImageUrlButts.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileButtEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlButts.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlButts.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlButts.Location = New System.Drawing.Point(3, 351)
Me.ChbImageUrlButts.Name = "ChbImageUrlButts"
Me.ChbImageUrlButts.Size = New System.Drawing.Size(70, 27)
Me.ChbImageUrlButts.TabIndex = 37
Me.ChbImageUrlButts.Text = "Butts"
Me.ChbImageUrlButts.UseVisualStyleBackColor = true
'
'ChbImageUrlMaledom
'
Me.ChbImageUrlMaledom.AutoSize = true
Me.ChbImageUrlMaledom.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileMaledomEnabled
Me.ChbImageUrlMaledom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileMaledomEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlMaledom.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlMaledom.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlMaledom.Location = New System.Drawing.Point(3, 235)
Me.ChbImageUrlMaledom.Name = "ChbImageUrlMaledom"
Me.ChbImageUrlMaledom.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlMaledom.TabIndex = 25
Me.ChbImageUrlMaledom.Text = "Maledom"
Me.ChbImageUrlMaledom.UseVisualStyleBackColor = true
'
'ChbImageUrlGay
'
Me.ChbImageUrlGay.AutoSize = true
Me.ChbImageUrlGay.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileGayEnabled
Me.ChbImageUrlGay.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileGayEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlGay.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlGay.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlGay.Location = New System.Drawing.Point(3, 206)
Me.ChbImageUrlGay.Name = "ChbImageUrlGay"
Me.ChbImageUrlGay.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlGay.TabIndex = 22
Me.ChbImageUrlGay.Text = "Gay"
Me.ChbImageUrlGay.UseVisualStyleBackColor = true
'
'ChbImageUrlSoftcore
'
Me.ChbImageUrlSoftcore.AutoSize = true
Me.ChbImageUrlSoftcore.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileSoftcoreEnabled
Me.ChbImageUrlSoftcore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileSoftcoreEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlSoftcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlSoftcore.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlSoftcore.Location = New System.Drawing.Point(3, 32)
Me.ChbImageUrlSoftcore.Name = "ChbImageUrlSoftcore"
Me.ChbImageUrlSoftcore.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlSoftcore.TabIndex = 4
Me.ChbImageUrlSoftcore.Text = "Softcore"
Me.ChbImageUrlSoftcore.UseVisualStyleBackColor = true
'
'ChbImageUrlBoobs
'
Me.ChbImageUrlBoobs.AutoSize = true
Me.ChbImageUrlBoobs.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileBoobsEnabled
Me.ChbImageUrlBoobs.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileBoobsEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlBoobs.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlBoobs.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlBoobs.Location = New System.Drawing.Point(3, 322)
Me.ChbImageUrlBoobs.Name = "ChbImageUrlBoobs"
Me.ChbImageUrlBoobs.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlBoobs.TabIndex = 34
Me.ChbImageUrlBoobs.Text = "Boobs"
Me.ChbImageUrlBoobs.UseVisualStyleBackColor = true
'
'ChbImageUrlLesbian
'
Me.ChbImageUrlLesbian.AutoSize = true
Me.ChbImageUrlLesbian.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileLesbianEnabled
Me.ChbImageUrlLesbian.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileLesbianEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlLesbian.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlLesbian.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlLesbian.Location = New System.Drawing.Point(3, 61)
Me.ChbImageUrlLesbian.Name = "ChbImageUrlLesbian"
Me.ChbImageUrlLesbian.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlLesbian.TabIndex = 7
Me.ChbImageUrlLesbian.Text = "Lesbian"
Me.ChbImageUrlLesbian.UseVisualStyleBackColor = true
'
'ChbImageUrlBlowjob
'
Me.ChbImageUrlBlowjob.AutoSize = true
Me.ChbImageUrlBlowjob.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileBlowjobEnabled
Me.ChbImageUrlBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileBlowjobEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlBlowjob.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlBlowjob.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlBlowjob.Location = New System.Drawing.Point(3, 90)
Me.ChbImageUrlBlowjob.Name = "ChbImageUrlBlowjob"
Me.ChbImageUrlBlowjob.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlBlowjob.TabIndex = 10
Me.ChbImageUrlBlowjob.Text = "Blowjob"
Me.ChbImageUrlBlowjob.UseVisualStyleBackColor = true
'
'ChbImageUrlCaptions
'
Me.ChbImageUrlCaptions.AutoSize = true
Me.ChbImageUrlCaptions.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileCaptionsEnabled
Me.ChbImageUrlCaptions.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileCaptionsEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlCaptions.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlCaptions.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlCaptions.Location = New System.Drawing.Point(3, 264)
Me.ChbImageUrlCaptions.Name = "ChbImageUrlCaptions"
Me.ChbImageUrlCaptions.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlCaptions.TabIndex = 28
Me.ChbImageUrlCaptions.Text = "Captions"
Me.ChbImageUrlCaptions.UseVisualStyleBackColor = true
'
'ChbImageUrlGeneral
'
Me.ChbImageUrlGeneral.AutoSize = true
Me.ChbImageUrlGeneral.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileGeneralEnabled
Me.ChbImageUrlGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileGeneralEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlGeneral.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlGeneral.Location = New System.Drawing.Point(3, 293)
Me.ChbImageUrlGeneral.Name = "ChbImageUrlGeneral"
Me.ChbImageUrlGeneral.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlGeneral.TabIndex = 31
Me.ChbImageUrlGeneral.Text = "General"
Me.ChbImageUrlGeneral.UseVisualStyleBackColor = true
'
'ChbImageUrlFemdom
'
Me.ChbImageUrlFemdom.AutoSize = true
Me.ChbImageUrlFemdom.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileFemdomEnabled
Me.ChbImageUrlFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileFemdomEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlFemdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlFemdom.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlFemdom.Location = New System.Drawing.Point(3, 119)
Me.ChbImageUrlFemdom.Name = "ChbImageUrlFemdom"
Me.ChbImageUrlFemdom.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlFemdom.TabIndex = 13
Me.ChbImageUrlFemdom.Text = "Femdom"
Me.ChbImageUrlFemdom.UseVisualStyleBackColor = true
'
'ChbImageUrlHentai
'
Me.ChbImageUrlHentai.AutoSize = true
Me.ChbImageUrlHentai.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileHentaiEnabled
Me.ChbImageUrlHentai.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileHentaiEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlHentai.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlHentai.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlHentai.Location = New System.Drawing.Point(3, 177)
Me.ChbImageUrlHentai.Name = "ChbImageUrlHentai"
Me.ChbImageUrlHentai.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlHentai.TabIndex = 19
Me.ChbImageUrlHentai.Text = "Hentai"
Me.ChbImageUrlHentai.UseVisualStyleBackColor = true
'
'ChbImageUrlLezdom
'
Me.ChbImageUrlLezdom.AutoSize = true
Me.ChbImageUrlLezdom.Checked = Global.Tease_AI.My.MySettings.Default.UrlFileLezdomEnabled
Me.ChbImageUrlLezdom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "UrlFileLezdomEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.ChbImageUrlLezdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.ChbImageUrlLezdom.ForeColor = System.Drawing.Color.Black
Me.ChbImageUrlLezdom.Location = New System.Drawing.Point(3, 148)
Me.ChbImageUrlLezdom.Name = "ChbImageUrlLezdom"
Me.ChbImageUrlLezdom.Size = New System.Drawing.Size(70, 23)
Me.ChbImageUrlLezdom.TabIndex = 16
Me.ChbImageUrlLezdom.Text = "Lezdom"
Me.ChbImageUrlLezdom.UseVisualStyleBackColor = true
'
'TxbImageUrlBlowjob
'
Me.TxbImageUrlBlowjob.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlBlowjob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileBlowjob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlBlowjob.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlBlowjob.Location = New System.Drawing.Point(115, 92)
Me.TxbImageUrlBlowjob.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlBlowjob.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlBlowjob.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlBlowjob.Name = "TxbImageUrlBlowjob"
Me.TxbImageUrlBlowjob.ReadOnly = true
Me.TxbImageUrlBlowjob.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlBlowjob.TabIndex = 12
Me.TxbImageUrlBlowjob.Text = Global.Tease_AI.My.MySettings.Default.UrlFileBlowjob
'
'TxbImageUrlSoftcore
'
Me.TxbImageUrlSoftcore.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlSoftcore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlSoftcore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileSoftcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlSoftcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlSoftcore.Location = New System.Drawing.Point(115, 34)
Me.TxbImageUrlSoftcore.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlSoftcore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlSoftcore.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlSoftcore.Name = "TxbImageUrlSoftcore"
Me.TxbImageUrlSoftcore.ReadOnly = true
Me.TxbImageUrlSoftcore.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlSoftcore.TabIndex = 6
Me.TxbImageUrlSoftcore.Text = Global.Tease_AI.My.MySettings.Default.UrlFileSoftcore
'
'TxbImageUrlLezdom
'
Me.TxbImageUrlLezdom.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlLezdom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlLezdom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileLezdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlLezdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlLezdom.Location = New System.Drawing.Point(115, 150)
Me.TxbImageUrlLezdom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlLezdom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlLezdom.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlLezdom.Name = "TxbImageUrlLezdom"
Me.TxbImageUrlLezdom.ReadOnly = true
Me.TxbImageUrlLezdom.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlLezdom.TabIndex = 18
Me.TxbImageUrlLezdom.Text = Global.Tease_AI.My.MySettings.Default.UrlFileLezdom
'
'TxbImageUrlFemdom
'
Me.TxbImageUrlFemdom.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlFemdom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileFemdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlFemdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlFemdom.Location = New System.Drawing.Point(115, 121)
Me.TxbImageUrlFemdom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlFemdom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlFemdom.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlFemdom.Name = "TxbImageUrlFemdom"
Me.TxbImageUrlFemdom.ReadOnly = true
Me.TxbImageUrlFemdom.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlFemdom.TabIndex = 15
Me.TxbImageUrlFemdom.Text = Global.Tease_AI.My.MySettings.Default.UrlFileFemdom
'
'TxbImageUrlHardcore
'
Me.TxbImageUrlHardcore.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlHardcore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlHardcore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileHardcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlHardcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlHardcore.Location = New System.Drawing.Point(115, 5)
Me.TxbImageUrlHardcore.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlHardcore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlHardcore.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlHardcore.Name = "TxbImageUrlHardcore"
Me.TxbImageUrlHardcore.ReadOnly = true
Me.TxbImageUrlHardcore.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlHardcore.TabIndex = 3
Me.TxbImageUrlHardcore.Text = Global.Tease_AI.My.MySettings.Default.UrlFileHardcore
'
'TxbImageUrlHentai
'
Me.TxbImageUrlHentai.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlHentai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlHentai.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileHentai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlHentai.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlHentai.Location = New System.Drawing.Point(115, 179)
Me.TxbImageUrlHentai.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlHentai.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlHentai.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlHentai.Name = "TxbImageUrlHentai"
Me.TxbImageUrlHentai.ReadOnly = true
Me.TxbImageUrlHentai.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlHentai.TabIndex = 21
Me.TxbImageUrlHentai.Text = Global.Tease_AI.My.MySettings.Default.UrlFileHentai
'
'TxbImageUrlGay
'
Me.TxbImageUrlGay.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlGay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlGay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileGay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlGay.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlGay.Location = New System.Drawing.Point(115, 208)
Me.TxbImageUrlGay.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlGay.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlGay.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlGay.Name = "TxbImageUrlGay"
Me.TxbImageUrlGay.ReadOnly = true
Me.TxbImageUrlGay.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlGay.TabIndex = 24
Me.TxbImageUrlGay.Text = Global.Tease_AI.My.MySettings.Default.UrlFileGay
'
'TxbImageUrlLesbian
'
Me.TxbImageUrlLesbian.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlLesbian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlLesbian.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileLesbian", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlLesbian.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlLesbian.Location = New System.Drawing.Point(115, 63)
Me.TxbImageUrlLesbian.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlLesbian.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlLesbian.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlLesbian.Name = "TxbImageUrlLesbian"
Me.TxbImageUrlLesbian.ReadOnly = true
Me.TxbImageUrlLesbian.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlLesbian.TabIndex = 9
Me.TxbImageUrlLesbian.Text = Global.Tease_AI.My.MySettings.Default.UrlFileLesbian
'
'TxbImageUrlMaledom
'
Me.TxbImageUrlMaledom.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlMaledom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlMaledom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileMaledom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlMaledom.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlMaledom.Location = New System.Drawing.Point(115, 237)
Me.TxbImageUrlMaledom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlMaledom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlMaledom.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlMaledom.Name = "TxbImageUrlMaledom"
Me.TxbImageUrlMaledom.ReadOnly = true
Me.TxbImageUrlMaledom.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlMaledom.TabIndex = 27
Me.TxbImageUrlMaledom.Text = Global.Tease_AI.My.MySettings.Default.UrlFileMaledom
'
'TxbImageUrlCaptions
'
Me.TxbImageUrlCaptions.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlCaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlCaptions.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileCaptions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlCaptions.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlCaptions.Location = New System.Drawing.Point(115, 266)
Me.TxbImageUrlCaptions.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlCaptions.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlCaptions.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlCaptions.Name = "TxbImageUrlCaptions"
Me.TxbImageUrlCaptions.ReadOnly = true
Me.TxbImageUrlCaptions.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlCaptions.TabIndex = 30
Me.TxbImageUrlCaptions.Text = Global.Tease_AI.My.MySettings.Default.UrlFileCaptions
'
'TxbImageUrlGeneral
'
Me.TxbImageUrlGeneral.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileGeneral", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlGeneral.Location = New System.Drawing.Point(115, 295)
Me.TxbImageUrlGeneral.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlGeneral.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlGeneral.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlGeneral.Name = "TxbImageUrlGeneral"
Me.TxbImageUrlGeneral.ReadOnly = true
Me.TxbImageUrlGeneral.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlGeneral.TabIndex = 33
Me.TxbImageUrlGeneral.Text = Global.Tease_AI.My.MySettings.Default.UrlFileGeneral
'
'TxbImageUrlBoobs
'
Me.TxbImageUrlBoobs.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlBoobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlBoobs.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileBoobs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlBoobs.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlBoobs.Location = New System.Drawing.Point(115, 324)
Me.TxbImageUrlBoobs.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlBoobs.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlBoobs.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlBoobs.Name = "TxbImageUrlBoobs"
Me.TxbImageUrlBoobs.ReadOnly = true
Me.TxbImageUrlBoobs.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlBoobs.TabIndex = 36
Me.TxbImageUrlBoobs.Text = Global.Tease_AI.My.MySettings.Default.UrlFileBoobs
'
'TxbImageUrlButts
'
Me.TxbImageUrlButts.BackColor = System.Drawing.Color.LightGray
Me.TxbImageUrlButts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImageUrlButts.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "UrlFileButt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbImageUrlButts.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImageUrlButts.Location = New System.Drawing.Point(115, 353)
Me.TxbImageUrlButts.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TxbImageUrlButts.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbImageUrlButts.MinimumSize = New System.Drawing.Size(182, 17)
Me.TxbImageUrlButts.Name = "TxbImageUrlButts"
Me.TxbImageUrlButts.ReadOnly = true
Me.TxbImageUrlButts.Size = New System.Drawing.Size(182, 17)
Me.TxbImageUrlButts.TabIndex = 39
Me.TxbImageUrlButts.Text = Global.Tease_AI.My.MySettings.Default.UrlFileButt
'
'GbxImagesGenre
'
Me.GbxImagesGenre.Controls.Add(Me.TableLayoutPanel1)
Me.GbxImagesGenre.Location = New System.Drawing.Point(6, 8)
Me.GbxImagesGenre.Name = "GbxImagesGenre"
Me.GbxImagesGenre.Size = New System.Drawing.Size(371, 400)
Me.GbxImagesGenre.TabIndex = 0
Me.GbxImagesGenre.TabStop = false
Me.GbxImagesGenre.Text = "Local Images"
'
'TableLayoutPanel1
'
Me.TableLayoutPanel1.ColumnCount = 4
Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
Me.TableLayoutPanel1.Controls.Add(Me.BTNIHardcore, 1, 0)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIHardcore, 2, 0)
Me.TableLayoutPanel1.Controls.Add(Me.CBIHardcoreSD, 3, 0)
Me.TableLayoutPanel1.Controls.Add(Me.CBIHardcore, 0, 0)
Me.TableLayoutPanel1.Controls.Add(Me.CBISoftcore, 0, 1)
Me.TableLayoutPanel1.Controls.Add(Me.TbxISoftcore, 2, 1)
Me.TableLayoutPanel1.Controls.Add(Me.CBButtSubDir, 3, 12)
Me.TableLayoutPanel1.Controls.Add(Me.CBISoftcoreSD, 3, 1)
Me.TableLayoutPanel1.Controls.Add(Me.CBBoobSubDir, 3, 11)
Me.TableLayoutPanel1.Controls.Add(Me.CBILezdomSD, 3, 5)
Me.TableLayoutPanel1.Controls.Add(Me.CBIGeneralSD, 3, 10)
Me.TableLayoutPanel1.Controls.Add(Me.CBILesbianSD, 3, 2)
Me.TableLayoutPanel1.Controls.Add(Me.CBICaptionsSD, 3, 9)
Me.TableLayoutPanel1.Controls.Add(Me.CBILesbian, 0, 2)
Me.TableLayoutPanel1.Controls.Add(Me.CBIMaledomSD, 3, 8)
Me.TableLayoutPanel1.Controls.Add(Me.CBIBlowjob, 0, 3)
Me.TableLayoutPanel1.Controls.Add(Me.CBIGaySD, 3, 7)
Me.TableLayoutPanel1.Controls.Add(Me.CBIHentaiSD, 3, 6)
Me.TableLayoutPanel1.Controls.Add(Me.CBIBlowjobSD, 3, 3)
Me.TableLayoutPanel1.Controls.Add(Me.CBIFemdomSD, 3, 4)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIButts, 2, 12)
Me.TableLayoutPanel1.Controls.Add(Me.CBIFemdom, 0, 4)
Me.TableLayoutPanel1.Controls.Add(Me.TbxILesbian, 2, 2)
Me.TableLayoutPanel1.Controls.Add(Me.BTNISoftcore, 1, 1)
Me.TableLayoutPanel1.Controls.Add(Me.CBILezdom, 0, 5)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIBoobs, 2, 11)
Me.TableLayoutPanel1.Controls.Add(Me.CBIHentai, 0, 6)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIBlowjob, 2, 3)
Me.TableLayoutPanel1.Controls.Add(Me.CBIGay, 0, 7)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIGeneral, 2, 10)
Me.TableLayoutPanel1.Controls.Add(Me.CBIMaledom, 0, 8)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIFemdom, 2, 4)
Me.TableLayoutPanel1.Controls.Add(Me.BTNILesbian, 1, 2)
Me.TableLayoutPanel1.Controls.Add(Me.TbxICaptions, 2, 9)
Me.TableLayoutPanel1.Controls.Add(Me.CBICaptions, 0, 9)
Me.TableLayoutPanel1.Controls.Add(Me.TbxILezdom, 2, 5)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIMaledom, 2, 8)
Me.TableLayoutPanel1.Controls.Add(Me.BTNButtPath, 1, 12)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIHentai, 2, 6)
Me.TableLayoutPanel1.Controls.Add(Me.CBIGeneral, 0, 10)
Me.TableLayoutPanel1.Controls.Add(Me.TbxIGay, 2, 7)
Me.TableLayoutPanel1.Controls.Add(Me.CBIBoobs, 0, 11)
Me.TableLayoutPanel1.Controls.Add(Me.CBIButts, 0, 12)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIBlowjob, 1, 3)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIFemdom, 1, 4)
Me.TableLayoutPanel1.Controls.Add(Me.BTNBoobPath, 1, 11)
Me.TableLayoutPanel1.Controls.Add(Me.BTNILezdom, 1, 5)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIHentai, 1, 6)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIGay, 1, 7)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIMaledom, 1, 8)
Me.TableLayoutPanel1.Controls.Add(Me.BTNICaptions, 1, 9)
Me.TableLayoutPanel1.Controls.Add(Me.BTNIGeneral, 1, 10)
Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
Me.TableLayoutPanel1.RowCount = 13
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
Me.TableLayoutPanel1.Size = New System.Drawing.Size(365, 381)
Me.TableLayoutPanel1.TabIndex = 0
'
'BTNIHardcore
'
Me.BTNIHardcore.BackColor = System.Drawing.Color.LightGray
Me.BTNIHardcore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIHardcore.ForeColor = System.Drawing.Color.Black
Me.BTNIHardcore.Location = New System.Drawing.Point(76, 0)
Me.BTNIHardcore.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIHardcore.Name = "BTNIHardcore"
Me.BTNIHardcore.Size = New System.Drawing.Size(34, 28)
Me.BTNIHardcore.TabIndex = 1
Me.BTNIHardcore.Text = "1"
Me.BTNIHardcore.UseVisualStyleBackColor = false
'
'TbxIHardcore
'
Me.TbxIHardcore.BackColor = System.Drawing.Color.LightGray
Me.TbxIHardcore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIHardcore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IHardcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIHardcore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIHardcore.ForeColor = System.Drawing.Color.Black
Me.TbxIHardcore.Location = New System.Drawing.Point(115, 5)
Me.TbxIHardcore.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIHardcore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIHardcore.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIHardcore.Name = "TbxIHardcore"
Me.TbxIHardcore.ReadOnly = true
Me.TbxIHardcore.Size = New System.Drawing.Size(217, 17)
Me.TbxIHardcore.TabIndex = 2
Me.TbxIHardcore.Text = Global.Tease_AI.My.MySettings.Default.IHardcore
'
'CBIHardcoreSD
'
Me.CBIHardcoreSD.AutoSize = true
Me.CBIHardcoreSD.Checked = Global.Tease_AI.My.MySettings.Default.IHardcoreSD
Me.CBIHardcoreSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIHardcoreSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IHardcoreSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIHardcoreSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIHardcoreSD.ForeColor = System.Drawing.Color.Black
Me.CBIHardcoreSD.Location = New System.Drawing.Point(343, 3)
Me.CBIHardcoreSD.Name = "CBIHardcoreSD"
Me.CBIHardcoreSD.Size = New System.Drawing.Size(19, 23)
Me.CBIHardcoreSD.TabIndex = 3
Me.CBIHardcoreSD.UseVisualStyleBackColor = true
'
'CBIHardcore
'
Me.CBIHardcore.AutoSize = true
Me.CBIHardcore.Checked = Global.Tease_AI.My.MySettings.Default.CBIHardcore
Me.CBIHardcore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIHardcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIHardcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIHardcore.ForeColor = System.Drawing.Color.Black
Me.CBIHardcore.Location = New System.Drawing.Point(3, 3)
Me.CBIHardcore.Name = "CBIHardcore"
Me.CBIHardcore.Size = New System.Drawing.Size(70, 23)
Me.CBIHardcore.TabIndex = 0
Me.CBIHardcore.Text = "Hardcore"
Me.CBIHardcore.UseVisualStyleBackColor = true
'
'CBISoftcore
'
Me.CBISoftcore.AutoSize = true
Me.CBISoftcore.Checked = Global.Tease_AI.My.MySettings.Default.CBISoftcore
Me.CBISoftcore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBISoftcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBISoftcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBISoftcore.ForeColor = System.Drawing.Color.Black
Me.CBISoftcore.Location = New System.Drawing.Point(3, 32)
Me.CBISoftcore.Name = "CBISoftcore"
Me.CBISoftcore.Size = New System.Drawing.Size(70, 23)
Me.CBISoftcore.TabIndex = 4
Me.CBISoftcore.Text = "Softcore"
Me.CBISoftcore.UseVisualStyleBackColor = true
'
'TbxISoftcore
'
Me.TbxISoftcore.BackColor = System.Drawing.Color.LightGray
Me.TbxISoftcore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxISoftcore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "ISoftcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxISoftcore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxISoftcore.ForeColor = System.Drawing.Color.Black
Me.TbxISoftcore.Location = New System.Drawing.Point(115, 34)
Me.TbxISoftcore.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxISoftcore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxISoftcore.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxISoftcore.Name = "TbxISoftcore"
Me.TbxISoftcore.ReadOnly = true
Me.TbxISoftcore.Size = New System.Drawing.Size(217, 17)
Me.TbxISoftcore.TabIndex = 6
Me.TbxISoftcore.Text = Global.Tease_AI.My.MySettings.Default.ISoftcore
'
'CBButtSubDir
'
Me.CBButtSubDir.AutoSize = true
Me.CBButtSubDir.Checked = Global.Tease_AI.My.MySettings.Default.CBButtSubDir
Me.CBButtSubDir.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBButtSubDir.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBButtSubDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBButtSubDir.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBButtSubDir.ForeColor = System.Drawing.Color.Black
Me.CBButtSubDir.Location = New System.Drawing.Point(343, 351)
Me.CBButtSubDir.Name = "CBButtSubDir"
Me.CBButtSubDir.Size = New System.Drawing.Size(19, 27)
Me.CBButtSubDir.TabIndex = 51
Me.CBButtSubDir.UseVisualStyleBackColor = true
'
'CBISoftcoreSD
'
Me.CBISoftcoreSD.AutoSize = true
Me.CBISoftcoreSD.Checked = Global.Tease_AI.My.MySettings.Default.ISoftcoreSD
Me.CBISoftcoreSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBISoftcoreSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "ISoftcoreSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBISoftcoreSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBISoftcoreSD.ForeColor = System.Drawing.Color.Black
Me.CBISoftcoreSD.Location = New System.Drawing.Point(343, 32)
Me.CBISoftcoreSD.Name = "CBISoftcoreSD"
Me.CBISoftcoreSD.Size = New System.Drawing.Size(19, 23)
Me.CBISoftcoreSD.TabIndex = 7
Me.CBISoftcoreSD.UseVisualStyleBackColor = true
'
'CBBoobSubDir
'
Me.CBBoobSubDir.AutoSize = true
Me.CBBoobSubDir.Checked = Global.Tease_AI.My.MySettings.Default.CBBoobSubDir
Me.CBBoobSubDir.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBBoobSubDir.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBBoobSubDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBBoobSubDir.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBBoobSubDir.ForeColor = System.Drawing.Color.Black
Me.CBBoobSubDir.Location = New System.Drawing.Point(343, 322)
Me.CBBoobSubDir.Name = "CBBoobSubDir"
Me.CBBoobSubDir.Size = New System.Drawing.Size(19, 23)
Me.CBBoobSubDir.TabIndex = 47
Me.CBBoobSubDir.UseVisualStyleBackColor = true
'
'CBILezdomSD
'
Me.CBILezdomSD.AutoSize = true
Me.CBILezdomSD.Checked = Global.Tease_AI.My.MySettings.Default.ILezdomSD
Me.CBILezdomSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBILezdomSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "ILezdomSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBILezdomSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBILezdomSD.ForeColor = System.Drawing.Color.Black
Me.CBILezdomSD.Location = New System.Drawing.Point(343, 148)
Me.CBILezdomSD.Name = "CBILezdomSD"
Me.CBILezdomSD.Size = New System.Drawing.Size(19, 23)
Me.CBILezdomSD.TabIndex = 23
Me.CBILezdomSD.UseVisualStyleBackColor = true
'
'CBIGeneralSD
'
Me.CBIGeneralSD.AutoSize = true
Me.CBIGeneralSD.Checked = Global.Tease_AI.My.MySettings.Default.IGeneralSD
Me.CBIGeneralSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIGeneralSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IGeneralSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIGeneralSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIGeneralSD.ForeColor = System.Drawing.Color.Black
Me.CBIGeneralSD.Location = New System.Drawing.Point(343, 293)
Me.CBIGeneralSD.Name = "CBIGeneralSD"
Me.CBIGeneralSD.Size = New System.Drawing.Size(19, 23)
Me.CBIGeneralSD.TabIndex = 43
Me.CBIGeneralSD.UseVisualStyleBackColor = true
'
'CBILesbianSD
'
Me.CBILesbianSD.AutoSize = true
Me.CBILesbianSD.Checked = Global.Tease_AI.My.MySettings.Default.ILesbianSD
Me.CBILesbianSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBILesbianSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "ILesbianSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBILesbianSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBILesbianSD.ForeColor = System.Drawing.Color.Black
Me.CBILesbianSD.Location = New System.Drawing.Point(343, 61)
Me.CBILesbianSD.Name = "CBILesbianSD"
Me.CBILesbianSD.Size = New System.Drawing.Size(19, 23)
Me.CBILesbianSD.TabIndex = 11
Me.CBILesbianSD.UseVisualStyleBackColor = true
'
'CBICaptionsSD
'
Me.CBICaptionsSD.AutoSize = true
Me.CBICaptionsSD.Checked = Global.Tease_AI.My.MySettings.Default.ICaptionsSD
Me.CBICaptionsSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBICaptionsSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "ICaptionsSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBICaptionsSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBICaptionsSD.ForeColor = System.Drawing.Color.Black
Me.CBICaptionsSD.Location = New System.Drawing.Point(343, 264)
Me.CBICaptionsSD.Name = "CBICaptionsSD"
Me.CBICaptionsSD.Size = New System.Drawing.Size(19, 23)
Me.CBICaptionsSD.TabIndex = 39
Me.CBICaptionsSD.UseVisualStyleBackColor = true
'
'CBILesbian
'
Me.CBILesbian.AutoSize = true
Me.CBILesbian.Checked = Global.Tease_AI.My.MySettings.Default.CBILesbian
Me.CBILesbian.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBILesbian", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBILesbian.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBILesbian.ForeColor = System.Drawing.Color.Black
Me.CBILesbian.Location = New System.Drawing.Point(3, 61)
Me.CBILesbian.Name = "CBILesbian"
Me.CBILesbian.Size = New System.Drawing.Size(70, 23)
Me.CBILesbian.TabIndex = 8
Me.CBILesbian.Text = "Lesbian"
Me.CBILesbian.UseVisualStyleBackColor = true
'
'CBIMaledomSD
'
Me.CBIMaledomSD.AutoSize = true
Me.CBIMaledomSD.Checked = Global.Tease_AI.My.MySettings.Default.IMaledomSD
Me.CBIMaledomSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIMaledomSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IMaledomSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIMaledomSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIMaledomSD.ForeColor = System.Drawing.Color.Black
Me.CBIMaledomSD.Location = New System.Drawing.Point(343, 235)
Me.CBIMaledomSD.Name = "CBIMaledomSD"
Me.CBIMaledomSD.Size = New System.Drawing.Size(19, 23)
Me.CBIMaledomSD.TabIndex = 35
Me.CBIMaledomSD.UseVisualStyleBackColor = true
'
'CBIBlowjob
'
Me.CBIBlowjob.AutoSize = true
Me.CBIBlowjob.Checked = Global.Tease_AI.My.MySettings.Default.CBIBlowjob
Me.CBIBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIBlowjob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIBlowjob.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIBlowjob.ForeColor = System.Drawing.Color.Black
Me.CBIBlowjob.Location = New System.Drawing.Point(3, 90)
Me.CBIBlowjob.Name = "CBIBlowjob"
Me.CBIBlowjob.Size = New System.Drawing.Size(70, 23)
Me.CBIBlowjob.TabIndex = 12
Me.CBIBlowjob.Text = "Blowjob"
Me.CBIBlowjob.UseVisualStyleBackColor = true
'
'CBIGaySD
'
Me.CBIGaySD.AutoSize = true
Me.CBIGaySD.Checked = Global.Tease_AI.My.MySettings.Default.IGaySD
Me.CBIGaySD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIGaySD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IGaySD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIGaySD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIGaySD.ForeColor = System.Drawing.Color.Black
Me.CBIGaySD.Location = New System.Drawing.Point(343, 206)
Me.CBIGaySD.Name = "CBIGaySD"
Me.CBIGaySD.Size = New System.Drawing.Size(19, 23)
Me.CBIGaySD.TabIndex = 31
Me.CBIGaySD.UseVisualStyleBackColor = true
'
'CBIHentaiSD
'
Me.CBIHentaiSD.AutoSize = true
Me.CBIHentaiSD.Checked = Global.Tease_AI.My.MySettings.Default.IHentaiSD
Me.CBIHentaiSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIHentaiSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IHentaiSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIHentaiSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIHentaiSD.ForeColor = System.Drawing.Color.Black
Me.CBIHentaiSD.Location = New System.Drawing.Point(343, 177)
Me.CBIHentaiSD.Name = "CBIHentaiSD"
Me.CBIHentaiSD.Size = New System.Drawing.Size(19, 23)
Me.CBIHentaiSD.TabIndex = 27
Me.CBIHentaiSD.UseVisualStyleBackColor = true
'
'CBIBlowjobSD
'
Me.CBIBlowjobSD.AutoSize = true
Me.CBIBlowjobSD.Checked = Global.Tease_AI.My.MySettings.Default.IBlowjobSD
Me.CBIBlowjobSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIBlowjobSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IBlowjobSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIBlowjobSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIBlowjobSD.ForeColor = System.Drawing.Color.Black
Me.CBIBlowjobSD.Location = New System.Drawing.Point(343, 90)
Me.CBIBlowjobSD.Name = "CBIBlowjobSD"
Me.CBIBlowjobSD.Size = New System.Drawing.Size(19, 23)
Me.CBIBlowjobSD.TabIndex = 15
Me.CBIBlowjobSD.UseVisualStyleBackColor = true
'
'CBIFemdomSD
'
Me.CBIFemdomSD.AutoSize = true
Me.CBIFemdomSD.Checked = Global.Tease_AI.My.MySettings.Default.IFemdomSD
Me.CBIFemdomSD.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIFemdomSD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "IFemdomSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIFemdomSD.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIFemdomSD.ForeColor = System.Drawing.Color.Black
Me.CBIFemdomSD.Location = New System.Drawing.Point(343, 119)
Me.CBIFemdomSD.Name = "CBIFemdomSD"
Me.CBIFemdomSD.Size = New System.Drawing.Size(19, 23)
Me.CBIFemdomSD.TabIndex = 19
Me.CBIFemdomSD.UseVisualStyleBackColor = true
'
'TbxIButts
'
Me.TbxIButts.BackColor = System.Drawing.Color.LightGray
Me.TbxIButts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIButts.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "LBLButtPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIButts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIButts.ForeColor = System.Drawing.Color.Black
Me.TbxIButts.Location = New System.Drawing.Point(115, 353)
Me.TbxIButts.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIButts.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIButts.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIButts.Name = "TbxIButts"
Me.TbxIButts.ReadOnly = true
Me.TbxIButts.Size = New System.Drawing.Size(217, 17)
Me.TbxIButts.TabIndex = 50
Me.TbxIButts.Text = Global.Tease_AI.My.MySettings.Default.LBLButtPath
'
'CBIFemdom
'
Me.CBIFemdom.AutoSize = true
Me.CBIFemdom.Checked = Global.Tease_AI.My.MySettings.Default.CBIFemdom
Me.CBIFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIFemdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIFemdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIFemdom.ForeColor = System.Drawing.Color.Black
Me.CBIFemdom.Location = New System.Drawing.Point(3, 119)
Me.CBIFemdom.Name = "CBIFemdom"
Me.CBIFemdom.Size = New System.Drawing.Size(70, 23)
Me.CBIFemdom.TabIndex = 16
Me.CBIFemdom.Text = "Femdom"
Me.CBIFemdom.UseVisualStyleBackColor = true
'
'TbxILesbian
'
Me.TbxILesbian.BackColor = System.Drawing.Color.LightGray
Me.TbxILesbian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxILesbian.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "ILesbian", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxILesbian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxILesbian.ForeColor = System.Drawing.Color.Black
Me.TbxILesbian.Location = New System.Drawing.Point(115, 63)
Me.TbxILesbian.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxILesbian.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxILesbian.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxILesbian.Name = "TbxILesbian"
Me.TbxILesbian.ReadOnly = true
Me.TbxILesbian.Size = New System.Drawing.Size(217, 17)
Me.TbxILesbian.TabIndex = 10
Me.TbxILesbian.Text = Global.Tease_AI.My.MySettings.Default.ILesbian
'
'BTNISoftcore
'
Me.BTNISoftcore.BackColor = System.Drawing.Color.LightGray
Me.BTNISoftcore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNISoftcore.ForeColor = System.Drawing.Color.Black
Me.BTNISoftcore.Location = New System.Drawing.Point(76, 29)
Me.BTNISoftcore.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNISoftcore.Name = "BTNISoftcore"
Me.BTNISoftcore.Size = New System.Drawing.Size(34, 28)
Me.BTNISoftcore.TabIndex = 5
Me.BTNISoftcore.Text = "1"
Me.BTNISoftcore.UseVisualStyleBackColor = false
'
'CBILezdom
'
Me.CBILezdom.AutoSize = true
Me.CBILezdom.Checked = Global.Tease_AI.My.MySettings.Default.CBILezdom
Me.CBILezdom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBILezdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBILezdom.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBILezdom.ForeColor = System.Drawing.Color.Black
Me.CBILezdom.Location = New System.Drawing.Point(3, 148)
Me.CBILezdom.Name = "CBILezdom"
Me.CBILezdom.Size = New System.Drawing.Size(70, 23)
Me.CBILezdom.TabIndex = 20
Me.CBILezdom.Text = "Lezdom"
Me.CBILezdom.UseVisualStyleBackColor = true
'
'TbxIBoobs
'
Me.TbxIBoobs.BackColor = System.Drawing.Color.LightGray
Me.TbxIBoobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIBoobs.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "LBLBoobPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIBoobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIBoobs.ForeColor = System.Drawing.Color.Black
Me.TbxIBoobs.Location = New System.Drawing.Point(115, 324)
Me.TbxIBoobs.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIBoobs.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIBoobs.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIBoobs.Name = "TbxIBoobs"
Me.TbxIBoobs.ReadOnly = true
Me.TbxIBoobs.Size = New System.Drawing.Size(217, 17)
Me.TbxIBoobs.TabIndex = 46
Me.TbxIBoobs.Text = Global.Tease_AI.My.MySettings.Default.LBLBoobPath
'
'CBIHentai
'
Me.CBIHentai.AutoSize = true
Me.CBIHentai.Checked = Global.Tease_AI.My.MySettings.Default.CBIHentai
Me.CBIHentai.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIHentai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIHentai.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIHentai.ForeColor = System.Drawing.Color.Black
Me.CBIHentai.Location = New System.Drawing.Point(3, 177)
Me.CBIHentai.Name = "CBIHentai"
Me.CBIHentai.Size = New System.Drawing.Size(70, 23)
Me.CBIHentai.TabIndex = 24
Me.CBIHentai.Text = "Hentai"
Me.CBIHentai.UseVisualStyleBackColor = true
'
'TbxIBlowjob
'
Me.TbxIBlowjob.BackColor = System.Drawing.Color.LightGray
Me.TbxIBlowjob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IBlowjob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIBlowjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIBlowjob.ForeColor = System.Drawing.Color.Black
Me.TbxIBlowjob.Location = New System.Drawing.Point(115, 92)
Me.TbxIBlowjob.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIBlowjob.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIBlowjob.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIBlowjob.Name = "TbxIBlowjob"
Me.TbxIBlowjob.ReadOnly = true
Me.TbxIBlowjob.Size = New System.Drawing.Size(217, 17)
Me.TbxIBlowjob.TabIndex = 14
Me.TbxIBlowjob.Text = Global.Tease_AI.My.MySettings.Default.IBlowjob
'
'CBIGay
'
Me.CBIGay.AutoSize = true
Me.CBIGay.Checked = Global.Tease_AI.My.MySettings.Default.CBIGay
Me.CBIGay.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIGay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIGay.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIGay.ForeColor = System.Drawing.Color.Black
Me.CBIGay.Location = New System.Drawing.Point(3, 206)
Me.CBIGay.Name = "CBIGay"
Me.CBIGay.Size = New System.Drawing.Size(70, 23)
Me.CBIGay.TabIndex = 28
Me.CBIGay.Text = "Gay"
Me.CBIGay.UseVisualStyleBackColor = true
'
'TbxIGeneral
'
Me.TbxIGeneral.BackColor = System.Drawing.Color.LightGray
Me.TbxIGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IGeneral", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIGeneral.ForeColor = System.Drawing.Color.Black
Me.TbxIGeneral.Location = New System.Drawing.Point(115, 295)
Me.TbxIGeneral.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIGeneral.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIGeneral.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIGeneral.Name = "TbxIGeneral"
Me.TbxIGeneral.ReadOnly = true
Me.TbxIGeneral.Size = New System.Drawing.Size(217, 17)
Me.TbxIGeneral.TabIndex = 42
Me.TbxIGeneral.Text = Global.Tease_AI.My.MySettings.Default.IGeneral
'
'CBIMaledom
'
Me.CBIMaledom.AutoSize = true
Me.CBIMaledom.Checked = Global.Tease_AI.My.MySettings.Default.CBIMaledom
Me.CBIMaledom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIMaledom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIMaledom.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIMaledom.ForeColor = System.Drawing.Color.Black
Me.CBIMaledom.Location = New System.Drawing.Point(3, 235)
Me.CBIMaledom.Name = "CBIMaledom"
Me.CBIMaledom.Size = New System.Drawing.Size(70, 23)
Me.CBIMaledom.TabIndex = 32
Me.CBIMaledom.Text = "Maledom"
Me.CBIMaledom.UseVisualStyleBackColor = true
'
'TbxIFemdom
'
Me.TbxIFemdom.BackColor = System.Drawing.Color.LightGray
Me.TbxIFemdom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IFemdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIFemdom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIFemdom.ForeColor = System.Drawing.Color.Black
Me.TbxIFemdom.Location = New System.Drawing.Point(115, 121)
Me.TbxIFemdom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIFemdom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIFemdom.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIFemdom.Name = "TbxIFemdom"
Me.TbxIFemdom.ReadOnly = true
Me.TbxIFemdom.Size = New System.Drawing.Size(217, 17)
Me.TbxIFemdom.TabIndex = 18
Me.TbxIFemdom.Text = Global.Tease_AI.My.MySettings.Default.IFemdom
'
'BTNILesbian
'
Me.BTNILesbian.BackColor = System.Drawing.Color.LightGray
Me.BTNILesbian.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNILesbian.ForeColor = System.Drawing.Color.Black
Me.BTNILesbian.Location = New System.Drawing.Point(76, 58)
Me.BTNILesbian.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNILesbian.Name = "BTNILesbian"
Me.BTNILesbian.Size = New System.Drawing.Size(34, 28)
Me.BTNILesbian.TabIndex = 9
Me.BTNILesbian.Text = "1"
Me.BTNILesbian.UseVisualStyleBackColor = false
'
'TbxICaptions
'
Me.TbxICaptions.BackColor = System.Drawing.Color.LightGray
Me.TbxICaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxICaptions.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "ICaptions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxICaptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxICaptions.ForeColor = System.Drawing.Color.Black
Me.TbxICaptions.Location = New System.Drawing.Point(115, 266)
Me.TbxICaptions.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxICaptions.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxICaptions.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxICaptions.Name = "TbxICaptions"
Me.TbxICaptions.ReadOnly = true
Me.TbxICaptions.Size = New System.Drawing.Size(217, 17)
Me.TbxICaptions.TabIndex = 38
Me.TbxICaptions.Text = Global.Tease_AI.My.MySettings.Default.ICaptions
'
'CBICaptions
'
Me.CBICaptions.AutoSize = true
Me.CBICaptions.Checked = Global.Tease_AI.My.MySettings.Default.CBICaptions
Me.CBICaptions.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBICaptions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBICaptions.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBICaptions.ForeColor = System.Drawing.Color.Black
Me.CBICaptions.Location = New System.Drawing.Point(3, 264)
Me.CBICaptions.Name = "CBICaptions"
Me.CBICaptions.Size = New System.Drawing.Size(70, 23)
Me.CBICaptions.TabIndex = 36
Me.CBICaptions.Text = "Captions"
Me.CBICaptions.UseVisualStyleBackColor = true
'
'TbxILezdom
'
Me.TbxILezdom.BackColor = System.Drawing.Color.LightGray
Me.TbxILezdom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxILezdom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "ILezdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxILezdom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxILezdom.ForeColor = System.Drawing.Color.Black
Me.TbxILezdom.Location = New System.Drawing.Point(115, 150)
Me.TbxILezdom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxILezdom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxILezdom.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxILezdom.Name = "TbxILezdom"
Me.TbxILezdom.ReadOnly = true
Me.TbxILezdom.Size = New System.Drawing.Size(217, 17)
Me.TbxILezdom.TabIndex = 22
Me.TbxILezdom.Text = Global.Tease_AI.My.MySettings.Default.ILezdom
'
'TbxIMaledom
'
Me.TbxIMaledom.BackColor = System.Drawing.Color.LightGray
Me.TbxIMaledom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIMaledom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IMaledom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIMaledom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIMaledom.ForeColor = System.Drawing.Color.Black
Me.TbxIMaledom.Location = New System.Drawing.Point(115, 237)
Me.TbxIMaledom.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIMaledom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIMaledom.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIMaledom.Name = "TbxIMaledom"
Me.TbxIMaledom.ReadOnly = true
Me.TbxIMaledom.Size = New System.Drawing.Size(217, 17)
Me.TbxIMaledom.TabIndex = 34
Me.TbxIMaledom.Text = Global.Tease_AI.My.MySettings.Default.IMaledom
'
'BTNButtPath
'
Me.BTNButtPath.BackColor = System.Drawing.Color.LightGray
Me.BTNButtPath.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNButtPath.ForeColor = System.Drawing.Color.Black
Me.BTNButtPath.Location = New System.Drawing.Point(76, 348)
Me.BTNButtPath.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNButtPath.Name = "BTNButtPath"
Me.BTNButtPath.Size = New System.Drawing.Size(34, 28)
Me.BTNButtPath.TabIndex = 49
Me.BTNButtPath.Text = "1"
Me.BTNButtPath.UseVisualStyleBackColor = false
'
'TbxIHentai
'
Me.TbxIHentai.BackColor = System.Drawing.Color.LightGray
Me.TbxIHentai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIHentai.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IHentai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIHentai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIHentai.ForeColor = System.Drawing.Color.Black
Me.TbxIHentai.Location = New System.Drawing.Point(115, 179)
Me.TbxIHentai.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIHentai.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIHentai.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIHentai.Name = "TbxIHentai"
Me.TbxIHentai.ReadOnly = true
Me.TbxIHentai.Size = New System.Drawing.Size(217, 17)
Me.TbxIHentai.TabIndex = 26
Me.TbxIHentai.Text = Global.Tease_AI.My.MySettings.Default.IHentai
'
'CBIGeneral
'
Me.CBIGeneral.AutoSize = true
Me.CBIGeneral.Checked = Global.Tease_AI.My.MySettings.Default.CBIGeneral
Me.CBIGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIGeneral", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIGeneral.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIGeneral.ForeColor = System.Drawing.Color.Black
Me.CBIGeneral.Location = New System.Drawing.Point(3, 293)
Me.CBIGeneral.Name = "CBIGeneral"
Me.CBIGeneral.Size = New System.Drawing.Size(70, 23)
Me.CBIGeneral.TabIndex = 40
Me.CBIGeneral.Text = "General"
Me.CBIGeneral.UseVisualStyleBackColor = true
'
'TbxIGay
'
Me.TbxIGay.BackColor = System.Drawing.Color.LightGray
Me.TbxIGay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxIGay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "IGay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxIGay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxIGay.ForeColor = System.Drawing.Color.Black
Me.TbxIGay.Location = New System.Drawing.Point(115, 208)
Me.TbxIGay.Margin = New System.Windows.Forms.Padding(5, 5, 8, 3)
Me.TbxIGay.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxIGay.MinimumSize = New System.Drawing.Size(217, 17)
Me.TbxIGay.Name = "TbxIGay"
Me.TbxIGay.ReadOnly = true
Me.TbxIGay.Size = New System.Drawing.Size(217, 17)
Me.TbxIGay.TabIndex = 30
Me.TbxIGay.Text = Global.Tease_AI.My.MySettings.Default.IGay
'
'CBIBoobs
'
Me.CBIBoobs.AutoSize = true
Me.CBIBoobs.Checked = Global.Tease_AI.My.MySettings.Default.CBIBoobs
Me.CBIBoobs.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIBoobs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIBoobs.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIBoobs.ForeColor = System.Drawing.Color.Black
Me.CBIBoobs.Location = New System.Drawing.Point(3, 322)
Me.CBIBoobs.Name = "CBIBoobs"
Me.CBIBoobs.Size = New System.Drawing.Size(70, 23)
Me.CBIBoobs.TabIndex = 44
Me.CBIBoobs.Text = "Boobs"
Me.CBIBoobs.UseVisualStyleBackColor = true
'
'CBIButts
'
Me.CBIButts.AutoSize = true
Me.CBIButts.Checked = Global.Tease_AI.My.MySettings.Default.CBIButts
Me.CBIButts.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIButts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIButts.Dock = System.Windows.Forms.DockStyle.Fill
Me.CBIButts.ForeColor = System.Drawing.Color.Black
Me.CBIButts.Location = New System.Drawing.Point(3, 351)
Me.CBIButts.Name = "CBIButts"
Me.CBIButts.Size = New System.Drawing.Size(70, 27)
Me.CBIButts.TabIndex = 48
Me.CBIButts.Text = "Butts"
Me.CBIButts.UseVisualStyleBackColor = true
'
'BTNIBlowjob
'
Me.BTNIBlowjob.BackColor = System.Drawing.Color.LightGray
Me.BTNIBlowjob.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIBlowjob.ForeColor = System.Drawing.Color.Black
Me.BTNIBlowjob.Location = New System.Drawing.Point(76, 87)
Me.BTNIBlowjob.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIBlowjob.Name = "BTNIBlowjob"
Me.BTNIBlowjob.Size = New System.Drawing.Size(34, 28)
Me.BTNIBlowjob.TabIndex = 13
Me.BTNIBlowjob.Text = "1"
Me.BTNIBlowjob.UseVisualStyleBackColor = false
'
'BTNIFemdom
'
Me.BTNIFemdom.BackColor = System.Drawing.Color.LightGray
Me.BTNIFemdom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIFemdom.ForeColor = System.Drawing.Color.Black
Me.BTNIFemdom.Location = New System.Drawing.Point(76, 116)
Me.BTNIFemdom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIFemdom.Name = "BTNIFemdom"
Me.BTNIFemdom.Size = New System.Drawing.Size(34, 28)
Me.BTNIFemdom.TabIndex = 17
Me.BTNIFemdom.Text = "1"
Me.BTNIFemdom.UseVisualStyleBackColor = false
'
'BTNBoobPath
'
Me.BTNBoobPath.BackColor = System.Drawing.Color.LightGray
Me.BTNBoobPath.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNBoobPath.ForeColor = System.Drawing.Color.Black
Me.BTNBoobPath.Location = New System.Drawing.Point(76, 319)
Me.BTNBoobPath.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNBoobPath.Name = "BTNBoobPath"
Me.BTNBoobPath.Size = New System.Drawing.Size(34, 28)
Me.BTNBoobPath.TabIndex = 45
Me.BTNBoobPath.Text = "1"
Me.BTNBoobPath.UseVisualStyleBackColor = false
'
'BTNILezdom
'
Me.BTNILezdom.BackColor = System.Drawing.Color.LightGray
Me.BTNILezdom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNILezdom.ForeColor = System.Drawing.Color.Black
Me.BTNILezdom.Location = New System.Drawing.Point(76, 145)
Me.BTNILezdom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNILezdom.Name = "BTNILezdom"
Me.BTNILezdom.Size = New System.Drawing.Size(34, 28)
Me.BTNILezdom.TabIndex = 21
Me.BTNILezdom.Text = "1"
Me.BTNILezdom.UseVisualStyleBackColor = false
'
'BTNIHentai
'
Me.BTNIHentai.BackColor = System.Drawing.Color.LightGray
Me.BTNIHentai.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIHentai.ForeColor = System.Drawing.Color.Black
Me.BTNIHentai.Location = New System.Drawing.Point(76, 174)
Me.BTNIHentai.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIHentai.Name = "BTNIHentai"
Me.BTNIHentai.Size = New System.Drawing.Size(34, 28)
Me.BTNIHentai.TabIndex = 25
Me.BTNIHentai.Text = "1"
Me.BTNIHentai.UseVisualStyleBackColor = false
'
'BTNIGay
'
Me.BTNIGay.BackColor = System.Drawing.Color.LightGray
Me.BTNIGay.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIGay.ForeColor = System.Drawing.Color.Black
Me.BTNIGay.Location = New System.Drawing.Point(76, 203)
Me.BTNIGay.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIGay.Name = "BTNIGay"
Me.BTNIGay.Size = New System.Drawing.Size(34, 28)
Me.BTNIGay.TabIndex = 29
Me.BTNIGay.Text = "1"
Me.BTNIGay.UseVisualStyleBackColor = false
'
'BTNIMaledom
'
Me.BTNIMaledom.BackColor = System.Drawing.Color.LightGray
Me.BTNIMaledom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIMaledom.ForeColor = System.Drawing.Color.Black
Me.BTNIMaledom.Location = New System.Drawing.Point(76, 232)
Me.BTNIMaledom.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIMaledom.Name = "BTNIMaledom"
Me.BTNIMaledom.Size = New System.Drawing.Size(34, 28)
Me.BTNIMaledom.TabIndex = 33
Me.BTNIMaledom.Text = "1"
Me.BTNIMaledom.UseVisualStyleBackColor = false
'
'BTNICaptions
'
Me.BTNICaptions.BackColor = System.Drawing.Color.LightGray
Me.BTNICaptions.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNICaptions.ForeColor = System.Drawing.Color.Black
Me.BTNICaptions.Location = New System.Drawing.Point(76, 261)
Me.BTNICaptions.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNICaptions.Name = "BTNICaptions"
Me.BTNICaptions.Size = New System.Drawing.Size(34, 28)
Me.BTNICaptions.TabIndex = 37
Me.BTNICaptions.Text = "1"
Me.BTNICaptions.UseVisualStyleBackColor = false
'
'BTNIGeneral
'
Me.BTNIGeneral.BackColor = System.Drawing.Color.LightGray
Me.BTNIGeneral.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNIGeneral.ForeColor = System.Drawing.Color.Black
Me.BTNIGeneral.Location = New System.Drawing.Point(76, 290)
Me.BTNIGeneral.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
Me.BTNIGeneral.Name = "BTNIGeneral"
Me.BTNIGeneral.Size = New System.Drawing.Size(34, 28)
Me.BTNIGeneral.TabIndex = 41
Me.BTNIGeneral.Text = "1"
Me.BTNIGeneral.UseVisualStyleBackColor = false
'
'TabPage33
'
Me.TabPage33.BackColor = System.Drawing.Color.Silver
Me.TabPage33.Controls.Add(Me.TabControl5)
Me.TabPage33.Location = New System.Drawing.Point(4, 22)
Me.TabPage33.Name = "TabPage33"
Me.TabPage33.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage33.Size = New System.Drawing.Size(720, 448)
Me.TabPage33.TabIndex = 21
Me.TabPage33.Text = "Tagging"
'
'TabControl5
'
Me.TabControl5.Controls.Add(Me.TabPage34)
Me.TabControl5.Controls.Add(Me.TabPage35)
Me.TabControl5.Location = New System.Drawing.Point(6, 6)
Me.TabControl5.Name = "TabControl5"
Me.TabControl5.SelectedIndex = 0
Me.TabControl5.Size = New System.Drawing.Size(708, 437)
Me.TabControl5.TabIndex = 0
'
'TabPage34
'
Me.TabPage34.BackColor = System.Drawing.Color.LightGray
Me.TabPage34.Controls.Add(Me.CBTagSeeThrough)
Me.TabPage34.Controls.Add(Me.CBTagAllFours)
Me.TabPage34.Controls.Add(Me.CBTagGlaring)
Me.TabPage34.Controls.Add(Me.CBTagSmiling)
Me.TabPage34.Controls.Add(Me.TBTagDir)
Me.TabPage34.Controls.Add(Me.CBTagPiercing)
Me.TabPage34.Controls.Add(Me.CBTagLegs)
Me.TabPage34.Controls.Add(Me.TBTagFurniture)
Me.TabPage34.Controls.Add(Me.CBTagFurniture)
Me.TabPage34.Controls.Add(Me.TBTagSexToy)
Me.TabPage34.Controls.Add(Me.CBTagSexToy)
Me.TabPage34.Controls.Add(Me.TBTagTattoo)
Me.TabPage34.Controls.Add(Me.CBTagTattoo)
Me.TabPage34.Controls.Add(Me.TBTagUnderwear)
Me.TabPage34.Controls.Add(Me.CBTagUnderwear)
Me.TabPage34.Controls.Add(Me.TBTagGarment)
Me.TabPage34.Controls.Add(Me.CBTagGarment)
Me.TabPage34.Controls.Add(Me.Label72)
Me.TabPage34.Controls.Add(Me.CBTagHandsCovering)
Me.TabPage34.Controls.Add(Me.CBTagGarmentCovering)
Me.TabPage34.Controls.Add(Me.CBTagCloseUp)
Me.TabPage34.Controls.Add(Me.CBTagNaked)
Me.TabPage34.Controls.Add(Me.CBTagSideView)
Me.TabPage34.Controls.Add(Me.BTNTagPrevious)
Me.TabPage34.Controls.Add(Me.CBTagHalfDressed)
Me.TabPage34.Controls.Add(Me.BTNTagNext)
Me.TabPage34.Controls.Add(Me.CBTagFullyDressed)
Me.TabPage34.Controls.Add(Me.LBLTagCount)
Me.TabPage34.Controls.Add(Me.CBTagSucking)
Me.TabPage34.Controls.Add(Me.CBTagMasturbating)
Me.TabPage34.Controls.Add(Me.CBTagFeet)
Me.TabPage34.Controls.Add(Me.CBTagBoobs)
Me.TabPage34.Controls.Add(Me.CBTagAss)
Me.TabPage34.Controls.Add(Me.CBTagPussy)
Me.TabPage34.Controls.Add(Me.BTNTagSave)
Me.TabPage34.Controls.Add(Me.BTNTagDir)
Me.TabPage34.Controls.Add(Me.ImageTagPictureBox)
Me.TabPage34.Controls.Add(Me.CBTagFace)
Me.TabPage34.Location = New System.Drawing.Point(4, 22)
Me.TabPage34.Name = "TabPage34"
Me.TabPage34.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage34.Size = New System.Drawing.Size(700, 411)
Me.TabPage34.TabIndex = 0
Me.TabPage34.Text = "Domme Tags"
'
'CBTagSeeThrough
'
Me.CBTagSeeThrough.AutoSize = true
Me.CBTagSeeThrough.Enabled = false
Me.CBTagSeeThrough.Location = New System.Drawing.Point(577, 117)
Me.CBTagSeeThrough.Name = "CBTagSeeThrough"
Me.CBTagSeeThrough.Size = New System.Drawing.Size(87, 17)
Me.CBTagSeeThrough.TabIndex = 226
Me.CBTagSeeThrough.Text = "See Through"
Me.CBTagSeeThrough.UseVisualStyleBackColor = true
'
'CBTagAllFours
'
Me.CBTagAllFours.AutoSize = true
Me.CBTagAllFours.Enabled = false
Me.CBTagAllFours.ForeColor = System.Drawing.Color.Black
Me.CBTagAllFours.Location = New System.Drawing.Point(577, 207)
Me.CBTagAllFours.Name = "CBTagAllFours"
Me.CBTagAllFours.Size = New System.Drawing.Size(66, 17)
Me.CBTagAllFours.TabIndex = 225
Me.CBTagAllFours.Text = "All Fours"
Me.CBTagAllFours.UseVisualStyleBackColor = true
'
'CBTagGlaring
'
Me.CBTagGlaring.AutoSize = true
Me.CBTagGlaring.Enabled = false
Me.CBTagGlaring.ForeColor = System.Drawing.Color.Black
Me.CBTagGlaring.Location = New System.Drawing.Point(484, 227)
Me.CBTagGlaring.Name = "CBTagGlaring"
Me.CBTagGlaring.Size = New System.Drawing.Size(59, 17)
Me.CBTagGlaring.TabIndex = 224
Me.CBTagGlaring.Text = "Glaring"
Me.CBTagGlaring.UseVisualStyleBackColor = true
'
'CBTagSmiling
'
Me.CBTagSmiling.AutoSize = true
Me.CBTagSmiling.Enabled = false
Me.CBTagSmiling.ForeColor = System.Drawing.Color.Black
Me.CBTagSmiling.Location = New System.Drawing.Point(484, 207)
Me.CBTagSmiling.Name = "CBTagSmiling"
Me.CBTagSmiling.Size = New System.Drawing.Size(59, 17)
Me.CBTagSmiling.TabIndex = 223
Me.CBTagSmiling.Text = "Smiling"
Me.CBTagSmiling.UseVisualStyleBackColor = true
'
'TBTagDir
'
Me.TBTagDir.Location = New System.Drawing.Point(55, 9)
Me.TBTagDir.Name = "TBTagDir"
Me.TBTagDir.Size = New System.Drawing.Size(330, 20)
Me.TBTagDir.TabIndex = 222
Me.TBTagDir.Text = "Enter Image Directory"
'
'CBTagPiercing
'
Me.CBTagPiercing.AutoSize = true
Me.CBTagPiercing.Enabled = false
Me.CBTagPiercing.ForeColor = System.Drawing.Color.Black
Me.CBTagPiercing.Location = New System.Drawing.Point(577, 227)
Me.CBTagPiercing.Name = "CBTagPiercing"
Me.CBTagPiercing.Size = New System.Drawing.Size(64, 17)
Me.CBTagPiercing.TabIndex = 221
Me.CBTagPiercing.Text = "Piercing"
Me.CBTagPiercing.UseVisualStyleBackColor = true
'
'CBTagLegs
'
Me.CBTagLegs.AutoSize = true
Me.CBTagLegs.Enabled = false
Me.CBTagLegs.ForeColor = System.Drawing.Color.Black
Me.CBTagLegs.Location = New System.Drawing.Point(484, 117)
Me.CBTagLegs.Name = "CBTagLegs"
Me.CBTagLegs.Size = New System.Drawing.Size(49, 17)
Me.CBTagLegs.TabIndex = 220
Me.CBTagLegs.Text = "Legs"
Me.CBTagLegs.UseVisualStyleBackColor = true
'
'TBTagFurniture
'
Me.TBTagFurniture.Enabled = false
Me.TBTagFurniture.Location = New System.Drawing.Point(559, 370)
Me.TBTagFurniture.Name = "TBTagFurniture"
Me.TBTagFurniture.Size = New System.Drawing.Size(108, 20)
Me.TBTagFurniture.TabIndex = 219
'
'CBTagFurniture
'
Me.CBTagFurniture.AutoSize = true
Me.CBTagFurniture.Enabled = false
Me.CBTagFurniture.ForeColor = System.Drawing.Color.Black
Me.CBTagFurniture.Location = New System.Drawing.Point(476, 372)
Me.CBTagFurniture.Name = "CBTagFurniture"
Me.CBTagFurniture.Size = New System.Drawing.Size(67, 17)
Me.CBTagFurniture.TabIndex = 218
Me.CBTagFurniture.Text = "Furniture"
Me.CBTagFurniture.UseVisualStyleBackColor = true
'
'TBTagSexToy
'
Me.TBTagSexToy.Enabled = false
Me.TBTagSexToy.Location = New System.Drawing.Point(560, 346)
Me.TBTagSexToy.Name = "TBTagSexToy"
Me.TBTagSexToy.Size = New System.Drawing.Size(108, 20)
Me.TBTagSexToy.TabIndex = 217
'
'CBTagSexToy
'
Me.CBTagSexToy.AutoSize = true
Me.CBTagSexToy.Enabled = false
Me.CBTagSexToy.ForeColor = System.Drawing.Color.Black
Me.CBTagSexToy.Location = New System.Drawing.Point(476, 348)
Me.CBTagSexToy.Name = "CBTagSexToy"
Me.CBTagSexToy.Size = New System.Drawing.Size(65, 17)
Me.CBTagSexToy.TabIndex = 216
Me.CBTagSexToy.Text = "Sex Toy"
Me.CBTagSexToy.UseVisualStyleBackColor = true
'
'TBTagTattoo
'
Me.TBTagTattoo.Enabled = false
Me.TBTagTattoo.Location = New System.Drawing.Point(560, 322)
Me.TBTagTattoo.Name = "TBTagTattoo"
Me.TBTagTattoo.Size = New System.Drawing.Size(108, 20)
Me.TBTagTattoo.TabIndex = 215
'
'CBTagTattoo
'
Me.CBTagTattoo.AutoSize = true
Me.CBTagTattoo.Enabled = false
Me.CBTagTattoo.ForeColor = System.Drawing.Color.Black
Me.CBTagTattoo.Location = New System.Drawing.Point(476, 324)
Me.CBTagTattoo.Name = "CBTagTattoo"
Me.CBTagTattoo.Size = New System.Drawing.Size(57, 17)
Me.CBTagTattoo.TabIndex = 214
Me.CBTagTattoo.Text = "Tattoo"
Me.CBTagTattoo.UseVisualStyleBackColor = true
'
'TBTagUnderwear
'
Me.TBTagUnderwear.Enabled = false
Me.TBTagUnderwear.Location = New System.Drawing.Point(560, 298)
Me.TBTagUnderwear.Name = "TBTagUnderwear"
Me.TBTagUnderwear.Size = New System.Drawing.Size(108, 20)
Me.TBTagUnderwear.TabIndex = 213
'
'CBTagUnderwear
'
Me.CBTagUnderwear.AutoSize = true
Me.CBTagUnderwear.Enabled = false
Me.CBTagUnderwear.ForeColor = System.Drawing.Color.Black
Me.CBTagUnderwear.Location = New System.Drawing.Point(476, 300)
Me.CBTagUnderwear.Name = "CBTagUnderwear"
Me.CBTagUnderwear.Size = New System.Drawing.Size(78, 17)
Me.CBTagUnderwear.TabIndex = 212
Me.CBTagUnderwear.Text = "Underwear"
Me.CBTagUnderwear.UseVisualStyleBackColor = true
'
'TBTagGarment
'
Me.TBTagGarment.Enabled = false
Me.TBTagGarment.Location = New System.Drawing.Point(560, 274)
Me.TBTagGarment.Name = "TBTagGarment"
Me.TBTagGarment.Size = New System.Drawing.Size(108, 20)
Me.TBTagGarment.TabIndex = 211
'
'CBTagGarment
'
Me.CBTagGarment.AutoSize = true
Me.CBTagGarment.Enabled = false
Me.CBTagGarment.ForeColor = System.Drawing.Color.Black
Me.CBTagGarment.Location = New System.Drawing.Point(476, 276)
Me.CBTagGarment.Name = "CBTagGarment"
Me.CBTagGarment.Size = New System.Drawing.Size(66, 17)
Me.CBTagGarment.TabIndex = 210
Me.CBTagGarment.Text = "Garment"
Me.CBTagGarment.UseVisualStyleBackColor = true
'
'Label72
'
Me.Label72.BackColor = System.Drawing.Color.Transparent
Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label72.ForeColor = System.Drawing.Color.Black
Me.Label72.Location = New System.Drawing.Point(5, 368)
Me.Label72.Name = "Label72"
Me.Label72.Size = New System.Drawing.Size(451, 35)
Me.Label72.TabIndex = 189
Me.Label72.Text = "Open a directory containing images. Check all tags that apply to each image displ"& _ 
    "ayed, and enter one-word tag descriptions in the text fields when appropriate. ("& _ 
    "e.g. Garment: dress)"
Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'CBTagHandsCovering
'
Me.CBTagHandsCovering.AutoSize = true
Me.CBTagHandsCovering.Enabled = false
Me.CBTagHandsCovering.Location = New System.Drawing.Point(577, 97)
Me.CBTagHandsCovering.Name = "CBTagHandsCovering"
Me.CBTagHandsCovering.Size = New System.Drawing.Size(101, 17)
Me.CBTagHandsCovering.TabIndex = 209
Me.CBTagHandsCovering.Text = "Hands Covering"
Me.CBTagHandsCovering.UseVisualStyleBackColor = true
'
'CBTagGarmentCovering
'
Me.CBTagGarmentCovering.AutoSize = true
Me.CBTagGarmentCovering.Enabled = false
Me.CBTagGarmentCovering.Location = New System.Drawing.Point(577, 77)
Me.CBTagGarmentCovering.Name = "CBTagGarmentCovering"
Me.CBTagGarmentCovering.Size = New System.Drawing.Size(110, 17)
Me.CBTagGarmentCovering.TabIndex = 208
Me.CBTagGarmentCovering.Text = "Garment Covering"
Me.CBTagGarmentCovering.UseVisualStyleBackColor = true
'
'CBTagCloseUp
'
Me.CBTagCloseUp.AutoSize = true
Me.CBTagCloseUp.Enabled = false
Me.CBTagCloseUp.ForeColor = System.Drawing.Color.Black
Me.CBTagCloseUp.Location = New System.Drawing.Point(577, 187)
Me.CBTagCloseUp.Name = "CBTagCloseUp"
Me.CBTagCloseUp.Size = New System.Drawing.Size(69, 17)
Me.CBTagCloseUp.TabIndex = 205
Me.CBTagCloseUp.Text = "Close Up"
Me.CBTagCloseUp.UseVisualStyleBackColor = true
'
'CBTagNaked
'
Me.CBTagNaked.AutoSize = true
Me.CBTagNaked.Enabled = false
Me.CBTagNaked.Location = New System.Drawing.Point(577, 136)
Me.CBTagNaked.Name = "CBTagNaked"
Me.CBTagNaked.Size = New System.Drawing.Size(57, 17)
Me.CBTagNaked.TabIndex = 199
Me.CBTagNaked.Text = "Naked"
Me.CBTagNaked.UseVisualStyleBackColor = true
'
'CBTagSideView
'
Me.CBTagSideView.AutoSize = true
Me.CBTagSideView.Enabled = false
Me.CBTagSideView.ForeColor = System.Drawing.Color.Black
Me.CBTagSideView.Location = New System.Drawing.Point(577, 167)
Me.CBTagSideView.Name = "CBTagSideView"
Me.CBTagSideView.Size = New System.Drawing.Size(73, 17)
Me.CBTagSideView.TabIndex = 204
Me.CBTagSideView.Text = "Side View"
Me.CBTagSideView.UseVisualStyleBackColor = true
'
'BTNTagPrevious
'
Me.BTNTagPrevious.BackColor = System.Drawing.Color.LightGray
Me.BTNTagPrevious.Enabled = false
Me.BTNTagPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNTagPrevious.ForeColor = System.Drawing.Color.Black
Me.BTNTagPrevious.Location = New System.Drawing.Point(391, 8)
Me.BTNTagPrevious.Name = "BTNTagPrevious"
Me.BTNTagPrevious.Size = New System.Drawing.Size(47, 24)
Me.BTNTagPrevious.TabIndex = 207
Me.BTNTagPrevious.Text = "<<"
Me.BTNTagPrevious.UseVisualStyleBackColor = false
'
'CBTagHalfDressed
'
Me.CBTagHalfDressed.AutoSize = true
Me.CBTagHalfDressed.Enabled = false
Me.CBTagHalfDressed.Location = New System.Drawing.Point(577, 57)
Me.CBTagHalfDressed.Name = "CBTagHalfDressed"
Me.CBTagHalfDressed.Size = New System.Drawing.Size(86, 17)
Me.CBTagHalfDressed.TabIndex = 198
Me.CBTagHalfDressed.Text = "Half Dressed"
Me.CBTagHalfDressed.UseVisualStyleBackColor = true
'
'BTNTagNext
'
Me.BTNTagNext.BackColor = System.Drawing.Color.LightGray
Me.BTNTagNext.Enabled = false
Me.BTNTagNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNTagNext.ForeColor = System.Drawing.Color.Black
Me.BTNTagNext.Location = New System.Drawing.Point(560, 8)
Me.BTNTagNext.Name = "BTNTagNext"
Me.BTNTagNext.Size = New System.Drawing.Size(47, 24)
Me.BTNTagNext.TabIndex = 206
Me.BTNTagNext.Text = ">>"
Me.BTNTagNext.UseVisualStyleBackColor = false
'
'CBTagFullyDressed
'
Me.CBTagFullyDressed.AutoSize = true
Me.CBTagFullyDressed.Enabled = false
Me.CBTagFullyDressed.Location = New System.Drawing.Point(577, 37)
Me.CBTagFullyDressed.Name = "CBTagFullyDressed"
Me.CBTagFullyDressed.Size = New System.Drawing.Size(88, 17)
Me.CBTagFullyDressed.TabIndex = 197
Me.CBTagFullyDressed.Text = "Fully Dressed"
Me.CBTagFullyDressed.UseVisualStyleBackColor = true
'
'LBLTagCount
'
Me.LBLTagCount.BackColor = System.Drawing.Color.Transparent
Me.LBLTagCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLTagCount.Enabled = false
Me.LBLTagCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLTagCount.ForeColor = System.Drawing.Color.Black
Me.LBLTagCount.Location = New System.Drawing.Point(444, 10)
Me.LBLTagCount.Name = "LBLTagCount"
Me.LBLTagCount.Size = New System.Drawing.Size(110, 20)
Me.LBLTagCount.TabIndex = 203
Me.LBLTagCount.Text = "0/0"
Me.LBLTagCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBTagSucking
'
Me.CBTagSucking.AutoSize = true
Me.CBTagSucking.Enabled = false
Me.CBTagSucking.ForeColor = System.Drawing.Color.Black
Me.CBTagSucking.Location = New System.Drawing.Point(484, 187)
Me.CBTagSucking.Name = "CBTagSucking"
Me.CBTagSucking.Size = New System.Drawing.Size(65, 17)
Me.CBTagSucking.TabIndex = 202
Me.CBTagSucking.Text = "Sucking"
Me.CBTagSucking.UseVisualStyleBackColor = true
'
'CBTagMasturbating
'
Me.CBTagMasturbating.AutoSize = true
Me.CBTagMasturbating.Enabled = false
Me.CBTagMasturbating.ForeColor = System.Drawing.Color.Black
Me.CBTagMasturbating.Location = New System.Drawing.Point(484, 167)
Me.CBTagMasturbating.Name = "CBTagMasturbating"
Me.CBTagMasturbating.Size = New System.Drawing.Size(87, 17)
Me.CBTagMasturbating.TabIndex = 201
Me.CBTagMasturbating.Text = "Masturbating"
Me.CBTagMasturbating.UseVisualStyleBackColor = true
'
'CBTagFeet
'
Me.CBTagFeet.AutoSize = true
Me.CBTagFeet.Enabled = false
Me.CBTagFeet.ForeColor = System.Drawing.Color.Black
Me.CBTagFeet.Location = New System.Drawing.Point(484, 137)
Me.CBTagFeet.Name = "CBTagFeet"
Me.CBTagFeet.Size = New System.Drawing.Size(47, 17)
Me.CBTagFeet.TabIndex = 200
Me.CBTagFeet.Text = "Feet"
Me.CBTagFeet.UseVisualStyleBackColor = true
'
'CBTagBoobs
'
Me.CBTagBoobs.AutoSize = true
Me.CBTagBoobs.Enabled = false
Me.CBTagBoobs.ForeColor = System.Drawing.Color.Black
Me.CBTagBoobs.Location = New System.Drawing.Point(484, 57)
Me.CBTagBoobs.Name = "CBTagBoobs"
Me.CBTagBoobs.Size = New System.Drawing.Size(56, 17)
Me.CBTagBoobs.TabIndex = 196
Me.CBTagBoobs.Text = "Boobs"
Me.CBTagBoobs.UseVisualStyleBackColor = true
'
'CBTagAss
'
Me.CBTagAss.AutoSize = true
Me.CBTagAss.Enabled = false
Me.CBTagAss.ForeColor = System.Drawing.Color.Black
Me.CBTagAss.Location = New System.Drawing.Point(484, 97)
Me.CBTagAss.Name = "CBTagAss"
Me.CBTagAss.Size = New System.Drawing.Size(43, 17)
Me.CBTagAss.TabIndex = 195
Me.CBTagAss.Text = "Ass"
Me.CBTagAss.UseVisualStyleBackColor = true
'
'CBTagPussy
'
Me.CBTagPussy.AutoSize = true
Me.CBTagPussy.Enabled = false
Me.CBTagPussy.ForeColor = System.Drawing.Color.Black
Me.CBTagPussy.Location = New System.Drawing.Point(484, 77)
Me.CBTagPussy.Name = "CBTagPussy"
Me.CBTagPussy.Size = New System.Drawing.Size(54, 17)
Me.CBTagPussy.TabIndex = 194
Me.CBTagPussy.Text = "Pussy"
Me.CBTagPussy.UseVisualStyleBackColor = true
'
'BTNTagSave
'
Me.BTNTagSave.Enabled = false
Me.BTNTagSave.Location = New System.Drawing.Point(613, 9)
Me.BTNTagSave.Name = "BTNTagSave"
Me.BTNTagSave.Size = New System.Drawing.Size(83, 23)
Me.BTNTagSave.TabIndex = 193
Me.BTNTagSave.Text = "Finished"
Me.BTNTagSave.UseVisualStyleBackColor = true
'
'BTNTagDir
'
Me.BTNTagDir.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNTagDir.Location = New System.Drawing.Point(6, 8)
Me.BTNTagDir.Name = "BTNTagDir"
Me.BTNTagDir.Size = New System.Drawing.Size(43, 23)
Me.BTNTagDir.TabIndex = 192
Me.BTNTagDir.Text = "1"
Me.BTNTagDir.UseVisualStyleBackColor = true
'
'ImageTagPictureBox
'
Me.ImageTagPictureBox.BackColor = System.Drawing.Color.Black
Me.ImageTagPictureBox.Location = New System.Drawing.Point(5, 37)
Me.ImageTagPictureBox.Name = "ImageTagPictureBox"
Me.ImageTagPictureBox.Size = New System.Drawing.Size(451, 328)
Me.ImageTagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
Me.ImageTagPictureBox.TabIndex = 191
Me.ImageTagPictureBox.TabStop = false
'
'CBTagFace
'
Me.CBTagFace.AutoSize = true
Me.CBTagFace.Enabled = false
Me.CBTagFace.ForeColor = System.Drawing.Color.Black
Me.CBTagFace.Location = New System.Drawing.Point(484, 37)
Me.CBTagFace.Name = "CBTagFace"
Me.CBTagFace.Size = New System.Drawing.Size(50, 17)
Me.CBTagFace.TabIndex = 190
Me.CBTagFace.Text = "Face"
Me.CBTagFace.UseVisualStyleBackColor = true
'
'TabPage35
'
Me.TabPage35.BackColor = System.Drawing.Color.LightGray
Me.TabPage35.Controls.Add(Me.GroupBox55)
Me.TabPage35.Controls.Add(Me.GroupBox53)
Me.TabPage35.Controls.Add(Me.GroupBox49)
Me.TabPage35.Controls.Add(Me.GroupBox46)
Me.TabPage35.Controls.Add(Me.GroupBox54)
Me.TabPage35.Controls.Add(Me.GroupBox51)
Me.TabPage35.Controls.Add(Me.GroupBox50)
Me.TabPage35.Controls.Add(Me.GroupBox48)
Me.TabPage35.Controls.Add(Me.TBLocalTagDir)
Me.TabPage35.Controls.Add(Me.BTNLocalTagPrevious)
Me.TabPage35.Controls.Add(Me.BTNLocalTagNext)
Me.TabPage35.Controls.Add(Me.LBLLocalTagCount)
Me.TabPage35.Controls.Add(Me.BTNLocalTagSave)
Me.TabPage35.Controls.Add(Me.BTNLocalTagDir)
Me.TabPage35.Location = New System.Drawing.Point(4, 22)
Me.TabPage35.Name = "TabPage35"
Me.TabPage35.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage35.Size = New System.Drawing.Size(700, 411)
Me.TabPage35.TabIndex = 1
Me.TabPage35.Text = "Local Tags"
'
'GroupBox55
'
Me.GroupBox55.Controls.Add(Me.CBTagNurse)
Me.GroupBox55.Controls.Add(Me.CBTagSchoolgirl)
Me.GroupBox55.Controls.Add(Me.CBTagMaid)
Me.GroupBox55.Controls.Add(Me.CBTagTeacher)
Me.GroupBox55.Controls.Add(Me.CBTagSuperhero)
Me.GroupBox55.Location = New System.Drawing.Point(341, 277)
Me.GroupBox55.Name = "GroupBox55"
Me.GroupBox55.Size = New System.Drawing.Size(103, 118)
Me.GroupBox55.TabIndex = 241
Me.GroupBox55.TabStop = false
Me.GroupBox55.Text = "Outfit"
'
'CBTagNurse
'
Me.CBTagNurse.AutoSize = true
Me.CBTagNurse.Enabled = false
Me.CBTagNurse.ForeColor = System.Drawing.Color.Black
Me.CBTagNurse.Location = New System.Drawing.Point(15, 17)
Me.CBTagNurse.Name = "CBTagNurse"
Me.CBTagNurse.Size = New System.Drawing.Size(54, 17)
Me.CBTagNurse.TabIndex = 203
Me.CBTagNurse.Text = "Nurse"
Me.CBTagNurse.UseVisualStyleBackColor = true
'
'CBTagSchoolgirl
'
Me.CBTagSchoolgirl.AutoSize = true
Me.CBTagSchoolgirl.Enabled = false
Me.CBTagSchoolgirl.ForeColor = System.Drawing.Color.Black
Me.CBTagSchoolgirl.Location = New System.Drawing.Point(15, 57)
Me.CBTagSchoolgirl.Name = "CBTagSchoolgirl"
Me.CBTagSchoolgirl.Size = New System.Drawing.Size(72, 17)
Me.CBTagSchoolgirl.TabIndex = 204
Me.CBTagSchoolgirl.Text = "Schoolgirl"
Me.CBTagSchoolgirl.UseVisualStyleBackColor = true
'
'CBTagMaid
'
Me.CBTagMaid.AutoSize = true
Me.CBTagMaid.Enabled = false
Me.CBTagMaid.ForeColor = System.Drawing.Color.Black
Me.CBTagMaid.Location = New System.Drawing.Point(15, 77)
Me.CBTagMaid.Name = "CBTagMaid"
Me.CBTagMaid.Size = New System.Drawing.Size(49, 17)
Me.CBTagMaid.TabIndex = 205
Me.CBTagMaid.Text = "Maid"
Me.CBTagMaid.UseVisualStyleBackColor = true
'
'CBTagTeacher
'
Me.CBTagTeacher.AutoSize = true
Me.CBTagTeacher.Enabled = false
Me.CBTagTeacher.ForeColor = System.Drawing.Color.Black
Me.CBTagTeacher.Location = New System.Drawing.Point(15, 37)
Me.CBTagTeacher.Name = "CBTagTeacher"
Me.CBTagTeacher.Size = New System.Drawing.Size(66, 17)
Me.CBTagTeacher.TabIndex = 206
Me.CBTagTeacher.Text = "Teacher"
Me.CBTagTeacher.UseVisualStyleBackColor = true
'
'CBTagSuperhero
'
Me.CBTagSuperhero.AutoSize = true
Me.CBTagSuperhero.Enabled = false
Me.CBTagSuperhero.ForeColor = System.Drawing.Color.Black
Me.CBTagSuperhero.Location = New System.Drawing.Point(15, 97)
Me.CBTagSuperhero.Name = "CBTagSuperhero"
Me.CBTagSuperhero.Size = New System.Drawing.Size(75, 17)
Me.CBTagSuperhero.TabIndex = 213
Me.CBTagSuperhero.Text = "Superhero"
Me.CBTagSuperhero.UseVisualStyleBackColor = true
'
'GroupBox53
'
Me.GroupBox53.Controls.Add(Me.CBTagTrap)
Me.GroupBox53.Controls.Add(Me.CBTagTentacles)
Me.GroupBox53.Controls.Add(Me.CBTagMonsterGirl)
Me.GroupBox53.Controls.Add(Me.CBTagBukkake)
Me.GroupBox53.Controls.Add(Me.CBTagGanguro)
Me.GroupBox53.Controls.Add(Me.CBTagBodyWriting)
Me.GroupBox53.Controls.Add(Me.CBTagMahouShoujo)
Me.GroupBox53.Controls.Add(Me.CBTagBakunyuu)
Me.GroupBox53.Controls.Add(Me.CBTagAhegao)
Me.GroupBox53.Controls.Add(Me.CBTagShibari)
Me.GroupBox53.Location = New System.Drawing.Point(450, 277)
Me.GroupBox53.Name = "GroupBox53"
Me.GroupBox53.Size = New System.Drawing.Size(246, 118)
Me.GroupBox53.TabIndex = 240
Me.GroupBox53.TabStop = false
Me.GroupBox53.Text = "Hentai/JAV Themes"
'
'CBTagTrap
'
Me.CBTagTrap.AutoSize = true
Me.CBTagTrap.Enabled = false
Me.CBTagTrap.ForeColor = System.Drawing.Color.Black
Me.CBTagTrap.Location = New System.Drawing.Point(126, 37)
Me.CBTagTrap.Name = "CBTagTrap"
Me.CBTagTrap.Size = New System.Drawing.Size(48, 17)
Me.CBTagTrap.TabIndex = 226
Me.CBTagTrap.Text = "Trap"
Me.CBTagTrap.UseVisualStyleBackColor = true
'
'CBTagTentacles
'
Me.CBTagTentacles.AutoSize = true
Me.CBTagTentacles.Enabled = false
Me.CBTagTentacles.ForeColor = System.Drawing.Color.Black
Me.CBTagTentacles.Location = New System.Drawing.Point(15, 37)
Me.CBTagTentacles.Name = "CBTagTentacles"
Me.CBTagTentacles.Size = New System.Drawing.Size(73, 17)
Me.CBTagTentacles.TabIndex = 204
Me.CBTagTentacles.Text = "Tentacles"
Me.CBTagTentacles.UseVisualStyleBackColor = true
'
'CBTagMonsterGirl
'
Me.CBTagMonsterGirl.AutoSize = true
Me.CBTagMonsterGirl.Enabled = false
Me.CBTagMonsterGirl.ForeColor = System.Drawing.Color.Black
Me.CBTagMonsterGirl.Location = New System.Drawing.Point(126, 97)
Me.CBTagMonsterGirl.Name = "CBTagMonsterGirl"
Me.CBTagMonsterGirl.Size = New System.Drawing.Size(82, 17)
Me.CBTagMonsterGirl.TabIndex = 214
Me.CBTagMonsterGirl.Text = "Monster Girl"
Me.CBTagMonsterGirl.UseVisualStyleBackColor = true
'
'CBTagBukkake
'
Me.CBTagBukkake.AutoSize = true
Me.CBTagBukkake.Enabled = false
Me.CBTagBukkake.ForeColor = System.Drawing.Color.Black
Me.CBTagBukkake.Location = New System.Drawing.Point(15, 57)
Me.CBTagBukkake.Name = "CBTagBukkake"
Me.CBTagBukkake.Size = New System.Drawing.Size(69, 17)
Me.CBTagBukkake.TabIndex = 210
Me.CBTagBukkake.Text = "Bukkake"
Me.CBTagBukkake.UseVisualStyleBackColor = true
'
'CBTagGanguro
'
Me.CBTagGanguro.AutoSize = true
Me.CBTagGanguro.Enabled = false
Me.CBTagGanguro.ForeColor = System.Drawing.Color.Black
Me.CBTagGanguro.Location = New System.Drawing.Point(126, 57)
Me.CBTagGanguro.Name = "CBTagGanguro"
Me.CBTagGanguro.Size = New System.Drawing.Size(67, 17)
Me.CBTagGanguro.TabIndex = 205
Me.CBTagGanguro.Text = "Ganguro"
Me.CBTagGanguro.UseVisualStyleBackColor = true
'
'CBTagBodyWriting
'
Me.CBTagBodyWriting.AutoSize = true
Me.CBTagBodyWriting.Enabled = false
Me.CBTagBodyWriting.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyWriting.Location = New System.Drawing.Point(126, 17)
Me.CBTagBodyWriting.Name = "CBTagBodyWriting"
Me.CBTagBodyWriting.Size = New System.Drawing.Size(86, 17)
Me.CBTagBodyWriting.TabIndex = 208
Me.CBTagBodyWriting.Text = "Body Writing"
Me.CBTagBodyWriting.UseVisualStyleBackColor = true
'
'CBTagMahouShoujo
'
Me.CBTagMahouShoujo.AutoSize = true
Me.CBTagMahouShoujo.Enabled = false
Me.CBTagMahouShoujo.ForeColor = System.Drawing.Color.Black
Me.CBTagMahouShoujo.Location = New System.Drawing.Point(126, 77)
Me.CBTagMahouShoujo.Name = "CBTagMahouShoujo"
Me.CBTagMahouShoujo.Size = New System.Drawing.Size(95, 17)
Me.CBTagMahouShoujo.TabIndex = 209
Me.CBTagMahouShoujo.Text = "Mahou Shoujo"
Me.CBTagMahouShoujo.UseVisualStyleBackColor = true
'
'CBTagBakunyuu
'
Me.CBTagBakunyuu.AutoSize = true
Me.CBTagBakunyuu.Enabled = false
Me.CBTagBakunyuu.ForeColor = System.Drawing.Color.Black
Me.CBTagBakunyuu.Location = New System.Drawing.Point(15, 77)
Me.CBTagBakunyuu.Name = "CBTagBakunyuu"
Me.CBTagBakunyuu.Size = New System.Drawing.Size(74, 17)
Me.CBTagBakunyuu.TabIndex = 213
Me.CBTagBakunyuu.Text = "Bakunyuu"
Me.CBTagBakunyuu.UseVisualStyleBackColor = true
'
'CBTagAhegao
'
Me.CBTagAhegao.AutoSize = true
Me.CBTagAhegao.Enabled = false
Me.CBTagAhegao.ForeColor = System.Drawing.Color.Black
Me.CBTagAhegao.Location = New System.Drawing.Point(15, 97)
Me.CBTagAhegao.Name = "CBTagAhegao"
Me.CBTagAhegao.Size = New System.Drawing.Size(63, 17)
Me.CBTagAhegao.TabIndex = 207
Me.CBTagAhegao.Text = "Ahegao"
Me.CBTagAhegao.UseVisualStyleBackColor = true
'
'CBTagShibari
'
Me.CBTagShibari.AutoSize = true
Me.CBTagShibari.Enabled = false
Me.CBTagShibari.ForeColor = System.Drawing.Color.Black
Me.CBTagShibari.Location = New System.Drawing.Point(15, 17)
Me.CBTagShibari.Name = "CBTagShibari"
Me.CBTagShibari.Size = New System.Drawing.Size(58, 17)
Me.CBTagShibari.TabIndex = 203
Me.CBTagShibari.Text = "Shibari"
Me.CBTagShibari.UseVisualStyleBackColor = true
'
'GroupBox49
'
Me.GroupBox49.Controls.Add(Me.CBTagBodyMouth)
Me.GroupBox49.Controls.Add(Me.CBTagBodyAss)
Me.GroupBox49.Controls.Add(Me.CBTagBodyFace)
Me.GroupBox49.Controls.Add(Me.CBTagBodyLegs)
Me.GroupBox49.Controls.Add(Me.CBTagBodyBalls)
Me.GroupBox49.Controls.Add(Me.CBTagBodyCock)
Me.GroupBox49.Controls.Add(Me.CBTagBodyFeet)
Me.GroupBox49.Controls.Add(Me.CBTagBodyNipples)
Me.GroupBox49.Controls.Add(Me.CBTagBodyPussy)
Me.GroupBox49.Controls.Add(Me.CBTagBodyTits)
Me.GroupBox49.Controls.Add(Me.CBTagBodyFingers)
Me.GroupBox49.Location = New System.Drawing.Point(341, 37)
Me.GroupBox49.Name = "GroupBox49"
Me.GroupBox49.Size = New System.Drawing.Size(103, 238)
Me.GroupBox49.TabIndex = 236
Me.GroupBox49.TabStop = false
Me.GroupBox49.Text = "Body Part"
'
'CBTagBodyMouth
'
Me.CBTagBodyMouth.AutoSize = true
Me.CBTagBodyMouth.Enabled = false
Me.CBTagBodyMouth.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyMouth.Location = New System.Drawing.Point(14, 57)
Me.CBTagBodyMouth.Name = "CBTagBodyMouth"
Me.CBTagBodyMouth.Size = New System.Drawing.Size(56, 17)
Me.CBTagBodyMouth.TabIndex = 220
Me.CBTagBodyMouth.Text = "Mouth"
Me.CBTagBodyMouth.UseVisualStyleBackColor = true
'
'CBTagBodyAss
'
Me.CBTagBodyAss.AutoSize = true
Me.CBTagBodyAss.Enabled = false
Me.CBTagBodyAss.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyAss.Location = New System.Drawing.Point(15, 137)
Me.CBTagBodyAss.Name = "CBTagBodyAss"
Me.CBTagBodyAss.Size = New System.Drawing.Size(43, 17)
Me.CBTagBodyAss.TabIndex = 219
Me.CBTagBodyAss.Text = "Ass"
Me.CBTagBodyAss.UseVisualStyleBackColor = true
'
'CBTagBodyFace
'
Me.CBTagBodyFace.AutoSize = true
Me.CBTagBodyFace.Enabled = false
Me.CBTagBodyFace.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyFace.Location = New System.Drawing.Point(15, 17)
Me.CBTagBodyFace.Name = "CBTagBodyFace"
Me.CBTagBodyFace.Size = New System.Drawing.Size(50, 17)
Me.CBTagBodyFace.TabIndex = 203
Me.CBTagBodyFace.Text = "Face"
Me.CBTagBodyFace.UseVisualStyleBackColor = true
'
'CBTagBodyLegs
'
Me.CBTagBodyLegs.AutoSize = true
Me.CBTagBodyLegs.Enabled = false
Me.CBTagBodyLegs.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyLegs.Location = New System.Drawing.Point(15, 157)
Me.CBTagBodyLegs.Name = "CBTagBodyLegs"
Me.CBTagBodyLegs.Size = New System.Drawing.Size(49, 17)
Me.CBTagBodyLegs.TabIndex = 218
Me.CBTagBodyLegs.Text = "Legs"
Me.CBTagBodyLegs.UseVisualStyleBackColor = true
'
'CBTagBodyBalls
'
Me.CBTagBodyBalls.AutoSize = true
Me.CBTagBodyBalls.Enabled = false
Me.CBTagBodyBalls.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyBalls.Location = New System.Drawing.Point(15, 217)
Me.CBTagBodyBalls.Name = "CBTagBodyBalls"
Me.CBTagBodyBalls.Size = New System.Drawing.Size(48, 17)
Me.CBTagBodyBalls.TabIndex = 217
Me.CBTagBodyBalls.Text = "Balls"
Me.CBTagBodyBalls.UseVisualStyleBackColor = true
'
'CBTagBodyCock
'
Me.CBTagBodyCock.AutoSize = true
Me.CBTagBodyCock.Enabled = false
Me.CBTagBodyCock.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyCock.Location = New System.Drawing.Point(15, 197)
Me.CBTagBodyCock.Name = "CBTagBodyCock"
Me.CBTagBodyCock.Size = New System.Drawing.Size(51, 17)
Me.CBTagBodyCock.TabIndex = 216
Me.CBTagBodyCock.Text = "Cock"
Me.CBTagBodyCock.UseVisualStyleBackColor = true
'
'CBTagBodyFeet
'
Me.CBTagBodyFeet.AutoSize = true
Me.CBTagBodyFeet.Enabled = false
Me.CBTagBodyFeet.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyFeet.Location = New System.Drawing.Point(15, 177)
Me.CBTagBodyFeet.Name = "CBTagBodyFeet"
Me.CBTagBodyFeet.Size = New System.Drawing.Size(47, 17)
Me.CBTagBodyFeet.TabIndex = 215
Me.CBTagBodyFeet.Text = "Feet"
Me.CBTagBodyFeet.UseVisualStyleBackColor = true
'
'CBTagBodyNipples
'
Me.CBTagBodyNipples.AutoSize = true
Me.CBTagBodyNipples.Enabled = false
Me.CBTagBodyNipples.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyNipples.Location = New System.Drawing.Point(15, 97)
Me.CBTagBodyNipples.Name = "CBTagBodyNipples"
Me.CBTagBodyNipples.Size = New System.Drawing.Size(61, 17)
Me.CBTagBodyNipples.TabIndex = 207
Me.CBTagBodyNipples.Text = "Nipples"
Me.CBTagBodyNipples.UseVisualStyleBackColor = true
'
'CBTagBodyPussy
'
Me.CBTagBodyPussy.AutoSize = true
Me.CBTagBodyPussy.Enabled = false
Me.CBTagBodyPussy.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyPussy.Location = New System.Drawing.Point(15, 117)
Me.CBTagBodyPussy.Name = "CBTagBodyPussy"
Me.CBTagBodyPussy.Size = New System.Drawing.Size(54, 17)
Me.CBTagBodyPussy.TabIndex = 209
Me.CBTagBodyPussy.Text = "Pussy"
Me.CBTagBodyPussy.UseVisualStyleBackColor = true
'
'CBTagBodyTits
'
Me.CBTagBodyTits.AutoSize = true
Me.CBTagBodyTits.Enabled = false
Me.CBTagBodyTits.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyTits.Location = New System.Drawing.Point(15, 77)
Me.CBTagBodyTits.Name = "CBTagBodyTits"
Me.CBTagBodyTits.Size = New System.Drawing.Size(43, 17)
Me.CBTagBodyTits.TabIndex = 213
Me.CBTagBodyTits.Text = "Tits"
Me.CBTagBodyTits.UseVisualStyleBackColor = true
'
'CBTagBodyFingers
'
Me.CBTagBodyFingers.AutoSize = true
Me.CBTagBodyFingers.Enabled = false
Me.CBTagBodyFingers.ForeColor = System.Drawing.Color.Black
Me.CBTagBodyFingers.Location = New System.Drawing.Point(15, 37)
Me.CBTagBodyFingers.Name = "CBTagBodyFingers"
Me.CBTagBodyFingers.Size = New System.Drawing.Size(60, 17)
Me.CBTagBodyFingers.TabIndex = 210
Me.CBTagBodyFingers.Text = "Fingers"
Me.CBTagBodyFingers.UseVisualStyleBackColor = true
'
'GroupBox46
'
Me.GroupBox46.Controls.Add(Me.CBTagMultiSub)
Me.GroupBox46.Controls.Add(Me.CBTagMultiDom)
Me.GroupBox46.Controls.Add(Me.CBTagFemdom)
Me.GroupBox46.Controls.Add(Me.CBTag2M)
Me.GroupBox46.Controls.Add(Me.CBTagFutadom)
Me.GroupBox46.Controls.Add(Me.CBTagFemsub)
Me.GroupBox46.Controls.Add(Me.CBTag2Futa)
Me.GroupBox46.Controls.Add(Me.CBTagMaledom)
Me.GroupBox46.Controls.Add(Me.CBTag3M)
Me.GroupBox46.Controls.Add(Me.CBTagFutasub)
Me.GroupBox46.Controls.Add(Me.CBTag3Futa)
Me.GroupBox46.Controls.Add(Me.CBTagMalesub)
Me.GroupBox46.Controls.Add(Me.CBTag2F)
Me.GroupBox46.Controls.Add(Me.CBTag1Futa)
Me.GroupBox46.Controls.Add(Me.CBTag1M)
Me.GroupBox46.Controls.Add(Me.CBTag1F)
Me.GroupBox46.Controls.Add(Me.CBTag3F)
Me.GroupBox46.Location = New System.Drawing.Point(230, 37)
Me.GroupBox46.Name = "GroupBox46"
Me.GroupBox46.Size = New System.Drawing.Size(105, 358)
Me.GroupBox46.TabIndex = 234
Me.GroupBox46.TabStop = false
Me.GroupBox46.Text = "Genders && Roles"
'
'CBTagMultiSub
'
Me.CBTagMultiSub.AutoSize = true
Me.CBTagMultiSub.Enabled = false
Me.CBTagMultiSub.ForeColor = System.Drawing.Color.Black
Me.CBTagMultiSub.Location = New System.Drawing.Point(15, 337)
Me.CBTagMultiSub.Name = "CBTagMultiSub"
Me.CBTagMultiSub.Size = New System.Drawing.Size(70, 17)
Me.CBTagMultiSub.TabIndex = 207
Me.CBTagMultiSub.Text = "Multi-Sub"
Me.CBTagMultiSub.UseVisualStyleBackColor = true
'
'CBTagMultiDom
'
Me.CBTagMultiDom.AutoSize = true
Me.CBTagMultiDom.Enabled = false
Me.CBTagMultiDom.ForeColor = System.Drawing.Color.Black
Me.CBTagMultiDom.Location = New System.Drawing.Point(15, 317)
Me.CBTagMultiDom.Name = "CBTagMultiDom"
Me.CBTagMultiDom.Size = New System.Drawing.Size(73, 17)
Me.CBTagMultiDom.TabIndex = 230
Me.CBTagMultiDom.Text = "Multi-Dom"
Me.CBTagMultiDom.UseVisualStyleBackColor = true
'
'CBTagFemdom
'
Me.CBTagFemdom.AutoSize = true
Me.CBTagFemdom.Enabled = false
Me.CBTagFemdom.ForeColor = System.Drawing.Color.Black
Me.CBTagFemdom.Location = New System.Drawing.Point(15, 197)
Me.CBTagFemdom.Name = "CBTagFemdom"
Me.CBTagFemdom.Size = New System.Drawing.Size(66, 17)
Me.CBTagFemdom.TabIndex = 229
Me.CBTagFemdom.Text = "Femdom"
Me.CBTagFemdom.UseVisualStyleBackColor = true
'
'CBTag2M
'
Me.CBTag2M.AutoSize = true
Me.CBTag2M.Enabled = false
Me.CBTag2M.ForeColor = System.Drawing.Color.Black
Me.CBTag2M.Location = New System.Drawing.Point(15, 97)
Me.CBTag2M.Name = "CBTag2M"
Me.CBTag2M.Size = New System.Drawing.Size(56, 17)
Me.CBTag2M.TabIndex = 206
Me.CBTag2M.Text = "2 Men"
Me.CBTag2M.UseVisualStyleBackColor = true
'
'CBTagFutadom
'
Me.CBTagFutadom.AutoSize = true
Me.CBTagFutadom.Enabled = false
Me.CBTagFutadom.ForeColor = System.Drawing.Color.Black
Me.CBTagFutadom.Location = New System.Drawing.Point(15, 237)
Me.CBTagFutadom.Name = "CBTagFutadom"
Me.CBTagFutadom.Size = New System.Drawing.Size(67, 17)
Me.CBTagFutadom.TabIndex = 204
Me.CBTagFutadom.Text = "Futadom"
Me.CBTagFutadom.UseVisualStyleBackColor = true
'
'CBTagFemsub
'
Me.CBTagFemsub.AutoSize = true
Me.CBTagFemsub.Enabled = false
Me.CBTagFemsub.ForeColor = System.Drawing.Color.Black
Me.CBTagFemsub.Location = New System.Drawing.Point(15, 257)
Me.CBTagFemsub.Name = "CBTagFemsub"
Me.CBTagFemsub.Size = New System.Drawing.Size(63, 17)
Me.CBTagFemsub.TabIndex = 205
Me.CBTagFemsub.Text = "Femsub"
Me.CBTagFemsub.UseVisualStyleBackColor = true
'
'CBTag2Futa
'
Me.CBTag2Futa.AutoSize = true
Me.CBTag2Futa.Enabled = false
Me.CBTag2Futa.ForeColor = System.Drawing.Color.Black
Me.CBTag2Futa.Location = New System.Drawing.Point(15, 157)
Me.CBTag2Futa.Name = "CBTag2Futa"
Me.CBTag2Futa.Size = New System.Drawing.Size(56, 17)
Me.CBTag2Futa.TabIndex = 186
Me.CBTag2Futa.Text = "2 Futa"
Me.CBTag2Futa.UseVisualStyleBackColor = true
'
'CBTagMaledom
'
Me.CBTagMaledom.AutoSize = true
Me.CBTagMaledom.Enabled = false
Me.CBTagMaledom.ForeColor = System.Drawing.Color.Black
Me.CBTagMaledom.Location = New System.Drawing.Point(15, 217)
Me.CBTagMaledom.Name = "CBTagMaledom"
Me.CBTagMaledom.Size = New System.Drawing.Size(69, 17)
Me.CBTagMaledom.TabIndex = 206
Me.CBTagMaledom.Text = "Maledom"
Me.CBTagMaledom.UseVisualStyleBackColor = true
'
'CBTag3M
'
Me.CBTag3M.AutoSize = true
Me.CBTag3M.Enabled = false
Me.CBTag3M.ForeColor = System.Drawing.Color.Black
Me.CBTag3M.Location = New System.Drawing.Point(15, 117)
Me.CBTag3M.Name = "CBTag3M"
Me.CBTag3M.Size = New System.Drawing.Size(56, 17)
Me.CBTag3M.TabIndex = 190
Me.CBTag3M.Text = "3 Men"
Me.CBTag3M.UseVisualStyleBackColor = true
'
'CBTagFutasub
'
Me.CBTagFutasub.AutoSize = true
Me.CBTagFutasub.Enabled = false
Me.CBTagFutasub.ForeColor = System.Drawing.Color.Black
Me.CBTagFutasub.Location = New System.Drawing.Point(15, 297)
Me.CBTagFutasub.Name = "CBTagFutasub"
Me.CBTagFutasub.Size = New System.Drawing.Size(64, 17)
Me.CBTagFutasub.TabIndex = 213
Me.CBTagFutasub.Text = "Futasub"
Me.CBTagFutasub.UseVisualStyleBackColor = true
'
'CBTag3Futa
'
Me.CBTag3Futa.AutoSize = true
Me.CBTag3Futa.Enabled = false
Me.CBTag3Futa.ForeColor = System.Drawing.Color.Black
Me.CBTag3Futa.Location = New System.Drawing.Point(15, 177)
Me.CBTag3Futa.Name = "CBTag3Futa"
Me.CBTag3Futa.Size = New System.Drawing.Size(56, 17)
Me.CBTag3Futa.TabIndex = 197
Me.CBTag3Futa.Text = "3 Futa"
Me.CBTag3Futa.UseVisualStyleBackColor = true
'
'CBTagMalesub
'
Me.CBTagMalesub.AutoSize = true
Me.CBTagMalesub.Enabled = false
Me.CBTagMalesub.ForeColor = System.Drawing.Color.Black
Me.CBTagMalesub.Location = New System.Drawing.Point(15, 277)
Me.CBTagMalesub.Name = "CBTagMalesub"
Me.CBTagMalesub.Size = New System.Drawing.Size(66, 17)
Me.CBTagMalesub.TabIndex = 210
Me.CBTagMalesub.Text = "Malesub"
Me.CBTagMalesub.UseVisualStyleBackColor = true
'
'CBTag2F
'
Me.CBTag2F.AutoSize = true
Me.CBTag2F.Enabled = false
Me.CBTag2F.ForeColor = System.Drawing.Color.Black
Me.CBTag2F.Location = New System.Drawing.Point(15, 37)
Me.CBTag2F.Name = "CBTag2F"
Me.CBTag2F.Size = New System.Drawing.Size(72, 17)
Me.CBTag2F.TabIndex = 188
Me.CBTag2F.Text = "2 Women"
Me.CBTag2F.UseVisualStyleBackColor = true
'
'CBTag1Futa
'
Me.CBTag1Futa.AutoSize = true
Me.CBTag1Futa.Enabled = false
Me.CBTag1Futa.ForeColor = System.Drawing.Color.Black
Me.CBTag1Futa.Location = New System.Drawing.Point(15, 137)
Me.CBTag1Futa.Name = "CBTag1Futa"
Me.CBTag1Futa.Size = New System.Drawing.Size(56, 17)
Me.CBTag1Futa.TabIndex = 191
Me.CBTag1Futa.Text = "1 Futa"
Me.CBTag1Futa.UseVisualStyleBackColor = true
'
'CBTag1M
'
Me.CBTag1M.AutoSize = true
Me.CBTag1M.Enabled = false
Me.CBTag1M.ForeColor = System.Drawing.Color.Black
Me.CBTag1M.Location = New System.Drawing.Point(15, 77)
Me.CBTag1M.Name = "CBTag1M"
Me.CBTag1M.Size = New System.Drawing.Size(56, 17)
Me.CBTag1M.TabIndex = 189
Me.CBTag1M.Text = "1 Man"
Me.CBTag1M.UseVisualStyleBackColor = true
'
'CBTag1F
'
Me.CBTag1F.AutoSize = true
Me.CBTag1F.Enabled = false
Me.CBTag1F.ForeColor = System.Drawing.Color.Black
Me.CBTag1F.Location = New System.Drawing.Point(15, 17)
Me.CBTag1F.Name = "CBTag1F"
Me.CBTag1F.Size = New System.Drawing.Size(72, 17)
Me.CBTag1F.TabIndex = 185
Me.CBTag1F.Text = "1 Woman"
Me.CBTag1F.UseVisualStyleBackColor = true
'
'CBTag3F
'
Me.CBTag3F.AutoSize = true
Me.CBTag3F.Enabled = false
Me.CBTag3F.ForeColor = System.Drawing.Color.Black
Me.CBTag3F.Location = New System.Drawing.Point(15, 57)
Me.CBTag3F.Name = "CBTag3F"
Me.CBTag3F.Size = New System.Drawing.Size(72, 17)
Me.CBTag3F.TabIndex = 192
Me.CBTag3F.Text = "3 Women"
Me.CBTag3F.UseVisualStyleBackColor = true
'
'GroupBox54
'
Me.GroupBox54.Controls.Add(Me.CBTagTattoos)
Me.GroupBox54.Controls.Add(Me.CBTagAnalToy)
Me.GroupBox54.Controls.Add(Me.CBTagDomme)
Me.GroupBox54.Controls.Add(Me.CBTagPocketPussy)
Me.GroupBox54.Controls.Add(Me.CBTagWatersports)
Me.GroupBox54.Controls.Add(Me.CBTagStockings)
Me.GroupBox54.Controls.Add(Me.CBTagCumshot)
Me.GroupBox54.Controls.Add(Me.CBTagCumEating)
Me.GroupBox54.Controls.Add(Me.CBTagVibrator)
Me.GroupBox54.Controls.Add(Me.CBTagDildo)
Me.GroupBox54.Controls.Add(Me.CBTagKissing)
Me.GroupBox54.Location = New System.Drawing.Point(561, 37)
Me.GroupBox54.Name = "GroupBox54"
Me.GroupBox54.Size = New System.Drawing.Size(135, 238)
Me.GroupBox54.TabIndex = 239
Me.GroupBox54.TabStop = false
Me.GroupBox54.Text = "Misc"
'
'CBTagTattoos
'
Me.CBTagTattoos.AutoSize = true
Me.CBTagTattoos.Enabled = false
Me.CBTagTattoos.ForeColor = System.Drawing.Color.Black
Me.CBTagTattoos.Location = New System.Drawing.Point(15, 97)
Me.CBTagTattoos.Name = "CBTagTattoos"
Me.CBTagTattoos.Size = New System.Drawing.Size(62, 17)
Me.CBTagTattoos.TabIndex = 214
Me.CBTagTattoos.Text = "Tattoos"
Me.CBTagTattoos.UseVisualStyleBackColor = true
'
'CBTagAnalToy
'
Me.CBTagAnalToy.AutoSize = true
Me.CBTagAnalToy.Enabled = false
Me.CBTagAnalToy.ForeColor = System.Drawing.Color.Black
Me.CBTagAnalToy.Location = New System.Drawing.Point(15, 197)
Me.CBTagAnalToy.Name = "CBTagAnalToy"
Me.CBTagAnalToy.Size = New System.Drawing.Size(68, 17)
Me.CBTagAnalToy.TabIndex = 215
Me.CBTagAnalToy.Text = "Anal Toy"
Me.CBTagAnalToy.UseVisualStyleBackColor = true
'
'CBTagDomme
'
Me.CBTagDomme.AutoSize = true
Me.CBTagDomme.Enabled = false
Me.CBTagDomme.ForeColor = System.Drawing.Color.Black
Me.CBTagDomme.Location = New System.Drawing.Point(15, 17)
Me.CBTagDomme.Name = "CBTagDomme"
Me.CBTagDomme.Size = New System.Drawing.Size(114, 17)
Me.CBTagDomme.TabIndex = 219
Me.CBTagDomme.Text = "Tease A.I. Domme"
Me.CBTagDomme.UseVisualStyleBackColor = true
'
'CBTagPocketPussy
'
Me.CBTagPocketPussy.AutoSize = true
Me.CBTagPocketPussy.Enabled = false
Me.CBTagPocketPussy.ForeColor = System.Drawing.Color.Black
Me.CBTagPocketPussy.Location = New System.Drawing.Point(15, 177)
Me.CBTagPocketPussy.Name = "CBTagPocketPussy"
Me.CBTagPocketPussy.Size = New System.Drawing.Size(91, 17)
Me.CBTagPocketPussy.TabIndex = 205
Me.CBTagPocketPussy.Text = "Pocket Pussy"
Me.CBTagPocketPussy.UseVisualStyleBackColor = true
'
'CBTagWatersports
'
Me.CBTagWatersports.AutoSize = true
Me.CBTagWatersports.Enabled = false
Me.CBTagWatersports.ForeColor = System.Drawing.Color.Black
Me.CBTagWatersports.Location = New System.Drawing.Point(15, 217)
Me.CBTagWatersports.Name = "CBTagWatersports"
Me.CBTagWatersports.Size = New System.Drawing.Size(83, 17)
Me.CBTagWatersports.TabIndex = 218
Me.CBTagWatersports.Text = "Watersports"
Me.CBTagWatersports.UseVisualStyleBackColor = true
'
'CBTagStockings
'
Me.CBTagStockings.AutoSize = true
Me.CBTagStockings.Enabled = false
Me.CBTagStockings.ForeColor = System.Drawing.Color.Black
Me.CBTagStockings.Location = New System.Drawing.Point(15, 117)
Me.CBTagStockings.Name = "CBTagStockings"
Me.CBTagStockings.Size = New System.Drawing.Size(73, 17)
Me.CBTagStockings.TabIndex = 217
Me.CBTagStockings.Text = "Stockings"
Me.CBTagStockings.UseVisualStyleBackColor = true
'
'CBTagCumshot
'
Me.CBTagCumshot.AutoSize = true
Me.CBTagCumshot.Enabled = false
Me.CBTagCumshot.ForeColor = System.Drawing.Color.Black
Me.CBTagCumshot.Location = New System.Drawing.Point(15, 37)
Me.CBTagCumshot.Name = "CBTagCumshot"
Me.CBTagCumshot.Size = New System.Drawing.Size(67, 17)
Me.CBTagCumshot.TabIndex = 206
Me.CBTagCumshot.Text = "Cumshot"
Me.CBTagCumshot.UseVisualStyleBackColor = true
'
'CBTagCumEating
'
Me.CBTagCumEating.AutoSize = true
Me.CBTagCumEating.Enabled = false
Me.CBTagCumEating.ForeColor = System.Drawing.Color.Black
Me.CBTagCumEating.Location = New System.Drawing.Point(15, 57)
Me.CBTagCumEating.Name = "CBTagCumEating"
Me.CBTagCumEating.Size = New System.Drawing.Size(80, 17)
Me.CBTagCumEating.TabIndex = 204
Me.CBTagCumEating.Text = "Cum Eating"
Me.CBTagCumEating.UseVisualStyleBackColor = true
'
'CBTagVibrator
'
Me.CBTagVibrator.AutoSize = true
Me.CBTagVibrator.Enabled = false
Me.CBTagVibrator.ForeColor = System.Drawing.Color.Black
Me.CBTagVibrator.Location = New System.Drawing.Point(15, 137)
Me.CBTagVibrator.Name = "CBTagVibrator"
Me.CBTagVibrator.Size = New System.Drawing.Size(62, 17)
Me.CBTagVibrator.TabIndex = 210
Me.CBTagVibrator.Text = "Vibrator"
Me.CBTagVibrator.UseVisualStyleBackColor = true
'
'CBTagDildo
'
Me.CBTagDildo.AutoSize = true
Me.CBTagDildo.Enabled = false
Me.CBTagDildo.ForeColor = System.Drawing.Color.Black
Me.CBTagDildo.Location = New System.Drawing.Point(15, 157)
Me.CBTagDildo.Name = "CBTagDildo"
Me.CBTagDildo.Size = New System.Drawing.Size(50, 17)
Me.CBTagDildo.TabIndex = 213
Me.CBTagDildo.Text = "Dildo"
Me.CBTagDildo.UseVisualStyleBackColor = true
'
'CBTagKissing
'
Me.CBTagKissing.AutoSize = true
Me.CBTagKissing.Enabled = false
Me.CBTagKissing.ForeColor = System.Drawing.Color.Black
Me.CBTagKissing.Location = New System.Drawing.Point(15, 77)
Me.CBTagKissing.Name = "CBTagKissing"
Me.CBTagKissing.Size = New System.Drawing.Size(59, 17)
Me.CBTagKissing.TabIndex = 203
Me.CBTagKissing.Text = "Kissing"
Me.CBTagKissing.UseVisualStyleBackColor = true
'
'GroupBox51
'
Me.GroupBox51.Controls.Add(Me.CBTagBallTorture)
Me.GroupBox51.Controls.Add(Me.CBTagGag)
Me.GroupBox51.Controls.Add(Me.CBTagBlindfold)
Me.GroupBox51.Controls.Add(Me.CBTagWhipping)
Me.GroupBox51.Controls.Add(Me.CBTagCockTorture)
Me.GroupBox51.Controls.Add(Me.CBTagElectro)
Me.GroupBox51.Controls.Add(Me.CBTagHotWax)
Me.GroupBox51.Controls.Add(Me.CBTagClamps)
Me.GroupBox51.Controls.Add(Me.CBTagStrapon)
Me.GroupBox51.Controls.Add(Me.CBTagSpanking)
Me.GroupBox51.Controls.Add(Me.CBTagNeedles)
Me.GroupBox51.Location = New System.Drawing.Point(450, 37)
Me.GroupBox51.Name = "GroupBox51"
Me.GroupBox51.Size = New System.Drawing.Size(105, 238)
Me.GroupBox51.TabIndex = 238
Me.GroupBox51.TabStop = false
Me.GroupBox51.Text = "BDSM"
'
'CBTagBallTorture
'
Me.CBTagBallTorture.AutoSize = true
Me.CBTagBallTorture.Enabled = false
Me.CBTagBallTorture.ForeColor = System.Drawing.Color.Black
Me.CBTagBallTorture.Location = New System.Drawing.Point(15, 77)
Me.CBTagBallTorture.Name = "CBTagBallTorture"
Me.CBTagBallTorture.Size = New System.Drawing.Size(80, 17)
Me.CBTagBallTorture.TabIndex = 220
Me.CBTagBallTorture.Text = "Ball Torture"
Me.CBTagBallTorture.UseVisualStyleBackColor = true
'
'CBTagGag
'
Me.CBTagGag.AutoSize = true
Me.CBTagGag.Enabled = false
Me.CBTagGag.ForeColor = System.Drawing.Color.Black
Me.CBTagGag.Location = New System.Drawing.Point(15, 137)
Me.CBTagGag.Name = "CBTagGag"
Me.CBTagGag.Size = New System.Drawing.Size(46, 17)
Me.CBTagGag.TabIndex = 214
Me.CBTagGag.Text = "Gag"
Me.CBTagGag.UseVisualStyleBackColor = true
'
'CBTagBlindfold
'
Me.CBTagBlindfold.AutoSize = true
Me.CBTagBlindfold.Enabled = false
Me.CBTagBlindfold.ForeColor = System.Drawing.Color.Black
Me.CBTagBlindfold.Location = New System.Drawing.Point(15, 117)
Me.CBTagBlindfold.Name = "CBTagBlindfold"
Me.CBTagBlindfold.Size = New System.Drawing.Size(66, 17)
Me.CBTagBlindfold.TabIndex = 208
Me.CBTagBlindfold.Text = "Blindfold"
Me.CBTagBlindfold.UseVisualStyleBackColor = true
'
'CBTagWhipping
'
Me.CBTagWhipping.AutoSize = true
Me.CBTagWhipping.Enabled = false
Me.CBTagWhipping.ForeColor = System.Drawing.Color.Black
Me.CBTagWhipping.Location = New System.Drawing.Point(15, 17)
Me.CBTagWhipping.Name = "CBTagWhipping"
Me.CBTagWhipping.Size = New System.Drawing.Size(71, 17)
Me.CBTagWhipping.TabIndex = 203
Me.CBTagWhipping.Text = "Whipping"
Me.CBTagWhipping.UseVisualStyleBackColor = true
'
'CBTagCockTorture
'
Me.CBTagCockTorture.AutoSize = true
Me.CBTagCockTorture.Enabled = false
Me.CBTagCockTorture.ForeColor = System.Drawing.Color.Black
Me.CBTagCockTorture.Location = New System.Drawing.Point(15, 57)
Me.CBTagCockTorture.Name = "CBTagCockTorture"
Me.CBTagCockTorture.Size = New System.Drawing.Size(88, 17)
Me.CBTagCockTorture.TabIndex = 204
Me.CBTagCockTorture.Text = "Cock Torture"
Me.CBTagCockTorture.UseVisualStyleBackColor = true
'
'CBTagElectro
'
Me.CBTagElectro.AutoSize = true
Me.CBTagElectro.Enabled = false
Me.CBTagElectro.ForeColor = System.Drawing.Color.Black
Me.CBTagElectro.Location = New System.Drawing.Point(15, 217)
Me.CBTagElectro.Name = "CBTagElectro"
Me.CBTagElectro.Size = New System.Drawing.Size(59, 17)
Me.CBTagElectro.TabIndex = 207
Me.CBTagElectro.Text = "Electro"
Me.CBTagElectro.UseVisualStyleBackColor = true
'
'CBTagHotWax
'
Me.CBTagHotWax.AutoSize = true
Me.CBTagHotWax.Enabled = false
Me.CBTagHotWax.ForeColor = System.Drawing.Color.Black
Me.CBTagHotWax.Location = New System.Drawing.Point(15, 177)
Me.CBTagHotWax.Name = "CBTagHotWax"
Me.CBTagHotWax.Size = New System.Drawing.Size(68, 17)
Me.CBTagHotWax.TabIndex = 213
Me.CBTagHotWax.Text = "Hot Wax"
Me.CBTagHotWax.UseVisualStyleBackColor = true
'
'CBTagClamps
'
Me.CBTagClamps.AutoSize = true
Me.CBTagClamps.Enabled = false
Me.CBTagClamps.ForeColor = System.Drawing.Color.Black
Me.CBTagClamps.Location = New System.Drawing.Point(15, 157)
Me.CBTagClamps.Name = "CBTagClamps"
Me.CBTagClamps.Size = New System.Drawing.Size(60, 17)
Me.CBTagClamps.TabIndex = 210
Me.CBTagClamps.Text = "Clamps"
Me.CBTagClamps.UseVisualStyleBackColor = true
'
'CBTagStrapon
'
Me.CBTagStrapon.AutoSize = true
Me.CBTagStrapon.Enabled = false
Me.CBTagStrapon.ForeColor = System.Drawing.Color.Black
Me.CBTagStrapon.Location = New System.Drawing.Point(15, 97)
Me.CBTagStrapon.Name = "CBTagStrapon"
Me.CBTagStrapon.Size = New System.Drawing.Size(66, 17)
Me.CBTagStrapon.TabIndex = 205
Me.CBTagStrapon.Text = "Strap-on"
Me.CBTagStrapon.UseVisualStyleBackColor = true
'
'CBTagSpanking
'
Me.CBTagSpanking.AutoSize = true
Me.CBTagSpanking.Enabled = false
Me.CBTagSpanking.ForeColor = System.Drawing.Color.Black
Me.CBTagSpanking.Location = New System.Drawing.Point(15, 37)
Me.CBTagSpanking.Name = "CBTagSpanking"
Me.CBTagSpanking.Size = New System.Drawing.Size(71, 17)
Me.CBTagSpanking.TabIndex = 206
Me.CBTagSpanking.Text = "Spanking"
Me.CBTagSpanking.UseVisualStyleBackColor = true
'
'CBTagNeedles
'
Me.CBTagNeedles.AutoSize = true
Me.CBTagNeedles.Enabled = false
Me.CBTagNeedles.ForeColor = System.Drawing.Color.Black
Me.CBTagNeedles.Location = New System.Drawing.Point(15, 197)
Me.CBTagNeedles.Name = "CBTagNeedles"
Me.CBTagNeedles.Size = New System.Drawing.Size(65, 17)
Me.CBTagNeedles.TabIndex = 209
Me.CBTagNeedles.Text = "Needles"
Me.CBTagNeedles.UseVisualStyleBackColor = true
'
'GroupBox50
'
Me.GroupBox50.Controls.Add(Me.CBTagRimming)
Me.GroupBox50.Controls.Add(Me.CBTagFacesitting)
Me.GroupBox50.Controls.Add(Me.CBTagMissionary)
Me.GroupBox50.Controls.Add(Me.CBTagMasturbation)
Me.GroupBox50.Controls.Add(Me.CBTagRCowgirl)
Me.GroupBox50.Controls.Add(Me.CBTagFingering)
Me.GroupBox50.Controls.Add(Me.CBTagGangbang)
Me.GroupBox50.Controls.Add(Me.CBTagBlowjob)
Me.GroupBox50.Controls.Add(Me.CBTagDP)
Me.GroupBox50.Controls.Add(Me.CBTagHandjob)
Me.GroupBox50.Controls.Add(Me.CBTagStanding)
Me.GroupBox50.Controls.Add(Me.CBTagFootjob)
Me.GroupBox50.Controls.Add(Me.CBTagCowgirl)
Me.GroupBox50.Controls.Add(Me.CBTagDoggyStyle)
Me.GroupBox50.Controls.Add(Me.CBTagTitjob)
Me.GroupBox50.Controls.Add(Me.CBTagCunnilingus)
Me.GroupBox50.Controls.Add(Me.CBTagAnalSex)
Me.GroupBox50.Location = New System.Drawing.Point(119, 37)
Me.GroupBox50.Name = "GroupBox50"
Me.GroupBox50.Size = New System.Drawing.Size(105, 358)
Me.GroupBox50.TabIndex = 237
Me.GroupBox50.TabStop = false
Me.GroupBox50.Text = "Sex"
'
'CBTagRimming
'
Me.CBTagRimming.AutoSize = true
Me.CBTagRimming.Enabled = false
Me.CBTagRimming.ForeColor = System.Drawing.Color.Black
Me.CBTagRimming.Location = New System.Drawing.Point(15, 177)
Me.CBTagRimming.Name = "CBTagRimming"
Me.CBTagRimming.Size = New System.Drawing.Size(66, 17)
Me.CBTagRimming.TabIndex = 219
Me.CBTagRimming.Text = "Rimming"
Me.CBTagRimming.UseVisualStyleBackColor = true
'
'CBTagFacesitting
'
Me.CBTagFacesitting.AutoSize = true
Me.CBTagFacesitting.Enabled = false
Me.CBTagFacesitting.ForeColor = System.Drawing.Color.Black
Me.CBTagFacesitting.Location = New System.Drawing.Point(15, 157)
Me.CBTagFacesitting.Name = "CBTagFacesitting"
Me.CBTagFacesitting.Size = New System.Drawing.Size(77, 17)
Me.CBTagFacesitting.TabIndex = 226
Me.CBTagFacesitting.Text = "Facesitting"
Me.CBTagFacesitting.UseVisualStyleBackColor = true
'
'CBTagMissionary
'
Me.CBTagMissionary.AutoSize = true
Me.CBTagMissionary.Enabled = false
Me.CBTagMissionary.ForeColor = System.Drawing.Color.Black
Me.CBTagMissionary.Location = New System.Drawing.Point(15, 197)
Me.CBTagMissionary.Name = "CBTagMissionary"
Me.CBTagMissionary.Size = New System.Drawing.Size(75, 17)
Me.CBTagMissionary.TabIndex = 208
Me.CBTagMissionary.Text = "Missionary"
Me.CBTagMissionary.UseVisualStyleBackColor = true
'
'CBTagMasturbation
'
Me.CBTagMasturbation.AutoSize = true
Me.CBTagMasturbation.Enabled = false
Me.CBTagMasturbation.ForeColor = System.Drawing.Color.Black
Me.CBTagMasturbation.Location = New System.Drawing.Point(15, 17)
Me.CBTagMasturbation.Name = "CBTagMasturbation"
Me.CBTagMasturbation.Size = New System.Drawing.Size(87, 17)
Me.CBTagMasturbation.TabIndex = 203
Me.CBTagMasturbation.Text = "Masturbation"
Me.CBTagMasturbation.UseVisualStyleBackColor = true
'
'CBTagRCowgirl
'
Me.CBTagRCowgirl.AutoSize = true
Me.CBTagRCowgirl.Enabled = false
Me.CBTagRCowgirl.ForeColor = System.Drawing.Color.Black
Me.CBTagRCowgirl.Location = New System.Drawing.Point(15, 257)
Me.CBTagRCowgirl.Name = "CBTagRCowgirl"
Me.CBTagRCowgirl.Size = New System.Drawing.Size(74, 17)
Me.CBTagRCowgirl.TabIndex = 218
Me.CBTagRCowgirl.Text = "R. Cowgirl"
Me.CBTagRCowgirl.UseVisualStyleBackColor = true
'
'CBTagFingering
'
Me.CBTagFingering.AutoSize = true
Me.CBTagFingering.Enabled = false
Me.CBTagFingering.ForeColor = System.Drawing.Color.Black
Me.CBTagFingering.Location = New System.Drawing.Point(15, 57)
Me.CBTagFingering.Name = "CBTagFingering"
Me.CBTagFingering.Size = New System.Drawing.Size(69, 17)
Me.CBTagFingering.TabIndex = 204
Me.CBTagFingering.Text = "Fingering"
Me.CBTagFingering.UseVisualStyleBackColor = true
'
'CBTagGangbang
'
Me.CBTagGangbang.AutoSize = true
Me.CBTagGangbang.Enabled = false
Me.CBTagGangbang.ForeColor = System.Drawing.Color.Black
Me.CBTagGangbang.Location = New System.Drawing.Point(15, 337)
Me.CBTagGangbang.Name = "CBTagGangbang"
Me.CBTagGangbang.Size = New System.Drawing.Size(76, 17)
Me.CBTagGangbang.TabIndex = 217
Me.CBTagGangbang.Text = "Gangbang"
Me.CBTagGangbang.UseVisualStyleBackColor = true
'
'CBTagBlowjob
'
Me.CBTagBlowjob.AutoSize = true
Me.CBTagBlowjob.Enabled = false
Me.CBTagBlowjob.ForeColor = System.Drawing.Color.Black
Me.CBTagBlowjob.Location = New System.Drawing.Point(15, 77)
Me.CBTagBlowjob.Name = "CBTagBlowjob"
Me.CBTagBlowjob.Size = New System.Drawing.Size(63, 17)
Me.CBTagBlowjob.TabIndex = 205
Me.CBTagBlowjob.Text = "Blowjob"
Me.CBTagBlowjob.UseVisualStyleBackColor = true
'
'CBTagDP
'
Me.CBTagDP.AutoSize = true
Me.CBTagDP.Enabled = false
Me.CBTagDP.ForeColor = System.Drawing.Color.Black
Me.CBTagDP.Location = New System.Drawing.Point(15, 317)
Me.CBTagDP.Name = "CBTagDP"
Me.CBTagDP.Size = New System.Drawing.Size(41, 17)
Me.CBTagDP.TabIndex = 216
Me.CBTagDP.Text = "DP"
Me.CBTagDP.UseVisualStyleBackColor = true
'
'CBTagHandjob
'
Me.CBTagHandjob.AutoSize = true
Me.CBTagHandjob.Enabled = false
Me.CBTagHandjob.ForeColor = System.Drawing.Color.Black
Me.CBTagHandjob.Location = New System.Drawing.Point(15, 37)
Me.CBTagHandjob.Name = "CBTagHandjob"
Me.CBTagHandjob.Size = New System.Drawing.Size(66, 17)
Me.CBTagHandjob.TabIndex = 206
Me.CBTagHandjob.Text = "Handjob"
Me.CBTagHandjob.UseVisualStyleBackColor = true
'
'CBTagStanding
'
Me.CBTagStanding.AutoSize = true
Me.CBTagStanding.Enabled = false
Me.CBTagStanding.ForeColor = System.Drawing.Color.Black
Me.CBTagStanding.Location = New System.Drawing.Point(15, 277)
Me.CBTagStanding.Name = "CBTagStanding"
Me.CBTagStanding.Size = New System.Drawing.Size(68, 17)
Me.CBTagStanding.TabIndex = 215
Me.CBTagStanding.Text = "Standing"
Me.CBTagStanding.UseVisualStyleBackColor = true
'
'CBTagFootjob
'
Me.CBTagFootjob.AutoSize = true
Me.CBTagFootjob.Enabled = false
Me.CBTagFootjob.ForeColor = System.Drawing.Color.Black
Me.CBTagFootjob.Location = New System.Drawing.Point(15, 137)
Me.CBTagFootjob.Name = "CBTagFootjob"
Me.CBTagFootjob.Size = New System.Drawing.Size(61, 17)
Me.CBTagFootjob.TabIndex = 207
Me.CBTagFootjob.Text = "Footjob"
Me.CBTagFootjob.UseVisualStyleBackColor = true
'
'CBTagCowgirl
'
Me.CBTagCowgirl.AutoSize = true
Me.CBTagCowgirl.Enabled = false
Me.CBTagCowgirl.ForeColor = System.Drawing.Color.Black
Me.CBTagCowgirl.Location = New System.Drawing.Point(15, 237)
Me.CBTagCowgirl.Name = "CBTagCowgirl"
Me.CBTagCowgirl.Size = New System.Drawing.Size(60, 17)
Me.CBTagCowgirl.TabIndex = 214
Me.CBTagCowgirl.Text = "Cowgirl"
Me.CBTagCowgirl.UseVisualStyleBackColor = true
'
'CBTagDoggyStyle
'
Me.CBTagDoggyStyle.AutoSize = true
Me.CBTagDoggyStyle.Enabled = false
Me.CBTagDoggyStyle.ForeColor = System.Drawing.Color.Black
Me.CBTagDoggyStyle.Location = New System.Drawing.Point(15, 217)
Me.CBTagDoggyStyle.Name = "CBTagDoggyStyle"
Me.CBTagDoggyStyle.Size = New System.Drawing.Size(83, 17)
Me.CBTagDoggyStyle.TabIndex = 209
Me.CBTagDoggyStyle.Text = "Doggy Style"
Me.CBTagDoggyStyle.UseVisualStyleBackColor = true
'
'CBTagTitjob
'
Me.CBTagTitjob.AutoSize = true
Me.CBTagTitjob.Enabled = false
Me.CBTagTitjob.ForeColor = System.Drawing.Color.Black
Me.CBTagTitjob.Location = New System.Drawing.Point(15, 117)
Me.CBTagTitjob.Name = "CBTagTitjob"
Me.CBTagTitjob.Size = New System.Drawing.Size(52, 17)
Me.CBTagTitjob.TabIndex = 213
Me.CBTagTitjob.Text = "Titjob"
Me.CBTagTitjob.UseVisualStyleBackColor = true
'
'CBTagCunnilingus
'
Me.CBTagCunnilingus.AutoSize = true
Me.CBTagCunnilingus.Enabled = false
Me.CBTagCunnilingus.ForeColor = System.Drawing.Color.Black
Me.CBTagCunnilingus.Location = New System.Drawing.Point(15, 97)
Me.CBTagCunnilingus.Name = "CBTagCunnilingus"
Me.CBTagCunnilingus.Size = New System.Drawing.Size(80, 17)
Me.CBTagCunnilingus.TabIndex = 210
Me.CBTagCunnilingus.Text = "Cunnilingus"
Me.CBTagCunnilingus.UseVisualStyleBackColor = true
'
'CBTagAnalSex
'
Me.CBTagAnalSex.AutoSize = true
Me.CBTagAnalSex.Enabled = false
Me.CBTagAnalSex.ForeColor = System.Drawing.Color.Black
Me.CBTagAnalSex.Location = New System.Drawing.Point(15, 297)
Me.CBTagAnalSex.Name = "CBTagAnalSex"
Me.CBTagAnalSex.Size = New System.Drawing.Size(68, 17)
Me.CBTagAnalSex.TabIndex = 212
Me.CBTagAnalSex.Text = "Anal Sex"
Me.CBTagAnalSex.UseVisualStyleBackColor = true
'
'GroupBox48
'
Me.GroupBox48.Controls.Add(Me.CBTagArtwork)
Me.GroupBox48.Controls.Add(Me.CBTagOutdoors)
Me.GroupBox48.Controls.Add(Me.CBTagPOV)
Me.GroupBox48.Controls.Add(Me.CBTagHardcore)
Me.GroupBox48.Controls.Add(Me.CBTagTD)
Me.GroupBox48.Controls.Add(Me.CBTagGay)
Me.GroupBox48.Controls.Add(Me.CBTagBath)
Me.GroupBox48.Controls.Add(Me.CBTagBisexual)
Me.GroupBox48.Controls.Add(Me.CBTagCFNM)
Me.GroupBox48.Controls.Add(Me.CBTagLesbian)
Me.GroupBox48.Controls.Add(Me.CBTagSoloFuta)
Me.GroupBox48.Controls.Add(Me.CBTagSM)
Me.GroupBox48.Controls.Add(Me.CBTagBondage)
Me.GroupBox48.Controls.Add(Me.CBTagSoloM)
Me.GroupBox48.Controls.Add(Me.CBTagSoloF)
Me.GroupBox48.Controls.Add(Me.CBTagChastity)
Me.GroupBox48.Controls.Add(Me.CBTagShower)
Me.GroupBox48.Location = New System.Drawing.Point(8, 37)
Me.GroupBox48.Name = "GroupBox48"
Me.GroupBox48.Size = New System.Drawing.Size(105, 358)
Me.GroupBox48.TabIndex = 235
Me.GroupBox48.TabStop = false
Me.GroupBox48.Text = "Category"
'
'CBTagArtwork
'
Me.CBTagArtwork.AutoSize = true
Me.CBTagArtwork.Enabled = false
Me.CBTagArtwork.ForeColor = System.Drawing.Color.Black
Me.CBTagArtwork.Location = New System.Drawing.Point(15, 337)
Me.CBTagArtwork.Name = "CBTagArtwork"
Me.CBTagArtwork.Size = New System.Drawing.Size(62, 17)
Me.CBTagArtwork.TabIndex = 225
Me.CBTagArtwork.Text = "Artwork"
Me.CBTagArtwork.UseVisualStyleBackColor = true
'
'CBTagOutdoors
'
Me.CBTagOutdoors.AutoSize = true
Me.CBTagOutdoors.Enabled = false
Me.CBTagOutdoors.ForeColor = System.Drawing.Color.Black
Me.CBTagOutdoors.Location = New System.Drawing.Point(15, 317)
Me.CBTagOutdoors.Name = "CBTagOutdoors"
Me.CBTagOutdoors.Size = New System.Drawing.Size(69, 17)
Me.CBTagOutdoors.TabIndex = 219
Me.CBTagOutdoors.Text = "Outdoors"
Me.CBTagOutdoors.UseVisualStyleBackColor = true
'
'CBTagPOV
'
Me.CBTagPOV.AutoSize = true
Me.CBTagPOV.Enabled = false
Me.CBTagPOV.ForeColor = System.Drawing.Color.Black
Me.CBTagPOV.Location = New System.Drawing.Point(15, 157)
Me.CBTagPOV.Name = "CBTagPOV"
Me.CBTagPOV.Size = New System.Drawing.Size(48, 17)
Me.CBTagPOV.TabIndex = 208
Me.CBTagPOV.Text = "POV"
Me.CBTagPOV.UseVisualStyleBackColor = true
'
'CBTagHardcore
'
Me.CBTagHardcore.AutoSize = true
Me.CBTagHardcore.Enabled = false
Me.CBTagHardcore.ForeColor = System.Drawing.Color.Black
Me.CBTagHardcore.Location = New System.Drawing.Point(15, 17)
Me.CBTagHardcore.Name = "CBTagHardcore"
Me.CBTagHardcore.Size = New System.Drawing.Size(70, 17)
Me.CBTagHardcore.TabIndex = 203
Me.CBTagHardcore.Text = "Hardcore"
Me.CBTagHardcore.UseVisualStyleBackColor = true
'
'CBTagTD
'
Me.CBTagTD.AutoSize = true
Me.CBTagTD.Enabled = false
Me.CBTagTD.ForeColor = System.Drawing.Color.Black
Me.CBTagTD.Location = New System.Drawing.Point(15, 217)
Me.CBTagTD.Name = "CBTagTD"
Me.CBTagTD.Size = New System.Drawing.Size(47, 17)
Me.CBTagTD.TabIndex = 218
Me.CBTagTD.Text = "T&&D"
Me.CBTagTD.UseVisualStyleBackColor = true
'
'CBTagGay
'
Me.CBTagGay.AutoSize = true
Me.CBTagGay.Enabled = false
Me.CBTagGay.ForeColor = System.Drawing.Color.Black
Me.CBTagGay.Location = New System.Drawing.Point(15, 57)
Me.CBTagGay.Name = "CBTagGay"
Me.CBTagGay.Size = New System.Drawing.Size(45, 17)
Me.CBTagGay.TabIndex = 204
Me.CBTagGay.Text = "Gay"
Me.CBTagGay.UseVisualStyleBackColor = true
'
'CBTagBath
'
Me.CBTagBath.AutoSize = true
Me.CBTagBath.Enabled = false
Me.CBTagBath.ForeColor = System.Drawing.Color.Black
Me.CBTagBath.Location = New System.Drawing.Point(15, 277)
Me.CBTagBath.Name = "CBTagBath"
Me.CBTagBath.Size = New System.Drawing.Size(48, 17)
Me.CBTagBath.TabIndex = 217
Me.CBTagBath.Text = "Bath"
Me.CBTagBath.UseVisualStyleBackColor = true
'
'CBTagBisexual
'
Me.CBTagBisexual.AutoSize = true
Me.CBTagBisexual.Enabled = false
Me.CBTagBisexual.ForeColor = System.Drawing.Color.Black
Me.CBTagBisexual.Location = New System.Drawing.Point(15, 77)
Me.CBTagBisexual.Name = "CBTagBisexual"
Me.CBTagBisexual.Size = New System.Drawing.Size(65, 17)
Me.CBTagBisexual.TabIndex = 205
Me.CBTagBisexual.Text = "Bisexual"
Me.CBTagBisexual.UseVisualStyleBackColor = true
'
'CBTagCFNM
'
Me.CBTagCFNM.AutoSize = true
Me.CBTagCFNM.Enabled = false
Me.CBTagCFNM.ForeColor = System.Drawing.Color.Black
Me.CBTagCFNM.Location = New System.Drawing.Point(15, 257)
Me.CBTagCFNM.Name = "CBTagCFNM"
Me.CBTagCFNM.Size = New System.Drawing.Size(56, 17)
Me.CBTagCFNM.TabIndex = 216
Me.CBTagCFNM.Text = "CFNM"
Me.CBTagCFNM.UseVisualStyleBackColor = true
'
'CBTagLesbian
'
Me.CBTagLesbian.AutoSize = true
Me.CBTagLesbian.Enabled = false
Me.CBTagLesbian.ForeColor = System.Drawing.Color.Black
Me.CBTagLesbian.Location = New System.Drawing.Point(15, 37)
Me.CBTagLesbian.Name = "CBTagLesbian"
Me.CBTagLesbian.Size = New System.Drawing.Size(63, 17)
Me.CBTagLesbian.TabIndex = 206
Me.CBTagLesbian.Text = "Lesbian"
Me.CBTagLesbian.UseVisualStyleBackColor = true
'
'CBTagSoloFuta
'
Me.CBTagSoloFuta.AutoSize = true
Me.CBTagSoloFuta.Enabled = false
Me.CBTagSoloFuta.ForeColor = System.Drawing.Color.Black
Me.CBTagSoloFuta.Location = New System.Drawing.Point(15, 137)
Me.CBTagSoloFuta.Name = "CBTagSoloFuta"
Me.CBTagSoloFuta.Size = New System.Drawing.Size(71, 17)
Me.CBTagSoloFuta.TabIndex = 207
Me.CBTagSoloFuta.Text = "Solo Futa"
Me.CBTagSoloFuta.UseVisualStyleBackColor = true
'
'CBTagSM
'
Me.CBTagSM.AutoSize = true
Me.CBTagSM.Enabled = false
Me.CBTagSM.ForeColor = System.Drawing.Color.Black
Me.CBTagSM.Location = New System.Drawing.Point(15, 197)
Me.CBTagSM.Name = "CBTagSM"
Me.CBTagSM.Size = New System.Drawing.Size(48, 17)
Me.CBTagSM.TabIndex = 214
Me.CBTagSM.Text = "S&&M"
Me.CBTagSM.UseVisualStyleBackColor = true
'
'CBTagBondage
'
Me.CBTagBondage.AutoSize = true
Me.CBTagBondage.Enabled = false
Me.CBTagBondage.ForeColor = System.Drawing.Color.Black
Me.CBTagBondage.Location = New System.Drawing.Point(15, 177)
Me.CBTagBondage.Name = "CBTagBondage"
Me.CBTagBondage.Size = New System.Drawing.Size(69, 17)
Me.CBTagBondage.TabIndex = 209
Me.CBTagBondage.Text = "Bondage"
Me.CBTagBondage.UseVisualStyleBackColor = true
'
'CBTagSoloM
'
Me.CBTagSoloM.AutoSize = true
Me.CBTagSoloM.Enabled = false
Me.CBTagSoloM.ForeColor = System.Drawing.Color.Black
Me.CBTagSoloM.Location = New System.Drawing.Point(15, 117)
Me.CBTagSoloM.Name = "CBTagSoloM"
Me.CBTagSoloM.Size = New System.Drawing.Size(59, 17)
Me.CBTagSoloM.TabIndex = 213
Me.CBTagSoloM.Text = "Solo M"
Me.CBTagSoloM.UseVisualStyleBackColor = true
'
'CBTagSoloF
'
Me.CBTagSoloF.AutoSize = true
Me.CBTagSoloF.Enabled = false
Me.CBTagSoloF.ForeColor = System.Drawing.Color.Black
Me.CBTagSoloF.Location = New System.Drawing.Point(15, 97)
Me.CBTagSoloF.Name = "CBTagSoloF"
Me.CBTagSoloF.Size = New System.Drawing.Size(56, 17)
Me.CBTagSoloF.TabIndex = 210
Me.CBTagSoloF.Text = "Solo F"
Me.CBTagSoloF.UseVisualStyleBackColor = true
'
'CBTagChastity
'
Me.CBTagChastity.AutoSize = true
Me.CBTagChastity.Enabled = false
Me.CBTagChastity.ForeColor = System.Drawing.Color.Black
Me.CBTagChastity.Location = New System.Drawing.Point(15, 237)
Me.CBTagChastity.Name = "CBTagChastity"
Me.CBTagChastity.Size = New System.Drawing.Size(63, 17)
Me.CBTagChastity.TabIndex = 212
Me.CBTagChastity.Text = "Chastity"
Me.CBTagChastity.UseVisualStyleBackColor = true
'
'CBTagShower
'
Me.CBTagShower.AutoSize = true
Me.CBTagShower.Enabled = false
Me.CBTagShower.ForeColor = System.Drawing.Color.Black
Me.CBTagShower.Location = New System.Drawing.Point(15, 297)
Me.CBTagShower.Name = "CBTagShower"
Me.CBTagShower.Size = New System.Drawing.Size(62, 17)
Me.CBTagShower.TabIndex = 211
Me.CBTagShower.Text = "Shower"
Me.CBTagShower.UseVisualStyleBackColor = true
'
'TBLocalTagDir
'
Me.TBLocalTagDir.Location = New System.Drawing.Point(55, 9)
Me.TBLocalTagDir.Name = "TBLocalTagDir"
Me.TBLocalTagDir.Size = New System.Drawing.Size(330, 20)
Me.TBLocalTagDir.TabIndex = 233
Me.TBLocalTagDir.Text = "Enter Image Directory"
'
'BTNLocalTagPrevious
'
Me.BTNLocalTagPrevious.BackColor = System.Drawing.Color.LightGray
Me.BTNLocalTagPrevious.Enabled = false
Me.BTNLocalTagPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNLocalTagPrevious.ForeColor = System.Drawing.Color.Black
Me.BTNLocalTagPrevious.Location = New System.Drawing.Point(391, 8)
Me.BTNLocalTagPrevious.Name = "BTNLocalTagPrevious"
Me.BTNLocalTagPrevious.Size = New System.Drawing.Size(47, 24)
Me.BTNLocalTagPrevious.TabIndex = 232
Me.BTNLocalTagPrevious.Text = "<<"
Me.BTNLocalTagPrevious.UseVisualStyleBackColor = false
'
'BTNLocalTagNext
'
Me.BTNLocalTagNext.BackColor = System.Drawing.Color.LightGray
Me.BTNLocalTagNext.Enabled = false
Me.BTNLocalTagNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNLocalTagNext.ForeColor = System.Drawing.Color.Black
Me.BTNLocalTagNext.Location = New System.Drawing.Point(560, 8)
Me.BTNLocalTagNext.Name = "BTNLocalTagNext"
Me.BTNLocalTagNext.Size = New System.Drawing.Size(47, 24)
Me.BTNLocalTagNext.TabIndex = 231
Me.BTNLocalTagNext.Text = ">>"
Me.BTNLocalTagNext.UseVisualStyleBackColor = false
'
'LBLLocalTagCount
'
Me.LBLLocalTagCount.BackColor = System.Drawing.Color.Transparent
Me.LBLLocalTagCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLLocalTagCount.Enabled = false
Me.LBLLocalTagCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLLocalTagCount.ForeColor = System.Drawing.Color.Black
Me.LBLLocalTagCount.Location = New System.Drawing.Point(444, 10)
Me.LBLLocalTagCount.Name = "LBLLocalTagCount"
Me.LBLLocalTagCount.Size = New System.Drawing.Size(110, 20)
Me.LBLLocalTagCount.TabIndex = 230
Me.LBLLocalTagCount.Text = "0/0"
Me.LBLLocalTagCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNLocalTagSave
'
Me.BTNLocalTagSave.Enabled = false
Me.BTNLocalTagSave.Location = New System.Drawing.Point(613, 9)
Me.BTNLocalTagSave.Name = "BTNLocalTagSave"
Me.BTNLocalTagSave.Size = New System.Drawing.Size(83, 23)
Me.BTNLocalTagSave.TabIndex = 229
Me.BTNLocalTagSave.Text = "Finished"
Me.BTNLocalTagSave.UseVisualStyleBackColor = true
'
'BTNLocalTagDir
'
Me.BTNLocalTagDir.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNLocalTagDir.Location = New System.Drawing.Point(6, 8)
Me.BTNLocalTagDir.Name = "BTNLocalTagDir"
Me.BTNLocalTagDir.Size = New System.Drawing.Size(43, 23)
Me.BTNLocalTagDir.TabIndex = 228
Me.BTNLocalTagDir.Text = "1"
Me.BTNLocalTagDir.UseVisualStyleBackColor = true
'
'TabPage11
'
Me.TabPage11.BackColor = System.Drawing.Color.Silver
Me.TabPage11.Controls.Add(Me.Panel7)
Me.TabPage11.Location = New System.Drawing.Point(4, 22)
Me.TabPage11.Name = "TabPage11"
Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage11.Size = New System.Drawing.Size(720, 448)
Me.TabPage11.TabIndex = 10
Me.TabPage11.Text = "URL Files"
'
'Panel7
'
Me.Panel7.BackColor = System.Drawing.Color.LightGray
Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel7.Controls.Add(Me.BTNWIContinue)
Me.Panel7.Controls.Add(Me.BTNWIAddandContinue)
Me.Panel7.Controls.Add(Me.BTNWICancel)
Me.Panel7.Controls.Add(Me.CBWIReview)
Me.Panel7.Controls.Add(Me.BTNWIBrowse)
Me.Panel7.Controls.Add(Me.TBWIDirectory)
Me.Panel7.Controls.Add(Me.BTNWIDisliked)
Me.Panel7.Controls.Add(Me.BTNWILiked)
Me.Panel7.Controls.Add(Me.BTNWIRemove)
Me.Panel7.Controls.Add(Me.CBWISaveToDisk)
Me.Panel7.Controls.Add(Me.PictureBox5)
Me.Panel7.Controls.Add(Me.WebImageProgressBar)
Me.Panel7.Controls.Add(Me.BTNWICreateURL)
Me.Panel7.Controls.Add(Me.LBLWebImageCount)
Me.Panel7.Controls.Add(Me.BTNWISave)
Me.Panel7.Controls.Add(Me.BTNWIOpenURL)
Me.Panel7.Controls.Add(Me.BTNWIPrevious)
Me.Panel7.Controls.Add(Me.BTNWINext)
Me.Panel7.Controls.Add(Me.WebPictureBox)
Me.Panel7.Controls.Add(Me.Label71)
Me.Panel7.Location = New System.Drawing.Point(6, 6)
Me.Panel7.Name = "Panel7"
Me.Panel7.Size = New System.Drawing.Size(708, 437)
Me.Panel7.TabIndex = 91
'
'BTNWIContinue
'
Me.BTNWIContinue.BackColor = System.Drawing.Color.LightGray
Me.BTNWIContinue.Enabled = false
Me.BTNWIContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIContinue.ForeColor = System.Drawing.Color.Black
Me.BTNWIContinue.Location = New System.Drawing.Point(566, 158)
Me.BTNWIContinue.Name = "BTNWIContinue"
Me.BTNWIContinue.Size = New System.Drawing.Size(131, 24)
Me.BTNWIContinue.TabIndex = 168
Me.BTNWIContinue.Text = "Continue"
Me.BTNWIContinue.UseVisualStyleBackColor = false
'
'BTNWIAddandContinue
'
Me.BTNWIAddandContinue.BackColor = System.Drawing.Color.LightGray
Me.BTNWIAddandContinue.Enabled = false
Me.BTNWIAddandContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIAddandContinue.ForeColor = System.Drawing.Color.Black
Me.BTNWIAddandContinue.Location = New System.Drawing.Point(566, 128)
Me.BTNWIAddandContinue.Name = "BTNWIAddandContinue"
Me.BTNWIAddandContinue.Size = New System.Drawing.Size(131, 24)
Me.BTNWIAddandContinue.TabIndex = 167
Me.BTNWIAddandContinue.Text = "Add and Continue"
Me.BTNWIAddandContinue.UseVisualStyleBackColor = false
'
'BTNWICancel
'
Me.BTNWICancel.BackColor = System.Drawing.Color.LightGray
Me.BTNWICancel.Enabled = false
Me.BTNWICancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWICancel.ForeColor = System.Drawing.Color.Black
Me.BTNWICancel.Location = New System.Drawing.Point(566, 188)
Me.BTNWICancel.Name = "BTNWICancel"
Me.BTNWICancel.Size = New System.Drawing.Size(131, 24)
Me.BTNWICancel.TabIndex = 166
Me.BTNWICancel.Text = "Cancel"
Me.BTNWICancel.UseVisualStyleBackColor = false
'
'CBWIReview
'
Me.CBWIReview.Location = New System.Drawing.Point(567, 69)
Me.CBWIReview.Name = "CBWIReview"
Me.CBWIReview.Size = New System.Drawing.Size(124, 30)
Me.CBWIReview.TabIndex = 165
Me.CBWIReview.Text = "Review Each Image"
Me.CBWIReview.UseVisualStyleBackColor = true
'
'BTNWIBrowse
'
Me.BTNWIBrowse.BackColor = System.Drawing.Color.LightGray
Me.BTNWIBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIBrowse.ForeColor = System.Drawing.Color.Black
Me.BTNWIBrowse.Location = New System.Drawing.Point(105, 402)
Me.BTNWIBrowse.Name = "BTNWIBrowse"
Me.BTNWIBrowse.Size = New System.Drawing.Size(50, 24)
Me.BTNWIBrowse.TabIndex = 163
Me.BTNWIBrowse.Text = "Browse"
Me.BTNWIBrowse.UseVisualStyleBackColor = false
'
'TBWIDirectory
'
Me.TBWIDirectory.BackColor = System.Drawing.Color.White
Me.TBWIDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBWIDirectory.ForeColor = System.Drawing.Color.Black
Me.TBWIDirectory.Location = New System.Drawing.Point(161, 404)
Me.TBWIDirectory.Name = "TBWIDirectory"
Me.TBWIDirectory.Size = New System.Drawing.Size(400, 20)
Me.TBWIDirectory.TabIndex = 164
Me.TBWIDirectory.Text = "Saved Image Directory"
'
'BTNWIDisliked
'
Me.BTNWIDisliked.BackColor = System.Drawing.Color.LightGray
Me.BTNWIDisliked.Enabled = false
Me.BTNWIDisliked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIDisliked.ForeColor = System.Drawing.Color.Black
Me.BTNWIDisliked.Location = New System.Drawing.Point(567, 372)
Me.BTNWIDisliked.Name = "BTNWIDisliked"
Me.BTNWIDisliked.Size = New System.Drawing.Size(131, 24)
Me.BTNWIDisliked.TabIndex = 162
Me.BTNWIDisliked.Text = "Add to Disliked Images"
Me.BTNWIDisliked.UseVisualStyleBackColor = false
'
'BTNWILiked
'
Me.BTNWILiked.BackColor = System.Drawing.Color.LightGray
Me.BTNWILiked.Enabled = false
Me.BTNWILiked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWILiked.ForeColor = System.Drawing.Color.Black
Me.BTNWILiked.Location = New System.Drawing.Point(567, 342)
Me.BTNWILiked.Name = "BTNWILiked"
Me.BTNWILiked.Size = New System.Drawing.Size(131, 24)
Me.BTNWILiked.TabIndex = 161
Me.BTNWILiked.Text = "Add to Liked Images"
Me.BTNWILiked.UseVisualStyleBackColor = false
'
'BTNWIRemove
'
Me.BTNWIRemove.BackColor = System.Drawing.Color.LightGray
Me.BTNWIRemove.Enabled = false
Me.BTNWIRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIRemove.ForeColor = System.Drawing.Color.Black
Me.BTNWIRemove.Location = New System.Drawing.Point(567, 312)
Me.BTNWIRemove.Name = "BTNWIRemove"
Me.BTNWIRemove.Size = New System.Drawing.Size(131, 24)
Me.BTNWIRemove.TabIndex = 160
Me.BTNWIRemove.Text = "Remove From URL File"
Me.BTNWIRemove.UseVisualStyleBackColor = false
'
'CBWISaveToDisk
'
Me.CBWISaveToDisk.Location = New System.Drawing.Point(567, 95)
Me.CBWISaveToDisk.Name = "CBWISaveToDisk"
Me.CBWISaveToDisk.Size = New System.Drawing.Size(124, 30)
Me.CBWISaveToDisk.TabIndex = 157
Me.CBWISaveToDisk.Text = "Save Images to Disk"
Me.CBWISaveToDisk.UseVisualStyleBackColor = true
'
'PictureBox5
'
Me.PictureBox5.BackColor = System.Drawing.Color.LightGray
Me.PictureBox5.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox5.Location = New System.Drawing.Point(9, 6)
Me.PictureBox5.Name = "PictureBox5"
Me.PictureBox5.Size = New System.Drawing.Size(160, 19)
Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox5.TabIndex = 156
Me.PictureBox5.TabStop = false
'
'WebImageProgressBar
'
Me.WebImageProgressBar.Location = New System.Drawing.Point(567, 218)
Me.WebImageProgressBar.Maximum = 2500
Me.WebImageProgressBar.Name = "WebImageProgressBar"
Me.WebImageProgressBar.Size = New System.Drawing.Size(131, 23)
Me.WebImageProgressBar.TabIndex = 155
'
'BTNWICreateURL
'
Me.BTNWICreateURL.BackColor = System.Drawing.Color.LightGray
Me.BTNWICreateURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWICreateURL.ForeColor = System.Drawing.Color.Black
Me.BTNWICreateURL.Location = New System.Drawing.Point(567, 39)
Me.BTNWICreateURL.Name = "BTNWICreateURL"
Me.BTNWICreateURL.Size = New System.Drawing.Size(132, 24)
Me.BTNWICreateURL.TabIndex = 154
Me.BTNWICreateURL.Text = "Create URL File"
Me.BTNWICreateURL.UseVisualStyleBackColor = false
'
'LBLWebImageCount
'
Me.LBLWebImageCount.BackColor = System.Drawing.Color.Transparent
Me.LBLWebImageCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLWebImageCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLWebImageCount.ForeColor = System.Drawing.Color.Black
Me.LBLWebImageCount.Location = New System.Drawing.Point(6, 404)
Me.LBLWebImageCount.Name = "LBLWebImageCount"
Me.LBLWebImageCount.Size = New System.Drawing.Size(93, 21)
Me.LBLWebImageCount.TabIndex = 153
Me.LBLWebImageCount.Text = "0/0"
Me.LBLWebImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNWISave
'
Me.BTNWISave.BackColor = System.Drawing.Color.LightGray
Me.BTNWISave.Enabled = false
Me.BTNWISave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWISave.ForeColor = System.Drawing.Color.Black
Me.BTNWISave.Location = New System.Drawing.Point(567, 401)
Me.BTNWISave.Name = "BTNWISave"
Me.BTNWISave.Size = New System.Drawing.Size(131, 24)
Me.BTNWISave.TabIndex = 152
Me.BTNWISave.Text = "Save Image to Disk"
Me.BTNWISave.UseVisualStyleBackColor = false
'
'BTNWIOpenURL
'
Me.BTNWIOpenURL.BackColor = System.Drawing.Color.LightGray
Me.BTNWIOpenURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIOpenURL.ForeColor = System.Drawing.Color.Black
Me.BTNWIOpenURL.Location = New System.Drawing.Point(566, 252)
Me.BTNWIOpenURL.Name = "BTNWIOpenURL"
Me.BTNWIOpenURL.Size = New System.Drawing.Size(132, 24)
Me.BTNWIOpenURL.TabIndex = 151
Me.BTNWIOpenURL.Text = "Open URL File"
Me.BTNWIOpenURL.UseVisualStyleBackColor = false
'
'BTNWIPrevious
'
Me.BTNWIPrevious.BackColor = System.Drawing.Color.LightGray
Me.BTNWIPrevious.Enabled = false
Me.BTNWIPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWIPrevious.ForeColor = System.Drawing.Color.Black
Me.BTNWIPrevious.Location = New System.Drawing.Point(567, 282)
Me.BTNWIPrevious.Name = "BTNWIPrevious"
Me.BTNWIPrevious.Size = New System.Drawing.Size(47, 24)
Me.BTNWIPrevious.TabIndex = 149
Me.BTNWIPrevious.Text = "<<"
Me.BTNWIPrevious.UseVisualStyleBackColor = false
'
'BTNWINext
'
Me.BTNWINext.BackColor = System.Drawing.Color.LightGray
Me.BTNWINext.Enabled = false
Me.BTNWINext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNWINext.ForeColor = System.Drawing.Color.Black
Me.BTNWINext.Location = New System.Drawing.Point(651, 282)
Me.BTNWINext.Name = "BTNWINext"
Me.BTNWINext.Size = New System.Drawing.Size(47, 24)
Me.BTNWINext.TabIndex = 150
Me.BTNWINext.Text = ">>"
Me.BTNWINext.UseVisualStyleBackColor = false
'
'WebPictureBox
'
Me.WebPictureBox.BackColor = System.Drawing.Color.Black
Me.WebPictureBox.Location = New System.Drawing.Point(6, 38)
Me.WebPictureBox.Name = "WebPictureBox"
Me.WebPictureBox.Size = New System.Drawing.Size(555, 358)
Me.WebPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
Me.WebPictureBox.TabIndex = 148
Me.WebPictureBox.TabStop = false
'
'Label71
'
Me.Label71.BackColor = System.Drawing.Color.Transparent
Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label71.ForeColor = System.Drawing.Color.Black
Me.Label71.Location = New System.Drawing.Point(7, 6)
Me.Label71.Name = "Label71"
Me.Label71.Size = New System.Drawing.Size(692, 21)
Me.Label71.TabIndex = 48
Me.Label71.Text = "URL Files"
Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TpVideoSettings
'
Me.TpVideoSettings.BackColor = System.Drawing.Color.Silver
Me.TpVideoSettings.Controls.Add(Me.PnlVideoSettings)
Me.TpVideoSettings.Location = New System.Drawing.Point(4, 22)
Me.TpVideoSettings.Name = "TpVideoSettings"
Me.TpVideoSettings.Padding = New System.Windows.Forms.Padding(6)
Me.TpVideoSettings.Size = New System.Drawing.Size(720, 448)
Me.TpVideoSettings.TabIndex = 2
Me.TpVideoSettings.Text = "Video"
'
'PnlVideoSettings
'
Me.PnlVideoSettings.BackColor = System.Drawing.Color.LightGray
Me.PnlVideoSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.PnlVideoSettings.Controls.Add(Me.PbBannerVideoSettings)
Me.PnlVideoSettings.Controls.Add(Me.BTNRefreshVideos)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoGeneralD)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoSpecialD)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoGenreD)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoDescription)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoGeneral)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoSpecial)
Me.PnlVideoSettings.Controls.Add(Me.GbxVideoGenre)
Me.PnlVideoSettings.Controls.Add(Me.LblVideoHeader)
Me.PnlVideoSettings.Dock = System.Windows.Forms.DockStyle.Fill
Me.PnlVideoSettings.Location = New System.Drawing.Point(6, 6)
Me.PnlVideoSettings.Margin = New System.Windows.Forms.Padding(6)
Me.PnlVideoSettings.Name = "PnlVideoSettings"
Me.PnlVideoSettings.Size = New System.Drawing.Size(708, 436)
Me.PnlVideoSettings.TabIndex = 92
'
'PbBannerVideoSettings
'
Me.PbBannerVideoSettings.BackColor = System.Drawing.Color.LightGray
Me.PbBannerVideoSettings.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PbBannerVideoSettings.Location = New System.Drawing.Point(9, 6)
Me.PbBannerVideoSettings.Name = "PbBannerVideoSettings"
Me.PbBannerVideoSettings.Size = New System.Drawing.Size(160, 19)
Me.PbBannerVideoSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PbBannerVideoSettings.TabIndex = 151
Me.PbBannerVideoSettings.TabStop = false
'
'BTNRefreshVideos
'
Me.BTNRefreshVideos.BackColor = System.Drawing.Color.LightGray
Me.BTNRefreshVideos.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Refresh
Me.BTNRefreshVideos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
Me.BTNRefreshVideos.FlatAppearance.BorderSize = 0
Me.BTNRefreshVideos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BTNRefreshVideos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.BTNRefreshVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BTNRefreshVideos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNRefreshVideos.ForeColor = System.Drawing.Color.Black
Me.BTNRefreshVideos.Location = New System.Drawing.Point(671, 6)
Me.BTNRefreshVideos.Name = "BTNRefreshVideos"
Me.BTNRefreshVideos.Size = New System.Drawing.Size(30, 26)
Me.BTNRefreshVideos.TabIndex = 149
Me.BTNRefreshVideos.UseVisualStyleBackColor = false
'
'GbxVideoGeneralD
'
Me.GbxVideoGeneralD.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoGeneralD.Controls.Add(Me.LblVideoGeneralTotalD)
Me.GbxVideoGeneralD.Controls.Add(Me.TxbVideoGeneralD)
Me.GbxVideoGeneralD.Controls.Add(Me.BTNVideoGeneralD)
Me.GbxVideoGeneralD.Controls.Add(Me.CBVideoGeneralD)
Me.GbxVideoGeneralD.ForeColor = System.Drawing.Color.Black
Me.GbxVideoGeneralD.Location = New System.Drawing.Point(359, 277)
Me.GbxVideoGeneralD.Name = "GbxVideoGeneralD"
Me.GbxVideoGeneralD.Size = New System.Drawing.Size(340, 48)
Me.GbxVideoGeneralD.TabIndex = 5
Me.GbxVideoGeneralD.TabStop = false
Me.GbxVideoGeneralD.Text = "Domme General"
'
'LblVideoGeneralTotalD
'
Me.LblVideoGeneralTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoGeneralTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoGeneralTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoGeneralTotalD.Location = New System.Drawing.Point(299, 19)
Me.LblVideoGeneralTotalD.Name = "LblVideoGeneralTotalD"
Me.LblVideoGeneralTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoGeneralTotalD.TabIndex = 3
Me.LblVideoGeneralTotalD.Text = "0"
Me.LblVideoGeneralTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoGeneralD
'
Me.TxbVideoGeneralD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoGeneralD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoGeneralD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoGeneralD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoGeneralD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoGeneralD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoGeneralD.Location = New System.Drawing.Point(113, 18)
Me.TxbVideoGeneralD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoGeneralD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoGeneralD.Name = "TxbVideoGeneralD"
Me.TxbVideoGeneralD.ReadOnly = true
Me.TxbVideoGeneralD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoGeneralD.TabIndex = 2
Me.TxbVideoGeneralD.Text = Global.Tease_AI.My.MySettings.Default.VideoGeneralD
'
'BTNVideoGeneralD
'
Me.BTNVideoGeneralD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoGeneralD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoGeneralD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoGeneralD.Location = New System.Drawing.Point(73, 13)
Me.BTNVideoGeneralD.Name = "BTNVideoGeneralD"
Me.BTNVideoGeneralD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoGeneralD.TabIndex = 1
Me.BTNVideoGeneralD.Text = "1"
Me.BTNVideoGeneralD.UseVisualStyleBackColor = false
'
'CBVideoGeneralD
'
Me.CBVideoGeneralD.AutoSize = true
Me.CBVideoGeneralD.Checked = Global.Tease_AI.My.MySettings.Default.CBGeneralD
Me.CBVideoGeneralD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGeneralD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoGeneralD.ForeColor = System.Drawing.Color.Black
Me.CBVideoGeneralD.Location = New System.Drawing.Point(6, 19)
Me.CBVideoGeneralD.Name = "CBVideoGeneralD"
Me.CBVideoGeneralD.Size = New System.Drawing.Size(63, 17)
Me.CBVideoGeneralD.TabIndex = 0
Me.CBVideoGeneralD.Text = "General"
Me.CBVideoGeneralD.UseVisualStyleBackColor = true
'
'GbxVideoSpecialD
'
Me.GbxVideoSpecialD.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoSpecialD.Controls.Add(Me.LblVideoCHTotalD)
Me.GbxVideoSpecialD.Controls.Add(Me.LblVideoJOITotalD)
Me.GbxVideoSpecialD.Controls.Add(Me.TxbVideoCHD)
Me.GbxVideoSpecialD.Controls.Add(Me.TxbVideoJOID)
Me.GbxVideoSpecialD.Controls.Add(Me.BTNVideoCHD)
Me.GbxVideoSpecialD.Controls.Add(Me.BTNVideoJOID)
Me.GbxVideoSpecialD.Controls.Add(Me.CBVideoJOID)
Me.GbxVideoSpecialD.Controls.Add(Me.CBVideoCHD)
Me.GbxVideoSpecialD.ForeColor = System.Drawing.Color.Black
Me.GbxVideoSpecialD.Location = New System.Drawing.Point(359, 201)
Me.GbxVideoSpecialD.Name = "GbxVideoSpecialD"
Me.GbxVideoSpecialD.Size = New System.Drawing.Size(340, 70)
Me.GbxVideoSpecialD.TabIndex = 4
Me.GbxVideoSpecialD.TabStop = false
Me.GbxVideoSpecialD.Text = "Domme Special"
'
'LblVideoCHTotalD
'
Me.LblVideoCHTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoCHTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoCHTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoCHTotalD.Location = New System.Drawing.Point(299, 42)
Me.LblVideoCHTotalD.Name = "LblVideoCHTotalD"
Me.LblVideoCHTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoCHTotalD.TabIndex = 7
Me.LblVideoCHTotalD.Text = "0"
Me.LblVideoCHTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LblVideoJOITotalD
'
Me.LblVideoJOITotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoJOITotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoJOITotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoJOITotalD.Location = New System.Drawing.Point(299, 19)
Me.LblVideoJOITotalD.Name = "LblVideoJOITotalD"
Me.LblVideoJOITotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoJOITotalD.TabIndex = 3
Me.LblVideoJOITotalD.Text = "0"
Me.LblVideoJOITotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoCHD
'
Me.TxbVideoCHD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoCHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoCHD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoCHD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoCHD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoCHD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoCHD.Location = New System.Drawing.Point(113, 41)
Me.TxbVideoCHD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoCHD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoCHD.Name = "TxbVideoCHD"
Me.TxbVideoCHD.ReadOnly = true
Me.TxbVideoCHD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoCHD.TabIndex = 6
Me.TxbVideoCHD.Text = Global.Tease_AI.My.MySettings.Default.VideoCHD
'
'TxbVideoJOID
'
Me.TxbVideoJOID.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoJOID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoJOID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoJOID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoJOID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoJOID.ForeColor = System.Drawing.Color.Black
Me.TxbVideoJOID.Location = New System.Drawing.Point(113, 18)
Me.TxbVideoJOID.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoJOID.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoJOID.Name = "TxbVideoJOID"
Me.TxbVideoJOID.ReadOnly = true
Me.TxbVideoJOID.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoJOID.TabIndex = 2
Me.TxbVideoJOID.Text = Global.Tease_AI.My.MySettings.Default.VideoJOID
'
'BTNVideoCHD
'
Me.BTNVideoCHD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoCHD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoCHD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoCHD.Location = New System.Drawing.Point(73, 36)
Me.BTNVideoCHD.Name = "BTNVideoCHD"
Me.BTNVideoCHD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoCHD.TabIndex = 5
Me.BTNVideoCHD.Text = "1"
Me.BTNVideoCHD.UseVisualStyleBackColor = false
'
'BTNVideoJOID
'
Me.BTNVideoJOID.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoJOID.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoJOID.ForeColor = System.Drawing.Color.Black
Me.BTNVideoJOID.Location = New System.Drawing.Point(73, 13)
Me.BTNVideoJOID.Name = "BTNVideoJOID"
Me.BTNVideoJOID.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoJOID.TabIndex = 1
Me.BTNVideoJOID.Text = "1"
Me.BTNVideoJOID.UseVisualStyleBackColor = false
'
'CBVideoJOID
'
Me.CBVideoJOID.AutoSize = true
Me.CBVideoJOID.Checked = Global.Tease_AI.My.MySettings.Default.CBJOID
Me.CBVideoJOID.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBJOID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoJOID.ForeColor = System.Drawing.Color.Black
Me.CBVideoJOID.Location = New System.Drawing.Point(6, 19)
Me.CBVideoJOID.Name = "CBVideoJOID"
Me.CBVideoJOID.Size = New System.Drawing.Size(42, 17)
Me.CBVideoJOID.TabIndex = 0
Me.CBVideoJOID.Text = "JOI"
Me.CBVideoJOID.UseVisualStyleBackColor = true
'
'CBVideoCHD
'
Me.CBVideoCHD.AutoSize = true
Me.CBVideoCHD.Checked = Global.Tease_AI.My.MySettings.Default.CBCHD
Me.CBVideoCHD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBCHD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoCHD.ForeColor = System.Drawing.Color.Black
Me.CBVideoCHD.Location = New System.Drawing.Point(6, 43)
Me.CBVideoCHD.Name = "CBVideoCHD"
Me.CBVideoCHD.Size = New System.Drawing.Size(41, 17)
Me.CBVideoCHD.TabIndex = 4
Me.CBVideoCHD.Text = "CH"
Me.CBVideoCHD.UseVisualStyleBackColor = true
'
'GbxVideoGenreD
'
Me.GbxVideoGenreD.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoFemsubTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoFemsubD)
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoFemdomTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoFemdomD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoBlowjobD)
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoBlowjobTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoLesbianD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoSoftCoreD)
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoLesbianTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.TxbVideoHardCoreD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoFemSubD)
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoSoftCoreTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoFemDomD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoBlowjobD)
Me.GbxVideoGenreD.Controls.Add(Me.LblVideoHardCoreTotalD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoLesbianD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoSoftCoreD)
Me.GbxVideoGenreD.Controls.Add(Me.BTNVideoHardCoreD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoHardcoreD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoSoftCoreD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoLesbianD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoBlowjobD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoFemsubD)
Me.GbxVideoGenreD.Controls.Add(Me.CBVideoFemdomD)
Me.GbxVideoGenreD.ForeColor = System.Drawing.Color.Black
Me.GbxVideoGenreD.Location = New System.Drawing.Point(359, 30)
Me.GbxVideoGenreD.Name = "GbxVideoGenreD"
Me.GbxVideoGenreD.Size = New System.Drawing.Size(340, 165)
Me.GbxVideoGenreD.TabIndex = 3
Me.GbxVideoGenreD.TabStop = false
Me.GbxVideoGenreD.Text = "Domme Genre"
'
'LblVideoFemsubTotalD
'
Me.LblVideoFemsubTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoFemsubTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoFemsubTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoFemsubTotalD.Location = New System.Drawing.Point(299, 136)
Me.LblVideoFemsubTotalD.Name = "LblVideoFemsubTotalD"
Me.LblVideoFemsubTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoFemsubTotalD.TabIndex = 23
Me.LblVideoFemsubTotalD.Text = "0"
Me.LblVideoFemsubTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoFemsubD
'
Me.TxbVideoFemsubD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoFemsubD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoFemsubD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoFemsubD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoFemsubD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoFemsubD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoFemsubD.Location = New System.Drawing.Point(113, 136)
Me.TxbVideoFemsubD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoFemsubD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoFemsubD.Name = "TxbVideoFemsubD"
Me.TxbVideoFemsubD.ReadOnly = true
Me.TxbVideoFemsubD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoFemsubD.TabIndex = 22
Me.TxbVideoFemsubD.Text = Global.Tease_AI.My.MySettings.Default.VideoFemsubD
'
'LblVideoFemdomTotalD
'
Me.LblVideoFemdomTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoFemdomTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoFemdomTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoFemdomTotalD.Location = New System.Drawing.Point(299, 112)
Me.LblVideoFemdomTotalD.Name = "LblVideoFemdomTotalD"
Me.LblVideoFemdomTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoFemdomTotalD.TabIndex = 19
Me.LblVideoFemdomTotalD.Text = "0"
Me.LblVideoFemdomTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoFemdomD
'
Me.TxbVideoFemdomD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoFemdomD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoFemdomD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoFemdomD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoFemdomD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoFemdomD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoFemdomD.Location = New System.Drawing.Point(113, 112)
Me.TxbVideoFemdomD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoFemdomD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoFemdomD.Name = "TxbVideoFemdomD"
Me.TxbVideoFemdomD.ReadOnly = true
Me.TxbVideoFemdomD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoFemdomD.TabIndex = 18
Me.TxbVideoFemdomD.Text = Global.Tease_AI.My.MySettings.Default.VideoFemdomD
'
'TxbVideoBlowjobD
'
Me.TxbVideoBlowjobD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoBlowjobD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoBlowjobD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoBlowjobD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoBlowjobD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoBlowjobD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoBlowjobD.Location = New System.Drawing.Point(113, 88)
Me.TxbVideoBlowjobD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoBlowjobD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoBlowjobD.Name = "TxbVideoBlowjobD"
Me.TxbVideoBlowjobD.ReadOnly = true
Me.TxbVideoBlowjobD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoBlowjobD.TabIndex = 14
Me.TxbVideoBlowjobD.Text = Global.Tease_AI.My.MySettings.Default.VideoBlowjobD
'
'LblVideoBlowjobTotalD
'
Me.LblVideoBlowjobTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoBlowjobTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoBlowjobTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoBlowjobTotalD.Location = New System.Drawing.Point(299, 88)
Me.LblVideoBlowjobTotalD.Name = "LblVideoBlowjobTotalD"
Me.LblVideoBlowjobTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoBlowjobTotalD.TabIndex = 15
Me.LblVideoBlowjobTotalD.Text = "0"
Me.LblVideoBlowjobTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoLesbianD
'
Me.TxbVideoLesbianD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoLesbianD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoLesbianD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoLesbianD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoLesbianD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoLesbianD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoLesbianD.Location = New System.Drawing.Point(113, 65)
Me.TxbVideoLesbianD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoLesbianD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoLesbianD.Name = "TxbVideoLesbianD"
Me.TxbVideoLesbianD.ReadOnly = true
Me.TxbVideoLesbianD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoLesbianD.TabIndex = 10
Me.TxbVideoLesbianD.Text = Global.Tease_AI.My.MySettings.Default.VideoLesbianD
'
'TxbVideoSoftCoreD
'
Me.TxbVideoSoftCoreD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoSoftCoreD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoSoftCoreD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoSoftcoreD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoSoftCoreD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoSoftCoreD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoSoftCoreD.Location = New System.Drawing.Point(113, 42)
Me.TxbVideoSoftCoreD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoSoftCoreD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoSoftCoreD.Name = "TxbVideoSoftCoreD"
Me.TxbVideoSoftCoreD.ReadOnly = true
Me.TxbVideoSoftCoreD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoSoftCoreD.TabIndex = 6
Me.TxbVideoSoftCoreD.Text = Global.Tease_AI.My.MySettings.Default.VideoSoftcoreD
'
'LblVideoLesbianTotalD
'
Me.LblVideoLesbianTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoLesbianTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoLesbianTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoLesbianTotalD.Location = New System.Drawing.Point(299, 66)
Me.LblVideoLesbianTotalD.Name = "LblVideoLesbianTotalD"
Me.LblVideoLesbianTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoLesbianTotalD.TabIndex = 11
Me.LblVideoLesbianTotalD.Text = "0"
Me.LblVideoLesbianTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoHardCoreD
'
Me.TxbVideoHardCoreD.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoHardCoreD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoHardCoreD.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoHardcoreD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoHardCoreD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoHardCoreD.ForeColor = System.Drawing.Color.Black
Me.TxbVideoHardCoreD.Location = New System.Drawing.Point(113, 19)
Me.TxbVideoHardCoreD.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoHardCoreD.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoHardCoreD.Name = "TxbVideoHardCoreD"
Me.TxbVideoHardCoreD.ReadOnly = true
Me.TxbVideoHardCoreD.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoHardCoreD.TabIndex = 2
Me.TxbVideoHardCoreD.Text = Global.Tease_AI.My.MySettings.Default.VideoHardcoreD
'
'BTNVideoFemSubD
'
Me.BTNVideoFemSubD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoFemSubD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoFemSubD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoFemSubD.Location = New System.Drawing.Point(73, 130)
Me.BTNVideoFemSubD.Name = "BTNVideoFemSubD"
Me.BTNVideoFemSubD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoFemSubD.TabIndex = 21
Me.BTNVideoFemSubD.Text = "1"
Me.BTNVideoFemSubD.UseVisualStyleBackColor = false
'
'LblVideoSoftCoreTotalD
'
Me.LblVideoSoftCoreTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoSoftCoreTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoSoftCoreTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoSoftCoreTotalD.Location = New System.Drawing.Point(299, 43)
Me.LblVideoSoftCoreTotalD.Name = "LblVideoSoftCoreTotalD"
Me.LblVideoSoftCoreTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoSoftCoreTotalD.TabIndex = 7
Me.LblVideoSoftCoreTotalD.Text = "0"
Me.LblVideoSoftCoreTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNVideoFemDomD
'
Me.BTNVideoFemDomD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoFemDomD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoFemDomD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoFemDomD.Location = New System.Drawing.Point(73, 106)
Me.BTNVideoFemDomD.Name = "BTNVideoFemDomD"
Me.BTNVideoFemDomD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoFemDomD.TabIndex = 17
Me.BTNVideoFemDomD.Text = "1"
Me.BTNVideoFemDomD.UseVisualStyleBackColor = false
'
'BTNVideoBlowjobD
'
Me.BTNVideoBlowjobD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoBlowjobD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoBlowjobD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoBlowjobD.Location = New System.Drawing.Point(73, 82)
Me.BTNVideoBlowjobD.Name = "BTNVideoBlowjobD"
Me.BTNVideoBlowjobD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoBlowjobD.TabIndex = 13
Me.BTNVideoBlowjobD.Text = "1"
Me.BTNVideoBlowjobD.UseVisualStyleBackColor = false
'
'LblVideoHardCoreTotalD
'
Me.LblVideoHardCoreTotalD.BackColor = System.Drawing.Color.Transparent
Me.LblVideoHardCoreTotalD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoHardCoreTotalD.ForeColor = System.Drawing.Color.Black
Me.LblVideoHardCoreTotalD.Location = New System.Drawing.Point(299, 19)
Me.LblVideoHardCoreTotalD.Name = "LblVideoHardCoreTotalD"
Me.LblVideoHardCoreTotalD.Size = New System.Drawing.Size(34, 17)
Me.LblVideoHardCoreTotalD.TabIndex = 3
Me.LblVideoHardCoreTotalD.Text = "0"
Me.LblVideoHardCoreTotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNVideoLesbianD
'
Me.BTNVideoLesbianD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoLesbianD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoLesbianD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoLesbianD.Location = New System.Drawing.Point(73, 59)
Me.BTNVideoLesbianD.Name = "BTNVideoLesbianD"
Me.BTNVideoLesbianD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoLesbianD.TabIndex = 9
Me.BTNVideoLesbianD.Text = "1"
Me.BTNVideoLesbianD.UseVisualStyleBackColor = false
'
'BTNVideoSoftCoreD
'
Me.BTNVideoSoftCoreD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoSoftCoreD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoSoftCoreD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoSoftCoreD.Location = New System.Drawing.Point(73, 36)
Me.BTNVideoSoftCoreD.Name = "BTNVideoSoftCoreD"
Me.BTNVideoSoftCoreD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoSoftCoreD.TabIndex = 5
Me.BTNVideoSoftCoreD.Text = "1"
Me.BTNVideoSoftCoreD.UseVisualStyleBackColor = false
'
'BTNVideoHardCoreD
'
Me.BTNVideoHardCoreD.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoHardCoreD.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoHardCoreD.ForeColor = System.Drawing.Color.Black
Me.BTNVideoHardCoreD.Location = New System.Drawing.Point(73, 12)
Me.BTNVideoHardCoreD.Name = "BTNVideoHardCoreD"
Me.BTNVideoHardCoreD.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoHardCoreD.TabIndex = 1
Me.BTNVideoHardCoreD.Text = "1"
Me.BTNVideoHardCoreD.UseVisualStyleBackColor = false
'
'CBVideoHardcoreD
'
Me.CBVideoHardcoreD.AutoSize = true
Me.CBVideoHardcoreD.Checked = Global.Tease_AI.My.MySettings.Default.CBHardcoreD
Me.CBVideoHardcoreD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBHardcoreD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoHardcoreD.ForeColor = System.Drawing.Color.Black
Me.CBVideoHardcoreD.Location = New System.Drawing.Point(6, 19)
Me.CBVideoHardcoreD.Name = "CBVideoHardcoreD"
Me.CBVideoHardcoreD.Size = New System.Drawing.Size(70, 17)
Me.CBVideoHardcoreD.TabIndex = 0
Me.CBVideoHardcoreD.Text = "Hardcore"
Me.CBVideoHardcoreD.UseVisualStyleBackColor = true
'
'CBVideoSoftCoreD
'
Me.CBVideoSoftCoreD.AutoSize = true
Me.CBVideoSoftCoreD.Checked = Global.Tease_AI.My.MySettings.Default.CBSoftcoreD
Me.CBVideoSoftCoreD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBSoftcoreD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoSoftCoreD.ForeColor = System.Drawing.Color.Black
Me.CBVideoSoftCoreD.Location = New System.Drawing.Point(6, 43)
Me.CBVideoSoftCoreD.Name = "CBVideoSoftCoreD"
Me.CBVideoSoftCoreD.Size = New System.Drawing.Size(66, 17)
Me.CBVideoSoftCoreD.TabIndex = 4
Me.CBVideoSoftCoreD.Text = "Softcore"
Me.CBVideoSoftCoreD.UseVisualStyleBackColor = true
'
'CBVideoLesbianD
'
Me.CBVideoLesbianD.AutoSize = true
Me.CBVideoLesbianD.Checked = Global.Tease_AI.My.MySettings.Default.CBLesbianD
Me.CBVideoLesbianD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBLesbianD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoLesbianD.ForeColor = System.Drawing.Color.Black
Me.CBVideoLesbianD.Location = New System.Drawing.Point(6, 66)
Me.CBVideoLesbianD.Name = "CBVideoLesbianD"
Me.CBVideoLesbianD.Size = New System.Drawing.Size(63, 17)
Me.CBVideoLesbianD.TabIndex = 8
Me.CBVideoLesbianD.Text = "Lesbian"
Me.CBVideoLesbianD.UseVisualStyleBackColor = true
'
'CBVideoBlowjobD
'
Me.CBVideoBlowjobD.AutoSize = true
Me.CBVideoBlowjobD.Checked = Global.Tease_AI.My.MySettings.Default.CBBlowjobD
Me.CBVideoBlowjobD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBBlowjobD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoBlowjobD.ForeColor = System.Drawing.Color.Black
Me.CBVideoBlowjobD.Location = New System.Drawing.Point(6, 89)
Me.CBVideoBlowjobD.Name = "CBVideoBlowjobD"
Me.CBVideoBlowjobD.Size = New System.Drawing.Size(63, 17)
Me.CBVideoBlowjobD.TabIndex = 12
Me.CBVideoBlowjobD.Text = "Blowjob"
Me.CBVideoBlowjobD.UseVisualStyleBackColor = true
'
'CBVideoFemsubD
'
Me.CBVideoFemsubD.AutoSize = true
Me.CBVideoFemsubD.Checked = Global.Tease_AI.My.MySettings.Default.CBFemsubD
Me.CBVideoFemsubD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBFemsubD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoFemsubD.ForeColor = System.Drawing.Color.Black
Me.CBVideoFemsubD.Location = New System.Drawing.Point(6, 137)
Me.CBVideoFemsubD.Name = "CBVideoFemsubD"
Me.CBVideoFemsubD.Size = New System.Drawing.Size(63, 17)
Me.CBVideoFemsubD.TabIndex = 20
Me.CBVideoFemsubD.Text = "Femsub"
Me.CBVideoFemsubD.UseVisualStyleBackColor = true
'
'CBVideoFemdomD
'
Me.CBVideoFemdomD.AutoSize = true
Me.CBVideoFemdomD.Checked = Global.Tease_AI.My.MySettings.Default.CBFemdomD
Me.CBVideoFemdomD.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBFemdomD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoFemdomD.ForeColor = System.Drawing.Color.Black
Me.CBVideoFemdomD.Location = New System.Drawing.Point(6, 113)
Me.CBVideoFemdomD.Name = "CBVideoFemdomD"
Me.CBVideoFemdomD.Size = New System.Drawing.Size(66, 17)
Me.CBVideoFemdomD.TabIndex = 16
Me.CBVideoFemdomD.Text = "Femdom"
Me.CBVideoFemdomD.UseVisualStyleBackColor = true
'
'GbxVideoDescription
'
Me.GbxVideoDescription.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoDescription.Controls.Add(Me.VideoDescriptionLabel)
Me.GbxVideoDescription.ForeColor = System.Drawing.Color.Black
Me.GbxVideoDescription.Location = New System.Drawing.Point(7, 331)
Me.GbxVideoDescription.Name = "GbxVideoDescription"
Me.GbxVideoDescription.Size = New System.Drawing.Size(692, 92)
Me.GbxVideoDescription.TabIndex = 6
Me.GbxVideoDescription.TabStop = false
Me.GbxVideoDescription.Text = "Description"
'
'VideoDescriptionLabel
'
Me.VideoDescriptionLabel.BackColor = System.Drawing.Color.Transparent
Me.VideoDescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.VideoDescriptionLabel.ForeColor = System.Drawing.Color.Black
Me.VideoDescriptionLabel.Location = New System.Drawing.Point(6, 16)
Me.VideoDescriptionLabel.Name = "VideoDescriptionLabel"
Me.VideoDescriptionLabel.Size = New System.Drawing.Size(680, 73)
Me.VideoDescriptionLabel.TabIndex = 62
Me.VideoDescriptionLabel.Text = "Use this page to select the videos you would like the program to use and set thei"& _ 
    "r paths."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"The Domme Genre paths are for videos that feature the model you are "& _ 
    "using as your domme."
Me.VideoDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GbxVideoGeneral
'
Me.GbxVideoGeneral.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoGeneral.Controls.Add(Me.LblVideoGeneralTotal)
Me.GbxVideoGeneral.Controls.Add(Me.TxbVideoGeneral)
Me.GbxVideoGeneral.Controls.Add(Me.BTNVideoGeneral)
Me.GbxVideoGeneral.Controls.Add(Me.CBVideoGeneral)
Me.GbxVideoGeneral.ForeColor = System.Drawing.Color.Black
Me.GbxVideoGeneral.Location = New System.Drawing.Point(7, 277)
Me.GbxVideoGeneral.Name = "GbxVideoGeneral"
Me.GbxVideoGeneral.Size = New System.Drawing.Size(340, 48)
Me.GbxVideoGeneral.TabIndex = 2
Me.GbxVideoGeneral.TabStop = false
Me.GbxVideoGeneral.Text = "General"
'
'LblVideoGeneralTotal
'
Me.LblVideoGeneralTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoGeneralTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoGeneralTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoGeneralTotal.Location = New System.Drawing.Point(299, 19)
Me.LblVideoGeneralTotal.Name = "LblVideoGeneralTotal"
Me.LblVideoGeneralTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoGeneralTotal.TabIndex = 3
Me.LblVideoGeneralTotal.Text = "0"
Me.LblVideoGeneralTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoGeneral
'
Me.TxbVideoGeneral.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoGeneral", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoGeneral.ForeColor = System.Drawing.Color.Black
Me.TxbVideoGeneral.Location = New System.Drawing.Point(113, 18)
Me.TxbVideoGeneral.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoGeneral.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoGeneral.Name = "TxbVideoGeneral"
Me.TxbVideoGeneral.ReadOnly = true
Me.TxbVideoGeneral.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoGeneral.TabIndex = 2
Me.TxbVideoGeneral.Text = Global.Tease_AI.My.MySettings.Default.VideoGeneral
'
'BTNVideoGeneral
'
Me.BTNVideoGeneral.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoGeneral.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoGeneral.ForeColor = System.Drawing.Color.Black
Me.BTNVideoGeneral.Location = New System.Drawing.Point(73, 13)
Me.BTNVideoGeneral.Name = "BTNVideoGeneral"
Me.BTNVideoGeneral.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoGeneral.TabIndex = 1
Me.BTNVideoGeneral.Text = "1"
Me.BTNVideoGeneral.UseVisualStyleBackColor = false
'
'CBVideoGeneral
'
Me.CBVideoGeneral.AutoSize = true
Me.CBVideoGeneral.Checked = Global.Tease_AI.My.MySettings.Default.CBGeneral
Me.CBVideoGeneral.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGeneral", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoGeneral.ForeColor = System.Drawing.Color.Black
Me.CBVideoGeneral.Location = New System.Drawing.Point(6, 19)
Me.CBVideoGeneral.Name = "CBVideoGeneral"
Me.CBVideoGeneral.Size = New System.Drawing.Size(63, 17)
Me.CBVideoGeneral.TabIndex = 0
Me.CBVideoGeneral.Text = "General"
Me.CBVideoGeneral.UseVisualStyleBackColor = true
'
'GbxVideoSpecial
'
Me.GbxVideoSpecial.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoSpecial.Controls.Add(Me.LblVideoCHTotal)
Me.GbxVideoSpecial.Controls.Add(Me.LblVideoJOITotal)
Me.GbxVideoSpecial.Controls.Add(Me.TxbVideoCH)
Me.GbxVideoSpecial.Controls.Add(Me.TxbVideoJOI)
Me.GbxVideoSpecial.Controls.Add(Me.BTNVideoCH)
Me.GbxVideoSpecial.Controls.Add(Me.BTNVideoJOI)
Me.GbxVideoSpecial.Controls.Add(Me.CBVideoJOI)
Me.GbxVideoSpecial.Controls.Add(Me.CBVideoCH)
Me.GbxVideoSpecial.ForeColor = System.Drawing.Color.Black
Me.GbxVideoSpecial.Location = New System.Drawing.Point(7, 201)
Me.GbxVideoSpecial.Name = "GbxVideoSpecial"
Me.GbxVideoSpecial.Size = New System.Drawing.Size(340, 70)
Me.GbxVideoSpecial.TabIndex = 1
Me.GbxVideoSpecial.TabStop = false
Me.GbxVideoSpecial.Text = "Special"
'
'LblVideoCHTotal
'
Me.LblVideoCHTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoCHTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoCHTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoCHTotal.Location = New System.Drawing.Point(299, 41)
Me.LblVideoCHTotal.Name = "LblVideoCHTotal"
Me.LblVideoCHTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoCHTotal.TabIndex = 7
Me.LblVideoCHTotal.Text = "0"
Me.LblVideoCHTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LblVideoJOITotal
'
Me.LblVideoJOITotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoJOITotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoJOITotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoJOITotal.Location = New System.Drawing.Point(299, 18)
Me.LblVideoJOITotal.Name = "LblVideoJOITotal"
Me.LblVideoJOITotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoJOITotal.TabIndex = 3
Me.LblVideoJOITotal.Text = "0"
Me.LblVideoJOITotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoCH
'
Me.TxbVideoCH.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoCH.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoCH", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoCH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoCH.ForeColor = System.Drawing.Color.Black
Me.TxbVideoCH.Location = New System.Drawing.Point(113, 41)
Me.TxbVideoCH.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoCH.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoCH.Name = "TxbVideoCH"
Me.TxbVideoCH.ReadOnly = true
Me.TxbVideoCH.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoCH.TabIndex = 6
Me.TxbVideoCH.Text = Global.Tease_AI.My.MySettings.Default.VideoCH
'
'TxbVideoJOI
'
Me.TxbVideoJOI.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoJOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoJOI.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoJOI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoJOI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoJOI.ForeColor = System.Drawing.Color.Black
Me.TxbVideoJOI.Location = New System.Drawing.Point(113, 18)
Me.TxbVideoJOI.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoJOI.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoJOI.Name = "TxbVideoJOI"
Me.TxbVideoJOI.ReadOnly = true
Me.TxbVideoJOI.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoJOI.TabIndex = 2
Me.TxbVideoJOI.Text = Global.Tease_AI.My.MySettings.Default.VideoJOI
'
'BTNVideoCH
'
Me.BTNVideoCH.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoCH.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoCH.ForeColor = System.Drawing.Color.Black
Me.BTNVideoCH.Location = New System.Drawing.Point(73, 36)
Me.BTNVideoCH.Name = "BTNVideoCH"
Me.BTNVideoCH.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoCH.TabIndex = 5
Me.BTNVideoCH.Text = "1"
Me.BTNVideoCH.UseVisualStyleBackColor = false
'
'BTNVideoJOI
'
Me.BTNVideoJOI.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoJOI.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoJOI.ForeColor = System.Drawing.Color.Black
Me.BTNVideoJOI.Location = New System.Drawing.Point(73, 13)
Me.BTNVideoJOI.Name = "BTNVideoJOI"
Me.BTNVideoJOI.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoJOI.TabIndex = 1
Me.BTNVideoJOI.Text = "1"
Me.BTNVideoJOI.UseVisualStyleBackColor = false
'
'CBVideoJOI
'
Me.CBVideoJOI.AutoSize = true
Me.CBVideoJOI.Checked = Global.Tease_AI.My.MySettings.Default.CBJOI
Me.CBVideoJOI.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBJOI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoJOI.ForeColor = System.Drawing.Color.Black
Me.CBVideoJOI.Location = New System.Drawing.Point(6, 19)
Me.CBVideoJOI.Name = "CBVideoJOI"
Me.CBVideoJOI.Size = New System.Drawing.Size(42, 17)
Me.CBVideoJOI.TabIndex = 0
Me.CBVideoJOI.Text = "JOI"
Me.CBVideoJOI.UseVisualStyleBackColor = true
'
'CBVideoCH
'
Me.CBVideoCH.AutoSize = true
Me.CBVideoCH.Checked = Global.Tease_AI.My.MySettings.Default.CBCH
Me.CBVideoCH.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBCH", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoCH.ForeColor = System.Drawing.Color.Black
Me.CBVideoCH.Location = New System.Drawing.Point(6, 43)
Me.CBVideoCH.Name = "CBVideoCH"
Me.CBVideoCH.Size = New System.Drawing.Size(41, 17)
Me.CBVideoCH.TabIndex = 4
Me.CBVideoCH.Text = "CH"
Me.CBVideoCH.UseVisualStyleBackColor = true
'
'GbxVideoGenre
'
Me.GbxVideoGenre.BackColor = System.Drawing.Color.LightGray
Me.GbxVideoGenre.Controls.Add(Me.LblVideoFemsubTotal)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoFemsub)
Me.GbxVideoGenre.Controls.Add(Me.LblVideoFemdomTotal)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoFemdom)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoBlowjob)
Me.GbxVideoGenre.Controls.Add(Me.LblVideoBlowjobTotal)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoLesbian)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoSoftCore)
Me.GbxVideoGenre.Controls.Add(Me.LblVideoLesbianTotal)
Me.GbxVideoGenre.Controls.Add(Me.TxbVideoHardCore)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoFemSub)
Me.GbxVideoGenre.Controls.Add(Me.LblVideoSoftCoreTotal)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoFemDom)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoBlowjob)
Me.GbxVideoGenre.Controls.Add(Me.LblVideoHardCoreTotal)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoLesbian)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoSoftCore)
Me.GbxVideoGenre.Controls.Add(Me.BTNVideoHardCore)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoHardcore)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoSoftCore)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoLesbian)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoBlowjob)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoFemsub)
Me.GbxVideoGenre.Controls.Add(Me.CBVideoFemdom)
Me.GbxVideoGenre.ForeColor = System.Drawing.Color.Black
Me.GbxVideoGenre.Location = New System.Drawing.Point(7, 30)
Me.GbxVideoGenre.Name = "GbxVideoGenre"
Me.GbxVideoGenre.Size = New System.Drawing.Size(340, 165)
Me.GbxVideoGenre.TabIndex = 0
Me.GbxVideoGenre.TabStop = false
Me.GbxVideoGenre.Text = "Genre"
'
'LblVideoFemsubTotal
'
Me.LblVideoFemsubTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoFemsubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoFemsubTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoFemsubTotal.Location = New System.Drawing.Point(299, 136)
Me.LblVideoFemsubTotal.Name = "LblVideoFemsubTotal"
Me.LblVideoFemsubTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoFemsubTotal.TabIndex = 23
Me.LblVideoFemsubTotal.Text = "0"
Me.LblVideoFemsubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoFemsub
'
Me.TxbVideoFemsub.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoFemsub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoFemsub.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoFemsub", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoFemsub.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoFemsub.ForeColor = System.Drawing.Color.Black
Me.TxbVideoFemsub.Location = New System.Drawing.Point(113, 136)
Me.TxbVideoFemsub.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoFemsub.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoFemsub.Name = "TxbVideoFemsub"
Me.TxbVideoFemsub.ReadOnly = true
Me.TxbVideoFemsub.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoFemsub.TabIndex = 22
Me.TxbVideoFemsub.Text = Global.Tease_AI.My.MySettings.Default.VideoFemsub
'
'LblVideoFemdomTotal
'
Me.LblVideoFemdomTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoFemdomTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoFemdomTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoFemdomTotal.Location = New System.Drawing.Point(299, 112)
Me.LblVideoFemdomTotal.Name = "LblVideoFemdomTotal"
Me.LblVideoFemdomTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoFemdomTotal.TabIndex = 19
Me.LblVideoFemdomTotal.Text = "0"
Me.LblVideoFemdomTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoFemdom
'
Me.TxbVideoFemdom.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoFemdom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoFemdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoFemdom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoFemdom.ForeColor = System.Drawing.Color.Black
Me.TxbVideoFemdom.Location = New System.Drawing.Point(113, 112)
Me.TxbVideoFemdom.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoFemdom.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoFemdom.Name = "TxbVideoFemdom"
Me.TxbVideoFemdom.ReadOnly = true
Me.TxbVideoFemdom.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoFemdom.TabIndex = 18
Me.TxbVideoFemdom.Text = Global.Tease_AI.My.MySettings.Default.VideoFemdom
'
'TxbVideoBlowjob
'
Me.TxbVideoBlowjob.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoBlowjob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoBlowjob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoBlowjob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoBlowjob.ForeColor = System.Drawing.Color.Black
Me.TxbVideoBlowjob.Location = New System.Drawing.Point(113, 88)
Me.TxbVideoBlowjob.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoBlowjob.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoBlowjob.Name = "TxbVideoBlowjob"
Me.TxbVideoBlowjob.ReadOnly = true
Me.TxbVideoBlowjob.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoBlowjob.TabIndex = 14
Me.TxbVideoBlowjob.Text = Global.Tease_AI.My.MySettings.Default.VideoBlowjob
'
'LblVideoBlowjobTotal
'
Me.LblVideoBlowjobTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoBlowjobTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoBlowjobTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoBlowjobTotal.Location = New System.Drawing.Point(299, 88)
Me.LblVideoBlowjobTotal.Name = "LblVideoBlowjobTotal"
Me.LblVideoBlowjobTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoBlowjobTotal.TabIndex = 15
Me.LblVideoBlowjobTotal.Text = "0"
Me.LblVideoBlowjobTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoLesbian
'
Me.TxbVideoLesbian.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoLesbian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoLesbian.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoLesbian", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoLesbian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoLesbian.ForeColor = System.Drawing.Color.Black
Me.TxbVideoLesbian.Location = New System.Drawing.Point(113, 65)
Me.TxbVideoLesbian.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoLesbian.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoLesbian.Name = "TxbVideoLesbian"
Me.TxbVideoLesbian.ReadOnly = true
Me.TxbVideoLesbian.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoLesbian.TabIndex = 10
Me.TxbVideoLesbian.Text = Global.Tease_AI.My.MySettings.Default.VideoLesbian
'
'TxbVideoSoftCore
'
Me.TxbVideoSoftCore.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoSoftCore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoSoftCore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoSoftcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoSoftCore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoSoftCore.ForeColor = System.Drawing.Color.Black
Me.TxbVideoSoftCore.Location = New System.Drawing.Point(113, 42)
Me.TxbVideoSoftCore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoSoftCore.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoSoftCore.Name = "TxbVideoSoftCore"
Me.TxbVideoSoftCore.ReadOnly = true
Me.TxbVideoSoftCore.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoSoftCore.TabIndex = 6
Me.TxbVideoSoftCore.Text = Global.Tease_AI.My.MySettings.Default.VideoSoftcore
'
'LblVideoLesbianTotal
'
Me.LblVideoLesbianTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoLesbianTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoLesbianTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoLesbianTotal.Location = New System.Drawing.Point(299, 66)
Me.LblVideoLesbianTotal.Name = "LblVideoLesbianTotal"
Me.LblVideoLesbianTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoLesbianTotal.TabIndex = 11
Me.LblVideoLesbianTotal.Text = "0"
Me.LblVideoLesbianTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxbVideoHardCore
'
Me.TxbVideoHardCore.BackColor = System.Drawing.Color.LightGray
Me.TxbVideoHardCore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbVideoHardCore.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "VideoHardcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TxbVideoHardCore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TxbVideoHardCore.ForeColor = System.Drawing.Color.Black
Me.TxbVideoHardCore.Location = New System.Drawing.Point(113, 19)
Me.TxbVideoHardCore.MaximumSize = New System.Drawing.Size(2, 17)
Me.TxbVideoHardCore.MinimumSize = New System.Drawing.Size(180, 17)
Me.TxbVideoHardCore.Name = "TxbVideoHardCore"
Me.TxbVideoHardCore.ReadOnly = true
Me.TxbVideoHardCore.Size = New System.Drawing.Size(180, 17)
Me.TxbVideoHardCore.TabIndex = 2
Me.TxbVideoHardCore.Text = Global.Tease_AI.My.MySettings.Default.VideoHardcore
'
'BTNVideoFemSub
'
Me.BTNVideoFemSub.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoFemSub.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoFemSub.ForeColor = System.Drawing.Color.Black
Me.BTNVideoFemSub.Location = New System.Drawing.Point(73, 130)
Me.BTNVideoFemSub.Name = "BTNVideoFemSub"
Me.BTNVideoFemSub.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoFemSub.TabIndex = 21
Me.BTNVideoFemSub.Text = "1"
Me.BTNVideoFemSub.UseVisualStyleBackColor = false
'
'LblVideoSoftCoreTotal
'
Me.LblVideoSoftCoreTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoSoftCoreTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoSoftCoreTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoSoftCoreTotal.Location = New System.Drawing.Point(299, 43)
Me.LblVideoSoftCoreTotal.Name = "LblVideoSoftCoreTotal"
Me.LblVideoSoftCoreTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoSoftCoreTotal.TabIndex = 7
Me.LblVideoSoftCoreTotal.Text = "0"
Me.LblVideoSoftCoreTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNVideoFemDom
'
Me.BTNVideoFemDom.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoFemDom.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoFemDom.ForeColor = System.Drawing.Color.Black
Me.BTNVideoFemDom.Location = New System.Drawing.Point(73, 106)
Me.BTNVideoFemDom.Name = "BTNVideoFemDom"
Me.BTNVideoFemDom.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoFemDom.TabIndex = 17
Me.BTNVideoFemDom.Text = "1"
Me.BTNVideoFemDom.UseVisualStyleBackColor = false
'
'BTNVideoBlowjob
'
Me.BTNVideoBlowjob.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoBlowjob.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoBlowjob.ForeColor = System.Drawing.Color.Black
Me.BTNVideoBlowjob.Location = New System.Drawing.Point(73, 82)
Me.BTNVideoBlowjob.Name = "BTNVideoBlowjob"
Me.BTNVideoBlowjob.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoBlowjob.TabIndex = 13
Me.BTNVideoBlowjob.Text = "1"
Me.BTNVideoBlowjob.UseVisualStyleBackColor = false
'
'LblVideoHardCoreTotal
'
Me.LblVideoHardCoreTotal.BackColor = System.Drawing.Color.Transparent
Me.LblVideoHardCoreTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoHardCoreTotal.ForeColor = System.Drawing.Color.Black
Me.LblVideoHardCoreTotal.Location = New System.Drawing.Point(299, 19)
Me.LblVideoHardCoreTotal.Name = "LblVideoHardCoreTotal"
Me.LblVideoHardCoreTotal.Size = New System.Drawing.Size(34, 17)
Me.LblVideoHardCoreTotal.TabIndex = 3
Me.LblVideoHardCoreTotal.Text = "0"
Me.LblVideoHardCoreTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNVideoLesbian
'
Me.BTNVideoLesbian.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoLesbian.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoLesbian.ForeColor = System.Drawing.Color.Black
Me.BTNVideoLesbian.Location = New System.Drawing.Point(73, 59)
Me.BTNVideoLesbian.Name = "BTNVideoLesbian"
Me.BTNVideoLesbian.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoLesbian.TabIndex = 9
Me.BTNVideoLesbian.Text = "1"
Me.BTNVideoLesbian.UseVisualStyleBackColor = false
'
'BTNVideoSoftCore
'
Me.BTNVideoSoftCore.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoSoftCore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoSoftCore.ForeColor = System.Drawing.Color.Black
Me.BTNVideoSoftCore.Location = New System.Drawing.Point(73, 36)
Me.BTNVideoSoftCore.Name = "BTNVideoSoftCore"
Me.BTNVideoSoftCore.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoSoftCore.TabIndex = 5
Me.BTNVideoSoftCore.Text = "1"
Me.BTNVideoSoftCore.UseVisualStyleBackColor = false
'
'BTNVideoHardCore
'
Me.BTNVideoHardCore.BackColor = System.Drawing.Color.LightGray
Me.BTNVideoHardCore.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.BTNVideoHardCore.ForeColor = System.Drawing.Color.Black
Me.BTNVideoHardCore.Location = New System.Drawing.Point(73, 12)
Me.BTNVideoHardCore.Name = "BTNVideoHardCore"
Me.BTNVideoHardCore.Size = New System.Drawing.Size(34, 28)
Me.BTNVideoHardCore.TabIndex = 1
Me.BTNVideoHardCore.Text = "1"
Me.BTNVideoHardCore.UseVisualStyleBackColor = false
'
'CBVideoHardcore
'
Me.CBVideoHardcore.AutoSize = true
Me.CBVideoHardcore.Checked = Global.Tease_AI.My.MySettings.Default.CBHardcore
Me.CBVideoHardcore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBHardcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoHardcore.ForeColor = System.Drawing.Color.Black
Me.CBVideoHardcore.Location = New System.Drawing.Point(6, 19)
Me.CBVideoHardcore.Name = "CBVideoHardcore"
Me.CBVideoHardcore.Size = New System.Drawing.Size(70, 17)
Me.CBVideoHardcore.TabIndex = 0
Me.CBVideoHardcore.Text = "Hardcore"
Me.CBVideoHardcore.UseVisualStyleBackColor = true
'
'CBVideoSoftCore
'
Me.CBVideoSoftCore.AutoSize = true
Me.CBVideoSoftCore.Checked = Global.Tease_AI.My.MySettings.Default.CBSoftcore
Me.CBVideoSoftCore.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBSoftcore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoSoftCore.ForeColor = System.Drawing.Color.Black
Me.CBVideoSoftCore.Location = New System.Drawing.Point(6, 43)
Me.CBVideoSoftCore.Name = "CBVideoSoftCore"
Me.CBVideoSoftCore.Size = New System.Drawing.Size(66, 17)
Me.CBVideoSoftCore.TabIndex = 4
Me.CBVideoSoftCore.Text = "Softcore"
Me.CBVideoSoftCore.UseVisualStyleBackColor = true
'
'CBVideoLesbian
'
Me.CBVideoLesbian.AutoSize = true
Me.CBVideoLesbian.Checked = Global.Tease_AI.My.MySettings.Default.CBLesbian
Me.CBVideoLesbian.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBLesbian", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoLesbian.ForeColor = System.Drawing.Color.Black
Me.CBVideoLesbian.Location = New System.Drawing.Point(6, 66)
Me.CBVideoLesbian.Name = "CBVideoLesbian"
Me.CBVideoLesbian.Size = New System.Drawing.Size(63, 17)
Me.CBVideoLesbian.TabIndex = 8
Me.CBVideoLesbian.Text = "Lesbian"
Me.CBVideoLesbian.UseVisualStyleBackColor = true
'
'CBVideoBlowjob
'
Me.CBVideoBlowjob.AutoSize = true
Me.CBVideoBlowjob.Checked = Global.Tease_AI.My.MySettings.Default.CBBlowjob
Me.CBVideoBlowjob.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBBlowjob", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoBlowjob.ForeColor = System.Drawing.Color.Black
Me.CBVideoBlowjob.Location = New System.Drawing.Point(6, 89)
Me.CBVideoBlowjob.Name = "CBVideoBlowjob"
Me.CBVideoBlowjob.Size = New System.Drawing.Size(63, 17)
Me.CBVideoBlowjob.TabIndex = 12
Me.CBVideoBlowjob.Text = "Blowjob"
Me.CBVideoBlowjob.UseVisualStyleBackColor = true
'
'CBVideoFemsub
'
Me.CBVideoFemsub.AutoSize = true
Me.CBVideoFemsub.Checked = Global.Tease_AI.My.MySettings.Default.CBFemsub
Me.CBVideoFemsub.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBFemsub", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoFemsub.ForeColor = System.Drawing.Color.Black
Me.CBVideoFemsub.Location = New System.Drawing.Point(6, 137)
Me.CBVideoFemsub.Name = "CBVideoFemsub"
Me.CBVideoFemsub.Size = New System.Drawing.Size(63, 17)
Me.CBVideoFemsub.TabIndex = 20
Me.CBVideoFemsub.Text = "Femsub"
Me.CBVideoFemsub.UseVisualStyleBackColor = true
'
'CBVideoFemdom
'
Me.CBVideoFemdom.AutoSize = true
Me.CBVideoFemdom.Checked = Global.Tease_AI.My.MySettings.Default.CBFemdom
Me.CBVideoFemdom.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBFemdom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBVideoFemdom.ForeColor = System.Drawing.Color.Black
Me.CBVideoFemdom.Location = New System.Drawing.Point(6, 113)
Me.CBVideoFemdom.Name = "CBVideoFemdom"
Me.CBVideoFemdom.Size = New System.Drawing.Size(66, 17)
Me.CBVideoFemdom.TabIndex = 16
Me.CBVideoFemdom.Text = "Femdom"
Me.CBVideoFemdom.UseVisualStyleBackColor = true
'
'LblVideoHeader
'
Me.LblVideoHeader.BackColor = System.Drawing.Color.Transparent
Me.LblVideoHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblVideoHeader.ForeColor = System.Drawing.Color.Black
Me.LblVideoHeader.Location = New System.Drawing.Point(7, 6)
Me.LblVideoHeader.Name = "LblVideoHeader"
Me.LblVideoHeader.Size = New System.Drawing.Size(692, 21)
Me.LblVideoHeader.TabIndex = 49
Me.LblVideoHeader.Text = "Video Settings"
Me.LblVideoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage20
'
Me.TabPage20.BackColor = System.Drawing.Color.Silver
Me.TabPage20.Controls.Add(Me.TabControl1)
Me.TabPage20.Location = New System.Drawing.Point(4, 22)
Me.TabPage20.Name = "TabPage20"
Me.TabPage20.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage20.Size = New System.Drawing.Size(720, 448)
Me.TabPage20.TabIndex = 16
Me.TabPage20.Text = "Apps"
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.TabPage22)
Me.TabControl1.Controls.Add(Me.TpGames)
Me.TabControl1.Controls.Add(Me.TabPage6)
Me.TabControl1.Location = New System.Drawing.Point(6, 6)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(708, 437)
Me.TabControl1.TabIndex = 0
'
'TabPage22
'
Me.TabPage22.BackColor = System.Drawing.Color.LightGray
Me.TabPage22.Controls.Add(Me.PNLGlitter)
Me.TabPage22.Location = New System.Drawing.Point(4, 22)
Me.TabPage22.Name = "TabPage22"
Me.TabPage22.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage22.Size = New System.Drawing.Size(700, 411)
Me.TabPage22.TabIndex = 0
Me.TabPage22.Text = "Glitter"
'
'PNLGlitter
'
Me.PNLGlitter.BackColor = System.Drawing.Color.LightGray
Me.PNLGlitter.Controls.Add(Me.GroupBox14)
Me.PNLGlitter.Controls.Add(Me.GroupBox4)
Me.PNLGlitter.Controls.Add(Me.Button15)
Me.PNLGlitter.Controls.Add(Me.Button16)
Me.PNLGlitter.Controls.Add(Me.Label121)
Me.PNLGlitter.Controls.Add(Me.Label122)
Me.PNLGlitter.Controls.Add(Me.GBGlitterD)
Me.PNLGlitter.Controls.Add(Me.GBGlitter1)
Me.PNLGlitter.Controls.Add(Me.GBGlitter3)
Me.PNLGlitter.Controls.Add(Me.GBGlitter2)
Me.PNLGlitter.Location = New System.Drawing.Point(-3, 5)
Me.PNLGlitter.Name = "PNLGlitter"
Me.PNLGlitter.Size = New System.Drawing.Size(708, 404)
Me.PNLGlitter.TabIndex = 91
'
'GroupBox14
'
Me.GroupBox14.BackColor = System.Drawing.Color.LightGray
Me.GroupBox14.Controls.Add(Me.Label170)
Me.GroupBox14.Controls.Add(Me.alwaysNewSlideshow)
Me.GroupBox14.Controls.Add(Me.RandomHonorific)
Me.GroupBox14.Location = New System.Drawing.Point(355, 307)
Me.GroupBox14.Name = "GroupBox14"
Me.GroupBox14.Size = New System.Drawing.Size(306, 85)
Me.GroupBox14.TabIndex = 182
Me.GroupBox14.TabStop = false
Me.GroupBox14.Text = "General Contact Settings"
'
'Label170
'
Me.Label170.Location = New System.Drawing.Point(4, 52)
Me.Label170.Name = "Label170"
Me.Label170.Size = New System.Drawing.Size(142, 18)
Me.Label170.TabIndex = 28
Me.Label170.Text = "Random Domme Honorific:"
Me.Label170.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'alwaysNewSlideshow
'
Me.alwaysNewSlideshow.AutoSize = true
Me.alwaysNewSlideshow.ForeColor = System.Drawing.Color.Black
Me.alwaysNewSlideshow.Location = New System.Drawing.Point(10, 24)
Me.alwaysNewSlideshow.Name = "alwaysNewSlideshow"
Me.alwaysNewSlideshow.Size = New System.Drawing.Size(294, 17)
Me.alwaysNewSlideshow.TabIndex = 151
Me.alwaysNewSlideshow.Text = "Always Load New Slideshow When Using @AddContact"
Me.alwaysNewSlideshow.UseVisualStyleBackColor = true
'
'RandomHonorific
'
Me.RandomHonorific.BackColor = System.Drawing.Color.White
Me.RandomHonorific.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.RandomHonorific.Location = New System.Drawing.Point(149, 51)
Me.RandomHonorific.Name = "RandomHonorific"
Me.RandomHonorific.Size = New System.Drawing.Size(143, 20)
Me.RandomHonorific.TabIndex = 187
Me.RandomHonorific.Text = "Mistress"
Me.RandomHonorific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.LBLCurrentDomme)
Me.GroupBox4.Controls.Add(Me.BTNDomChangeContact1)
Me.GroupBox4.Controls.Add(Me.BTNDomChangeRandom)
Me.GroupBox4.Controls.Add(Me.BTNDomChangeContact3)
Me.GroupBox4.Controls.Add(Me.BTNDomChangeContact2)
Me.GroupBox4.Controls.Add(Me.BTNDomChangeDomme)
Me.GroupBox4.Location = New System.Drawing.Point(7, 307)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(344, 85)
Me.GroupBox4.TabIndex = 167
Me.GroupBox4.TabStop = false
Me.GroupBox4.Text = "Change Current Domme"
'
'LBLCurrentDomme
'
Me.LBLCurrentDomme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLCurrentDomme.Location = New System.Drawing.Point(230, 19)
Me.LBLCurrentDomme.Name = "LBLCurrentDomme"
Me.LBLCurrentDomme.Size = New System.Drawing.Size(104, 24)
Me.LBLCurrentDomme.TabIndex = 168
Me.LBLCurrentDomme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNDomChangeContact1
'
Me.BTNDomChangeContact1.BackColor = System.Drawing.Color.LightGray
Me.BTNDomChangeContact1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomChangeContact1.ForeColor = System.Drawing.Color.Black
Me.BTNDomChangeContact1.Location = New System.Drawing.Point(6, 49)
Me.BTNDomChangeContact1.Name = "BTNDomChangeContact1"
Me.BTNDomChangeContact1.Size = New System.Drawing.Size(108, 24)
Me.BTNDomChangeContact1.TabIndex = 173
Me.BTNDomChangeContact1.Text = "Contact 1"
Me.BTNDomChangeContact1.UseVisualStyleBackColor = false
'
'BTNDomChangeRandom
'
Me.BTNDomChangeRandom.BackColor = System.Drawing.Color.LightGray
Me.BTNDomChangeRandom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomChangeRandom.ForeColor = System.Drawing.Color.Black
Me.BTNDomChangeRandom.Location = New System.Drawing.Point(116, 19)
Me.BTNDomChangeRandom.Name = "BTNDomChangeRandom"
Me.BTNDomChangeRandom.Size = New System.Drawing.Size(108, 24)
Me.BTNDomChangeRandom.TabIndex = 172
Me.BTNDomChangeRandom.Text = "Random"
Me.BTNDomChangeRandom.UseVisualStyleBackColor = false
'
'BTNDomChangeContact3
'
Me.BTNDomChangeContact3.BackColor = System.Drawing.Color.LightGray
Me.BTNDomChangeContact3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomChangeContact3.ForeColor = System.Drawing.Color.Black
Me.BTNDomChangeContact3.Location = New System.Drawing.Point(226, 49)
Me.BTNDomChangeContact3.Name = "BTNDomChangeContact3"
Me.BTNDomChangeContact3.Size = New System.Drawing.Size(108, 24)
Me.BTNDomChangeContact3.TabIndex = 171
Me.BTNDomChangeContact3.Text = "Contact 3"
Me.BTNDomChangeContact3.UseVisualStyleBackColor = false
'
'BTNDomChangeContact2
'
Me.BTNDomChangeContact2.BackColor = System.Drawing.Color.LightGray
Me.BTNDomChangeContact2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomChangeContact2.ForeColor = System.Drawing.Color.Black
Me.BTNDomChangeContact2.Location = New System.Drawing.Point(116, 49)
Me.BTNDomChangeContact2.Name = "BTNDomChangeContact2"
Me.BTNDomChangeContact2.Size = New System.Drawing.Size(108, 24)
Me.BTNDomChangeContact2.TabIndex = 170
Me.BTNDomChangeContact2.Text = "Contact 2"
Me.BTNDomChangeContact2.UseVisualStyleBackColor = false
'
'BTNDomChangeDomme
'
Me.BTNDomChangeDomme.BackColor = System.Drawing.Color.LightGray
Me.BTNDomChangeDomme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNDomChangeDomme.ForeColor = System.Drawing.Color.Black
Me.BTNDomChangeDomme.Location = New System.Drawing.Point(6, 19)
Me.BTNDomChangeDomme.Name = "BTNDomChangeDomme"
Me.BTNDomChangeDomme.Size = New System.Drawing.Size(108, 24)
Me.BTNDomChangeDomme.TabIndex = 168
Me.BTNDomChangeDomme.Text = "Domme"
Me.BTNDomChangeDomme.UseVisualStyleBackColor = false
'
'Button15
'
Me.Button15.BackColor = System.Drawing.Color.LightGray
Me.Button15.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Export
Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.Button15.FlatAppearance.BorderSize = 0
Me.Button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.Button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.Button15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Button15.ForeColor = System.Drawing.Color.Black
Me.Button15.Location = New System.Drawing.Point(670, 366)
Me.Button15.Name = "Button15"
Me.Button15.Size = New System.Drawing.Size(30, 26)
Me.Button15.TabIndex = 163
Me.Button15.UseVisualStyleBackColor = false
'
'Button16
'
Me.Button16.BackColor = System.Drawing.Color.LightGray
Me.Button16.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Button_Save
Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.Button16.FlatAppearance.BorderSize = 0
Me.Button16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.Button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.Button16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Button16.ForeColor = System.Drawing.Color.Black
Me.Button16.Location = New System.Drawing.Point(667, 324)
Me.Button16.Name = "Button16"
Me.Button16.Size = New System.Drawing.Size(30, 26)
Me.Button16.TabIndex = 164
Me.Button16.UseVisualStyleBackColor = false
'
'Label121
'
Me.Label121.AutoSize = true
Me.Label121.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label121.ForeColor = System.Drawing.Color.Black
Me.Label121.Location = New System.Drawing.Point(669, 352)
Me.Label121.Name = "Label121"
Me.Label121.Size = New System.Drawing.Size(27, 13)
Me.Label121.TabIndex = 166
Me.Label121.Text = "load"
Me.Label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label122
'
Me.Label122.AutoSize = true
Me.Label122.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label122.ForeColor = System.Drawing.Color.Black
Me.Label122.Location = New System.Drawing.Point(667, 313)
Me.Label122.Name = "Label122"
Me.Label122.Size = New System.Drawing.Size(30, 13)
Me.Label122.TabIndex = 165
Me.Label122.Text = "save"
Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GBGlitterD
'
Me.GBGlitterD.BackColor = System.Drawing.Color.LightGray
Me.GBGlitterD.Controls.Add(Me.GrbGlitterfeed)
Me.GBGlitterD.Controls.Add(Me.BTNGlitterD)
Me.GBGlitterD.Controls.Add(Me.LBLGlitterNCDomme)
Me.GBGlitterD.Controls.Add(Me.LBLGlitterSlider)
Me.GBGlitterD.Controls.Add(Me.CBCustom2)
Me.GBGlitterD.Controls.Add(Me.GlitterSlider)
Me.GBGlitterD.Controls.Add(Me.CBCustom1)
Me.GBGlitterD.Controls.Add(Me.CBDaily)
Me.GBGlitterD.Controls.Add(Me.CBTrivia)
Me.GBGlitterD.Controls.Add(Me.TBGlitterShortName)
Me.GBGlitterD.Controls.Add(Me.CBEgotist)
Me.GBGlitterD.Controls.Add(Me.CBTease)
Me.GBGlitterD.Controls.Add(Me.GlitterAV)
Me.GBGlitterD.Location = New System.Drawing.Point(7, 1)
Me.GBGlitterD.Name = "GBGlitterD"
Me.GBGlitterD.Size = New System.Drawing.Size(344, 150)
Me.GBGlitterD.TabIndex = 162
Me.GBGlitterD.TabStop = false
Me.GBGlitterD.Text = "Domme"
'
'GrbGlitterfeed
'
Me.GrbGlitterfeed.Controls.Add(Me.CBGlitterFeedScripts)
Me.GrbGlitterfeed.Controls.Add(Me.CBGlitterFeed)
Me.GrbGlitterfeed.Controls.Add(Me.CBGlitterFeedOff)
Me.GrbGlitterfeed.Location = New System.Drawing.Point(79, 16)
Me.GrbGlitterfeed.Name = "GrbGlitterfeed"
Me.GrbGlitterfeed.Size = New System.Drawing.Size(134, 35)
Me.GrbGlitterfeed.TabIndex = 168
Me.GrbGlitterfeed.TabStop = false
Me.GrbGlitterfeed.Text = "Glitterfeeds"
'
'CBGlitterFeedScripts
'
Me.CBGlitterFeedScripts.AutoSize = true
Me.CBGlitterFeedScripts.BackColor = System.Drawing.Color.Transparent
Me.CBGlitterFeedScripts.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitterFeedScripts
Me.CBGlitterFeedScripts.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitterFeedScripts", true))
Me.CBGlitterFeedScripts.Location = New System.Drawing.Point(79, 11)
Me.CBGlitterFeedScripts.Margin = New System.Windows.Forms.Padding(0)
Me.CBGlitterFeedScripts.Name = "CBGlitterFeedScripts"
Me.CBGlitterFeedScripts.Size = New System.Drawing.Size(57, 17)
Me.CBGlitterFeedScripts.TabIndex = 146
Me.CBGlitterFeedScripts.Text = "Scripts"
Me.CBGlitterFeedScripts.UseVisualStyleBackColor = false
'
'CBGlitterFeed
'
Me.CBGlitterFeed.AutoSize = true
Me.CBGlitterFeed.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitterFeed
Me.CBGlitterFeed.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitterFeed", true))
Me.CBGlitterFeed.Location = New System.Drawing.Point(42, 11)
Me.CBGlitterFeed.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
Me.CBGlitterFeed.Name = "CBGlitterFeed"
Me.CBGlitterFeed.Size = New System.Drawing.Size(39, 17)
Me.CBGlitterFeed.TabIndex = 145
Me.CBGlitterFeed.Text = "On"
Me.CBGlitterFeed.UseVisualStyleBackColor = true
'
'CBGlitterFeedOff
'
Me.CBGlitterFeedOff.AutoSize = true
Me.CBGlitterFeedOff.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitterFeedOff
Me.CBGlitterFeedOff.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitterFeedOff", true))
Me.CBGlitterFeedOff.Location = New System.Drawing.Point(8, 11)
Me.CBGlitterFeedOff.Margin = New System.Windows.Forms.Padding(0)
Me.CBGlitterFeedOff.Name = "CBGlitterFeedOff"
Me.CBGlitterFeedOff.Size = New System.Drawing.Size(39, 17)
Me.CBGlitterFeedOff.TabIndex = 147
Me.CBGlitterFeedOff.TabStop = true
Me.CBGlitterFeedOff.Text = "Off"
Me.CBGlitterFeedOff.UseVisualStyleBackColor = true
'
'BTNGlitterD
'
Me.BTNGlitterD.BackColor = System.Drawing.Color.LightGray
Me.BTNGlitterD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNGlitterD.ForeColor = System.Drawing.Color.Black
Me.BTNGlitterD.Location = New System.Drawing.Point(220, 23)
Me.BTNGlitterD.Name = "BTNGlitterD"
Me.BTNGlitterD.Size = New System.Drawing.Size(115, 24)
Me.BTNGlitterD.TabIndex = 166
Me.BTNGlitterD.Text = "Choose Name Color"
Me.BTNGlitterD.UseVisualStyleBackColor = false
'
'LBLGlitterNCDomme
'
Me.LBLGlitterNCDomme.BackColor = System.Drawing.Color.White
Me.LBLGlitterNCDomme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLGlitterNCDomme.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "GlitterNCDommeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLGlitterNCDomme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterNCDomme.ForeColor = Global.Tease_AI.My.MySettings.Default.GlitterNCDommeColor
Me.LBLGlitterNCDomme.Location = New System.Drawing.Point(220, 57)
Me.LBLGlitterNCDomme.Name = "LBLGlitterNCDomme"
Me.LBLGlitterNCDomme.Size = New System.Drawing.Size(115, 23)
Me.LBLGlitterNCDomme.TabIndex = 163
Me.LBLGlitterNCDomme.Text = "Preview"
Me.LBLGlitterNCDomme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLGlitterSlider
'
Me.LBLGlitterSlider.BackColor = System.Drawing.Color.Transparent
Me.LBLGlitterSlider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterSlider.ForeColor = System.Drawing.Color.Black
Me.LBLGlitterSlider.Location = New System.Drawing.Point(220, 96)
Me.LBLGlitterSlider.Name = "LBLGlitterSlider"
Me.LBLGlitterSlider.Size = New System.Drawing.Size(115, 19)
Me.LBLGlitterSlider.TabIndex = 162
Me.LBLGlitterSlider.Text = "Post Frequency"
Me.LBLGlitterSlider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBCustom2
'
Me.CBCustom2.AutoSize = true
Me.CBCustom2.Checked = Global.Tease_AI.My.MySettings.Default.CB2Custom2
Me.CBCustom2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CB2Custom2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBCustom2.ForeColor = System.Drawing.Color.Black
Me.CBCustom2.Location = New System.Drawing.Point(149, 121)
Me.CBCustom2.Name = "CBCustom2"
Me.CBCustom2.Size = New System.Drawing.Size(70, 17)
Me.CBCustom2.TabIndex = 161
Me.CBCustom2.Text = "Custom 2"
Me.CBCustom2.UseVisualStyleBackColor = true
'
'GlitterSlider
'
Me.GlitterSlider.AutoSize = false
Me.GlitterSlider.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "GlitterDSlider", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GlitterSlider.LargeChange = 1
Me.GlitterSlider.Location = New System.Drawing.Point(220, 118)
Me.GlitterSlider.Maximum = 9
Me.GlitterSlider.Minimum = 1
Me.GlitterSlider.Name = "GlitterSlider"
Me.GlitterSlider.Size = New System.Drawing.Size(115, 25)
Me.GlitterSlider.TabIndex = 160
Me.GlitterSlider.Value = Global.Tease_AI.My.MySettings.Default.GlitterDSlider
'
'CBCustom1
'
Me.CBCustom1.AutoSize = true
Me.CBCustom1.Checked = Global.Tease_AI.My.MySettings.Default.CB2Custom1
Me.CBCustom1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CB2Custom1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBCustom1.ForeColor = System.Drawing.Color.Black
Me.CBCustom1.Location = New System.Drawing.Point(149, 98)
Me.CBCustom1.Name = "CBCustom1"
Me.CBCustom1.Size = New System.Drawing.Size(70, 17)
Me.CBCustom1.TabIndex = 157
Me.CBCustom1.Text = "Custom 1"
Me.CBCustom1.UseVisualStyleBackColor = true
'
'CBDaily
'
Me.CBDaily.AutoSize = true
Me.CBDaily.Checked = Global.Tease_AI.My.MySettings.Default.CBDaily
Me.CBDaily.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBDaily", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBDaily.ForeColor = System.Drawing.Color.Black
Me.CBDaily.Location = New System.Drawing.Point(79, 121)
Me.CBDaily.Name = "CBDaily"
Me.CBDaily.Size = New System.Drawing.Size(49, 17)
Me.CBDaily.TabIndex = 156
Me.CBDaily.Text = "Daily"
Me.CBDaily.UseVisualStyleBackColor = true
'
'CBTrivia
'
Me.CBTrivia.AutoSize = true
Me.CBTrivia.Checked = Global.Tease_AI.My.MySettings.Default.CBTrivia
Me.CBTrivia.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBTrivia.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBTrivia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBTrivia.ForeColor = System.Drawing.Color.Black
Me.CBTrivia.Location = New System.Drawing.Point(79, 98)
Me.CBTrivia.Name = "CBTrivia"
Me.CBTrivia.Size = New System.Drawing.Size(52, 17)
Me.CBTrivia.TabIndex = 155
Me.CBTrivia.Text = "Trivia"
Me.CBTrivia.UseVisualStyleBackColor = true
'
'TBGlitterShortName
'
Me.TBGlitterShortName.BackColor = System.Drawing.Color.White
Me.TBGlitterShortName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GlitterSN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TBGlitterShortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBGlitterShortName.ForeColor = System.Drawing.Color.Black
Me.TBGlitterShortName.Location = New System.Drawing.Point(79, 57)
Me.TBGlitterShortName.Name = "TBGlitterShortName"
Me.TBGlitterShortName.Size = New System.Drawing.Size(134, 23)
Me.TBGlitterShortName.TabIndex = 49
Me.TBGlitterShortName.Text = Global.Tease_AI.My.MySettings.Default.GlitterSN
Me.TBGlitterShortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'CBEgotist
'
Me.CBEgotist.AutoSize = true
Me.CBEgotist.Checked = Global.Tease_AI.My.MySettings.Default.CBEgotist
Me.CBEgotist.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBEgotist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBEgotist.ForeColor = System.Drawing.Color.Black
Me.CBEgotist.Location = New System.Drawing.Point(9, 121)
Me.CBEgotist.Name = "CBEgotist"
Me.CBEgotist.Size = New System.Drawing.Size(58, 17)
Me.CBEgotist.TabIndex = 153
Me.CBEgotist.Text = "Egotist"
Me.CBEgotist.UseVisualStyleBackColor = true
'
'CBTease
'
Me.CBTease.AutoSize = true
Me.CBTease.Checked = Global.Tease_AI.My.MySettings.Default.CBTease
Me.CBTease.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBTease", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBTease.ForeColor = System.Drawing.Color.Black
Me.CBTease.Location = New System.Drawing.Point(9, 98)
Me.CBTease.Name = "CBTease"
Me.CBTease.Size = New System.Drawing.Size(56, 17)
Me.CBTease.TabIndex = 152
Me.CBTease.Text = "Tease"
Me.CBTease.UseVisualStyleBackColor = true
'
'GlitterAV
'
Me.GlitterAV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GlitterAV.Location = New System.Drawing.Point(9, 22)
Me.GlitterAV.Name = "GlitterAV"
Me.GlitterAV.Size = New System.Drawing.Size(64, 64)
Me.GlitterAV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GlitterAV.TabIndex = 149
Me.GlitterAV.TabStop = false
'
'GBGlitter1
'
Me.GBGlitter1.BackColor = System.Drawing.Color.LightGray
Me.GBGlitter1.Controls.Add(Me.Label167)
Me.GBGlitter1.Controls.Add(Me.G1Honorific)
Me.GBGlitter1.Controls.Add(Me.BtnContact1ImageDirClear)
Me.GBGlitter1.Controls.Add(Me.BtnContact1ImageDir)
Me.GBGlitter1.Controls.Add(Me.TbxContact1ImageDir)
Me.GBGlitter1.Controls.Add(Me.BTNGlitter1)
Me.GBGlitter1.Controls.Add(Me.LBLGlitterNC1)
Me.GBGlitter1.Controls.Add(Me.LBLGlitterSlider1)
Me.GBGlitter1.Controls.Add(Me.GlitterSlider1)
Me.GBGlitter1.Controls.Add(Me.CBGlitter1)
Me.GBGlitter1.Controls.Add(Me.TBGlitter1)
Me.GBGlitter1.Controls.Add(Me.GlitterAV1)
Me.GBGlitter1.Location = New System.Drawing.Point(355, 1)
Me.GBGlitter1.Name = "GBGlitter1"
Me.GBGlitter1.Size = New System.Drawing.Size(344, 150)
Me.GBGlitter1.TabIndex = 161
Me.GBGlitter1.TabStop = false
Me.GBGlitter1.Text = "Contact 1"
'
'Label167
'
Me.Label167.BackColor = System.Drawing.Color.Transparent
Me.Label167.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label167.ForeColor = System.Drawing.Color.Black
Me.Label167.Location = New System.Drawing.Point(220, 15)
Me.Label167.Name = "Label167"
Me.Label167.Size = New System.Drawing.Size(114, 19)
Me.Label167.TabIndex = 182
Me.Label167.Text = "Contact Honorific"
Me.Label167.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'G1Honorific
'
Me.G1Honorific.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.G1Honorific.Location = New System.Drawing.Point(220, 34)
Me.G1Honorific.Name = "G1Honorific"
Me.G1Honorific.Size = New System.Drawing.Size(116, 23)
Me.G1Honorific.TabIndex = 0
Me.G1Honorific.Text = "Mistress"
Me.G1Honorific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BtnContact1ImageDirClear
'
Me.BtnContact1ImageDirClear.BackColor = System.Drawing.Color.LightGray
Me.BtnContact1ImageDirClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact1ImageDirClear.ForeColor = System.Drawing.Color.Black
Me.BtnContact1ImageDirClear.Location = New System.Drawing.Point(174, 93)
Me.BtnContact1ImageDirClear.Name = "BtnContact1ImageDirClear"
Me.BtnContact1ImageDirClear.Size = New System.Drawing.Size(39, 22)
Me.BtnContact1ImageDirClear.TabIndex = 181
Me.BtnContact1ImageDirClear.Text = "Clear"
Me.BtnContact1ImageDirClear.UseVisualStyleBackColor = false
'
'BtnContact1ImageDir
'
Me.BtnContact1ImageDir.BackColor = System.Drawing.Color.LightGray
Me.BtnContact1ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact1ImageDir.ForeColor = System.Drawing.Color.Black
Me.BtnContact1ImageDir.Location = New System.Drawing.Point(9, 93)
Me.BtnContact1ImageDir.Name = "BtnContact1ImageDir"
Me.BtnContact1ImageDir.Size = New System.Drawing.Size(160, 22)
Me.BtnContact1ImageDir.TabIndex = 177
Me.BtnContact1ImageDir.Text = "Set Contact1 Images Directory"
Me.BtnContact1ImageDir.UseVisualStyleBackColor = false
'
'TbxContact1ImageDir
'
Me.TbxContact1ImageDir.BackColor = System.Drawing.Color.LightGray
Me.TbxContact1ImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxContact1ImageDir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Contact1ImageDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxContact1ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxContact1ImageDir.ForeColor = System.Drawing.Color.Black
Me.TbxContact1ImageDir.Location = New System.Drawing.Point(9, 121)
Me.TbxContact1ImageDir.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxContact1ImageDir.MinimumSize = New System.Drawing.Size(204, 17)
Me.TbxContact1ImageDir.Name = "TbxContact1ImageDir"
Me.TbxContact1ImageDir.ReadOnly = true
Me.TbxContact1ImageDir.Size = New System.Drawing.Size(204, 17)
Me.TbxContact1ImageDir.TabIndex = 176
Me.TbxContact1ImageDir.Text = Global.Tease_AI.My.MySettings.Default.Contact1ImageDir
'
'BTNGlitter1
'
Me.BTNGlitter1.BackColor = System.Drawing.Color.LightGray
Me.BTNGlitter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNGlitter1.ForeColor = System.Drawing.Color.Black
Me.BTNGlitter1.Location = New System.Drawing.Point(78, 64)
Me.BTNGlitter1.Name = "BTNGlitter1"
Me.BTNGlitter1.Size = New System.Drawing.Size(136, 23)
Me.BTNGlitter1.TabIndex = 175
Me.BTNGlitter1.Text = "Choose Name Color"
Me.BTNGlitter1.UseVisualStyleBackColor = false
'
'LBLGlitterNC1
'
Me.LBLGlitterNC1.BackColor = System.Drawing.Color.White
Me.LBLGlitterNC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLGlitterNC1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "GlitterNC1Color", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLGlitterNC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterNC1.ForeColor = Global.Tease_AI.My.MySettings.Default.GlitterNC1Color
Me.LBLGlitterNC1.Location = New System.Drawing.Point(220, 64)
Me.LBLGlitterNC1.Name = "LBLGlitterNC1"
Me.LBLGlitterNC1.Size = New System.Drawing.Size(114, 23)
Me.LBLGlitterNC1.TabIndex = 166
Me.LBLGlitterNC1.Text = "Preview"
Me.LBLGlitterNC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLGlitterSlider1
'
Me.LBLGlitterSlider1.BackColor = System.Drawing.Color.Transparent
Me.LBLGlitterSlider1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterSlider1.ForeColor = System.Drawing.Color.Black
Me.LBLGlitterSlider1.Location = New System.Drawing.Point(220, 96)
Me.LBLGlitterSlider1.Name = "LBLGlitterSlider1"
Me.LBLGlitterSlider1.Size = New System.Drawing.Size(115, 19)
Me.LBLGlitterSlider1.TabIndex = 163
Me.LBLGlitterSlider1.Text = "Response Frequency"
Me.LBLGlitterSlider1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GlitterSlider1
'
Me.GlitterSlider1.AutoSize = false
Me.GlitterSlider1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "Glitter1Slider", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GlitterSlider1.LargeChange = 1
Me.GlitterSlider1.Location = New System.Drawing.Point(220, 118)
Me.GlitterSlider1.Maximum = 9
Me.GlitterSlider1.Minimum = 1
Me.GlitterSlider1.Name = "GlitterSlider1"
Me.GlitterSlider1.Size = New System.Drawing.Size(115, 25)
Me.GlitterSlider1.TabIndex = 161
Me.GlitterSlider1.Value = Global.Tease_AI.My.MySettings.Default.Glitter1Slider
'
'CBGlitter1
'
Me.CBGlitter1.AutoSize = true
Me.CBGlitter1.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitter1
Me.CBGlitter1.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBGlitter1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitter1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBGlitter1.ForeColor = System.Drawing.Color.Black
Me.CBGlitter1.Location = New System.Drawing.Point(79, 15)
Me.CBGlitter1.Name = "CBGlitter1"
Me.CBGlitter1.Size = New System.Drawing.Size(122, 17)
Me.CBGlitter1.TabIndex = 151
Me.CBGlitter1.Text = "Enable This Contact"
Me.CBGlitter1.UseVisualStyleBackColor = true
'
'TBGlitter1
'
Me.TBGlitter1.BackColor = System.Drawing.Color.White
Me.TBGlitter1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Glitter1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TBGlitter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBGlitter1.ForeColor = System.Drawing.Color.Black
Me.TBGlitter1.Location = New System.Drawing.Point(79, 34)
Me.TBGlitter1.Name = "TBGlitter1"
Me.TBGlitter1.Size = New System.Drawing.Size(134, 23)
Me.TBGlitter1.TabIndex = 49
Me.TBGlitter1.Text = Global.Tease_AI.My.MySettings.Default.Glitter1
Me.TBGlitter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GlitterAV1
'
Me.GlitterAV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GlitterAV1.Location = New System.Drawing.Point(9, 22)
Me.GlitterAV1.Name = "GlitterAV1"
Me.GlitterAV1.Size = New System.Drawing.Size(64, 64)
Me.GlitterAV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GlitterAV1.TabIndex = 149
Me.GlitterAV1.TabStop = false
'
'GBGlitter3
'
Me.GBGlitter3.BackColor = System.Drawing.Color.LightGray
Me.GBGlitter3.Controls.Add(Me.Label168)
Me.GBGlitter3.Controls.Add(Me.G3Honorific)
Me.GBGlitter3.Controls.Add(Me.BtnContact3ImageDirClear)
Me.GBGlitter3.Controls.Add(Me.BtnContact3ImageDir)
Me.GBGlitter3.Controls.Add(Me.TbxContact3ImageDir)
Me.GBGlitter3.Controls.Add(Me.BTNGlitter3)
Me.GBGlitter3.Controls.Add(Me.LBLGlitterNC3)
Me.GBGlitter3.Controls.Add(Me.LBLGlitterSlider3)
Me.GBGlitter3.Controls.Add(Me.GlitterSlider3)
Me.GBGlitter3.Controls.Add(Me.CBGlitter3)
Me.GBGlitter3.Controls.Add(Me.TBGlitter3)
Me.GBGlitter3.Controls.Add(Me.GlitterAV3)
Me.GBGlitter3.Location = New System.Drawing.Point(355, 151)
Me.GBGlitter3.Name = "GBGlitter3"
Me.GBGlitter3.Size = New System.Drawing.Size(344, 150)
Me.GBGlitter3.TabIndex = 160
Me.GBGlitter3.TabStop = false
Me.GBGlitter3.Text = "Contact 3"
'
'Label168
'
Me.Label168.BackColor = System.Drawing.Color.Transparent
Me.Label168.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label168.ForeColor = System.Drawing.Color.Black
Me.Label168.Location = New System.Drawing.Point(220, 15)
Me.Label168.Name = "Label168"
Me.Label168.Size = New System.Drawing.Size(114, 19)
Me.Label168.TabIndex = 181
Me.Label168.Text = "Contact Honorific"
Me.Label168.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'G3Honorific
'
Me.G3Honorific.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.G3Honorific.Location = New System.Drawing.Point(220, 34)
Me.G3Honorific.Name = "G3Honorific"
Me.G3Honorific.Size = New System.Drawing.Size(115, 23)
Me.G3Honorific.TabIndex = 0
Me.G3Honorific.Text = "Mistress"
Me.G3Honorific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BtnContact3ImageDirClear
'
Me.BtnContact3ImageDirClear.BackColor = System.Drawing.Color.LightGray
Me.BtnContact3ImageDirClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact3ImageDirClear.ForeColor = System.Drawing.Color.Black
Me.BtnContact3ImageDirClear.Location = New System.Drawing.Point(174, 93)
Me.BtnContact3ImageDirClear.Name = "BtnContact3ImageDirClear"
Me.BtnContact3ImageDirClear.Size = New System.Drawing.Size(39, 22)
Me.BtnContact3ImageDirClear.TabIndex = 180
Me.BtnContact3ImageDirClear.Text = "Clear"
Me.BtnContact3ImageDirClear.UseVisualStyleBackColor = false
'
'BtnContact3ImageDir
'
Me.BtnContact3ImageDir.BackColor = System.Drawing.Color.LightGray
Me.BtnContact3ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact3ImageDir.ForeColor = System.Drawing.Color.Black
Me.BtnContact3ImageDir.Location = New System.Drawing.Point(9, 93)
Me.BtnContact3ImageDir.Name = "BtnContact3ImageDir"
Me.BtnContact3ImageDir.Size = New System.Drawing.Size(160, 22)
Me.BtnContact3ImageDir.TabIndex = 179
Me.BtnContact3ImageDir.Text = "Set Contact3 Images Directory"
Me.BtnContact3ImageDir.UseVisualStyleBackColor = false
'
'TbxContact3ImageDir
'
Me.TbxContact3ImageDir.BackColor = System.Drawing.Color.LightGray
Me.TbxContact3ImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxContact3ImageDir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Contact3ImageDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxContact3ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxContact3ImageDir.ForeColor = System.Drawing.Color.Black
Me.TbxContact3ImageDir.Location = New System.Drawing.Point(9, 121)
Me.TbxContact3ImageDir.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxContact3ImageDir.MinimumSize = New System.Drawing.Size(204, 17)
Me.TbxContact3ImageDir.Name = "TbxContact3ImageDir"
Me.TbxContact3ImageDir.ReadOnly = true
Me.TbxContact3ImageDir.Size = New System.Drawing.Size(204, 17)
Me.TbxContact3ImageDir.TabIndex = 178
Me.TbxContact3ImageDir.Text = Global.Tease_AI.My.MySettings.Default.Contact3ImageDir
'
'BTNGlitter3
'
Me.BTNGlitter3.BackColor = System.Drawing.Color.LightGray
Me.BTNGlitter3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNGlitter3.ForeColor = System.Drawing.Color.Black
Me.BTNGlitter3.Location = New System.Drawing.Point(78, 64)
Me.BTNGlitter3.Name = "BTNGlitter3"
Me.BTNGlitter3.Size = New System.Drawing.Size(136, 23)
Me.BTNGlitter3.TabIndex = 175
Me.BTNGlitter3.Text = "Choose Name Color"
Me.BTNGlitter3.UseVisualStyleBackColor = false
'
'LBLGlitterNC3
'
Me.LBLGlitterNC3.BackColor = System.Drawing.Color.White
Me.LBLGlitterNC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLGlitterNC3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "GlitterNC3Color", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLGlitterNC3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterNC3.ForeColor = Global.Tease_AI.My.MySettings.Default.GlitterNC3Color
Me.LBLGlitterNC3.Location = New System.Drawing.Point(220, 64)
Me.LBLGlitterNC3.Name = "LBLGlitterNC3"
Me.LBLGlitterNC3.Size = New System.Drawing.Size(114, 23)
Me.LBLGlitterNC3.TabIndex = 166
Me.LBLGlitterNC3.Text = "Preview"
Me.LBLGlitterNC3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLGlitterSlider3
'
Me.LBLGlitterSlider3.BackColor = System.Drawing.Color.Transparent
Me.LBLGlitterSlider3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterSlider3.ForeColor = System.Drawing.Color.Black
Me.LBLGlitterSlider3.Location = New System.Drawing.Point(220, 96)
Me.LBLGlitterSlider3.Name = "LBLGlitterSlider3"
Me.LBLGlitterSlider3.Size = New System.Drawing.Size(115, 19)
Me.LBLGlitterSlider3.TabIndex = 163
Me.LBLGlitterSlider3.Text = "Response Frequency"
Me.LBLGlitterSlider3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GlitterSlider3
'
Me.GlitterSlider3.AutoSize = false
Me.GlitterSlider3.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "Glitter3Slider", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GlitterSlider3.LargeChange = 1
Me.GlitterSlider3.Location = New System.Drawing.Point(220, 118)
Me.GlitterSlider3.Maximum = 9
Me.GlitterSlider3.Minimum = 1
Me.GlitterSlider3.Name = "GlitterSlider3"
Me.GlitterSlider3.Size = New System.Drawing.Size(115, 25)
Me.GlitterSlider3.TabIndex = 161
Me.GlitterSlider3.Value = Global.Tease_AI.My.MySettings.Default.Glitter3Slider
'
'CBGlitter3
'
Me.CBGlitter3.AutoSize = true
Me.CBGlitter3.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitter3
Me.CBGlitter3.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBGlitter3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitter3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBGlitter3.ForeColor = System.Drawing.Color.Black
Me.CBGlitter3.Location = New System.Drawing.Point(79, 15)
Me.CBGlitter3.Name = "CBGlitter3"
Me.CBGlitter3.Size = New System.Drawing.Size(122, 17)
Me.CBGlitter3.TabIndex = 151
Me.CBGlitter3.Text = "Enable This Contact"
Me.CBGlitter3.UseVisualStyleBackColor = true
'
'TBGlitter3
'
Me.TBGlitter3.BackColor = System.Drawing.Color.White
Me.TBGlitter3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Glitter3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TBGlitter3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBGlitter3.ForeColor = System.Drawing.Color.Black
Me.TBGlitter3.Location = New System.Drawing.Point(79, 34)
Me.TBGlitter3.Name = "TBGlitter3"
Me.TBGlitter3.Size = New System.Drawing.Size(134, 23)
Me.TBGlitter3.TabIndex = 49
Me.TBGlitter3.Text = Global.Tease_AI.My.MySettings.Default.Glitter3
Me.TBGlitter3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GlitterAV3
'
Me.GlitterAV3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GlitterAV3.Location = New System.Drawing.Point(9, 22)
Me.GlitterAV3.Name = "GlitterAV3"
Me.GlitterAV3.Size = New System.Drawing.Size(64, 64)
Me.GlitterAV3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GlitterAV3.TabIndex = 149
Me.GlitterAV3.TabStop = false
'
'GBGlitter2
'
Me.GBGlitter2.BackColor = System.Drawing.Color.LightGray
Me.GBGlitter2.Controls.Add(Me.Label169)
Me.GBGlitter2.Controls.Add(Me.G2Honorific)
Me.GBGlitter2.Controls.Add(Me.BtnContact2ImageDirClear)
Me.GBGlitter2.Controls.Add(Me.BtnContact2ImageDir)
Me.GBGlitter2.Controls.Add(Me.TbxContact2ImageDir)
Me.GBGlitter2.Controls.Add(Me.BTNGlitter2)
Me.GBGlitter2.Controls.Add(Me.LBLGlitterNC2)
Me.GBGlitter2.Controls.Add(Me.LBLGlitterSlider2)
Me.GBGlitter2.Controls.Add(Me.GlitterSlider2)
Me.GBGlitter2.Controls.Add(Me.CBGlitter2)
Me.GBGlitter2.Controls.Add(Me.TBGlitter2)
Me.GBGlitter2.Controls.Add(Me.GlitterAV2)
Me.GBGlitter2.Location = New System.Drawing.Point(7, 151)
Me.GBGlitter2.Name = "GBGlitter2"
Me.GBGlitter2.Size = New System.Drawing.Size(344, 150)
Me.GBGlitter2.TabIndex = 151
Me.GBGlitter2.TabStop = false
Me.GBGlitter2.Text = "Contact 2"
'
'Label169
'
Me.Label169.BackColor = System.Drawing.Color.Transparent
Me.Label169.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label169.ForeColor = System.Drawing.Color.Black
Me.Label169.Location = New System.Drawing.Point(220, 15)
Me.Label169.Name = "Label169"
Me.Label169.Size = New System.Drawing.Size(114, 19)
Me.Label169.TabIndex = 182
Me.Label169.Text = "Contact Honorific"
Me.Label169.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'G2Honorific
'
Me.G2Honorific.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.G2Honorific.Location = New System.Drawing.Point(220, 34)
Me.G2Honorific.Name = "G2Honorific"
Me.G2Honorific.Size = New System.Drawing.Size(115, 23)
Me.G2Honorific.TabIndex = 0
Me.G2Honorific.Text = "Mistress"
Me.G2Honorific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BtnContact2ImageDirClear
'
Me.BtnContact2ImageDirClear.BackColor = System.Drawing.Color.LightGray
Me.BtnContact2ImageDirClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact2ImageDirClear.ForeColor = System.Drawing.Color.Black
Me.BtnContact2ImageDirClear.Location = New System.Drawing.Point(174, 93)
Me.BtnContact2ImageDirClear.Name = "BtnContact2ImageDirClear"
Me.BtnContact2ImageDirClear.Size = New System.Drawing.Size(39, 22)
Me.BtnContact2ImageDirClear.TabIndex = 181
Me.BtnContact2ImageDirClear.Text = "Clear"
Me.BtnContact2ImageDirClear.UseVisualStyleBackColor = false
'
'BtnContact2ImageDir
'
Me.BtnContact2ImageDir.BackColor = System.Drawing.Color.LightGray
Me.BtnContact2ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnContact2ImageDir.ForeColor = System.Drawing.Color.Black
Me.BtnContact2ImageDir.Location = New System.Drawing.Point(9, 93)
Me.BtnContact2ImageDir.Name = "BtnContact2ImageDir"
Me.BtnContact2ImageDir.Size = New System.Drawing.Size(160, 22)
Me.BtnContact2ImageDir.TabIndex = 179
Me.BtnContact2ImageDir.Text = "Set Contact2 Images Directory"
Me.BtnContact2ImageDir.UseVisualStyleBackColor = false
'
'TbxContact2ImageDir
'
Me.TbxContact2ImageDir.BackColor = System.Drawing.Color.LightGray
Me.TbxContact2ImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TbxContact2ImageDir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Contact2ImageDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TbxContact2ImageDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TbxContact2ImageDir.ForeColor = System.Drawing.Color.Black
Me.TbxContact2ImageDir.Location = New System.Drawing.Point(9, 121)
Me.TbxContact2ImageDir.MaximumSize = New System.Drawing.Size(2, 17)
Me.TbxContact2ImageDir.MinimumSize = New System.Drawing.Size(204, 17)
Me.TbxContact2ImageDir.Name = "TbxContact2ImageDir"
Me.TbxContact2ImageDir.ReadOnly = true
Me.TbxContact2ImageDir.Size = New System.Drawing.Size(204, 17)
Me.TbxContact2ImageDir.TabIndex = 178
Me.TbxContact2ImageDir.Text = Global.Tease_AI.My.MySettings.Default.Contact2ImageDir
'
'BTNGlitter2
'
Me.BTNGlitter2.BackColor = System.Drawing.Color.LightGray
Me.BTNGlitter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNGlitter2.ForeColor = System.Drawing.Color.Black
Me.BTNGlitter2.Location = New System.Drawing.Point(78, 64)
Me.BTNGlitter2.Name = "BTNGlitter2"
Me.BTNGlitter2.Size = New System.Drawing.Size(136, 23)
Me.BTNGlitter2.TabIndex = 167
Me.BTNGlitter2.Text = "Choose Name Color"
Me.BTNGlitter2.UseVisualStyleBackColor = false
'
'LBLGlitterNC2
'
Me.LBLGlitterNC2.BackColor = System.Drawing.Color.White
Me.LBLGlitterNC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLGlitterNC2.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tease_AI.My.MySettings.Default, "GlitterNC2Color", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLGlitterNC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterNC2.ForeColor = Global.Tease_AI.My.MySettings.Default.GlitterNC2Color
Me.LBLGlitterNC2.Location = New System.Drawing.Point(220, 64)
Me.LBLGlitterNC2.Name = "LBLGlitterNC2"
Me.LBLGlitterNC2.Size = New System.Drawing.Size(114, 23)
Me.LBLGlitterNC2.TabIndex = 166
Me.LBLGlitterNC2.Text = "Preview"
Me.LBLGlitterNC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLGlitterSlider2
'
Me.LBLGlitterSlider2.BackColor = System.Drawing.Color.Transparent
Me.LBLGlitterSlider2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitterSlider2.ForeColor = System.Drawing.Color.Black
Me.LBLGlitterSlider2.Location = New System.Drawing.Point(220, 96)
Me.LBLGlitterSlider2.Name = "LBLGlitterSlider2"
Me.LBLGlitterSlider2.Size = New System.Drawing.Size(115, 19)
Me.LBLGlitterSlider2.TabIndex = 163
Me.LBLGlitterSlider2.Text = "Response Frequency"
Me.LBLGlitterSlider2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GlitterSlider2
'
Me.GlitterSlider2.AutoSize = false
Me.GlitterSlider2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "Glitter2Slider", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GlitterSlider2.LargeChange = 1
Me.GlitterSlider2.Location = New System.Drawing.Point(220, 118)
Me.GlitterSlider2.Maximum = 9
Me.GlitterSlider2.Minimum = 1
Me.GlitterSlider2.Name = "GlitterSlider2"
Me.GlitterSlider2.Size = New System.Drawing.Size(115, 25)
Me.GlitterSlider2.TabIndex = 161
Me.GlitterSlider2.Value = Global.Tease_AI.My.MySettings.Default.Glitter2Slider
'
'CBGlitter2
'
Me.CBGlitter2.AutoSize = true
Me.CBGlitter2.Checked = Global.Tease_AI.My.MySettings.Default.CBGlitter2
Me.CBGlitter2.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBGlitter2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBGlitter2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBGlitter2.ForeColor = System.Drawing.Color.Black
Me.CBGlitter2.Location = New System.Drawing.Point(79, 15)
Me.CBGlitter2.Name = "CBGlitter2"
Me.CBGlitter2.Size = New System.Drawing.Size(122, 17)
Me.CBGlitter2.TabIndex = 151
Me.CBGlitter2.Text = "Enable This Contact"
Me.CBGlitter2.UseVisualStyleBackColor = true
'
'TBGlitter2
'
Me.TBGlitter2.BackColor = System.Drawing.Color.White
Me.TBGlitter2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "Glitter2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TBGlitter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.TBGlitter2.ForeColor = System.Drawing.Color.Black
Me.TBGlitter2.Location = New System.Drawing.Point(79, 34)
Me.TBGlitter2.Name = "TBGlitter2"
Me.TBGlitter2.Size = New System.Drawing.Size(134, 23)
Me.TBGlitter2.TabIndex = 49
Me.TBGlitter2.Text = Global.Tease_AI.My.MySettings.Default.Glitter2
Me.TBGlitter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GlitterAV2
'
Me.GlitterAV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GlitterAV2.Location = New System.Drawing.Point(9, 22)
Me.GlitterAV2.Name = "GlitterAV2"
Me.GlitterAV2.Size = New System.Drawing.Size(64, 64)
Me.GlitterAV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GlitterAV2.TabIndex = 149
Me.GlitterAV2.TabStop = false
'
'TpGames
'
Me.TpGames.BackColor = System.Drawing.Color.LightGray
Me.TpGames.Controls.Add(Me.CBIncludeGifs)
Me.TpGames.Controls.Add(Me.LblCardsSetupNote)
Me.TpGames.Controls.Add(Me.CBGameSounds)
Me.TpGames.Controls.Add(Me.GbxCardsGold)
Me.TpGames.Controls.Add(Me.GbxCardsBackground)
Me.TpGames.Controls.Add(Me.GbxCardsBronze)
Me.TpGames.Controls.Add(Me.GbxCardsSilver)
Me.TpGames.Location = New System.Drawing.Point(4, 22)
Me.TpGames.Name = "TpGames"
Me.TpGames.Padding = New System.Windows.Forms.Padding(3)
Me.TpGames.Size = New System.Drawing.Size(700, 411)
Me.TpGames.TabIndex = 1
Me.TpGames.Text = "Games"
'
'CBIncludeGifs
'
Me.CBIncludeGifs.AutoSize = true
Me.CBIncludeGifs.Checked = Global.Tease_AI.My.MySettings.Default.CBIncludeGifs
Me.CBIncludeGifs.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBIncludeGifs.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBIncludeGifs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBIncludeGifs.Location = New System.Drawing.Point(528, 351)
Me.CBIncludeGifs.Name = "CBIncludeGifs"
Me.CBIncludeGifs.Size = New System.Drawing.Size(154, 17)
Me.CBIncludeGifs.TabIndex = 5
Me.CBIncludeGifs.Text = "Match Game Includes Gifs "
Me.CBIncludeGifs.UseVisualStyleBackColor = true
'
'LblCardsSetupNote
'
Me.LblCardsSetupNote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblCardsSetupNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LblCardsSetupNote.Location = New System.Drawing.Point(523, 249)
Me.LblCardsSetupNote.Name = "LblCardsSetupNote"
Me.LblCardsSetupNote.Size = New System.Drawing.Size(171, 93)
Me.LblCardsSetupNote.TabIndex = 4
Me.LblCardsSetupNote.Text = "Each of the pictures in this tab MUST be set before the Games app can be selected"& _ 
    "!"
Me.LblCardsSetupNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'CBGameSounds
'
Me.CBGameSounds.AutoSize = true
Me.CBGameSounds.Checked = true
Me.CBGameSounds.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBGameSounds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBGameSounds.ForeColor = System.Drawing.Color.Black
Me.CBGameSounds.Location = New System.Drawing.Point(528, 379)
Me.CBGameSounds.Name = "CBGameSounds"
Me.CBGameSounds.Size = New System.Drawing.Size(116, 17)
Me.CBGameSounds.TabIndex = 6
Me.CBGameSounds.Text = "Play Game Sounds"
Me.CBGameSounds.UseVisualStyleBackColor = true
'
'GbxCardsGold
'
Me.GbxCardsGold.Controls.Add(Me.GN6)
Me.GbxCardsGold.Controls.Add(Me.GP6)
Me.GbxCardsGold.Controls.Add(Me.GN2)
Me.GbxCardsGold.Controls.Add(Me.GP2)
Me.GbxCardsGold.Controls.Add(Me.GP5)
Me.GbxCardsGold.Controls.Add(Me.GN1)
Me.GbxCardsGold.Controls.Add(Me.GP1)
Me.GbxCardsGold.Controls.Add(Me.GN5)
Me.GbxCardsGold.Controls.Add(Me.GN3)
Me.GbxCardsGold.Controls.Add(Me.GP3)
Me.GbxCardsGold.Controls.Add(Me.GP4)
Me.GbxCardsGold.Controls.Add(Me.GN4)
Me.GbxCardsGold.Location = New System.Drawing.Point(350, 7)
Me.GbxCardsGold.Name = "GbxCardsGold"
Me.GbxCardsGold.Size = New System.Drawing.Size(166, 398)
Me.GbxCardsGold.TabIndex = 2
Me.GbxCardsGold.TabStop = false
Me.GbxCardsGold.Text = "Gold Cards"
'
'GN6
'
Me.GN6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN6.Location = New System.Drawing.Point(86, 367)
Me.GN6.Name = "GN6"
Me.GN6.Size = New System.Drawing.Size(71, 20)
Me.GN6.TabIndex = 5
Me.GN6.Text = Global.Tease_AI.My.MySettings.Default.GN6
Me.GN6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GP6
'
Me.GP6.BackColor = System.Drawing.Color.Silver
Me.GP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP6.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP6.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP6
Me.GP6.InitialImage = Nothing
Me.GP6.Location = New System.Drawing.Point(86, 268)
Me.GP6.Name = "GP6"
Me.GP6.Size = New System.Drawing.Size(71, 93)
Me.GP6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP6.TabIndex = 17
Me.GP6.TabStop = false
'
'GN2
'
Me.GN2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN2.Location = New System.Drawing.Point(86, 117)
Me.GN2.Name = "GN2"
Me.GN2.Size = New System.Drawing.Size(71, 20)
Me.GN2.TabIndex = 1
Me.GN2.Text = Global.Tease_AI.My.MySettings.Default.GN2
Me.GN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GP2
'
Me.GP2.BackColor = System.Drawing.Color.Silver
Me.GP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP2.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP2.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP2
Me.GP2.InitialImage = Nothing
Me.GP2.Location = New System.Drawing.Point(86, 17)
Me.GP2.Name = "GP2"
Me.GP2.Size = New System.Drawing.Size(71, 94)
Me.GP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP2.TabIndex = 9
Me.GP2.TabStop = false
'
'GP5
'
Me.GP5.BackColor = System.Drawing.Color.Silver
Me.GP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP5.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP5.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP5
Me.GP5.InitialImage = Nothing
Me.GP5.Location = New System.Drawing.Point(9, 268)
Me.GP5.Name = "GP5"
Me.GP5.Size = New System.Drawing.Size(71, 93)
Me.GP5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP5.TabIndex = 15
Me.GP5.TabStop = false
'
'GN1
'
Me.GN1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN1.Location = New System.Drawing.Point(9, 117)
Me.GN1.Name = "GN1"
Me.GN1.Size = New System.Drawing.Size(71, 20)
Me.GN1.TabIndex = 0
Me.GN1.Text = Global.Tease_AI.My.MySettings.Default.GN1
Me.GN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GP1
'
Me.GP1.BackColor = System.Drawing.Color.Silver
Me.GP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP1.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP1.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP1
Me.GP1.InitialImage = Nothing
Me.GP1.Location = New System.Drawing.Point(9, 17)
Me.GP1.Name = "GP1"
Me.GP1.Size = New System.Drawing.Size(71, 94)
Me.GP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP1.TabIndex = 0
Me.GP1.TabStop = false
'
'GN5
'
Me.GN5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN5.Location = New System.Drawing.Point(9, 367)
Me.GN5.Name = "GN5"
Me.GN5.Size = New System.Drawing.Size(71, 20)
Me.GN5.TabIndex = 4
Me.GN5.Text = Global.Tease_AI.My.MySettings.Default.GN5
Me.GN5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GN3
'
Me.GN3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN3.Location = New System.Drawing.Point(9, 242)
Me.GN3.Name = "GN3"
Me.GN3.Size = New System.Drawing.Size(71, 20)
Me.GN3.TabIndex = 2
Me.GN3.Text = Global.Tease_AI.My.MySettings.Default.GN3
Me.GN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GP3
'
Me.GP3.BackColor = System.Drawing.Color.Silver
Me.GP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP3.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP3.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP3
Me.GP3.InitialImage = Nothing
Me.GP3.Location = New System.Drawing.Point(9, 143)
Me.GP3.Name = "GP3"
Me.GP3.Size = New System.Drawing.Size(71, 93)
Me.GP3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP3.TabIndex = 11
Me.GP3.TabStop = false
'
'GP4
'
Me.GP4.BackColor = System.Drawing.Color.Silver
Me.GP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.GP4.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "GP4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GP4.ImageLocation = Global.Tease_AI.My.MySettings.Default.GP4
Me.GP4.InitialImage = Nothing
Me.GP4.Location = New System.Drawing.Point(86, 143)
Me.GP4.Name = "GP4"
Me.GP4.Size = New System.Drawing.Size(71, 93)
Me.GP4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.GP4.TabIndex = 13
Me.GP4.TabStop = false
'
'GN4
'
Me.GN4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "GN4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.GN4.Location = New System.Drawing.Point(86, 242)
Me.GN4.Name = "GN4"
Me.GN4.Size = New System.Drawing.Size(71, 20)
Me.GN4.TabIndex = 3
Me.GN4.Text = Global.Tease_AI.My.MySettings.Default.GN4
Me.GN4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'GbxCardsBackground
'
Me.GbxCardsBackground.Controls.Add(Me.CardBack)
Me.GbxCardsBackground.Location = New System.Drawing.Point(522, 7)
Me.GbxCardsBackground.Name = "GbxCardsBackground"
Me.GbxCardsBackground.Size = New System.Drawing.Size(172, 236)
Me.GbxCardsBackground.TabIndex = 3
Me.GbxCardsBackground.TabStop = false
Me.GbxCardsBackground.Text = "Card Background"
'
'CardBack
'
Me.CardBack.BackColor = System.Drawing.Color.Silver
Me.CardBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.CardBack.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "CardBack", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CardBack.ImageLocation = Global.Tease_AI.My.MySettings.Default.CardBack
Me.CardBack.InitialImage = Nothing
Me.CardBack.Location = New System.Drawing.Point(17, 28)
Me.CardBack.Name = "CardBack"
Me.CardBack.Size = New System.Drawing.Size(138, 179)
Me.CardBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.CardBack.TabIndex = 18
Me.CardBack.TabStop = false
'
'GbxCardsBronze
'
Me.GbxCardsBronze.Controls.Add(Me.BN6)
Me.GbxCardsBronze.Controls.Add(Me.BN3)
Me.GbxCardsBronze.Controls.Add(Me.BP3)
Me.GbxCardsBronze.Controls.Add(Me.BP6)
Me.GbxCardsBronze.Controls.Add(Me.BN2)
Me.GbxCardsBronze.Controls.Add(Me.BN5)
Me.GbxCardsBronze.Controls.Add(Me.BP5)
Me.GbxCardsBronze.Controls.Add(Me.BP2)
Me.GbxCardsBronze.Controls.Add(Me.BN1)
Me.GbxCardsBronze.Controls.Add(Me.BN4)
Me.GbxCardsBronze.Controls.Add(Me.BP4)
Me.GbxCardsBronze.Controls.Add(Me.BP1)
Me.GbxCardsBronze.Location = New System.Drawing.Point(6, 6)
Me.GbxCardsBronze.Name = "GbxCardsBronze"
Me.GbxCardsBronze.Size = New System.Drawing.Size(166, 399)
Me.GbxCardsBronze.TabIndex = 0
Me.GbxCardsBronze.TabStop = false
Me.GbxCardsBronze.Text = "Bronze Cards"
'
'BN6
'
Me.BN6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN6.Location = New System.Drawing.Point(86, 368)
Me.BN6.Name = "BN6"
Me.BN6.Size = New System.Drawing.Size(71, 20)
Me.BN6.TabIndex = 5
Me.BN6.Text = Global.Tease_AI.My.MySettings.Default.BN6
Me.BN6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BN3
'
Me.BN3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN3.Location = New System.Drawing.Point(9, 243)
Me.BN3.Name = "BN3"
Me.BN3.Size = New System.Drawing.Size(71, 20)
Me.BN3.TabIndex = 2
Me.BN3.Text = Global.Tease_AI.My.MySettings.Default.BN3
Me.BN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BP3
'
Me.BP3.BackColor = System.Drawing.Color.Silver
Me.BP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP3.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP3.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP3
Me.BP3.InitialImage = Nothing
Me.BP3.Location = New System.Drawing.Point(9, 144)
Me.BP3.Name = "BP3"
Me.BP3.Size = New System.Drawing.Size(71, 93)
Me.BP3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP3.TabIndex = 11
Me.BP3.TabStop = false
'
'BP6
'
Me.BP6.BackColor = System.Drawing.Color.Silver
Me.BP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP6.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP6.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP6
Me.BP6.InitialImage = Nothing
Me.BP6.Location = New System.Drawing.Point(86, 269)
Me.BP6.Name = "BP6"
Me.BP6.Size = New System.Drawing.Size(71, 93)
Me.BP6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP6.TabIndex = 17
Me.BP6.TabStop = false
'
'BN2
'
Me.BN2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN2.Location = New System.Drawing.Point(86, 118)
Me.BN2.Name = "BN2"
Me.BN2.Size = New System.Drawing.Size(71, 20)
Me.BN2.TabIndex = 1
Me.BN2.Text = Global.Tease_AI.My.MySettings.Default.BN2
Me.BN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BN5
'
Me.BN5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN5.Location = New System.Drawing.Point(9, 368)
Me.BN5.Name = "BN5"
Me.BN5.Size = New System.Drawing.Size(71, 20)
Me.BN5.TabIndex = 4
Me.BN5.Text = Global.Tease_AI.My.MySettings.Default.BN5
Me.BN5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BP5
'
Me.BP5.BackColor = System.Drawing.Color.Silver
Me.BP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP5.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP5.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP5
Me.BP5.InitialImage = Nothing
Me.BP5.Location = New System.Drawing.Point(9, 269)
Me.BP5.Name = "BP5"
Me.BP5.Size = New System.Drawing.Size(71, 93)
Me.BP5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP5.TabIndex = 15
Me.BP5.TabStop = false
'
'BP2
'
Me.BP2.BackColor = System.Drawing.Color.Silver
Me.BP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP2.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP2.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP2
Me.BP2.InitialImage = Nothing
Me.BP2.Location = New System.Drawing.Point(86, 19)
Me.BP2.Name = "BP2"
Me.BP2.Size = New System.Drawing.Size(71, 93)
Me.BP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP2.TabIndex = 9
Me.BP2.TabStop = false
'
'BN1
'
Me.BN1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN1.Location = New System.Drawing.Point(9, 118)
Me.BN1.Name = "BN1"
Me.BN1.Size = New System.Drawing.Size(71, 20)
Me.BN1.TabIndex = 0
Me.BN1.Text = Global.Tease_AI.My.MySettings.Default.BN1
Me.BN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BN4
'
Me.BN4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "BN4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BN4.Location = New System.Drawing.Point(86, 243)
Me.BN4.Name = "BN4"
Me.BN4.Size = New System.Drawing.Size(71, 20)
Me.BN4.TabIndex = 3
Me.BN4.Text = Global.Tease_AI.My.MySettings.Default.BN4
Me.BN4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'BP4
'
Me.BP4.BackColor = System.Drawing.Color.Silver
Me.BP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP4.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP4.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP4
Me.BP4.InitialImage = Nothing
Me.BP4.Location = New System.Drawing.Point(86, 144)
Me.BP4.Name = "BP4"
Me.BP4.Size = New System.Drawing.Size(71, 93)
Me.BP4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP4.TabIndex = 13
Me.BP4.TabStop = false
'
'BP1
'
Me.BP1.BackColor = System.Drawing.Color.Silver
Me.BP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.BP1.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "BP1", true))
Me.BP1.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Global.Tease_AI.My.MySettings.Default, "BP1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.BP1.ImageLocation = Global.Tease_AI.My.MySettings.Default.BP1
Me.BP1.InitialImage = Nothing
Me.BP1.Location = New System.Drawing.Point(9, 19)
Me.BP1.Name = "BP1"
Me.BP1.Size = New System.Drawing.Size(71, 93)
Me.BP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.BP1.TabIndex = 0
Me.BP1.TabStop = false
Me.BP1.Tag = Global.Tease_AI.My.MySettings.Default.BP1
'
'GbxCardsSilver
'
Me.GbxCardsSilver.Controls.Add(Me.SN6)
Me.GbxCardsSilver.Controls.Add(Me.SP6)
Me.GbxCardsSilver.Controls.Add(Me.SN2)
Me.GbxCardsSilver.Controls.Add(Me.SP2)
Me.GbxCardsSilver.Controls.Add(Me.SN1)
Me.GbxCardsSilver.Controls.Add(Me.SP5)
Me.GbxCardsSilver.Controls.Add(Me.SP1)
Me.GbxCardsSilver.Controls.Add(Me.SN5)
Me.GbxCardsSilver.Controls.Add(Me.SN3)
Me.GbxCardsSilver.Controls.Add(Me.SN4)
Me.GbxCardsSilver.Controls.Add(Me.SP3)
Me.GbxCardsSilver.Controls.Add(Me.SP4)
Me.GbxCardsSilver.Location = New System.Drawing.Point(178, 6)
Me.GbxCardsSilver.Name = "GbxCardsSilver"
Me.GbxCardsSilver.Size = New System.Drawing.Size(166, 399)
Me.GbxCardsSilver.TabIndex = 1
Me.GbxCardsSilver.TabStop = false
Me.GbxCardsSilver.Text = "Silver Cards"
'
'SN6
'
Me.SN6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN6.Location = New System.Drawing.Point(86, 368)
Me.SN6.Name = "SN6"
Me.SN6.Size = New System.Drawing.Size(71, 20)
Me.SN6.TabIndex = 5
Me.SN6.Text = Global.Tease_AI.My.MySettings.Default.SN6
Me.SN6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SP6
'
Me.SP6.BackColor = System.Drawing.Color.Silver
Me.SP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP6.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP6.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP6
Me.SP6.InitialImage = Nothing
Me.SP6.Location = New System.Drawing.Point(86, 269)
Me.SP6.Name = "SP6"
Me.SP6.Size = New System.Drawing.Size(71, 93)
Me.SP6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP6.TabIndex = 17
Me.SP6.TabStop = false
'
'SN2
'
Me.SN2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN2.Location = New System.Drawing.Point(86, 118)
Me.SN2.Name = "SN2"
Me.SN2.Size = New System.Drawing.Size(71, 20)
Me.SN2.TabIndex = 1
Me.SN2.Text = Global.Tease_AI.My.MySettings.Default.SN2
Me.SN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SP2
'
Me.SP2.BackColor = System.Drawing.Color.Silver
Me.SP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP2.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP2.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP2
Me.SP2.InitialImage = Nothing
Me.SP2.Location = New System.Drawing.Point(86, 19)
Me.SP2.Name = "SP2"
Me.SP2.Size = New System.Drawing.Size(71, 93)
Me.SP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP2.TabIndex = 9
Me.SP2.TabStop = false
'
'SN1
'
Me.SN1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN1.Location = New System.Drawing.Point(9, 118)
Me.SN1.Name = "SN1"
Me.SN1.Size = New System.Drawing.Size(71, 20)
Me.SN1.TabIndex = 0
Me.SN1.Text = Global.Tease_AI.My.MySettings.Default.SN1
Me.SN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SP5
'
Me.SP5.BackColor = System.Drawing.Color.Silver
Me.SP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP5.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP5.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP5
Me.SP5.InitialImage = Nothing
Me.SP5.Location = New System.Drawing.Point(9, 269)
Me.SP5.Name = "SP5"
Me.SP5.Size = New System.Drawing.Size(71, 93)
Me.SP5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP5.TabIndex = 15
Me.SP5.TabStop = false
'
'SP1
'
Me.SP1.BackColor = System.Drawing.Color.Silver
Me.SP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP1.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP1.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP1
Me.SP1.InitialImage = Nothing
Me.SP1.Location = New System.Drawing.Point(9, 19)
Me.SP1.Name = "SP1"
Me.SP1.Size = New System.Drawing.Size(71, 93)
Me.SP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP1.TabIndex = 0
Me.SP1.TabStop = false
'
'SN5
'
Me.SN5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN5.Location = New System.Drawing.Point(9, 368)
Me.SN5.Name = "SN5"
Me.SN5.Size = New System.Drawing.Size(71, 20)
Me.SN5.TabIndex = 4
Me.SN5.Text = Global.Tease_AI.My.MySettings.Default.SN5
Me.SN5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SN3
'
Me.SN3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN3.Location = New System.Drawing.Point(9, 243)
Me.SN3.Name = "SN3"
Me.SN3.Size = New System.Drawing.Size(71, 20)
Me.SN3.TabIndex = 2
Me.SN3.Text = Global.Tease_AI.My.MySettings.Default.SN3
Me.SN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SN4
'
Me.SN4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tease_AI.My.MySettings.Default, "SN4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SN4.Location = New System.Drawing.Point(86, 243)
Me.SN4.Name = "SN4"
Me.SN4.Size = New System.Drawing.Size(71, 20)
Me.SN4.TabIndex = 3
Me.SN4.Text = Global.Tease_AI.My.MySettings.Default.SN4
Me.SN4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'SP3
'
Me.SP3.BackColor = System.Drawing.Color.Silver
Me.SP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP3.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP3.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP3
Me.SP3.InitialImage = Nothing
Me.SP3.Location = New System.Drawing.Point(9, 144)
Me.SP3.Name = "SP3"
Me.SP3.Size = New System.Drawing.Size(71, 93)
Me.SP3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP3.TabIndex = 11
Me.SP3.TabStop = false
'
'SP4
'
Me.SP4.BackColor = System.Drawing.Color.Silver
Me.SP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.SP4.DataBindings.Add(New System.Windows.Forms.Binding("ImageLocation", Global.Tease_AI.My.MySettings.Default, "SP4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.SP4.ImageLocation = Global.Tease_AI.My.MySettings.Default.SP4
Me.SP4.InitialImage = Nothing
Me.SP4.Location = New System.Drawing.Point(86, 144)
Me.SP4.Name = "SP4"
Me.SP4.Size = New System.Drawing.Size(71, 93)
Me.SP4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.SP4.TabIndex = 13
Me.SP4.TabStop = false
'
'TabPage6
'
Me.TabPage6.BackColor = System.Drawing.Color.LightGray
Me.TabPage6.Controls.Add(Me.Panel10)
Me.TabPage6.Controls.Add(Me.Label107)
Me.TabPage6.Controls.Add(Me.BTNWishlistCreate)
Me.TabPage6.Controls.Add(Me.Label18)
Me.TabPage6.Controls.Add(Me.PNLWishList)
Me.TabPage6.Location = New System.Drawing.Point(4, 22)
Me.TabPage6.Name = "TabPage6"
Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage6.Size = New System.Drawing.Size(700, 411)
Me.TabPage6.TabIndex = 2
Me.TabPage6.Text = "Wishlist"
'
'Panel10
'
Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel10.Controls.Add(Me.TBWishlistComment)
Me.Panel10.Controls.Add(Me.Label32)
Me.Panel10.Controls.Add(Me.TBWishlistItem)
Me.Panel10.Controls.Add(Me.radioGold)
Me.Panel10.Controls.Add(Me.Label42)
Me.Panel10.Controls.Add(Me.radioSilver)
Me.Panel10.Controls.Add(Me.TBWishlistURL)
Me.Panel10.Controls.Add(Me.NBWishlistCost)
Me.Panel10.Controls.Add(Me.Label48)
Me.Panel10.Controls.Add(Me.Label73)
Me.Panel10.Location = New System.Drawing.Point(38, 47)
Me.Panel10.Name = "Panel10"
Me.Panel10.Size = New System.Drawing.Size(252, 308)
Me.Panel10.TabIndex = 179
'
'TBWishlistComment
'
Me.TBWishlistComment.Location = New System.Drawing.Point(16, 173)
Me.TBWishlistComment.Multiline = true
Me.TBWishlistComment.Name = "TBWishlistComment"
Me.TBWishlistComment.Size = New System.Drawing.Size(217, 118)
Me.TBWishlistComment.TabIndex = 172
'
'Label32
'
Me.Label32.AutoSize = true
Me.Label32.Location = New System.Drawing.Point(13, 4)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(58, 13)
Me.Label32.TabIndex = 167
Me.Label32.Text = "Item Name"
'
'TBWishlistItem
'
Me.TBWishlistItem.Location = New System.Drawing.Point(16, 20)
Me.TBWishlistItem.Name = "TBWishlistItem"
Me.TBWishlistItem.Size = New System.Drawing.Size(217, 20)
Me.TBWishlistItem.TabIndex = 168
'
'radioGold
'
Me.radioGold.AutoSize = true
Me.radioGold.Location = New System.Drawing.Point(167, 125)
Me.radioGold.Name = "radioGold"
Me.radioGold.Size = New System.Drawing.Size(47, 17)
Me.radioGold.TabIndex = 176
Me.radioGold.Text = "Gold"
Me.radioGold.UseVisualStyleBackColor = true
'
'Label42
'
Me.Label42.AutoSize = true
Me.Label42.Location = New System.Drawing.Point(13, 56)
Me.Label42.Name = "Label42"
Me.Label42.Size = New System.Drawing.Size(75, 13)
Me.Label42.TabIndex = 169
Me.Label42.Text = "Item Image Url"
'
'radioSilver
'
Me.radioSilver.AutoSize = true
Me.radioSilver.Checked = true
Me.radioSilver.Location = New System.Drawing.Point(100, 125)
Me.radioSilver.Name = "radioSilver"
Me.radioSilver.Size = New System.Drawing.Size(51, 17)
Me.radioSilver.TabIndex = 175
Me.radioSilver.TabStop = true
Me.radioSilver.Text = "Silver"
Me.radioSilver.UseVisualStyleBackColor = true
'
'TBWishlistURL
'
Me.TBWishlistURL.Location = New System.Drawing.Point(16, 72)
Me.TBWishlistURL.Name = "TBWishlistURL"
Me.TBWishlistURL.Size = New System.Drawing.Size(217, 20)
Me.TBWishlistURL.TabIndex = 170
'
'NBWishlistCost
'
Me.NBWishlistCost.Location = New System.Drawing.Point(16, 125)
Me.NBWishlistCost.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
Me.NBWishlistCost.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBWishlistCost.Name = "NBWishlistCost"
Me.NBWishlistCost.Size = New System.Drawing.Size(40, 20)
Me.NBWishlistCost.TabIndex = 174
Me.NBWishlistCost.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'Label48
'
Me.Label48.AutoSize = true
Me.Label48.Location = New System.Drawing.Point(13, 157)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(74, 13)
Me.Label48.TabIndex = 171
Me.Label48.Text = "Item Comment"
'
'Label73
'
Me.Label73.AutoSize = true
Me.Label73.Location = New System.Drawing.Point(13, 108)
Me.Label73.Name = "Label73"
Me.Label73.Size = New System.Drawing.Size(51, 13)
Me.Label73.TabIndex = 173
Me.Label73.Text = "Item Cost"
'
'Label107
'
Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label107.Location = New System.Drawing.Point(38, 5)
Me.Label107.Name = "Label107"
Me.Label107.Size = New System.Drawing.Size(252, 47)
Me.Label107.TabIndex = 178
Me.Label107.Text = "Use this page to create Wishlist files."
Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNWishlistCreate
'
Me.BTNWishlistCreate.Location = New System.Drawing.Point(38, 365)
Me.BTNWishlistCreate.Name = "BTNWishlistCreate"
Me.BTNWishlistCreate.Size = New System.Drawing.Size(252, 33)
Me.BTNWishlistCreate.TabIndex = 177
Me.BTNWishlistCreate.Text = "Create Wishlist File"
Me.BTNWishlistCreate.UseVisualStyleBackColor = true
'
'Label18
'
Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label18.Location = New System.Drawing.Point(409, 5)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(250, 23)
Me.Label18.TabIndex = 166
Me.Label18.Text = "Preview"
Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'PNLWishList
'
Me.PNLWishList.BackColor = System.Drawing.Color.White
Me.PNLWishList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.PNLWishList.Controls.Add(Me.WishlistCostSilver)
Me.PNLWishList.Controls.Add(Me.LBLWishListText)
Me.PNLWishList.Controls.Add(Me.LBLWishlistCost)
Me.PNLWishList.Controls.Add(Me.WishlistCostGold)
Me.PNLWishList.Controls.Add(Me.LBLWishListName)
Me.PNLWishList.Controls.Add(Me.WishlistPreview)
Me.PNLWishList.Location = New System.Drawing.Point(407, 31)
Me.PNLWishList.Name = "PNLWishList"
Me.PNLWishList.Size = New System.Drawing.Size(250, 367)
Me.PNLWishList.TabIndex = 165
'
'WishlistCostSilver
'
Me.WishlistCostSilver.BackColor = System.Drawing.Color.Transparent
Me.WishlistCostSilver.Image = CType(resources.GetObject("WishlistCostSilver.Image"),System.Drawing.Image)
Me.WishlistCostSilver.Location = New System.Drawing.Point(107, 206)
Me.WishlistCostSilver.Name = "WishlistCostSilver"
Me.WishlistCostSilver.Size = New System.Drawing.Size(28, 28)
Me.WishlistCostSilver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.WishlistCostSilver.TabIndex = 111
Me.WishlistCostSilver.TabStop = false
'
'LBLWishListText
'
Me.LBLWishListText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLWishListText.Location = New System.Drawing.Point(14, 247)
Me.LBLWishListText.Name = "LBLWishListText"
Me.LBLWishListText.Size = New System.Drawing.Size(220, 109)
Me.LBLWishListText.TabIndex = 108
'
'LBLWishlistCost
'
Me.LBLWishlistCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLWishlistCost.ForeColor = System.Drawing.Color.Black
Me.LBLWishlistCost.Location = New System.Drawing.Point(139, 206)
Me.LBLWishlistCost.Name = "LBLWishlistCost"
Me.LBLWishlistCost.Size = New System.Drawing.Size(44, 28)
Me.LBLWishlistCost.TabIndex = 107
Me.LBLWishlistCost.Text = "3"
Me.LBLWishlistCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'WishlistCostGold
'
Me.WishlistCostGold.BackColor = System.Drawing.Color.Transparent
Me.WishlistCostGold.Image = CType(resources.GetObject("WishlistCostGold.Image"),System.Drawing.Image)
Me.WishlistCostGold.Location = New System.Drawing.Point(107, 206)
Me.WishlistCostGold.Name = "WishlistCostGold"
Me.WishlistCostGold.Size = New System.Drawing.Size(28, 28)
Me.WishlistCostGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.WishlistCostGold.TabIndex = 106
Me.WishlistCostGold.TabStop = false
Me.WishlistCostGold.Visible = false
'
'LBLWishListName
'
Me.LBLWishListName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLWishListName.ForeColor = System.Drawing.Color.CornflowerBlue
Me.LBLWishListName.Location = New System.Drawing.Point(14, 22)
Me.LBLWishListName.Name = "LBLWishListName"
Me.LBLWishListName.Size = New System.Drawing.Size(220, 23)
Me.LBLWishListName.TabIndex = 104
Me.LBLWishListName.Text = "Item Name Goes Here"
Me.LBLWishListName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'WishlistPreview
'
Me.WishlistPreview.ImageLocation = ""
Me.WishlistPreview.Location = New System.Drawing.Point(50, 54)
Me.WishlistPreview.Name = "WishlistPreview"
Me.WishlistPreview.Size = New System.Drawing.Size(145, 143)
Me.WishlistPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
Me.WishlistPreview.TabIndex = 101
Me.WishlistPreview.TabStop = false
'
'TabPage26
'
Me.TabPage26.BackColor = System.Drawing.Color.Silver
Me.TabPage26.Controls.Add(Me.Panel12)
Me.TabPage26.Location = New System.Drawing.Point(4, 22)
Me.TabPage26.Name = "TabPage26"
Me.TabPage26.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage26.Size = New System.Drawing.Size(720, 448)
Me.TabPage26.TabIndex = 19
Me.TabPage26.Text = "Themes"
'
'Panel12
'
Me.Panel12.BackColor = System.Drawing.Color.LightGray
Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel12.Controls.Add(Me.GroupBox9)
Me.Panel12.Controls.Add(Me.PictureBox10)
Me.Panel12.Controls.Add(Me.GroupBox5)
Me.Panel12.Controls.Add(Me.GroupBox11)
Me.Panel12.Controls.Add(Me.GroupBox1)
Me.Panel12.Controls.Add(Me.Label164)
Me.Panel12.Location = New System.Drawing.Point(6, 6)
Me.Panel12.Name = "Panel12"
Me.Panel12.Size = New System.Drawing.Size(708, 437)
Me.Panel12.TabIndex = 93
'
'GroupBox9
'
Me.GroupBox9.Controls.Add(Me.Button32)
Me.GroupBox9.Controls.Add(Me.Button31)
Me.GroupBox9.Location = New System.Drawing.Point(351, 231)
Me.GroupBox9.Name = "GroupBox9"
Me.GroupBox9.Size = New System.Drawing.Size(348, 94)
Me.GroupBox9.TabIndex = 152
Me.GroupBox9.TabStop = false
Me.GroupBox9.Text = "System"
'
'Button32
'
Me.Button32.BackColor = System.Drawing.Color.Transparent
Me.Button32.Image = Global.Tease_AI.My.Resources.Resources.Button_Save_Big
Me.Button32.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.Button32.Location = New System.Drawing.Point(196, 24)
Me.Button32.Name = "Button32"
Me.Button32.Size = New System.Drawing.Size(135, 55)
Me.Button32.TabIndex = 55
Me.Button32.Text = "  Save Theme"
Me.Button32.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
Me.Button32.UseVisualStyleBackColor = false
'
'Button31
'
Me.Button31.BackColor = System.Drawing.Color.Transparent
Me.Button31.Image = Global.Tease_AI.My.Resources.Resources.Button_Import_Big
Me.Button31.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.Button31.Location = New System.Drawing.Point(17, 24)
Me.Button31.Name = "Button31"
Me.Button31.Size = New System.Drawing.Size(135, 55)
Me.Button31.TabIndex = 54
Me.Button31.Text = "  Open Theme"
Me.Button31.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
Me.Button31.UseVisualStyleBackColor = false
'
'PictureBox10
'
Me.PictureBox10.BackColor = System.Drawing.Color.LightGray
Me.PictureBox10.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox10.Location = New System.Drawing.Point(9, 6)
Me.PictureBox10.Name = "PictureBox10"
Me.PictureBox10.Size = New System.Drawing.Size(160, 19)
Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox10.TabIndex = 151
Me.PictureBox10.TabStop = false
'
'GroupBox5
'
Me.GroupBox5.Controls.Add(Me.CBTransparentTime)
Me.GroupBox5.Controls.Add(Me.LBLDateTimeColor2)
Me.GroupBox5.Controls.Add(Me.Label137)
Me.GroupBox5.Controls.Add(Me.Label138)
Me.GroupBox5.Controls.Add(Me.LBLDateBackColor2)
Me.GroupBox5.Controls.Add(Me.LBLTextColor)
Me.GroupBox5.Controls.Add(Me.LBLChatWindowColor2)
Me.GroupBox5.Controls.Add(Me.LBLTextColor2)
Me.GroupBox5.Controls.Add(Me.LBLChatTextColor)
Me.GroupBox5.Controls.Add(Me.LBLBackColor2)
Me.GroupBox5.Controls.Add(Me.LBLButtonColor)
Me.GroupBox5.Controls.Add(Me.LBLChatWindowColor)
Me.GroupBox5.Controls.Add(Me.LBLBackColor)
Me.GroupBox5.Controls.Add(Me.LBLChatTextColor2)
Me.GroupBox5.Controls.Add(Me.LBLButtonColor2)
Me.GroupBox5.Location = New System.Drawing.Point(9, 31)
Me.GroupBox5.Name = "GroupBox5"
Me.GroupBox5.Size = New System.Drawing.Size(336, 294)
Me.GroupBox5.TabIndex = 58
Me.GroupBox5.TabStop = false
Me.GroupBox5.Text = "UI Colors"
'
'CBTransparentTime
'
Me.CBTransparentTime.AutoSize = true
Me.CBTransparentTime.Location = New System.Drawing.Point(7, 262)
Me.CBTransparentTime.Name = "CBTransparentTime"
Me.CBTransparentTime.Size = New System.Drawing.Size(179, 17)
Me.CBTransparentTime.TabIndex = 23
Me.CBTransparentTime.Text = "Transparent Date/Time Window"
Me.CBTransparentTime.UseVisualStyleBackColor = true
'
'LBLDateTimeColor2
'
Me.LBLDateTimeColor2.BackColor = Global.Tease_AI.My.MySettings.Default.DateTextColor
Me.LBLDateTimeColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDateTimeColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "DateTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLDateTimeColor2.Location = New System.Drawing.Point(187, 190)
Me.LBLDateTimeColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLDateTimeColor2.Name = "LBLDateTimeColor2"
Me.LBLDateTimeColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLDateTimeColor2.TabIndex = 19
'
'Label137
'
Me.Label137.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Label137.Location = New System.Drawing.Point(6, 227)
Me.Label137.Name = "Label137"
Me.Label137.Size = New System.Drawing.Size(175, 20)
Me.Label137.TabIndex = 20
Me.Label137.Text = "Date/Time Window Color"
Me.Label137.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label138
'
Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Label138.Location = New System.Drawing.Point(6, 193)
Me.Label138.Name = "Label138"
Me.Label138.Size = New System.Drawing.Size(175, 20)
Me.Label138.TabIndex = 17
Me.Label138.Text = "Date/Time Text Color"
Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLDateBackColor2
'
Me.LBLDateBackColor2.BackColor = Global.Tease_AI.My.MySettings.Default.DateBackColor
Me.LBLDateBackColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDateBackColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "DateBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLDateBackColor2.Location = New System.Drawing.Point(187, 224)
Me.LBLDateBackColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLDateBackColor2.Name = "LBLDateBackColor2"
Me.LBLDateBackColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLDateBackColor2.TabIndex = 22
'
'LBLTextColor
'
Me.LBLTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLTextColor.Location = New System.Drawing.Point(6, 91)
Me.LBLTextColor.Name = "LBLTextColor"
Me.LBLTextColor.Size = New System.Drawing.Size(175, 20)
Me.LBLTextColor.TabIndex = 7
Me.LBLTextColor.Text = "Text Color"
Me.LBLTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLChatWindowColor2
'
Me.LBLChatWindowColor2.BackColor = Global.Tease_AI.My.MySettings.Default.ChatWindowColor
Me.LBLChatWindowColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLChatWindowColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "ChatWindowColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLChatWindowColor2.Location = New System.Drawing.Point(187, 122)
Me.LBLChatWindowColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLChatWindowColor2.Name = "LBLChatWindowColor2"
Me.LBLChatWindowColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLChatWindowColor2.TabIndex = 12
'
'LBLTextColor2
'
Me.LBLTextColor2.BackColor = Global.Tease_AI.My.MySettings.Default.TextColor
Me.LBLTextColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLTextColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "TextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLTextColor2.Location = New System.Drawing.Point(187, 88)
Me.LBLTextColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLTextColor2.Name = "LBLTextColor2"
Me.LBLTextColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLTextColor2.TabIndex = 9
'
'LBLChatTextColor
'
Me.LBLChatTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLChatTextColor.Location = New System.Drawing.Point(6, 159)
Me.LBLChatTextColor.Name = "LBLChatTextColor"
Me.LBLChatTextColor.Size = New System.Drawing.Size(175, 20)
Me.LBLChatTextColor.TabIndex = 14
Me.LBLChatTextColor.Text = "Chat Text Color"
Me.LBLChatTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLBackColor2
'
Me.LBLBackColor2.BackColor = Global.Tease_AI.My.MySettings.Default.BackgroundColor
Me.LBLBackColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLBackColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLBackColor2.Location = New System.Drawing.Point(187, 20)
Me.LBLBackColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLBackColor2.Name = "LBLBackColor2"
Me.LBLBackColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLBackColor2.TabIndex = 3
'
'LBLButtonColor
'
Me.LBLButtonColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLButtonColor.Location = New System.Drawing.Point(6, 57)
Me.LBLButtonColor.Name = "LBLButtonColor"
Me.LBLButtonColor.Size = New System.Drawing.Size(175, 20)
Me.LBLButtonColor.TabIndex = 4
Me.LBLButtonColor.Text = "Button Color"
Me.LBLButtonColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLChatWindowColor
'
Me.LBLChatWindowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLChatWindowColor.Location = New System.Drawing.Point(6, 125)
Me.LBLChatWindowColor.Name = "LBLChatWindowColor"
Me.LBLChatWindowColor.Size = New System.Drawing.Size(175, 20)
Me.LBLChatWindowColor.TabIndex = 10
Me.LBLChatWindowColor.Text = "Chat Window Color"
Me.LBLChatWindowColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLBackColor
'
Me.LBLBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLBackColor.Location = New System.Drawing.Point(6, 23)
Me.LBLBackColor.Name = "LBLBackColor"
Me.LBLBackColor.Size = New System.Drawing.Size(175, 20)
Me.LBLBackColor.TabIndex = 0
Me.LBLBackColor.Text = "Background Color"
Me.LBLBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLChatTextColor2
'
Me.LBLChatTextColor2.BackColor = Global.Tease_AI.My.MySettings.Default.ChatTextColor
Me.LBLChatTextColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLChatTextColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "ChatTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLChatTextColor2.Location = New System.Drawing.Point(187, 156)
Me.LBLChatTextColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLChatTextColor2.Name = "LBLChatTextColor2"
Me.LBLChatTextColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLChatTextColor2.TabIndex = 16
'
'LBLButtonColor2
'
Me.LBLButtonColor2.BackColor = Global.Tease_AI.My.MySettings.Default.ButtonColor
Me.LBLButtonColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLButtonColor2.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tease_AI.My.MySettings.Default, "ButtonColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.LBLButtonColor2.Location = New System.Drawing.Point(187, 54)
Me.LBLButtonColor2.Margin = New System.Windows.Forms.Padding(3, 0, 10, 0)
Me.LBLButtonColor2.Name = "LBLButtonColor2"
Me.LBLButtonColor2.Size = New System.Drawing.Size(136, 28)
Me.LBLButtonColor2.TabIndex = 6
'
'GroupBox11
'
Me.GroupBox11.BackColor = System.Drawing.Color.LightGray
Me.GroupBox11.Controls.Add(Me.Label144)
Me.GroupBox11.ForeColor = System.Drawing.Color.Black
Me.GroupBox11.Location = New System.Drawing.Point(7, 331)
Me.GroupBox11.Name = "GroupBox11"
Me.GroupBox11.Size = New System.Drawing.Size(692, 92)
Me.GroupBox11.TabIndex = 65
Me.GroupBox11.TabStop = false
Me.GroupBox11.Text = "Description"
'
'Label144
'
Me.Label144.BackColor = System.Drawing.Color.Transparent
Me.Label144.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label144.ForeColor = System.Drawing.Color.Black
Me.Label144.Location = New System.Drawing.Point(6, 16)
Me.Label144.Name = "Label144"
Me.Label144.Size = New System.Drawing.Size(680, 73)
Me.Label144.TabIndex = 62
Me.Label144.Text = "Use this page to create custom themes for Tease AI."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Themes can then be saved a"& _ 
    "nd opened from txt files."
Me.Label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.CBFlipBack)
Me.GroupBox1.Controls.Add(Me.PBBackgroundPreview)
Me.GroupBox1.Controls.Add(Me.Button17)
Me.GroupBox1.Controls.Add(Me.CBStretchBack)
Me.GroupBox1.Controls.Add(Me.Button18)
Me.GroupBox1.Location = New System.Drawing.Point(351, 30)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(348, 195)
Me.GroupBox1.TabIndex = 57
Me.GroupBox1.TabStop = false
Me.GroupBox1.Text = "Background"
'
'CBFlipBack
'
Me.CBFlipBack.Enabled = false
Me.CBFlipBack.Location = New System.Drawing.Point(6, 153)
Me.CBFlipBack.Name = "CBFlipBack"
Me.CBFlipBack.Size = New System.Drawing.Size(86, 41)
Me.CBFlipBack.TabIndex = 4
Me.CBFlipBack.Text = "Flip Background"
Me.CBFlipBack.UseVisualStyleBackColor = true
'
'PBBackgroundPreview
'
Me.PBBackgroundPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.PBBackgroundPreview.Location = New System.Drawing.Point(6, 19)
Me.PBBackgroundPreview.Name = "PBBackgroundPreview"
Me.PBBackgroundPreview.Size = New System.Drawing.Size(202, 133)
Me.PBBackgroundPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.PBBackgroundPreview.TabIndex = 0
Me.PBBackgroundPreview.TabStop = false
'
'Button17
'
Me.Button17.BackColor = System.Drawing.Color.Transparent
Me.Button17.BackgroundImage = Global.Tease_AI.My.Resources.Resources.Background_Load
Me.Button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
Me.Button17.Location = New System.Drawing.Point(228, 36)
Me.Button17.Name = "Button17"
Me.Button17.Size = New System.Drawing.Size(103, 93)
Me.Button17.TabIndex = 1
Me.Button17.UseVisualStyleBackColor = false
'
'CBStretchBack
'
Me.CBStretchBack.Checked = true
Me.CBStretchBack.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBStretchBack.Location = New System.Drawing.Point(122, 153)
Me.CBStretchBack.Name = "CBStretchBack"
Me.CBStretchBack.Size = New System.Drawing.Size(86, 41)
Me.CBStretchBack.TabIndex = 2
Me.CBStretchBack.Text = "Stretch Background"
Me.CBStretchBack.UseVisualStyleBackColor = true
'
'Button18
'
Me.Button18.Location = New System.Drawing.Point(228, 155)
Me.Button18.Name = "Button18"
Me.Button18.Size = New System.Drawing.Size(103, 31)
Me.Button18.TabIndex = 3
Me.Button18.Text = "Clear"
Me.Button18.UseVisualStyleBackColor = true
'
'Label164
'
Me.Label164.BackColor = System.Drawing.Color.Transparent
Me.Label164.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label164.ForeColor = System.Drawing.Color.Black
Me.Label164.Location = New System.Drawing.Point(7, 6)
Me.Label164.Name = "Label164"
Me.Label164.Size = New System.Drawing.Size(692, 21)
Me.Label164.TabIndex = 49
Me.Label164.Text = "Theme Settings"
Me.Label164.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage4
'
Me.TabPage4.BackColor = System.Drawing.Color.Silver
Me.TabPage4.Controls.Add(Me.Panel6)
Me.TabPage4.Location = New System.Drawing.Point(4, 22)
Me.TabPage4.Name = "TabPage4"
Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage4.Size = New System.Drawing.Size(720, 448)
Me.TabPage4.TabIndex = 3
Me.TabPage4.Text = "Ranges"
'
'Panel6
'
Me.Panel6.BackColor = System.Drawing.Color.LightGray
Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel6.Controls.Add(Me.GroupBox69)
Me.Panel6.Controls.Add(Me.GroupBox68)
Me.Panel6.Controls.Add(Me.GroupBox67)
Me.Panel6.Controls.Add(Me.GroupBox10)
Me.Panel6.Controls.Add(Me.GroupBox57)
Me.Panel6.Controls.Add(Me.GBRangeRuinChance)
Me.Panel6.Controls.Add(Me.GroupBox17)
Me.Panel6.Controls.Add(Me.GBRangeOrgasmChance)
Me.Panel6.Controls.Add(Me.PictureBox8)
Me.Panel6.Controls.Add(Me.Label38)
Me.Panel6.Location = New System.Drawing.Point(6, 6)
Me.Panel6.Name = "Panel6"
Me.Panel6.Size = New System.Drawing.Size(708, 437)
Me.Panel6.TabIndex = 91
'
'GroupBox69
'
Me.GroupBox69.Controls.Add(Me.TypesSpeedVal)
Me.GroupBox69.Controls.Add(Me.TypeSpeedLabel)
Me.GroupBox69.Controls.Add(Me.TimedWriting)
Me.GroupBox69.Controls.Add(Me.TypeSpeedSlider)
Me.GroupBox69.Location = New System.Drawing.Point(236, 344)
Me.GroupBox69.Name = "GroupBox69"
Me.GroupBox69.Size = New System.Drawing.Size(166, 83)
Me.GroupBox69.TabIndex = 173
Me.GroupBox69.TabStop = false
Me.GroupBox69.Text = "Writing Tasks"
'
'TypesSpeedVal
'
Me.TypesSpeedVal.AutoSize = true
Me.TypesSpeedVal.Location = New System.Drawing.Point(132, 64)
Me.TypesSpeedVal.Name = "TypesSpeedVal"
Me.TypesSpeedVal.Size = New System.Drawing.Size(19, 13)
Me.TypesSpeedVal.TabIndex = 0
Me.TypesSpeedVal.Text = "10"
Me.TypesSpeedVal.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'TypeSpeedLabel
'
Me.TypeSpeedLabel.AutoSize = true
Me.TypeSpeedLabel.Location = New System.Drawing.Point(6, 64)
Me.TypeSpeedLabel.Name = "TypeSpeedLabel"
Me.TypeSpeedLabel.Size = New System.Drawing.Size(76, 13)
Me.TypeSpeedLabel.TabIndex = 2
Me.TypeSpeedLabel.Text = "Typing Speed:"
'
'TimedWriting
'
Me.TimedWriting.AutoSize = true
Me.TimedWriting.Checked = Global.Tease_AI.My.MySettings.Default.TimedWriting
Me.TimedWriting.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "TimedWriting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TimedWriting.Location = New System.Drawing.Point(9, 19)
Me.TimedWriting.Name = "TimedWriting"
Me.TimedWriting.Size = New System.Drawing.Size(123, 17)
Me.TimedWriting.TabIndex = 1
Me.TimedWriting.Text = "Timed Writing Tasks"
Me.TimedWriting.UseVisualStyleBackColor = true
'
'TypeSpeedSlider
'
Me.TypeSpeedSlider.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TypeSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.TypeSpeedSlider.Location = New System.Drawing.Point(9, 35)
Me.TypeSpeedSlider.Maximum = 100
Me.TypeSpeedSlider.Minimum = 33
Me.TypeSpeedSlider.Name = "TypeSpeedSlider"
Me.TypeSpeedSlider.Size = New System.Drawing.Size(148, 45)
Me.TypeSpeedSlider.TabIndex = 3
Me.TypeSpeedSlider.Value = Global.Tease_AI.My.MySettings.Default.TypeSpeed
'
'GroupBox68
'
Me.GroupBox68.Controls.Add(Me.NBTasksMax)
Me.GroupBox68.Controls.Add(Me.NBTasksMin)
Me.GroupBox68.Controls.Add(Me.Label165)
Me.GroupBox68.Controls.Add(Me.Label166)
Me.GroupBox68.Location = New System.Drawing.Point(236, 287)
Me.GroupBox68.Name = "GroupBox68"
Me.GroupBox68.Size = New System.Drawing.Size(166, 51)
Me.GroupBox68.TabIndex = 172
Me.GroupBox68.TabStop = false
Me.GroupBox68.Text = "Session Tasks"
'
'NBTasksMax
'
Me.NBTasksMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TasksMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTasksMax.Location = New System.Drawing.Point(113, 20)
Me.NBTasksMax.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
Me.NBTasksMax.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBTasksMax.Name = "NBTasksMax"
Me.NBTasksMax.Size = New System.Drawing.Size(44, 20)
Me.NBTasksMax.TabIndex = 187
Me.NBTasksMax.Value = New Decimal(New Integer() {6, 0, 0, 0})
'
'NBTasksMin
'
Me.NBTasksMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TasksMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTasksMin.Location = New System.Drawing.Point(54, 21)
Me.NBTasksMin.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
Me.NBTasksMin.Name = "NBTasksMin"
Me.NBTasksMin.Size = New System.Drawing.Size(44, 20)
Me.NBTasksMin.TabIndex = 186
Me.NBTasksMin.Value = New Decimal(New Integer() {3, 0, 0, 0})
'
'Label165
'
Me.Label165.BackColor = System.Drawing.Color.Transparent
Me.Label165.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label165.ForeColor = System.Drawing.Color.Black
Me.Label165.Location = New System.Drawing.Point(100, 20)
Me.Label165.Name = "Label165"
Me.Label165.Size = New System.Drawing.Size(10, 17)
Me.Label165.TabIndex = 185
Me.Label165.Text = "-"
Me.Label165.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label166
'
Me.Label166.BackColor = System.Drawing.Color.Transparent
Me.Label166.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label166.ForeColor = System.Drawing.Color.Black
Me.Label166.Location = New System.Drawing.Point(6, 21)
Me.Label166.Name = "Label166"
Me.Label166.Size = New System.Drawing.Size(49, 17)
Me.Label166.TabIndex = 188
Me.Label166.Text = "Amount:"
Me.Label166.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox67
'
Me.GroupBox67.Controls.Add(Me.Label161)
Me.GroupBox67.Controls.Add(Me.NBTaskCBTTimeMax)
Me.GroupBox67.Controls.Add(Me.NBTaskCBTTimeMin)
Me.GroupBox67.Controls.Add(Me.Label162)
Me.GroupBox67.Controls.Add(Me.Label163)
Me.GroupBox67.Controls.Add(Me.Label158)
Me.GroupBox67.Controls.Add(Me.NBTaskEdgeHoldTimeMax)
Me.GroupBox67.Controls.Add(Me.NBTaskEdgeHoldTimeMin)
Me.GroupBox67.Controls.Add(Me.Label159)
Me.GroupBox67.Controls.Add(Me.Label160)
Me.GroupBox67.Controls.Add(Me.NBTaskEdgesMax)
Me.GroupBox67.Controls.Add(Me.NBTaskEdgesMin)
Me.GroupBox67.Controls.Add(Me.Label119)
Me.GroupBox67.Controls.Add(Me.Label157)
Me.GroupBox67.Controls.Add(Me.Label151)
Me.GroupBox67.Controls.Add(Me.NBTaskStrokingTimeMax)
Me.GroupBox67.Controls.Add(Me.NBTaskStrokingTimeMin)
Me.GroupBox67.Controls.Add(Me.Label154)
Me.GroupBox67.Controls.Add(Me.Label155)
Me.GroupBox67.Controls.Add(Me.NBTaskStrokesMax)
Me.GroupBox67.Controls.Add(Me.NBTaskStrokesMin)
Me.GroupBox67.Controls.Add(Me.Label146)
Me.GroupBox67.Controls.Add(Me.Label149)
Me.GroupBox67.Location = New System.Drawing.Point(408, 288)
Me.GroupBox67.Name = "GroupBox67"
Me.GroupBox67.Size = New System.Drawing.Size(291, 139)
Me.GroupBox67.TabIndex = 171
Me.GroupBox67.TabStop = false
Me.GroupBox67.Text = "Letter Tasks"
'
'Label161
'
Me.Label161.BackColor = System.Drawing.Color.Transparent
Me.Label161.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label161.ForeColor = System.Drawing.Color.Black
Me.Label161.Location = New System.Drawing.Point(233, 110)
Me.Label161.Name = "Label161"
Me.Label161.Size = New System.Drawing.Size(50, 17)
Me.Label161.TabIndex = 204
Me.Label161.Text = "minutes"
Me.Label161.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTaskCBTTimeMax
'
Me.NBTaskCBTTimeMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskCBTTimeMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskCBTTimeMax.Location = New System.Drawing.Point(183, 110)
Me.NBTaskCBTTimeMax.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
Me.NBTaskCBTTimeMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskCBTTimeMax.Name = "NBTaskCBTTimeMax"
Me.NBTaskCBTTimeMax.Size = New System.Drawing.Size(44, 20)
Me.NBTaskCBTTimeMax.TabIndex = 203
Me.NBTaskCBTTimeMax.Value = Global.Tease_AI.My.MySettings.Default.TaskCBTTimeMax
'
'NBTaskCBTTimeMin
'
Me.NBTaskCBTTimeMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskCBTTimeMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskCBTTimeMin.Location = New System.Drawing.Point(117, 111)
Me.NBTaskCBTTimeMin.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskCBTTimeMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskCBTTimeMin.Name = "NBTaskCBTTimeMin"
Me.NBTaskCBTTimeMin.Size = New System.Drawing.Size(44, 20)
Me.NBTaskCBTTimeMin.TabIndex = 202
Me.NBTaskCBTTimeMin.Value = Global.Tease_AI.My.MySettings.Default.TaskCBTTimeMin
'
'Label162
'
Me.Label162.BackColor = System.Drawing.Color.Transparent
Me.Label162.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label162.ForeColor = System.Drawing.Color.Black
Me.Label162.Location = New System.Drawing.Point(167, 110)
Me.Label162.Name = "Label162"
Me.Label162.Size = New System.Drawing.Size(10, 17)
Me.Label162.TabIndex = 201
Me.Label162.Text = "-"
Me.Label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label163
'
Me.Label163.BackColor = System.Drawing.Color.Transparent
Me.Label163.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label163.ForeColor = System.Drawing.Color.Black
Me.Label163.Location = New System.Drawing.Point(12, 111)
Me.Label163.Name = "Label163"
Me.Label163.Size = New System.Drawing.Size(151, 17)
Me.Label163.TabIndex = 200
Me.Label163.Text = "CBT Time:"
Me.Label163.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label158
'
Me.Label158.BackColor = System.Drawing.Color.Transparent
Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label158.ForeColor = System.Drawing.Color.Black
Me.Label158.Location = New System.Drawing.Point(233, 87)
Me.Label158.Name = "Label158"
Me.Label158.Size = New System.Drawing.Size(50, 17)
Me.Label158.TabIndex = 199
Me.Label158.Text = "minutes"
Me.Label158.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTaskEdgeHoldTimeMax
'
Me.NBTaskEdgeHoldTimeMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskEdgeHoldTimeMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskEdgeHoldTimeMax.Location = New System.Drawing.Point(183, 87)
Me.NBTaskEdgeHoldTimeMax.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
Me.NBTaskEdgeHoldTimeMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskEdgeHoldTimeMax.Name = "NBTaskEdgeHoldTimeMax"
Me.NBTaskEdgeHoldTimeMax.Size = New System.Drawing.Size(44, 20)
Me.NBTaskEdgeHoldTimeMax.TabIndex = 198
Me.NBTaskEdgeHoldTimeMax.Value = Global.Tease_AI.My.MySettings.Default.TaskEdgeHoldTimeMax
'
'NBTaskEdgeHoldTimeMin
'
Me.NBTaskEdgeHoldTimeMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskEdgeHoldTimeMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskEdgeHoldTimeMin.Location = New System.Drawing.Point(117, 88)
Me.NBTaskEdgeHoldTimeMin.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskEdgeHoldTimeMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskEdgeHoldTimeMin.Name = "NBTaskEdgeHoldTimeMin"
Me.NBTaskEdgeHoldTimeMin.Size = New System.Drawing.Size(44, 20)
Me.NBTaskEdgeHoldTimeMin.TabIndex = 197
Me.NBTaskEdgeHoldTimeMin.Value = Global.Tease_AI.My.MySettings.Default.TaskEdgeHoldTimeMin
'
'Label159
'
Me.Label159.BackColor = System.Drawing.Color.Transparent
Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label159.ForeColor = System.Drawing.Color.Black
Me.Label159.Location = New System.Drawing.Point(167, 87)
Me.Label159.Name = "Label159"
Me.Label159.Size = New System.Drawing.Size(10, 17)
Me.Label159.TabIndex = 196
Me.Label159.Text = "-"
Me.Label159.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label160
'
Me.Label160.BackColor = System.Drawing.Color.Transparent
Me.Label160.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label160.ForeColor = System.Drawing.Color.Black
Me.Label160.Location = New System.Drawing.Point(12, 88)
Me.Label160.Name = "Label160"
Me.Label160.Size = New System.Drawing.Size(151, 17)
Me.Label160.TabIndex = 195
Me.Label160.Text = "Edge Hold Time:"
Me.Label160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTaskEdgesMax
'
Me.NBTaskEdgesMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskEdgesMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskEdgesMax.Location = New System.Drawing.Point(183, 64)
Me.NBTaskEdgesMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
Me.NBTaskEdgesMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskEdgesMax.Name = "NBTaskEdgesMax"
Me.NBTaskEdgesMax.Size = New System.Drawing.Size(44, 20)
Me.NBTaskEdgesMax.TabIndex = 194
Me.NBTaskEdgesMax.Value = Global.Tease_AI.My.MySettings.Default.TaskEdgesMax
'
'NBTaskEdgesMin
'
Me.NBTaskEdgesMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskEdgesMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskEdgesMin.Location = New System.Drawing.Point(117, 65)
Me.NBTaskEdgesMin.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskEdgesMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskEdgesMin.Name = "NBTaskEdgesMin"
Me.NBTaskEdgesMin.Size = New System.Drawing.Size(44, 20)
Me.NBTaskEdgesMin.TabIndex = 193
Me.NBTaskEdgesMin.Value = Global.Tease_AI.My.MySettings.Default.TaskEdgesMin
'
'Label119
'
Me.Label119.BackColor = System.Drawing.Color.Transparent
Me.Label119.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label119.ForeColor = System.Drawing.Color.Black
Me.Label119.Location = New System.Drawing.Point(167, 64)
Me.Label119.Name = "Label119"
Me.Label119.Size = New System.Drawing.Size(10, 17)
Me.Label119.TabIndex = 192
Me.Label119.Text = "-"
Me.Label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label157
'
Me.Label157.BackColor = System.Drawing.Color.Transparent
Me.Label157.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label157.ForeColor = System.Drawing.Color.Black
Me.Label157.Location = New System.Drawing.Point(12, 65)
Me.Label157.Name = "Label157"
Me.Label157.Size = New System.Drawing.Size(151, 17)
Me.Label157.TabIndex = 191
Me.Label157.Text = "Edges:"
Me.Label157.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label151
'
Me.Label151.BackColor = System.Drawing.Color.Transparent
Me.Label151.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label151.ForeColor = System.Drawing.Color.Black
Me.Label151.Location = New System.Drawing.Point(233, 41)
Me.Label151.Name = "Label151"
Me.Label151.Size = New System.Drawing.Size(50, 17)
Me.Label151.TabIndex = 190
Me.Label151.Text = "minutes"
Me.Label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTaskStrokingTimeMax
'
Me.NBTaskStrokingTimeMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskStrokingTimeMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskStrokingTimeMax.Location = New System.Drawing.Point(183, 41)
Me.NBTaskStrokingTimeMax.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskStrokingTimeMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskStrokingTimeMax.Name = "NBTaskStrokingTimeMax"
Me.NBTaskStrokingTimeMax.Size = New System.Drawing.Size(44, 20)
Me.NBTaskStrokingTimeMax.TabIndex = 189
Me.NBTaskStrokingTimeMax.Value = Global.Tease_AI.My.MySettings.Default.TaskStrokingTimeMax
'
'NBTaskStrokingTimeMin
'
Me.NBTaskStrokingTimeMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskStrokingTimeMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskStrokingTimeMin.Location = New System.Drawing.Point(117, 42)
Me.NBTaskStrokingTimeMin.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskStrokingTimeMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskStrokingTimeMin.Name = "NBTaskStrokingTimeMin"
Me.NBTaskStrokingTimeMin.Size = New System.Drawing.Size(44, 20)
Me.NBTaskStrokingTimeMin.TabIndex = 188
Me.NBTaskStrokingTimeMin.Value = Global.Tease_AI.My.MySettings.Default.TaskStrokingTimeMin
'
'Label154
'
Me.Label154.BackColor = System.Drawing.Color.Transparent
Me.Label154.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label154.ForeColor = System.Drawing.Color.Black
Me.Label154.Location = New System.Drawing.Point(167, 41)
Me.Label154.Name = "Label154"
Me.Label154.Size = New System.Drawing.Size(10, 17)
Me.Label154.TabIndex = 187
Me.Label154.Text = "-"
Me.Label154.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label155
'
Me.Label155.BackColor = System.Drawing.Color.Transparent
Me.Label155.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label155.ForeColor = System.Drawing.Color.Black
Me.Label155.Location = New System.Drawing.Point(12, 42)
Me.Label155.Name = "Label155"
Me.Label155.Size = New System.Drawing.Size(151, 17)
Me.Label155.TabIndex = 186
Me.Label155.Text = "Stroking Time:"
Me.Label155.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTaskStrokesMax
'
Me.NBTaskStrokesMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskStrokesMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskStrokesMax.Location = New System.Drawing.Point(183, 18)
Me.NBTaskStrokesMax.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskStrokesMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskStrokesMax.Name = "NBTaskStrokesMax"
Me.NBTaskStrokesMax.Size = New System.Drawing.Size(44, 20)
Me.NBTaskStrokesMax.TabIndex = 184
Me.NBTaskStrokesMax.Value = Global.Tease_AI.My.MySettings.Default.TaskStrokesMax
'
'NBTaskStrokesMin
'
Me.NBTaskStrokesMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "TaskStrokesMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBTaskStrokesMin.Location = New System.Drawing.Point(117, 19)
Me.NBTaskStrokesMin.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
Me.NBTaskStrokesMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTaskStrokesMin.Name = "NBTaskStrokesMin"
Me.NBTaskStrokesMin.Size = New System.Drawing.Size(44, 20)
Me.NBTaskStrokesMin.TabIndex = 183
Me.NBTaskStrokesMin.Value = Global.Tease_AI.My.MySettings.Default.TaskStrokesMin
'
'Label146
'
Me.Label146.BackColor = System.Drawing.Color.Transparent
Me.Label146.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label146.ForeColor = System.Drawing.Color.Black
Me.Label146.Location = New System.Drawing.Point(167, 18)
Me.Label146.Name = "Label146"
Me.Label146.Size = New System.Drawing.Size(10, 17)
Me.Label146.TabIndex = 182
Me.Label146.Text = "-"
Me.Label146.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label149
'
Me.Label149.BackColor = System.Drawing.Color.Transparent
Me.Label149.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label149.ForeColor = System.Drawing.Color.Black
Me.Label149.Location = New System.Drawing.Point(12, 19)
Me.Label149.Name = "Label149"
Me.Label149.Size = New System.Drawing.Size(151, 17)
Me.Label149.TabIndex = 181
Me.Label149.Text = "Strokes:"
Me.Label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox10
'
Me.GroupBox10.Controls.Add(Me.Label112)
Me.GroupBox10.Controls.Add(Me.NBNextImageChance)
Me.GroupBox10.Controls.Add(Me.Label6)
Me.GroupBox10.Location = New System.Drawing.Point(408, 31)
Me.GroupBox10.Name = "GroupBox10"
Me.GroupBox10.Size = New System.Drawing.Size(291, 54)
Me.GroupBox10.TabIndex = 170
Me.GroupBox10.TabStop = false
Me.GroupBox10.Text = "Tease Slideshow"
'
'Label112
'
Me.Label112.BackColor = System.Drawing.Color.Transparent
Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label112.ForeColor = System.Drawing.Color.Black
Me.Label112.Location = New System.Drawing.Point(233, 21)
Me.Label112.Name = "Label112"
Me.Label112.Size = New System.Drawing.Size(50, 17)
Me.Label112.TabIndex = 180
Me.Label112.Text = "percent"
Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBNextImageChance
'
Me.NBNextImageChance.Location = New System.Drawing.Point(183, 20)
Me.NBNextImageChance.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBNextImageChance.Name = "NBNextImageChance"
Me.NBNextImageChance.Size = New System.Drawing.Size(44, 20)
Me.NBNextImageChance.TabIndex = 179
Me.NBNextImageChance.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'Label6
'
Me.Label6.BackColor = System.Drawing.Color.Transparent
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label6.ForeColor = System.Drawing.Color.Black
Me.Label6.Location = New System.Drawing.Point(9, 21)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(151, 17)
Me.Label6.TabIndex = 154
Me.Label6.Text = "Image Next/Previous Chance:"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox57
'
Me.GroupBox57.Controls.Add(Me.Label139)
Me.GroupBox57.Controls.Add(Me.NBTauntEdging)
Me.GroupBox57.Controls.Add(Me.LBLVtf)
Me.GroupBox57.Controls.Add(Me.LBLStf)
Me.GroupBox57.Controls.Add(Me.SliderSTF)
Me.GroupBox57.Controls.Add(Me.TauntSlider)
Me.GroupBox57.Controls.Add(Me.Label106)
Me.GroupBox57.Controls.Add(Me.CBTauntCycleDD)
Me.GroupBox57.Controls.Add(Me.CBTeaseLengthDD)
Me.GroupBox57.Controls.Add(Me.Label103)
Me.GroupBox57.Controls.Add(Me.NBTauntCycleMax)
Me.GroupBox57.Controls.Add(Me.Label105)
Me.GroupBox57.Controls.Add(Me.Label101)
Me.GroupBox57.Controls.Add(Me.NBTauntCycleMin)
Me.GroupBox57.Controls.Add(Me.Label102)
Me.GroupBox57.Controls.Add(Me.Label97)
Me.GroupBox57.Controls.Add(Me.NBTeaseLengthMax)
Me.GroupBox57.Controls.Add(Me.Label99)
Me.GroupBox57.Controls.Add(Me.Label96)
Me.GroupBox57.Controls.Add(Me.NBTeaseLengthMin)
Me.GroupBox57.Controls.Add(Me.Label95)
Me.GroupBox57.Controls.Add(Me.Label49)
Me.GroupBox57.Controls.Add(Me.Label141)
Me.GroupBox57.Location = New System.Drawing.Point(7, 30)
Me.GroupBox57.Name = "GroupBox57"
Me.GroupBox57.Size = New System.Drawing.Size(223, 308)
Me.GroupBox57.TabIndex = 169
Me.GroupBox57.TabStop = false
Me.GroupBox57.Text = "Tease"
'
'Label139
'
Me.Label139.BackColor = System.Drawing.Color.Transparent
Me.Label139.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label139.ForeColor = System.Drawing.Color.Black
Me.Label139.Location = New System.Drawing.Point(175, 171)
Me.Label139.Name = "Label139"
Me.Label139.Size = New System.Drawing.Size(50, 17)
Me.Label139.TabIndex = 184
Me.Label139.Text = "percent"
Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTauntEdging
'
Me.NBTauntEdging.Location = New System.Drawing.Point(130, 171)
Me.NBTauntEdging.Name = "NBTauntEdging"
Me.NBTauntEdging.Size = New System.Drawing.Size(44, 20)
Me.NBTauntEdging.TabIndex = 188
Me.NBTauntEdging.Value = New Decimal(New Integer() {70, 0, 0, 0})
'
'LBLVtf
'
Me.LBLVtf.BackColor = System.Drawing.Color.Transparent
Me.LBLVtf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLVtf.ForeColor = System.Drawing.Color.Black
Me.LBLVtf.Location = New System.Drawing.Point(128, 261)
Me.LBLVtf.Name = "LBLVtf"
Me.LBLVtf.Size = New System.Drawing.Size(87, 17)
Me.LBLVtf.TabIndex = 187
Me.LBLVtf.Text = "Normal"
Me.LBLVtf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLStf
'
Me.LBLStf.BackColor = System.Drawing.Color.Transparent
Me.LBLStf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLStf.ForeColor = System.Drawing.Color.Black
Me.LBLStf.Location = New System.Drawing.Point(130, 220)
Me.LBLStf.Name = "LBLStf"
Me.LBLStf.Size = New System.Drawing.Size(87, 17)
Me.LBLStf.TabIndex = 165
Me.LBLStf.Text = "Normal"
Me.LBLStf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'SliderSTF
'
Me.SliderSTF.AutoSize = false
Me.SliderSTF.LargeChange = 1
Me.SliderSTF.Location = New System.Drawing.Point(130, 199)
Me.SliderSTF.Maximum = 5
Me.SliderSTF.Minimum = 1
Me.SliderSTF.Name = "SliderSTF"
Me.SliderSTF.Size = New System.Drawing.Size(87, 25)
Me.SliderSTF.TabIndex = 163
Me.SliderSTF.Value = 3
'
'TauntSlider
'
Me.TauntSlider.AutoSize = false
Me.TauntSlider.LargeChange = 1
Me.TauntSlider.Location = New System.Drawing.Point(130, 240)
Me.TauntSlider.Maximum = 9
Me.TauntSlider.Minimum = 1
Me.TauntSlider.Name = "TauntSlider"
Me.TauntSlider.Size = New System.Drawing.Size(87, 25)
Me.TauntSlider.TabIndex = 161
Me.TauntSlider.Value = 4
'
'Label106
'
Me.Label106.BackColor = System.Drawing.Color.Transparent
Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label106.ForeColor = System.Drawing.Color.Black
Me.Label106.Location = New System.Drawing.Point(6, 243)
Me.Label106.Name = "Label106"
Me.Label106.Size = New System.Drawing.Size(123, 17)
Me.Label106.TabIndex = 186
Me.Label106.Text = "Video Taunt Frequency:"
Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'CBTauntCycleDD
'
Me.CBTauntCycleDD.AutoSize = true
Me.CBTauntCycleDD.ForeColor = System.Drawing.Color.Black
Me.CBTauntCycleDD.Location = New System.Drawing.Point(9, 140)
Me.CBTauntCycleDD.Name = "CBTauntCycleDD"
Me.CBTauntCycleDD.Size = New System.Drawing.Size(176, 17)
Me.CBTauntCycleDD.TabIndex = 185
Me.CBTauntCycleDD.Text = "Domme Decide Based on Level"
Me.CBTauntCycleDD.UseVisualStyleBackColor = true
'
'CBTeaseLengthDD
'
Me.CBTeaseLengthDD.AutoSize = true
Me.CBTeaseLengthDD.ForeColor = System.Drawing.Color.Black
Me.CBTeaseLengthDD.Location = New System.Drawing.Point(9, 69)
Me.CBTeaseLengthDD.Name = "CBTeaseLengthDD"
Me.CBTeaseLengthDD.Size = New System.Drawing.Size(176, 17)
Me.CBTeaseLengthDD.TabIndex = 184
Me.CBTeaseLengthDD.Text = "Domme Decide Based on Level"
Me.CBTeaseLengthDD.UseVisualStyleBackColor = true
'
'Label103
'
Me.Label103.BackColor = System.Drawing.Color.Transparent
Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label103.ForeColor = System.Drawing.Color.Black
Me.Label103.Location = New System.Drawing.Point(175, 117)
Me.Label103.Name = "Label103"
Me.Label103.Size = New System.Drawing.Size(50, 17)
Me.Label103.TabIndex = 183
Me.Label103.Text = "minutes"
Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTauntCycleMax
'
Me.NBTauntCycleMax.Location = New System.Drawing.Point(130, 116)
Me.NBTauntCycleMax.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
Me.NBTauntCycleMax.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
Me.NBTauntCycleMax.Name = "NBTauntCycleMax"
Me.NBTauntCycleMax.Size = New System.Drawing.Size(44, 20)
Me.NBTauntCycleMax.TabIndex = 182
Me.NBTauntCycleMax.Value = New Decimal(New Integer() {5, 0, 0, 0})
'
'Label105
'
Me.Label105.BackColor = System.Drawing.Color.Transparent
Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label105.ForeColor = System.Drawing.Color.Black
Me.Label105.Location = New System.Drawing.Point(6, 117)
Me.Label105.Name = "Label105"
Me.Label105.Size = New System.Drawing.Size(123, 17)
Me.Label105.TabIndex = 181
Me.Label105.Text = "Taunt Cycle Maximum:"
Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label101
'
Me.Label101.BackColor = System.Drawing.Color.Transparent
Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label101.ForeColor = System.Drawing.Color.Black
Me.Label101.Location = New System.Drawing.Point(175, 93)
Me.Label101.Name = "Label101"
Me.Label101.Size = New System.Drawing.Size(50, 17)
Me.Label101.TabIndex = 180
Me.Label101.Text = "minutes"
Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTauntCycleMin
'
Me.NBTauntCycleMin.Location = New System.Drawing.Point(130, 92)
Me.NBTauntCycleMin.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
Me.NBTauntCycleMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBTauntCycleMin.Name = "NBTauntCycleMin"
Me.NBTauntCycleMin.Size = New System.Drawing.Size(44, 20)
Me.NBTauntCycleMin.TabIndex = 179
Me.NBTauntCycleMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'Label102
'
Me.Label102.BackColor = System.Drawing.Color.Transparent
Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label102.ForeColor = System.Drawing.Color.Black
Me.Label102.Location = New System.Drawing.Point(6, 93)
Me.Label102.Name = "Label102"
Me.Label102.Size = New System.Drawing.Size(123, 17)
Me.Label102.TabIndex = 178
Me.Label102.Text = "Taunt Cycle Minimum:"
Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label97
'
Me.Label97.BackColor = System.Drawing.Color.Transparent
Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label97.ForeColor = System.Drawing.Color.Black
Me.Label97.Location = New System.Drawing.Point(175, 46)
Me.Label97.Name = "Label97"
Me.Label97.Size = New System.Drawing.Size(50, 17)
Me.Label97.TabIndex = 177
Me.Label97.Text = "minutes"
Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTeaseLengthMax
'
Me.NBTeaseLengthMax.Location = New System.Drawing.Point(130, 45)
Me.NBTeaseLengthMax.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
Me.NBTeaseLengthMax.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
Me.NBTeaseLengthMax.Name = "NBTeaseLengthMax"
Me.NBTeaseLengthMax.Size = New System.Drawing.Size(44, 20)
Me.NBTeaseLengthMax.TabIndex = 176
Me.NBTeaseLengthMax.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'Label99
'
Me.Label99.BackColor = System.Drawing.Color.Transparent
Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label99.ForeColor = System.Drawing.Color.Black
Me.Label99.Location = New System.Drawing.Point(6, 46)
Me.Label99.Name = "Label99"
Me.Label99.Size = New System.Drawing.Size(123, 17)
Me.Label99.TabIndex = 175
Me.Label99.Text = "Tease Length Maximum:"
Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label96
'
Me.Label96.BackColor = System.Drawing.Color.Transparent
Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label96.ForeColor = System.Drawing.Color.Black
Me.Label96.Location = New System.Drawing.Point(175, 20)
Me.Label96.Name = "Label96"
Me.Label96.Size = New System.Drawing.Size(50, 17)
Me.Label96.TabIndex = 174
Me.Label96.Text = "minutes"
Me.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBTeaseLengthMin
'
Me.NBTeaseLengthMin.Location = New System.Drawing.Point(130, 19)
Me.NBTeaseLengthMin.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
Me.NBTeaseLengthMin.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBTeaseLengthMin.Name = "NBTeaseLengthMin"
Me.NBTeaseLengthMin.Size = New System.Drawing.Size(44, 20)
Me.NBTeaseLengthMin.TabIndex = 169
Me.NBTeaseLengthMin.Value = New Decimal(New Integer() {15, 0, 0, 0})
'
'Label95
'
Me.Label95.BackColor = System.Drawing.Color.Transparent
Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label95.ForeColor = System.Drawing.Color.Black
Me.Label95.Location = New System.Drawing.Point(6, 20)
Me.Label95.Name = "Label95"
Me.Label95.Size = New System.Drawing.Size(123, 17)
Me.Label95.TabIndex = 166
Me.Label95.Text = "Tease Length Minimum:"
Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label49
'
Me.Label49.BackColor = System.Drawing.Color.Transparent
Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label49.ForeColor = System.Drawing.Color.Black
Me.Label49.Location = New System.Drawing.Point(6, 207)
Me.Label49.Name = "Label49"
Me.Label49.Size = New System.Drawing.Size(132, 17)
Me.Label49.TabIndex = 164
Me.Label49.Text = "Stroke Taunt Frequency:"
Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label141
'
Me.Label141.BackColor = System.Drawing.Color.Transparent
Me.Label141.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label141.ForeColor = System.Drawing.Color.Black
Me.Label141.Location = New System.Drawing.Point(6, 163)
Me.Label141.Name = "Label141"
Me.Label141.Size = New System.Drawing.Size(141, 32)
Me.Label141.TabIndex = 189
Me.Label141.Text = "Edging Ends Taunts:"
Me.Label141.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GBRangeRuinChance
'
Me.GBRangeRuinChance.Controls.Add(Me.Label90)
Me.GBRangeRuinChance.Controls.Add(Me.NBRuinSometimes)
Me.GBRangeRuinChance.Controls.Add(Me.Label91)
Me.GBRangeRuinChance.Controls.Add(Me.Label92)
Me.GBRangeRuinChance.Controls.Add(Me.NBRuinRarely)
Me.GBRangeRuinChance.Controls.Add(Me.NBRuinOften)
Me.GBRangeRuinChance.Controls.Add(Me.CBRangeRuin)
Me.GBRangeRuinChance.Location = New System.Drawing.Point(236, 159)
Me.GBRangeRuinChance.Name = "GBRangeRuinChance"
Me.GBRangeRuinChance.Size = New System.Drawing.Size(166, 122)
Me.GBRangeRuinChance.TabIndex = 168
Me.GBRangeRuinChance.TabStop = false
Me.GBRangeRuinChance.Text = "Ruin Chance"
'
'Label90
'
Me.Label90.BackColor = System.Drawing.Color.Transparent
Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label90.ForeColor = System.Drawing.Color.Black
Me.Label90.Location = New System.Drawing.Point(6, 94)
Me.Label90.Name = "Label90"
Me.Label90.Size = New System.Drawing.Size(83, 17)
Me.Label90.TabIndex = 173
Me.Label90.Text = "Rarely Ruins:"
Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBRuinSometimes
'
Me.NBRuinSometimes.Enabled = false
Me.NBRuinSometimes.Location = New System.Drawing.Point(113, 68)
Me.NBRuinSometimes.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBRuinSometimes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBRuinSometimes.Name = "NBRuinSometimes"
Me.NBRuinSometimes.Size = New System.Drawing.Size(44, 20)
Me.NBRuinSometimes.TabIndex = 169
Me.NBRuinSometimes.Value = New Decimal(New Integer() {50, 0, 0, 0})
'
'Label91
'
Me.Label91.BackColor = System.Drawing.Color.Transparent
Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label91.ForeColor = System.Drawing.Color.Black
Me.Label91.Location = New System.Drawing.Point(6, 68)
Me.Label91.Name = "Label91"
Me.Label91.Size = New System.Drawing.Size(102, 17)
Me.Label91.TabIndex = 172
Me.Label91.Text = "Sometimes Ruins:"
Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label92
'
Me.Label92.BackColor = System.Drawing.Color.Transparent
Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label92.ForeColor = System.Drawing.Color.Black
Me.Label92.Location = New System.Drawing.Point(6, 42)
Me.Label92.Name = "Label92"
Me.Label92.Size = New System.Drawing.Size(72, 17)
Me.Label92.TabIndex = 171
Me.Label92.Text = "Often Ruins:"
Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBRuinRarely
'
Me.NBRuinRarely.Enabled = false
Me.NBRuinRarely.Location = New System.Drawing.Point(113, 94)
Me.NBRuinRarely.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBRuinRarely.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBRuinRarely.Name = "NBRuinRarely"
Me.NBRuinRarely.Size = New System.Drawing.Size(44, 20)
Me.NBRuinRarely.TabIndex = 170
Me.NBRuinRarely.Value = New Decimal(New Integer() {20, 0, 0, 0})
'
'NBRuinOften
'
Me.NBRuinOften.Enabled = false
Me.NBRuinOften.Location = New System.Drawing.Point(113, 42)
Me.NBRuinOften.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBRuinOften.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBRuinOften.Name = "NBRuinOften"
Me.NBRuinOften.Size = New System.Drawing.Size(44, 20)
Me.NBRuinOften.TabIndex = 168
Me.NBRuinOften.Value = New Decimal(New Integer() {75, 0, 0, 0})
'
'CBRangeRuin
'
Me.CBRangeRuin.AutoSize = true
Me.CBRangeRuin.ForeColor = System.Drawing.Color.Black
Me.CBRangeRuin.Location = New System.Drawing.Point(9, 19)
Me.CBRangeRuin.Name = "CBRangeRuin"
Me.CBRangeRuin.Size = New System.Drawing.Size(99, 17)
Me.CBRangeRuin.TabIndex = 159
Me.CBRangeRuin.Text = "Domme Decide"
Me.CBRangeRuin.UseVisualStyleBackColor = true
'
'GroupBox17
'
Me.GroupBox17.Controls.Add(Me.GroupBox19)
Me.GroupBox17.Controls.Add(Me.GroupBox18)
Me.GroupBox17.Location = New System.Drawing.Point(408, 91)
Me.GroupBox17.Name = "GroupBox17"
Me.GroupBox17.Size = New System.Drawing.Size(291, 190)
Me.GroupBox17.TabIndex = 0
Me.GroupBox17.TabStop = false
Me.GroupBox17.Text = "Video Teases"
'
'GroupBox19
'
Me.GroupBox19.Controls.Add(Me.Label110)
Me.GroupBox19.Controls.Add(Me.Label111)
Me.GroupBox19.Controls.Add(Me.NBGreenLightMax)
Me.GroupBox19.Controls.Add(Me.NBGreenLightMin)
Me.GroupBox19.Controls.Add(Me.NBRedLightMax)
Me.GroupBox19.Controls.Add(Me.Label26)
Me.GroupBox19.Controls.Add(Me.NBRedLightMin)
Me.GroupBox19.Controls.Add(Me.Label28)
Me.GroupBox19.Controls.Add(Me.Label27)
Me.GroupBox19.Controls.Add(Me.Label29)
Me.GroupBox19.Location = New System.Drawing.Point(6, 110)
Me.GroupBox19.Name = "GroupBox19"
Me.GroupBox19.Size = New System.Drawing.Size(279, 66)
Me.GroupBox19.TabIndex = 2
Me.GroupBox19.TabStop = false
Me.GroupBox19.Text = "Red Light, Green Light"
'
'Label110
'
Me.Label110.BackColor = System.Drawing.Color.Transparent
Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label110.ForeColor = System.Drawing.Color.Black
Me.Label110.Location = New System.Drawing.Point(227, 39)
Me.Label110.Name = "Label110"
Me.Label110.Size = New System.Drawing.Size(50, 17)
Me.Label110.TabIndex = 181
Me.Label110.Text = "seconds"
Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label111
'
Me.Label111.BackColor = System.Drawing.Color.Transparent
Me.Label111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label111.ForeColor = System.Drawing.Color.Black
Me.Label111.Location = New System.Drawing.Point(227, 16)
Me.Label111.Name = "Label111"
Me.Label111.Size = New System.Drawing.Size(50, 17)
Me.Label111.TabIndex = 180
Me.Label111.Text = "seconds"
Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBGreenLightMax
'
Me.NBGreenLightMax.Location = New System.Drawing.Point(177, 38)
Me.NBGreenLightMax.Name = "NBGreenLightMax"
Me.NBGreenLightMax.Size = New System.Drawing.Size(44, 20)
Me.NBGreenLightMax.TabIndex = 156
Me.NBGreenLightMax.Value = New Decimal(New Integer() {60, 0, 0, 0})
'
'NBGreenLightMin
'
Me.NBGreenLightMin.Location = New System.Drawing.Point(111, 38)
Me.NBGreenLightMin.Name = "NBGreenLightMin"
Me.NBGreenLightMin.Size = New System.Drawing.Size(44, 20)
Me.NBGreenLightMin.TabIndex = 155
Me.NBGreenLightMin.Value = New Decimal(New Integer() {10, 0, 0, 0})
'
'NBRedLightMax
'
Me.NBRedLightMax.Location = New System.Drawing.Point(177, 15)
Me.NBRedLightMax.Name = "NBRedLightMax"
Me.NBRedLightMax.Size = New System.Drawing.Size(44, 20)
Me.NBRedLightMax.TabIndex = 152
Me.NBRedLightMax.Value = New Decimal(New Integer() {30, 0, 0, 0})
'
'Label26
'
Me.Label26.BackColor = System.Drawing.Color.Transparent
Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label26.ForeColor = System.Drawing.Color.Black
Me.Label26.Location = New System.Drawing.Point(161, 38)
Me.Label26.Name = "Label26"
Me.Label26.Size = New System.Drawing.Size(10, 17)
Me.Label26.TabIndex = 154
Me.Label26.Text = "-"
Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBRedLightMin
'
Me.NBRedLightMin.Location = New System.Drawing.Point(111, 15)
Me.NBRedLightMin.Name = "NBRedLightMin"
Me.NBRedLightMin.Size = New System.Drawing.Size(44, 20)
Me.NBRedLightMin.TabIndex = 151
Me.NBRedLightMin.Value = New Decimal(New Integer() {5, 0, 0, 0})
'
'Label28
'
Me.Label28.BackColor = System.Drawing.Color.Transparent
Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label28.ForeColor = System.Drawing.Color.Black
Me.Label28.Location = New System.Drawing.Point(161, 15)
Me.Label28.Name = "Label28"
Me.Label28.Size = New System.Drawing.Size(10, 17)
Me.Label28.TabIndex = 150
Me.Label28.Text = "-"
Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label27
'
Me.Label27.BackColor = System.Drawing.Color.Transparent
Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label27.ForeColor = System.Drawing.Color.Black
Me.Label27.Location = New System.Drawing.Point(6, 39)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(151, 17)
Me.Label27.TabIndex = 153
Me.Label27.Text = "Green Light Time:"
Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label29
'
Me.Label29.BackColor = System.Drawing.Color.Transparent
Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label29.ForeColor = System.Drawing.Color.Black
Me.Label29.Location = New System.Drawing.Point(6, 16)
Me.Label29.Name = "Label29"
Me.Label29.Size = New System.Drawing.Size(151, 17)
Me.Label29.TabIndex = 149
Me.Label29.Text = "Red Light Time:"
Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox18
'
Me.GroupBox18.Controls.Add(Me.Label108)
Me.GroupBox18.Controls.Add(Me.Label109)
Me.GroupBox18.Controls.Add(Me.NBCensorShowMin)
Me.GroupBox18.Controls.Add(Me.NBCensorHideMax)
Me.GroupBox18.Controls.Add(Me.NBCensorHideMin)
Me.GroupBox18.Controls.Add(Me.CBCensorConstant)
Me.GroupBox18.Controls.Add(Me.Label25)
Me.GroupBox18.Controls.Add(Me.Label20)
Me.GroupBox18.Controls.Add(Me.Label19)
Me.GroupBox18.Controls.Add(Me.Label24)
Me.GroupBox18.Controls.Add(Me.NBCensorShowMax)
Me.GroupBox18.Location = New System.Drawing.Point(6, 16)
Me.GroupBox18.Name = "GroupBox18"
Me.GroupBox18.Size = New System.Drawing.Size(279, 88)
Me.GroupBox18.TabIndex = 1
Me.GroupBox18.TabStop = false
Me.GroupBox18.Text = "Censorship Sucks"
'
'Label108
'
Me.Label108.BackColor = System.Drawing.Color.Transparent
Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label108.ForeColor = System.Drawing.Color.Black
Me.Label108.Location = New System.Drawing.Point(227, 39)
Me.Label108.Name = "Label108"
Me.Label108.Size = New System.Drawing.Size(50, 17)
Me.Label108.TabIndex = 179
Me.Label108.Text = "seconds"
Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label109
'
Me.Label109.BackColor = System.Drawing.Color.Transparent
Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label109.ForeColor = System.Drawing.Color.Black
Me.Label109.Location = New System.Drawing.Point(227, 16)
Me.Label109.Name = "Label109"
Me.Label109.Size = New System.Drawing.Size(50, 17)
Me.Label109.TabIndex = 178
Me.Label109.Text = "seconds"
Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBCensorShowMin
'
Me.NBCensorShowMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "NBCensorShowMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBCensorShowMin.Location = New System.Drawing.Point(111, 15)
Me.NBCensorShowMin.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
Me.NBCensorShowMin.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBCensorShowMin.Name = "NBCensorShowMin"
Me.NBCensorShowMin.Size = New System.Drawing.Size(44, 20)
Me.NBCensorShowMin.TabIndex = 151
Me.NBCensorShowMin.Value = Global.Tease_AI.My.MySettings.Default.NBCensorShowMin
'
'NBCensorHideMax
'
Me.NBCensorHideMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "NBCensorHideMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBCensorHideMax.Location = New System.Drawing.Point(177, 38)
Me.NBCensorHideMax.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.NBCensorHideMax.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBCensorHideMax.Name = "NBCensorHideMax"
Me.NBCensorHideMax.Size = New System.Drawing.Size(44, 20)
Me.NBCensorHideMax.TabIndex = 156
Me.NBCensorHideMax.Value = Global.Tease_AI.My.MySettings.Default.NBCensorHideMax
'
'NBCensorHideMin
'
Me.NBCensorHideMin.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "NBCensorHideMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBCensorHideMin.Location = New System.Drawing.Point(111, 38)
Me.NBCensorHideMin.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
Me.NBCensorHideMin.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBCensorHideMin.Name = "NBCensorHideMin"
Me.NBCensorHideMin.Size = New System.Drawing.Size(44, 20)
Me.NBCensorHideMin.TabIndex = 155
Me.NBCensorHideMin.Value = Global.Tease_AI.My.MySettings.Default.NBCensorHideMin
'
'CBCensorConstant
'
Me.CBCensorConstant.AutoSize = true
Me.CBCensorConstant.Checked = Global.Tease_AI.My.MySettings.Default.CBCensorConstant
Me.CBCensorConstant.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tease_AI.My.MySettings.Default, "CBCensorConstant", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.CBCensorConstant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.CBCensorConstant.ForeColor = System.Drawing.Color.Black
Me.CBCensorConstant.Location = New System.Drawing.Point(6, 65)
Me.CBCensorConstant.Name = "CBCensorConstant"
Me.CBCensorConstant.Size = New System.Drawing.Size(263, 17)
Me.CBCensorConstant.TabIndex = 157
Me.CBCensorConstant.Text = "Censorship Bar Always Visible During Video Tease"
Me.CBCensorConstant.UseVisualStyleBackColor = true
'
'Label25
'
Me.Label25.BackColor = System.Drawing.Color.Transparent
Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label25.ForeColor = System.Drawing.Color.Black
Me.Label25.Location = New System.Drawing.Point(161, 15)
Me.Label25.Name = "Label25"
Me.Label25.Size = New System.Drawing.Size(10, 17)
Me.Label25.TabIndex = 150
Me.Label25.Text = "-"
Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label20
'
Me.Label20.BackColor = System.Drawing.Color.Transparent
Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label20.ForeColor = System.Drawing.Color.Black
Me.Label20.Location = New System.Drawing.Point(6, 39)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(110, 17)
Me.Label20.TabIndex = 153
Me.Label20.Text = "Censor Bar Hidden:"
Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label19
'
Me.Label19.BackColor = System.Drawing.Color.Transparent
Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label19.ForeColor = System.Drawing.Color.Black
Me.Label19.Location = New System.Drawing.Point(161, 38)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(10, 17)
Me.Label19.TabIndex = 154
Me.Label19.Text = "-"
Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label24
'
Me.Label24.BackColor = System.Drawing.Color.Transparent
Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label24.ForeColor = System.Drawing.Color.Black
Me.Label24.Location = New System.Drawing.Point(6, 16)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(110, 17)
Me.Label24.TabIndex = 149
Me.Label24.Text = "Censor Bar Shown:"
Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBCensorShowMax
'
Me.NBCensorShowMax.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tease_AI.My.MySettings.Default, "NBCensorShowMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
Me.NBCensorShowMax.Location = New System.Drawing.Point(177, 15)
Me.NBCensorShowMax.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.NBCensorShowMax.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
Me.NBCensorShowMax.Name = "NBCensorShowMax"
Me.NBCensorShowMax.Size = New System.Drawing.Size(44, 20)
Me.NBCensorShowMax.TabIndex = 152
Me.NBCensorShowMax.Value = Global.Tease_AI.My.MySettings.Default.NBCensorShowMax
'
'GBRangeOrgasmChance
'
Me.GBRangeOrgasmChance.Controls.Add(Me.Label89)
Me.GBRangeOrgasmChance.Controls.Add(Me.NBAllowSometimes)
Me.GBRangeOrgasmChance.Controls.Add(Me.Label86)
Me.GBRangeOrgasmChance.Controls.Add(Me.Label82)
Me.GBRangeOrgasmChance.Controls.Add(Me.NBAllowRarely)
Me.GBRangeOrgasmChance.Controls.Add(Me.NBAllowOften)
Me.GBRangeOrgasmChance.Controls.Add(Me.CBRangeOrgasm)
Me.GBRangeOrgasmChance.Location = New System.Drawing.Point(236, 31)
Me.GBRangeOrgasmChance.Name = "GBRangeOrgasmChance"
Me.GBRangeOrgasmChance.Size = New System.Drawing.Size(166, 122)
Me.GBRangeOrgasmChance.TabIndex = 167
Me.GBRangeOrgasmChance.TabStop = false
Me.GBRangeOrgasmChance.Text = "Orgasm Chance"
'
'Label89
'
Me.Label89.BackColor = System.Drawing.Color.Transparent
Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label89.ForeColor = System.Drawing.Color.Black
Me.Label89.Location = New System.Drawing.Point(6, 94)
Me.Label89.Name = "Label89"
Me.Label89.Size = New System.Drawing.Size(83, 17)
Me.Label89.TabIndex = 173
Me.Label89.Text = "Rarely Allows:"
Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBAllowSometimes
'
Me.NBAllowSometimes.Enabled = false
Me.NBAllowSometimes.Location = New System.Drawing.Point(113, 68)
Me.NBAllowSometimes.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBAllowSometimes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBAllowSometimes.Name = "NBAllowSometimes"
Me.NBAllowSometimes.Size = New System.Drawing.Size(44, 20)
Me.NBAllowSometimes.TabIndex = 169
Me.NBAllowSometimes.Value = New Decimal(New Integer() {50, 0, 0, 0})
'
'Label86
'
Me.Label86.BackColor = System.Drawing.Color.Transparent
Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label86.ForeColor = System.Drawing.Color.Black
Me.Label86.Location = New System.Drawing.Point(6, 68)
Me.Label86.Name = "Label86"
Me.Label86.Size = New System.Drawing.Size(102, 17)
Me.Label86.TabIndex = 172
Me.Label86.Text = "Sometimes Allows:"
Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label82
'
Me.Label82.BackColor = System.Drawing.Color.Transparent
Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label82.ForeColor = System.Drawing.Color.Black
Me.Label82.Location = New System.Drawing.Point(6, 42)
Me.Label82.Name = "Label82"
Me.Label82.Size = New System.Drawing.Size(83, 17)
Me.Label82.TabIndex = 171
Me.Label82.Text = "Often Allows:"
Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'NBAllowRarely
'
Me.NBAllowRarely.Enabled = false
Me.NBAllowRarely.Location = New System.Drawing.Point(113, 94)
Me.NBAllowRarely.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBAllowRarely.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBAllowRarely.Name = "NBAllowRarely"
Me.NBAllowRarely.Size = New System.Drawing.Size(44, 20)
Me.NBAllowRarely.TabIndex = 170
Me.NBAllowRarely.Value = New Decimal(New Integer() {20, 0, 0, 0})
'
'NBAllowOften
'
Me.NBAllowOften.Enabled = false
Me.NBAllowOften.Location = New System.Drawing.Point(113, 42)
Me.NBAllowOften.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
Me.NBAllowOften.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NBAllowOften.Name = "NBAllowOften"
Me.NBAllowOften.Size = New System.Drawing.Size(44, 20)
Me.NBAllowOften.TabIndex = 168
Me.NBAllowOften.Value = New Decimal(New Integer() {75, 0, 0, 0})
'
'CBRangeOrgasm
'
Me.CBRangeOrgasm.AutoSize = true
Me.CBRangeOrgasm.ForeColor = System.Drawing.Color.Black
Me.CBRangeOrgasm.Location = New System.Drawing.Point(9, 19)
Me.CBRangeOrgasm.Name = "CBRangeOrgasm"
Me.CBRangeOrgasm.Size = New System.Drawing.Size(99, 17)
Me.CBRangeOrgasm.TabIndex = 159
Me.CBRangeOrgasm.Text = "Domme Decide"
Me.CBRangeOrgasm.UseVisualStyleBackColor = true
'
'PictureBox8
'
Me.PictureBox8.BackColor = System.Drawing.Color.LightGray
Me.PictureBox8.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox8.Location = New System.Drawing.Point(9, 6)
Me.PictureBox8.Name = "PictureBox8"
Me.PictureBox8.Size = New System.Drawing.Size(160, 19)
Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox8.TabIndex = 166
Me.PictureBox8.TabStop = false
'
'Label38
'
Me.Label38.BackColor = System.Drawing.Color.Transparent
Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label38.ForeColor = System.Drawing.Color.Black
Me.Label38.Location = New System.Drawing.Point(7, 6)
Me.Label38.Name = "Label38"
Me.Label38.Size = New System.Drawing.Size(692, 21)
Me.Label38.TabIndex = 48
Me.Label38.Text = "Range Settings"
Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage13
'
Me.TabPage13.BackColor = System.Drawing.Color.Silver
Me.TabPage13.Controls.Add(Me.TabControl2)
Me.TabPage13.Location = New System.Drawing.Point(4, 22)
Me.TabPage13.Name = "TabPage13"
Me.TabPage13.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage13.Size = New System.Drawing.Size(720, 448)
Me.TabPage13.TabIndex = 13
Me.TabPage13.Text = "Modding"
'
'TabControl2
'
Me.TabControl2.Controls.Add(Me.TabPage27)
Me.TabControl2.Controls.Add(Me.TabPage14)
Me.TabControl2.Controls.Add(Me.TabPage24)
Me.TabControl2.Controls.Add(Me.TabPage8)
Me.TabControl2.Controls.Add(Me.TabPage15)
Me.TabControl2.Location = New System.Drawing.Point(6, 6)
Me.TabControl2.Name = "TabControl2"
Me.TabControl2.SelectedIndex = 0
Me.TabControl2.Size = New System.Drawing.Size(708, 437)
Me.TabControl2.TabIndex = 0
'
'TabPage27
'
Me.TabPage27.BackColor = System.Drawing.Color.LightGray
Me.TabPage27.Controls.Add(Me.TBPlaylistSave)
Me.TabPage27.Controls.Add(Me.BTNPlaylistCtrlZ)
Me.TabPage27.Controls.Add(Me.RadioPlaylistRegScripts)
Me.TabPage27.Controls.Add(Me.RadioPlaylistScripts)
Me.TabPage27.Controls.Add(Me.BTNPlaylistEnd)
Me.TabPage27.Controls.Add(Me.BTNPlaylistClearAll)
Me.TabPage27.Controls.Add(Me.BTNPlaylistSave)
Me.TabPage27.Controls.Add(Me.Button7)
Me.TabPage27.Controls.Add(Me.WBPlaylist)
Me.TabPage27.Controls.Add(Me.Label80)
Me.TabPage27.Controls.Add(Me.LBLPlaylIstLink)
Me.TabPage27.Controls.Add(Me.LBLPlaylistModule)
Me.TabPage27.Controls.Add(Me.LBLPLaylistStart)
Me.TabPage27.Controls.Add(Me.LBPlaylist)
Me.TabPage27.Location = New System.Drawing.Point(4, 22)
Me.TabPage27.Name = "TabPage27"
Me.TabPage27.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage27.Size = New System.Drawing.Size(700, 411)
Me.TabPage27.TabIndex = 5
Me.TabPage27.Text = "Playlists"
'
'TBPlaylistSave
'
Me.TBPlaylistSave.Location = New System.Drawing.Point(413, 371)
Me.TBPlaylistSave.Name = "TBPlaylistSave"
Me.TBPlaylistSave.Size = New System.Drawing.Size(201, 20)
Me.TBPlaylistSave.TabIndex = 203
'
'BTNPlaylistCtrlZ
'
Me.BTNPlaylistCtrlZ.Enabled = false
Me.BTNPlaylistCtrlZ.Location = New System.Drawing.Point(621, 21)
Me.BTNPlaylistCtrlZ.Name = "BTNPlaylistCtrlZ"
Me.BTNPlaylistCtrlZ.Size = New System.Drawing.Size(44, 23)
Me.BTNPlaylistCtrlZ.TabIndex = 202
Me.BTNPlaylistCtrlZ.Text = "Undo"
Me.BTNPlaylistCtrlZ.UseVisualStyleBackColor = true
'
'RadioPlaylistRegScripts
'
Me.RadioPlaylistRegScripts.AutoSize = true
Me.RadioPlaylistRegScripts.Location = New System.Drawing.Point(228, 372)
Me.RadioPlaylistRegScripts.Name = "RadioPlaylistRegScripts"
Me.RadioPlaylistRegScripts.Size = New System.Drawing.Size(127, 17)
Me.RadioPlaylistRegScripts.TabIndex = 201
Me.RadioPlaylistRegScripts.Text = "Show Regular Scripts"
Me.RadioPlaylistRegScripts.UseVisualStyleBackColor = true
'
'RadioPlaylistScripts
'
Me.RadioPlaylistScripts.AutoSize = true
Me.RadioPlaylistScripts.Checked = true
Me.RadioPlaylistScripts.Location = New System.Drawing.Point(62, 372)
Me.RadioPlaylistScripts.Name = "RadioPlaylistScripts"
Me.RadioPlaylistScripts.Size = New System.Drawing.Size(122, 17)
Me.RadioPlaylistScripts.TabIndex = 200
Me.RadioPlaylistScripts.TabStop = true
Me.RadioPlaylistScripts.Text = "Show Playlist Scripts"
Me.RadioPlaylistScripts.UseVisualStyleBackColor = true
'
'BTNPlaylistEnd
'
Me.BTNPlaylistEnd.BackColor = System.Drawing.Color.LightGray
Me.BTNPlaylistEnd.Enabled = false
Me.BTNPlaylistEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BTNPlaylistEnd.ForeColor = System.Drawing.Color.Black
Me.BTNPlaylistEnd.Location = New System.Drawing.Point(165, 21)
Me.BTNPlaylistEnd.Name = "BTNPlaylistEnd"
Me.BTNPlaylistEnd.Size = New System.Drawing.Size(44, 23)
Me.BTNPlaylistEnd.TabIndex = 199
Me.BTNPlaylistEnd.Text = "End"
Me.BTNPlaylistEnd.UseVisualStyleBackColor = false
'
'BTNPlaylistClearAll
'
Me.BTNPlaylistClearAll.Enabled = false
Me.BTNPlaylistClearAll.Location = New System.Drawing.Point(296, 21)
Me.BTNPlaylistClearAll.Name = "BTNPlaylistClearAll"
Me.BTNPlaylistClearAll.Size = New System.Drawing.Size(78, 23)
Me.BTNPlaylistClearAll.TabIndex = 198
Me.BTNPlaylistClearAll.Text = "Clear All"
Me.BTNPlaylistClearAll.UseVisualStyleBackColor = true
'
'BTNPlaylistSave
'
Me.BTNPlaylistSave.Enabled = false
Me.BTNPlaylistSave.Location = New System.Drawing.Point(621, 369)
Me.BTNPlaylistSave.Name = "BTNPlaylistSave"
Me.BTNPlaylistSave.Size = New System.Drawing.Size(44, 23)
Me.BTNPlaylistSave.TabIndex = 197
Me.BTNPlaylistSave.Text = "Save"
Me.BTNPlaylistSave.UseVisualStyleBackColor = true
'
'Button7
'
Me.Button7.Location = New System.Drawing.Point(213, 21)
Me.Button7.Name = "Button7"
Me.Button7.Size = New System.Drawing.Size(78, 23)
Me.Button7.TabIndex = 196
Me.Button7.Text = "Add Random"
Me.Button7.UseVisualStyleBackColor = true
'
'WBPlaylist
'
Me.WBPlaylist.Location = New System.Drawing.Point(38, 54)
Me.WBPlaylist.MinimumSize = New System.Drawing.Size(20, 20)
Me.WBPlaylist.Name = "WBPlaylist"
Me.WBPlaylist.Size = New System.Drawing.Size(336, 292)
Me.WBPlaylist.TabIndex = 195
'
'Label80
'
Me.Label80.AutoSize = true
Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label80.Location = New System.Drawing.Point(410, 27)
Me.Label80.Name = "Label80"
Me.Label80.Size = New System.Drawing.Size(47, 13)
Me.Label80.TabIndex = 194
Me.Label80.Text = "Playlist"
'
'LBLPlaylIstLink
'
Me.LBLPlaylIstLink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLPlaylIstLink.Enabled = false
Me.LBLPlaylIstLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLPlaylIstLink.Location = New System.Drawing.Point(128, 22)
Me.LBLPlaylIstLink.Name = "LBLPlaylIstLink"
Me.LBLPlaylIstLink.Size = New System.Drawing.Size(34, 21)
Me.LBLPlaylIstLink.TabIndex = 193
Me.LBLPlaylIstLink.Text = "Link"
Me.LBLPlaylIstLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLPlaylistModule
'
Me.LBLPlaylistModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLPlaylistModule.Enabled = false
Me.LBLPlaylistModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLPlaylistModule.Location = New System.Drawing.Point(76, 22)
Me.LBLPlaylistModule.Name = "LBLPlaylistModule"
Me.LBLPlaylistModule.Size = New System.Drawing.Size(50, 21)
Me.LBLPlaylistModule.TabIndex = 192
Me.LBLPlaylistModule.Text = "Module"
Me.LBLPlaylistModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLPLaylistStart
'
Me.LBLPLaylistStart.BackColor = System.Drawing.Color.Green
Me.LBLPLaylistStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLPLaylistStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLPLaylistStart.ForeColor = System.Drawing.Color.White
Me.LBLPLaylistStart.Location = New System.Drawing.Point(38, 22)
Me.LBLPLaylistStart.Name = "LBLPLaylistStart"
Me.LBLPLaylistStart.Size = New System.Drawing.Size(36, 21)
Me.LBLPLaylistStart.TabIndex = 190
Me.LBLPLaylistStart.Text = "Start"
Me.LBLPLaylistStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBPlaylist
'
Me.LBPlaylist.AllowDrop = true
Me.LBPlaylist.FormattingEnabled = true
Me.LBPlaylist.Location = New System.Drawing.Point(413, 56)
Me.LBPlaylist.Name = "LBPlaylist"
Me.LBPlaylist.Size = New System.Drawing.Size(252, 290)
Me.LBPlaylist.TabIndex = 189
'
'TabPage14
'
Me.TabPage14.BackColor = System.Drawing.Color.LightGray
Me.TabPage14.Controls.Add(Me.LBLKeywordPreview)
Me.TabPage14.Controls.Add(Me.Label88)
Me.TabPage14.Controls.Add(Me.TBKeywordPreview)
Me.TabPage14.Controls.Add(Me.Button37)
Me.TabPage14.Controls.Add(Me.Button50)
Me.TabPage14.Controls.Add(Me.Button22)
Me.TabPage14.Controls.Add(Me.TBKeyWords)
Me.TabPage14.Controls.Add(Me.LBKeyWords)
Me.TabPage14.Controls.Add(Me.RTBKeyWords)
Me.TabPage14.Location = New System.Drawing.Point(4, 22)
Me.TabPage14.Name = "TabPage14"
Me.TabPage14.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage14.Size = New System.Drawing.Size(700, 411)
Me.TabPage14.TabIndex = 0
Me.TabPage14.Text = "Keywords"
'
'LBLKeywordPreview
'
Me.LBLKeywordPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLKeywordPreview.Location = New System.Drawing.Point(215, 385)
Me.LBLKeywordPreview.Name = "LBLKeywordPreview"
Me.LBLKeywordPreview.Size = New System.Drawing.Size(416, 23)
Me.LBLKeywordPreview.TabIndex = 174
Me.LBLKeywordPreview.Text = "Get Preview Here"
Me.LBLKeywordPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label88
'
Me.Label88.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.Label88.Location = New System.Drawing.Point(3, 358)
Me.Label88.Name = "Label88"
Me.Label88.Size = New System.Drawing.Size(194, 53)
Me.Label88.TabIndex = 173
Me.Label88.Text = "Preview:  Enter any line with a Keyword and press # to generate a random sentence"& _ 
    " the domme return."
Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TBKeywordPreview
'
Me.TBKeywordPreview.Location = New System.Drawing.Point(215, 358)
Me.TBKeywordPreview.Name = "TBKeywordPreview"
Me.TBKeywordPreview.Size = New System.Drawing.Size(416, 20)
Me.TBKeywordPreview.TabIndex = 172
Me.TBKeywordPreview.Text = "Enter Line Here"
Me.TBKeywordPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Button37
'
Me.Button37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Button37.Location = New System.Drawing.Point(638, 358)
Me.Button37.Name = "Button37"
Me.Button37.Size = New System.Drawing.Size(47, 50)
Me.Button37.TabIndex = 171
Me.Button37.Text = "#"
Me.Button37.UseVisualStyleBackColor = true
'
'Button50
'
Me.Button50.Location = New System.Drawing.Point(6, 10)
Me.Button50.Name = "Button50"
Me.Button50.Size = New System.Drawing.Size(194, 23)
Me.Button50.TabIndex = 169
Me.Button50.Text = "Refresh and Clear Keyword List"
Me.Button50.UseVisualStyleBackColor = true
'
'Button22
'
Me.Button22.Location = New System.Drawing.Point(638, 10)
Me.Button22.Name = "Button22"
Me.Button22.Size = New System.Drawing.Size(47, 23)
Me.Button22.TabIndex = 167
Me.Button22.Text = "Save"
Me.Button22.UseVisualStyleBackColor = true
'
'TBKeyWords
'
Me.TBKeyWords.Location = New System.Drawing.Point(215, 10)
Me.TBKeyWords.Name = "TBKeyWords"
Me.TBKeyWords.Size = New System.Drawing.Size(416, 20)
Me.TBKeyWords.TabIndex = 166
'
'LBKeyWords
'
Me.LBKeyWords.FormattingEnabled = true
Me.LBKeyWords.Location = New System.Drawing.Point(6, 36)
Me.LBKeyWords.Name = "LBKeyWords"
Me.LBKeyWords.Size = New System.Drawing.Size(194, 316)
Me.LBKeyWords.Sorted = true
Me.LBKeyWords.TabIndex = 165
'
'RTBKeyWords
'
Me.RTBKeyWords.Location = New System.Drawing.Point(215, 39)
Me.RTBKeyWords.Name = "RTBKeyWords"
Me.RTBKeyWords.Size = New System.Drawing.Size(470, 313)
Me.RTBKeyWords.TabIndex = 164
Me.RTBKeyWords.Text = ""
'
'TabPage24
'
Me.TabPage24.BackColor = System.Drawing.Color.LightGray
Me.TabPage24.Controls.Add(Me.Button9)
Me.TabPage24.Controls.Add(Me.RTBResponsesKEY)
Me.TabPage24.Controls.Add(Me.Button4)
Me.TabPage24.Controls.Add(Me.Button5)
Me.TabPage24.Controls.Add(Me.TBResponses)
Me.TabPage24.Controls.Add(Me.LBResponses)
Me.TabPage24.Controls.Add(Me.RTBResponses)
Me.TabPage24.Location = New System.Drawing.Point(4, 22)
Me.TabPage24.Name = "TabPage24"
Me.TabPage24.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage24.Size = New System.Drawing.Size(700, 411)
Me.TabPage24.TabIndex = 3
Me.TabPage24.Text = "Responses"
'
'Button9
'
Me.Button9.Location = New System.Drawing.Point(217, 10)
Me.Button9.Name = "Button9"
Me.Button9.Size = New System.Drawing.Size(215, 23)
Me.Button9.TabIndex = 176
Me.Button9.Text = "Response Template"
Me.Button9.UseVisualStyleBackColor = true
'
'RTBResponsesKEY
'
Me.RTBResponsesKEY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.RTBResponsesKEY.Location = New System.Drawing.Point(217, 36)
Me.RTBResponsesKEY.Name = "RTBResponsesKEY"
Me.RTBResponsesKEY.Size = New System.Drawing.Size(468, 40)
Me.RTBResponsesKEY.TabIndex = 175
Me.RTBResponsesKEY.Text = ""
'
'Button4
'
Me.Button4.Location = New System.Drawing.Point(6, 10)
Me.Button4.Name = "Button4"
Me.Button4.Size = New System.Drawing.Size(194, 23)
Me.Button4.TabIndex = 174
Me.Button4.Text = "Refresh and Clear Response List"
Me.Button4.UseVisualStyleBackColor = true
'
'Button5
'
Me.Button5.Location = New System.Drawing.Point(638, 10)
Me.Button5.Name = "Button5"
Me.Button5.Size = New System.Drawing.Size(47, 23)
Me.Button5.TabIndex = 173
Me.Button5.Text = "Save"
Me.Button5.UseVisualStyleBackColor = true
'
'TBResponses
'
Me.TBResponses.Location = New System.Drawing.Point(438, 10)
Me.TBResponses.Name = "TBResponses"
Me.TBResponses.Size = New System.Drawing.Size(194, 20)
Me.TBResponses.TabIndex = 172
'
'LBResponses
'
Me.LBResponses.FormattingEnabled = true
Me.LBResponses.Location = New System.Drawing.Point(6, 36)
Me.LBResponses.Name = "LBResponses"
Me.LBResponses.Size = New System.Drawing.Size(194, 355)
Me.LBResponses.Sorted = true
Me.LBResponses.TabIndex = 171
'
'RTBResponses
'
Me.RTBResponses.Location = New System.Drawing.Point(217, 82)
Me.RTBResponses.Name = "RTBResponses"
Me.RTBResponses.Size = New System.Drawing.Size(468, 309)
Me.RTBResponses.TabIndex = 170
Me.RTBResponses.Text = ""
'
'TabPage8
'
Me.TabPage8.BackColor = System.Drawing.Color.LightGray
Me.TabPage8.Controls.Add(Me.RTBVideoMod)
Me.TabPage8.Controls.Add(Me.GroupBox29)
Me.TabPage8.Controls.Add(Me.BTNVideoModClear)
Me.TabPage8.Controls.Add(Me.GroupBox28)
Me.TabPage8.Controls.Add(Me.BTNVideoModLoad)
Me.TabPage8.Controls.Add(Me.GroupBox30)
Me.TabPage8.Controls.Add(Me.BTNVideoModSave)
Me.TabPage8.Location = New System.Drawing.Point(4, 22)
Me.TabPage8.Name = "TabPage8"
Me.TabPage8.Size = New System.Drawing.Size(700, 411)
Me.TabPage8.TabIndex = 2
Me.TabPage8.Text = "Video"
'
'RTBVideoMod
'
Me.RTBVideoMod.Enabled = false
Me.RTBVideoMod.Location = New System.Drawing.Point(167, 17)
Me.RTBVideoMod.Name = "RTBVideoMod"
Me.RTBVideoMod.Size = New System.Drawing.Size(525, 286)
Me.RTBVideoMod.TabIndex = 150
Me.RTBVideoMod.Text = ""
'
'GroupBox29
'
Me.GroupBox29.BackColor = System.Drawing.Color.LightGray
Me.GroupBox29.Controls.Add(Me.Label51)
Me.GroupBox29.ForeColor = System.Drawing.Color.Black
Me.GroupBox29.Location = New System.Drawing.Point(6, 309)
Me.GroupBox29.Name = "GroupBox29"
Me.GroupBox29.Size = New System.Drawing.Size(692, 92)
Me.GroupBox29.TabIndex = 66
Me.GroupBox29.TabStop = false
Me.GroupBox29.Text = "Description"
'
'Label51
'
Me.Label51.BackColor = System.Drawing.Color.Transparent
Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label51.ForeColor = System.Drawing.Color.Black
Me.Label51.Location = New System.Drawing.Point(6, 16)
Me.Label51.Name = "Label51"
Me.Label51.Size = New System.Drawing.Size(680, 73)
Me.Label51.TabIndex = 62
Me.Label51.Text = resources.GetString("Label51.Text")
Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNVideoModClear
'
Me.BTNVideoModClear.Enabled = false
Me.BTNVideoModClear.Location = New System.Drawing.Point(6, 227)
Me.BTNVideoModClear.Name = "BTNVideoModClear"
Me.BTNVideoModClear.Size = New System.Drawing.Size(155, 35)
Me.BTNVideoModClear.TabIndex = 153
Me.BTNVideoModClear.Text = "Clear Text and Select New Video Tease Type/Script"
Me.BTNVideoModClear.UseVisualStyleBackColor = true
'
'GroupBox28
'
Me.GroupBox28.Controls.Add(Me.CBVTType)
Me.GroupBox28.Location = New System.Drawing.Point(6, 8)
Me.GroupBox28.Name = "GroupBox28"
Me.GroupBox28.Size = New System.Drawing.Size(155, 46)
Me.GroupBox28.TabIndex = 148
Me.GroupBox28.TabStop = false
Me.GroupBox28.Text = "Video Tease Type"
'
'CBVTType
'
Me.CBVTType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.CBVTType.FormattingEnabled = true
Me.CBVTType.Items.AddRange(New Object() {"Avoid The Edge", "Censorship Sucks", "Red Light Green Light"})
Me.CBVTType.Location = New System.Drawing.Point(9, 15)
Me.CBVTType.Name = "CBVTType"
Me.CBVTType.Size = New System.Drawing.Size(137, 21)
Me.CBVTType.TabIndex = 171
'
'BTNVideoModLoad
'
Me.BTNVideoModLoad.Location = New System.Drawing.Point(6, 176)
Me.BTNVideoModLoad.Name = "BTNVideoModLoad"
Me.BTNVideoModLoad.Size = New System.Drawing.Size(155, 35)
Me.BTNVideoModLoad.TabIndex = 152
Me.BTNVideoModLoad.Text = "Load Script"
Me.BTNVideoModLoad.UseVisualStyleBackColor = true
'
'GroupBox30
'
Me.GroupBox30.Controls.Add(Me.LBVidScript)
Me.GroupBox30.Location = New System.Drawing.Point(6, 60)
Me.GroupBox30.Name = "GroupBox30"
Me.GroupBox30.Size = New System.Drawing.Size(155, 100)
Me.GroupBox30.TabIndex = 149
Me.GroupBox30.TabStop = false
Me.GroupBox30.Text = "Script"
'
'LBVidScript
'
Me.LBVidScript.FormattingEnabled = true
Me.LBVidScript.Location = New System.Drawing.Point(9, 20)
Me.LBVidScript.Name = "LBVidScript"
Me.LBVidScript.Size = New System.Drawing.Size(137, 69)
Me.LBVidScript.TabIndex = 0
'
'BTNVideoModSave
'
Me.BTNVideoModSave.Enabled = false
Me.BTNVideoModSave.Location = New System.Drawing.Point(6, 268)
Me.BTNVideoModSave.Name = "BTNVideoModSave"
Me.BTNVideoModSave.Size = New System.Drawing.Size(155, 35)
Me.BTNVideoModSave.TabIndex = 151
Me.BTNVideoModSave.Text = "Save Changes"
Me.BTNVideoModSave.UseVisualStyleBackColor = true
'
'TabPage15
'
Me.TabPage15.BackColor = System.Drawing.Color.LightGray
Me.TabPage15.Controls.Add(Me.Label62)
Me.TabPage15.Controls.Add(Me.Label61)
Me.TabPage15.Controls.Add(Me.Label57)
Me.TabPage15.Controls.Add(Me.Label58)
Me.TabPage15.Controls.Add(Me.Label60)
Me.TabPage15.Controls.Add(Me.TBGlitModFileName)
Me.TabPage15.Controls.Add(Me.GroupBox34)
Me.TabPage15.Controls.Add(Me.RTBGlitModDommePost)
Me.TabPage15.Controls.Add(Me.Button26)
Me.TabPage15.Controls.Add(Me.Label56)
Me.TabPage15.Controls.Add(Me.RTBGlitModResponses)
Me.TabPage15.Controls.Add(Me.LBGlitModScripts)
Me.TabPage15.Controls.Add(Me.LBLGlitModScriptCount)
Me.TabPage15.Controls.Add(Me.LBLGlitModDomType)
Me.TabPage15.Controls.Add(Me.Button29)
Me.TabPage15.Controls.Add(Me.CBGlitModType)
Me.TabPage15.Controls.Add(Me.Label59)
Me.TabPage15.Controls.Add(Me.Label50)
Me.TabPage15.Location = New System.Drawing.Point(4, 22)
Me.TabPage15.Name = "TabPage15"
Me.TabPage15.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage15.Size = New System.Drawing.Size(700, 411)
Me.TabPage15.TabIndex = 1
Me.TabPage15.Text = "Glitter"
'
'Label62
'
Me.Label62.Location = New System.Drawing.Point(255, 169)
Me.Label62.Name = "Label62"
Me.Label62.Size = New System.Drawing.Size(59, 51)
Me.Label62.TabIndex = 177
Me.Label62.Text = "@Cruel @Angry @Custom2"
Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label61
'
Me.Label61.Location = New System.Drawing.Point(194, 169)
Me.Label61.Name = "Label61"
Me.Label61.Size = New System.Drawing.Size(59, 51)
Me.Label61.TabIndex = 176
Me.Label61.Text = "@Bratty @Caring @Custom1"
Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label57
'
Me.Label57.Location = New System.Drawing.Point(194, 11)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(120, 23)
Me.Label57.TabIndex = 160
Me.Label57.Text = "File Name"
Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label58
'
Me.Label58.Location = New System.Drawing.Point(350, 11)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(326, 23)
Me.Label58.TabIndex = 161
Me.Label58.Text = "Domme's Post"
Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label60
'
Me.Label60.Location = New System.Drawing.Point(194, 139)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(120, 30)
Me.Label60.TabIndex = 175
Me.Label60.Text = "Tease Responses Need 3 of Each:"
Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TBGlitModFileName
'
Me.TBGlitModFileName.Location = New System.Drawing.Point(194, 36)
Me.TBGlitModFileName.Name = "TBGlitModFileName"
Me.TBGlitModFileName.Size = New System.Drawing.Size(120, 20)
Me.TBGlitModFileName.TabIndex = 158
'
'GroupBox34
'
Me.GroupBox34.BackColor = System.Drawing.Color.LightGray
Me.GroupBox34.Controls.Add(Me.Label52)
Me.GroupBox34.ForeColor = System.Drawing.Color.Black
Me.GroupBox34.Location = New System.Drawing.Point(8, 296)
Me.GroupBox34.Name = "GroupBox34"
Me.GroupBox34.Size = New System.Drawing.Size(683, 107)
Me.GroupBox34.TabIndex = 66
Me.GroupBox34.TabStop = false
Me.GroupBox34.Text = "Description"
'
'Label52
'
Me.Label52.BackColor = System.Drawing.Color.Transparent
Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label52.ForeColor = System.Drawing.Color.Black
Me.Label52.Location = New System.Drawing.Point(6, 16)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(670, 88)
Me.Label52.TabIndex = 62
Me.Label52.Text = resources.GetString("Label52.Text")
Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'RTBGlitModDommePost
'
Me.RTBGlitModDommePost.Location = New System.Drawing.Point(350, 36)
Me.RTBGlitModDommePost.Name = "RTBGlitModDommePost"
Me.RTBGlitModDommePost.Size = New System.Drawing.Size(326, 41)
Me.RTBGlitModDommePost.TabIndex = 162
Me.RTBGlitModDommePost.Text = ""
'
'Button26
'
Me.Button26.Location = New System.Drawing.Point(194, 239)
Me.Button26.Name = "Button26"
Me.Button26.Size = New System.Drawing.Size(120, 23)
Me.Button26.TabIndex = 174
Me.Button26.Text = "Clear Fields"
Me.Button26.UseVisualStyleBackColor = true
'
'Label56
'
Me.Label56.Location = New System.Drawing.Point(350, 80)
Me.Label56.Name = "Label56"
Me.Label56.Size = New System.Drawing.Size(324, 23)
Me.Label56.TabIndex = 156
Me.Label56.Text = "Responses (Minimum 3)"
Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'RTBGlitModResponses
'
Me.RTBGlitModResponses.Location = New System.Drawing.Point(350, 106)
Me.RTBGlitModResponses.Name = "RTBGlitModResponses"
Me.RTBGlitModResponses.Size = New System.Drawing.Size(326, 184)
Me.RTBGlitModResponses.TabIndex = 150
Me.RTBGlitModResponses.Text = ""
'
'LBGlitModScripts
'
Me.LBGlitModScripts.FormattingEnabled = true
Me.LBGlitModScripts.Location = New System.Drawing.Point(27, 106)
Me.LBGlitModScripts.Name = "LBGlitModScripts"
Me.LBGlitModScripts.Size = New System.Drawing.Size(136, 186)
Me.LBGlitModScripts.TabIndex = 163
'
'LBLGlitModScriptCount
'
Me.LBLGlitModScriptCount.Location = New System.Drawing.Point(27, 80)
Me.LBLGlitModScriptCount.Name = "LBLGlitModScriptCount"
Me.LBLGlitModScriptCount.Size = New System.Drawing.Size(136, 23)
Me.LBLGlitModScriptCount.TabIndex = 173
Me.LBLGlitModScriptCount.Text = "0 Trivia Glitter Scripts Found"
Me.LBLGlitModScriptCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLGlitModDomType
'
Me.LBLGlitModDomType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLGlitModDomType.Location = New System.Drawing.Point(191, 103)
Me.LBLGlitModDomType.Name = "LBLGlitModDomType"
Me.LBLGlitModDomType.Size = New System.Drawing.Size(123, 23)
Me.LBLGlitModDomType.TabIndex = 155
Me.LBLGlitModDomType.Text = "Total Brat"
Me.LBLGlitModDomType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Button29
'
Me.Button29.Location = New System.Drawing.Point(194, 268)
Me.Button29.Name = "Button29"
Me.Button29.Size = New System.Drawing.Size(120, 23)
Me.Button29.TabIndex = 151
Me.Button29.Text = "Save Glitter File"
Me.Button29.UseVisualStyleBackColor = true
'
'CBGlitModType
'
Me.CBGlitModType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.CBGlitModType.FormattingEnabled = true
Me.CBGlitModType.Items.AddRange(New Object() {"Tease", "Egotist", "Trivia", "Daily", "Custom 1", "Custom 2"})
Me.CBGlitModType.Location = New System.Drawing.Point(27, 35)
Me.CBGlitModType.Name = "CBGlitModType"
Me.CBGlitModType.Size = New System.Drawing.Size(136, 21)
Me.CBGlitModType.TabIndex = 171
'
'Label59
'
Me.Label59.Location = New System.Drawing.Point(33, 11)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(130, 23)
Me.Label59.TabIndex = 172
Me.Label59.Text = "Glitter Post Type"
Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label50
'
Me.Label50.Location = New System.Drawing.Point(191, 80)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(123, 23)
Me.Label50.TabIndex = 154
Me.Label50.Text = "Current Domme Personality:"
Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage25
'
Me.TabPage25.BackColor = System.Drawing.Color.Silver
Me.TabPage25.Controls.Add(Me.Panel11)
Me.TabPage25.Location = New System.Drawing.Point(4, 22)
Me.TabPage25.Name = "TabPage25"
Me.TabPage25.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage25.Size = New System.Drawing.Size(720, 448)
Me.TabPage25.TabIndex = 18
Me.TabPage25.Text = "Misc"
'
'Panel11
'
Me.Panel11.BackColor = System.Drawing.Color.LightGray
Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel11.Controls.Add(Me.GroupBox62)
Me.Panel11.Controls.Add(Me.GroupBox33)
Me.Panel11.Controls.Add(Me.GroupBox8)
Me.Panel11.Controls.Add(Me.GroupBox27)
Me.Panel11.Controls.Add(Me.GroupBox20)
Me.Panel11.Controls.Add(Me.GroupBox15)
Me.Panel11.Controls.Add(Me.PictureBox9)
Me.Panel11.Controls.Add(Me.Label148)
Me.Panel11.Location = New System.Drawing.Point(6, 6)
Me.Panel11.Name = "Panel11"
Me.Panel11.Size = New System.Drawing.Size(708, 437)
Me.Panel11.TabIndex = 92
'
'GroupBox62
'
Me.GroupBox62.Controls.Add(Me.RBGerman)
Me.GroupBox62.Controls.Add(Me.RBEnglish)
Me.GroupBox62.Location = New System.Drawing.Point(420, 155)
Me.GroupBox62.Name = "GroupBox62"
Me.GroupBox62.Size = New System.Drawing.Size(277, 56)
Me.GroupBox62.TabIndex = 178
Me.GroupBox62.TabStop = false
Me.GroupBox62.Text = "Language"
'
'RBGerman
'
Me.RBGerman.AutoSize = true
Me.RBGerman.Location = New System.Drawing.Point(180, 20)
Me.RBGerman.Name = "RBGerman"
Me.RBGerman.Size = New System.Drawing.Size(65, 17)
Me.RBGerman.TabIndex = 1
Me.RBGerman.Text = "Deutsch"
Me.RBGerman.UseVisualStyleBackColor = true
'
'RBEnglish
'
Me.RBEnglish.AutoSize = true
Me.RBEnglish.Checked = true
Me.RBEnglish.Location = New System.Drawing.Point(36, 19)
Me.RBEnglish.Name = "RBEnglish"
Me.RBEnglish.Size = New System.Drawing.Size(59, 17)
Me.RBEnglish.TabIndex = 0
Me.RBEnglish.TabStop = true
Me.RBEnglish.Text = "English"
Me.RBEnglish.UseVisualStyleBackColor = true
'
'GroupBox33
'
Me.GroupBox33.Controls.Add(Me.BTNOfflineMode)
Me.GroupBox33.Controls.Add(Me.LBLOfflineMode)
Me.GroupBox33.Controls.Add(Me.Label140)
Me.GroupBox33.Controls.Add(Me.Button11)
Me.GroupBox33.Controls.Add(Me.LBLChastityState)
Me.GroupBox33.Controls.Add(Me.Label120)
Me.GroupBox33.Location = New System.Drawing.Point(420, 321)
Me.GroupBox33.Name = "GroupBox33"
Me.GroupBox33.Size = New System.Drawing.Size(277, 106)
Me.GroupBox33.TabIndex = 177
Me.GroupBox33.TabStop = false
Me.GroupBox33.Text = "System States"
'
'BTNOfflineMode
'
Me.BTNOfflineMode.Location = New System.Drawing.Point(161, 70)
Me.BTNOfflineMode.Name = "BTNOfflineMode"
Me.BTNOfflineMode.Size = New System.Drawing.Size(99, 23)
Me.BTNOfflineMode.TabIndex = 180
Me.BTNOfflineMode.Text = "Toggle"
Me.BTNOfflineMode.UseVisualStyleBackColor = true
'
'LBLOfflineMode
'
Me.LBLOfflineMode.BackColor = System.Drawing.Color.LightGray
Me.LBLOfflineMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLOfflineMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLOfflineMode.ForeColor = System.Drawing.Color.Red
Me.LBLOfflineMode.Location = New System.Drawing.Point(120, 70)
Me.LBLOfflineMode.Name = "LBLOfflineMode"
Me.LBLOfflineMode.Size = New System.Drawing.Size(37, 23)
Me.LBLOfflineMode.TabIndex = 179
Me.LBLOfflineMode.Text = "OFF"
Me.LBLOfflineMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label140
'
Me.Label140.BackColor = System.Drawing.Color.LightGray
Me.Label140.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.Label140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label140.Location = New System.Drawing.Point(17, 70)
Me.Label140.Name = "Label140"
Me.Label140.Size = New System.Drawing.Size(98, 23)
Me.Label140.TabIndex = 178
Me.Label140.Text = "OFFLINE MODE"
Me.Label140.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Button11
'
Me.Button11.Location = New System.Drawing.Point(161, 33)
Me.Button11.Name = "Button11"
Me.Button11.Size = New System.Drawing.Size(99, 23)
Me.Button11.TabIndex = 177
Me.Button11.Text = "Toggle"
Me.Button11.UseVisualStyleBackColor = true
'
'LBLChastityState
'
Me.LBLChastityState.BackColor = System.Drawing.Color.LightGray
Me.LBLChastityState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLChastityState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLChastityState.ForeColor = System.Drawing.Color.Red
Me.LBLChastityState.Location = New System.Drawing.Point(120, 33)
Me.LBLChastityState.Name = "LBLChastityState"
Me.LBLChastityState.Size = New System.Drawing.Size(37, 23)
Me.LBLChastityState.TabIndex = 3
Me.LBLChastityState.Text = "OFF"
Me.LBLChastityState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label120
'
Me.Label120.BackColor = System.Drawing.Color.LightGray
Me.Label120.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.Label120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label120.Location = New System.Drawing.Point(17, 33)
Me.Label120.Name = "Label120"
Me.Label120.Size = New System.Drawing.Size(98, 23)
Me.Label120.TabIndex = 2
Me.Label120.Text = "CHASTITY"
Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox8
'
Me.GroupBox8.Controls.Add(Me.CBOutputErrors)
Me.GroupBox8.Location = New System.Drawing.Point(420, 214)
Me.GroupBox8.Name = "GroupBox8"
Me.GroupBox8.Size = New System.Drawing.Size(279, 47)
Me.GroupBox8.TabIndex = 179
Me.GroupBox8.TabStop = false
Me.GroupBox8.Text = "System Information"
'
'CBOutputErrors
'
Me.CBOutputErrors.AutoSize = true
Me.CBOutputErrors.Checked = true
Me.CBOutputErrors.CheckState = System.Windows.Forms.CheckState.Checked
Me.CBOutputErrors.ForeColor = System.Drawing.Color.Black
Me.CBOutputErrors.Location = New System.Drawing.Point(17, 19)
Me.CBOutputErrors.Name = "CBOutputErrors"
Me.CBOutputErrors.Size = New System.Drawing.Size(213, 17)
Me.CBOutputErrors.TabIndex = 29
Me.CBOutputErrors.TabStop = false
Me.CBOutputErrors.Text = "Output Error Messages to Chat Window"
Me.CBOutputErrors.UseVisualStyleBackColor = true
'
'GroupBox27
'
Me.GroupBox27.Controls.Add(Me.Button6)
Me.GroupBox27.Controls.Add(Me.LBLSesSpace)
Me.GroupBox27.Controls.Add(Me.Button3)
Me.GroupBox27.Controls.Add(Me.LBLSesFiles)
Me.GroupBox27.Controls.Add(Me.Label125)
Me.GroupBox27.Controls.Add(Me.Label124)
Me.GroupBox27.Location = New System.Drawing.Point(420, 32)
Me.GroupBox27.Name = "GroupBox27"
Me.GroupBox27.Size = New System.Drawing.Size(279, 117)
Me.GroupBox27.TabIndex = 176
Me.GroupBox27.TabStop = false
Me.GroupBox27.Text = "Session Images"
'
'Button6
'
Me.Button6.Location = New System.Drawing.Point(143, 76)
Me.Button6.Name = "Button6"
Me.Button6.Size = New System.Drawing.Size(117, 23)
Me.Button6.TabIndex = 176
Me.Button6.Text = "Delete All Files"
Me.Button6.UseVisualStyleBackColor = true
'
'LBLSesSpace
'
Me.LBLSesSpace.Location = New System.Drawing.Point(149, 53)
Me.LBLSesSpace.Name = "LBLSesSpace"
Me.LBLSesSpace.Size = New System.Drawing.Size(124, 13)
Me.LBLSesSpace.TabIndex = 3
'
'Button3
'
Me.Button3.Location = New System.Drawing.Point(20, 76)
Me.Button3.Name = "Button3"
Me.Button3.Size = New System.Drawing.Size(117, 23)
Me.Button3.TabIndex = 175
Me.Button3.Text = "Open Folder"
Me.Button3.UseVisualStyleBackColor = true
'
'LBLSesFiles
'
Me.LBLSesFiles.Location = New System.Drawing.Point(149, 24)
Me.LBLSesFiles.Name = "LBLSesFiles"
Me.LBLSesFiles.Size = New System.Drawing.Size(124, 13)
Me.LBLSesFiles.TabIndex = 2
'
'Label125
'
Me.Label125.AutoSize = true
Me.Label125.Location = New System.Drawing.Point(17, 53)
Me.Label125.Name = "Label125"
Me.Label125.Size = New System.Drawing.Size(120, 13)
Me.Label125.TabIndex = 1
Me.Label125.Text = "Total Disk Space Used:"
'
'Label124
'
Me.Label124.AutoSize = true
Me.Label124.Location = New System.Drawing.Point(17, 24)
Me.Label124.Name = "Label124"
Me.Label124.Size = New System.Drawing.Size(126, 13)
Me.Label124.TabIndex = 0
Me.Label124.Text = "Number of Files in Folder:"
'
'GroupBox20
'
Me.GroupBox20.Controls.Add(Me.BTNURLFileReplace)
Me.GroupBox20.Controls.Add(Me.Label87)
Me.GroupBox20.Controls.Add(Me.TBURLFileWith)
Me.GroupBox20.Controls.Add(Me.Label118)
Me.GroupBox20.Controls.Add(Me.Label85)
Me.GroupBox20.Controls.Add(Me.TBURLFileReplace)
Me.GroupBox20.Controls.Add(Me.Label53)
Me.GroupBox20.Controls.Add(Me.Label8)
Me.GroupBox20.Controls.Add(Me.Button1)
Me.GroupBox20.Controls.Add(Me.BTNMaintenanceScripts)
Me.GroupBox20.Controls.Add(Me.BTNMaintenanceRefresh)
Me.GroupBox20.Controls.Add(Me.Label117)
Me.GroupBox20.Controls.Add(Me.Label116)
Me.GroupBox20.Controls.Add(Me.PBCurrent)
Me.GroupBox20.Controls.Add(Me.BTNMaintenanceCancel)
Me.GroupBox20.Controls.Add(Me.PBMaintenance)
Me.GroupBox20.Controls.Add(Me.LBLMaintenance)
Me.GroupBox20.Controls.Add(Me.BTNMaintenanceRebuild)
Me.GroupBox20.Location = New System.Drawing.Point(6, 32)
Me.GroupBox20.Name = "GroupBox20"
Me.GroupBox20.Size = New System.Drawing.Size(408, 283)
Me.GroupBox20.TabIndex = 174
Me.GroupBox20.TabStop = false
Me.GroupBox20.Text = "Maintenance"
'
'BTNURLFileReplace
'
Me.BTNURLFileReplace.Location = New System.Drawing.Point(270, 249)
Me.BTNURLFileReplace.Name = "BTNURLFileReplace"
Me.BTNURLFileReplace.Size = New System.Drawing.Size(121, 23)
Me.BTNURLFileReplace.TabIndex = 184
Me.BTNURLFileReplace.Text = "Replace"
Me.BTNURLFileReplace.UseVisualStyleBackColor = true
'
'Label87
'
Me.Label87.AutoSize = true
Me.Label87.Location = New System.Drawing.Point(206, 254)
Me.Label87.Name = "Label87"
Me.Label87.Size = New System.Drawing.Size(38, 13)
Me.Label87.TabIndex = 183
Me.Label87.Text = ".media"
'
'TBURLFileWith
'
Me.TBURLFileWith.Location = New System.Drawing.Point(177, 251)
Me.TBURLFileWith.Name = "TBURLFileWith"
Me.TBURLFileWith.Size = New System.Drawing.Size(30, 20)
Me.TBURLFileWith.TabIndex = 182
'
'Label118
'
Me.Label118.AutoSize = true
Me.Label118.Location = New System.Drawing.Point(142, 254)
Me.Label118.Name = "Label118"
Me.Label118.Size = New System.Drawing.Size(29, 13)
Me.Label118.TabIndex = 181
Me.Label118.Text = "With"
'
'Label85
'
Me.Label85.AutoSize = true
Me.Label85.Location = New System.Drawing.Point(98, 254)
Me.Label85.Name = "Label85"
Me.Label85.Size = New System.Drawing.Size(38, 13)
Me.Label85.TabIndex = 180
Me.Label85.Text = ".media"
'
'TBURLFileReplace
'
Me.TBURLFileReplace.Location = New System.Drawing.Point(69, 251)
Me.TBURLFileReplace.Name = "TBURLFileReplace"
Me.TBURLFileReplace.Size = New System.Drawing.Size(30, 20)
Me.TBURLFileReplace.TabIndex = 179
'
'Label53
'
Me.Label53.AutoSize = true
Me.Label53.Location = New System.Drawing.Point(16, 254)
Me.Label53.Name = "Label53"
Me.Label53.Size = New System.Drawing.Size(47, 13)
Me.Label53.TabIndex = 178
Me.Label53.Text = "Replace"
'
'Label8
'
Me.Label8.AutoSize = true
Me.Label8.Location = New System.Drawing.Point(16, 232)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(130, 13)
Me.Label8.TabIndex = 177
Me.Label8.Text = "Change URL File Servers "
'
'Button1
'
Me.Button1.Enabled = false
Me.Button1.Location = New System.Drawing.Point(270, 19)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(121, 23)
Me.Button1.TabIndex = 176
Me.Button1.Text = "Reset Settings"
Me.Button1.UseVisualStyleBackColor = true
'
'BTNMaintenanceScripts
'
Me.BTNMaintenanceScripts.Location = New System.Drawing.Point(142, 19)
Me.BTNMaintenanceScripts.Name = "BTNMaintenanceScripts"
Me.BTNMaintenanceScripts.Size = New System.Drawing.Size(121, 23)
Me.BTNMaintenanceScripts.TabIndex = 175
Me.BTNMaintenanceScripts.Text = "Audit Scripts"
Me.BTNMaintenanceScripts.UseVisualStyleBackColor = true
'
'BTNMaintenanceRefresh
'
Me.BTNMaintenanceRefresh.Location = New System.Drawing.Point(15, 19)
Me.BTNMaintenanceRefresh.Name = "BTNMaintenanceRefresh"
Me.BTNMaintenanceRefresh.Size = New System.Drawing.Size(121, 23)
Me.BTNMaintenanceRefresh.TabIndex = 7
Me.BTNMaintenanceRefresh.Text = "Refresh URL Files"
Me.BTNMaintenanceRefresh.UseVisualStyleBackColor = true
'
'Label117
'
Me.Label117.AutoSize = true
Me.Label117.Location = New System.Drawing.Point(15, 182)
Me.Label117.Name = "Label117"
Me.Label117.Size = New System.Drawing.Size(84, 13)
Me.Label117.TabIndex = 6
Me.Label117.Text = "Overall Progress"
'
'Label116
'
Me.Label116.AutoSize = true
Me.Label116.Location = New System.Drawing.Point(15, 140)
Me.Label116.Name = "Label116"
Me.Label116.Size = New System.Drawing.Size(85, 13)
Me.Label116.TabIndex = 5
Me.Label116.Text = "Current Progress"
'
'PBCurrent
'
Me.PBCurrent.Location = New System.Drawing.Point(15, 156)
Me.PBCurrent.Name = "PBCurrent"
Me.PBCurrent.Size = New System.Drawing.Size(376, 23)
Me.PBCurrent.TabIndex = 4
'
'BTNMaintenanceCancel
'
Me.BTNMaintenanceCancel.Enabled = false
Me.BTNMaintenanceCancel.Location = New System.Drawing.Point(270, 48)
Me.BTNMaintenanceCancel.Name = "BTNMaintenanceCancel"
Me.BTNMaintenanceCancel.Size = New System.Drawing.Size(121, 23)
Me.BTNMaintenanceCancel.TabIndex = 3
Me.BTNMaintenanceCancel.Text = "Cancel"
Me.BTNMaintenanceCancel.UseVisualStyleBackColor = true
'
'PBMaintenance
'
Me.PBMaintenance.Location = New System.Drawing.Point(15, 197)
Me.PBMaintenance.Name = "PBMaintenance"
Me.PBMaintenance.Size = New System.Drawing.Size(376, 23)
Me.PBMaintenance.TabIndex = 2
'
'LBLMaintenance
'
Me.LBLMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLMaintenance.Location = New System.Drawing.Point(15, 76)
Me.LBLMaintenance.Name = "LBLMaintenance"
Me.LBLMaintenance.Size = New System.Drawing.Size(376, 61)
Me.LBLMaintenance.TabIndex = 1
Me.LBLMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNMaintenanceRebuild
'
Me.BTNMaintenanceRebuild.Location = New System.Drawing.Point(15, 48)
Me.BTNMaintenanceRebuild.Name = "BTNMaintenanceRebuild"
Me.BTNMaintenanceRebuild.Size = New System.Drawing.Size(121, 23)
Me.BTNMaintenanceRebuild.TabIndex = 0
Me.BTNMaintenanceRebuild.Text = "Rebuild URL Files"
Me.BTNMaintenanceRebuild.UseVisualStyleBackColor = true
'
'GroupBox15
'
Me.GroupBox15.Controls.Add(Me.Label115)
Me.GroupBox15.Controls.Add(Me.TBWebStop)
Me.GroupBox15.Controls.Add(Me.TBWebStart)
Me.GroupBox15.Controls.Add(Me.Label114)
Me.GroupBox15.Controls.Add(Me.WebToy)
Me.GroupBox15.Location = New System.Drawing.Point(6, 321)
Me.GroupBox15.Name = "GroupBox15"
Me.GroupBox15.Size = New System.Drawing.Size(408, 106)
Me.GroupBox15.TabIndex = 173
Me.GroupBox15.TabStop = false
Me.GroupBox15.Text = "Web-Controlled Sex Toy"
'
'Label115
'
Me.Label115.AutoSize = true
Me.Label115.Location = New System.Drawing.Point(12, 58)
Me.Label115.Name = "Label115"
Me.Label115.Size = New System.Drawing.Size(54, 13)
Me.Label115.TabIndex = 171
Me.Label115.Text = "Stop URL"
'
'TBWebStop
'
Me.TBWebStop.Location = New System.Drawing.Point(10, 72)
Me.TBWebStop.Name = "TBWebStop"
Me.TBWebStop.Size = New System.Drawing.Size(330, 20)
Me.TBWebStop.TabIndex = 170
'
'TBWebStart
'
Me.TBWebStart.Location = New System.Drawing.Point(10, 33)
Me.TBWebStart.Name = "TBWebStart"
Me.TBWebStart.Size = New System.Drawing.Size(330, 20)
Me.TBWebStart.TabIndex = 167
'
'Label114
'
Me.Label114.AutoSize = true
Me.Label114.Location = New System.Drawing.Point(12, 17)
Me.Label114.Name = "Label114"
Me.Label114.Size = New System.Drawing.Size(54, 13)
Me.Label114.TabIndex = 168
Me.Label114.Text = "Start URL"
'
'WebToy
'
Me.WebToy.Location = New System.Drawing.Point(346, 33)
Me.WebToy.MinimumSize = New System.Drawing.Size(20, 20)
Me.WebToy.Name = "WebToy"
Me.WebToy.Size = New System.Drawing.Size(45, 59)
Me.WebToy.TabIndex = 172
'
'PictureBox9
'
Me.PictureBox9.BackColor = System.Drawing.Color.LightGray
Me.PictureBox9.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_small
Me.PictureBox9.Location = New System.Drawing.Point(9, 6)
Me.PictureBox9.Name = "PictureBox9"
Me.PictureBox9.Size = New System.Drawing.Size(160, 19)
Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
Me.PictureBox9.TabIndex = 166
Me.PictureBox9.TabStop = false
'
'Label148
'
Me.Label148.BackColor = System.Drawing.Color.Transparent
Me.Label148.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label148.ForeColor = System.Drawing.Color.Black
Me.Label148.Location = New System.Drawing.Point(7, 6)
Me.Label148.Name = "Label148"
Me.Label148.Size = New System.Drawing.Size(692, 21)
Me.Label148.TabIndex = 48
Me.Label148.Text = "Miscellaneous Settings"
Me.Label148.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage28
'
Me.TabPage28.BackColor = System.Drawing.Color.Silver
Me.TabPage28.Controls.Add(Me.TabControl3)
Me.TabPage28.Location = New System.Drawing.Point(4, 22)
Me.TabPage28.Name = "TabPage28"
Me.TabPage28.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage28.Size = New System.Drawing.Size(720, 448)
Me.TabPage28.TabIndex = 20
Me.TabPage28.Text = "Debug"
'
'TabControl3
'
Me.TabControl3.Controls.Add(Me.TabPage29)
Me.TabControl3.Controls.Add(Me.TabPage30)
Me.TabControl3.Location = New System.Drawing.Point(6, 6)
Me.TabControl3.Name = "TabControl3"
Me.TabControl3.SelectedIndex = 0
Me.TabControl3.Size = New System.Drawing.Size(708, 437)
Me.TabControl3.TabIndex = 0
'
'TabPage29
'
Me.TabPage29.BackColor = System.Drawing.Color.LightGray
Me.TabPage29.Controls.Add(Me.Label143)
Me.TabPage29.Controls.Add(Me.LBLDebugScriptTime)
Me.TabPage29.Controls.Add(Me.BTNDebugHoldEdgeTimer)
Me.TabPage29.Controls.Add(Me.GroupBox26)
Me.TabPage29.Controls.Add(Me.BTNDebugStrokeTauntTimer)
Me.TabPage29.Controls.Add(Me.LBLDebugHoldEdgeTime)
Me.TabPage29.Controls.Add(Me.Label145)
Me.TabPage29.Controls.Add(Me.BTNDebugStrokeTime)
Me.TabPage29.Controls.Add(Me.BTNDebugEdgeTauntTimer)
Me.TabPage29.Controls.Add(Me.LBLDebugTeaseTime)
Me.TabPage29.Controls.Add(Me.LBLDebugStrokeTime)
Me.TabPage29.Controls.Add(Me.LBLDebugEdgeTauntTime)
Me.TabPage29.Controls.Add(Me.BTNDebugTeaseTimer)
Me.TabPage29.Controls.Add(Me.Label142)
Me.TabPage29.Controls.Add(Me.Label150)
Me.TabPage29.Controls.Add(Me.Label152)
Me.TabPage29.Controls.Add(Me.LBLDebugStrokeTauntTime)
Me.TabPage29.Controls.Add(Me.Label147)
Me.TabPage29.Location = New System.Drawing.Point(4, 22)
Me.TabPage29.Name = "TabPage29"
Me.TabPage29.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage29.Size = New System.Drawing.Size(700, 411)
Me.TabPage29.TabIndex = 0
Me.TabPage29.Text = "TabPage29"
'
'Label143
'
Me.Label143.Location = New System.Drawing.Point(402, 46)
Me.Label143.Name = "Label143"
Me.Label143.Size = New System.Drawing.Size(67, 23)
Me.Label143.TabIndex = 15
Me.Label143.Text = "Script Timer"
Me.Label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLDebugScriptTime
'
Me.LBLDebugScriptTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugScriptTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugScriptTime.Location = New System.Drawing.Point(475, 46)
Me.LBLDebugScriptTime.Name = "LBLDebugScriptTime"
Me.LBLDebugScriptTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugScriptTime.TabIndex = 16
Me.LBLDebugScriptTime.Text = "0"
Me.LBLDebugScriptTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNDebugHoldEdgeTimer
'
Me.BTNDebugHoldEdgeTimer.Location = New System.Drawing.Point(581, 248)
Me.BTNDebugHoldEdgeTimer.Name = "BTNDebugHoldEdgeTimer"
Me.BTNDebugHoldEdgeTimer.Size = New System.Drawing.Size(75, 23)
Me.BTNDebugHoldEdgeTimer.TabIndex = 14
Me.BTNDebugHoldEdgeTimer.Text = "Set to 5"
Me.BTNDebugHoldEdgeTimer.UseVisualStyleBackColor = true
'
'GroupBox26
'
Me.GroupBox26.Controls.Add(Me.LBLCycleDebugCountdown)
Me.GroupBox26.Controls.Add(Me.Button19)
Me.GroupBox26.Controls.Add(Me.BTNDebugTauntsClear)
Me.GroupBox26.Controls.Add(Me.TBDebugTaunts3)
Me.GroupBox26.Controls.Add(Me.TBDebugTaunts2)
Me.GroupBox26.Controls.Add(Me.TBDebugTaunts1)
Me.GroupBox26.Controls.Add(Me.RBDebugTaunts3)
Me.GroupBox26.Controls.Add(Me.RBDebugTaunts2)
Me.GroupBox26.Controls.Add(Me.RBDebugTaunts1)
Me.GroupBox26.Controls.Add(Me.CBDebugTauntsEndless)
Me.GroupBox26.Controls.Add(Me.CBDebugTaunts)
Me.GroupBox26.Location = New System.Drawing.Point(6, 5)
Me.GroupBox26.Name = "GroupBox26"
Me.GroupBox26.Size = New System.Drawing.Size(346, 178)
Me.GroupBox26.TabIndex = 0
Me.GroupBox26.TabStop = false
Me.GroupBox26.Text = "Taunt Cycle"
'
'LBLCycleDebugCountdown
'
Me.LBLCycleDebugCountdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLCycleDebugCountdown.Location = New System.Drawing.Point(100, 146)
Me.LBLCycleDebugCountdown.Name = "LBLCycleDebugCountdown"
Me.LBLCycleDebugCountdown.Size = New System.Drawing.Size(81, 23)
Me.LBLCycleDebugCountdown.TabIndex = 10
Me.LBLCycleDebugCountdown.Text = "0"
Me.LBLCycleDebugCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Button19
'
Me.Button19.Location = New System.Drawing.Point(191, 142)
Me.Button19.Name = "Button19"
Me.Button19.Size = New System.Drawing.Size(146, 30)
Me.Button19.TabIndex = 9
Me.Button19.Text = "Countdown to 5 Seconds"
Me.Button19.UseVisualStyleBackColor = true
'
'BTNDebugTauntsClear
'
Me.BTNDebugTauntsClear.Location = New System.Drawing.Point(194, 28)
Me.BTNDebugTauntsClear.Name = "BTNDebugTauntsClear"
Me.BTNDebugTauntsClear.Size = New System.Drawing.Size(146, 30)
Me.BTNDebugTauntsClear.TabIndex = 8
Me.BTNDebugTauntsClear.Text = "Clear"
Me.BTNDebugTauntsClear.UseVisualStyleBackColor = true
'
'TBDebugTaunts3
'
Me.TBDebugTaunts3.Location = New System.Drawing.Point(6, 116)
Me.TBDebugTaunts3.Name = "TBDebugTaunts3"
Me.TBDebugTaunts3.Size = New System.Drawing.Size(331, 20)
Me.TBDebugTaunts3.TabIndex = 7
'
'TBDebugTaunts2
'
Me.TBDebugTaunts2.Location = New System.Drawing.Point(6, 90)
Me.TBDebugTaunts2.Name = "TBDebugTaunts2"
Me.TBDebugTaunts2.Size = New System.Drawing.Size(331, 20)
Me.TBDebugTaunts2.TabIndex = 6
'
'TBDebugTaunts1
'
Me.TBDebugTaunts1.Location = New System.Drawing.Point(6, 64)
Me.TBDebugTaunts1.Name = "TBDebugTaunts1"
Me.TBDebugTaunts1.Size = New System.Drawing.Size(331, 20)
Me.TBDebugTaunts1.TabIndex = 5
'
'RBDebugTaunts3
'
Me.RBDebugTaunts3.AutoSize = true
Me.RBDebugTaunts3.Location = New System.Drawing.Point(127, 41)
Me.RBDebugTaunts3.Name = "RBDebugTaunts3"
Me.RBDebugTaunts3.Size = New System.Drawing.Size(59, 17)
Me.RBDebugTaunts3.TabIndex = 4
Me.RBDebugTaunts3.Text = "3 Lines"
Me.RBDebugTaunts3.UseVisualStyleBackColor = true
'
'RBDebugTaunts2
'
Me.RBDebugTaunts2.AutoSize = true
Me.RBDebugTaunts2.Location = New System.Drawing.Point(66, 41)
Me.RBDebugTaunts2.Name = "RBDebugTaunts2"
Me.RBDebugTaunts2.Size = New System.Drawing.Size(59, 17)
Me.RBDebugTaunts2.TabIndex = 3
Me.RBDebugTaunts2.Text = "2 Lines"
Me.RBDebugTaunts2.UseVisualStyleBackColor = true
'
'RBDebugTaunts1
'
Me.RBDebugTaunts1.AutoSize = true
Me.RBDebugTaunts1.Checked = true
Me.RBDebugTaunts1.Location = New System.Drawing.Point(7, 41)
Me.RBDebugTaunts1.Name = "RBDebugTaunts1"
Me.RBDebugTaunts1.Size = New System.Drawing.Size(54, 17)
Me.RBDebugTaunts1.TabIndex = 2
Me.RBDebugTaunts1.TabStop = true
Me.RBDebugTaunts1.Text = "1 Line"
Me.RBDebugTaunts1.UseVisualStyleBackColor = true
'
'CBDebugTauntsEndless
'
Me.CBDebugTauntsEndless.AutoSize = true
Me.CBDebugTauntsEndless.Location = New System.Drawing.Point(7, 150)
Me.CBDebugTauntsEndless.Name = "CBDebugTauntsEndless"
Me.CBDebugTauntsEndless.Size = New System.Drawing.Size(92, 17)
Me.CBDebugTauntsEndless.TabIndex = 1
Me.CBDebugTauntsEndless.Text = "Endless Cycle"
Me.CBDebugTauntsEndless.UseVisualStyleBackColor = true
'
'CBDebugTaunts
'
Me.CBDebugTaunts.AutoSize = true
Me.CBDebugTaunts.Location = New System.Drawing.Point(7, 20)
Me.CBDebugTaunts.Name = "CBDebugTaunts"
Me.CBDebugTaunts.Size = New System.Drawing.Size(174, 17)
Me.CBDebugTaunts.TabIndex = 0
Me.CBDebugTaunts.Text = "Enable Taunt Cycle Debugging"
Me.CBDebugTaunts.UseVisualStyleBackColor = true
'
'BTNDebugStrokeTauntTimer
'
Me.BTNDebugStrokeTauntTimer.Location = New System.Drawing.Point(581, 150)
Me.BTNDebugStrokeTauntTimer.Name = "BTNDebugStrokeTauntTimer"
Me.BTNDebugStrokeTauntTimer.Size = New System.Drawing.Size(75, 23)
Me.BTNDebugStrokeTauntTimer.TabIndex = 8
Me.BTNDebugStrokeTauntTimer.Text = "Set to 5"
Me.BTNDebugStrokeTauntTimer.UseVisualStyleBackColor = true
'
'LBLDebugHoldEdgeTime
'
Me.LBLDebugHoldEdgeTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugHoldEdgeTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugHoldEdgeTime.Location = New System.Drawing.Point(475, 248)
Me.LBLDebugHoldEdgeTime.Name = "LBLDebugHoldEdgeTime"
Me.LBLDebugHoldEdgeTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugHoldEdgeTime.TabIndex = 13
Me.LBLDebugHoldEdgeTime.Text = "0"
Me.LBLDebugHoldEdgeTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label145
'
Me.Label145.Location = New System.Drawing.Point(402, 11)
Me.Label145.Name = "Label145"
Me.Label145.Size = New System.Drawing.Size(67, 23)
Me.Label145.TabIndex = 3
Me.Label145.Text = "Tease Timer"
Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNDebugStrokeTime
'
Me.BTNDebugStrokeTime.Location = New System.Drawing.Point(581, 121)
Me.BTNDebugStrokeTime.Name = "BTNDebugStrokeTime"
Me.BTNDebugStrokeTime.Size = New System.Drawing.Size(75, 23)
Me.BTNDebugStrokeTime.TabIndex = 2
Me.BTNDebugStrokeTime.Text = "Set to 5"
Me.BTNDebugStrokeTime.UseVisualStyleBackColor = true
'
'BTNDebugEdgeTauntTimer
'
Me.BTNDebugEdgeTauntTimer.Location = New System.Drawing.Point(581, 209)
Me.BTNDebugEdgeTauntTimer.Name = "BTNDebugEdgeTauntTimer"
Me.BTNDebugEdgeTauntTimer.Size = New System.Drawing.Size(75, 23)
Me.BTNDebugEdgeTauntTimer.TabIndex = 11
Me.BTNDebugEdgeTauntTimer.Text = "Set to 5"
Me.BTNDebugEdgeTauntTimer.UseVisualStyleBackColor = true
'
'LBLDebugTeaseTime
'
Me.LBLDebugTeaseTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugTeaseTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugTeaseTime.Location = New System.Drawing.Point(475, 11)
Me.LBLDebugTeaseTime.Name = "LBLDebugTeaseTime"
Me.LBLDebugTeaseTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugTeaseTime.TabIndex = 4
Me.LBLDebugTeaseTime.Text = "0"
Me.LBLDebugTeaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLDebugStrokeTime
'
Me.LBLDebugStrokeTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugStrokeTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugStrokeTime.Location = New System.Drawing.Point(475, 121)
Me.LBLDebugStrokeTime.Name = "LBLDebugStrokeTime"
Me.LBLDebugStrokeTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugStrokeTime.TabIndex = 1
Me.LBLDebugStrokeTime.Text = "0"
Me.LBLDebugStrokeTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLDebugEdgeTauntTime
'
Me.LBLDebugEdgeTauntTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugEdgeTauntTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugEdgeTauntTime.Location = New System.Drawing.Point(475, 209)
Me.LBLDebugEdgeTauntTime.Name = "LBLDebugEdgeTauntTime"
Me.LBLDebugEdgeTauntTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugEdgeTauntTime.TabIndex = 10
Me.LBLDebugEdgeTauntTime.Text = "0"
Me.LBLDebugEdgeTauntTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BTNDebugTeaseTimer
'
Me.BTNDebugTeaseTimer.Location = New System.Drawing.Point(581, 11)
Me.BTNDebugTeaseTimer.Name = "BTNDebugTeaseTimer"
Me.BTNDebugTeaseTimer.Size = New System.Drawing.Size(75, 23)
Me.BTNDebugTeaseTimer.TabIndex = 5
Me.BTNDebugTeaseTimer.Text = "Set to 5"
Me.BTNDebugTeaseTimer.UseVisualStyleBackColor = true
'
'Label142
'
Me.Label142.Location = New System.Drawing.Point(402, 121)
Me.Label142.Name = "Label142"
Me.Label142.Size = New System.Drawing.Size(67, 23)
Me.Label142.TabIndex = 0
Me.Label142.Text = "Stroke Timer"
Me.Label142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label150
'
Me.Label150.Location = New System.Drawing.Point(402, 206)
Me.Label150.Name = "Label150"
Me.Label150.Size = New System.Drawing.Size(67, 27)
Me.Label150.TabIndex = 9
Me.Label150.Text = "Edge Taunt Timer"
Me.Label150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label152
'
Me.Label152.Location = New System.Drawing.Point(402, 238)
Me.Label152.Name = "Label152"
Me.Label152.Size = New System.Drawing.Size(67, 40)
Me.Label152.TabIndex = 12
Me.Label152.Text = "Hold Edge Timer"
Me.Label152.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLDebugStrokeTauntTime
'
Me.LBLDebugStrokeTauntTime.BackColor = System.Drawing.Color.Gainsboro
Me.LBLDebugStrokeTauntTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LBLDebugStrokeTauntTime.Location = New System.Drawing.Point(475, 150)
Me.LBLDebugStrokeTauntTime.Name = "LBLDebugStrokeTauntTime"
Me.LBLDebugStrokeTauntTime.Size = New System.Drawing.Size(100, 23)
Me.LBLDebugStrokeTauntTime.TabIndex = 7
Me.LBLDebugStrokeTauntTime.Text = "0"
Me.LBLDebugStrokeTauntTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label147
'
Me.Label147.Location = New System.Drawing.Point(402, 143)
Me.Label147.Name = "Label147"
Me.Label147.Size = New System.Drawing.Size(67, 29)
Me.Label147.TabIndex = 6
Me.Label147.Text = "Stroke Taunt Timer"
Me.Label147.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TabPage30
'
Me.TabPage30.BackColor = System.Drawing.Color.LightGray
Me.TabPage30.Controls.Add(Me.Button33)
Me.TabPage30.Controls.Add(Me.Button24)
Me.TabPage30.Location = New System.Drawing.Point(4, 22)
Me.TabPage30.Name = "TabPage30"
Me.TabPage30.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage30.Size = New System.Drawing.Size(700, 411)
Me.TabPage30.TabIndex = 1
Me.TabPage30.Text = "TabPage30"
'
'Button33
'
Me.Button33.Location = New System.Drawing.Point(6, 35)
Me.Button33.Name = "Button33"
Me.Button33.Size = New System.Drawing.Size(75, 23)
Me.Button33.TabIndex = 1
Me.Button33.Text = "LoadState"
Me.Button33.UseVisualStyleBackColor = true
'
'Button24
'
Me.Button24.Location = New System.Drawing.Point(6, 6)
Me.Button24.Name = "Button24"
Me.Button24.Size = New System.Drawing.Size(75, 23)
Me.Button24.TabIndex = 0
Me.Button24.Text = "SaveState"
Me.Button24.UseVisualStyleBackColor = true
'
'TabPage5
'
Me.TabPage5.BackColor = System.Drawing.Color.Silver
Me.TabPage5.Controls.Add(Me.Panel5)
Me.TabPage5.Location = New System.Drawing.Point(4, 22)
Me.TabPage5.Name = "TabPage5"
Me.TabPage5.Size = New System.Drawing.Size(720, 448)
Me.TabPage5.TabIndex = 17
Me.TabPage5.Text = "About"
'
'Panel5
'
Me.Panel5.BackColor = System.Drawing.Color.LightGray
Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel5.Controls.Add(Me.Label130)
Me.Panel5.Controls.Add(Me.Label123)
Me.Panel5.Controls.Add(Me.Label69)
Me.Panel5.Controls.Add(Me.Label113)
Me.Panel5.Controls.Add(Me.Label40)
Me.Panel5.Controls.Add(Me.Label35)
Me.Panel5.Controls.Add(Me.Label33)
Me.Panel5.Controls.Add(Me.Label17)
Me.Panel5.Controls.Add(Me.Label3)
Me.Panel5.Controls.Add(Me.PictureBox3)
Me.Panel5.Controls.Add(Me.Label41)
Me.Panel5.Location = New System.Drawing.Point(6, 6)
Me.Panel5.Name = "Panel5"
Me.Panel5.Size = New System.Drawing.Size(708, 437)
Me.Panel5.TabIndex = 92
'
'Label130
'
Me.Label130.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label130.Location = New System.Drawing.Point(522, 314)
Me.Label130.Name = "Label130"
Me.Label130.Size = New System.Drawing.Size(132, 54)
Me.Label130.TabIndex = 176
Me.Label130.Text = "q55x8x"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Stefaf"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"OxiKlein"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
Me.Label130.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label123
'
Me.Label123.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label123.Location = New System.Drawing.Point(62, 314)
Me.Label123.Name = "Label123"
Me.Label123.Size = New System.Drawing.Size(132, 54)
Me.Label123.TabIndex = 175
Me.Label123.Text = "pepsifreak"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Daragorn"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Ambossli"
Me.Label123.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label69
'
Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label69.Location = New System.Drawing.Point(35, 314)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(638, 54)
Me.Label69.TabIndex = 174
Me.Label69.Text = "Triple Alfa"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" malaru"
Me.Label69.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label113
'
Me.Label113.AutoSize = true
Me.Label113.Location = New System.Drawing.Point(4, 417)
Me.Label113.Name = "Label113"
Me.Label113.Size = New System.Drawing.Size(452, 13)
Me.Label113.TabIndex = 173
Me.Label113.Text = "All content contained in or viewed through this program are property of their res"& _ 
    "pective owners."
'
'Label40
'
Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label40.Location = New System.Drawing.Point(35, 273)
Me.Label40.Name = "Label40"
Me.Label40.Size = New System.Drawing.Size(638, 24)
Me.Label40.TabIndex = 171
Me.Label40.Text = "Special Thanks"
Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label35
'
Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label35.Location = New System.Drawing.Point(32, 107)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(641, 77)
Me.Label35.TabIndex = 170
Me.Label35.Text = "This program is freeware. It may be freely distributed."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Do not package or dist"& _ 
    "ribute this program with any scripts or additional content."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Please distribute a"& _ 
    "dditional files separately."
Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label33
'
Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label33.Location = New System.Drawing.Point(32, 191)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(641, 77)
Me.Label33.TabIndex = 169
Me.Label33.Text = resources.GetString("Label33.Text")
Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label17
'
Me.Label17.AutoSize = true
Me.Label17.Location = New System.Drawing.Point(522, 78)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(93, 13)
Me.Label17.TabIndex = 168
Me.Label17.Text = "Designed by 1885"
'
'Label3
'
Me.Label3.AutoSize = true
Me.Label3.Location = New System.Drawing.Point(489, 417)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(215, 13)
Me.Label3.TabIndex = 167
Me.Label3.Text = " Tease AI © 2015 1885 All Rights Reserved"
'
'PictureBox3
'
Me.PictureBox3.BackColor = System.Drawing.Color.LightGray
Me.PictureBox3.Image = Global.Tease_AI.My.Resources.Resources.TAI_Banner_big
Me.PictureBox3.Location = New System.Drawing.Point(84, 17)
Me.PictureBox3.Name = "PictureBox3"
Me.PictureBox3.Size = New System.Drawing.Size(531, 58)
Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
Me.PictureBox3.TabIndex = 166
Me.PictureBox3.TabStop = false
'
'Label41
'
Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label41.Location = New System.Drawing.Point(35, 372)
Me.Label41.Name = "Label41"
Me.Label41.Size = New System.Drawing.Size(638, 39)
Me.Label41.TabIndex = 172
Me.Label41.Text = "Thank you to everyone who has provided help and feedback."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Thank you to the commu"& _ 
    "nity who's been supportive of my work over the years. Tease AI exists because of"& _ 
    " you."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'BtnRandomImageDirClear
'
Me.BtnRandomImageDirClear.BackColor = System.Drawing.Color.LightGray
Me.BtnRandomImageDirClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.BtnRandomImageDirClear.ForeColor = System.Drawing.Color.Black
Me.BtnRandomImageDirClear.Location = New System.Drawing.Point(804, 212)
Me.BtnRandomImageDirClear.Name = "BtnRandomImageDirClear"
Me.BtnRandomImageDirClear.Size = New System.Drawing.Size(39, 22)
Me.BtnRandomImageDirClear.TabIndex = 181
Me.BtnRandomImageDirClear.Text = "Clear"
Me.BtnRandomImageDirClear.UseVisualStyleBackColor = false
'
'GroupBox47
'
Me.GroupBox47.BackColor = System.Drawing.Color.LightGray
Me.GroupBox47.Controls.Add(Me.GroupBox41)
Me.GroupBox47.Controls.Add(Me.GroupBox40)
Me.GroupBox47.ForeColor = System.Drawing.Color.Black
Me.GroupBox47.Location = New System.Drawing.Point(806, 255)
Me.GroupBox47.Name = "GroupBox47"
Me.GroupBox47.Size = New System.Drawing.Size(310, 190)
Me.GroupBox47.TabIndex = 63
Me.GroupBox47.TabStop = false
Me.GroupBox47.Text = "Boobs and Butts Paths"
'
'GroupBox41
'
Me.GroupBox41.Controls.Add(Me.Button34)
Me.GroupBox41.Location = New System.Drawing.Point(6, 110)
Me.GroupBox41.Name = "GroupBox41"
Me.GroupBox41.Size = New System.Drawing.Size(298, 74)
Me.GroupBox41.TabIndex = 153
Me.GroupBox41.TabStop = false
Me.GroupBox41.Text = "Butts"
'
'Button34
'
Me.Button34.BackColor = System.Drawing.Color.LightGray
Me.Button34.Font = New System.Drawing.Font("Wingdings", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
Me.Button34.ForeColor = System.Drawing.Color.Black
Me.Button34.Location = New System.Drawing.Point(85, 25)
Me.Button34.Name = "Button34"
Me.Button34.Size = New System.Drawing.Size(34, 28)
Me.Button34.TabIndex = 131
Me.Button34.Text = "1"
Me.Button34.UseVisualStyleBackColor = false
'
'GroupBox40
'
Me.GroupBox40.Location = New System.Drawing.Point(5, 35)
Me.GroupBox40.Name = "GroupBox40"
Me.GroupBox40.Size = New System.Drawing.Size(298, 74)
Me.GroupBox40.TabIndex = 152
Me.GroupBox40.TabStop = false
Me.GroupBox40.Text = "Boobs"
'
'GroupBox44
'
Me.GroupBox44.BackColor = System.Drawing.Color.LightGray
Me.GroupBox44.Controls.Add(Me.Label100)
Me.GroupBox44.ForeColor = System.Drawing.Color.Black
Me.GroupBox44.Location = New System.Drawing.Point(1149, 332)
Me.GroupBox44.Name = "GroupBox44"
Me.GroupBox44.Size = New System.Drawing.Size(310, 92)
Me.GroupBox44.TabIndex = 65
Me.GroupBox44.TabStop = false
Me.GroupBox44.Text = "Description"
'
'Label100
'
Me.Label100.BackColor = System.Drawing.Color.Transparent
Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label100.ForeColor = System.Drawing.Color.Black
Me.Label100.Location = New System.Drawing.Point(11, 16)
Me.Label100.Name = "Label100"
Me.Label100.Size = New System.Drawing.Size(286, 73)
Me.Label100.TabIndex = 62
Me.Label100.Text = resources.GetString("Label100.Text")
Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox6
'
Me.GroupBox6.Controls.Add(Me.Label171)
Me.GroupBox6.Controls.Add(Me.Label4)
Me.GroupBox6.Controls.Add(Me.LBLAvgEdgeStroking)
Me.GroupBox6.Controls.Add(Me.LBLStrokeTimeTotal)
Me.GroupBox6.Controls.Add(Me.Label94)
Me.GroupBox6.Controls.Add(Me.LBLLastRuined)
Me.GroupBox6.Controls.Add(Me.Label65)
Me.GroupBox6.Controls.Add(Me.LBLAvgEdgeNoTouch)
Me.GroupBox6.Controls.Add(Me.LBLLastOrgasm)
Me.GroupBox6.Controls.Add(Me.Label14)
Me.GroupBox6.Location = New System.Drawing.Point(239, 201)
Me.GroupBox6.Name = "GroupBox6"
Me.GroupBox6.Size = New System.Drawing.Size(195, 181)
Me.GroupBox6.TabIndex = 156
Me.GroupBox6.TabStop = false
Me.GroupBox6.Text = "Stats"
'
'Label4
'
Me.Label4.AutoSize = true
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label4.Location = New System.Drawing.Point(6, 19)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(75, 13)
Me.Label4.TabIndex = 147
Me.Label4.Text = "Stroking Time:"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLAvgEdgeStroking
'
Me.LBLAvgEdgeStroking.AutoSize = true
Me.LBLAvgEdgeStroking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLAvgEdgeStroking.Location = New System.Drawing.Point(142, 85)
Me.LBLAvgEdgeStroking.Name = "LBLAvgEdgeStroking"
Me.LBLAvgEdgeStroking.Size = New System.Drawing.Size(36, 15)
Me.LBLAvgEdgeStroking.TabIndex = 144
Me.LBLAvgEdgeStroking.Text = "00:00"
Me.LBLAvgEdgeStroking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLStrokeTimeTotal
'
Me.LBLStrokeTimeTotal.Location = New System.Drawing.Point(106, 17)
Me.LBLStrokeTimeTotal.Name = "LBLStrokeTimeTotal"
Me.LBLStrokeTimeTotal.Size = New System.Drawing.Size(77, 17)
Me.LBLStrokeTimeTotal.TabIndex = 148
Me.LBLStrokeTimeTotal.Text = "0000:00:00:00"
Me.LBLStrokeTimeTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label94
'
Me.Label94.AutoSize = true
Me.Label94.BackColor = System.Drawing.Color.Transparent
Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label94.ForeColor = System.Drawing.Color.Black
Me.Label94.Location = New System.Drawing.Point(6, 63)
Me.Label94.Name = "Label94"
Me.Label94.Size = New System.Drawing.Size(64, 13)
Me.Label94.TabIndex = 150
Me.Label94.Text = "Last Ruined"
Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLLastRuined
'
Me.LBLLastRuined.Location = New System.Drawing.Point(111, 61)
Me.LBLLastRuined.Name = "LBLLastRuined"
Me.LBLLastRuined.Size = New System.Drawing.Size(75, 17)
Me.LBLLastRuined.TabIndex = 152
Me.LBLLastRuined.Text = "04/28/2015"
Me.LBLLastRuined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label65
'
Me.Label65.AutoSize = true
Me.Label65.BackColor = System.Drawing.Color.Transparent
Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label65.ForeColor = System.Drawing.Color.Black
Me.Label65.Location = New System.Drawing.Point(6, 41)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(66, 13)
Me.Label65.TabIndex = 149
Me.Label65.Text = "Last Orgasm"
Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLAvgEdgeNoTouch
'
Me.LBLAvgEdgeNoTouch.AutoSize = true
Me.LBLAvgEdgeNoTouch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LBLAvgEdgeNoTouch.Location = New System.Drawing.Point(142, 107)
Me.LBLAvgEdgeNoTouch.Name = "LBLAvgEdgeNoTouch"
Me.LBLAvgEdgeNoTouch.Size = New System.Drawing.Size(36, 15)
Me.LBLAvgEdgeNoTouch.TabIndex = 146
Me.LBLAvgEdgeNoTouch.Text = "00:00"
Me.LBLAvgEdgeNoTouch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'LBLLastOrgasm
'
Me.LBLLastOrgasm.Location = New System.Drawing.Point(111, 39)
Me.LBLLastOrgasm.Name = "LBLLastOrgasm"
Me.LBLLastOrgasm.Size = New System.Drawing.Size(75, 17)
Me.LBLLastOrgasm.TabIndex = 151
Me.LBLLastOrgasm.Text = "04/28/2015"
Me.LBLLastOrgasm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label14
'
Me.Label14.AutoSize = true
Me.Label14.BackColor = System.Drawing.Color.Transparent
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label14.ForeColor = System.Drawing.Color.Black
Me.Label14.Location = New System.Drawing.Point(6, 85)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(131, 13)
Me.Label14.TabIndex = 138
Me.Label14.Text = "Avg Edge Time (Stroking):"
Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'GroupBox21
'
Me.GroupBox21.BackColor = System.Drawing.Color.LightGray
Me.GroupBox21.Controls.Add(Me.Label153)
Me.GroupBox21.Controls.Add(Me.LBLRangeSettingsDescription)
Me.GroupBox21.Controls.Add(Me.Label156)
Me.GroupBox21.ForeColor = System.Drawing.Color.Black
Me.GroupBox21.Location = New System.Drawing.Point(1143, 163)
Me.GroupBox21.Name = "GroupBox21"
Me.GroupBox21.Size = New System.Drawing.Size(316, 216)
Me.GroupBox21.TabIndex = 66
Me.GroupBox21.TabStop = false
Me.GroupBox21.Text = "Description"
'
'Label153
'
Me.Label153.BackColor = System.Drawing.Color.Transparent
Me.Label153.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Label153.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label153.ForeColor = System.Drawing.Color.Black
Me.Label153.Location = New System.Drawing.Point(78, 94)
Me.Label153.Name = "Label153"
Me.Label153.Size = New System.Drawing.Size(158, 17)
Me.Label153.TabIndex = 135
Me.Label153.Text = "No path selected"
Me.Label153.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LBLRangeSettingsDescription
'
Me.LBLRangeSettingsDescription.BackColor = System.Drawing.Color.Transparent
Me.LBLRangeSettingsDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLRangeSettingsDescription.ForeColor = System.Drawing.Color.Black
Me.LBLRangeSettingsDescription.Location = New System.Drawing.Point(6, 16)
Me.LBLRangeSettingsDescription.Name = "LBLRangeSettingsDescription"
Me.LBLRangeSettingsDescription.Size = New System.Drawing.Size(680, 117)
Me.LBLRangeSettingsDescription.TabIndex = 62
Me.LBLRangeSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its functio"& _ 
    "n."
Me.LBLRangeSettingsDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label156
'
Me.Label156.BackColor = System.Drawing.Color.Transparent
Me.Label156.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Label156.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label156.ForeColor = System.Drawing.Color.Black
Me.Label156.Location = New System.Drawing.Point(133, 23)
Me.Label156.Name = "Label156"
Me.Label156.Size = New System.Drawing.Size(158, 17)
Me.Label156.TabIndex = 135
Me.Label156.Text = "No path selected"
Me.Label156.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'GroupBox12
'
Me.GroupBox12.BackColor = System.Drawing.Color.LightGray
Me.GroupBox12.Controls.Add(Me.LBLSubSettingsDescription)
Me.GroupBox12.ForeColor = System.Drawing.Color.Black
Me.GroupBox12.Location = New System.Drawing.Point(1299, 163)
Me.GroupBox12.Name = "GroupBox12"
Me.GroupBox12.Size = New System.Drawing.Size(171, 124)
Me.GroupBox12.TabIndex = 65
Me.GroupBox12.TabStop = false
Me.GroupBox12.Text = "Description"
'
'LBLSubSettingsDescription
'
Me.LBLSubSettingsDescription.BackColor = System.Drawing.Color.Transparent
Me.LBLSubSettingsDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.LBLSubSettingsDescription.ForeColor = System.Drawing.Color.Black
Me.LBLSubSettingsDescription.Location = New System.Drawing.Point(10, 19)
Me.LBLSubSettingsDescription.Name = "LBLSubSettingsDescription"
Me.LBLSubSettingsDescription.Size = New System.Drawing.Size(150, 89)
Me.LBLSubSettingsDescription.TabIndex = 62
Me.LBLSubSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its functio"& _ 
    "n."
'
'OpenFileDialog1
'
Me.OpenFileDialog1.FileName = "OpenFileDialog1"
Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file"& _ 
    "s (*.*)|*.*"
Me.OpenFileDialog1.Title = "Select an image file"
'
'GetColor
'
Me.GetColor.Color = System.Drawing.Color.SteelBlue
'
'WebImageFileDialog
'
Me.WebImageFileDialog.Filter = "TXT Files (*.txt)|*.txt"
Me.WebImageFileDialog.Title = "Please select a URL File"
'
'OpenScriptDialog
'
Me.OpenScriptDialog.Filter = "TXT Files (*.txt)|*.txt"
Me.OpenScriptDialog.Title = "Please select a script"
'
'OpenSettingsDialog
'
Me.OpenSettingsDialog.Filter = "TXT Files (*.txt)|*.txt"
Me.OpenSettingsDialog.Title = "Please select a settings file to open"
'
'SaveSettingsDialog
'
Me.SaveSettingsDialog.Filter = "TXT Files (*.txt)|*.txt"
Me.SaveSettingsDialog.Title = "Select a location to save current Domme settings"
'
'GroupBox65
'
Me.GroupBox65.BackColor = System.Drawing.Color.LightGray
Me.GroupBox65.Controls.Add(Me.Label136)
Me.GroupBox65.Controls.Add(Me.Label134)
Me.GroupBox65.Controls.Add(Me.Label132)
Me.GroupBox65.Controls.Add(Me.TrackBar1)
Me.GroupBox65.Controls.Add(Me.ComboBox1)
Me.GroupBox65.Controls.Add(Me.CheckBox1)
Me.GroupBox65.Controls.Add(Me.Label135)
Me.GroupBox65.Controls.Add(Me.TrackBar2)
Me.GroupBox65.ForeColor = System.Drawing.Color.Black
Me.GroupBox65.Location = New System.Drawing.Point(1166, 28)
Me.GroupBox65.Name = "GroupBox65"
Me.GroupBox65.Size = New System.Drawing.Size(259, 117)
Me.GroupBox65.TabIndex = 157
Me.GroupBox65.TabStop = false
Me.GroupBox65.Text = "Text to Speech"
'
'Label136
'
Me.Label136.AutoSize = true
Me.Label136.Location = New System.Drawing.Point(14, 52)
Me.Label136.Name = "Label136"
Me.Label136.Size = New System.Drawing.Size(45, 13)
Me.Label136.TabIndex = 32
Me.Label136.Text = "Volume:"
'
'Label134
'
Me.Label134.AutoSize = true
Me.Label134.Location = New System.Drawing.Point(141, 52)
Me.Label134.Name = "Label134"
Me.Label134.Size = New System.Drawing.Size(33, 13)
Me.Label134.TabIndex = 157
Me.Label134.Text = "Rate:"
'
'Label132
'
Me.Label132.Location = New System.Drawing.Point(202, 52)
Me.Label132.Name = "Label132"
Me.Label132.Size = New System.Drawing.Size(45, 13)
Me.Label132.TabIndex = 158
Me.Label132.Text = "100"
Me.Label132.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'TrackBar1
'
Me.TrackBar1.Location = New System.Drawing.Point(133, 68)
Me.TrackBar1.Minimum = -10
Me.TrackBar1.Name = "TrackBar1"
Me.TrackBar1.Size = New System.Drawing.Size(120, 45)
Me.TrackBar1.TabIndex = 31
'
'ComboBox1
'
Me.ComboBox1.BackColor = System.Drawing.SystemColors.Window
Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
Me.ComboBox1.FormattingEnabled = true
Me.ComboBox1.Location = New System.Drawing.Point(71, 16)
Me.ComboBox1.Name = "ComboBox1"
Me.ComboBox1.Size = New System.Drawing.Size(178, 21)
Me.ComboBox1.TabIndex = 29
Me.ComboBox1.TabStop = false
'
'CheckBox1
'
Me.CheckBox1.AutoSize = true
Me.CheckBox1.ForeColor = System.Drawing.Color.Black
Me.CheckBox1.Location = New System.Drawing.Point(10, 18)
Me.CheckBox1.Name = "CheckBox1"
Me.CheckBox1.Size = New System.Drawing.Size(59, 17)
Me.CheckBox1.TabIndex = 28
Me.CheckBox1.TabStop = false
Me.CheckBox1.Text = "Enable"
Me.CheckBox1.UseVisualStyleBackColor = true
'
'Label135
'
Me.Label135.Location = New System.Drawing.Point(75, 52)
Me.Label135.Name = "Label135"
Me.Label135.Size = New System.Drawing.Size(45, 13)
Me.Label135.TabIndex = 33
Me.Label135.Text = "100"
Me.Label135.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'TrackBar2
'
Me.TrackBar2.Location = New System.Drawing.Point(6, 68)
Me.TrackBar2.Maximum = 100
Me.TrackBar2.Name = "TrackBar2"
Me.TrackBar2.Size = New System.Drawing.Size(120, 45)
Me.TrackBar2.TabIndex = 30
Me.TrackBar2.Value = 50
'
'TxbImgUrlHardcore
'
Me.TxbImgUrlHardcore.BackColor = System.Drawing.Color.LightGray
Me.TxbImgUrlHardcore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TxbImgUrlHardcore.Dock = System.Windows.Forms.DockStyle.Fill
Me.TxbImgUrlHardcore.Location = New System.Drawing.Point(116, 6)
Me.TxbImgUrlHardcore.Name = "TxbImgUrlHardcore"
Me.TxbImgUrlHardcore.ReadOnly = true
Me.TxbImgUrlHardcore.Size = New System.Drawing.Size(189, 20)
Me.TxbImgUrlHardcore.TabIndex = 145
'
'TextBox2
'
Me.TextBox2.BackColor = System.Drawing.Color.LightGray
Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
Me.TextBox2.Location = New System.Drawing.Point(116, 34)
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.ReadOnly = true
Me.TextBox2.Size = New System.Drawing.Size(189, 20)
Me.TextBox2.TabIndex = 145
'
'Label171
'
Me.Label171.AutoSize = true
Me.Label171.BackColor = System.Drawing.Color.Transparent
Me.Label171.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label171.ForeColor = System.Drawing.Color.Black
Me.Label171.Location = New System.Drawing.Point(6, 107)
Me.Label171.Name = "Label171"
Me.Label171.Size = New System.Drawing.Size(114, 13)
Me.Label171.TabIndex = 153
Me.Label171.Text = "Avg Edge Time (Rest):"
Me.Label171.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'BWURLFiles
'
Me.BWURLFiles.DislikeListPath = "Images\System\DislikedImageURLs.txt"
Me.BWURLFiles.ImageURLFileDir = "Images\System\URL Files\"
Me.BWURLFiles.LikeListPath = "Images\System\LikedImageURLs.txt"
Me.BWURLFiles.WorkerReportsProgress = true
Me.BWURLFiles.WorkerSupportsCancellation = true
'
'FrmSettings
'
Me.AllowDrop = true
Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(727, 465)
Me.Controls.Add(Me.GroupBox65)
Me.Controls.Add(Me.GroupBox44)
Me.Controls.Add(Me.GroupBox47)
Me.Controls.Add(Me.BtnRandomImageDirClear)
Me.Controls.Add(Me.SettingsPanel)
Me.Controls.Add(Me.GroupBox12)
Me.Controls.Add(Me.GroupBox21)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
Me.MaximizeBox = false
Me.MinimizeBox = false
Me.Name = "FrmSettings"
Me.ShowIcon = false
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Tease AI Settings"
Me.SettingsPanel.ResumeLayout(false)
Me.SettingsTabs.ResumeLayout(false)
Me.TabPage1.ResumeLayout(false)
Me.PNLGeneralSettings.ResumeLayout(false)
Me.PNLGeneralSettings.PerformLayout
Me.GroupBox3.ResumeLayout(false)
Me.GroupBox2.ResumeLayout(false)
Me.GroupBox2.PerformLayout
Me.GroupBox64.ResumeLayout(false)
Me.GroupBox64.PerformLayout
Me.GBDommeImages.ResumeLayout(false)
Me.GBDommeImages.PerformLayout
CType(Me.slideshowNumBox,System.ComponentModel.ISupportInitialize).EndInit
Me.GBGeneralTextToSpeech.ResumeLayout(false)
Me.GBGeneralTextToSpeech.PerformLayout
CType(Me.SliderVRate,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SliderVVolume,System.ComponentModel.ISupportInitialize).EndInit
Me.GBSafeword.ResumeLayout(false)
Me.GBSafeword.PerformLayout
Me.GBGeneralSystem.ResumeLayout(false)
Me.GBGeneralSystem.PerformLayout
Me.GBGeneralImages.ResumeLayout(false)
Me.GBGeneralImages.PerformLayout
CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
Me.GBGeneralSettings.ResumeLayout(false)
Me.GBGeneralSettings.PerformLayout
Me.GBSubFont.ResumeLayout(false)
CType(Me.NBFontSize,System.ComponentModel.ISupportInitialize).EndInit
Me.GBDommeFont.ResumeLayout(false)
CType(Me.NBFontSizeD,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage2.ResumeLayout(false)
Me.Panel3.ResumeLayout(false)
Me.Panel3.PerformLayout
Me.GBGiveUp.ResumeLayout(false)
Me.GBGiveUp.PerformLayout
CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).EndInit
Me.GBDomTypingStyle.ResumeLayout(false)
Me.GBDomTypingStyle.PerformLayout
CType(Me.NBTypoChance,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox63.ResumeLayout(false)
Me.GroupBox63.PerformLayout
Me.GBDomRanges.ResumeLayout(false)
CType(Me.NBDomMoodMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBDomMoodMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBSubAgeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBSubAgeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBSelfAgeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBSelfAgeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBAvgCockMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBAvgCockMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GBDomStats.ResumeLayout(false)
Me.GBDomStats.PerformLayout
CType(Me.NBEmpathy,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBDomBirthdayDay,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.domageNumBox,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBDomBirthdayMonth,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.domlevelNumBox,System.ComponentModel.ISupportInitialize).EndInit
Me.GBDomPersonality.ResumeLayout(false)
Me.GBDomPersonality.PerformLayout
Me.GBDomOrgasms.ResumeLayout(false)
Me.GBDomOrgasms.PerformLayout
CType(Me.orgasmsPerNumBox,System.ComponentModel.ISupportInitialize).EndInit
Me.GBDomPetNames.ResumeLayout(false)
Me.GBDomPetNames.PerformLayout
Me.TabPage10.ResumeLayout(false)
Me.Panel2.ResumeLayout(false)
Me.GroupBox22.ResumeLayout(false)
CType(Me.NBWritingTaskMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBWritingTaskMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox45.ResumeLayout(false)
CType(Me.CBTSlider,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox35.ResumeLayout(false)
Me.GroupBoxSorry.ResumeLayout(false)
Me.GroupBoxSorry.PerformLayout
Me.GroupBox39.ResumeLayout(false)
Me.GroupBox39.PerformLayout
Me.GroupBox38.ResumeLayout(false)
Me.GroupBox38.PerformLayout
Me.GroupBox37.ResumeLayout(false)
Me.GroupBox37.PerformLayout
Me.GroupBox36.ResumeLayout(false)
Me.GroupBox36.PerformLayout
Me.GroupBox13.ResumeLayout(false)
Me.GroupBox7.ResumeLayout(false)
Me.GroupBox7.PerformLayout
CType(Me.NBExtremeHoldMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBExtremeHoldMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBLongHoldMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBLongHoldMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBLongEdge,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBHoldTheEdgeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBHoldTheEdgeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.PictureBox12,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox32.ResumeLayout(false)
Me.GroupBox32.PerformLayout
CType(Me.NBBirthdayDay,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.subAgeNumBox,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBBirthdayMonth,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.CockSizeNumBox,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage16.ResumeLayout(false)
Me.Panel9.ResumeLayout(false)
Me.GroupBox31.ResumeLayout(false)
Me.TCScripts.ResumeLayout(false)
Me.TabPage21.ResumeLayout(false)
Me.TabPage17.ResumeLayout(false)
Me.TabPage18.ResumeLayout(false)
Me.TabPage19.ResumeLayout(false)
Me.GroupBox42.ResumeLayout(false)
CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox43.ResumeLayout(false)
Me.TabPage7.ResumeLayout(false)
Me.TabControl4.ResumeLayout(false)
Me.TpImagesUrlFiles.ResumeLayout(false)
Me.TpImagesUrlFiles.PerformLayout
Me.GroupBox66.ResumeLayout(false)
CType(Me.PBURLPreview,System.ComponentModel.ISupportInitialize).EndInit
Me.TpImagesGenre.ResumeLayout(false)
Me.GrbImageUrlFiles.ResumeLayout(false)
Me.TlpImageUrls.ResumeLayout(false)
Me.TlpImageUrls.PerformLayout
Me.GbxImagesGenre.ResumeLayout(false)
Me.TableLayoutPanel1.ResumeLayout(false)
Me.TableLayoutPanel1.PerformLayout
Me.TabPage33.ResumeLayout(false)
Me.TabControl5.ResumeLayout(false)
Me.TabPage34.ResumeLayout(false)
Me.TabPage34.PerformLayout
CType(Me.ImageTagPictureBox,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage35.ResumeLayout(false)
Me.TabPage35.PerformLayout
Me.GroupBox55.ResumeLayout(false)
Me.GroupBox55.PerformLayout
Me.GroupBox53.ResumeLayout(false)
Me.GroupBox53.PerformLayout
Me.GroupBox49.ResumeLayout(false)
Me.GroupBox49.PerformLayout
Me.GroupBox46.ResumeLayout(false)
Me.GroupBox46.PerformLayout
Me.GroupBox54.ResumeLayout(false)
Me.GroupBox54.PerformLayout
Me.GroupBox51.ResumeLayout(false)
Me.GroupBox51.PerformLayout
Me.GroupBox50.ResumeLayout(false)
Me.GroupBox50.PerformLayout
Me.GroupBox48.ResumeLayout(false)
Me.GroupBox48.PerformLayout
Me.TabPage11.ResumeLayout(false)
Me.Panel7.ResumeLayout(false)
Me.Panel7.PerformLayout
CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.WebPictureBox,System.ComponentModel.ISupportInitialize).EndInit
Me.TpVideoSettings.ResumeLayout(false)
Me.PnlVideoSettings.ResumeLayout(false)
CType(Me.PbBannerVideoSettings,System.ComponentModel.ISupportInitialize).EndInit
Me.GbxVideoGeneralD.ResumeLayout(false)
Me.GbxVideoGeneralD.PerformLayout
Me.GbxVideoSpecialD.ResumeLayout(false)
Me.GbxVideoSpecialD.PerformLayout
Me.GbxVideoGenreD.ResumeLayout(false)
Me.GbxVideoGenreD.PerformLayout
Me.GbxVideoDescription.ResumeLayout(false)
Me.GbxVideoGeneral.ResumeLayout(false)
Me.GbxVideoGeneral.PerformLayout
Me.GbxVideoSpecial.ResumeLayout(false)
Me.GbxVideoSpecial.PerformLayout
Me.GbxVideoGenre.ResumeLayout(false)
Me.GbxVideoGenre.PerformLayout
Me.TabPage20.ResumeLayout(false)
Me.TabControl1.ResumeLayout(false)
Me.TabPage22.ResumeLayout(false)
Me.PNLGlitter.ResumeLayout(false)
Me.PNLGlitter.PerformLayout
Me.GroupBox14.ResumeLayout(false)
Me.GroupBox14.PerformLayout
Me.GroupBox4.ResumeLayout(false)
Me.GBGlitterD.ResumeLayout(false)
Me.GBGlitterD.PerformLayout
Me.GrbGlitterfeed.ResumeLayout(false)
Me.GrbGlitterfeed.PerformLayout
CType(Me.GlitterSlider,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GlitterAV,System.ComponentModel.ISupportInitialize).EndInit
Me.GBGlitter1.ResumeLayout(false)
Me.GBGlitter1.PerformLayout
CType(Me.GlitterSlider1,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GlitterAV1,System.ComponentModel.ISupportInitialize).EndInit
Me.GBGlitter3.ResumeLayout(false)
Me.GBGlitter3.PerformLayout
CType(Me.GlitterSlider3,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GlitterAV3,System.ComponentModel.ISupportInitialize).EndInit
Me.GBGlitter2.ResumeLayout(false)
Me.GBGlitter2.PerformLayout
CType(Me.GlitterSlider2,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GlitterAV2,System.ComponentModel.ISupportInitialize).EndInit
Me.TpGames.ResumeLayout(false)
Me.TpGames.PerformLayout
Me.GbxCardsGold.ResumeLayout(false)
Me.GbxCardsGold.PerformLayout
CType(Me.GP6,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GP2,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GP5,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GP1,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GP3,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.GP4,System.ComponentModel.ISupportInitialize).EndInit
Me.GbxCardsBackground.ResumeLayout(false)
CType(Me.CardBack,System.ComponentModel.ISupportInitialize).EndInit
Me.GbxCardsBronze.ResumeLayout(false)
Me.GbxCardsBronze.PerformLayout
CType(Me.BP3,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.BP6,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.BP5,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.BP2,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.BP4,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.BP1,System.ComponentModel.ISupportInitialize).EndInit
Me.GbxCardsSilver.ResumeLayout(false)
Me.GbxCardsSilver.PerformLayout
CType(Me.SP6,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SP2,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SP5,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SP1,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SP3,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SP4,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage6.ResumeLayout(false)
Me.Panel10.ResumeLayout(false)
Me.Panel10.PerformLayout
CType(Me.NBWishlistCost,System.ComponentModel.ISupportInitialize).EndInit
Me.PNLWishList.ResumeLayout(false)
CType(Me.WishlistCostSilver,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.WishlistCostGold,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.WishlistPreview,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage26.ResumeLayout(false)
Me.Panel12.ResumeLayout(false)
Me.GroupBox9.ResumeLayout(false)
CType(Me.PictureBox10,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox5.ResumeLayout(false)
Me.GroupBox5.PerformLayout
Me.GroupBox11.ResumeLayout(false)
Me.GroupBox1.ResumeLayout(false)
CType(Me.PBBackgroundPreview,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage4.ResumeLayout(false)
Me.Panel6.ResumeLayout(false)
Me.GroupBox69.ResumeLayout(false)
Me.GroupBox69.PerformLayout
CType(Me.TypeSpeedSlider,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox68.ResumeLayout(false)
CType(Me.NBTasksMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTasksMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox67.ResumeLayout(false)
CType(Me.NBTaskCBTTimeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskCBTTimeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskEdgeHoldTimeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskEdgeHoldTimeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskEdgesMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskEdgesMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskStrokingTimeMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskStrokingTimeMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskStrokesMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTaskStrokesMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox10.ResumeLayout(false)
CType(Me.NBNextImageChance,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox57.ResumeLayout(false)
Me.GroupBox57.PerformLayout
CType(Me.NBTauntEdging,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.SliderSTF,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.TauntSlider,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTauntCycleMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTauntCycleMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTeaseLengthMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBTeaseLengthMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GBRangeRuinChance.ResumeLayout(false)
Me.GBRangeRuinChance.PerformLayout
CType(Me.NBRuinSometimes,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBRuinRarely,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBRuinOften,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox17.ResumeLayout(false)
Me.GroupBox19.ResumeLayout(false)
CType(Me.NBGreenLightMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBGreenLightMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBRedLightMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBRedLightMin,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox18.ResumeLayout(false)
Me.GroupBox18.PerformLayout
CType(Me.NBCensorShowMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBCensorHideMax,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBCensorHideMin,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBCensorShowMax,System.ComponentModel.ISupportInitialize).EndInit
Me.GBRangeOrgasmChance.ResumeLayout(false)
Me.GBRangeOrgasmChance.PerformLayout
CType(Me.NBAllowSometimes,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBAllowRarely,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.NBAllowOften,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.PictureBox8,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage13.ResumeLayout(false)
Me.TabControl2.ResumeLayout(false)
Me.TabPage27.ResumeLayout(false)
Me.TabPage27.PerformLayout
Me.TabPage14.ResumeLayout(false)
Me.TabPage14.PerformLayout
Me.TabPage24.ResumeLayout(false)
Me.TabPage24.PerformLayout
Me.TabPage8.ResumeLayout(false)
Me.GroupBox29.ResumeLayout(false)
Me.GroupBox28.ResumeLayout(false)
Me.GroupBox30.ResumeLayout(false)
Me.TabPage15.ResumeLayout(false)
Me.TabPage15.PerformLayout
Me.GroupBox34.ResumeLayout(false)
Me.TabPage25.ResumeLayout(false)
Me.Panel11.ResumeLayout(false)
Me.GroupBox62.ResumeLayout(false)
Me.GroupBox62.PerformLayout
Me.GroupBox33.ResumeLayout(false)
Me.GroupBox8.ResumeLayout(false)
Me.GroupBox8.PerformLayout
Me.GroupBox27.ResumeLayout(false)
Me.GroupBox27.PerformLayout
Me.GroupBox20.ResumeLayout(false)
Me.GroupBox20.PerformLayout
Me.GroupBox15.ResumeLayout(false)
Me.GroupBox15.PerformLayout
CType(Me.PictureBox9,System.ComponentModel.ISupportInitialize).EndInit
Me.TabPage28.ResumeLayout(false)
Me.TabControl3.ResumeLayout(false)
Me.TabPage29.ResumeLayout(false)
Me.GroupBox26.ResumeLayout(false)
Me.GroupBox26.PerformLayout
Me.TabPage30.ResumeLayout(false)
Me.TabPage5.ResumeLayout(false)
Me.Panel5.ResumeLayout(false)
Me.Panel5.PerformLayout
CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox47.ResumeLayout(false)
Me.GroupBox41.ResumeLayout(false)
Me.GroupBox44.ResumeLayout(false)
Me.GroupBox6.ResumeLayout(false)
Me.GroupBox6.PerformLayout
Me.GroupBox21.ResumeLayout(false)
Me.GroupBox12.ResumeLayout(false)
Me.GroupBox65.ResumeLayout(false)
Me.GroupBox65.PerformLayout
CType(Me.TrackBar1,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.TrackBar2,System.ComponentModel.ISupportInitialize).EndInit
Me.ResumeLayout(false)

End Sub
	Friend WithEvents SettingsPanel As System.Windows.Forms.Panel
	Friend WithEvents SettingsTabs As System.Windows.Forms.TabControl
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
	Friend WithEvents PNLGeneralSettings As System.Windows.Forms.Panel
	Friend WithEvents GBSafeword As System.Windows.Forms.GroupBox
	Friend WithEvents LBLSubColor As System.Windows.Forms.Label
	Friend WithEvents BTNSubColor As System.Windows.Forms.Button
	Friend WithEvents BTNDomColor As System.Windows.Forms.Button
	Friend WithEvents LBLDomColor As System.Windows.Forms.Label
	Friend WithEvents GBGeneralSystem As System.Windows.Forms.GroupBox
	Friend WithEvents CBSettingsPause As System.Windows.Forms.CheckBox
	Friend WithEvents CBSaveChatlogExit As System.Windows.Forms.CheckBox
	Friend WithEvents CBAutosaveChatlog As System.Windows.Forms.CheckBox
	Friend WithEvents GBGeneralImages As System.Windows.Forms.GroupBox
	Friend WithEvents CBSlideshowRandom As System.Windows.Forms.CheckBox
	Friend WithEvents landscapeCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents CBBlogImageWindow As System.Windows.Forms.CheckBox
	Friend WithEvents CBSlideshowSubDir As System.Windows.Forms.CheckBox
	Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
	Friend WithEvents GBGeneralTextToSpeech As System.Windows.Forms.GroupBox
	Friend WithEvents TTSCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents TTSComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents GBGeneralSettings As System.Windows.Forms.GroupBox
	Friend WithEvents CBInputIcon As System.Windows.Forms.CheckBox
	Friend WithEvents typeinstantlyCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents timestampCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents shownamesCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents LBLGeneralSettings As System.Windows.Forms.Label
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents Panel3 As System.Windows.Forms.Panel
	Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
	Friend WithEvents GBDomRanges As System.Windows.Forms.GroupBox
	Friend WithEvents NBDomMoodMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBDomMoodMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label37 As System.Windows.Forms.Label
	Friend WithEvents Label39 As System.Windows.Forms.Label
	Friend WithEvents NBSubAgeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBSubAgeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label31 As System.Windows.Forms.Label
	Friend WithEvents Label36 As System.Windows.Forms.Label
	Friend WithEvents NBSelfAgeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBSelfAgeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents Label22 As System.Windows.Forms.Label
	Friend WithEvents NBAvgCockMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBAvgCockMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label23 As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents GBDomStats As System.Windows.Forms.GroupBox
	Friend WithEvents boobComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents DomLevelDescLabel As System.Windows.Forms.Label
	Friend WithEvents domageNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents domlevelNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label43 As System.Windows.Forms.Label
	Friend WithEvents Label44 As System.Windows.Forms.Label
	Friend WithEvents Label45 As System.Windows.Forms.Label
	Friend WithEvents Label46 As System.Windows.Forms.Label
	Friend WithEvents Label47 As System.Windows.Forms.Label
	Friend WithEvents Label54 As System.Windows.Forms.Label
	Friend WithEvents GBDomPersonality As System.Windows.Forms.GroupBox
	Friend WithEvents supremacistCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents vulgarCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents crazyCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents GBDomTypingStyle As System.Windows.Forms.GroupBox
	Friend WithEvents CBMeMyMine As System.Windows.Forms.CheckBox
	Friend WithEvents apostropheCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents LCaseCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents periodCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents commaCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents GBDomOrgasms As System.Windows.Forms.GroupBox
	Friend WithEvents orgasmlockrandombutton As System.Windows.Forms.Button
	Friend WithEvents CBDomOrgasmEnds As System.Windows.Forms.CheckBox
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents orgasmsperlockButton As System.Windows.Forms.Button
	Friend WithEvents orgasmsperComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents orgasmsperLabel As System.Windows.Forms.Label
	Friend WithEvents limitcheckbox As System.Windows.Forms.CheckBox
	Friend WithEvents orgasmsPerNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents CBDomDenialEnds As System.Windows.Forms.CheckBox
	Friend WithEvents alloworgasmComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents ruinorgasmComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents GBDomPetNames As System.Windows.Forms.GroupBox
	Friend WithEvents petnameBox7 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox1 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox4 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox8 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox2 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox6 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox5 As System.Windows.Forms.TextBox
	Friend WithEvents petnameBox3 As System.Windows.Forms.TextBox
	Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox39 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBoxSorry As System.Windows.Forms.GroupBox
	Friend WithEvents TBSorry As System.Windows.Forms.TextBox
	Friend WithEvents CBHonorificInclude As System.Windows.Forms.CheckBox
	Friend WithEvents CBHonorificCapitalized As System.Windows.Forms.CheckBox
	Friend WithEvents TBHonorific As System.Windows.Forms.TextBox
	Friend WithEvents G1Honorific As System.Windows.Forms.TextBox
	Friend WithEvents G2Honorific As System.Windows.Forms.TextBox
	Friend WithEvents G3Honorific As System.Windows.Forms.TextBox
	Friend WithEvents RandomHonorific As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox38 As System.Windows.Forms.GroupBox
	Friend WithEvents TBNo As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox37 As System.Windows.Forms.GroupBox
	Friend WithEvents TBYes As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
	Friend WithEvents TBGreeting As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
	Friend WithEvents NBWritingTaskMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBWritingTaskMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label75 As System.Windows.Forms.Label
	Friend WithEvents Label77 As System.Windows.Forms.Label
	Friend WithEvents NBHoldTheEdgeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label81 As System.Windows.Forms.Label
	Friend WithEvents NBLongEdge As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBLStrokeTimeTotal As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents LBLAvgEdgeNoTouch As System.Windows.Forms.Label
	Friend WithEvents LBLAvgEdgeStroking As System.Windows.Forms.Label
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
	Friend WithEvents LBLSubSettingsDescription As System.Windows.Forms.Label
	Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
	Friend WithEvents NBBirthdayDay As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label63 As System.Windows.Forms.Label
	Friend WithEvents LBLSubInches As System.Windows.Forms.Label
	Friend WithEvents subAgeNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBBirthdayMonth As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBLSubCockSize As System.Windows.Forms.Label
	Friend WithEvents CockSizeNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBLSubEye As System.Windows.Forms.Label
	Friend WithEvents LBLSubHair As System.Windows.Forms.Label
	Friend WithEvents LBLSubBirthday As System.Windows.Forms.Label
	Friend WithEvents LBLSubAge As System.Windows.Forms.Label
	Friend WithEvents Label70 As System.Windows.Forms.Label
	Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
	Friend WithEvents GroupBox44 As System.Windows.Forms.GroupBox
	Friend WithEvents Label100 As System.Windows.Forms.Label
	Friend WithEvents GroupBox47 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox41 As System.Windows.Forms.GroupBox
	Friend WithEvents CBButtSubDir As System.Windows.Forms.CheckBox
	Friend WithEvents TbxIButts As System.Windows.Forms.TextBox
	Friend WithEvents BTNButtPath As System.Windows.Forms.Button
	Friend WithEvents BtnImageUrlButt As System.Windows.Forms.Button
	Friend WithEvents GroupBox40 As System.Windows.Forms.GroupBox
	Friend WithEvents CBBoobSubDir As System.Windows.Forms.CheckBox
	Friend WithEvents TbxIBoobs As System.Windows.Forms.TextBox
	Friend WithEvents BTNBoobPath As System.Windows.Forms.Button
	Friend WithEvents BtnImageUrlBoobs As System.Windows.Forms.Button
	Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
	Friend WithEvents Panel7 As System.Windows.Forms.Panel
	Friend WithEvents BTNWIContinue As System.Windows.Forms.Button
	Friend WithEvents BTNWIAddandContinue As System.Windows.Forms.Button
	Friend WithEvents BTNWICancel As System.Windows.Forms.Button
	Friend WithEvents CBWIReview As System.Windows.Forms.CheckBox
	Friend WithEvents BTNWIBrowse As System.Windows.Forms.Button
	Friend WithEvents TBWIDirectory As System.Windows.Forms.TextBox
	Friend WithEvents BTNWIDisliked As System.Windows.Forms.Button
	Friend WithEvents BTNWILiked As System.Windows.Forms.Button
	Friend WithEvents BTNWIRemove As System.Windows.Forms.Button
	Friend WithEvents CBWISaveToDisk As System.Windows.Forms.CheckBox
	Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
	Friend WithEvents WebImageProgressBar As System.Windows.Forms.ProgressBar
	Friend WithEvents BTNWICreateURL As System.Windows.Forms.Button
	Friend WithEvents LBLWebImageCount As System.Windows.Forms.Label
	Friend WithEvents BTNWISave As System.Windows.Forms.Button
	Friend WithEvents BTNWIOpenURL As System.Windows.Forms.Button
	Friend WithEvents BTNWIPrevious As System.Windows.Forms.Button
	Friend WithEvents BTNWINext As System.Windows.Forms.Button
	Friend WithEvents WebPictureBox As System.Windows.Forms.PictureBox
	Friend WithEvents Label71 As System.Windows.Forms.Label
	Friend WithEvents TpVideoSettings As System.Windows.Forms.TabPage
	Friend WithEvents PnlVideoSettings As System.Windows.Forms.Panel
	Friend WithEvents PbBannerVideoSettings As System.Windows.Forms.PictureBox
	Friend WithEvents BTNRefreshVideos As System.Windows.Forms.Button
	Friend WithEvents GbxVideoGeneralD As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoGeneralTotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoGeneralD As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoGeneralD As System.Windows.Forms.Button
	Friend WithEvents CBVideoGeneralD As System.Windows.Forms.CheckBox
	Friend WithEvents GbxVideoSpecialD As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoCHTotalD As System.Windows.Forms.Label
	Friend WithEvents LblVideoJOITotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoCHD As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoJOID As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoCHD As System.Windows.Forms.Button
	Friend WithEvents BTNVideoJOID As System.Windows.Forms.Button
	Friend WithEvents CBVideoJOID As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoCHD As System.Windows.Forms.CheckBox
	Friend WithEvents GbxVideoGenreD As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoFemsubTotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoFemsubD As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoFemdomTotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoFemdomD As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoBlowjobD As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoBlowjobTotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoLesbianD As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoSoftCoreD As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoLesbianTotalD As System.Windows.Forms.Label
	Friend WithEvents TxbVideoHardCoreD As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoFemSubD As System.Windows.Forms.Button
	Friend WithEvents LblVideoSoftCoreTotalD As System.Windows.Forms.Label
	Friend WithEvents BTNVideoFemDomD As System.Windows.Forms.Button
	Friend WithEvents BTNVideoBlowjobD As System.Windows.Forms.Button
	Friend WithEvents LblVideoHardCoreTotalD As System.Windows.Forms.Label
	Friend WithEvents BTNVideoLesbianD As System.Windows.Forms.Button
	Friend WithEvents BTNVideoSoftCoreD As System.Windows.Forms.Button
	Friend WithEvents BTNVideoHardCoreD As System.Windows.Forms.Button
	Friend WithEvents CBVideoHardcoreD As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoSoftCoreD As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoLesbianD As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoBlowjobD As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoFemsubD As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoFemdomD As System.Windows.Forms.CheckBox
	Friend WithEvents GbxVideoDescription As System.Windows.Forms.GroupBox
	Friend WithEvents VideoDescriptionLabel As System.Windows.Forms.Label
	Friend WithEvents GbxVideoGeneral As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoGeneralTotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoGeneral As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoGeneral As System.Windows.Forms.Button
	Friend WithEvents CBVideoGeneral As System.Windows.Forms.CheckBox
	Friend WithEvents GbxVideoSpecial As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoCHTotal As System.Windows.Forms.Label
	Friend WithEvents LblVideoJOITotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoCH As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoJOI As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoCH As System.Windows.Forms.Button
	Friend WithEvents BTNVideoJOI As System.Windows.Forms.Button
	Friend WithEvents CBVideoJOI As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoCH As System.Windows.Forms.CheckBox
	Friend WithEvents GbxVideoGenre As System.Windows.Forms.GroupBox
	Friend WithEvents LblVideoFemsubTotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoFemsub As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoFemdomTotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoFemdom As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoBlowjob As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoBlowjobTotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoLesbian As System.Windows.Forms.TextBox
	Friend WithEvents TxbVideoSoftCore As System.Windows.Forms.TextBox
	Friend WithEvents LblVideoLesbianTotal As System.Windows.Forms.Label
	Friend WithEvents TxbVideoHardCore As System.Windows.Forms.TextBox
	Friend WithEvents BTNVideoFemSub As System.Windows.Forms.Button
	Friend WithEvents LblVideoSoftCoreTotal As System.Windows.Forms.Label
	Friend WithEvents BTNVideoFemDom As System.Windows.Forms.Button
	Friend WithEvents BTNVideoBlowjob As System.Windows.Forms.Button
	Friend WithEvents LblVideoHardCoreTotal As System.Windows.Forms.Label
	Friend WithEvents BTNVideoLesbian As System.Windows.Forms.Button
	Friend WithEvents BTNVideoSoftCore As System.Windows.Forms.Button
	Friend WithEvents BTNVideoHardCore As System.Windows.Forms.Button
	Friend WithEvents CBVideoHardcore As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoSoftCore As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoLesbian As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoBlowjob As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoFemsub As System.Windows.Forms.CheckBox
	Friend WithEvents CBVideoFemdom As System.Windows.Forms.CheckBox
	Friend WithEvents LblVideoHeader As System.Windows.Forms.Label
	Friend WithEvents BTNVideoModClear As System.Windows.Forms.Button
	Friend WithEvents BTNVideoModLoad As System.Windows.Forms.Button
	Friend WithEvents BTNVideoModSave As System.Windows.Forms.Button
	Friend WithEvents RTBVideoMod As System.Windows.Forms.RichTextBox
	Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
	Friend WithEvents CBVTType As System.Windows.Forms.ComboBox
	Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
	Friend WithEvents Label51 As System.Windows.Forms.Label
	Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
	Friend WithEvents Panel6 As System.Windows.Forms.Panel
	Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
	Friend WithEvents LBLStf As System.Windows.Forms.Label
	Friend WithEvents Label49 As System.Windows.Forms.Label
	Friend WithEvents SliderSTF As System.Windows.Forms.TrackBar
	Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
	Friend WithEvents LBLRangeSettingsDescription As System.Windows.Forms.Label
	Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
	Friend WithEvents NBGreenLightMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBGreenLightMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label26 As System.Windows.Forms.Label
	Friend WithEvents Label27 As System.Windows.Forms.Label
	Friend WithEvents NBRedLightMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBRedLightMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label28 As System.Windows.Forms.Label
	Friend WithEvents Label29 As System.Windows.Forms.Label
	Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
	Friend WithEvents CBCensorConstant As System.Windows.Forms.CheckBox
	Friend WithEvents NBCensorHideMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBCensorHideMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents NBCensorShowMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBCensorShowMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label25 As System.Windows.Forms.Label
	Friend WithEvents Label24 As System.Windows.Forms.Label
	Friend WithEvents Label38 As System.Windows.Forms.Label
	Friend WithEvents PNLGlitter As System.Windows.Forms.Panel
	Friend WithEvents GBGlitterD As System.Windows.Forms.GroupBox
	Friend WithEvents BTNGlitterD As System.Windows.Forms.Button
	Friend WithEvents LBLGlitterNCDomme As System.Windows.Forms.Label
	Friend WithEvents LBLGlitterSlider As System.Windows.Forms.Label
	Friend WithEvents CBCustom2 As System.Windows.Forms.CheckBox
	Friend WithEvents GlitterSlider As System.Windows.Forms.TrackBar
	Friend WithEvents CBCustom1 As System.Windows.Forms.CheckBox
	Friend WithEvents CBDaily As System.Windows.Forms.CheckBox
	Friend WithEvents CBTrivia As System.Windows.Forms.CheckBox
	Friend WithEvents TBGlitterShortName As System.Windows.Forms.TextBox
	Friend WithEvents CBEgotist As System.Windows.Forms.CheckBox
	Friend WithEvents CBTease As System.Windows.Forms.CheckBox
	Friend WithEvents GlitterAV As System.Windows.Forms.PictureBox
	Friend WithEvents GBGlitter1 As System.Windows.Forms.GroupBox
	Friend WithEvents BTNGlitter1 As System.Windows.Forms.Button
	Friend WithEvents LBLGlitterNC1 As System.Windows.Forms.Label
	Friend WithEvents LBLGlitterSlider1 As System.Windows.Forms.Label
	Friend WithEvents GlitterSlider1 As System.Windows.Forms.TrackBar
	Friend WithEvents CBGlitter1 As System.Windows.Forms.CheckBox
	Friend WithEvents TBGlitter1 As System.Windows.Forms.TextBox
	Friend WithEvents GlitterAV1 As System.Windows.Forms.PictureBox
	Friend WithEvents GBGlitter3 As System.Windows.Forms.GroupBox
	Friend WithEvents BTNGlitter3 As System.Windows.Forms.Button
	Friend WithEvents LBLGlitterNC3 As System.Windows.Forms.Label
	Friend WithEvents LBLGlitterSlider3 As System.Windows.Forms.Label
	Friend WithEvents GlitterSlider3 As System.Windows.Forms.TrackBar
	Friend WithEvents CBGlitter3 As System.Windows.Forms.CheckBox
	Friend WithEvents TBGlitter3 As System.Windows.Forms.TextBox
	Friend WithEvents GlitterAV3 As System.Windows.Forms.PictureBox
	Friend WithEvents GBGlitter2 As System.Windows.Forms.GroupBox
	Friend WithEvents BTNGlitter2 As System.Windows.Forms.Button
	Friend WithEvents LBLGlitterNC2 As System.Windows.Forms.Label
	Friend WithEvents LBLGlitterSlider2 As System.Windows.Forms.Label
	Friend WithEvents GlitterSlider2 As System.Windows.Forms.TrackBar
	Friend WithEvents CBGlitter2 As System.Windows.Forms.CheckBox
	Friend WithEvents TBGlitter2 As System.Windows.Forms.TextBox
	Friend WithEvents GlitterAV2 As System.Windows.Forms.PictureBox
	Friend WithEvents Label62 As System.Windows.Forms.Label
	Friend WithEvents Label61 As System.Windows.Forms.Label
	Friend WithEvents Label60 As System.Windows.Forms.Label
	Friend WithEvents Button26 As System.Windows.Forms.Button
	Friend WithEvents LBLGlitModScriptCount As System.Windows.Forms.Label
	Friend WithEvents Label59 As System.Windows.Forms.Label
	Friend WithEvents CBGlitModType As System.Windows.Forms.ComboBox
	Friend WithEvents LBGlitModScripts As System.Windows.Forms.ListBox
	Friend WithEvents RTBGlitModDommePost As System.Windows.Forms.RichTextBox
	Friend WithEvents Label58 As System.Windows.Forms.Label
	Friend WithEvents Label57 As System.Windows.Forms.Label
	Friend WithEvents TBGlitModFileName As System.Windows.Forms.TextBox
	Friend WithEvents Label56 As System.Windows.Forms.Label
	Friend WithEvents LBLGlitModDomType As System.Windows.Forms.Label
	Friend WithEvents Label50 As System.Windows.Forms.Label
	Friend WithEvents Button29 As System.Windows.Forms.Button
	Friend WithEvents RTBGlitModResponses As System.Windows.Forms.RichTextBox
	Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
	Friend WithEvents Label52 As System.Windows.Forms.Label
	Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
	Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage14 As System.Windows.Forms.TabPage
	Friend WithEvents LBLKeywordPreview As System.Windows.Forms.Label
	Friend WithEvents TBKeywordPreview As System.Windows.Forms.TextBox
	Friend WithEvents Button37 As System.Windows.Forms.Button
	Friend WithEvents Button50 As System.Windows.Forms.Button
	Friend WithEvents Button22 As System.Windows.Forms.Button
	Friend WithEvents TBKeyWords As System.Windows.Forms.TextBox
	Friend WithEvents LBKeyWords As System.Windows.Forms.ListBox
	Friend WithEvents RTBKeyWords As System.Windows.Forms.RichTextBox
	Friend WithEvents TabPage15 As System.Windows.Forms.TabPage
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents GetColor As System.Windows.Forms.ColorDialog
	Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents WebImageFileDialog As System.Windows.Forms.OpenFileDialog
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents OpenScriptDialog As System.Windows.Forms.OpenFileDialog
	Friend WithEvents teaseRadio As System.Windows.Forms.RadioButton
	Friend WithEvents offRadio As System.Windows.Forms.RadioButton
	Friend WithEvents slideshowNumBox As System.Windows.Forms.NumericUpDown
	Friend WithEvents timedRadio As System.Windows.Forms.RadioButton
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents FontComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents NBFontSize As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents FontComboBoxD As System.Windows.Forms.ComboBox
	Friend WithEvents NBFontSizeD As System.Windows.Forms.NumericUpDown
	Friend WithEvents GBDommeFont As System.Windows.Forms.GroupBox
	Friend WithEvents GBSubFont As System.Windows.Forms.GroupBox
	Friend WithEvents dompubichairComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents domhairlengthComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents CBDomTattoos As System.Windows.Forms.CheckBox
	Friend WithEvents CBDomFreckles As System.Windows.Forms.CheckBox
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents Label74 As System.Windows.Forms.Label
	Friend WithEvents NBDomBirthdayDay As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label76 As System.Windows.Forms.Label
	Friend WithEvents NBDomBirthdayMonth As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label84 As System.Windows.Forms.Label
	Friend WithEvents CBImageInfo As System.Windows.Forms.CheckBox
	Friend WithEvents Label88 As System.Windows.Forms.Label
	Friend WithEvents URLFileList As System.Windows.Forms.CheckedListBox
	Friend WithEvents TbxIMaledom As System.Windows.Forms.TextBox
	Friend WithEvents TbxIGay As System.Windows.Forms.TextBox
	Friend WithEvents TbxIHentai As System.Windows.Forms.TextBox
	Friend WithEvents BTNIMaledom As System.Windows.Forms.Button
	Friend WithEvents BTNIGay As System.Windows.Forms.Button
	Friend WithEvents BTNIHentai As System.Windows.Forms.Button
	Friend WithEvents CBIHentai As System.Windows.Forms.CheckBox
	Friend WithEvents CBIMaledom As System.Windows.Forms.CheckBox
	Friend WithEvents CBIGay As System.Windows.Forms.CheckBox
	Friend WithEvents TbxILezdom As System.Windows.Forms.TextBox
	Friend WithEvents TbxIFemdom As System.Windows.Forms.TextBox
	Friend WithEvents TbxIBlowjob As System.Windows.Forms.TextBox
	Friend WithEvents TbxILesbian As System.Windows.Forms.TextBox
	Friend WithEvents TbxISoftcore As System.Windows.Forms.TextBox
	Friend WithEvents TbxIHardcore As System.Windows.Forms.TextBox
	Friend WithEvents BTNILezdom As System.Windows.Forms.Button
	Friend WithEvents BTNIFemdom As System.Windows.Forms.Button
	Friend WithEvents BTNIBlowjob As System.Windows.Forms.Button
	Friend WithEvents BTNILesbian As System.Windows.Forms.Button
	Friend WithEvents BTNISoftcore As System.Windows.Forms.Button
	Friend WithEvents BTNIHardcore As System.Windows.Forms.Button
	Friend WithEvents CBIHardcore As System.Windows.Forms.CheckBox
	Friend WithEvents CBISoftcore As System.Windows.Forms.CheckBox
	Friend WithEvents CBILesbian As System.Windows.Forms.CheckBox
	Friend WithEvents CBIBlowjob As System.Windows.Forms.CheckBox
	Friend WithEvents CBILezdom As System.Windows.Forms.CheckBox
	Friend WithEvents CBIFemdom As System.Windows.Forms.CheckBox
	Friend WithEvents TbxIGeneral As System.Windows.Forms.TextBox
	Friend WithEvents BTNIGeneral As System.Windows.Forms.Button
	Friend WithEvents CBIGeneral As System.Windows.Forms.CheckBox
	Friend WithEvents CBIHardcoreSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIGeneralSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIMaledomSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIGaySD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIHentaiSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBILezdomSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIFemdomSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBIBlowjobSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBILesbianSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBISoftcoreSD As System.Windows.Forms.CheckBox
	Friend WithEvents CBICaptionsSD As System.Windows.Forms.CheckBox
	Friend WithEvents TbxICaptions As System.Windows.Forms.TextBox
	Friend WithEvents BTNICaptions As System.Windows.Forms.Button
	Friend WithEvents CBICaptions As System.Windows.Forms.CheckBox
	Friend WithEvents GBDommeImages As System.Windows.Forms.GroupBox
	Friend WithEvents BTNDomImageDir As System.Windows.Forms.Button
	Friend WithEvents TbxDomImageDir As System.Windows.Forms.TextBox
	Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
	Friend WithEvents Panel9 As System.Windows.Forms.Panel
	Friend WithEvents TCScripts As System.Windows.Forms.TabControl
	Friend WithEvents TabPage21 As System.Windows.Forms.TabPage
	Friend WithEvents CLBStartList As System.Windows.Forms.CheckedListBox
	Friend WithEvents TabPage17 As System.Windows.Forms.TabPage
	Friend WithEvents TabPage18 As System.Windows.Forms.TabPage
	Friend WithEvents TabPage19 As System.Windows.Forms.TabPage
	Friend WithEvents GroupBox42 As System.Windows.Forms.GroupBox
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox43 As System.Windows.Forms.GroupBox
	Friend WithEvents Label98 As System.Windows.Forms.Label
	Friend WithEvents Label104 As System.Windows.Forms.Label
	Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
	Friend WithEvents RTBScriptReq As System.Windows.Forms.RichTextBox
	Friend WithEvents RTBScriptDesc As System.Windows.Forms.RichTextBox
	Friend WithEvents LBLScriptReq As System.Windows.Forms.Label
	Friend WithEvents CLBModuleList As System.Windows.Forms.CheckedListBox
	Friend WithEvents CLBLinkList As System.Windows.Forms.CheckedListBox
	Friend WithEvents CLBEndList As System.Windows.Forms.CheckedListBox
	Friend WithEvents BTNScriptOpen As System.Windows.Forms.Button
	Friend WithEvents BTNScriptAvailable As System.Windows.Forms.Button
	Friend WithEvents BTNScriptNone As System.Windows.Forms.Button
	Friend WithEvents BTNScriptAll As System.Windows.Forms.Button
	Friend WithEvents GroupBox45 As System.Windows.Forms.GroupBox
	Friend WithEvents CBCBTBalls As System.Windows.Forms.CheckBox
	Friend WithEvents CBCBTCock As System.Windows.Forms.CheckBox
	Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
	Friend WithEvents OpenSettingsDialog As System.Windows.Forms.OpenFileDialog
	Friend WithEvents SaveSettingsDialog As System.Windows.Forms.SaveFileDialog
	Friend WithEvents CBChastitySpikes As System.Windows.Forms.CheckBox
	Friend WithEvents CBChastityPA As System.Windows.Forms.CheckBox
	Friend WithEvents CBLongEdgeInterrupts As System.Windows.Forms.CheckBox
	Friend WithEvents Label55 As System.Windows.Forms.Label
	Friend WithEvents CBLongEdgeTaunts As System.Windows.Forms.CheckBox
	Friend WithEvents LBLCBTSlider As System.Windows.Forms.Label
	Friend WithEvents CBTSlider As System.Windows.Forms.TrackBar
	Friend WithEvents TBDomEyeColor As System.Windows.Forms.TextBox
	Friend WithEvents TBDomHairColor As System.Windows.Forms.TextBox
	Friend WithEvents TBSubEyeColor As System.Windows.Forms.TextBox
	Friend WithEvents TBSubHairColor As System.Windows.Forms.TextBox
	Friend WithEvents CBSubCircumcised As System.Windows.Forms.CheckBox
	Friend WithEvents CBSubPierced As System.Windows.Forms.CheckBox
	Friend WithEvents LBLEmpathy As System.Windows.Forms.Label
	Friend WithEvents NBEmpathy As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label83 As System.Windows.Forms.Label
	Friend WithEvents BTNSaveDomSet As System.Windows.Forms.Button
	Friend WithEvents BTNLoadDomSet As System.Windows.Forms.Button
	Friend WithEvents CBAuditStartup As System.Windows.Forms.CheckBox
	Friend WithEvents GBRangeOrgasmChance As System.Windows.Forms.GroupBox
	Friend WithEvents Label89 As System.Windows.Forms.Label
	Friend WithEvents NBAllowSometimes As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label86 As System.Windows.Forms.Label
	Friend WithEvents Label82 As System.Windows.Forms.Label
	Friend WithEvents NBAllowRarely As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBAllowOften As System.Windows.Forms.NumericUpDown
	Friend WithEvents CBRangeOrgasm As System.Windows.Forms.CheckBox
	Friend WithEvents GBRangeRuinChance As System.Windows.Forms.GroupBox
	Friend WithEvents Label90 As System.Windows.Forms.Label
	Friend WithEvents NBRuinSometimes As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label91 As System.Windows.Forms.Label
	Friend WithEvents Label92 As System.Windows.Forms.Label
	Friend WithEvents NBRuinRarely As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBRuinOften As System.Windows.Forms.NumericUpDown
	Friend WithEvents CBRangeRuin As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox57 As System.Windows.Forms.GroupBox
	Friend WithEvents LBLSafeword As System.Windows.Forms.Label
	Friend WithEvents TBSafeword As System.Windows.Forms.TextBox
	Friend WithEvents TabPage20 As System.Windows.Forms.TabPage
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage22 As System.Windows.Forms.TabPage
	Friend WithEvents TpGames As System.Windows.Forms.TabPage
	Friend WithEvents GbxCardsGold As System.Windows.Forms.GroupBox
	Friend WithEvents GN6 As System.Windows.Forms.TextBox
	Friend WithEvents GP6 As System.Windows.Forms.PictureBox
	Friend WithEvents GN5 As System.Windows.Forms.TextBox
	Friend WithEvents GP5 As System.Windows.Forms.PictureBox
	Friend WithEvents GN4 As System.Windows.Forms.TextBox
	Friend WithEvents GP4 As System.Windows.Forms.PictureBox
	Friend WithEvents GN3 As System.Windows.Forms.TextBox
	Friend WithEvents GP3 As System.Windows.Forms.PictureBox
	Friend WithEvents GN2 As System.Windows.Forms.TextBox
	Friend WithEvents GP2 As System.Windows.Forms.PictureBox
	Friend WithEvents GN1 As System.Windows.Forms.TextBox
	Friend WithEvents GP1 As System.Windows.Forms.PictureBox
	Friend WithEvents GbxCardsSilver As System.Windows.Forms.GroupBox
	Friend WithEvents SN6 As System.Windows.Forms.TextBox
	Friend WithEvents SP6 As System.Windows.Forms.PictureBox
	Friend WithEvents SN5 As System.Windows.Forms.TextBox
	Friend WithEvents SP5 As System.Windows.Forms.PictureBox
	Friend WithEvents SN4 As System.Windows.Forms.TextBox
	Friend WithEvents SP4 As System.Windows.Forms.PictureBox
	Friend WithEvents SN3 As System.Windows.Forms.TextBox
	Friend WithEvents SP3 As System.Windows.Forms.PictureBox
	Friend WithEvents SN2 As System.Windows.Forms.TextBox
	Friend WithEvents SP2 As System.Windows.Forms.PictureBox
	Friend WithEvents SN1 As System.Windows.Forms.TextBox
	Friend WithEvents SP1 As System.Windows.Forms.PictureBox
	Friend WithEvents GbxCardsBackground As System.Windows.Forms.GroupBox
	Friend WithEvents GbxCardsBronze As System.Windows.Forms.GroupBox
	Friend WithEvents BN6 As System.Windows.Forms.TextBox
	Friend WithEvents BP6 As System.Windows.Forms.PictureBox
	Friend WithEvents BN5 As System.Windows.Forms.TextBox
	Friend WithEvents BP5 As System.Windows.Forms.PictureBox
	Friend WithEvents BN4 As System.Windows.Forms.TextBox
	Friend WithEvents BP4 As System.Windows.Forms.PictureBox
	Friend WithEvents BN3 As System.Windows.Forms.TextBox
	Friend WithEvents BP3 As System.Windows.Forms.PictureBox
	Friend WithEvents BN2 As System.Windows.Forms.TextBox
	Friend WithEvents BP2 As System.Windows.Forms.PictureBox
	Friend WithEvents BN1 As System.Windows.Forms.TextBox
	Friend WithEvents BP1 As System.Windows.Forms.PictureBox
	Friend WithEvents CardBack As System.Windows.Forms.PictureBox
	Friend WithEvents CBGameSounds As System.Windows.Forms.CheckBox
	Friend WithEvents LblCardsSetupNote As System.Windows.Forms.Label
	Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
	Friend WithEvents CBEdgeUseAvg As System.Windows.Forms.CheckBox
	Friend WithEvents LBLLastRuined As System.Windows.Forms.Label
	Friend WithEvents TabPage24 As System.Windows.Forms.TabPage
	Friend WithEvents Button4 As System.Windows.Forms.Button
	Friend WithEvents Button5 As System.Windows.Forms.Button
	Friend WithEvents TBResponses As System.Windows.Forms.TextBox
	Friend WithEvents LBResponses As System.Windows.Forms.ListBox
	Friend WithEvents RTBResponses As System.Windows.Forms.RichTextBox
	Friend WithEvents RTBResponsesKEY As System.Windows.Forms.RichTextBox
	Friend WithEvents Button9 As System.Windows.Forms.Button
	Friend WithEvents TauntSlider As System.Windows.Forms.TrackBar
	Friend WithEvents Label97 As System.Windows.Forms.Label
	Friend WithEvents NBTeaseLengthMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label99 As System.Windows.Forms.Label
	Friend WithEvents Label96 As System.Windows.Forms.Label
	Friend WithEvents NBTeaseLengthMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label95 As System.Windows.Forms.Label
	Friend WithEvents Label103 As System.Windows.Forms.Label
	Friend WithEvents NBTauntCycleMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label105 As System.Windows.Forms.Label
	Friend WithEvents Label101 As System.Windows.Forms.Label
	Friend WithEvents NBTauntCycleMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label102 As System.Windows.Forms.Label
	Friend WithEvents CBTauntCycleDD As System.Windows.Forms.CheckBox
	Friend WithEvents CBTeaseLengthDD As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
	Friend WithEvents Label106 As System.Windows.Forms.Label
	Friend WithEvents LBLVtf As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label108 As System.Windows.Forms.Label
	Friend WithEvents Label109 As System.Windows.Forms.Label
	Friend WithEvents Label110 As System.Windows.Forms.Label
	Friend WithEvents Label111 As System.Windows.Forms.Label
	Friend WithEvents Label112 As System.Windows.Forms.Label
	Friend WithEvents NBNextImageChance As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBVidScript As System.Windows.Forms.ListBox
	Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
	Friend WithEvents BTNWishlistCreate As System.Windows.Forms.Button
	Friend WithEvents radioGold As System.Windows.Forms.RadioButton
	Friend WithEvents radioSilver As System.Windows.Forms.RadioButton
	Friend WithEvents NBWishlistCost As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label73 As System.Windows.Forms.Label
	Friend WithEvents TBWishlistComment As System.Windows.Forms.TextBox
	Friend WithEvents Label48 As System.Windows.Forms.Label
	Friend WithEvents TBWishlistURL As System.Windows.Forms.TextBox
	Friend WithEvents Label42 As System.Windows.Forms.Label
	Friend WithEvents TBWishlistItem As System.Windows.Forms.TextBox
	Friend WithEvents Label32 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents PNLWishList As System.Windows.Forms.Panel
	Friend WithEvents WishlistCostSilver As System.Windows.Forms.PictureBox
	Friend WithEvents LBLWishListText As System.Windows.Forms.Label
	Friend WithEvents LBLWishlistCost As System.Windows.Forms.Label
	Friend WithEvents WishlistCostGold As System.Windows.Forms.PictureBox
	Friend WithEvents LBLWishListName As System.Windows.Forms.Label
	Friend WithEvents WishlistPreview As System.Windows.Forms.PictureBox
	Friend WithEvents Label107 As System.Windows.Forms.Label
	Friend WithEvents Panel10 As System.Windows.Forms.Panel
	Friend WithEvents CBOwnChastity As System.Windows.Forms.CheckBox
	Friend WithEvents CBIncludeGifs As System.Windows.Forms.CheckBox
	Friend WithEvents CBHimHer As System.Windows.Forms.CheckBox
	Friend WithEvents CBDomDel As System.Windows.Forms.CheckBox
	Friend WithEvents TabPage25 As System.Windows.Forms.TabPage
	Friend WithEvents Panel11 As System.Windows.Forms.Panel
	Friend WithEvents Label115 As System.Windows.Forms.Label
	Friend WithEvents TBWebStop As System.Windows.Forms.TextBox
	Friend WithEvents Label114 As System.Windows.Forms.Label
	Friend WithEvents TBWebStart As System.Windows.Forms.TextBox
	Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
	Friend WithEvents Label148 As System.Windows.Forms.Label
	Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
	Friend WithEvents WebToy As System.Windows.Forms.WebBrowser
	Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
	Friend WithEvents PBMaintenance As System.Windows.Forms.ProgressBar
	Friend WithEvents LBLMaintenance As System.Windows.Forms.Label
	Friend WithEvents BTNMaintenanceRebuild As System.Windows.Forms.Button
	Friend WithEvents BTNMaintenanceCancel As System.Windows.Forms.Button
	Friend WithEvents Label116 As System.Windows.Forms.Label
	Friend WithEvents PBCurrent As System.Windows.Forms.ProgressBar
	Friend WithEvents Label117 As System.Windows.Forms.Label
	Friend WithEvents BTNMaintenanceRefresh As System.Windows.Forms.Button
	Friend WithEvents TabPage27 As System.Windows.Forms.TabPage
	Friend WithEvents BTNMaintenanceScripts As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
	Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
	Friend WithEvents Button6 As System.Windows.Forms.Button
	Friend WithEvents LBLSesSpace As System.Windows.Forms.Label
	Friend WithEvents LBLSesFiles As System.Windows.Forms.Label
	Friend WithEvents Label125 As System.Windows.Forms.Label
	Friend WithEvents Label124 As System.Windows.Forms.Label
	Friend WithEvents CBBallsToPussy As System.Windows.Forms.CheckBox
	Friend WithEvents CBCockToClit As System.Windows.Forms.CheckBox
	Friend WithEvents LBLLastOrgasm As System.Windows.Forms.Label
	Friend WithEvents Label65 As System.Windows.Forms.Label
	Friend WithEvents Label94 As System.Windows.Forms.Label
	Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Label127 As System.Windows.Forms.Label
	Friend WithEvents Label126 As System.Windows.Forms.Label
	Friend WithEvents Label128 As System.Windows.Forms.Label
	Friend WithEvents LBLSubBdayFormat As System.Windows.Forms.Label
	Friend WithEvents WBPlaylist As System.Windows.Forms.WebBrowser
	Friend WithEvents Label80 As System.Windows.Forms.Label
	Friend WithEvents LBLPlaylIstLink As System.Windows.Forms.Label
	Friend WithEvents LBLPlaylistModule As System.Windows.Forms.Label
	Friend WithEvents LBLPLaylistStart As System.Windows.Forms.Label
	Friend WithEvents LBPlaylist As System.Windows.Forms.ListBox
	Friend WithEvents BTNPlaylistEnd As System.Windows.Forms.Button
	Friend WithEvents BTNPlaylistClearAll As System.Windows.Forms.Button
	Friend WithEvents BTNPlaylistSave As System.Windows.Forms.Button
	Friend WithEvents Button7 As System.Windows.Forms.Button
	Friend WithEvents TBPlaylistSave As System.Windows.Forms.TextBox
	Friend WithEvents BTNPlaylistCtrlZ As System.Windows.Forms.Button
	Friend WithEvents RadioPlaylistRegScripts As System.Windows.Forms.RadioButton
	Friend WithEvents RadioPlaylistScripts As System.Windows.Forms.RadioButton
	Friend WithEvents BtnContact1ImageDir As System.Windows.Forms.Button
	Friend WithEvents TbxContact1ImageDir As System.Windows.Forms.TextBox
	Friend WithEvents BtnContact3ImageDir As System.Windows.Forms.Button
	Friend WithEvents TbxContact3ImageDir As System.Windows.Forms.TextBox
	Friend WithEvents BtnContact2ImageDir As System.Windows.Forms.Button
	Friend WithEvents TbxContact2ImageDir As System.Windows.Forms.TextBox
	Friend WithEvents BtnRandomImageDir As System.Windows.Forms.Button
	Friend WithEvents BtnRandomImageDirClear As System.Windows.Forms.Button
	Friend WithEvents CBGlitterFeedOff As System.Windows.Forms.RadioButton
	Friend WithEvents CBGlitterFeedScripts As System.Windows.Forms.RadioButton
	Friend WithEvents CBGlitterFeed As System.Windows.Forms.RadioButton
	Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
	Friend WithEvents Button11 As System.Windows.Forms.Button
	Friend WithEvents LBLChastityState As System.Windows.Forms.Label
	Friend WithEvents Label120 As System.Windows.Forms.Label
	Friend WithEvents TTDir As System.Windows.Forms.ToolTip
	Friend WithEvents BtnContact3ImageDirClear As System.Windows.Forms.Button
	Friend WithEvents BtnContact1ImageDirClear As System.Windows.Forms.Button
	Friend WithEvents BtnContact2ImageDirClear As System.Windows.Forms.Button
	Friend WithEvents Button15 As System.Windows.Forms.Button
	Friend WithEvents Button16 As System.Windows.Forms.Button
	Friend WithEvents Label121 As System.Windows.Forms.Label
	Friend WithEvents Label122 As System.Windows.Forms.Label
	Friend WithEvents GroupBox62 As System.Windows.Forms.GroupBox
	Friend WithEvents RBGerman As System.Windows.Forms.RadioButton
	Friend WithEvents RBEnglish As System.Windows.Forms.RadioButton
	Friend WithEvents TabPage26 As System.Windows.Forms.TabPage
	Friend WithEvents Panel12 As System.Windows.Forms.Panel
	Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
	Friend WithEvents Label144 As System.Windows.Forms.Label
	Friend WithEvents Label164 As System.Windows.Forms.Label
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents PBBackgroundPreview As System.Windows.Forms.PictureBox
	Friend WithEvents Button17 As System.Windows.Forms.Button
	Friend WithEvents CBStretchBack As System.Windows.Forms.CheckBox
	Friend WithEvents Button18 As System.Windows.Forms.Button
	Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
	Friend WithEvents LBLTextColor As System.Windows.Forms.Label
	Friend WithEvents LBLChatWindowColor2 As System.Windows.Forms.Label
	Friend WithEvents LBLTextColor2 As System.Windows.Forms.Label
	Friend WithEvents LBLChatTextColor As System.Windows.Forms.Label
	Friend WithEvents LBLBackColor2 As System.Windows.Forms.Label
	Friend WithEvents LBLButtonColor As System.Windows.Forms.Label
	Friend WithEvents LBLChatWindowColor As System.Windows.Forms.Label
	Friend WithEvents LBLBackColor As System.Windows.Forms.Label
	Friend WithEvents LBLChatTextColor2 As System.Windows.Forms.Label
	Friend WithEvents LBLButtonColor2 As System.Windows.Forms.Label
	Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
	Friend WithEvents LBLDateTimeColor2 As System.Windows.Forms.Label
	Friend WithEvents Label137 As System.Windows.Forms.Label
	Friend WithEvents Label138 As System.Windows.Forms.Label
	Friend WithEvents LBLDateBackColor2 As System.Windows.Forms.Label
	Friend WithEvents CBTransparentTime As System.Windows.Forms.CheckBox
	Friend WithEvents Button31 As System.Windows.Forms.Button
	Friend WithEvents CBFlipBack As System.Windows.Forms.CheckBox
	Friend WithEvents Button32 As System.Windows.Forms.Button
	Friend WithEvents CFNMCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents degradingCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents sadisticCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
	Friend WithEvents TimeBoxWakeUp As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents LBLMinHold As System.Windows.Forms.Label
	Friend WithEvents NBHoldTheEdgeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBLMaxHold As System.Windows.Forms.Label
	Friend WithEvents Label79 As System.Windows.Forms.Label
	Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents Label66 As System.Windows.Forms.Label
	Friend WithEvents GroupBox63 As System.Windows.Forms.GroupBox
	Friend WithEvents Label64 As System.Windows.Forms.Label
	Friend WithEvents Label67 As System.Windows.Forms.Label
	Friend WithEvents NBTypoChance As System.Windows.Forms.NumericUpDown
	Friend WithEvents TBEmote As System.Windows.Forms.TextBox
	Friend WithEvents TBEmoteEnd As System.Windows.Forms.TextBox
	Friend WithEvents SliderVRate As System.Windows.Forms.TrackBar
	Friend WithEvents SliderVVolume As System.Windows.Forms.TrackBar
	Friend WithEvents LBLVRate As System.Windows.Forms.Label
	Friend WithEvents Label93 As System.Windows.Forms.Label
	Friend WithEvents LBLVVolume As System.Windows.Forms.Label
	Friend WithEvents Label68 As System.Windows.Forms.Label
	Friend WithEvents LBLMaxExtremeHold As System.Windows.Forms.Label
	Friend WithEvents LBLMinExtremeHold As System.Windows.Forms.Label
	Friend WithEvents NBExtremeHoldMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label133 As System.Windows.Forms.Label
	Friend WithEvents NBExtremeHoldMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents LBLMaxLongHold As System.Windows.Forms.Label
	Friend WithEvents Label78 As System.Windows.Forms.Label
	Friend WithEvents LBLMinLongHold As System.Windows.Forms.Label
	Friend WithEvents NBLongHoldMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label129 As System.Windows.Forms.Label
	Friend WithEvents NBLongHoldMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label131 As System.Windows.Forms.Label
	Friend WithEvents CBWebtease As System.Windows.Forms.CheckBox
	Friend WithEvents TabPage28 As System.Windows.Forms.TabPage
	Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage29 As System.Windows.Forms.TabPage
	Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
	Friend WithEvents RBDebugTaunts3 As System.Windows.Forms.RadioButton
	Friend WithEvents RBDebugTaunts2 As System.Windows.Forms.RadioButton
	Friend WithEvents RBDebugTaunts1 As System.Windows.Forms.RadioButton
	Friend WithEvents CBDebugTauntsEndless As System.Windows.Forms.CheckBox
	Friend WithEvents CBDebugTaunts As System.Windows.Forms.CheckBox
	Friend WithEvents TabPage30 As System.Windows.Forms.TabPage
	Friend WithEvents TBDebugTaunts3 As System.Windows.Forms.TextBox
	Friend WithEvents TBDebugTaunts2 As System.Windows.Forms.TextBox
	Friend WithEvents TBDebugTaunts1 As System.Windows.Forms.TextBox
	Friend WithEvents BTNDebugTauntsClear As System.Windows.Forms.Button
	Friend WithEvents LBLCycleDebugCountdown As System.Windows.Forms.Label
	Friend WithEvents Button19 As System.Windows.Forms.Button
	Friend WithEvents Panel5 As System.Windows.Forms.Panel
	Friend WithEvents Label130 As System.Windows.Forms.Label
	Friend WithEvents Label123 As System.Windows.Forms.Label
	Friend WithEvents Label69 As System.Windows.Forms.Label
	Friend WithEvents Label113 As System.Windows.Forms.Label
	Friend WithEvents Label40 As System.Windows.Forms.Label
	Friend WithEvents Label35 As System.Windows.Forms.Label
	Friend WithEvents Label33 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
	Friend WithEvents Label41 As System.Windows.Forms.Label
	Friend WithEvents GroupBox64 As System.Windows.Forms.GroupBox
	Friend WithEvents CBMuteMedia As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox65 As System.Windows.Forms.GroupBox
	Friend WithEvents Label136 As System.Windows.Forms.Label
	Friend WithEvents Label134 As System.Windows.Forms.Label
	Friend WithEvents Label132 As System.Windows.Forms.Label
	Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
	Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
	Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
	Friend WithEvents Label135 As System.Windows.Forms.Label
	Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
	Friend WithEvents BTNOfflineMode As System.Windows.Forms.Button
	Friend WithEvents LBLOfflineMode As System.Windows.Forms.Label
	Friend WithEvents Label140 As System.Windows.Forms.Label
	Friend WithEvents CBNewSlideshow As System.Windows.Forms.CheckBox
	Friend WithEvents Label139 As System.Windows.Forms.Label
	Friend WithEvents NBTauntEdging As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label141 As System.Windows.Forms.Label
	Friend WithEvents BTNDebugHoldEdgeTimer As System.Windows.Forms.Button
	Friend WithEvents BTNDebugStrokeTauntTimer As System.Windows.Forms.Button
	Friend WithEvents LBLDebugHoldEdgeTime As System.Windows.Forms.Label
	Friend WithEvents Label145 As System.Windows.Forms.Label
	Friend WithEvents BTNDebugStrokeTime As System.Windows.Forms.Button
	Friend WithEvents BTNDebugEdgeTauntTimer As System.Windows.Forms.Button
	Friend WithEvents LBLDebugTeaseTime As System.Windows.Forms.Label
	Friend WithEvents LBLDebugStrokeTime As System.Windows.Forms.Label
	Friend WithEvents LBLDebugEdgeTauntTime As System.Windows.Forms.Label
	Friend WithEvents BTNDebugTeaseTimer As System.Windows.Forms.Button
	Friend WithEvents Label142 As System.Windows.Forms.Label
	Friend WithEvents Label150 As System.Windows.Forms.Label
	Friend WithEvents Label152 As System.Windows.Forms.Label
	Friend WithEvents LBLDebugStrokeTauntTime As System.Windows.Forms.Label
	Friend WithEvents Label147 As System.Windows.Forms.Label
	Friend WithEvents Label143 As System.Windows.Forms.Label
	Friend WithEvents LBLDebugScriptTime As System.Windows.Forms.Label
	Friend WithEvents TabControl4 As System.Windows.Forms.TabControl
	Friend WithEvents TpImagesUrlFiles As System.Windows.Forms.TabPage
	Friend WithEvents TpImagesGenre As System.Windows.Forms.TabPage
	Friend WithEvents BTNURLFilesNone As System.Windows.Forms.Button
	Friend WithEvents BTNURLFilesAll As System.Windows.Forms.Button
	Friend WithEvents GbxImagesGenre As System.Windows.Forms.GroupBox
	Friend WithEvents GrbImageUrlFiles As System.Windows.Forms.GroupBox
	Friend WithEvents ChbImageUrlButts As System.Windows.Forms.CheckBox
	Friend WithEvents ChbImageUrlBoobs As System.Windows.Forms.CheckBox
	Friend WithEvents Label153 As System.Windows.Forms.Label
	Friend WithEvents Label156 As System.Windows.Forms.Label
	Friend WithEvents BtnImageUrlGeneral As System.Windows.Forms.Button
	Friend WithEvents Button34 As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlLesbian As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlCaptions As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlBlowjob As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlMaledom As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlGay As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlGay As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlSoftcore As System.Windows.Forms.CheckBox
	Friend WithEvents ChbImageUrlHentai As System.Windows.Forms.CheckBox
	Friend WithEvents ChbImageUrlLezdom As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlHentai As System.Windows.Forms.Button
	Friend WithEvents BtnImageUrlLezdom As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlFemdom As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlFemdom As System.Windows.Forms.Button
	Friend WithEvents BtnImageUrlBlowjob As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlCaptions As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlLesbian As System.Windows.Forms.Button
	Friend WithEvents BtnImageUrlSoftcore As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlGeneral As System.Windows.Forms.CheckBox
	Friend WithEvents BtnImageUrlHardcore As System.Windows.Forms.Button
	Friend WithEvents ChbImageUrlHardcore As System.Windows.Forms.CheckBox
	Friend WithEvents ChbImageUrlMaledom As System.Windows.Forms.CheckBox
	Friend WithEvents CBIButts As System.Windows.Forms.CheckBox
	Friend WithEvents CBIBoobs As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox66 As System.Windows.Forms.GroupBox
	Friend WithEvents PBURLPreview As System.Windows.Forms.PictureBox
	Friend WithEvents CBURLPreview As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox67 As System.Windows.Forms.GroupBox
	Friend WithEvents Label151 As System.Windows.Forms.Label
	Friend WithEvents NBTaskStrokingTimeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTaskStrokingTimeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label154 As System.Windows.Forms.Label
	Friend WithEvents Label155 As System.Windows.Forms.Label
	Friend WithEvents NBTaskStrokesMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTaskStrokesMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label146 As System.Windows.Forms.Label
	Friend WithEvents Label149 As System.Windows.Forms.Label
	Friend WithEvents NBTaskEdgesMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTaskEdgesMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label119 As System.Windows.Forms.Label
	Friend WithEvents Label157 As System.Windows.Forms.Label
	Friend WithEvents Label161 As System.Windows.Forms.Label
	Friend WithEvents NBTaskCBTTimeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTaskCBTTimeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label162 As System.Windows.Forms.Label
	Friend WithEvents Label163 As System.Windows.Forms.Label
	Friend WithEvents Label158 As System.Windows.Forms.Label
	Friend WithEvents NBTaskEdgeHoldTimeMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTaskEdgeHoldTimeMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label159 As System.Windows.Forms.Label
	Friend WithEvents Label160 As System.Windows.Forms.Label
	Friend WithEvents BtnImportSettings As Button
	Friend WithEvents LblImportSettings As Label
	Friend WithEvents GroupBox68 As System.Windows.Forms.GroupBox
	Friend WithEvents NBTasksMax As System.Windows.Forms.NumericUpDown
	Friend WithEvents NBTasksMin As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label165 As System.Windows.Forms.Label
	Friend WithEvents Label166 As System.Windows.Forms.Label
	Friend WithEvents GroupBox69 As System.Windows.Forms.GroupBox
	Friend WithEvents TypeSpeedSlider As System.Windows.Forms.TrackBar
	Friend WithEvents TypeSpeedLabel As System.Windows.Forms.Label
	Friend WithEvents TimedWriting As System.Windows.Forms.CheckBox
	Friend WithEvents TypesSpeedVal As System.Windows.Forms.Label
	Friend WithEvents TlpImageUrls As TableLayoutPanel
	Friend WithEvents TxbImageUrlLesbian As TextBox
	Friend WithEvents TxbImageUrlHardcore As TextBox
	Friend WithEvents TxbImageUrlSoftcore As TextBox
	Friend WithEvents TxbImageUrlBlowjob As TextBox
	Friend WithEvents TxbImageUrlFemdom As TextBox
	Friend WithEvents TxbImageUrlLezdom As TextBox
	Friend WithEvents TxbImageUrlHentai As TextBox
	Friend WithEvents TxbImageUrlGay As TextBox
	Friend WithEvents TxbImageUrlMaledom As TextBox
	Friend WithEvents TxbImageUrlCaptions As TextBox
	Friend WithEvents TxbImageUrlGeneral As TextBox
	Friend WithEvents TxbImageUrlBoobs As TextBox
	Friend WithEvents TxbImageUrlButts As TextBox
	Friend WithEvents TxbImgUrlHardcore As TextBox
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents BWURLFiles As URL_Files.URL_File_BGW
	Friend WithEvents Button24 As System.Windows.Forms.Button
	Friend WithEvents Button33 As System.Windows.Forms.Button
	Friend WithEvents TabPage33 As TabPage
	Friend WithEvents TabControl5 As TabControl
	Friend WithEvents TabPage34 As TabPage
	Friend WithEvents TabPage35 As TabPage
	Friend WithEvents CBTagSeeThrough As RadioButton
	Friend WithEvents CBTagAllFours As CheckBox
	Friend WithEvents CBTagGlaring As CheckBox
	Friend WithEvents CBTagSmiling As CheckBox
	Friend WithEvents TBTagDir As TextBox
	Friend WithEvents CBTagPiercing As CheckBox
	Friend WithEvents CBTagLegs As CheckBox
	Friend WithEvents TBTagFurniture As TextBox
	Friend WithEvents CBTagFurniture As CheckBox
	Friend WithEvents TBTagSexToy As TextBox
	Friend WithEvents CBTagSexToy As CheckBox
	Friend WithEvents TBTagTattoo As TextBox
	Friend WithEvents CBTagTattoo As CheckBox
	Friend WithEvents TBTagUnderwear As TextBox
	Friend WithEvents CBTagUnderwear As CheckBox
	Friend WithEvents TBTagGarment As TextBox
	Friend WithEvents CBTagGarment As CheckBox
	Friend WithEvents Label72 As Label
	Friend WithEvents CBTagHandsCovering As RadioButton
	Friend WithEvents CBTagGarmentCovering As RadioButton
	Friend WithEvents CBTagCloseUp As CheckBox
	Friend WithEvents CBTagNaked As RadioButton
	Friend WithEvents CBTagSideView As CheckBox
	Friend WithEvents BTNTagPrevious As Button
	Friend WithEvents CBTagHalfDressed As RadioButton
	Friend WithEvents BTNTagNext As Button
	Friend WithEvents CBTagFullyDressed As RadioButton
	Friend WithEvents LBLTagCount As Label
	Friend WithEvents CBTagSucking As CheckBox
	Friend WithEvents CBTagMasturbating As CheckBox
	Friend WithEvents CBTagFeet As CheckBox
	Friend WithEvents CBTagBoobs As CheckBox
	Friend WithEvents CBTagAss As CheckBox
	Friend WithEvents CBTagPussy As CheckBox
	Friend WithEvents BTNTagSave As Button
	Friend WithEvents BTNTagDir As Button
	Friend WithEvents ImageTagPictureBox As PictureBox
	Friend WithEvents CBTagFace As CheckBox
	Friend WithEvents GroupBox55 As GroupBox
	Friend WithEvents CBTagNurse As CheckBox
	Friend WithEvents CBTagSchoolgirl As CheckBox
	Friend WithEvents CBTagMaid As CheckBox
	Friend WithEvents CBTagTeacher As CheckBox
	Friend WithEvents CBTagSuperhero As CheckBox
	Friend WithEvents GroupBox53 As GroupBox
	Friend WithEvents CBTagTrap As CheckBox
	Friend WithEvents CBTagTentacles As CheckBox
	Friend WithEvents CBTagMonsterGirl As CheckBox
	Friend WithEvents CBTagBukkake As CheckBox
	Friend WithEvents CBTagGanguro As CheckBox
	Friend WithEvents CBTagBodyWriting As CheckBox
	Friend WithEvents CBTagMahouShoujo As CheckBox
	Friend WithEvents CBTagBakunyuu As CheckBox
	Friend WithEvents CBTagAhegao As CheckBox
	Friend WithEvents CBTagShibari As CheckBox
	Friend WithEvents GroupBox49 As GroupBox
	Friend WithEvents CBTagBodyMouth As CheckBox
	Friend WithEvents CBTagBodyAss As CheckBox
	Friend WithEvents CBTagBodyFace As CheckBox
	Friend WithEvents CBTagBodyLegs As CheckBox
	Friend WithEvents CBTagBodyBalls As CheckBox
	Friend WithEvents CBTagBodyCock As CheckBox
	Friend WithEvents CBTagBodyFeet As CheckBox
	Friend WithEvents CBTagBodyNipples As CheckBox
	Friend WithEvents CBTagBodyPussy As CheckBox
	Friend WithEvents CBTagBodyTits As CheckBox
	Friend WithEvents CBTagBodyFingers As CheckBox
	Friend WithEvents GroupBox46 As GroupBox
	Friend WithEvents CBTagMultiSub As CheckBox
	Friend WithEvents CBTagMultiDom As CheckBox
	Friend WithEvents CBTagFemdom As CheckBox
	Friend WithEvents CBTag2M As CheckBox
	Friend WithEvents CBTagFutadom As CheckBox
	Friend WithEvents CBTagFemsub As CheckBox
	Friend WithEvents CBTag2Futa As CheckBox
	Friend WithEvents CBTagMaledom As CheckBox
	Friend WithEvents CBTag3M As CheckBox
	Friend WithEvents CBTagFutasub As CheckBox
	Friend WithEvents CBTag3Futa As CheckBox
	Friend WithEvents CBTagMalesub As CheckBox
	Friend WithEvents CBTag2F As CheckBox
	Friend WithEvents CBTag1Futa As CheckBox
	Friend WithEvents CBTag1M As CheckBox
	Friend WithEvents CBTag1F As CheckBox
	Friend WithEvents CBTag3F As CheckBox
	Friend WithEvents GroupBox54 As GroupBox
	Friend WithEvents CBTagTattoos As CheckBox
	Friend WithEvents CBTagAnalToy As CheckBox
	Friend WithEvents CBTagDomme As CheckBox
	Friend WithEvents CBTagPocketPussy As CheckBox
	Friend WithEvents CBTagWatersports As CheckBox
	Friend WithEvents CBTagStockings As CheckBox
	Friend WithEvents CBTagCumshot As CheckBox
	Friend WithEvents CBTagCumEating As CheckBox
	Friend WithEvents CBTagVibrator As CheckBox
	Friend WithEvents CBTagDildo As CheckBox
	Friend WithEvents CBTagKissing As CheckBox
	Friend WithEvents GroupBox51 As GroupBox
	Friend WithEvents CBTagBallTorture As CheckBox
	Friend WithEvents CBTagGag As CheckBox
	Friend WithEvents CBTagBlindfold As CheckBox
	Friend WithEvents CBTagWhipping As CheckBox
	Friend WithEvents CBTagCockTorture As CheckBox
	Friend WithEvents CBTagElectro As CheckBox
	Friend WithEvents CBTagHotWax As CheckBox
	Friend WithEvents CBTagClamps As CheckBox
	Friend WithEvents CBTagStrapon As CheckBox
	Friend WithEvents CBTagSpanking As CheckBox
	Friend WithEvents CBTagNeedles As CheckBox
	Friend WithEvents GroupBox50 As GroupBox
	Friend WithEvents CBTagRimming As CheckBox
	Friend WithEvents CBTagFacesitting As CheckBox
	Friend WithEvents CBTagMissionary As CheckBox
	Friend WithEvents CBTagMasturbation As CheckBox
	Friend WithEvents CBTagRCowgirl As CheckBox
	Friend WithEvents CBTagFingering As CheckBox
	Friend WithEvents CBTagGangbang As CheckBox
	Friend WithEvents CBTagBlowjob As CheckBox
	Friend WithEvents CBTagDP As CheckBox
	Friend WithEvents CBTagHandjob As CheckBox
	Friend WithEvents CBTagStanding As CheckBox
	Friend WithEvents CBTagFootjob As CheckBox
	Friend WithEvents CBTagCowgirl As CheckBox
	Friend WithEvents CBTagDoggyStyle As CheckBox
	Friend WithEvents CBTagTitjob As CheckBox
	Friend WithEvents CBTagCunnilingus As CheckBox
	Friend WithEvents CBTagAnalSex As CheckBox
	Friend WithEvents GroupBox48 As GroupBox
	Friend WithEvents CBTagArtwork As CheckBox
	Friend WithEvents CBTagOutdoors As CheckBox
	Friend WithEvents CBTagPOV As CheckBox
	Friend WithEvents CBTagHardcore As CheckBox
	Friend WithEvents CBTagTD As CheckBox
	Friend WithEvents CBTagGay As CheckBox
	Friend WithEvents CBTagBath As CheckBox
	Friend WithEvents CBTagBisexual As CheckBox
	Friend WithEvents CBTagCFNM As CheckBox
	Friend WithEvents CBTagLesbian As CheckBox
	Friend WithEvents CBTagSoloFuta As CheckBox
	Friend WithEvents CBTagSM As CheckBox
	Friend WithEvents CBTagBondage As CheckBox
	Friend WithEvents CBTagSoloM As CheckBox
	Friend WithEvents CBTagSoloF As CheckBox
	Friend WithEvents CBTagChastity As CheckBox
	Friend WithEvents CBTagShower As CheckBox
	Friend WithEvents TBLocalTagDir As TextBox
	Friend WithEvents BTNLocalTagPrevious As Button
	Friend WithEvents BTNLocalTagNext As Button
	Friend WithEvents LBLLocalTagCount As Label
	Friend WithEvents BTNLocalTagSave As Button
	Friend WithEvents BTNLocalTagDir As Button
	Friend WithEvents CBLockOrgasmChances As CheckBox
	Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
	Friend WithEvents GrbGlitterfeed As GroupBox
	Friend WithEvents GBGiveUp As GroupBox
	Friend WithEvents giveupCheckBox As CheckBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents CBRandomDomme As System.Windows.Forms.CheckBox
	Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
	Friend WithEvents BTNValidateSystemFiles As System.Windows.Forms.Button
	Friend WithEvents TbxRandomImageDir As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
	Friend WithEvents BTNDomChangeContact1 As System.Windows.Forms.Button
	Friend WithEvents BTNDomChangeRandom As System.Windows.Forms.Button
	Friend WithEvents BTNDomChangeContact3 As System.Windows.Forms.Button
	Friend WithEvents BTNDomChangeContact2 As System.Windows.Forms.Button
	Friend WithEvents BTNDomChangeDomme As System.Windows.Forms.Button
	Friend WithEvents LBLCurrentDomme As System.Windows.Forms.Label
	Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
	Friend WithEvents CBOutputErrors As System.Windows.Forms.CheckBox
	Friend WithEvents Label85 As System.Windows.Forms.Label
	Friend WithEvents TBURLFileReplace As System.Windows.Forms.TextBox
	Friend WithEvents Label53 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents BTNURLFileReplace As System.Windows.Forms.Button
	Friend WithEvents Label87 As System.Windows.Forms.Label
	Friend WithEvents TBURLFileWith As System.Windows.Forms.TextBox
	Friend WithEvents Label118 As System.Windows.Forms.Label
	Friend WithEvents Label167 As Label
	Friend WithEvents Label168 As Label
	Friend WithEvents Label170 As Label
	Friend WithEvents GroupBox14 As GroupBox
	Friend WithEvents alwaysNewSlideshow As System.Windows.Forms.CheckBox
	Friend WithEvents Label169 As System.Windows.Forms.Label
	Friend WithEvents Label171 As System.Windows.Forms.Label
End Class
