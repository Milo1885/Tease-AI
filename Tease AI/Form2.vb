Imports System.IO
Imports System.Xml

Imports System.Drawing.Font
Imports System.Drawing.FontFamily
Imports System.Drawing.FontConverter
Imports System.Speech.Synthesis
Imports System.Net
Imports System.Text
Imports System.Threading





Public Class FrmSettings





	Public URLFileIncludeList As New List(Of String)
	Public FrmSettingsLoading As Boolean
	Public AvailFail As Boolean
	Public AvailList As New List(Of String)
	Dim ScriptList As New List(Of String)
	Dim ScriptFile As String
	Dim LocalImageDir As New List(Of String)

	Dim ImageTagDir As New List(Of String)
	Dim LocalImageTagDir As New List(Of String)
	Dim ImageTagCount As Integer
	Dim LocalImageTagCount As Integer
	Dim CurrentImageTagImage As String
	Dim CurrentLocalImageTagImage As String


	Dim CheckImgDir As New List(Of String)

	'Dim Fringe As New SpeechSynthesizer

	Private Thr As Threading.Thread

	Dim URLCancel As Boolean

	Dim CancelRebuild As Boolean

	Dim TagImageFolder As String

	' Protected Overrides ReadOnly Property CreateParams() As CreateParams
	'    Get
	' Dim param As CreateParams = MyBase.CreateParams
	'        param.ClassStyle = param.ClassStyle Or &H200
	'       Return param
	'  End Get
	'End Property

	Private Sub frmProgramma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

		Me.Visible = False
		Form1.SettingsButton.Text = "Open Settings Menu"
		e.Cancel = True

	End Sub


	Public Sub FrmSettingStartUp()

		FrmSettingsLoading = True

		CardBack.AllowDrop = True

		GP1.AllowDrop = True
		GP2.AllowDrop = True
		GP3.AllowDrop = True
		GP4.AllowDrop = True
		GP5.AllowDrop = True
		GP6.AllowDrop = True

		SP1.AllowDrop = True
		SP2.AllowDrop = True
		SP3.AllowDrop = True
		SP4.AllowDrop = True
		SP5.AllowDrop = True
		SP6.AllowDrop = True

		BP1.AllowDrop = True
		BP2.AllowDrop = True
		BP3.AllowDrop = True
		BP4.AllowDrop = True
		BP5.AllowDrop = True
		BP6.AllowDrop = True


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking installed voices..."
		FrmSplash.Refresh()


		Dim oSpeech As New System.Speech.Synthesis.SpeechSynthesizer()
		Dim installedVoices As System.Collections.ObjectModel.
			ReadOnlyCollection(Of System.Speech.Synthesis.InstalledVoice) _
			= oSpeech.GetInstalledVoices

		Dim names(installedVoices.Count - 1) As String
		For i As Integer = 0 To installedVoices.Count - 1
			names(i) = installedVoices(i).VoiceInfo.Name
			Debug.Print("Name = " & names(i))
		Next

		oSpeech.Dispose()




		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking URL Files..."
		FrmSplash.Refresh()

		If File.Exists(Application.StartupPath & "\Images\System\URLFileCheckList.cld") Then
			URLFileList.Items.Clear()
			Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Open)
			Dim BinaryReader As New System.IO.BinaryReader(FileStream)
			URLFileList.BeginUpdate()
			Do While FileStream.Position < FileStream.Length
				URLFileList.Items.Add(BinaryReader.ReadString)
				URLFileList.SetItemChecked(URLFileList.Items.Count - 1, BinaryReader.ReadBoolean)
			Loop
			URLFileList.EndUpdate()
			BinaryReader.Close()
			FileStream.Dispose()
			RefreshURLList()
		Else
			URLFileList.Items.Clear()
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempUrl As String = foundFile
				TempUrl = Path.GetFileName(TempUrl).Replace(".txt", "")
				URLFileList.Items.Add(TempUrl)
			Next
			For i As Integer = 0 To URLFileList.Items.Count - 1
				URLFileList.SetItemChecked(i, True)
			Next
			Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
			Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
			For i = 0 To URLFileList.Items.Count - 1
				BinaryWriter.Write(CStr(URLFileList.Items(i)))
				BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
			Next
			BinaryWriter.Close()
			FileStream.Dispose()
		End If


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking Local Image settings..."
		FrmSplash.Refresh()

		LBLIHardcore.Text = My.Settings.IHardcore
		LBLISoftcore.Text = My.Settings.ISoftcore
		LBLILesbian.Text = My.Settings.ILesbian
		LBLIBlowjob.Text = My.Settings.IBlowjob
		LBLIFemdom.Text = My.Settings.IFemdom
		LBLILezdom.Text = My.Settings.ILezdom
		LBLIHentai.Text = My.Settings.IHentai
		LBLIGay.Text = My.Settings.IGay
		LBLIMaledom.Text = My.Settings.IMaledom
		LBLICaptions.Text = My.Settings.ICaptions
		LBLIGeneral.Text = My.Settings.IGeneral

		Debug.Print("FRM2 STAGE ONE reached")

		If My.Settings.CBIHardcore = True Then
			CBIHardcore.Checked = True
		Else
			CBIHardcore.Checked = False
		End If

		If My.Settings.CBISoftcore = True Then
			CBISoftcore.Checked = True
		Else
			CBISoftcore.Checked = False
		End If

		If My.Settings.CBILesbian = True Then
			CBILesbian.Checked = True
		Else
			CBILesbian.Checked = False
		End If

		If My.Settings.CBIBlowjob = True Then
			CBIBlowjob.Checked = True
		Else
			CBIBlowjob.Checked = False
		End If

		If My.Settings.CBIFemdom = True Then
			CBIFemdom.Checked = True
		Else
			CBIFemdom.Checked = False
		End If

		If My.Settings.CBILezdom = True Then
			CBILezdom.Checked = True
		Else
			CBILezdom.Checked = False
		End If

		If My.Settings.CBIHentai = True Then
			CBIHentai.Checked = True
		Else
			CBIHentai.Checked = False
		End If

		If My.Settings.CBIGay = True Then
			CBIGay.Checked = True
		Else
			CBIGay.Checked = False
		End If

		If My.Settings.CBIMaledom = True Then
			CBIMaledom.Checked = True
		Else
			CBIMaledom.Checked = False
		End If

		If My.Settings.CBICaptions = True Then
			CBICaptions.Checked = True
		Else
			CBICaptions.Checked = False
		End If

		If My.Settings.CBIGeneral = True Then
			CBIGeneral.Checked = True
		Else
			CBIGeneral.Checked = False
		End If

		Debug.Print(My.Settings.IHardcoreSD & "????????")


		If My.Settings.IHardcoreSD = True Then
			CBIHardcoreSD.Checked = True
		Else
			CBIHardcoreSD.Checked = False
		End If

		If My.Settings.ISoftcoreSD = True Then
			CBISoftcoreSD.Checked = True
		Else
			CBISoftcoreSD.Checked = False
		End If

		If My.Settings.ILesbianSD = True Then
			CBILesbianSD.Checked = True
		Else
			CBILesbianSD.Checked = False
		End If

		If My.Settings.IBlowjobSD = True Then
			CBIBlowjobSD.Checked = True
		Else
			CBIBlowjobSD.Checked = False
		End If

		If My.Settings.IFemdomSD = True Then
			CBIFemdomSD.Checked = True
		Else
			CBIFemdomSD.Checked = False
		End If

		If My.Settings.ILezdomSD = True Then
			CBILezdomSD.Checked = True
		Else
			CBILezdomSD.Checked = False
		End If

		If My.Settings.IHentaiSD = True Then
			CBIHentaiSD.Checked = True
		Else
			CBIHentaiSD.Checked = False
		End If

		If My.Settings.IGaySD = True Then
			CBIGaySD.Checked = True
		Else
			CBIGaySD.Checked = False
		End If

		If My.Settings.IMaledomSD = True Then
			CBIMaledomSD.Checked = True
		Else
			CBIMaledomSD.Checked = False
		End If

		If My.Settings.ICaptionsSD = True Then
			CBICaptionsSD.Checked = True
		Else
			CBICaptionsSD.Checked = False
		End If

		If My.Settings.IGeneralSD = True Then
			CBIGeneralSD.Checked = True
		Else
			CBIGeneralSD.Checked = False
		End If

		'VerifyLocalImagePaths()

		Debug.Print("FRM2 STAGE Two reached")

		LBLDomImageDir.Text = My.Settings.DomImageDir

		Debug.Print("FrmSettingsLoading = " & FrmSettingsLoading)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking installed fonts..."
		FrmSplash.Refresh()

		BindCombo()
		BindCombo2()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking available scripts..."
		FrmSplash.Refresh()

		Try
			CLBStartList.Items.Clear()

			InitializeStartScripts()

			InitializeModuleScripts()

			Debug.Print("frmsettings2 wtf now")
			InitializeLinkScripts()
			InitializeEndScripts()

			StartTab()
		Catch
		End Try

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Populating available voices..."
		FrmSplash.Refresh()

		Dim voicecheck As Integer
		'Dim voices = Fringe.GetInstalledVoices()
		For Each v As InstalledVoice In installedVoices
			Debug.Print("Voice " & v.ToString())
			voicecheck += 1
			TTSComboBox.Items.Add(v.VoiceInfo.Name)
			TTSComboBox.Text = v.VoiceInfo.Name
		Next
		If voicecheck = 0 Then
			TTSComboBox.Text = "No voices installed"
			TTSComboBox.Enabled = False
			TTSCheckBox.Checked = False
			TTSCheckBox.Enabled = False
		End If

		Debug.Print("Voicecheck = " & voicecheck)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Sub settings..."
		FrmSplash.Refresh()


		If My.Settings.CBTCock = True Then
			CBCBTCock.Checked = True
		Else
			CBCBTCock.Checked = False
		End If

		If My.Settings.CBTBalls = True Then
			CBCBTBalls.Checked = True
		Else
			CBCBTBalls.Checked = False
		End If



		If My.Settings.ChastityPA = True Then
			CBChastityPA.Checked = True
		Else
			CBChastityPA.Checked = False
		End If

		If My.Settings.ChastitySpikes = True Then
			CBChastitySpikes.Checked = True
		Else
			CBChastitySpikes.Checked = False
		End If

		NBLongEdge.Value = My.Settings.LongEdge

		If My.Settings.CBLongEdgeInterrupt = True Then
			CBLongEdgeInterrupts.Checked = True
		Else
			CBLongEdgeInterrupts.Checked = False
		End If

		NBHoldTheEdgeMax.Value = My.Settings.HoldTheEdgeMax
		NBHoldTheEdgeMin.Value = My.Settings.HoldTheEdgeMin
		LBLMinHold.Text = My.Settings.HoldTheEdgeMinAmount
		LBLMaxHold.Text = My.Settings.HoldTheEdgeMaxAmount
		NBLongHoldMax.Value = My.Settings.LongHoldMax
		NBLongHoldMin.Value = My.Settings.LongHoldMin
		NBExtremeHoldMax.Value = My.Settings.ExtremeHoldMax
		NBExtremeHoldMin.Value = My.Settings.ExtremeHoldMin


		CBTSlider.Value = My.Settings.CBTSlider

		If CBTSlider.Value = 1 Then LBLCBTSlider.Text = "CBT Level: 1"
		If CBTSlider.Value = 2 Then LBLCBTSlider.Text = "CBT Level: 2"
		If CBTSlider.Value = 3 Then LBLCBTSlider.Text = "CBT Level: 3"
		If CBTSlider.Value = 4 Then LBLCBTSlider.Text = "CBT Level: 4"
		If CBTSlider.Value = 5 Then LBLCBTSlider.Text = "CBT Level: 5"

		If My.Settings.SubCircumcised = True Then
			CBSubCircumcised.Checked = True
		Else
			CBSubCircumcised.Checked = False
		End If

		If My.Settings.SubPierced = True Then
			CBSubPierced.Checked = True
		Else
			CBSubPierced.Checked = False
		End If

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Domme settings..."
		FrmSplash.Refresh()

		domlevelNumBox.Value = My.Settings.DomLevel

		If domlevelNumBox.Value = 1 Then DomLevelDescLabel.Text = "Gentle"
		If domlevelNumBox.Value = 2 Then DomLevelDescLabel.Text = "Lenient"
		If domlevelNumBox.Value = 3 Then DomLevelDescLabel.Text = "Tease"
		If domlevelNumBox.Value = 4 Then DomLevelDescLabel.Text = "Rough"
		If domlevelNumBox.Value = 5 Then DomLevelDescLabel.Text = "Sadistic"

		NBEmpathy.Value = My.Settings.DomEmpathy

		If NBEmpathy.Value = 1 Then LBLEmpathy.Text = "Cautious"
		If NBEmpathy.Value = 2 Then LBLEmpathy.Text = "Caring"
		If NBEmpathy.Value = 3 Then LBLEmpathy.Text = "Moderate"
		If NBEmpathy.Value = 4 Then LBLEmpathy.Text = "Cruel"
		If NBEmpathy.Value = 5 Then LBLEmpathy.Text = "Merciless"





		CBRangeOrgasm.Checked = My.Settings.RangeOrgasm
		CBRangeRuin.Checked = My.Settings.RangeRuin
		NBAllowOften.Value = My.Settings.AllowOften
		NBAllowSometimes.Value = My.Settings.AllowSometimes
		NBAllowRarely.Value = My.Settings.AllowRarely
		NBRuinOften.Value = My.Settings.RuinOften
		NBRuinSometimes.Value = My.Settings.RuinSometimes
		NBRuinRarely.Value = My.Settings.RuinRarely

		If CBRangeOrgasm.Checked = False Then
			NBAllowOften.Enabled = True
			NBAllowSometimes.Enabled = True
			NBAllowRarely.Enabled = True
		Else
			NBAllowOften.Enabled = False
			NBAllowSometimes.Enabled = False
			NBAllowRarely.Enabled = False
		End If

		If CBRangeRuin.Checked = False Then
			NBRuinOften.Enabled = True
			NBRuinSometimes.Enabled = True
			NBRuinRarely.Enabled = True
		Else
			NBRuinOften.Enabled = False
			NBRuinSometimes.Enabled = False
			NBRuinRarely.Enabled = False
		End If

		TBSafeword.Text = My.Settings.Safeword

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading card images..."
		FrmSplash.Refresh()

		BN1.Text = My.Settings.BN1
		BN2.Text = My.Settings.BN2
		BN3.Text = My.Settings.BN3
		BN4.Text = My.Settings.BN4
		BN5.Text = My.Settings.BN5
		BN6.Text = My.Settings.BN6

		SN1.Text = My.Settings.SN1
		SN2.Text = My.Settings.SN2
		SN3.Text = My.Settings.SN3
		SN4.Text = My.Settings.SN4
		SN5.Text = My.Settings.SN5
		SN6.Text = My.Settings.SN6

		GN1.Text = My.Settings.GN1
		GN2.Text = My.Settings.GN2
		GN3.Text = My.Settings.GN3
		GN4.Text = My.Settings.GN4
		GN5.Text = My.Settings.GN5
		GN6.Text = My.Settings.GN6



		If File.Exists(My.Settings.BP1) Then
			BP1.Image = Image.FromFile(My.Settings.BP1)
			' BP1.Load(My.Settings.BP1)
		End If
		If File.Exists(My.Settings.BP2) Then
			BP2.Image = Image.FromFile(My.Settings.BP2)
			'BP2.Load(My.Settings.BP2)
		End If
		If File.Exists(My.Settings.BP3) Then
			BP3.Image = Image.FromFile(My.Settings.BP3)
			'BP3.Load(My.Settings.BP3)
		End If
		If File.Exists(My.Settings.BP4) Then
			BP4.Image = Image.FromFile(My.Settings.BP4)
			'BP4.Load(My.Settings.BP4)
		End If
		If File.Exists(My.Settings.BP5) Then
			BP5.Image = Image.FromFile(My.Settings.BP5)
			'BP5.Load(My.Settings.BP5)
		End If
		If File.Exists(My.Settings.BP6) Then
			BP6.Image = Image.FromFile(My.Settings.BP6)
			'BP6.Load(My.Settings.BP6)
		End If

		If File.Exists(My.Settings.SP1) Then
			SP1.Image = Image.FromFile(My.Settings.SP1)
			'SP1.Load(My.Settings.SP1)
		End If
		If File.Exists(My.Settings.SP2) Then
			SP2.Image = Image.FromFile(My.Settings.SP2)
			'SP2.Load(My.Settings.SP2)
		End If
		If File.Exists(My.Settings.SP3) Then
			SP3.Image = Image.FromFile(My.Settings.SP3)
			'SP3.Load(My.Settings.SP3)
		End If
		If File.Exists(My.Settings.SP4) Then
			SP4.Image = Image.FromFile(My.Settings.SP4)
			'SP4.Load(My.Settings.SP4)
		End If
		If File.Exists(My.Settings.SP5) Then
			SP5.Image = Image.FromFile(My.Settings.SP5)
			'SP5.Load(My.Settings.SP5)
		End If
		If File.Exists(My.Settings.SP6) Then
			SP6.Image = Image.FromFile(My.Settings.SP6)
			'SP6.Load(My.Settings.SP6)
		End If

		If File.Exists(My.Settings.GP1) Then
			GP1.Image = Image.FromFile(My.Settings.GP1)
			'GP1.Load(My.Settings.GP1)
		End If
		If File.Exists(My.Settings.GP2) Then
			GP2.Image = Image.FromFile(My.Settings.GP2)
			'GP2.Load(My.Settings.GP2)
		End If
		If File.Exists(My.Settings.GP3) Then
			GP3.Image = Image.FromFile(My.Settings.GP3)
			'GP3.Load(My.Settings.GP3)
		End If
		If File.Exists(My.Settings.GP4) Then
			GP4.Image = Image.FromFile(My.Settings.GP4)
			'GP4.Load(My.Settings.GP4)
		End If
		If File.Exists(My.Settings.GP5) Then
			GP5.Image = Image.FromFile(My.Settings.GP5)
			'GP5.Load(My.Settings.GP5)
		End If
		If File.Exists(My.Settings.GP6) Then
			GP6.Image = Image.FromFile(My.Settings.GP6)
			'GP6.Load(My.Settings.GP6)
		End If

		If File.Exists(My.Settings.CardBack) Then
			CardBack.Image = Image.FromFile(My.Settings.CardBack)
		End If

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking user settings..."
		FrmSplash.Refresh()

		NBNextImageChance.Value = My.Settings.NextImageChance

		CBEdgeUseAvg.Checked = My.Settings.CBEdgeUseAvg
		CBLongEdgeTaunts.Checked = My.Settings.CBLongEdgeTaunts
		CBLongEdgeInterrupts.Checked = My.Settings.CBLongEdgeInterrupts

		CBTeaseLengthDD.Checked = My.Settings.CBTeaseLengthDD
		CBTauntCycleDD.Checked = My.Settings.CBTauntCycleDD




		If My.Settings.OrgasmsLocked = True Then
			Debug.Print("Form2 Orgasm Lock Date = " & My.Settings.OrgasmLockDate)
			If Form1.CompareDates(My.Settings.OrgasmLockDate) <= 0 Then
				My.Settings.OrgasmsLocked = False
				My.Settings.Save()
			Else
				limitcheckbox.Checked = True
				limitcheckbox.Enabled = False
				orgasmsPerNumBox.Enabled = False
				orgasmsperComboBox.Enabled = False
				orgasmsperlockButton.Enabled = False
				orgasmlockrandombutton.Enabled = False
			End If

		End If

		CBOwnChastity.Checked = My.Settings.CBOwnChastity

		CBChastitySpikes.Checked = My.Settings.ChastitySpikes
		CBChastityPA.Checked = My.Settings.ChastityPA

		CBChastityPA.Enabled = CBOwnChastity.Checked
		CBChastitySpikes.Enabled = CBOwnChastity.Checked

		CBIncludeGifs.Checked = My.Settings.CBIncludeGifs

		CBHimHer.Checked = My.Settings.CBHimHer

		CBDomDel.Checked = My.Settings.DomDeleteMedia

		NBTeaseLengthMin.Value = My.Settings.TeaseLengthMin
		NBTeaseLengthMax.Value = My.Settings.TeaseLengthMax

		NBTauntCycleMin.Value = My.Settings.TauntCycleMin
		NBTauntCycleMax.Value = My.Settings.TauntCycleMax

		NBRedLightMin.Value = My.Settings.RedLightMin
		NBRedLightMax.Value = My.Settings.RedLightMax

		NBGreenLightMin.Value = My.Settings.GreenLightMin
		NBGreenLightMax.Value = My.Settings.GreenLightMax

		NBTeaseLengthMin.Value = My.Settings.TeaseLengthMin
		NBTeaseLengthMax.Value = My.Settings.TeaseLengthMax

		' teaseRadio.Checked = True

		' If My.Settings.SlideshowMode - "Tease" Then teaseRadio.Checked = True
		'If My.Settings.SlideshowMode = "Manual" Then offRadio.Checked = True
		'If My.Settings.SlideshowMode = "Timer" Then timedRadio.Checked = True

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Auditing scripts..."
		FrmSplash.Refresh()

		CBAuditStartup.Checked = My.Settings.AuditStartup

		If CBAuditStartup.Checked = True Then AuditScripts()


		TBWebStart.Text = My.Settings.WebToyStart
		TBWebStop.Text = My.Settings.WebToyStop

		CBCockToClit.Checked = My.Settings.CockToClit
		CBBallsToPussy.Checked = My.Settings.BallsToPussy


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Calculating space of saved session images..."
		FrmSplash.Refresh()

		CalculateSessionImages()


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Settings Menu options..."
		FrmSplash.Refresh()

		SaveSettingsDialog.InitialDirectory = Application.StartupPath & "\System"
		OpenSettingsDialog.InitialDirectory = Application.StartupPath & "\System"

		GP1.AllowDrop = True
		GP2.AllowDrop = True
		GP3.AllowDrop = True
		GP4.AllowDrop = True
		GP5.AllowDrop = True
		GP6.AllowDrop = True



		'dompersonalityComboBox.Text = PersonType
		Debug.Print("Dom personality = " & Form1.dompersonalitycombobox.Text)
		Debug.Print("WEB THING HELLO???" & Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
		WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")


		LBLContact1ImageDir.Text = My.Settings.Contact1ImageDir
		LBLContact2ImageDir.Text = My.Settings.Contact2ImageDir
		LBLContact3ImageDir.Text = My.Settings.Contact3ImageDir

		If My.Settings.TeaseAILanguage = "English" Then EnglishMenu()
		If My.Settings.TeaseAILanguage = "German" Then GermanMenu()

		Try
			TimeBoxWakeUp.Value = My.Settings.WakeUp
		Catch
		End Try

		NBTypoChance.Value = My.Settings.TypoChance

		SliderVVolume.Value = My.Settings.VVolume
		SliderVRate.Value = My.Settings.VRate

		LBLVVolume.Text = SliderVVolume.Value
		LBLVRate.Text = SliderVRate.Value

		FrmSettingsLoading = False

		Me.Visible = False



		Debug.Print("Form2 Loading Finished")


	End Sub

	Private Sub BindCombo()
		FontComboBox.DrawMode = DrawMode.OwnerDrawFixed
		FontComboBox.Font = New Font("Microsoft Sans Serif, 11.25pt", 11.25)
		FontComboBox.ItemHeight = 20
		Dim objFontFamily As FontFamily
		Dim objFontCollection As System.Drawing.Text.FontCollection
		Dim tempFont As Font
		objFontCollection = New System.Drawing.Text.InstalledFontCollection()
		For Each objFontFamily In objFontCollection.Families
			FontComboBox.Items.Add(objFontFamily.Name)

		Next
	End Sub

	Private Sub BindCombo2()
		FontComboBoxD.DrawMode = DrawMode.OwnerDrawFixed
		FontComboBoxD.Font = New Font("Microsoft Sans Serif, 11.25pt", 11.25)
		FontComboBoxD.ItemHeight = 20
		Dim objFontFamily As FontFamily
		Dim objFontCollection As System.Drawing.Text.FontCollection
		Dim tempFont As Font
		objFontCollection = New System.Drawing.Text.InstalledFontCollection()
		For Each objFontFamily In objFontCollection.Families
			FontComboBoxD.Items.Add(objFontFamily.Name)

		Next
	End Sub

	Private Sub ComboBox1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles FontComboBox.DrawItem
		e.DrawBackground()
		If (e.State And DrawItemState.Focus) <> 0 Then
			e.DrawFocusRectangle()
		End If
		Dim objBrush As Brush = Nothing
		Try
			objBrush = New SolidBrush(e.ForeColor)
			Dim _FontName As String = FontComboBox.Items(e.Index)
			Dim _font As Font
			Dim _fontfamily = New FontFamily(_FontName)
			If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
				_font = New Font(_fontfamily, 14, FontStyle.Regular)
			ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
				_font = New Font(_fontfamily, 14, FontStyle.Bold)
			ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
				_font = New Font(_fontfamily, 14, FontStyle.Italic)
			End If
			e.Graphics.DrawString(_FontName, _font, objBrush, e.Bounds)
		Finally
			If objBrush IsNot Nothing Then
				objBrush.Dispose()
			End If
			objBrush = Nothing
		End Try
	End Sub

	Private Sub ComboBox1D_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles FontComboBoxD.DrawItem
		e.DrawBackground()
		If (e.State And DrawItemState.Focus) <> 0 Then
			e.DrawFocusRectangle()
		End If
		Dim objBrush As Brush = Nothing
		Try
			objBrush = New SolidBrush(e.ForeColor)
			Dim _FontName As String = FontComboBoxD.Items(e.Index)
			Dim _font As Font
			Dim _fontfamily = New FontFamily(_FontName)
			If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
				_font = New Font(_fontfamily, 14, FontStyle.Regular)
			ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
				_font = New Font(_fontfamily, 14, FontStyle.Bold)
			ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
				_font = New Font(_fontfamily, 14, FontStyle.Italic)
			End If
			e.Graphics.DrawString(_FontName, _font, objBrush, e.Bounds)
		Finally
			If objBrush IsNot Nothing Then
				objBrush.Dispose()
			End If
			objBrush = Nothing
		End Try
	End Sub










	Private Sub CockSizeNumBox_ValueChanged(sender As System.Object, e As System.EventArgs) Handles CockSizeNumBox.ValueChanged
		Form1.CockSize = CockSizeNumBox.Value
	End Sub

	Private Sub CockSizeNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles CockSizeNumBox.LostFocus
		My.Settings.SubCockSize = CockSizeNumBox.Value
		My.Settings.Save()
	End Sub

	Private Sub BTNVideoHardCore_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoHardCore.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoHardCore.Text = FolderBrowserDialog1.SelectedPath
			Form1.HardCoreVideoTotal()
			My.Settings.VideoHardcore = LblVideoHardCore.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoSoftCore_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoSoftCore.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoSoftCore.Text = FolderBrowserDialog1.SelectedPath
			Form1.SoftcoreVideoTotal()
			My.Settings.VideoSoftcore = LblVideoSoftCore.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoLesbian_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoLesbian.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoLesbian.Text = FolderBrowserDialog1.SelectedPath
			Form1.LesbianVideoTotal()
			My.Settings.VideoLesbian = LblVideoLesbian.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoBlowjob.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoBlowjob.Text = FolderBrowserDialog1.SelectedPath
			Form1.BlowjobVideoTotal()
			My.Settings.VideoBlowjob = LblVideoBlowjob.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoFemDom_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemDom.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoFemdom.Text = FolderBrowserDialog1.SelectedPath
			Form1.FemdomVideoTotal()
			My.Settings.VideoFemdom = LblVideoFemdom.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoFemSub_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemSub.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoFemsub.Text = FolderBrowserDialog1.SelectedPath
			Form1.FemsubVideoTotal()
			My.Settings.VideoFemsub = LblVideoFemsub.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoJOI_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoJOI.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoJOI.Text = FolderBrowserDialog1.SelectedPath
			Form1.JOIVideoTotal()
			My.Settings.VideoJOI = LblVideoJOI.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoCH_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoCH.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoCH.Text = FolderBrowserDialog1.SelectedPath
			Form1.CHVideoTotal()
			My.Settings.VideoCH = LblVideoCH.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoGeneral_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoGeneral.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoGeneral.Text = FolderBrowserDialog1.SelectedPath
			Form1.GeneralVideoTotal()
			My.Settings.VideoGeneral = LblVideoGeneral.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoHardcoreD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoHardCoreD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoHardCoreD.Text = FolderBrowserDialog1.SelectedPath
			Form1.HardcoreDVideoTotal()
			My.Settings.VideoHardcoreD = LblVideoHardCoreD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoSoftcoreD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoSoftCoreD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoSoftCoreD.Text = FolderBrowserDialog1.SelectedPath
			Form1.SoftcoreDVideoTotal()
			My.Settings.VideoSoftcoreD = LblVideoSoftCoreD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoLesbianD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoLesbianD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoLesbianD.Text = FolderBrowserDialog1.SelectedPath
			Form1.LesbianDVideoTotal()
			My.Settings.VideoLesbianD = LblVideoLesbianD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoBlowjobD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoBlowjobD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoBlowjobD.Text = FolderBrowserDialog1.SelectedPath
			Form1.BlowjobDVideoTotal()
			My.Settings.VideoBlowjobD = LblVideoBlowjobD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoFemdomD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemDomD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoFemdomD.Text = FolderBrowserDialog1.SelectedPath
			Form1.FemdomDVideoTotal()
			My.Settings.VideoFemdomD = LblVideoFemdomD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoFemsubD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemSubD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoFemsubD.Text = FolderBrowserDialog1.SelectedPath
			Form1.FemsubDVideoTotal()
			My.Settings.VideoFemsubD = LblVideoFemsubD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoJOID_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoJOID.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoJOID.Text = FolderBrowserDialog1.SelectedPath
			Form1.JOIDVideoTotal()
			My.Settings.VideoJOID = LblVideoJOID.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoCHD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoCHD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoCHD.Text = FolderBrowserDialog1.SelectedPath
			Form1.CHDVideoTotal()
			My.Settings.VideoCHD = LblVideoCHD.Text
			My.Settings.Save()
		End If

	End Sub

	Private Sub BTNVideoGeneralD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoGeneralD.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LblVideoGeneralD.Text = FolderBrowserDialog1.SelectedPath
			Form1.GeneralDVideoTotal()
			My.Settings.VideoGeneralD = LblVideoGeneralD.Text
			My.Settings.Save()
		End If

	End Sub


	Private Sub CBVideoHardcore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoHardcore.CheckedChanged
		If CBVideoHardcore.Checked = True Then
			My.Settings.CBHardcore = True
		Else
			My.Settings.CBHardcore = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoSoftCore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoSoftCore.CheckedChanged
		If CBVideoSoftCore.Checked = True Then
			My.Settings.CBSoftcore = True
		Else
			My.Settings.CBSoftcore = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoLesbian_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoLesbian.CheckedChanged
		If CBVideoLesbian.Checked = True Then
			My.Settings.CBLesbian = True
		Else
			My.Settings.CBLesbian = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoBlowjob_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoBlowjob.CheckedChanged
		If CBVideoBlowjob.Checked = True Then
			My.Settings.CBBlowjob = True
		Else
			My.Settings.CBBlowjob = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoFemdom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoFemdom.CheckedChanged
		If CBVideoFemdom.Checked = True Then
			My.Settings.CBFemdom = True
		Else
			My.Settings.CBFemdom = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoFemSub_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoFemsub.CheckedChanged
		If CBVideoFemsub.Checked = True Then
			My.Settings.CBFemsub = True
		Else
			My.Settings.CBFemsub = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoJOI_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoJOI.CheckedChanged
		If CBVideoJOI.Checked = True Then
			My.Settings.CBJOI = True
		Else
			My.Settings.CBJOI = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoCH_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoCH.CheckedChanged
		If CBVideoCH.Checked = True Then
			My.Settings.CBCH = True
		Else
			My.Settings.CBCH = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoGeneral.CheckedChanged
		If CBVideoGeneral.Checked = True Then
			My.Settings.CBGeneral = True
		Else
			My.Settings.CBGeneral = False
		End If
		My.Settings.Save()
	End Sub


	Private Sub CBVideoHardcoreD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoHardcoreD.CheckedChanged
		If CBVideoHardcoreD.Checked = True Then
			My.Settings.CBHardcoreD = True
		Else
			My.Settings.CBHardcoreD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoSoftcoreD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoSoftCoreD.CheckedChanged
		If CBVideoSoftCoreD.Checked = True Then
			My.Settings.CBSoftcoreD = True
		Else
			My.Settings.CBSoftcoreD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoLesbianD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoLesbianD.CheckedChanged
		If CBVideoLesbianD.Checked = True Then
			My.Settings.CBLesbianD = True
		Else
			My.Settings.CBLesbianD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoBlowjobD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoBlowjobD.CheckedChanged
		If CBVideoBlowjobD.Checked = True Then
			My.Settings.CBBlowjobD = True
		Else
			My.Settings.CBBlowjobD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoFemdomD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoFemdomD.CheckedChanged
		If CBVideoFemdomD.Checked = True Then
			My.Settings.CBFemdomD = True
		Else
			My.Settings.CBFemdomD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoFemsubD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoFemsubD.CheckedChanged
		If CBVideoFemsubD.Checked = True Then
			My.Settings.CBFemsubD = True
		Else
			My.Settings.CBFemsubD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoJOID_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoJOID.CheckedChanged
		If CBVideoJOID.Checked = True Then
			My.Settings.CBJOID = True
		Else
			My.Settings.CBJOID = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoCHD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoCHD.CheckedChanged
		If CBVideoCHD.Checked = True Then
			My.Settings.CBCHD = True
		Else
			My.Settings.CBCHD = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBVideoGeneralD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVideoGeneralD.CheckedChanged
		If CBVideoGeneralD.Checked = True Then
			My.Settings.CBGeneralD = True
		Else
			My.Settings.CBGeneralD = False
		End If
		My.Settings.Save()
	End Sub


	Private Sub NBCensorShowMin_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMin.Leave
		My.Settings.NBCensorShowMin = NBCensorShowMin.Value
		My.Settings.Save()
		Debug.Print(My.Settings.NBCensorShowMin & " " & NBCensorShowMin.Value)
	End Sub

	Private Sub NBCensorShowMax_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMax.Leave
		My.Settings.NBCensorShowMax = NBCensorShowMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBCensorHideMin_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMin.Leave
		My.Settings.NBCensorHideMin = NBCensorHideMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBCensorHideMax_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMax.Leave
		My.Settings.NBCensorHideMax = NBCensorHideMax.Value
		My.Settings.Save()
	End Sub

	Private Sub CBCensorConstant_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCensorConstant.CheckedChanged
		If CBCensorConstant.Checked = True Then
			My.Settings.CBCensorConstant = True
		Else
			My.Settings.CBCensorConstant = False
		End If
		My.Settings.Save()
	End Sub

	Public Function Color2Html(ByVal MyColor As Color) As String
		Return "#" & MyColor.ToArgb().ToString("x").Substring(2).ToUpper
	End Function

#Region "Glitter"
	Private Sub GlitterAV_Click(sender As System.Object, e As System.EventArgs)
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			GlitterAV.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.GlitterAV = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub
	Private Sub GlitterAV_Click_1(sender As System.Object, e As System.EventArgs) Handles GlitterAV.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				GlitterAV.Image.Dispose()
			Catch
			End Try
			GlitterAV.Image = Nothing
			GC.Collect()
			GlitterAV.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.GlitterAV = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub
	Private Sub GlitterAV1_Click(sender As System.Object, e As System.EventArgs) Handles GlitterAV1.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				GlitterAV1.Image.Dispose()
			Catch
			End Try
			GlitterAV1.Image = Nothing
			GC.Collect()
			GlitterAV1.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.GlitterAV1 = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub
	Private Sub GlitterAV2_Click(sender As System.Object, e As System.EventArgs) Handles GlitterAV2.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				GlitterAV2.Image.Dispose()
			Catch
			End Try
			GlitterAV2.Image = Nothing
			GC.Collect()
			GlitterAV2.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.GlitterAV2 = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub
	Private Sub GlitterAV3_Click(sender As System.Object, e As System.EventArgs) Handles GlitterAV3.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				GlitterAV3.Image.Dispose()
			Catch
			End Try
			GlitterAV3.Image = Nothing
			GC.Collect()
			GlitterAV3.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.GlitterAV3 = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub
	Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitterD.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.GlitterNCDommeColor = GetColor.Color
			LBLGlitterNCDomme.ForeColor = GetColor.Color
			Form1.GlitterNCDomme = Color2Html(GetColor.Color)
			My.Settings.GlitterNCDomme = Form1.GlitterNCDomme
			My.Settings.Save()
			Debug.Print("GlitterNCDomme = " & Form1.GlitterNCDomme)
		End If
	End Sub
	Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitter1.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.GlitterNC1Color = GetColor.Color
			LBLGlitterNC1.ForeColor = GetColor.Color
			Form1.GlitterNC1 = Color2Html(GetColor.Color)
			My.Settings.GlitterNC1 = Form1.GlitterNC1
			My.Settings.Save()
			Debug.Print("GlitterNC1 = " & Form1.GlitterNC1)
		End If
	End Sub
	Private Sub Button4_Click_3(sender As System.Object, e As System.EventArgs) Handles BTNGlitter2.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.GlitterNC2Color = GetColor.Color
			LBLGlitterNC2.ForeColor = GetColor.Color
			Form1.GlitterNC2 = Color2Html(GetColor.Color)
			My.Settings.GlitterNC2 = Form1.GlitterNC2
			My.Settings.Save()
			Debug.Print("GlitterNC2 = " & Form1.GlitterNC2)
		End If
	End Sub
	Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitter3.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.GlitterNC3Color = GetColor.Color
			LBLGlitterNC3.ForeColor = GetColor.Color
			Form1.GlitterNC3 = Color2Html(GetColor.Color)
			My.Settings.GlitterNC3 = Form1.GlitterNC3
			My.Settings.Save()
			Debug.Print("GlitterNC3 = " & Form1.GlitterNC3)
		End If
	End Sub
	Private Sub TBGlitterShortName_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBGlitterShortName.Leave
		My.Settings.GlitterSN = TBGlitterShortName.Text
		My.Settings.Save()
	End Sub
	Private Sub TBGlitter1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBGlitter1.Leave
		My.Settings.Glitter1 = TBGlitter1.Text
		My.Settings.Save()
	End Sub
	Private Sub TBGlitter2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBGlitter2.Leave
		My.Settings.Glitter2 = TBGlitter2.Text
		My.Settings.Save()
	End Sub
	Private Sub TBGlitter3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBGlitter3.Leave
		My.Settings.Glitter3 = TBGlitter3.Text
		My.Settings.Save()
	End Sub
	Private Sub GlitterSlider_Scroll(sender As System.Object, e As System.EventArgs) Handles GlitterSlider.Scroll
		My.Settings.GlitterDSlider = GlitterSlider.Value
		My.Settings.Save()
	End Sub
	Private Sub GlitterSlider1_Scroll(sender As System.Object, e As System.EventArgs) Handles GlitterSlider1.Scroll
		My.Settings.Glitter1Slider = GlitterSlider1.Value
		My.Settings.Save()
	End Sub
	Private Sub GlitterSlider2_Scroll(sender As System.Object, e As System.EventArgs) Handles GlitterSlider2.Scroll
		My.Settings.Glitter2Slider = GlitterSlider2.Value
		My.Settings.Save()
	End Sub
	Private Sub GlitterSlider3_Scroll(sender As System.Object, e As System.EventArgs) Handles GlitterSlider3.Scroll
		My.Settings.Glitter3Slider = GlitterSlider3.Value
		My.Settings.Save()
	End Sub
	Private Sub CBGlitterFeed_CheckedChanged(sender As System.Object, e As System.EventArgs)
		If CBGlitterFeed.Checked = True Then
			My.Settings.CBGlitterFeed = True
		Else
			My.Settings.CBGlitterFeed = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBGlitter1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBGlitter1.CheckedChanged
		If CBGlitter1.Checked = True Then
			My.Settings.CBGlitter1 = True
		Else
			My.Settings.CBGlitter1 = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBGlitter2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBGlitter2.CheckedChanged
		If CBGlitter2.Checked = True Then
			My.Settings.CBGlitter2 = True
		Else
			My.Settings.CBGlitter2 = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBGlitter3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBGlitter3.CheckedChanged
		If CBGlitter3.Checked = True Then
			My.Settings.CBGlitter3 = True
		Else
			My.Settings.CBGlitter3 = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBTease_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBTease.CheckedChanged
		If CBTease.Checked = True Then
			My.Settings.CBTease = True
		Else
			My.Settings.CBTease = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBEgotist_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBEgotist.CheckedChanged
		If CBEgotist.Checked = True Then
			My.Settings.CBEgotist = True
		Else
			My.Settings.CBEgotist = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBTrivia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBTrivia.CheckedChanged
		If CBTrivia.Checked = True Then
			My.Settings.CBTrivia = True
		Else
			My.Settings.CBTrivia = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBDaily_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBDaily.CheckedChanged
		If CBDaily.Checked = True Then
			My.Settings.CBDaily = True
		Else
			My.Settings.CBDaily = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBCustom1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCustom1.CheckedChanged
		If CBCustom1.Checked = True Then
			My.Settings.CBCustom1 = True
		Else
			My.Settings.CBCustom1 = False
		End If
		My.Settings.Save()
	End Sub
	Private Sub CBCustom2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCustom2.CheckedChanged
		If CBCustom2.Checked = True Then
			My.Settings.CBCustom2 = True
		Else
			My.Settings.CBCustom2 = False
		End If
		My.Settings.Save()
	End Sub


	' Private Sub CBGlitterFeed_MouseHover(sender As Object, e As System.EventArgs)
	'    LblGlitterSettingsDescription.Text = "This check box turns Glitter functionality on and off. Glitter is a fictional app located in the sidebar on the left side of the window. It is meant to emulate a social media feed " _
	'       & "where the domme posts various thoughts that her contacts might then comment on. When this box is checked, the domme's posts and responses will appear in the Glitter app according to the settings above. " _
	'      & "If this box is unchecked, no new posts or responses will appear in the feed."
	'End Sub
	Private Sub BTNGlitterD_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitterD.MouseHover

		TTDir.SetToolTip(BTNGlitterD, "This button allows you to change the color of the domme's name as it appears in the Glitter app." & Environment.NewLine &
									  "A preview will appear in the text box below this button once a color has been selected.")

	End Sub
	Private Sub GlitterAV_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV.MouseHover
		TTDir.SetToolTip(GlitterAV, "Click here to set the image the domme will use as her Glitter avatar.")
	End Sub
	Private Sub LBLGlitterNCDomme_Click(sender As System.Object, e As System.EventArgs) Handles LBLGlitterNCDomme.MouseHover
		TTDir.SetToolTip(LBLGlitterNCDomme, "After clicking the ""Choose Name Color"" button above, a preview of the selected color will appear here.")
	End Sub
	Private Sub LBLGlitterNC1_Click(sender As System.Object, e As System.EventArgs) Handles LBLGlitterNC1.MouseHover
		TTDir.SetToolTip(LBLGlitterNC1, "After clicking the ""Choose Name Color"" button above, a preview of the selected color will appear here.")
	End Sub
	Private Sub LBLGlitterNC2_Click(sender As System.Object, e As System.EventArgs) Handles LBLGlitterNC2.MouseHover
		TTDir.SetToolTip(LBLGlitterNC2, "After clicking the ""Choose Name Color"" button above, a preview of the selected color will appear here.")
	End Sub
	Private Sub LBLGlitterNC3_Click(sender As System.Object, e As System.EventArgs) Handles LBLGlitterNC3.MouseHover
		TTDir.SetToolTip(LBLGlitterNC3, "After clicking the ""Choose Name Color"" button above, a preview of the selected color will appear here.")
	End Sub
	Private Sub TBGlitterShortName_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles TBGlitterShortName.MouseHover
		TTDir.SetToolTip(TBGlitterShortName, "This is the name that the domme's contacts will refer to her as in the Glitter feed.")
	End Sub
	Private Sub CBTease_MouseHover(sender As Object, e As System.EventArgs) Handles CBTease.MouseHover
		TTDir.SetToolTip(CBTease, "When this box is checked, the domme will make posts referencing your ongoing teasing and denial.")
	End Sub
	Private Sub CBEgotist_MouseHover(sender As Object, e As System.EventArgs) Handles CBEgotist.MouseHover
		TTDir.SetToolTip(CBEgotist, "When this box is checked, the domme will make self-centered posts stating how amazing she is.")
	End Sub
	Private Sub CBTrivia_MouseHover(sender As Object, e As System.EventArgs) Handles CBTrivia.MouseHover
		TTDir.SetToolTip(CBTrivia, "When this box is checked, the domme will make posts containing quotes or general trivia.")
	End Sub
	Private Sub CBDaily_MouseHover(sender As Object, e As System.EventArgs) Handles CBDaily.MouseHover
		TTDir.SetToolTip(CBDaily, "When this box is checked, the domme will make mundane posts about her day.")
	End Sub
	Private Sub CBCustom1_MouseHover(sender As Object, e As System.EventArgs) Handles CBCustom1.MouseHover
		TTDir.SetToolTip(CBCustom1, "When this box is checked, the domme will make posts taken from Custom 1" & Environment.NewLine &
								  "folder in the Glitter scripts directory for her personality style.")
	End Sub
	Private Sub CBCustom2_MouseHover(sender As Object, e As System.EventArgs) Handles CBCustom2.MouseHover
		TTDir.SetToolTip(CBCustom2, "When this box is checked, the domme will make posts taken from Custom 2" & Environment.NewLine &
								  "folder in the Glitter scripts directory for her personality style.")
	End Sub
	Private Sub GlitterSlider_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterSlider.MouseHover
		TTDir.SetToolTip(GlitterSlider, "This slider determines how often the domme makes Glitter posts on her own." & Environment.NewLine &
											 "The further to the right the slider is, the more often she posts.")
	End Sub
	Private Sub LBLGlitterSlider_MouseHover(sender As Object, e As System.EventArgs) Handles LBLGlitterSlider.MouseHover
		TTDir.SetToolTip(LBLGlitterSlider, "This slider determines how often the domme makes Glitter posts on her own." & Environment.NewLine &
											 "The further to the right the slider is, the more often she posts.")
	End Sub

	Private Sub TBGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles TBGlitter1.MouseHover
		TTDir.SetToolTip(TBGlitter1, "This will be the name of this contact as it appears in the Glitter feed.")
	End Sub
	Private Sub TBGlitter2_MouseHover(sender As Object, e As System.EventArgs) Handles TBGlitter2.MouseHover
		TTDir.SetToolTip(TBGlitter2, "This will be the name of this contact as it appears in the Glitter feed.")
	End Sub
	Private Sub TBGlitter3_MouseHover(sender As Object, e As System.EventArgs) Handles TBGlitter3.MouseHover
		TTDir.SetToolTip(TBGlitter3, "This will be the name of this contact as it appears in the Glitter feed.")
	End Sub
	Private Sub GlitterSlider1_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterSlider1.MouseHover
		TTDir.SetToolTip(GlitterSlider1, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub GlitterSlider2_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterSlider2.MouseHover
		TTDir.SetToolTip(GlitterSlider2, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub GlitterSlider3_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterSlider3.MouseHover
		TTDir.SetToolTip(GlitterSlider3, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub LBLGlitterSlider1_MouseHover(sender As Object, e As System.EventArgs) Handles LBLGlitterSlider1.MouseHover
		TTDir.SetToolTip(LBLGlitterSlider1, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub LBLGlitterSlider2_MouseHover(sender As Object, e As System.EventArgs) Handles LBLGlitterSlider2.MouseHover
		TTDir.SetToolTip(LBLGlitterSlider2, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub LBLGlitterSlider3_MouseHover(sender As Object, e As System.EventArgs) Handles LBLGlitterSlider3.MouseHover
		TTDir.SetToolTip(LBLGlitterSlider3, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub GlitterAV1_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV1.MouseHover
		TTDir.SetToolTip(GlitterAV1, "Click here to set the image that this contact will use as her Glitter avatar.")
	End Sub
	Private Sub GlitterAV2_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV2.MouseHover
		TTDir.SetToolTip(GlitterAV2, "Click here to set the image that this contact will use as her Glitter avatar.")
	End Sub
	Private Sub GlitterAV3_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV3.MouseHover
		TTDir.SetToolTip(GlitterAV3, "Click here to set the image that this contact will use as her Glitter avatar.")
	End Sub
	Private Sub CBGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles CBGlitter1.MouseHover
		TTDir.SetToolTip(CBGlitter1, "This check box enables this contact's participation in the Glitter feed.")
	End Sub
	Private Sub CBGlitter2_MouseHover(sender As Object, e As System.EventArgs) Handles CBGlitter2.MouseHover
		TTDir.SetToolTip(CBGlitter2, "This check box enables this contact's participation in the Glitter feed.")
	End Sub
	Private Sub CBGlitter3_MouseHover(sender As Object, e As System.EventArgs) Handles CBGlitter3.MouseHover
		TTDir.SetToolTip(CBGlitter3, "This check box enables this contact's participation in the Glitter feed.")
	End Sub
	Private Sub BTNGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitter1.MouseHover
		TTDir.SetToolTip(BTNGlitter1, "This button allows you to change the color of this contact's name as it appears in the Glitter app.")
	End Sub
	Private Sub BTNGlitter2_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitter2.MouseHover
		TTDir.SetToolTip(BTNGlitter2, "This button allows you to change the color of this contact's name as it appears in the Glitter app.")
	End Sub
	Private Sub BTNGlitter3_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitter3.MouseHover
		TTDir.SetToolTip(BTNGlitter3, "This button allows you to change the color of this contact's name as it appears in the Glitter app.")
	End Sub
#End Region

	Private Sub Button21_Click(sender As System.Object, e As System.EventArgs)

		Form1.ScriptTimer.Start()

		' Dim TestString As String
		'Dim TSStartIndex As Integer
		'Dim TSEndIndex As Integer

		'TSStartIndex = TextBox3.Text.IndexOf("@Chance") + 7
		'TSEndIndex = TextBox3.Text.IndexOf("@Chance") + 9

		'TestString = TextBox3.Text
		'TestString = TestString.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim

		'        Dim TestVal As Integer

		' TestVal = Val(TestString)

		'Debug.Print("Check Substring " & TestString & " , " & TestVal)
	End Sub



	Private Sub NBCensorShowMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMin.ValueChanged
		If NBCensorShowMin.Value > NBCensorShowMax.Value Then NBCensorShowMin.Value = NBCensorShowMax.Value
	End Sub

	Private Sub NBCensorShowMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMax.ValueChanged
		If NBCensorShowMax.Value < NBCensorShowMin.Value Then NBCensorShowMax.Value = NBCensorShowMin.Value
	End Sub

	Private Sub NBTeaseLengthMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMin.LostFocus
		My.Settings.TeaseLengthMin = NBTeaseLengthMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBTeaseLengthMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMax.LostFocus
		My.Settings.TeaseLengthMax = NBTeaseLengthMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBTauntCycleMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBTauntCycleMin.LostFocus
		My.Settings.TauntCycleMin = NBTauntCycleMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBTauntCycleMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBTauntCycleMax.LostFocus
		My.Settings.TauntCycleMax = NBTauntCycleMax.Value
		My.Settings.Save()
	End Sub
	Private Sub NBRedLightMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBRedLightMin.LostFocus
		My.Settings.RedLightMin = NBRedLightMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBRedLightMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBRedLightMax.LostFocus
		My.Settings.RedLightMax = NBRedLightMax.Value
		My.Settings.Save()
	End Sub
	Private Sub NBGreenLightMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBGreenLightMin.LostFocus
		My.Settings.GreenLightMin = NBGreenLightMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBGreenLightMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBGreenLightMax.LostFocus
		My.Settings.GreenLightMax = NBGreenLightMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBTeaseLengthMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTeaseLengthMin.ValueChanged
		If NBTeaseLengthMin.Value > NBTeaseLengthMax.Value Then NBTeaseLengthMin.Value = NBTeaseLengthMax.Value
	End Sub

	Private Sub NBTeaseLengthMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTeaseLengthMax.ValueChanged
		If NBTeaseLengthMax.Value < NBTeaseLengthMin.Value Then NBTeaseLengthMax.Value = NBTeaseLengthMin.Value
	End Sub

	Private Sub NBTauntCycleMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTauntCycleMin.ValueChanged
		If NBTauntCycleMin.Value > NBTauntCycleMax.Value Then NBTauntCycleMin.Value = NBTauntCycleMax.Value
	End Sub

	Private Sub NBTauntCycleMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTauntCycleMax.ValueChanged
		If NBTauntCycleMax.Value < NBTauntCycleMin.Value Then NBTauntCycleMax.Value = NBTauntCycleMin.Value
	End Sub



	Private Sub NBCensorHideMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMin.ValueChanged
		If NBCensorHideMin.Value > NBCensorHideMax.Value Then NBCensorHideMin.Value = NBCensorHideMax.Value
	End Sub

	Private Sub NBCensorHideMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMax.ValueChanged
		If NBCensorHideMax.Value < NBCensorHideMin.Value Then NBCensorHideMax.Value = NBCensorHideMin.Value
	End Sub

	Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles BTNRefreshVideos.Click
		Form1.RefreshVideoTotal = 0

		Form1.HardCoreVideoTotal()
		Form1.SoftcoreVideoTotal()
		Form1.LesbianVideoTotal()
		Form1.BlowjobVideoTotal()
		Form1.FemdomVideoTotal()
		Form1.FemsubVideoTotal()
		Form1.JOIVideoTotal()
		Form1.CHVideoTotal()
		Form1.GeneralVideoTotal()

		Form1.HardcoreDVideoTotal()
		Form1.SoftcoreDVideoTotal()
		Form1.LesbianDVideoTotal()
		Form1.BlowjobDVideoTotal()
		Form1.FemdomDVideoTotal()
		Form1.FemsubDVideoTotal()
		Form1.JOIDVideoTotal()
		Form1.CHDVideoTotal()
		Form1.GeneralDVideoTotal()

		VideoDescriptionLabel.Text = "Refresh complete: " & Form1.RefreshVideoTotal & " videos found!"
		VideoDescriptionLabel.Text = VideoDescriptionLabel.Text.Replace(": 1 videos", ": 1 video")
	End Sub







#Region "Save PetNames"

	Private Sub petnameBox1_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox1.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox1.Text = "" Then petnameBox1.Text = BlankName

		SavePetNames()

	End Sub


	Private Sub petnameBox2_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox3.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox3.Text = "" Then petnameBox3.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox3_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox4.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox4.Text = "" Then petnameBox4.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox4_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox7.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox7.Text = "" Then petnameBox7.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox5_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox2.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox2.Text = "" Then petnameBox2.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox6_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox5.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "loser"
		If NameVal = 3 Then BlankName = "slave"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox5.Text = "" Then petnameBox5.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox7_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox6.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "slave"
		If NameVal = 3 Then BlankName = "pet"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox6.Text = "" Then petnameBox6.Text = BlankName

		SavePetNames()

	End Sub

	Private Sub petnameBox8_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox8.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.randomizer.Next(1, 6)

		If NameVal = 1 Then BlankName = "stroker"
		If NameVal = 2 Then BlankName = "slave"
		If NameVal = 3 Then BlankName = "pet"
		If NameVal = 4 Then BlankName = "bitch boy"
		If NameVal = 5 Then BlankName = "wanker"

		If petnameBox8.Text = "" Then petnameBox8.Text = BlankName

		SavePetNames()

	End Sub


	Public Sub SavePetNames()

		My.Settings.pnSetting1 = petnameBox1.Text
		My.Settings.pnSetting2 = petnameBox2.Text
		My.Settings.pnSetting3 = petnameBox3.Text
		My.Settings.pnSetting4 = petnameBox4.Text
		My.Settings.pnSetting5 = petnameBox5.Text
		My.Settings.pnSetting6 = petnameBox6.Text
		My.Settings.pnSetting7 = petnameBox7.Text
		My.Settings.pnSetting8 = petnameBox8.Text

		My.Settings.Save()

	End Sub

#End Region


	Private Sub Button26_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNVideoModLoad.Click

		Dim CensorText As String = "NULL"

		If CBVTType.Text = "Censorship Sucks" Then
			If LBVidScript.SelectedItem = "CensorBarOff" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Censorship Sucks\CensorBarOff.txt"
			If LBVidScript.SelectedItem = "CensorBarOn" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Censorship Sucks\CensorBarOn.txt"
		End If

		If CBVTType.Text = "Avoid The Edge" Then
			If LBVidScript.SelectedItem = "Taunts" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Avoid The Edge\Taunts.txt"
		End If

		If CBVTType.Text = "Red Light Green Light" Then
			If LBVidScript.SelectedItem = "Green Light" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Red Light Green Light\Green Light.txt"
			If LBVidScript.SelectedItem = "Red Light" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Red Light Green Light\Red Light.txt"
			If LBVidScript.SelectedItem = "Taunts" Then CensorText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Video\Red Light Green Light\Taunts.txt"
		End If

		Form1.VTPath = CensorText

		Try
			Dim VidReader As New StreamReader(CensorText)
			Dim VidList As New List(Of String)

			While VidReader.Peek <> -1
				VidList.Add(VidReader.ReadLine())
			End While

			VidReader.Close()
			VidReader.Dispose()

			Dim VidString As String

			For i As Integer = 0 To VidList.Count - 1
				If i <> VidList.Count - 1 Then
					VidString = VidString & VidList(i) & Environment.NewLine
				Else
					VidString = VidString & VidList(i)
				End If
			Next

			RTBVideoMod.Text = VidString

			LBVidScript.Enabled = False
			CBVTType.Enabled = False
			BTNVideoModClear.Enabled = True
			BTNVideoModLoad.Enabled = False
			RTBVideoMod.Enabled = True
			BTNVideoModSave.Enabled = False
		Catch
		End Try



	End Sub

	Private Sub RTBVideoMod_TextChanged(sender As System.Object, e As System.EventArgs) Handles RTBVideoMod.TextChanged
		BTNVideoModSave.Enabled = True
	End Sub

	Private Sub BTNVideoModClear_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoModClear.Click
		BTNVideoModClear.Enabled = False
		BTNVideoModLoad.Enabled = True
		CBVTType.Enabled = True
		RTBVideoMod.Text = ""
		RTBVideoMod.Enabled = False
		BTNVideoModSave.Enabled = False
		LBVidScript.Enabled = True
	End Sub

	Private Sub BTNVideoModSave_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoModSave.Click




		If MsgBox("This will overwrite the current " & CBVTType.Text & " script!" & Environment.NewLine & Environment.NewLine & "Are you sure?", vbYesNo, "Warning!") = MsgBoxResult.Yes Then
			Debug.Print("Worked?")
		Else
			Debug.Print("Did not work")
			Return
		End If


		My.Computer.FileSystem.DeleteFile(Form1.VTPath)

		Dim WriteList As New List(Of String)

		WriteList.Clear()

		For i As Integer = 0 To RTBVideoMod.Lines.Count - 1
			If i <> RTBVideoMod.Lines.Count - 1 Then
				WriteList.Add(RTBVideoMod.Lines(i) & Environment.NewLine)
			Else
				WriteList.Add(RTBVideoMod.Lines(i))
			End If
		Next


		For i As Integer = 0 To WriteList.Count - 1
			If i <> WriteList.Count - 1 Then
				My.Computer.FileSystem.WriteAllText(Form1.VTPath, WriteList(i), True)
			Else
				My.Computer.FileSystem.WriteAllText(Form1.VTPath, WriteList(i), True)
			End If
		Next

		MessageBox.Show(Me, "File saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

		BTNVideoModSave.Enabled = False

	End Sub



	Private Sub Button26_Click_2(sender As System.Object, e As System.EventArgs) Handles Button26.Click
		TBGlitModFileName.Text = ""
		RTBGlitModDommePost.Text = ""
		RTBGlitModResponses.Text = ""
		LBGlitModScripts.ClearSelected()

	End Sub

	Private Sub CBGlitModType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBGlitModType.SelectedIndexChanged

		If Form1.FormLoading = False Then

			Dim files() As String = Directory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Glitter\" & CBGlitModType.Text & "\")
			Dim GlitterScriptCount As Integer

			LBGlitModScripts.Items.Clear()

			For Each file As String In files

				GlitterScriptCount += 1
				LBGlitModScripts.Items.Add(Path.GetFileName(file).Replace(".txt", ""))

			Next

			LBLGlitModScriptCount.Text = CBGlitModType.Text & " Scripts Found (" & GlitterScriptCount & ")"

		End If
	End Sub

	Private Sub LBGlitModScripts_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LBGlitModScripts.SelectedIndexChanged

		Dim GlitPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Glitter\" & CBGlitModType.Text & "\" & LBGlitModScripts.SelectedItem & ".txt"

		If Not File.Exists(GlitPath) Then Return

		If GlitPath = Form1.StatusText Then
			MsgBox("This file is currently in use by the program. Saving changes may be slow until the Glitter process has finished.", , "Warning!")
		End If


		TBGlitModFileName.Text = LBGlitModScripts.SelectedItem

		RTBGlitModDommePost.Text = ""
		RTBGlitModResponses.Text = ""



		Dim ioFile As New StreamReader(GlitPath)
		Dim lines As New List(Of String)

		Dim GlitCount As Integer
		Dim GlitEnd As Integer

		GlitCount = -1

		While ioFile.Peek <> -1
			GlitCount += 1
			lines.Add(ioFile.ReadLine())
		End While


		GlitEnd = GlitCount
		GlitCount = 1

		RTBGlitModDommePost.Text = lines(0)


		Do
			RTBGlitModResponses.Text = RTBGlitModResponses.Text & lines(GlitCount) & Environment.NewLine
			GlitCount += 1
		Loop Until GlitCount = GlitEnd + 1

		ioFile.Close()
		ioFile.Dispose()

		Debug.Print(RTBGlitModResponses.Lines.Count)


	End Sub

	Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click

		If TBGlitModFileName.Text = "" Or RTBGlitModDommePost.Text = "" Or RTBGlitModResponses.Text = "" Then
			MsgBox("Please make sure all fields have been filled out!", , "Error!")
			Return
		End If

		If RTBGlitModResponses.Lines.Count < 3 Then
			MsgBox("Please make sure the Responses text box has at least three responses!", , "Error!")
			Return
		End If
		'If LBGlitModScripts.Items.Contains Then



		Dim GlitPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Glitter\" & CBGlitModType.Text & "\" & TBGlitModFileName.Text & ".txt"


		'My.Computer.FileSystem.WriteAllText(GlitPath, RTBGlitModDommePost.Text & Environment.NewLine & RTBGlitModResponses.Text, False)

		' My.Computer.FileSystem.WriteAllText(GlitPath, Environment.NewLine, True)

		'For Each sLine As String In RTBGlitModResponses.Text
		'My.Computer.FileSystem.WriteAllText(GlitPath, sLine & Environment.NewLine, True)
		'Next

		' File.WriteAllLines(GlitPath, File.ReadAllLines(GlitPath).Where(Function(s) s <> String.Empty))

		'LBGlitModScripts.Items.Add(TBGlitModFileName.Text)

		If Not LBGlitModScripts.Items.Contains(TBGlitModFileName.Text) Then
			LBGlitModScripts.Items.Add(TBGlitModFileName.Text)
			My.Computer.FileSystem.WriteAllText(GlitPath, RTBGlitModDommePost.Text & Environment.NewLine & RTBGlitModResponses.Text, False)
			File.WriteAllLines(GlitPath, File.ReadAllLines(GlitPath).Where(Function(s) s <> String.Empty))
		Else
			If MsgBox(TBGlitModFileName.Text & ".txt already exists! Overwrite?", vbYesNo, "Warning!") = MsgBoxResult.Yes Then
				My.Computer.FileSystem.WriteAllText(GlitPath, RTBGlitModDommePost.Text & Environment.NewLine & RTBGlitModResponses.Text, False)
				File.WriteAllLines(GlitPath, File.ReadAllLines(GlitPath).Where(Function(s) s <> String.Empty))
			Else
				Debug.Print("Did not work")
				Return
			End If
		End If



	End Sub




	Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIOpenURL.Click

		WebImageFileDialog.InitialDirectory = Application.StartupPath & "\Images\System\URL Files"

		If (WebImageFileDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

			Form1.WebImageFile = New IO.StreamReader(WebImageFileDialog.FileName)
			Form1.WebImagePath = WebImageFileDialog.FileName

			Form1.WebImageLines.Clear()

			Form1.WebImageLine = 0
			Form1.WebImageLineTotal = 0

			While Form1.WebImageFile.Peek <> -1
				Form1.WebImageLineTotal += 1
				Form1.WebImageLines.Add(Form1.WebImageFile.ReadLine())
			End While

			Try
				WebPictureBox.Image.Dispose()
			Catch
			End Try
			WebPictureBox.Image = Nothing
			GC.Collect()

			Try
				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(0))))
			Catch
				MessageBox.Show(Me, "Failed to load URL File image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try

			Form1.WebImageFile.Close()
			Form1.WebImageFile.Dispose()

			LBLWebImageCount.Text = Form1.WebImageLine + 1 & "/" & Form1.WebImageLineTotal


			BTNWINext.Enabled = True
			BTNWIPrevious.Enabled = True
			BTNWIRemove.Enabled = True
			BTNWILiked.Enabled = True
			BTNWIDisliked.Enabled = True
			BTNWISave.Enabled = True


		End If




	End Sub


	Private Sub Button35_Click_2(sender As System.Object, e As System.EventArgs) Handles BTNWINext.Click

TryNextImage:

		Form1.WebImageLine += 1

		If Form1.WebImageLine > Form1.WebImageLineTotal - 1 Then
			Form1.WebImageLine = Form1.WebImageLineTotal
			MsgBox("No more images to display!", , "Warning!")
			Return
		End If

		Try
			WebPictureBox.Image.Dispose()
		Catch
		End Try

		WebPictureBox.Image = Nothing
		GC.Collect()
		Try
			WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(Form1.WebImageLine))))
			LBLWebImageCount.Text = Form1.WebImageLine + 1 & "/" & Form1.WebImageLineTotal
		Catch ex As Exception
			GoTo TryNextImage
		End Try



	End Sub

	Private Sub Button18_Click_2(sender As System.Object, e As System.EventArgs) Handles BTNWIPrevious.Click

trypreviousimage:

		Form1.WebImageLine -= 1

		If Form1.WebImageLine < 0 Then
			Form1.WebImageLine = 0
			MsgBox("No more images to display!", , "Warning!")
			Return
		End If

		Try
			WebPictureBox.Image.Dispose()
		Catch
		End Try

		WebPictureBox.Image = Nothing
		GC.Collect()
		Try
			WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(Form1.WebImageLine))))
			LBLWebImageCount.Text = Form1.WebImageLine + 1 & "/" & Form1.WebImageLineTotal
		Catch ex As Exception
			GoTo trypreviousimage
		End Try

	End Sub

	Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles BTNWISave.Click

		If WebPictureBox.Image Is Nothing Then
			MsgBox("Nothing to save!", , "Error!")
			Return
		End If


		SaveFileDialog1.Filter = "jpegs|*.jpg|gifs|*.gif|pngs|*.png|Bitmaps|*.bmp"
		SaveFileDialog1.FilterIndex = 1
		SaveFileDialog1.RestoreDirectory = True


		Try

			Form1.WebImage = Form1.WebImageLines(Form1.WebImageLine)

			Dim DirSplit As String() = Form1.WebImage.Split("/")
			Form1.WebImage = DirSplit(DirSplit.Length - 1)

			' ### Clean Code
			'Do Until Not Form1.WebImage.Contains("/")
			'Form1.WebImage = Form1.WebImage.Remove(0, 1)
			'Loop

			SaveFileDialog1.FileName = Form1.WebImage

		Catch ex As Exception

			SaveFileDialog1.FileName = "image.jpg"

		End Try





		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

			WebPictureBox.Image.Save(SaveFileDialog1.FileName)

		End If

	End Sub

	Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles BTNWICreateURL.Click


		BWCreateURLFiles.RunWorkerAsync()

	End Sub


	Public Sub CreateURLFiles()

		Dim FirstPass As Boolean = False
		Dim ExactPostsCount As Integer
		Dim PostsInt As Integer = 0
		Dim ImageAdded As Boolean
		Dim BlogCycle As Integer
		BlogCycle = -50

		Dim BlogListOld As New List(Of String)
		Dim BlogListNew As New List(Of String)

		WebImageProgressBar.Value = 0
		WebImageProgressBar.Maximum = 2500

		Dim ImageBlogUrl As String = InputBox("Enter an image blog", "URL File Generator", "http://(Blog Name).tumblr.com/")
		If ImageBlogUrl = "" Then Return

		Dim req As System.Net.WebRequest
		Dim res As System.Net.WebResponse


		Try
			req = System.Net.WebRequest.Create(ImageBlogUrl)
			res = req.GetResponse()
		Catch
			MessageBox.Show(Me, "This does not appear to be a valid URL!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End Try

		Dim ModifiedUrl As String
		ModifiedUrl = ImageBlogUrl
		ModifiedUrl = ModifiedUrl.Replace("http://", "")
		ModifiedUrl = ModifiedUrl.Replace("/", "")

		Dim ImageURLPath As String = Application.StartupPath & "\Images\System\URL Files\" & ModifiedUrl & ".txt"

		If File.Exists(ImageURLPath) Then
			Dim URLReader As New StreamReader(ImageURLPath)
			While URLReader.Peek <> -1
				BlogListOld.Add(URLReader.ReadLine)
			End While

			URLReader.Close()
			URLReader.Dispose()



		End If


		LBLWebImageCount.Text = "0/0"


		Dim DupeList As New List(Of String)
		DupeList.Clear()

		Dim DislikeList As New List(Of String)
		DislikeList.Clear()


		If File.Exists(ImageURLPath) Then
			Dim DupeCheck As New StreamReader(ImageURLPath)

			While DupeCheck.Peek <> -1
				DupeList.Add(DupeCheck.ReadLine())
			End While

			DupeCheck.Close()
			DupeCheck.Dispose()

		End If

		If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
			Dim DislikeCheck As New StreamReader(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")

			While DislikeCheck.Peek <> -1
				DislikeList.Add(DislikeCheck.ReadLine())
			End While

			DislikeCheck.Close()
			DislikeCheck.Dispose()

		End If

Scrape:

		BTNWIContinue.Enabled = True
		BTNWIAddandContinue.Enabled = True
		BTNWICancel.Enabled = True
		BTNWICreateURL.Enabled = False
		BTNWIOpenURL.Enabled = False

		BTNWINext.Enabled = False
		BTNWIPrevious.Enabled = False
		BTNWIRemove.Enabled = False
		BTNWILiked.Enabled = False
		BTNWIDisliked.Enabled = False
		BTNWISave.Enabled = False



		ImageAdded = False

		BlogCycle += 50



		If URLCancel = True Then GoTo ExitScrape

		Dim doc As XmlDocument = New XmlDocument()

		Try
			ImageBlogUrl = ImageBlogUrl.Replace("/", "")
			ImageBlogUrl = ImageBlogUrl.Replace("http:", "http://")
			Debug.Print("ImageBlogURL = " & ImageBlogUrl)
			doc.Load(ImageBlogUrl & "/api/read?start=" & BlogCycle & "&num=50")
		Catch ex As Exception
		End Try

		If FirstPass = False Then
			Try
				For Each node As XmlNode In doc.DocumentElement.SelectNodes("//posts")
					Dim PostsCount As Integer = node.Attributes.ItemOf("total").InnerText
					ExactPostsCount = PostsCount
					PostsCount = RoundUpToNearest(PostsCount, 50)
					WebImageProgressBar.Maximum = PostsCount
					Debug.Print("PostsCount = " & PostsCount)
				Next
				FirstPass = True
			Catch
				MessageBox.Show(Me, "Unable to read site api!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				BTNWIContinue.Enabled = False
				BTNWIAddandContinue.Enabled = False
				BTNWICancel.Enabled = False
				BTNWICreateURL.Enabled = True
				BTNWIOpenURL.Enabled = True
				FirstPass = False
				Return
			End Try
		End If

		For Each node As XmlNode In doc.DocumentElement.SelectNodes("//photo-url")
			Application.DoEvents()
			If URLCancel = True Then GoTo ExitScrape
			If node.Attributes.ItemOf("max-width").InnerText = 1280 Then
				PostsInt += 1
				LBLWebImageCount.Text = PostsInt & "/" & ExactPostsCount
				ImageAdded = True

				If DupeList.Contains(node.InnerXml) Or DislikeList.Contains(node.InnerXml) Or BlogListNew.Contains(node.InnerXml) Then
					'MsgBox(node.InnerXml & " ALREADY HAS!")
					If CBWISaveToDisk.Checked = False Then GoTo AlreadyHas
				End If


				If CBWIReview.Checked = True Then

					Try
						WebPictureBox.Image.Dispose()
					Catch
					End Try

					WebPictureBox.Image = Nothing
					GC.Collect()
					WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(node.InnerXml)))

					Do
						Application.DoEvents()
					Loop Until Form1.ApproveImage <> 0 Or URLCancel = True

					If URLCancel = True Then GoTo ExitScrape

					If Form1.ApproveImage = 2 Then

						If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
							My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & node.InnerXml, True)
						Else
							My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", node.InnerXml, True)
						End If

					End If


				Else

					Form1.ApproveImage = 1

				End If

				Debug.Print("ApproveImage = " & Form1.ApproveImage)

				If Form1.ApproveImage = 1 Then
					Try
						If CBWISaveToDisk.Checked = True Then
							Dim XMLImagePath As String = node.InnerXml

							Dim DirSplit As String() = XMLImagePath.Split("/")
							XMLImagePath = DirSplit(DirSplit.Length - 1)

							' ### Clean Code
							'Do Until Not XMLImagePath.Contains("/")
							'XMLImagePath = XMLImagePath.Remove(0, 1)
							'Loop
							Debug.Print("TBWIDirectory.Text & XMLImagePath = " & TBWIDirectory.Text & "\" & XMLImagePath.Replace("\\", "\"))
							If Not File.Exists(TBWIDirectory.Text & "\" & XMLImagePath.Replace("\\", "\")) Then
								My.Computer.Network.DownloadFile(node.InnerXml, TBWIDirectory.Text & "\" & XMLImagePath.Replace("\\", "\"))
							End If
						End If

						BlogListNew.Add(node.InnerXml)


						'If File.Exists(ImageURLPath) Then
						'My.Computer.FileSystem.WriteAllText(ImageURLPath, Environment.NewLine & node.InnerXml, True)
						'Else
						'My.Computer.FileSystem.WriteAllText(ImageURLPath, node.InnerXml, True)
						'End If

					Catch
						GoTo ExitScrape
					End Try

				End If

AlreadyHas:

				Form1.ApproveImage = 0

			End If

		Next

		WebImageProgressBar.Value = WebImageProgressBar.Value + 50

		If ImageAdded = True And WebImageProgressBar.Value < WebImageProgressBar.Maximum Then GoTo Scrape

ExitScrape:

		URLCancel = False

		BTNWIContinue.Enabled = False
		BTNWIAddandContinue.Enabled = False
		BTNWICancel.Enabled = False


		WebPictureBox.Image = Nothing
		LBLWebImageCount.Text = ExactPostsCount & "/" & ExactPostsCount

		If File.Exists(ImageURLPath) Then My.Computer.FileSystem.DeleteFile(ImageURLPath)

		Dim BlogCombine As New List(Of String)

		For i As Integer = 0 To BlogListNew.Count - 1
			BlogCombine.Add(BlogListNew(i))
			Debug.Print("BLN " & i & ": " & BlogListNew(i))
		Next

		If BlogListOld.Count > 0 Then
			Debug.Print(BlogListOld.Count)
			For i As Integer = 0 To BlogListOld.Count - 1
				BlogCombine.Add(BlogListOld(i))
				Debug.Print("BLO " & i & ": " & BlogListOld(i))
			Next

		End If

		Dim fs As New FileStream(ImageURLPath, FileMode.Create)
		Dim sw As New StreamWriter(fs)
		For i As Integer = 0 To BlogCombine.Count - 1
			If i <> BlogCombine.Count - 1 Then
				sw.WriteLine(BlogCombine(i))
			Else
				sw.Write(BlogCombine(i))
			End If
		Next
		sw.Close()
		sw.Dispose()
		fs.Close()
		fs.Dispose()

		MsgBox("URL File has been saved to:" & Environment.NewLine & Environment.NewLine & Application.StartupPath & "\Images\System\URL Files\" & ModifiedUrl & ".txt" & Environment.NewLine & Environment.NewLine & "Use the ""Open URL File"" button to load and view your collections.", , "Success!")

		If Not URLFileList.Items.Contains(ModifiedUrl) Then
			URLFileList.Items.Add(ModifiedUrl)
			For i As Integer = 0 To URLFileList.Items.Count - 1
				If URLFileList.Items(i) = ModifiedUrl Then URLFileList.SetItemChecked(i, True)
			Next
		End If

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To URLFileList.Items.Count - 1
			BinaryWriter.Write(CStr(URLFileList.Items(i)))
			BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

		WebImageProgressBar.Value = 0
		WebImageProgressBar.Maximum = 2500
		LBLWebImageCount.Text = "0/0"
		BTNWICreateURL.Enabled = True
		BTNWIOpenURL.Enabled = True
		FirstPass = False

	End Sub


	Public Sub CombineURLFiles()

		Dim NewURLCount As Integer
		Dim TotalURLCount As Integer

		Dim MaintString As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
		MaintString = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files")

		Dim MaintCount As Integer = CStr(MaintString.Count)
		PBMaintenance.Maximum = MaintCount
		PBMaintenance.Value = 0

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

			If CancelRebuild = True Then
				PBMaintenance.Value = 0
				PBCurrent.Value = 0
				LBLMaintenance.Text = ""
				CancelRebuild = False
				BTNMaintenanceRebuild.Enabled = True
				BTNMaintenanceCancel.Enabled = False
				BTNMaintenanceRefresh.Enabled = True
				BTNMaintenanceValidate.Enabled = True
				Return
			End If

			Debug.Print("FoundFile = " & foundFile)

			Dim FirstPass As Boolean = False
			Dim ExactPostsCount As Integer
			Dim PostsInt As Integer = 0
			Dim ImageAdded As Boolean
			Dim BlogCycle As Integer
			BlogCycle = -50

			NewURLCount = 0

			Dim BlogListOld As New List(Of String)
			Dim BlogListNew As New List(Of String)

			Dim ImageBlogUrl As String = foundFile.Replace(Application.StartupPath & "\Images\System\URL Files\", "")
			Dim BlogUrlInfo As String = ImageBlogUrl

			ImageBlogUrl = ImageBlogUrl.Replace(".txt", "")
			ImageBlogUrl = "http://" & ImageBlogUrl

			LBLMaintenance.Text = "Checking " & BlogUrlInfo & "..."

			Dim req As System.Net.WebRequest
			Dim res As System.Net.WebResponse

			req = System.Net.WebRequest.Create(ImageBlogUrl)

			Try
				res = req.GetResponse()
			Catch w As WebException
				GoTo NextURL
			End Try

			Dim ModifiedUrl As String
			ModifiedUrl = ImageBlogUrl
			ModifiedUrl = ModifiedUrl.Replace("http://", "")
			ModifiedUrl = ModifiedUrl.Replace("/", "")

			Dim ImageURLPath As String = Application.StartupPath & "\Images\System\URL Files\" & ModifiedUrl & ".txt"

			If File.Exists(ImageURLPath) Then
				Dim URLReader As New StreamReader(ImageURLPath)
				While URLReader.Peek <> -1
					BlogListOld.Add(URLReader.ReadLine)
				End While

				URLReader.Close()
				URLReader.Dispose()
			End If

			Dim DupeList As New List(Of String)
			DupeList.Clear()

			Dim DislikeList As New List(Of String)
			DislikeList.Clear()

			If File.Exists(ImageURLPath) Then
				Dim DupeCheck As New StreamReader(ImageURLPath)

				While DupeCheck.Peek <> -1
					DupeList.Add(DupeCheck.ReadLine())
				End While

				DupeCheck.Close()
				DupeCheck.Dispose()

			End If

			If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
				Dim DislikeCheck As New StreamReader(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")

				While DislikeCheck.Peek <> -1
					DislikeList.Add(DislikeCheck.ReadLine())
				End While

				DislikeCheck.Close()
				DislikeCheck.Dispose()

			End If



Scrape:





			ImageAdded = False

			BlogCycle += 50



			If Form1.WIExit = True Then GoTo ExitScrape

			Dim doc As XmlDocument = New XmlDocument()

			Try
				ImageBlogUrl = ImageBlogUrl.Replace("/", "")
				ImageBlogUrl = ImageBlogUrl.Replace("http:", "http://")
				Debug.Print("ImageBlogURL = " & ImageBlogUrl)
				doc.Load(ImageBlogUrl & "/api/read?start=" & BlogCycle & "&num=50")
			Catch ex As Exception
			End Try

			If FirstPass = False Then
				Try
					For Each node As XmlNode In doc.DocumentElement.SelectNodes("//posts")
						Dim PostsCount As Integer = node.Attributes.ItemOf("total").InnerText
						ExactPostsCount = PostsCount
						PostsCount = RoundUpToNearest(PostsCount, 50)
						Debug.Print("PostsCount = " & PostsCount)
					Next
					FirstPass = True
				Catch
					FirstPass = False
					GoTo NextURL
				End Try
			End If




			For Each node As XmlNode In doc.DocumentElement.SelectNodes("//photo-url")
				Application.DoEvents()
				If Form1.WIExit = True Then GoTo ExitScrape
				If node.Attributes.ItemOf("max-width").InnerText = 1280 Then
					PostsInt += 1
					ImageAdded = True

					If DupeList.Contains(node.InnerXml) Then
						Debug.Print("DUPELIST")
						TotalURLCount += NewURLCount
						GoTo ExitScrape
					End If




					Try
						BlogListNew.Add(node.InnerXml)
						NewURLCount += 1
						LBLMaintenance.Text = BlogUrlInfo & Environment.NewLine & NewURLCount & " new files"

					Catch
						GoTo ExitScrape
					End Try

					If CancelRebuild = True Then
						PBMaintenance.Value = 0
						PBCurrent.Value = 0
						LBLMaintenance.Text = ""
						CancelRebuild = False
						BTNMaintenanceRebuild.Enabled = True
						BTNMaintenanceCancel.Enabled = False
						BTNMaintenanceRefresh.Enabled = True
						BTNMaintenanceValidate.Enabled = True
						Return
					End If


					Form1.ApproveImage = 0

				End If

			Next



			If ImageAdded = True Then GoTo Scrape

ExitScrape:


			Form1.WIExit = False



			If File.Exists(ImageURLPath) Then My.Computer.FileSystem.DeleteFile(ImageURLPath)

			Dim BlogCombine As New List(Of String)

			For i As Integer = 0 To BlogListNew.Count - 1
				BlogCombine.Add(BlogListNew(i))
				'Debug.Print("BLN " & i & ": " & BlogListNew(i))
			Next

			If BlogListOld.Count > 0 Then
				' Debug.Print(BlogListOld.Count)
				For i As Integer = 0 To BlogListOld.Count - 1
					BlogCombine.Add(BlogListOld(i))
					' Debug.Print("BLO " & i & ": " & BlogListOld(i))
				Next

			End If








			'Dim objWriter As New System.IO.StreamWriter(ImageURLPath)


			' objWriter.WriteLine(BlogCombine(i))
			Dim fs As New FileStream(ImageURLPath, FileMode.Create)
			Dim sw As New StreamWriter(fs)
			For i As Integer = 0 To BlogCombine.Count - 1
				If i <> BlogCombine.Count - 1 Then
					sw.WriteLine(BlogCombine(i))
				Else
					sw.Write(BlogCombine(i))
				End If
			Next
			sw.Close()
			sw.Dispose()
			fs.Close()
			fs.Dispose()





			' For i As Integer = 0 To BlogCombine.Count - 1
			'If Not i = BlogCombine.Count - 1 Then
			'My.Computer.FileSystem.WriteAllText(ImageURLPath, BlogCombine(i) & Environment.NewLine, True)
			';Else
			'My.Computer.FileSystem.WriteAllText(ImageURLPath, BlogCombine(i), True)
			'End If
			' Debug.Print(BlogCombine(i))
			'Next

			If Not URLFileList.Items.Contains(ModifiedUrl) Then
				URLFileList.Items.Add(ModifiedUrl)
				For i As Integer = 0 To URLFileList.Items.Count - 1
					If URLFileList.Items(i) = ModifiedUrl Then URLFileList.SetItemChecked(i, True)
				Next
			End If

			Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
			Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
			For i = 0 To URLFileList.Items.Count - 1
				BinaryWriter.Write(CStr(URLFileList.Items(i)))
				BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
			Next
			BinaryWriter.Close()
			FileStream.Dispose()


			FirstPass = False

			PBMaintenance.Value += 1

NextURL:
		Next

		PBMaintenance.Value = PBMaintenance.Maximum

		MessageBox.Show(Me, "All URL Files have been refreshed!" & Environment.NewLine & Environment.NewLine & TotalURLCount & " new URLs have been added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

		LBLMaintenance.Text = ""

		BTNMaintenanceRebuild.Enabled = True
		BTNMaintenanceRefresh.Enabled = True
		BTNMaintenanceCancel.Enabled = False
		BTNMaintenanceValidate.Enabled = True

		PBMaintenance.Value = 0



























	End Sub





	Function RoundUpToNearest(Value As Integer, nearest As Integer) As Integer
		Return CInt(Math.Ceiling(Value / nearest) * nearest)
	End Function

	Private Sub WebPictureBox_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles WebPictureBox.MouseWheel




		Select Case e.Delta
			Case -120 'Scrolling down
				Form1.WebImageLine += 1

				If Form1.WebImageLine > Form1.WebImageLineTotal - 1 Then
					Form1.WebImageLine = Form1.WebImageLineTotal
					MsgBox("No more images to display!", , "Warning!")
					Return
				End If

				Try
					WebPictureBox.Image.Dispose()
				Catch
				End Try
				WebPictureBox.Image = Nothing
				GC.Collect()

				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(Form1.WebImageLine))))
				LBLWebImageCount.Text = Form1.WebImageLine + 1 & "/" & Form1.WebImageLineTotal
			Case 120 'Scrolling up
				Form1.WebImageLine -= 1

				If Form1.WebImageLine < 0 Then
					Form1.WebImageLine = 0
					MsgBox("No more images to display!", , "Warning!")
					Return
				End If

				Try
					WebPictureBox.Image.Dispose()
				Catch
				End Try
				WebPictureBox.Image = Nothing
				GC.Collect()
				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(Form1.WebImageLine))))
				LBLWebImageCount.Text = Form1.WebImageLine + 1 & "/" & Form1.WebImageLineTotal
		End Select


	End Sub


	Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebPictureBox.MouseEnter
		WebPictureBox.Focus()
	End Sub

	Private Sub Button32_Click_1(sender As System.Object, e As System.EventArgs)
		Form1.GetBlogImage()

	End Sub

	Private Sub SliderSTF_Scroll(sender As System.Object, e As System.EventArgs) Handles SliderSTF.Scroll
		If SliderSTF.Value = 1 Then LBLStf.Text = "Preoccupied"
		If SliderSTF.Value = 2 Then LBLStf.Text = "Distracted"
		If SliderSTF.Value = 3 Then LBLStf.Text = "Normal"
		If SliderSTF.Value = 4 Then LBLStf.Text = "Talkative"
		If SliderSTF.Value = 5 Then LBLStf.Text = "Verbose"

	End Sub

	Private Sub TauntSlider_Scroll(sender As System.Object, e As System.EventArgs) Handles TauntSlider.Scroll
		If TauntSlider.Value = 1 Then LBLVtf.Text = "Preoccupied"
		If TauntSlider.Value = 2 Or TauntSlider.Value = 3 Then LBLVtf.Text = "Distracted"
		If TauntSlider.Value = 4 Or TauntSlider.Value = 5 Then LBLVtf.Text = "Normal"
		If TauntSlider.Value = 6 Or TauntSlider.Value = 7 Or TauntSlider.Value = 8 Then LBLVtf.Text = "Talkative"
		If TauntSlider.Value = 9 Or TauntSlider.Value = 10 Then LBLVtf.Text = "Verbose"

	End Sub



	Private Sub TauntSlider_LostFocus(sender As System.Object, e As System.EventArgs) Handles TauntSlider.LostFocus
		My.Settings.TimerVTF = TauntSlider.Value
		My.Settings.Save()

	End Sub

	Private Sub SliderSTF_LostFocus(sender As System.Object, e As System.EventArgs) Handles SliderSTF.LostFocus
		My.Settings.TimerSTF = SliderSTF.Value
		My.Settings.Save()

	End Sub

	Private Sub BTNDomColor_Click(sender As System.Object, e As System.EventArgs) Handles BTNDomColor.Click

		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.DomColorColor = GetColor.Color
			LBLDomColor.ForeColor = GetColor.Color
			Form1.DomColor = Color2Html(GetColor.Color)
			My.Settings.DomColor = Form1.DomColor
			My.Settings.Save()
		End If


	End Sub

	Private Sub BTNSubColor_Click(sender As System.Object, e As System.EventArgs) Handles BTNSubColor.Click

		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.SubColorColor = GetColor.Color
			LBLSubColor.ForeColor = GetColor.Color
			Form1.SubColor = Color2Html(GetColor.Color)
			My.Settings.SubColor = Form1.SubColor
			My.Settings.Save()
		End If

	End Sub

	Private Sub Button39_Click(sender As System.Object, e As System.EventArgs)
		Form1.StrokePaceInt = 1
		Form1.StrokePaceRight = True

		If Form1.StrokePaceTimer.Enabled = True Then
			Form1.StopMetronome = True
			Form1.StrokePaceTimer.Stop()
		Else
			Form1.StopMetronome = False
			Form1.StrokePaceTimer.Start()
		End If
	End Sub





	Private Sub timestampCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles timestampCheckBox.MouseClick

		If timestampCheckBox.Checked = True Then
			My.Settings.CBTimeStamps = True
		Else
			My.Settings.CBTimeStamps = False
		End If
		My.Settings.Save()



	End Sub


	Private Sub shownamesCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles shownamesCheckBox.MouseClick

		If shownamesCheckBox.Checked = True Then
			My.Settings.CBShowNames = True
		Else
			My.Settings.CBShowNames = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub typeinstantlyCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles typeinstantlyCheckBox.MouseClick

		If typeinstantlyCheckBox.Checked = True Then
			My.Settings.CBInstantType = True
		Else
			My.Settings.CBInstantType = False
		End If
		My.Settings.Save()


	End Sub

	Private Sub CBWebtease_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBWebtease.MouseClick

		If CBWebtease.Checked = True Then
			My.Settings.CBWebtease = True
		Else
			My.Settings.CBWebtease = False
		End If
		My.Settings.Save()


	End Sub

	Private Sub CBBlogImageWindow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBBlogImageWindow.MouseClick
		If CBBlogImageWindow.Checked = True Then
			My.Settings.CBBlogImageMain = True
		Else
			My.Settings.CBBlogImageMain = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub landscapeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles landscapeCheckBox.MouseClick
		If landscapeCheckBox.Checked = True Then
			My.Settings.CBStretchLandscape = True
		Else
			My.Settings.CBStretchLandscape = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBSettingsPause_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSettingsPause.MouseClick
		If CBSettingsPause.Checked = True Then
			My.Settings.CBSettingsPause = True
		Else
			My.Settings.CBSettingsPause = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub timestampCheckBox_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles timestampCheckBox.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(timestampCheckBox, "When this is selected, a timestamp will appear" & Environment.NewLine &
																			 "with each message you and the domme send.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(timestampCheckBox, "Wenn dies aktiviert ist, wird mit jeder Nachricht die" & Environment.NewLine &
																			"du oder die Domina sendet ein Zeitstempel angezeigt")



		'LBLGeneralSettingsDescription.Text = "When this is selected, a timestamp will appear with each message you and the domme send."
		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird mit jeder Nachricht die du oder die Domina sendet ein Zeitstempel angezeigt"

	End Sub

	Private Sub shownamesCheckBox_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles shownamesCheckBox.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(shownamesCheckBox, "When this is selected, the names of you and the" & Environment.NewLine &
																			  "domme will appear with every message you send." & Environment.NewLine & Environment.NewLine &
																			  "If it is unselected, names will only appear" & Environment.NewLine &
																			  "when you were not the last one to type.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(shownamesCheckBox, "Wenn dies aktiviert ist, wird mit jeder Nachricht" & Environment.NewLine &
																			"die du oder die Domina sendet der Name angezeigt." & Environment.NewLine & Environment.NewLine &
																			"Wenn dies deaktiviert ist, Namen werden nur erscheinen" & Environment.NewLine &
																			"wenn du nicht der letzte warst, der geschrieben hat.")




		'LBLGeneralSettingsDescription.Text = "When this is selected, the names of you and the domme will appear with every message you send. If it is unselected, names will only appear when you were not the last one to type."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird mit jeder Nachricht die du oder die Domina sendet der Name angezeigt. Wenn dies deaktiviert ist," _
		'   & " Namen werden nur erscheinen wenn du nicht der letzte warst, der geschrieben hat."

	End Sub


	Private Sub typeinstantlyCheckBox_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles typeinstantlyCheckBox.MouseHover


		If RBEnglish.Checked = True Then TTDir.SetToolTip(typeinstantlyCheckBox, "This program simulates a chat environment, so a brief delay appears before each post the domme makes." & Environment.NewLine &
																				 "This delay is determined by the length of what she is saying and will be accompanied by the text ""[Dom Name] is typing...""" & Environment.NewLine & Environment.NewLine &
																				 "When this is selected, the typing delay is removed and the domme's messages become instantaneous.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(typeinstantlyCheckBox, "Dieses Programm simuliert eine Chat Umgebung, daher erscheint eine kurze Verzögerung vor jedem Beitrag den die Domina macht." & Environment.NewLine &
																				"Diese Verzögerung hängt von der Länge ab, was sie schreibt und wird begleitet mit dem text „[Dom Name] is typing…"" für einen besseren Effekt." & Environment.NewLine & Environment.NewLine &
																				"Wenn dies deaktiviert ist, ist die „Tippen"" Verzögerung entfernt und die Domina Beiträge erschein sofort")



		' LBLGeneralSettingsDescription.Text = "This program simulates a chat environment, so a brief delay appears before each post the domme makes. This delay is determined by the length of what she is saying and will " _
		'  & "be accompanied by the text ""[Dom Name] is typing..."" for added effect. When this is unselected, the typing delay is removed and the domme's messages become instantaneous."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Dieses Programm simuliert eine Chat Umgebung, daher erscheint eine kurze Verzögerung vor jedem Beitrag den die Domina macht. Diese Verzögerung hängt von der Länge ab, was sie schreibt und wird begleitet mit dem text „[Dom Name] is typing…"" für einen besseren Effekt."
		' Wenn dies deaktiviert ist, ist die „Tippen"" Verzögerung entfernt und die Domina Beiträge erschein sofort"

	End Sub

	Private Sub CBLockWindow_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBInputIcon.MouseHover

		TTDir.SetToolTip(CBInputIcon, "When this is selected, a small question mark icon will appear next to the" & Environment.NewLine &
									  "domme's question when your exact response will be saved to a variable.")
		'If RBGerman.Checked = True Then TTDir.SetToolTip(CBInputIcon, "Wenn dies aktiviert ist, wird mit jeder Nachricht die" & Environment.NewLine & _
		' "du oder die Domina sendet ein Zeitstempel angezeigt")

		'LBLGeneralSettingsDescription.Text = "When this is selected, a small question mark icon will appear next to domme's question when your exact response will be saved to a variable."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, kann der Teilungsbalken zwischen Chat Fenster und Bildfenster nicht verstellt werden."

	End Sub

	Private Sub CBBlogImageWindow_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBBlogImageWindow.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBBlogImageWindow, "When this is selected, any blog images the domme shows you will" & Environment.NewLine &
																			 "automatically be saved to ""[root folder]\Images\Session Images\"".")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBBlogImageWindow, "Wenn dies aktiviert ist, wird jedes Blog Bild, welches die Domina dir zeigt" & Environment.NewLine &
																			"automatisch gespeichert in „…\Tease AI Open Beta\Images\Session Images\""")


		'LBLGeneralSettingsDescription.Text = "When this is selected, any blog images the domme shows you will automatically be saved to ""[root folder]\Images\Session Images\""."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird jedes Blog Bild, welches die Domina dir zeigt automatisch gespeichert in „…\Tease AI Open Beta\Images\Session Images\"""
	End Sub

	Private Sub landscapeCheckBox_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles landscapeCheckBox.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(landscapeCheckBox, "When this is selected, images that appear in the main window will be" & Environment.NewLine &
																			 "stretched to fit the screen if their width is greater than their height.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(landscapeCheckBox, "Wenn dies aktiviert ist, werden die Bilder(welche Angezeigt" & Environment.NewLine &
																			"werden) gestreckt, wenn ihre Breite größer als ihre Höhe ist.")


		'LBLGeneralSettingsDescription.Text = "When this is selected, images that appear in the main window will be stretched to fit the screen if their width is greater than their height."
		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, werden die Bilder(welche Angezeigt werden) gestreckt, wenn ihre Breite größer als ihre Höhe ist"
	End Sub
	Private Sub CBImageInfo_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBImageInfo.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBImageInfo, "When this is selected, the local filepath or URL address of each image displayed" & Environment.NewLine &
																	   "in the main window will appear in the upper left hand corner of the screen.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBImageInfo, "Wenn dies aktiviert ist, wird der Lokale Dateipfad oder die URL-Adresse" & Environment.NewLine &
																	  "von jedem Bild in der oberen linken Ecke des Bildschirms angezeigt.")

		'LBLGeneralSettingsDescription.Text = "When this is selected, the local filepath or URL address of each image displayed in the main window will appear in the upper left hand corner of the screen."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird der Lokale Dateipfad oder die URL-Adresse von jedem Bild in der oberen linken Ecke des Bildschirms angezeigt."
	End Sub


	Private Sub Button2_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button2.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(Button2, "Use this button to select a directory containing several image" & Environment.NewLine &
"set folders of the same model you're using as your contact.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(Button2, "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre" & Environment.NewLine &
"Bildersets von dem selben Model enthält, die du als Kontakt benutzt.")
	End Sub
	Private Sub Button8_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button8.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(Button8, "Use this button to select a directory containing several image" & Environment.NewLine &
"set folders of the same model you're using as your contact.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(Button8, "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre" & Environment.NewLine &
"Bildersets von dem selben Model enthält, die du als Kontakt benutzt.")
	End Sub
	Private Sub Button10_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button10.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(Button10, "Use this button to select a directory containing several image" & Environment.NewLine &
"set folders of the same model you're using as your contact.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(Button10, "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre" & Environment.NewLine &
"Bildersets von dem selben Model enthält, die du als Kontakt benutzt.")
	End Sub



	Private Sub BTNDomImageDir_MouseHover(sender As System.Object, e As System.EventArgs) Handles BTNDomImageDir.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(BTNDomImageDir, "Use this button to select a directory containing several image" & Environment.NewLine &
																			 "set folders of the same model you're using as your domme." & Environment.NewLine & Environment.NewLine &
																			 "Once a valid directory has been set, any time you say hello to the domme, one of" & Environment.NewLine &
																			 "those folders will automatically be selected at random and used for the slideshow.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(BTNDomImageDir, "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre" & Environment.NewLine &
																			"Bildersets von dem selben Model enthält, die du als Domina benutzt." & Environment.NewLine & Environment.NewLine &
																			"Nachdem einmal ein gültiges Verzeichnis gesetzt wurde, wird nachdem du Hello" & Environment.NewLine &
																			"zu der Domina gesagt hast, automatisch zufällig eine Diashow ausgewählt.")


		'LBLGeneralSettingsDescription.Text = "Use this button to select a directory containing several image set folders of the same model you're using as your domme. Once a valid directory has been set, any time" _
		'& " you say hello to the domme, one of those folders will automatically be selected at random and used for the slideshow."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre Bildersets von dem selben Model enthält,"
		' die du als Domina benutzt. Nachdem einmal ein gültiges Verzeichnis gesetzt wurde, wird nachdem du Hello zu der Domina gesagt hast, automatisch zufällig eine Diashow ausgewählt."
	End Sub

	Private Sub offRadio_MouseHover(sender As System.Object, e As System.EventArgs) Handles offRadio.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(offRadio, "When this is set, any domme slideshow you have selected will not advance during the" & Environment.NewLine &
																	"tease. Use the Previous and Next buttons on the Media Bar to change the images.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(offRadio, "Wenn dies aktiviert ist, wird jede Diashow nicht automatisch die Bilder wechseln." & Environment.NewLine &
																   "Nutze die Vor- und Zurückschaltflächen in der media bar um die Bilder zu wechseln.")

		'LBLGeneralSettingsDescription.Text = "When this is set, any slideshow you have selected will not advance during the tease. Use the Previous and Next buttons on the Media Bar to change the images."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird jede Diashow nicht automatisch die Bilder wechseln. Nutze die Vor- und Zurückschaltflächen in der media bar um die Bilder zu wechseln"
	End Sub

	Private Sub timedRadio_MouseHover(sender As System.Object, e As System.EventArgs) Handles timedRadio.MouseHover

		TTDir.SetToolTip(timedRadio, "When this is set, any slideshow you have selected will advance the image" & Environment.NewLine &
									 "every number of seconds displayed in the box to the right of this option.")

		'LBLGeneralSettingsDescription.Text = "When this is set, any slideshow you have selected will advance the image every number of seconds displayed in the box to the right of this option."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = ""
	End Sub

	Private Sub SlideshowNumBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles slideshowNumBox.MouseHover

		TTDir.SetToolTip(slideshowNumBox, "The number of seconds between image changes" & Environment.NewLine &
										  "when the ""Timed"" slideshow option is checked.")

		'LBLGeneralSettingsDescription.Text = "The number of seconds between image changes when the ""Timed"" slideshow option is checked."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = ""
	End Sub

	Private Sub Radio_LostFocus(sender As Object, e As System.EventArgs) Handles teaseRadio.LostFocus, offRadio.LostFocus, timedRadio.LostFocus
		If teaseRadio.Checked = True Then My.Settings.SlideshowMode = "Tease"
		If timedRadio.Checked = True Then My.Settings.SlideshowMode = "Timed"
		If offRadio.Checked = True Then My.Settings.SlideshowMode = "Manual"
		My.Settings.Save()
	End Sub

	Private Sub teaseRadio_MouseHover(sender As System.Object, e As System.EventArgs) Handles teaseRadio.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(teaseRadio, "When this is set, any slideshow you have selected will advance automatically when the domme " & Environment.NewLine &
																	  "types. The slideshow may move forward or backward, but will not loop either direction." & Environment.NewLine & Environment.NewLine &
																	  "You can change the odds of which way the slideshow will move in" & Environment.NewLine &
																	  "the Ranges tab. This is the default slideshow mode for Tease AI.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(teaseRadio, "Wenn dies aktiviert ist, wird die Diashow automatisch die Bilder wechseln wenn die Domina schreibt." & Environment.NewLine &
																	 "Die Diashow kann vorwärts oder rückwärts laufen, aber wird keine Richtung wiederholen." & Environment.NewLine & Environment.NewLine &
																	 "Du kannst die Wahrscheinlichkeit in welche Richtung die Diashow läuft im Wertebereichs" & Environment.NewLine &
																	 "„Reiter"" ändern. Dies ist der Standart Diashow modus in Tease AI.")


		'LBLGeneralSettingsDescription.Text = "When this is set, any slideshow you have selected will advance automatically when the domme types. The slideshow may move forward or backward, but will not loop either" _
		'   & " direction. You can change the odds of which way the slideshow will move in the Ranges tab. This is the default slideshow mode for Tease AI."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird die Diashow automatisch die Bilder wechseln wenn die Domina schreibt. 
		'Die Diashow kann vorwärts oder rückwärts laufen, aber wird keine Richtung wiederholen. Du kannst die Wahrscheinlichkeit in welche Richtung die 
		'Diashow läuft im Wertebereichs „Reiter"" ändern. Dies ist der Standart Diashow modus in Tease AI "
	End Sub


	' Private Sub CBMetronome_CheckedChanged_1(sender As System.Object, e As System.EventArgs)
	' LBLGeneralSettingsDescription.Text = "When this is selected, the silent metronome located above the sub avatar will activate any time you are instructed to stroke."

	' If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = ""
	' End Sub

	Private Sub CBSettingsPause_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBSettingsPause.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBSettingsPause, "When this is selected, the program will pause any time" & Environment.NewLine &
																		   "the settings menu is open and resume once it is closed.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBSettingsPause, "Wenn dies aktiviert ist, wird das Programm immer in Pause" & Environment.NewLine &
																		  "springen solange das Einstellungsmenü geöffnet ist.")

		'LBLGeneralSettingsDescription.Text = "When this is selected, the program will pause any time the settings menu is open and resume once it is closed."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird das Programm immer in Pause springen solange das Einstellungsmenü geöffnet ist."
	End Sub

	Private Sub BTNDomColor_MouseHover(sender As Object, e As System.EventArgs) Handles BTNDomColor.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(BTNDomColor, "This button allows you to change the color of the" & Environment.NewLine &
																	   "domme's name as it appears in the chat window." & Environment.NewLine & Environment.NewLine &
																	   "A preview will appear in the text box next to this" & Environment.NewLine &
																	   "button once a color has been selected.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(BTNDomColor, "Diese Schaltfläche erlaubt dir die Farbe des Domina Namens" & Environment.NewLine &
																	  "zu ändern in der er im Chat Fenster angezeigt wird." & Environment.NewLine & Environment.NewLine &
																	  "Eine Vorschau wird in der Textbox neben dieser Schaltfläche" & Environment.NewLine &
																	  "angezeigt, nachdem eine Farbe ausgewählt wurde.")


		'LBLGeneralSettingsDescription.Text = "This button allows you to change the color of the domme's name as it appears in the chat window. A preview will appear in the text box next to this button once a color has been selected."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Diese Schaltfläche erlaubt dir die Farbe des Domina Namens zu ändern in der er im Chat Fenster angezeigt wird. Eine Vorschau wird in der Textbox neben dieser Schaltfläche angezeigt, nachdem eine Farbe ausgewählt wurde."
	End Sub

	Private Sub BTNSubColor_MouseHover(sender As Object, e As System.EventArgs) Handles BTNSubColor.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(BTNSubColor, "This button allows you to change the color of" & Environment.NewLine &
																	   "your name as it appears in the chat window." & Environment.NewLine & Environment.NewLine &
																	   "A preview will appear in the text box next to this" & Environment.NewLine &
																	   "button once a color has been selected.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(BTNSubColor, "Diese Schaltfläche erlaubt dir die Farbe des Sklaven Namens" & Environment.NewLine &
																	  "zu ändern in der er im Chat Fenster angezeigt wird." & Environment.NewLine & Environment.NewLine &
																	  "Eine Vorschau wird in der Textbox neben dieser Schaltfläche" & Environment.NewLine &
																	  "angezeigt, nachdem eine Farbe ausgewählt wurde.")

		'LBLGeneralSettingsDescription.Text = "This button allows you to change the color of your name as it appears in the chat window. A preview will appear in the text box next to this button once a color has been selected."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Diese Schaltfläche erlaubt dir die Farbe  des Sklaven Namens zu ändern in der er im Chat Fenster angezeigt wird. Eine Vorschau wird in der Textbox neben dieser Schaltfläche angezeigt, nachdem eine Farbe ausgewählt wurde."
	End Sub

	Private Sub LBLDomColor_Click(sender As System.Object, e As System.EventArgs) Handles LBLDomColor.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(LBLDomColor, "After clicking the ""Domme Name Color"" button to the" & Environment.NewLine &
																	   "left, a preview of the selected color will appear here.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(LBLDomColor, "Nachdem Klicken der Schaltfläche ""Domina Farbe für Namen"" zur" & Environment.NewLine &
																	  "linken, eine Vorschau der ausgewählten Farbe erscheint hier.")

		'LBLGeneralSettingsDescription.Text = "After clicking the ""Domme Name Color"" button to the left, a preview of the selected color will appear here."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Nachdem Klicken der Schaltfläche ""Domina Farbe für Namen"" zur linken, eine Vorschau der ausgewählten Farbe erscheint hier"
	End Sub

	Private Sub LBLSubColor_Click(sender As System.Object, e As System.EventArgs) Handles LBLSubColor.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(LBLSubColor, "After clicking the ""Sub Name Color"" button to the" & Environment.NewLine &
																	  "left, a preview of the selected color will appear here.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(LBLSubColor, "Nachdem Klicken der Schaltfläche ""Sklaven Farbe für Namen"" zur" & Environment.NewLine &
																	  "linken, eine Vorschau der ausgewählten Farbe erscheint hier.")


		'LBLGeneralSettingsDescription.Text = "After clicking the ""Sub Name Color"" button to the left, a preview of the selected color will appear here."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Nachdem Klicken der Schaltfläche ""Sklaven Farbe für Namen"" zur linken, eine Vorschau der ausgewählten Farbe erscheint hier"
	End Sub

	Private Sub CBDomDel_Click(sender As System.Object, e As System.EventArgs) Handles CBDomDel.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBDomDel, "When this box is checked, the domme will be able to permanently delete" & Environment.NewLine &
																	"media from your hard drive when such Commands are used in scripts." & Environment.NewLine & Environment.NewLine &
																	"When this box is NOT checked, media will not actually be deleted. Images will still" & Environment.NewLine &
																	"disappear from the window, but they will not be deleted from the hard drive.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBDomDel, "Wenn dies aktiviert ist, ist die Domina dazu in der Lage Medien permanent von" & Environment.NewLine &
																   "deiner Festplatte zu löschen, wenn solche Kommandos in dem Script genutzt werden." & Environment.NewLine & Environment.NewLine &
																   "Wenn dies deaktiviert ist, werden Bilder vom Bildschirm" & Environment.NewLine &
																   "verschwinden, aber nicht von der Festplatte gelöscht.")



		'LBLGeneralSettingsDescription.Text = "When this box is checked, the domme will be able to permanently delete media from your hard drive when such Commands are used in scripts." & Environment.NewLine & _
		'   Environment.NewLine & "When this box is NOT checked, media will not actually be deleted. Images will still disappear from the window, but they will not be deleted from the hard drive."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, ist die Domina dazu in der Lage Medien permanent von deiner Festplatte zu löschen, wenn solche "
		'Kommandos in dem Script genutzt werden. Wenn dies deaktiviert ist, werden Bilder vom Bildschirm verschwinden, aber nicht von der Festplatte gelöscht."
	End Sub

	' Private Sub GBGeneralSettings_MouseHover(sender As Object, e As System.EventArgs) Handles GBGeneralSettings.MouseEnter, PNLGeneralSettings.MouseEnter
	'    LBLGeneralSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its function."

	'   If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Ziehe die Maus über irgendeine Einstellung um eine genaure Beschreibung der Einstellung zu bekommen."
	'End Sub

	Private Sub domlevelNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domlevelNumBox.LostFocus
		My.Settings.DomLevel = domlevelNumBox.Value
		My.Settings.Save()
	End Sub

	Private Sub alloworgasmComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles alloworgasmComboBox.LostFocus



		My.Settings.OrgasmAllow = alloworgasmComboBox.Text
		My.Settings.Save()
	End Sub

	Private Sub ruinorgasmComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ruinorgasmComboBox.LostFocus



		My.Settings.OrgasmRuin = ruinorgasmComboBox.Text
		My.Settings.Save()



	End Sub


	Private Sub CBAutosaveChatlog_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBAutosaveChatlog.MouseClick
		If CBAutosaveChatlog.Checked = True Then
			My.Settings.CBAutosaveChatlog = True
		Else
			My.Settings.CBAutosaveChatlog = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBSaveChatlogExit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSaveChatlogExit.MouseClick
		If CBSaveChatlogExit.Checked = True Then
			My.Settings.CBExitSaveChatlog = True
		Else
			My.Settings.CBExitSaveChatlog = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBJackInTheBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBAuditStartup.MouseClick
		If CBAuditStartup.Checked = True Then
			My.Settings.AuditStartup = True
		Else
			My.Settings.AuditStartup = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub NBWritingTaskMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBWritingTaskMin.LostFocus
		My.Settings.NBWritingTaskMin = NBWritingTaskMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBWritingTaskMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBWritingTaskMin.ValueChanged
		If NBWritingTaskMin.Value > NBWritingTaskMax.Value Then NBWritingTaskMin.Value = NBWritingTaskMax.Value
	End Sub

	Private Sub NBWritingTaskMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBWritingTaskMax.LostFocus
		My.Settings.NBWritingTaskMax = NBWritingTaskMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBWritingTaskMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBWritingTaskMax.ValueChanged
		If NBWritingTaskMax.Value < NBWritingTaskMin.Value Then NBWritingTaskMax.Value = NBWritingTaskMin.Value
	End Sub

	Private Sub Button43_Click(sender As System.Object, e As System.EventArgs)
		'My.Computer.Network.DownloadFile("http://41.media.tumblr.com/71a41fe5e4b0fee012b516e2666465dd/tumblr_njunkf9uGX1rsx7u3o1_1280.jpg", "G:\Anime\Images\Tumblr\Tease AI\Scrape\file.jpg")

		If Form1.TnASlides.Enabled = True Then
			Form1.TnASlides.Stop()
			Return
		End If
		Form1.TnASlides.Start()

	End Sub





	Private Sub BTNBoobPath_Click(sender As System.Object, e As System.EventArgs) Handles BTNBoobPath.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLBoobPath.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.LBLBoobPath = LBLBoobPath.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNBoobURL_Click(sender As System.Object, e As System.EventArgs) Handles BTNBoobURL.Click
		If (WebImageFileDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
			LBLBoobURL.Text = WebImageFileDialog.FileName
			My.Settings.LBLBoobURL = LBLBoobURL.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNButtPath_Click(sender As System.Object, e As System.EventArgs) Handles BTNButtPath.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLButtPath.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.LBLButtPath = LBLButtPath.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNButtURL_Click(sender As System.Object, e As System.EventArgs) Handles BTNButtURL.Click
		If (WebImageFileDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
			LBLButtURL.Text = WebImageFileDialog.FileName
			My.Settings.LBLButtURL = LBLButtURL.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBBnBLocal_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBBnBLocal.LostFocus
		If CBBnBLocal.Checked = True Then
			My.Settings.CBBnBLocal = True
			My.Settings.CBBnBURL = False
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBBnBURL_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBBnBURL.LostFocus
		If CBBnBURL.Checked = True Then
			My.Settings.CBBnBLocal = False
			My.Settings.CBBnBURL = True
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBBoobSubDir_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBBoobSubDir.CheckedChanged
		If CBBoobSubDir.Checked = True Then
			My.Settings.CBBoobSubDir = True
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBButtSubDir_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBButtSubDir.CheckedChanged
		If CBButtSubDir.Checked = True Then
			My.Settings.CBButtSubDir = True
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBEnableBnB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBEnableBnB.CheckedChanged
		If CBEnableBnB.Checked = True Then

			If CBBnBLocal.Checked = True Then

				If Not Directory.Exists(LBLBoobPath.Text) Then
					MessageBox.Show(Me, "The current Boob path directory does not exist!" & Environment.NewLine & "Please set a directory using the button with the folder icon.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				If Not Directory.Exists(LBLButtPath.Text) Then
					MessageBox.Show(Me, "The current Butt path directory does not exist!" & Environment.NewLine & "Please set a directory using the button with the folder icon.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				If LBLBoobPath.Text = LBLButtPath.Text Then
					MessageBox.Show(Me, "The Boob and Butt paths must not be the same!" & Environment.NewLine & "Please select a different directory for at least one of them.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				Dim BnBFileCheck As New List(Of String)
				BnBFileCheck.Clear()

				Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
				'Dim files As String() = Directory.GetFiles(GetFolder, "*.*", SearchOption.AllDirectories)

				Dim files As String()

				If CBBoobSubDir.Checked = True Then
					files = Directory.GetFiles(LBLBoobPath.Text, "*.*", SearchOption.AllDirectories)
				Else
					files = Directory.GetFiles(LBLBoobPath.Text, "*.*")
				End If

				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						BnBFileCheck.Add(fi)
					End If
				Next


				If BnBFileCheck.Count < 1 Then
					MessageBox.Show(Me, "No images found in " & LBLBoobPath.Text & "!" & Environment.NewLine & "Please double check your selected folder and subdirectory setting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				BnBFileCheck.Clear()

				If CBButtSubDir.Checked = True Then
					files = Directory.GetFiles(LBLButtPath.Text, "*.*", SearchOption.AllDirectories)
				Else
					files = Directory.GetFiles(LBLButtPath.Text, "*.*")
				End If

				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						BnBFileCheck.Add(fi)
					End If
				Next

				If BnBFileCheck.Count < 1 Then
					MessageBox.Show(Me, "No images found in " & LBLButtPath.Text & "!" & Environment.NewLine & "Please double check your selected folder and subdirectory setting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If


				My.Settings.CBEnableBnB = True
				My.Settings.Save()
				Return

			End If

			If CBBnBURL.Checked = True Then

				If Not File.Exists(LBLBoobURL.Text) Then
					MessageBox.Show(Me, "The Boob URL File was not found!" & Environment.NewLine & "Please set a file using the button with the list icon", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				If Not File.Exists(LBLButtURL.Text) Then
					MessageBox.Show(Me, "The Butt URL File was not found!" & Environment.NewLine & "Please set a file using the button with the list icon", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBEnableBnB.Checked = False
					Return
				End If

				My.Settings.CBEnableBnB = True
				My.Settings.Save()
				Return

			End If

		End If
	End Sub

	Private Sub Button45_Click(sender As System.Object, e As System.EventArgs)
		Form1.GetBlogImage()

	End Sub

	Private Sub CheckBox6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBTagBoobs.CheckedChanged

	End Sub

	Private Sub BTNTagDir_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagDir.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then


			' BTNTagSave.Text = "Save and Display Next Image"

			ImageTagDir.Clear()

			TagImageFolder = FolderBrowserDialog1.SelectedPath

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			files = Directory.GetFiles(TagImageFolder, "*.*")

			Array.Sort(files)

			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					ImageTagDir.Add(fi)
				End If
			Next

			If ImageTagDir.Count < 1 Then
				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return
			End If

			Try
				ImageTagPictureBox.Image.Dispose()
			Catch
			End Try

			ImageTagPictureBox.Image = Nothing
			GC.Collect()

			ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(0))
			CurrentImageTagImage = ImageTagDir(0)

			If File.Exists(TagImageFolder & "\ImageTags.txt") Then
				Dim TagReader As New StreamReader(TagImageFolder & "\ImageTags.txt")
				Dim TagCheckList As New List(Of String)
				While TagReader.Peek <> -1
					TagCheckList.Add(TagImageFolder & TagReader.ReadLine())
				End While

				TagReader.Close()
				TagReader.Dispose()

				For i As Integer = 0 To TagCheckList.Count - 1
					If TagCheckList(i).Contains(Path.GetFileName(ImageTagDir(0))) Then
						Debug.Print(TagCheckList(i))
						CBTagFace.Checked = False
						CBTagBoobs.Checked = False
						CBTagPussy.Checked = False
						CBTagAss.Checked = False
						CBTagLegs.Checked = False
						CBTagFeet.Checked = False
						CBTagFullyDressed.Checked = False
						CBTagHalfDressed.Checked = False
						CBTagGarmentCovering.Checked = False
						CBTagHandsCovering.Checked = False
						CBTagNaked.Checked = False
						CBTagSideView.Checked = False
						CBTagCloseUp.Checked = False
						CBTagMasturbating.Checked = False
						CBTagSucking.Checked = False
						CBTagPiercing.Checked = False
						CBTagGarment.Checked = False
						CBTagUnderwear.Checked = False
						CBTagTattoo.Checked = False
						CBTagSexToy.Checked = False
						CBTagFurniture.Checked = False
						TBTagGarment.Text = ""
						TBTagUnderwear.Text = ""
						TBTagTattoo.Text = ""
						TBTagSexToy.Text = ""
						TBTagFurniture.Text = ""
						If TagCheckList(i).Contains("TagFace") Then CBTagFace.Checked = True
						If TagCheckList(i).Contains("TagBoobs") Then CBTagBoobs.Checked = True
						If TagCheckList(i).Contains("TagPussy") Then CBTagPussy.Checked = True
						If TagCheckList(i).Contains("TagAss") Then CBTagAss.Checked = True
						If TagCheckList(i).Contains("TagLegs") Then CBTagLegs.Checked = True
						If TagCheckList(i).Contains("TagFeet") Then CBTagFeet.Checked = True
						If TagCheckList(i).Contains("TagFullyDressed") Then CBTagFullyDressed.Checked = True
						If TagCheckList(i).Contains("TagHalfDressed") Then CBTagHalfDressed.Checked = True
						If TagCheckList(i).Contains("TagGarmentCovering") Then CBTagGarmentCovering.Checked = True
						If TagCheckList(i).Contains("TagHandsCovering") Then CBTagHandsCovering.Checked = True
						If TagCheckList(i).Contains("TagNaked") Then CBTagNaked.Checked = True
						If TagCheckList(i).Contains("TagSideView") Then CBTagSideView.Checked = True
						If TagCheckList(i).Contains("TagCloseUp") Then CBTagCloseUp.Checked = True
						If TagCheckList(i).Contains("TagMasturbating") Then CBTagMasturbating.Checked = True
						If TagCheckList(i).Contains("TagSucking") Then CBTagSucking.Checked = True
						If TagCheckList(i).Contains("TagPiercing") Then CBTagPiercing.Checked = True

						If TagCheckList(i).Contains("TagGarment") Then
							Dim TagSplit As String() = Split(TagCheckList(i))
							For j As Integer = 0 To TagSplit.Length - 1
								If TagSplit(j).Contains("TagGarment") Then
									TBTagGarment.Text = TagSplit(j).Replace("TagGarment", "")
									CBTagGarment.Checked = True
								End If
							Next
						End If

						If TagCheckList(i).Contains("TagUnderwear") Then
							Dim TagSplit As String() = Split(TagCheckList(i))
							For j As Integer = 0 To TagSplit.Length - 1
								If TagSplit(j).Contains("TagUnderwear") Then
									TBTagUnderwear.Text = TagSplit(j).Replace("TagUnderwear", "")
									CBTagUnderwear.Checked = True
								End If
							Next
						End If

						If TagCheckList(i).Contains("TagTattoo") Then
							Dim TagSplit As String() = Split(TagCheckList(i))
							For j As Integer = 0 To TagSplit.Length - 1
								If TagSplit(j).Contains("TagTattoo") Then
									TBTagTattoo.Text = TagSplit(j).Replace("TagTattoo", "")
									CBTagTattoo.Checked = True
								End If
							Next
						End If

						If TagCheckList(i).Contains("TagSexToy") Then
							Dim TagSplit As String() = Split(TagCheckList(i))
							For j As Integer = 0 To TagSplit.Length - 1
								If TagSplit(j).Contains("TagSexToy") Then
									TBTagSexToy.Text = TagSplit(j).Replace("TagSexToy", "")
									CBTagSexToy.Checked = True
								End If
							Next
						End If

						If TagCheckList(i).Contains("TagFurniture") Then
							Dim TagSplit As String() = Split(TagCheckList(i))
							For j As Integer = 0 To TagSplit.Length - 1
								If TagSplit(j).Contains("TagFurniture") Then
									TBTagFurniture.Text = TagSplit(j).Replace("TagFurniture", "")
									CBTagFurniture.Checked = True
								End If
							Next
						End If
					End If
				Next
			End If

			Form1.TagCount = 1
			LBLTagCount.Text = Form1.TagCount & "/" & ImageTagDir.Count

			'If ImageTagDir.Count = 1 Then BTNTagSave.Text = "Save and Finish"

			ImageTagCount = 0

			BTNTagSave.Enabled = True
			BTNTagNext.Enabled = True
			BTNTagPrevious.Enabled = False
			BTNTagDir.Enabled = False
			TBTagDir.Enabled = False

			CBTagFace.Enabled = True
			CBTagBoobs.Enabled = True
			CBTagPussy.Enabled = True
			CBTagAss.Enabled = True
			CBTagLegs.Enabled = True
			CBTagFeet.Enabled = True
			CBTagFullyDressed.Enabled = True
			CBTagHalfDressed.Enabled = True
			CBTagGarmentCovering.Enabled = True
			CBTagHandsCovering.Enabled = True
			CBTagNaked.Enabled = True
			CBTagSideView.Enabled = True
			CBTagCloseUp.Enabled = True
			CBTagMasturbating.Enabled = True
			CBTagSucking.Enabled = True
			CBTagPiercing.Enabled = True

			CBTagGarment.Enabled = True
			CBTagUnderwear.Enabled = True
			CBTagTattoo.Enabled = True
			CBTagSexToy.Enabled = True
			CBTagFurniture.Enabled = True

			TBTagGarment.Enabled = True
			TBTagUnderwear.Enabled = True
			TBTagTattoo.Enabled = True
			TBTagSexToy.Enabled = True
			TBTagFurniture.Enabled = True

			LBLTagCount.Enabled = True



		End If

	End Sub

	Private Sub TBTagDir_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TBTagDir.KeyPress

		If e.KeyChar = Convert.ToChar(13) Then

			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)

			If My.Computer.FileSystem.DirectoryExists(TBTagDir.Text) Then

				ImageTagDir.Clear()

				TagImageFolder = TBTagDir.Text

				Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
				Dim files As String()

				files = Directory.GetFiles(TagImageFolder, "*.*")

				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageTagDir.Add(fi)
					End If
				Next

				If ImageTagDir.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If

				Try
					ImageTagPictureBox.Image.Dispose()
				Catch
				End Try

				ImageTagPictureBox.Image = Nothing
				GC.Collect()

				Debug.Print("find")
				ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(0))


				CurrentImageTagImage = ImageTagDir(0)



				If File.Exists(TagImageFolder & "\ImageTags.txt") Then
					Debug.Print(TagImageFolder & "\ImageTags.txt  - File Exists")
					Dim TagReader As New StreamReader(TagImageFolder & "\ImageTags.txt")
					Dim TagCheckList As New List(Of String)
					While TagReader.Peek <> -1
						TagCheckList.Add(TagReader.ReadLine())
					End While

					TagReader.Close()
					TagReader.Dispose()

					For i As Integer = 0 To TagCheckList.Count - 1
						If TagCheckList(i).Contains(Path.GetFileName(ImageTagDir(0))) Then
							Debug.Print("For Next " & TagCheckList(i))
							CBTagFace.Checked = False
							CBTagBoobs.Checked = False
							CBTagPussy.Checked = False
							CBTagAss.Checked = False
							CBTagLegs.Checked = False
							CBTagFeet.Checked = False
							CBTagFullyDressed.Checked = False
							CBTagHalfDressed.Checked = False
							CBTagGarmentCovering.Checked = False
							CBTagHandsCovering.Checked = False
							CBTagNaked.Checked = False
							CBTagSideView.Checked = False
							CBTagCloseUp.Checked = False
							CBTagMasturbating.Checked = False
							CBTagSucking.Checked = False
							CBTagPiercing.Checked = False
							CBTagGarment.Checked = False
							CBTagUnderwear.Checked = False
							CBTagTattoo.Checked = False
							CBTagSexToy.Checked = False
							CBTagFurniture.Checked = False
							TBTagGarment.Text = ""
							TBTagUnderwear.Text = ""
							TBTagTattoo.Text = ""
							TBTagSexToy.Text = ""
							TBTagFurniture.Text = ""
							If TagCheckList(i).Contains("TagFace") Then CBTagFace.Checked = True
							If TagCheckList(i).Contains("TagBoobs") Then CBTagBoobs.Checked = True
							If TagCheckList(i).Contains("TagPussy") Then CBTagPussy.Checked = True
							If TagCheckList(i).Contains("TagAss") Then CBTagAss.Checked = True
							If TagCheckList(i).Contains("TagLegs") Then CBTagLegs.Checked = True
							If TagCheckList(i).Contains("TagFeet") Then CBTagFeet.Checked = True
							If TagCheckList(i).Contains("TagFullyDressed") Then CBTagFullyDressed.Checked = True
							If TagCheckList(i).Contains("TagHalfDressed") Then CBTagHalfDressed.Checked = True
							If TagCheckList(i).Contains("TagGarmentCovering") Then CBTagGarmentCovering.Checked = True
							If TagCheckList(i).Contains("TagHandsCovering") Then CBTagHandsCovering.Checked = True
							If TagCheckList(i).Contains("TagNaked") Then CBTagNaked.Checked = True
							If TagCheckList(i).Contains("TagSideView") Then CBTagSideView.Checked = True
							If TagCheckList(i).Contains("TagCloseUp") Then CBTagCloseUp.Checked = True
							If TagCheckList(i).Contains("TagMasturbating") Then CBTagMasturbating.Checked = True
							If TagCheckList(i).Contains("TagSucking") Then CBTagSucking.Checked = True
							If TagCheckList(i).Contains("TagPiercing") Then CBTagPiercing.Checked = True

							If TagCheckList(i).Contains("TagGarment") Then
								Dim TagSplit As String() = Split(TagCheckList(i))
								For j As Integer = 0 To TagSplit.Length - 1
									If TagSplit(j).Contains("TagGarment") Then
										TBTagGarment.Text = TagSplit(j).Replace("TagGarment", "")
										CBTagGarment.Checked = True
									End If
								Next
							End If

							If TagCheckList(i).Contains("TagUnderwear") Then
								Dim TagSplit As String() = Split(TagCheckList(i))
								For j As Integer = 0 To TagSplit.Length - 1
									If TagSplit(j).Contains("TagUnderwear") Then
										TBTagUnderwear.Text = TagSplit(j).Replace("TagUnderwear", "")
										CBTagUnderwear.Checked = True
									End If
								Next
							End If

							If TagCheckList(i).Contains("TagTattoo") Then
								Dim TagSplit As String() = Split(TagCheckList(i))
								For j As Integer = 0 To TagSplit.Length - 1
									If TagSplit(j).Contains("TagTattoo") Then
										TBTagTattoo.Text = TagSplit(j).Replace("TagTattoo", "")
										CBTagTattoo.Checked = True
									End If
								Next
							End If

							If TagCheckList(i).Contains("TagSexToy") Then
								Dim TagSplit As String() = Split(TagCheckList(i))
								For j As Integer = 0 To TagSplit.Length - 1
									If TagSplit(j).Contains("TagSexToy") Then
										TBTagSexToy.Text = TagSplit(j).Replace("TagSexToy", "")
										CBTagSexToy.Checked = True
									End If
								Next
							End If

							If TagCheckList(i).Contains("TagFurniture") Then
								Dim TagSplit As String() = Split(TagCheckList(i))
								For j As Integer = 0 To TagSplit.Length - 1
									If TagSplit(j).Contains("TagFurniture") Then
										TBTagFurniture.Text = TagSplit(j).Replace("TagFurniture", "")
										CBTagFurniture.Checked = True
									End If
								Next
							End If
						End If
					Next
				End If

				Form1.TagCount = 1
				LBLTagCount.Text = Form1.TagCount & "/" & ImageTagDir.Count

				'If ImageTagDir.Count = 1 Then BTNTagSave.Text = "Save and Finish"

				ImageTagCount = 0

				BTNTagSave.Enabled = True
				BTNTagNext.Enabled = True
				BTNTagPrevious.Enabled = False
				BTNTagDir.Enabled = False
				TBTagDir.Enabled = False

				CBTagFace.Enabled = True
				CBTagBoobs.Enabled = True
				CBTagPussy.Enabled = True
				CBTagAss.Enabled = True
				CBTagLegs.Enabled = True
				CBTagFeet.Enabled = True
				CBTagFullyDressed.Enabled = True
				CBTagHalfDressed.Enabled = True
				CBTagGarmentCovering.Enabled = True
				CBTagHandsCovering.Enabled = True
				CBTagNaked.Enabled = True
				CBTagSideView.Enabled = True
				CBTagCloseUp.Enabled = True
				CBTagMasturbating.Enabled = True
				CBTagSucking.Enabled = True
				CBTagPiercing.Enabled = True

				CBTagGarment.Enabled = True
				CBTagUnderwear.Enabled = True
				CBTagTattoo.Enabled = True
				CBTagSexToy.Enabled = True
				CBTagFurniture.Enabled = True

				TBTagGarment.Enabled = True
				TBTagUnderwear.Enabled = True
				TBTagTattoo.Enabled = True
				TBTagSexToy.Enabled = True
				TBTagFurniture.Enabled = True

				LBLTagCount.Enabled = True

			Else

				TBTagDir.Text = "Not a Valid Directory!"

			End If

		End If


	End Sub

	Private Sub BTNTagSave_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagSave.Click

		Dim TempImageDir As String = Path.GetFileName(CurrentImageTagImage)


		If CBTagFace.Checked = True Then TempImageDir = TempImageDir & " " & "TagFace"
		If CBTagBoobs.Checked = True Then TempImageDir = TempImageDir & " " & "TagBoobs"
		If CBTagPussy.Checked = True Then TempImageDir = TempImageDir & " " & "TagPussy"
		If CBTagAss.Checked = True Then TempImageDir = TempImageDir & " " & "TagAss"
		If CBTagLegs.Checked = True Then TempImageDir = TempImageDir & " " & "TagLegs"
		If CBTagFeet.Checked = True Then TempImageDir = TempImageDir & " " & "TagFeet"
		If CBTagFullyDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagFullyDressed"
		If CBTagHalfDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagHalfDressed"
		If CBTagGarmentCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagGarmentCovering"
		If CBTagHandsCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagHandsCovering"
		If CBTagNaked.Checked = True Then TempImageDir = TempImageDir & " " & "TagNaked"
		If CBTagSideView.Checked = True Then TempImageDir = TempImageDir & " " & "TagSideView"
		If CBTagCloseUp.Checked = True Then TempImageDir = TempImageDir & " " & "TagCloseUp"
		If CBTagMasturbating.Checked = True Then TempImageDir = TempImageDir & " " & "TagMasturbating"
		If CBTagSucking.Checked = True Then TempImageDir = TempImageDir & " " & "TagSucking"
		If CBTagPiercing.Checked = True Then TempImageDir = TempImageDir & " " & "TagPiercing"

		If CBTagGarment.Checked = True Then
			If TBTagGarment.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Garment field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagGarment" & TBTagGarment.Text
			End If
		End If

		If CBTagUnderwear.Checked = True Then
			If TBTagUnderwear.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Underwear field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagUnderwear" & TBTagUnderwear.Text
			End If
		End If

		If CBTagTattoo.Checked = True Then
			If TBTagTattoo.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Tattoo field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagTattoo" & TBTagTattoo.Text
			End If
		End If

		If CBTagSexToy.Checked = True Then
			If TBTagSexToy.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Room field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagSexToy" & TBTagSexToy.Text
			End If
		End If

		If CBTagFurniture.Checked = True Then
			If TBTagFurniture.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Furniture field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagFurniture" & TBTagFurniture.Text
			End If
		End If

		If File.Exists(TagImageFolder & "\ImageTags.txt") Then


			Dim TagCheckList As New List(Of String)
			TagCheckList = Txt2List(TagImageFolder & "\ImageTags.txt")
			TagCheckList = StripBlankLines(TagCheckList)

			'Dim TagReader As New StreamReader(TagImageFolder & "\ImageTags.txt")
			'Dim TagCheckList As New List(Of String)
			'While TagReader.Peek <> -1
			'TagCheckList.Add(TagReader.ReadLine())
			'End While
			'TagReader.Close()
			'TagReader.Dispose()

			Dim LineExists As Boolean
			LineExists = False

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(Path.GetFileName(CurrentImageTagImage)) Then
					TagCheckList(i) = TempImageDir
					LineExists = True
					System.IO.File.WriteAllLines(TagImageFolder & "\ImageTags.txt", TagCheckList)
				End If
			Next

			If LineExists = False Then
				My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", Environment.NewLine & TempImageDir, True)
				LineExists = False
			End If

		Else
			My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", TempImageDir, True)
		End If

		BTNTagDir.Enabled = True
		TBTagDir.Enabled = True
		BTNTagSave.Enabled = False
		BTNTagNext.Enabled = False
		BTNTagPrevious.Enabled = False




		' If BTNTagSave.Text = "Save and Finish" Then
		'BTNTagSave.Text = "Save and Display Next Image"
		'BTNTagSave.Enabled = False
		'MessageBox.Show(Me, "All images in this folder have been successfully tagged.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
		'ImageTagPictureBox.Image = Nothing
		'Return
		'End If

		CBTagFace.Checked = False
		CBTagBoobs.Checked = False
		CBTagPussy.Checked = False
		CBTagAss.Checked = False
		CBTagLegs.Checked = False
		CBTagFeet.Checked = False
		CBTagFullyDressed.Checked = False
		CBTagHalfDressed.Checked = False
		CBTagGarmentCovering.Checked = False
		CBTagHandsCovering.Checked = False
		CBTagNaked.Checked = False
		CBTagSideView.Checked = False
		CBTagCloseUp.Checked = False
		CBTagMasturbating.Checked = False
		CBTagSucking.Checked = False
		CBTagPiercing.Checked = False

		CBTagFace.Enabled = False
		CBTagBoobs.Enabled = False
		CBTagPussy.Enabled = False
		CBTagAss.Enabled = False
		CBTagLegs.Enabled = False
		CBTagFeet.Enabled = False
		CBTagFullyDressed.Enabled = False
		CBTagHalfDressed.Enabled = False
		CBTagGarmentCovering.Enabled = False
		CBTagHandsCovering.Enabled = False
		CBTagNaked.Enabled = False
		CBTagSideView.Enabled = False
		CBTagCloseUp.Enabled = False
		CBTagMasturbating.Enabled = False
		CBTagSucking.Enabled = False
		CBTagPiercing.Enabled = False

		CBTagGarment.Checked = False
		CBTagUnderwear.Checked = False
		CBTagTattoo.Checked = False
		CBTagSexToy.Checked = False
		CBTagFurniture.Checked = False

		CBTagGarment.Enabled = False
		CBTagUnderwear.Enabled = False
		CBTagTattoo.Enabled = False
		CBTagSexToy.Enabled = False
		CBTagFurniture.Enabled = False

		TBTagGarment.Enabled = False
		TBTagUnderwear.Enabled = False
		TBTagTattoo.Enabled = False
		TBTagSexToy.Enabled = False
		TBTagFurniture.Enabled = False

		TBTagGarment.Text = ""
		TBTagUnderwear.Text = ""
		TBTagTattoo.Text = ""
		TBTagSexToy.Text = ""
		TBTagFurniture.Text = ""

		LBLTagCount.Text = "0/0"
		LBLTagCount.Enabled = False


		ImageTagPictureBox.Image = Nothing



	End Sub

	Private Sub BTNTagNext_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagNext.Click

		Form1.TagCount += 1
		LBLTagCount.Text = Form1.TagCount & "/" & ImageTagDir.Count
		BTNTagPrevious.Enabled = True


		Dim TempImageDir As String = Path.GetFileName(CurrentImageTagImage)


		If CBTagFace.Checked = True Then TempImageDir = TempImageDir & " " & "TagFace"
		If CBTagBoobs.Checked = True Then TempImageDir = TempImageDir & " " & "TagBoobs"
		If CBTagPussy.Checked = True Then TempImageDir = TempImageDir & " " & "TagPussy"
		If CBTagAss.Checked = True Then TempImageDir = TempImageDir & " " & "TagAss"
		If CBTagLegs.Checked = True Then TempImageDir = TempImageDir & " " & "TagLegs"
		If CBTagFeet.Checked = True Then TempImageDir = TempImageDir & " " & "TagFeet"
		If CBTagFullyDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagFullyDressed"
		If CBTagHalfDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagHalfDressed"
		If CBTagGarmentCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagGarmentCovering"
		If CBTagHandsCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagHandsCovering"
		If CBTagNaked.Checked = True Then TempImageDir = TempImageDir & " " & "TagNaked"
		If CBTagSideView.Checked = True Then TempImageDir = TempImageDir & " " & "TagSideView"
		If CBTagCloseUp.Checked = True Then TempImageDir = TempImageDir & " " & "TagCloseUp"
		If CBTagMasturbating.Checked = True Then TempImageDir = TempImageDir & " " & "TagMasturbating"
		If CBTagSucking.Checked = True Then TempImageDir = TempImageDir & " " & "TagSucking"
		If CBTagPiercing.Checked = True Then TempImageDir = TempImageDir & " " & "TagPiercing"

		If CBTagGarment.Checked = True Then
			If TBTagGarment.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Garment field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagGarment" & TBTagGarment.Text
			End If
		End If

		If CBTagUnderwear.Checked = True Then
			If TBTagUnderwear.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Underwear field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagUnderwear" & TBTagUnderwear.Text
			End If
		End If

		If CBTagTattoo.Checked = True Then
			If TBTagTattoo.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Tattoo field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagTattoo" & TBTagTattoo.Text
			End If
		End If

		If CBTagSexToy.Checked = True Then
			If TBTagSexToy.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Room field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagSexToy" & TBTagSexToy.Text
			End If
		End If

		If CBTagFurniture.Checked = True Then
			If TBTagFurniture.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Underwear field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagFurniture" & TBTagFurniture.Text
			End If
		End If

		If File.Exists(TagImageFolder & "\ImageTags.txt") Then

			Dim TagCheckList As New List(Of String)
			TagCheckList = Txt2List(TagImageFolder & "\ImageTags.txt")
			TagCheckList = StripBlankLines(TagCheckList)

			Dim LineExists As Boolean
			LineExists = False

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(Path.GetFileName(CurrentImageTagImage)) Then
					TagCheckList(i) = TempImageDir
					LineExists = True
					System.IO.File.WriteAllLines(TagImageFolder & "\ImageTags.txt", TagCheckList)
				End If
			Next

			If LineExists = False Then
				My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", Environment.NewLine & TempImageDir, True)
				LineExists = False
			End If

		Else
			My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", TempImageDir, True)
		End If



		ImageTagCount += 1

		Try
			ImageTagPictureBox.Image.Dispose()
		Catch
		End Try

		ImageTagPictureBox.Image = Nothing
		GC.Collect()

		ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(ImageTagCount))



		CurrentImageTagImage = ImageTagDir(ImageTagCount)

		If ImageTagCount = ImageTagDir.Count - 1 Then BTNTagNext.Enabled = False


		If File.Exists(TagImageFolder & "\ImageTags.txt") Then
			Dim TagCheckList As New List(Of String)
			TagCheckList = Txt2List(TagImageFolder & "\ImageTags.txt")
			TagCheckList = StripBlankLines(TagCheckList)

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(Path.GetFileName(CurrentImageTagImage)) Then
					CBTagFace.Checked = False
					CBTagBoobs.Checked = False
					CBTagPussy.Checked = False
					CBTagAss.Checked = False
					CBTagLegs.Checked = False
					CBTagFeet.Checked = False
					CBTagFullyDressed.Checked = False
					CBTagHalfDressed.Checked = False
					CBTagGarmentCovering.Checked = False
					CBTagHandsCovering.Checked = False
					CBTagNaked.Checked = False
					CBTagSideView.Checked = False
					CBTagCloseUp.Checked = False
					CBTagMasturbating.Checked = False
					CBTagSucking.Checked = False
					CBTagPiercing.Checked = False
					CBTagGarment.Checked = False
					CBTagUnderwear.Checked = False
					CBTagTattoo.Checked = False
					CBTagSexToy.Checked = False
					CBTagFurniture.Checked = False
					TBTagGarment.Text = ""
					TBTagUnderwear.Text = ""
					TBTagTattoo.Text = ""
					TBTagSexToy.Text = ""
					TBTagFurniture.Text = ""

					If TagCheckList(i).Contains("TagFace") Then CBTagFace.Checked = True
					If TagCheckList(i).Contains("TagBoobs") Then CBTagBoobs.Checked = True
					If TagCheckList(i).Contains("TagPussy") Then CBTagPussy.Checked = True
					If TagCheckList(i).Contains("TagAss") Then CBTagAss.Checked = True
					If TagCheckList(i).Contains("TagLegs") Then CBTagLegs.Checked = True
					If TagCheckList(i).Contains("TagFeet") Then CBTagFeet.Checked = True
					If TagCheckList(i).Contains("TagFullyDressed") Then CBTagFullyDressed.Checked = True
					If TagCheckList(i).Contains("TagHalfDressed") Then CBTagHalfDressed.Checked = True
					If TagCheckList(i).Contains("TagGarmentCovering") Then CBTagGarmentCovering.Checked = True
					If TagCheckList(i).Contains("TagHandsCovering") Then CBTagHandsCovering.Checked = True
					If TagCheckList(i).Contains("TagNaked") Then CBTagNaked.Checked = True
					If TagCheckList(i).Contains("TagSideView") Then CBTagSideView.Checked = True
					If TagCheckList(i).Contains("TagCloseUp") Then CBTagCloseUp.Checked = True
					If TagCheckList(i).Contains("TagMasturbating") Then CBTagMasturbating.Checked = True
					If TagCheckList(i).Contains("TagSucking") Then CBTagSucking.Checked = True
					If TagCheckList(i).Contains("TagPiercing") Then CBTagPiercing.Checked = True

					If TagCheckList(i).Contains("TagGarment") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagGarment") Then
								TBTagGarment.Text = TagSplit(j).Replace("TagGarment", "")
								CBTagGarment.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagUnderwear") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagUnderwear") Then
								TBTagUnderwear.Text = TagSplit(j).Replace("TagUnderwear", "")
								CBTagUnderwear.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagTattoo") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagTattoo") Then
								TBTagTattoo.Text = TagSplit(j).Replace("TagTattoo", "")
								CBTagTattoo.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagSexToy") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagSexToy") Then
								TBTagSexToy.Text = TagSplit(j).Replace("TagSexToy", "")
								CBTagSexToy.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagFurniture") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagFurniture") Then
								TBTagFurniture.Text = TagSplit(j).Replace("TagFurniture", "")
								CBTagFurniture.Checked = True
							End If
						Next
					End If

				End If
			Next
		End If

	End Sub

	Private Sub BTNTagPrevious_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagPrevious.Click

		Form1.TagCount -= 1
		LBLTagCount.Text = Form1.TagCount & "/" & ImageTagDir.Count
		BTNTagNext.Enabled = True


		Dim TempImageDir As String = Path.GetFileName(CurrentImageTagImage)


		If CBTagFace.Checked = True Then TempImageDir = TempImageDir & " " & "TagFace"
		If CBTagBoobs.Checked = True Then TempImageDir = TempImageDir & " " & "TagBoobs"
		If CBTagPussy.Checked = True Then TempImageDir = TempImageDir & " " & "TagPussy"
		If CBTagAss.Checked = True Then TempImageDir = TempImageDir & " " & "TagAss"
		If CBTagLegs.Checked = True Then TempImageDir = TempImageDir & " " & "TagLegs"
		If CBTagFeet.Checked = True Then TempImageDir = TempImageDir & " " & "TagFeet"
		If CBTagFullyDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagFullyDressed"
		If CBTagHalfDressed.Checked = True Then TempImageDir = TempImageDir & " " & "TagHalfDressed"
		If CBTagGarmentCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagGarmentCovering"
		If CBTagHandsCovering.Checked = True Then TempImageDir = TempImageDir & " " & "TagHandsCovering"
		If CBTagNaked.Checked = True Then TempImageDir = TempImageDir & " " & "TagNaked"
		If CBTagSideView.Checked = True Then TempImageDir = TempImageDir & " " & "TagSideView"
		If CBTagCloseUp.Checked = True Then TempImageDir = TempImageDir & " " & "TagCloseUp"
		If CBTagMasturbating.Checked = True Then TempImageDir = TempImageDir & " " & "TagMasturbating"
		If CBTagSucking.Checked = True Then TempImageDir = TempImageDir & " " & "TagSucking"
		If CBTagPiercing.Checked = True Then TempImageDir = TempImageDir & " " & "TagPiercing"

		If CBTagGarment.Checked = True Then
			If TBTagGarment.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Garment field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagGarment" & TBTagGarment.Text
			End If
		End If

		If CBTagUnderwear.Checked = True Then
			If TBTagUnderwear.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Underwear field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagUnderwear" & TBTagUnderwear.Text
			End If
		End If

		If CBTagTattoo.Checked = True Then
			If TBTagTattoo.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Tattoo field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagTattoo" & TBTagTattoo.Text
			End If
		End If

		If CBTagSexToy.Checked = True Then
			If TBTagSexToy.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Room field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagSexToy" & TBTagSexToy.Text
			End If
		End If

		If CBTagFurniture.Checked = True Then
			If TBTagFurniture.Text = "" Then
				MessageBox.Show(Me, "Please enter a description in the Furniture field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			Else
				TempImageDir = TempImageDir & " " & "TagFurniture" & TBTagFurniture.Text
			End If
		End If

		If File.Exists(TagImageFolder & "\ImageTags.txt") Then

			Dim TagCheckList As New List(Of String)
			TagCheckList = Txt2List(TagImageFolder & "\ImageTags.txt")
			TagCheckList = StripBlankLines(TagCheckList)

			Dim LineExists As Boolean
			LineExists = False

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(Path.GetFileName(CurrentImageTagImage)) Then
					TagCheckList(i) = TempImageDir
					LineExists = True
					System.IO.File.WriteAllLines(TagImageFolder & "\ImageTags.txt", TagCheckList)
				End If
			Next

			If LineExists = False Then
				My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", Environment.NewLine & TempImageDir, True)
				LineExists = False
			End If

		Else
			My.Computer.FileSystem.WriteAllText(TagImageFolder & "\ImageTags.txt", TempImageDir, True)
		End If

		ImageTagCount -= 1

		Try
			ImageTagPictureBox.Image.Dispose()
		Catch
		End Try

		ImageTagPictureBox.Image = Nothing
		GC.Collect()

		ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(ImageTagCount))
		CurrentImageTagImage = ImageTagDir(ImageTagCount)

		If ImageTagCount = 0 Then BTNTagPrevious.Enabled = False


		If File.Exists(TagImageFolder & "\ImageTags.txt") Then

			Dim TagCheckList As New List(Of String)
			TagCheckList = Txt2List(TagImageFolder & "\ImageTags.txt")
			TagCheckList = StripBlankLines(TagCheckList)

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(Path.GetFileName(CurrentImageTagImage)) Then
					CBTagFace.Checked = False
					CBTagBoobs.Checked = False
					CBTagPussy.Checked = False
					CBTagAss.Checked = False
					CBTagLegs.Checked = False
					CBTagFeet.Checked = False
					CBTagFullyDressed.Checked = False
					CBTagHalfDressed.Checked = False
					CBTagGarmentCovering.Checked = False
					CBTagHandsCovering.Checked = False
					CBTagNaked.Checked = False
					CBTagSideView.Checked = False
					CBTagCloseUp.Checked = False
					CBTagMasturbating.Checked = False
					CBTagSucking.Checked = False
					CBTagPiercing.Checked = False
					CBTagGarment.Checked = False
					CBTagUnderwear.Checked = False
					CBTagTattoo.Checked = False
					CBTagSexToy.Checked = False
					CBTagFurniture.Checked = False
					TBTagGarment.Text = ""
					TBTagUnderwear.Text = ""
					TBTagTattoo.Text = ""
					TBTagSexToy.Text = ""
					TBTagFurniture.Text = ""
					If TagCheckList(i).Contains("TagFace") Then CBTagFace.Checked = True
					If TagCheckList(i).Contains("TagBoobs") Then CBTagBoobs.Checked = True
					If TagCheckList(i).Contains("TagPussy") Then CBTagPussy.Checked = True
					If TagCheckList(i).Contains("TagAss") Then CBTagAss.Checked = True
					If TagCheckList(i).Contains("TagLegs") Then CBTagLegs.Checked = True
					If TagCheckList(i).Contains("TagFeet") Then CBTagFeet.Checked = True
					If TagCheckList(i).Contains("TagFullyDressed") Then CBTagFullyDressed.Checked = True
					If TagCheckList(i).Contains("TagHalfDressed") Then CBTagHalfDressed.Checked = True
					If TagCheckList(i).Contains("TagGarmentCovering") Then CBTagGarmentCovering.Checked = True
					If TagCheckList(i).Contains("TagHandsCovering") Then CBTagHandsCovering.Checked = True
					If TagCheckList(i).Contains("TagNaked") Then CBTagNaked.Checked = True
					If TagCheckList(i).Contains("TagSideView") Then CBTagSideView.Checked = True
					If TagCheckList(i).Contains("TagCloseUp") Then CBTagCloseUp.Checked = True
					If TagCheckList(i).Contains("TagMasturbating") Then CBTagMasturbating.Checked = True
					If TagCheckList(i).Contains("TagSucking") Then CBTagSucking.Checked = True
					If TagCheckList(i).Contains("TagPiercing") Then CBTagPiercing.Checked = True

					If TagCheckList(i).Contains("TagGarment") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagGarment") Then
								TBTagGarment.Text = TagSplit(j).Replace("TagGarment", "")
								CBTagGarment.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagUnderwear") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagUnderwear") Then
								TBTagUnderwear.Text = TagSplit(j).Replace("TagUnderwear", "")
								CBTagUnderwear.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagTattoo") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagTattoo") Then
								TBTagTattoo.Text = TagSplit(j).Replace("TagTattoo", "")
								CBTagTattoo.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagSexToy") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagSexToy") Then
								TBTagSexToy.Text = TagSplit(j).Replace("TagSexToy", "")
								CBTagSexToy.Checked = True
							End If
						Next
					End If

					If TagCheckList(i).Contains("TagFurniture") Then
						Dim TagSplit As String() = Split(TagCheckList(i))
						For j As Integer = 0 To TagSplit.Length - 1
							If TagSplit(j).Contains("TagFurniture") Then
								TBTagFurniture.Text = TagSplit(j).Replace("TagFurniture", "")
								CBTagFurniture.Checked = True
							End If
						Next
					End If

				End If
			Next
		End If

	End Sub




	Private Sub CBSlideshowSubDir_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBSlideshowSubDir.LostFocus
		If CBSlideshowSubDir.Checked = True Then
			My.Settings.CBSlideshowSubDir = True
		Else
			My.Settings.CBSlideshowSubDir = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBSlideshowSubDir_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBSlideshowSubDir.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBSlideshowSubDir, "When this is selected, the program will include all subdirectories" & Environment.NewLine &
																			 "when you select a folder for domme slideshow images" & Environment.NewLine & Environment.NewLine &
																			 "When it is unselected, only the images in the top" & Environment.NewLine &
																			 "level of the folder will be used.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBSlideshowSubDir, "Wenn dies aktiviert ist, wird das Programm alle Unterordner mit" & Environment.NewLine &
																			"einbeziehn wenn du ein Ordner für Diashow bilder gewählt hast." & Environment.NewLine & Environment.NewLine &
																			"Wenn dies deaktiviert ist. Werden nur Bilder" & Environment.NewLine &
																			"des ausgewählten Ordners benutzt.")



		'LBLGeneralSettingsDescription.Text = "When this is selected, the program will include all subdirectories when you select a folder for slideshow images. When it is unselected, only the images in the top " & _
		'   "level of the folder will be used."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird das Programm alle Unterordner mit einbeziehn wenn du ein Ordner für Diashow bilder gewählt hast. "
		'Wenn dies deaktiviert ist. Werden nur Bilder des ausgewählten Ordners benutzt"
	End Sub

	Private Sub CBSlideshowRandom_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBSlideshowRandom.LostFocus
		If CBSlideshowRandom.Checked = True Then
			My.Settings.CBSlideshowRandom = True
		Else
			My.Settings.CBSlideshowRandom = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBSlideshowRandom_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBSlideshowRandom.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBSlideshowRandom, "When this is selected, the slideshow will display images randomly." & Environment.NewLine &
																			 "When it is unselected, it will display images in order of their filename.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBSlideshowRandom, "Wenn dies aktiviert ist, werden Diashow Bilder zufällig angezeigt." & Environment.NewLine &
																			" Wenn dies deaktiviert ist, werden die Bilder in Reihenfolge ihrer Dateinamen gezeigt.")


		'LBLGeneralSettingsDescription.Text = "When this is selected, the slideshow will display images randomly. When it is unselected, it will display images in order of their filename."
		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, werden Diashow Bilder zufällig angezeigt. Wenn dies deaktiviert ist, werden die Bilder in Reihenfolge ihrer Dateinamen gezeigt."

	End Sub

	Private Sub CBAutosaveChatlog_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBAutosaveChatlog.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBAutosaveChatlog, "When this is selected, the program will save a chatlog called" & Environment.NewLine &
																			 """Autosave.html"" any time you or the domme post a message." & Environment.NewLine & Environment.NewLine &
																			 "This log is overwritten each time, so it will only display a record of the current session." & Environment.NewLine &
																			 "This log can be found in the ""Chatlogs"" directory in the root folder of the program.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBAutosaveChatlog, "Wenn dies aktiviert ist, speichert das Programm einen Chatlog" & Environment.NewLine &
																			"(„Autosave.html"") immer wenn du oder die Domina eine Nachricht senden." & Environment.NewLine & Environment.NewLine &
																			"Dieses Log wird jedes Mal überschrieben, so das es nur die Aktuelle Session aufnimmt/anzeigt." & Environment.NewLine &
																			"Dieses Log befindet sich im Ordner „Chatlogs"" in dem Tease AI Ordner.")


		'LBLGeneralSettingsDescription.Text = "When this is selected, the program will save a chatlog called ""Autosave.html"" any time you or the domme post a message. This log is overwritten each time, so it will only display " & _
		' "a record of the current session. This log can be found in the ""Chatlogs"" directory in the root folder of the program."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, speichert das Programm einen Chatlog („Autosave.html"") immer wenn du oder die Domina eine Nachricht senden."
		' Dieses Log wird jedes Mal überschrieben, so das es nur die Aktuelle Session aufnimmt/anzeigt. Dieses Log befindet sich im Ordner „Chatlogs"" in dem Tease AI Ordner."

	End Sub

	Private Sub CBSaveChatlogExit_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBSaveChatlogExit.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBSaveChatlogExit, "When this is selected, a unique chatlog that includes the" & Environment.NewLine &
																			 "date and time will be created whenever you exit the program." & Environment.NewLine & Environment.NewLine &
																			 "This log can be found in the ""Chatlogs"" directory in the root folder of the program.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBSaveChatlogExit, "Wenn dies aktiviert ist, speichert das Programm einen einzigartigen Chatlog," & Environment.NewLine &
																			"der Datum und Zeit beinhaltet, immer dann wenn du das Programm beendest." & Environment.NewLine & Environment.NewLine &
																			"Dieses Log befindet sich im Ordner „Chatlogs"" in dem Tease AI Ordner.")


		' LBLGeneralSettingsDescription.Text = "When this is selected, a unique chatlog that includes the date and time will be created whenever you exit the program. This log can be found in the ""Chatlogs"" directory in " & _
		'    "the root folder of the program."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, speichert das Programm einen einzigartigen Chatlog, der Datum und Zeit beinhaltet, immer dann wenn du das "
		'Programm beendest. Dieses Log befindet sich im Ordner „Chatlogs"" in dem Tease AI Ordner."
	End Sub

	Private Sub CBJackInTheBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBAuditStartup.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(CBAuditStartup, "When this is checked, the program will automatically audit all" & Environment.NewLine &
																		  "scripts in the current domme's directory and fix common errors.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(CBAuditStartup, "Wenn dies aktiviert ist, wird das Programm automatisch alle" & Environment.NewLine &
																		 "Scripts im domina Ordner prüfen und häufige Fehler beheben.")


		'LBLGeneralSettingsDescription.Text = "When this is checked, the program will automatically audit all scripts in the current domme's directory and fix common errors."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies aktiviert ist, wird das Programm automatisch alle Scripts im domina Ordner prüfen und häufige Fehler beheben"
	End Sub

	Private Sub TBSafeword_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBSafeword.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(TBSafeword, "Use this to set the word you would like to use as your safeword." & Environment.NewLine & Environment.NewLine &
																	  "When used by itself during interaction with the domme, it will stop all activity" & Environment.NewLine &
																	  "and begin an Interrupt script where the domme makes sure you're okay to continue.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(TBSafeword, "Gebe hier dein Safeword ein, welches alle Aktivitäten der Domina stopt," & Environment.NewLine &
																	 "bis sie sicher ist, das du weiter machen kannst.")

		'LBLGeneralSettingsDescription.Text = "Use this to set the word you would like to use as your safeword. When used by itself during interaction with the domme, it will stop all activity and begin an Interrupt" _
		'   & " script where the domme makes sure you're okay to continue."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Gebe hier dein Safeword ein, welches alle Aktivitäten der Domina stopt, bis sie sicher ist, das du weiter machen kannst."
	End Sub

	Private Sub TTSCheckbox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TTSCheckBox.MouseHover


		If RBEnglish.Checked = True Then TTDir.SetToolTip(TTSCheckBox, "When this is selected, the domme will ""speak"" her lines using whichever TTS voice you have selected." & Environment.NewLine &
																	   "This setting must be manually checked to make the most out of the Hypnotic Guide app." & Environment.NewLine & Environment.NewLine &
																	   "For privacy reasons, this setting will not be saved through multiple uses of the program." & Environment.NewLine &
																	   "It must be selected each time you start Tease AI and wish to use it.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(TTSCheckBox, "Wenn dies Aktiviert ist, wird die Domina ihre Zeilen ""sprechen"" mit welcher TTS stimme du gewählt hast." & Environment.NewLine &
																	  "Diese Einstellung muss Manuel gewählt werden um das meiste aus der Hypnotic Guide app zu machen." & Environment.NewLine & Environment.NewLine &
																	  "Wegen der Privatsphäre wird diese Einstellung nicht gespeichert," & Environment.NewLine &
																	  "sondern muss bei jedem Start von Tease AI gesondert gewählt werden.")


		'LBLGeneralSettingsDescription.Text = "When this is selected, the domme will ""speak"" her lines using whichever TTS voice you have selected. This setting must be manually checked to make the most out of the" _
		'   & " Hypnotic Guide app. For privacy reasons, this setting will not be saved through multiple uses of the program. It must be selected each time you start Tease AI and wish to use it."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Wenn dies Aktiviert ist, wird die Domina ihre Zeilen ""sprechen"" mit welcher TTS stimme du gewählt hast."
		'Diese Einstellung muss Manuel gewählt werden um das meiste aus der Hypnotic Guide app zu machen. Wegen der Privatsphäre wird diese Einstellung nicht gespeichert,
		'   sondern muss bei jedem Start von Tease AI gesondert gewählt werden."
	End Sub

	Private Sub TTSComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TTSComboBox.MouseHover

		TTDir.SetToolTip(TTSComboBox, "Make a selection from the Text-to-Speech voices installed on your computer.")

		' LBLGeneralSettingsDescription.Text = "Make a selection from the Text-to-Speech voices installed on your computer."

		'If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = ""
	End Sub

	'Private Sub GBGeneralSystem_MouseEnter(sender As System.Object, e As System.EventArgs) Handles GBGeneralSystem.MouseEnter
	'   LBLGeneralSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its function."

	'    If RBGerman.Checked = True Then LBLGeneralSettingsDescription.Text = "Ziehe die Maus über irgendeine Einstellung um eine genaure Beschreibung der Einstellung zu bekommen."
	'End Sub


#Region " Domme Settings "

	Private Sub domageNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domageNumBox.LostFocus
		My.Settings.DomAge = domageNumBox.Value
		My.Settings.Save()
	End Sub

	Private Sub domageNumBox_MouseHover(sender As Object, e As System.EventArgs) Handles domageNumBox.MouseHover

		TTDir.SetToolTip(domageNumBox, "Sets the Domme's age (18-99 years old).")

		'LblDommeSettingsDescription.Text = "Sets the Domme's age (18-99 years old)." & Environment.NewLine & Environment.NewLine & "This setting mainly affects how the domme describes herself in random conversation. For example, a younger domme might refer to her skin " _
		' & "as tight or smooth, while an older domme might choose words like sensuous. Scripts may also contain keywords and variables that will limit certain paths to certain age groups."
	End Sub


	Private Sub domlevelNumBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles domlevelNumBox.MouseHover

		TTDir.SetToolTip(domlevelNumBox, "Sets the Domme's level (1-5)." & Environment.NewLine & Environment.NewLine &
						 "This setting affects the difficulty of the tasks the domme will subject you to.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's level (1-5)." & Environment.NewLine & Environment.NewLine & "This setting affects the difficulty of the tasks the domme will subject you to. For example, a domme with a higher level may make you hold edges for " _
		'   & "longer periods of time, while a domme with a lower level may not make you edge that often. The domme's level is a general guideline of how easy-going or sadistic she can be, not necessarily what she will " _
		'  & "choose for you every time."
	End Sub

	Private Sub NBEmpathy_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBEmpathy.MouseHover

		TTDir.SetToolTip(NBEmpathy, "Sets the Domme's Apathy level (1-5)." & Environment.NewLine & Environment.NewLine &
					   "This setting affects how merciless the domme is likely to be with you")

		'LblDommeSettingsDescription.Text = "Sets the Domme's Apathy level (1-5)." & Environment.NewLine & Environment.NewLine & "This setting affects how lenient the domme is likely to be with you. For example, a domme with a higher level may rarely take mercy on you or let " _
		'   & "you stop a task, while a domme with a lower level may never attempt to push your limits."
	End Sub

	Private Sub NBDomBirthdayMonth_MouseHover(sender As Object, e As System.EventArgs) Handles NBDomBirthdayMonth.MouseHover

		TTDir.SetToolTip(NBDomBirthdayMonth, "Sets the month the domme was born.")

		'LblDommeSettingsDescription.Text = "Sets the month the domme was born."
	End Sub

	Private Sub NBDomBirthdayDay_MouseHover(sender As Object, e As System.EventArgs) Handles NBDomBirthdayDay.MouseHover

		TTDir.SetToolTip(NBDomBirthdayDay, "Sets the day the domme was born.")

		'LblDommeSettingsDescription.Text = "Sets the day the domme was born."
	End Sub

	Private Sub TBDomHairColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBDomHairColor.LostFocus
		My.Settings.DomHair = TBDomHairColor.Text
		My.Settings.Save()
	End Sub

	Private Sub domhairComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBDomHairColor.MouseHover

		TTDir.SetToolTip(TBDomHairColor, "Sets the domme's hair color.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's hair color." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her hair color over the course of the tease. Set this value to the color " & _
		' "of the slideshow model's hair to enhance immersion."
	End Sub

	Private Sub domhairlengthComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domhairlengthComboBox.LostFocus
		My.Settings.DomHairLength = domhairlengthComboBox.Text
		My.Settings.Save()
	End Sub

	Private Sub domhairlengthComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles domhairlengthComboBox.MouseHover

		TTDir.SetToolTip(domhairlengthComboBox, "Sets the domme's hair length.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's hair length." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her hair length over the course of the tease. Set this value to the length " & _
		'   "of the slideshow model's hair to enhance immersion."
	End Sub

	Private Sub TBDomEyeColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBDomEyeColor.LostFocus
		My.Settings.DomEyes = TBDomEyeColor.Text
		My.Settings.Save()
	End Sub

	Private Sub domeyesComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBDomEyeColor.MouseHover

		TTDir.SetToolTip(TBDomEyeColor, "Sets the domme's eye color.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's eye color." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her eye color over the course of the tease. Set this value to the color " & _
		'   "of the slideshow model's eyes to enhance immersion."
	End Sub

	Private Sub boobComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles boobComboBox.LostFocus
		My.Settings.DomCup = boobComboBox.Text
		My.Settings.Save()
	End Sub

	Private Sub boobComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles boobComboBox.MouseHover

		TTDir.SetToolTip(boobComboBox, "Sets the Domme's cup size.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's cup size." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to the size of her breasts over the course of the tease. Set this value to the " & _
		'   "slideshow model's cup size to enhance immersion."
	End Sub

	Private Sub dompubichairComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles dompubichairComboBox.LostFocus
		My.Settings.DomPubicHair = dompubichairComboBox.Text
		My.Settings.Save()
	End Sub

	Private Sub dompubichairComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles dompubichairComboBox.MouseHover

		TTDir.SetToolTip(dompubichairComboBox, "Sets description of the Domme's pubic hair.")

		'LblDommeSettingsDescription.Text = "Sets description of the Domme's pubic hair." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her pubic hair over the course of the tease. Set this value to a description " & _
		'  "of the slideshow model's pubic hair to enhance immersion."
	End Sub

	' Private Sub dompersonalityComboBox_MouseHover(sender As System.Object, e As System.EventArgs)
	' LblDommeSettingsDescription.Text = "Sets the Domme's personality to a type you have created or downloaded." & Environment.NewLine & Environment.NewLine & "Different personalities allow for varied experiences while using " & _
	'     "this program. For best results, this value should only be changed before greeting the domme."
	' End Sub

	Private Sub crazyCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles crazyCheckBox.LostFocus
		If crazyCheckBox.Checked = True Then
			My.Settings.DomCrazy = True
		Else
			My.Settings.DomCrazy = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub crazyCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles crazyCheckBox.MouseHover

		TTDir.SetToolTip(crazyCheckBox, "Gives the Domme the Crazy trait." & Environment.NewLine & Environment.NewLine &
					 "This will open up dialogue options that suggest the domme is a little unhinged.")

		'LblDommeSettingsDescription.Text = "Gives the Domme the Crazy trait." & Environment.NewLine & Environment.NewLine & "This will open up dialogue options that suggest the domme is a little unhinged. " & _
		'   "Scripts may also contain keywords and variables that will limit certain paths to this trait."
	End Sub

	Private Sub CBDomTattoos_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBDomTattoos.LostFocus
		If CBDomTattoos.Checked = True Then
			My.Settings.DomTattoos = True
		Else
			My.Settings.DomTattoos = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBDomTattoos_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBDomTattoos.MouseHover

		TTDir.SetToolTip(CBDomTattoos, "Sets whether the domme has tattoos.")

		'LblDommeSettingsDescription.Text = "Sets whether the domme has tattoos." & Environment.NewLine & Environment.NewLine & "This will open up dialogue options that involve the domme being tattooed. " & _
		' "Scripts may also contain keywords and variables that will limit certain paths to this trait."
	End Sub


	Private Sub CBDomFreckles_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBDomFreckles.LostFocus
		If CBDomFreckles.Checked = True Then
			My.Settings.DomFreckles = True
		Else
			My.Settings.DomFreckles = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBDomFreckles_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBDomFreckles.MouseHover

		TTDir.SetToolTip(CBDomTattoos, "Sets whether the domme has freckles.")

		'LblDommeSettingsDescription.Text = "Sets whether the domme has freckles." & Environment.NewLine & Environment.NewLine & "This will open up dialogue options that involve the domme having freckles. " & _
		'   "Scripts may also contain keywords and variables that will limit certain paths to this trait."
	End Sub

	Private Sub vulgarCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles vulgarCheckBox.LostFocus
		If vulgarCheckBox.Checked = True Then
			My.Settings.DomVulgar = True
		Else
			My.Settings.DomVulgar = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub vulgarCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles vulgarCheckBox.MouseHover

		TTDir.SetToolTip(vulgarCheckBox, "Gives the Domme the Vulgar trait." & Environment.NewLine & Environment.NewLine &
				  "This will open up vulgar dialogue options for the domme.")

		'LblDommeSettingsDescription.Text = "Gives the Domme the Vulgar trait." & Environment.NewLine & Environment.NewLine & "This will open up vulgar dialogue options for the domme. She will include words like ""titties"" and " & _
		' """gonads"" while a more reserved domme may limit herself to ""tits"" and ""balls"". Scripts may also contain keywords and variables that will limit certain paths to this trait."
	End Sub

	Private Sub supremacistCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles supremacistCheckBox.LostFocus
		If supremacistCheckBox.Checked = True Then
			My.Settings.DomSupremacist = True
		Else
			My.Settings.DomSupremacist = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub supremacistCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles supremacistCheckBox.MouseHover

		TTDir.SetToolTip(supremacistCheckBox, "Gives the Domme the Supremacist trait." & Environment.NewLine & Environment.NewLine &
										 "This will open up dialogue options that suggest the" & Environment.NewLine &
										 "domme considers herself inherently superior to you.")

		' LblDommeSettingsDescription.Text = "Gives the Domme the Supremacist trait." & Environment.NewLine & Environment.NewLine & "This will open up dialogue options that suggest the domme considers herself inherently superior " & _
		'    "to you. Scripts may also contain keywords and variables that will limit certain paths to this trait."
	End Sub

	Private Sub LCaseCheckBoxCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles LCaseCheckBox.LostFocus
		If LCaseCheckBox.Checked = True Then
			My.Settings.DomLowercase = True
		Else
			My.Settings.DomLowercase = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub alloworgasmComboBox_MouseHover(sender As Object, e As System.EventArgs) Handles alloworgasmComboBox.MouseHover

		TTDir.SetToolTip(alloworgasmComboBox, "Sets how often the domme allows the user to have an orgasm during End scripts." & Environment.NewLine & Environment.NewLine &
											  "To further define these parameters, use the options in the Ranges tab.")


		'LblDommeSettingsDescription.Text = "Sets how often the domme allows the user to have an orgasm during End scripts." & Environment.NewLine & Environment.NewLine & "To further define these parameters, use the options in the Ranges tab."
	End Sub

	Private Sub ruinorgasmComboBox_MouseHover(sender As Object, e As System.EventArgs) Handles ruinorgasmComboBox.MouseHover

		TTDir.SetToolTip(ruinorgasmComboBox, "Sets how often the domme will ruin the user's orgasm during End scripts." & Environment.NewLine & Environment.NewLine &
											  "To further define these parameters, use the options in the Ranges tab.")

		'LblDommeSettingsDescription.Text = "Sets how often the domme will ruin the user's orgasm during End scripts." & Environment.NewLine & Environment.NewLine & "To further define these parameters, use the options in the Ranges tab."
	End Sub

	Private Sub LCaseCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles LCaseCheckBox.MouseHover

		TTDir.SetToolTip(LCaseCheckBox, "When this is checked, the domme won't use capital letters when she types." & Environment.NewLine & Environment.NewLine &
										 "She will still capitalize Me/My/Mine if that box is checked.")


		'LblDommeSettingsDescription.Text = "When this is checked, the domme won't use capital letters when she types." & Environment.NewLine & Environment.NewLine & "She will still capitalize Me/My/Mine if that box is checked."
	End Sub

	Private Sub apostropheCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles apostropheCheckBox.LostFocus
		If apostropheCheckBox.Checked = True Then
			My.Settings.DomNoApostrophes = True
		Else
			My.Settings.DomNoApostrophes = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub apostropheCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles apostropheCheckBox.MouseHover

		TTDir.SetToolTip(apostropheCheckBox, "When this is checked, the domme won't use apostrophes when she types.")

		'LblDommeSettingsDescription.Text = "When this is checked, the domme won't use apostrophes when she types."
	End Sub

	Private Sub commaCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles commaCheckBox.LostFocus
		If commaCheckBox.Checked = True Then
			My.Settings.DomNoCommas = True
		Else
			My.Settings.DomNoCommas = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub commaCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles commaCheckBox.MouseHover

		TTDir.SetToolTip(commaCheckBox, "When this is checked, the domme won't use commas when she types.")

		'LblDommeSettingsDescription.Text = "When this is checked, the domme won't use commas when she types."
	End Sub

	Private Sub periodCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles periodCheckBox.LostFocus
		If periodCheckBox.Checked = True Then
			My.Settings.DomNoPeriods = True
		Else
			My.Settings.DomNoPeriods = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub periodCheckBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles periodCheckBox.MouseHover

		TTDir.SetToolTip(periodCheckBox, "When this is checked, the domme won't use periods when she types.")

		'LblDommeSettingsDescription.Text = "When this is checked, the domme won't use periods when she types."
	End Sub

	Private Sub CBMeMyMine_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBMeMyMine.LostFocus
		If CBMeMyMine.Checked = True Then
			My.Settings.DomMeMyMine = True
		Else
			My.Settings.DomMeMyMine = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBMeMyMine_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBMeMyMine.MouseHover
		TTDir.SetToolTip(CBMeMyMine, "When this is checked, the domme will always capitalize ""Me, My and Mine""." & Environment.NewLine & Environment.NewLine &
		   "If the lowercase typing option is checked, she will also capitalize ""I, I'm, I'd and I'll"".")
	End Sub

	Private Sub TBEmote_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBEmote.LostFocus
		My.Settings.TBEmote = TBEmote.Text
		My.Settings.Save()
	End Sub

	Private Sub TBEmoteEnd_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBEmoteEnd.LostFocus
		My.Settings.TBEmoteEnd = TBEmoteEnd.Text
		My.Settings.Save()
	End Sub



	Private Sub TBEmote_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBEmote.MouseHover
		TTDir.SetToolTip(TBEmote, "This determines what symbol(s) the domme uses to begin an emote.")
	End Sub

	Private Sub TBEmoteEnd_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBEmoteEnd.MouseHover
		TTDir.SetToolTip(TBEmoteEnd, "This determines what symbol(s) the domme uses to end an emote.")
	End Sub

	Private Sub CBDomDenialEnds_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBDomDenialEnds.LostFocus
		If CBDomDenialEnds.Checked = True Then
			My.Settings.DomDenialEnd = True
		Else
			My.Settings.DomDenialEnd = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBDomDenialEnds_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBDomDenialEnds.MouseHover
		TTDir.SetToolTip(CBDomDenialEnds, "Determines whether the domme will keep teasing you after you have been denied." & Environment.NewLine & Environment.NewLine &
			"If this box is checked, she will end the tease after she decides to deny your orgasm." & Environment.NewLine &
			"If it is unchecked, she may choose to start teasing you all over again.")
	End Sub

	Private Sub CBDomOrgasmEnds_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBDomOrgasmEnds.LostFocus
		If CBDomOrgasmEnds.Checked = True Then
			My.Settings.DomOrgasmEnd = True
		Else
			My.Settings.DomOrgasmEnd = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBDomOrgasmEnds_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBDomOrgasmEnds.MouseHover
		TTDir.SetToolTip(CBDomOrgasmEnds, "Determines whether the domme will keep teasing you after you have an orgasm." & Environment.NewLine & Environment.NewLine &
			 "If this box is checked, she will end the tease after she allows you to cum." & Environment.NewLine &
			 "If it is unchecked, she may choose to start teasing you all over again.")
	End Sub

	Private Sub LockOrgasm_MouseHover(sender As System.Object, e As System.EventArgs) Handles orgasmsperlockButton.MouseHover
		TTDir.SetToolTip(orgasmsperlockButton, "When this arrangement is selected, the domme will limit the number of" & Environment.NewLine &
												"orgasms she allows you to have according to the parameters you set." & Environment.NewLine & Environment.NewLine &
												"This will not be finalized until the Limit box is checked and you click ""Lock Selected""." & Environment.NewLine &
												"Once an orgasm limit has been finalized, it cannot be undone until the period of time is up!")
	End Sub

	Private Sub limitcheckbox_MouseHover(sender As System.Object, e As System.EventArgs) Handles limitcheckbox.MouseHover
		TTDir.SetToolTip(limitcheckbox, "When this arrangement is selected, the domme will limit the number of" & Environment.NewLine &
												"orgasms she allows you to have according to the parameters you set." & Environment.NewLine & Environment.NewLine &
												"This will not be finalized until the Limit box is checked and you click ""Lock Selected""." & Environment.NewLine &
												"Once an orgasm limit has been finalized, it cannot be undone until the period of time is up!")
	End Sub

	Private Sub orgasmsPerNumBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles orgasmsPerNumBox.MouseHover
		TTDir.SetToolTip(orgasmsPerNumBox, "When this arrangement is selected, the domme will limit the number of" & Environment.NewLine &
												"orgasms she allows you to have according to the parameters you set." & Environment.NewLine & Environment.NewLine &
												"This will not be finalized until the Limit box is checked and you click ""Lock Selected""." & Environment.NewLine &
												"Once an orgasm limit has been finalized, it cannot be undone until the period of time is up!")
	End Sub

	Private Sub orgasmsperComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles orgasmsperComboBox.MouseHover
		TTDir.SetToolTip(orgasmsperComboBox, "When this arrangement is selected, the domme will limit the number of" & Environment.NewLine &
												"orgasms she allows you to have according to the parameters you set." & Environment.NewLine & Environment.NewLine &
												"This will not be finalized until the Limit box is checked and you click ""Lock Selected""." & Environment.NewLine &
												"Once an orgasm limit has been finalized, it cannot be undone until the period of time is up!")
	End Sub



	Private Sub LockRandomOrgasm_MouseHover(sender As System.Object, e As System.EventArgs) Handles orgasmlockrandombutton.MouseHover

		TTDir.SetToolTip(orgasmsperComboBox, "When this arrangement is selected, the domme will randomly limit the" & Environment.NewLine &
											  "number of orgasms she allows you to have for a random period of time." & Environment.NewLine & Environment.NewLine &
											  "Once you confirm this choice, it cannot be undone until the period of time is up!")

		'LblDommeSettingsDescription.Text = "When this button is clicked, the domme will randomly limit the number of orgasms she allows you to have for a random period of time." & Environment.NewLine & Environment.NewLine & _
		'   "Her choice will be based on her level, so be careful. A higher level domme could limit the amount of orgasms you have for up to a year! Once you confirm this choice, it cannot be undone until the period of time is up!"
	End Sub

	Private Sub NBDomMoodMin_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMin.LostFocus
		My.Settings.DomMoodMin = NBDomMoodMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBDomMoodMin_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMin.MouseHover

		TTDir.SetToolTip(NBDomMoodMin, "Determines the low range of the domme's mood index." & Environment.NewLine &
									   "The domme's mood may affect certain dialogue choices or outcomes." & Environment.NewLine & Environment.NewLine &
									   "The higher this number is, the easier it is to put her in a bad mood." & Environment.NewLine &
									   "Setting this value to ""1"" will prevent the domme from ever being in a bad mood.")



		'LblDommeSettingsDescription.Text = "Determines the low range of the domme's mood index. The domme's mood may affect certain dialogue choices or outcomes." & Environment.NewLine & Environment.NewLine & _
		'   "The higher this number is, the easier it is to put her in a bad mood. Setting this value to ""1"" will prevent the domme from ever being in a bad mood."
	End Sub

	Private Sub NBDomMoodMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMax.LostFocus
		My.Settings.DomMoodMax = NBDomMoodMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBDomMoodMax_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMax.MouseHover

		TTDir.SetToolTip(NBDomMoodMax, "Determines the high range of the domme's mood index." & Environment.NewLine &
									"The domme's mood may affect certain dialogue choices or outcomes." & Environment.NewLine & Environment.NewLine &
									"The lower this number is, the easier it is to put her in a good mood." & Environment.NewLine &
									"Setting this value to ""10"" will prevent the domme from ever being in an especially great mood.")



		'LblDommeSettingsDescription.Text = "Determines the high range of the domme's mood index. The domme's mood may affect certain dialogue choices or outcomes." & Environment.NewLine & Environment.NewLine & _
		'   "The lower this number is, the easier it is to put her in an especially great mood. Setting this value to ""10"" will prevent the domme from ever being in an especially great mood."
	End Sub

	Private Sub NBDomMoodMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMin.ValueChanged
		If NBDomMoodMin.Value > NBDomMoodMax.Value Then NBDomMoodMin.Value = NBDomMoodMax.Value
	End Sub

	Private Sub NBDomMoodMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBDomMoodMax.ValueChanged
		If NBDomMoodMax.Value < NBDomMoodMin.Value Then NBDomMoodMax.Value = NBDomMoodMin.Value
	End Sub

	Private Sub NBAvgCockMin_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMin.LostFocus
		My.Settings.AvgCockMin = NBAvgCockMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBAvgCockMin_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMin.MouseHover
		TTDir.SetToolTip(NBAvgCockMin, "Determines the lowest range of what the domme considers an average cock size." & Environment.NewLine & Environment.NewLine &
									   "If your cock size is lower then this, the domme will consider it small.")
	End Sub

	Private Sub NBAvgCockMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMax.LostFocus
		My.Settings.AvgCockMax = NBAvgCockMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBAvgCockMax_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMax.MouseHover
		TTDir.SetToolTip(NBAvgCockMin, "Determines the highest range of what the domme considers an average cock size." & Environment.NewLine & Environment.NewLine &
		   "If your cock size is higher than this, the domme will consider it big.")
	End Sub

	Private Sub NBAvgCockMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMin.ValueChanged
		If NBAvgCockMin.Value > NBAvgCockMax.Value Then NBAvgCockMin.Value = NBAvgCockMax.Value
	End Sub

	Private Sub NBAvgCockMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMax.ValueChanged
		If NBAvgCockMax.Value < NBAvgCockMin.Value Then NBAvgCockMax.Value = NBAvgCockMin.Value
	End Sub

	Private Sub NBSelfAgeMin_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSelfAgeMin.LostFocus
		My.Settings.SelfAgeMin = NBSelfAgeMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBSelfAgeMin_Enter(sender As Object, e As System.EventArgs) Handles NBSelfAgeMin.MouseHover

		TTDir.SetToolTip(NBSelfAgeMin, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
									   "If the domme's age is below this number, she will use dialogue options that suggest" & Environment.NewLine &
									   "having the maturity and body of a girl in her early twenties.")
	End Sub

	Private Sub NBSelfAgeMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSelfAgeMax.LostFocus
		My.Settings.SelfAgeMax = NBSelfAgeMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBSelfAgeMax_Enter(sender As Object, e As System.EventArgs) Handles NBSelfAgeMax.MouseHover

		TTDir.SetToolTip(NBSelfAgeMax, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
			   "If the domme's age is above this number, she will use dialogue options that suggest" & Environment.NewLine &
			   "an exceptional amount of maturity, or having an aging body.")
	End Sub

	Private Sub NBSelfAgeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBSelfAgeMin.ValueChanged
		If NBSelfAgeMin.Value > NBSelfAgeMax.Value Then NBSelfAgeMin.Value = NBSelfAgeMax.Value
	End Sub

	Private Sub NBSelfAgeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBSelfAgeMax.ValueChanged
		If NBSelfAgeMax.Value < NBSelfAgeMin.Value Then NBSelfAgeMax.Value = NBSelfAgeMin.Value
	End Sub

	Private Sub NBSubAgeMin_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSubAgeMin.LostFocus
		My.Settings.SubAgeMin = NBSubAgeMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBSubAgeMin_Enter(sender As Object, e As System.EventArgs) Handles NBSubAgeMin.MouseHover
		TTDir.SetToolTip(NBSubAgeMin, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
			"If your age is below this number, the domme will use dialogue options that suggest" & Environment.NewLine &
			"you have the virility and body of a male in his early twenties.")
	End Sub

	Private Sub NBSubAgeMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSubAgeMax.LostFocus
		My.Settings.SubAgeMax = NBSubAgeMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBSubAgeMax_Enter(sender As Object, e As System.EventArgs) Handles NBSubAgeMax.MouseHover
		TTDir.SetToolTip(NBSubAgeMax, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
									  "If your age is above this number, the domme will use dialogue options that suggest" & Environment.NewLine &
									  "you're over the hill.")
	End Sub

	Private Sub NBSubAgeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBSubAgeMin.ValueChanged
		If NBSubAgeMin.Value > NBSubAgeMax.Value Then NBSubAgeMin.Value = NBSubAgeMax.Value
	End Sub

	Private Sub NBSubAgeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBSubAgeMax.ValueChanged
		If NBSubAgeMax.Value < NBSubAgeMin.Value Then NBSubAgeMax.Value = NBSubAgeMin.Value
	End Sub

	Private Sub PetNameBox1_Enter(sender As Object, e As System.EventArgs) Handles petnameBox1.MouseHover
		TTDir.SetToolTip(petnameBox1, "Enter a pet name that the domme will call you when she's in a great mood." & Environment.NewLine & Environment.NewLine &
									  "All pet name boxes must be filled in.")
	End Sub

	Private Sub PetNameBox2_Enter(sender As Object, e As System.EventArgs) Handles petnameBox2.MouseHover
		TTDir.SetToolTip(petnameBox2, "Enter a pet name that the domme will call you when she's in a great mood." & Environment.NewLine & Environment.NewLine &
										"All pet name boxes must be filled in.")
	End Sub

	Private Sub PetNameBox3_Enter(sender As Object, e As System.EventArgs) Handles petnameBox3.MouseHover
		TTDir.SetToolTip(petnameBox3, "Enter a pet name that the domme will call you when she's in a neutral mood." & Environment.NewLine & Environment.NewLine &
									   "All pet name boxes must be filled in.")
	End Sub

	Private Sub PetNameBox4_Enter(sender As Object, e As System.EventArgs) Handles petnameBox4.MouseHover
		TTDir.SetToolTip(petnameBox4, "Enter a pet name that the domme will call you when she's in a neutral mood." & Environment.NewLine & Environment.NewLine &
									  "All pet name boxes must be filled in.")
	End Sub

	Private Sub PetNameBox5_Enter(sender As Object, e As System.EventArgs) Handles petnameBox5.MouseHover
		TTDir.SetToolTip(petnameBox5, "Enter a pet name that the domme will call you when she's in a neutral mood." & Environment.NewLine & Environment.NewLine &
											 "All pet name boxes must be filled in.")
	End Sub

	Private Sub PetNameBox6_Enter(sender As Object, e As System.EventArgs) Handles petnameBox6.MouseHover
		TTDir.SetToolTip(petnameBox6, "Enter a pet name that the domme will call you when she's in a neutral mood." & Environment.NewLine & Environment.NewLine &
									 "All pet name boxes must be filled in.")
	End Sub


	Private Sub PetNameBox7_Enter(sender As Object, e As System.EventArgs) Handles petnameBox7.MouseHover
		TTDir.SetToolTip(petnameBox7, "Enter a pet name that the domme will call you when she's in a bad mood." & Environment.NewLine & Environment.NewLine &
									 "All pet name boxes must be filled in.")
	End Sub


	Private Sub PetNameBox8_Enter(sender As Object, e As System.EventArgs) Handles petnameBox8.MouseHover
		TTDir.SetToolTip(petnameBox8, "Enter a pet name that the domme will call you when she's in a bad mood." & Environment.NewLine & Environment.NewLine &
									 "All pet name boxes must be filled in.")
	End Sub

	Private Sub BTNSaveDomSet_MouseHover(sender As Object, e As System.EventArgs) Handles BTNSaveDomSet.MouseHover
		TTDir.SetToolTip(BTNSaveDomSet, "Click to save this configuration of Domme Settings to a file that you can load at any time.")
	End Sub

	Private Sub BTNLoadDomSet_MouseHover(sender As Object, e As System.EventArgs) Handles BTNLoadDomSet.MouseHover
		TTDir.SetToolTip(BTNLoadDomSet, "Click to load a custom Domme Settings file you have previously created.")
	End Sub


#End Region


	Private Sub CBLockWindow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBInputIcon.LostFocus
		If CBInputIcon.Checked = True Then
			My.Settings.CBInputIcon = True
		Else
			My.Settings.CBInputIcon = False
		End If
		My.Settings.Save()
	End Sub




	Private Sub Button50_Click(sender As System.Object, e As System.EventArgs) Handles Button50.Click

		TBKeyWords.Text = ""
		RTBKeyWords.Text = ""

		Dim files() As String = Directory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\")

		LBKeyWords.Items.Clear()

		For Each file As String In files
			LBKeyWords.Items.Add(Path.GetFileName(file).Replace(".txt", ""))
		Next

	End Sub

	Private Sub LBKeyWords_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LBKeyWords.SelectedIndexChanged

		Dim KeyWordPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & LBKeyWords.SelectedItem & ".txt"

		If Not File.Exists(KeyWordPath) Then Return

		' If GlitPath = StatusText Then
		'MsgBox("This file is currently in use by the program. Saving changes may be slow until the Glitter process has finished.", , "Warning!")
		'End If


		TBKeyWords.Text = LBKeyWords.SelectedItem

		RTBKeyWords.Text = ""


		Dim ioFile As New StreamReader(KeyWordPath)
		Dim lines As New List(Of String)

		Dim KeyWordCount As Integer
		Dim KeyWordEnd As Integer

		KeyWordCount = -1

		While ioFile.Peek <> -1
			KeyWordCount += 1
			lines.Add(ioFile.ReadLine())
		End While


		KeyWordEnd = KeyWordCount
		KeyWordCount = 0



		Do
			RTBKeyWords.Text = RTBKeyWords.Text & lines(KeyWordCount) & Environment.NewLine
			KeyWordCount += 1
		Loop Until KeyWordCount = KeyWordEnd + 1

		ioFile.Close()
		ioFile.Dispose()

		Debug.Print(RTBKeyWords.Lines.Count)

	End Sub

	Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click

		Try
			If TBKeyWords.Text = "" Or InStr(TBKeyWords.Text, "#") <> 1 Or Not TBKeyWords.Text.Substring(0, 1) = "#" Then
				MessageBox.Show(Me, "Please enter a correct file name for this Keyword script!" & Environment.NewLine & Environment.NewLine & "Keyword file names must contain one ""#"" sign, " &
								"placed at the beginning of the word or phrase.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If
		Catch
			MessageBox.Show(Me, "Please enter a file name for this Keyword script!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End Try


		If RTBKeyWords.Text = "" Then
			MessageBox.Show(Me, "The Keyword file you are attempting to save is blank!" & Environment.NewLine & Environment.NewLine & "Please add some lines before saving.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		Dim KeyWordSaveDir As String = TBKeyWords.Text
		KeyWordSaveDir = KeyWordSaveDir.Replace(".txt", "")

		If Not LBKeyWords.Items.Contains(KeyWordSaveDir) Then
			LBKeyWords.Items.Add(KeyWordSaveDir)
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt", RTBKeyWords.Text, False)
			File.WriteAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt", File.ReadAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt").Where(Function(s) s <> String.Empty))
		Else
			Dim Result As Integer = MessageBox.Show(Me, KeyWordSaveDir & " already exists!" & Environment.NewLine & Environment.NewLine & "Do you wish to overwrite?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.Yes Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt", RTBKeyWords.Text, False)
				File.WriteAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt", File.ReadAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\" & KeyWordSaveDir & ".txt").Where(Function(s) s <> String.Empty))
			Else
				Debug.Print("Did not work")
				Return
			End If
		End If

		MessageBox.Show(Me, "Keyword file has been saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub

	Private Sub Button57_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIBrowse.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			TBWIDirectory.Text = FolderBrowserDialog1.SelectedPath
		End If
	End Sub

	Private Sub CBWISaveToDisk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBWISaveToDisk.CheckedChanged

		If CBWISaveToDisk.Checked = True Then
			If Not Directory.Exists(TBWIDirectory.Text) Then
				MessageBox.Show(Me, "Please enter or browse for a valid Saved Image Directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				CBWISaveToDisk.Checked = False
			End If
		End If


	End Sub

	Private Sub BTNWIAddandContinue_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIAddandContinue.Click
		Form1.ApproveImage = 1
	End Sub

	Private Sub BTNWIContinue_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIContinue.Click
		Form1.ApproveImage = 2
	End Sub

	Private Sub BTNCancel_Click(sender As System.Object, e As System.EventArgs) Handles BTNWICancel.Click
		URLCancel = True
	End Sub

	Private Sub BTNWIRemove_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIRemove.Click


		Form1.WebImageLines.Remove(Form1.WebImageLines(Form1.WebImageLine))


		If Form1.WebImageLine = Form1.WebImageLines.Count Then Form1.WebImageLine = 0
		'
		'Else
		'WebImageLine += 1
		'End If

		Try
			WebPictureBox.Image.Dispose()
		Catch
		End Try

		WebPictureBox.Image = Nothing
		GC.Collect()

		WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(Form1.WebImageLines(Form1.WebImageLine))))

		Debug.Print(Form1.WebImageLines(Form1.WebImageLine))

		My.Computer.FileSystem.DeleteFile(Form1.WebImagePath)

		If File.Exists(Form1.WebImagePath) Then
			Debug.Print("File Exists")
		Else
			Debug.Print("Nope")
		End If

		For i As Integer = 0 To Form1.WebImageLines.Count - 1
			If i = 0 Then
				My.Computer.FileSystem.WriteAllText(Form1.WebImagePath, Form1.WebImageLines(i), True)
			Else
				My.Computer.FileSystem.WriteAllText(Form1.WebImagePath, Environment.NewLine & Form1.WebImageLines(i), True)
			End If
		Next


	End Sub

	Private Sub BTNWILiked_Click(sender As System.Object, e As System.EventArgs) Handles BTNWILiked.Click


		If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & Form1.WebImageLines(Form1.WebImageLine), True)
		Else
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Form1.WebImageLines(Form1.WebImageLine), True)
		End If


	End Sub

	Private Sub BTNWIDisliked_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIDisliked.Click

		If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & Form1.WebImageLines(Form1.WebImageLine), True)
		Else
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Form1.WebImageLines(Form1.WebImageLine), True)
		End If

	End Sub

	Private Sub TBGreeting_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBGreeting.LostFocus
		My.Settings.SubGreeting = TBGreeting.Text
		My.Settings.Save()
	End Sub

	Private Sub TBYes_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBYes.LostFocus
		My.Settings.SubYes = TBYes.Text
		My.Settings.Save()
	End Sub

	Private Sub TBNo_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBNo.LostFocus
		My.Settings.SubNo = TBNo.Text
		My.Settings.Save()
	End Sub

	Private Sub TBHonorific_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBHonorific.LostFocus
		If TBHonorific.Text = "" Or TBHonorific.Text Is Nothing Then TBHonorific.Text = "Mistress"
		My.Settings.SubHonorific = TBHonorific.Text
		My.Settings.Save()
	End Sub

	Private Sub CBHonorificInclude_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBHonorificInclude.LostFocus
		If CBHonorificInclude.Checked = True Then
			My.Settings.CBUseHonor = True
		Else
			My.Settings.CBUseHonor = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBHonorificCapitalized_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBHonorificCapitalized.LostFocus
		If CBHonorificCapitalized.Checked = True Then
			My.Settings.CBCapHonor = True
		Else
			My.Settings.CBCapHonor = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub subAgeNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles subAgeNumBox.LostFocus
		My.Settings.SubAge = subAgeNumBox.Value
		My.Settings.Save()
	End Sub

	Private Sub NBDomBirthdayMonth_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomBirthdayMonth.LostFocus
		My.Settings.DomBirthMonth = NBDomBirthdayMonth.Value
		My.Settings.Save()
	End Sub

	Private Sub NBDomBirthdayDay_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomBirthdayDay.LostFocus
		My.Settings.DomBirthDay = NBDomBirthdayDay.Value
		My.Settings.Save()
	End Sub


	Private Sub NBBirthdayMonth_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBBirthdayMonth.LostFocus
		My.Settings.SubBirthMonth = NBBirthdayMonth.Value
		My.Settings.Save()
	End Sub

	Private Sub NBBirthdayDay_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBBirthdayDay.LostFocus
		My.Settings.SubBirthDay = NBBirthdayDay.Value
		My.Settings.Save()
	End Sub

	Private Sub TBSubHairColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBSubHairColor.LostFocus
		My.Settings.SubHair = TBSubHairColor.Text
		My.Settings.Save()
	End Sub

	Private Sub TBSubEyeColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBSubEyeColor.LostFocus
		My.Settings.SubEyes = TBSubEyeColor.Text
		My.Settings.Save()
	End Sub

	Private Sub Button37_Click_1(sender As System.Object, e As System.EventArgs) Handles Button37.Click
		If TBKeywordPreview.Text = "" Then Return

		LBLKeywordPreview.Text = Form1.PoundClean(TBKeywordPreview.Text)
	End Sub

	Private Sub NBBirthdayMonth_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBBirthdayMonth.MouseLeave

		If NBBirthdayMonth.Value = 2 And NBBirthdayDay.Value > 28 Then
			NBBirthdayDay.Value = 28
		End If

		If NBBirthdayMonth.Value = 4 Or NBBirthdayMonth.Value = 6 Or NBBirthdayMonth.Value = 9 Or NBBirthdayMonth.Value = 11 Then
			If NBBirthdayDay.Value > 30 Then
				NBBirthdayDay.Value = 30
			End If
			NBBirthdayDay.Maximum = 30
		Else
			NBBirthdayDay.Maximum = 31
		End If

		If NBBirthdayMonth.Value = 2 Then
			NBBirthdayDay.Maximum = 28
		End If

	End Sub

	Private Sub NBDomBirthdayMonth_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBDomBirthdayMonth.MouseLeave

		If NBDomBirthdayMonth.Value = 2 And NBDomBirthdayDay.Value > 28 Then
			NBDomBirthdayDay.Value = 28
		End If

		If NBDomBirthdayMonth.Value = 4 Or NBDomBirthdayMonth.Value = 6 Or NBDomBirthdayMonth.Value = 9 Or NBDomBirthdayMonth.Value = 11 Then
			If NBDomBirthdayDay.Value > 30 Then
				NBDomBirthdayDay.Value = 30
			End If
			NBDomBirthdayDay.Maximum = 30
		Else
			NBDomBirthdayDay.Maximum = 31
		End If

		If NBDomBirthdayMonth.Value = 2 Then
			NBDomBirthdayDay.Maximum = 28
		End If

	End Sub

	Private Sub ButtonOpenScript_Click(sender As System.Object, e As System.EventArgs)

		If OpenScriptDialog.ShowDialog() = DialogResult.OK Then

			Form1.StrokeTauntVal = -1

			Form1.FileText = OpenScriptDialog.FileName
			Form1.ScriptTick = 1
			Form1.ScriptTimer.Start()


		End If


	End Sub



	Private Sub timedRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles timedRadio.CheckedChanged
		If Form1.SlideshowLoaded = True And timedRadio.Checked = True Then
			Form1.SlideshowTimerTick = slideshowNumBox.Value
			Form1.SlideshowTimer.Start()
		End If
	End Sub

	Private Sub teaseRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles teaseRadio.CheckedChanged
		If timedRadio.Checked = False And Form1.FormLoading = False Then
			Form1.SlideshowTimer.Stop()
		End If
	End Sub

	Private Sub offRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles offRadio.CheckedChanged
		If timedRadio.Checked = False Then
			Form1.SlideshowTimer.Stop()
		End If
	End Sub

	Private Sub FontComboBoxD_LostFocus(sender As System.Object, e As System.EventArgs) Handles FontComboBoxD.LostFocus
		My.Settings.DomFont = FontComboBoxD.Text
		My.Settings.Save()
	End Sub

	Private Sub FontComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles FontComboBox.LostFocus
		My.Settings.SubFont = FontComboBox.Text
		My.Settings.Save()
	End Sub

	Private Sub NBFontSizeD_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBFontSizeD.LostFocus
		My.Settings.DomFontSize = NBFontSizeD.Value
		My.Settings.Save()
	End Sub

	Private Sub NBFontSize_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBFontSize.LostFocus
		My.Settings.SubFontSize = NBFontSize.Value
		My.Settings.Save()
	End Sub


	' Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
	'Dim Str As System.IO.Stream
	'Dim srRead As System.IO.StreamReader
	'   Try
	' make a Web request
	'Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(TextBox3.Text)
	'Dim resp As System.Net.WebResponse = req.GetResponse
	'       Str = resp.GetResponseStream
	'      srRead = New System.IO.StreamReader(Str)
	' read all the text
	'Dim strlist As New List(Of String)
	'       While srRead.Peek <> -1
	'          strlist.Add(srRead.ReadLine())
	'     End While

	'        For i As Integer = 0 To strlist.Count - 1
	'           If strlist(i).Contains(TextBox4.Text) Then
	'              MsgBox(TextBox4.Text & " found at line " & i + 1 & Environment.NewLine & Environment.NewLine & strlist(i))
	'         End If
	'    Next

	'        TextBox4.Text = "Finished"
	'   Catch ex As Exception
	'      TextBox4.Text = "Unable to download content"
	' Finally
	' Close Stream and StreamReader when done
	'    srRead.Close()
	'   Str.Close()
	'End Try
	'End Sub



	Private Sub CBImageInfo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBImageInfo.CheckedChanged
		If CBImageInfo.Checked = True Then
			Form1.LBLImageInfo.Visible = True
			'Form1.ShowImageInfo()
			My.Settings.CBImageInfo = True
		Else
			Form1.LBLImageInfo.Visible = False
			'Form1.LBLImageInfo.Text = ""
			My.Settings.CBImageInfo = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

		Dim KeywordCount As Integer = 0

		Dim Str As System.IO.Stream
		Dim srRead As System.IO.StreamReader
		Try
			' make a Web request
			Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(TBKeywordPreview.Text)
			Dim resp As System.Net.WebResponse = req.GetResponse
			Str = resp.GetResponseStream
			srRead = New System.IO.StreamReader(Str)
			' read all the text
			Dim strlist As New List(Of String)
			While srRead.Peek <> -1
				strlist.Add(srRead.ReadLine())
			End While

			For i As Integer = 0 To strlist.Count - 1
				If strlist(i).Contains("Keyword]") Then
					KeywordCount = InstrCount(strlist(i), "[Keyword]")
					strlist(i) = strlist(i).Replace("<br />", ",")
					strlist(i) = strlist(i).Replace("<br/>", ",")
					strlist(i) = strlist(i).Replace("</br>", ",")
					strlist(i) = strlist(i).Replace("</ br>", ",")


					For j As Integer = 1 To KeywordCount








					Next
				End If
			Next

			If KeywordCount > 0 Then
				Form1.ImportKeyword = True
				If KeywordCount > 1 Then
					'  Button3.Text = "Next"
				Else
					'  Button3.Enabled = False
				End If
			End If

			MsgBox("[Keyword] was found " & KeywordCount & " times!")

		Catch ex As Exception
			' TextBox4.Text = "Unable to download content"
		Finally



			' Close Stream and StreamReader when done
			srRead.Close()
			Str.Close()
		End Try


	End Sub

	Function InstrCount(StringToSearch As String,
		   StringToFind As String) As Long

		If Len(StringToFind) Then
			InstrCount = UBound(Split(StringToSearch, StringToFind))
		End If

		Return InstrCount
	End Function




	Private Sub TBTagDir_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBTagDir.MouseClick
		TBTagDir.SelectionStart = 0
		TBTagDir.SelectionLength = Len(TBTagDir.Text)
	End Sub

	Private Sub TBWIDirectory_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TBWIDirectory.MouseClick
		TBWIDirectory.SelectionStart = 0
		TBWIDirectory.SelectionLength = Len(TBWIDirectory.Text)
	End Sub




	Public Sub VerifyLocalImagePaths()

		Dim ImageList As New List(Of String)
		ImageList.Clear()

		PBMaintenance.Value = 0
		PBMaintenance.Maximum = 11

		Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
		Dim files As String()

		If CBIHardcore.Checked = True Then
			LBLMaintenance.Text = "Checking Hardcore image path..."
			If Not Directory.Exists(LBLIHardcore.Text) Then
				If LBLIHardcore.Text <> "" Or LBLIHardcore.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Hardcore images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Hardcore Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIHardcore.Checked = False
				LBLIHardcore.Text = ""
				My.Settings.IHardcore = "No path selected"
				My.Settings.CBIHardcore = False
			Else



				Dim ImageFolder As String = LBLIHardcore.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo HardcoreGood
				Next

HardcoreGood:
				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Hardcore folder!" & Environment.NewLine & Environment.NewLine &
									"Local Hardcore Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIHardcore.Checked = False
					LBLIHardcore.Text = ""
					My.Settings.IHardcore = "No path selected"
					My.Settings.CBIHardcore = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBISoftcore.Checked = True Then
			LBLMaintenance.Text = "Checking Softcore image path..."
			If Not Directory.Exists(LBLISoftcore.Text) Then
				If LBLISoftcore.Text <> "" Or LBLISoftcore.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Softcore images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Softcore Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBISoftcore.Checked = False
				LBLISoftcore.Text = ""
				My.Settings.ISoftcore = "No path selected"
				My.Settings.CBISoftcore = False
			Else

				Dim ImageFolder As String = LBLISoftcore.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo SoftcoreGood
				Next

SoftcoreGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Softcore folder!" & Environment.NewLine & Environment.NewLine &
									"Local Softcore Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBISoftcore.Checked = False
					LBLISoftcore.Text = ""
					My.Settings.ISoftcore = "No path selected"
					My.Settings.CBISoftcore = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBILesbian.Checked = True Then
			LBLMaintenance.Text = "Checking Lesbian image path..."
			If Not Directory.Exists(LBLILesbian.Text) Then
				If LBLILesbian.Text <> "" Or LBLILesbian.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Lesbian images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Lesbian Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBILesbian.Checked = False
				LBLILesbian.Text = ""
				My.Settings.ILesbian = "No path selected"
				My.Settings.CBILesbian = False
			Else

				Dim ImageFolder As String = LBLILesbian.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo LesbianGood
				Next

LesbianGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Lesbian folder!" & Environment.NewLine & Environment.NewLine &
									"Local Lesbian Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBILesbian.Checked = False
					LBLILesbian.Text = ""
					My.Settings.ILesbian = "No path selected"
					My.Settings.CBILesbian = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIBlowjob.Checked = True Then
			LBLMaintenance.Text = "Checking Blowjob image path..."
			If Not Directory.Exists(LBLIBlowjob.Text) Then
				If LBLIBlowjob.Text <> "" Or LBLIBlowjob.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Blowjob images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Blowjob Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIBlowjob.Checked = False
				LBLIBlowjob.Text = ""
				My.Settings.IBlowjob = "No path selected"
				My.Settings.CBIBlowjob = False
			Else

				Dim ImageFolder As String = LBLIBlowjob.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo BlowjobGood
				Next

BlowjobGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Blowjob folder!" & Environment.NewLine & Environment.NewLine &
									"Local Blowjob Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIBlowjob.Checked = False
					LBLIBlowjob.Text = ""
					My.Settings.IBlowjob = "No path selected"
					My.Settings.CBIBlowjob = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIFemdom.Checked = True Then
			LBLMaintenance.Text = "Checking Femdom image path..."
			If Not Directory.Exists(LBLIFemdom.Text) Then
				If LBLIFemdom.Text <> "" Or LBLIFemdom.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Femdom images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Femdom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIFemdom.Checked = False
				LBLIFemdom.Text = ""
				My.Settings.IFemdom = "No path selected"
				My.Settings.CBIFemdom = False
			Else

				Dim ImageFolder As String = LBLIFemdom.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo FemdomGood
				Next

FemdomGood:


				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Femdom folder!" & Environment.NewLine & Environment.NewLine &
									"Local Femdom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIFemdom.Checked = False
					LBLIFemdom.Text = ""
					My.Settings.IFemdom = "No path selected"
					My.Settings.CBIFemdom = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBILezdom.Checked = True Then
			LBLMaintenance.Text = "Checking Lezdom image path..."
			If Not Directory.Exists(LBLILezdom.Text) Then
				If LBLILezdom.Text <> "" Or LBLILezdom.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Lezdom images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Lezdom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBILezdom.Checked = False
				LBLILezdom.Text = ""
				My.Settings.ILezdom = "No path selected"
				My.Settings.CBILezdom = False
			Else

				Dim ImageFolder As String = LBLILezdom.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo LezdomGood
				Next

LezdomGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Lezdom folder!" & Environment.NewLine & Environment.NewLine &
									"Local Lezdom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBILezdom.Checked = False
					LBLILezdom.Text = ""
					My.Settings.ILezdom = "No path selected"
					My.Settings.CBILezdom = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIHentai.Checked = True Then
			LBLMaintenance.Text = "Checking Hentai image path..."
			If Not Directory.Exists(LBLIHentai.Text) Then
				If LBLIHentai.Text <> "" Or LBLIHentai.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Hentai images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Hentai Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIHentai.Checked = False
				LBLIHentai.Text = ""
				My.Settings.IHentai = "No path selected"
				My.Settings.CBIHentai = False
			Else

				Dim ImageFolder As String = LBLIHentai.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo HentaiGood
				Next

HentaiGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Hentai folder!" & Environment.NewLine & Environment.NewLine &
									"Local Hentai Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIHentai.Checked = False
					LBLIHentai.Text = ""
					My.Settings.IHentai = "No path selected"
					My.Settings.CBIHentai = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIGay.Checked = True Then
			LBLMaintenance.Text = "Checking Gay image path..."
			If Not Directory.Exists(LBLIGay.Text) Then
				If LBLIGay.Text <> "" Or LBLIGay.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Gay images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Gay Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIGay.Checked = False
				LBLIGay.Text = ""
				My.Settings.IGay = "No path selected"
				My.Settings.CBIGay = False
			Else

				Dim ImageFolder As String = LBLIGay.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo GayGood
				Next

GayGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Gay folder!" & Environment.NewLine & Environment.NewLine &
									"Local Gay Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIGay.Checked = False
					LBLIGay.Text = ""
					My.Settings.IGay = "No path selected"
					My.Settings.CBIGay = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIMaledom.Checked = True Then
			LBLMaintenance.Text = "Checking Maledom image path..."
			If Not Directory.Exists(LBLIMaledom.Text) Then
				If LBLIMaledom.Text <> "" Or LBLIMaledom.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Maledom images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Maledom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIMaledom.Checked = False
				LBLIMaledom.Text = ""
				My.Settings.IMaledom = "No path selected"
				My.Settings.CBIMaledom = False
			Else

				Dim ImageFolder As String = LBLIMaledom.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo MaledomGood
				Next

MaledomGood:


				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Maledom folder!" & Environment.NewLine & Environment.NewLine &
									"Local Maledom Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIMaledom.Checked = False
					LBLIMaledom.Text = ""
					My.Settings.IMaledom = "No path selected"
					My.Settings.CBIMaledom = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBICaptions.Checked = True Then
			LBLMaintenance.Text = "Checking Captions image path..."
			If Not Directory.Exists(LBLICaptions.Text) Then
				If LBLICaptions.Text <> "" Or LBLICaptions.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local Captions images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local Captions Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBICaptions.Checked = False
				LBLICaptions.Text = ""
				My.Settings.ICaptions = "No path selected"
				My.Settings.CBICaptions = False
			Else

				Dim ImageFolder As String = LBLICaptions.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo CaptionsGood
				Next

CaptionsGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified Captions folder!" & Environment.NewLine & Environment.NewLine &
									"Local Captions Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBICaptions.Checked = False
					LBLICaptions.Text = ""
					My.Settings.ICaptions = "No path selected"
					My.Settings.CBICaptions = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value += 1

		If CBIGeneral.Checked = True Then
			LBLMaintenance.Text = "Checking General image path..."
			If Not Directory.Exists(LBLIGeneral.Text) Then
				If LBLIGeneral.Text <> "" Or LBLIGeneral.Text <> "No path selected" Then
					MessageBox.Show(Me, "The directory for local General images was not found!" & Environment.NewLine & Environment.NewLine &
									"Local General Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
				CBIGeneral.Checked = False
				LBLIGeneral.Text = ""
				My.Settings.IGeneral = "No path selected"
				My.Settings.CBIGeneral = False
			Else

				Dim ImageFolder As String = LBLIGeneral.Text

				files = Directory.GetFiles(ImageFolder, "*.*")
				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						ImageList.Add(fi)
					End If
					If ImageList.Count > 0 Then GoTo GeneralGood
				Next

GeneralGood:

				If ImageList.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified General folder!" & Environment.NewLine & Environment.NewLine &
									"Local General Image setting has been deselected and cleared.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					CBIGeneral.Checked = False
					LBLIGeneral.Text = ""
					My.Settings.IGeneral = "No path selected"
					My.Settings.CBIGeneral = False
				End If
			End If

			ImageList.Clear()
		End If

		PBMaintenance.Value = PBMaintenance.Maximum


		My.Settings.Save()


		MessageBox.Show(Me, "All Local Image paths have been validated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

		LBLMaintenance.Text = ""

		BTNMaintenanceRebuild.Enabled = True
		BTNMaintenanceRefresh.Enabled = True
		BTNMaintenanceCancel.Enabled = False
		BTNMaintenanceValidate.Enabled = True

		PBMaintenance.Value = 0

	End Sub

	Public Sub RefreshURLList()


WhyUMakeMeDoDis:

		For i As Integer = 0 To URLFileList.Items.Count - 1
			'Debug.Print(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.Items(i) & ".txt") Then
				URLFileList.Items.Remove(URLFileList.Items(i))
				GoTo WhyUMakeMeDoDis
				Exit For
			End If
		Next

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To URLFileList.Items.Count - 1
			BinaryWriter.Write(CStr(URLFileList.Items(i)))
			BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

		If File.Exists(Application.StartupPath & "\Images\System\URLFileCheckList.cld") Then
			URLFileList.Items.Clear()
			Dim FileStream2 As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Open)
			Dim BinaryReader As New System.IO.BinaryReader(FileStream2)
			URLFileList.BeginUpdate()
			Do While FileStream2.Position < FileStream2.Length
				URLFileList.Items.Add(BinaryReader.ReadString)
				URLFileList.SetItemChecked(URLFileList.Items.Count - 1, BinaryReader.ReadBoolean)
			Loop
			URLFileList.EndUpdate()
			BinaryReader.Close()
			FileStream2.Dispose()
			If URLFileList.Items.Count > 0 Then
				For i As Integer = 0 To URLFileList.Items.Count - 1 Step -1
					If Not File.Exists(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.Items(i) & ".txt") Then URLFileList.Items.Remove(URLFileList.Items(i))
				Next
			End If
		Else
			URLFileList.Items.Clear()
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempUrl As String = foundFile
				TempUrl = Path.GetFileName(TempUrl).Replace(".txt", "")
				'TempUrl = TempUrl.Replace(".txt", "")
				'Do Until Not TempUrl.Contains("\")
				'TempUrl = TempUrl.Remove(0, 1)
				'Loop
				URLFileList.Items.Add(TempUrl)
			Next
			For i As Integer = 0 To URLFileList.Items.Count - 1
				URLFileList.SetItemChecked(i, True)
			Next
			Dim FileStream3 As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
			Dim BinaryWriter3 As New System.IO.BinaryWriter(FileStream3)
			For i = 0 To URLFileList.Items.Count - 1
				BinaryWriter3.Write(CStr(URLFileList.Items(i)))
				BinaryWriter3.Write(CBool(URLFileList.GetItemChecked(i)))
			Next
			BinaryWriter3.Close()
			FileStream3.Dispose()
		End If

	End Sub

	Private Sub URLFileList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles URLFileList.SelectedIndexChanged, URLFileList.LostFocus
		If FrmSettingsLoading = True Then Return

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To URLFileList.Items.Count - 1
			BinaryWriter.Write(CStr(URLFileList.Items(i)))
			BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()


	End Sub

	Private Sub BTNIHardcore_Click(sender As System.Object, e As System.EventArgs) Handles BTNIHardcore.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIHardcore.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IHardcore = LBLIHardcore.Text
			My.Settings.Save()
		End If
	End Sub


	Private Sub BTNISoftcore_Click(sender As System.Object, e As System.EventArgs) Handles BTNISoftcore.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLISoftcore.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.ISoftcore = LBLISoftcore.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNILesbian_Click(sender As System.Object, e As System.EventArgs) Handles BTNILesbian.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLILesbian.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.ILesbian = LBLILesbian.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles BTNIBlowjob.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIBlowjob.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IBlowjob = LBLIBlowjob.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIFemdom_Click(sender As System.Object, e As System.EventArgs) Handles BTNIFemdom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIFemdom.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IFemdom = LBLIFemdom.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNILezdom_Click(sender As System.Object, e As System.EventArgs) Handles BTNILezdom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLILezdom.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.ILezdom = LBLILezdom.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIHentai_Click(sender As System.Object, e As System.EventArgs) Handles BTNIHentai.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIHentai.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IHentai = LBLIHentai.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIGay_Click(sender As System.Object, e As System.EventArgs) Handles BTNIGay.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIGay.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IGay = LBLIGay.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIMaledom_Click(sender As System.Object, e As System.EventArgs) Handles BTNIMaledom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIMaledom.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IMaledom = LBLIMaledom.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNIGeneral_Click(sender As System.Object, e As System.EventArgs) Handles BTNIGeneral.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLIGeneral.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.IGeneral = LBLIGeneral.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIHardcoreSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIHardcoreSD.LostFocus
		Debug.Print("HardcoreSD CheckedChanged Called")
		If CBIHardcoreSD.Checked = True Then
			My.Settings.IHardcoreSD = True
		Else
			My.Settings.IHardcoreSD = False
		End If
		Debug.Print("My.Settings.IHardcoreSD = " & My.Settings.IHardcoreSD)
		My.Settings.Save()

	End Sub

	Private Sub CBISoftcoreSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBISoftcoreSD.LostFocus

		If CBISoftcoreSD.Checked = True Then
			My.Settings.ISoftcoreSD = True
		Else
			My.Settings.ISoftcoreSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBILesbianSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBILesbianSD.LostFocus

		If CBILesbianSD.Checked = True Then
			My.Settings.ILesbianSD = True
		Else
			My.Settings.ILesbianSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIBlowjobSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIBlowjobSD.LostFocus

		If CBIBlowjobSD.Checked = True Then
			My.Settings.IBlowjobSD = True
		Else
			My.Settings.IBlowjobSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIFemdomSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIFemdomSD.LostFocus

		If CBIFemdomSD.Checked = True Then
			My.Settings.IFemdomSD = True
		Else
			My.Settings.IFemdomSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBILezdomSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBILezdomSD.LostFocus

		If CBILezdomSD.Checked = True Then
			My.Settings.ILezdomSD = True
		Else
			My.Settings.ILezdomSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIHentaiSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIHentaiSD.LostFocus

		If CBIHentaiSD.Checked = True Then
			My.Settings.IHentaiSD = True
		Else
			My.Settings.IHentaiSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIGaySD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIGaySD.LostFocus

		If CBIGaySD.Checked = True Then
			My.Settings.IGaySD = True
		Else
			My.Settings.IGaySD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIMaledomSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIMaledomSD.LostFocus

		If CBIMaledomSD.Checked = True Then
			My.Settings.IMaledomSD = True
		Else
			My.Settings.IMaledomSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBIGeneralSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIGeneralSD.LostFocus

		If CBIGeneralSD.Checked = True Then
			My.Settings.IGeneralSD = True
		Else
			My.Settings.IGeneralSD = False
		End If
		My.Settings.Save()

	End Sub

	Private Sub CBICaptionsSD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBICaptionsSD.LostFocus

		If CBICaptionsSD.Checked = True Then
			My.Settings.ICaptionsSD = True
		Else
			My.Settings.ICaptionsSD = False
		End If
		My.Settings.Save()

	End Sub


	Private Sub CBIHardcore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIHardcore.CheckedChanged
		Debug.Print("Hardcore CheckedChanged Called WTF")
		Debug.Print("FrmSettingsLoading = " & FrmSettingsLoading)
		If FrmSettingsLoading = False Then
			Debug.Print("Hardcore CheckedChanged Called")
			If CBIHardcore.Checked = True Then
				My.Settings.CBIHardcore = True
			Else
				My.Settings.CBIHardcore = False
			End If
			Debug.Print("My.Settings.CBIHardcore = " & My.Settings.CBIHardcore)
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBISoftcore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBISoftcore.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBISoftcore.Checked = True Then
				My.Settings.CBISoftcore = True
			Else
				My.Settings.CBISoftcore = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBILesbian_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBILesbian.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBILesbian.Checked = True Then
				My.Settings.CBILesbian = True
			Else
				My.Settings.CBILesbian = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIBlowjob_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIBlowjob.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIBlowjob.Checked = True Then
				My.Settings.CBIBlowjob = True
			Else
				My.Settings.CBIBlowjob = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIFemdom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIFemdom.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIFemdom.Checked = True Then
				My.Settings.CBIFemdom = True
			Else
				My.Settings.CBIFemdom = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBILezdom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBILezdom.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBILezdom.Checked = True Then
				My.Settings.CBILezdom = True
			Else
				My.Settings.CBILezdom = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIHentai_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIHentai.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIHentai.Checked = True Then
				My.Settings.CBIHentai = True
			Else
				My.Settings.CBIHentai = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIGay_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIGay.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIGay.Checked = True Then
				My.Settings.CBIGay = True
			Else
				My.Settings.CBIGay = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIMaledom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIMaledom.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIMaledom.Checked = True Then
				My.Settings.CBIMaledom = True
			Else
				My.Settings.CBIMaledom = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBICaptions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBICaptions.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBICaptions.Checked = True Then
				My.Settings.CBICaptions = True
			Else
				My.Settings.CBICaptions = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBIGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBIGeneral.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBIGeneral.Checked = True Then
				My.Settings.CBIGeneral = True
			Else
				My.Settings.CBIGeneral = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNICaptions_Click(sender As System.Object, e As System.EventArgs) Handles BTNICaptions.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLICaptions.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.ICaptions = LBLICaptions.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub BTNDomImageDir_Click(sender As System.Object, e As System.EventArgs) Handles BTNDomImageDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLDomImageDir.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.DomImageDir = LBLDomImageDir.Text
			My.Settings.Save()
		End If
	End Sub

	Private Sub LBLIHardcore_Click(sender As System.Object, e As System.EventArgs) Handles LBLIHardcore.DoubleClick
		LBLIHardcore.Text = "No path selected"
	End Sub

	Private Sub LBLISoftcore_Click(sender As System.Object, e As System.EventArgs) Handles LBLISoftcore.DoubleClick
		LBLISoftcore.Text = "No path selected"
	End Sub

	Private Sub LBLILesbian_Click(sender As System.Object, e As System.EventArgs) Handles LBLILesbian.DoubleClick
		LBLILesbian.Text = "No path selected"
	End Sub

	Private Sub LBLIBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles LBLIBlowjob.DoubleClick
		LBLIBlowjob.Text = "No path selected"
	End Sub

	Private Sub LBLIFemdom_Click(sender As System.Object, e As System.EventArgs) Handles LBLIFemdom.DoubleClick
		LBLIFemdom.Text = "No path selected"
	End Sub

	Private Sub LBLILezdom_Click(sender As System.Object, e As System.EventArgs) Handles LBLILezdom.DoubleClick
		LBLILezdom.Text = "No path selected"
	End Sub

	Private Sub LBLIHentai_Click(sender As System.Object, e As System.EventArgs) Handles LBLIHentai.DoubleClick
		LBLIHentai.Text = "No path selected"
	End Sub

	Private Sub LBLIGay_Click(sender As System.Object, e As System.EventArgs) Handles LBLIGay.DoubleClick
		LBLIGay.Text = "No path selected"
	End Sub

	Private Sub LBLIMaledom_Click(sender As System.Object, e As System.EventArgs) Handles LBLIMaledom.DoubleClick
		LBLIMaledom.Text = "No path selected"
	End Sub

	Private Sub LBLICaptions_Click(sender As System.Object, e As System.EventArgs) Handles LBLICaptions.DoubleClick
		LBLICaptions.Text = "No path selected"
	End Sub

	Private Sub LBLIGeneral_Click(sender As System.Object, e As System.EventArgs) Handles LBLIGeneral.DoubleClick
		LBLIGeneral.Text = "No path selected"
	End Sub

	Private Sub SettingsTabs_TabIndexChanged(sender As Object, e As System.EventArgs) Handles SettingsTabs.SelectedIndexChanged

		If SettingsTabs.SelectedIndex = 3 Then
			If CLBStartList.Visible = True Then
				Debug.Print("PersonChange Starttab")
				StartTab()
			End If

			If CLBModuleList.Visible = True Then
				Debug.Print("PersonChange Moduletab")
				ModuleTab()
			End If

			If CLBLinkList.Visible = True Then
				Debug.Print("PersonChange Linktab")
				LinkTab()
			End If

			If CLBEndList.Visible = True Then
				Debug.Print("PersonChange Endab")
				EndTab()
			End If
		End If

		If TCScripts.SelectedIndex = 0 Then
			CLBStartList.Focus()
		End If

		If TCScripts.SelectedIndex = 1 Then
			CLBModuleList.Focus()
		End If

		If TCScripts.SelectedIndex = 2 Then
			CLBLinkList.Focus()
		End If

		If TCScripts.SelectedIndex = 3 Then
			CLBEndList.Focus()
		End If


	End Sub

	Private Sub TCScripts_TabIndexChanged(sender As Object, e As System.EventArgs) Handles TCScripts.SelectedIndexChanged
		Debug.Print(TCScripts.SelectedIndex)

		If TCScripts.SelectedIndex = 0 Then
			If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\StartCheckList.cld") Then
				LoadStartScripts()
				If CLBStartList.Items.Count > 0 Then
					CLBStartList.SetSelected(0, True)
					StartTab()
				End If

				Dim i, j As Long
				For i = 0 To CLBStartList.Items.Count - 1
					For j = CLBStartList.Items.Count - 1 To (i + 1) Step -1
						If CLBStartList.Items(i) = CLBStartList.Items(j) Then
							CLBStartList.Items.Remove(CLBStartList.Items(j))
						End If
					Next
				Next

			Else
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					Dim TempFile As String = foundFile
					TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
					CLBStartList.Items.Add(TempFile)
				Next
				SaveStartScripts()
				If CLBStartList.Items.Count > 0 Then
					CLBStartList.SetSelected(0, True)
					StartTab()
				End If
			End If
			CLBStartList.Focus()
		End If

		If TCScripts.SelectedIndex = 1 Then
			If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\ModuleCheckList.cld") Then
				LoadModuleScripts()

				If CLBModuleList.Items.Count > 0 Then
					CLBModuleList.SetSelected(0, True)
					ModuleTab()
				End If
				' Dim dupes(CLBModuleList.Items.Count - 1) As Object
				'CLBModuleList.Items.CopyTo(dupes, 0)
				'CLBModuleList.Items.Clear()
				Debug.Print("Doing it?")
				'CLBModuleList.Items.AddRange(dupes.AsEnumerable().Distinct().ToArray())

				Dim i, j As Long
				For i = 0 To CLBModuleList.Items.Count - 1
					For j = CLBModuleList.Items.Count - 1 To (i + 1) Step -1
						If CLBModuleList.Items(i) = CLBModuleList.Items(j) Then
							CLBModuleList.Items.Remove(CLBModuleList.Items(j))
						End If
					Next
				Next
			Else
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					Dim TempFile As String = foundFile
					TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
					CLBModuleList.Items.Add(TempFile)
				Next
				SaveModuleScripts()
				If CLBModuleList.Items.Count > 0 Then
					CLBModuleList.SetSelected(0, True)
					ModuleTab()
				End If
			End If
			CLBModuleList.Focus()
		End If

		If TCScripts.SelectedIndex = 2 Then
			If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\LinkCheckList.cld") Then
				LoadLinkScripts()
				If CLBLinkList.Items.Count > 0 Then
					CLBLinkList.SetSelected(0, True)
					LinkTab()
				End If
				Dim i, j As Long
				For i = 0 To CLBLinkList.Items.Count - 1
					For j = CLBLinkList.Items.Count - 1 To (i + 1) Step -1
						If CLBLinkList.Items(i) = CLBLinkList.Items(j) Then
							CLBLinkList.Items.Remove(CLBLinkList.Items(j))
						End If
					Next
				Next
			Else
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					Dim TempFile As String = foundFile
					TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
					CLBLinkList.Items.Add(TempFile)
				Next
				SaveLinkScripts()
				If CLBLinkList.Items.Count > 0 Then
					CLBLinkList.SetSelected(0, True)
					LinkTab()
				End If
			End If
			CLBLinkList.Focus()
		End If

		If TCScripts.SelectedIndex = 3 Then
			If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\EndCheckList.cld") Then
				LoadEndScripts()
				If CLBEndList.Items.Count > 0 Then
					CLBEndList.SetSelected(0, True)
					EndTab()
				End If

				Dim i, j As Long
				For i = 0 To CLBEndList.Items.Count - 1
					For j = CLBEndList.Items.Count - 1 To (i + 1) Step -1
						If CLBEndList.Items(i) = CLBEndList.Items(j) Then
							CLBEndList.Items.Remove(CLBEndList.Items(j))
						End If
					Next
				Next

			Else
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					Dim TempFile As String = foundFile
					TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
					CLBEndList.Items.Add(TempFile)
				Next
				SaveEndScripts()
				If CLBEndList.Items.Count > 0 Then
					CLBEndList.SetSelected(0, True)
					EndTab()
				End If
			End If
			CLBEndList.Focus()
		End If

	End Sub

	Public Sub SaveStartScripts()

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\StartCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To CLBStartList.Items.Count - 1
			BinaryWriter.Write(CStr(CLBStartList.Items(i)))
			BinaryWriter.Write(CBool(CLBStartList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

	End Sub

	Public Sub SaveModuleScripts()

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\ModuleCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To CLBModuleList.Items.Count - 1
			BinaryWriter.Write(CStr(CLBModuleList.Items(i)))
			BinaryWriter.Write(CBool(CLBModuleList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

	End Sub

	Public Sub SaveLinkScripts()

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\LinkCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To CLBLinkList.Items.Count - 1
			BinaryWriter.Write(CStr(CLBLinkList.Items(i)))
			BinaryWriter.Write(CBool(CLBLinkList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

	End Sub

	Public Sub SaveEndScripts()

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\EndCheckList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To CLBEndList.Items.Count - 1
			BinaryWriter.Write(CStr(CLBEndList.Items(i)))
			BinaryWriter.Write(CBool(CLBEndList.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

	End Sub


	Public Sub InitializeStartScripts()

		If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\StartCheckList.cld") Then

			LoadStartScripts()

			If CLBStartList.Items.Count > 0 Then
				CLBStartList.SetSelected(0, True)
				StartTab()
			End If

			Dim i, j As Long
			For i = 0 To CLBStartList.Items.Count - 1
				For j = CLBStartList.Items.Count - 1 To (i + 1) Step -1
					If CLBStartList.Items(i) = CLBStartList.Items(j) Then
						CLBStartList.Items.Remove(CLBStartList.Items(j))
					End If
				Next
			Next

		Else
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempFile As String = foundFile
				TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
				CLBStartList.Items.Add(TempFile)
			Next
			For i As Integer = 0 To CLBStartList.Items.Count - 1
				CLBStartList.SetItemChecked(i, True)
			Next
			SaveStartScripts()
			If CLBStartList.Items.Count > 0 Then
				CLBStartList.SetSelected(0, True)
				CLBStartList.SelectedIndex = 0
				StartTab()
			End If
		End If

	End Sub

	Public Sub InitializeModuleScripts()

		If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\ModuleCheckList.cld") Then

			LoadModuleScripts()



			If CLBModuleList.Items.Count > 0 Then

				'If CLBModuleList.Visible = True Then CLBModuleList.SetSelected(0, True)

				ModuleTab()

				Dim i, j As Long
				For i = 0 To CLBModuleList.Items.Count - 1
					For j = CLBModuleList.Items.Count - 1 To (i + 1) Step -1
						If CLBModuleList.Items(i) = CLBModuleList.Items(j) Then
							CLBModuleList.Items.Remove(CLBModuleList.Items(j))
						End If
					Next
				Next

			End If
		Else
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempFile As String = foundFile
				TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
				CLBModuleList.Items.Add(TempFile)
			Next

			For i As Integer = 0 To CLBModuleList.Items.Count - 1
				CLBModuleList.SetItemChecked(i, True)
			Next



			SaveModuleScripts()
			If CLBModuleList.Items.Count > 0 Then
				CLBModuleList.SetSelected(0, True)
				ModuleTab()
			End If
		End If


	End Sub

	Public Sub InitializeLinkScripts()

		If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\LinkCheckList.cld") Then

			LoadLinkScripts()

			If CLBLinkList.Items.Count > 0 Then
				' CLBLinkList.SetSelected(0, True)
				LinkTab()

				Dim i, j As Long
				For i = 0 To CLBLinkList.Items.Count - 1
					For j = CLBLinkList.Items.Count - 1 To (i + 1) Step -1
						If CLBLinkList.Items(i) = CLBLinkList.Items(j) Then
							CLBLinkList.Items.Remove(CLBLinkList.Items(j))
						End If
					Next
				Next

			End If

		Else
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempFile As String = foundFile
				TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
				CLBLinkList.Items.Add(TempFile)
			Next
			For i As Integer = 0 To CLBLinkList.Items.Count - 1
				CLBLinkList.SetItemChecked(i, True)
			Next
			SaveLinkScripts()
			If CLBLinkList.Items.Count > 0 Then
				CLBLinkList.SetSelected(0, True)
				LinkTab()
			End If
		End If

	End Sub

	Public Sub InitializeEndScripts()

		If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\EndCheckList.cld") Then

			LoadEndScripts()

			If CLBEndList.Items.Count > 0 Then
				'CLBEndList.SetSelected(0, True)
				EndTab()

				Dim i, j As Long
				For i = 0 To CLBEndList.Items.Count - 1
					For j = CLBEndList.Items.Count - 1 To (i + 1) Step -1
						If CLBEndList.Items(i) = CLBEndList.Items(j) Then
							CLBEndList.Items.Remove(CLBEndList.Items(j))
						End If
					Next
				Next

			End If
		Else
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				Dim TempFile As String = foundFile
				TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
				CLBEndList.Items.Add(TempFile)
			Next
			For i As Integer = 0 To CLBEndList.Items.Count - 1
				CLBEndList.SetItemChecked(i, True)
			Next
			SaveEndScripts()
			If CLBEndList.Items.Count > 0 Then
				CLBEndList.SetSelected(0, True)
				EndTab()
			End If
		End If

	End Sub


	Public Sub LoadStartScripts()

		CLBStartList.Items.Clear()
		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\StartCheckList.cld", IO.FileMode.Open)
		Dim BinaryReader As New System.IO.BinaryReader(FileStream)
		CLBStartList.BeginUpdate()
		Do While FileStream.Position < FileStream.Length
			CLBStartList.Items.Add(BinaryReader.ReadString)
			CLBStartList.SetItemChecked(CLBStartList.Items.Count - 1, BinaryReader.ReadBoolean)
		Loop
		CLBStartList.EndUpdate()
		BinaryReader.Close()
		FileStream.Dispose()
		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			Dim TempFile As String = foundFile
			TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
			If Not CLBStartList.Items.Contains(TempFile) Then
				Debug.Print("CLBStartList does not contain " & TempFile)
				CLBStartList.Items.Add(TempFile)
			End If
		Next
		For i As Integer = 0 To CLBStartList.Items.Count - 1 Step -1
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\" & CLBStartList.Items(i) & ".txt") Then CLBStartList.Items.Remove(CLBStartList.Items(i))
		Next

	End Sub

	Public Sub LoadModuleScripts()

		CLBModuleList.Items.Clear()
		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\ModuleCheckList.cld", IO.FileMode.Open)
		Dim BinaryReader As New System.IO.BinaryReader(FileStream)
		CLBModuleList.BeginUpdate()
		Do While FileStream.Position < FileStream.Length
			CLBModuleList.Items.Add(BinaryReader.ReadString)
			CLBModuleList.SetItemChecked(CLBModuleList.Items.Count - 1, BinaryReader.ReadBoolean)
		Loop
		CLBModuleList.EndUpdate()
		BinaryReader.Close()
		FileStream.Dispose()
		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			Dim TempFile As String = foundFile
			TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
			Debug.Print("Module Tempfile = " & TempFile)
			If Not CLBModuleList.Items.Contains(TempFile) Then
				Debug.Print("CLBModuleList does not contain " & TempFile)
				CLBModuleList.Items.Add(TempFile)
			End If
		Next
		For i As Integer = 0 To CLBModuleList.Items.Count - 1 Step -1
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\" & CLBModuleList.Items(i) & ".txt") Then CLBModuleList.Items.Remove(CLBModuleList.Items(i))
		Next





	End Sub

	Public Sub LoadLinkScripts()

		CLBLinkList.Items.Clear()
		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\LinkCheckList.cld", IO.FileMode.Open)
		Dim BinaryReader As New System.IO.BinaryReader(FileStream)
		CLBLinkList.BeginUpdate()
		Do While FileStream.Position < FileStream.Length
			CLBLinkList.Items.Add(BinaryReader.ReadString)
			CLBLinkList.SetItemChecked(CLBLinkList.Items.Count - 1, BinaryReader.ReadBoolean)
		Loop
		CLBLinkList.EndUpdate()
		BinaryReader.Close()
		FileStream.Dispose()
		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			Dim TempFile As String = foundFile
			TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
			If Not CLBLinkList.Items.Contains(TempFile) Then
				CLBLinkList.Items.Add(TempFile)
			End If
		Next
		For i As Integer = 0 To CLBLinkList.Items.Count - 1 Step -1
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\" & CLBLinkList.Items(i) & ".txt") Then CLBLinkList.Items.Remove(CLBLinkList.Items(i))
		Next

	End Sub

	Public Sub LoadEndScripts()

		CLBEndList.Items.Clear()
		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\EndCheckList.cld", IO.FileMode.Open)
		Dim BinaryReader As New System.IO.BinaryReader(FileStream)
		CLBEndList.BeginUpdate()
		Do While FileStream.Position < FileStream.Length
			CLBEndList.Items.Add(BinaryReader.ReadString)
			CLBEndList.SetItemChecked(CLBEndList.Items.Count - 1, BinaryReader.ReadBoolean)
		Loop
		CLBEndList.EndUpdate()
		BinaryReader.Close()
		FileStream.Dispose()
		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			Dim TempFile As String = foundFile
			TempFile = Path.GetFileName(TempFile).Replace(".txt", "")
			If Not CLBEndList.Items.Contains(TempFile) Then
				CLBEndList.Items.Add(TempFile)
			End If
		Next
		For i As Integer = 0 To CLBEndList.Items.Count - 1 Step -1
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\" & CLBEndList.Items(i) & ".txt") Then CLBEndList.Items.Remove(CLBEndList.Items(i))
		Next

	End Sub

	Private Sub CLBStartList_LostFocus(sender As Object, e As System.EventArgs) Handles CLBStartList.LostFocus
		SaveStartScripts()
	End Sub

	Private Sub CLBModuleList_LostFocus(sender As Object, e As System.EventArgs) Handles CLBModuleList.LostFocus
		SaveModuleScripts()
	End Sub

	Private Sub CLBLinkList_LostFocus(sender As Object, e As System.EventArgs) Handles CLBLinkList.LostFocus
		SaveLinkScripts()
	End Sub

	Private Sub CLBEndList_LostFocus(sender As Object, e As System.EventArgs) Handles CLBEndList.LostFocus
		SaveEndScripts()
	End Sub

	Private Sub CLBStartList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBStartList.SelectedIndexChanged
		StartTab()
	End Sub

	Private Sub CLBModuleList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBModuleList.SelectedIndexChanged
		ModuleTab()
	End Sub

	Private Sub CLBLinkList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBLinkList.SelectedIndexChanged
		LinkTab()
	End Sub

	Private Sub CLBEndList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBEndList.SelectedIndexChanged
		EndTab()
	End Sub

	Public Sub StartTab()

WhyUMakeMeDoDis:

		For i As Integer = 0 To CLBStartList.Items.Count - 1
			'Debug.Print(Application.StartupPath & "\Scripts\" & Form1.dompersonalityComboBox.Text & "\Stroke\Start\" & CLBStartList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\" & CLBStartList.Items(i) & ".txt") Then
				CLBStartList.Items.Remove(CLBStartList.Items(i))
				GoTo WhyUMakeMeDoDis
				Exit For
			End If
		Next

		ScriptFile = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\" & CLBStartList.Items(CLBStartList.SelectedIndex) & ".txt"
		GetScriptStatus()

	End Sub

	Public Sub ModuleTab()


		If FrmSettingsLoading = True Then Return

WhyUMakeMeDoDis:

		For i As Integer = 0 To CLBModuleList.Items.Count - 1
			' Debug.Print(Application.StartupPath & "\Scripts\" & Form1.dompersonalityComboBox.Text & "\Modules\" & CLBModuleList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\" & CLBModuleList.Items(i) & ".txt") Then
				CLBModuleList.Items.Remove(CLBModuleList.Items(i))
				GoTo WhyUMakeMeDoDis
				Exit For
			End If
		Next



		ScriptFile = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\" & CLBModuleList.Items(CLBModuleList.SelectedIndex) & ".txt"



		GetScriptStatus()




	End Sub

	Public Sub LinkTab()

		If FrmSettingsLoading = True Then Return

WhyUMakeMeDoDis:

		For i As Integer = 0 To CLBLinkList.Items.Count - 1
			' Debug.Print(Application.StartupPath & "\Scripts\" & Form1.dompersonalityComboBox.Text & "\Stroke\Link\" & CLBLinkList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\" & CLBLinkList.Items(i) & ".txt") Then
				CLBLinkList.Items.Remove(CLBLinkList.Items(i))
				GoTo WhyUMakeMeDoDis
				Exit For
			End If
		Next

		ScriptFile = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\" & CLBLinkList.Items(CLBLinkList.SelectedIndex) & ".txt"
		GetScriptStatus()

	End Sub

	Public Sub EndTab()

		If FrmSettingsLoading = True Then Return

WhyUMakeMeDoDis:

		For i As Integer = 0 To CLBEndList.Items.Count - 1
			' Debug.Print(Application.StartupPath & "\Scripts\" & Form1.dompersonalityComboBox.Text & "\Stroke\End\" & CLBEndList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\" & CLBEndList.Items(i) & ".txt") Then
				CLBEndList.Items.Remove(CLBEndList.Items(i))
				GoTo WhyUMakeMeDoDis
				Exit For
			End If
		Next

		ScriptFile = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\" & CLBEndList.Items(CLBEndList.SelectedIndex) & ".txt"
		GetScriptStatus()

	End Sub

	Public Sub GetScriptStatus()

		Dim ScriptReader As New StreamReader(ScriptFile)
		ScriptList.Clear()
		While ScriptReader.Peek <> -1
			ScriptList.Add(ScriptReader.ReadLine())
		End While

		ScriptReader.Close()
		ScriptReader.Dispose()
		RTBScriptDesc.Text = ""
		RTBScriptReq.Text = ""
		Dim ScriptReqFailed As Boolean = False

		For i As Integer = 0 To ScriptList.Count - 1

			If ScriptList(i).Contains("@Info") Then RTBScriptDesc.Text = ScriptList(i).Replace("@Info ", "")

			If ScriptList(i).Contains("@ShowBlogImage") Then
				If Not RTBScriptReq.Text.Contains("* At least one URL File selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one URL File selected *" & Environment.NewLine
				If URLFileList.CheckedItems.Count = 0 Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@NewBlogImage") Then
				If Not RTBScriptReq.Text.Contains("* At least one URL File selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one URL File selected *" & Environment.NewLine
				If URLFileList.CheckedItems.Count = 0 Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowLocalImage") Then
				If Not RTBScriptReq.Text.Contains("* At least one Local Image path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one Local Image path selected with a valid directory *" & Environment.NewLine
				Dim LocalCount As Integer = 0
				If CBIHardcore.Checked = True Then
					If Directory.Exists(LBLIHardcore.Text) Then LocalCount += 1
				End If
				If CBISoftcore.Checked = True Then
					If Directory.Exists(LBLISoftcore.Text) Then LocalCount += 1
				End If
				If CBILesbian.Checked = True Then
					If Directory.Exists(LBLILesbian.Text) Then LocalCount += 1
				End If
				If CBIBlowjob.Checked = True Then
					If Directory.Exists(LBLIBlowjob.Text) Then LocalCount += 1
				End If
				If CBIFemdom.Checked = True Then
					If Directory.Exists(LBLIFemdom.Text) Then LocalCount += 1
				End If
				If CBILezdom.Checked = True Then
					If Directory.Exists(LBLILezdom.Text) Then LocalCount += 1
				End If
				If CBIHentai.Checked = True Then
					If Directory.Exists(LBLIHentai.Text) Then LocalCount += 1
				End If
				If CBIGay.Checked = True Then
					If Directory.Exists(LBLIGay.Text) Then LocalCount += 1
				End If
				If CBIMaledom.Checked = True Then
					If Directory.Exists(LBLIMaledom.Text) Then LocalCount += 1
				End If
				If CBICaptions.Checked = True Then
					If Directory.Exists(LBLICaptions.Text) Then LocalCount += 1
				End If
				If CBIGeneral.Checked = True Then
					If Directory.Exists(LBLIGeneral.Text) Then LocalCount += 1
				End If
				If LocalCount = 0 Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowImage") Then
				If Not RTBScriptReq.Text.Contains("* At least one URL File selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one URL File selected *" & Environment.NewLine
				If Not RTBScriptReq.Text.Contains("* At least one Local Image path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one Local Image path selected with a valid directory *" & Environment.NewLine
				If URLFileList.CheckedItems.Count = 0 Then ScriptReqFailed = True
				Dim LocalCount As Integer = 0
				If CBIHardcore.Checked = True Then
					If Directory.Exists(LBLIHardcore.Text) Then LocalCount += 1
				End If
				If CBISoftcore.Checked = True Then
					If Directory.Exists(LBLISoftcore.Text) Then LocalCount += 1
				End If
				If CBILesbian.Checked = True Then
					If Directory.Exists(LBLILesbian.Text) Then LocalCount += 1
				End If
				If CBIBlowjob.Checked = True Then
					If Directory.Exists(LBLIBlowjob.Text) Then LocalCount += 1
				End If
				If CBIFemdom.Checked = True Then
					If Directory.Exists(LBLIFemdom.Text) Then LocalCount += 1
				End If
				If CBILezdom.Checked = True Then
					If Directory.Exists(LBLILezdom.Text) Then LocalCount += 1
				End If
				If CBIHentai.Checked = True Then
					If Directory.Exists(LBLIHentai.Text) Then LocalCount += 1
				End If
				If CBIGay.Checked = True Then
					If Directory.Exists(LBLIGay.Text) Then LocalCount += 1
				End If
				If CBIMaledom.Checked = True Then
					If Directory.Exists(LBLIMaledom.Text) Then LocalCount += 1
				End If
				If CBICaptions.Checked = True Then
					If Directory.Exists(LBLICaptions.Text) Then LocalCount += 1
				End If
				If CBIGeneral.Checked = True Then
					If Directory.Exists(LBLIGeneral.Text) Then LocalCount += 1
				End If
				If LocalCount = 0 Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@CBTBalls") Then
				If Not RTBScriptReq.Text.Contains("* Ball Torture must be enabled *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Ball Torture must be enabled *" & Environment.NewLine
				If CBCBTBalls.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@CBTCock") Then
				If Not RTBScriptReq.Text.Contains("* Cock Torture must be enabled *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Cock Torture must be enabled *" & Environment.NewLine
				If CBCBTCock.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@CBT") Then
				If Not RTBScriptReq.Text.Contains("* Cock Torture must be enabled *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Cock Torture must be enabled *" & Environment.NewLine
				If Not RTBScriptReq.Text.Contains("* Ball Torture must be enabled *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Ball Torture must be enabled *" & Environment.NewLine
				If CBCBTCock.Checked = False Then ScriptReqFailed = True
				If CBCBTBalls.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@PlayJOIVideo") Then
				If Not RTBScriptReq.Text.Contains("* JOI or JOI Domme Video path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* JOI or JOI Domme Video path selected with a valid directory *" & Environment.NewLine
				If CBVideoJOI.Checked = False And CBVideoJOID.Checked = False Then ScriptReqFailed = True
				If LblVideoJOITotal.Text = "0" And LblVideoJOITotalD.Text = "0" Then ScriptReqFailed = True
				If CBVideoJOI.Checked = True And Not Directory.Exists(LblVideoJOI.Text) Then ScriptReqFailed = True
				If CBVideoJOID.Checked = True And Not Directory.Exists(LblVideoJOID.Text) Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@PlayCHVideo") Then
				If Not RTBScriptReq.Text.Contains("* CH or CH Domme Video path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* CH or CH Domme Video path selected with a valid directory *" & Environment.NewLine
				If CBVideoCH.Checked = False And CBVideoCHD.Checked = False Then ScriptReqFailed = True
				If LblVideoCHTotal.Text = "0" And LblVideoCHTotalD.Text = "0" Then ScriptReqFailed = True
				If CBVideoCH.Checked = True And Not Directory.Exists(LblVideoCH.Text) Then ScriptReqFailed = True
				If CBVideoCHD.Checked = True And Not Directory.Exists(LblVideoCHD.Text) Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@TnAFastSlides") Or ScriptList(i).Contains("@TnASlowSlides") Or ScriptList(i).Contains("@TnASlides") Or ScriptList(i).Contains("@CheckTnA") Then
				If Not RTBScriptReq.Text.Contains("* BnB Games must be enabled in Image Settings *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Games must be enabled in Image Settings *" & Environment.NewLine
				If CBEnableBnB.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowButtImage") Then
				If Not RTBScriptReq.Text.Contains("* BnB Butt path must be set to a valid directory or URL File *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Butt path must be set to a valid directory or URL File *" & Environment.NewLine
				If CBBnBLocal.Checked = True And Not Directory.Exists(LBLButtPath.Text) Then ScriptReqFailed = True
				If CBBnBURL.Checked = True And Not File.Exists(LBLButtURL.Text) Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowBoobsImage") Then
				If Not RTBScriptReq.Text.Contains("* BnB Boobs path must be set to a valid directory or URL File *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Boobs path must be set to a valid directory or URL File *" & Environment.NewLine
				If CBBnBLocal.Checked = True And Not Directory.Exists(LBLBoobPath.Text) Then ScriptReqFailed = True
				If CBBnBURL.Checked = True And Not File.Exists(LBLBoobURL.Text) Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowHardcoreImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Hardcore Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Hardcore Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIHardcore.Text) Or CBIHardcore.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowSoftcoreImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Softcore Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Softcore Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLISoftcore.Text) Or CBISoftcore.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowLesbianImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Lesbian Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Lesbian Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLILesbian.Text) Or CBILesbian.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowBlowjobImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Blowjob Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Blowjob Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIBlowjob.Text) Or CBIBlowjob.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowFemdomImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Femdom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Femdom Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIFemdom.Text) Or CBIFemdom.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowLezdomImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Lezdom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Lezdom Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLILezdom.Text) Or CBILezdom.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowHentaiImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Hentai Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Hentai Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIHentai.Text) Or CBIHentai.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowGayImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Gay Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Gay Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIGay.Text) Or CBIGay.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowMaledomImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Maledom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Maledom Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIMaledom.Text) Or CBIMaledom.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowCaptionsImage") Then
				If Not RTBScriptReq.Text.Contains("* Local Captions Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Captions Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLICaptions.Text) Or CBICaptions.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowGeneralImage") Then
				If Not RTBScriptReq.Text.Contains("* Local General Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local General Image path must be selected and set to a valid directory *" & Environment.NewLine
				If Not Directory.Exists(LBLIGeneral.Text) Or CBIGeneral.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@ShowTaggedImage") And ScriptList(i).Contains("@Tag") Then
				Dim TagDesc As String = "* Images in LocalImageTags.txt tagged with: "

				Dim LocalTagImageList As New List(Of String)
				LocalTagImageList.Clear()

				If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
					Dim LocalReader As New StreamReader(Application.StartupPath & "\Images\System\LocalImageTags.txt")
					While LocalReader.Peek <> -1
						LocalTagImageList.Add(LocalReader.ReadLine())
					End While
					LocalReader.Close()
					LocalReader.Dispose()
					For k As Integer = LocalTagImageList.Count - 1 To 0 Step -1
						If LocalTagImageList(k) = "" Or LocalTagImageList(k) Is Nothing Then LocalTagImageList.RemoveAt(k)
					Next
				End If

				Dim TagCount As Integer = 0

				Dim TSplit As String() = Split(ScriptList(i))
				For j As Integer = 0 To TSplit.Length - 1
					If TSplit(j).Contains("@Tag") Then
						Dim TString As String = TSplit(j).Replace("@Tag", "")
						TagDesc = TagDesc & TSplit(j) & " "
						For k As Integer = LocalTagImageList.Count - 1 To 0 Step -1
							If LocalTagImageList(k).Contains(TString) Then TagCount += 1
						Next
						If TagCount = 0 Then
							ScriptReqFailed = True
						End If
						TagCount = 0
					End If
				Next

				If Not RTBScriptReq.Text.Contains(TagDesc & "*") Then RTBScriptReq.Text = RTBScriptReq.Text & TagDesc & "*" & Environment.NewLine

			End If

			If ScriptList(i).Contains("@ShowTaggedImage") And Not ScriptList(i).Contains("@Tag") Then
				If Not RTBScriptReq.Text.Contains("* LocalImageTags.txt must exist in \Images\System\ *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* LocalImageTags.txt must exist in \Images\System\ *" & Environment.NewLine
				If Not File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@CheckVideo") Then
				If Not RTBScriptReq.Text.Contains("* At least one Genre or Domme Video path set and selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one Genre or Domme Video path set and selected *" & Environment.NewLine
				Form1.VideoCheck = True
				Form1.RandomVideo()
				If Form1.NoVideo = True Then ScriptReqFailed = True
				Form1.VideoCheck = False
				Form1.NoVideo = False
			End If


			If ScriptList(i).Contains("@PlayCensorshipSucks") Or ScriptList(i).Contains("@PlayAvoidTheEdge") Or ScriptList(i).Contains("@PlayRedLightGreenLight") Then
				If Not RTBScriptReq.Text.Contains("* At least one non-Special Genre or Domme Video path set and selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one non-Special Genre or Domme Video path set and selected *" & Environment.NewLine
				Form1.VideoCheck = True
				Form1.NoSpecialVideo = True
				Form1.RandomVideo()
				If Form1.NoVideo = True Then ScriptReqFailed = True
				Form1.VideoCheck = False
				Form1.NoSpecialVideo = False
				Form1.NoVideo = False
			End If

			If ScriptList(i).Contains("@ChastityOn") Or ScriptList(i).Contains("@ChastityOff") Then
				If Not RTBScriptReq.Text.Contains("* You must indicate you own a chastity device *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* You must indicate you own a chastity device *" & Environment.NewLine
				If CBOwnChastity.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@DeleteLocalImage") Then
				If Not RTBScriptReq.Text.Contains("* ""Allow Domme to Delete Local Media"" muct be checked *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* ""Allow Domme to Delete Local Media"" muct be checked *" & Environment.NewLine
				If CBDomDel.Checked = False Then ScriptReqFailed = True
			End If

			If ScriptList(i).Contains("@VitalSubAssignment") Then
				If Not RTBScriptReq.Text.Contains("* VitalSub must be enabled *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* VitalSub must be enabled *" & Environment.NewLine
				If Not RTBScriptReq.Text.Contains("* ""Domme Assignments"" must be checked in the VitalSub app *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* ""Domme Assignments"" must be checked in the VitalSub app *" & Environment.NewLine
				If Form1.CBVitalSub.Checked = False Or Form1.CBVitalSubDomTask.Checked = False Then ScriptReqFailed = True
			End If

		Next

		RTBScriptReq.Text = RTBScriptReq.Text.Replace("**", "* *")

		If ScriptReqFailed = True Then
			LBLScriptReq.ForeColor = Color.Red
			LBLScriptReq.Text = "All requirements not met!"
		Else
			LBLScriptReq.ForeColor = Color.Green
			LBLScriptReq.Text = "All requirements met!"
		End If

	End Sub


	Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
		CLBStartList.SetItemChecked(2, False)
	End Sub

	Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNScriptOpen.Click
		If CLBStartList.Visible = True Then
			Form1.ShellExecute(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\" & CLBStartList.Items(CLBStartList.SelectedIndex) & ".txt")
		End If

		If CLBModuleList.Visible = True Then
			Form1.ShellExecute(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\" & CLBModuleList.Items(CLBModuleList.SelectedIndex) & ".txt")
		End If

		If CLBLinkList.Visible = True Then
			Form1.ShellExecute(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\" & CLBLinkList.Items(CLBLinkList.SelectedIndex) & ".txt")
		End If

		If CLBEndList.Visible = True Then
			Form1.ShellExecute(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\" & CLBEndList.Items(CLBEndList.SelectedIndex) & ".txt")
		End If
	End Sub

	Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles BTNScriptAll.Click
		If CLBStartList.Visible = True Then
			Debug.Print("CLBStartList Select All")
			For i As Integer = 0 To CLBStartList.Items.Count - 1
				CLBStartList.SetItemChecked(i, True)
			Next
			SaveStartScripts()
		End If

		If CLBModuleList.Visible = True Then
			Debug.Print("CLBModuleList Select All")
			For i As Integer = 0 To CLBModuleList.Items.Count - 1
				CLBModuleList.SetItemChecked(i, True)
			Next
			SaveModuleScripts()
		End If

		If CLBLinkList.Visible = True Then
			Debug.Print("CLBLinkList Select All")
			For i As Integer = 0 To CLBLinkList.Items.Count - 1
				CLBLinkList.SetItemChecked(i, True)
			Next
			SaveLinkScripts()
		End If

		If CLBEndList.Visible = True Then
			Debug.Print("CLBEndList Select All")
			For i As Integer = 0 To CLBEndList.Items.Count - 1
				CLBEndList.SetItemChecked(i, True)
			Next
			SaveEndScripts()
		End If

		If TCScripts.SelectedIndex = 0 Then
			CLBStartList.Focus()
		End If

		If TCScripts.SelectedIndex = 1 Then
			CLBModuleList.Focus()
		End If

		If TCScripts.SelectedIndex = 2 Then
			CLBLinkList.Focus()
		End If

		If TCScripts.SelectedIndex = 3 Then
			CLBEndList.Focus()
		End If

	End Sub

	Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles BTNScriptNone.Click
		If CLBStartList.Visible = True Then
			Debug.Print("CLBStartList Select None")
			For i As Integer = 0 To CLBStartList.Items.Count - 1
				CLBStartList.SetItemChecked(i, False)
			Next
			SaveStartScripts()
		End If

		If CLBModuleList.Visible = True Then
			Debug.Print("CLBModuleList Select None")
			For i As Integer = 0 To CLBModuleList.Items.Count - 1
				CLBModuleList.SetItemChecked(i, False)
			Next
			SaveModuleScripts()
		End If

		If CLBLinkList.Visible = True Then
			Debug.Print("CLBLinkList Select None")
			For i As Integer = 0 To CLBLinkList.Items.Count - 1
				CLBLinkList.SetItemChecked(i, False)
			Next
			SaveLinkScripts()
		End If

		If CLBEndList.Visible = True Then
			Debug.Print("CLBEndList Select None")
			For i As Integer = 0 To CLBEndList.Items.Count - 1
				CLBEndList.SetItemChecked(i, False)
			Next
			SaveEndScripts()
		End If

		If TCScripts.SelectedIndex = 0 Then
			CLBStartList.Focus()
		End If

		If TCScripts.SelectedIndex = 1 Then
			CLBModuleList.Focus()
		End If

		If TCScripts.SelectedIndex = 2 Then
			CLBLinkList.Focus()
		End If

		If TCScripts.SelectedIndex = 3 Then
			CLBEndList.Focus()
		End If

	End Sub

	Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles BTNScriptAvailable.Click


		If CLBStartList.Visible = True Then

			For i As Integer = 0 To CLBStartList.Items.Count - 1

				AvailFail = False

				Dim AvailPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\" & CLBStartList.Items(i) & ".txt"
				Dim AvailReader As New StreamReader(AvailPath)
				AvailList.Clear()

				While AvailReader.Peek <> -1
					AvailList.Add(AvailReader.ReadLine())
				End While

				AvailReader.Close()
				AvailReader.Dispose()

				GetAvailFail()

				If AvailFail = True Then
					CLBStartList.SetItemChecked(i, False)
				Else
					CLBStartList.SetItemChecked(i, True)
				End If

			Next

			SaveStartScripts()

		End If


		If CLBModuleList.Visible = True Then

			For i As Integer = 0 To CLBModuleList.Items.Count - 1

				AvailFail = False
				Dim AvailPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\" & CLBModuleList.Items(i) & ".txt"

				Dim AvailReader As New StreamReader(AvailPath)
				AvailList.Clear()

				While AvailReader.Peek <> -1
					AvailList.Add(AvailReader.ReadLine())
				End While

				AvailReader.Close()
				AvailReader.Dispose()

				GetAvailFail()

				If AvailFail = True Then
					CLBModuleList.SetItemChecked(i, False)
				Else
					CLBModuleList.SetItemChecked(i, True)
				End If

			Next

			SaveModuleScripts()

		End If

		If CLBLinkList.Visible = True Then

			For i As Integer = 0 To CLBLinkList.Items.Count - 1

				AvailFail = False

				Dim AvailPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\" & CLBLinkList.Items(i) & ".txt"
				Dim AvailReader As New StreamReader(AvailPath)
				AvailList.Clear()

				While AvailReader.Peek <> -1
					AvailList.Add(AvailReader.ReadLine())
				End While

				AvailReader.Close()
				AvailReader.Dispose()

				GetAvailFail()

				If AvailFail = True Then
					CLBLinkList.SetItemChecked(i, False)
				Else
					CLBLinkList.SetItemChecked(i, True)
				End If

			Next

			SaveLinkScripts()

		End If

		If CLBEndList.Visible = True Then

			For i As Integer = 0 To CLBEndList.Items.Count - 1

				AvailFail = False

				Dim AvailPath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\" & CLBEndList.Items(i) & ".txt"
				Dim AvailReader As New StreamReader(AvailPath)
				AvailList.Clear()

				While AvailReader.Peek <> -1
					AvailList.Add(AvailReader.ReadLine())
				End While

				AvailReader.Close()
				AvailReader.Dispose()

				GetAvailFail()

				If AvailFail = True Then
					CLBEndList.SetItemChecked(i, False)
				Else
					CLBEndList.SetItemChecked(i, True)
				End If

			Next

			SaveEndScripts()

		End If

		If TCScripts.SelectedIndex = 0 Then
			CLBStartList.Focus()
		End If

		If TCScripts.SelectedIndex = 1 Then
			CLBModuleList.Focus()
		End If

		If TCScripts.SelectedIndex = 2 Then
			CLBLinkList.Focus()
		End If

		If TCScripts.SelectedIndex = 3 Then
			CLBEndList.Focus()
		End If



	End Sub

	Public Sub GetAvailFail()

		For j As Integer = 0 To AvailList.Count - 1
			If AvailList(j).Contains("@ShowBlogImage") Then
				If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
			End If
			If AvailList(j).Contains("@NewBlogImage") Then
				If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
			End If
			If AvailList(j).Contains("@ShowLocalImage") Then
				Dim LocalCount As Integer = 0
				If CBIHardcore.Checked = True Then
					If Directory.Exists(LBLIHardcore.Text) Then LocalCount += 1
				End If
				If CBISoftcore.Checked = True Then
					If Directory.Exists(LBLISoftcore.Text) Then LocalCount += 1
				End If
				If CBILesbian.Checked = True Then
					If Directory.Exists(LBLILesbian.Text) Then LocalCount += 1
				End If
				If CBIBlowjob.Checked = True Then
					If Directory.Exists(LBLIBlowjob.Text) Then LocalCount += 1
				End If
				If CBIFemdom.Checked = True Then
					If Directory.Exists(LBLIFemdom.Text) Then LocalCount += 1
				End If
				If CBILezdom.Checked = True Then
					If Directory.Exists(LBLILezdom.Text) Then LocalCount += 1
				End If
				If CBIHentai.Checked = True Then
					If Directory.Exists(LBLIHentai.Text) Then LocalCount += 1
				End If
				If CBIGay.Checked = True Then
					If Directory.Exists(LBLIGay.Text) Then LocalCount += 1
				End If
				If CBIMaledom.Checked = True Then
					If Directory.Exists(LBLIMaledom.Text) Then LocalCount += 1
				End If
				If CBICaptions.Checked = True Then
					If Directory.Exists(LBLICaptions.Text) Then LocalCount += 1
				End If
				If CBIGeneral.Checked = True Then
					If Directory.Exists(LBLIGeneral.Text) Then LocalCount += 1
				End If
				If LocalCount = 0 Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowImage") Then
				If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
				Dim LocalCount As Integer = 0
				If CBIHardcore.Checked = True Then
					If Directory.Exists(LBLIHardcore.Text) Then LocalCount += 1
				End If
				If CBISoftcore.Checked = True Then
					If Directory.Exists(LBLISoftcore.Text) Then LocalCount += 1
				End If
				If CBILesbian.Checked = True Then
					If Directory.Exists(LBLILesbian.Text) Then LocalCount += 1
				End If
				If CBIBlowjob.Checked = True Then
					If Directory.Exists(LBLIBlowjob.Text) Then LocalCount += 1
				End If
				If CBIFemdom.Checked = True Then
					If Directory.Exists(LBLIFemdom.Text) Then LocalCount += 1
				End If
				If CBILezdom.Checked = True Then
					If Directory.Exists(LBLILezdom.Text) Then LocalCount += 1
				End If
				If CBIHentai.Checked = True Then
					If Directory.Exists(LBLIHentai.Text) Then LocalCount += 1
				End If
				If CBIGay.Checked = True Then
					If Directory.Exists(LBLIGay.Text) Then LocalCount += 1
				End If
				If CBIMaledom.Checked = True Then
					If Directory.Exists(LBLIMaledom.Text) Then LocalCount += 1
				End If
				If CBICaptions.Checked = True Then
					If Directory.Exists(LBLICaptions.Text) Then LocalCount += 1
				End If
				If CBIGeneral.Checked = True Then
					If Directory.Exists(LBLIGeneral.Text) Then LocalCount += 1
				End If
				If LocalCount = 0 Then AvailFail = True
			End If

			If AvailList(j).Contains("@CBTBalls") Then
				If CBCBTBalls.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@CBTCock") Then
				If CBCBTCock.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@CBT") Then
				If CBCBTCock.Checked = False Then AvailFail = True
				If CBCBTBalls.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@PlayJOIVideo") Then
				If CBVideoJOI.Checked = False And CBVideoJOID.Checked = False Then AvailFail = True
				If LblVideoJOITotal.Text = "0" And LblVideoJOITotalD.Text = "0" Then AvailFail = True
				If CBVideoJOI.Checked = True And Not Directory.Exists(LblVideoJOI.Text) Then AvailFail = True
				If CBVideoJOID.Checked = True And Not Directory.Exists(LblVideoJOID.Text) Then AvailFail = True
			End If

			If AvailList(j).Contains("@PlayCHVideo") Then
				If CBVideoCH.Checked = False And CBVideoCHD.Checked = False Then AvailFail = True
				If LblVideoCHTotal.Text = "0" And LblVideoCHTotalD.Text = "0" Then AvailFail = True
				If CBVideoCH.Checked = True And Not Directory.Exists(LblVideoCH.Text) Then AvailFail = True
				If CBVideoCHD.Checked = True And Not Directory.Exists(LblVideoCHD.Text) Then AvailFail = True
			End If

			If AvailList(j).Contains("@TnAFastSlides") Or AvailList(j).Contains("@TnASlowSlides") Or AvailList(j).Contains("@TnASlides") Or AvailList(j).Contains("@CheckTnA") Then
				If CBEnableBnB.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowButtImage") Then
				If CBBnBLocal.Checked = True And Not Directory.Exists(LBLButtPath.Text) Then AvailFail = True
				If CBBnBURL.Checked = True And Not File.Exists(LBLButtURL.Text) Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowBoobsImage") Then
				If CBBnBLocal.Checked = True And Not Directory.Exists(LBLBoobPath.Text) Then AvailFail = True
				If CBBnBURL.Checked = True And Not File.Exists(LBLBoobURL.Text) Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowHardcoreImage") Then
				If Not Directory.Exists(LBLIHardcore.Text) Or CBIHardcore.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowSoftcoreImage") Then
				If Not Directory.Exists(LBLISoftcore.Text) Or CBISoftcore.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowLesbianImage") Then
				If Not Directory.Exists(LBLILesbian.Text) Or CBILesbian.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowBlowjobImage") Then
				If Not Directory.Exists(LBLIBlowjob.Text) Or CBIBlowjob.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowFemdomImage") Then
				If Not Directory.Exists(LBLIFemdom.Text) Or CBIFemdom.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowLezdomImage") Then
				If Not Directory.Exists(LBLILezdom.Text) Or CBILezdom.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowHentaiImage") Then
				If Not Directory.Exists(LBLIHentai.Text) Or CBIHentai.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowGayImage") Then
				If Not Directory.Exists(LBLIGay.Text) Or CBIGay.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowMaledomImage") Then
				If Not Directory.Exists(LBLIMaledom.Text) Or CBIMaledom.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowCaptionsImage") Then
				If Not Directory.Exists(LBLICaptions.Text) Or CBICaptions.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@ShowGeneralImage") Then
				If Not Directory.Exists(LBLIGeneral.Text) Or CBIGeneral.Checked = False Then AvailFail = True
			End If



			If AvailList(j).Contains("@ShowTaggedImage") And AvailList(j).Contains("@Tag") Then

				Dim LocalTagImageList As New List(Of String)
				LocalTagImageList.Clear()

				If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
					Dim LocalReader As New StreamReader(Application.StartupPath & "\Images\System\LocalImageTags.txt")
					While LocalReader.Peek <> -1
						LocalTagImageList.Add(LocalReader.ReadLine())
					End While
					LocalReader.Close()
					LocalReader.Dispose()
					For k As Integer = LocalTagImageList.Count - 1 To 0 Step -1
						If LocalTagImageList(k) = "" Or LocalTagImageList(k) Is Nothing Then LocalTagImageList.RemoveAt(k)
					Next
				End If

				Dim TagCount As Integer = 0

				Dim TSplit As String() = Split(AvailList(j))
				For m As Integer = 0 To TSplit.Length - 1
					If TSplit(m).Contains("@Tag") Then
						Dim TString As String = TSplit(m).Replace("@Tag", "")
						For k As Integer = LocalTagImageList.Count - 1 To 0 Step -1
							If LocalTagImageList(k).Contains(TString) Then TagCount += 1
						Next
						If TagCount = 0 Then
							AvailFail = True
						End If
						TagCount = 0
					End If
				Next
			End If



			If AvailList(j).Contains("@ShowTaggedImage") And Not AvailList(j).Contains("@Tag") Then
				If Not File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then AvailFail = True
			End If

			If AvailList(j).Contains("@CheckVideo") Then
				Form1.VideoCheck = True
				Form1.RandomVideo()
				If Form1.NoVideo = True Then AvailFail = True
				Form1.VideoCheck = False
				Form1.NoVideo = False
			End If

			If AvailList(j).Contains("@PlayCensorshipSucks") Or AvailList(j).Contains("@PlayAvoidTheEdge") Or AvailList(j).Contains("@PlayRedLightGreenLight") Then
				Form1.VideoCheck = True
				Form1.NoSpecialVideo = True
				Form1.RandomVideo()
				If Form1.NoVideo = True Then AvailFail = True
				Form1.VideoCheck = False
				Form1.NoSpecialVideo = False
				Form1.NoVideo = False
			End If

			If AvailList(j).Contains("@ChastityOn") Or AvailList(j).Contains("@ChastityOff") Then
				If CBOwnChastity.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@DeleteLocalImage") Then
				If CBDomDel.Checked = False Then AvailFail = True
			End If

			If AvailList(j).Contains("@VitalSubAssignment") Then
				If Form1.CBVitalSub.Checked = False Or Form1.CBVitalSubDomTask.Checked = False Then AvailFail = True
			End If

		Next


	End Sub

	Private Sub Button4_Click_2(sender As System.Object, e As System.EventArgs)
		For i As Integer = 0 To CLBStartList.Items.Count - 1
			' Debug.Print("CLBStartList.GetItemChecked(i) = " & CLBStartList.GetItemChecked(i))
		Next
	End Sub

	Private Sub CBCBTCock_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCBTCock.LostFocus
		If CBCBTCock.Checked = True Then
			My.Settings.CBTCock = True
		Else
			My.Settings.CBTCock = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub CBCBTBalls_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCBTBalls.LostFocus
		If CBCBTBalls.Checked = True Then
			My.Settings.CBTBalls = True
		Else
			My.Settings.CBTBalls = False
		End If
		My.Settings.Save()
	End Sub

	Private Sub TabPage9_Click(sender As System.Object, e As System.EventArgs) Handles TabPage9.Click

	End Sub

	Private Sub Button9_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNLocalTagDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then


			' BTNTagSave.Text = "Save and Display Next Image"

			LocalImageTagDir.Clear()

			Dim TagLocalImageFolder As String = FolderBrowserDialog1.SelectedPath

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			files = Directory.GetFiles(TagLocalImageFolder, "*.*")

			Array.Sort(files)

			For Each fi As String In files
				If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
					LocalImageTagDir.Add(fi)
				End If
			Next

			If LocalImageTagDir.Count < 1 Then
				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return
			End If

			Form1.mainPictureBox.Image = Image.FromFile(LocalImageTagDir(0))


			CurrentLocalImageTagImage = LocalImageTagDir(0)


			CheckLocalTagList()



			Form1.LocalTagCount = 1
			LBLLocalTagCount.Text = Form1.LocalTagCount & "/" & LocalImageTagDir.Count


			LocalImageTagCount = 0

			BTNLocalTagSave.Enabled = True
			BTNLocalTagNext.Enabled = True
			BTNLocalTagPrevious.Enabled = False
			BTNLocalTagDir.Enabled = False
			TBLocalTagDir.Enabled = False

			EnableLocalTagList()

			LBLLocalTagCount.Enabled = True

		End If



	End Sub

	Private Sub BTNLocalTagNext_Click(sender As System.Object, e As System.EventArgs) Handles BTNLocalTagNext.Click

		Form1.LocalTagCount += 1
		LBLLocalTagCount.Text = Form1.LocalTagCount & "/" & LocalImageTagDir.Count
		BTNLocalTagPrevious.Enabled = True

		SetLocalImageTags()

		LocalImageTagCount += 1
		Form1.mainPictureBox.Image = Image.FromFile(LocalImageTagDir(LocalImageTagCount))
		CurrentLocalImageTagImage = LocalImageTagDir(LocalImageTagCount)

		If LocalImageTagCount = LocalImageTagDir.Count - 1 Then BTNLocalTagNext.Enabled = False

		CheckLocalTagList()

	End Sub

	Public Sub ClearLocalTagList()

		CBTagHardcore.Checked = False
		CBTagLesbian.Checked = False
		CBTagGay.Checked = False
		CBTagBisexual.Checked = False
		CBTagSoloF.Checked = False
		CBTagSoloM.Checked = False
		CBTagSoloFuta.Checked = False
		CBTagPOV.Checked = False
		CBTagBondage.Checked = False
		CBTagSM.Checked = False
		CBTagTD.Checked = False
		CBTagChastity.Checked = False
		CBTagCFNM.Checked = False
		CBTagBath.Checked = False
		CBTagShower.Checked = False
		CBTagOutdoors.Checked = False
		CBTagArtwork.Checked = False

		CBTagMasturbation.Checked = False
		CBTagHandjob.Checked = False
		CBTagFingering.Checked = False
		CBTagBlowjob.Checked = False
		CBTagCunnilingus.Checked = False
		CBTagTitjob.Checked = False
		CBTagFootjob.Checked = False
		CBTagFacesitting.Checked = False
		CBTagRimming.Checked = False
		CBTagMissionary.Checked = False
		CBTagDoggyStyle.Checked = False
		CBTagCowgirl.Checked = False
		CBTagRCowgirl.Checked = False
		CBTagStanding.Checked = False
		CBTagAnalSex.Checked = False
		CBTagDP.Checked = False
		CBTagGangbang.Checked = False

		CBTag1F.Checked = False
		CBTag2F.Checked = False
		CBTag3F.Checked = False
		CBTag1M.Checked = False
		CBTag2M.Checked = False
		CBTag3M.Checked = False
		CBTag1Futa.Checked = False
		CBTag2Futa.Checked = False
		CBTag3Futa.Checked = False
		CBTagFemdom.Checked = False
		CBTagMaledom.Checked = False
		CBTagFutadom.Checked = False
		CBTagFemsub.Checked = False
		CBTagMalesub.Checked = False
		CBTagFutasub.Checked = False
		CBTagMultiDom.Checked = False
		CBTagMultiSub.Checked = False

		CBTagBodyFace.Checked = False
		CBTagBodyFingers.Checked = False
		CBTagBodyMouth.Checked = False
		CBTagBodyTits.Checked = False
		CBTagBodyNipples.Checked = False
		CBTagBodyPussy.Checked = False
		CBTagBodyAss.Checked = False
		CBTagBodyLegs.Checked = False
		CBTagBodyFeet.Checked = False
		CBTagBodyCock.Checked = False
		CBTagBodyBalls.Checked = False

		CBTagNurse.Checked = False
		CBTagTeacher.Checked = False
		CBTagSchoolgirl.Checked = False
		CBTagMaid.Checked = False
		CBTagSuperhero.Checked = False

		CBTagWhipping.Checked = False
		CBTagSpanking.Checked = False
		CBTagCockTorture.Checked = False
		CBTagBallTorture.Checked = False
		CBTagStrapon.Checked = False
		CBTagBlindfold.Checked = False
		CBTagGag.Checked = False
		CBTagClamps.Checked = False
		CBTagHotWax.Checked = False
		CBTagNeedles.Checked = False
		CBTagElectro.Checked = False

		CBTagDomme.Checked = False
		CBTagCumshot.Checked = False
		CBTagCumEating.Checked = False
		CBTagKissing.Checked = False
		CBTagTattoos.Checked = False
		CBTagStockings.Checked = False
		CBTagVibrator.Checked = False
		CBTagDildo.Checked = False
		CBTagPocketPussy.Checked = False
		CBTagAnalToy.Checked = False
		CBTagWatersports.Checked = False

		CBTagShibari.Checked = False
		CBTagTentacles.Checked = False
		CBTagBukkake.Checked = False
		CBTagBakunyuu.Checked = False
		CBTagAhegao.Checked = False
		CBTagBodyWriting.Checked = False
		CBTagTrap.Checked = False
		CBTagGanguro.Checked = False
		CBTagMahouShoujo.Checked = False
		CBTagMonsterGirl.Checked = False

	End Sub

	Public Sub CheckLocalTagList()

		If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
			Dim TagReader As New StreamReader(Application.StartupPath & "\Images\System\LocalImageTags.txt")
			Dim TagCheckList As New List(Of String)
			While TagReader.Peek <> -1
				TagCheckList.Add(TagReader.ReadLine())
			End While

			TagReader.Close()
			TagReader.Dispose()

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(CurrentLocalImageTagImage) Then

					ClearLocalTagList()

					If TagCheckList(i).Contains("TagHardcore") Then CBTagHardcore.Checked = True
					If TagCheckList(i).Contains("TagLesbian") Then CBTagLesbian.Checked = True
					If TagCheckList(i).Contains("TagGay") Then CBTagGay.Checked = True
					If TagCheckList(i).Contains("TagBisexual") Then CBTagBisexual.Checked = True
					If TagCheckList(i).Contains("TagSoloF") Then CBTagSoloF.Checked = True
					If TagCheckList(i).Contains("TagSoloM") Then CBTagSoloM.Checked = True
					If TagCheckList(i).Contains("TagSoloFuta") Then CBTagSoloFuta.Checked = True
					If TagCheckList(i).Contains("TagPOV") Then CBTagPOV.Checked = True
					If TagCheckList(i).Contains("TagBondage") Then CBTagBondage.Checked = True
					If TagCheckList(i).Contains("TagSM") Then CBTagSM.Checked = True
					If TagCheckList(i).Contains("TagTD") Then CBTagTD.Checked = True
					If TagCheckList(i).Contains("TagChastity") Then CBTagChastity.Checked = True
					If TagCheckList(i).Contains("TagCFNM") Then CBTagCFNM.Checked = True
					If TagCheckList(i).Contains("TagBath") Then CBTagBath.Checked = True
					If TagCheckList(i).Contains("TagShower") Then CBTagShower.Checked = True
					If TagCheckList(i).Contains("TagOutdoors") Then CBTagOutdoors.Checked = True
					If TagCheckList(i).Contains("TagArtwork") Then CBTagArtwork.Checked = True

					If TagCheckList(i).Contains("TagMasturbation") Then CBTagMasturbation.Checked = True
					If TagCheckList(i).Contains("TagHandjob") Then CBTagHandjob.Checked = True
					If TagCheckList(i).Contains("TagFingering") Then CBTagFingering.Checked = True
					If TagCheckList(i).Contains("TagBlowjob") Then CBTagBlowjob.Checked = True
					If TagCheckList(i).Contains("TagCunnilingus") Then CBTagCunnilingus.Checked = True
					If TagCheckList(i).Contains("TagTitjob") Then CBTagTitjob.Checked = True
					If TagCheckList(i).Contains("TagFootjob") Then CBTagFootjob.Checked = True
					If TagCheckList(i).Contains("TagFacesitting") Then CBTagFacesitting.Checked = True
					If TagCheckList(i).Contains("TagRimming") Then CBTagRimming.Checked = True
					If TagCheckList(i).Contains("TagMissionary") Then CBTagMissionary.Checked = True
					If TagCheckList(i).Contains("TagDoggyStyle") Then CBTagDoggyStyle.Checked = True
					If TagCheckList(i).Contains("TagCowgirl") Then CBTagCowgirl.Checked = True
					If TagCheckList(i).Contains("TagRCowgirl") Then CBTagRCowgirl.Checked = True
					If TagCheckList(i).Contains("TagStanding") Then CBTagStanding.Checked = True
					If TagCheckList(i).Contains("TagAnalSex") Then CBTagAnalSex.Checked = True
					If TagCheckList(i).Contains("TagDP") Then CBTagDP.Checked = True
					If TagCheckList(i).Contains("TagGangbang") Then CBTagGangbang.Checked = True

					If TagCheckList(i).Contains("Tag1F") Then CBTag1F.Checked = True
					If TagCheckList(i).Contains("Tag2F") Then CBTag2F.Checked = True
					If TagCheckList(i).Contains("Tag3F") Then CBTag3F.Checked = True
					If TagCheckList(i).Contains("Tag1M") Then CBTag1M.Checked = True
					If TagCheckList(i).Contains("Tag2M") Then CBTag2M.Checked = True
					If TagCheckList(i).Contains("Tag3M") Then CBTag3M.Checked = True
					If TagCheckList(i).Contains("Tag1Futa") Then CBTag1Futa.Checked = True
					If TagCheckList(i).Contains("Tag2Futa") Then CBTag2Futa.Checked = True
					If TagCheckList(i).Contains("Tag3Futa") Then CBTag3Futa.Checked = True
					If TagCheckList(i).Contains("TagFemdom") Then CBTagFemdom.Checked = True
					If TagCheckList(i).Contains("TagMaledom") Then CBTagMaledom.Checked = True
					If TagCheckList(i).Contains("TagFutadom") Then CBTagFutadom.Checked = True
					If TagCheckList(i).Contains("TagFemsub") Then CBTagFemsub.Checked = True
					If TagCheckList(i).Contains("TagMalesub") Then CBTagMalesub.Checked = True
					If TagCheckList(i).Contains("TagFutasub") Then CBTagFutasub.Checked = True
					If TagCheckList(i).Contains("TagMultiDom") Then CBTagMultiDom.Checked = True
					If TagCheckList(i).Contains("TagMultiSub") Then CBTagMultiSub.Checked = True

					If TagCheckList(i).Contains("TagBodyFace") Then CBTagBodyFace.Checked = True
					If TagCheckList(i).Contains("TagBodyFingers") Then CBTagBodyFingers.Checked = True
					If TagCheckList(i).Contains("TagBodyMouth") Then CBTagBodyMouth.Checked = True
					If TagCheckList(i).Contains("TagBodyTits") Then CBTagBodyTits.Checked = True
					If TagCheckList(i).Contains("TagBodyNipples") Then CBTagBodyNipples.Checked = True
					If TagCheckList(i).Contains("TagBodyPussy") Then CBTagBodyPussy.Checked = True
					If TagCheckList(i).Contains("TagBodyAss") Then CBTagBodyAss.Checked = True
					If TagCheckList(i).Contains("TagBodyLegs") Then CBTagBodyLegs.Checked = True
					If TagCheckList(i).Contains("TagBodyFeet") Then CBTagBodyFeet.Checked = True
					If TagCheckList(i).Contains("TagBodyCock") Then CBTagBodyCock.Checked = True
					If TagCheckList(i).Contains("TagBodyBalls") Then CBTagBodyBalls.Checked = True

					If TagCheckList(i).Contains("TagNurse") Then CBTagNurse.Checked = True
					If TagCheckList(i).Contains("TagTeacher") Then CBTagTeacher.Checked = True
					If TagCheckList(i).Contains("TagSchoolgirl") Then CBTagSchoolgirl.Checked = True
					If TagCheckList(i).Contains("TagMaid") Then CBTagMaid.Checked = True
					If TagCheckList(i).Contains("TagSuperhero") Then CBTagSuperhero.Checked = True

					If TagCheckList(i).Contains("TagWhipping") Then CBTagWhipping.Checked = True
					If TagCheckList(i).Contains("TagSpanking") Then CBTagSpanking.Checked = True
					If TagCheckList(i).Contains("TagCockTorture") Then CBTagCockTorture.Checked = True
					If TagCheckList(i).Contains("TagBallTorture") Then CBTagBallTorture.Checked = True
					If TagCheckList(i).Contains("TagStrapon") Then CBTagStrapon.Checked = True
					If TagCheckList(i).Contains("TagBlindfold") Then CBTagBlindfold.Checked = True
					If TagCheckList(i).Contains("TagGag") Then CBTagGag.Checked = True
					If TagCheckList(i).Contains("TagClamps") Then CBTagClamps.Checked = True
					If TagCheckList(i).Contains("TagHotWax") Then CBTagHotWax.Checked = True
					If TagCheckList(i).Contains("TagNeedles") Then CBTagNeedles.Checked = True
					If TagCheckList(i).Contains("TagElectro") Then CBTagElectro.Checked = True

					If TagCheckList(i).Contains("TagDomme") Then CBTagDomme.Checked = True
					If TagCheckList(i).Contains("TagCumshot") Then CBTagCumshot.Checked = True
					If TagCheckList(i).Contains("TagCumEating") Then CBTagCumEating.Checked = True
					If TagCheckList(i).Contains("TagKissing") Then CBTagKissing.Checked = True
					If TagCheckList(i).Contains("TagTattoos") Then CBTagTattoos.Checked = True
					If TagCheckList(i).Contains("TagStockings") Then CBTagStockings.Checked = True
					If TagCheckList(i).Contains("TagVibrator") Then CBTagVibrator.Checked = True
					If TagCheckList(i).Contains("TagDildo") Then CBTagDildo.Checked = True
					If TagCheckList(i).Contains("TagPocketPussy") Then CBTagPocketPussy.Checked = True
					If TagCheckList(i).Contains("TagAnalToy") Then CBTagAnalToy.Checked = True
					If TagCheckList(i).Contains("TagWaterSports") Then CBTagWatersports.Checked = True

					If TagCheckList(i).Contains("TagShibari") Then CBTagShibari.Checked = True
					If TagCheckList(i).Contains("TagTentacles") Then CBTagTentacles.Checked = True
					If TagCheckList(i).Contains("TagBukkake") Then CBTagBukkake.Checked = True
					If TagCheckList(i).Contains("TagBakunyuu") Then CBTagBakunyuu.Checked = True
					If TagCheckList(i).Contains("TagAhegao") Then CBTagAhegao.Checked = True
					If TagCheckList(i).Contains("TagBodyWriting") Then CBTagBodyWriting.Checked = True
					If TagCheckList(i).Contains("TagTrap") Then CBTagTrap.Checked = True
					If TagCheckList(i).Contains("TagGanguro") Then CBTagGanguro.Checked = True
					If TagCheckList(i).Contains("TagMahouShoujo") Then CBTagMahouShoujo.Checked = True
					If TagCheckList(i).Contains("TagMonsterGirl") Then CBTagMonsterGirl.Checked = True

				End If
			Next

		End If

	End Sub

	Public Sub EnableLocalTagList()


		CBTagHardcore.Enabled = True
		CBTagLesbian.Enabled = True
		CBTagGay.Enabled = True
		CBTagBisexual.Enabled = True
		CBTagSoloF.Enabled = True
		CBTagSoloM.Enabled = True
		CBTagSoloFuta.Enabled = True
		CBTagPOV.Enabled = True
		CBTagBondage.Enabled = True
		CBTagSM.Enabled = True
		CBTagTD.Enabled = True
		CBTagChastity.Enabled = True
		CBTagCFNM.Enabled = True
		CBTagBath.Enabled = True
		CBTagShower.Enabled = True
		CBTagOutdoors.Enabled = True
		CBTagArtwork.Enabled = True

		CBTagMasturbation.Enabled = True
		CBTagHandjob.Enabled = True
		CBTagFingering.Enabled = True
		CBTagBlowjob.Enabled = True
		CBTagCunnilingus.Enabled = True
		CBTagTitjob.Enabled = True
		CBTagFootjob.Enabled = True
		CBTagFacesitting.Enabled = True
		CBTagRimming.Enabled = True
		CBTagMissionary.Enabled = True
		CBTagDoggyStyle.Enabled = True
		CBTagCowgirl.Enabled = True
		CBTagRCowgirl.Enabled = True
		CBTagStanding.Enabled = True
		CBTagAnalSex.Enabled = True
		CBTagDP.Enabled = True
		CBTagGangbang.Enabled = True

		CBTag1F.Enabled = True
		CBTag2F.Enabled = True
		CBTag3F.Enabled = True
		CBTag1M.Enabled = True
		CBTag2M.Enabled = True
		CBTag3M.Enabled = True
		CBTag1Futa.Enabled = True
		CBTag2Futa.Enabled = True
		CBTag3Futa.Enabled = True
		CBTagFemdom.Enabled = True
		CBTagMaledom.Enabled = True
		CBTagFutadom.Enabled = True
		CBTagFemsub.Enabled = True
		CBTagMalesub.Enabled = True
		CBTagFutasub.Enabled = True
		CBTagMultiDom.Enabled = True
		CBTagMultiSub.Enabled = True

		CBTagBodyFace.Enabled = True
		CBTagBodyFingers.Enabled = True
		CBTagBodyMouth.Enabled = True
		CBTagBodyTits.Enabled = True
		CBTagBodyNipples.Enabled = True
		CBTagBodyPussy.Enabled = True
		CBTagBodyAss.Enabled = True
		CBTagBodyLegs.Enabled = True
		CBTagBodyFeet.Enabled = True
		CBTagBodyCock.Enabled = True
		CBTagBodyBalls.Enabled = True

		CBTagNurse.Enabled = True
		CBTagTeacher.Enabled = True
		CBTagSchoolgirl.Enabled = True
		CBTagMaid.Enabled = True
		CBTagSuperhero.Enabled = True

		CBTagWhipping.Enabled = True
		CBTagSpanking.Enabled = True
		CBTagCockTorture.Enabled = True
		CBTagBallTorture.Enabled = True
		CBTagStrapon.Enabled = True
		CBTagBlindfold.Enabled = True
		CBTagGag.Enabled = True
		CBTagClamps.Enabled = True
		CBTagHotWax.Enabled = True
		CBTagNeedles.Enabled = True
		CBTagElectro.Enabled = True

		CBTagDomme.Enabled = True
		CBTagCumshot.Enabled = True
		CBTagCumEating.Enabled = True
		CBTagKissing.Enabled = True
		CBTagTattoos.Enabled = True
		CBTagStockings.Enabled = True
		CBTagVibrator.Enabled = True
		CBTagDildo.Enabled = True
		CBTagPocketPussy.Enabled = True
		CBTagAnalToy.Enabled = True
		CBTagWatersports.Enabled = True

		CBTagShibari.Enabled = True
		CBTagTentacles.Enabled = True
		CBTagBukkake.Enabled = True
		CBTagBakunyuu.Enabled = True
		CBTagAhegao.Enabled = True
		CBTagBodyWriting.Enabled = True
		CBTagTrap.Enabled = True
		CBTagGanguro.Enabled = True
		CBTagMahouShoujo.Enabled = True
		CBTagMonsterGirl.Enabled = True


	End Sub

	Public Sub DisableLocalTagList()


		CBTagHardcore.Enabled = False
		CBTagLesbian.Enabled = False
		CBTagGay.Enabled = False
		CBTagBisexual.Enabled = False
		CBTagSoloF.Enabled = False
		CBTagSoloM.Enabled = False
		CBTagSoloFuta.Enabled = False
		CBTagPOV.Enabled = False
		CBTagBondage.Enabled = False
		CBTagSM.Enabled = False
		CBTagTD.Enabled = False
		CBTagChastity.Enabled = False
		CBTagCFNM.Enabled = False
		CBTagBath.Enabled = False
		CBTagShower.Enabled = False
		CBTagOutdoors.Enabled = False
		CBTagArtwork.Enabled = False

		CBTagMasturbation.Enabled = False
		CBTagHandjob.Enabled = False
		CBTagFingering.Enabled = False
		CBTagBlowjob.Enabled = False
		CBTagCunnilingus.Enabled = False
		CBTagTitjob.Enabled = False
		CBTagFootjob.Enabled = False
		CBTagFacesitting.Enabled = False
		CBTagRimming.Enabled = False
		CBTagMissionary.Enabled = False
		CBTagDoggyStyle.Enabled = False
		CBTagCowgirl.Enabled = False
		CBTagRCowgirl.Enabled = False
		CBTagStanding.Enabled = False
		CBTagAnalSex.Enabled = False
		CBTagDP.Enabled = False
		CBTagGangbang.Enabled = False

		CBTag1F.Enabled = False
		CBTag2F.Enabled = False
		CBTag3F.Enabled = False
		CBTag1M.Enabled = False
		CBTag2M.Enabled = False
		CBTag3M.Enabled = False
		CBTag1Futa.Enabled = False
		CBTag2Futa.Enabled = False
		CBTag3Futa.Enabled = False
		CBTagFemdom.Enabled = False
		CBTagMaledom.Enabled = False
		CBTagFutadom.Enabled = False
		CBTagFemsub.Enabled = False
		CBTagMalesub.Enabled = False
		CBTagFutasub.Enabled = False
		CBTagMultiDom.Enabled = False
		CBTagMultiSub.Enabled = False

		CBTagBodyFace.Enabled = False
		CBTagBodyFingers.Enabled = False
		CBTagBodyMouth.Enabled = False
		CBTagBodyTits.Enabled = False
		CBTagBodyNipples.Enabled = False
		CBTagBodyPussy.Enabled = False
		CBTagBodyAss.Enabled = False
		CBTagBodyLegs.Enabled = False
		CBTagBodyFeet.Enabled = False
		CBTagBodyCock.Enabled = False
		CBTagBodyBalls.Enabled = False

		CBTagNurse.Enabled = False
		CBTagTeacher.Enabled = False
		CBTagSchoolgirl.Enabled = False
		CBTagMaid.Enabled = False
		CBTagSuperhero.Enabled = False

		CBTagWhipping.Enabled = False
		CBTagSpanking.Enabled = False
		CBTagCockTorture.Enabled = False
		CBTagBallTorture.Enabled = False
		CBTagStrapon.Enabled = False
		CBTagBlindfold.Enabled = False
		CBTagGag.Enabled = False
		CBTagClamps.Enabled = False
		CBTagHotWax.Enabled = False
		CBTagNeedles.Enabled = False
		CBTagElectro.Enabled = False

		CBTagDomme.Enabled = False
		CBTagCumshot.Enabled = False
		CBTagCumEating.Enabled = False
		CBTagKissing.Enabled = False
		CBTagTattoos.Enabled = False
		CBTagStockings.Enabled = False
		CBTagVibrator.Enabled = False
		CBTagDildo.Enabled = False
		CBTagPocketPussy.Enabled = False
		CBTagAnalToy.Enabled = False
		CBTagWatersports.Enabled = False

		CBTagShibari.Enabled = False
		CBTagTentacles.Enabled = False
		CBTagBukkake.Enabled = False
		CBTagBakunyuu.Enabled = False
		CBTagAhegao.Enabled = False
		CBTagBodyWriting.Enabled = False
		CBTagTrap.Enabled = False
		CBTagGanguro.Enabled = False
		CBTagMahouShoujo.Enabled = False
		CBTagMonsterGirl.Enabled = False



		CBTagHardcore.Checked = False
		CBTagLesbian.Checked = False
		CBTagGay.Checked = False
		CBTagBisexual.Checked = False
		CBTagSoloF.Checked = False
		CBTagSoloM.Checked = False
		CBTagSoloFuta.Checked = False
		CBTagPOV.Checked = False
		CBTagBondage.Checked = False
		CBTagSM.Checked = False
		CBTagTD.Checked = False
		CBTagChastity.Checked = False
		CBTagCFNM.Checked = False
		CBTagBath.Checked = False
		CBTagShower.Checked = False
		CBTagOutdoors.Checked = False
		CBTagArtwork.Checked = False

		CBTagMasturbation.Checked = False
		CBTagHandjob.Checked = False
		CBTagFingering.Checked = False
		CBTagBlowjob.Checked = False
		CBTagCunnilingus.Checked = False
		CBTagTitjob.Checked = False
		CBTagFootjob.Checked = False
		CBTagFacesitting.Checked = False
		CBTagRimming.Checked = False
		CBTagMissionary.Checked = False
		CBTagDoggyStyle.Checked = False
		CBTagCowgirl.Checked = False
		CBTagRCowgirl.Checked = False
		CBTagStanding.Checked = False
		CBTagAnalSex.Checked = False
		CBTagDP.Checked = False
		CBTagGangbang.Checked = False

		CBTag1F.Checked = False
		CBTag2F.Checked = False
		CBTag3F.Checked = False
		CBTag1M.Checked = False
		CBTag2M.Checked = False
		CBTag3M.Checked = False
		CBTag1Futa.Checked = False
		CBTag2Futa.Checked = False
		CBTag3Futa.Checked = False
		CBTagFemdom.Checked = False
		CBTagMaledom.Checked = False
		CBTagFutadom.Checked = False
		CBTagFemsub.Checked = False
		CBTagMalesub.Checked = False
		CBTagFutasub.Checked = False
		CBTagMultiDom.Checked = False
		CBTagMultiSub.Checked = False

		CBTagBodyFace.Checked = False
		CBTagBodyFingers.Checked = False
		CBTagBodyMouth.Checked = False
		CBTagBodyTits.Checked = False
		CBTagBodyNipples.Checked = False
		CBTagBodyPussy.Checked = False
		CBTagBodyAss.Checked = False
		CBTagBodyLegs.Checked = False
		CBTagBodyFeet.Checked = False
		CBTagBodyCock.Checked = False
		CBTagBodyBalls.Checked = False

		CBTagNurse.Checked = False
		CBTagTeacher.Checked = False
		CBTagSchoolgirl.Checked = False
		CBTagMaid.Checked = False
		CBTagSuperhero.Checked = False

		CBTagWhipping.Checked = False
		CBTagSpanking.Checked = False
		CBTagCockTorture.Checked = False
		CBTagBallTorture.Checked = False
		CBTagStrapon.Checked = False
		CBTagBlindfold.Checked = False
		CBTagGag.Checked = False
		CBTagClamps.Checked = False
		CBTagHotWax.Checked = False
		CBTagNeedles.Checked = False
		CBTagElectro.Checked = False

		CBTagDomme.Checked = False
		CBTagCumshot.Checked = False
		CBTagCumEating.Checked = False
		CBTagKissing.Checked = False
		CBTagTattoos.Checked = False
		CBTagStockings.Checked = False
		CBTagVibrator.Checked = False
		CBTagDildo.Checked = False
		CBTagPocketPussy.Checked = False
		CBTagAnalToy.Checked = False
		CBTagWatersports.Checked = False

		CBTagShibari.Checked = False
		CBTagTentacles.Checked = False
		CBTagBukkake.Checked = False
		CBTagBakunyuu.Checked = False
		CBTagAhegao.Checked = False
		CBTagBodyWriting.Checked = False
		CBTagTrap.Checked = False
		CBTagGanguro.Checked = False
		CBTagMahouShoujo.Checked = False
		CBTagMonsterGirl.Checked = False


	End Sub

	Public Sub SetLocalImageTags()

		Dim TempImageDir As String = CurrentLocalImageTagImage

		If CBTagHardcore.Checked = True Then TempImageDir = TempImageDir & " " & "TagHardcore"
		If CBTagLesbian.Checked = True Then TempImageDir = TempImageDir & " " & "TagLesbian"
		If CBTagGay.Checked = True Then TempImageDir = TempImageDir & " " & "TagGay"
		If CBTagBisexual.Checked = True Then TempImageDir = TempImageDir & " " & "TagBisexual"
		If CBTagSoloF.Checked = True Then TempImageDir = TempImageDir & " " & "TagSoloF"
		If CBTagSoloM.Checked = True Then TempImageDir = TempImageDir & " " & "TagSoloM"
		If CBTagSoloFuta.Checked = True Then TempImageDir = TempImageDir & " " & "TagSoloFuta"
		If CBTagPOV.Checked = True Then TempImageDir = TempImageDir & " " & "TagPOV"
		If CBTagBondage.Checked = True Then TempImageDir = TempImageDir & " " & "TagBondage"
		If CBTagSM.Checked = True Then TempImageDir = TempImageDir & " " & "TagSM"
		If CBTagTD.Checked = True Then TempImageDir = TempImageDir & " " & "TagTD"
		If CBTagChastity.Checked = True Then TempImageDir = TempImageDir & " " & "TagChastity"
		If CBTagCFNM.Checked = True Then TempImageDir = TempImageDir & " " & "TagCFNM"
		If CBTagBath.Checked = True Then TempImageDir = TempImageDir & " " & "TagBath"
		If CBTagShower.Checked = True Then TempImageDir = TempImageDir & " " & "TagShower"
		If CBTagOutdoors.Checked = True Then TempImageDir = TempImageDir & " " & "TagOutdoors"
		If CBTagArtwork.Checked = True Then TempImageDir = TempImageDir & " " & "TagArtwork"

		If CBTagMasturbation.Checked = True Then TempImageDir = TempImageDir & " " & "TagMasturbation"
		If CBTagHandjob.Checked = True Then TempImageDir = TempImageDir & " " & "TagHandjob"
		If CBTagFingering.Checked = True Then TempImageDir = TempImageDir & " " & "TagFingering"
		If CBTagBlowjob.Checked = True Then TempImageDir = TempImageDir & " " & "TagBlowjob"
		If CBTagCunnilingus.Checked = True Then TempImageDir = TempImageDir & " " & "TagCunnilingus"
		If CBTagTitjob.Checked = True Then TempImageDir = TempImageDir & " " & "TagTitjob"
		If CBTagFootjob.Checked = True Then TempImageDir = TempImageDir & " " & "TagFootjob"
		If CBTagFacesitting.Checked = True Then TempImageDir = TempImageDir & " " & "TagFacesitting"
		If CBTagRimming.Checked = True Then TempImageDir = TempImageDir & " " & "TagRimming"
		If CBTagMissionary.Checked = True Then TempImageDir = TempImageDir & " " & "TagMissionary"
		If CBTagDoggyStyle.Checked = True Then TempImageDir = TempImageDir & " " & "TagDoggyStyle"
		If CBTagCowgirl.Checked = True Then TempImageDir = TempImageDir & " " & "TagCowgirl"
		If CBTagRCowgirl.Checked = True Then TempImageDir = TempImageDir & " " & "TagRCowgirl"
		If CBTagStanding.Checked = True Then TempImageDir = TempImageDir & " " & "TagStanding"
		If CBTagAnalSex.Checked = True Then TempImageDir = TempImageDir & " " & "TagAnalSex"
		If CBTagDP.Checked = True Then TempImageDir = TempImageDir & " " & "TagDP"
		If CBTagGangbang.Checked = True Then TempImageDir = TempImageDir & " " & "TagGangbang"

		If CBTag1F.Checked = True Then TempImageDir = TempImageDir & " " & "Tag1F"
		If CBTag2F.Checked = True Then TempImageDir = TempImageDir & " " & "Tag2F"
		If CBTag3F.Checked = True Then TempImageDir = TempImageDir & " " & "Tag3F"
		If CBTag1M.Checked = True Then TempImageDir = TempImageDir & " " & "Tag1M"
		If CBTag2M.Checked = True Then TempImageDir = TempImageDir & " " & "Tag2M"
		If CBTag3M.Checked = True Then TempImageDir = TempImageDir & " " & "Tag3M"
		If CBTag1Futa.Checked = True Then TempImageDir = TempImageDir & " " & "Tag1Futa"
		If CBTag2Futa.Checked = True Then TempImageDir = TempImageDir & " " & "Tag2Futa"
		If CBTag3Futa.Checked = True Then TempImageDir = TempImageDir & " " & "Tag3Futa"
		If CBTagFemdom.Checked = True Then TempImageDir = TempImageDir & " " & "TagFemdom"
		If CBTagMaledom.Checked = True Then TempImageDir = TempImageDir & " " & "TagMaledom"
		If CBTagFutadom.Checked = True Then TempImageDir = TempImageDir & " " & "TagFutadom"
		If CBTagFemsub.Checked = True Then TempImageDir = TempImageDir & " " & "TagFemsub"
		If CBTagMalesub.Checked = True Then TempImageDir = TempImageDir & " " & "TagMalesub"
		If CBTagFutasub.Checked = True Then TempImageDir = TempImageDir & " " & "TagFutasub"
		If CBTagMultiDom.Checked = True Then TempImageDir = TempImageDir & " " & "TagMultiDom"
		If CBTagMultiSub.Checked = True Then TempImageDir = TempImageDir & " " & "TagMultiSub"

		If CBTagBodyFace.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyFace"
		If CBTagBodyFingers.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyFingers"
		If CBTagBodyMouth.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyMouth"
		If CBTagBodyTits.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyTits"
		If CBTagBodyNipples.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyNipples"
		If CBTagBodyPussy.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyPussy"
		If CBTagBodyAss.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyAss"
		If CBTagBodyLegs.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyLegs"
		If CBTagBodyFeet.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyFeet"
		If CBTagBodyCock.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyCock"
		If CBTagBodyBalls.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyBalls"

		If CBTagNurse.Checked = True Then TempImageDir = TempImageDir & " " & "TagNurse"
		If CBTagTeacher.Checked = True Then TempImageDir = TempImageDir & " " & "TagTeacher"
		If CBTagSchoolgirl.Checked = True Then TempImageDir = TempImageDir & " " & "TagSchoolgirl"
		If CBTagMaid.Checked = True Then TempImageDir = TempImageDir & " " & "TagMaid"
		If CBTagSuperhero.Checked = True Then TempImageDir = TempImageDir & " " & "TagSuperhero"

		If CBTagWhipping.Checked = True Then TempImageDir = TempImageDir & " " & "TagWhipping"
		If CBTagSpanking.Checked = True Then TempImageDir = TempImageDir & " " & "TagSpanking"
		If CBTagCockTorture.Checked = True Then TempImageDir = TempImageDir & " " & "TagCockTorture"
		If CBTagBallTorture.Checked = True Then TempImageDir = TempImageDir & " " & "TagBallTorture"
		If CBTagStrapon.Checked = True Then TempImageDir = TempImageDir & " " & "TagStrapon"
		If CBTagBlindfold.Checked = True Then TempImageDir = TempImageDir & " " & "TagBlindfold"
		If CBTagGag.Checked = True Then TempImageDir = TempImageDir & " " & "TagGag"
		If CBTagClamps.Checked = True Then TempImageDir = TempImageDir & " " & "TagClamps"
		If CBTagHotWax.Checked = True Then TempImageDir = TempImageDir & " " & "TagHotWax"
		If CBTagNeedles.Checked = True Then TempImageDir = TempImageDir & " " & "TagNeedles"
		If CBTagElectro.Checked = True Then TempImageDir = TempImageDir & " " & "TagElectro"

		If CBTagDomme.Checked = True Then TempImageDir = TempImageDir & " " & "TagDomme"
		If CBTagCumshot.Checked = True Then TempImageDir = TempImageDir & " " & "TagCumshot"
		If CBTagCumEating.Checked = True Then TempImageDir = TempImageDir & " " & "TagCumEating"
		If CBTagKissing.Checked = True Then TempImageDir = TempImageDir & " " & "TagKissing"
		If CBTagTattoos.Checked = True Then TempImageDir = TempImageDir & " " & "TagTattoos"
		If CBTagStockings.Checked = True Then TempImageDir = TempImageDir & " " & "TagStockings"
		If CBTagVibrator.Checked = True Then TempImageDir = TempImageDir & " " & "TagVibrator"
		If CBTagDildo.Checked = True Then TempImageDir = TempImageDir & " " & "TagDildo"
		If CBTagPocketPussy.Checked = True Then TempImageDir = TempImageDir & " " & "TagPocketPussy"
		If CBTagAnalToy.Checked = True Then TempImageDir = TempImageDir & " " & "TagAnalToy"
		If CBTagWatersports.Checked = True Then TempImageDir = TempImageDir & " " & "TagWatersports"

		If CBTagShibari.Checked = True Then TempImageDir = TempImageDir & " " & "TagShibari"
		If CBTagTentacles.Checked = True Then TempImageDir = TempImageDir & " " & "TagTentacles"
		If CBTagBukkake.Checked = True Then TempImageDir = TempImageDir & " " & "TagBukkake"
		If CBTagBakunyuu.Checked = True Then TempImageDir = TempImageDir & " " & "TagBakunyuu"
		If CBTagAhegao.Checked = True Then TempImageDir = TempImageDir & " " & "TagAhegao"
		If CBTagBodyWriting.Checked = True Then TempImageDir = TempImageDir & " " & "TagBodyWriting"
		If CBTagTrap.Checked = True Then TempImageDir = TempImageDir & " " & "TagTrap"
		If CBTagGanguro.Checked = True Then TempImageDir = TempImageDir & " " & "TagGanguro"
		If CBTagMahouShoujo.Checked = True Then TempImageDir = TempImageDir & " " & "TagMahouShoujo"
		If CBTagMonsterGirl.Checked = True Then TempImageDir = TempImageDir & " " & "TagMonsterGirl"

		If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then

			Dim TagReader As New StreamReader(Application.StartupPath & "\Images\System\LocalImageTags.txt")
			Dim TagCheckList As New List(Of String)
			While TagReader.Peek <> -1
				TagCheckList.Add(TagReader.ReadLine())
			End While

			TagReader.Close()
			TagReader.Dispose()

			Dim LineExists As Boolean
			LineExists = False

			For i As Integer = 0 To TagCheckList.Count - 1
				If TagCheckList(i).Contains(CurrentLocalImageTagImage) Then
					TagCheckList(i) = TempImageDir
					LineExists = True
					System.IO.File.WriteAllLines(Application.StartupPath & "\Images\System\LocalImageTags.txt", TagCheckList)
				End If
			Next

			If LineExists = False Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LocalImageTags.txt", Environment.NewLine & TempImageDir, True)
				LineExists = False
			End If

		Else
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LocalImageTags.txt", TempImageDir, True)
		End If


	End Sub

	Private Sub Button4_Click_4(sender As System.Object, e As System.EventArgs)
		'If (SaveSettingsDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
		'My.Settings.Save(SaveSettingsDialog.FileName)

		' Dim SettingsSave As String = Configuration.ConfigurationSettings.AppSettings(My.Settings(0))

		'Dim SettingsSave As String = Configuration.ConfigurationSettings.AppSettings(My.Settings(6))


		'End If

	End Sub

	Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs)


		' For Each MySet As My.MySettings In Configuration.ConfigurationSettings.AppSettings
		'Debug.Print(MySet.ToString)

		'Next


	End Sub

	Private Sub NBLongEdge_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBLongEdge.LostFocus
		My.Settings.LongEdge = NBLongEdge.Value
		My.Settings.Save()
	End Sub


	Private Sub NBHoldTheEdgeMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBHoldTheEdgeMax.LostFocus
		My.Settings.HoldTheEdgeMax = NBHoldTheEdgeMax.Value
		My.Settings.HoldTheEdgeMaxAmount = LBLMaxHold.Text
		My.Settings.Save()
	End Sub

	Private Sub NBHoldTheEdgeMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBHoldTheEdgeMin.LostFocus
		My.Settings.HoldTheEdgeMin = NBHoldTheEdgeMin.Value
		My.Settings.HoldTheEdgeMinAmount = LBLMinHold.Text
		My.Settings.Save()
	End Sub

	Private Sub NBHoldTheEdgeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBHoldTheEdgeMax.ValueChanged
		If FrmSettingsLoading = False Then

			If NBHoldTheEdgeMax.Value = 0 And LBLMaxHold.Text = "minutes" Then
				NBHoldTheEdgeMax.Value = 59
				LBLMaxHold.Text = "seconds"
				Return
			End If

			If NBHoldTheEdgeMax.Value = 60 And LBLMaxHold.Text = "seconds" Then
				NBHoldTheEdgeMax.Value = 1
				LBLMaxHold.Text = "minutes"
				Return
			End If
		End If
	End Sub

	Private Sub NBHoldTheEdgeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBHoldTheEdgeMin.ValueChanged
		If FrmSettingsLoading = False Then

			If NBHoldTheEdgeMin.Value = 0 And LBLMinHold.Text = "minutes" Then
				NBHoldTheEdgeMin.Value = 59
				LBLMinHold.Text = "seconds"
				Return
			End If

			If NBHoldTheEdgeMin.Value = 60 And LBLMinHold.Text = "seconds" Then
				NBHoldTheEdgeMin.Value = 1
				LBLMinHold.Text = "minutes"
				Return
			End If
		End If
	End Sub

	Private Sub NBLongHoldMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBLongHoldMax.LostFocus
		My.Settings.LongHoldMax = NBLongHoldMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBLongHoldMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBLongHoldMin.LostFocus
		My.Settings.LongHoldMin = NBLongHoldMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBLongHoldMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBLongHoldMax.ValueChanged
		If FrmSettingsLoading = False Then
			If NBLongHoldMax.Value = 1 Then
				LBLMaxLongHold.Text = "minute"
			Else
				LBLMaxLongHold.Text = "minutes"
			End If
		End If
	End Sub

	Private Sub NBLongHoldMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBLongHoldMin.ValueChanged
		If FrmSettingsLoading = False Then
			If NBLongHoldMin.Value = 1 Then
				LBLMinLongHold.Text = "minute"
			Else
				LBLMinLongHold.Text = "minutes"
			End If
		End If
	End Sub


	Private Sub NBExtremeHoldMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBExtremeHoldMax.LostFocus
		My.Settings.ExtremeHoldMax = NBExtremeHoldMax.Value
		My.Settings.Save()
	End Sub

	Private Sub NBExtremeHoldMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBExtremeHoldMin.LostFocus
		My.Settings.ExtremeHoldMin = NBExtremeHoldMin.Value
		My.Settings.Save()
	End Sub

	Private Sub NBExtremeHoldMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBExtremeHoldMax.ValueChanged
		If FrmSettingsLoading = False Then
			If NBExtremeHoldMax.Value = 1 Then
				LBLMaxExtremeHold.Text = "minute"
			Else
				LBLMaxExtremeHold.Text = "minutes"
			End If
		End If
	End Sub

	Private Sub NBExtremeHoldMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBExtremeHoldMin.ValueChanged
		If FrmSettingsLoading = False Then
			If NBExtremeHoldMin.Value = 1 Then
				LBLMinExtremeHold.Text = "minute"
			Else
				LBLMinExtremeHold.Text = "minutes"
			End If
		End If
	End Sub

	Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
		Dim testreader As New StreamReader(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\StrokeTaunts_1.txt")
		Dim TestingList As New List(Of String)
		While testreader.Peek <> -1
			TestingList.Add(testreader.ReadLine())
		End While

		testreader.Close()
		testreader.Dispose()




	End Sub

	Private Sub CBTSlider_Scroll(sender As System.Object, e As System.EventArgs) Handles CBTSlider.Scroll
		If FrmSettingsLoading = False Then
			My.Settings.CBTSlider = CBTSlider.Value
			My.Settings.Save()
			If CBTSlider.Value = 1 Then LBLCBTSlider.Text = "CBT Level: 1"
			If CBTSlider.Value = 2 Then LBLCBTSlider.Text = "CBT Level: 2"
			If CBTSlider.Value = 3 Then LBLCBTSlider.Text = "CBT Level: 3"
			If CBTSlider.Value = 4 Then LBLCBTSlider.Text = "CBT Level: 4"
			If CBTSlider.Value = 5 Then LBLCBTSlider.Text = "CBT Level: 5"
		End If
	End Sub

	Private Sub CBSubCircumcised_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSubCircumcised.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBSubCircumcised.Checked = True Then
				My.Settings.SubCircumcised = True
			Else
				My.Settings.SubCircumcised = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub CBSubPierced_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSubPierced.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBSubPierced.Checked = True Then
				My.Settings.SubPierced = True
			Else
				My.Settings.SubPierced = False
			End If
			My.Settings.Save()
		End If
	End Sub

	Private Sub NBEmpathy_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBEmpathy.LostFocus

		If NBEmpathy.Value = 1 Then My.Settings.DomEmpathy = 1
		If NBEmpathy.Value = 2 Then My.Settings.DomEmpathy = 2
		If NBEmpathy.Value = 3 Then My.Settings.DomEmpathy = 3
		If NBEmpathy.Value = 4 Then My.Settings.DomEmpathy = 4
		If NBEmpathy.Value = 5 Then My.Settings.DomEmpathy = 5

		My.Settings.Save()

		Debug.Print(My.Settings.DomEmpathy)




	End Sub

	Private Sub domlevelNumBox_ValueChanged(sender As System.Object, e As System.EventArgs) Handles domlevelNumBox.ValueChanged
		If FrmSettingsLoading = False Then
			If domlevelNumBox.Value = 1 Then DomLevelDescLabel.Text = "Gentle"
			If domlevelNumBox.Value = 2 Then DomLevelDescLabel.Text = "Lenient"
			If domlevelNumBox.Value = 3 Then DomLevelDescLabel.Text = "Tease"
			If domlevelNumBox.Value = 4 Then DomLevelDescLabel.Text = "Rough"
			If domlevelNumBox.Value = 5 Then DomLevelDescLabel.Text = "Sadistic"
		End If
	End Sub

	Private Sub NBEmpathy_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBEmpathy.ValueChanged
		If FrmSettingsLoading = False Then
			If NBEmpathy.Value = 1 Then LBLEmpathy.Text = "Cautious"
			If NBEmpathy.Value = 2 Then LBLEmpathy.Text = "Caring"
			If NBEmpathy.Value = 3 Then LBLEmpathy.Text = "Moderate"
			If NBEmpathy.Value = 4 Then LBLEmpathy.Text = "Cruel"
			If NBEmpathy.Value = 5 Then LBLEmpathy.Text = "Merciless"
		End If
	End Sub

	Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles BTNSaveDomSet.Click

		SaveSettingsDialog.Title = "Select a location to save current Domme settings"
		SaveSettingsDialog.InitialDirectory = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\"
		SaveSettingsDialog.FileName = Form1.dompersonalitycombobox.Text & " Domme Settings"

		If SaveSettingsDialog.ShowDialog() = DialogResult.OK Then
			Dim SettingsPath As String = SaveSettingsDialog.FileName
			Dim SettingsList As New List(Of String)
			SettingsList.Clear()

			SettingsList.Add("Level: " & domlevelNumBox.Value)
			SettingsList.Add("Empathy: " & NBEmpathy.Value)
			SettingsList.Add("Age: " & domageNumBox.Value)
			SettingsList.Add("Birth Month: " & NBDomBirthdayMonth.Value)
			SettingsList.Add("Birth Day: " & NBDomBirthdayDay.Value)
			SettingsList.Add("Hair Color: " & TBDomHairColor.Text)
			SettingsList.Add("Hair Length: " & domhairlengthComboBox.Text)
			SettingsList.Add("Eye Color: " & TBDomEyeColor.Text)
			SettingsList.Add("Cup Size: " & boobComboBox.Text)
			SettingsList.Add("Pubic Hair: " & dompubichairComboBox.Text)
			SettingsList.Add("Tattoos: " & CBDomTattoos.Checked)
			SettingsList.Add("Freckles: " & CBDomFreckles.Checked)

			SettingsList.Add("Personality: " & Form1.dompersonalitycombobox.Text)
			SettingsList.Add("Crazy: " & crazyCheckBox.Checked)
			SettingsList.Add("Vulgar: " & vulgarCheckBox.Checked)
			SettingsList.Add("Supremacist: " & supremacistCheckBox.Checked)
			SettingsList.Add("Pet Name 1: " & petnameBox1.Text)
			SettingsList.Add("Pet Name 2: " & petnameBox2.Text)
			SettingsList.Add("Pet Name 3: " & petnameBox3.Text)
			SettingsList.Add("Pet Name 4: " & petnameBox4.Text)
			SettingsList.Add("Pet Name 5: " & petnameBox5.Text)
			SettingsList.Add("Pet Name 6: " & petnameBox6.Text)
			SettingsList.Add("Pet Name 7: " & petnameBox7.Text)
			SettingsList.Add("Pet Name 8: " & petnameBox8.Text)

			SettingsList.Add("Allows Orgasms: " & alloworgasmComboBox.Text)
			SettingsList.Add("Ruins Orgasms: " & ruinorgasmComboBox.Text)
			SettingsList.Add("Denial Ends: " & CBDomDenialEnds.Checked)
			SettingsList.Add("Orgasm Ends: " & CBDomOrgasmEnds.Checked)
			SettingsList.Add("P.O.T.: NULL")
			SettingsList.Add("All Lowercase: " & LCaseCheckBox.Checked)
			SettingsList.Add("No Apostrophes: " & apostropheCheckBox.Checked)
			SettingsList.Add("No Commas: " & commaCheckBox.Checked)
			SettingsList.Add("No Periods: " & periodCheckBox.Checked)
			SettingsList.Add("Me/My/Mine: " & CBMeMyMine.Checked)
			SettingsList.Add("Emotes: " & "NULL")

			SettingsList.Add("DommeMoodMin: " & NBDomMoodMin.Value)
			SettingsList.Add("DommeMoodMax: " & NBDomMoodMax.Value)
			SettingsList.Add("AvgCockSizeMin: " & NBAvgCockMin.Value)
			SettingsList.Add("AvgCockSizeMax: " & NBAvgCockMax.Value)
			SettingsList.Add("SelfAgeMin: " & NBSelfAgeMin.Value)
			SettingsList.Add("SelfAgeMax: " & NBSelfAgeMax.Value)
			SettingsList.Add("SubAgeMin: " & NBSubAgeMin.Value)
			SettingsList.Add("SubAgeMax: " & NBSubAgeMax.Value)

			SettingsList.Add("Emote Start: " & TBEmote.Text)
			SettingsList.Add("Emote End: " & TBEmoteEnd.Text)

			SettingsList.Add("Sadistic: " & sadisticCheckBox.Checked)
			SettingsList.Add("Degrading: " & degradingCheckBox.Checked)

			SettingsList.Add("Typo Chance: " & NBTypoChance.Value)

			Dim SettingsString As String = ""

			For i As Integer = 0 To SettingsList.Count - 1
				SettingsString = SettingsString & SettingsList(i)
				If i <> SettingsList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next

			My.Computer.FileSystem.WriteAllText(SettingsPath, SettingsString, False)
		End If

	End Sub

	Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles BTNLoadDomSet.Click

		OpenSettingsDialog.Title = "Select a Domme settings file"
		OpenSettingsDialog.InitialDirectory = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\"

		If OpenSettingsDialog.ShowDialog() = DialogResult.OK Then

			Dim SettingsList As New List(Of String)

			Try
				Dim SettingsReader As New StreamReader(OpenSettingsDialog.FileName)
				While SettingsReader.Peek <> -1
					SettingsList.Add(SettingsReader.ReadLine())
				End While
				SettingsReader.Close()
				SettingsReader.Dispose()
			Catch ex As Exception
				MessageBox.Show(Me, "This file could not be opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End Try

			Try
				domlevelNumBox.Value = SettingsList(0).Replace("Level: ", "")
				NBEmpathy.Value = SettingsList(1).Replace("Empathy: ", "")
				domageNumBox.Value = SettingsList(2).Replace("Age: ", "")
				NBDomBirthdayMonth.Value = SettingsList(3).Replace("Birth Month: ", "")
				NBDomBirthdayDay.Value = SettingsList(4).Replace("Birth Day: ", "")
				TBDomHairColor.Text = SettingsList(5).Replace("Hair Color: ", "")
				domhairlengthComboBox.Text = SettingsList(6).Replace("Hair Length: ", "")
				TBDomEyeColor.Text = SettingsList(7).Replace("Eye Color: ", "")
				boobComboBox.Text = SettingsList(8).Replace("Cup Size: ", "")
				dompubichairComboBox.Text = SettingsList(9).Replace("Pubic Hair: ", "")
				CBDomTattoos.Checked = SettingsList(10).Replace("Tattoos: ", "")
				CBDomFreckles.Checked = SettingsList(11).Replace("Freckles: ", "")

				Form1.dompersonalitycombobox.Text = SettingsList(12).Replace("Personality: ", "")
				crazyCheckBox.Checked = SettingsList(13).Replace("Crazy: ", "")
				vulgarCheckBox.Checked = SettingsList(14).Replace("Vulgar: ", "")
				supremacistCheckBox.Checked = SettingsList(15).Replace("Supremacist: ", "")
				petnameBox1.Text = SettingsList(16).Replace("Pet Name 1: ", "")
				petnameBox2.Text = SettingsList(17).Replace("Pet Name 2: ", "")
				petnameBox3.Text = SettingsList(18).Replace("Pet Name 3: ", "")
				petnameBox4.Text = SettingsList(19).Replace("Pet Name 4: ", "")
				petnameBox5.Text = SettingsList(20).Replace("Pet Name 5: ", "")
				petnameBox6.Text = SettingsList(21).Replace("Pet Name 6: ", "")
				petnameBox7.Text = SettingsList(22).Replace("Pet Name 7: ", "")
				petnameBox8.Text = SettingsList(23).Replace("Pet Name 8: ", "")

				alloworgasmComboBox.Text = SettingsList(24).Replace("Allows Orgasms: ", "")
				ruinorgasmComboBox.Text = SettingsList(25).Replace("Ruins Orgasms: ", "")
				CBDomDenialEnds.Checked = SettingsList(26).Replace("Denial Ends: ", "")
				CBDomOrgasmEnds.Checked = SettingsList(27).Replace("Orgasm Ends: ", "")
				'CBDomPOT.Checked = SettingsList(28).Replace("P.O.T.: NULL", "")
				LCaseCheckBox.Checked = SettingsList(29).Replace("All Lowercase: ", "")
				apostropheCheckBox.Checked = SettingsList(30).Replace("No Apostrophes: ", "")
				commaCheckBox.Checked = SettingsList(31).Replace("No Commas: ", "")
				periodCheckBox.Checked = SettingsList(32).Replace("No Periods: ", "")
				CBMeMyMine.Checked = SettingsList(33).Replace("Me/My/Mine: ", "")
				'domemoteComboBox.Text = SettingsList(34).Replace("Emotes: ", "")

				NBDomMoodMin.Value = SettingsList(35).Replace("DommeMoodMin: ", "")
				NBDomMoodMax.Value = SettingsList(36).Replace("DommeMoodMax: ", "")
				NBAvgCockMin.Value = SettingsList(37).Replace("AvgCockSizeMin: ", "")
				NBAvgCockMax.Value = SettingsList(38).Replace("AvgCockSizeMax: ", "")
				NBSelfAgeMin.Value = SettingsList(39).Replace("SelfAgeMin: ", "")
				NBSelfAgeMax.Value = SettingsList(40).Replace("SelfAgeMax: ", "")
				NBSubAgeMin.Value = SettingsList(41).Replace("SubAgeMin: ", "")
				NBSubAgeMax.Value = SettingsList(42).Replace("SubAgeMax: ", "")


				TBEmote.Text = SettingsList(43).Replace("Emote Start: ", "")
				TBEmoteEnd.Text = SettingsList(44).Replace("Emote End: ", "")

				sadisticCheckBox.Checked = SettingsList(45).Replace("Sadistic: ", "")
				degradingCheckBox.Checked = SettingsList(46).Replace("Degrading: ", "")

				NBTypoChance.Value = SettingsList(47).Replace("Typo Chance: ", "")


				SaveDommeSettings()
			Catch
				MessageBox.Show(Me, "This settings file is invalid or has been edited incorrectly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				LoadDommeSettings()
			End Try




		End If
	End Sub

	Public Sub SaveDommeSettings()

		My.Settings.DomLevel = domlevelNumBox.Value
		My.Settings.DomEmpathy = NBEmpathy.Value
		My.Settings.DomAge = domageNumBox.Value
		My.Settings.DomBirthMonth = NBDomBirthdayMonth.Value
		My.Settings.DomBirthDay = NBDomBirthdayDay.Value
		My.Settings.DomHair = TBDomHairColor.Text
		My.Settings.DomHairLength = domhairlengthComboBox.Text
		My.Settings.DomEyes = TBDomEyeColor.Text
		My.Settings.DomCup = boobComboBox.Text
		My.Settings.DomPubicHair = dompubichairComboBox.Text
		My.Settings.DomTattoos = CBDomTattoos.Checked
		My.Settings.DomFreckles = CBDomFreckles.Checked

		My.Settings.DomPersonality = Form1.dompersonalitycombobox.Text
		My.Settings.DomCrazy = crazyCheckBox.Checked
		My.Settings.DomVulgar = vulgarCheckBox.Checked
		My.Settings.DomSupremacist = supremacistCheckBox.Checked
		My.Settings.DomSadistic = sadisticCheckBox.Checked
		My.Settings.DomDegrading = degradingCheckBox.Checked
		My.Settings.pnSetting1 = petnameBox1.Text
		My.Settings.pnSetting2 = petnameBox2.Text
		My.Settings.pnSetting3 = petnameBox3.Text
		My.Settings.pnSetting4 = petnameBox4.Text
		My.Settings.pnSetting5 = petnameBox5.Text
		My.Settings.pnSetting6 = petnameBox6.Text
		My.Settings.pnSetting7 = petnameBox7.Text
		My.Settings.pnSetting8 = petnameBox8.Text

		My.Settings.OrgasmAllow = alloworgasmComboBox.Text
		My.Settings.OrgasmRuin = ruinorgasmComboBox.Text
		My.Settings.DomDenialEnd = CBDomDenialEnds.Checked
		My.Settings.DomOrgasmEnd = CBDomOrgasmEnds.Checked
		' My.Settings.DomPOT = CBDomPOT.Checked
		My.Settings.DomLowercase = LCaseCheckBox.Checked
		My.Settings.DomNoApostrophes = apostropheCheckBox.Checked
		My.Settings.DomNoCommas = commaCheckBox.Checked
		My.Settings.DomNoPeriods = periodCheckBox.Checked
		My.Settings.DomMeMyMine = CBMeMyMine.Checked
		My.Settings.DomEmotes = "NULL"

		My.Settings.DomMoodMin = NBDomMoodMin.Value
		My.Settings.DomMoodMax = NBDomMoodMax.Value
		My.Settings.AvgCockMin = NBAvgCockMin.Value
		My.Settings.AvgCockMax = NBAvgCockMax.Value
		My.Settings.SelfAgeMin = NBSelfAgeMin.Value
		My.Settings.SelfAgeMax = NBSelfAgeMax.Value
		My.Settings.SubAgeMin = NBSubAgeMin.Value
		My.Settings.SubAgeMax = NBSubAgeMax.Value

		My.Settings.Save()


	End Sub

	Public Sub LoadDommeSettings()

		domlevelNumBox.Value = My.Settings.DomLevel
		NBEmpathy.Value = My.Settings.DomEmpathy
		domageNumBox.Value = My.Settings.DomAge
		NBDomBirthdayMonth.Value = My.Settings.DomBirthMonth
		NBDomBirthdayDay.Value = My.Settings.DomBirthDay
		TBDomHairColor.Text = My.Settings.DomHair
		domhairlengthComboBox.Text = My.Settings.DomHairLength
		TBDomEyeColor.Text = My.Settings.DomEyes
		boobComboBox.Text = My.Settings.DomCup
		dompubichairComboBox.Text = My.Settings.DomPubicHair
		CBDomTattoos.Checked = My.Settings.DomTattoos
		CBDomFreckles.Checked = My.Settings.DomFreckles

		Form1.dompersonalitycombobox.Text = My.Settings.DomPersonality
		crazyCheckBox.Checked = My.Settings.DomCrazy
		vulgarCheckBox.Checked = My.Settings.DomVulgar
		supremacistCheckBox.Checked = My.Settings.DomSupremacist
		sadisticCheckBox.Checked = My.Settings.DomSadistic
		degradingCheckBox.Checked = My.Settings.DomDegrading
		petnameBox1.Text = My.Settings.pnSetting1
		petnameBox2.Text = My.Settings.pnSetting2
		petnameBox3.Text = My.Settings.pnSetting3
		petnameBox4.Text = My.Settings.pnSetting4
		petnameBox5.Text = My.Settings.pnSetting5
		petnameBox6.Text = My.Settings.pnSetting6
		petnameBox7.Text = My.Settings.pnSetting7
		petnameBox8.Text = My.Settings.pnSetting8

		alloworgasmComboBox.Text = My.Settings.OrgasmAllow
		ruinorgasmComboBox.Text = My.Settings.OrgasmRuin
		CBDomDenialEnds.Checked = My.Settings.DomDenialEnd
		CBDomOrgasmEnds.Checked = My.Settings.DomOrgasmEnd
		'CBDomPOT.Checked = My.Settings.DomPOT
		LCaseCheckBox.Checked = My.Settings.DomLowercase
		apostropheCheckBox.Checked = My.Settings.DomNoApostrophes
		commaCheckBox.Checked = My.Settings.DomNoCommas
		periodCheckBox.Checked = My.Settings.DomNoPeriods
		CBMeMyMine.Checked = My.Settings.DomMeMyMine
		'domemoteComboBox.Text = My.Settings.DomEmotes

		NBDomMoodMin.Value = My.Settings.DomMoodMin
		NBDomMoodMax.Value = My.Settings.DomMoodMax
		NBAvgCockMin.Value = My.Settings.AvgCockMin
		NBAvgCockMax.Value = My.Settings.AvgCockMax
		NBSelfAgeMin.Value = My.Settings.SelfAgeMin
		NBSelfAgeMax.Value = My.Settings.SelfAgeMax
		NBSubAgeMin.Value = My.Settings.SubAgeMin
		NBSubAgeMax.Value = My.Settings.SubAgeMax

	End Sub

	Private Sub BTNLocalTagPrevious_Click(sender As System.Object, e As System.EventArgs) Handles BTNLocalTagPrevious.Click

		Form1.LocalTagCount -= 1
		LBLLocalTagCount.Text = Form1.LocalTagCount & "/" & LocalImageTagDir.Count
		BTNLocalTagNext.Enabled = True

		SetLocalImageTags()

		LocalImageTagCount -= 1
		Form1.mainPictureBox.Image = Image.FromFile(LocalImageTagDir(LocalImageTagCount))
		CurrentLocalImageTagImage = LocalImageTagDir(LocalImageTagCount)

		If LocalImageTagCount = 0 Then BTNLocalTagPrevious.Enabled = False

		CheckLocalTagList()

	End Sub

	Private Sub BTNLocalTagSave_Click(sender As System.Object, e As System.EventArgs) Handles BTNLocalTagSave.Click

		SetLocalImageTags()

		BTNLocalTagDir.Enabled = True
		TBLocalTagDir.Enabled = True
		BTNLocalTagSave.Enabled = False
		BTNLocalTagNext.Enabled = False
		BTNLocalTagPrevious.Enabled = False

		DisableLocalTagList()

		LBLLocalTagCount.Text = "0/0"
		LBLLocalTagCount.Enabled = False


		Form1.mainPictureBox.Image = Nothing

	End Sub

	Private Sub TBLocalTagDir_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TBLocalTagDir.KeyPress

		If e.KeyChar = Convert.ToChar(13) Then

			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)

			If My.Computer.FileSystem.DirectoryExists(TBLocalTagDir.Text) Then

				LocalImageTagDir.Clear()

				Dim TagLocalImageFolder As String = TBLocalTagDir.Text

				Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
				Dim files As String()

				files = Directory.GetFiles(TagLocalImageFolder, "*.*")

				Array.Sort(files)

				For Each fi As String In files
					If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
						LocalImageTagDir.Add(fi)
					End If
				Next

				If LocalImageTagDir.Count < 1 Then
					MessageBox.Show(Me, "There are no images in the specified folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If

				Form1.mainPictureBox.Image = Image.FromFile(LocalImageTagDir(0))


				CurrentLocalImageTagImage = LocalImageTagDir(0)


				CheckLocalTagList()



				Form1.LocalTagCount = 1
				LBLLocalTagCount.Text = Form1.LocalTagCount & "/" & LocalImageTagDir.Count


				LocalImageTagCount = 0

				BTNLocalTagSave.Enabled = True
				BTNLocalTagNext.Enabled = True
				BTNLocalTagPrevious.Enabled = False
				BTNLocalTagDir.Enabled = False
				TBLocalTagDir.Enabled = False

				EnableLocalTagList()

				LBLLocalTagCount.Enabled = True

			Else

				TBLocalTagDir.Text = "Not a Valid Directory!"

			End If

		End If



	End Sub


	Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs)
		Form1.CreateTaskLetter()
	End Sub

	Private Sub CBSaveChatlogExit_CheckedChanged(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CBSaveChatlogExit.MouseClick

	End Sub

	Private Sub CBRangeOrgasm_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBRangeOrgasm.CheckedChanged
		If CBRangeOrgasm.Checked = False Then
			NBAllowOften.Enabled = True
			NBAllowSometimes.Enabled = True
			NBAllowRarely.Enabled = True
		Else
			NBAllowOften.Enabled = False
			NBAllowSometimes.Enabled = False
			NBAllowRarely.Enabled = False
		End If
	End Sub

	Private Sub CBRangeRuin_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBRangeRuin.CheckedChanged
		If CBRangeRuin.Checked = False Then
			NBRuinOften.Enabled = True
			NBRuinSometimes.Enabled = True
			NBRuinRarely.Enabled = True
		Else
			NBRuinOften.Enabled = False
			NBRuinSometimes.Enabled = False
			NBRuinRarely.Enabled = False
		End If
	End Sub

	Private Sub CBRangeOrgasm_LostFocus(sender As Object, e As System.EventArgs) Handles CBRangeOrgasm.LostFocus
		My.Settings.RangeOrgasm = CBRangeOrgasm.Checked
		My.Settings.Save()
	End Sub
	Private Sub CBRangeRuin_LostFocus(sender As Object, e As System.EventArgs) Handles CBRangeRuin.LostFocus
		My.Settings.RangeRuin = CBRangeRuin.Checked
		My.Settings.Save()
	End Sub

	Private Sub NBAllowOften_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowOften.LostFocus
		My.Settings.AllowOften = NBAllowOften.Value
		My.Settings.Save()
	End Sub

	Private Sub NBAllowSometimes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowSometimes.LostFocus
		My.Settings.AllowSometimes = NBAllowSometimes.Value
		My.Settings.Save()
	End Sub

	Private Sub NBAllowRarely_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowRarely.LostFocus
		My.Settings.AllowRarely = NBAllowRarely.Value
		My.Settings.Save()
	End Sub

	Private Sub NBRuinOften_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinOften.LostFocus
		My.Settings.RuinOften = NBRuinOften.Value
		My.Settings.Save()
	End Sub

	Private Sub NBRuinSometimes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinSometimes.LostFocus
		My.Settings.RuinSometimes = NBRuinSometimes.Value
		My.Settings.Save()
	End Sub

	Private Sub NBRuinRarely_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinRarely.LostFocus
		My.Settings.RuinRarely = NBRuinRarely.Value
		My.Settings.Save()
	End Sub

	Private Sub TBSafeword_LostFocus(sender As Object, e As System.EventArgs) Handles TBSafeword.LostFocus
		My.Settings.Safeword = TBSafeword.Text
		My.Settings.Save()
	End Sub


	Private Sub BN1_LostFocus(sender As Object, e As System.EventArgs) Handles BN1.LostFocus
		My.Settings.BN1 = BN1.Text
		My.Settings.Save()
	End Sub
	Private Sub BN2_LostFocus(sender As Object, e As System.EventArgs) Handles BN2.LostFocus
		My.Settings.BN2 = BN2.Text
		My.Settings.Save()
	End Sub
	Private Sub BN3_LostFocus(sender As Object, e As System.EventArgs) Handles BN3.LostFocus
		My.Settings.BN3 = BN3.Text
		My.Settings.Save()
	End Sub
	Private Sub BN4_LostFocus(sender As Object, e As System.EventArgs) Handles BN4.LostFocus
		My.Settings.BN4 = BN4.Text
		My.Settings.Save()
	End Sub
	Private Sub BN5_LostFocus(sender As Object, e As System.EventArgs) Handles BN5.LostFocus
		My.Settings.BN5 = BN5.Text
		My.Settings.Save()
	End Sub
	Private Sub BN6_LostFocus(sender As Object, e As System.EventArgs) Handles BN6.LostFocus
		My.Settings.BN6 = BN6.Text
		My.Settings.Save()
	End Sub

	Private Sub SN1_LostFocus(sender As Object, e As System.EventArgs) Handles SN1.LostFocus
		My.Settings.SN1 = SN1.Text
		My.Settings.Save()
	End Sub
	Private Sub SN2_LostFocus(sender As Object, e As System.EventArgs) Handles SN2.LostFocus
		My.Settings.SN2 = SN2.Text
		My.Settings.Save()
	End Sub
	Private Sub SN3_LostFocus(sender As Object, e As System.EventArgs) Handles SN3.LostFocus
		My.Settings.SN3 = SN3.Text
		My.Settings.Save()
	End Sub
	Private Sub SN4_LostFocus(sender As Object, e As System.EventArgs) Handles SN4.LostFocus
		My.Settings.SN4 = SN4.Text
		My.Settings.Save()
	End Sub
	Private Sub SN5_LostFocus(sender As Object, e As System.EventArgs) Handles SN5.LostFocus
		My.Settings.SN5 = SN5.Text
		My.Settings.Save()
	End Sub
	Private Sub SN6_LostFocus(sender As Object, e As System.EventArgs) Handles SN6.LostFocus
		My.Settings.SN6 = SN6.Text
		My.Settings.Save()
	End Sub

	Private Sub GN1_LostFocus(sender As Object, e As System.EventArgs) Handles GN1.LostFocus
		My.Settings.GN1 = GN1.Text
		My.Settings.Save()
	End Sub
	Private Sub GN2_LostFocus(sender As Object, e As System.EventArgs) Handles GN2.LostFocus
		My.Settings.GN2 = GN2.Text
		My.Settings.Save()
	End Sub
	Private Sub GN3_LostFocus(sender As Object, e As System.EventArgs) Handles GN3.LostFocus
		My.Settings.GN3 = GN3.Text
		My.Settings.Save()
	End Sub
	Private Sub GN4_LostFocus(sender As Object, e As System.EventArgs) Handles GN4.LostFocus
		My.Settings.GN4 = GN4.Text
		My.Settings.Save()
	End Sub
	Private Sub GN5_LostFocus(sender As Object, e As System.EventArgs) Handles GN5.LostFocus
		My.Settings.GN5 = GN5.Text
		My.Settings.Save()
	End Sub
	Private Sub GN6_LostFocus(sender As Object, e As System.EventArgs) Handles GN6.LostFocus
		My.Settings.GN6 = GN6.Text
		My.Settings.Save()
	End Sub

	Private Sub BP1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP1.DragEnter, BP2.DragEnter, BP3.DragEnter, BP4.DragEnter, BP5.DragEnter, BP6.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Public Sub AutosizeImage(ByVal ImagePath As String, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
		Try
			picBox.Image = Nothing
			picBox.SizeMode = pSizeMode
			If System.IO.File.Exists(ImagePath) Then
				Dim imgOrg As Bitmap
				Dim imgShow As Bitmap
				Dim g As Graphics
				Dim divideBy, divideByH, divideByW As Double
				imgOrg = DirectCast(Bitmap.FromFile(ImagePath), Bitmap)

				divideByW = imgOrg.Width / picBox.Width
				divideByH = imgOrg.Height / picBox.Height
				If divideByW > 1 Or divideByH > 1 Then
					If divideByW > divideByH Then
						divideBy = divideByW
					Else
						divideBy = divideByH
					End If

					imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
					imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
					g = Graphics.FromImage(imgShow)
					g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
					g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
					g.Dispose()
				Else
					imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
					imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
					g = Graphics.FromImage(imgShow)
					g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
					g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
					g.Dispose()
				End If
				imgOrg.Dispose()

				picBox.Image = imgShow
			Else
				picBox.Image = Nothing
			End If


		Catch ex As Exception
			MsgBox(ex.ToString)
		End Try

	End Sub


	Private Function CardType(ByVal CardExtension As String) As String

		Dim SaveExtension As String

		SaveExtension = "bmp"
		If UCase(Path.GetFileName(CardExtension)).Contains(".GIF") Then SaveExtension = "gif"
		If UCase(Path.GetFileName(CardExtension)).Contains(".PNG") Then SaveExtension = "png"
		If UCase(Path.GetFileName(CardExtension)).Contains(".JPG") Then SaveExtension = "jpg"
		If UCase(Path.GetFileName(CardExtension)).Contains(".jpeg") Then SaveExtension = "jpeg"

		Return SaveExtension

	End Function

	Private Sub BP1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP1.DragDrop

		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP1.Image.Dispose()
		Catch
		End Try
		BP1.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP1, PictureBoxSizeMode.StretchImage)

		'Dim CardExt As String = CardType((CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString))

		FrmCardList.BronzeP1.Image.Save(Application.StartupPath & "\Images\Cards\CardBP1.bmp")

		Try
			BP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP1.bmp")
			My.Settings.BP1 = Application.StartupPath & "\Images\Cards\CardBP1.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try

	End Sub


	Private Sub BP1_Click(sender As System.Object, e As System.EventArgs) Handles BP1.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP1.Image.Dispose()
			Catch
			End Try
			BP1.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP1.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP1.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP1.bmp")
			resizedcard.Dispose()

			Try
				BP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP1.bmp")
				My.Settings.BP1 = Application.StartupPath & "\Images\Cards\CardBP1.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub BP2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP2.DragDrop

		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP2.Image.Dispose()
		Catch
		End Try
		BP2.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP2, PictureBoxSizeMode.StretchImage)



		FrmCardList.BronzeP2.Image.Save(Application.StartupPath & "\Images\Cards\CardBP2.bmp")

		Try
			BP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP2.bmp")
			My.Settings.BP2 = Application.StartupPath & "\Images\Cards\CardBP2.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try

	End Sub

	Private Sub BP2_Click(sender As System.Object, e As System.EventArgs) Handles BP2.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP2.Image.Dispose()
			Catch
			End Try
			BP2.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP2.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP2.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP2.bmp")
			resizedcard.Dispose()

			Try
				BP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP2.bmp")
				My.Settings.BP2 = Application.StartupPath & "\Images\Cards\CardBP2.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub BP3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP3.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP3.Image.Dispose()
		Catch
		End Try
		BP3.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP3, PictureBoxSizeMode.StretchImage)



		FrmCardList.BronzeP3.Image.Save(Application.StartupPath & "\Images\Cards\CardBP3.bmp")

		Try
			BP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP3.bmp")
			My.Settings.BP3 = Application.StartupPath & "\Images\Cards\CardBP3.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub BP3_Click(sender As System.Object, e As System.EventArgs) Handles BP3.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP3.Image.Dispose()
			Catch
			End Try
			BP3.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP3.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP3.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP3.bmp")
			resizedcard.Dispose()

			Try
				BP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP3.bmp")
				My.Settings.BP3 = Application.StartupPath & "\Images\Cards\CardBP3.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub BP4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP4.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP4.Image.Dispose()
		Catch
		End Try
		BP4.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP4, PictureBoxSizeMode.StretchImage)



		FrmCardList.BronzeP4.Image.Save(Application.StartupPath & "\Images\Cards\CardBP4.bmp")

		Try
			BP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP4.bmp")
			My.Settings.BP4 = Application.StartupPath & "\Images\Cards\CardBP4.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub BP4_Click(sender As System.Object, e As System.EventArgs) Handles BP4.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP4.Image.Dispose()
			Catch
			End Try
			BP4.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP4.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP4.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP4.bmp")
			resizedcard.Dispose()

			Try
				BP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP4.bmp")
				My.Settings.BP4 = Application.StartupPath & "\Images\Cards\CardBP4.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub BP5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP5.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP5.Image.Dispose()
		Catch
		End Try
		BP5.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP5, PictureBoxSizeMode.StretchImage)



		FrmCardList.BronzeP5.Image.Save(Application.StartupPath & "\Images\Cards\CardBP5.bmp")

		Try
			BP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP5.bmp")
			My.Settings.BP5 = Application.StartupPath & "\Images\Cards\CardBP5.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub BP5_Click(sender As System.Object, e As System.EventArgs) Handles BP5.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP5.Image.Dispose()
			Catch
			End Try
			BP5.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP5.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP5.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP5.bmp")
			resizedcard.Dispose()

			Try
				BP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP5.bmp")
				My.Settings.BP5 = Application.StartupPath & "\Images\Cards\CardBP5.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub BP6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BP6.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			BP6.Image.Dispose()
		Catch
		End Try
		BP6.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.BronzeP6, PictureBoxSizeMode.StretchImage)



		FrmCardList.BronzeP6.Image.Save(Application.StartupPath & "\Images\Cards\CardBP6.bmp")

		Try
			BP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP6.bmp")
			My.Settings.BP6 = Application.StartupPath & "\Images\Cards\CardBP6.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub BP6_Click(sender As System.Object, e As System.EventArgs) Handles BP6.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				BP6.Image.Dispose()
			Catch
			End Try
			BP6.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardBP6.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardBP6.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardBP6.bmp")
			resizedcard.Dispose()

			Try
				BP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardBP6.bmp")
				My.Settings.BP6 = Application.StartupPath & "\Images\Cards\CardBP6.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP1.DragEnter, SP2.DragEnter, SP3.DragEnter, SP4.DragEnter, SP5.DragEnter, SP6.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub SP1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP1.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP1.Image.Dispose()
		Catch
		End Try
		SP1.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP1, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP1.Image.Save(Application.StartupPath & "\Images\Cards\CardSP1.bmp")

		Try
			SP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP1.bmp")
			My.Settings.SP1 = Application.StartupPath & "\Images\Cards\CardSP1.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub SP1_Click(sender As System.Object, e As System.EventArgs) Handles SP1.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP1.Image.Dispose()
			Catch
			End Try
			SP1.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP1.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP1.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP1.bmp")
			resizedcard.Dispose()

			Try
				SP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP1.bmp")
				My.Settings.SP1 = Application.StartupPath & "\Images\Cards\CardSP1.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP2.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP2.Image.Dispose()
		Catch
		End Try
		SP2.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP2, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP2.Image.Save(Application.StartupPath & "\Images\Cards\CardSP2.bmp")

		Try
			SP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP2.bmp")
			My.Settings.SP2 = Application.StartupPath & "\Images\Cards\CardSP2.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub
	Private Sub SP2_Click(sender As System.Object, e As System.EventArgs) Handles SP2.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP2.Image.Dispose()
			Catch
			End Try
			SP2.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP2.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP2.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP2.bmp")
			resizedcard.Dispose()

			Try
				SP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP2.bmp")
				My.Settings.SP2 = Application.StartupPath & "\Images\Cards\CardSP2.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP3.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP3.Image.Dispose()
		Catch
		End Try
		SP3.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP3, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP3.Image.Save(Application.StartupPath & "\Images\Cards\CardSP3.bmp")

		Try
			SP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP3.bmp")
			My.Settings.SP3 = Application.StartupPath & "\Images\Cards\CardSP3.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub SP3_Click(sender As System.Object, e As System.EventArgs) Handles SP3.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP3.Image.Dispose()
			Catch
			End Try
			SP3.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP3.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP3.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP3.bmp")
			resizedcard.Dispose()

			Try
				SP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP3.bmp")
				My.Settings.SP3 = Application.StartupPath & "\Images\Cards\CardSP3.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP4.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP4.Image.Dispose()
		Catch
		End Try
		SP4.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP4, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP4.Image.Save(Application.StartupPath & "\Images\Cards\CardSP4.bmp")

		Try
			SP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP4.bmp")
			My.Settings.SP4 = Application.StartupPath & "\Images\Cards\CardSP4.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub SP4_Click(sender As System.Object, e As System.EventArgs) Handles SP4.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP4.Image.Dispose()
			Catch
			End Try
			SP4.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP4.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP4.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP4.bmp")
			resizedcard.Dispose()

			Try
				SP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP4.bmp")
				My.Settings.SP4 = Application.StartupPath & "\Images\Cards\CardSP4.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP5.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP5.Image.Dispose()
		Catch
		End Try
		SP5.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP5, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP5.Image.Save(Application.StartupPath & "\Images\Cards\CardSP5.bmp")

		Try
			SP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP5.bmp")
			My.Settings.SP5 = Application.StartupPath & "\Images\Cards\CardSP5.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub SP5_Click(sender As System.Object, e As System.EventArgs) Handles SP5.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP5.Image.Dispose()
			Catch
			End Try
			SP5.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP5.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP5.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP5.bmp")
			resizedcard.Dispose()

			Try
				SP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP5.bmp")
				My.Settings.SP5 = Application.StartupPath & "\Images\Cards\CardSP5.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub SP6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SP6.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			SP6.Image.Dispose()
		Catch
		End Try
		SP6.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.SilverP6, PictureBoxSizeMode.StretchImage)



		FrmCardList.SilverP6.Image.Save(Application.StartupPath & "\Images\Cards\CardSP6.bmp")

		Try
			SP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP6.bmp")
			My.Settings.SP6 = Application.StartupPath & "\Images\Cards\CardSP6.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub SP6_Click(sender As System.Object, e As System.EventArgs) Handles SP6.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				SP6.Image.Dispose()
			Catch
			End Try
			SP6.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardSP6.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardSP6.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardSP6.bmp")
			resizedcard.Dispose()

			Try
				SP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardSP6.bmp")
				My.Settings.SP6 = Application.StartupPath & "\Images\Cards\CardSP6.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP1.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP1.Image.Dispose()
		Catch
		End Try
		GP1.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP1, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP1.Image.Save(Application.StartupPath & "\Images\Cards\CardGP1.bmp")

		Try
			GP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP1.bmp")
			My.Settings.GP1 = Application.StartupPath & "\Images\Cards\CardGP1.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub GP1_Click(sender As System.Object, e As System.EventArgs) Handles GP1.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP1.Image.Dispose()
			Catch
			End Try
			GP1.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP1.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP1.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP1.bmp")
			resizedcard.Dispose()

			Try
				GP1.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP1.bmp")
				My.Settings.GP1 = Application.StartupPath & "\Images\Cards\CardGP1.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP1.DragEnter, GP2.DragEnter, GP3.DragEnter, GP4.DragEnter, GP5.DragEnter, GP6.DragEnter, CardBack.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub GP2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP2.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP2.Image.Dispose()
		Catch
		End Try
		GP2.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP2, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP2.Image.Save(Application.StartupPath & "\Images\Cards\CardGP2.bmp")

		Try
			GP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP2.bmp")
			My.Settings.GP2 = Application.StartupPath & "\Images\Cards\CardGP2.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub GP2_Click(sender As System.Object, e As System.EventArgs) Handles GP2.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP2.Image.Dispose()
			Catch
			End Try
			GP2.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP2.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP2.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP2.bmp")
			resizedcard.Dispose()

			Try
				GP2.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP2.bmp")
				My.Settings.GP2 = Application.StartupPath & "\Images\Cards\CardGP2.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP3.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP3.Image.Dispose()
		Catch
		End Try
		GP3.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP3, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP3.Image.Save(Application.StartupPath & "\Images\Cards\CardGP3.bmp")

		Try
			GP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP3.bmp")
			My.Settings.GP3 = Application.StartupPath & "\Images\Cards\CardGP3.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub
	Private Sub GP3_Click(sender As System.Object, e As System.EventArgs) Handles GP3.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP3.Image.Dispose()
			Catch
			End Try
			GP3.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP3.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP3.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP3.bmp")
			resizedcard.Dispose()

			Try
				GP3.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP3.bmp")
				My.Settings.GP3 = Application.StartupPath & "\Images\Cards\CardGP3.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP4_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP4.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP4.Image.Dispose()
		Catch
		End Try
		GP4.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP4, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP4.Image.Save(Application.StartupPath & "\Images\Cards\CardGP4.bmp")

		Try
			GP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP4.bmp")
			My.Settings.GP4 = Application.StartupPath & "\Images\Cards\CardGP4.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub GP4_Click(sender As System.Object, e As System.EventArgs) Handles GP4.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP4.Image.Dispose()
			Catch
			End Try
			GP4.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP4.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP4.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP4.bmp")
			resizedcard.Dispose()

			Try
				GP4.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP4.bmp")
				My.Settings.GP4 = Application.StartupPath & "\Images\Cards\CardGP4.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP5_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP5.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP5.Image.Dispose()
		Catch
		End Try
		GP5.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP5, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP5.Image.Save(Application.StartupPath & "\Images\Cards\CardGP5.bmp")

		Try
			GP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP5.bmp")
			My.Settings.GP5 = Application.StartupPath & "\Images\Cards\CardGP5.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub GP5_Click(sender As System.Object, e As System.EventArgs) Handles GP5.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP5.Image.Dispose()
			Catch
			End Try
			GP5.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP5.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP5.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP5.bmp")
			resizedcard.Dispose()

			Try
				GP5.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP5.bmp")
				My.Settings.GP5 = Application.StartupPath & "\Images\Cards\CardGP5.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub

	Private Sub GP6_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GP6.DragDrop
		If FrmCardList.Visible = True Then FrmCardList.Dispose()
		FrmCardList.ClearAllCards()

		Try
			GP6.Image.Dispose()
		Catch
		End Try
		GP6.Image = Nothing
		GC.Collect()

		AutosizeImage(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString, FrmCardList.GoldP6, PictureBoxSizeMode.StretchImage)



		FrmCardList.GoldP6.Image.Save(Application.StartupPath & "\Images\Cards\CardGP6.bmp")

		Try
			GP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP6.bmp")
			My.Settings.GP6 = Application.StartupPath & "\Images\Cards\CardGP6.bmp"
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub GP6_Click(sender As System.Object, e As System.EventArgs) Handles GP6.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			FrmCardList.ClearAllCards()

			Try
				GP6.Image.Dispose()
			Catch
			End Try
			GP6.Image = Nothing
			GC.Collect()

			Dim originalcard As Image = Image.FromFile(OpenFileDialog1.FileName)
			Dim resizedcard As Image = Form1.ResizeImage(originalcard, New Size(120, 165))
			originalcard.Dispose()

			If File.Exists(Application.StartupPath & "\Images\Cards\CardGP6.bmp") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Images\Cards\CardGP6.bmp")
			End If
			resizedcard.Save(Application.StartupPath & "\Images\Cards\CardGP6.bmp")
			resizedcard.Dispose()

			Try
				GP6.Image = Image.FromFile(Application.StartupPath & "\Images\Cards\CardGP6.bmp")
				My.Settings.GP6 = Application.StartupPath & "\Images\Cards\CardGP6.bmp"
				My.Settings.Save()
			Catch ex As Exception
				MessageBox.Show("An error occurred - Card did not save correctly")
			End Try
		End If
	End Sub


	Private Sub CardBack_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles CardBack.DragDrop
		Try

			GC.Collect()
		Catch
		End Try

		CardBack.Image.Dispose()
		CardBack.Image = Nothing

		Try
			CardBack.Image = Image.FromFile(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
			My.Settings.CardBack = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
			My.Settings.Save()
		Catch ex As Exception
			MessageBox.Show("Error Doing Drag/Drop")
		End Try
	End Sub

	Private Sub CardBack_Click(sender As System.Object, e As System.EventArgs) Handles CardBack.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				CardBack.Image.Dispose()
			Catch
			End Try
			CardBack.Image = Nothing
			GC.Collect()
			CardBack.Load(OpenFileDialog1.FileName)
			My.Settings.CardBack = OpenFileDialog1.FileName
			My.Settings.Save()
		End If
	End Sub



	Private Sub Button4_Click_5(sender As System.Object, e As System.EventArgs) Handles Button4.Click

		TBResponses.Text = ""
		RTBResponses.Text = ""
		RTBResponsesKEY.Text = ""

		Dim files() As String = Directory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\")

		LBResponses.Items.Clear()

		For Each file As String In files
			LBResponses.Items.Add(Path.GetFileName(file).Replace(".txt", ""))
		Next




	End Sub

	Private Sub LBResponses_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LBResponses.SelectedIndexChanged

		Dim ResponsePath As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & LBResponses.SelectedItem & ".txt"

		If Not File.Exists(ResponsePath) Then Return



		TBResponses.Text = LBResponses.SelectedItem

		RTBResponses.Text = ""


		Dim ioFile As New StreamReader(ResponsePath)
		Dim lines As New List(Of String)

		' Dim ResponseCount As Integer
		'Dim ResponseEnd As Integer

		'ResponseCount = -1

		While ioFile.Peek <> -1
			'   ResponseCount += 1
			lines.Add(ioFile.ReadLine())
		End While

		ioFile.Close()
		ioFile.Dispose()


		'ResponseEnd = ResponseCount
		'ResponseCount = 0

		RTBResponsesKEY.Text = lines(0)

		For i As Integer = 1 To lines.Count - 1
			RTBResponses.Text = RTBResponses.Text & lines(i) & Environment.NewLine
		Next

		' Array.ForEach(Enumerable.Range(0, RTBResponses.Lines.Length).Where(Function(x) RTBResponses.Lines(x).StartsWith("[")).ToArray, Sub(x)
		'RTBResponses.SelectionStart = RTBResponses.GetFirstCharIndexFromLine(x)
		'RTBResponses.SelectionLength = RTBResponses.Lines(x).Length
		'RTBResponses.SelectionFont = New Font(RTBResponses.SelectionFont, FontStyle.Bold)
		'                                                                                                                              End Sub)

		For i As Integer = 0 To RTBResponses.Lines.Count - 1
			Try
				If RTBResponses.Lines(i).Substring(0, 1) = "[" Then
					RTBResponses.SelectionStart = RTBResponses.Text.IndexOf(RTBResponses.Lines(i))
					RTBResponses.SelectionLength = RTBResponses.Lines(i).Length
					'RTBResponses.Select(RTBResponses.GetFirstCharIndexFromLine(i), RTBResponses.Lines(i).Length)
					RTBResponses.SelectionFont = New Font(RTBResponses.SelectionFont, FontStyle.Bold)
				End If
			Catch
			End Try
		Next




		'Do
		'RTBResponses.Text = RTBResponses.Text & lines(ResponseCount) & Environment.NewLine
		'ResponseCount += 1
		'Loop Until ResponseCount = ResponseEnd + 1






	End Sub

	Private Sub Button5_Click_2(sender As System.Object, e As System.EventArgs) Handles Button5.Click



		If TBResponses.Text = "" Then
			MessageBox.Show(Me, "Please enter a file name for this Response script!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		If RTBResponsesKEY.Text = "" Then
			MessageBox.Show(Me, "You have not entered any keywords for the program to find!" & Environment.NewLine & Environment.NewLine & "Please add at least one keyword between brackets in the top window.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		If RTBResponses.Text = "" Then
			MessageBox.Show(Me, "The Response file you are attempting to save is blank!" & Environment.NewLine & Environment.NewLine & "Please add some lines before saving.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		Dim ResponsesaveDir As String = TBResponses.Text
		ResponsesaveDir = ResponsesaveDir.Replace(".txt", "")

		If Not LBResponses.Items.Contains(ResponsesaveDir) Then
			LBResponses.Items.Add(ResponsesaveDir)
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", RTBResponsesKEY.Text & Environment.NewLine, False)
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", RTBResponses.Text, True)
			File.WriteAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", File.ReadAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt").Where(Function(s) s <> String.Empty))
		Else
			Dim Result As Integer = MessageBox.Show(Me, ResponsesaveDir & " already exists!" & Environment.NewLine & Environment.NewLine & "Do you wish to overwrite?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.Yes Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", RTBResponsesKEY.Text & Environment.NewLine, False)
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", RTBResponses.Text, True)
				File.WriteAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt", File.ReadAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ResponsesaveDir & ".txt").Where(Function(s) s <> String.Empty))
			Else
				Debug.Print("Did not work")
				Return
			End If
		End If

		MessageBox.Show(Me, "Response file has been saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)






	End Sub

	Private Sub Button9_Click_2(sender As System.Object, e As System.EventArgs) Handles Button9.Click

		If RTBResponses.Text <> "" Then
			MessageBox.Show(Me, "Template cannot be generated while there is text in the main Response window!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Dim TemplateDir As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\System\Template\Template.txt"

		If File.Exists(TemplateDir) Then

			Dim TempReader As New StreamReader(TemplateDir)
			Dim TempList As New List(Of String)

			While TempReader.Peek <> -1
				TempList.Add(TempReader.ReadLine())
			End While

			TempReader.Close()
			TempReader.Dispose()

			For i As Integer = 0 To TempList.Count - 1
				RTBResponses.Text = RTBResponses.Text & TempList(i) & Environment.NewLine
			Next

			For i As Integer = 0 To RTBResponses.Lines.Count - 1
				' If RTBResponses.Lines(i).Substring(0, 1) = "[" Then
				RTBResponses.SelectionStart = RTBResponses.Text.IndexOf(RTBResponses.Lines(i))
				RTBResponses.SelectionLength = RTBResponses.Lines(i).Length
				RTBResponses.SelectionFont = New Font(RTBResponses.SelectionFont, FontStyle.Bold)
				'End If
			Next

		Else
			MessageBox.Show(Me, "Template file was not found!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If


	End Sub

	Private Sub Button10_Click(sender As System.Object, e As System.EventArgs)

		For i As Integer = 0 To RTBResponses.Lines.Count - 1
			' If RTBResponses.Lines(i).Substring(0, 1) = "[" Then
			RTBResponses.SelectionStart = RTBResponses.Text.IndexOf(RTBResponses.Lines(i))
			RTBResponses.SelectionLength = RTBResponses.Lines(i).Length
			RTBResponses.SelectionFont = New Font(RTBResponses.SelectionFont, FontStyle.Bold)
			'End If
		Next

	End Sub



	Private Sub subAgeNumBox_MouseHover(sender As Object, e As System.EventArgs) Handles subAgeNumBox.MouseEnter
		TTDir.SetToolTip(subAgeNumBox, "Set your age.")
		'LBLSubSettingsDescription.Text = "Set your age."
	End Sub

	Private Sub NBBirthdayMonth_MouseHover(sender As Object, e As System.EventArgs) Handles NBBirthdayMonth.MouseEnter
		TTDir.SetToolTip(NBBirthdayMonth, "Set the month you were born.")
		'LBLSubSettingsDescription.Text = "Set the month you were born."
	End Sub

	Private Sub Birthday_MouseHover(sender As Object, e As System.EventArgs) Handles LBLSubBirthday.MouseHover
		TTDir.SetToolTip(LBLSubBirthday, "Set your birthday with the format mm/dd.")
		'LBLSubSettingsDescription.Text = "Set the day you were born."
	End Sub

	Private Sub NBBirthdayDay_MouseHover(sender As Object, e As System.EventArgs) Handles NBBirthdayDay.MouseEnter
		TTDir.SetToolTip(NBBirthdayDay, "Set the day you were born.")
		'LBLSubSettingsDescription.Text = "Set the day you were born."
	End Sub

	Private Sub TBSubHairColor_MouseHover(sender As Object, e As System.EventArgs) Handles TBSubHairColor.MouseHover
		TTDir.SetToolTip(TBSubHairColor, "Enter your hair color using all lower case letters.")
		'LBLSubSettingsDescription.Text = "Enter your hair color using all lower case letters."
	End Sub

	Private Sub TBSubEyeColor_MouseHover(sender As Object, e As System.EventArgs) Handles TBSubEyeColor.MouseHover
		TTDir.SetToolTip(TBSubEyeColor, "Enter your eye color using all lower case letters.")
		'LBLSubSettingsDescription.Text = "Enter your eye color using all lower case letters."
	End Sub

	Private Sub CockSizeNumBox_MouseHover(sender As Object, e As System.EventArgs) Handles CockSizeNumBox.MouseEnter
		TTDir.SetToolTip(CockSizeNumBox, "Set your cock size in inches.")
		'LBLSubSettingsDescription.Text = "Set your cock size in inches."
	End Sub

	Private Sub CBSubCircumcised_MouseHover(sender As Object, e As System.EventArgs) Handles CBSubCircumcised.MouseHover
		TTDir.SetToolTip(CBSubCircumcised, "Check this box if your cock is circumcised.")
		'LBLSubSettingsDescription.Text = "Check this box if your cock is circumcised."
	End Sub

	Private Sub CBSubPierced_MouseHover(sender As Object, e As System.EventArgs) Handles CBSubPierced.MouseHover
		TTDir.SetToolTip(CBSubPierced, "Check this box if your cock is pierced.")
		'LBLSubSettingsDescription.Text = "Check this box if your cock is pierced."
	End Sub

	Private Sub CBCBTCock_MouseHover(sender As Object, e As System.EventArgs) Handles CBCBTCock.MouseHover

		TTDir.SetToolTip(CBCBTCock, "Check this box to enable cock torture." & Environment.NewLine & Environment.NewLine &
									 "If this box is unchecked, the domme may still state that you're about to endure cock torture," & Environment.NewLine &
									 "but the program will simply move to the next line instead of making you perform it.")



		'LBLSubSettingsDescription.Text = "Check this box to enabled cock torture." & Environment.NewLine & Environment.NewLine & "If this box is unchecked, the domme may still state that you're about to endure" _
		' & " cock torture, but the program will simply move to the next line instead of making you perform it."
	End Sub

	Private Sub CBCBTBall_MouseHover(sender As Object, e As System.EventArgs) Handles CBCBTBalls.MouseHover

		TTDir.SetToolTip(CBCBTBalls, "Check this box to enable ball torture." & Environment.NewLine & Environment.NewLine &
								  "If this box is unchecked, the domme may still state that you're about to endure ball torture," & Environment.NewLine &
								  "but the program will simply move to the next line instead of making you perform it.")

		'LBLSubSettingsDescription.Text = "Check this box to enabled ball torture." & Environment.NewLine & Environment.NewLine & "If this box is unchecked, the domme may still state that you're about to endure" _
		'   & " ball torture, but the program will simply move to the next line instead of making you perform it."
	End Sub

	Private Sub CBTSlider_MouseHover(sender As Object, e As System.EventArgs) Handles CBTSlider.MouseHover

		TTDir.SetToolTip(CBTSlider, "This affects the severity of the CBT tasks you will be asked to perform." & Environment.NewLine & Environment.NewLine &
								  "The higher this slider, the more severe the tasks will be.")

		'LBLSubSettingsDescription.Text = "This affects the severity of the CBT tasks you will be asked to perform. The higher this slider, the more severe the tasks will be."
	End Sub

	Private Sub GBPerformance_MouseHover(sender As Object, e As System.EventArgs)
		LBLSubSettingsDescription.Text = "This area keeps track of several statistics related to your time with the program."
	End Sub

	Private Sub CBOwnChastity_MouseHover(sender As Object, e As System.EventArgs) Handles CBOwnChastity.MouseHover

		TTDir.SetToolTip(CBOwnChastity, "Check this box if you own a chastity device and wish to run scripts" & Environment.NewLine &
										"where the domme places you in chastity.")
		'LBLSubSettingsDescription.Text = "Check this box if you own a chastity device. This allows the program to use that fact in various scripts."
	End Sub

	Private Sub CBChastityPA_MouseHover(sender As Object, e As System.EventArgs) Handles CBChastityPA.MouseHover
		TTDir.SetToolTip(CBChastityPA, "Check this box if your chastity device requires a piercing.")
		'LBLSubSettingsDescription.Text = "Check this box if your chastity device requires a piercing."
	End Sub

	Private Sub CBChastitySpikes_MouseHover(sender As Object, e As System.EventArgs) Handles CBChastitySpikes.MouseHover

		TTDir.SetToolTip(CBChastitySpikes, "Check this box if your chastity device contains spikes.")
		'LBLSubSettingsDescription.Text = "Check this box if your chastity device contains spikes."

	End Sub

	Private Sub TBGreeting_MouseHover(sender As Object, e As System.EventArgs) Handles TBGreeting.MouseHover

		TTDir.SetToolTip(TBGreeting, "Enter any number of words or phrases, separated by commas." & Environment.NewLine & Environment.NewLine &
								  "When you use any of these words/phrases by themselves after starting the" & Environment.NewLine &
								  "program, the domme will recognize it as a greeting and begin the tease.")

		'LBLSubSettingsDescription.Text = "Enter any number of words or phrases, separated by commas. When you use any of these words/phrases by themselves after starting the program, " _
		'    & "the domme will recognize it as a greeting and begin the tease."
	End Sub

	Private Sub TBYes_MouseHover(sender As Object, e As System.EventArgs) Handles TBYes.MouseHover

		TTDir.SetToolTip(TBYes, "Enter any number of words or phrases, separated by commas." & Environment.NewLine & Environment.NewLine &
									"The domme will recognize these as ""yes"" answers to Multiple Choice sections.")

		' LBLSubSettingsDescription.Text = "Enter any number of words or phrases, separated by commas. The domme will recognize these as ""yes"" answers to Multiple Choice sections."
	End Sub

	Private Sub TBNo_MouseHover(sender As Object, e As System.EventArgs) Handles TBNo.MouseHover

		TTDir.SetToolTip(TBNo, "Enter any number of words or phrases, separated by commas." & Environment.NewLine & Environment.NewLine &
								 "The domme will recognize these as ""no"" answers to Multiple Choice sections.")

		'LBLSubSettingsDescription.Text = "Enter any number of words or phrases, separated by commas. The domme will recognize these as ""no"" answers to Multiple Choice sections."
	End Sub

	Private Sub TBHonorific_MouseHover(sender As Object, e As System.EventArgs) Handles TBHonorific.MouseHover

		TTDir.SetToolTip(TBHonorific, "Enter an honorific to use for the domme, such as Mistress, Goddess, Princess, etc.")

		'LBLSubSettingsDescription.Text = "Enter an honorific to use for the domme, such as Mistress, Goddess, Princess, etc."
	End Sub

	Private Sub CBHonorificInclude_MouseHover(sender As Object, e As System.EventArgs) Handles CBHonorificInclude.MouseHover

		TTDir.SetToolTip(CBHonorificInclude, "When this box is checked, the domme's honorific must be included with" & Environment.NewLine &
											 "greetings and yes or no responses used during multiple choice segments.")

		'LBLSubSettingsDescription.Text = "When this box is checked, the domme's honorific must be included with greetings and yes or no responses used during multiple choice segments."
	End Sub
	Private Sub CBHonorificCapitalized_MouseHover(sender As Object, e As System.EventArgs) Handles CBHonorificCapitalized.MouseHover

		TTDir.SetToolTip(CBHonorificCapitalized, "When this box is checked, the domme's honorific must be capitalized where it is required.")
		'LBLSubSettingsDescription.Text = "When this box is checked, the domme's honorific must be capitalized where it is required."
	End Sub

	Private Sub NBLongEdge_MouseHover(sender As Object, e As System.EventArgs) Handles NBLongEdge.MouseEnter
		LBLSubSettingsDescription.Text = "Sets how long (in seconds) it will take after being told to edge for the domme to believe you have been trying to reach the edge for too long."
	End Sub

	Private Sub CBEdgeUseAvg_LostFocus(sender As Object, e As System.EventArgs) Handles CBEdgeUseAvg.LostFocus
		My.Settings.CBEdgeUseAvg = CBEdgeUseAvg.Checked
		My.Settings.Save()
	End Sub
	Private Sub CBEdgeUseAvg_MouseHover(sender As Object, e As System.EventArgs) Handles CBEdgeUseAvg.MouseEnter
		LBLSubSettingsDescription.Text = "When this is checked, the domme will use the average amount of time it has historically taken you to reach the edge to decide when you have been trying to edge for too long."
	End Sub

	Private Sub CBLongEdgeTaunts_LostFocus(sender As Object, e As System.EventArgs) Handles CBLongEdgeTaunts.LostFocus
		My.Settings.CBLongEdgeTaunts = CBLongEdgeTaunts.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBLongEdgeTaunts_MouseHover(sender As Object, e As System.EventArgs) Handles CBLongEdgeTaunts.MouseEnter
		LBLSubSettingsDescription.Text = "When this box is checked, the domme will include edge taunts that are reserved for when the Long Edge threshold has been passed." & Environment.NewLine & Environment.NewLine &
			"This will allow the domme to tease you about the fact that you have been trying to edge for longer than she expected."
	End Sub

	Private Sub CBLongEdgeInterrupts_LostFocus(sender As Object, e As System.EventArgs) Handles CBLongEdgeInterrupts.LostFocus
		My.Settings.CBLongEdgeInterrupts = CBLongEdgeInterrupts.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBLongEdgeInterrupts_MouseHover(sender As Object, e As System.EventArgs) Handles CBLongEdgeInterrupts.MouseEnter
		LBLSubSettingsDescription.Text = "When this box is checked, the domme will include edge taunts that call special Interrupt scripts when the Long Edge threshold has been passed."
	End Sub

	Private Sub NBHOldTheEdgeMax_MouseHover(sender As Object, e As System.EventArgs) Handles NBHoldTheEdgeMax.MouseEnter
		LBLSubSettingsDescription.Text = "Sets the maximum time (in seconds) that the domme will make you hold the edge. If you enter 0 as an amount, then the domme will decide based on her level."
	End Sub

	Private Sub NBWritinGTaskMin_MouseHover(sender As Object, e As System.EventArgs) Handles NBWritingTaskMin.MouseEnter
		LBLSubSettingsDescription.Text = "Sets the minimum amount of lines the domme will assign you for writing tasks."
	End Sub
	Private Sub NBWritinGTaskMax_MouseHover(sender As Object, e As System.EventArgs) Handles NBWritingTaskMax.MouseEnter
		LBLSubSettingsDescription.Text = "Sets the maximum amount of lines the domme will assign you for writing tasks."
	End Sub
	'Private Sub SubDescText_MouseHover(sender As Object, e As System.EventArgs) Handles Panel2.MouseEnter, GroupBox32.MouseEnter, GroupBox45.MouseEnter, GroupBox35.MouseEnter, GroupBox7.MouseEnter, GroupBox12.MouseEnter
	'   LBLSubSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its function."
	'End Sub
	Private Sub CBHimHer_MouseHover(sender As Object, e As System.EventArgs) Handles CBHimHer.MouseEnter
		LBLSubSettingsDescription.Text = "When this is checked, Glitter will automatically replace any instance of He/Him/His with She/Her/Her."
	End Sub

	Private Sub NBNextImageChance_LostFocus(sender As Object, e As System.EventArgs) Handles NBNextImageChance.LostFocus
		My.Settings.NextImageChance = NBNextImageChance.Value
		My.Settings.Save()
	End Sub



	Private Sub orgasmsperlockButton_Click(sender As System.Object, e As System.EventArgs) Handles orgasmsperlockButton.Click

		If limitcheckbox.Checked = False Then
			MessageBox.Show(Me, "The Limit box must be checked before clicking this button!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Dim result As Integer


		If orgasmsPerNumBox.Value = 1 Then
			result = MessageBox.Show("This will limit you to 1 orgasm for the next " & LCase(orgasmsperComboBox.Text) & "." & Environment.NewLine & Environment.NewLine &
											   "Are you absolutely sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
		Else
			result = MessageBox.Show("This will limit you to " & orgasmsPerNumBox.Value & " orgasms for the next " & LCase(orgasmsperComboBox.Text) & "." & Environment.NewLine & Environment.NewLine &
														   "Are you absolutely sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
		End If


		If result = DialogResult.No Then
			Return
		End If

		If result = DialogResult.Yes Then

			My.Settings.OrgasmsRemaining = orgasmsPerNumBox.Value
			My.Settings.DomOrgasmPer = orgasmsPerNumBox.Value

			My.Settings.DomPerMonth = orgasmsperComboBox.Text

			Dim SetDate As Date = FormatDateTime(Now, DateFormat.ShortDate)

			Debug.Print(SetDate)


			If orgasmsperComboBox.Text = "Week" Then SetDate = DateAdd(DateInterval.Day, 7, SetDate)
			If orgasmsperComboBox.Text = "2 Weeks" Then SetDate = DateAdd(DateInterval.Day, 14, SetDate)
			If orgasmsperComboBox.Text = "Month" Then SetDate = DateAdd(DateInterval.Month, 1, SetDate)
			If orgasmsperComboBox.Text = "2 Months" Then SetDate = DateAdd(DateInterval.Month, 2, SetDate)
			If orgasmsperComboBox.Text = "3 Months" Then SetDate = DateAdd(DateInterval.Month, 3, SetDate)
			If orgasmsperComboBox.Text = "6 Months" Then SetDate = DateAdd(DateInterval.Month, 6, SetDate)
			If orgasmsperComboBox.Text = "9 Months" Then SetDate = DateAdd(DateInterval.Month, 9, SetDate)
			If orgasmsperComboBox.Text = "Year" Then SetDate = DateAdd(DateInterval.Year, 1, SetDate)
			If orgasmsperComboBox.Text = "2 Years" Then SetDate = DateAdd(DateInterval.Year, 2, SetDate)
			If orgasmsperComboBox.Text = "3 Years" Then SetDate = DateAdd(DateInterval.Year, 3, SetDate)
			If orgasmsperComboBox.Text = "5 Years" Then SetDate = DateAdd(DateInterval.Year, 5, SetDate)
			If orgasmsperComboBox.Text = "10 Years" Then SetDate = DateAdd(DateInterval.Year, 10, SetDate)
			If orgasmsperComboBox.Text = "25 Years" Then SetDate = DateAdd(DateInterval.Year, 25, SetDate)
			If orgasmsperComboBox.Text = "Lifetime" Then SetDate = DateAdd(DateInterval.Year, 100, SetDate)

			Debug.Print(SetDate)

			My.Settings.OrgasmLockDate = FormatDateTime(SetDate, DateFormat.ShortDate)
			Debug.Print(My.Settings.OrgasmLockDate)




			My.Settings.OrgasmsLocked = True

			limitcheckbox.Enabled = False
			orgasmsPerNumBox.Enabled = False
			orgasmsperComboBox.Enabled = False
			orgasmsperlockButton.Enabled = False
			orgasmlockrandombutton.Enabled = False


			My.Settings.Save()



		End If






	End Sub

	Private Sub orgasmlockrandombutton_Click(sender As System.Object, e As System.EventArgs) Handles orgasmlockrandombutton.Click

		If limitcheckbox.Checked = False Then
			MessageBox.Show(Me, "The Limit box must be checked before clicking this button!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Dim result As Integer

		result = MessageBox.Show("This will allow the domme to limit you to a random number of orgasms for a random amount of time. High level dommes could restrict you to a very low amount for up to a year!" & Environment.NewLine & Environment.NewLine &
										   "Are you absolutely sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

		If result = DialogResult.No Then
			Return
		End If

		If result = DialogResult.Yes Then

			Dim RandomOrgasms As Integer = Form1.randomizer.Next(1, 6)


			My.Settings.OrgasmsRemaining = RandomOrgasms
			My.Settings.DomOrgasmPer = RandomOrgasms

			orgasmsPerNumBox.Value = RandomOrgasms

			Dim RandomTime As Integer = Form1.randomizer.Next(1, 4)

			If domlevelNumBox.Value = 1 Then

				My.Settings.DomPerMonth = "Week"
				If RandomTime = 1 Then My.Settings.DomPerMonth = "Week"
				If RandomTime = 2 Then My.Settings.DomPerMonth = "2 Weeks"
				If RandomTime = 3 Then My.Settings.DomPerMonth = "Week"

			End If

			If domlevelNumBox.Value = 2 Then

				My.Settings.DomPerMonth = "2 Weeks"
				If RandomTime = 1 Then My.Settings.DomPerMonth = "2 Weeks"
				If RandomTime = 2 Then My.Settings.DomPerMonth = "2 Weeks"
				If RandomTime = 3 Then My.Settings.DomPerMonth = "Month"

			End If

			If domlevelNumBox.Value = 3 Then

				My.Settings.DomPerMonth = "Month"
				If RandomTime = 1 Then My.Settings.DomPerMonth = "2 Weeks"
				If RandomTime = 2 Then My.Settings.DomPerMonth = "Month"
				If RandomTime = 3 Then My.Settings.DomPerMonth = "2 Months"

			End If

			If domlevelNumBox.Value = 4 Then

				My.Settings.DomPerMonth = "3 Months"
				If RandomTime = 1 Then My.Settings.DomPerMonth = "2 Months"
				If RandomTime = 2 Then My.Settings.DomPerMonth = "3 Months"
				If RandomTime = 3 Then My.Settings.DomPerMonth = "6 Months"

			End If

			If domlevelNumBox.Value = 5 Then

				My.Settings.DomPerMonth = "6 Months"
				If RandomTime = 1 Then My.Settings.DomPerMonth = "6 Months"
				If RandomTime = 2 Then My.Settings.DomPerMonth = "9 Months"
				If RandomTime = 3 Then My.Settings.DomPerMonth = "Year"

			End If

			orgasmsperComboBox.Text = My.Settings.DomPerMonth

			Dim SetDate As Date = FormatDateTime(Now, DateFormat.ShortDate)

			If orgasmsperComboBox.Text = "Week" Then SetDate = DateAdd(DateInterval.Day, 7, SetDate)
			If orgasmsperComboBox.Text = "2 Weeks" Then SetDate = DateAdd(DateInterval.Day, 14, SetDate)
			If orgasmsperComboBox.Text = "Month" Then SetDate = DateAdd(DateInterval.Month, 1, SetDate)
			If orgasmsperComboBox.Text = "2 Months" Then SetDate = DateAdd(DateInterval.Month, 2, SetDate)
			If orgasmsperComboBox.Text = "3 Months" Then SetDate = DateAdd(DateInterval.Month, 3, SetDate)
			If orgasmsperComboBox.Text = "6 Months" Then SetDate = DateAdd(DateInterval.Month, 6, SetDate)
			If orgasmsperComboBox.Text = "9 Months" Then SetDate = DateAdd(DateInterval.Month, 9, SetDate)
			If orgasmsperComboBox.Text = "Year" Then SetDate = DateAdd(DateInterval.Year, 1, SetDate)
			If orgasmsperComboBox.Text = "2 Years" Then SetDate = DateAdd(DateInterval.Year, 2, SetDate)
			If orgasmsperComboBox.Text = "3 Years" Then SetDate = DateAdd(DateInterval.Year, 3, SetDate)
			If orgasmsperComboBox.Text = "5 Years" Then SetDate = DateAdd(DateInterval.Year, 5, SetDate)
			If orgasmsperComboBox.Text = "10 Years" Then SetDate = DateAdd(DateInterval.Year, 10, SetDate)
			If orgasmsperComboBox.Text = "25 Years" Then SetDate = DateAdd(DateInterval.Year, 25, SetDate)
			If orgasmsperComboBox.Text = "Lifetime" Then SetDate = DateAdd(DateInterval.Year, 100, SetDate)


			My.Settings.OrgasmLockDate = FormatDateTime(SetDate, DateFormat.ShortDate)
			Debug.Print(My.Settings.OrgasmLockDate)


			My.Settings.OrgasmsLocked = True

			limitcheckbox.Enabled = False
			orgasmsPerNumBox.Enabled = False
			orgasmsperComboBox.Enabled = False
			orgasmsperlockButton.Enabled = False
			orgasmlockrandombutton.Enabled = False

			My.Settings.Save()

		End If





	End Sub

	Private Sub CBVTType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBVTType.SelectedIndexChanged


		If CBVTType.Text = "Censorship Sucks" Then
			LBVidScript.Items.Clear()
			LBVidScript.Items.Add("CensorBarOff")
			LBVidScript.Items.Add("CensorBarOn")
		End If

		If CBVTType.Text = "Avoid The Edge" Then
			LBVidScript.Items.Clear()
			LBVidScript.Items.Add("Taunts")
		End If


		If CBVTType.Text = "Red Light Green Light" Then
			LBVidScript.Items.Clear()
			LBVidScript.Items.Add("Green Light")
			LBVidScript.Items.Add("Red Light")
			LBVidScript.Items.Add("Taunts")
		End If


	End Sub


	Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
		Form1.UpdatesTick = 3
	End Sub



	Private Sub NBTeaseLengthMin_MouseHover(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMin.MouseEnter
		LBLRangeSettingsDescription.Text = "Set the minimum amount of time the program will run before the domme decides if you can have an orgasm." & Environment.NewLine & Environment.NewLine &
			"The domme will not move to an End script until the first @End point of a Module that occurs after tease time expires." & Environment.NewLine & Environment.NewLine &
			"If the domme decides to tease you again, the tease time will be reset to a new amount based Tease Length settings."
	End Sub

	Private Sub NBTeaseLengthMax_MouseHover(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMax.MouseEnter
		LBLRangeSettingsDescription.Text = "Set the maximum amount of time the program will run before the domme decides if you can have an orgasm." & Environment.NewLine & Environment.NewLine &
			"The domme will not move to an End script until the first @End point of a Module that occurs after tease time expires." & Environment.NewLine & Environment.NewLine &
			"If the domme decides to tease you again, the tease time will be reset to a new amount based Tease Length settings."
	End Sub


	Private Sub CBTeaseLengthDD_LostFocus(sender As Object, e As System.EventArgs) Handles CBTeaseLengthDD.LostFocus
		My.Settings.CBTeaseLengthDD = CBTeaseLengthDD.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBTauntCycleDD_LostFocus(sender As Object, e As System.EventArgs) Handles CBTauntCycleDD.LostFocus
		My.Settings.CBTauntCycleDD = CBTauntCycleDD.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBTeaseLengthDD_MouseHover(sender As Object, e As System.EventArgs) Handles CBTeaseLengthDD.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows the domme to decide the length of the tease based on her level." & Environment.NewLine & Environment.NewLine &
			"A level 1 domme may tease you for 15-20 minutes, while a level 5 domme may tease you as long as an hour." & Environment.NewLine & Environment.NewLine &
			"The domme will not move to an End script until the first @End point of a Module that occurs after tease time expires."
	End Sub

	Private Sub NBTauntCycleMin_MouseHover(sender As Object, e As System.EventArgs) Handles NBTauntCycleMin.MouseEnter
		LBLRangeSettingsDescription.Text = "Set the minimum amount of time the domme will make you stroke during Taunt cycles."
	End Sub

	Private Sub NBTauntCycleMax_MouseHover(sender As Object, e As System.EventArgs) Handles NBTauntCycleMax.MouseEnter
		LBLRangeSettingsDescription.Text = "Set the maximum amount of time the domme will make you stroke during Taunt cycles"
	End Sub

	Private Sub CBTauntCycleDD_MouseHover(sender As Object, e As System.EventArgs) Handles CBTauntCycleDD.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows the domme to decide how long she makes you stroke during Taunt cycles based on her level." & Environment.NewLine & Environment.NewLine &
			"A level 1 domme may have you stroke for a couple minutes at a time, while a level 5 domme may have you stroke up to 10 minutes during each Taunt cycle."
	End Sub

	Private Sub SliderSTF_MouseHover(sender As Object, e As System.EventArgs) Handles SliderSTF.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows you to set the frequency of the domme's Stroke Taunts." & Environment.NewLine & Environment.NewLine &
			"A middle value tries to emulate an online experience as closely as possible. Use a higher value to increase the frequency of Taunts to something you would expect in a webtease. Use a lower value to simulate the domme being preoccupied or not that interested in engaging you."
	End Sub

	Private Sub TauntSlider_MouseHover(sender As Object, e As System.EventArgs) Handles TauntSlider.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows you to set the frequency of the domme's Taunts during Video Teases." & Environment.NewLine & Environment.NewLine &
			"A middle value creates a fairly common use of Taunts. Use a higher value to make the domme extremely engaged. Use a lower value to focus on the Video Tease with minimal interaction from the domme."
	End Sub

	Private Sub CBRangeOrgasm_MouseHover(sender As Object, e As System.EventArgs) Handles CBRangeOrgasm.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows the domme to decide what chance she will allow an orgasm based on her settings." & Environment.NewLine & Environment.NewLine &
			"Default settings are: Often Allows: 75% - Sometimes Allows: 50% - Rarely Allows: 20%"
	End Sub

	Private Sub NBAllowOften_MouseHover(sender As Object, e As System.EventArgs) Handles NBAllowOften.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will allow orgasm when she is set to ""Often Allows""."
	End Sub

	Private Sub NBAllowSometimes_MouseHover(sender As Object, e As System.EventArgs) Handles NBAllowSometimes.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will allow orgasm when she is set to ""Sometimes Allows""."
	End Sub

	Private Sub NBAllowRarely_MouseHover(sender As Object, e As System.EventArgs) Handles NBAllowRarely.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will allow orgasm when she is set to ""Rarely Allows""."
	End Sub

	Private Sub CBRangeRuin_MouseHover(sender As Object, e As System.EventArgs) Handles CBRangeRuin.MouseEnter
		LBLRangeSettingsDescription.Text = "This allows the domme to decide what chance she will ruin an orgasm based on her settings." & Environment.NewLine & Environment.NewLine &
			"Default settings are: Often Ruins: 75% - Sometimes Ruins: 50% - Rarely Ruins: 20%"
	End Sub

	Private Sub NBRuinOften_MouseHover(sender As Object, e As System.EventArgs) Handles NBRuinOften.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will ruin an orgasm when she is set to ""Often Ruins""."
	End Sub

	Private Sub NBRuinSometimes_MouseHover(sender As Object, e As System.EventArgs) Handles NBRuinSometimes.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will ruin an orgasm when she is set to ""Sometimes Ruins""."
	End Sub

	Private Sub NBRuinRarely_MouseHover(sender As Object, e As System.EventArgs) Handles NBRuinRarely.MouseEnter
		LBLRangeSettingsDescription.Text = "When ""Domme Decide"" is not checked, this allows you to set what chance the domme will ruin an orgasm when she is set to ""Rarely Ruins""."
	End Sub


	Private Sub NBNextImageChance_MouseHover(sender As Object, e As System.EventArgs) Handles NBNextImageChance.MouseEnter
		LBLRangeSettingsDescription.Text = "When running a slideshow with the ""Tease"" option selected, this value determines what chance the slideshow will move forward instead of backward."
	End Sub

	Private Sub nbcensorshowmin_MouseHover(sender As Object, e As System.EventArgs) Handles NBCensorShowMin.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the minimum amount of time the censor bar will be on the screen at a time while playing Censorship Sucks."
	End Sub

	Private Sub nbcensorshowmax_MouseHover(sender As Object, e As System.EventArgs) Handles NBCensorShowMax.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the maximum amount of time the censor bar will be on the screen at a time while playing Censorship Sucks."
	End Sub

	Private Sub nbcensorhidemin_MouseHover(sender As Object, e As System.EventArgs) Handles NBCensorHideMin.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the minimum amount of time the censor bar will be invisible while playing Censorship Sucks."
	End Sub

	Private Sub nbcensorhidemax_MouseHover(sender As Object, e As System.EventArgs) Handles NBCensorHideMax.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the maximum amount of time the censor bar will be invisible while playing Censorship Sucks."
	End Sub

	Private Sub cbcensorconstant_MouseHover(sender As Object, e As System.EventArgs) Handles CBCensorConstant.MouseEnter
		LBLRangeSettingsDescription.Text = "When this is checked, the censor bar will always be visible while playing Censorship Sucks. Its position on the screen will still change in time with Show Censor Bar settings."
	End Sub

	Private Sub nbredlightmin_MouseHover(sender As Object, e As System.EventArgs) Handles NBRedLightMin.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the minimum amount of time the domme will keep the video paused while playing Red Light Green Light."
	End Sub

	Private Sub nbredlightmax_MouseHover(sender As Object, e As System.EventArgs) Handles NBRedLightMax.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the maximum amount of time the domme will keep the video paused while playing Red Light Green Light."
	End Sub

	Private Sub nbgreenlightmin_MouseHover(sender As Object, e As System.EventArgs) Handles NBGreenLightMin.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the minimum amount of time the domme will keep the video playing while playing Red Light Green Light."
	End Sub

	Private Sub nbgreenlightmax_MouseHover(sender As Object, e As System.EventArgs) Handles NBGreenLightMax.MouseEnter
		LBLRangeSettingsDescription.Text = "This determines the maximum amount of time the domme will keep the video playing while playing Red Light Green Light."
	End Sub

	Private Sub RangeSet_MouseHover(sender As Object, e As System.EventArgs) Handles Panel6.MouseEnter, GroupBox21.MouseEnter, GroupBox18.MouseEnter, GroupBox19.MouseEnter, GroupBox10.MouseEnter, GroupBox56.MouseEnter, GroupBox52.MouseEnter, GroupBox57.MouseEnter
		LBLRangeSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its function."
	End Sub



	Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBWishlistURL.TextChanged
		Try
			WishlistPreview.Image.Dispose()
		Catch
		End Try
		WishlistPreview.Image = Nothing
		GC.Collect()
		Try
			WishlistPreview.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(TBWishlistURL.Text)))
		Catch
			MessageBox.Show(Me, "Failed to load Wishlist preview image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub

	Private Sub radioGold_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioGold.CheckedChanged
		WishlistCostGold.Visible = True
		WishlistCostSilver.Visible = False
	End Sub

	Private Sub radioSilver_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioSilver.CheckedChanged
		WishlistCostGold.Visible = False
		WishlistCostSilver.Visible = True
	End Sub

	Private Sub TBWishlistItem_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBWishlistItem.TextChanged
		LBLWishListName.Text = TBWishlistItem.Text
	End Sub

	Private Sub NBWishlistCost_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBWishlistCost.ValueChanged
		LBLWishlistCost.Text = NBWishlistCost.Value
	End Sub

	Private Sub TBWishlistComment_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBWishlistComment.TextChanged
		LBLWishListText.Text = TBWishlistComment.Text
	End Sub

	Private Sub BTNWishlistCreate_Click(sender As System.Object, e As System.EventArgs) Handles BTNWishlistCreate.Click

		If TBWishlistItem.Text = "" Then
			MessageBox.Show(Me, "Please enter a name for this item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		Try
			WishlistPreview.Image.Dispose()
		Catch
		End Try

		WishlistPreview.Image = Nothing
		GC.Collect()



		Try
			WishlistPreview.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(TBWishlistURL.Text)))
		Catch ex As Exception
			MessageBox.Show(Me, "Tease AI cannot locate the image URL provided! Please make sure it is a valid address and you are connected to the internet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End Try

		If TBWishlistComment.Text = "" Then
			MessageBox.Show(Me, "Please enter a comment for this item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		Try
			Dim WishDir As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Wishlist\Items\" & TBWishlistItem.Text & ".txt"

			If File.Exists(WishDir) Then My.Computer.FileSystem.DeleteFile(WishDir)

			My.Computer.FileSystem.WriteAllText(WishDir, TBWishlistItem.Text, True)
			My.Computer.FileSystem.WriteAllText(WishDir, Environment.NewLine, True)
			My.Computer.FileSystem.WriteAllText(WishDir, TBWishlistURL.Text, True)
			My.Computer.FileSystem.WriteAllText(WishDir, Environment.NewLine, True)
			Dim WishCost As String
			If radioSilver.Checked = True Then
				WishCost = NBWishlistCost.Value & " Silver"
			Else
				WishCost = NBWishlistCost.Value & " Gold"
			End If
			My.Computer.FileSystem.WriteAllText(WishDir, WishCost, True)
			My.Computer.FileSystem.WriteAllText(WishDir, Environment.NewLine, True)
			My.Computer.FileSystem.WriteAllText(WishDir, TBWishlistComment.Text, True)

			MessageBox.Show(Me, "Wishlist file saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch
			MessageBox.Show(Me, "There was a problem saving this file.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try

	End Sub

	Private Sub CBOwnChastity_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBOwnChastity.CheckedChanged

		CBChastityPA.Enabled = CBOwnChastity.Checked
		CBChastitySpikes.Enabled = CBOwnChastity.Checked

	End Sub

	Private Sub CBOwnChastity_LostFocus(sender As Object, e As System.EventArgs) Handles CBOwnChastity.LostFocus
		My.Settings.CBOwnChastity = CBOwnChastity.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBChastityPA_LostFocus(sender As Object, e As System.EventArgs) Handles CBChastityPA.LostFocus
		My.Settings.ChastityPA = CBChastityPA.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBChastitySpikes_LostFocus(sender As Object, e As System.EventArgs) Handles CBChastitySpikes.LostFocus
		My.Settings.ChastitySpikes = CBChastitySpikes.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBIncludeGifs_LostFocus(sender As Object, e As System.EventArgs) Handles CBIncludeGifs.LostFocus
		My.Settings.CBIncludeGifs = CBIncludeGifs.Checked
		My.Settings.Save()

	End Sub

	Private Sub CBMetronome_CheckedChanged(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

	End Sub



	Private Sub CBHimHer_LostFocus(sender As Object, e As System.EventArgs) Handles CBHimHer.LostFocus
		My.Settings.CBHimHer = CBHimHer.Checked
		My.Settings.Save()

	End Sub

	Private Sub CBSettingsPause_CheckedChanged(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CBSettingsPause.MouseClick

	End Sub

	Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBDomDel.CheckedChanged

	End Sub


	Private Sub CBDomDel_LostFocus(sender As Object, e As System.EventArgs) Handles CBDomDel.LostFocus
		My.Settings.DomDeleteMedia = CBDomDel.Checked
		My.Settings.Save()
	End Sub




	Private Sub BTNMaintenance_Click(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceRebuild.Click

		CancelRebuild = False
		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False
		BTNMaintenanceValidate.Enabled = False
		BTNMaintenanceCancel.Enabled = True

		BWRebuildURLFiles.RunWorkerAsync()



	End Sub

	Private Sub BTNMaintenanceRefresh_Click(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceRefresh.Click

		CancelRebuild = False
		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False
		BTNMaintenanceValidate.Enabled = False
		BTNMaintenanceCancel.Enabled = True

		BWRefreshURLFiles.RunWorkerAsync()

	End Sub

	Private Sub BTNMaintenanceValidate_Click(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceValidate.Click
		CancelRebuild = False
		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False
		BTNMaintenanceValidate.Enabled = False
		BTNMaintenanceCancel.Enabled = True

		BWValidateLocalFiles.RunWorkerAsync()
	End Sub

	Private Sub BWCreateFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWCreateURLFiles.DoWork


		Control.CheckForIllegalCrossThreadCalls = False

		Thr = New Threading.Thread(New Threading.ThreadStart(AddressOf CreateURLFiles))
		Thr.SetApartmentState(ApartmentState.STA)
		Thr.Start()

	End Sub

	Private Sub BWRefreshURLFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWRefreshURLFiles.DoWork


		Control.CheckForIllegalCrossThreadCalls = False

		Thr = New Threading.Thread(New Threading.ThreadStart(AddressOf CombineURLFiles))
		Thr.SetApartmentState(ApartmentState.STA)
		Thr.Start()

	End Sub



	Private Sub BWRebuildURLFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWRebuildURLFiles.DoWork


		Control.CheckForIllegalCrossThreadCalls = False

		Thr = New Threading.Thread(New Threading.ThreadStart(AddressOf RebuildURLs))
		Thr.SetApartmentState(ApartmentState.STA)
		Thr.Start()

	End Sub


	Private Sub BWValidateLocalFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWValidateLocalFiles.DoWork


		Control.CheckForIllegalCrossThreadCalls = False

		Thr = New Threading.Thread(New Threading.ThreadStart(AddressOf VerifyLocalImagePaths))
		Thr.SetApartmentState(ApartmentState.STA)
		Thr.Start()

	End Sub

	Public Sub RebuildURLs()

		Dim NewURLCount As Integer



		Dim MaintString As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
		MaintString = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files")

		Dim MaintCount As Integer = CStr(MaintString.Count)
		PBMaintenance.Maximum = MaintCount
		PBMaintenance.Value = 0





		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\URL Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

			If CancelRebuild = True Then
				PBMaintenance.Value = 0
				PBCurrent.Value = 0
				LBLMaintenance.Text = ""
				CancelRebuild = False
				BTNMaintenanceRebuild.Enabled = True
				BTNMaintenanceCancel.Enabled = False
				BTNMaintenanceRefresh.Enabled = True
				BTNMaintenanceValidate.Enabled = True
				Return
			End If

			PBCurrent.Value = 0


			Debug.Print("FoundFile = " & foundFile)

			Dim FirstPass As Boolean = False
			Dim ExactPostsCount As Integer
			Dim PostsInt As Integer = 0
			Dim ImageAdded As Boolean
			Dim BlogCycle As Integer
			BlogCycle = -50

			NewURLCount = 0

			Dim BlogListOld As New List(Of String)
			Dim BlogListNew As New List(Of String)

			Dim ImageBlogUrl As String = foundFile.Replace(Application.StartupPath & "\Images\System\URL Files\", "")
			Dim BlogUrlInfo As String = ImageBlogUrl

			ImageBlogUrl = ImageBlogUrl.Replace(".txt", "")
			ImageBlogUrl = "http://" & ImageBlogUrl


			Dim req As System.Net.WebRequest
			Dim res As System.Net.WebResponse

			req = System.Net.WebRequest.Create(ImageBlogUrl)

			Try
				res = req.GetResponse()
			Catch w As WebException
				GoTo NextURL
			End Try

			Dim ModifiedUrl As String
			ModifiedUrl = ImageBlogUrl
			ModifiedUrl = ModifiedUrl.Replace("http://", "")
			ModifiedUrl = ModifiedUrl.Replace("/", "")

			Dim ImageURLPath As String = Application.StartupPath & "\Images\System\URL Files\" & ModifiedUrl & ".txt"



			Dim DupeList As New List(Of String)
			DupeList.Clear()

			Dim DislikeList As New List(Of String)
			DislikeList.Clear()

			If File.Exists(foundFile) Then

				My.Computer.FileSystem.CopyFile(foundFile, foundFile & ".bak", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)


				Dim DupeCheck As New StreamReader(foundFile)

				While DupeCheck.Peek <> -1
					DupeList.Add(DupeCheck.ReadLine())
				End While

				DupeCheck.Close()
				DupeCheck.Dispose()
				My.Computer.FileSystem.DeleteFile(foundFile)
			End If





			If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
				Dim DislikeCheck As New StreamReader(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")

				While DislikeCheck.Peek <> -1
					DislikeList.Add(DislikeCheck.ReadLine())
				End While

				DislikeCheck.Close()
				DislikeCheck.Dispose()

			End If



Scrape:





			ImageAdded = False

			BlogCycle += 50



			If Form1.WIExit = True Then GoTo ExitScrape

			Dim doc As XmlDocument = New XmlDocument()

			Try
				ImageBlogUrl = ImageBlogUrl.Replace("/", "")
				ImageBlogUrl = ImageBlogUrl.Replace("http:", "http://")
				Debug.Print("ImageBlogURL = " & ImageBlogUrl)
				doc.Load(ImageBlogUrl & "/api/read?start=" & BlogCycle & "&num=50")
			Catch ex As Exception
			End Try

			If FirstPass = False Then
				Try
					For Each node As XmlNode In doc.DocumentElement.SelectNodes("//posts")
						Dim PostsCount As Integer = node.Attributes.ItemOf("total").InnerText
						ExactPostsCount = PostsCount
						PBCurrent.Maximum = ExactPostsCount
						PostsCount = RoundUpToNearest(PostsCount, 50)
						Debug.Print("PostsCount = " & PostsCount)
					Next
					LBLMaintenance.Text = "Validating URL Files" & Environment.NewLine & Path.GetFileName(foundFile)
					FirstPass = True
				Catch
					FirstPass = False
					GoTo NextURL
				End Try
			End If




			For Each node As XmlNode In doc.DocumentElement.SelectNodes("//photo-url")
				Application.DoEvents()
				If Form1.WIExit = True Then GoTo ExitScrape
				If node.Attributes.ItemOf("max-width").InnerText = 1280 Then
					PostsInt += 1
					ImageAdded = True

					If PBCurrent.Value < PBCurrent.Maximum Then PBCurrent.Value += 1



					If BlogListNew.Contains(node.InnerXml) Then
						'MsgBox(node.InnerXml & " ALREADY HAS!")
						GoTo AlreadyHas
					End If

					NewURLCount += 1



					Try
						BlogListNew.Add(node.InnerXml)

					Catch
						GoTo ExitScrape
					End Try
					If PBCurrent.Value >= PBCurrent.Maximum Then GoTo ExitScrape

AlreadyHas:

					Form1.ApproveImage = 0

				End If

				If CancelRebuild = True Then
					PBMaintenance.Value = 0
					PBCurrent.Value = 0
					LBLMaintenance.Text = ""
					CancelRebuild = False

					If File.Exists(foundFile & ".bak") Then
						My.Computer.FileSystem.CopyFile(foundFile & ".bak", foundFile, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
						My.Computer.FileSystem.DeleteFile(foundFile & ".bak")
					End If

					BTNMaintenanceRebuild.Enabled = True
					BTNMaintenanceCancel.Enabled = False
					BTNMaintenanceRefresh.Enabled = True
					BTNMaintenanceValidate.Enabled = True

					Return
				End If

			Next



			If ImageAdded = True Then GoTo Scrape

ExitScrape:


			Form1.WIExit = False



			If File.Exists(ImageURLPath) Then My.Computer.FileSystem.DeleteFile(ImageURLPath)

			Dim BlogCombine As New List(Of String)

			For i As Integer = 0 To BlogListNew.Count - 1
				BlogCombine.Add(BlogListNew(i))
				'Debug.Print("BLN " & i & ": " & BlogListNew(i))
			Next




			Dim fs As New FileStream(ImageURLPath, FileMode.Create)
			Dim sw As New StreamWriter(fs)
			For i As Integer = 0 To BlogCombine.Count - 1
				If i <> BlogCombine.Count - 1 Then
					sw.WriteLine(BlogCombine(i))
				Else
					sw.Write(BlogCombine(i))
				End If
			Next
			sw.Close()
			sw.Dispose()
			fs.Close()
			fs.Dispose()




			' For i As Integer = 0 To BlogCombine.Count - 1
			'If Not i = BlogCombine.Count - 1 Then
			'My.Computer.FileSystem.WriteAllText(ImageURLPath, BlogCombine(i) & Environment.NewLine, True)
			';Else
			'My.Computer.FileSystem.WriteAllText(ImageURLPath, BlogCombine(i), True)
			'End If
			' Debug.Print(BlogCombine(i))
			'Next

			If Not URLFileList.Items.Contains(ModifiedUrl) Then
				URLFileList.Items.Add(ModifiedUrl)
				For i As Integer = 0 To URLFileList.Items.Count - 1
					If URLFileList.Items(i) = ModifiedUrl Then URLFileList.SetItemChecked(i, True)
				Next
			End If

			Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
			Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
			For i = 0 To URLFileList.Items.Count - 1
				BinaryWriter.Write(CStr(URLFileList.Items(i)))
				BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
			Next
			BinaryWriter.Close()
			FileStream.Dispose()


			FirstPass = False

			PBMaintenance.Value += 1

			If File.Exists(foundFile & ".bak") Then My.Computer.FileSystem.DeleteFile(foundFile & ".bak")

NextURL:
		Next

		PBMaintenance.Value = PBMaintenance.Maximum

		MessageBox.Show(Me, "All URL Files have been rebuilt!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

		PBMaintenance.Value = 0
		PBCurrent.Value = 0


	End Sub

	Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceCancel.Click

		CancelRebuild = True


	End Sub


	Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceScripts.Click

		PBMaintenance.Maximum = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count +
			 My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count
		PBMaintenance.Value = 0
		Dim BlankAudit As Integer = 0
		Dim ErrorAudit As Integer = 0

		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False
		BTNMaintenanceValidate.Enabled = False

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")

			LBLMaintenance.Text = "Checking " & Path.GetFileName(foundFile) & "..."
			PBMaintenance.Value += 1
			Dim CheckFiles As String() = File.ReadAllLines(foundFile)

			Dim GoodLines As New List(Of String)

			For Each line As String In CheckFiles
				If Not line = "" Then
					GoodLines.Add(line)
				Else
					BlankAudit += 1
				End If
			Next

			For i As Integer = 0 To GoodLines.Count - 1
				If GoodLines(i).Contains(" ]") Then
					ErrorAudit += 1
					Do
						GoodLines(i) = GoodLines(i).Replace(" ]", "]")
					Loop Until Not GoodLines(i).Contains(" ]")
				End If
				If GoodLines(i).Contains("[ ") Then
					ErrorAudit += 1
					Do
						GoodLines(i) = GoodLines(i).Replace("[ ", "[")
					Loop Until Not GoodLines(i).Contains("[ ")
				End If
				If GoodLines(i).Contains(",,") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(",,", ",")
					Loop Until Not GoodLines(i).Contains(",,")
				End If
				If GoodLines(i).Contains(",]") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(",]", "]")
					Loop Until Not GoodLines(i).Contains(",]")
				End If
				If GoodLines(i).Contains(" ,") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(" ,", ",")
					Loop Until Not GoodLines(i).Contains(" ,")
				End If
				If foundFile.Contains("Suffering") Then Debug.Print(GoodLines(i))

				If GoodLines(i).Contains("@ShowBoobImage") Then
					ErrorAudit += 1
					GoodLines(i) = GoodLines(i).Replace("@ShowBoobImage", "@ShowBoobsImage")
				End If

			Next


			If Not foundFile.Contains("Received Files") Then

				Dim fs As New FileStream(foundFile, FileMode.Create)
				Dim sw As New StreamWriter(fs)


				For i As Integer = 0 To GoodLines.Count - 1
					If i <> GoodLines.Count - 1 Then
						sw.WriteLine(GoodLines(i))
					Else
						sw.Write(GoodLines(i))
					End If
				Next


				sw.Close()
				sw.Dispose()

				fs.Close()
				fs.Dispose()

			End If

		Next




		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt")

			LBLMaintenance.Text = "Checking " & Path.GetFileName(foundFile) & "..."
			PBMaintenance.Value += 1
			Dim CheckFiles As String() = File.ReadAllLines(foundFile)

			Dim GoodLines As New List(Of String)

			For Each line As String In CheckFiles
				If Not line = "" Then
					GoodLines.Add(line)
				Else
					BlankAudit += 1
				End If
			Next

			Dim fs As New FileStream(foundFile, FileMode.Create)
			Dim sw As New StreamWriter(fs)


			For i As Integer = 0 To GoodLines.Count - 1
				If i <> GoodLines.Count - 1 Then
					sw.WriteLine(GoodLines(i))
				Else
					sw.Write(GoodLines(i))
				End If
			Next

			sw.Close()
			sw.Dispose()

			fs.Close()
			fs.Dispose()

		Next


		Debug.Print("done")

		' Github Patch
		MessageBox.Show(If(Me.Visible, Me, FrmSplash), PBMaintenance.Maximum & " scripts have been audited." & Environment.NewLine & Environment.NewLine &
						"Blank lines cleared: " & BlankAudit & Environment.NewLine & Environment.NewLine &
						"Script errors corrected: " & ErrorAudit, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

		PBMaintenance.Value = 0

		LBLMaintenance.Text = ""

		BTNMaintenanceRebuild.Enabled = True
		BTNMaintenanceRefresh.Enabled = True
		BTNMaintenanceValidate.Enabled = True


	End Sub

	Public Sub AuditScripts()

		PBMaintenance.Maximum = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count +
	   My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count
		PBMaintenance.Value = 0
		Dim BlankAudit As Integer = 0
		Dim ErrorAudit As Integer = 0

		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False
		BTNMaintenanceValidate.Enabled = False

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")

			LBLMaintenance.Text = "Checking " & Path.GetFileName(foundFile) & "..."
			PBMaintenance.Value += 1
			Dim CheckFiles As String() = File.ReadAllLines(foundFile)

			Dim GoodLines As New List(Of String)

			For Each line As String In CheckFiles
				If Not line = "" Then
					GoodLines.Add(line)
				Else
					BlankAudit += 1
				End If
			Next

			For i As Integer = 0 To GoodLines.Count - 1
				If GoodLines(i).Contains(" ]") Then
					ErrorAudit += 1
					Do
						GoodLines(i) = GoodLines(i).Replace(" ]", "]")
					Loop Until Not GoodLines(i).Contains(" ]")
				End If
				If GoodLines(i).Contains("[ ") Then
					ErrorAudit += 1
					Do
						GoodLines(i) = GoodLines(i).Replace("[ ", "[")
					Loop Until Not GoodLines(i).Contains("[ ")
				End If
				If GoodLines(i).Contains(",,") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(",,", ",")
					Loop Until Not GoodLines(i).Contains(",,")
				End If
				If GoodLines(i).Contains(",]") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(",]", "]")
					Loop Until Not GoodLines(i).Contains(",]")
				End If
				If GoodLines(i).Contains(" ,") Then
					ErrorAudit += 1
					Do

						GoodLines(i) = GoodLines(i).Replace(" ,", ",")
					Loop Until Not GoodLines(i).Contains(" ,")
				End If
				If foundFile.Contains("Suffering") Then Debug.Print(GoodLines(i))

				If GoodLines(i).Contains("@ShowBoobImage") Then
					ErrorAudit += 1
					GoodLines(i) = GoodLines(i).Replace("@ShowBoobImage", "@ShowBoobsImage")
				End If

			Next




			Dim fs As New FileStream(foundFile, FileMode.Create)
			Dim sw As New StreamWriter(fs)


			For i As Integer = 0 To GoodLines.Count - 1
				If i <> GoodLines.Count - 1 Then
					sw.WriteLine(GoodLines(i))
				Else
					sw.Write(GoodLines(i))
				End If
			Next


			sw.Close()
			sw.Dispose()

			fs.Close()
			fs.Dispose()

		Next


		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt")

			LBLMaintenance.Text = "Checking " & Path.GetFileName(foundFile) & "..."
			PBMaintenance.Value += 1
			Dim CheckFiles As String() = File.ReadAllLines(foundFile)

			Dim GoodLines As New List(Of String)

			For Each line As String In CheckFiles
				If Not line = "" Then
					GoodLines.Add(line)
				Else
					BlankAudit += 1
				End If
			Next

			Dim fs As New FileStream(foundFile, FileMode.Create)
			Dim sw As New StreamWriter(fs)


			For i As Integer = 0 To GoodLines.Count - 1
				If i <> GoodLines.Count - 1 Then
					sw.WriteLine(GoodLines(i))
				Else
					sw.Write(GoodLines(i))
				End If
			Next

			sw.Close()
			sw.Dispose()

			fs.Close()
			fs.Dispose()

		Next


		Debug.Print("done")

		MessageBox.Show(Me, PBMaintenance.Maximum & " scripts have been audited." & Environment.NewLine & Environment.NewLine &
						"Blank lines cleared: " & BlankAudit & Environment.NewLine & Environment.NewLine &
						"Script errors corrected: " & ErrorAudit, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

		PBMaintenance.Value = 0

		LBLMaintenance.Text = ""

		BTNMaintenanceRebuild.Enabled = True
		BTNMaintenanceRefresh.Enabled = True
		BTNMaintenanceValidate.Enabled = True

	End Sub

	Private Sub TBWebStart_LostFocus(sender As Object, e As System.EventArgs) Handles TBWebStart.LostFocus
		My.Settings.WebToyStart = TBWebStart.Text
	End Sub

	Private Sub TBWebStop_LostFocus(sender As Object, e As System.EventArgs) Handles TBWebStop.LostFocus
		My.Settings.WebToyStop = TBWebStop.Text
	End Sub

	Private Sub Button3_Click_2(sender As System.Object, e As System.EventArgs) Handles Button3.Click

		Process.Start(Application.StartupPath & "\Images\Session Images\")

	End Sub

	Public Sub CalculateSessionImages()

		Dim SesImgCount As Integer = 0
		Dim SesImgSpace As Long = 0


		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\Session Images\", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
			SesImgCount += 1
			SesImgSpace += My.Computer.FileSystem.GetFileInfo(foundFile).Length
		Next



		LBLSesFiles.Text = SesImgCount
		LBLSesSpace.Text = FormatBytes(SesImgSpace)

	End Sub


	Private Function FormatBytes(ByVal Bytes As Long) As String
		Try
			Dim dblBytes As Double = Bytes
			Dim Size As String() = {"bytes", "KB", "MB", "GB", "TB", "PB"}
			Dim SizeCounter As Integer = 0
			While dblBytes > 768
				dblBytes = dblBytes / 1024
				SizeCounter += 1
			End While
			dblBytes = CType(CType(dblBytes * 100, Integer), Double) * 0.01
			Return dblBytes.ToString & " " & Size(SizeCounter)
		Catch ex As Exception
			Return Bytes.ToString
		End Try
	End Function

	Private Sub Button6_Click_2(sender As System.Object, e As System.EventArgs) Handles Button6.Click

		Dim result As Integer = MessageBox.Show("This will permanently delete all files in the Session Images folder." & Environment.NewLine & Environment.NewLine &
												"Are you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
		If result = DialogResult.No Then

		ElseIf result = DialogResult.Yes Then
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\Session Images\", Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.*")

				My.Computer.FileSystem.DeleteFile(foundFile)

			Next

			CalculateSessionImages()
		End If




	End Sub






	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

		Dim result As Integer = MessageBox.Show("This will permanently reset all saved Tease AI settings back to their default value!" & Environment.NewLine & Environment.NewLine &
											  "Are you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
		If result = DialogResult.No Then

		ElseIf result = DialogResult.Yes Then
			My.Settings.Reset()
			MessageBox.Show(Me, "Tease AI settings have been reverted back to default values.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If

	End Sub

	Private Sub CBCockToClit_LostFocus(sender As Object, e As System.EventArgs) Handles CBCockToClit.LostFocus
		My.Settings.CockToClit = CBCockToClit.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBBallsToPussy_LostFocus(sender As Object, e As System.EventArgs) Handles CBBallsToPussy.LostFocus
		My.Settings.BallsToPussy = CBBallsToPussy.Checked
		My.Settings.Save()
	End Sub

	Private Sub CBCockToClit_MouseHover(sender As Object, e As System.EventArgs) Handles CBCockToClit.MouseEnter
		LBLSubSettingsDescription.Text = "When this box is checked, the domme will replace #Cock with a Keyword for ""clit"" when it appears in a script" & Environment.NewLine & Environment.NewLine &
			"She will also replace the word ""stroking"" with words like ""rubbing, fingering, teasing"" etc."
	End Sub

	Private Sub CBBallsToPussy_MouseHover(sender As Object, e As System.EventArgs) Handles CBBallsToPussy.MouseEnter
		LBLSubSettingsDescription.Text = "When this box is checked, the domme will replace #Balls with a Keyword for ""pussy"" when it appears in a script" & Environment.NewLine & Environment.NewLine &
			"She will also replace ""those #Balls"" with ""that pussy"" to make the exchange more natural."
	End Sub

	Private Sub LBPlaylist_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LBPlaylist.DragDrop

		Debug.Print("Playlist DragDrop called? called?")
		If FrmSettingsLoading = True Then Return

		Dim LBPlaylistString As String = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
		LBPlaylistString = Path.GetFileName(LBPlaylistString).Replace(".txt", "")
		If RadioPlaylistRegScripts.Checked = True Then
			LBPlaylist.Items.Add(LBPlaylistString & " Regular-TeaseAI-Script")
		Else
			LBPlaylist.Items.Add(LBPlaylistString)
		End If

		ProcessPlaylist()


	End Sub

	Private Sub LBPlaylist_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LBPlaylist.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Function Txt2List(ByVal GetText As String) As List(Of String)
		If File.Exists(GetText) Then
			Dim TextReader As New StreamReader(GetText)
			Dim TextList As New List(Of String)
			TextList.Clear()
			While TextReader.Peek <> -1
				TextList.Add(TextReader.ReadLine())
			End While
			TextReader.Close()
			TextReader.Dispose()
			Return TextList
		End If
	End Function


	Private Function StripBlankLines(ByVal SpaceClean As List(Of String)) As List(Of String)
		For i As Integer = SpaceClean.Count - 1 To 0 Step -1
			If SpaceClean(i) = "" Then SpaceClean.Remove(SpaceClean(i))
		Next
		Return SpaceClean
	End Function



	Private Sub BTNPlaylistEnd_Click(sender As System.Object, e As System.EventArgs) Handles BTNPlaylistEnd.Click

		Debug.Print("BTNPLaylistENd called?")
		If FrmSettingsLoading = True Or BTNPlaylistEnd.BackColor = Color.Blue Then Return

		If RadioPlaylistRegScripts.Checked = True Then
			WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End")
		Else
			WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\End\")
		End If
		LBLPlaylIstLink.Enabled = False
		LBLPlaylIstLink.ForeColor = Color.Black
		BTNPlaylistEnd.ForeColor = Color.White
		LBLPlaylIstLink.BackColor = Color.LightGray
		BTNPlaylistEnd.BackColor = Color.Blue
		Return
	End Sub

	Private Sub RadioPlaylistScripts_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioPlaylistScripts.CheckedChanged, RadioPlaylistRegScripts.CheckedChanged
		Debug.Print("Radio CHanged called?")
		If FrmSettingsLoading = True Or Form1.FormLoading = True Then Return
		Debug.Print("Radio CHanged accepted??")
		If LBLPLaylistStart.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
			End If
			Return
		End If

		If BTNPlaylistEnd.BackColor = Color.Blue Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\End\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\End\")
			End If
			Return
		End If

		If LBLPlaylistModule.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Modules\")
			End If
			Return
		End If

		If LBLPlaylIstLink.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Link\")
			End If
			Return
		End If


	End Sub

	Private Sub BTNPlaylistSave_Click(sender As System.Object, e As System.EventArgs) Handles BTNPlaylistSave.Click

		If TBPlaylistSave.Text = "" Or TBPlaylistSave.Text Is Nothing Then
			MessageBox.Show(Me, "Please enter a name for this Playlist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If
		If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\" & TBPlaylistSave.Text & ".txt") Then
			Dim result As Integer
			result = MessageBox.Show(TBPlaylistSave.Text & ".txt already exists!" & Environment.NewLine & Environment.NewLine & "Do you wish to overwrite this file?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If result = DialogResult.No Then
				Return
			End If
		End If

		Dim PlaylistList As New List(Of String)
		For i As Integer = 0 To LBPlaylist.Items.Count - 1
			PlaylistList.Add(LBPlaylist.Items(i))
		Next

		Try
			System.IO.File.WriteAllLines(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\" & TBPlaylistSave.Text & ".txt", PlaylistList)
			MessageBox.Show(Me, "Playlist file has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
			BTNPlaylistSave.Enabled = False
			LBPlaylist.Items.Clear()
			LBLPLaylistStart.Enabled = True
			LBLPLaylistStart.ForeColor = Color.White
			LBLPLaylistStart.BackColor = Color.Green
			BTNPlaylistCtrlZ.Enabled = False
			BTNPlaylistClearAll.Enabled = False
			If LBLPLaylistStart.Enabled = True Then
				If RadioPlaylistRegScripts.Checked = True Then
					WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\")
				Else
					WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
				End If
			End If
		Catch
			MessageBox.Show(Me, "Something went wrong and the Playlist file was not saved successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub BTNPlaylistClearAll_Click(sender As System.Object, e As System.EventArgs) Handles BTNPlaylistClearAll.Click

		LBPlaylist.Items.Clear()
		BTNPlaylistSave.Enabled = False
		TBPlaylistSave.Text = ""
		LBLPLaylistStart.Enabled = True
		LBLPLaylistStart.ForeColor = Color.White
		LBLPLaylistStart.BackColor = Color.Green
		LBLPlaylistModule.Enabled = False
		LBLPlaylistModule.ForeColor = Color.Black
		LBLPlaylistModule.BackColor = Color.LightGray
		LBLPlaylIstLink.Enabled = False
		LBLPlaylIstLink.ForeColor = Color.Black
		LBLPlaylIstLink.BackColor = Color.LightGray
		BTNPlaylistEnd.Enabled = False
		BTNPlaylistEnd.ForeColor = Color.Black
		BTNPlaylistEnd.BackColor = Color.LightGray
		BTNPlaylistCtrlZ.Enabled = False
		BTNPlaylistClearAll.Enabled = False
		If LBLPLaylistStart.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
			End If
		End If

	End Sub

	Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click

		If BTNPlaylistSave.Enabled = True Then Return

		If LBLPLaylistStart.Enabled = True Then
			LBPlaylist.Items.Add("Random Start")
			ProcessPlaylist()
			Return
		End If

		If LBLPlaylistModule.Enabled = True Then
			LBPlaylist.Items.Add("Random Module")
			ProcessPlaylist()
			Return
		End If

		If LBLPlaylIstLink.Enabled = True Then
			LBPlaylist.Items.Add("Random Link")
			ProcessPlaylist()
			Return
		End If

		If BTNPlaylistEnd.BackColor = Color.Blue Then
			LBPlaylist.Items.Add("Random End")
			ProcessPlaylist()
			Return
		End If

	End Sub


	Public Sub ProcessPlaylist()

		If BTNPlaylistEnd.BackColor = Color.Blue Then
			WBPlaylist.Navigate("about:blank")
			BTNPlaylistEnd.Enabled = False
			BTNPlaylistEnd.ForeColor = Color.Black
			BTNPlaylistEnd.BackColor = Color.LightGray
			BTNPlaylistSave.Enabled = True
			Return
		End If

		If LBLPLaylistStart.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Modules\")
			End If

			LBLPLaylistStart.Enabled = False
			LBLPlaylistModule.ForeColor = Color.White
			LBLPLaylistStart.ForeColor = Color.Black
			LBLPlaylistModule.BackColor = Color.Green
			LBLPLaylistStart.BackColor = Color.LightGray
			LBLPlaylistModule.Enabled = True
			BTNPlaylistCtrlZ.Enabled = True
			BTNPlaylistClearAll.Enabled = True
			Return
		End If

		If LBLPlaylistModule.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Link\")
			End If
			LBLPlaylistModule.Enabled = False
			LBLPlaylIstLink.Enabled = True
			BTNPlaylistEnd.Enabled = True
			LBLPlaylistModule.ForeColor = Color.Black
			LBLPlaylIstLink.ForeColor = Color.White
			BTNPlaylistEnd.ForeColor = Color.White
			LBLPlaylistModule.BackColor = Color.LightGray
			LBLPlaylIstLink.BackColor = Color.Green
			BTNPlaylistEnd.BackColor = Color.Green
			Return
		End If

		If LBLPlaylIstLink.Enabled = True Then
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Modules\")
			End If
			LBLPlaylIstLink.Enabled = False
			LBLPlaylistModule.Enabled = True
			BTNPlaylistEnd.Enabled = False
			LBLPlaylistModule.ForeColor = Color.White
			LBLPlaylIstLink.ForeColor = Color.Black
			BTNPlaylistEnd.ForeColor = Color.Black
			LBLPlaylistModule.BackColor = Color.Green
			LBLPlaylIstLink.BackColor = Color.LightGray
			BTNPlaylistEnd.BackColor = Color.LightGray
			Return
		End If

	End Sub

	Private Sub BTNPlaylistCtrlZ_Click(sender As System.Object, e As System.EventArgs) Handles BTNPlaylistCtrlZ.Click

		If BTNPlaylistEnd.BackColor = Color.Blue Then
			If BTNPlaylistSave.Enabled = True Then
				LBPlaylist.Items.RemoveAt(LBPlaylist.Items.Count - 1)
				BTNPlaylistSave.Enabled = False
			End If
		End If

		If BTNPlaylistEnd.BackColor = Color.Blue Then
			LBLPlaylIstLink.Enabled = True
			LBLPlaylIstLink.ForeColor = Color.White
			LBLPlaylIstLink.BackColor = Color.Green
			BTNPlaylistEnd.Enabled = True
			BTNPlaylistEnd.ForeColor = Color.White
			BTNPlaylistEnd.BackColor = Color.Green
			LBLPlaylistModule.Enabled = False
			LBLPlaylistModule.ForeColor = Color.Black
			LBLPlaylistModule.BackColor = Color.LightGray
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Link\")
			End If
			Return
		End If

		LBPlaylist.Items.RemoveAt(LBPlaylist.Items.Count - 1)

		If LBPlaylist.Items.Count = 0 Then
			LBLPLaylistStart.Enabled = True
			LBLPLaylistStart.ForeColor = Color.White
			LBLPLaylistStart.BackColor = Color.Green
			LBLPlaylistModule.Enabled = False
			LBLPlaylistModule.ForeColor = Color.Black
			LBLPlaylistModule.BackColor = Color.LightGray
			BTNPlaylistCtrlZ.Enabled = False
			BTNPlaylistClearAll.Enabled = False
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Start\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
			End If
			Return
		End If

		If LBLPlaylistModule.Enabled = True Then
			LBLPlaylIstLink.Enabled = True
			LBLPlaylIstLink.ForeColor = Color.White
			LBLPlaylIstLink.BackColor = Color.Green
			BTNPlaylistEnd.Enabled = True
			BTNPlaylistEnd.ForeColor = Color.White
			BTNPlaylistEnd.BackColor = Color.Green
			LBLPlaylistModule.Enabled = False
			LBLPlaylistModule.ForeColor = Color.Black
			LBLPlaylistModule.BackColor = Color.LightGray
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Stroke\Link\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Link\")
			End If
			Return
		End If

		If LBLPlaylIstLink.Enabled = True Then
			LBLPlaylistModule.Enabled = True
			LBLPlaylistModule.ForeColor = Color.White
			LBLPlaylistModule.BackColor = Color.Green
			BTNPlaylistEnd.Enabled = False
			BTNPlaylistEnd.ForeColor = Color.Black
			BTNPlaylistEnd.BackColor = Color.LightGray
			LBLPlaylIstLink.Enabled = False
			LBLPlaylIstLink.ForeColor = Color.Black
			LBLPlaylIstLink.BackColor = Color.LightGray
			If RadioPlaylistRegScripts.Checked = True Then
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Modules\")
			Else
				WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Modules\")
			End If
			Return
		End If



	End Sub

	Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLContact1ImageDir.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.Contact1ImageDir = LBLContact1ImageDir.Text
			My.Settings.Save()
			Form1.GetContact1Pics()
		End If
	End Sub

	Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLContact2ImageDir.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.Contact2ImageDir = LBLContact2ImageDir.Text
			My.Settings.Save()
			Form1.GetContact2Pics()
		End If
	End Sub

	Private Sub Button10_Click_1(sender As System.Object, e As System.EventArgs) Handles Button10.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			LBLContact3ImageDir.Text = FolderBrowserDialog1.SelectedPath
			My.Settings.Contact3ImageDir = LBLContact3ImageDir.Text
			My.Settings.Save()
			Form1.GetContact3Pics()
		End If
	End Sub


	Private Sub CBGlitterFeed_LostFocus(sender As Object, e As System.EventArgs) Handles CBGlitterFeed.LostFocus, CBGlitterFeedScripts.LostFocus, CBGlitterFeedOff.LostFocus
		My.Settings.CBGlitterFeed = CBGlitterFeed.Checked
		My.Settings.CBGlitterFeedScripts = CBGlitterFeedScripts.Checked
		My.Settings.CBGlitterFeedOff = CBGlitterFeedOff.Checked
		My.Settings.Save()
	End Sub

	Private Sub Button11_Click_1(sender As System.Object, e As System.EventArgs) Handles Button11.Click

		If MsgBox("This will change the Chastity state of Tease AI. Depending on the Personality or Scripts used so far, this could cause unexpected behavior or break certain scripts." & Environment.NewLine _
				  & Environment.NewLine & "It is recommended to only change this state if you are otherwise stuck. Are you sure you wish to change the Chastity state?", vbYesNo, "Warning!") = MsgBoxResult.Yes Then
			If My.Settings.Chastity = True Then
				My.Settings.Chastity = False
				LBLChastityState.Text = "OFF"
				LBLChastityState.ForeColor = Color.Red
			Else
				My.Settings.Chastity = True
				LBLChastityState.Text = "ON"
				LBLChastityState.ForeColor = Color.Green
			End If
			My.Settings.Save()
		Else
			Return
		End If


	End Sub

	Private Sub LBLContact1ImageDir_MouseHover(sender As Object, e As System.EventArgs) Handles LBLContact1ImageDir.MouseHover
		If LBLContact1ImageDir.Text <> Nothing = True And LBLContact1ImageDir.Text <> "No path selected" Then
			TTDir.SetToolTip(LBLContact1ImageDir, LBLContact1ImageDir.Text)
		Else
			TTDir.SetToolTip(LBLContact1ImageDir, "No path selected")
		End If
	End Sub

	Private Sub LBLContact2ImageDir_MouseHover(sender As Object, e As System.EventArgs) Handles LBLContact2ImageDir.MouseHover
		If LBLContact2ImageDir.Text <> Nothing = True And LBLContact2ImageDir.Text <> "No path selected" Then
			TTDir.SetToolTip(LBLContact2ImageDir, LBLContact2ImageDir.Text)
		Else
			TTDir.SetToolTip(LBLContact2ImageDir, "No path selected")
		End If
	End Sub

	Private Sub LBLContact3ImageDir_MouseHover(sender As Object, e As System.EventArgs) Handles LBLContact3ImageDir.MouseHover
		If LBLContact3ImageDir.Text <> Nothing = True And LBLContact3ImageDir.Text <> "No path selected" Then
			TTDir.SetToolTip(LBLContact3ImageDir, LBLContact3ImageDir.Text)
		Else
			TTDir.SetToolTip(LBLContact3ImageDir, "No path selected")
		End If
	End Sub

	Private Sub LBLDomImageDir_MouseHover(sender As Object, e As System.EventArgs) Handles LBLDomImageDir.MouseEnter
		If LBLDomImageDir.Text <> Nothing = True And LBLDomImageDir.Text <> "No path selected" Then
			TTDir.SetToolTip(LBLDomImageDir, LBLDomImageDir.Text)
		Else
			TTDir.SetToolTip(LBLDomImageDir, "No path selected")
		End If
	End Sub



	Private Sub Button14_Click_1(sender As System.Object, e As System.EventArgs) Handles Button14.Click
		LBLContact1ImageDir.Text = "No path selected"
		My.Settings.Contact1ImageDir = "No path selected"
		My.Settings.Save()
		Form1.Contact1Pics.Clear()
	End Sub

	Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
		LBLContact2ImageDir.Text = "No path selected"
		My.Settings.Contact2ImageDir = "No path selected"
		My.Settings.Save()
		Form1.Contact2Pics.Clear()
	End Sub

	Private Sub Button12_Click_1(sender As System.Object, e As System.EventArgs) Handles Button12.Click
		LBLContact3ImageDir.Text = "No path selected"
		My.Settings.Contact3ImageDir = "No path selected"
		My.Settings.Save()
		Form1.Contact3Pics.Clear()
	End Sub

	Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click

		SaveSettingsDialog.Title = "Select a location to save current Glitter settings"
		SaveSettingsDialog.InitialDirectory = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\"


		SaveSettingsDialog.FileName = Form1.dompersonalitycombobox.Text & " Glitter Settings"

		If SaveSettingsDialog.ShowDialog() = DialogResult.OK Then
			Dim SettingsPath As String = SaveSettingsDialog.FileName
			Dim SettingsList As New List(Of String)
			SettingsList.Clear()


			If CBGlitterFeed.Checked = True Then SettingsList.Add("Glitter Feed: On")
			If CBGlitterFeedScripts.Checked = True Then SettingsList.Add("Glitter Feed: Scripts")
			If CBGlitterFeedOff.Checked = True Then SettingsList.Add("Glitter Feed: Off")

			SettingsList.Add("Short Name: " & TBGlitterShortName.Text)
			SettingsList.Add("Domme Color: " & LBLGlitterNCDomme.ForeColor.ToArgb.ToString)
			SettingsList.Add("Tease: " & CBTease.Checked)
			SettingsList.Add("Egotist: " & CBEgotist.Checked)
			SettingsList.Add("Trivia: " & CBTrivia.Checked)
			SettingsList.Add("Daily: " & CBDaily.Checked)
			SettingsList.Add("Custom 1: " & CBCustom1.Checked)
			SettingsList.Add("Custom 2: " & CBCustom2.Checked)
			SettingsList.Add("Domme Post Frequency: " & GlitterSlider.Value)

			SettingsList.Add("Contact 1 Enabled: " & CBGlitter1.Checked)
			SettingsList.Add("Contact 1 Name: " & TBGlitter1.Text)
			SettingsList.Add("Contact 1 Color: " & LBLGlitterNC1.ForeColor.ToArgb.ToString)
			SettingsList.Add("Contact 1 Image Directory: " & LBLContact1ImageDir.Text)
			SettingsList.Add("Contact 1 Post Frequency: " & GlitterSlider1.Value)

			SettingsList.Add("Contact 2 Enabled: " & CBGlitter2.Checked)
			SettingsList.Add("Contact 2 Name: " & TBGlitter2.Text)
			SettingsList.Add("Contact 2 Color: " & LBLGlitterNC2.ForeColor.ToArgb.ToString)
			SettingsList.Add("Contact 2 Image Directory: " & LBLContact2ImageDir.Text)
			SettingsList.Add("Contact 2 Post Frequency: " & GlitterSlider2.Value)

			SettingsList.Add("Contact 3 Enabled: " & CBGlitter3.Checked)
			SettingsList.Add("Contact 3 Name: " & TBGlitter3.Text)
			SettingsList.Add("Contact 3 Color: " & LBLGlitterNC3.ForeColor.ToArgb.ToString)
			SettingsList.Add("Contact 3 Image Directory: " & LBLContact3ImageDir.Text)
			SettingsList.Add("Contact 3 Post Frequency: " & GlitterSlider3.Value)

			SettingsList.Add("Domme AV: " & My.Settings.GlitterAV)
			SettingsList.Add("Contact 1 AV: " & My.Settings.GlitterAV1)
			SettingsList.Add("Contact 2 AV: " & My.Settings.GlitterAV2)
			SettingsList.Add("Contact 3 AV: " & My.Settings.GlitterAV3)



			Dim SettingsString As String = ""

			For i As Integer = 0 To SettingsList.Count - 1
				SettingsString = SettingsString & SettingsList(i)
				If i <> SettingsList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next

			My.Computer.FileSystem.WriteAllText(SettingsPath, SettingsString, False)
		End If


	End Sub

	Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click

		OpenSettingsDialog.Title = "Select a Glitter settings file"
		OpenSettingsDialog.InitialDirectory = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\"

		If OpenSettingsDialog.ShowDialog() = DialogResult.OK Then

			Dim SettingsList As New List(Of String)

			Try
				Dim SettingsReader As New StreamReader(OpenSettingsDialog.FileName)
				While SettingsReader.Peek <> -1
					SettingsList.Add(SettingsReader.ReadLine())
				End While
				SettingsReader.Close()
				SettingsReader.Dispose()
			Catch ex As Exception
				MessageBox.Show(Me, "This file could not be opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End Try

			Try

				Dim CheckState As String = SettingsList(0).Replace("Glitter Feed: ", "")
				If CheckState = "On" Then CBGlitterFeed.Checked = True
				If CheckState = "Scripts" Then CBGlitterFeedScripts.Checked = True
				If CheckState = "Off" Then CBGlitterFeedOff.Checked = True

				TBGlitterShortName.Text = SettingsList(1).Replace("Short Name: ", "")

				Dim GlitterColor As Color = Color.FromArgb(SettingsList(2).Replace("Domme Color: ", ""))
				LBLGlitterNCDomme.ForeColor = GlitterColor

				CBTease.Checked = SettingsList(3).Replace("Tease: ", "")
				CBEgotist.Checked = SettingsList(4).Replace("Egotist: ", "")
				CBTrivia.Checked = SettingsList(5).Replace("Trivia: ", "")
				CBDaily.Checked = SettingsList(6).Replace("Daily: ", "")
				CBCustom1.Checked = SettingsList(7).Replace("Custom 1: ", "")
				CBCustom2.Checked = SettingsList(8).Replace("Custom 2: ", "")
				GlitterSlider.Value = SettingsList(9).Replace("Domme Post Frequency: ", "")


				CBGlitter1.Checked = SettingsList(10).Replace("Contact 1 Enabled: ", "")
				TBGlitter1.Text = SettingsList(11).Replace("Contact 1 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(12).Replace("Contact 1 Color: ", ""))
				LBLGlitterNC1.ForeColor = GlitterColor
				LBLContact1ImageDir.Text = SettingsList(13).Replace("Contact 1 Image Directory: ", "")
				GlitterSlider1.Value = SettingsList(14).Replace("Contact 1 Post Frequency: ", "")

				CBGlitter2.Checked = SettingsList(15).Replace("Contact 2 Enabled: ", "")
				TBGlitter2.Text = SettingsList(16).Replace("Contact 2 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(17).Replace("Contact 2 Color: ", ""))
				LBLGlitterNC2.ForeColor = GlitterColor
				LBLContact2ImageDir.Text = SettingsList(18).Replace("Contact 2 Image Directory: ", "")
				GlitterSlider2.Value = SettingsList(19).Replace("Contact 2 Post Frequency: ", "")

				CBGlitter3.Checked = SettingsList(20).Replace("Contact 3 Enabled: ", "")
				TBGlitter3.Text = SettingsList(21).Replace("Contact 3 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(22).Replace("Contact 3 Color: ", ""))
				LBLGlitterNC3.ForeColor = GlitterColor
				LBLContact3ImageDir.Text = SettingsList(23).Replace("Contact 3 Image Directory: ", "")
				GlitterSlider3.Value = SettingsList(24).Replace("Contact 3 Post Frequency: ", "")

				Try
					GlitterAV.Image = Image.FromFile(SettingsList(25).Replace("Domme AV: ", ""))
					My.Settings.GlitterAV = SettingsList(25).Replace("Domme AV: ", "")
					My.Settings.Save()
				Catch
				End Try

				Try
					GlitterAV1.Image = Image.FromFile(SettingsList(26).Replace("Contact 1 AV: ", ""))
					My.Settings.GlitterAV1 = SettingsList(26).Replace("Contact 1 AV: ", "")
					My.Settings.Save()
				Catch
				End Try

				Try
					GlitterAV2.Image = Image.FromFile(SettingsList(27).Replace("Contact 2 AV: ", ""))
					My.Settings.GlitterAV2 = SettingsList(27).Replace("Contact 2 AV: ", "")
					My.Settings.Save()
				Catch
				End Try

				Try
					GlitterAV3.Image = Image.FromFile(SettingsList(28).Replace("Contact 3 AV: ", ""))
					My.Settings.GlitterAV3 = SettingsList(28).Replace("Contact 3 AV: ", "")
					My.Settings.Save()
				Catch
				End Try


				SaveGlitterSettings()

			Catch
				MessageBox.Show(Me, "This Glitter settings file is invalid or has been edited incorrectly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				LoadGlitterSettings()
			End Try

		End If
	End Sub

	Public Sub SaveGlitterSettings()

		If CBGlitterFeed.Checked = True Then
			My.Settings.CBGlitterFeed = True
			My.Settings.CBGlitterFeedScripts = False
			My.Settings.CBGlitterFeedOff = False
		End If
		If CBGlitterFeedScripts.Checked = True Then
			My.Settings.CBGlitterFeed = False
			My.Settings.CBGlitterFeedScripts = True
			My.Settings.CBGlitterFeedOff = False
		End If
		If CBGlitterFeedOff.Checked = True Then
			My.Settings.CBGlitterFeed = False
			My.Settings.CBGlitterFeedScripts = False
			My.Settings.CBGlitterFeedOff = True
		End If

		My.Settings.GlitterSN = TBGlitterShortName.Text

		My.Settings.GlitterNCDommeColor = LBLGlitterNCDomme.ForeColor

		My.Settings.CBTease = CBTease.Checked
		My.Settings.CBEgotist = CBEgotist.Checked
		My.Settings.CBTrivia = CBTrivia.Checked
		My.Settings.CBDaily = CBDaily.Checked
		My.Settings.CBCustom1 = CBCustom1.Checked
		My.Settings.CBCustom2 = CBCustom2.Checked
		My.Settings.GlitterDSlider = GlitterSlider.Value

		My.Settings.CBGlitter1 = CBGlitter1.Checked
		My.Settings.Glitter1 = TBGlitter1.Text
		My.Settings.GlitterNC1Color = LBLGlitterNC1.ForeColor
		My.Settings.Contact1ImageDir = LBLContact1ImageDir.Text
		My.Settings.Glitter1Slider = GlitterSlider1.Value

		My.Settings.CBGlitter2 = CBGlitter2.Checked
		My.Settings.Glitter2 = TBGlitter2.Text
		My.Settings.GlitterNC2Color = LBLGlitterNC2.ForeColor
		My.Settings.Contact2ImageDir = LBLContact2ImageDir.Text
		My.Settings.Glitter2Slider = GlitterSlider2.Value

		My.Settings.CBGlitter3 = CBGlitter3.Checked
		My.Settings.Glitter3 = TBGlitter3.Text
		My.Settings.GlitterNC3Color = LBLGlitterNC3.ForeColor
		My.Settings.Contact3ImageDir = LBLContact3ImageDir.Text
		My.Settings.Glitter3Slider = GlitterSlider3.Value

		My.Settings.Save()

	End Sub

	Public Sub LoadGlitterSettings()

		If My.Settings.CBGlitterFeed = True Then CBGlitterFeed.Checked = True
		If My.Settings.CBGlitterFeedScripts = True Then CBGlitterFeedScripts.Checked = True
		If My.Settings.CBGlitterFeedOff = True Then CBGlitterFeedOff.Checked = True

		TBGlitterShortName.Text = My.Settings.GlitterSN

		LBLGlitterNCDomme.ForeColor = My.Settings.GlitterNCDommeColor

		CBTease.Checked = My.Settings.CBTease
		CBEgotist.Checked = My.Settings.CBEgotist
		CBTrivia.Checked = My.Settings.CBTrivia
		CBDaily.Checked = My.Settings.CBDaily
		CBCustom1.Checked = My.Settings.CBCustom1
		CBCustom2.Checked = My.Settings.CBCustom2
		GlitterSlider.Value = My.Settings.GlitterDSlider

		CBGlitter1.Checked = My.Settings.CBGlitter1
		TBGlitter1.Text = My.Settings.Glitter1
		LBLGlitterNC1.ForeColor = My.Settings.GlitterNC1Color
		LBLContact1ImageDir.Text = My.Settings.Contact1ImageDir
		GlitterSlider1.Value = My.Settings.Glitter1Slider

		CBGlitter2.Checked = My.Settings.CBGlitter2
		TBGlitter2.Text = My.Settings.Glitter2
		LBLGlitterNC2.ForeColor = My.Settings.GlitterNC2Color
		LBLContact2ImageDir.Text = My.Settings.Contact2ImageDir
		GlitterSlider2.Value = My.Settings.Glitter2Slider

		CBGlitter3.Checked = My.Settings.CBGlitter3
		TBGlitter3.Text = My.Settings.Glitter3
		LBLGlitterNC3.ForeColor = My.Settings.GlitterNC3Color
		LBLContact3ImageDir.Text = My.Settings.Contact3ImageDir
		GlitterSlider3.Value = My.Settings.Glitter3Slider

	End Sub

	Public Sub EnglishMenu()

		LBLGeneralSettings.Text = "General Settings"

		GBGeneralSettings.Text = "Chat Window"

		timestampCheckBox.Text = "Show Timestamps"
		shownamesCheckBox.Text = "Always Show Names"
		typeinstantlyCheckBox.Text = "Domme Types Instantly"
		CBInputIcon.Text = "Show Icon During Input Questions"

		GBDommeFont.Text = "Domme Font Settings"
		BTNDomColor.Text = "Domme Name Color"
		LBLDomColor.Text = "Preview"

		GBSubFont.Text = "Sub Font Settings"
		BTNSubColor.Text = "Sub Name Color"
		LBLSubColor.Text = "Preview"

		GBGeneralImages.Text = "Images"

		CBBlogImageWindow.Text = "Save Blog Images From Session"
		CBSlideshowSubDir.Text = "Slideshow Includes Subdirectories"
		CBSlideshowRandom.Text = "Display Slideshow Pictures Randomly"
		landscapeCheckBox.Text = "Stretch Landscape Images"
		CBImageInfo.Text = "Display Image Information"

		GBDommeImages.Text = "Domme Images Directory"
		BTNDomImageDir.Text = "Set Domme Images Directory"

		GBSlideshowOptions.Text = "Slideshow Options"
		offRadio.Text = "Manual"
		teaseRadio.Text = "Tease"

		GBGeneralSystem.Text = "System"
		CBAuditStartup.Text = "Audit Scripts on Startup"
		CBSettingsPause.Text = "Pause Program When Settings Menu is Visible"
		CBAutosaveChatlog.Text = "Autosave Chatlog"
		CBSaveChatlogExit.Text = "Save Unique Chatlog on Exit"
		CBDomDel.Text = "Allow Domme to Delete Local Media"

		GBSafeword.Text = "Safeword"
		LBLSafeword.Text = "Enter a safeword that will stop all activity until the domme is sure you're able to continue."

		GBGeneralTextToSpeech.Text = "Text to Speech"
		TTSCheckBox.Text = "Enable"

		' GBGeneralDesc.Text = "Description"
		'LBLGeneralSettingsDescription.Text = "Hover over any setting in the menu for a more detailed description of its function."

	End Sub

	Public Sub GermanMenu()


		LBLGeneralSettings.Text = "Allgemeine Einstellung"

		GBGeneralSettings.Text = "Chat Fenster"

		timestampCheckBox.Text = "Zeige Zeitstempel"
		shownamesCheckBox.Text = "Zeige immer die Namen"
		typeinstantlyCheckBox.Text = "Domina Schreibt sofort"
		'CBInputIcon.Text = "Deaktiviere Chat Fenster Verstellung"

		GBDommeFont.Text = "Domina Schrift Einstellungen"
		BTNDomColor.Text = "Domina Farbe"
		LBLDomColor.Text = "Vorschau"

		GBSubFont.Text = "Sklaven Schrift Einstellungen"
		BTNSubColor.Text = "Sklaven Farbe"
		LBLSubColor.Text = "Vorschau"

		GBGeneralImages.Text = "Bilder"

		CBBlogImageWindow.Text = "Speichere Blog Bilder von Sitzung"
		CBSlideshowSubDir.Text = "Diashows enthalten Unterordner"
		CBSlideshowRandom.Text = "Zeige Diashow Bilder zufällig"
		landscapeCheckBox.Text = "Strecke „Landschaftsbilder"""
		CBImageInfo.Text = "Zeige Bild Informationen"

		GBDommeImages.Text = "Domina Bilder Ordner"
		BTNDomImageDir.Text = "Wähle Domina Bilder Speicherpfad"

		GBSlideshowOptions.Text = "Diashow Einstellungen"
		offRadio.Text = "Manual"
		teaseRadio.Text = "Tease"

		GBGeneralSystem.Text = "System"
		CBAuditStartup.Text = "Prüfen der Scripts beim Starten"
		CBSettingsPause.Text = "Pause wenn Einstellungsmenü geöffnet ist"
		CBAutosaveChatlog.Text = "Autospeichern des Chatverlaufs"
		CBSaveChatlogExit.Text = "Speichert beim beenden einen Chatverlauf"
		CBDomDel.Text = "Erlaube Domina Lokale Medien zu löschen"

		GBSafeword.Text = "Safeword"
		LBLSafeword.Text = "Gebe hier dein Safeword ein, welches alle Aktivitäten der Domina stopt, bis sie sicher ist, das du weiter machen kannst."

		GBGeneralTextToSpeech.Text = "Text zu Sprache"
		TTSCheckBox.Text = "Aktiv"

		'GBGeneralDesc.Text = "Beschreibung"
		'LBLGeneralSettingsDescription.Text = "Ziehe die Maus über irgendeine Einstellung um eine genaure Beschreibung der Einstellung zu bekommen."

	End Sub



	Private Sub RBGerman_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBGerman.CheckedChanged, RBEnglish.CheckedChanged

		If FrmSettingsLoading = False Then

			If RBGerman.Checked = True Then
				GermanMenu()
				My.Settings.TeaseAILanguage = "German"
			End If

			If RBEnglish.Checked = True Then
				EnglishMenu()
				My.Settings.TeaseAILanguage = "English"
			End If

			My.Settings.Save()

		End If

	End Sub

	'Private Sub MetroTest_ValueChanged(sender As System.Object, e As System.EventArgs)

	'Dim bpm As Integer
	'   bpm = MetroTest.Value
	'Dim MetroVal As Integer = 60 / bpm * 1000
	'Form1.StrokePace = MetroTest.Value


	' Form1.MetroTimer.Interval = MetroVal
	'End Sub


	Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.BackgroundColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button27_Click_1(sender As System.Object, e As System.EventArgs) Handles Button27.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.ButtonColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.TextColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.ChatWindowColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				Form1.BackgroundImage.Dispose()
			Catch
			End Try
			Form1.BackgroundImage = Nothing
			GC.Collect()
			Form1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.BackgroundImage = OpenFileDialog1.FileName
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
		Try
			Form1.BackgroundImage.Dispose()
			PBBackgroundPreview.Image.Dispose()
		Catch
		End Try
		Form1.BackgroundImage = Nothing
		PBBackgroundPreview.Image = Nothing
		GC.Collect()
		My.Settings.BackgroundImage = ""
		My.Settings.Save()
	End Sub



	Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
		OpenScriptDialog.Title = "Select a Theme settings file"
		OpenScriptDialog.InitialDirectory = Application.StartupPath & "\System\"

		If OpenScriptDialog.ShowDialog() = DialogResult.OK Then

			Dim SettingsList As New List(Of String)

			Try
				Dim SettingsReader As New StreamReader(OpenScriptDialog.FileName)
				While SettingsReader.Peek <> -1
					SettingsList.Add(SettingsReader.ReadLine())
				End While
				SettingsReader.Close()
				SettingsReader.Dispose()
			Catch ex As Exception
				MessageBox.Show(Me, "This file could not be opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End Try

			Try
				If File.Exists(SettingsList(0).Replace("Background Image: ", "")) Then
					PBBackgroundPreview.Image = Image.FromFile(SettingsList(0).Replace("Background Image: ", ""))
					My.Settings.BackgroundImage = SettingsList(0).Replace("Background Image: ", "")
				End If

				CBStretchBack.Checked = SettingsList(1).Replace("Stretch Image: ", "")

				My.Settings.BackgroundColor = Color.FromArgb(SettingsList(2).Replace("Background Color: ", ""))
				My.Settings.ButtonColor = Color.FromArgb(SettingsList(3).Replace("Button Color: ", ""))
				My.Settings.TextColor = Color.FromArgb(SettingsList(4).Replace("Text Color: ", ""))
				My.Settings.ChatWindowColor = Color.FromArgb(SettingsList(5).Replace("Chat Window Color: ", ""))
				My.Settings.ChatTextColor = Color.FromArgb(SettingsList(6).Replace("Chat Text Color: ", ""))

				My.Settings.DateTextColor = Color.FromArgb(SettingsList(7).Replace("Date Text Color: ", ""))
				My.Settings.DateBackColor = Color.FromArgb(SettingsList(8).Replace("Date Back Color: ", ""))
				CBTransparentTime.Checked = SettingsList(9).Replace("Transparent Date: ", "")

				CBFlipBack.Checked = SettingsList(10).Replace("FlipImage: ", "")

				My.Settings.Save()


			Catch
				MessageBox.Show(Me, "This Theme settings file is invalid or has been edited incorrectly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try

			Form1.ApplyThemeColor()


		End If
	End Sub

	Private Sub Button21_Click_1(sender As System.Object, e As System.EventArgs) Handles Button21.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.ChatTextColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub CBStretchBack_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBStretchBack.CheckedChanged
		If Form1.ApplyingTheme = False Then
			My.Settings.BackgroundStretch = CBStretchBack.Checked
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If

	End Sub



	Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.DateTextColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.DateBackColor = GetColor.Color
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If
	End Sub

	Private Sub CBTransparentTime_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBTransparentTime.CheckedChanged
		If Form1.ApplyingTheme = False Then
			My.Settings.CBDateTransparent = CBTransparentTime.Checked
			My.Settings.Save()
			Form1.ApplyThemeColor()
		End If

	End Sub









	Private Sub CheckBox1_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBFlipBack.CheckedChanged

		If Form1.FormLoading = False And Form1.ApplyingTheme = False Then Form1.ApplyThemeColor()

	End Sub

	Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click
		SaveFileDialog1.Title = "Select a location to save current Theme"
		SaveFileDialog1.InitialDirectory = Application.StartupPath & "\System\"


		SaveFileDialog1.FileName = "Theme.txt"

		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
			Dim SettingsPath As String = SaveFileDialog1.FileName
			Dim SettingsList As New List(Of String)
			SettingsList.Clear()

			SettingsList.Add("Background Image: " & My.Settings.BackgroundImage)
			SettingsList.Add("Stretch Image: " & CBStretchBack.Checked)

			SettingsList.Add("Background Color: " & My.Settings.BackgroundColor.ToArgb.ToString)
			SettingsList.Add("Button Color: " & My.Settings.ButtonColor.ToArgb.ToString)
			SettingsList.Add("Text Color: " & My.Settings.TextColor.ToArgb.ToString)
			SettingsList.Add("Chat Window Color: " & My.Settings.ChatWindowColor.ToArgb.ToString)
			SettingsList.Add("Chat Text Color: " & My.Settings.ChatTextColor.ToArgb.ToString)
			SettingsList.Add("Date Text Color: " & My.Settings.DateTextColor.ToArgb.ToString)
			SettingsList.Add("Date Back Color: " & My.Settings.DateBackColor.ToArgb.ToString)
			SettingsList.Add("Transparent Date: " & CBTransparentTime.Checked)

			SettingsList.Add("FlipImage: " & CBFlipBack.Checked)

			Dim SettingsString As String = ""

			For i As Integer = 0 To SettingsList.Count - 1
				SettingsString = SettingsString & SettingsList(i)
				If i <> SettingsList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next

			My.Computer.FileSystem.WriteAllText(SettingsPath, SettingsString, False)
		End If

	End Sub

	Private Sub Button33_Click(sender As System.Object, e As System.EventArgs)
		Form1.MetroThread.Start()
	End Sub

	Private Sub Button34_Click(sender As System.Object, e As System.EventArgs)
		Form1.MetroThread.Suspend()
	End Sub

	Private Sub TimeBoxWakeUp_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TimeBoxWakeUp.ValueChanged
		If Form1.FormLoading = False Then


			Dim SetDate As Date = FormatDateTime(TimeBoxWakeUp.Value, DateFormat.LongTime)

			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\Variables\SYS_WakeUp", FormatDateTime(SetDate, DateFormat.LongTime), False)



			'Debug.Print("Dates = " & Dates)

			' Github Patch My.Settings.WakeUp = Form1.GetTime("SYS_WakeUp")
			My.Settings.WakeUp = FormatDateTime(Now, DateFormat.ShortDate) & " " & Form1.GetTime("SYS_WakeUp")
			My.Settings.Save()








		End If
	End Sub

	Private Sub NBTypoChance_LostFocus(sender As Object, e As System.EventArgs) Handles NBTypoChance.LostFocus
		My.Settings.TypoChance = NBTypoChance.Value
		My.Settings.Save()
	End Sub


	Private Sub LBLBoobPath_MouseHover(sender As Object, e As System.EventArgs) Handles LBLBoobPath.MouseHover
		TTDir.SetToolTip(LBLBoobPath, LBLBoobPath.Text)
	End Sub
	Private Sub LBLBoobURL_MouseHover(sender As Object, e As System.EventArgs) Handles LBLBoobURL.MouseHover
		TTDir.SetToolTip(LBLBoobURL, LBLBoobURL.Text)
	End Sub

	Private Sub LBLButtPath_MouseHover(sender As Object, e As System.EventArgs) Handles LBLButtPath.MouseHover
		TTDir.SetToolTip(LBLButtPath, LBLButtPath.Text)
	End Sub
	Private Sub LBLButtURL_MouseHover(sender As Object, e As System.EventArgs) Handles LBLButtURL.MouseHover
		TTDir.SetToolTip(LBLButtURL, LBLButtURL.Text)
	End Sub

	Private Sub LBLIHardcore_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIHardcore.MouseHover
		TTDir.SetToolTip(LBLIHardcore, LBLIHardcore.Text)
	End Sub
	Private Sub LBLISoftcore_MouseHover(sender As Object, e As System.EventArgs) Handles LBLISoftcore.MouseHover
		TTDir.SetToolTip(LBLISoftcore, LBLISoftcore.Text)
	End Sub
	Private Sub LBLILesbian_MouseHover(sender As Object, e As System.EventArgs) Handles LBLILesbian.MouseHover
		TTDir.SetToolTip(LBLILesbian, LBLILesbian.Text)
	End Sub
	Private Sub LBLIBlowjob_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIBlowjob.MouseHover
		TTDir.SetToolTip(LBLIBlowjob, LBLIBlowjob.Text)
	End Sub
	Private Sub LBLIFemdom_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIFemdom.MouseHover
		TTDir.SetToolTip(LBLIFemdom, LBLIFemdom.Text)
	End Sub
	Private Sub LBLILezdom_MouseHover(sender As Object, e As System.EventArgs) Handles LBLILezdom.MouseHover
		TTDir.SetToolTip(LBLILezdom, LBLILezdom.Text)
	End Sub
	Private Sub LBLIHentai_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIHentai.MouseHover
		TTDir.SetToolTip(LBLIHentai, LBLIHentai.Text)
	End Sub
	Private Sub LBLIGay_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIGay.MouseHover
		TTDir.SetToolTip(LBLIGay, LBLIGay.Text)
	End Sub
	Private Sub LBLIMaledom_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIMaledom.MouseHover
		TTDir.SetToolTip(LBLIMaledom, LBLIMaledom.Text)
	End Sub
	Private Sub LBLICaptions_MouseHover(sender As Object, e As System.EventArgs) Handles LBLICaptions.MouseHover
		TTDir.SetToolTip(LBLICaptions, LBLICaptions.Text)
	End Sub
	Private Sub LBLIGeneral_MouseHover(sender As Object, e As System.EventArgs) Handles LBLIGeneral.MouseHover
		TTDir.SetToolTip(LBLIGeneral, LBLIGeneral.Text)
	End Sub




	Private Sub BTNWICreateURL_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWICreateURL.MouseHover
		TTDir.SetToolTip(BTNWICreateURL, "Click here to create a new URL File." & Environment.NewLine & Environment.NewLine &
										 "URL Files create a txt file containing the URL address" & Environment.NewLine &
										 "of every image posted at the image blog you specify.")
	End Sub

	Private Sub CBWIreview_MouseHover(sender As Object, e As System.EventArgs) Handles CBWIReview.MouseHover
		TTDir.SetToolTip(CBWIReview, "When this is checked, you'll need to review" & Environment.NewLine &
									 "each image before it's added to the URL File.")
	End Sub

	Private Sub CBWISavetoDisk_MouseHover(sender As Object, e As System.EventArgs) Handles CBWISaveToDisk.MouseHover
		TTDir.SetToolTip(CBWISaveToDisk, "When this is checked, images will also be saved" & Environment.NewLine &
										 "to the specified HDD directory as they are added.")
	End Sub

	Private Sub BTNWIAddandContinue_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIAddandContinue.MouseHover
		TTDir.SetToolTip(BTNWIAddandContinue, "When reviewing images, click this button to add the" & Environment.NewLine &
											  "current image to the URL File and continue to the next.")
	End Sub

	Private Sub BTNWIContinue_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIContinue.MouseHover
		TTDir.SetToolTip(BTNWIContinue, "When reviewing images, click this button to skip the" & Environment.NewLine &
										"current image without adding it to the URL File.")
	End Sub

	Private Sub BTNWICancel_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWICancel.MouseHover
		TTDir.SetToolTip(BTNWICancel, "Use this button to cancel URL File creation.")
	End Sub

	Private Sub BTNWIOpenURL_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIOpenURL.MouseHover
		TTDir.SetToolTip(BTNWIOpenURL, "Use this button to view a URL File you have previously created.")
	End Sub

	Private Sub BTNWIPrevious_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIPrevious.MouseHover
		TTDir.SetToolTip(BTNWIPrevious, "Use this button to view the previous image of a URL File.")
	End Sub

	Private Sub BTNWINext_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWINext.MouseHover
		TTDir.SetToolTip(BTNWINext, "Use this button to view the next image of a URL File.")
	End Sub

	Private Sub BTNWIRemove_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIRemove.MouseHover
		TTDir.SetToolTip(BTNWIRemove, "Use this button to remove an image from a URL File.")
	End Sub

	Private Sub BTNWILiked_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWILiked.MouseHover
		TTDir.SetToolTip(BTNWILiked, "Use this button to add the current image to your Liked URL Files list.")
	End Sub

	Private Sub BTNWIDisliked_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIDisliked.MouseHover
		TTDir.SetToolTip(BTNWIDisliked, "Use this button to add the current image to your Disliked URL Files list.")
	End Sub

	Private Sub BTNWISave_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWISave.MouseHover
		TTDir.SetToolTip(BTNWISave, "Use this button to save the current image to your hard drive.")
	End Sub

	Private Sub TBWIDirectory_MouseHover(sender As Object, e As System.EventArgs) Handles TBWIDirectory.MouseHover
		TTDir.SetToolTip(TBWIDirectory, "This is where images will be saved if ""Save Images to Disk"" is checked.")
	End Sub

	Private Sub BTNWIBrowse_MouseHover(sender As Object, e As System.EventArgs) Handles BTNWIBrowse.MouseHover
		TTDir.SetToolTip(BTNWIBrowse, "Select the directory where images will be saved to disk.")
	End Sub

	Private Sub LBLVideoHardcore_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoHardCore.MouseHover
		TTDir.SetToolTip(LblVideoHardCore, LblVideoHardCore.Text)
	End Sub

	Private Sub LBLVideoHardcoreD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoHardCoreD.MouseHover
		TTDir.SetToolTip(LblVideoHardCoreD, LblVideoHardCoreD.Text)
	End Sub

	Private Sub LBLVideoSoftcore_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoSoftCore.MouseHover
		TTDir.SetToolTip(LblVideoSoftCore, LblVideoSoftCore.Text)
	End Sub

	Private Sub LBLVideoSoftcoreD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoSoftCoreD.MouseHover
		TTDir.SetToolTip(LblVideoSoftCoreD, LblVideoSoftCoreD.Text)
	End Sub

	Private Sub LBLVideoLesbian_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoLesbian.MouseHover
		TTDir.SetToolTip(LblVideoLesbian, LblVideoLesbian.Text)
	End Sub

	Private Sub LBLVideoLesbianD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoLesbianD.MouseHover
		TTDir.SetToolTip(LblVideoLesbianD, LblVideoLesbianD.Text)
	End Sub

	Private Sub LBLVideoBlowjob_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoBlowjob.MouseHover
		TTDir.SetToolTip(LblVideoBlowjob, LblVideoBlowjob.Text)
	End Sub

	Private Sub LBLVideoBlowjobD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoBlowjobD.MouseHover
		TTDir.SetToolTip(LblVideoBlowjobD, LblVideoBlowjobD.Text)
	End Sub

	Private Sub LBLVideoFemdom_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoFemdom.MouseHover
		TTDir.SetToolTip(LblVideoFemdom, LblVideoFemdom.Text)
	End Sub

	Private Sub LBLVideoFemdomD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoFemdomD.MouseHover
		TTDir.SetToolTip(LblVideoFemdomD, LblVideoFemdomD.Text)
	End Sub

	Private Sub LBLVideoFemsub_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoFemsub.MouseHover
		TTDir.SetToolTip(LblVideoFemsub, LblVideoFemsub.Text)
	End Sub

	Private Sub LBLVideoFemsubD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoFemsubD.MouseHover
		TTDir.SetToolTip(LblVideoFemsubD, LblVideoFemsubD.Text)
	End Sub

	Private Sub LBLVideoJOI_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoJOI.MouseHover
		TTDir.SetToolTip(LblVideoJOI, LblVideoJOI.Text)
	End Sub

	Private Sub LBLVideoJOID_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoJOID.MouseHover
		TTDir.SetToolTip(LblVideoJOID, LblVideoJOID.Text)
	End Sub

	Private Sub LBLVideoCH_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoCH.MouseHover
		TTDir.SetToolTip(LblVideoCH, LblVideoCH.Text)
	End Sub

	Private Sub LBLVideoCHD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoCHD.MouseHover
		TTDir.SetToolTip(LblVideoCHD, LblVideoCHD.Text)
	End Sub

	Private Sub LBLVideoGeneral_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoGeneral.MouseHover
		TTDir.SetToolTip(LblVideoGeneral, LblVideoGeneral.Text)
	End Sub

	Private Sub LBLVideoGeneralD_MouseHover(sender As Object, e As System.EventArgs) Handles LblVideoGeneralD.MouseHover
		TTDir.SetToolTip(LblVideoGeneralD, LblVideoGeneralD.Text)
	End Sub

	Private Sub BTNRefreshVideos_MouseHover(sender As Object, e As System.EventArgs) Handles BTNRefreshVideos.MouseHover
		TTDir.SetToolTip(BTNRefreshVideos, "Use this button to refresh video paths.")
	End Sub

	Private Sub SliderVVolume_LostFocus(sender As Object, e As System.EventArgs) Handles SliderVVolume.LostFocus
		My.Settings.VVolume = SliderVVolume.Value
		My.Settings.Save()
	End Sub
	Private Sub SliderVRate_LostFocus(sender As Object, e As System.EventArgs) Handles SliderVRate.LostFocus
		My.Settings.VRate = SliderVRate.Value
		My.Settings.Save()
	End Sub

	Private Sub SliderVVolume_MouseHover(sender As Object, e As System.EventArgs) Handles SliderVVolume.MouseHover
		TTDir.SetToolTip(SliderVVolume, "Adusts the volume of the domme's TTS voice.")
	End Sub

	Private Sub SliderVRate_MouseHover(sender As Object, e As System.EventArgs) Handles SliderVRate.MouseHover
		TTDir.SetToolTip(SliderVRate, "Adusts the speed of the domme's TTS voice.")
	End Sub

	Private Sub SliderVVolume_Scroll(sender As System.Object, e As System.EventArgs) Handles SliderVVolume.Scroll
		Form1.synth.Volume = SliderVVolume.Value
		Form1.synth2.Volume = SliderVVolume.Value
		LBLVVolume.Text = SliderVVolume.Value
	End Sub
	Private Sub SliderVRate_Scroll(sender As System.Object, e As System.EventArgs) Handles SliderVRate.Scroll
		Form1.synth.Rate = SliderVRate.Value
		Form1.synth2.Rate = SliderVRate.Value
		LBLVRate.Text = SliderVRate.Value
	End Sub

	Private Sub sadisticCheckBox_LostFocus(sender As Object, e As System.EventArgs) Handles sadisticCheckBox.LostFocus
		My.Settings.DomSadistic = sadisticCheckBox.Checked
		My.Settings.Save()
	End Sub

	Private Sub degradingCheckBox_LostFocus(sender As Object, e As System.EventArgs) Handles degradingCheckBox.LostFocus
		My.Settings.DomDegrading = degradingCheckBox.Checked
		My.Settings.Save()
	End Sub


	Private Sub CBWebtease_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBWebtease.CheckedChanged
		If CBWebtease.Checked = True Then
			Form1.WebteaseModeToolStripMenuItem.Checked = True
			Form1.ChatText.ScrollBarsEnabled = False
			Form1.ChatText2.ScrollBarsEnabled = False
		Else
			Form1.WebteaseModeToolStripMenuItem.Checked = False
			Form1.ChatText.ScrollBarsEnabled = True
			Form1.ChatText2.ScrollBarsEnabled = True

		End If
	End Sub

	Private Sub CBDebugTaunts_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBDebugTaunts.CheckedChanged
		If CBDebugTaunts.Checked = True Then
			RBDebugTaunts1.Enabled = True
			RBDebugTaunts2.Enabled = True
			RBDebugTaunts3.Enabled = True
			CBDebugTauntsEndless.Enabled = True
			BTNDebugTauntsClear.Enabled = True

			If RBDebugTaunts1.Checked = True Then
				TBDebugTaunts1.Enabled = True
				TBDebugTaunts2.Enabled = False
				TBDebugTaunts3.Enabled = False
			End If
			If RBDebugTaunts2.Checked = True Then
				TBDebugTaunts1.Enabled = True
				TBDebugTaunts2.Enabled = True
				TBDebugTaunts3.Enabled = False
			End If
			If RBDebugTaunts3.Checked = True Then
				TBDebugTaunts1.Enabled = True
				TBDebugTaunts2.Enabled = True
				TBDebugTaunts3.Enabled = True
			End If
		Else
			RBDebugTaunts1.Enabled = False
			RBDebugTaunts2.Enabled = False
			RBDebugTaunts3.Enabled = False
			CBDebugTauntsEndless.Enabled = False
			BTNDebugTauntsClear.Enabled = False
			TBDebugTaunts1.Enabled = False
			TBDebugTaunts2.Enabled = False
			TBDebugTaunts3.Enabled = False
		End If
	End Sub

	Private Sub RBDebugTaunts1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBDebugTaunts1.CheckedChanged, RBDebugTaunts2.CheckedChanged, RBDebugTaunts3.CheckedChanged
		If RBDebugTaunts1.Checked = True Then
			TBDebugTaunts1.Enabled = True
			TBDebugTaunts2.Enabled = False
			TBDebugTaunts3.Enabled = False
		End If
		If RBDebugTaunts2.Checked = True Then
			TBDebugTaunts1.Enabled = True
			TBDebugTaunts2.Enabled = True
			TBDebugTaunts3.Enabled = False
		End If
		If RBDebugTaunts3.Checked = True Then
			TBDebugTaunts1.Enabled = True
			TBDebugTaunts2.Enabled = True
			TBDebugTaunts3.Enabled = True
		End If
	End Sub

	Private Sub BTNDebugTauntsClear_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugTauntsClear.Click
		TBDebugTaunts1.Text = ""
		TBDebugTaunts2.Text = ""
		TBDebugTaunts3.Text = ""
	End Sub

	Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
		Form1.StrokeTick = 5
	End Sub

	Private Sub CBWebtease_CheckedChanged(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CBWebtease.MouseClick

	End Sub

	Private Sub CBMuteMedia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBMuteMedia.CheckedChanged
		If Form1.FormLoading = False Then
			My.Settings.MuteMedia = CBMuteMedia.Checked
			My.Settings.Save()
		End If
	End Sub


End Class