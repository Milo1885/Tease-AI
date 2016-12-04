Imports System.ComponentModel
Imports System.IO
Imports System.Speech.Synthesis
Imports Tease_AI.URL_Files




Public Class FrmSettings

	Private Property Ssh As SessionState
		Get
			Return My.Application.Session
		End Get
		Set(value As SessionState)
			My.Application.Session = value
		End Set
	End Property



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
	Dim TagCount As Integer
	Dim LocalTagCount As Integer


	Public WebImage As String
	Public WebImageFile As StreamReader
	Public WebImageLines As New List(Of String)
	Public WebImageLine As Integer
	Public WebImageLineTotal As Integer
	Public WebImagePath As String
	Public ApproveImage As Integer = 0

	Dim CheckImgDir As New List(Of String)

	'Dim Fringe As New SpeechSynthesizer

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
		Form1.BtnToggleSettings.Text = "Open Settings Menu"
		e.Cancel = True

	End Sub


	Private Sub FrmSettings_LostFocus(sender As Object, e As EventArgs) Handles Me.Deactivate
		My.Settings.Save()
	End Sub

	Public Sub FrmSettingStartUp()

		FrmSettingsLoading = True


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

		Debug.Print("Checking Local image Settings...")

		' Check image Folders
		ImagesHardcore_CheckFolder()
		ImagesSoftcore_CheckFolder()
		ImagesLesbian_CheckFolder()
		ImagesBlowjob_CheckFolder()
		ImagesFemdom_CheckFolder()
		ImagesLezdom_CheckFolder()
		ImagesHentai_CheckFolder()
		ImagesGay_CheckFolder()
		ImagesMaledom_CheckFolder()
		ImagesGeneral_CheckFolder()
		ImagesCaptions_CheckFolder()
		ImagesBoobs_CheckFolder()
		ImagesButts_CheckFolder()


		Debug.Print("FRM2 STAGE Two reached")

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

			LoadStartScripts()
			LoadModuleScripts()
			LoadLinkScripts()
			LoadEndScripts()

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

		'===============================================================================
		'								Card images & names
		'===============================================================================
		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading card images..."
		FrmSplash.Refresh()

		Form1.GamesToolStripMenuItem1.Enabled = CardGameCheck()
		'===============================================================================
		'								User settings
		'===============================================================================
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




		'dompersonalityComboBox.Text = PersonType
		Debug.Print("Dom personality = " & Form1.dompersonalitycombobox.Text)
		Debug.Print("WEB THING HELLO???" & Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")
		WBPlaylist.Navigate(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Playlist\Start\")


		For Each tmptbx As TextBox In New List(Of TextBox) From {TbxContact1ImageDir, TbxContact2ImageDir, TbxContact3ImageDir, TbxDomImageDir}
			If tmptbx.DataBindings("Text") Is Nothing Then
				Throw New Exception("There is no databinding set on """ & tmptbx.Name &
					"""'s text-property. Set the databinding and recompile!")
			End If
		Next

		For Each tmptbx As CheckBox In New List(Of CheckBox) From {CBGlitter1, CBGlitter2, CBGlitter3}
			If tmptbx.DataBindings("Checked") Is Nothing Then
				Throw New Exception("There is no databinding set on """ & tmptbx.Name &
					"""'s checked-property. Set the databinding and recompile!")
			End If
		Next

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

		If My.Settings.OfflineMode = False Then
			LBLOfflineMode.Text = "OFF"
			LBLOfflineMode.ForeColor = Color.Red
		Else
			LBLOfflineMode.Text = "ON"
			LBLOfflineMode.ForeColor = Color.Green
		End If

		CBNewSlideshow.Checked = My.Settings.CBNewSlideshow

		NBTauntEdging.Value = My.Settings.TauntEdging

		CBURLPreview.Checked = My.Settings.CBURLPreview

		TypesSpeedVal.Text = TypeSpeedSlider.Value


		FrmSettingsLoading = False

		Me.Visible = False



		Debug.Print("Form2 Loading Finished")


	End Sub

	Private Sub SettingsTabs_TabIndexChanged(sender As Object, e As System.EventArgs) Handles SettingsTabs.SelectedIndexChanged

		' If current Tab is Scripts force focus onto CheckedListBoxes.
		If SettingsTabs.SelectedTab Is TabPage16 Then TCScripts_TabIndexChanged(TCScripts, Nothing)

	End Sub

#Region "------------------------------------- GeneralTab -----------------------------------------------"

	Private Sub BtnImportSettings_Click(sender As Object, e As EventArgs) Handles BtnImportSettings.Click
		My.MySettings.importOnRestart()
	End Sub


	Private Sub timestampCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles timestampCheckBox.MouseClick

		If timestampCheckBox.Checked = True Then
			My.Settings.CBTimeStamps = True
		Else
			My.Settings.CBTimeStamps = False
		End If



	End Sub


	Private Sub shownamesCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles shownamesCheckBox.MouseClick

		If shownamesCheckBox.Checked = True Then
			My.Settings.CBShowNames = True
		Else
			My.Settings.CBShowNames = False
		End If

	End Sub

	Private Sub typeinstantlyCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles typeinstantlyCheckBox.MouseClick

		If typeinstantlyCheckBox.Checked = True Then
			My.Settings.CBInstantType = True
		Else
			My.Settings.CBInstantType = False
		End If


	End Sub

	Private Sub CBWebtease_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBWebtease.MouseClick

		If CBWebtease.Checked = True Then
			My.Settings.CBWebtease = True
		Else
			My.Settings.CBWebtease = False
		End If


	End Sub

	Private Sub CBBlogImageWindow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBBlogImageWindow.MouseClick
		If CBBlogImageWindow.Checked = True Then
			My.Settings.CBBlogImageMain = True
		Else
			My.Settings.CBBlogImageMain = False
		End If
	End Sub

	Private Sub landscapeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles landscapeCheckBox.MouseClick
		If landscapeCheckBox.Checked = True Then
			My.Settings.CBStretchLandscape = True
		Else
			My.Settings.CBStretchLandscape = False
		End If
	End Sub

	Private Sub CBSettingsPause_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSettingsPause.MouseClick
		If CBSettingsPause.Checked = True Then
			My.Settings.CBSettingsPause = True
		Else
			My.Settings.CBSettingsPause = False
		End If
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


	Private Sub CBAutosaveChatlog_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBAutosaveChatlog.MouseClick
		If CBAutosaveChatlog.Checked = True Then
			My.Settings.CBAutosaveChatlog = True
		Else
			My.Settings.CBAutosaveChatlog = False
		End If
	End Sub

	Private Sub CBSaveChatlogExit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSaveChatlogExit.MouseClick
		If CBSaveChatlogExit.Checked = True Then
			My.Settings.CBExitSaveChatlog = True
		Else
			My.Settings.CBExitSaveChatlog = False
		End If
	End Sub

	Private Sub CBJackInTheBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBAuditStartup.MouseClick
		If CBAuditStartup.Checked = True Then
			My.Settings.AuditStartup = True
		Else
			My.Settings.AuditStartup = False
		End If
	End Sub

	Private Sub CBSlideshowSubDir_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBSlideshowSubDir.LostFocus
		If CBSlideshowSubDir.Checked = True Then
			My.Settings.CBSlideshowSubDir = True
		Else
			My.Settings.CBSlideshowSubDir = False
		End If
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

	Private Sub CBLockWindow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBInputIcon.LostFocus
		If CBInputIcon.Checked = True Then
			My.Settings.CBInputIcon = True
		Else
			My.Settings.CBInputIcon = False
		End If
	End Sub

	Private Sub BTNDomColor_Click(sender As System.Object, e As System.EventArgs) Handles BTNDomColor.Click

		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.DomColorColor = GetColor.Color
			LBLDomColor.ForeColor = GetColor.Color
			My.Settings.DomColor = Color2Html(GetColor.Color)
		End If


	End Sub

	Private Sub BTNSubColor_Click(sender As System.Object, e As System.EventArgs) Handles BTNSubColor.Click

		If GetColor.ShowDialog() = DialogResult.OK Then
			My.Settings.SubColorColor = GetColor.Color
			LBLSubColor.ForeColor = GetColor.Color
			My.Settings.SubColor = Color2Html(GetColor.Color)
		End If

	End Sub



	Private Sub timedRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles timedRadio.CheckedChanged
		If Form1.ssh.SlideshowLoaded = True And timedRadio.Checked = True Then
			Form1.ssh.SlideshowTimerTick = slideshowNumBox.Value
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
	End Sub

	Private Sub FontComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles FontComboBox.LostFocus
		My.Settings.SubFont = FontComboBox.Text
	End Sub

	Private Sub NBFontSizeD_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBFontSizeD.LostFocus
		My.Settings.DomFontSize = NBFontSizeD.Value
	End Sub

	Private Sub NBFontSize_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBFontSize.LostFocus
		My.Settings.SubFontSize = NBFontSize.Value
	End Sub




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
	End Sub

#End Region ' General

#Region "-------------------------------------- Domme Tab -----------------------------------------------"

#Region "Save PetNames"

	Private Sub petnameBox1_LostFocus(sender As System.Object, e As System.EventArgs) Handles petnameBox1.LostFocus

		Dim BlankName As String
		BlankName = "stroker"
		Dim NameVal As Integer
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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
		NameVal = Form1.ssh.randomizer.Next(1, 6)

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


	End Sub

#End Region


	''' <summary>
	''' Locks the Orgasm Chances.
	''' </summary>
	''' <param name="lock">If True the Controls regarding orgasms are locked.</param>
	Friend Sub LockOrgasmChances(ByVal lock As Boolean)

		alloworgasmComboBox.Enabled = Not lock
		ruinorgasmComboBox.Enabled = Not lock

		GBRangeOrgasmChance.Enabled = Not lock
		GBRangeRuinChance.Enabled = Not lock

	End Sub


	Private Sub domlevelNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domlevelNumBox.LostFocus
		My.Settings.DomLevel = domlevelNumBox.Value
	End Sub

	Private Sub alloworgasmComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles alloworgasmComboBox.LostFocus



		My.Settings.OrgasmAllow = alloworgasmComboBox.Text
	End Sub

	Private Sub ruinorgasmComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ruinorgasmComboBox.LostFocus



		My.Settings.OrgasmRuin = ruinorgasmComboBox.Text



	End Sub

	Private Sub domageNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domageNumBox.LostFocus
		My.Settings.DomAge = domageNumBox.Value
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
	End Sub

	Private Sub domhairComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBDomHairColor.MouseHover

		TTDir.SetToolTip(TBDomHairColor, "Sets the domme's hair color.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's hair color." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her hair color over the course of the tease. Set this value to the color " & _
		' "of the slideshow model's hair to enhance immersion."
	End Sub

	Private Sub domhairlengthComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles domhairlengthComboBox.LostFocus
		My.Settings.DomHairLength = domhairlengthComboBox.Text
	End Sub

	Private Sub domhairlengthComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles domhairlengthComboBox.MouseHover

		TTDir.SetToolTip(domhairlengthComboBox, "Sets the domme's hair length.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's hair length." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her hair length over the course of the tease. Set this value to the length " & _
		'   "of the slideshow model's hair to enhance immersion."
	End Sub

	Private Sub TBDomEyeColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBDomEyeColor.LostFocus
		My.Settings.DomEyes = TBDomEyeColor.Text
	End Sub

	Private Sub domeyesComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBDomEyeColor.MouseHover

		TTDir.SetToolTip(TBDomEyeColor, "Sets the domme's eye color.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's eye color." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her eye color over the course of the tease. Set this value to the color " & _
		'   "of the slideshow model's eyes to enhance immersion."
	End Sub

	Private Sub boobComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles boobComboBox.LostFocus
		My.Settings.DomCup = boobComboBox.Text
	End Sub

	Private Sub boobComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles boobComboBox.MouseHover

		TTDir.SetToolTip(boobComboBox, "Sets the Domme's cup size.")

		'LblDommeSettingsDescription.Text = "Sets the Domme's cup size." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to the size of her breasts over the course of the tease. Set this value to the " & _
		'   "slideshow model's cup size to enhance immersion."
	End Sub

	Private Sub dompubichairComboBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles dompubichairComboBox.LostFocus
		My.Settings.DomPubicHair = dompubichairComboBox.Text
	End Sub

	Private Sub dompubichairComboBox_MouseHover(sender As System.Object, e As System.EventArgs) Handles dompubichairComboBox.MouseHover

		TTDir.SetToolTip(dompubichairComboBox, "Sets description of the Domme's pubic hair.")

		'LblDommeSettingsDescription.Text = "Sets description of the Domme's pubic hair." & Environment.NewLine & Environment.NewLine & "The domme may sometimes refer to her pubic hair over the course of the tease. Set this value to a description " & _
		'  "of the slideshow model's pubic hair to enhance immersion."
	End Sub


	Private Sub crazyCheckBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles crazyCheckBox.LostFocus
		If crazyCheckBox.Checked = True Then
			My.Settings.DomCrazy = True
		Else
			My.Settings.DomCrazy = False
		End If
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
	End Sub

	Private Sub CBMeMyMine_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBMeMyMine.MouseHover
		TTDir.SetToolTip(CBMeMyMine, "When this is checked, the domme will always capitalize ""Me, My and Mine""." & Environment.NewLine & Environment.NewLine &
		   "If the lowercase typing option is checked, she will also capitalize ""I, I'm, I'd and I'll"".")
	End Sub

	Private Sub TBEmote_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBEmote.LostFocus
		My.Settings.TBEmote = TBEmote.Text
	End Sub

	Private Sub TBEmoteEnd_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBEmoteEnd.LostFocus
		My.Settings.TBEmoteEnd = TBEmoteEnd.Text
	End Sub



	Private Sub TBEmote_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBEmote.MouseHover
		TTDir.SetToolTip(TBEmote, "This determines what symbol(s) the domme uses to begin an emote.")
	End Sub

	Private Sub TBEmoteEnd_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBEmoteEnd.MouseHover
		TTDir.SetToolTip(TBEmoteEnd, "This determines what symbol(s) the domme uses to end an emote.")
	End Sub



	Private Sub LockOrgasmChances_MouseHover(sender As System.Object, e As System.EventArgs) Handles CBLockOrgasmChances.MouseHover
		TTDir.SetToolTip(CBLockOrgasmChances, "If checked the orgasm chances will be locked and unchangeable once you start the tease." & Environment.NewLine & Environment.NewLine &
			"Orgasm chances will be changeable and unlocked when out of a tease.")
	End Sub

	Private Sub CBDomDenialEnds_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBDomDenialEnds.LostFocus
		If CBDomDenialEnds.Checked = True Then
			My.Settings.DomDenialEnd = True
		Else
			My.Settings.DomDenialEnd = False
		End If
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
	End Sub

	Private Sub NBAvgCockMin_MouseHover(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMin.MouseHover
		TTDir.SetToolTip(NBAvgCockMin, "Determines the lowest range of what the domme considers an average cock size." & Environment.NewLine & Environment.NewLine &
									   "If your cock size is lower then this, the domme will consider it small.")
	End Sub

	Private Sub NBAvgCockMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBAvgCockMax.LostFocus
		My.Settings.AvgCockMax = NBAvgCockMax.Value
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
	End Sub

	Private Sub NBSelfAgeMin_Enter(sender As Object, e As System.EventArgs) Handles NBSelfAgeMin.MouseHover

		TTDir.SetToolTip(NBSelfAgeMin, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
									   "If the domme's age is below this number, she will use dialogue options that suggest" & Environment.NewLine &
									   "having the maturity and body of a girl in her early twenties.")
	End Sub

	Private Sub NBSelfAgeMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSelfAgeMax.LostFocus
		My.Settings.SelfAgeMax = NBSelfAgeMax.Value
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
	End Sub

	Private Sub NBSubAgeMin_Enter(sender As Object, e As System.EventArgs) Handles NBSubAgeMin.MouseHover
		TTDir.SetToolTip(NBSubAgeMin, "This is the age range that the domme considers ""not that young, but not that old""." & Environment.NewLine & Environment.NewLine &
			"If your age is below this number, the domme will use dialogue options that suggest" & Environment.NewLine &
			"you have the virility and body of a male in his early twenties.")
	End Sub

	Private Sub NBSubAgeMax_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBSubAgeMax.LostFocus
		My.Settings.SubAgeMax = NBSubAgeMax.Value
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


	Private Sub NBEmpathy_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBEmpathy.LostFocus

		If NBEmpathy.Value = 1 Then My.Settings.DomEmpathy = 1
		If NBEmpathy.Value = 2 Then My.Settings.DomEmpathy = 2
		If NBEmpathy.Value = 3 Then My.Settings.DomEmpathy = 3
		If NBEmpathy.Value = 4 Then My.Settings.DomEmpathy = 4
		If NBEmpathy.Value = 5 Then My.Settings.DomEmpathy = 5


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

#End Region ' Domme

#Region "-------------------------------------- Scripts -------------------------------------------------"

	''' <summary>
	''' Forces the Focus onto the CheckedListBoxes in Tabcontrol.
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TCScripts_TabIndexChanged(sender As Object, e As System.EventArgs) Handles TCScripts.SelectedIndexChanged

		If TCScripts.SelectedTab Is TabPage21 Then
			CLBStartList.Focus()
		ElseIf TCScripts.SelectedTab Is TabPage17 Then
			CLBModuleList.Focus()
		ElseIf TCScripts.SelectedTab Is TabPage18 Then
			CLBLinkList.Focus()
		ElseIf TCScripts.SelectedTab Is TabPage19 Then
			CLBEndList.Focus()
		End If
	End Sub

	Public Shared Sub saveCheckedListBox(target As CheckedListBox, filePath As String)
		Try
			If Not Directory.Exists(Path.GetDirectoryName(filePath)) Then _
				Directory.CreateDirectory(Path.GetDirectoryName(filePath))

			Using fs As New FileStream(filePath, IO.FileMode.Create), BinWrite As New BinaryWriter(fs)
				For i = 0 To target.Items.Count - 1
					BinWrite.Write(CStr(target.Items(i)))
					BinWrite.Write(CBool(target.GetItemChecked(i)))
				Next
			End Using

		Catch ex As Exception
			Throw
		End Try
	End Sub

	Private Sub SaveStartScripts() Handles CLBStartList.LostFocus
		Try
			saveCheckedListBox(CLBStartList, Ssh.Files.StartChecklist)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error on saving checkstate")
			MessageBox.Show(ex.Message, "Error on saving checkstate", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub SaveModuleScripts() Handles CLBModuleList.LostFocus
		Try
			saveCheckedListBox(CLBModuleList, Ssh.Files.ModuleChecklist)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error on saving checkstate")
			MessageBox.Show(ex.Message, "Error on saving checkstate", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub SaveLinkScripts() Handles CLBLinkList.LostFocus
		Try
			saveCheckedListBox(CLBLinkList, Ssh.Files.LinkChecklist)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error on saving checkstate")
			MessageBox.Show(ex.Message, "Error on saving checkstate", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub SaveEndScripts() Handles CLBEndList.LostFocus
		Try
			saveCheckedListBox(CLBEndList, Ssh.Files.EndChecklist)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error on saving checkstate")
			MessageBox.Show(ex.Message, "Error on saving checkstate", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub loadCheckedListBox(target As CheckedListBox,
								   ByVal loadPath As String,
								   ByVal scriptDir As String,
								   ByVal Optional preEnable As Boolean = True)
		Try
			Dim Modified As Boolean = False

			Dim LastIndex As Integer = target.SelectedIndex
			Dim LastItem As String = target.SelectedItem

			target.Items.Clear()
			target.BeginUpdate()

			If Not Directory.Exists(Path.GetDirectoryName(loadPath)) Then GoTo SkipDeserializing
			If Not File.Exists(loadPath) Then GoTo SkipDeserializing

			Using fs As New FileStream(loadPath, FileMode.Open), binRead As New BinaryReader(fs)
				Do While fs.Position < fs.Length
					Dim FileName As String = binRead.ReadString
					Dim enabled As Boolean = binRead.ReadBoolean
					Dim FilePath As String = scriptDir & FileName & ".txt"

					If File.Exists(FilePath) And target.Items.Contains(FileName) = False Then
						target.Items.Add(FileName, enabled)
					Else
						Modified = True
						Debug.Print("File """ & FilePath & """ was Not found.")
					End If
				Loop
			End Using

SkipDeserializing:

			' Create script directory if it doesn't exist.
			If Directory.Exists(scriptDir) = False Then Directory.CreateDirectory(scriptDir)

			' Add each file to Listbox.
			For Each FilePath As String In Directory.GetFiles(scriptDir, "*.txt", SearchOption.TopDirectoryOnly)
				Dim FileName As String = Path.GetFileNameWithoutExtension(FilePath)

				If Not target.Items.Contains(FileName) Then
					Debug.Print(target.Name & " does Not contain " & FileName)
					target.Items.Add(FileName, preEnable)
				Else
					Modified = True
				End If
			Next

			' If there was somethng to fix during loading save it.
			If Modified Then saveCheckedListBox(target, loadPath)

			If LastIndex = -1 Then
				ScriptStatusUnlock(False)
			ElseIf target.Items.Contains(LastItem) Then
				target.SelectedItem = LastItem
			ElseIf target.Items.Count >= LastIndex Then
				target.SelectedIndex = LastIndex
			End If

		Catch ex As Exception
			Throw
		Finally
			target.EndUpdate()
		End Try
	End Sub

	Public Sub LoadStartScripts() Handles CLBStartList.GotFocus
		Try
			If InvokeRequired Then
				Invoke(New Action(AddressOf LoadStartScripts))
				Exit Sub
			End If

			loadCheckedListBox(CLBStartList, Ssh.Files.StartChecklist, Ssh.Folders.StartScripts)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	Public Sub LoadModuleScripts() Handles CLBModuleList.GotFocus
		Try
			If InvokeRequired Then
				Invoke(New Action(AddressOf LoadModuleScripts))
				Exit Sub
			End If

			loadCheckedListBox(CLBModuleList, Ssh.Files.ModuleChecklist, Ssh.Folders.ModuleScripts)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	Public Sub LoadLinkScripts() Handles CLBLinkList.GotFocus
		Try
			If InvokeRequired Then
				Invoke(New Action(AddressOf LoadLinkScripts))
				Exit Sub
			End If

			loadCheckedListBox(CLBLinkList, Ssh.Files.LinkChecklist, Ssh.Folders.LinkScripts)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	Public Sub LoadEndScripts() Handles CLBEndList.GotFocus
		Try
			If InvokeRequired Then
				Invoke(New Action(AddressOf LoadEndScripts))
				Exit Sub
			End If

			loadCheckedListBox(CLBEndList, Ssh.Files.EndChecklist, Ssh.Folders.EndScripts)
		Catch ex As Exception
			Throw
		End Try
	End Sub

	Private Sub CLBStartList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBStartList.SelectedIndexChanged, CLBModuleList.SelectedIndexChanged, CLBLinkList.SelectedIndexChanged, CLBEndList.SelectedIndexChanged
		Try
			Dim target As CheckedListBox = DirectCast(sender, CheckedListBox)
			Dim Scriptfolder As String = ""

			If target Is CLBStartList Then
				Scriptfolder = Ssh.Folders.StartScripts
			ElseIf target Is CLBModuleList Then
				Scriptfolder = Ssh.Folders.ModuleScripts
			ElseIf target Is CLBLinkList Then
				Scriptfolder = Ssh.Folders.LinkScripts
			ElseIf target Is CLBEndList Then
				Scriptfolder = Ssh.Folders.EndScripts
			Else
				Throw New NotImplementedException("The starting conrol is not implemnted in this method.")
			End If

			Debug.WriteLine(target.Name)

			For i As Integer = target.Items.Count - 1 To 0 Step -1
				Dim checkfile As String = Scriptfolder & target.Items(i) & ".txt"
				If Not File.Exists(Scriptfolder & target.Items(i) & ".txt") Then
					target.Items.Remove(target.Items(i))
					'Exit For
				End If
			Next

			If target.SelectedIndex = -1 Then ScriptStatusUnlock(False) : Exit Sub

			ScriptFile = Scriptfolder & target.Items(target.SelectedIndex) & ".txt"
			If File.Exists(ScriptFile) Then GetScriptStatus()
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show(ex.Message, "Error on changing Item", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub


	''' <summary>
	''' This Procedure enables or disables the Controls to view a script status.
	''' On disabling it will clear the textbox.text as well.
	''' </summary>
	''' <param name="state">False disables the Controls. True enables them.</param>
	Private Sub ScriptStatusUnlock(ByVal state As Boolean)
		BTNScriptOpen.Enabled = state
		RTBScriptDesc.Enabled = state
		RTBScriptReq.Enabled = state
		LBLScriptReq.Enabled = state
		If state = False Then
			RTBScriptDesc.Text = ""
			RTBScriptReq.Text = ""
			LBLScriptReq.Text = ""
		End If
	End Sub

	Public Sub GetScriptStatus()
		'BUG: This Function is not checking all Commands and their contditions
		Try
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
					If My.Settings.CBIHardcore = True Then
						If Directory.Exists(My.Settings.IHardcore) Then LocalCount += 1
					End If
					If My.Settings.CBISoftcore = True Then
						If Directory.Exists(My.Settings.ISoftcore) Then LocalCount += 1
					End If
					If My.Settings.CBILesbian = True Then
						If Directory.Exists(My.Settings.ILesbian) Then LocalCount += 1
					End If
					If My.Settings.CBIBlowjob = True Then
						If Directory.Exists(My.Settings.IBlowjob) Then LocalCount += 1
					End If
					If My.Settings.CBIFemdom = True Then
						If Directory.Exists(My.Settings.IFemdom) Then LocalCount += 1
					End If
					If My.Settings.CBILezdom = True Then
						If Directory.Exists(My.Settings.ILezdom) Then LocalCount += 1
					End If
					If My.Settings.CBIHentai = True Then
						If Directory.Exists(My.Settings.IHentai) Then LocalCount += 1
					End If
					If My.Settings.CBIGay = True Then
						If Directory.Exists(My.Settings.IGay) Then LocalCount += 1
					End If
					If My.Settings.CBIMaledom = True Then
						If Directory.Exists(My.Settings.IMaledom) Then LocalCount += 1
					End If
					If My.Settings.CBICaptions = True Then
						If Directory.Exists(My.Settings.ICaptions) Then LocalCount += 1
					End If
					If My.Settings.CBIGeneral = True Then
						If Directory.Exists(My.Settings.IGeneral) Then LocalCount += 1
					End If
					If LocalCount = 0 Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowImage") Then
					If Not RTBScriptReq.Text.Contains("* At least one URL File selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one URL File selected *" & Environment.NewLine
					If Not RTBScriptReq.Text.Contains("* At least one Local Image path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one Local Image path selected with a valid directory *" & Environment.NewLine
					If URLFileList.CheckedItems.Count = 0 Then ScriptReqFailed = True
					Dim LocalCount As Integer = 0
					If My.Settings.CBIHardcore = True Then
						If Directory.Exists(My.Settings.IHardcore) Then LocalCount += 1
					End If
					If My.Settings.CBISoftcore = True Then
						If Directory.Exists(My.Settings.ISoftcore) Then LocalCount += 1
					End If
					If My.Settings.CBILesbian = True Then
						If Directory.Exists(My.Settings.ILesbian) Then LocalCount += 1
					End If
					If My.Settings.CBIBlowjob = True Then
						If Directory.Exists(My.Settings.IBlowjob) Then LocalCount += 1
					End If
					If My.Settings.CBIFemdom = True Then
						If Directory.Exists(My.Settings.IFemdom) Then LocalCount += 1
					End If
					If My.Settings.CBILezdom = True Then
						If Directory.Exists(My.Settings.ILezdom) Then LocalCount += 1
					End If
					If My.Settings.CBIHentai = True Then
						If Directory.Exists(My.Settings.IHentai) Then LocalCount += 1
					End If
					If My.Settings.CBIGay = True Then
						If Directory.Exists(My.Settings.IGay) Then LocalCount += 1
					End If
					If My.Settings.CBIMaledom = True Then
						If Directory.Exists(My.Settings.IMaledom) Then LocalCount += 1
					End If
					If My.Settings.CBICaptions = True Then
						If Directory.Exists(My.Settings.ICaptions) Then LocalCount += 1
					End If
					If My.Settings.CBIGeneral = True Then
						If Directory.Exists(My.Settings.ICaptions) Then LocalCount += 1
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
					If CBVideoJOI.Checked = True And Not Directory.Exists(TxbVideoJOI.Text) Then ScriptReqFailed = True
					If CBVideoJOID.Checked = True And Not Directory.Exists(TxbVideoJOID.Text) Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@PlayCHVideo") Then
					If Not RTBScriptReq.Text.Contains("* CH or CH Domme Video path selected with a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* CH or CH Domme Video path selected with a valid directory *" & Environment.NewLine
					If CBVideoCH.Checked = False And CBVideoCHD.Checked = False Then ScriptReqFailed = True
					If LblVideoCHTotal.Text = "0" And LblVideoCHTotalD.Text = "0" Then ScriptReqFailed = True
					If CBVideoCH.Checked = True And Not Directory.Exists(TxbVideoCH.Text) Then ScriptReqFailed = True
					If CBVideoCHD.Checked = True And Not Directory.Exists(TxbVideoCHD.Text) Then ScriptReqFailed = True
				End If

				'If ScriptList(i).Contains("@TnAFastSlides") Or ScriptList(i).Contains("@TnASlowSlides") Or ScriptList(i).Contains("@TnASlides") Or ScriptList(i).Contains("@CheckTnA") Then
				'If Not RTBScriptReq.Text.Contains("* BnB Games must be enabled in Image Settings *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Games must be enabled in Image Settings *" & Environment.NewLine
				'If CBEnableBnB.Checked = False Then ScriptReqFailed = True
				'End If

				If ScriptList(i).Contains("@ShowButtImage") Then
					If Not RTBScriptReq.Text.Contains("* BnB Butt path must be set to a valid directory or URL File *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Butt path must be set to a valid directory or URL File *" & Environment.NewLine
					If My.Settings.CBIButts = True And Not Directory.Exists(My.Settings.LBLButtPath) Then ScriptReqFailed = True
					If ChbImageUrlButts.Checked = True And Not File.Exists(My.Settings.UrlFileButt) Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowBoobsImage") Then
					If Not RTBScriptReq.Text.Contains("* BnB Boobs path must be set to a valid directory or URL File *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* BnB Boobs path must be set to a valid directory or URL File *" & Environment.NewLine
					If My.Settings.CBIBoobs = True And Not Directory.Exists(My.Settings.LBLBoobPath) Then ScriptReqFailed = True
					If ChbImageUrlBoobs.Checked = True And Not File.Exists(My.Settings.UrlFileBoobs) Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowHardcoreImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Hardcore Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Hardcore Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IHardcore) Or My.Settings.CBIHardcore = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowSoftcoreImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Softcore Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Softcore Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.ISoftcore) Or My.Settings.CBISoftcore = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowLesbianImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Lesbian Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Lesbian Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.ILesbian) Or My.Settings.CBILesbian = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowBlowjobImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Blowjob Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Blowjob Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IBlowjob) Or My.Settings.CBIBlowjob = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowFemdomImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Femdom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Femdom Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IFemdom) Or My.Settings.CBIFemdom = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowLezdomImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Lezdom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Lezdom Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.ILezdom) Or My.Settings.CBILezdom = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowHentaiImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Hentai Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Hentai Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IHentai) Or My.Settings.CBIHentai = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowGayImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Gay Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Gay Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IGay) Or My.Settings.CBIGay = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowMaledomImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Maledom Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Maledom Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IMaledom) Or My.Settings.CBIMaledom = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowCaptionsImage") Then
					If Not RTBScriptReq.Text.Contains("* Local Captions Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local Captions Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.ICaptions) Or My.Settings.CBICaptions = False Then ScriptReqFailed = True
				End If

				If ScriptList(i).Contains("@ShowGeneralImage") Then
					If Not RTBScriptReq.Text.Contains("* Local General Image path must be selected and set to a valid directory *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* Local General Image path must be selected and set to a valid directory *" & Environment.NewLine
					If Not Directory.Exists(My.Settings.IGeneral) Or My.Settings.CBIGeneral = False Then ScriptReqFailed = True
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
					Form1.ssh.VideoCheck = True
					Form1.RandomVideo()
					If Form1.ssh.NoVideo = True Then ScriptReqFailed = True
					Form1.ssh.VideoCheck = False
					Form1.ssh.NoVideo = False
				End If


				If ScriptList(i).Contains("@PlayCensorshipSucks") Or ScriptList(i).Contains("@PlayAvoidTheEdge") Or ScriptList(i).Contains("@PlayRedLightGreenLight") Then
					If Not RTBScriptReq.Text.Contains("* At least one non-Special Genre or Domme Video path set and selected *") Then RTBScriptReq.Text = RTBScriptReq.Text & "* At least one non-Special Genre or Domme Video path set and selected *" & Environment.NewLine
					Form1.ssh.VideoCheck = True
					Form1.ssh.NoSpecialVideo = True
					Form1.RandomVideo()
					If Form1.ssh.NoVideo = True Then ScriptReqFailed = True
					Form1.ssh.VideoCheck = False
					Form1.ssh.NoSpecialVideo = False
					Form1.ssh.NoVideo = False
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

			ScriptStatusUnlock(True)

			RTBScriptReq.Text = RTBScriptReq.Text.Replace("**", "* *")

			If ScriptReqFailed = True Then
				LBLScriptReq.ForeColor = Color.Red
				LBLScriptReq.Text = "All requirements not met!"
			Else
				LBLScriptReq.ForeColor = Color.Green
				LBLScriptReq.Text = "All requirements met!"
			End If
		Catch ex As Exception
			ScriptStatusUnlock(False)
			MessageBox.Show(ex.Message, "Error Checking ScriptStatus", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub



	Private Sub BtnScriptsOpen_Click(sender As System.Object, e As System.EventArgs) Handles BTNScriptOpen.Click
		Dim Filepath As String = ""
		Try
			If CLBStartList.Visible = True Then
				Filepath = Ssh.Folders.StartScripts & CLBStartList.Items(CLBStartList.SelectedIndex) & ".txt"
			ElseIf CLBModuleList.Visible = True Then
				Filepath = Ssh.Folders.ModuleScripts & CLBModuleList.Items(CLBModuleList.SelectedIndex) & ".txt"
			ElseIf CLBLinkList.Visible = True Then
				Filepath = Ssh.Folders.LinkScripts & CLBLinkList.Items(CLBLinkList.SelectedIndex) & ".txt"
			ElseIf CLBEndList.Visible = True Then
				Filepath = Ssh.Folders.EndScripts & CLBEndList.Items(CLBEndList.SelectedIndex) & ".txt"
			Else
				Throw New Exception("Unable to determine CheckedListBox.")
			End If

			If Not File.Exists(Filepath) Then _
				Throw New FileNotFoundException("Unable to locate file """ & Filepath & """.")

			Form1.ShellExecute(Filepath)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show(ex.Message, "Error opening Script", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub


	Private Sub BtnScriptsSelectAutomated_Click(sender As System.Object, e As System.EventArgs) Handles BTNScriptAvailable.Click, BTNScriptNone.Click, BTNScriptAll.Click
		' Lock Buttons to prevent double trigger
		BTNScriptAvailable.Enabled = False
		BTNScriptNone.Enabled = False
		BTNScriptAll.Enabled = False

		' The CheckedListBox to use.
		Dim Target As CheckedListBox = Nothing

		' The corresponding Folder containing scripts
		Dim Scriptfolder As String

		' A Lamda Object for saving the changes.
		Dim SaveAction As Action

		Try
			' Dertermine variable data
			If TCScripts.SelectedTab Is TabPage21 = True Then
				Target = CLBStartList
				Scriptfolder = Ssh.Folders.StartScripts
				SaveAction = AddressOf SaveStartScripts
			ElseIf TCScripts.SelectedTab Is TabPage17 Then
				Target = CLBModuleList
				Scriptfolder = Ssh.Folders.ModuleScripts
				SaveAction = AddressOf SaveModuleScripts
			ElseIf TCScripts.SelectedTab Is TabPage18 Then
				Target = CLBLinkList
				Scriptfolder = Ssh.Folders.LinkScripts
				SaveAction = AddressOf SaveLinkScripts
			ElseIf TCScripts.SelectedTab Is TabPage19 Then
				Target = CLBEndList
				Scriptfolder = Ssh.Folders.EndScripts
				SaveAction = AddressOf SaveEndScripts
			Else
				Throw New Exception("Unable to determine CheckedListBox.")
			End If

			Target.BeginUpdate()

			If sender Is BTNScriptNone Then
				' ####################### Select None #########################
				Debug.Print(Target.Name & " select none")

				For i As Integer = 0 To Target.Items.Count - 1
					Target.SetItemChecked(i, False)
				Next

			ElseIf sender Is BTNScriptAll Then
				' ####################### Select All ##########################
				Debug.Print(Target.Name & " select all")

				For i As Integer = 0 To Target.Items.Count - 1
					Target.SetItemChecked(i, True)
				Next

			ElseIf sender Is BTNScriptAvailable Then
				' #################### Select Available #######################
				Debug.Print(Target.Name & " select available")

				For i As Integer = 0 To Target.Items.Count - 1

					AvailFail = False

					AvailList = Common.Txt2List(Scriptfolder & Target.Items(i) & ".txt")
					GetAvailFail()

					If AvailFail = True Then
						Target.SetItemChecked(i, False)
					Else
						Target.SetItemChecked(i, True)
					End If

				Next
			End If

			SaveAction()
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show(ex.Message, "Error selecting Scripts", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		Finally
			If Target IsNot Nothing Then
				Target.EndUpdate()
				Target.Focus()
			End If
		End Try

		' Unlock Buttons
		BTNScriptAvailable.Enabled = True
		BTNScriptNone.Enabled = True
		BTNScriptAll.Enabled = True
	End Sub

	Public Sub GetAvailFail()
		'BUG: This Function is not checking all Commands and their contditions
		Try
			For j As Integer = 0 To AvailList.Count - 1
				If AvailList(j).Contains("@ShowBlogImage") Then
					If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
				End If
				If AvailList(j).Contains("@NewBlogImage") Then
					If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
				End If
				If AvailList(j).Contains("@ShowLocalImage") Then
					Dim LocalCount As Integer = 0
					If My.Settings.CBIHardcore = True Then
						If Directory.Exists(My.Settings.IHardcore) Then LocalCount += 1
					End If
					If My.Settings.CBISoftcore = True Then
						If Directory.Exists(My.Settings.ISoftcore) Then LocalCount += 1
					End If
					If My.Settings.CBILesbian = True Then
						If Directory.Exists(My.Settings.ILesbian) Then LocalCount += 1
					End If
					If My.Settings.CBIBlowjob = True Then
						If Directory.Exists(My.Settings.IBlowjob) Then LocalCount += 1
					End If
					If My.Settings.CBIFemdom = True Then
						If Directory.Exists(My.Settings.IFemdom) Then LocalCount += 1
					End If
					If My.Settings.CBILezdom = True Then
						If Directory.Exists(My.Settings.ILezdom) Then LocalCount += 1
					End If
					If My.Settings.CBIHentai = True Then
						If Directory.Exists(My.Settings.IHentai) Then LocalCount += 1
					End If
					If My.Settings.CBIGay = True Then
						If Directory.Exists(My.Settings.IGay) Then LocalCount += 1
					End If
					If My.Settings.CBIMaledom = True Then
						If Directory.Exists(My.Settings.IMaledom) Then LocalCount += 1
					End If
					If My.Settings.CBICaptions = True Then
						If Directory.Exists(My.Settings.ICaptions) Then LocalCount += 1
					End If
					If My.Settings.CBIGeneral = True Then
						If Directory.Exists(My.Settings.IGeneral) Then LocalCount += 1
					End If
					If LocalCount = 0 Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowImage") Then
					If URLFileList.CheckedItems.Count = 0 Then AvailFail = True
					Dim LocalCount As Integer = 0
					If My.Settings.CBIHardcore = True Then
						If Directory.Exists(My.Settings.IHardcore) Then LocalCount += 1
					End If
					If My.Settings.CBISoftcore = True Then
						If Directory.Exists(My.Settings.ISoftcore) Then LocalCount += 1
					End If
					If My.Settings.CBILesbian = True Then
						If Directory.Exists(My.Settings.ILesbian) Then LocalCount += 1
					End If
					If My.Settings.CBIBlowjob = True Then
						If Directory.Exists(My.Settings.IBlowjob) Then LocalCount += 1
					End If
					If My.Settings.CBIFemdom = True Then
						If Directory.Exists(My.Settings.IFemdom) Then LocalCount += 1
					End If
					If My.Settings.CBILezdom = True Then
						If Directory.Exists(My.Settings.ILezdom) Then LocalCount += 1
					End If
					If My.Settings.CBIHentai = True Then
						If Directory.Exists(My.Settings.IHentai) Then LocalCount += 1
					End If
					If My.Settings.CBIGay = True Then
						If Directory.Exists(My.Settings.IGay) Then LocalCount += 1
					End If
					If My.Settings.CBIMaledom = True Then
						If Directory.Exists(My.Settings.IMaledom) Then LocalCount += 1
					End If
					If My.Settings.CBICaptions = True Then
						If Directory.Exists(My.Settings.ICaptions) Then LocalCount += 1
					End If
					If My.Settings.CBIGeneral = True Then
						If Directory.Exists(My.Settings.IGeneral) Then LocalCount += 1
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
					If CBVideoJOI.Checked = True And Not Directory.Exists(TxbVideoJOI.Text) Then AvailFail = True
					If CBVideoJOID.Checked = True And Not Directory.Exists(TxbVideoJOID.Text) Then AvailFail = True
				End If

				If AvailList(j).Contains("@PlayCHVideo") Then
					If CBVideoCH.Checked = False And CBVideoCHD.Checked = False Then AvailFail = True
					If LblVideoCHTotal.Text = "0" And LblVideoCHTotalD.Text = "0" Then AvailFail = True
					If CBVideoCH.Checked = True And Not Directory.Exists(TxbVideoCH.Text) Then AvailFail = True
					If CBVideoCHD.Checked = True And Not Directory.Exists(TxbVideoCHD.Text) Then AvailFail = True
				End If

				'If AvailList(j).Contains("@TnAFastSlides") Or AvailList(j).Contains("@TnASlowSlides") Or AvailList(j).Contains("@TnASlides") Or AvailList(j).Contains("@CheckTnA") Then
				'If CBEnableBnB.Checked = False Then AvailFail = True
				'End If

				If AvailList(j).Contains("@ShowButtImage") Then
					If My.Settings.CBIButts = True And Not Directory.Exists(My.Settings.LBLButtPath) Then AvailFail = True
					If ChbImageUrlButts.Checked = True And Not File.Exists(My.Settings.UrlFileButt) Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowBoobsImage") Then
					If My.Settings.CBIBoobs = True And Not Directory.Exists(My.Settings.LBLBoobPath) Then AvailFail = True
					If ChbImageUrlBoobs.Checked = True And Not File.Exists(My.Settings.UrlFileBoobs) Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowHardcoreImage") Then
					If Not Directory.Exists(My.Settings.IHardcore) Or My.Settings.CBIHardcore = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowSoftcoreImage") Then
					If Not Directory.Exists(My.Settings.ISoftcore) Or My.Settings.CBISoftcore = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowLesbianImage") Then
					If Not Directory.Exists(My.Settings.ILesbian) Or My.Settings.CBILesbian = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowBlowjobImage") Then
					If Not Directory.Exists(My.Settings.IBlowjob) Or My.Settings.CBIBlowjob = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowFemdomImage") Then
					If Not Directory.Exists(My.Settings.IFemdom) Or My.Settings.CBIFemdom = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowLezdomImage") Then
					If Not Directory.Exists(My.Settings.ILezdom) Or My.Settings.CBILezdom = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowHentaiImage") Then
					If Not Directory.Exists(My.Settings.IHentai) Or My.Settings.CBIHentai = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowGayImage") Then
					If Not Directory.Exists(My.Settings.IGay) Or My.Settings.CBIGay = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowMaledomImage") Then
					If Not Directory.Exists(My.Settings.IMaledom) Or My.Settings.CBIMaledom = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowCaptionsImage") Then
					If Not Directory.Exists(My.Settings.ICaptions) Or My.Settings.CBICaptions = False Then AvailFail = True
				End If

				If AvailList(j).Contains("@ShowGeneralImage") Then
					If Not Directory.Exists(My.Settings.IGeneral) Or My.Settings.CBIGeneral = False Then AvailFail = True
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
					Form1.ssh.VideoCheck = True
					Form1.RandomVideo()
					If Form1.ssh.NoVideo = True Then AvailFail = True
					Form1.ssh.VideoCheck = False
					Form1.ssh.NoVideo = False
				End If

				If AvailList(j).Contains("@PlayCensorshipSucks") Or AvailList(j).Contains("@PlayAvoidTheEdge") Or AvailList(j).Contains("@PlayRedLightGreenLight") Then
					Form1.ssh.VideoCheck = True
					Form1.ssh.NoSpecialVideo = True
					Form1.RandomVideo()
					If Form1.ssh.NoVideo = True Then AvailFail = True
					Form1.ssh.VideoCheck = False
					Form1.ssh.NoSpecialVideo = False
					Form1.ssh.NoVideo = False
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

		Catch ex As Exception
			Throw
		End Try
	End Sub

#End Region ' Scripts

#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Apps ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"

#Region "----------------------------------------- Glitter ----------------------------------------------"

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
		End If
	End Sub


	Private Sub BTNDomImageDir_Click(sender As System.Object, e As System.EventArgs) Handles BTNDomImageDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.DomImageDir = FolderBrowserDialog1.SelectedPath
			My.Application.Session.SlideshowMain = New ContactData(ContactType.Domme)
		End If
	End Sub

	Private Sub BtnContact1ImageDir_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact1ImageDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.Contact1ImageDir = FolderBrowserDialog1.SelectedPath
			My.Application.Session.SlideshowContact1 = New ContactData(ContactType.Contact1)
		End If
	End Sub

	Private Sub BtnContact2ImageDir_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact2ImageDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.Contact2ImageDir = FolderBrowserDialog1.SelectedPath
			My.Application.Session.SlideshowContact2 = New ContactData(ContactType.Contact2)
		End If
	End Sub

	Private Sub BtnContact3ImageDir_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact3ImageDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.Contact3ImageDir = FolderBrowserDialog1.SelectedPath
			My.Application.Session.SlideshowContact3 = New ContactData(ContactType.Contact3)
		End If
	End Sub


	Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitterD.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			LBLGlitterNCDomme.ForeColor = GetColor.Color
		End If
	End Sub
	Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitter1.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			LBLGlitterNC1.ForeColor = GetColor.Color
		End If
	End Sub
	Private Sub Button4_Click_3(sender As System.Object, e As System.EventArgs) Handles BTNGlitter2.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			LBLGlitterNC2.ForeColor = GetColor.Color
		End If
	End Sub
	Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles BTNGlitter3.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			LBLGlitterNC3.ForeColor = GetColor.Color
		End If
	End Sub

	Private Sub CBGlitterFeed_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBGlitterFeed.Click, CBGlitterFeedScripts.Click, CBGlitterFeedOff.Click
		If Form1.FormLoading = False Then
			' In order to prevent wrong values, we have to change the DataSourceUpdateMode.
			' Since the Designer will reset this value, we have to undo this changes.
			For Each ob As RadioButton In {CBGlitterFeed, CBGlitterFeedOff, CBGlitterFeedScripts}
				ob.DataBindings("Checked").DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
			Next

			' Set the desired Value manually - Didn't know it is that much of a problem to databind RadioButtons.
			' This Solution ensures the ui to display the current value, whenever and whatever thread changed in and
			' it saves correctly. The only issue could be, when setting a value, while forgetting to disable the others.
			Dim checked As Boolean = CType(sender, RadioButton).Checked
			My.Settings.CBGlitterFeed = If(sender Is CBGlitterFeed, checked, False)
			My.Settings.CBGlitterFeedOff = If(sender Is CBGlitterFeedOff, checked, False)
			My.Settings.CBGlitterFeedScripts = If(sender Is CBGlitterFeedScripts, checked, False)

			Debug.Print("Set RadioButton Values")
			Debug.Print(CBGlitterFeed.Checked)
			Debug.Print(CBGlitterFeedScripts.Checked)
			Debug.Print(CBGlitterFeedOff.Checked)
		End If
	End Sub

	Private Sub BTNGlitterD_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitterD.MouseHover
		TTDir.SetToolTip(BTNGlitterD, "This button allows you to change the color of the domme's name as it appears in the Glitter app." & Environment.NewLine &
									  "A preview will appear in the text box below this button once a color has been selected.")
	End Sub
	Private Sub GlitterAV_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV.MouseHover
		TTDir.SetToolTip(GlitterAV, "Click here to set the image the domme will use as her Glitter avatar.")
	End Sub
	Private Sub LBLGlitterNCDomme_Click(sender As System.Object, e As System.EventArgs) Handles LBLGlitterNCDomme.MouseHover, LBLGlitterNC1.MouseHover, LBLGlitterNC2.MouseHover, LBLGlitterNC3.MouseHover
		TTDir.SetToolTip(sender, "After clicking the ""Choose Name Color"" button above, a preview of the selected color will appear here.")
	End Sub
	Private Sub TBGlitterShortName_MouseHover(sender As System.Object, e As System.EventArgs) Handles TBGlitterShortName.MouseHover
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

	Private Sub TBGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles TBGlitter1.MouseHover, TBGlitter2.MouseHover, TBGlitter3.MouseHover
		TTDir.SetToolTip(sender, "This will be the name of this contact as it appears in the Glitter feed.")
	End Sub
	Private Sub GlitterSlider1_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterSlider1.MouseHover, GlitterSlider2.MouseHover, GlitterSlider3.MouseHover, LBLGlitterSlider1.MouseHover, LBLGlitterSlider2.MouseHover, LBLGlitterSlider3.MouseHover
		TTDir.SetToolTip(sender, "This slider determines how often this contact responds to the domme's Glitter posts." & Environment.NewLine &
										 "The further to the right the slider is, the more often she responds.")
	End Sub
	Private Sub GlitterAV1_MouseHover(sender As Object, e As System.EventArgs) Handles GlitterAV1.MouseHover, GlitterAV2.MouseHover, GlitterAV3.MouseHover
		TTDir.SetToolTip(sender, "Click here to set the image that this contact will use as her Glitter avatar.")
	End Sub
	Private Sub CBGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles CBGlitter1.MouseHover, CBGlitter2.MouseHover, CBGlitter3.MouseHover
		TTDir.SetToolTip(sender, "This check box enables this contact's participation in the Glitter feed.")
	End Sub
	Private Sub BTNGlitter1_MouseHover(sender As Object, e As System.EventArgs) Handles BTNGlitter1.MouseHover, BTNGlitter2.MouseHover, BTNGlitter3.MouseHover
		TTDir.SetToolTip(sender, "This button allows you to change the color of this contact's name as it appears in the Glitter app.")
	End Sub

	Private Sub LBLContact1ImageDir_MouseHover(sender As Object, e As System.EventArgs) Handles TbxContact1ImageDir.MouseHover, TbxContact2ImageDir.MouseHover, TbxContact3ImageDir.MouseHover, TbxDomImageDir.MouseHover
		TTDir.SetToolTip(sender, CType(sender, TextBox).Text)
	End Sub

	Private Sub Button2_MouseHover(sender As System.Object, e As System.EventArgs) Handles BtnContact1ImageDir.MouseHover, BtnContact2ImageDir.MouseHover, BtnContact3ImageDir.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(sender, "Use this button to select a directory containing several image" & Environment.NewLine &
"set folders of the same model you're using as your contact.")
		If RBGerman.Checked = True Then TTDir.SetToolTip(sender, "Benutze diese Schaltfläche um einen Ordner zu wählen, welcher mehre" & Environment.NewLine &
"Bildersets von dem selben Model enthält, die du als Kontakt benutzt.")
	End Sub

	Private Sub BtnContact1ImageDirClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact1ImageDirClear.Click
		My.Settings.ResetField(TbxContact1ImageDir, "Text")
		My.Application.Session.SlideshowContact1 = New ContactData()
	End Sub

	Private Sub BtnContact2ImageDirClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact2ImageDirClear.Click
		My.Settings.ResetField(TbxContact2ImageDir, "Text")
		My.Application.Session.SlideshowContact2 = New ContactData()
	End Sub

	Private Sub BtnContact3ImageDirClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnContact3ImageDirClear.Click
		My.Settings.ResetField(TbxContact3ImageDir, "Text")
		My.Application.Session.SlideshowContact3 = New ContactData()
	End Sub

	Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click

		SaveSettingsDialog.Title = "Select a location to save current Glitter settings"
		SaveSettingsDialog.InitialDirectory = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\"


		SaveSettingsDialog.FileName = Form1.dompersonalitycombobox.Text & " Glitter Settings"

		If SaveSettingsDialog.ShowDialog() = DialogResult.OK Then
			Dim SettingsPath As String = SaveSettingsDialog.FileName
			Dim SettingsList As New List(Of String)
			SettingsList.Clear()


			If My.Settings.CBGlitterFeed = True Then SettingsList.Add("Glitter Feed: On")
			If My.Settings.CBGlitterFeedScripts = True Then SettingsList.Add("Glitter Feed: Scripts")
			If My.Settings.CBGlitterFeedOff = True Then SettingsList.Add("Glitter Feed: Off")

			SettingsList.Add("Short Name: " & My.Settings.GlitterSN)
			SettingsList.Add("Domme Color: " & My.Settings.GlitterNCDommeColor.ToArgb.ToString)
			SettingsList.Add("Tease: " & My.Settings.CBTease)
			SettingsList.Add("Egotist: " & My.Settings.CBEgotist)
			SettingsList.Add("Trivia: " & My.Settings.CBTrivia)
			SettingsList.Add("Daily: " & My.Settings.CBDaily)
			SettingsList.Add("Custom 1: " & My.Settings.CBCustom1)
			SettingsList.Add("Custom 2: " & My.Settings.CBCustom2)
			SettingsList.Add("Domme Post Frequency: " & My.Settings.GlitterDSlider)

			SettingsList.Add("Contact 1 Enabled: " & My.Settings.CBGlitter1)
			SettingsList.Add("Contact 1 Name: " & My.Settings.Glitter1)
			SettingsList.Add("Contact 1 Color: " & My.Settings.GlitterNC1Color.ToArgb.ToString)
			SettingsList.Add("Contact 1 Image Directory: " & My.Settings.Contact1ImageDir)
			SettingsList.Add("Contact 1 Post Frequency: " & My.Settings.Glitter1Slider)

			SettingsList.Add("Contact 2 Enabled: " & My.Settings.CBGlitter2)
			SettingsList.Add("Contact 2 Name: " & My.Settings.Glitter2)
			SettingsList.Add("Contact 2 Color: " & My.Settings.GlitterNC2Color.ToArgb.ToString)
			SettingsList.Add("Contact 2 Image Directory: " & My.Settings.Contact2ImageDir)
			SettingsList.Add("Contact 2 Post Frequency: " & My.Settings.Glitter2Slider)

			SettingsList.Add("Contact 3 Enabled: " & My.Settings.CBGlitter3)
			SettingsList.Add("Contact 3 Name: " & My.Settings.Glitter3)
			SettingsList.Add("Contact 3 Color: " & My.Settings.GlitterNC3Color.ToArgb.ToString)
			SettingsList.Add("Contact 3 Image Directory: " & My.Settings.Contact3ImageDir)
			SettingsList.Add("Contact 3 Post Frequency: " & My.Settings.Glitter3Slider)

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
		'ISSUE: Loading a corrupted textfile results in half loaded Glitter settings.
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
				If CheckState = "On" Then My.Settings.CBGlitterFeed = True
				If CheckState = "Scripts" Then My.Settings.CBGlitterFeedScripts = True
				If CheckState = "Off" Then My.Settings.CBGlitterFeedOff = True

				My.Settings.GlitterSN = SettingsList(1).Replace("Short Name: ", "")

				Dim GlitterColor As Color = Color.FromArgb(SettingsList(2).Replace("Domme Color: ", ""))
				My.Settings.GlitterNCDommeColor = GlitterColor

				My.Settings.CBTease = SettingsList(3).Replace("Tease: ", "")
				My.Settings.CBEgotist = SettingsList(4).Replace("Egotist: ", "")
				My.Settings.CBTrivia = SettingsList(5).Replace("Trivia: ", "")
				My.Settings.CBDaily = SettingsList(6).Replace("Daily: ", "")
				My.Settings.CBCustom1 = SettingsList(7).Replace("Custom 1: ", "")
				My.Settings.CBCustom2 = SettingsList(8).Replace("Custom 2: ", "")
				My.Settings.GlitterDSlider = CInt(SettingsList(9).Replace("Domme Post Frequency: ", ""))


				My.Settings.CBGlitter1 = SettingsList(10).Replace("Contact 1 Enabled: ", "")
				My.Settings.Glitter1 = SettingsList(11).Replace("Contact 1 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(12).Replace("Contact 1 Color: ", ""))
				My.Settings.GlitterNC1Color = GlitterColor
				My.Settings.Contact1ImageDir = SettingsList(13).Replace("Contact 1 Image Directory: ", "")
				My.Settings.Glitter1Slider = SettingsList(14).Replace("Contact 1 Post Frequency: ", "")

				My.Settings.CBGlitter2 = SettingsList(15).Replace("Contact 2 Enabled: ", "")
				My.Settings.Glitter2 = SettingsList(16).Replace("Contact 2 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(17).Replace("Contact 2 Color: ", ""))
				My.Settings.GlitterNC2Color = GlitterColor
				My.Settings.Contact2ImageDir = SettingsList(18).Replace("Contact 2 Image Directory: ", "")
				My.Settings.Glitter2Slider = SettingsList(19).Replace("Contact 2 Post Frequency: ", "")

				My.Settings.CBGlitter3 = SettingsList(20).Replace("Contact 3 Enabled: ", "")
				My.Settings.Glitter3 = SettingsList(21).Replace("Contact 3 Name: ", "")
				GlitterColor = Color.FromArgb(SettingsList(22).Replace("Contact 3 Color: ", ""))
				My.Settings.GlitterNC3Color = GlitterColor
				My.Settings.Contact3ImageDir = SettingsList(23).Replace("Contact 3 Image Directory: ", "")
				My.Settings.Glitter3Slider = SettingsList(24).Replace("Contact 3 Post Frequency: ", "")

				Try
					GlitterAV.Image = Image.FromFile(SettingsList(25).Replace("Domme AV: ", ""))
					My.Settings.GlitterAV = SettingsList(25).Replace("Domme AV: ", "")
				Catch
				End Try

				Try
					GlitterAV1.Image = Image.FromFile(SettingsList(26).Replace("Contact 1 AV: ", ""))
					My.Settings.GlitterAV1 = SettingsList(26).Replace("Contact 1 AV: ", "")
				Catch
				End Try

				Try
					GlitterAV2.Image = Image.FromFile(SettingsList(27).Replace("Contact 2 AV: ", ""))
					My.Settings.GlitterAV2 = SettingsList(27).Replace("Contact 2 AV: ", "")
				Catch
				End Try

				Try
					GlitterAV3.Image = Image.FromFile(SettingsList(28).Replace("Contact 3 AV: ", ""))
					My.Settings.GlitterAV3 = SettingsList(28).Replace("Contact 3 AV: ", "")
				Catch
				End Try


			Catch
				MessageBox.Show(Me, "This Glitter settings file is invalid or has been edited incorrectly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try

		End If
	End Sub

#End Region ' Glitter

#Region "----------------------------------------- Games ------------------------------------------------"

	''' =========================================================================================================
	''' <summary>
	''' Checks if all the conditions for card games are met.
	''' </summary>
	''' <returns>Returns true if all conditions are met.</returns>
	Friend Function CardGameCheck() As Boolean
		Dim rtnVal As Boolean = True

		For Each tmpPicBox As PictureBox In New List(Of PictureBox) From
		{BP1, BP2, BP3, BP4, BP5, BP6, SP1, SP2, SP3, SP4, SP5, SP6,
		GP1, GP2, GP3, GP4, GP5, GP6, CardBack}

			' Check if the Databinding is properly set.
			If tmpPicBox.DataBindings.Item("ImageLocation") Is Nothing Then
				Throw New Exception("There is no databinding set on """ & tmpPicBox.Name &
									"""'s image location. Set the databinding and recompile!")
			End If

			tmpPicBox.AllowDrop = True

			If tmpPicBox.ImageLocation = My.Settings.GetDefault(tmpPicBox, "ImageLocation") Then
				rtnVal = False
			ElseIf File.Exists(tmpPicBox.ImageLocation) Then
				tmpPicBox.Image = Image.FromFile(tmpPicBox.ImageLocation)
			Else
				rtnVal = False
				My.Settings.ResetField(tmpPicBox, "ImageLocation")
			End If
		Next

		'>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Card names <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		For Each tmpTbx As TextBox In New List(Of TextBox) From
				{BN1, BN2, BN3, BN4, BN5, BN6,
				SN1, SN2, SN3, SN4, SN5, SN6,
				GN1, GN2, GN3, GN4, GN5, GN6}

			If tmpTbx.DataBindings.Item("Text") Is Nothing Then
				Throw New Exception("There is no databinding set on """ & tmpTbx.Name &
									"""'s text property. Set the databinding and recompile!")
			End If

			If tmpTbx.Text.Length < 1 Then My.Settings.ResetField(tmpTbx, "Text")
		Next
		Return rtnVal
	End Function

	''' =========================================================================================================
	''' <summary>
	''' Sets a Cardimage for the given picturebox.
	''' </summary>
	''' <param name="sender">The PictureBox to set the Image.</param>
	''' <param name="filepath">The image filepath to set.</param>
	''' <remarks>The PictureBox must have a databinding between the 
	''' ImageLoaction-Property and My.Settings.</remarks>
	Private Sub CardImageSet(sender As PictureBox, filepath As String)
		Try
			Dim target As PictureBox = CType(sender, PictureBox)
			Dim savePath As String = String.Format("{0}\Images\Cards\Card{1}.bmp",
												   Application.StartupPath,
												   target.Name)

			savePath = savePath.Replace("CardCard", "Card")

			' Close Games form and end file access.
			If FrmCardList.Visible Then FrmCardList.Dispose()
			FrmCardList.ClearAllCards()

			' Release all ressources.
			If target.Image IsNot Nothing Then target.Image.Dispose()
			target.Image = Nothing
			target.ImageLocation = ""

			GC.Collect()
			Application.DoEvents()

			' Check if the file is locked. Sometimes the GC needs some time
			' to finally release the file lock after the image was disposed.
			Dim retrycounter As Integer = 5
			Do While IsFileLocked(savePath) AndAlso retrycounter > 0
				retrycounter -= 1
				GC.Collect()
				Application.DoEvents()
			Loop

			If retrycounter <= 0 Then Throw New IO.IOException(
				String.Format("The file """"{0}"" is already in use."), savePath)

			' Check if the Databinding is properly set.
			If target.DataBindings.Item("ImageLocation") Is Nothing Then
				Throw New Exception("There is no databinding set on """ & target.Name &
									"""'s image location. Set the databinding and recompile!")
			End If

			' Set the resized image as picturebox image and write it to disk
			target.Image = ResizeImage(filepath, New Size(138, 179))
			target.Image.Save(savePath)

			' Set the image Location-Property. Property has to be databound with My.Settings!
			target.ImageLocation = savePath

			' Writing to databound Imagelocation doesn't update My.Settings!
			' Now we write the value directly using the binding to get the My.Settings.Member to write to.
			My.Settings(target.DataBindings.Item("ImageLocation").BindingMemberInfo.BindingField) = savePath


			Form1.GamesToolStripMenuItem1.Enabled = CardGameCheck()
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MsgBox(ex.Message, MsgBoxStyle.Critical, "Unable to set Card Image")
		End Try
	End Sub

	Private Sub CardPictureboxes_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles _
										BP1.DragEnter, BP2.DragEnter, BP3.DragEnter, BP4.DragEnter, BP5.DragEnter, BP6.DragEnter,
										SP1.DragEnter, SP2.DragEnter, SP3.DragEnter, SP4.DragEnter, SP5.DragEnter, SP6.DragEnter,
										GP1.DragEnter, GP2.DragEnter, GP3.DragEnter, GP4.DragEnter, GP5.DragEnter, GP6.DragEnter,
										CardBack.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub CardPictureboxes_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles _
										BP1.DragDrop, BP2.DragDrop, BP3.DragDrop, BP4.DragDrop, BP5.DragDrop, BP6.DragDrop,
										SP1.DragDrop, SP2.DragDrop, SP3.DragDrop, SP4.DragDrop, SP5.DragDrop, SP6.DragDrop,
										GP1.DragDrop, GP2.DragDrop, GP3.DragDrop, GP4.DragDrop, GP5.DragDrop, GP6.DragDrop,
										CardBack.DragDrop
		CardImageSet(CType(sender, PictureBox), CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0))
	End Sub

	Private Sub CardPictureboxes_Click(sender As System.Object, e As System.EventArgs) Handles _
										BP1.Click, BP2.Click, BP3.Click, BP4.Click, BP5.Click, BP6.Click,
										SP1.Click, SP2.Click, SP3.Click, SP4.Click, SP5.Click, SP6.Click,
										GP1.Click, GP2.Click, GP3.Click, GP4.Click, GP5.Click, GP6.Click,
										CardBack.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			CardImageSet(CType(sender, PictureBox), OpenFileDialog1.FileName)
		End If
	End Sub

	''' <summary>
	''' Resets the databinding source of a TextBox to its initial value, if there is no Text entered.
	''' </summary>
	Private Sub CardTextboxes_Validating(sender As Object, e As CancelEventArgs) Handles _
										BN1.Validating, BN2.Validating, BN3.Validating, BN4.Validating, BN5.Validating, BN6.Validating,
										SN1.Validating, SN2.Validating, SN3.Validating, SN4.Validating, SN5.Validating, SN6.Validating,
										GN1.Validating, GN2.Validating, GN3.Validating, GN4.Validating, GN5.Validating, GN6.Validating
		Dim tmpTbx As TextBox = CType(sender, TextBox)

		If tmpTbx.Text = "" AndAlso tmpTbx.DataBindings("Text") IsNot Nothing Then
			My.Settings.ResetField(tmpTbx, "Text")
			e.Cancel = False
		End If
	End Sub

#End Region ' Games

#End Region ' Apps

#Region "-------------------------------------- URL Files -----------------------------------------------"

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
		ApproveImage = 1
	End Sub

	Private Sub BTNWIContinue_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIContinue.Click
		ApproveImage = 2
	End Sub

	Private Sub BTNCancel_Click(sender As System.Object, e As System.EventArgs) Handles BTNWICancel.Click
		If BWURLFiles.IsBusy Then BWURLFiles.CancelAsync()
	End Sub

	Private Sub BTNWIRemove_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIRemove.Click


		WebImageLines.Remove(WebImageLines(WebImageLine))


		If WebImageLine = WebImageLines.Count Then WebImageLine = 0
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

		WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(WebImageLine))))

		Debug.Print(WebImageLines(WebImageLine))

		My.Computer.FileSystem.DeleteFile(WebImagePath)

		If File.Exists(WebImagePath) Then
			Debug.Print("File Exists")
		Else
			Debug.Print("Nope")
		End If

		My.Computer.FileSystem.WriteAllText(WebImagePath, String.Join(Environment.NewLine, WebImageLines), False)

	End Sub

	Private Sub BTNWILiked_Click(sender As System.Object, e As System.EventArgs) Handles BTNWILiked.Click


		If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & WebImageLines(WebImageLine), True)
		Else
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", WebImageLines(WebImageLine), True)
		End If


	End Sub

	Private Sub BTNWIDisliked_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIDisliked.Click

		If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & WebImageLines(WebImageLine), True)
		Else
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", WebImageLines(WebImageLine), True)
		End If

	End Sub

	Private Sub WebPictureBox_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles WebPictureBox.MouseWheel

		Select Case e.Delta
			Case -120 'Scrolling down
				WebImageLine += 1

				If WebImageLine > WebImageLineTotal - 1 Then
					WebImageLine = WebImageLineTotal
					MsgBox("No more images to display!", , "Warning!")
					Return
				End If

				Try
					WebPictureBox.Image.Dispose()
				Catch
				End Try
				WebPictureBox.Image = Nothing
				GC.Collect()

				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(WebImageLine))))
				LBLWebImageCount.Text = WebImageLine + 1 & "/" & WebImageLineTotal
			Case 120 'Scrolling up
				WebImageLine -= 1

				If WebImageLine < 0 Then
					WebImageLine = 0
					MsgBox("No more images to display!", , "Warning!")
					Return
				End If

				Try
					WebPictureBox.Image.Dispose()
				Catch
				End Try
				WebPictureBox.Image = Nothing
				GC.Collect()
				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(WebImageLine))))
				LBLWebImageCount.Text = WebImageLine + 1 & "/" & WebImageLineTotal
		End Select


	End Sub

	Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebPictureBox.MouseEnter
		WebPictureBox.Focus()
	End Sub


	Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles BTNWIOpenURL.Click

		WebImageFileDialog.InitialDirectory = Application.StartupPath & "\Images\System\URL Files"

		If (WebImageFileDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then

			WebImageFile = New IO.StreamReader(WebImageFileDialog.FileName)
			WebImagePath = WebImageFileDialog.FileName

			WebImageLines.Clear()

			WebImageLine = 0
			WebImageLineTotal = 0

			While WebImageFile.Peek <> -1
				WebImageLineTotal += 1
				WebImageLines.Add(WebImageFile.ReadLine())
			End While

			Try
				WebPictureBox.Image.Dispose()
			Catch
			End Try
			WebPictureBox.Image = Nothing
			GC.Collect()

			Try
				WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(0))))
			Catch
				MessageBox.Show(Me, "Failed to load URL File image!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try

			WebImageFile.Close()
			WebImageFile.Dispose()

			LBLWebImageCount.Text = WebImageLine + 1 & "/" & WebImageLineTotal


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

		WebImageLine += 1

		If WebImageLine > WebImageLineTotal - 1 Then
			WebImageLine = WebImageLineTotal
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
			WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(WebImageLine))))
			LBLWebImageCount.Text = WebImageLine + 1 & "/" & WebImageLineTotal
		Catch ex As Exception
			GoTo TryNextImage
		End Try



	End Sub

	Private Sub Button18_Click_2(sender As System.Object, e As System.EventArgs) Handles BTNWIPrevious.Click

trypreviousimage:

		WebImageLine -= 1

		If WebImageLine < 0 Then
			WebImageLine = 0
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
			WebPictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(WebImageLines(WebImageLine))))
			LBLWebImageCount.Text = WebImageLine + 1 & "/" & WebImageLineTotal
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

			WebImage = WebImageLines(WebImageLine)

			Dim DirSplit As String() = WebImage.Split("/")
			WebImage = DirSplit(DirSplit.Length - 1)

			' ### Clean Code
			'Do Until Not Form1.WebImage.Contains("/")
			'Form1.WebImage = Form1.WebImage.Remove(0, 1)
			'Loop

			SaveFileDialog1.FileName = WebImage

		Catch ex As Exception

			SaveFileDialog1.FileName = "image.jpg"

		End Try





		If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

			WebPictureBox.Image.Save(SaveFileDialog1.FileName)

		End If

	End Sub

	Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles BTNWICreateURL.Click,
																					   BTNMaintenanceRefresh.Click,
																					   BTNMaintenanceRebuild.Click
        ' Group Buttons by inital-State.
        Dim __PreEnabled As New List(Of Control) From
			{BTNWIOpenURL, BTNWICreateURL, BTNMaintenanceRefresh,
			BTNMaintenanceRebuild, BTNMaintenanceScripts}
		Dim __PreDisabled As New List(Of Control) From
			{BTNWICancel, BTNMaintenanceCancel}

		Try
            ' Set their new State, so the User can't disturb.
            __PreEnabled.ForEach(Sub(x) x.Enabled = False)
			__PreDisabled.ForEach(Sub(x) x.Enabled = True)

			Select Case sender.name
				Case BTNWICreateURL.Name
                    '**************************************************************************************************************
                    '                                                Create URL-File
                    '**************************************************************************************************************
                    Dim __BtnLocalURL As New List(Of Control) From {
						BTNWINext, BTNWIPrevious, BTNWIRemove, BTNWILiked, BTNWIDisliked, BTNWISave}
					Try
                        ' Disable Buttons for Opening-URL-Files
                        __BtnLocalURL.ForEach(Sub(x) x.Enabled = False)

                        ' Run Backgroundworker
                        Dim __tmpResult As URL_File_BGW.CreateUrlFileResult = BWURLFiles.CreateURLFileAsync()

                        ' Activate the created URL-File
                        URL_File_Set(__tmpResult.Filename)

						' UserInfo
						If __tmpResult._Error Is Nothing Then
							MsgBox("URL File has been saved to:" &
							   vbCrLf & vbCrLf & Application.StartupPath & "\Images\System\URL Files\" & __tmpResult.Filename & ".txt" &
							   vbCrLf & vbCrLf & "Use the ""Open URL File"" button to load and view your collections.",  , "Success!")
						Else
							MsgBox("It is encountered an error during URL-File-Creation." & vbCrLf &
								   __tmpResult._Error.Message & vbCrLf &
									   "URL File has been saved to:" &
									vbCrLf & vbCrLf & Application.StartupPath & "\Images\System\URL Files\" & __tmpResult.Filename & ".txt" &
									vbCrLf & vbCrLf & "Use the ""Open URL File"" button to load and view your collections.",  , "Successful despite errors!")
						End If
					Catch
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        '                                            All Errors
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        Throw
					Finally
                        '⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
                        __BtnLocalURL.ForEach(Sub(x) x.Enabled = True)
					End Try
				Case BTNMaintenanceRefresh.Name
                    '**************************************************************************************************************
                    '                                             Refresh URL-Files
                    '**************************************************************************************************************
                    Try

                        ' Run Backgroundworker
                        Dim __tmpResult As URL_File_BGW.MaintainUrlResult = BWURLFiles.RefreshURLFilesAsync()

                        ' Activate the URL-Files
                        __tmpResult.MaintainedUrlFiles.ForEach(AddressOf URL_File_Set)

						If __tmpResult.Cancelled Then
							MessageBox.Show(Me, "Refreshing URL-File has been aborted after " & __tmpResult.MaintainedUrlFiles.Count & " URL-Files." &
											vbCrLf & __tmpResult.ModifiedLinkCount & " new URLs have been added.",
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						ElseIf __tmpResult.ErrorText.Capacity > 0
							MessageBox.Show(Me, "URL Files have been refreshed with errors!" &
											vbCrLf & vbCrLf & __tmpResult.ModifiedLinkCount & " new URLs have been added." &
											vbCrLf & vbCrLf & String.Join(vbCrLf, __tmpResult.ErrorText),
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						Else
							MessageBox.Show(Me, "All URL Files have been refreshed!" &
											vbCrLf & vbCrLf & __tmpResult.ModifiedLinkCount & " new URLs have been added.",
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						End If
					Catch
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        '                                            All Errors
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        Throw
					Finally
                        '⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
                        LBLMaintenance.Text = String.Empty
						PBCurrent.Value = 0
						PBMaintenance.Value = 0
					End Try
				Case BTNMaintenanceRebuild.Name
                    '**************************************************************************************************************
                    '                                             Rebuild URL-Files
                    '**************************************************************************************************************
                    Try
                        ' Run Backgroundworker
                        Dim __tmpResult As URL_File_BGW.MaintainUrlResult = BWURLFiles.RebuildURLFilesAsync()

                        ' Activate the URL-Files
                        __tmpResult.MaintainedUrlFiles.ForEach(AddressOf URL_File_Set)

						If __tmpResult.Cancelled Then
							MessageBox.Show(Me, "Rebuilding URL-File has been aborted after " & __tmpResult.MaintainedUrlFiles.Count & " URL-Files." &
											vbCrLf & __tmpResult.ModifiedLinkCount & " dead URLs have been removed.",
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						ElseIf __tmpResult.ErrorText.Capacity > 0
							MessageBox.Show(Me, "URL Files have been rebuilded with errors!" &
											vbCrLf & vbCrLf & __tmpResult.ModifiedLinkCount & " dead URLs have been removed." &
											vbCrLf & vbCrLf & __tmpResult.LinkCountTotal & " URLs in total." &
											vbCrLf & vbCrLf & String.Join(vbCrLf, __tmpResult.ErrorText),
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						Else
							MessageBox.Show(Me, "All URL Files have been rebuilded!" &
											vbCrLf & vbCrLf & __tmpResult.ModifiedLinkCount & " dead URLs have been removed." &
											vbCrLf & vbCrLf & __tmpResult.LinkCountTotal & " URLs in total.",
											"Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						End If
					Catch
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        '                                            All Errors
                        '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                        Throw
					Finally
                        '⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
                        LBLMaintenance.Text = String.Empty
						PBCurrent.Value = 0
						PBMaintenance.Value = 0
					End Try
			End Select
		Catch ex As Exception
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            '                                            All Errors
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            If ex.InnerException IsNot Nothing Then
                ' If an Error ocurred in the other Thread, initial Exception is innner one.
                MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical, "Error Creating URL-File")
			Else
                ' Otherwise show it normal.
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Creating URL-File")
			End If
		Finally
            '⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
            ' Restore the initial State of the Buttons
            __PreEnabled.ForEach(Sub(x) x.Enabled = True)
			__PreDisabled.ForEach(Sub(x) x.Enabled = False)
		End Try
	End Sub

#Region "-------------------------------------- Backgroundworker URL Files --------------------------------------"

	''' =========================================================================================================
	''' <summary>
	''' This Event is used, to gather Variables, for the BackgroundThread, the User can change during runtime.
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub BWURLFiles_URLCreate_User_Interactions(ByVal sender As URL_File_BGW, ByRef e As URL_File_BGW.UserActions) Handles BWURLFiles.URL_FileCreate_UserInteractions
		If Me.InvokeRequired Then
			Dim Callbak As New URL_File_BGW.URL_FileCreate_UserInteractions_Delegate(AddressOf BWURLFiles_URLCreate_User_Interactions)
			Me.Invoke(Callbak, sender, e)
		Else
			e.ReviewImages = CBWIReview.Checked
			e.ApproveImage = ApproveImage
			e.SaveImages = CBWISaveToDisk.Checked
			e.ImgSaveDir = TBWIDirectory.Text
		End If
	End Sub

    ''' =========================================================================================================
    ''' <summary>
    ''' This Event will be triggered, when the Working Stage of the BGW changes
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="e"></param>
    Private Sub BWURLFiles_ProgressChanged(ByVal Sender As Object, ByRef e As URL_File_BGW.URL_File_ProgressChangedEventArgs) Handles BWURLFiles.URL_File_ProgressChanged
		If Me.InvokeRequired Then
            ' Beware: Event is fired in Worker Thread, so you need to do a Function Callback.
            Dim CallBack As New URL_File_BGW.URL_File_ProgressChanged_Delegate(AddressOf BWURLFiles_ProgressChanged)
			Me.Invoke(CallBack, Sender, e)
		Else
            ' Reset remanent Marker for Image Approval
            If ApproveImage <> 0 Then ApproveImage = 0
			Select Case e.CurrentTask
				Case URL_File_Tasks.CreateURLFile
                    '===============================================================================
                    '                           Create URL-File
                    '===============================================================================
                    Select Case e.ActStage
                        ' ------------------------ Image Approval -------------------------------
                        Case WorkingStages.ImageApproval
							If e.ImageToReview IsNot Nothing Then
                                ' Dispose old Image & Set new Image
                                Try : WebPictureBox.Image.Dispose() : Catch : End Try
								WebPictureBox.Image = e.ImageToReview
                                ' Enabled UI Elements
                                BTNWIContinue.Enabled = True
								BTNWIAddandContinue.Enabled = True
							End If
						Case WorkingStages.Writing_File
                            ' ---------------------- Write to File -------------------------------
                            'State info to User
                            LBLWebImageCount.Text = "Writing"
                            ' At this state no cnancel possible
                            BTNWICancel.Enabled = False
							WebPictureBox.Image = Nothing
						Case Else
                            ' ---------------------- Everthing else ------------------------------
                            ' Refresh Progressbars
                            WebImageProgressBar.Maximum = e.BlogPageTotal + 1
							WebImageProgressBar.Value = e.BlogPage
                            ' Disable Image Approval-UI
                            BTNWIContinue.Enabled = False
							BTNWIAddandContinue.Enabled = False
                            ' Inform User about BGW-State
                            LBLWebImageCount.Text = String.Format("{0}/{1} ({2})", e.BlogPage, e.BlogPageTotal, e.ImageCount)
					End Select
				Case Else
                    '===============================================================================
                    '                           Refresh URL-File
                    '===============================================================================
                    LBLMaintenance.Text = e.InfoText
					PBCurrent.Maximum = e.BlogPageTotal
					PBCurrent.Value = e.BlogPage
					PBMaintenance.Maximum = e.OverallProgressTotal
					PBMaintenance.Value = e.OverallProgress
			End Select
		End If
	End Sub

#End Region

#End Region ' Url Files

#Region "--------------------------------------- Images -------------------------------------------------"

	Friend Shared Function Image_FolderCheck(ByVal directoryDescription As String,
											 ByVal directoryPath As String,
											 ByVal defaultPath As String,
											 ByRef subDirectories As Boolean) As String
		Dim rtnPath As String

		' Exit if default value.
		If directoryPath = defaultPath Then subDirectories = False : Return defaultPath

		' check it if the directory exists.
		If Directory.Exists(directoryPath) Then rtnPath = directoryPath : GoTo checkFolder

		' Tell User, the dir. wasn't found. Ask to search manually for the folder.
		If MessageBox.Show(ActiveForm,
						   "The directory """ & directoryPath & """ was not found." & vbCrLf & "Do you want to search for it?",
						   directoryDescription & " image directory not found.",
						   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
set_default:
			Return defaultPath
		Else
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'								Set new Folder
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
set_newFolder:
			' Find the first available parent-directory. 
			' This way the user hasn't to browse through his hole IO-System.
			Dim __tmp_dir As String = directoryPath
			Do Until Directory.Exists(__tmp_dir) Or __tmp_dir Is Nothing
				__tmp_dir = Path.GetDirectoryName(__tmp_dir)
			Loop

			' Initialize new Dialog-Form
			Dim FolSel As New FolderBrowserDialog With {.SelectedPath = __tmp_dir,
															.Description = "Select " & directoryDescription & " image folder."}
			' Display the Dialog -> Now the user has to set the new dir.
			If FolSel.ShowDialog(ActiveForm) = DialogResult.OK Then
				rtnPath = FolSel.SelectedPath
			Else
				GoTo set_default
			End If
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' Set new Folder - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		End If ' END IF - Messagebox.

		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		'							   Check folder content
		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
checkFolder:
		Dim count_top As Integer = myDirectory.GetFilesImages(rtnPath, SearchOption.TopDirectoryOnly).Count
		Dim count_all As Integer = myDirectory.GetFilesImages(rtnPath, SearchOption.AllDirectories).Count

		If count_top = 0 And count_all = 0 Then
			' ================================= No images in folder ===============================
			If MessageBox.Show(ActiveForm,
			   "The directory """ & directoryPath & """ doesn't contain images." & vbCrLf & "Do you want to set a new folder?",
			   directoryDescription & " image folder empty",
			   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
				GoTo set_newFolder
			Else
				GoTo set_default
			End If
		ElseIf count_top = 0 And count_all > count_top And subDirectories = False
			' ======================== none in top, but in sub ->enable sub? ======================
			If MessageBox.Show(ActiveForm,
			   "The directory """ & directoryPath & """ doesn't contain images, but it's " &
			   "subdirectories. Do you want to include subdirectories? If you click no the " &
			   "default value will be set.",
			   directoryDescription & " image folder empty",
			   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				subDirectories = True
				Return rtnPath
			Else
				GoTo set_default
			End If
		Else
			'================================= everything fine ====================================
			Return rtnPath
		End If
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' Check folder content - End
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
	End Function

#Region "------------------------------------- Hardcore Images -------------------------------------------"

	Private Sub BTNIHardcore_Click(sender As System.Object, e As System.EventArgs) Handles BTNIHardcore.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IHardcore = FolderBrowserDialog1.SelectedPath
			ImagesHardcore_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesHardcore_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IHardcoreSD

		Dim def As String =
			My.Settings.PropertyValues("IHardcore").Property.DefaultValue

		My.Settings.IHardcore =
			Image_FolderCheck("Hardcore", My.Settings.IHardcore, def, subdir)

		If My.Settings.IHardcore = def Then
			My.Settings.CBIHardcore = False
			My.Settings.IHardcoreSD = My.Settings.PropertyValues("IHardcoreSD").Property.DefaultValue
		Else
			My.Settings.CBIHardcore = True
			My.Settings.IHardcoreSD = subdir
		End If

		Return My.Settings.CBIHardcore
	End Function

#End Region ' Hardcore

#Region "------------------------------------- Softcore Images -------------------------------------------"

	Private Sub BTNISoftcore_Click(sender As System.Object, e As System.EventArgs) Handles BTNISoftcore.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.ISoftcore = FolderBrowserDialog1.SelectedPath
			ImagesSoftcore_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesSoftcore_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.ISoftcoreSD

		Dim def As String =
			My.Settings.PropertyValues("ISoftcore").Property.DefaultValue

		My.Settings.ISoftcore =
			Image_FolderCheck("Softcore", My.Settings.ISoftcore, def, subdir)

		If My.Settings.ISoftcore = def Then
			My.Settings.CBISoftcore = False
			My.Settings.ISoftcoreSD = My.Settings.PropertyValues("ISoftcoreSD").Property.DefaultValue
		Else
			My.Settings.CBISoftcore = True
			My.Settings.ISoftcoreSD = subdir
		End If

		Return My.Settings.CBISoftcore
	End Function

#End Region ' Softcore

#Region "------------------------------------- Lesbian Images --------------------------------------------"

	Private Sub BTNILesbian_Click(sender As System.Object, e As System.EventArgs) Handles BTNILesbian.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.ILesbian = FolderBrowserDialog1.SelectedPath
			ImagesLesbian_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesLesbian_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.ILesbianSD

		Dim def As String =
			My.Settings.PropertyValues("ILesbian").Property.DefaultValue

		My.Settings.ILesbian =
			Image_FolderCheck("Lesbian", My.Settings.ILesbian, def, subdir)

		If My.Settings.ILesbian = def Then
			My.Settings.CBILesbian = False
			My.Settings.ILesbianSD = My.Settings.PropertyValues("ILesbianSD").Property.DefaultValue
		Else
			My.Settings.CBILesbian = True
			My.Settings.ILesbianSD = subdir
		End If

		Return My.Settings.CBILesbian
	End Function

#End Region ' Lesbian

#Region "------------------------------------- Blowjob Images --------------------------------------------"

	Private Sub BTNIBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles BTNIBlowjob.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IBlowjob = FolderBrowserDialog1.SelectedPath
			ImagesBlowjob_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesBlowjob_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IBlowjobSD

		Dim def As String =
			My.Settings.PropertyValues("IBlowjob").Property.DefaultValue

		My.Settings.IBlowjob =
			Image_FolderCheck("Blowjob", My.Settings.IBlowjob, def, subdir)

		If My.Settings.IBlowjob = def Then
			My.Settings.CBIBlowjob = False
			My.Settings.IBlowjobSD = My.Settings.PropertyValues("IBlowjobSD").Property.DefaultValue
		Else
			My.Settings.CBIBlowjob = True
			My.Settings.IBlowjobSD = subdir
		End If

		Return My.Settings.CBIBlowjob
	End Function

#End Region ' Blowjob

#Region "------------------------------------- Femdom Images ---------------------------------------------"

	Private Sub BTNIFemdom_Click(sender As System.Object, e As System.EventArgs) Handles BTNIFemdom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IFemdom = FolderBrowserDialog1.SelectedPath
			ImagesFemdom_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesFemdom_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IFemdomSD

		Dim def As String =
			My.Settings.PropertyValues("IFemdom").Property.DefaultValue

		My.Settings.IFemdom =
			Image_FolderCheck("Femdom", My.Settings.IFemdom, def, subdir)

		If My.Settings.IFemdom = def Then
			My.Settings.CBIFemdom = False
			My.Settings.IFemdomSD = My.Settings.PropertyValues("IFemdomSD").Property.DefaultValue
		Else
			My.Settings.CBIFemdom = True
			My.Settings.IFemdomSD = subdir
		End If

		Return My.Settings.CBIFemdom
	End Function

#End Region ' Femdom

#Region "------------------------------------- Lezdom Images ---------------------------------------------"

	Private Sub BTNILezdom_Click(sender As System.Object, e As System.EventArgs) Handles BTNILezdom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.ILezdom = FolderBrowserDialog1.SelectedPath
			ImagesLezdom_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesLezdom_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.ILezdomSD

		Dim def As String =
			My.Settings.PropertyValues("ILezdom").Property.DefaultValue

		My.Settings.ILezdom =
			Image_FolderCheck("Lezdom", My.Settings.ILezdom, def, subdir)

		If My.Settings.ILezdom = def Then
			My.Settings.CBILezdom = False
			My.Settings.ILezdomSD = My.Settings.PropertyValues("ILezdomSD").Property.DefaultValue
		Else
			My.Settings.CBILezdom = True
			My.Settings.ILezdomSD = subdir
		End If

		Return My.Settings.CBILezdom
	End Function

#End Region ' Lezdon

#Region "------------------------------------- Hentai Images ---------------------------------------------"

	Private Sub BTNIHentai_Click(sender As System.Object, e As System.EventArgs) Handles BTNIHentai.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IHentai = FolderBrowserDialog1.SelectedPath
			ImagesHentai_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesHentai_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IHentaiSD

		Dim def As String =
			My.Settings.PropertyValues("IHentai").Property.DefaultValue

		My.Settings.IHentai =
			Image_FolderCheck("Hentai", My.Settings.IHentai, def, subdir)

		If My.Settings.IHentai = def Then
			My.Settings.CBIHentai = False
			My.Settings.IHentaiSD = My.Settings.PropertyValues("IHentaiSD").Property.DefaultValue
		Else
			My.Settings.CBIHentai = True
			My.Settings.IHentaiSD = subdir
		End If

		Return My.Settings.CBIHentai
	End Function

#End Region ' Hentai

#Region "------------------------------------- Gay Images ------------------------------------------------"

	Private Sub BTNIGay_Click(sender As System.Object, e As System.EventArgs) Handles BTNIGay.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IGay = FolderBrowserDialog1.SelectedPath
			ImagesGay_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesGay_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IGaySD

		Dim def As String =
			My.Settings.PropertyValues("IGay").Property.DefaultValue

		My.Settings.IGay =
			Image_FolderCheck("Gay", My.Settings.IGay, def, subdir)

		If My.Settings.IGay = def Then
			My.Settings.CBIGay = False
			My.Settings.IGaySD = My.Settings.PropertyValues("IGaySD").Property.DefaultValue
		Else
			My.Settings.CBIGay = True
			My.Settings.IGaySD = subdir
		End If

		Return My.Settings.CBIGay
	End Function

#End Region ' Gay

#Region "------------------------------------- Maledom Images ---------------------------------------------"

	Private Sub BTNIMaledom_Click(sender As System.Object, e As System.EventArgs) Handles BTNIMaledom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IMaledom = FolderBrowserDialog1.SelectedPath
			ImagesMaledom_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesMaledom_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IMaledomSD

		Dim def As String =
			My.Settings.PropertyValues("IMaledom").Property.DefaultValue

		My.Settings.IMaledom =
			Image_FolderCheck("Maledom", My.Settings.IMaledom, def, subdir)

		If My.Settings.IMaledom = def Then
			My.Settings.CBIMaledom = False
			My.Settings.IMaledomSD = My.Settings.PropertyValues("IMaledomSD").Property.DefaultValue
		Else
			My.Settings.CBIMaledom = True
			My.Settings.IMaledomSD = subdir
		End If

		Return My.Settings.CBIMaledom
	End Function

#End Region ' Maledom

#Region "------------------------------------- General Images ---------------------------------------------"

	Private Sub BTNIGeneral_Click(sender As System.Object, e As System.EventArgs) Handles BTNIGeneral.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.IGeneral = FolderBrowserDialog1.SelectedPath
			ImagesGeneral_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesGeneral_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.IGeneralSD

		Dim def As String =
			My.Settings.PropertyValues("IGeneral").Property.DefaultValue

		My.Settings.IGeneral =
			Image_FolderCheck("General", My.Settings.IGeneral, def, subdir)

		If My.Settings.IGeneral = def Then
			My.Settings.CBIGeneral = False
			My.Settings.IGeneralSD = My.Settings.PropertyValues("IGeneralSD").Property.DefaultValue
		Else
			My.Settings.CBIGeneral = True
			My.Settings.IGeneralSD = subdir
		End If

		Return My.Settings.CBIGeneral
	End Function

#End Region ' General

#Region "------------------------------------- Captions Images ---------------------------------------------"

	Private Sub BTNICaptions_Click(sender As System.Object, e As System.EventArgs) Handles BTNICaptions.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.ICaptions = FolderBrowserDialog1.SelectedPath
			ImagesCaptions_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesCaptions_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.ICaptionsSD

		Dim def As String =
			My.Settings.PropertyValues("ICaptions").Property.DefaultValue

		My.Settings.ICaptions =
			Image_FolderCheck("Captions", My.Settings.ICaptions, def, subdir)

		If My.Settings.ICaptions = def Then
			My.Settings.CBICaptions = False
			My.Settings.ICaptionsSD = My.Settings.PropertyValues("ICaptionsSD").Property.DefaultValue
		Else
			My.Settings.CBICaptions = True
			My.Settings.ICaptionsSD = subdir
		End If

		Return My.Settings.CBICaptions
	End Function

#End Region ' Captions

#Region "------------------------------------- Boobs Images ----------------------------------------------"

	Private Sub BTNBoobPath_Click(sender As System.Object, e As System.EventArgs) Handles BTNBoobPath.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.LBLBoobPath = FolderBrowserDialog1.SelectedPath
			ImagesBoobs_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesBoobs_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.CBBoobSubDir

		Dim def As String =
			My.Settings.PropertyValues("LBLBoobPath").Property.DefaultValue

		My.Settings.LBLBoobPath =
			Image_FolderCheck("Boobs", My.Settings.LBLBoobPath, def, subdir)

		If My.Settings.LBLBoobPath = def Then
			My.Settings.CBIBoobs = False
			My.Settings.CBBoobSubDir = My.Settings.PropertyValues("CBBoobSubDir").Property.DefaultValue
		Else
			My.Settings.CBIBoobs = True
			My.Settings.CBBoobSubDir = subdir
		End If

		Return My.Settings.CBIBoobs
	End Function

#End Region ' Boobs

#Region "------------------------------------- Butts Images ----------------------------------------------"

	Private Sub BTNButtPath_Click(sender As System.Object, e As System.EventArgs) Handles BTNButtPath.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.LBLButtPath = FolderBrowserDialog1.SelectedPath
			ImagesButts_CheckFolder()
		End If
	End Sub

	Friend Shared Function ImagesButts_CheckFolder() As Boolean
		Dim subdir As Boolean = My.Settings.CBButtSubDir

		Dim def As String =
			My.Settings.PropertyValues("LBLButtPath").Property.DefaultValue

		My.Settings.LBLButtPath =
			Image_FolderCheck("Butts", My.Settings.LBLButtPath, def, subdir)

		If My.Settings.LBLButtPath = def Then
			My.Settings.CBIButts = False
			My.Settings.CBButtSubDir = My.Settings.PropertyValues("CBButtSubDir").Property.DefaultValue
		Else
			My.Settings.CBIButts = True
			My.Settings.CBButtSubDir = subdir
		End If

		Return My.Settings.CBIButts
	End Function

#End Region ' Butt


	Private Sub LBLIHardcore_Click(sender As System.Object, e As System.EventArgs) Handles TbxIHardcore.DoubleClick
		TbxIHardcore.Text = "No path selected"
	End Sub

	Private Sub LBLISoftcore_Click(sender As System.Object, e As System.EventArgs) Handles TbxISoftcore.DoubleClick
		TbxISoftcore.Text = "No path selected"
	End Sub

	Private Sub LBLILesbian_Click(sender As System.Object, e As System.EventArgs) Handles TbxILesbian.DoubleClick
		TbxILesbian.Text = "No path selected"
	End Sub

	Private Sub LBLIBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles TbxIBlowjob.DoubleClick
		TbxIBlowjob.Text = "No path selected"
	End Sub

	Private Sub LBLIFemdom_Click(sender As System.Object, e As System.EventArgs) Handles TbxIFemdom.DoubleClick
		TbxIFemdom.Text = "No path selected"
	End Sub

	Private Sub LBLILezdom_Click(sender As System.Object, e As System.EventArgs) Handles TbxILezdom.DoubleClick
		TbxILezdom.Text = "No path selected"
	End Sub

	Private Sub LBLIHentai_Click(sender As System.Object, e As System.EventArgs) Handles TbxIHentai.DoubleClick
		TbxIHentai.Text = "No path selected"
	End Sub

	Private Sub LBLIGay_Click(sender As System.Object, e As System.EventArgs) Handles TbxIGay.DoubleClick
		TbxIGay.Text = "No path selected"
	End Sub

	Private Sub LBLIMaledom_Click(sender As System.Object, e As System.EventArgs) Handles TbxIMaledom.DoubleClick
		TbxIMaledom.Text = "No path selected"
	End Sub

	Private Sub LBLICaptions_Click(sender As System.Object, e As System.EventArgs) Handles TbxICaptions.DoubleClick
		TbxICaptions.Text = "No path selected"
	End Sub

	Private Sub LBLIGeneral_Click(sender As System.Object, e As System.EventArgs) Handles TbxIGeneral.DoubleClick
		TbxIGeneral.Text = "No path selected"
	End Sub

	Private Sub LBLIHardcore_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIHardcore.MouseHover
		TTDir.SetToolTip(TbxIHardcore, TbxIHardcore.Text)
	End Sub
	Private Sub LBLISoftcore_MouseHover(sender As Object, e As System.EventArgs) Handles TbxISoftcore.MouseHover
		TTDir.SetToolTip(TbxISoftcore, TbxISoftcore.Text)
	End Sub
	Private Sub LBLILesbian_MouseHover(sender As Object, e As System.EventArgs) Handles TbxILesbian.MouseHover
		TTDir.SetToolTip(TbxILesbian, TbxILesbian.Text)
	End Sub
	Private Sub LBLIBlowjob_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIBlowjob.MouseHover
		TTDir.SetToolTip(TbxIBlowjob, TbxIBlowjob.Text)
	End Sub
	Private Sub LBLIFemdom_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIFemdom.MouseHover
		TTDir.SetToolTip(TbxIFemdom, TbxIFemdom.Text)
	End Sub
	Private Sub LBLILezdom_MouseHover(sender As Object, e As System.EventArgs) Handles TbxILezdom.MouseHover
		TTDir.SetToolTip(TbxILezdom, TbxILezdom.Text)
	End Sub
	Private Sub LBLIHentai_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIHentai.MouseHover
		TTDir.SetToolTip(TbxIHentai, TbxIHentai.Text)
	End Sub
	Private Sub LBLIGay_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIGay.MouseHover
		TTDir.SetToolTip(TbxIGay, TbxIGay.Text)
	End Sub
	Private Sub LBLIMaledom_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIMaledom.MouseHover
		TTDir.SetToolTip(TbxIMaledom, TbxIMaledom.Text)
	End Sub
	Private Sub LBLICaptions_MouseHover(sender As Object, e As System.EventArgs) Handles TbxICaptions.MouseHover
		TTDir.SetToolTip(TbxICaptions, TbxICaptions.Text)
	End Sub
	Private Sub LBLIGeneral_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIGeneral.MouseHover
		TTDir.SetToolTip(TbxIGeneral, TbxIGeneral.Text)
	End Sub

	Private Sub LBLBoobPath_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIBoobs.MouseHover
		TTDir.SetToolTip(TbxIBoobs, TbxIBoobs.Text)
	End Sub

	Private Sub LBLButtPath_MouseHover(sender As Object, e As System.EventArgs) Handles TbxIButts.MouseHover
		TTDir.SetToolTip(TbxIButts, TbxIButts.Text)
	End Sub

#Region "----------------------------------- GenreImages-Url-Files --------------------------------------"

	Private Sub BtnImageUrlSetFile_Click(sender As System.Object, e As System.EventArgs) Handles BtnImageUrlHardcore.Click,
					BtnImageUrlSoftcore.Click, BtnImageUrlMaledom.Click, BtnImageUrlLezdom.Click, BtnImageUrlLesbian.Click,
					BtnImageUrlHentai.Click, BtnImageUrlGeneral.Click, BtnImageUrlGay.Click, BtnImageUrlFemdom.Click,
					BtnImageUrlCaptions.Click, BtnImageUrlButt.Click, BtnImageUrlBoobs.Click, BtnImageUrlBlowjob.Click
		Try
			' Read the Row of the current Button
			Dim tmpTlpRow As Integer = TlpImageUrls.GetRow(sender)

			' Check if the Button is in the TableLayoutPanel.
			If tmpTlpRow = -1 Then Throw New Exception("Can't find control in TableLayoutPanel. " &
													   "This is a major Design issue has to be fixed in code.")

			' Get the Checkbox for the current button
			Dim tmpCheckbox As CheckBox = TlpImageUrls.GetControlFromPosition(0, tmpTlpRow)

			' Check if the Text-Property has an active Databinding.
			If tmpCheckbox.DataBindings.Item("Checked") Is Nothing Then _
				Throw New InvalidDataException("Databinding """" Checked """" was not found in Checkbox." &
												"This is a major design issue and has to be fixed in code.")

			' Get the TExtBox for the Current Button
			Dim tmpTextbox As TextBox = TlpImageUrls.GetControlFromPosition(2, tmpTlpRow)

			' Check if the Text-Property has an active Databinding.
			If tmpTextbox.DataBindings.Item("Text") Is Nothing Then _
				Throw New InvalidDataException("This function is only availabe with a Databound Textbox. " &
												"This is a major design issue and has to be fixed in code.")

			'Declare a new instance of An OpenFileDialog. Use the URL-FilePat as initial
			Dim tmpFS As New OpenFileDialog With {
				.Filter = "Textfiles|*.txt",
				.Multiselect = False,
				.CheckFileExists = True,
				.Title = "Select an " & tmpCheckbox.Text & " URL-File",
				.InitialDirectory = Form1.pathUrlFileDir}

			' Check if the URL-FilePath exits -> Otherwise create it.
			If Not Directory.Exists(tmpFS.InitialDirectory) Then _
			Directory.CreateDirectory(tmpFS.InitialDirectory)

			Dim tmpPath As String = tmpTextbox.Text
			If tmpPath.ToLower.EndsWith(".txt") Then
				If Path.IsPathRooted(tmpPath) AndAlso Directory.Exists(Path.GetDirectoryName(tmpPath)) Then
					' Set an alternate Initial directory if filepath is absolute 
					tmpFS.InitialDirectory = Path.GetDirectoryName(tmpPath)
					tmpFS.FileName = Path.GetFileName(tmpPath)
				Else
					' Set the given Filename
					tmpFS.FileName = tmpPath
				End If
			End If

			If tmpFS.ShowDialog() = DialogResult.OK Then
				If Path.GetDirectoryName(tmpFS.FileName).ToLower = Path.GetDirectoryName(Form1.pathUrlFileDir).ToLower Then
					' If the file is located standarddirectory st only the filename
					tmpTextbox.Text = tmpFS.SafeFileName
				Else
					' Otherwise set the absoulte filepath
					tmpTextbox.Text = tmpFS.FileName
				End If

				' This will force the Settings to save.
				tmpCheckbox.Checked = True
			End If
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'						       All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MsgBox(ex.Message & vbCrLf & "Please report this error at the Milovana Forum.",
				   MsgBoxStyle.Critical, "Cant Set URl-File")
			Log.WriteError(ex.Message, ex, "Error Set Url-File")
		End Try
	End Sub

#End Region 'GenreImages-Url-Files

#End Region ' Images

#Region "--------------------------------------- Videos -------------------------------------------------"

	Friend Shared Function Video_FolderCheck(ByVal directoryDescription As String, ByVal directoryPath As String, ByVal defaultPath As String) As String
		' Exit if the directory exists.
		If Directory.Exists(directoryPath) Then Return directoryPath
		' Exit if default value.
		If directoryPath = defaultPath Then Return defaultPath

		' Tell User, the dir. wasn't found. Ask to search manually for the folder.
		If MessageBox.Show(ActiveForm,
						   "The directory """ & directoryPath & """ was not found." & vbCrLf & "Do you want to search for it?",
						   directoryDescription & " directory not found.",
						   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

			' Find the first available parent-directory. 
			' This way the user hasn't to browse through his hole IO-System.
			Dim __tmp_dir As String = directoryPath
			Do Until Directory.Exists(__tmp_dir) Or __tmp_dir Is Nothing
				__tmp_dir = Path.GetDirectoryName(__tmp_dir)
			Loop

			' Initialize new Dialog-Form
			Dim FolSel As New FolderBrowserDialog With {.SelectedPath = __tmp_dir,
														.Description = "Select " & directoryDescription & " folder."}
			' Display the Dialog -> Now the user has to set the new dir.
			If FolSel.ShowDialog(ActiveForm) = DialogResult.OK Then
				Return FolSel.SelectedPath
			End If

		End If ' END IF - Messagebox.
		Return defaultPath
	End Function

	Friend Function Video_CheckAllFolders() As Integer
		Dim t As Integer = 0

		LblVideoHardCoreTotal.Text = VideoHardcore_Count() : t += CInt(LblVideoHardCoreTotal.Text)
		LblVideoSoftCoreTotal.Text = VideoSoftcore_Count() : t += CInt(LblVideoSoftCoreTotal.Text)
		LblVideoLesbianTotal.Text = VideoLesbian_Count() : t += CInt(LblVideoLesbianTotal.Text)
		LblVideoBlowjobTotal.Text = VideoBlowjob_Count() : t += CInt(LblVideoBlowjobTotal.Text)
		LblVideoFemdomTotal.Text = VideoFemdom_Count() : t += CInt(LblVideoFemdomTotal.Text)
		LblVideoFemsubTotal.Text = VideoFemsub_Count() : t += CInt(LblVideoFemsubTotal.Text)
		LblVideoJOITotal.Text = VideoJOI_Count() : t += CInt(LblVideoJOITotal.Text)
		LblVideoCHTotal.Text = VideoCH_Count() : t += CInt(LblVideoCHTotal.Text)
		LblVideoGeneralTotal.Text = VideoGeneral_Count() : t += CInt(LblVideoGeneralTotal.Text)

		LblVideoHardCoreTotalD.Text = VideoHardcoreD_Count() : t += CInt(LblVideoHardCoreTotalD.Text)
		LblVideoSoftCoreTotalD.Text = VideoSoftcoreD_Count() : t += CInt(LblVideoSoftCoreTotalD.Text)
		LblVideoLesbianTotalD.Text = VideoLesbianD_Count() : t += CInt(LblVideoLesbianTotalD.Text)
		LblVideoBlowjobTotalD.Text = VideoBlowjobD_Count() : t += CInt(LblVideoBlowjobTotalD.Text)
		LblVideoFemdomTotalD.Text = VideoFemdomD_Count() : t += CInt(LblVideoFemdomTotalD.Text)
		LblVideoFemsubTotalD.Text = VideoFemsubD_Count() : t += CInt(LblVideoFemsubTotalD.Text)
		LblVideoJOITotalD.Text = VideoJOID_Count() : t += CInt(LblVideoJOITotalD.Text)
		LblVideoCHTotalD.Text = VideoCHD_Count() : t += CInt(LblVideoCHTotalD.Text)
		LblVideoGeneralTotalD.Text = VideoGeneralD_Count() : t += CInt(LblVideoGeneralTotalD.Text)

		Return t
	End Function

	Private Sub TxbVideoFolder_MouseHover(sender As Object, e As System.EventArgs) Handles TxbVideoHardCore.MouseHover,
				TxbVideoHardCoreD.MouseHover, TxbVideoSoftCore.MouseHover, TxbVideoSoftCoreD.MouseHover, TxbVideoLesbian.MouseHover,
				TxbVideoLesbianD.MouseHover, TxbVideoBlowjob.MouseHover, TxbVideoBlowjobD.MouseHover, TxbVideoFemdom.MouseHover,
				TxbVideoFemdomD.MouseHover, TxbVideoFemsub.MouseHover, TxbVideoFemsubD.MouseHover, TxbVideoJOI.MouseHover,
				TxbVideoJOID.MouseHover, TxbVideoCH.MouseHover, TxbVideoCHD.MouseHover, TxbVideoGeneral.MouseHover, TxbVideoGeneralD.MouseHover

		TTDir.SetToolTip(sender, CType(sender, TextBox).Text)
	End Sub

	Private Sub BTNRefreshVideos_MouseHover(sender As Object, e As System.EventArgs) Handles BTNRefreshVideos.MouseHover
		TTDir.SetToolTip(BTNRefreshVideos, "Use this button to refresh video paths.")
	End Sub

#Region "----------------------------------------- Regular -----------------------------------------------"

#Region "------------------------------------- Hardcore Videos -------------------------------------------"

	Private Sub BTNVideoHardCore_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoHardCore.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoHardcore = FolderBrowserDialog1.SelectedPath
			My.Settings.CBHardcore = True
			LblVideoHardCoreTotal.Text = VideoHardcore_Count(False)
		End If
	End Sub

	Friend Shared Function VideoHardcore_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoHardcore").Property.DefaultValue

		My.Settings.VideoHardcore =
			Video_FolderCheck("Hardcore Video", My.Settings.VideoHardcore, def)

		If My.Settings.VideoHardcore = def Then My.Settings.CBHardcore = False

		Return My.Settings.CBHardcore
	End Function

	Friend Shared Function VideoHardcore_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoHardcore_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoHardcore).Count
	End Function

#End Region ' Hardcore

#Region "------------------------------------- Softcore Videos -------------------------------------------"

	Private Sub BTNVideoSoftCore_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoSoftCore.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoSoftcore = FolderBrowserDialog1.SelectedPath
			My.Settings.CBSoftcore = True
			LblVideoSoftCoreTotal.Text = VideoSoftcore_Count(False)
		End If
	End Sub

	Friend Shared Function VideoSoftcore_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoSoftcore").Property.DefaultValue

		My.Settings.VideoSoftcore =
			Video_FolderCheck("Softcore Video", My.Settings.VideoSoftcore, def)

		If My.Settings.VideoSoftcore = def Then My.Settings.CBSoftcore = False

		Return My.Settings.CBSoftcore
	End Function

	Friend Shared Function VideoSoftcore_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoSoftcore_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoSoftcore).Count
	End Function

#End Region ' Softcore

#Region "------------------------------------- Lesbian Videos --------------------------------------------"

	Private Sub BTNVideoLesbian_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoLesbian.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoLesbian = FolderBrowserDialog1.SelectedPath
			My.Settings.CBLesbian = True
			LblVideoLesbianTotal.Text = VideoLesbian_Count(False)
		End If
	End Sub

	Friend Shared Function VideoLesbian_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoLesbian").Property.DefaultValue

		My.Settings.VideoLesbian =
			Video_FolderCheck("Lesbian Video", My.Settings.VideoLesbian, def)

		If My.Settings.VideoLesbian = def Then My.Settings.CBLesbian = False

		Return My.Settings.CBLesbian
	End Function

	Friend Shared Function VideoLesbian_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoLesbian_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoLesbian).Count
	End Function

#End Region ' Lesbian

#Region "------------------------------------- Blowjob Videos --------------------------------------------"

	Private Sub BTNVideoBlowjob_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoBlowjob.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoBlowjob = FolderBrowserDialog1.SelectedPath
			My.Settings.CBBlowjob = True
			LblVideoBlowjobTotal.Text = VideoBlowjob_Count(False)
		End If
	End Sub

	Friend Shared Function VideoBlowjob_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoBlowjob").Property.DefaultValue

		My.Settings.VideoBlowjob =
			Video_FolderCheck("Blowjob Video", My.Settings.VideoBlowjob, def)

		If My.Settings.VideoBlowjob = def Then My.Settings.CBBlowjob = False

		Return My.Settings.CBBlowjob
	End Function

	Friend Shared Function VideoBlowjob_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoBlowjob_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoBlowjob).Count
	End Function

#End Region ' Blowjob

#Region "---------------------------------------- Femdom -------------------------------------------------"

	Private Sub BTNVideoFemDom_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemDom.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoFemdom = FolderBrowserDialog1.SelectedPath
			My.Settings.CBFemdom = True
			LblVideoFemdomTotal.Text = VideoFemdom_Count(False)
		End If
	End Sub

	Friend Shared Function VideoFemdom_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoFemdom").Property.DefaultValue

		My.Settings.VideoFemdom =
			Video_FolderCheck("Femdom Video", My.Settings.VideoFemdom, def)

		If My.Settings.VideoFemdom = def Then My.Settings.CBFemdom = False

		Return My.Settings.CBFemdom
	End Function

	Friend Shared Function VideoFemdom_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoFemdom_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoFemdom).Count
	End Function

#End Region ' Femdom

#Region "------------------------------------- Femsub Videos ---------------------------------------------"

	Private Sub BTNVideoFemSub_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemSub.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoFemsub = FolderBrowserDialog1.SelectedPath
			My.Settings.CBFemsub = True
			LblVideoFemsubTotal.Text = VideoFemsub_Count(False)
		End If
	End Sub

	Friend Shared Function VideoFemsub_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoFemsub").Property.DefaultValue

		My.Settings.VideoFemsub =
			Video_FolderCheck("Femsub Video", My.Settings.VideoFemsub, def)

		If My.Settings.VideoFemsub = def Then My.Settings.CBFemsub = False

		Return My.Settings.CBFemsub
	End Function

	Friend Shared Function VideoFemsub_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoFemsub_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoFemsub).Count
	End Function

#End Region ' Femsub

#Region "------------------------------------- JOI Videos ------------------------------------------------"

	Private Sub BTNVideoJOI_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoJOI.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoJOI = FolderBrowserDialog1.SelectedPath
			My.Settings.CBJOI = True
			LblVideoJOITotal.Text = VideoJOI_Count(False)
		End If
	End Sub

	Friend Shared Function VideoJOI_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoJOI").Property.DefaultValue

		My.Settings.VideoJOI =
			Video_FolderCheck("JOI Video", My.Settings.VideoJOI, def)

		If My.Settings.VideoJOI = def Then My.Settings.CBJOI = False

		Return My.Settings.CBJOI
	End Function

	Friend Shared Function VideoJOI_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoJOI_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoJOI).Count
	End Function

#End Region ' JOI

#Region "------------------------------------- CH Videos -------------------------------------------------"

	Private Sub BTNVideoCH_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoCH.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoCH = FolderBrowserDialog1.SelectedPath
			My.Settings.CBCH = True
			LblVideoCHTotal.Text = VideoCH_Count(False)
		End If
	End Sub

	Friend Shared Function VideoCH_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoCH").Property.DefaultValue

		My.Settings.VideoCH =
			Video_FolderCheck("CH Video", My.Settings.VideoCH, def)

		If My.Settings.VideoCH = def Then My.Settings.CBCH = False

		Return My.Settings.CBCH
	End Function

	Friend Shared Function VideoCH_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoCH_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoCH).Count
	End Function

#End Region ' CH

#Region "------------------------------------- General Videos --------------------------------------------"

	Private Sub BTNVideoGeneral_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoGeneral.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoGeneral = FolderBrowserDialog1.SelectedPath
			My.Settings.CBGeneral = True
			LblVideoGeneralTotal.Text = VideoGeneral_Count(False)
		End If
	End Sub

	Friend Shared Function VideoGeneral_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoGeneral").Property.DefaultValue

		My.Settings.VideoGeneral =
			Video_FolderCheck("General Video", My.Settings.VideoGeneral, def)

		If My.Settings.VideoGeneral = def Then My.Settings.CBGeneral = False

		Return My.Settings.CBGeneral
	End Function

	Friend Shared Function VideoGeneral_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoGeneral_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoGeneral).Count
	End Function

#End Region ' General

#End Region ' Regular

#Region "------------------------------------------ Domme ------------------------------------------------"

#Region "---------------------------------------- HardcoreD ----------------------------------------------"

	Private Sub BTNVideoHardcoreD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoHardCoreD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoHardcoreD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBHardcoreD = True
			LblVideoHardCoreTotalD.Text = VideoHardcoreD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoHardcoreD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoHardcoreD").Property.DefaultValue

		My.Settings.VideoHardcoreD =
			Video_FolderCheck("HardcoreD Video", My.Settings.VideoHardcoreD, def)

		If My.Settings.VideoHardcoreD = def Then My.Settings.CBHardcoreD = False

		Return My.Settings.CBHardcoreD
	End Function

	Friend Shared Function VideoHardcoreD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoHardcoreD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoHardcoreD).Count
	End Function

#End Region ' HardcoreD

#Region "---------------------------------------- SoftcoreD ----------------------------------------------"

	Private Sub BTNVideoSoftcoreD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoSoftCoreD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoSoftcoreD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBSoftcoreD = True
			LblVideoSoftCoreTotalD.Text = VideoSoftcoreD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoSoftcoreD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoSoftcoreD").Property.DefaultValue

		My.Settings.VideoSoftcoreD =
			Video_FolderCheck("SoftcoreD Video", My.Settings.VideoSoftcoreD, def)

		If My.Settings.VideoSoftcoreD = def Then My.Settings.CBSoftcoreD = False

		Return My.Settings.CBSoftcoreD
	End Function

	Friend Shared Function VideoSoftcoreD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoSoftcoreD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoSoftcoreD).Count
	End Function

#End Region ' SoftcoreD

#Region "---------------------------------------- LesbianD -----------------------------------------------"

	Private Sub BTNVideoLesbianD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoLesbianD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoLesbianD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBLesbianD = True
			LblVideoLesbianTotalD.Text = VideoLesbianD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoLesbianD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoLesbianD").Property.DefaultValue

		My.Settings.VideoLesbianD =
			Video_FolderCheck("LesbianD Video", My.Settings.VideoLesbianD, def)

		If My.Settings.VideoLesbianD = def Then My.Settings.CBLesbianD = False

		Return My.Settings.CBLesbianD
	End Function

	Friend Shared Function VideoLesbianD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoLesbianD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoLesbianD).Count
	End Function

#End Region ' LesbianD

#Region "---------------------------------------- BlowjobD -----------------------------------------------"

	Private Sub BTNVideoBlowjobD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoBlowjobD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoBlowjobD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBBlowjobD = True
			LblVideoBlowjobTotalD.Text = VideoBlowjobD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoBlowjobD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoBlowjobD").Property.DefaultValue

		My.Settings.VideoBlowjobD =
			Video_FolderCheck("BlowjobD Video", My.Settings.VideoBlowjobD, def)

		If My.Settings.VideoBlowjobD = def Then My.Settings.CBBlowjobD = False

		Return My.Settings.CBBlowjobD
	End Function

	Friend Shared Function VideoBlowjobD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoBlowjobD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoBlowjobD).Count
	End Function

#End Region ' BlowjobD

#Region "---------------------------------------- FemdomD ------------------------------------------------"

	Private Sub BTNVideoFemdomD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemDomD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoFemdomD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBFemdomD = True
			LblVideoFemdomTotalD.Text = VideoFemdomD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoFemdomD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoFemdomD").Property.DefaultValue

		My.Settings.VideoFemdomD =
			Video_FolderCheck("FemdomD Video", My.Settings.VideoFemdomD, def)

		If My.Settings.VideoFemdomD = def Then My.Settings.CBFemdomD = False

		Return My.Settings.CBFemdomD
	End Function

	Friend Shared Function VideoFemdomD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoFemdomD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoFemdomD).Count
	End Function

#End Region ' FemdomD

#Region "---------------------------------------- FemsubD ------------------------------------------------"

	Private Sub BTNVideoFemsubD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoFemSubD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoFemsubD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBFemsubD = True
			LblVideoFemsubTotalD.Text = VideoFemsubD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoFemsubD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoFemsubD").Property.DefaultValue

		My.Settings.VideoFemsubD =
			Video_FolderCheck("FemsubD Video", My.Settings.VideoFemsubD, def)

		If My.Settings.VideoFemsubD = def Then My.Settings.CBFemsubD = False

		Return My.Settings.CBFemsubD
	End Function

	Friend Shared Function VideoFemsubD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoFemsubD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoFemsubD).Count
	End Function

#End Region ' FemsubD

#Region "---------------------------------------- JOI-D --------------------------------------------------"

	Private Sub BTNVideoJOID_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoJOID.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoJOID = FolderBrowserDialog1.SelectedPath
			My.Settings.CBJOID = True
			LblVideoJOITotalD.Text = VideoJOID_Count(False)
		End If
	End Sub

	Friend Shared Function VideoJOID_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoJOID").Property.DefaultValue

		My.Settings.VideoJOID =
			Video_FolderCheck("JOID Video", My.Settings.VideoJOID, def)

		If My.Settings.VideoJOID = def Then My.Settings.CBJOID = False

		Return My.Settings.CBJOID
	End Function

	Friend Shared Function VideoJOID_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoJOID_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoJOID).Count
	End Function

#End Region ' JOI-D

#Region "---------------------------------------- CH-D ---------------------------------------------------"

	Private Sub BTNVideoCHD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoCHD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoCHD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBCHD = True
			LblVideoCHTotalD.Text = VideoCHD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoCHD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoCHD").Property.DefaultValue

		My.Settings.VideoCHD =
			Video_FolderCheck("CHD Video", My.Settings.VideoCHD, def)

		If My.Settings.VideoCHD = def Then My.Settings.CBCHD = False

		Return My.Settings.CBCHD
	End Function

	Friend Shared Function VideoCHD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoCHD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoCHD).Count
	End Function

#End Region ' CH-D

#Region "---------------------------------------- GeneralD -----------------------------------------------"

	Private Sub BTNVideoGeneralD_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoGeneralD.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
			My.Settings.VideoGeneralD = FolderBrowserDialog1.SelectedPath
			My.Settings.CBGeneralD = True
			LblVideoGeneralTotalD.Text = VideoGeneralD_Count(False)
		End If
	End Sub

	Friend Shared Function VideoGeneralD_CheckFolder() As Boolean
		Dim def As String =
			My.Settings.PropertyValues("VideoGeneralD").Property.DefaultValue

		My.Settings.VideoGeneralD =
			Video_FolderCheck("GeneralD Video", My.Settings.VideoGeneralD, def)

		If My.Settings.VideoGeneralD = def Then My.Settings.CBGeneralD = False

		Return My.Settings.CBGeneralD
	End Function

	Friend Shared Function VideoGeneralD_Count(Optional ByVal checkfolder As Boolean = True) As Integer
		If checkfolder Then VideoGeneralD_CheckFolder()
		Return myDirectory.GetFilesVideo(My.Settings.VideoGeneralD).Count
	End Function

#End Region ' GeneralD

#End Region ' Domme

	Private Sub BTNRefreshVideos_Click(sender As System.Object, e As System.EventArgs) Handles BTNRefreshVideos.Click
		VideoDescriptionLabel.Text = "Refresh complete: " & Video_CheckAllFolders() & " videos found!"
		VideoDescriptionLabel.Text = VideoDescriptionLabel.Text.Replace(": 1 videos", ": 1 video")
	End Sub

#End Region ' Videos


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











	Private Sub CockSizeNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles CockSizeNumBox.LostFocus
		My.Settings.SubCockSize = CockSizeNumBox.Value
	End Sub


	Private Sub NBCensorShowMin_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMin.Leave
		My.Settings.NBCensorShowMin = NBCensorShowMin.Value
		Debug.Print(My.Settings.NBCensorShowMin & " " & NBCensorShowMin.Value)
	End Sub

	Private Sub NBCensorShowMax_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMax.Leave
		My.Settings.NBCensorShowMax = NBCensorShowMax.Value
	End Sub

	Private Sub NBCensorHideMin_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMin.Leave
		My.Settings.NBCensorHideMin = NBCensorHideMin.Value
	End Sub

	Private Sub NBCensorHideMax_Leave(sender As System.Object, e As System.EventArgs) Handles NBCensorHideMax.Leave
		My.Settings.NBCensorHideMax = NBCensorHideMax.Value
	End Sub

	Private Sub CBCensorConstant_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCensorConstant.CheckedChanged
		If CBCensorConstant.Checked = True Then
			My.Settings.CBCensorConstant = True
		Else
			My.Settings.CBCensorConstant = False
		End If
	End Sub

	Public Function Color2Html(ByVal MyColor As Color) As String
		Return "#" & MyColor.ToArgb().ToString("x").Substring(2).ToUpper
	End Function




	Private Sub NBCensorShowMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMin.ValueChanged
		If NBCensorShowMin.Value > NBCensorShowMax.Value Then NBCensorShowMin.Value = NBCensorShowMax.Value
	End Sub

	Private Sub NBCensorShowMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBCensorShowMax.ValueChanged
		If NBCensorShowMax.Value < NBCensorShowMin.Value Then NBCensorShowMax.Value = NBCensorShowMin.Value
	End Sub

	Private Sub NBTeaseLengthMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMin.LostFocus
		My.Settings.TeaseLengthMin = NBTeaseLengthMin.Value
	End Sub

	Private Sub NBTeaseLengthMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBTeaseLengthMax.LostFocus
		My.Settings.TeaseLengthMax = NBTeaseLengthMax.Value
	End Sub

	Private Sub NBTauntCycleMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBTauntCycleMin.LostFocus
		My.Settings.TauntCycleMin = NBTauntCycleMin.Value
	End Sub

	Private Sub NBTauntCycleMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBTauntCycleMax.LostFocus
		My.Settings.TauntCycleMax = NBTauntCycleMax.Value
	End Sub
	Private Sub NBRedLightMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBRedLightMin.LostFocus
		My.Settings.RedLightMin = NBRedLightMin.Value
	End Sub

	Private Sub NBRedLightMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBRedLightMax.LostFocus
		My.Settings.RedLightMax = NBRedLightMax.Value
	End Sub
	Private Sub NBGreenLightMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBGreenLightMin.LostFocus
		My.Settings.GreenLightMin = NBGreenLightMin.Value
	End Sub

	Private Sub NBGreenLightMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBGreenLightMax.LostFocus
		My.Settings.GreenLightMax = NBGreenLightMax.Value
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

		Form1.ssh.VTPath = CensorText

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


		My.Computer.FileSystem.DeleteFile(Form1.ssh.VTPath)

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
				My.Computer.FileSystem.WriteAllText(Form1.ssh.VTPath, WriteList(i), True)
			Else
				My.Computer.FileSystem.WriteAllText(Form1.ssh.VTPath, WriteList(i), True)
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

			Dim files() As String = myDirectory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Glitter\" & CBGlitModType.Text & "\")
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

		If GlitPath = Form1.ssh.StatusText Then
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




    ''' =========================================================================================================
    ''' <summary>
    ''' Activates the specified is activaed in Listbox and saves the Listboxstate.
    ''' </summary>
    ''' <param name="URL_FileName"></param>
    Private Sub URL_File_Set(ByVal URL_FileName As String)
		Try
            ' Set the new URL-File
            If Not URLFileList.Items.Contains(URL_FileName) Then
				URLFileList.Items.Add(URL_FileName)
				For i As Integer = 0 To URLFileList.Items.Count - 1
					If URLFileList.Items(i) = URL_FileName Then URLFileList.SetItemChecked(i, True)
				Next
			End If
            ' Save ListState
            Using FileStream As New System.IO.FileStream(Application.StartupPath & "\Images\System\URLFileCheckList.cld", IO.FileMode.Create)
				Using BinaryWriter As New System.IO.BinaryWriter(FileStream)
					For i = 0 To URLFileList.Items.Count - 1
						BinaryWriter.Write(CStr(URLFileList.Items(i)))
						BinaryWriter.Write(CBool(URLFileList.GetItemChecked(i)))
					Next
					BinaryWriter.Close()
				End Using
			End Using
		Catch ex As Exception
			Throw
		End Try
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

	End Sub

	Private Sub SliderSTF_LostFocus(sender As System.Object, e As System.EventArgs) Handles SliderSTF.LostFocus
		My.Settings.TimerSTF = SliderSTF.Value

	End Sub







	Private Sub NBWritingTaskMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBWritingTaskMin.LostFocus
		My.Settings.NBWritingTaskMin = NBWritingTaskMin.Value
	End Sub

	Private Sub NBWritingTaskMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBWritingTaskMin.ValueChanged
		If NBWritingTaskMin.Value > NBWritingTaskMax.Value Then NBWritingTaskMin.Value = NBWritingTaskMax.Value
	End Sub

	Private Sub NBWritingTaskMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBWritingTaskMax.LostFocus
		My.Settings.NBWritingTaskMax = NBWritingTaskMax.Value
	End Sub

	Private Sub NBWritingTaskMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBWritingTaskMax.ValueChanged
		If NBWritingTaskMax.Value < NBWritingTaskMin.Value Then NBWritingTaskMax.Value = NBWritingTaskMin.Value
	End Sub


	Private Sub BTNTagDir_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagDir.Click

		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then


			' BTNTagSave.Text = "Save and Display Next Image"

			ImageTagDir.Clear()

			TagImageFolder = FolderBrowserDialog1.SelectedPath

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			files = myDirectory.GetFiles(TagImageFolder, "*.*")

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
			Form1.mainPictureBox.LoadAsync(ImageTagDir(0))
			CurrentImageTagImage = ImageTagDir(0)

			LoadDommeTags()

			TagCount = 1
			LBLTagCount.Text = TagCount & "/" & ImageTagDir.Count

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
			CBTagSmiling.Enabled = True
			CBTagGlaring.Enabled = True
			CBTagSeeThrough.Enabled = True
			CBTagAllFours.Enabled = True

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

				files = myDirectory.GetFiles(TagImageFolder, "*.*")

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
				Form1.mainPictureBox.LoadAsync(ImageTagDir(0))


				CurrentImageTagImage = ImageTagDir(0)



				LoadDommeTags()

				TagCount = 1
				LBLTagCount.Text = TagCount & "/" & ImageTagDir.Count

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
				CBTagSmiling.Enabled = True
				CBTagGlaring.Enabled = True
				CBTagSeeThrough.Enabled = True
				CBTagAllFours.Enabled = True

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

		SaveDommeTags()

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
		CBTagSmiling.Checked = False
		CBTagGlaring.Checked = False
		CBTagSeeThrough.Checked = False
		CBTagAllFours.Checked = False

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
		CBTagSmiling.Enabled = False
		CBTagGlaring.Enabled = False
		CBTagSeeThrough.Enabled = False
		CBTagAllFours.Enabled = False

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

		TagCount += 1
		LBLTagCount.Text = TagCount & "/" & ImageTagDir.Count
		BTNTagPrevious.Enabled = True


		SaveDommeTags()



		ImageTagCount += 1

		Try
			ImageTagPictureBox.Image.Dispose()
		Catch
		End Try

		ImageTagPictureBox.Image = Nothing
		GC.Collect()

		ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(ImageTagCount))
		Form1.mainPictureBox.LoadAsync(ImageTagDir(ImageTagCount))


		CurrentImageTagImage = ImageTagDir(ImageTagCount)

		If ImageTagCount = ImageTagDir.Count - 1 Then BTNTagNext.Enabled = False


		LoadDommeTags()

	End Sub

	Private Sub BTNTagPrevious_Click(sender As System.Object, e As System.EventArgs) Handles BTNTagPrevious.Click

		TagCount -= 1
		LBLTagCount.Text = TagCount & "/" & ImageTagDir.Count
		BTNTagNext.Enabled = True


		SaveDommeTags()

		ImageTagCount -= 1

		Try
			ImageTagPictureBox.Image.Dispose()
		Catch
		End Try

		ImageTagPictureBox.Image = Nothing
		GC.Collect()

		ImageTagPictureBox.Image = Image.FromFile(ImageTagDir(ImageTagCount))
		Form1.mainPictureBox.LoadAsync(ImageTagDir(ImageTagCount))
		CurrentImageTagImage = ImageTagDir(ImageTagCount)

		If ImageTagCount = 0 Then BTNTagPrevious.Enabled = False


		LoadDommeTags()

	End Sub









	Private Sub Button50_Click(sender As System.Object, e As System.EventArgs) Handles Button50.Click

		TBKeyWords.Text = ""
		RTBKeyWords.Text = ""

		Dim files() As String = myDirectory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\")

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

	Private Sub TBGreeting_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBGreeting.LostFocus
		My.Settings.SubGreeting = TBGreeting.Text
	End Sub

	Private Sub TBYes_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBYes.LostFocus
		My.Settings.SubYes = TBYes.Text
	End Sub

	Private Sub TBNo_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBNo.LostFocus
		My.Settings.SubNo = TBNo.Text
	End Sub

	Private Sub TBHonorific_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBHonorific.LostFocus
		If TBHonorific.Text = "" Or TBHonorific.Text Is Nothing Then TBHonorific.Text = "Mistress"
		My.Settings.SubHonorific = TBHonorific.Text
	End Sub

	Private Sub CBHonorificInclude_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBHonorificInclude.LostFocus
		If CBHonorificInclude.Checked = True Then
			My.Settings.CBUseHonor = True
		Else
			My.Settings.CBUseHonor = False
		End If
	End Sub

	Private Sub CBHonorificCapitalized_LostFocus(sender As System.Object, e As System.EventArgs) Handles CBHonorificCapitalized.LostFocus
		If CBHonorificCapitalized.Checked = True Then
			My.Settings.CBCapHonor = True
		Else
			My.Settings.CBCapHonor = False
		End If
	End Sub

	Private Sub subAgeNumBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles subAgeNumBox.LostFocus
		My.Settings.SubAge = subAgeNumBox.Value
	End Sub

	Private Sub NBDomBirthdayMonth_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomBirthdayMonth.LostFocus
		My.Settings.DomBirthMonth = NBDomBirthdayMonth.Value
	End Sub

	Private Sub NBDomBirthdayDay_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBDomBirthdayDay.LostFocus
		My.Settings.DomBirthDay = NBDomBirthdayDay.Value
	End Sub


	Private Sub NBBirthdayMonth_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBBirthdayMonth.LostFocus
		My.Settings.SubBirthMonth = NBBirthdayMonth.Value
	End Sub

	Private Sub NBBirthdayDay_LostFocus(sender As System.Object, e As System.EventArgs) Handles NBBirthdayDay.LostFocus
		My.Settings.SubBirthDay = NBBirthdayDay.Value
	End Sub

	Private Sub TBSubHairColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBSubHairColor.LostFocus
		My.Settings.SubHair = TBSubHairColor.Text
	End Sub

	Private Sub TBSubEyeColor_LostFocus(sender As System.Object, e As System.EventArgs) Handles TBSubEyeColor.LostFocus
		My.Settings.SubEyes = TBSubEyeColor.Text
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





	Public Sub RefreshURLList()


		For i As Integer = URLFileList.Items.Count - 1 To 0 Step -1
			'Debug.Print(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.Items(i) & ".txt")
			If Not File.Exists(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.Items(i) & ".txt") Then
				URLFileList.Items.Remove(URLFileList.Items(i))
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

	Private Sub SaveURLFileSelection()

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

	Private Sub URLFileList_LostFocus(sender As Object, e As System.EventArgs) Handles URLFileList.LostFocus
		SaveURLFileSelection()
	End Sub


	Private Sub URLFileList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles URLFileList.SelectedIndexChanged

		If CBURLPreview.Checked = True Then
			Dim PreviewList As New List(Of String)
			PreviewList = Txt2List(Application.StartupPath & "\Images\System\URL Files\" & URLFileList.SelectedItem & ".txt")
			PBURLPreview.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(PreviewList(Form1.ssh.randomizer.Next(0, PreviewList.Count)))))
		End If

		SaveURLFileSelection()

	End Sub

	Private Sub BTNURLFilesAll_Click(sender As System.Object, e As System.EventArgs) Handles BTNURLFilesAll.Click
		For i As Integer = 0 To URLFileList.Items.Count - 1
			URLFileList.SetItemChecked(i, True)
		Next
		SaveURLFileSelection()
	End Sub

	Private Sub BTNURLFilesNone_Click(sender As System.Object, e As System.EventArgs) Handles BTNURLFilesNone.Click
		For i As Integer = 0 To URLFileList.Items.Count - 1
			URLFileList.SetItemChecked(i, False)
		Next
		SaveURLFileSelection()
	End Sub

	Private Sub CBCBTCock_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCBTCock.LostFocus
		If CBCBTCock.Checked = True Then
			My.Settings.CBTCock = True
		Else
			My.Settings.CBTCock = False
		End If
	End Sub

	Private Sub CBCBTBalls_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBCBTBalls.LostFocus
		If CBCBTBalls.Checked = True Then
			My.Settings.CBTBalls = True
		Else
			My.Settings.CBTBalls = False
		End If
	End Sub

	Private Sub Button9_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNLocalTagDir.Click
		If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then


			' BTNTagSave.Text = "Save and Display Next Image"

			LocalImageTagDir.Clear()

			Dim TagLocalImageFolder As String = FolderBrowserDialog1.SelectedPath

			Dim supportedExtensions As String = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
			Dim files As String()

			files = myDirectory.GetFiles(TagLocalImageFolder, "*.*")

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

			Form1.mainPictureBox.LoadAsync(LocalImageTagDir(0))


			CurrentLocalImageTagImage = LocalImageTagDir(0)


			CheckLocalTagList()



			LocalTagCount = 1
			LBLLocalTagCount.Text = LocalTagCount & "/" & LocalImageTagDir.Count


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

		LocalTagCount += 1
		LBLLocalTagCount.Text = LocalTagCount & "/" & LocalImageTagDir.Count
		BTNLocalTagPrevious.Enabled = True

		SetLocalImageTags()

		LocalImageTagCount += 1
		Form1.mainPictureBox.LoadAsync(LocalImageTagDir(LocalImageTagCount))
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


	Private Sub NBLongEdge_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBLongEdge.LostFocus
		My.Settings.LongEdge = NBLongEdge.Value
	End Sub


	Private Sub NBHoldTheEdgeMax_LostFocus(sender As Object, e As System.EventArgs) Handles NBHoldTheEdgeMax.LostFocus
		My.Settings.HoldTheEdgeMax = NBHoldTheEdgeMax.Value
		My.Settings.HoldTheEdgeMaxAmount = LBLMaxHold.Text
	End Sub

	Private Sub NBHoldTheEdgeMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBHoldTheEdgeMin.LostFocus
		My.Settings.HoldTheEdgeMin = NBHoldTheEdgeMin.Value
		My.Settings.HoldTheEdgeMinAmount = LBLMinHold.Text
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
	End Sub

	Private Sub NBLongHoldMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBLongHoldMin.LostFocus
		My.Settings.LongHoldMin = NBLongHoldMin.Value
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
	End Sub

	Private Sub NBExtremeHoldMin_LostFocus(sender As Object, e As System.EventArgs) Handles NBExtremeHoldMin.LostFocus
		My.Settings.ExtremeHoldMin = NBExtremeHoldMin.Value
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


	Private Sub CBTSlider_Scroll(sender As System.Object, e As System.EventArgs) Handles CBTSlider.Scroll
		If FrmSettingsLoading = False Then
			My.Settings.CBTSlider = CBTSlider.Value
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
		End If
	End Sub

	Private Sub CBSubPierced_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBSubPierced.CheckedChanged
		If FrmSettingsLoading = False Then
			If CBSubPierced.Checked = True Then
				My.Settings.SubPierced = True
			Else
				My.Settings.SubPierced = False
			End If
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
		My.Settings.LockOrgasmChances = CBLockOrgasmChances.Checked
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
		CBLockOrgasmChances.Checked = My.Settings.LockOrgasmChances
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

		LocalTagCount -= 1
		LBLLocalTagCount.Text = LocalTagCount & "/" & LocalImageTagDir.Count
		BTNLocalTagNext.Enabled = True

		SetLocalImageTags()

		LocalImageTagCount -= 1
		Form1.mainPictureBox.LoadAsync(LocalImageTagDir(LocalImageTagCount))
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

				files = myDirectory.GetFiles(TagLocalImageFolder, "*.*")

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

				Form1.mainPictureBox.LoadAsync(LocalImageTagDir(0))


				CurrentLocalImageTagImage = LocalImageTagDir(0)


				CheckLocalTagList()



				LocalTagCount = 1
				LBLLocalTagCount.Text = LocalTagCount & "/" & LocalImageTagDir.Count


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
	End Sub
	Private Sub CBRangeRuin_LostFocus(sender As Object, e As System.EventArgs) Handles CBRangeRuin.LostFocus
		My.Settings.RangeRuin = CBRangeRuin.Checked
	End Sub

	Private Sub NBAllowOften_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowOften.LostFocus
		My.Settings.AllowOften = NBAllowOften.Value
	End Sub

	Private Sub NBAllowSometimes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowSometimes.LostFocus
		My.Settings.AllowSometimes = NBAllowSometimes.Value
	End Sub

	Private Sub NBAllowRarely_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBAllowRarely.LostFocus
		My.Settings.AllowRarely = NBAllowRarely.Value
	End Sub

	Private Sub NBRuinOften_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinOften.LostFocus
		My.Settings.RuinOften = NBRuinOften.Value
	End Sub

	Private Sub NBRuinSometimes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinSometimes.LostFocus
		My.Settings.RuinSometimes = NBRuinSometimes.Value
	End Sub

	Private Sub NBRuinRarely_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBRuinRarely.LostFocus
		My.Settings.RuinRarely = NBRuinRarely.Value
	End Sub

	Private Sub TBSafeword_LostFocus(sender As Object, e As System.EventArgs) Handles TBSafeword.LostFocus
		My.Settings.Safeword = TBSafeword.Text
	End Sub



	Private Sub Button4_Click_5(sender As System.Object, e As System.EventArgs) Handles Button4.Click

		TBResponses.Text = ""
		RTBResponses.Text = ""
		RTBResponsesKEY.Text = ""

		Dim files() As String = myDirectory.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Vocabulary\Responses\")

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
	End Sub
	Private Sub CBEdgeUseAvg_MouseHover(sender As Object, e As System.EventArgs) Handles CBEdgeUseAvg.MouseEnter
		LBLSubSettingsDescription.Text = "When this is checked, the domme will use the average amount of time it has historically taken you to reach the edge to decide when you have been trying to edge for too long."
	End Sub

	Private Sub CBLongEdgeTaunts_LostFocus(sender As Object, e As System.EventArgs) Handles CBLongEdgeTaunts.LostFocus
		My.Settings.CBLongEdgeTaunts = CBLongEdgeTaunts.Checked
	End Sub

	Private Sub CBLongEdgeTaunts_MouseHover(sender As Object, e As System.EventArgs) Handles CBLongEdgeTaunts.MouseEnter
		LBLSubSettingsDescription.Text = "When this box is checked, the domme will include edge taunts that are reserved for when the Long Edge threshold has been passed." & Environment.NewLine & Environment.NewLine &
			"This will allow the domme to tease you about the fact that you have been trying to edge for longer than she expected."
	End Sub

	Private Sub CBLongEdgeInterrupts_LostFocus(sender As Object, e As System.EventArgs) Handles CBLongEdgeInterrupts.LostFocus
		My.Settings.CBLongEdgeInterrupts = CBLongEdgeInterrupts.Checked
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

			Dim RandomOrgasms As Integer = Form1.ssh.randomizer.Next(1, 6)


			My.Settings.OrgasmsRemaining = RandomOrgasms
			My.Settings.DomOrgasmPer = RandomOrgasms

			orgasmsPerNumBox.Value = RandomOrgasms

			Dim RandomTime As Integer = Form1.ssh.randomizer.Next(1, 4)

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
	End Sub

	Private Sub CBTauntCycleDD_LostFocus(sender As Object, e As System.EventArgs) Handles CBTauntCycleDD.LostFocus
		My.Settings.CBTauntCycleDD = CBTauntCycleDD.Checked
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

	Private Sub RangeSet_MouseHover(sender As Object, e As System.EventArgs) Handles Panel6.MouseEnter, GroupBox21.MouseEnter, GroupBox18.MouseEnter, GroupBox19.MouseEnter, GroupBox10.MouseEnter, GBRangeRuinChance.MouseEnter, GBRangeOrgasmChance.MouseEnter, GroupBox57.MouseEnter
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
	End Sub

	Private Sub CBChastityPA_LostFocus(sender As Object, e As System.EventArgs) Handles CBChastityPA.LostFocus
		My.Settings.ChastityPA = CBChastityPA.Checked
	End Sub

	Private Sub CBChastitySpikes_LostFocus(sender As Object, e As System.EventArgs) Handles CBChastitySpikes.LostFocus
		My.Settings.ChastitySpikes = CBChastitySpikes.Checked
	End Sub

	Private Sub CBHimHer_LostFocus(sender As Object, e As System.EventArgs) Handles CBHimHer.LostFocus
		My.Settings.CBHimHer = CBHimHer.Checked
	End Sub

	Private Sub CBDomDel_LostFocus(sender As Object, e As System.EventArgs) Handles CBDomDel.LostFocus
		My.Settings.DomDeleteMedia = CBDomDel.Checked
	End Sub

	Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceCancel.Click
		If BWURLFiles.IsBusy Then BWURLFiles.CancelAsync()
	End Sub


	Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNMaintenanceScripts.Click

		PBMaintenance.Maximum = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count +
			 My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count
		PBMaintenance.Value = 0
		Dim BlankAudit As Integer = 0
		Dim ErrorAudit As Integer = 0

		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False

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


	End Sub

	Public Sub AuditScripts()

		PBMaintenance.Maximum = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count +
	   My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images\System\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count
		PBMaintenance.Value = 0
		Dim BlankAudit As Integer = 0
		Dim ErrorAudit As Integer = 0

		BTNMaintenanceRebuild.Enabled = False
		BTNMaintenanceRefresh.Enabled = False

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

		MessageBox.Show(If(Me.Visible, Me, FrmSplash), PBMaintenance.Maximum & " scripts have been audited." & Environment.NewLine & Environment.NewLine &
						"Blank lines cleared: " & BlankAudit & Environment.NewLine & Environment.NewLine &
						"Script errors corrected: " & ErrorAudit, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

		PBMaintenance.Value = 0

		LBLMaintenance.Text = ""

		BTNMaintenanceRebuild.Enabled = True
		BTNMaintenanceRefresh.Enabled = True

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
	End Sub

	Private Sub CBBallsToPussy_LostFocus(sender As Object, e As System.EventArgs) Handles CBBallsToPussy.LostFocus
		My.Settings.BallsToPussy = CBBallsToPussy.Checked
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
		Else
			Return
		End If


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

		GBDommeImages.Text = "Slideshow Options"
		BTNDomImageDir.Text = "Set Domme Images Directory"

		'GBSlideshowOptions.Text = "Slideshow Options"
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

		GBDommeImages.Text = "Diashow Einstellungen"
		BTNDomImageDir.Text = "Wähle Domina Bilder Speicherpfad"

		'GBSlideshowOptions.Text = "Diashow Einstellungen"
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
		End If
	End Sub

	Private Sub ThemeLbl_Click(sender As System.Object, e As System.EventArgs) Handles LBLBackColor2.Click, LBLButtonColor2.Click, LBLTextColor2.Click, LBLDateTimeColor2.Click, LBLDateBackColor2.Click, LBLChatWindowColor2.Click, LBLChatTextColor2.Click
		If GetColor.ShowDialog() = DialogResult.OK Then
			Form1.SuspendLayout()
			CType(sender, Label).BackColor = GetColor.Color
			Form1.ResumeLayout()
		End If
	End Sub

	Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
			Try
				Form1.PnlLayoutForm.BackgroundImage.Dispose()
			Catch
			End Try
			Form1.PnlLayoutForm.BackgroundImage = Nothing
			GC.Collect()
			Form1.PnlLayoutForm.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.BackgroundImage = OpenFileDialog1.FileName
		End If
	End Sub

	Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
		Try
			Form1.PnlLayoutForm.BackgroundImage.Dispose()
			PBBackgroundPreview.Image.Dispose()
		Catch
		End Try
		Form1.PnlLayoutForm.BackgroundImage = Nothing
		PBBackgroundPreview.Image = Nothing
		GC.Collect()
		My.Settings.BackgroundImage = ""
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



			Catch
				MessageBox.Show(Me, "This Theme settings file is invalid or has been edited incorrectly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try



		End If
	End Sub


	Private Sub CBStretchBack_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBStretchBack.CheckedChanged
		My.Settings.BackgroundStretch = CBStretchBack.Checked
	End Sub




	Private Sub CBTransparentTime_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBTransparentTime.CheckedChanged
		My.Settings.CBDateTransparent = CBTransparentTime.Checked
	End Sub









	Private Sub CheckBox1_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles CBFlipBack.CheckedChanged

		Try
			If Form1.FormLoading = False And Form1.ApplyingTheme = False Then
				'TODO: implement Flip Background
			End If
		Catch
		End Try

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

	Private Sub TimeBoxWakeUp_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TimeBoxWakeUp.ValueChanged
		If Form1.FormLoading = False Then


			Dim SetDate As Date = FormatDateTime(TimeBoxWakeUp.Value, DateFormat.LongTime)

			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\Variables\SYS_WakeUp", FormatDateTime(SetDate, DateFormat.LongTime), False)



			'Debug.Print("Dates = " & Dates)

			' Github Patch My.Settings.WakeUp = Form1.GetTime("SYS_WakeUp")
			My.Settings.WakeUp = FormatDateTime(Now, DateFormat.ShortDate) & " " & Form1.GetTime("SYS_WakeUp")



			Debug.Print(Form1.ssh.GeneralTime)




		End If
	End Sub

	Private Sub NBTypoChance_LostFocus(sender As Object, e As System.EventArgs) Handles NBTypoChance.LostFocus
		My.Settings.TypoChance = NBTypoChance.Value
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

	Private Sub SliderVVolume_LostFocus(sender As Object, e As System.EventArgs) Handles SliderVVolume.LostFocus
		My.Settings.VVolume = SliderVVolume.Value
	End Sub
	Private Sub SliderVRate_LostFocus(sender As Object, e As System.EventArgs) Handles SliderVRate.LostFocus
		My.Settings.VRate = SliderVRate.Value
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
	End Sub

	Private Sub degradingCheckBox_LostFocus(sender As Object, e As System.EventArgs) Handles degradingCheckBox.LostFocus
		My.Settings.DomDegrading = degradingCheckBox.Checked
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



	Private Sub BTNDebugTauntsClear_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugTauntsClear.Click
		TBDebugTaunts1.Text = ""
		TBDebugTaunts2.Text = ""
		TBDebugTaunts3.Text = ""
	End Sub

	Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
		Form1.ssh.StrokeTick = 5
	End Sub

	Private Sub CBMuteMedia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBMuteMedia.CheckedChanged

		Form1.DomWMP.settings.mute = CBMuteMedia.Checked

	End Sub

	Private Sub CBMuteMedia_LostFocus(sender As Object, e As System.EventArgs) Handles CBMuteMedia.LostFocus
		My.Settings.MuteMedia = CBMuteMedia.Checked
	End Sub


	Private Sub BTNOfflineMode_Click(sender As System.Object, e As System.EventArgs) Handles BTNOfflineMode.Click
		If My.Settings.OfflineMode = True Then
			My.Settings.OfflineMode = False
			LBLOfflineMode.Text = "OFF"
			LBLOfflineMode.ForeColor = Color.Red
		Else
			My.Settings.OfflineMode = True
			LBLOfflineMode.Text = "ON"
			LBLOfflineMode.ForeColor = Color.Green
		End If
	End Sub

	Private Sub CBNewSlideshow_LostFocus(sender As Object, e As System.EventArgs) Handles CBNewSlideshow.LostFocus
		If CBNewSlideshow.Checked = True Then
			My.Settings.CBNewSlideshow = True
		Else
			My.Settings.CBNewSlideshow = False
		End If
	End Sub

	Private Sub NBTauntEdging_LostFocus(sender As Object, e As System.EventArgs) Handles NBTauntEdging.LostFocus
		My.Settings.TauntEdging = NBTauntEdging.Value
	End Sub

	Private Sub BTNDebugTeaseTimer_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugTeaseTimer.Click
		Form1.ssh.TeaseTick = 5
	End Sub

	Private Sub BTNDebugStrokeTime_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugStrokeTime.Click
		Form1.ssh.StrokeTick = 5
	End Sub

	Private Sub BTNDebugStrokeTauntTimer_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugStrokeTauntTimer.Click
		Form1.ssh.StrokeTauntTick = 5
	End Sub

	Private Sub BTNDebugEdgeTauntTimer_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugEdgeTauntTimer.Click
		Form1.ssh.EdgeTauntInt = 5
	End Sub

	Private Sub BTNDebugHoldEdgeTimer_Click(sender As System.Object, e As System.EventArgs) Handles BTNDebugHoldEdgeTimer.Click
		Form1.ssh.HoldEdgeTick = 5
	End Sub





	Private Sub CBURLPreview_LostFocus(sender As Object, e As System.EventArgs) Handles CBURLPreview.LostFocus
		My.Settings.CBURLPreview = CBURLPreview.Checked
	End Sub


	Private Sub NBTaskStrokesMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskStrokesMin.ValueChanged
		If NBTaskStrokesMin.Value > NBTaskStrokesMax.Value Then NBTaskStrokesMin.Value = NBTaskStrokesMax.Value
	End Sub
	Private Sub NBTaskStrokesMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskStrokesMax.ValueChanged
		If NBTaskStrokesMax.Value < NBTaskStrokesMin.Value Then NBTaskStrokesMax.Value = NBTaskStrokesMin.Value
	End Sub

	Private Sub NBTaskStrokingTimeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskStrokingTimeMin.ValueChanged
		If NBTaskStrokingTimeMin.Value > NBTaskStrokingTimeMax.Value Then NBTaskStrokingTimeMin.Value = NBTaskStrokingTimeMax.Value
	End Sub
	Private Sub NBTaskStrokingTimeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskStrokingTimeMax.ValueChanged
		If NBTaskStrokingTimeMax.Value < NBTaskStrokingTimeMin.Value Then NBTaskStrokingTimeMax.Value = NBTaskStrokingTimeMin.Value
	End Sub

	Private Sub NBTaskEdgesMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskEdgesMin.ValueChanged
		If NBTaskEdgesMin.Value > NBTaskEdgesMax.Value Then NBTaskEdgesMin.Value = NBTaskEdgesMax.Value
	End Sub
	Private Sub NBTaskEdgesMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskEdgesMax.ValueChanged
		If NBTaskEdgesMax.Value < NBTaskEdgesMin.Value Then NBTaskEdgesMax.Value = NBTaskEdgesMin.Value
	End Sub

	Private Sub NBTaskEdgeHoldTimeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskEdgeHoldTimeMin.ValueChanged
		If NBTaskEdgeHoldTimeMin.Value > NBTaskEdgeHoldTimeMax.Value Then NBTaskEdgeHoldTimeMin.Value = NBTaskEdgeHoldTimeMax.Value
	End Sub
	Private Sub NBTaskEdgeHoldTimeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskEdgeHoldTimeMax.ValueChanged
		If NBTaskEdgeHoldTimeMax.Value < NBTaskEdgeHoldTimeMin.Value Then NBTaskEdgeHoldTimeMax.Value = NBTaskEdgeHoldTimeMin.Value
	End Sub

	Private Sub NBTaskCBTTimeMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskCBTTimeMin.ValueChanged
		If NBTaskCBTTimeMin.Value > NBTaskCBTTimeMax.Value Then NBTaskCBTTimeMin.Value = NBTaskCBTTimeMax.Value
	End Sub
	Private Sub NBTaskCBTTimeMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTaskCBTTimeMax.ValueChanged
		If NBTaskCBTTimeMax.Value < NBTaskCBTTimeMin.Value Then NBTaskCBTTimeMax.Value = NBTaskCBTTimeMin.Value
	End Sub

	Private Sub NBTasksMin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTasksMin.ValueChanged
		If NBTasksMin.Value > NBTasksMax.Value Then NBTasksMin.Value = NBTasksMax.Value
	End Sub
	Private Sub NBTasksMax_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBTasksMax.ValueChanged
		If NBTasksMax.Value < NBTasksMin.Value Then NBTasksMax.Value = NBTasksMin.Value
	End Sub

	Private Sub TypeSpeedSlider_MouseHover(sender As Object, e As System.EventArgs) Handles TypeSpeedSlider.MouseHover
		TTDir.SetToolTip(TypeSpeedSlider, "Adjust your typing speed. It determines how much time you will have during Writing Tasks to accomplish them." & vbCrLf & "(There is a 3-fold difference in time granted between slowest and fastest typing speed")
	End Sub

	Private Sub TypeSpeedSlider_Scroll(sender As System.Object, e As System.EventArgs) Handles TypeSpeedSlider.Scroll
		TypesSpeedVal.Text = TypeSpeedSlider.Value
	End Sub

	Private Sub TimedWriting_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles TimedWriting.MouseHover

		If RBEnglish.Checked = True Then TTDir.SetToolTip(TimedWriting, "When selected, you will need to complete Writing Tasks in a certain amount of time, based on sentence length and Typing Speed value" & Environment.NewLine &
	  "When unselected, Writing Tasks failure will only be based on errors made")
		If RBGerman.Checked = True Then TTDir.SetToolTip(TimedWriting, "Wenn diese Option aktiviert , müssen Sie Schreibaufgaben in einer bestimmten Zeit zu vervollständigen, basierend auf Satzlängeund Typing Speed ​​Wert" & Environment.NewLine &
		 "Wenn diese Option deaktiviert, Schreibaufgaben Fehler wird nur auf Fehler beruhen gemacht")

	End Sub

	Private Sub Button24_Click_1(sender As System.Object, e As System.EventArgs) Handles Button24.Click
	End Sub

	Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click
	End Sub

	Public Sub SaveDommeTags()

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
		If CBTagSmiling.Checked = True Then TempImageDir = TempImageDir & " " & "TagSmiling"
		If CBTagGlaring.Checked = True Then TempImageDir = TempImageDir & " " & "TagGlaring"
		If CBTagSeeThrough.Checked = True Then TempImageDir = TempImageDir & " " & "TagSeeThrough"
		If CBTagAllFours.Checked = True Then TempImageDir = TempImageDir & " " & "TagAllFours"

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
	End Sub


	Public Sub LoadDommeTags()

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
					CBTagSmiling.Checked = False
					CBTagGlaring.Checked = False
					CBTagSeeThrough.Checked = False
					CBTagAllFours.Checked = False
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
					If TagCheckList(i).Contains("TagSmiling") Then CBTagSmiling.Checked = True
					If TagCheckList(i).Contains("TagGlaring") Then CBTagGlaring.Checked = True
					If TagCheckList(i).Contains("TagSeeThrough") Then CBTagSeeThrough.Checked = True
					If TagCheckList(i).Contains("TagAllFours") Then CBTagAllFours.Checked = True

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

End Class