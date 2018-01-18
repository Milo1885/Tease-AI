﻿
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Speech.Synthesis
Imports System.Speech.AudioFormat
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions



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
	Friend Shared ReadOnly pathImageErrorNoLocalImages As String = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"

	Friend Shared ReadOnly SavedSessionDefaultPath As String = Application.StartupPath & "\System\SavedState.save"
#End Region ' File Constants.

	' Github Patch  Public FormLoading As Boolean
	Friend FormLoading As Boolean = True
	Dim FormFinishedLoading As Boolean = False
	Public customVocabLines As List(Of String)
	Dim sshSyncLock As New Object
	''' <summary>
	''' Shorthand Property to access My.Application.Session
	''' </summary>
	''' <returns></returns>
	Public Property ssh As SessionState
		Get
			SyncLock sshSyncLock
				Return My.Application.Session
			End SyncLock
		End Get
		Set(ByVal value As SessionState)
			SyncLock sshSyncLock
				My.Application.Session = value
			End SyncLock
		End Set
	End Property





	Public MetroThread As Thread

#Region "-------------------------------------- StrokePace ----------------------------------------------"
	''' <summary>
	''' Synclock Object to prevent datacorruption of <see cref="ssh.StrokePace"/>.
	''' </summary>
	Public _StrokePaceSyncLock As New Object
	''' <summary>
	''' Gets or sets the strokepace.
	''' Changing this value will  delay the MetronomeThread, until all 
	''' registers are written to RAM.
	''' </summary>
	''' <returns>The current StrokePace.</returns>
	Public Property StrokePace As Integer
		Get
			Return ssh.StrokePace
		End Get
		Set(ByVal value As Integer)
			If value <> ssh.StrokePace Then
				SyncLock _StrokePaceSyncLock
					ssh.StrokePace = value
				End SyncLock
			End If
			If value <> _StrokePaceMetronomeUnsynced Then
				SyncLock _StrokePaceMetronomeSyncLock
					_StrokePaceMetronomeUnsynced = value
				End SyncLock
			End If
		End Set
	End Property
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
	Friend ReadOnly Property StrokePaceMetronome As Integer
		Get
			If Thread.CurrentThread IsNot MetroThread Then _
			 Throw New AccessViolationException("Reading StrokePaceMetronome is restricted to MetronomeThread.")

			SyncLock _StrokePaceMetronomeSyncLock
				Dim tmpInt As Integer = _StrokePaceMetronomeUnsynced
				Return tmpInt
			End SyncLock
		End Get
	End Property
#End Region ' StrokePace

	Public synth As New SpeechSynthesizer
	Public synth2 As New SpeechSynthesizer



	Public ApplyingTheme As Boolean

	Private Const DISABLE_SOUNDS As Integer = 21
	Private Const SET_FEATURE_ON_PROCESS As Integer = 2

	Private Declare Function GetKeyState _
	  Lib "user32" _
	  (ByVal nVirtKey As Long) As Integer
	Private Const VK_LBUTTON = &H1



	<DllImport("urlmon.dll")>
	Public Shared Function CoInternetSetFeatureEnabled(
 ByVal FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> ByVal dwFlags As Integer, ByVal fEnable As Boolean) As Integer

	End Function

	Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String,
   ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer



	Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


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




			If ssh.BeforeTease = False And Val(GetVariable("SYS_SubLeftEarly")) <> 0 Then SetVariable("SYS_SubLeftEarlyTotal", Val(GetVariable("SYS_SubLeftEarlyTotal")) + 1)



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

			If ssh.SaidHello Then SaveChatLog(False)

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



			TeaseAINotify.Visible = False
			TeaseAINotify.Icon = Nothing
			TeaseAINotify.Dispose()
			TeaseAINotify = Nothing


			System.Windows.Forms.Application.DoEvents()
		Catch ex As Exception

		Finally
			My.Settings.Save()
		End Try
	End Sub

	Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

		TeaseAINotify.Visible = False

		TeaseAINotify.Dispose()

		MyBase.OnClosing(e)
	End Sub






	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
retryStart:
			ssh.dommePresent = True
			ssh.contact1Present = False
			ssh.contact2Present = False
			ssh.contact3Present = False
			FrmSplash.PBSplash.Value = 0
			Debug.Print("Form 2 Opened")

			Dim tv As Version = My.Application.Info.Version
			Me.Text = String.Format("Tease A.I. - PATCH {0}.{1}{2}",
				 tv.Minor,
				 tv.Build,
				 If(tv.MinorRevision > 0, "." & tv.MinorRevision, ""))

			FormLoading = True


			FrmSplash.UpdateText("Checking orgasm limit...")

			If My.Settings.OrgasmLockDate = Nothing Then My.Settings.OrgasmLockDate = FormatDateTime(Now, DateFormat.ShortDate)
			Debug.Print("OrgasmLockDate = " & My.Settings.OrgasmLockDate)


			' #############################################################
			FrmSplash.UpdateText("Clearing Metronome settings...")

			StrokePace = 0

			' #############################################################
			FrmSplash.UpdateText("Checking terms and conditions...")

			If My.Settings.TC2Agreed = False Then
				If FrmTaC.ShowDialog() = DialogResult.Yes Then
					My.Settings.TC2Agreed = True
					My.Settings.Save()
				Else
					Process.GetCurrentProcess().Kill()
				End If
			End If

			' #############################################################
			FrmSplash.UpdateText("Checking installed Personalities...")

			For Each Dir As String In myDirectory.GetDirectories(Application.StartupPath & "\Scripts\")
				Try
					Dim DirSplit As String() = Dir.Split("\")
					Dim PersonType As String = DirSplit(DirSplit.Length - 1)
					Debug.Print("Adding Personality: " & PersonType)
					dompersonalitycombobox.Items.Add(PersonType)
				Catch
				End Try
			Next

			If dompersonalitycombobox.Items.Count < 1 Then
				MessageBox.Show(Me, "No domme Personalities were found! Many aspects of this program will not work correctly until at least one Personality is installed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Try
					Debug.Print("Set previous personality: " & My.Settings.DomPersonality)
					dompersonalitycombobox.Text = My.Settings.DomPersonality
				Catch ex As Exception
					dompersonalitycombobox.Text = dompersonalitycombobox.Items(0)
				End Try
			End If

			' #############################################################
			FrmSettings.FrmSettingsLoading = True
			FrmSettings.FrmSettingStartUp()

			Do
				Application.DoEvents()
			Loop Until FrmSettings.FrmSettingsLoading = False

			' #############################################################
			FrmSplash.UpdateText("Calculating total stroke time...")

			Dim STT As TimeSpan = TimeSpan.FromSeconds(ssh.StrokeTimeTotal)
			FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)

			ssh.StrokeTimeTotal = My.Settings.StrokeTimeTotal
			StrokeTimeTotalTimer.Start()

			ssh.DomTask = "Null"
			ssh.DomChat = "Null"

			ssh.CBTBallsFirst = True
			ssh.CBTCockFirst = True
			ssh.CBTBothFirst = True
			ssh.CustomTaskFirst = True

			CoInternetSetFeatureEnabled(DISABLE_SOUNDS, SET_FEATURE_ON_PROCESS, True)

			ssh.Chat = ""
			IsTypingTimer.Start()

			' #############################################################
			FrmSplash.UpdateText("Loading avatar images...")

			'If File.Exists(My.Settings.DomAvatarSave) Then domAvatar.Image = Image.FromFile(My.Settings.DomAvatarSave)
			'If File.Exists(My.Settings.SubAvatarSave) Then subAvatar.Image = Image.FromFile(My.Settings.SubAvatarSave)
			If File.Exists(My.Settings.GlitterAV) Then FrmSettings.GlitterAV.Image = Image.FromFile(My.Settings.GlitterAV)
			If File.Exists(My.Settings.GlitterAV1) Then FrmSettings.GlitterAV1.Image = Image.FromFile(My.Settings.GlitterAV1)
			If File.Exists(My.Settings.GlitterAV2) Then FrmSettings.GlitterAV2.Image = Image.FromFile(My.Settings.GlitterAV2)
			If File.Exists(My.Settings.GlitterAV3) Then FrmSettings.GlitterAV3.Image = Image.FromFile(My.Settings.GlitterAV3)

			' #############################################################
			FrmSplash.UpdateText("Checking recent slideshows...")


			Dim uniqueNames = From u In My.Settings.RecentSlideshows Distinct

			For Each n In uniqueNames
				If Directory.Exists(n) Then ImageFolderComboBox.Items.Add(n)
			Next

			' because Specialized.StringCollections are crap, 
			' we have to clear And refill it using For-Each...
			My.Settings.RecentSlideshows.Clear()

			For Each comboitem As String In ImageFolderComboBox.Items
				My.Settings.RecentSlideshows.Add(comboitem)
			Next

			' #############################################################
			FrmSplash.UpdateText("Checking local videos...")

			' Checks all folders and Sets the VideoCount as LabelText
			FrmSettings.Video_CheckAllFolders()

			ssh.VideoType = "General"

			' #############################################################
			FrmSplash.UpdateText("Starting Glitter APP...")


			ssh.UpdatesTick = 120
			UpdatesTimer.Start()

			Me.ActiveControl = Me.chatBox

			'################## Validate RadioButtons #################
			If My.Settings.CBGlitterFeedOff Then
				My.Settings.CBGlitterFeed = False
				My.Settings.CBGlitterFeedScripts = False
			ElseIf My.Settings.CBGlitterFeed Then
				' No need to unset My.Settings.CBGlitterFeedOff. 
				' If it would be true, this branch is unreachable
				My.Settings.CBGlitterFeedScripts = False
			ElseIf My.Settings.CBGlitterFeed = False _
			  AndAlso My.Settings.CBGlitterFeedOff = False _
			  AndAlso My.Settings.CBGlitterFeedScripts = False Then
				My.Settings.CBGlitterFeedOff = True
			End If


			FrmSplash.UpdateText("Loading names...")


			FrmSettings.petnameBox1.Text = My.Settings.pnSetting1
			FrmSettings.petnameBox2.Text = My.Settings.pnSetting2
			FrmSettings.petnameBox3.Text = My.Settings.pnSetting3
			FrmSettings.petnameBox4.Text = My.Settings.pnSetting4
			FrmSettings.petnameBox5.Text = My.Settings.pnSetting5
			FrmSettings.petnameBox6.Text = My.Settings.pnSetting6
			FrmSettings.petnameBox7.Text = My.Settings.pnSetting7
			FrmSettings.petnameBox8.Text = My.Settings.pnSetting8

			' #############################################################
			FrmSplash.UpdateText("Loading General settings...")


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

			FrmSplash.UpdateText("Loading Domme settings...")

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


			FrmSplash.UpdateText("Checking Glitter scripts...")

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

			FrmSplash.UpdateText("Loading Image settings...")

			FrmSplash.UpdateText("Loading Sub settings...")

			FrmSettings.CockSizeNumBox.Value = My.Settings.SubCockSize
			FrmSettings.subAgeNumBox.Value = My.Settings.SubAge

			FrmSettings.TBGreeting.Text = My.Settings.SubGreeting
			FrmSettings.TBYes.Text = My.Settings.SubYes
			FrmSettings.TBNo.Text = My.Settings.SubNo
			FrmSettings.TBSorry.Text = My.Settings.SubSorry
			FrmSettings.TBHonorific.Text = My.Settings.SubHonorific
			FrmSettings.G1Honorific.Text = My.Settings.G1Honorific
			FrmSettings.G2Honorific.Text = My.Settings.G2Honorific
			FrmSettings.G3Honorific.Text = My.Settings.G3Honorific
			FrmSettings.RandomHonorific.Text = My.Settings.RandomHonorific

			If FrmSettings.TBHonorific.Text = "" Or FrmSettings.TBHonorific.Text Is Nothing Then FrmSettings.TBHonorific.Text = "Mistress"

			If My.Settings.CBUseHonor = True Then
				FrmSettings.CBHonorificInclude.Checked = True
			Else
				FrmSettings.CBHonorificInclude.Checked = False
			End If

			If My.Settings.CBUseName = True Then
				FrmSettings.CBNameInclude.Checked = True
			Else
				FrmSettings.CBNameInclude.Checked = False
			End If

			If My.Settings.CBCapHonor = True Then
				FrmSettings.CBHonorificCapitalized.Checked = True
			Else
				FrmSettings.CBHonorificCapitalized.Checked = False
			End If

			FrmSplash.UpdateText("Loading Range settings...")

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

			FrmSplash.UpdateText("Configuring media player...")

			DomWMP.uiMode = "none"

			If My.Settings.DomAVStretch = False Then domAvatar.SizeMode = PictureBoxSizeMode.Zoom
			'If My.Settings.SubAvStretch = False Then subAvatar.SizeMode = PictureBoxSizeMode.Zoom

			ssh.HoldEdgeTimeTotal = My.Settings.HoldEdgeTimeTotal

			BTNFileTransferOpen.Visible = False
			BTNFIleTransferDismiss.Visible = False

			FrmSplash.UpdateText("Initializing Games window...")


			Try
				RefreshCards()
			Catch
			End Try

			ssh.GoldTokens = My.Settings.GoldTokens
			ssh.SilverTokens = My.Settings.SilverTokens
			ssh.BronzeTokens = My.Settings.BronzeTokens

			If My.Settings.Patch45Tokens = False Then
				ssh.BronzeTokens += 100
				My.Settings.Patch45Tokens = True
				My.Settings.BronzeTokens = ssh.BronzeTokens
			End If

			If ssh.BronzeTokens < 0 Then
				ssh.BronzeTokens = 0
			End If

			If ssh.SilverTokens < 0 Then
				ssh.SilverTokens = 0
			End If

			If ssh.GoldTokens < 0 Then
				ssh.GoldTokens = 0
			End If


			FrmSplash.UpdateText("Checking previous orgasms...")

			If My.Settings.LastOrgasm = Nothing Then
				My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
			End If

			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm.ToString()

			If My.Settings.LastRuined = Nothing Then
				My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
			End If

			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined.ToString()

			FrmSplash.UpdateText("Checking current date...")

			If CompareDates(My.Settings.DateStamp) <> 0 Then

				Dim LoginChance As Integer = ssh.randomizer.Next(1, 101)
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
				ssh.BronzeTokens += LoginAmt
				SaveTokens()
			End If

			Debug.Print("Break here?")


			If CompareDates(My.Settings.WishlistDate) <> 0 Then
				My.Settings.ClearWishlist = False
			End If
			Debug.Print("Test?")


			FrmSplash.UpdateText("Calculating average edge information...")

			ssh.AvgEdgeStroking = My.Settings.AvgEdgeStroking
			ssh.AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
			ssh.AvgEdgeCount = My.Settings.AvgEdgeCount
			ssh.AvgEdgeCountRest = My.Settings.AvgEdgeCountRest



			If My.Settings.AvgEdgeCount > 4 Then
				Dim TS1 As TimeSpan = TimeSpan.FromSeconds(ssh.AvgEdgeStroking)
				FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
			Else
				FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
			End If


			If My.Settings.AvgEdgeCountRest > 4 Then
				Dim TS2 As TimeSpan = TimeSpan.FromSeconds(ssh.AvgEdgeNoTouch)
				FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
			Else
				FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
			End If

			FrmSplash.UpdateText("Loading Domme Personality...")

			ssh.DomPersonality = dompersonalitycombobox.Text

			FrmSplash.UpdateText("Clearing temporary flags...")

			If Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\") Then
				My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\", FileIO.DeleteDirectoryOption.DeleteAllContents)
			End If

			System.IO.Directory.CreateDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\")

			FrmSplash.UpdateText("Loading Glitter Contact image slideshows...")


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

			FrmSplash.UpdateText("Loading Shorthands...")

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

			FrmSplash.UpdateText("Checking saved dimensions...")
			'===============================================================================
			'								Restore View
			'===============================================================================
			CloseApp(Nothing)

			RestoreFormPosition()

			If File.Exists(My.Settings.BackgroundImage) Then
				Me.PnlLayoutForm.BackgroundImage = Image.FromFile(My.Settings.BackgroundImage)
			Else
				Me.PnlLayoutForm.BackgroundImage = Nothing
			End If

			If My.Settings.BackgroundStretch Then PnlLayoutForm.BackgroundImageLayout = ImageLayout.Stretch
			If My.Settings.CBDateTransparent Then PNLDate.BackColor = Color.Transparent

			' Setting the Checked-State will raise the Control's CheckedChanged-Event.
			SwitchSidesToolStripMenuItem.Checked = My.Settings.MirrorWindows
			SidepanelToolStripMenuItem.Checked = My.Settings.DisplaySidePanel
			LazySubAVToolStripMenuItem.Checked = My.Settings.LazySubAV
			MaximizeImageToolStripMenuItem.Checked = My.Settings.MaximizeMediaWindow
			SideChatToolStripMenuItem1.Checked = My.Settings.SideChat

			'----------------------------------------
			' Restore View - End
			'----------------------------------------

			TeaseAIClock.Start()

			FrmSplash.UpdateText("Loading VitalSub...")
			'===============================================================================
			'								Vital sub
			'===============================================================================
			LBLCalorie.Text = My.Settings.CaloriesConsumed
			Debug.Print("VitalSub: Calories consumed: " & My.Settings.CaloriesConsumed)

			Dim VsubDir As String = Application.StartupPath & "\System\VitalSub"

			If Not Directory.Exists(VsubDir) Then Directory.CreateDirectory(VsubDir)

			If File.Exists(Application.StartupPath & "\System\VitalSub\ExerciseList.cld") Then
				LoadExercise()
			End If

			ssh.CaloriesConsumed = My.Settings.CaloriesConsumed

			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieList.txt") Then
				For Each str As String In Txt2List(Application.StartupPath & "\System\VitalSub\CalorieList.txt")
					ComboBoxCalorie.Items.Add(str)
				Next
			End If

			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
				' Read the given File, convert List(of String) to Array and add it to ListboxItems.
				LBCalorie.Items.AddRange(Txt2List(Application.StartupPath & "\System\VitalSub\CalorieItems.txt").ToArray)
				LBLCalorie.Text = ssh.CaloriesConsumed
			Else
				ssh.CaloriesConsumed = 0
				My.Settings.CaloriesConsumed = 0
				LBLCalorie.Text = ssh.CaloriesConsumed
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
			'----------------------------------------
			' Vital sub - End
			'----------------------------------------

			NBMinPace.Value = My.Settings.MinPace
			NBMaxPace.Value = My.Settings.MaxPace


			CBMetronome.Checked = My.Settings.MetroOn


			FrmSettings.CBMuteMedia.Checked = My.Settings.MuteMedia


			FormLoading = False

			Control.CheckForIllegalCrossThreadCalls = False

			MetroThread = New Thread(AddressOf MetronomeTick) With {.Name = "Metronome-Thread"}
			MetroThread.IsBackground = True
			MetroThread.Start()





			'ImageThread.Start()

			FrmSplash.Close()
			FrmSplash.Dispose()



			If VariableExists("SYS_OrgasmRestricted") Then
				If CompareDatesWithTime(GetDate("SYS_OrgasmRestricted")) <> 1 Then
					DeleteVariable("SYS_OrgasmRestricted")
					ssh.OrgasmRestricted = False
				Else
					ssh.OrgasmRestricted = True
				End If
			End If


			ssh.Activate(Me)

			FormFinishedLoading = True


			My.Settings.Save()
			setStartName()
			Trace.WriteLine("Startup has been completed")
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Exception occurred on startup")

			Dim btn As MessageBoxButtons = If(Debugger.IsAttached, MessageBoxButtons.AbortRetryIgnore, MessageBoxButtons.RetryCancel)

			Dim b As MsgBoxResult =
			  MessageBox.Show("An exception occurred on startup. Tease-AI is unable to work correctly until this error is fixed." &
			   vbCrLf & vbCrLf &
			   ex.Message &
			   vbCrLf & vbCrLf &
			   "Further details were written to the error log.", "Startup failed",
			   btn, MessageBoxIcon.Hand)

			If b = MsgBoxResult.Abort Or b = MsgBoxResult.Cancel Then
				Process.GetCurrentProcess().Kill()
			ElseIf b = MsgBoxResult.Retry Then
				GoTo retryStart
			End If

		End Try
	End Sub

	Private Sub Form1_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyCode = (Keys.F Or Keys.Control) Then
			FullscreenToolStripMenuItem_Click(Nothing, Nothing)
		ElseIf e.Alt AndAlso MainMenuStrip.Visible = False Then
			MainMenuStrip.Visible = True
			MainMenuStrip.Focus()
		ElseIf e.Alt AndAlso FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
			MainMenuStrip.Visible = False
		End If
	End Sub

	Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd, Me.Resize
		If Me.IsHandleCreated = False Then Exit Sub
		If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
			Exit Sub
		ElseIf Me.WindowState = FormWindowState.Maximized Then
			My.Settings.WindowHeight = 0
			My.Settings.WindowWidth = 0
		Else
			My.Settings.WindowHeight = Me.Height
			My.Settings.WindowWidth = Me.Width
		End If

	End Sub




	Private Sub sendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendButton.Click
		' Check for empty or whitespaced input.
		If String.IsNullOrWhiteSpace(chatBox.Text & ChatBox2.Text) Then Exit Sub

		If TimeoutTimer.Enabled = True Then TimeoutTimer.Stop()

		If dompersonalitycombobox.Items.Count < 1 Then
			MessageBox.Show(Me, "No domme Personalities were found! Please install at least one Personality directory in the Scripts folder before using this part of the program.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ssh.ChatString = If(Trim(chatBox.Text) <> "", chatBox.Text, ChatBox2.Text)

		chatBox.Text = ""
		ChatBox2.Text = ""

		If CBShortcuts.Checked = True Then

			If UCase(ssh.ChatString) = UCase(TBShortYes.Text) Then ssh.ChatString = "Yes " & ssh.tempHonorific
			If UCase(ssh.ChatString) = UCase(TBShortNo.Text) Then ssh.ChatString = "No " & ssh.tempHonorific
			If UCase(ssh.ChatString) = UCase(TBShortEdge.Text) Then ssh.ChatString = "On the edge"
			If UCase(ssh.ChatString) = UCase(TBShortSpeedUp.Text) Then ssh.ChatString = "Let me speed up"
			If UCase(ssh.ChatString) = UCase(TBShortSlowDown.Text) Then ssh.ChatString = "Let me slow down"
			If UCase(ssh.ChatString) = UCase(TBShortStop.Text) Then ssh.ChatString = "Let me stop"
			If UCase(ssh.ChatString) = UCase(TBShortStroke.Text) Then ssh.ChatString = "May I start stroking?"
			If UCase(ssh.ChatString) = UCase(TBShortCum.Text) Then ssh.ChatString = "Please let me cum " & ssh.tempHonorific
			If UCase(ssh.ChatString) = UCase(TBShortGreet.Text) Then ssh.ChatString = "Hello " & ssh.tempHonorific
			If UCase(ssh.ChatString) = UCase(TBShortSafeword.Text) Then ssh.ChatString = FrmSettings.TBSafeword.Text

		End If




		If ssh.ChatString.Substring(0, 1) = "@" Then
			ChatAddScriptPosInfo(ssh.ChatString)

			Exit Sub
		End If

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If





		If ssh.WritingTaskFlag = True Then GoTo WritingTaskLine

		ChatAddMessage(My.Settings.SubName, ssh.ChatString)





		ssh.SubWroteLast = True




		'If frmApps.CBDebugAwareness.Checked = True Then GoTo DebugAwareness



		If ssh.SaidHello = False Then
			If UCase(ssh.ChatString).Contains("TASK") Then
				Dim TaskList As New List(Of String)

				For Each TaskFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Tasks\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					TaskList.Add(TaskFile)
				Next

				If TaskList.Count > 0 Then
					If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
						LoadDommeImageFolder()
					End If
					ssh.BeforeTease = True
					ssh.SaidHello = True
					ssh.SubEdging = False
					ssh.SubHoldingEdge = False
					ssh.FileText = TaskList(ssh.randomizer.Next(0, TaskList.Count))
					ssh.LockImage = False
					If ssh.SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						PicStripTSMIdommeSlideshow.Enabled = True
					End If
					ssh.StrokeTauntVal = -1
					ssh.ScriptTick = 3
					ScriptTimer.Start()
					ssh.ShowModule = False
				Else
					MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Tasks!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				Return
			End If

			Debug.Print("CHeck")

			If checkSubAnswer("hi") = 1 Then
				Debug.Print("CHeck")
				ssh.justStarted = True
				ssh.SaidHello = True
				ssh.BeforeTease = True



				If FrmSettings.CBTeaseLengthDD.Checked = True Then


					If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60


				Else

					ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)

				End If


				TeaseTimer.Start()

				' Lock Orgasm Chances if setting is activated. 
				If My.Settings.LockOrgasmChances Then _
				 FrmSettings.LockOrgasmChances(True)

				If ssh.PlaylistFile.Count = 0 Then GoTo NoPlaylistStartFile

				If ssh.Playlist = False Or ssh.PlaylistFile(0).Contains("Random Start") Then

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
							ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start_CHASTITY.txt"
						Else
							ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start.txt"
						End If
					Else
						ssh.FileText = StartList(ssh.randomizer.Next(0, StartList.Count))
					End If

				Else
					Debug.Print("Start situation found")
					If ssh.PlaylistFile(0).Contains("Regular-TeaseAI-Script") Then
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Start\" & ssh.PlaylistFile(0)
						ssh.FileText = ssh.FileText.Replace(" Regular-TeaseAI-Script", "")
						ssh.FileText = ssh.FileText & ".txt"
					Else
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Start\" & ssh.PlaylistFile(0) & ".txt"
					End If
				End If

				If ssh.Playlist = True Then ssh.PlaylistCurrent += 1
				ssh.LastScriptCountdown = ssh.randomizer.Next(3, 5 * FrmSettings.domlevelNumBox.Value)

				If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
					If FrmSettings.CBRandomDomme.Checked = True Then ssh.glitterDommeNumber = 4
					LoadDommeImageFolder()
				End If


				ssh.StrokeTauntVal = -1
				ssh.ScriptTick = 3
				ScriptTimer.Start()

			End If

		End If




		If ssh.SaidHello = False Then Return

		If UCase(ssh.ChatString) = UCase(FrmSettings.TBSafeword.Text) Then


			Dim SafeList As New List(Of String)

			For Each SafeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				SafeList.Add(SafeFile)
			Next

			If SafeList.Count > 0 Then
				StopEverything()
				ssh.FileText = SafeList(ssh.randomizer.Next(0, SafeList.Count))
				ssh.ShowModule = True
				ssh.StrokeTauntVal = -1
				ssh.ScriptTick = 2
				ScriptTimer.Start()
			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			Return
		End If

		If UCase(ssh.ChatString).Contains(UCase("stop")) Then TnASlides.Stop()

		' If UCase(ChatString).Contains(UCase("stop")) Then
		'If CustomSlideshow = True Then CustomSlideshowTimer.Stop()
		'End If


WritingTaskLine:

		If ssh.WritingTaskFlag = True Then
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'								Writing Task
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

			' ##################### Evaluate Input ########################
			Dim InputWrong, TaskTimeout, TaskFailed, TaskSuccess As Boolean

			If ssh.ChatString = LBLWritingTaskText.Text Then

				ssh.WritingTaskLinesWritten += 1
				ssh.WritingTaskLinesRemaining -= 1
				LBLLinesWritten.Text = ssh.WritingTaskLinesWritten
				LBLLinesRemaining.Text = ssh.WritingTaskLinesRemaining

				If ssh.WritingTaskLinesRemaining <= 0 Then TaskSuccess = True

			Else

				InputWrong = True

				ssh.WritingTaskMistakesMade += 1
				LBLMistakesMade.Text = ssh.WritingTaskMistakesMade

				If ssh.WritingTaskMistakesAllowed - ssh.WritingTaskMistakesMade <= 0 Then TaskFailed = True

			End If

			If ssh.WritingTaskCurrentTime < 1 And My.Settings.TimedWriting = True And ssh.WritingTaskFlag = True Then
				TaskTimeout = True
			End If

			' ################# Generate output text ######################
			Dim ProgrText As String = ""
			Dim OutColor As String = ""
			Dim OutHtml As String = "<span style=""color:{0}"">{1}</span>"

			If TaskTimeout Or TaskFailed Or InputWrong Then
				If TaskTimeout Then
					ProgrText = "Time Expired"
				ElseIf TaskFailed Then
					ProgrText = "Task Failed"
				ElseIf InputWrong Then
					ProgrText = String.Format("Wrong: {0} mistakes remaining", ssh.WritingTaskMistakesAllowed - ssh.WritingTaskMistakesMade)
					If ssh.WritingTaskMistakesAllowed - ssh.WritingTaskMistakesMade = 1 Then ProgrText = ProgrText.Replace("mistakes", "mistake")
				End If

				OutColor = "red"
			Else
				If TaskSuccess Then
					ProgrText = "Task completed successfully"
				Else
					ProgrText = String.Format("Correct: {0} lines remaining", ssh.WritingTaskLinesRemaining)
					If ssh.WritingTaskLinesRemaining = 1 Then ProgrText = ProgrText.Replace("lines", "line")
				End If

				OutColor = "green"
			End If

			' ####################### Print output ########################
			ChatAddMessage(My.Settings.SubName, String.Format(OutHtml, OutColor, ssh.ChatString), True)
			ChatAddWritingTaskInfo(String.Format(OutHtml, OutColor, ProgrText))

			' ##################### Continue script? ######################
			If TaskTimeout Or TaskFailed Then

				ClearWriteTask()
				ssh.SkipGotoLine = True
				ssh.FileGoto = "Failed Writing Task"
				GetGoto()
				ssh.ScriptTick = 4
				ScriptTimer.Start()

			ElseIf TaskSuccess Then

				ClearWriteTask()
				ssh.ScriptTick = 3
				ScriptTimer.Start()

			End If


			If ssh.randomWriteTask Then setWriteTask()
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' Writing Task - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		End If

		If ssh.AFK And Not ssh.YesOrNo Then Return

		' Previous Commas





		Dim EdgeList As New List(Of String)
		EdgeList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeKEY.txt")



		Dim EdgeCheck As String = ssh.ChatString

		Dim EdgeString As String

		Debug.Print("EdgeFOund 1 = " & ssh.EdgeFound)

		For i As Integer = 0 To EdgeList.Count - 1
			EdgeString = EdgeList(i)
			EdgeString = EdgeString.Replace("'", "")
			EdgeString = EdgeString.Replace(".", "")
			EdgeString = EdgeString.Replace(",", "")
			EdgeString = EdgeString.Replace("!", "")
			EdgeCheck = EdgeCheck.Replace("'", "")
			EdgeCheck = EdgeCheck.Replace(".", "")
			EdgeCheck = EdgeCheck.Replace(",", "")
			EdgeCheck = EdgeCheck.Replace("!", "")
			If UCase(EdgeCheck).Contains("DONT") Or UCase(EdgeCheck).Contains("NEVER") Or UCase(EdgeCheck).Contains("NOT") Then
				If UCase(EdgeCheck).Contains(UCase(EdgeString)) Then
					ssh.EdgeNOT = True
					Exit For
				End If
			End If
			If UCase(EdgeString) = UCase(EdgeCheck) Then
				ssh.EdgeFound = True
				Exit For
			End If
		Next

		Debug.Print("EdgeFOund 2 = " & ssh.EdgeFound)

		If ssh.EdgeFound = True And My.Settings.Chastity = False Then



			Debug.Print("EdgeFOund = True Called")

			ssh.EdgeFound = False


			If ssh.SubHoldingEdge = True Then
				Debug.Print("EdgeFOund = SubHoldingedge")
				ssh.DomChat = " #YoureAlreadySupposedToBeClose"
				TypingDelay()
				Return
			End If

			SetVariable("SYS_EdgeTotal", Val(GetVariable("SYS_EdgeTotal") + 1))

			If ssh.TauntEdging = True And ssh.SubEdging = False And ssh.ShowModule = False Then
				ssh.DomChat = "#SYS_TauntEdgingAsked"
				TypingDelay()

				' Recalculate TantEdging-Chance
				If ssh.randomizer.Next(1, 101) <= FrmSettings.NBTauntEdging.Value Then
					ssh.TauntEdging = False
				End If

				Exit Sub
			End If


			If ssh.edgeMode.VideoMode = True Then
				ssh.SessionEdges += 1
				ssh.edgeMode.VideoMode = False
				ssh.TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh.FileGoto = ssh.edgeMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If

			If ssh.edgeMode.GotoMode = True Then
				ssh.SessionEdges += 1
				ssh.edgeMode.GotoMode = False
				ssh.FileGoto = ssh.edgeMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If

			If ssh.edgeMode.MessageMode = True Then
				ssh.SessionEdges += 1
				ssh.edgeMode.MessageMode = False
				ssh.ChatString = ssh.edgeMode.MessageText
				GoTo DebugAwareness
			End If

			'EdgeMessageYesNo = EdgeArray(1)

			If ssh.RLGLGame = True Then
				Debug.Print("EdgeFOund = RLGL")
				ssh.DomChat = "#TryToHoldIt"
				TypingDelay()
				Return
			End If


			If ssh.AvoidTheEdgeStroking = True Then

				Debug.Print("EdgeFOund = ATE")

				AvoidTheEdgeTaunts.Stop()

				ssh.SessionEdges += 1
				ssh.AvoidTheEdgeStroking = False
				ssh.VideoTease = False

				Dim ATEList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Avoid The Edge\Scripts\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					ATEList.Add(foundFile)
				Next

				If ATEList.Count < 1 Then
					MessageBox.Show(Me, "No Avoid The Edge scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If

				DomWMP.Ctlcontrols.pause()

				ssh.StrokeTauntVal = -1
				ssh.FileText = ATEList(ssh.randomizer.Next(0, ATEList.Count))

				ssh.ScriptTick = 2
				ScriptTimer.Start()
				Return
			End If


			If ssh.SubEdging = True Then

				Debug.Print("EdgeFOund = SubEdging")

				EdgeCountTimer.Stop()

				If ssh.MultipleEdges = True Then
					ssh.MultipleEdgesAmount -= 1
					ssh.SessionEdges += 1

					If ssh.MultipleEdgesAmount < 1 Then

						ssh.MultipleEdges = False

					Else

						EdgeCountTimer.Stop()
						ssh.DomChat = "#SYS_MultipleEdgesStop"
						If ssh.Contact1Edge = True Then ssh.DomChat = "@Contact1 #SYS_MultipleEdgesStop"
						If ssh.Contact2Edge = True Then ssh.DomChat = "@Contact2 #SYS_MultipleEdgesStop"
						If ssh.Contact3Edge = True Then ssh.DomChat = "@Contact3 #SYS_MultipleEdgesStop"
						TypingDelay()
						ssh.MultipleEdgesTick = ssh.MultipleEdgesInterval
						MultipleEdgesTimer.Start()
						ssh.MultipleEdgesMetronome = "STOP"
						Return

					End If


				End If

				If ssh.AlreadyStrokingEdge = True Then
					ssh.AvgEdgeCount += 1
					If ssh.AvgEdgeStroking = 0 Then
						ssh.AvgEdgeStroking = ssh.EdgeCountTick
					Else
						ssh.AvgEdgeStroking = ssh.AvgEdgeStroking + ssh.EdgeCountTick
					End If
					My.Settings.AvgEdgeStroking = ssh.AvgEdgeStroking
					My.Settings.AvgEdgeCount = ssh.AvgEdgeCount
				Else
					ssh.AvgEdgeCountRest += 1
					If ssh.AvgEdgeNoTouch = 0 Then
						ssh.AvgEdgeNoTouch = ssh.EdgeCountTick
					Else
						ssh.AvgEdgeNoTouch = ssh.AvgEdgeNoTouch + ssh.EdgeCountTick
					End If
					My.Settings.AvgEdgeNoTouch = ssh.AvgEdgeNoTouch
					My.Settings.AvgEdgeCountRest = ssh.AvgEdgeCountRest
				End If


				If My.Settings.AvgEdgeCount > 4 Then
					ssh.AvgEdgeStroking = My.Settings.AvgEdgeStroking
					Dim TS1 As TimeSpan = TimeSpan.FromSeconds(ssh.AvgEdgeStroking / ssh.AvgEdgeCount)
					FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
				Else
					FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
				End If

				If My.Settings.AvgEdgeCountRest > 4 Then
					ssh.AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
					Dim TS2 As TimeSpan = TimeSpan.FromSeconds(ssh.AvgEdgeNoTouch / ssh.AvgEdgeCountRest)
					FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
				Else
					FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
				End If

				If FrmSettings.domlevelNumBox.Value = 1 Then ssh.HoldEdgeChance = 20
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh.HoldEdgeChance = 25
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh.HoldEdgeChance = 30
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh.HoldEdgeChance = 40
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh.HoldEdgeChance = 50

				Dim HoldEdgeInt As Integer = ssh.randomizer.Next(1, 101)

				If ssh.EdgeHold = True Then HoldEdgeInt = 0
				If ssh.EdgeNoHold = True Then HoldEdgeInt = 1000


				Debug.Print("HoldEdgeInt = " & HoldEdgeInt)

				ssh.EdgeHold = False
				ssh.EdgeNoHold = False



				If HoldEdgeInt < ssh.HoldEdgeChance Then

					Debug.Print("EdgeFOund = HOldtheedge")

					ssh.DomTypeCheck = True
					ssh.SubEdging = False
					ssh.SubStroking = False
					ssh.SubHoldingEdge = True
					EdgeTauntTimer.Stop()
					ssh.DomChat = "#HoldTheEdge"
					If ssh.Contact1Edge = True Then
						ssh.DomChat = "@Contact1 #HoldTheEdge"
						' Github Patch Contact1Edge = False
					End If
					If ssh.Contact2Edge = True Then
						ssh.DomChat = "@Contact2 #HoldTheEdge"
						' github Patch Contact2Edge = False
					End If
					If ssh.Contact3Edge = True Then
						ssh.DomChat = "@Contact3 #HoldTheEdge"
						' github patch Contact3Edge = False
					End If
					TypingDelay()


					If ssh.EdgeHoldFlag = False Then

						ssh.HoldEdgeTick = ssh.HoldEdgeChance

						Dim HoldEdgeMin As Integer
						Dim HoldEdgeMax As Integer

						HoldEdgeMin = FrmSettings.NBHoldTheEdgeMin.Value
						If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

						HoldEdgeMax = FrmSettings.NBHoldTheEdgeMax.Value
						If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60


						If ssh.ExtremeHold = True Then
							HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
						End If

						If ssh.LongHold = True Then
							HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
						End If

						If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

						ssh.HoldEdgeTick = ssh.randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)

						If ssh.HoldEdgeTick < 10 Then ssh.HoldEdgeTick = 10

					Else

						ssh.HoldEdgeTick = ssh.EdgeHoldSeconds
						ssh.EdgeHoldFlag = False

					End If

					ssh.HoldEdgeTime = 0

					HoldEdgeTimer.Start()
					HoldEdgeTauntTimer.Start()
					Return

				Else

					If ssh.EdgeToRuin = True Or ssh.OrgasmRuined = True Then
						ssh.LastOrgasmType = "RUINED"
						ssh.OrgasmRuined = False
						GoTo RuinedOrgasm
					End If

					If ssh.OrgasmAllowed = True Then
						ssh.LastOrgasmType = "ALLOWED"
						ssh.OrgasmAllowed = False
						GoTo AllowedOrgasm
					End If


					Debug.Print("Ruined Orgasm skipped")

					If ssh.OrgasmDenied = True Then

						ssh.LastOrgasmType = "DENIED"

						If FrmSettings.CBDomDenialEnds.Checked = False And ssh.TeaseTick < 1 Then

							Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

							If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then
								ssh.SecondSession = False
								ssh.SubEdging = False
								ssh.SubStroking = False
								EdgeTauntTimer.Stop()

								Dim RepeatList As New List(Of String)

								For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
									RepeatList.Add(foundFile)
								Next

								If RepeatList.Count < 1 Then GoTo NoRepeatFiles


								If FrmSettings.CBTeaseLengthDD.Checked = True Then
									If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
									If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
									If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
									If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
									If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
								Else
									ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
								End If
								TeaseTimer.Start()

								ssh.OrgasmYesNo = False

								'Github Patch
								ssh.YesOrNo = False

								'ShowModule = True
								ssh.StrokeTauntVal = -1
								ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
								ssh.ScriptTick = 2
								ScriptTimer.Start()
								ssh.OrgasmDenied = False
								ssh.OrgasmYesNo = False
								ssh.EndTease = False
								Return
							Else
								If ssh.LastScript = True Then ssh.EndTease = True
							End If

						End If


					End If

NoRepeatFiles:

					ssh.DomTypeCheck = True
					ssh.OrgasmYesNo = False
					ssh.SubEdging = False
					ssh.SubStroking = False
					EdgeTauntTimer.Stop()
					ssh.DomChat = "#StopStrokingEdge"
					If ssh.Contact1Edge = True Then
						ssh.DomChat = "@Contact1 #StopStrokingEdge"
						ssh.Contact1Edge = False
					End If
					If ssh.Contact2Edge = True Then
						ssh.DomChat = "@Contact2 #StopStrokingEdge"
						ssh.Contact2Edge = False
					End If
					If ssh.Contact3Edge = True Then
						ssh.DomChat = "@Contact3 #StopStrokingEdge"
						ssh.Contact3Edge = False
					End If
					TypingDelay()
					Return

				End If

RuinedOrgasm:

				My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
				FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

				If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh.OrgasmRuined = True And ssh.TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

					If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then

						ssh.SecondSession = False
						ssh.SubEdging = False
						ssh.SubStroking = False
						ssh.EdgeToRuin = False
						ssh.EdgeToRuinSecret = True
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
						Else
							ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						ssh.OrgasmYesNo = False

						'Github Patch
						ssh.YesOrNo = False

						'ShowModule = True
						ssh.StrokeTauntVal = -1
						ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
						ssh.ScriptTick = 2
						ScriptTimer.Start()
						ssh.OrgasmRuined = False
						ssh.OrgasmYesNo = False
						ssh.EndTease = False
						Return
					Else
						If ssh.LastScript = True Then ssh.EndTease = True
					End If

				End If



NoRepeatRFiles:


				ssh.DomTypeCheck = True
				ssh.SubEdging = False
				ssh.SubStroking = False
				ssh.EdgeToRuin = False
				ssh.EdgeToRuinSecret = True
				EdgeTauntTimer.Stop()
				ssh.OrgasmYesNo = False
				ssh.DomChat = "#RuinYourOrgasm"
				If ssh.Contact1Edge = True Then
					ssh.DomChat = "@Contact1 #RuinYourOrgasm"
					ssh.Contact1Edge = False
				End If
				If ssh.Contact2Edge = True Then
					ssh.DomChat = "@Contact2 #RuinYourOrgasm"
					ssh.Contact2Edge = False
				End If
				If ssh.Contact3Edge = True Then
					ssh.DomChat = "@Contact3 #RuinYourOrgasm"
					ssh.Contact3Edge = False
				End If
				TypingDelay()
				If ssh.LastScript = True Then ssh.EndTease = True
				Return

AllowedOrgasm:

				If My.Settings.OrgasmsLocked = True Then

					If My.Settings.OrgasmsRemaining < 1 Then

						Dim NoCumList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Out of Orgasms\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							NoCumList.Add(foundFile)
						Next

						If NoCumList.Count < 1 Then GoTo NoNoCumFiles


						ssh.SubEdging = False
						ssh.SubStroking = False
						EdgeTauntTimer.Stop()
						ssh.OrgasmYesNo = False

						'Github Patch
						ssh.YesOrNo = False

						'ShowModule = True
						ssh.StrokeTauntVal = -1
						ssh.FileText = NoCumList(ssh.randomizer.Next(0, NoCumList.Count))
						ssh.ScriptTick = 2
						ScriptTimer.Start()
						Return
					End If


					My.Settings.OrgasmsRemaining -= 1


				End If

NoNoCumFiles:

				My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
				FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

				If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh.TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

					If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then
						ssh.SecondSession = False
						ssh.SubEdging = False
						ssh.SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
						Else
							ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						ssh.OrgasmYesNo = False

						'Github Patch
						ssh.YesOrNo = False

						'ShowModule = True
						ssh.StrokeTauntVal = -1
						ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
						ssh.ScriptTick = 2
						ScriptTimer.Start()
						ssh.OrgasmAllowed = False
						ssh.OrgasmYesNo = False
						ssh.EndTease = False
						Return
					Else
						If ssh.LastScript = True Then ssh.EndTease = True
					End If

				End If



NoRepeatOFiles:








				ssh.DomTypeCheck = True
				ssh.SubEdging = False
				ssh.SubStroking = False
				'OrgasmAllowed = False
				EdgeTauntTimer.Stop()
				ssh.OrgasmYesNo = False
				ssh.DomChat = "#CumForMe"
				If ssh.Contact1Edge = True Then
					ssh.DomChat = "@Contact1 #CumForMe"
					ssh.Contact1Edge = False
				End If
				If ssh.Contact2Edge = True Then
					ssh.DomChat = "@Contact2 #CumForMe"
					ssh.Contact2Edge = False
				End If
				If ssh.Contact3Edge = True Then
					ssh.DomChat = "@Contact3 #CumForMe"
					ssh.Contact3Edge = False
				End If
				TypingDelay()
				If ssh.LastScript = True Then ssh.EndTease = True
				Return


			End If



			If ssh.SubStroking = True Then

				Dim TauntStop As Integer = ssh.randomizer.Next(1, 101)

				If TauntStop <= FrmSettings.NBTauntEdging.Value Then

					ssh.FirstRound = False
					'ShowModule = True
					StrokeTauntTimer.Stop()
					StrokeTimer.Stop()


					If ssh.BookmarkModule = True Then
						ssh.DomTypeCheck = True
						ssh.SubEdging = False
						ssh.SubStroking = False
						ssh.DomChat = "#StopStrokingEdge"
						If ssh.Contact1Edge = True Then
							ssh.DomChat = "@Contact1 #StopStrokingEdge"
							ssh.Contact1Edge = False
						End If
						If ssh.Contact2Edge = True Then
							ssh.DomChat = "@Contact2 #StopStrokingEdge"
							ssh.Contact2Edge = False
						End If
						If ssh.Contact3Edge = True Then
							ssh.DomChat = "@Contact3 #StopStrokingEdge"
							ssh.Contact3Edge = False
						End If
						TypingDelay()

						Do
							Application.DoEvents()
						Loop Until ssh.DomTypeCheck = False

						ssh.BookmarkModule = False
						ssh.FileText = ssh.BookmarkModuleFile
						ssh.StrokeTauntVal = ssh.BookmarkModuleLine
						RunFileText()
						Return
					End If

					RunModuleScript(True)

				Else

					ssh.TauntEdging = True
					ssh.DomChat = "#SYS_TauntEdging"
					TypingDelay()

				End If



			End If


			Return

		End If


		If ssh.EdgeFound = True And My.Settings.Chastity = True Then
			ssh.EdgeFound = False
			ssh.EdgeNOT = True
		End If






DebugAwareness:



		If ssh.InputFlag = True And ssh.DomTypeCheck = False Then
			SetVariable(ssh.InputString, ssh.ChatString)
			'ssh.InputFlag = False
		End If

		' Remove commas and apostrophes from user's entered text
		ssh.ChatString = ssh.ChatString.Replace(",", "")
		ssh.ChatString = ssh.ChatString.Replace("'", "")
		ssh.ChatString = ssh.ChatString.Replace(".", "")


		If UCase(ssh.ChatString) = UCase("CAME") Or UCase(ssh.ChatString) = UCase("I CAME") Or UCase(ssh.ChatString) = UCase("JUST CAME") Or UCase(ssh.ChatString) = UCase("I JUST CAME") Then
			If ssh.cameMode.MessageMode = True Then
				ssh.cameMode.MessageMode = False
				ssh.ChatString = ssh.cameMode.MessageText
			End If
		End If

		If UCase(ssh.ChatString) = UCase("RUINED") Or UCase(ssh.ChatString) = UCase("I RUINED") Or UCase(ssh.ChatString) = UCase("RUINED IT") Or UCase(ssh.ChatString) = UCase("I RUINED IT") Then
			If ssh.ruinMode.MessageMode = True Then
				ssh.ruinMode.MessageMode = False
				ssh.ChatString = ssh.ruinMode.MessageText
			End If
		End If


		' If the domme is waiting for a response, go straight to this sub-routine instead
		If ssh.YesOrNo = True And ssh.SubEdging = True Then GoTo EdgeSkip
		If ssh.YesOrNo = True And ssh.SubHoldingEdge = True Then GoTo EdgeSkip

		If ssh.YesOrNo = True And ssh.OrgasmYesNo = False And ssh.DomTypeCheck = False Then 'And ssh.TasksCount <= 0 Then
			YesOrNoQuestions()
			Return
		End If



EdgeSkip:

		Debug.Print("Before Dom Response, YesOrNo = " & ssh.YesOrNo)

		DomResponse()

		'CalculateResponse()

	End Sub

	Public Sub DomResponse()
		If ssh.WritingTaskFlag Then Return

		If ssh.dontCheck Then
			ssh.dontCheck = False
			Return
		End If

		Debug.Print("DomResponse Called")
		If ssh.justStarted Then
			ssh.justStarted = False
		Else
			If checkSubAnswer(, False) = 0 Then
				checkForPunish()
				Return
			End If
		End If

		If ssh.InputFlag = True Then
			ssh.InputFlag = False
			Return
		End If

		If ssh.EdgeNOT = True Then
			ssh.EdgeNOT = False
			ssh.ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeNOT.txt")
			GoTo FoundResponse
		End If





		'If BeforeTease = True And CBDebugAwareness.Checked = False Then Return

		Dim CheckResponse As String = UCase(ssh.ChatString)
		CheckResponse = CheckResponse.Replace(UCase(ssh.tempDomName), "")
		If ssh.tempHonorific <> "" Then CheckResponse = CheckResponse.Replace(UCase(ssh.tempHonorific), "")
		CheckResponse = CheckResponse.Replace("!", "")
		CheckResponse = CheckResponse.Replace("?", "")
		CheckResponse = CheckResponse.Replace(".", "")
		CheckResponse = CheckResponse.Replace("*", "")
		CheckResponse = CheckResponse.Replace("  ", " ")

		'   If Not CheckResponse = UCase("please") Then CheckResponse = CheckResponse.Replace(UCase("please"), "")
		'	If Not CheckResponse = UCase("fucking") Then CheckResponse = CheckResponse.Replace(UCase("fucking"), "")
		'	If Not CheckResponse = UCase("fuckin") Then CheckResponse = CheckResponse.Replace(UCase("fuckin"), "")

		CheckResponse = Trim(CheckResponse)

		If UCase(CheckResponse) = UCase("CAME") Or UCase(CheckResponse) = UCase("I CAME") Then
			If ssh.cameMode.GotoMode = True Then
				ssh.cameMode.GotoMode = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					ssh.YesOrNo = False
					ssh.InputFlag = False
				End If
				ssh.FileGoto = ssh.cameMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If
			If ssh.cameMode.VideoMode = True Then
				ssh.cameMode.VideoMode = False
				ssh.TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh.FileGoto = ssh.cameMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If


		If UCase(CheckResponse) = UCase("RUINED") Or UCase(CheckResponse) = UCase("I RUINED") Or UCase(CheckResponse) = UCase("RUINED IT") Or UCase(CheckResponse) = UCase("I RUINED IT") Then
			If ssh.ruinMode.GotoMode = True Then
				ssh.ruinMode.GotoMode = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					ssh.YesOrNo = False
					ssh.InputFlag = False
				End If
				ssh.FileGoto = ssh.ruinMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If
			If ssh.ruinMode.VideoMode = True Then
				ssh.ruinMode.VideoMode = False
				ssh.TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh.FileGoto = ssh.ruinMode.GotoLine
				ssh.SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If

		If ssh.Modes.Count > 0 Then
			If ssh.Modes.Keys.Contains(CheckResponse) Then
				If ssh.Modes(CheckResponse).Type.ToUpper.Contains("GOTO") Then
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh.YesOrNo = False
						ssh.InputFlag = False
					End If
					ssh.FileGoto = ssh.Modes(CheckResponse).GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
					ssh.Modes.Remove(CheckResponse)
					Return
				End If
				If ssh.Modes(CheckResponse).Type.ToUpper.Contains("VIDEO") Then
					ssh.TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh.FileGoto = ssh.Modes(CheckResponse).GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
					ssh.Modes.Remove(CheckResponse)
					Return
				End If
			End If
		End If


		ssh.ResponseFile = ""

		Dim YesSplit As String = FrmSettings.TBYes.Text

		Do
			YesSplit = YesSplit.Replace("  ", " ")
			YesSplit = YesSplit.Replace(" ,", ",")
			YesSplit = YesSplit.Replace(", ", ",")
			YesSplit = YesSplit.Replace("'", "")
		Loop Until Not YesSplit.Contains("  ") And Not YesSplit.Contains(", ") And Not YesSplit.Contains(" ,") And Not YesSplit.Contains("'")

		If ssh.yesMode.GotoMode = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.yesMode.GotoMode = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh.YesOrNo = False
						ssh.InputFlag = False
					End If
					ssh.FileGoto = ssh.yesMode.GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh.yesMode.GotoMode = False Then Return
		End If

		If ssh.yesMode.VideoMode = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.yesMode.VideoMode = False
					ssh.TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh.FileGoto = ssh.yesMode.GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh.yesMode.VideoMode = False Then Return
		End If

		If ssh.ResponseYes <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh.ResponseYes & ".txt") Then

			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh.ResponseYes & ".txt"
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

		If ssh.noMode.GotoMode = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.noMode.GotoMode = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh.YesOrNo = False
						ssh.InputFlag = False
					End If
					ssh.FileGoto = ssh.noMode.GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh.noMode.GotoMode = False Then Return
		End If

		If ssh.noMode.VideoMode = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.noMode.VideoMode = False
					ssh.TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh.FileGoto = ssh.noMode.GotoLine
					ssh.SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh.noMode.VideoMode = False Then Return
		End If

		If ssh.ResponseNo <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh.ResponseNo & ".txt") Then

			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh.ResponseNo & ".txt"
					GoTo FoundResponse
					Exit For
				End If
			Next
		End If

		If ssh.BeforeTease = False Then
			If UCase(CheckResponse).Contains(UCase("I have an orgasm")) Or UCase(CheckResponse).Contains(UCase("me have an orgasm")) Then
				If ssh.TeaseTick > 0 Then
					ssh.ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\BegToCum.txt")
					If My.Settings.Chastity = False And ssh.OrgasmRestricted = False Then ssh.TeaseTick = ssh.TeaseTick / 2
					Debug.Print("LastScriptCountdown = " & ssh.LastScriptCountdown)
					If ssh.TeaseTick < 1 And ssh.Playlist = False And ssh.OrgasmRestricted = False Then
						StrokeTimer.Stop()
						StrokeTauntTimer.Stop()
						EdgeTauntTimer.Stop()
						ssh.SubStroking = False
						ssh.SubEdging = False
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
						ssh.ResponseFile = foundFile
						ssh.ResponseFile = ssh.ResponseFile.Replace("KEY", "")
						'QUESTION: (Stefaf) What does the following line?
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ssh.ResponseFile = ssh.ResponseFile.Replace(".txt", "NOT.txt")
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
			If SplitResponse(0).Contains("#") Then
				ssh.addResponseList = True
				SplitResponse(0) = PoundClean(SplitResponse(0))
				ssh.addResponseList = False
			End If
			Do
				SplitResponse(0) = SplitResponse(0).Replace("  ", " ")
				SplitResponse(0) = SplitResponse(0).Replace(" ,", ",")
				SplitResponse(0) = SplitResponse(0).Replace(", ", ",")
				SplitResponse(0) = SplitResponse(0).Replace("'", "")
			Loop Until Not SplitResponse(0).Contains("  ") And Not SplitResponse(0).Contains(", ") And Not SplitResponse(0).Contains(" ,") And Not SplitResponse(0).Contains("'")

			Dim SplitParts As String() = SplitResponse(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh.ResponseFile = foundFile
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
						ssh.ResponseFile = foundFile
						ssh.ResponseFile = ssh.ResponseFile.Replace("KEY", "")
						'QUESTION: (Stefaf) What does the following line?
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ssh.ResponseFile = ssh.ResponseFile.Replace(".txt", "NOT.txt")
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
				If SplitResponse(0).Contains("#") Then
					ssh.addResponseList = True
					SplitResponse(0) = PoundClean(SplitResponse(0))
					ssh.addResponseList = False
				End If

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
						ssh.ResponseFile = foundFile
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
			If SplitResponse(0).Contains("#") Then
				ssh.addResponseList = True
				SplitResponse(0) = PoundClean(SplitResponse(0))
				ssh.addResponseList = False
			End If

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
					ssh.ResponseFile = foundFile
					If Not UCase(CheckResponse).Contains(CheckResponseArray(j)) Then
						ssh.ResponseFile = ""
						Exit For
					End If
				Next

				If ssh.ResponseFile <> "" Then GoTo FoundResponse

			Next

		Next



		If ssh.CBTCockFlag = True Or ssh.CBTBallsFlag = True Or ssh.CBTBothFlag = True Or ssh.CustomTask = True Then
			ssh.TasksCount -= 1
			If ssh.TasksCount < 1 Then
				ssh.CBTCockFlag = False
				ssh.CBTBallsFlag = False
				ssh.CBTBothFlag = False
				ssh.CustomTask = False
				ssh.CBTBallsFirst = True
				ssh.CBTCockFirst = True
				ssh.CBTBothFirst = True
				ssh.CustomTaskFirst = True
				ssh.ScriptTick = 3
				ScriptTimer.Start()
				If ssh.YesOrNo Then
					ssh.DomChat = "#SYS_ReturnAnswer"
					TypingDelay()
					Return
				End If
			End If
		End If

		If ssh.CBTCockFlag = True Then
			CBTCock()
		End If

		If ssh.CBTBallsFlag = True Then
			CBTBalls()
		End If

		If ssh.CBTBothFlag = True Then
			CBTBoth()
		End If

		If ssh.CustomTask = True Then
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
			ssh.TempScriptCount = 0
			If FrmSettings.SliderSTF.Value = 1 Then ssh.StrokeTauntTick = ssh.randomizer.Next(120, 241)
			If FrmSettings.SliderSTF.Value = 2 Then ssh.StrokeTauntTick = ssh.randomizer.Next(75, 121)
			If FrmSettings.SliderSTF.Value = 3 Then ssh.StrokeTauntTick = ssh.randomizer.Next(45, 76)
			If FrmSettings.SliderSTF.Value = 4 Then ssh.StrokeTauntTick = ssh.randomizer.Next(25, 46)
			If FrmSettings.SliderSTF.Value = 5 Then ssh.StrokeTauntTick = ssh.randomizer.Next(15, 26)
		End If

		ssh.DomChat = ResponseClean(ssh.DomChat)

		If ssh.DomChat = "NULL" Then
			ssh.DomChat = ""
			Return
		End If

		'Debug.Print("DoNotDisturb = " & DoNotDisturb)
		'Debug.Print("DomChat = " & DomChat)

		If ssh.DoNotDisturb = True Then
			If ssh.DomChat.Contains("@Interrupt") Or ssh.DomChat.Contains("@Call(") Or ssh.DomChat.Contains("@CallRandom(") Then
				ssh.DomChat = "#SYS_InterruptsOff"
			End If
		End If




		TypingDelay()


	End Sub

	Public Function ResponseClean(ByVal CleanResponse As String) As String
		ResponseClean = "NULL"

		Dim FilteredLines As New List(Of String)
		Dim Section As String


		Dim AddResponse As Boolean = False

		If My.Settings.Chastity = True Then
			If ssh.CBTCockFlag Then
				Section = "CBT Cock"
			ElseIf ssh.CBTBallsFlag = True Or ssh.CBTBothFlag = True Then
				Section = "CBT Balls"
			Else
				Section = "Chastity"
			End If
		ElseIf ssh.BeforeTease = True Then
			Section = "Before Tease"
		ElseIf ssh.FirstRound = True Then
			Section = "First Round"
		ElseIf ssh.EndTease = True Then
			Section = "After Tease"
		ElseIf ssh.CBTCockFlag = True Then
			Section = "CBT Cock"
		ElseIf ssh.CBTBallsFlag = True Or ssh.CBTBothFlag = True Then
			Section = "CBT Balls"
		ElseIf ssh.SubHoldingEdge = True Then
			Section = "Holding The Edge"
		ElseIf ssh.SubEdging = True Then
			Section = "Edging"
		ElseIf ssh.SubStroking = True Then
			Section = "Stroking"
		Else
			Section = "Not Stroking"
		End If

		Dim RespLines As List(Of String) = Txt2List(ssh.ResponseFile)

		For Each line As String In RespLines
			If Trim(line).ToUpper = String.Format("[{0}]", Section).ToUpper Then
				AddResponse = True
			ElseIf Trim(line).ToUpper = String.Format("[{0} End]", Section).ToUpper Then
				AddResponse = False
			ElseIf AddResponse = True
				FilteredLines.Add(line)
			End If
		Next

		AddResponse = False

		If Section <> "After Tease" And Section <> "Before Tease" Then
			For Each line As String In RespLines
				If Trim(line).ToUpper = "[All]".ToUpper Then
					AddResponse = True
				ElseIf Trim(line).ToUpper = "[All End]".ToUpper Then
					AddResponse = False
				ElseIf AddResponse = True
					FilteredLines.Add(line)
				End If
			Next
		End If


		If FilteredLines.Count < 1 Then
			Exit Function
		End If

		Try
			FilteredLines = FilterList(FilteredLines)
			ssh.ResponseLine = ssh.randomizer.Next(0, FilteredLines.Count)
			ResponseClean = FilteredLines(ssh.ResponseLine)
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid Response line from file: " &
				  ssh.ResponseFile, ex, "ReponseClean(String)")
			ResponseClean = "ERROR: Tease AI did not return a valid Response line from file: " & ssh.ResponseFile
		End Try

		ssh.Responding = True
	End Function



	Public Function CountWords(ByVal value As String) As Integer

		' Count matches.
		Dim collection As MatchCollection = Regex.Matches(value, "\S+")
		Return collection.Count

	End Function




	Public Sub YesOrNoQuestions()
		Dim TempChatString As String
		TempChatString = UCase(ssh.ChatString)

		If ssh.CBT = True Then
			If InStr(UCase(TempChatString), UCase("done")) <> 0 Or InStr(UCase(TempChatString), UCase("finish")) <> 0 Then
				ssh.YesOrNo = False
				ssh.CBT = False
				Return
			Else
				ssh.DomChat = "Hurry up and tell me when you're done"
				TypingDelay()
				Return
			End If
		End If

		Dim dir As String

		dir = ssh.FileText

		' Read all lines of File
		Dim lines As List(Of String) = Txt2List(dir)
		Dim line As Integer

		line = ssh.StrokeTauntVal

		ssh.tempResponseLine = -1
		ssh.checkAnswers.clearAnswers()
		Do
			line += 1
			Debug.Print("YESNO Line = " & lines(line))
			Dim getWords As String = GetParentheses(lines(line), "[")
			ssh.addAnswerList = True
			getWords = PoundClean(getWords)
			ssh.addAnswerList = False
			ssh.checkAnswers.addToAnswerList(getWords)
		Loop Until InStr(UCase(lines(line + 1)), UCase("@AcceptAnswer")) <> 0 Or InStr(UCase(lines(line + 1)), UCase("@DifferentAnswer")) <> 0
		ssh.tempResponseLine = line + 1
		line = ssh.StrokeTauntVal

		Dim CheckLines As String
		Dim ChatReplace As String

		'we get the trigger word that is present in the chat (if there is a word that matches one of the answers)
		Dim triggerWord As String = ssh.checkAnswers.triggerWord(ssh.ChatString)

		'we check to see what answer to trigger only if there was a trigger word, otherwise we move directly to the noanswer found part
		If triggerWord <> "" Then

			Do
				line += 1
				CheckLines = lines(line)
				Dim checkResult As Integer = -1

				Dim Splits As String() = CheckLines.Split(New Char() {"]"c})
				Splits(0) = Splits(0).Replace("[", "")
				ChatReplace = CheckLines.Replace("[" & Splits(0) & "]", "")
				ssh.addResponseList = True
				Splits(0) = PoundClean(Splits(0))
				ssh.addResponseList = False

				'we check to see if what the user wrote contains one of the keywords for the different yes/no/etc responses
				'this is useful if the script contains something like [yes,maybe] as an answer option
				'if the user write maybe then it will not need to use the honorific but if he writes yes, instead, it will check the honorific
				If LCase(Splits(0)).Contains(LCase(triggerWord)) Then
					Dim checkFor As String = ssh.checkAnswers.returnSystemWord(triggerWord)
					If checkFor = "" Then
						checkResult = checkSubAnswer(Splits(0))
					Else
						checkResult = checkSubAnswer(checkFor)
					End If
				End If

				If checkResult = 1 Then
					GoTo FoundAnswer
				ElseIf checkResult = 0 Then
					checkForPunish()
					Return
				End If

			Loop Until InStr(UCase(lines(line + 1)), UCase("@DifferentAnswer")) <> 0 Or InStr(UCase(lines(line + 1)), UCase("@AcceptAnswer")) <> 0

		End If

		GoTo NothingFound

FoundAnswer:
		'	updateDommeName(ChatReplace)
		ssh.DomChat = ChatReplace
		'we clear the answer list 
		If ssh.DomChat.Contains("@NullResponse") Then ssh.NullResponse = True
		If ssh.DomChat.Contains("@LoopAnswer") Then GoTo LoopAnswer

		ssh.YesOrNo = False
		YesOrNoLanguageCheck()


		If ssh.GotoFlag = False Then ssh.StrokeTauntVal = ssh.tempResponseLine

		TypingDelay()

		Return


NothingFound:
		If checkSubAnswer() = 0 Then
			checkForPunish()
			Return
		End If
		If InStr(UCase(lines(ssh.tempResponseLine)), UCase("DifferentAnswer")) <> 0 Then

DifferentAnswer:
			ssh.DomChat = lines(ssh.tempResponseLine)
			ssh.DomChat = ssh.DomChat.Replace("@DifferentAnswer ", "")

LoopAnswer:
			ssh.DomChat = ssh.DomChat.Replace("@LoopAnswer", "")
			' CleanParse()
			TypingDelay()
			Return
		End If


		If InStr(UCase(lines(ssh.tempResponseLine)), UCase("AcceptAnswer")) <> 0 Then

AcceptAnswer:
			'ssh.DomChat = lines(line)
			ssh.DomChat = lines(ssh.tempResponseLine)
			' TimedAnswerTimer.Stop()

			ssh.DomChat = ssh.DomChat.Replace("@AcceptAnswer ", "")
			ScriptTimer.Start()
			ssh.YesOrNo = False

			YesOrNoLanguageCheck()

			If ssh.GotoFlag = False Then ssh.StrokeTauntVal = ssh.tempResponseLine
			TypingDelay()
			Return
		End If



	End Sub

	Public Sub YesOrNoLanguageCheck()


		If InStr(UCase(ssh.DomChat), UCase("@Goto(")) <> 0 Then
			GetGotoChat()
		End If

	End Sub

	Public Sub GetGotoChat()

		ssh.GotoFlag = True

		If InStr(UCase(ssh.DomChat), UCase("@Goto")) <> 0 Then

			ssh.DomTypeCheck = True

			Dim TempGoto As String = ssh.DomChat & " some garbage"
			Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
			TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
			TempGoto = TempGoto.Split(")")(0)
			ssh.FileGoto = TempGoto

			Dim StripGoto As String = ssh.FileGoto

			If TempGoto.Contains(",") Then
				TempGoto = TempGoto.Replace(", ", ",")
				Dim GotoSplit As String() = TempGoto.Split(",")
				Dim GotoTemp As Integer = ssh.randomizer.Next(0, GotoSplit.Count)
				ssh.FileGoto = GotoSplit(GotoTemp)
			End If

			Dim GotoText As String

			GotoText = ssh.FileText

			If File.Exists(GotoText) Then
				' Read all lines of File
				Dim gotolines As List(Of String) = Txt2List(GotoText)
				Dim gotoline As Integer = -1

				If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
				If ssh.FileGoto.Substring(0, 1) <> "(" Then ssh.FileGoto = "(" & ssh.FileGoto & ")"

				ssh.DomChat = ssh.DomChat.Replace("@Goto" & StripGoto, "")
				Try
					Do
						gotoline += 1

					Loop Until gotolines(gotoline).StartsWith(ssh.FileGoto)
				Catch ex As ArgumentOutOfRangeException
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                                 ArgumentOutOfRangeException - Regular Script
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Throw New ArgumentOutOfRangeException("The Goto-Destination """ & ssh.FileGoto &
							   """ in file """ & GotoText & """ was not found.", ex)
				End Try

				ssh.StrokeTauntVal = gotoline

			Else
				Throw New FileNotFoundException("The Goto-File """ & GotoText & """ was not found.")
			End If

		End If

	End Sub


	Public Sub ScriptTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptTimer.Tick

		FrmSettings.LBLDebugScriptTime.Text = ssh.ScriptTick
		'Debug.Print("ScriptTick = " & ScriptTick)

		If ssh.DomTyping = True Then Return
		If ssh.YesOrNo = True Then Return

		'If ChatText.IsBusy Then Return

		If WaitTimer.Enabled = True Or ssh.DomTypeCheck = True Then Return

		'Debug.Print("ScriptTimer Substroking = " & SubStroking)
		'Debug.Print("ScriptTimer StrokePaceTimer = " & StrokePaceTimer.Enabled)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If playingStatus() = True Then
			If ssh.ScriptTick < 4 Then Return
		End If


		If ssh.DomTypeCheck = True And ssh.ScriptTick < 4 Then Return
		If chatBox.Text <> "" And ssh.ScriptTick < 4 Then Return
		If ChatBox2.Text <> "" And ssh.ScriptTick < 4 Then Return


		ssh.ScriptTick -= 1
		' Debug.Print("ScriptTick = " & ScriptTick)
		If ssh.ScriptTick < 1 Then



			ssh.ScriptTick = ssh.randomizer.Next(4, 7)

			RunFileText()


		End If




	End Sub

	Public Sub CBTBalls()
		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If ssh.CBTBallsFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			ssh.CBTBallsCount += 1
		End If

		' Read all Lines of the given File.
		Dim BallList As List(Of String) = Txt2List(File2Read)

		Try
			BallList = FilterList(BallList)
			ssh.DomTask = BallList(ssh.randomizer.Next(0, BallList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBTBalls line from file: " &
				  File2Read, ex, "CBTBalls()")
			ssh.DomTask = "ERROR: Tease AI did not return a valid @CBTBalls line from file: " & File2Read
		End Try

		ssh.CBTBallsFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTCock()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If ssh.CBTCockFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			ssh.CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim CockList As List(Of String) = Txt2List(File2Read)

		Try
			CockList = FilterList(CockList)
			ssh.DomTask = CockList(ssh.randomizer.Next(0, CockList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBTCock line from file: " &
				  File2Read, ex, "CBTCock()")
			ssh.DomTask = "ERROR: Tease AI did not return a valid @CBTCock line from file: " & File2Read
		End Try

		ssh.CBTCockFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTBoth()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If ssh.CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			ssh.CBTBallsCount += 1
			ssh.CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim BothList As List(Of String) = Txt2List(File2Read)

		File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If ssh.CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			ssh.CBTBallsCount += 1
			ssh.CBTCockCount += 1
		End If

		' Read all Lines of the given file and append to List.
		BothList.AddRange(Txt2List(File2Read))

		Try
			BothList = FilterList(BothList)
			ssh.DomTask = BothList(ssh.randomizer.Next(0, BothList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBT line from file: " &
				  File2Read, ex, "CBTBoth()")
			ssh.DomTask = "ERROR: Tease AI did not return a valid @CBT line from file: " & File2Read
		End Try

		ssh.CBTBothFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub RunCustomTask()

		Dim File2Read As String = ssh.CustomTaskTextFirst

		If ssh.CustomTaskFirst = False Then
			File2Read = ssh.CustomTaskText
		End If

		' Read all Lines of the given File.
		Dim CustomList As List(Of String) = Txt2List(File2Read)

		Try
			CustomList = FilterList(CustomList)
			ssh.DomTask = CustomList(ssh.randomizer.Next(0, CustomList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid Custom Task line from file: " & File2Read, ex, "RunCustomTask()")
			ssh.DomTask = "ERROR: Tease AI did not return a valid Custom Task line from file: " & File2Read
		End Try

		ssh.CustomTaskFirst = False

		TypingDelayGeneric()

	End Sub


	Public Sub RunFileText()

		Debug.Print("SaidHello = " & ssh.SaidHello)
		If ssh.SaidHello = False Then Return

		'Debug.Print("CBTCockFlag = " & CBTCockFlag)
		'Debug.Print("CBTBallsFlag = " & CBTBallsFlag)
		If ssh.CBTCockFlag = True Or ssh.CBTBallsFlag = True Or ssh.CBTBothFlag = True Or ssh.CustomTask = True Then Return

		'Debug.Print("WritingTaskFlag = " & WritingTaskFlag)
		If ssh.WritingTaskFlag = True Then Return

		'Debug.Print("TeaseVideo = " & TeaseVideo)
		If ssh.TeaseVideo = True Then Return



		If ssh.RiskyDelay = True Then Return

		If ssh.InputFlag = True Then Return

		If ssh.CensorshipGame = True Or ssh.RLGLGame = True Or ssh.AvoidTheEdgeStroking = True Or ssh.SubEdging = True Or ssh.SubHoldingEdge = True Then Return

		If ssh.MultipleEdges = True Then Return

		'Debug.Print("RunFileText " & StrokeTauntVal)

		Dim lines As New List(Of String)

		ssh.StrokeTauntVal += 1
		lines = Txt2List(ssh.FileText)
		Try
			If ssh.StrokeTauntVal < lines.Count - 1 Then
				If lines(ssh.StrokeTauntVal).Substring(0, 1) = "(" Then
					Do
						ssh.StrokeTauntVal += 1
					Loop Until lines(ssh.StrokeTauntVal).Substring(0, 1) <> "("
				End If
			End If
		Catch
		End Try

		Try
			If ssh.RunningScript = False And ssh.AvoidTheEdgeGame = False And ssh.CallReturns.Count() = 0 Then
				Debug.Print("End Check StrokeTauntVal = " & ssh.StrokeTauntVal)

				'end the scripts anyway if it reaches the last line, even if the user forgot to use the @End command
				If ssh.StrokeTauntVal >= lines.Count Or lines(ssh.StrokeTauntVal) = "@End" Then
					If ssh.ShowModule = True Then ssh.ModuleEnd = True
					'if we reached the end of the script and we are in a link or in the beforeTease, and we forget to use the @StartStroking/Taunt
					'it will automatically do it to avoid session errors
					If (ssh.isLink Or ssh.BeforeTease) And ssh.SubStroking = False Then
						ssh.isLink = False
						If My.Settings.Chastity Then
							ssh.DomChat = "@NullResponse @StartTaunts"
						Else
							ssh.DomChat = "@NullResponse @StartStroking"
						End If
						TypingDelay()
					End If
				End If
			End If
		Catch
		End Try

		HandleScripts()
	End Sub

	Public Sub HandleScripts()

		Debug.Print("Handlescripts Called")

ModuleEnd:

		If ssh.ModuleEnd = True And ssh.AvoidTheEdgeGame = False Then
			Debug.Print("Module End Called?")
			ScriptTimer.Stop()
			ssh.ModuleEnd = False
			ssh.ShowModule = False

			'DelayFlag = True
			'DelayTick = randomizer.Next(3, 6)

			'DelayTimer.Start()

			'Do
			'Application.DoEvents()
			'Loop Until DelayFlag = False

			'LastScriptCountdown -= 1
			'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

			If ssh.Playlist = True Then
				Debug.Print("Playlist True - StrokeTimer")
				If ssh.PlaylistCurrent = ssh.PlaylistFile.Count - 1 Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			Else
				If ssh.TeaseTick < 1 And ssh.BookmarkModule = False Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			End If
			Return
		End If

		If StrokeTimer.Enabled = True Then Return

		'If ShowThought = False And ShowEdgeThought = False And ShowModule = False Then HandleScriptText = FileText
		'If ShowThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\Thoughts.txt")
		'If ShowEdgeThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\EdgeThoughts.txt")
		'If ShowModule = True Then HandleScriptText = ModText

		Debug.Print("CHeck")

		Debug.Print(ssh.FileText)

		Dim CheckText As String


		CheckText = ssh.FileText

		'If File.Exists(HandleScriptText) Then
		If File.Exists(CheckText) Then
			'Debug.Print(StrokeTauntVal)
			'Dim ioFile As New StreamReader(HandleScriptText)
			Dim lines As List(Of String) = Txt2List(CheckText)
			Dim line As Integer


			line = ssh.StrokeTauntVal

			If line = lines.Count Then
				If ssh.ShowModule = True Then
					ssh.ModuleEnd = True
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

			If lines(line) = "@End" Or ssh.StrokeTauntVal > lines.Count Then

NonModuleEnd:
				If ssh.CallReturns.Count() > 0 Then
					handleCallReturn()
					If ssh.ShowModule Then Return
				End If

				If ssh.RiskyEdges = True Then ssh.RiskyEdges = False
				If ssh.LastScript = True Then
					ssh.LastScript = False
					SaveChatLog(False)
					ssh.Reset()
					FrmSettings.LockOrgasmChances(False)
					mainPictureBox.Image = Nothing
					Exit Sub
				End If
				If ssh.HypnoGen = True Then
					If ssh.Induction = True Then
						ssh.Induction = False
						ssh.StrokeTauntVal = -1
						ssh.FileText = ssh.TempHypno
						ssh.ScriptTick = 1
						ScriptTimer.Start()
						Return
					End If
					ssh.HypnoGen = False
					ssh.AFK = False
					DomWMP.Ctlcontrols.stop()
					BTNHypnoGenStart.Text = "Guide Me!"
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
					ssh.YesOrNo = True
					ScriptTimer.Stop()
				End If
			End If

			Debug.Print("CHeck")


			ssh.DomTask = (lines(line).Trim)


			ssh.StringLength = 1



			ssh.DomTask = ssh.DomTask.Replace("#SubName", subName.Text)

			ssh.DomTask = ssh.DomTask.Replace("#VTLength", ssh.VTLength / 60)


			If InStr(ssh.DomTask, "@CockSizeSmall") <> 0 Then ssh.DivideText = True

			'QUESTION: What is this Code doing here? Shouldn't it be in CommandClean?
			If ssh.DomTask.Contains("@SearchImageBlogAgain") Then

				ShowImage(GetRandomImage(ImageGenre.Blog), False)

			End If


			If ssh.DomTask.Contains("@SearchImageBlog") And Not ssh.DomTask.Contains("@SearchImageBlogAgain") Then

				ShowImage(GetRandomImage(ImageGenre.Blog), False)

			End If


			'If InStr(UCase(DomTask), UCase("@Goto")) <> 0 And InStr(UCase(DomTask), UCase("@GotoDommeLevel")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeOrgasm")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeRuin")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeApathy")) = 0 And InStr(UCase(DomTask), UCase("@GotoSlideshow")) = 0 Then
			If ssh.DomTask.Contains("@Goto(") Then
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

			Debug.Print("TempVal = " & ssh.TempVal)
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

			If ssh.DomTask.Contains("@ShowTaggedImage") Then ssh.JustShowedBlogImage = True

			If ssh.DomTask.Contains("@NullResponse") Then ssh.NullResponse = True

			If ssh.HypnoGen = True Then

				If CBHypnoGenSlideshow.Checked = True Then

					If LBHypnoGenSlideshow.SelectedItem = "Boobs" Then ssh.DomTask = ssh.DomTask & " @ShowBoobsImage"
					If LBHypnoGenSlideshow.SelectedItem = "Butts" Then ssh.DomTask = ssh.DomTask & " @ShowButtImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hardcore" Then ssh.DomTask = ssh.DomTask & " @ShowHardcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Softcore" Then ssh.DomTask = ssh.DomTask & " @ShowSoftcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lesbian" Then ssh.DomTask = ssh.DomTask & " @ShowLesbianImage"
					If LBHypnoGenSlideshow.SelectedItem = "Blowjob" Then ssh.DomTask = ssh.DomTask & " @ShowBlowjobImage"
					If LBHypnoGenSlideshow.SelectedItem = "Femdom" Then ssh.DomTask = ssh.DomTask & " @ShowFemdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lezdom" Then ssh.DomTask = ssh.DomTask & " @ShowLezdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hentai" Then ssh.DomTask = ssh.DomTask & " @ShowHentaiImage"
					If LBHypnoGenSlideshow.SelectedItem = "Gay" Then ssh.DomTask = ssh.DomTask & " @ShowGayImage"
					If LBHypnoGenSlideshow.SelectedItem = "Maledom" Then ssh.DomTask = ssh.DomTask & " @ShowMaledomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Captions" Then ssh.DomTask = ssh.DomTask & " @ShowCaptionsImage"
					If LBHypnoGenSlideshow.SelectedItem = "General" Then ssh.DomTask = ssh.DomTask & " @ShowGeneralImage"
					If LBHypnoGenSlideshow.SelectedItem = "Tagged" Then ssh.DomTask = ssh.DomTask & " @ShowTaggedImage @Tag" & TBHypnoGenImageTag.Text



				End If

			End If


			If ssh.DomTask <> "" Then
				TypingDelayGeneric()
			Else
				RunFileText()
			End If


		End If

	End Sub

	Public Sub GetGoto()

		Dim ReplaceGoto As String = ""
		Dim ReplaceX As Integer = 0

		ssh.GotoFlag = True

		Dim StripGoto As String

		If ssh.GotoDommeLevel = True Or ssh.SkipGotoLine = True Then
			StripGoto = ssh.FileGoto
			GoTo SkipGotoSearch
		End If

		Dim TempGoto As String = ssh.DomTask & " some garbage"
		Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
		TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
		TempGoto = TempGoto.Split(")")(0)
		ssh.FileGoto = TempGoto

		StripGoto = ssh.FileGoto

		If TempGoto.Contains(",") Then
			TempGoto = TempGoto.Replace(", ", ",")
			Dim GotoSplit As String() = TempGoto.Split(",")
			Dim GotoTemp As Integer = ssh.randomizer.Next(0, GotoSplit.Count)
			ssh.FileGoto = GotoSplit(GotoTemp)
		End If



SkipGotoSearch:
		Dim GotoText As String

		GotoText = ssh.FileText
		Dim gotolines As List(Of String) = Txt2List(GotoText)
		Dim CountGotoLines As Integer = gotolines.Count

ResumeGotoSearch:
		Try
			'TODO: Add Errorhandling.
			If File.Exists(GotoText) Then
				' Read all lines of the given file.
				If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
				If ssh.FileGoto.Substring(0, 1) <> "(" Then ssh.FileGoto = "(" & ssh.FileGoto & ")"

				ssh.DomTask = ssh.DomTask.Replace("@Goto" & StripGoto, "")

				Dim gotoline As Integer = -1

				Do
					gotoline += 1
					If ssh.GotoDommeLevel = True And gotoline = CountGotoLines Then
						ssh.FileGoto = "(DommeLevel)"
						GoTo SkipGotoSearch
					End If
				Loop Until gotolines(gotoline).StartsWith(ssh.FileGoto)

				ssh.StrokeTauntVal = gotoline
			End If

		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError("Exception occured finding GotoLabel """ & ssh.FileGoto & """ in file """ & GotoText & """", ex, "Exception occured in GetGoto()")

			'      Dim GotoLikeList As New List(Of String)
			'			GotoLikeList = Txt2List(GotoText)

			' BreakPoint 
			Do

				For i As Integer = 0 To gotolines.Count - 1
					If gotolines(i).Substring(0, 1) = "(" Then
						Dim t As Integer = GetLikeValue(gotolines(i), ssh.FileGoto)
						If GetLikeValue(gotolines(i), ssh.FileGoto) = ReplaceX Then
							ReplaceX = 1885
							ReplaceGoto = gotolines(i)
							Exit For
						End If
					End If
				Next

				ReplaceX += 1
				Application.DoEvents()

			Loop Until ReplaceX > 5

			'If My.Settings.CBOutputErrors = True And ssh.SaidHello = True Then ChatAddSystemMessage("<font color=""red"">ERROR: " & ex.Message & "::: Exception occured finding GotoLabel """ & ssh.FileGoto & """ in file """ & GotoText & """</font>", False)
			'Throw
		End Try

		If ReplaceGoto <> "" Then
			ReplaceX = 0
			ssh.FileGoto = ReplaceGoto
			ReplaceGoto = ""
			GoTo ResumeGotoSearch
		End If

CancelGoto:

		ssh.GotoDommeLevel = False
		ssh.SkipGotoLine = False

		If ReplaceX <> 0 Then
			If ssh.CallReturns.Count() > 0 Then
				ChatAddWarning("Error: @Goto() could not find a valid Goto Label. Sending you to the previous callreturn, to avoid blocking the session")
				handleCallReturn()
				If ssh.ShowModule Then Return
			Else
				StopEverything()
				ssh.CallReturns.Clear()
				ChatAddWarning("Error: @Goto() could not find a valid Goto Label. Sending you to a link, to avoid blocking the session")
				If ssh.LastScript = False Then
					If ssh.BeforeTease = True Then
						ssh.BeforeTease = False
						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
						Else
							ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
					End If
					RunLinkScript()
				Else
					ChatAddWarning("Error: @Goto() could not find a valid Goto Label. Since this is the final cycle, the session will now end.")
					SetVariable("SYS_SubLeftEarly", 0)
					SaveChatLog(False)
					ssh.Reset()
					FrmSettings.LockOrgasmChances(False)
				End If
			End If
		End If

	End Sub

	Public Sub TypingDelay()

		'Debug.Print("Typing Delay Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			ssh.DomChat = OfflineConversion(ssh.DomChat)
		End If
		ssh.TypeDelay = ssh.StringLength
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh.RapidCode = True = True Then ssh.TypeDelay = 0
		If ssh.TypeDelay <> 0 Then
			If GetCharCount(ssh.DomChat, "@RT(") <> 0 Then
				ssh.TypeDelay /= GetCharCount(ssh.DomChat, ",") + 1
				ssh.TypeDelay *= GetSubstringCount(ssh.DomChat, "@RT(")
			End If
			If GetCharCount(ssh.DomChat, "@RandomText(") <> 0 Then
				ssh.TypeDelay /= GetCharCount(ssh.DomChat, ",") + 1
				ssh.TypeDelay *= GetSubstringCount(ssh.DomChat, "@RandomText(")
			End If
		End If
		If ssh.TypeDelay > 60 Then ssh.TypeDelay = 60
		SendTimer.Start()


	End Sub

	Public Sub TypingDelayGeneric()
		'Debug.Print("Typing Delay Generic Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			ssh.DomTask = OfflineConversion(ssh.DomTask)
		End If
		ssh.TypeDelay = ssh.StringLength
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh.RapidCode = True = True Then ssh.TypeDelay = 0
		If ssh.HypnoGen = True And CBHypnoGenNoText.Checked = True Then ssh.TypeDelay = 0
		If ssh.TypeDelay <> 0 Then
			If GetCharCount(ssh.DomTask, "@RT(") <> 0 Then
				ssh.TypeDelay /= GetCharCount(ssh.DomTask, ",") + 1
				ssh.TypeDelay *= GetSubstringCount(ssh.DomTask, "@RT(")
			End If
			If GetCharCount(ssh.DomTask, "@RandomText(") <> 0 Then
				ssh.TypeDelay /= GetCharCount(ssh.DomTask, ",") + 1
				ssh.TypeDelay *= GetSubstringCount(ssh.DomTask, "@RandomText(")
			End If
		End If
		If ssh.TypeDelay > 60 Then ssh.TypeDelay = 60
		Timer1.Start()

	End Sub

	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh.DomTyping = True
		Dim ShowPicture As Boolean = False


		' Let the program know that the domme is currently typing
		ssh.DomTypeCheck = True




		If CBHypnoGenNoText.Checked = True And ssh.HypnoGen = True Then ssh.NullResponse = True
		If ssh.DomTask.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()

		'Debug.Print("Nullresponse = " & NullResponse)
		If ssh.DomTask.Contains("@NullResponse") Then
			ssh.NullResponse = True
		Else
			ssh.RapidCode = False
		End If

		If ssh.NullResponse = True Then
			Timer1.Stop()
			GoTo NullResponse
		End If

		'Debug.Print("CBHypnoGenNoText.Enabled = " & CBHypnoGenNoText.Enabled)
		'Debug.Print("HypnoGen = " & HypnoGen)

		' Debug.Print("TypeToggle = " & TypeToggle)
		'Debug.Print("TypeDelay = " & TypeDelay)


		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If ssh.TypeToggle = 0 Then
			'Debug.Print("TypeDelay = " & TypeDelay)
			If ssh.TypeDelay > 0 Then
				ssh.TypeDelay -= 1
			Else
				Timer1.Stop()
				'Debug.Print("NullCommand DomTask = " & DomTask)
				If ssh.RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				updateDommeName(ssh.DomTask)
				If ssh.NullResponse = False Then
					ssh.IsTyping = True

					If ssh.DomTask.Contains("@EmoteMessage") Then ssh.EmoMes = True

					If ssh.DomTask.Contains("@SystemMessage") Then
						ssh.SysMes = True
						ssh.TypeDelay = 0
						GoTo SkipIsTyping
					End If

					' ###### display "is typing..." message.
					ChatUpdate()


SkipIsTyping:

				End If




				ssh.TypeToggle = 1
				ssh.StringLength = ssh.DomTask.Length
				If ssh.DivideText = True Then
					ssh.StringLength /= 3
					ssh.DivideText = False
				End If
				If ssh.RLGLGame = True Then ssh.StringLength = 0
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh.RapidCode = True Then ssh.StringLength = 0
				If ssh.HypnoGen = True And CBHypnoGenNoText.Checked = True Then ssh.StringLength = 0
				TypingDelayGeneric()
			End If

		Else

			If ssh.TypeDelay > 0 Then
				ssh.TypeDelay -= 1
				If ssh.DomTask.Contains("@SystemMessage") Then ssh.TypeDelay = 0

			Else
				ssh.TypeToggle = 0
				Timer1.Stop()
				ssh.IsTyping = False
				If ssh.RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

				ssh.ResponseYes = ""
				ssh.ResponseNo = ""

				' If PreCleanString.Contains("#") Then GoTo PoundLoop

				' DomTask = PreCleanString

				'################## Display a Slideimage? #################
				'TODO: Optimize Code. Since images loaded by the Backgroundworker are prioritized, this section can be shrinked down.
				If ssh.DomTask.Contains("@ImageTag") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ImageTagOr") Then ssh.JustShowedBlogImage = True

				If ssh.DomTask.Contains("@ShowHardcoreImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowSoftcoreImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowLesbianImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowBlowjobImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowFemdomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowLezdomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowHentaiImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowGayImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowMaledomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowCaptionsImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowGeneralImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowLocalImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@ShowBlogImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomTask.Contains("@NewBlogImage") Then ssh.JustShowedBlogImage = True

				If ssh.DomTask.Contains("@SlideshowFirst") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomTask.Contains("@SlideshowNext") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomTask.Contains("@SlideshowPrevious") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomTask.Contains("@SlideshowLast") Then ssh.JustShowedSlideshowImage = True


				If ssh.GlitterTease = True And ssh.JustShowedBlogImage = False And ssh.LockImage = False Then GoTo TryNextWithTease


				If FrmSettings.teaseRadio.Checked = True And ssh.JustShowedBlogImage = False And ssh.TeaseVideo = False And Not ssh.DomTask.Contains("@NewBlogImage") And ssh.NullResponse = False _
				  And ssh.SlideshowLoaded = True And Not ssh.DomTask.Contains("@ShowButtImage") And Not ssh.DomTask.Contains("@ShowBoobsImage") And Not ssh.DomTask.Contains("@ShowButtsImage") _
				  And Not ssh.DomTask.Contains("@ShowBoobsImage") And ssh.LockImage = False And ssh.CustomSlideEnabled = False And ssh.RapidFire = False _
				  And UCase(ssh.DomTask) <> "@SystemMessage Tease AI has been reset" And ssh.JustShowedSlideshowImage = False And ssh.MultiTauntPictureHold = False Then
					' Begin Next Button
					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:




					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					ShowPicture = True

				End If



NullResponse:


				If ssh.DomTask.Contains("@WritingTask(") Then
					ssh.currentWriteTask = GetParentheses(ssh.DomTask, "@WritingTask(")
					ssh.DomTask = ssh.DomTask.Replace(ssh.currentWriteTask, PoundClean(ssh.currentWriteTask))
				End If

				If ssh.DomTask.Contains("@WritingTaskRandom(") Then
					ssh.currentWriteTask = GetParentheses(ssh.DomTask, "@WritingTaskRandom(")
					ssh.DomTask = ssh.DomTask.Replace(ssh.currentWriteTask, PoundClean(ssh.currentWriteTask))
				End If

				If ssh.DomTask.Contains("@Contact1") Or ssh.DomTask.Contains("@Contact2") Or ssh.DomTask.Contains("@Contact3") Or ssh.DomTask.Contains("@RandomContact") Then ssh.SubWroteLast = True

				'################### Gather Response Data #################
				'TODO-Next: Test Code
				'ssh.contactToUse = ssh.SlideshowMain

				'If ssh.DomTask.Contains("@Contact1") Then _
				'ssh.contactToUse = ssh.SlideshowContact1

				'If ssh.DomTask.Contains("@Contact2") Then _
				'ssh.contactToUse = ssh.SlideshowContact2

				'If ssh.DomTask.Contains("@Contact3") Then _
				'ssh.contactToUse = ssh.SlideshowContact3

				'Dim TypeName As String = ssh.contactToUse.TypeName
				'Dim TypeColor As String = ssh.contactToUse.TypeColorHtml
				'Dim TypeFont As String = ssh.contactToUse.TypeFont
				'Dim TypeSize As String = ssh.contactToUse.TypeSize

				Dim TTSVoice As String = FrmSettings.TTSComboBox.Text
				'Dim TTSrate As Integer = ssh.contactToUse.TTSrate
				'Dim TTSvolume As String = ssh.contactToUse.TTSvolume

				' Set LineSpeaker for typo corrections.
				Dim LineSpeaker As String = ""

				If ssh.dommePresent Then
					If ssh.contactToUse.Equals(ssh.SlideshowContact1) Then
						LineSpeaker = "@Contact1 "
					ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact2) Then
						LineSpeaker = "@Contact2 "
					ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact3) Then
						LineSpeaker = "@Contact3 "
					End If
				End If


				If FrmSettings.TTSCheckBox.Checked = True And TTSVoice <> "No voices installed" Then
					Dim EmoteArray() As String = Split(ssh.DomTask)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					ssh.DomTask = Join(EmoteArray)
				End If

				'SaveBlogImage.Text = ""

				'If RiskyDeal = True Then Me.Focus()

				Dim LoopBuffer As Integer = 0


#If TRACE Then
				Dim sw As New Stopwatch
				sw.Start()

				Trace.WriteLine("Timer1 Parse Line: " & ssh.DomTask)
				Trace.Indent()
#End If
				Do
					LoopBuffer += 1

					Debug.Print("############################### DomTask = " & ssh.DomTask)

					ssh.DomTask = ssh.DomTask.Replace("#Null", "")
					ssh.DomTask = PoundClean(ssh.DomTask)
					If ssh.DomTask.Contains("@EmoteMessage") Then ssh.EmoMes = True
					If ssh.DomTask.Contains("@SystemMessage") Then ssh.SysMes = True
					ssh.DomTask = CommandClean(ssh.DomTask)
					ssh.DomTask = StripCommands(ssh.DomTask)
					ssh.DomTask = ssh.DomTask.Replace("#Null", "")
					ssh.DomTask = PoundClean(ssh.DomTask)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not ssh.DomTask.Contains("#") And Not ssh.DomTask.Contains("@")
#If TRACE Then
				Trace.Unindent()
				Trace.WriteLine("Timer1 finished - Duration: " & sw.ElapsedMilliseconds & "ms")
#End If



				'Debug.Print("NullResponse = " & NullResponse)
				If CBHypnoGenNoText.Checked = True And ssh.HypnoGen = True Then GoTo HypNoResponse
				If ssh.NullResponse = True Then GoTo NoResponse

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


				If ssh.DomTask.Contains("(") And ssh.DomTask.Contains(")") Then
					Dim ParenReg As RegularExpressions.Regex
					ParenReg = New RegularExpressions.Regex("\(([^\)]*)\)")
					ssh.DomTask = ssh.DomTask.Replace(ParenReg.Match(ssh.DomTask).Value(), "")
				End If

				' Github Patch If SysMes = False And EmoMes = False Then
				If ssh.SysMes = False And ssh.EmoMes = False And Not ssh.DomTask = "" Then

					Try
						Dim UCASELine As String = UCase(ssh.DomTask.Substring(0, 1))
						ssh.DomTask = ssh.DomTask.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try


					If FrmSettings.LCaseCheckBox.Checked = True Then ssh.DomTask = LCase(ssh.DomTask)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(ssh.DomTask)
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
						ssh.DomTask = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then ssh.DomTask = ssh.DomTask.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then ssh.DomTask = ssh.DomTask.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then ssh.DomTask = ssh.DomTask.Replace(".", "")

					' Try
					'DomTask = DomTask.Replace("*", FrmSettings.domemoteComboBox.Text.Substring(0, 1))
					'Catch
					'End Try

					Dim EmoToggle As Boolean = True
					For i As Integer = ssh.DomTask.Length - 1 To 0 Step -1
						If ssh.DomTask.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								ssh.DomTask = ssh.DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								ssh.DomTask = ssh.DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					ssh.DomTask = ssh.DomTask.Replace(":d", ":D")
					ssh.DomTask = ssh.DomTask.Replace(": d", ": D")


					'Typo Test

					Try

						Dim RestoreDomTask As String = ssh.DomTask

						If Not ssh.DomTask.Substring(0, 1) = FrmSettings.TBEmote.Text.Substring(0, 1) And Not ssh.DomTask.Contains("<") And ssh.YesOrNo = False And ssh.TypoSwitch <> 0 And ssh.TyposDisabled = False _
						  And FrmSettings.TTSCheckBox.Checked = False Then

							Dim TypoChance As Integer = ssh.randomizer.Next(0, 101)

							If TypoChance < FrmSettings.NBTypoChance.Value Or ssh.TypoSwitch = 2 Then

								Try

									Dim TypoString As String

									Dim TypoSplit As String() = ssh.DomTask.Split(" ")

									ssh.TempVal = ssh.randomizer.Next(0, TypoSplit.Count)

									ssh.CorrectedWord = TypoSplit(ssh.TempVal)

									ssh.CorrectedWord = ssh.CorrectedWord.Replace(",", "")
									ssh.CorrectedWord = ssh.CorrectedWord.Replace(".", "")
									ssh.CorrectedWord = ssh.CorrectedWord.Replace("!", "")
									ssh.CorrectedWord = ssh.CorrectedWord.Replace("?", "")

									TypoString = "w d s f x"


									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "a" Then TypoString = "q w s z x"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "b" Then TypoString = "f v g h n"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "c" Then TypoString = "x d f v b"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "d" Then TypoString = "s c f x e"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "e" Then TypoString = "s r w 3 d"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "f" Then TypoString = "d r g v c"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "g" Then TypoString = "f t b h y"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "h" Then TypoString = "g b n u j"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "i" Then TypoString = "o u j k l"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "j" Then TypoString = "k u i n h"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "k" Then TypoString = "j m , l i"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "l" Then TypoString = "; p . , i"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "m" Then TypoString = "n j k , l"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "n" Then TypoString = "b h j k m"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "o" Then TypoString = "p 0 i k ;"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "p" Then TypoString = "[ - o ; l"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "q" Then TypoString = "1 w s a 2"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "r" Then TypoString = "4 5 t f d"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "s" Then TypoString = "w d a z x"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "t" Then TypoString = "5 6 g y r"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "u" Then TypoString = "y 7 j i k"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "v" Then TypoString = "c f g h b"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "w" Then TypoString = "2 a e q s"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "x" Then TypoString = "z s d f c"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "y" Then TypoString = "t 7 h u g"
									If LCase(TypoSplit(ssh.TempVal).Substring(0, 1)) = "z" Then TypoString = "a s x d c"


									Dim UpperChance As Integer = ssh.randomizer.Next(0, 101)
									If UpperChance < 26 Then TypoString = UCase(TypoString)



									Dim GetTypo As String() = TypoString.Split(" ")

									Dim MadeTypo As String = GetTypo(ssh.randomizer.Next(0, GetTypo.Count))


									Dim DoubleChance As Integer = ssh.randomizer.Next(0, 101)
									If DoubleChance < 11 Then MadeTypo = MadeTypo & LCase(GetTypo(ssh.randomizer.Next(0, GetTypo.Count)))


									TypoSplit(ssh.TempVal) = TypoSplit(ssh.TempVal).Remove(0, 1)

									Dim SpaceChance As Integer = ssh.randomizer.Next(0, 101)
									If SpaceChance < 7 Then
										TypoSplit(ssh.TempVal) = MadeTypo & " " & TypoSplit(ssh.TempVal)
									Else
										TypoSplit(ssh.TempVal) = MadeTypo & TypoSplit(ssh.TempVal)

									End If

									ssh.DomTask = Join(TypoSplit)

									ssh.CorrectedTypo = True

								Catch

									ssh.DomTask = RestoreDomTask
									ssh.CorrectedTypo = False
								End Try

							End If

						End If

						ssh.TypoSwitch = 1

					Catch
					End Try


				End If

				ssh.DomTask = ssh.DomTask.Replace("ATSYMBOL", "@")
				ssh.DomTask = ssh.DomTask.Replace("atsymbol", "@")

				If ssh.InputIcon = True Then
					' github patch DomTask = DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					ssh.DomTask = ssh.DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png"" title=""This icon means your Domme will remember your answer!""/>"
					ssh.InputIcon = False
				End If

				ssh.DomTask = ssh.DomTask.Replace(" a a", " an a")
				ssh.DomTask = ssh.DomTask.Replace(" a e", " an e")
				ssh.DomTask = ssh.DomTask.Replace(" a i", " an i")
				ssh.DomTask = ssh.DomTask.Replace(" a o", " an o")
				ssh.DomTask = ssh.DomTask.Replace(" a u", " an u")

				ssh.DomTask = ssh.DomTask.Replace(" an uni", " a uni")
				ssh.DomTask = ssh.DomTask.Replace(" an utensil", " a utensil")
				ssh.DomTask = ssh.DomTask.Replace(" an ukulele", " a ukulele")
				ssh.DomTask = ssh.DomTask.Replace(" an use", " a use")
				ssh.DomTask = ssh.DomTask.Replace(" an urethra", " a urethra")
				ssh.DomTask = ssh.DomTask.Replace(" an urine", " a urine")
				ssh.DomTask = ssh.DomTask.Replace(" an usual", " a usual")
				ssh.DomTask = ssh.DomTask.Replace(" an utility", " a utility")
				ssh.DomTask = ssh.DomTask.Replace(" an uterus", " a uterus")
				ssh.DomTask = ssh.DomTask.Replace(" an utopia", " a utopia")


				'SUGGESTION: (Stefaf) All Writing to the Chatbox and Wating for fetched Images shoud be in a separat Function. 

				If ssh.NullResponse = False And ssh.DomTask <> "" Then
					If ssh.SysMes = True Then
						' ##################### System Message ########################
						ChatAddSystemMessage(ssh.DomTask, False)
						ssh.SysMes = False
					ElseIf ssh.EmoMes = True Then
						' ###################### Emote Message ########################
						ChatAddEmoteMessage(ssh.contactToUse.TypeName, ssh.DomTask, True)
						ssh.EmoMes = False
					Else
						' ##################### Regular Message #######################
						ChatAddMessage(ssh.contactToUse.TypeName, ssh.DomTask, True)
						If ssh.SubWroteLast = True Then ssh.TypeToggle = 0
					End If
					ssh.SubWroteLast = False
				End If

HypNoResponse:
NoResponse:
				Try
					If BWimageFetcher.TriggerRequired AndAlso BWimageFetcher.WaitToFinish() Then
						' ################## Image already loading ####################
						' If Sync of results is activated, wait for the ImageFetcher to finish .
						' Do nothing else -> WaitToFinish has already displayed an image.

					ElseIf ssh.RiskyDeal = True Then
						' ######################## Risky Pick #########################
						FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh.contactToUse.NavigateNextTease)

					ElseIf Not String.IsNullOrWhiteSpace(ssh.DommeImageSTR) Then
						' ######################## Domme Tags #########################
						ShowImage(ssh.DommeImageSTR, True)

					ElseIf ShowPicture = True AndAlso ssh.contactToUse IsNot Nothing Then
						' ######################## Slideshow ##########################
						ShowImage(ssh.contactToUse.NavigateNextTease, True)

					ElseIf ShowPicture = True Then
						' #################### Domme Slideshow ########################
DommeSlideshowFallback:
						ShowImage(ssh.SlideshowMain.NavigateNextTease, True)
					End If

					If ssh.DomTask <> "" AndAlso ssh.contactToUse IsNot Nothing AndAlso ShowPicture Then
						' Apply texted Tags, after displaying an image.
						Dim OutputOrg As String = ssh.DomTask
						ssh.DomTask = ssh.contactToUse.ApplyTextedTags(OutputOrg)
						ssh.Chat = ssh.Chat.Replace(OutputOrg, ssh.DomTask)
					End If

				Catch ex As Exception When ssh.contactToUse IsNot ssh.SlideshowMain
					'@@@@@@@@@@@@@@ Exception - Try Fallback @@@@@@@@@@@@@@@@@@
					ssh.contactToUse = Nothing
					Log.WriteError("Error occurred while displaying image. Performing Fallback.",
					   ex, "Display Image")
					ChatAddSystemMessage(ex.ToString, False)
					GoTo DommeSlideshowFallback
				Catch ex As Exception
					'@@@@@@@@@@@@@@@@@@@@@@@ Exception @@@@@@@@@@@@@@@@@@@@@@@@
					Log.WriteError("Error occurred while displaying image. Fallback Failed.",
					   ex, "Display Image")
					ClearMainPictureBox()
				Finally
					ssh.DommeImageSTR = ""
					ssh.JustShowedBlogImage = False
					ssh.JustShowedSlideshowImage = False
					ShowPicture = False
				End Try

				' #################### Update ChatText ########################
				' Since ssh.Chat is not modified on NullResponse etc. we can display it every time.
				' --> This will disallow to scroll up in chat.
				ChatUpdate()

				' ####################### TTS Output ##########################
				If FrmSettings.TTSCheckBox.Checked = True _
				And TTSVoice <> "No voices installed" _
				And ssh.DomTask <> "" Then
					Debug.Print(ssh.DomTask)
					ssh.DomTask = StripFormat(ssh.DomTask)

					mciSendString("CLOSE Speech1", String.Empty, 0, 0)
					mciSendString("CLOSE Echo1", String.Empty, 0, 0)

					Dim SpeechDir As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\TempWav.wav"

					synth2.Volume = ssh.contactToUse.TTSvolume
					synth2.Rate = ssh.contactToUse.TTSrate
					synth2.SelectVoice(TTSVoice)
					synth2.SetOutputToWaveFile(SpeechDir, New SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono))
					synth2.Speak(ssh.DomTask)
					synth2.SetOutputToNull()

					SpeechDir = GetShortPathName(SpeechDir)

					mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Speech1", String.Empty, 0, 0)
					mciSendString("PLAY Speech1 FROM 0", String.Empty, 0, 0)



					If CBHypnoGenPhase.Checked And ssh.HypnoGen = True Then
						Delay(0.4)
						mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Echo1", String.Empty, 0, 0)
						mciSendString("PLAY Echo1 FROM 0", String.Empty, 0, 0)
					End If

				End If



				If ssh.CorrectedTypo = True Then
					ssh.CorrectedTypo = False
					'DomTask = "*" & CorrectedWord
					ssh.DomTask = LineSpeaker & "*" & ssh.CorrectedWord
					TypingDelayGeneric()
					Return
				End If

				StrokeSpeedCheck()

				If ssh.SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If ssh.RLGLGame = True And ssh.RedLight = False Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused) Then
						DomWMP.Ctlcontrols.play()


						ssh.AskedToSpeedUp = False
						ssh.AskedToSlowDown = False
						ssh.SubStroking = True
						ssh.SubEdging = False
						ssh.SubHoldingEdge = False
						StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
						StrokePace = 50 * Math.Round(StrokePace / 50)
						ssh.RLGLTauntTick = ssh.randomizer.Next(20, 31)
						' VideoTauntTick = randomizer.Next(20, 31)
						RLGLTauntTimer.Start()

					End If
				End If

				If ssh.RLGLGame = True And ssh.RedLight = True Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
						DomWMP.Ctlcontrols.pause()
						ssh.SubStroking = False
						StrokePace = 0
						'VideoTauntTimer.Stop()
					End If
				End If



				ssh.NullResponse = False

				If ssh.FollowUp <> "" Then
					If GetFilter(ssh.FollowUp) Then
						ssh.DomTask = ssh.FollowUp
					Else
						ssh.DomTask = "@NullResponse"
					End If
					Debug.Print("FollowUp DomTask = " & ssh.DomTask)
					ssh.FollowUp = ""
					TypingDelayGeneric()
					Exit Sub
				End If

				ssh.DomTypeCheck = False
				ssh.DomTyping = False
				'StringLength = 20
				ssh.StringLength = ssh.randomizer.Next(8, 16)

				If ssh.SubHoldingEdge = True Then
					StrokePace = 0
				End If
				'Debug.Print("End of DomTask #######################################################################################################################")
				'JustShowedBlogImage = False

				If ssh.TempScriptCount = 0 Then
					ssh.JustShowedBlogImage = False
					ssh.JustShowedSlideshowImage = False
				End If


				If ssh.CBTCockActive = True Then
					ssh.CBTCockActive = False
					CBTCock()
				End If

				If ssh.CBTBallsActive = True Then
					ssh.CBTBallsActive = False
					CBTBalls()
				End If

				If ssh.CBTBothActive = True Then
					ssh.CBTBothActive = False
					CBTBoth()
				End If

				If ssh.CustomTaskActive = True Then
					ssh.CustomTaskActive = False
					RunCustomTask()
				End If

				If ssh.YesOrNo = False Then
					If ssh.RapidCode = True Then
						If Not WaitTimer.Enabled Then RunFileText()
					Else
						ssh.ScriptTick = ssh.randomizer.Next(4, 7)
						If ssh.RapidFire = True Then ssh.ScriptTick = 1
						If ssh.RiskyDeal = True Then ssh.ScriptTick = 2
						ScriptTimer.Start()
					End If
				End If

				If ssh.YesOrNo = True And ssh.RiskyDeal = True Then
					FrmCardList.BTNPickIt.Visible = True
					FrmCardList.BTNRiskIt.Visible = True
					FrmCardList.HighlightCaseLabelsOffer()

				End If

				ssh.GotoFlag = False

				If ssh.EndSession = True Then
					ssh.EndSession = False
					SaveChatLog(False)
					ssh.Reset()
					FrmSettings.LockOrgasmChances(False)
					mainPictureBox.Image = Nothing
				End If

				If ssh.SubGaveUp = True Then
					If ssh.YesOrNo And ssh.giveUpReturn Then
						ssh.DomChat = "#SYS_ReturnAnswer"
						TypingDelay()
					End If

					ssh.SubGaveUp = False

					ssh.AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = ssh.SubStroking
					Dim WasEdging As Boolean = ssh.SubEdging
					Dim WasHolding As Boolean = ssh.SubHoldingEdge

					StopEverything()
					ssh.ModuleEnd = False
					ssh.ShowModule = False

					If ssh.CallReturns.Count() > 0 Then
						'if giveupreturn is on, we continue with the script after the give up
						If ssh.giveUpReturn Then
							ssh.ShowModule = True
							ssh.AskedToGiveUpSection = False
							ScriptTimer.Start()
							Return
							'else we reset all the callreturns and move to a link/end/module as expected from the give up
						Else
							ssh.CallReturns.Clear()
						End If
					End If

					If ssh.giveUpReturn Then
						ssh.ShowModule = True
						ssh.AskedToGiveUpSection = False
						ScriptTimer.Start()
					ElseIf ssh.TeaseTick < 1 And ssh.Playlist = False Then
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						RunModuleScript(False)
					Else
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

	Private Sub SendTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendTimer.Tick


		If ssh.DomChat.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()
		If ssh.DomChat.Contains("@NullResponse") Then
			ssh.NullResponse = True
			ssh.JustShowedBlogImage = True
		Else
			ssh.RapidCode = False
		End If

		updateDommeName(ssh.DomChat)
		'If Not ssh.Group.Contains("D") And Not ssh.DomChat.Contains("@Contact1") And Not ssh.DomChat.Contains("@Contact2") And Not ssh.DomChat.Contains("@Contact3") Then
		'Dim GroupList As New List(Of String)
		'	GroupList.Clear()
		'If ssh.Group.Contains("1") Then GroupList.Add(" @Contact1 ")
		'If ssh.Group.Contains("2") Then GroupList.Add(" @Contact2 ")
		'If ssh.Group.Contains("3") Then GroupList.Add(" @Contact3 ")
		'	ssh.DomChat = ssh.DomChat & GroupList(ssh.randomizer.Next(0, GroupList.Count))
		'End If

		If ssh.NullResponse = True Then
			SendTimer.Stop()
			GoTo NullResponseLine
		End If

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		Dim ShowPicture As Boolean = False

		' Let the program know that the domme is currently typing
		ssh.DomTypeCheck = True

		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If ssh.TypeToggle = 0 Then
			If ssh.TypeDelay > 0 Then
				ssh.TypeDelay -= 1
			Else

				SendTimer.Stop()

				If ssh.RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				ssh.IsTyping = True

				If ssh.DomChat.Contains("@EmoteMessage") Then ssh.EmoMes = True

				If ssh.DomChat.Contains("@SystemMessage") Then
					ssh.SysMes = True
					ssh.TypeDelay = 0
					GoTo SkipIsTyping
				End If

				' ###### display "is typing..." message.
				ChatUpdate()

SkipIsTyping:

				ssh.TypeToggle = 1
				ssh.StringLength = ssh.DomChat.Length
				If ssh.DivideText = True Then
					ssh.StringLength /= 3
					ssh.DivideText = False
				End If
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh.RapidCode = True Then ssh.StringLength = 0
				TypingDelay()
			End If

		Else

			If ssh.TypeDelay > 0 Then
				ssh.TypeDelay -= 1
				If ssh.DomChat.Contains("@SystemMessage") Then ssh.TypeDelay = 0
			Else
				ssh.TypeToggle = 0
				SendTimer.Stop()
				ssh.IsTyping = False

				ssh.ResponseYes = ""
				ssh.ResponseNo = ""

				If ssh.RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

NullResponseLine:
				'################## Display a Slideimage? #################
				'TODO: Optimize Code. Since images loaded by the Backgroundworker are prioritized, this section can be shrinked down.
				If ssh.DomChat.Contains("@ShowHardcoreImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowSoftcoreImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowLesbianImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowBlowjobImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowFemdomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowLezdomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowHentaiImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowGayImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowMaledomImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowCaptionsImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowGeneralImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowLocalImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@ShowBlogImage") Then ssh.JustShowedBlogImage = True
				If ssh.DomChat.Contains("@NewBlogImage") Then ssh.JustShowedBlogImage = True

				If ssh.DomChat.Contains("@SlideshowFirst") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomChat.Contains("@SlideshowNext") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomChat.Contains("@SlideshowPrevious") Then ssh.JustShowedSlideshowImage = True
				If ssh.DomChat.Contains("@SlideshowLast") Then ssh.JustShowedSlideshowImage = True

				If ssh.GlitterTease = True And ssh.JustShowedBlogImage = False Then GoTo TryNextWithTease

				If FrmSettings.teaseRadio.Checked = True And ssh.JustShowedBlogImage = False And ssh.TeaseVideo = False And Not ssh.DomChat.Contains("@NewBlogImage") And ssh.NullResponse = False _
				 And ssh.SlideshowLoaded = True And Not ssh.DomChat.Contains("@ShowButtImage") And Not ssh.DomChat.Contains("@ShowBoobsImage") And Not ssh.DomChat.Contains("@ShowButtsImage") _
				 And Not ssh.DomChat.Contains("@ShowBoobImage") And ssh.LockImage = False And ssh.CustomSlideEnabled = False And ssh.RapidFire = False _
				 And UCase(ssh.DomChat) <> "@SystemMessage Tease AI has been reset" And ssh.JustShowedSlideshowImage = False Then
					' Begin Next Button

					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:


					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


					ShowPicture = True

				End If


				If ssh.DomChat.Contains("@WritingTask(") Then
					ssh.currentWriteTask = GetParentheses(ssh.DomChat, "@WritingTask(")
					ssh.DomChat = ssh.DomChat.Replace(ssh.currentWriteTask, PoundClean(ssh.currentWriteTask))
				End If

				If ssh.DomChat.Contains("@WritingTaskRandom(") Then
					ssh.currentWriteTask = GetParentheses(ssh.DomChat, "@WritingTaskRandom(")
					ssh.DomChat = ssh.DomChat.Replace(ssh.currentWriteTask, PoundClean(ssh.currentWriteTask))
				End If

				If ssh.DomChat.Contains("@Contact1") Or ssh.DomChat.Contains("@Contact2") Or ssh.DomChat.Contains("@Contact3") Or ssh.DomChat.Contains("@RandomContact") Then ssh.SubWroteLast = True


				'################### Gather Response Data #################
				'TODO-Next: Test Code
				'ssh.contactToUse = ssh.SlideshowMain

				'If ssh.DomChat.Contains("@Contact1") Then _
				'ssh.contactToUse = ssh.SlideshowContact1

				'If ssh.DomChat.Contains("@Contact2") Then _
				'ssh.contactToUse = ssh.SlideshowContact2

				'If ssh.DomChat.Contains("@Contact3") Then _
				'ssh.contactToUse = ssh.SlideshowContact3

				'Dim TypeName As String = ssh.contactToUse.TypeName
				'Dim TypeColor As String = ssh.contactToUse.TypeColorHtml
				'Dim TypeFont As String = ssh.contactToUse.TypeFont
				'Dim TypeSize As String = ssh.contactToUse.TypeSize

				Dim TTSVoice As String = FrmSettings.TTSComboBox.Text
				'Dim TTSrate As Integer = ssh.contactToUse.TTSrate
				'Dim TTSvolume As String = ssh.contactToUse.TTSvolume



				If FrmSettings.TTSCheckBox.Checked = True And TTSVoice <> "No voices installed" Then
					Dim EmoteArray() As String = Split(ssh.DomChat)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					ssh.DomChat = Join(EmoteArray)
				End If


				Dim LoopBuffer As Integer = 0

				Do

					LoopBuffer += 1

					ssh.DomChat = ssh.DomChat.Replace("#Null", "")
					ssh.DomChat = PoundClean(ssh.DomChat)
					ssh.DomChat = CommandClean(ssh.DomChat)
					ssh.DomChat = StripCommands(ssh.DomChat)
					ssh.DomChat = ssh.DomChat.Replace("#Null", "")
					ssh.DomChat = PoundClean(ssh.DomChat)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not ssh.DomChat.Contains("#") And Not ssh.DomChat.Contains("@")



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

				If ssh.SysMes = False And ssh.EmoMes = False Then

					Try
						Dim UCASELine As String = UCase(ssh.DomChat.Substring(0, 1))
						ssh.DomChat = ssh.DomChat.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try

					If FrmSettings.LCaseCheckBox.Checked = True Then ssh.DomChat = LCase(ssh.DomChat)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(ssh.DomChat)
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
						ssh.DomChat = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then ssh.DomChat = ssh.DomChat.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then ssh.DomChat = ssh.DomChat.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then ssh.DomChat = ssh.DomChat.Replace(".", "")

					Dim EmoToggle As Boolean = True
					For i As Integer = ssh.DomChat.Length - 1 To 0 Step -1
						If ssh.DomChat.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								ssh.DomChat = ssh.DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								ssh.DomChat = ssh.DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					ssh.DomChat = ssh.DomChat.Replace(":d", ":D")
					ssh.DomChat = ssh.DomChat.Replace(": d", ": D")

				End If

				ssh.DomChat = ssh.DomChat.Replace("ATSYMBOL", "@")
				ssh.DomChat = ssh.DomChat.Replace("atsymbol", "@")

				If ssh.InputIcon = True Then
					ssh.DomChat = ssh.DomChat & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					ssh.InputIcon = False
				End If

				ssh.DomChat = ssh.DomChat.Replace(" a a", " an a")
				ssh.DomChat = ssh.DomChat.Replace(" a e", " an e")
				ssh.DomChat = ssh.DomChat.Replace(" a i", " an i")
				ssh.DomChat = ssh.DomChat.Replace(" a o", " an o")
				ssh.DomChat = ssh.DomChat.Replace(" a u", " an u")

				ssh.DomChat = ssh.DomChat.Replace(" an uni", " a uni")
				ssh.DomChat = ssh.DomChat.Replace(" an utensil", " a utensil")
				ssh.DomChat = ssh.DomChat.Replace(" an ukulele", " a ukulele")
				ssh.DomChat = ssh.DomChat.Replace(" an use", " a use")
				ssh.DomChat = ssh.DomChat.Replace(" an urethra", " a urethra")
				ssh.DomChat = ssh.DomChat.Replace(" an urine", " a urine")
				ssh.DomChat = ssh.DomChat.Replace(" an usual", " a usual")
				ssh.DomChat = ssh.DomChat.Replace(" an utility", " a utility")
				ssh.DomChat = ssh.DomChat.Replace(" an uterus", " a uterus")
				ssh.DomChat = ssh.DomChat.Replace(" an utopia", " a utopia")

				'SUGGESTION: (Stefaf) All Writing to the Chatbox and Wating for fetched Images shoud be in a separat Function. 

				If ssh.NullResponse = True Or ssh.DomChat = "" Or ssh.DomChat Is Nothing Then GoTo NullResponseLine2

				Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)


				If ssh.SysMes = True Then
					' ##################### System Message ########################
					ChatAddSystemMessage(ssh.DomChat, False)
					ssh.SysMes = False
				ElseIf ssh.EmoMes = True Then
					' ###################### Emote Message ########################
					ChatAddEmoteMessage(ssh.contactToUse.TypeName, ssh.DomTask, True)
					ssh.EmoMes = False
				Else
					' ##################### Regular Message #######################
					ChatAddMessage(ssh.contactToUse.TypeName, ssh.DomChat, True)
					If ssh.SubWroteLast Then ssh.TypeToggle = 0
				End If


				ssh.SubWroteLast = False

NullResponseLine2:

				Try
					If BWimageFetcher.TriggerRequired AndAlso BWimageFetcher.WaitToFinish() Then
						' ################## Image already loading ####################
						' If Sync of results is activated, wait for the ImageFetcher to finish .
						' Do nothing else -> WaitToFinish has already displayed an image.

					ElseIf ssh.RiskyDeal = True Then
						' ######################## Risky Pick #########################
						FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh.contactToUse.NavigateNextTease)

					ElseIf Not String.IsNullOrWhiteSpace(ssh.DommeImageSTR) Then
						' ######################## Domme Tags #########################
						ShowImage(ssh.DommeImageSTR, True)

					ElseIf ShowPicture = True AndAlso ssh.contactToUse IsNot Nothing Then
						' ################### Variable Slideshow ######################
						ShowImage(ssh.contactToUse.NavigateNextTease, True)

					ElseIf ShowPicture = True Then
						' #################### Domme Slideshow ########################
DommeSlideshowFallback:
						ShowImage(ssh.SlideshowMain.NavigateNextTease, True)
					End If

					If ssh.DomChat <> "" AndAlso ssh.contactToUse IsNot Nothing AndAlso ShowPicture Then
						' Apply texted Tags, after displaying an image.
						Dim OutputOrg As String = ssh.DomChat
						ssh.DomChat = ssh.contactToUse.ApplyTextedTags(OutputOrg)
						ssh.Chat = ssh.Chat.Replace(OutputOrg, ssh.DomChat)
					End If
				Catch ex As Exception When ssh.contactToUse IsNot ssh.SlideshowMain
					'@@@@@@@@@@@@@@ Exception - Try Fallback @@@@@@@@@@@@@@@@@@
					ssh.contactToUse = Nothing
					Log.WriteError("Error occurred while displaying image. Performing Fallback.",
					 ex, "Display Image")
					GoTo DommeSlideshowFallback
				Catch ex As Exception
					'@@@@@@@@@@@@@@@@@@@@@@@ Exception @@@@@@@@@@@@@@@@@@@@@@@@
					Log.WriteError("Error occurred while displaying image. Fallback Failed.",
					 ex, "Display Image")
					ClearMainPictureBox()
				Finally
					ssh.DommeImageSTR = ""
					ssh.JustShowedBlogImage = False
					ssh.JustShowedSlideshowImage = False
					ShowPicture = False
				End Try

				' #################### Update ChatText ########################
				' Since ssh.Chat is not modified on NullResponse etc. we can display it every time.
				' --> This will disallow to scroll up in chat.
				ChatUpdate()


				' ####################### TTS Output ##########################
				If FrmSettings.TTSCheckBox.Checked = True _
				And TTSVoice <> "No voices installed" _
				And ssh.DomChat <> "" Then
					ssh.DomChat = StripFormat(ssh.DomChat)
					synth.Volume = ssh.contactToUse.TTSvolume
					synth.Rate = ssh.contactToUse.TTSrate
					synth.SelectVoice(TTSVoice)
					synth.Speak(ssh.DomChat)
				End If



				If ssh.MultipleEdgesMetronome = "STOP" Then
					ssh.MultipleEdgesMetronome = ""
					StrokePace = 0
					ssh.SubStroking = False
					ssh.SubEdging = False
					DeactivateWebToy()
				End If

				If ssh.MultipleEdgesMetronome = "START" Then
					ssh.MultipleEdgesMetronome = ""
					EdgePace()
					ssh.SubStroking = True
					ssh.SubEdging = True
					ActivateWebToy()
					DisableContactStroke()
				End If

				StrokeSpeedCheck()

				If ssh.SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If ssh.SubHoldingEdge = True Then
					StrokePace = 0
				End If

				'Debug.Print("NullResponse = " & NullResponse)

				ssh.NullResponse = False

				If ssh.FollowUp <> "" Then
					If GetFilter(ssh.FollowUp) Then
						ssh.DomChat = ssh.FollowUp
					Else
						ssh.DomChat = "@NullResponse"
					End If
					ssh.FollowUp = ""
					TypingDelay()
					Exit Sub
				End If

				ssh.DomTypeCheck = False
				'StringLength = 20
				ssh.StringLength = ssh.randomizer.Next(8, 16)

				If ssh.TempScriptCount = 0 Then
					ssh.JustShowedBlogImage = False
					ssh.JustShowedSlideshowImage = False
				End If


				If ssh.CBTCockActive = True Then ssh.CBTCockActive = False
				If ssh.CBTBallsActive = True Then ssh.CBTBallsActive = False
				If ssh.CBTBothActive = True Then ssh.CBTBothActive = False


				If ssh.TasksCount > 0 Then
					If ssh.CBTCockFlag = True Then
						CBTCock()
					End If

					If ssh.CBTBallsFlag = True Then
						CBTBalls()
					End If

					If ssh.CBTBothFlag = True Then
						CBTBoth()
					End If

					If ssh.CustomTask = True Then
						RunCustomTask()
					End If
				End If

				If ssh.YesOrNo = False And ssh.Responding = False Then
					ssh.ScriptTick = ssh.randomizer.Next(4, 7)
					If ssh.RiskyDeal = True Then ssh.ScriptTick = 2
					ScriptTimer.Start()
				End If

				ssh.Responding = False

				If ssh.EndSession = True Then
					ssh.EndSession = False
					SaveChatLog(False)
					ssh.Reset()
					FrmSettings.LockOrgasmChances(False)
					mainPictureBox.Image = Nothing
				End If

				If ssh.SubGaveUp = True Then
					If ssh.YesOrNo And ssh.giveUpReturn Then
						ssh.DomChat = "#SYS_ReturnAnswer"
						TypingDelay()
					End If
					ssh.SubGaveUp = False

					ssh.AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = ssh.SubStroking
					Dim WasEdging As Boolean = ssh.SubEdging
					Dim WasHolding As Boolean = ssh.SubHoldingEdge

					StopEverything()
					ssh.ModuleEnd = False
					ssh.ShowModule = False

					'DelayFlag = True
					'DelayTick = randomizer.Next(3, 6)

					'DelayTimer.Start()

					'Do
					'Application.DoEvents()
					'Loop Until DelayFlag = False

					ssh.LastScriptCountdown -= 1
					'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

					'FrmSettings.LBLOrgasmCountdown.Text = LastScriptCountdown

					If ssh.CallReturns.Count() > 0 Then
						'if giveupreturn is on, we continue with the script after the give up
						If ssh.giveUpReturn Then
							ssh.ShowModule = True
							ssh.AskedToGiveUpSection = False
							ScriptTimer.Start()
							Return
							'else we reset all the callreturns and move to a link/end/module as expected from the give up
						Else
							ssh.CallReturns.Clear()
						End If
					End If

					If ssh.giveUpReturn Then
						ssh.ShowModule = True
						ssh.AskedToGiveUpSection = False
						ScriptTimer.Start()
					ElseIf ssh.TeaseTick < 1 And ssh.Playlist = False Then
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						RunModuleScript(False)
					Else
						RunLinkScript()
					End If
				End If
			End If
		End If
	End Sub




#Region "------------------------------------------ Images ----------------------------------------------"

	Private Sub LoadCustomizedSlideshow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browsefolderButton.Click, ImageFolderComboBox.KeyDown, ImageFolderComboBox.SelectionChangeCommitted
		'TODO-Next-Stefaf: Implement enhanced RecentSlideshows.Item handling
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		Try
			Dim GetFolder As String = ""
			Dim ManuallyEntered As Boolean = False
			browsefolderButton.Enabled = False
			nextButton.Enabled = False
			previousButton.Enabled = False
			PicStripTSMIdommeSlideshow.Enabled = False
			'TODO-Next: Move ImageNavigation-Lock to BWImageSync
			If sender Is browsefolderButton Then
				'===============================================================================
				'								browsefolderButton
				'===============================================================================
				If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
					GetFolder = FolderBrowserDialog1.SelectedPath

					My.Settings.RecentSlideshows.Add(GetFolder)

					Do Until My.Settings.RecentSlideshows.Count < 11
						My.Settings.RecentSlideshows.Remove(My.Settings.RecentSlideshows(0))
					Loop

					ImageFolderComboBox.Items.Clear()

					Dim uniqueNames = From u In My.Settings.RecentSlideshows Distinct

					For Each n In uniqueNames
						ImageFolderComboBox.Items.Add(n)
					Next

					'For Each comboitem As String In My.Settings.RecentSlideshows
					'ImageFolderComboBox.Items.Add(comboitem)
					'Next

					ImageFolderComboBox.Text = GetFolder
				End If
			ElseIf sender Is ImageFolderComboBox And TypeOf e Is KeyEventArgs Then
				'===============================================================================
				'						ImageFolderComboBox - KeyPressEvent
				'===============================================================================
				Dim _e As KeyEventArgs = DirectCast(e, KeyEventArgs)

				If _e.KeyCode = Keys.Enter Then
					_e.Handled = True
					ManuallyEntered = True
					GoTo chooseComboboxText
				Else
					Exit Sub
				End If
			ElseIf sender Is ImageFolderComboBox And TypeOf e Is EventArgs Then
				'===============================================================================
				'								ImageFolderComboBox
				'===============================================================================
chooseComboboxText:
				'ImageFolderComboBox.Text = ImageFolderComboBox.SelectedItem
				Dim StringToCheck As String
				If ManuallyEntered = True Then
					StringToCheck = ImageFolderComboBox.Text
				Else
					StringToCheck = ImageFolderComboBox.SelectedItem
				End If

				If Directory.Exists(StringToCheck) Or isURL(StringToCheck) Then
					GetFolder = StringToCheck

					My.Settings.RecentSlideshows.Add(GetFolder)

					Do Until My.Settings.RecentSlideshows.Count < 11
						My.Settings.RecentSlideshows.Remove(My.Settings.RecentSlideshows(0))
					Loop

					ImageFolderComboBox.Items.Clear()

					Dim uniqueNames = From u In My.Settings.RecentSlideshows Distinct

					For Each n In uniqueNames
						ImageFolderComboBox.Items.Add(n)
					Next

					ImageFolderComboBox.Text = GetFolder

					'For Each comboitem As String In My.Settings.RecentSlideshows
					'ImageFolderComboBox.Items.Add(comboitem)
					'Next
				Else
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

				ssh.SlideshowLoaded = False

				If FrmSettings.CBSlideshowSubDir.Checked = True Then
					ssh.SlideshowMain.ImageList = myDirectory.GetFilesImages(GetFolder, SearchOption.AllDirectories)
				Else
					ssh.SlideshowMain.ImageList = myDirectory.GetFilesImages(GetFolder, SearchOption.TopDirectoryOnly)
				End If

				ssh.SlideshowMain.Index = 0

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

					ssh.SlideshowLoaded = False

					For Each ___PhotoNode As Xml.XmlNode In tmpDoc.DocumentElement.SelectNodes("//photo-url")
						If CInt(___PhotoNode.Attributes.ItemOf("max-width").InnerText) = 1280 Then
							ssh.SlideshowMain.ImageList.Add(___PhotoNode.InnerXml)
						End If
					Next
					ssh.SlideshowMain.Index = 0
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
			If ssh.SlideshowMain.ImageList.Count <= 0 Then

				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!",
				  MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			Else
				ssh.SlideshowLoaded = True
			End If



			ShowImage(ssh.SlideshowMain.NavigateNextTease, True)
			ssh.JustShowedBlogImage = False

			'TODO: FrmSettings.timedRadio.Checked - Remove CrossForm DataAccess
			If FrmSettings.timedRadio.Checked = True Then
				ssh.SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
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

	Private Sub imagesNextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextButton.Click, previousButton.Click
		Try
			If My.Settings.CBSettingsPause And FrmSettings.SettingsPanel.Visible = True Then
				MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
				Exit Sub
			End If

			If ssh.SlideshowLoaded = False Or ssh.TeaseVideo = True Then Return

			Dim sh As ContactData = ssh.SlideshowMain
Retry:
			If My.Settings.CBSlideshowRandom Then
				sh.NavigateNextTease()
			ElseIf sender Is nextButton Then
				' ====================== Next Image =======================
				sh.NavigateForward()
			ElseIf sender Is previousButton Then
				' ==================== Previous Image =====================
				sh.NavigateBackward()
			Else
				' ======================== Error ==========================
				Throw New NotImplementedException("Action for button not implemented.")
			End If

			If Not (File.Exists(sh.CurrentImage) _
			  Or isURL(sh.CurrentImage)) Then
				ClearMainPictureBox()
				Return
			End If

			Try
				'TODO-Next: Move ImageNavigation-Lock to BWImageSync
				browsefolderButton.Enabled = False
				ImageFolderComboBox.Enabled = False
				nextButton.Enabled = False
				previousButton.Enabled = False
				PicStripTSMIdommeSlideshow.Enabled = False

				ShowImage(sh.CurrentImage, True)

				ssh.JustShowedBlogImage = False

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

	Private Sub ImageFolderComboBox_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ImageFolderComboBox.MouseWheel
		Dim mwe As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
		mwe.Handled = True
	End Sub

#End Region  ' Images

#Region " VLC "

	Private Sub BTNLoadVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLoadVideo.Click

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



	Private Sub BTNVideoControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVideoControls.Click

		If BTNVideoControls.Text = "Hide Video Controls" Then
			DomWMP.uiMode = "none"
			BTNVideoControls.Text = "Show Video Controls"
		Else
			DomWMP.uiMode = "full"
			BTNVideoControls.Text = "Hide Video Controls"
		End If

		DomWMP.stretchToFit = True

	End Sub



#End Region


	Private Sub StrokeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrokeTimer.Tick


		If ssh.InputFlag = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		If ssh.DomTypeCheck = True And ssh.StrokeTick < 5 Then Return
		If chatBox.Text <> "" And ssh.StrokeTick < 5 Then Return
		If ChatBox2.Text <> "" And ssh.StrokeTick < 5 Then Return
		If ssh.FollowUp <> "" And ssh.StrokeTick < 5 Then Return


		If FrmSettings.CBDebugTauntsEndless.Checked = True And ssh.StrokeTick < 5 Then Return

		ssh.StrokeTick -= 1
		FrmSettings.LBLCycleDebugCountdown.Text = ssh.StrokeTick

		FrmSettings.LBLDebugStrokeTime.Text = ssh.StrokeTick
		'Debug.Print("StrokeTick = " & StrokeTick)

		If ssh.StrokeTick < 4 And ssh.TempScriptCount > 0 Then ssh.StrokeTick += 1

		If ssh.StrokeTick < 1 Then

			ssh.FirstRound = False

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()

			If ssh.RunningScript = True Then
				ssh.ScriptTick = 3
				ScriptTimer.Start()
			Else

				RunModuleScript(False)

			End If


		End If









	End Sub


	Private Sub StrokeTauntTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrokeTauntTimer.Tick

		If ssh.InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.StrokeTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh.StrokeTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.StrokeTauntTick < 6 Then Return








		ssh.StrokeTauntTick -= 1

		FrmSettings.LBLDebugStrokeTauntTime.Text = ssh.StrokeTauntTick

		If ssh.StrokeTauntTick > 0 Then
			' #################### Time hasn't come #######################
			Exit Sub

		ElseIf ssh.TempScriptCount <= 0 AndAlso FrmSettings.CBDebugTaunts.Checked Then
			' ###################### Debug Taunt ##########################

			Dim Lines As New List(Of String)

			Dim TmpString As String = FrmSettings.TBDebugTaunts1.Text
			If Not String.IsNullOrWhiteSpace(TmpString) Then Lines.Add(TmpString)

			TmpString = FrmSettings.TBDebugTaunts2.Text
			If Not String.IsNullOrWhiteSpace(TmpString) Then Lines.Add(TmpString)

			TmpString = FrmSettings.TBDebugTaunts3.Text
			If Not String.IsNullOrWhiteSpace(TmpString) Then Lines.Add(TmpString)

			Dim Count As Integer = 1
			If FrmSettings.RBDebugTaunts2.Checked Then Count = 2
			If FrmSettings.RBDebugTaunts3.Checked Then Count = 3

			Do Until Lines.Count >= Count
				Lines.Add("Tease-AI: Debug taunt line missing.")
			Loop


			ssh.TauntText = "Debug-Menu"
			ssh.TauntLines = Lines
			ssh.TauntTextCount = 0
			ssh.TempScriptCount = Lines.Count - 1

		ElseIf ssh.TempScriptCount <= 0 Then
			' ##################### Taunt from File #######################

			Dim tauntFile As String = "StrokeTaunts"
			If My.Settings.Chastity = True Then tauntFile = "ChastityTaunts"
			If ssh.GlitterTease = True Then tauntFile = "GlitterTaunts"

			Dim TauntFiles As New List(Of TauntProcessingObject)

			For Each str As String In myDirectory.GetFiles(Path.Combine(ssh.Folders.Personality, "Stroke"), tauntFile & "_*.txt", SearchOption.TopDirectoryOnly)
				Dim Taunt As New TauntProcessingObject(str, Me)
				If Taunt.Avaialable Then TauntFiles.Add(Taunt)
			Next


			If TauntFiles.Count = 0 Then
				' No Taunt available
				ssh.TauntText = ""
				ssh.TauntLines = New List(Of String)
				ssh.TauntTextCount = 0
				ssh.TempScriptCount = 0
			Else
				' Taunt available
				Dim TauntToUse As TauntProcessingObject

				' Increase chance of one line taunt
				Dim OneLineChance As Integer = ssh.randomizer.Next(0, 101)

				If OneLineChance < 45 _
				AndAlso TauntFiles.Find(Function(x) x.TauntSize = 1) IsNot Nothing Then
					' 1 line taunts available, force to use it.
					Dim OneLiners As List(Of TauntProcessingObject) = TauntFiles.Where(Function(x) x.TauntSize = 1).ToList
					TauntToUse = OneLiners(ssh.randomizer.Next(0, OneLiners.Count))
				Else
					' Pick a random taunt size.
					TauntToUse = TauntFiles(ssh.randomizer.Next(0, TauntFiles.Count))
				End If

				ssh.TauntText = TauntToUse.FilePath
				ssh.TauntLines = TauntToUse.Lines
				ssh.TauntTextCount = TauntToUse.RandomTauntLine
				ssh.TempScriptCount = TauntToUse.TauntSize - 1

				ssh.MultiTauntPictureHold = False

			End If

		Else
			' ##################### Next Taunt line #######################
			ssh.TauntTextCount += 1

			If ssh.TempScriptCount > 0 Then ssh.MultiTauntPictureHold = True

			ssh.TempScriptCount -= 1

		End If

		If ssh.TauntLines.Count > 0 Then

			Try
				ssh.DomTask = ssh.TauntLines(ssh.TauntTextCount)
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Taunt from file: " &
				  ssh.TauntText, ex, "StrokeTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Taunt from file: " & ssh.TauntText
			End Try
		Else
			Try
				ssh.DomTask = ssh.TauntLines(ssh.TauntTextCount)
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Taunt from any available file", ex, "StrokeTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Taunt from any available file"
			End Try
		End If



		If InStr(UCase(ssh.DomTask), UCase("@CBT")) <> 0 Then
			CBTScript()
		Else
			TypingDelayGeneric()
		End If


		If ssh.TempScriptCount = 0 Then
			If FrmSettings.SliderSTF.Value = 1 Then ssh.StrokeTauntTick = ssh.randomizer.Next(120, 241)
			If FrmSettings.SliderSTF.Value = 2 Then ssh.StrokeTauntTick = ssh.randomizer.Next(75, 121)
			If FrmSettings.SliderSTF.Value = 3 Then ssh.StrokeTauntTick = ssh.randomizer.Next(45, 76)
			If FrmSettings.SliderSTF.Value = 4 Then ssh.StrokeTauntTick = ssh.randomizer.Next(25, 46)
			If FrmSettings.SliderSTF.Value = 5 Then ssh.StrokeTauntTick = ssh.randomizer.Next(15, 26)
		Else
			ssh.StrokeTauntTick = ssh.randomizer.Next(5, 9)
		End If





	End Sub


	Public Sub CBTScript()
		Try
			Dim FilePath As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBT.txt"

			If Not Directory.Exists(Path.GetDirectoryName(FilePath)) OrElse Not File.Exists(FilePath) Then
				Throw New Exception("TEASE-AI: unable to locate CBT-File: " & FilePath)
			Else

				Dim lines As List(Of String) = Txt2List(FilePath)
				If lines.Count = 0 Then Throw New Exception("TEASE-AI: CBT-file is empty: " & FilePath)

				lines = FilterList(lines)
				If lines.Count = 0 Then Throw New Exception("TEASE-AI: No available lines in CBT-file: " & FilePath)

				Dim CBTCount As Integer

				CBTCount = ssh.randomizer.Next(0, lines.Count)

				ssh.DomTask = lines(CBTCount)
				ssh.CBT = True
				ssh.YesOrNo = True
			End If

		Catch ex As Exception
			ssh.DomTask = ex.Message
			Log.WriteError(ex.Message, ex, "CBTScript()")
		Finally
			TypingDelayGeneric()
		End Try
	End Sub




#Region "----------------------------------------------------- Video-Files ----------------------------------------------------"

	Public Sub RandomVideo()
		' Reset retentive global variables
		ssh.NoVideo = False
		ssh.DommeVideo = False

		Dim __dom As Random = New Random()
		Dim __domVideo As String
		Dim __TotalFiles As New List(Of String)

		'======================================================================================
		'									Genre Videos
		'======================================================================================
		If My.Settings.CBHardcore = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "HARDCORE") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoHardcore))

		If My.Settings.CBSoftcore = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "SOFTCORE") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoSoftcore))

		If My.Settings.CBLesbian = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "LESBIAN") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoLesbian))

		If My.Settings.CBBlowjob = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "BLOWJOB") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoBlowjob))

		If My.Settings.CBFemdom = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "FEMDOM") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemdom))

		If My.Settings.CBFemsub = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "FEMSUB") Then _
		__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemsub))

		If ssh.NoSpecialVideo = True Then GoTo SkipSpecial

		If ssh.ScriptVideoTeaseFlag = True Then
			If ssh.ScriptVideoTease = "Censorship Sucks" Or ssh.ScriptVideoTease = "Avoid The Edge" Or ssh.ScriptVideoTease = "RLGL" Then GoTo SkipSpecial
		End If

		If ssh.RandomizerVideo = True Then GoTo SkipSpecial

		'======================================================================================
		'								Special - Videos
		'======================================================================================
		If My.Settings.CBJOI = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "JOI") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOI))

		If My.Settings.CBCH = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "CH") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCH))

SkipSpecial:
		'======================================================================================
		'									General Videos
		'======================================================================================
		If My.Settings.CBGeneral = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "GENERAL") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoGeneral))

		'======================================================================================
		'									Domme - Videos
		'======================================================================================
		If My.Settings.CBHardcoreD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "HARDCORE DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoHardcoreD))

		If My.Settings.CBSoftcoreD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "SOFTCORE DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoSoftcoreD))

		If My.Settings.CBLesbianD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "LESBIAN DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoLesbianD))

		If My.Settings.CBBlowjobD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "BLOWJOB DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoBlowjobD))

		If My.Settings.CBFemdomD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "FEMDOM DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemdomD))

		If My.Settings.CBFemsubD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "FEMSUB DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemsubD))

		If ssh.NoSpecialVideo = True Then GoTo SkipSpecialD
		If ssh.ScriptVideoTeaseFlag = True Then
			If ssh.ScriptVideoTease = "Censorship Sucks" Or ssh.ScriptVideoTease = "Avoid The Edge" Or ssh.ScriptVideoTease = "RLGL" Then GoTo SkipSpecialD
		End If

		If ssh.RandomizerVideo = True Then GoTo SkipSpecialD

		'======================================================================================
		'								Domme - Special - Videos
		'======================================================================================
		If My.Settings.CBJOID = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "JOI DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOID))

		If My.Settings.CBCHD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "CH DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCHD))

SkipSpecialD:
		'======================================================================================
		'								Domme - General Videos
		'======================================================================================
		If My.Settings.CBGeneralD = True And (ssh.VideoGenre = "ALL" Or ssh.VideoGenre = "GENERAL DOMME") Then _
   __TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoGeneralD))

		ssh.VideoGenre = "ALL"

		If __TotalFiles.Count = 0 Then Exit Sub

		If ssh.VideoCheck = True Then Exit Sub

GetAnotherRandomVideo:

		__domVideo = __TotalFiles(__dom.Next(0, __TotalFiles.Count))

		If __domVideo = "" Then GoTo GetAnotherRandomVideo

		'@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Debug Line @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		If Debugger.IsAttached AndAlso 1 = 2 Then _
		 __TotalFiles.ForEach(Sub(x) Debug.Print("RndVideoCheck: " & x))


		If My.Settings.CBHardcore And InStr(__domVideo, My.Settings.VideoHardcore) <> 0 Then ssh.VideoType = "Hardcore"
		If My.Settings.CBSoftcore And InStr(__domVideo, My.Settings.VideoSoftcore) <> 0 Then ssh.VideoType = "Softcore"
		If My.Settings.CBLesbian = True And InStr(__domVideo, My.Settings.VideoLesbian) <> 0 Then ssh.VideoType = "Lesbian"
		If My.Settings.CBBlowjob = True And InStr(__domVideo, My.Settings.VideoBlowjob) <> 0 Then ssh.VideoType = "Blowjob"
		If My.Settings.CBFemdom = True And InStr(__domVideo, My.Settings.VideoFemdom) <> 0 Then ssh.VideoType = "Femdom"
		If My.Settings.CBFemsub = True And InStr(__domVideo, My.Settings.VideoFemsub) <> 0 Then ssh.VideoType = "Femsub"
		If My.Settings.CBJOI = True And InStr(__domVideo, My.Settings.VideoJOI) <> 0 Then ssh.VideoType = "JOI"
		If My.Settings.CBCH = True And InStr(__domVideo, My.Settings.VideoCH) <> 0 Then ssh.VideoType = "CH"
		If My.Settings.CBGeneral = True And InStr(__domVideo, My.Settings.VideoGeneral) <> 0 Then ssh.VideoType = "General"


		If My.Settings.CBHardcoreD And InStr(__domVideo, My.Settings.VideoHardcoreD) <> 0 Then
			ssh.VideoType = "HardcoreD"
			ssh.DommeVideo = True
		End If
		If My.Settings.CBSoftcoreD And InStr(__domVideo, My.Settings.VideoSoftcoreD) <> 0 Then
			ssh.VideoType = "SoftcoreD"
			ssh.DommeVideo = True
		End If
		If My.Settings.CBLesbianD And InStr(__domVideo, My.Settings.VideoLesbianD) <> 0 Then
			ssh.VideoType = "LesbianD"
			ssh.DommeVideo = True
		End If

		If My.Settings.CBBlowjobD And InStr(__domVideo, My.Settings.VideoBlowjobD) <> 0 Then
			ssh.VideoType = "BlowjobD"
			ssh.DommeVideo = True
		End If
		If My.Settings.CBFemdomD And InStr(__domVideo, My.Settings.VideoFemdomD) <> 0 Then
			ssh.VideoType = "FemdomD"
			ssh.DommeVideo = True
		End If
		If My.Settings.CBFemsubD And InStr(__domVideo, My.Settings.VideoFemsubD) <> 0 Then
			ssh.VideoType = "FemsubD"
			ssh.DommeVideo = True
		End If

		If My.Settings.CBJOID And InStr(__domVideo, My.Settings.VideoJOID) <> 0 Then
			ssh.VideoType = "JOID"
			ssh.DommeVideo = True
		End If

		If My.Settings.CBCHD = True And InStr(__domVideo, My.Settings.VideoCHD) <> 0 Then
			ssh.VideoType = "CHD"
			ssh.DommeVideo = True
		End If

		If My.Settings.CBGeneralD = True And InStr(__domVideo, My.Settings.VideoGeneral) <> 0 Then
			ssh.VideoType = "GeneralD"
			ssh.DommeVideo = True
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



		If ssh.JumpVideo = True Then
			Do
				Application.DoEvents()
			Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

			VideoJump2Random(Nothing, Nothing)

		End If

		ssh.JumpVideo = False
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
			MessageBox.Show(Me, "No JOI Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If ssh.TeaseVideo = True Then RunFileText()
			ssh.TeaseVideo = False
			Return
		End If

		Dim JOIVideoLine As Integer = ssh.randomizer.Next(0, JOIVideos.Count)

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
			MessageBox.Show(Me, "No CH Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If ssh.TeaseVideo = True Then RunFileText()
			ssh.TeaseVideo = False
			Return
		End If

		Dim CHVideoLine As Integer = ssh.randomizer.Next(0, CHVideos.Count)

		DomWMP.Visible = True
		DomWMP.stretchToFit = True

		mainPictureBox.Visible = False

		DomWMP.URL = CHVideos(CHVideoLine)


	End Sub

#End Region


	Private Sub SettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToggleSettings.Click
		If FrmSettings.Visible = True Then
			FrmSettings.Visible = False
			BtnToggleSettings.Text = "Open Settings Menu"
		Else
			FrmSettings.Visible = True
			BtnToggleSettings.Text = "Close Settings Menu"
		End If
	End Sub



	Public Sub CensorshipTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CensorshipTimer.Tick


		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.CensorshipTick < 6 Then Return
		If chatBox.Text <> "" And ssh.CensorshipTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.CensorshipTick < 6 Then Return
		If ssh.FollowUp <> "" And ssh.CensorshipTick < 6 Then Return

		ssh.CensorshipTick -= 1


		If ssh.CensorshipTick < 1 Then


			Dim CensorLineTemp As Integer = ssh.randomizer.Next(1, 101)


			Dim CensorVideo As String

			If FrmSettings.CBCensorConstant.Checked = True Then GoTo CensorConstant

			If CensorshipBar.Visible = True Then
				CensorshipBar.Visible = False
				ssh.CensorshipTick = ssh.randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)

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
					CensorshipBarY2 = ssh.randomizer.Next(200, DomWMP.Height / 2)
				Catch
					CensorshipBarY2 = 100
				End Try

				CensorshipBar.Height = CensorshipBarY2
				CensorshipBar.Width = CensorshipBarY2 * 2.6

				'QnD-BUGFIX: if CensorshipBar.Width > DomWMP.Width then ArgumentOutOfRangeException 
				CensorshipBarX = ssh.randomizer.Next(5, If(CensorshipBar.Width > DomWMP.Width, DomWMP.Width, DomWMP.Width - CensorshipBar.Width + 1))
				CensorshipBarY = ssh.randomizer.Next(5, If(CensorshipBar.Height > DomWMP.Height, DomWMP.Height, DomWMP.Height - CensorshipBar.Height + 1))
				CensorshipBar.Location = New Point(CensorshipBarX, CensorshipBarY)



				CensorshipBar.Visible = False
				CensorshipBar.Visible = True
				CensorshipBar.BringToFront()

				ssh.CensorshipTick = ssh.randomizer.Next(FrmSettings.NBCensorShowMin.Value, FrmSettings.NBCensorShowMax.Value + 1)

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
				CensorLine = ssh.randomizer.Next(0, lines.Count)
				ssh.DomTask = lines(CensorLine)
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Censorship Sucks line from file: " &
					  CensorVideo, ex, "CensorshipTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Censorship Sucks line from file: " & CensorVideo
			End Try

			TypingDelayGeneric()

		End If

	End Sub


	Public Sub RLGLTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RLGLTimer.Tick
		' Check all Conditions before starting scripts.
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.RLGLTick < 6 Then Return
		If chatBox.Text <> "" And ssh.RLGLTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.RLGLTick < 6 Then Return
		If ssh.FollowUp <> "" And ssh.RLGLTick < 6 Then Return

		' Decrement TickCounter if Game is running.
		If ssh.RLGLGame = True Then ssh.RLGLTick -= 1

		' Run scripts only if time is over.
		If ssh.RLGLTick < 1 Then
			' Swap the BooleanValue
			ssh.RedLight = Not ssh.RedLight
			' Turn off TauntTimer when State is red.
			If ssh.RedLight Then RLGLTauntTimer.Stop()

			' Declare list to read
			Dim tempList As List(Of String)
			Dim file2read As String

			' Read File according to state and set the next timer-tick-duration.
			If ssh.RedLight Then
				'################################## RED - Light ##################################
				file2read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Red Light.txt"
				tempList = Txt2List(file2read)
				ssh.RLGLTick = ssh.randomizer.Next(FrmSettings.NBRedLightMin.Value, FrmSettings.NBRedLightMax.Value + 1)
			Else
				'################################## Green - Light ################################
				file2read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Green Light.txt"
				tempList = Txt2List(file2read)
				ssh.RLGLTick = ssh.randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
			End If

			Try
				tempList = FilterList(tempList)
				ssh.DomTask = tempList(ssh.randomizer.Next(0, tempList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid RLGL line from file: " &
					  file2read, ex, "RLGLTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid RLGL line from file: " & file2read
			End Try

			TypingDelayGeneric()
		End If
	End Sub





	Private Sub domName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles domName.Leave
		My.Settings.DomName = domName.Text
	End Sub
	Private Sub subName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subName.Leave
		My.Settings.SubName = subName.Text
	End Sub

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

	Private Sub domAvatar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles domAvatar.Click
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





	'TODO-Next: Move to proper Region
	Private Sub MediaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToggleMediaPanel.Click

		If SplitContainer1.Panel2.Height < 68 Then Return

		If PNLMediaBar.Visible = True Then
			PNLMediaBar.Visible = False
			BtnToggleMediaPanel.Text = "Show Media Panel"
		Else

			PNLMediaBar.Visible = True
			BtnToggleMediaPanel.Text = "Hide Media Panel"
		End If

		ScrollChatDown()

	End Sub

	Public Function SysKeywordClean(ByVal StringClean As String) As String

		If StringClean.Contains("#Var[") Then
			Dim VarArray As String() = StringClean.Split("]")
			For i As Integer = 0 To VarArray.Count - 1
				If VarArray(i).Contains("#Var[") Then
					StringClean = StringClean.Replace("#Var[" & GetParentheses(VarArray(i) & "]", "#Var[") & "]", GetVariable(GetParentheses(VarArray(i) & "]", "#Var[")))
				End If
			Next
		End If

		If StringClean.Contains("@RT(") Or StringClean.Contains("@RandomText(") Then
			Dim replace As String() = {"@RT(", "@RandomText("}
			Dim RandArray As String() = StringClean.Split("@")
			For a = 0 To replace.Length() - 1
				For i As Integer = 0 To RandArray.Count - 1
					RandArray(i) = "@" & RandArray(i)
					If RandArray(i).Contains(replace(a)) Then
						Dim tempString = GetParentheses(RandArray(i), replace(a), RandArray(i).Split(")").Length - 1)
						Dim startString = tempString
						tempString = tempString.Replace(",,", "###INSERT-COMMA###")
						tempString = FixCommas(tempString)
						Dim selectArray As String() = tempString.Split(",")
						For n As Integer = 0 To selectArray.Count - 1
							selectArray(n) = selectArray(n).Replace("###INSERT-COMMA###", ",")
						Next
						tempString = selectArray(ssh.randomizer.Next(0, selectArray.Count()))
						StringClean = StringClean.Replace(replace(a) & startString & ")", tempString)
					End If
				Next
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

		If Not ssh.SlideshowMain Is Nothing Then
			StringClean = StringClean.Replace("#DomName", ssh.SlideshowMain.TypeName)
		Else
			StringClean = StringClean.Replace("#DomName", ssh.tempDomName)
		End If

		StringClean = StringClean.Replace("#MainDom", My.Settings.DomName)
		StringClean = StringClean.Replace("#MainHonorific", My.Settings.SubHonorific)

		If StringClean.Contains("#Contact1Honorific") Then StringClean = StringClean.Replace("#Contact1Honorific", My.Settings.G1Honorific)

		If StringClean.Contains("#Contact2Honorific") Then StringClean = StringClean.Replace("#Contact2Honorific", My.Settings.G2Honorific)

		If StringClean.Contains("#Contact3Honorific") Then StringClean = StringClean.Replace("#Contact3Honorific", My.Settings.G3Honorific)

		If ssh.dommePresent = True Then
			StringClean = StringClean.Replace("#DomHonorific", ssh.tempHonorific)
		Else
			StringClean = StringClean.Replace("#DomHonorific", My.Settings.SubHonorific)
		End If

		StringClean = StringClean.Replace("#DomAge", FrmSettings.domageNumBox.Value)

		StringClean = StringClean.Replace("#DomLevel", FrmSettings.domlevelNumBox.Value)

		StringClean = StringClean.Replace("#DomApathy", FrmSettings.NBEmpathy.Value)

		StringClean = StringClean.Replace("#DomHairLength", LCase(FrmSettings.domhairlengthComboBox.Text))

		StringClean = StringClean.Replace("#DomHair", FrmSettings.TBDomHairColor.Text)

		StringClean = StringClean.Replace("#DomEyes", FrmSettings.TBDomEyeColor.Text)

		StringClean = StringClean.Replace("#DomCup", FrmSettings.boobComboBox.Text)

		StringClean = StringClean.Replace("#DomMoodMin", FrmSettings.NBDomMoodMin.Value)

		StringClean = StringClean.Replace("#DomMoodMax", FrmSettings.NBDomMoodMax.Value)

		StringClean = StringClean.Replace("#DomMood", ssh.DommeMood)

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

		StringClean = StringClean.Replace("#ShortName", ssh.shortName)

		StringClean = StringClean.Replace("#GlitterContact1", My.Settings.Glitter1)
		StringClean = StringClean.Replace("#Contact1", My.Settings.Glitter1)
		StringClean = StringClean.Replace("#GlitterContact2", My.Settings.Glitter2)
		StringClean = StringClean.Replace("#Contact2", My.Settings.Glitter2)
		StringClean = StringClean.Replace("#GlitterContact3", My.Settings.Glitter3)
		StringClean = StringClean.Replace("#Contact3", My.Settings.Glitter3)

		StringClean = StringClean.Replace("#CBTCockCount", ssh.CBTCockCount)
		StringClean = StringClean.Replace("#CBTBallsCount", ssh.CBTBallsCount)

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

			RandInt = ssh.randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 100 Then RandInt = 100 * Math.Round(RandInt / 100)
			StringClean = StringClean.Replace("#RandomRound100(" & OriginalFlag & ")", RandInt)

		End If

		If StringClean.Contains("#RandomRound10(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound10(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh.randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 10 Then RandInt = 10 * Math.Round(RandInt / 10)
			StringClean = StringClean.Replace("#RandomRound10(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#RandomRound5(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound5(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh.randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 5 Then RandInt = 5 * Math.Round(RandInt / 5)
			StringClean = StringClean.Replace("#RandomRound5(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#Random(") Then
			Dim randomArray As String() = StringClean.Split(")")

			For i As Integer = 0 To randomArray.Count - 1

				If randomArray(i).Contains("Random(") Then

					randomArray(i) = randomArray(i) & ")"
					Dim RandomFlag As String = GetParentheses(StringClean, "#Random(")
					Dim OriginalFlag As String = RandomFlag
					RandomFlag = FixCommas(RandomFlag)
					Dim RandInt As Integer
					Dim FlagArray() As String = RandomFlag.Split(",")

					RandInt = ssh.randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
					StringClean = StringClean.Replace("#Random(" & OriginalFlag & ")", RandInt)
				End If
			Next
		End If

		If StringClean.Contains("#DateDifference(") Then
			Dim myArray As String() = StringClean.Split("#")

			For i As Integer = 0 To myArray.Count - 1

				If myArray(i).Contains("DateDifference") Then
					Dim DateFlag As String = GetParentheses(StringClean, "DateDifference(")
					Dim OriginalFlag As String = DateFlag
					DateFlag = FixCommas(DateFlag)
					Dim DateArray() As String = DateFlag.Split(",")

					Dim DDiff As Integer

					If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
					If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
					If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
					If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
					If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) / 7
					If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
					If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

					StringClean = StringClean.Replace("#DateDifference(" & OriginalFlag & ")", DDiff)
				End If
			Next
		End If



		Dim PetNameVal As Integer = ssh.randomizer.Next(1, 5)

		If PetNameVal = 1 Then ssh.PetName = FrmSettings.petnameBox3.Text
		If PetNameVal = 2 Then ssh.PetName = FrmSettings.petnameBox4.Text
		If PetNameVal = 3 Then ssh.PetName = FrmSettings.petnameBox5.Text
		If PetNameVal = 4 Then ssh.PetName = FrmSettings.petnameBox6.Text

		If ssh.DommeMood < FrmSettings.NBDomMoodMin.Value Then
			PetNameVal = ssh.randomizer.Next(1, 3)
			If PetNameVal = 1 Then ssh.PetName = FrmSettings.petnameBox7.Text
			If PetNameVal = 2 Then ssh.PetName = FrmSettings.petnameBox8.Text
		End If


		If ssh.DommeMood > FrmSettings.NBDomMoodMax.Value Then
			PetNameVal = ssh.randomizer.Next(1, 3)
			If PetNameVal = 1 Then ssh.PetName = FrmSettings.petnameBox1.Text
			If PetNameVal = 2 Then ssh.PetName = FrmSettings.petnameBox2.Text
		End If


		StringClean = StringClean.Replace("#PetName", ssh.PetName)

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

		If ssh.AssImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Ass")
		If ssh.BoobImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Boobs")

		If StringClean.Contains("#RANDNumberLow") Then
			' ### Number between 3-5 , 5-25
			ssh.TempVal = ssh.randomizer.Next(1, 6) * FrmSettings.domlevelNumBox.Value
			If ssh.TempVal > 10 Then ssh.TempVal = 5 * Math.Round(ssh.TempVal / 5)
			If ssh.TempVal < 3 Then ssh.TempVal = 3
			StringClean = StringClean.Replace("#RNDNumberLow", ssh.TempVal)
		End If


		If StringClean.Contains("#RANDNumberHigh") Then
			' ### Number between 5-25 , 25-100
			ssh.TempVal = ssh.randomizer.Next(5, 21) * FrmSettings.domlevelNumBox.Value
			If ssh.TempVal > 10 Then ssh.TempVal = 5 * Math.Round(ssh.TempVal / 5)
			StringClean = StringClean.Replace("#RNDNumberHigh", ssh.TempVal)
		End If


		If StringClean.Contains("#RANDNumber") Then
			' ### Number between 3-10 , 5-50
			ssh.TempVal = ssh.randomizer.Next(1, 11) * FrmSettings.domlevelNumBox.Value
			If ssh.TempVal > 10 Then ssh.TempVal = 5 * Math.Round(ssh.TempVal / 5)
			If ssh.TempVal < 3 Then ssh.TempVal = 3
			StringClean = StringClean.Replace("#RNDNumber", ssh.TempVal)
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

		StringClean = StringClean.Replace("#BronzeTokens", ssh.BronzeTokens)
		StringClean = StringClean.Replace("#SilverTokens", ssh.SilverTokens)
		StringClean = StringClean.Replace("#GoldTokens", ssh.GoldTokens)

		StringClean = StringClean.Replace("#SessionEdges", ssh.SessionEdges)
		StringClean = StringClean.Replace("#SessionCBTCock", ssh.CBTCockCount)
		StringClean = StringClean.Replace("#SessionCBTBalls", ssh.CBTBallsCount)

		'StringClean = StringClean.Replace("#Sys_SubLeftEarly", My.Settings.Sys_SubLeftEarly)
		'StringClean = StringClean.Replace("#Sys_SubLeftEarlyTotal", My.Settings.Sys_SubLeftEarlyTotal)

		StringClean = StringClean.Replace("#SlideshowCount", ssh.CustomSlideshow.Count - 1)
		StringClean = StringClean.Replace("#SlideshowCurrent", ssh.CustomSlideshow.Index)
		StringClean = StringClean.Replace("#SlideshowRemaining", (ssh.CustomSlideshow.Count - 1) - ssh.CustomSlideshow.Index)

		StringClean = StringClean.Replace("#CurrentTime", Format(Now, "h:mm"))
		StringClean = StringClean.Replace("#CurrentDay", Format(Now, "dddd"))
		StringClean = StringClean.Replace("#CurrentMonth", Format(Now, "MMMMM"))
		StringClean = StringClean.Replace("#CurrentYear", Format(Now, "yyyy"))
		StringClean = StringClean.Replace("#CurrentDate", FormatDateTime(Date.Now, DateFormat.ShortDate))
		' StringClean = StringClean.Replace("#CurrentDate", Format(Now, "MM/dd/yyyy"))

		If StringClean.Contains("#RandomSlideshowCategory") Then
			Dim RanCat As New List(Of String)

			If FrmSettings.CBIHardcore.Checked = True Then RanCat.Add("Hardcore")
			If FrmSettings.CBISoftcore.Checked = True Then RanCat.Add("Softcore")
			If FrmSettings.CBILesbian.Checked = True Then RanCat.Add("Lesbian")
			If FrmSettings.CBIBlowjob.Checked = True Then RanCat.Add("Blowjob")
			If FrmSettings.CBIFemdom.Checked = True Then RanCat.Add("Femdom")
			If FrmSettings.CBILezdom.Checked = True Then RanCat.Add("Lezdom")
			If FrmSettings.CBIHentai.Checked = True Then RanCat.Add("Hentai")
			If FrmSettings.CBIGay.Checked = True Then RanCat.Add("Gay")
			If FrmSettings.CBIMaledom.Checked = True Then RanCat.Add("Maledom")
			If FrmSettings.CBICaptions.Checked = True Then RanCat.Add("Captions")
			If FrmSettings.CBIGeneral.Checked = True Then RanCat.Add("General")

			If RanCat.Count < 1 Then
				ChatAddSystemMessage("ERROR: #RandomSlideshowCategory called but no local images have been set.")
			Else
				StringClean = StringClean.Replace("#RandomSlideshowCategory", RanCat(ssh.randomizer.Next(0, RanCat.Count)))
			End If

		End If


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

			Dim t As Integer = ssh.randomizer.Next(i, x + 1)
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#EdgeHold", TConvert)
		End If

		If StringClean.Contains("#LongHold") Then
			Dim i As Integer = FrmSettings.NBLongHoldMin.Value
			Dim x As Integer = FrmSettings.NBLongHoldMax.Value
			Dim t As Integer = ssh.randomizer.Next(i, x + 1)
			t *= 60
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#LongHold", TConvert)
		End If

		If StringClean.Contains("#ExtremeHold") Then
			Dim i As Integer = FrmSettings.NBExtremeHoldMin.Value
			Dim x As Integer = FrmSettings.NBExtremeHoldMax.Value
			Dim t As Integer = ssh.randomizer.Next(i, x + 1)
			t *= 60
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#ExtremeHold", TConvert)
		End If

		StringClean = StringClean.Replace("#CurrentImage", ssh.ImageLocation)

		Dim int As Integer

		If StringClean.Contains("#TaskEdges") Then
			int = ssh.randomizer.Next(FrmSettings.NBTaskEdgesMin.Value, FrmSettings.NBTaskEdgesMax.Value + 1)
			If int > 5 Then int = 5 * Math.Round(int / 5)
			StringClean = StringClean.Replace("#TaskEdges", int)
		End If

		If StringClean.Contains("#TaskStrokes") Then
			int = ssh.randomizer.Next(FrmSettings.NBTaskStrokesMin.Value, FrmSettings.NBTaskStrokesMax.Value + 1)
			If int > 10 Then int = 10 * Math.Round(int / 10)
			StringClean = StringClean.Replace("#TaskStrokes", int)
		End If

		If StringClean.Contains("#TaskHours") Then
			int = ssh.randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1) + FrmSettings.domlevelNumBox.Value
			StringClean = StringClean.Replace("#TaskHours", int)
		End If

		If StringClean.Contains("#TaskMinutes") Then
			int = ssh.randomizer.Next(5, 13) * FrmSettings.domlevelNumBox.Value
			StringClean = StringClean.Replace("#TaskMinutes", int)
		End If

		If StringClean.Contains("#TaskSeconds") Then
			int = ssh.randomizer.Next(10, 30) * FrmSettings.domlevelNumBox.Value * ssh.randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1)
			StringClean = StringClean.Replace("#TaskSeconds", int)
		End If

		If StringClean.Contains("#TaskAmountLarge") Then
			int = (ssh.randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value) * 2
			If int > 5 Then int = 5 * Math.Round(int / 5)
			StringClean = StringClean.Replace("#TaskAmountLarge", int)
		End If

		If StringClean.Contains("#TaskAmountSmall") Then
			int = (ssh.randomizer.Next(5, 11) * FrmSettings.domlevelNumBox.Value) / 2
			If int > 5 Then int = 5 * Math.Round(int / 5)
			StringClean = StringClean.Replace("#TaskAmountSmall", int)
		End If

		If StringClean.Contains("#TaskAmount") Then
			int = ssh.randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value
			If int > 5 Then int = 5 * Math.Round(int / 5)
			StringClean = StringClean.Replace("#TaskAmount", int)
		End If

		If StringClean.Contains("#TaskStrokingTime") Then
			int = ssh.randomizer.Next(FrmSettings.NBTaskStrokingTimeMin.Value, FrmSettings.NBTaskStrokingTimeMax.Value + 1)
			int *= 60
			Dim TConvert As String = ConvertSeconds(int)
			StringClean = StringClean.Replace("#TaskStrokingTime", TConvert)
		End If

		If StringClean.Contains("#TaskHoldTheEdgeTime") Then
			int = ssh.randomizer.Next(FrmSettings.NBTaskEdgeHoldTimeMin.Value, FrmSettings.NBTaskEdgeHoldTimeMax.Value + 1)
			int *= 60
			Dim TConvert As String = ConvertSeconds(int)
			StringClean = StringClean.Replace("#TaskHoldTheEdgeTime", TConvert)
		End If

		If StringClean.Contains("#TaskCBTTime") Then
			int = ssh.randomizer.Next(FrmSettings.NBTaskCBTTimeMin.Value, FrmSettings.NBTaskCBTTimeMax.Value + 1)
			int *= 60
			Dim TConvert As String = ConvertSeconds(int)
			StringClean = StringClean.Replace("#TaskCBTTime", TConvert)
		End If



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
		Dim alreadyChecked As List(Of String) = New List(Of String)
#If TRACE Then
		Dim TS As New TraceSwitch("PoundClean", "")

		If TS.TraceVerbose Then
			Trace.WriteLine("============= PoundClean(String) =============")
			Trace.Indent()
			Trace.WriteLine(String.Format("StartValue: ""{0}""", StringClean))
		ElseIf TS.TraceInfo Then
			Trace.WriteLine(String.Format("PoundClean(String) parsing: ""{0}""", StringClean))
			Trace.Indent()
		End If

		Dim sw As New Stopwatch
		Dim StartTime As Date = Now
		sw.Start()
#End If

		Dim OrgString As String = StringClean
		Dim Recurrence As Integer = 0

		' Create Regex-Pattern to find #Keywords and exclude custom imagetags.
		Dim ExcludeKeywords As String() = {"TagGarment", "TagUnderwear", "TagTattoo", "TagSexToy", "TagFurniture"}
		Dim Pattern As String = String.Format("##*(?!{0})[\w\d\+\-_]+", Join(ExcludeKeywords, "|"))

		' Append included non-Keywords to pattern.
		Dim NonKeywordInclude As String() = {"@RT\(", "@RandomText\("}
		Pattern &= If(NonKeywordInclude.Length = 0, "", "|" & String.Join("|", NonKeywordInclude))

		Dim RegexKeyWords As New Regex(Pattern)

		Do While Recurrence < 5 AndAlso RegexKeyWords.IsMatch(StringClean)
			Recurrence += 1

#If TRACE Then
			If TS.TraceVerbose Then
				Trace.WriteLine(String.Format("Starting scan run {0} on ""{1}""", Recurrence, StringClean))
				Trace.Indent()
			End If
#End If

			StringClean = SysKeywordClean(StringClean)
#If TRACE Then
			If TS.TraceVerbose Then Trace.WriteLine(String.Format("System keywords cleaned: ""{0}""", StringClean))
#End If

			' Find all remaining #Keywords.
			Dim re As New Regex(Pattern, RegexOptions.IgnoreCase)
			Dim mc As MatchCollection = re.Matches(StringClean)

			Dim controlCustom As String = ""
			If StringClean.Contains("@CustomMode(") Then
				controlCustom = GetParentheses(StringClean, "@CustomMode(")
			End If

			For Each keyword As Match In mc
				Dim doNotContinue As Boolean = False
				'if we already checked for this vocab we avoid checking again
				For i As Integer = 0 To alreadyChecked.Count - 1
					If alreadyChecked(i) = keyword.Value Then
						doNotContinue = True
						Exit For
					End If
				Next

				If Not doNotContinue Then
#If TRACE Then
					If TS.TraceVerbose Then Trace.WriteLine(String.Format("Applying vocabulary: ""{0}""", keyword.Value))
#End If

					Dim filepath As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\" & keyword.Value & ".txt"

					If Directory.Exists(Path.GetDirectoryName(filepath)) AndAlso File.Exists(filepath) Then
						Dim lines As List(Of String) = Txt2List(filepath)


						lines = FilterList(lines)
						If controlCustom.Contains(keyword.ToString) Then customVocabLines = lines
						If ssh.addAnswerList Then
							For Each s As String In lines
								s = PoundClean(s)
								ssh.checkAnswers.addToAnswerList(s)
							Next
						End If
						If ssh.addResponseList Then
							For Each s As String In lines
								s = PoundClean(s)
								StringClean &= "," & s
							Next
						End If
						If lines.Count > 0 Then

							Dim PoundVal As Integer = ssh.randomizer.Next(0, lines.Count)

							StringClean = StringClean.Replace(keyword.Value, lines(PoundVal))

						Else
							'StringClean = StringClean.Replace(keyword.Value, "<font color=""DarkOrange"">" & keyword.Value & "</font>")
							Dim wrong As String = keyword.Value
							wrong = wrong.Remove(0, 1)
							wrong = "Vocab Error: " & wrong
							If My.Settings.CBOutputErrors = True Then
								StringClean = StringClean.Replace(keyword.Value, "<font color=""DarkOrange"">" & wrong & "</font>")
								ssh.KeywordError = "<font color=""DarkOrange"">" & wrong & "</font>"
							Else
								StringClean = StringClean.Replace(keyword.Value, "")
							End If
						End If

						'Try
						'lines = FilterList(lines)
						'Dim PoundVal As Integer = ssh.randomizer.Next(0, lines.Count)
						'StringClean = StringClean.Replace(keyword.Value, lines(PoundVal))
						'Catch ex As Exception
						'Log.WriteError("Error Processing vocabulary file:  " & filepath, ex,
						' "Tease AI did not return a valid line while parsing vocabulary file.")
						'StringClean = "ERROR: Tease AI did not return a valid line while parsing vocabulary file: " & keyword.Value
						'End Try

					Else
						'StringClean = StringClean.Replace(keyword.Value, "<font color=""red"">" & keyword.Value & "</font>")

						Dim wrong As String = keyword.Value

						If UCase(wrong) = "#NULL" Then
							StringClean = StringClean.Replace(keyword.Value, "")
						Else
							wrong = wrong.Remove(0, 1)
							wrong = "Missing Vocab: " & wrong
							StringClean = StringClean.Replace(keyword.Value, "<font color=""red"">" & wrong & "</font>")
							ssh.KeywordError = "<font color=""red"">" & wrong & "</font>"
							Dim lazytext As String = "Unable to locate vocabulary file: """ & keyword.Value & """"
							Log.WriteError(lazytext, New Exception(lazytext), "PoundClean(String)")
						End If



					End If
				End If
				alreadyChecked.Add(keyword.Value)
			Next

#If TRACE Then
			Trace.Unindent()
#End If
		Loop

		If RegexKeyWords.IsMatch(StringClean) Then
#If TRACE Then
			If TS.TraceError Then
				Trace.WriteLine("PoundClean(String): Stopping scan, maximum allowed scan depth reached.")
				Trace.Indent()
				Trace.WriteLine(String.Format("StartValue: ""{0}""", OrgString))
				Trace.WriteLine(String.Format("EndValue:   ""{0}""", StringClean))
				Trace.Unindent()
			End If
#End If
			Log.WriteError("Maximum allowed Vocabulary depth reached for line:" & OrgString & vbCrLf &
				  "Aborted Cleaning at: " & StringClean,
				  New StackOverflowException("PoundClean infinite loop protection"), "PoundClean(String)")
		Else
#If TRACE Then
			If TS.TraceVerbose Then
				Trace.WriteLine(String.Format("EndValue: ""{0}""", StringClean))
				Trace.WriteLine(String.Format("Duration: {0}ms", (Now - StartTime).TotalMilliseconds.ToString))
			End If
#End If

		End If

#If TRACE Then
		Trace.Unindent()
#End If
		Return StringClean
	End Function

	Public Function CommandClean(ByVal StringClean As String, Optional ByVal TaskClean As Boolean = False) As String

		Debug.Print("Stringclean Intro = " & StringClean)


		If TaskClean = True Then
			Debug.Print("Tasks CommandClean")
			GoTo TaskCleanSet
		End If

		If StringClean.Contains("@FollowUp(") And ssh.FollowUp = "" Then
			StringClean = StringClean.Trim
			ssh.FollowUp = GetParentheses(StringClean, "@FollowUp(", StringClean.Split(")").Count - 1)
			'if there is a leftover ) (might happen in very complex followUp) we remove it
			If ssh.FollowUp.Trim.EndsWith(")") Then ssh.FollowUp = ssh.FollowUp.Remove(ssh.FollowUp.LastIndexOf(")"c), 1)
			StringClean = StringClean.Replace("@FollowUp(" & ssh.FollowUp & ")", "")
		End If


		If StringClean.Contains("@FollowUp") And ssh.FollowUp = "" Then

			Dim FollowTemp As String
			Dim TSStartIndex As Integer
			Dim TSEndIndex As Integer

			TSStartIndex = StringClean.IndexOf("@FollowUp") + 9
			TSEndIndex = StringClean.IndexOf("@FollowUp") + 11

			FollowTemp = StringClean.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim

			Dim FollowVal As Integer

			FollowVal = Val(FollowTemp)

			ssh.TempVal = ssh.randomizer.Next(1, 101)

			Dim FollowLineTemp As String
			StringClean = StringClean.Trim
			FollowLineTemp = GetParentheses(StringClean, "@FollowUp" & FollowTemp & "(", StringClean.Split(")").Count - 1)
			'if there is a leftover ) (might happen in very complex followUp) we remove it
			If FollowLineTemp.Trim.EndsWith(")") Then FollowLineTemp = FollowLineTemp.Remove(FollowLineTemp.LastIndexOf(")"c), 1)

			If ssh.TempVal <= FollowVal Then ssh.FollowUp = FollowLineTemp

			StringClean = StringClean.Replace("@FollowUp" & FollowTemp & "(" & FollowLineTemp & ")", "")
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
			If ssh.SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh.LockImage = False
			StringClean = StringClean.Replace("@UnlockImages", "")
		End If

		If StringClean.Contains("@DommeTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DommeTag(")
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True)
				If ssh.DommeImageSTR = String.Empty Then ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Or")
			Else
				ssh.DommeImageSTR = ""
			End If
			' Clean the Text.
			StringClean = StringClean.Replace("@DommeTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@DommeTagOr(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DommeTagOr(")
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Or")
			Else
				ssh.DommeImageSTR = ""
			End If
			' Clean the Text.
			StringClean = StringClean.Replace("@DommeTagOr(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@DommeTagAny(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DommeTagAny(")
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Any")
			Else
				ssh.DommeImageSTR = ""
			End If
			' Clean the Text.
			StringClean = StringClean.Replace("@DommeTagAny(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@NewDommeSlideshow") Then
			'TODO: Add Support for contact slideshows.
			ssh.newSlideshow = True
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@NewDommeSlideshow", "")
		End If

		If StringClean.Contains("@NewContact1Slideshow") Then
			If ssh.contact1Present Then ssh.SlideshowContact1.LoadNew(False)
			StringClean = StringClean.Replace("@NewContact1Slideshow", "")
		End If

		If StringClean.Contains("@NewContact2Slideshow") Then
			If ssh.contact2Present Then ssh.SlideshowContact2.LoadNew(False)
			StringClean = StringClean.Replace("@NewContact2Slideshow", "")
		End If

		If StringClean.Contains("@NewContact3Slideshow") Then
			If ssh.contact3Present Then ssh.SlideshowContact3.LoadNew(False)
			StringClean = StringClean.Replace("@NewContact3Slideshow", "")
		End If

		If StringClean.Contains("@DomTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DomTag(")
			' Try to get a Domme Image for the given Tags.
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True)
				If ssh.DommeImageSTR = String.Empty Then ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Or")
			Else
				ssh.DommeImageSTR = ""
			End If

			StringClean = StringClean.Replace("@DomTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@DomTagOr(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DomTagOr(")
			' Try to get a Domme Image for the given Tags.
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Or")
			Else
				ssh.DommeImageSTR = ""
			End If
			StringClean = StringClean.Replace("@DomTagOr(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@DomTagAny(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DomTagAny(")
			' Try to get a Domme Image for the given Tags.
			'QND-Implemented: ContactData.GetTaggedImage
			If ssh.contactToUse IsNot Nothing Then
				ssh.DommeImageSTR = GetLocalImage(TagFlag, True, "Any")
			Else
				ssh.DommeImageSTR = ""
			End If
			StringClean = StringClean.Replace("@DomTagAny(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@ImageTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@ImageTag(")
			ShowImage(GetLocalImage(TagFlag), False)
			StringClean = StringClean.Replace("@ImageTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@ImageTagOr(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@ImageTagOr(")
			ShowImage(GetLocalImage(TagFlag,, "Or"), False)
			StringClean = StringClean.Replace("@ImageTagOr(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@ImageTagAny(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@ImageTagAny(")
			ShowImage(GetLocalImage(TagFlag,, "Any"), False)
			StringClean = StringClean.Replace("@ImageTagAny(" & TagFlag & ")", "")
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
				Trace.WriteLine("failed to execute Command: @ShowLocalImage(" & LocalFlag & ") No images found.")
			End If

			ShowImage(tmpImgToShow, False)

			StringClean = StringClean.Replace("@ShowLocalImage(" & GetParentheses(StringClean, "@ShowLocalImage(") & ")", "")
		End If
		'----------------------------------------
		' @ShowLocalImage()- End
		'----------------------------------------

		If StringClean.Contains("@ShowLocalImage") Then
			ShowImage(GetRandomImage(ImageSourceType.Local), False)
			StringClean = StringClean.Replace("@ShowLocalImage", "")
		End If

		'===============================================================================
		'								@ShowTaggedImage
		'===============================================================================
		If StringClean.Contains("@ShowTaggedImage") OrElse StringClean.Contains("@Tag") Then

			ChatAddWarning("@ShowTaggedImage and all @Tag- instructions are marked as obsolete. Use @ImageTag() instead.")

			Dim Tags As List(Of String) = StringClean.Split() _
				  .Select(Function(s) s.Trim()) _
				  .Where(Function(w) CType(w, String).StartsWith("@Tag")).ToList

			Dim FoundString As String = GetLocalImage(Tags, Nothing)

			'TODO: @ShowTaggedImage - Add a dedicated ErrorImage when there are no tagged images.
			If FoundString = String.Empty Then FoundString = pathImageErrorNoLocalImages

			ssh.JustShowedBlogImage = True
			ShowImage(FoundString, False)

			Tags.ForEach(Sub(x) StringClean = StringClean.Replace(x, ""))
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
			ShowImage(checkForImage(ImageToShow), False)
			StringClean = StringClean.Replace("@ShowImage[" & GetParentheses(StringClean, "@ShowImage[") & "]", "")
		End If

		If StringClean.Contains("@ShowImage") Then
			ShowImage(GetRandomImage(), False)
			StringClean = StringClean.Replace("@ShowImage", "")
		End If
		'----------------------------------------
		' @ShowImage[]- End
		'----------------------------------------
		'===============================================================================
		'								Legacy TnA-Slideshow
		'===============================================================================
		' TODO: Rework TnA-Game to use CustomSlideshow instead of its own code.
		' @TnAFastSlides starts a fast slideshow with Boobs and Butts. Use with local images, to avoid the download delay. otherwise the images will stutter.
		' @TnASlides starts a slideshow with boobs and butts. the Speed is fixed at 1 image per second.
		' @TnASlowSlides starts a slideshow with boobs and butts. the Speed is fixed at 1 image per 5 seconds.

		If StringClean.Contains("@TnAFastSlides") Or StringClean.Contains("@TnASlowSlides") Or StringClean.Contains("@TnASlides") Then
			If StringClean.Contains("@TnAFastSlides") Then TnASlides.Interval = 334
			If StringClean.Contains("@TnASlides") Then TnASlides.Interval = 1000
			If StringClean.Contains("@TnASlowSlides") Then TnASlides.Interval = 5000

			Try
				ssh.BoobList.Clear()
				ssh.AssList.Clear()

				If ssh.BoobList.Count < 1 Then ssh.BoobList = GetImageData(ImageGenre.Boobs).ToList
				If ssh.AssList.Count < 1 Then ssh.AssList = GetImageData(ImageGenre.Butt).ToList

				If ssh.BoobList.Count < 1 Then Throw New Exception("No Boobs-images found.")
				If ssh.AssList.Count < 1 Then Throw New Exception("No Butt-images found.")

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
			If ssh.AssImage = True Then ssh.FileGoto = "(Butt)"
			If ssh.BoobImage = True Then ssh.FileGoto = "(Boobs)"
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckTnA", "")
		End If

		If StringClean.Contains("@StopTnA") Then
			TnASlides.Stop()
			ssh.BoobList.Clear()
			ssh.BoobImage = False
			ssh.AssList.Clear()
			ssh.AssImage = False
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

			ssh.CustomSlideshow.Clear()

			If SlideFlag.ToLower.Contains("hardcore") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Hardcore).ToList(), ImageGenre.Hardcore)
			End If

			If SlideFlag.ToLower.Contains("softcore") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Softcore).ToList(), ImageGenre.Softcore)
			End If

			If SlideFlag.ToLower.Contains("lesbian") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Lesbian).ToList(), ImageGenre.Lesbian)
			End If

			If SlideFlag.ToLower.Contains("blowjob") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Blowjob).ToList(), ImageGenre.Blowjob)
			End If

			If SlideFlag.ToLower.Contains("femdom") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Femdom).ToList(), ImageGenre.Femdom)
			End If

			If SlideFlag.ToLower.Contains("lezdom") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Lezdom).ToList(), ImageGenre.Lezdom)
			End If

			If SlideFlag.ToLower.Contains("hentai") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Hentai).ToList(), ImageGenre.Hentai)
			End If

			If SlideFlag.ToLower.Contains("gay") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Gay).ToList(), ImageGenre.Gay)
			End If

			If SlideFlag.ToLower.Contains("maledom") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Maledom).ToList(), ImageGenre.Maledom)
			End If

			If SlideFlag.ToLower.Contains("captions") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Captions).ToList(), ImageGenre.Captions)
			End If

			If SlideFlag.ToLower.Contains("general") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.General).ToList(), ImageGenre.General)
			End If

			If SlideFlag.ToLower.Contains("boob") Or LCase(SlideFlag).Contains("boobs") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Boobs).ToList(), ImageGenre.Boobs)
			End If

			If SlideFlag.ToLower.Contains("butt") Or LCase(SlideFlag).Contains("butts") Then
				ssh.CustomSlideshow.AddRange(GetImageData(ImageGenre.Butt).ToList(), ImageGenre.Butt)
			End If


			CustomSlideshowTimer.Interval = 1000
			If LCase(SlideFlag).Contains("slow") Then CustomSlideshowTimer.Interval = 5000
			If LCase(SlideFlag).Contains("fast") Then CustomSlideshowTimer.Interval = 500


			StringClean = StringClean.Replace("@Slideshow(" & SlideFlag & ")", "")
		End If

		If StringClean.Contains("@SlideshowOn") Then
			If ssh.CustomSlideshow.Count > 0 Then
				ssh.CustomSlideEnabled = True
				CustomSlideshowTimer.Start()
			End If
			StringClean = StringClean.Replace("@SlideshowOn", "")
		End If

		If StringClean.Contains("@SlideshowOff") Then
			ssh.CustomSlideEnabled = False
			CustomSlideshowTimer.Stop()
			StringClean = StringClean.Replace("@SlideshowOff", "")
		End If

		If StringClean.Contains("@SlideshowFirst") Then
			ssh.CustomSlideEnabled = True
			ShowImage(ssh.CustomSlideshow.FirstImage, False)
			StringClean = StringClean.Replace("@SlideshowFirst", "")
		End If

		If StringClean.Contains("@SlideshowLast") Then
			ssh.CustomSlideEnabled = True
			ShowImage(ssh.CustomSlideshow.LastImage, False)
			StringClean = StringClean.Replace("@SlideshowLast", "")
		End If

		If StringClean.Contains("@SlideshowNext") Then
			ssh.CustomSlideEnabled = True
			ShowImage(ssh.CustomSlideshow.NextImage, False)
			StringClean = StringClean.Replace("@SlideshowNext", "")
		End If

		If StringClean.Contains("@SlideshowPrevious") Then
			ssh.CustomSlideEnabled = True
			ShowImage(ssh.CustomSlideshow.PreviousImage, False)
			StringClean = StringClean.Replace("@SlideshowPrevious", "")
		End If

		If StringClean.Contains("@GotoSlideshow") Then
			Dim ImageString As String = ssh.CustomSlideshow.CurrentImage

			If ImageString IsNot Nothing OrElse ImageString = "" Then
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Hardcore Then ssh.FileGoto = "(Hardcore)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Softcore Then ssh.FileGoto = "(Softcore)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Lesbian Then ssh.FileGoto = "(Lesbian)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Blowjob Then ssh.FileGoto = "(Blowjob)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Femdom Then ssh.FileGoto = "(Femdom)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Lezdom Then ssh.FileGoto = "(Lezdom)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Hentai Then ssh.FileGoto = "(Hentai)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Gay Then ssh.FileGoto = "(Gay)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Maledom Then ssh.FileGoto = "(Maledom)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Captions Then ssh.FileGoto = "(Captions)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.General Then ssh.FileGoto = "(General)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Boobs Then ssh.FileGoto = "(Boobs)"
				If ssh.CustomSlideshow(ImageString) = ImageGenre.Butt Then ssh.FileGoto = "(Butts)"

				Debug.Print("GotoSlideshow called, FileGoto = " & ssh.FileGoto)

				ssh.SkipGotoLine = True
				GetGoto()
			Else
				Dim lazytext As String = "@GotoSlideshow can't determine the current CustomSlideshow image. Please make sure to start it before using @GotoSlideshow."
				Log.WriteError(lazytext, New NullReferenceException(lazytext), "@GotoSlideshow")
			End If

			StringClean = StringClean.Replace("@GotoSlideshow", "")
		End If
		'----------------------------------------
		' Slideshow - End
		'----------------------------------------
		' This Command will not work in the same line, because the Images are loaded async and not available yet.
		If StringClean.Contains("@CurrentImage") Then
			StringClean = StringClean.Replace("@CurrentImage", ssh.ImageLocation)
		End If

		' The @LockImages Commnd prevents the Domme Slideshow from moving forward or back when set to "Tease" or "Timed". Manual operation of Domme Slideshow images is still allowed,
		' and pictures displayed through other means will still work. Images are automatically unlocked whenever Tease AI moves into a Link script, an End script, any Interrupt occurs
		' (including Long Edge and Start Stroking) or when the sub gives up.

		If StringClean.Contains("@LockImages") Then
			ssh.LockImage = True
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
			Dim ChanceArray As String() = StringClean.Split(")")

			For i As Integer = 0 To ChanceArray.Count - 1
				If ChanceArray(i).Contains("@Chance") Then

					Dim ChanceTemp As String
					Dim TSStartIndex As Integer
					Dim TSEndIndex As Integer

					TSStartIndex = StringClean.IndexOf("@Chance") + 7
					TSEndIndex = StringClean.IndexOf("@Chance") + 9

					ChanceTemp = StringClean.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim

					Dim ChanceVal As Integer

					ChanceVal = Val(ChanceTemp)

					ssh.TempVal = ssh.randomizer.Next(1, 101)

					Dim ChanceString As String = StringClean.Substring(TSStartIndex + 2, StringClean.Length - (TSStartIndex + 2)).Trim

					Dim ChanceSplit As String() = Split(ChanceString, ")")


					Debug.Print("CHanceCheck = " & "@Chance" & ChanceTemp & ChanceSplit(0) & ")")
					StringClean = StringClean.Replace("@Chance" & ChanceTemp & ChanceSplit(0) & ")", "")

					If ssh.TempVal <= ChanceVal Then

						ssh.FileGoto = ChanceSplit(0) & ")"
						ssh.SkipGotoLine = True

						If ssh.YesOrNo = True Then
							GetGotoChat()
						Else
							GetGoto()
						End If
						Exit For
					End If
				End If
			Next
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
							ssh.SkipGotoLine = True
							ssh.FileGoto = FlagArray(1)
							GetGoto()
						End If

					Else

						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & CheckFlag) Or
						 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & CheckFlag) Then
							ssh.SkipGotoLine = True
							ssh.FileGoto = CheckFlag
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

				If VariableExists(VarName) Then
					Integer.TryParse(GetVariable(VarName), Val1)

					SCGotVarSplit(0) = ""

					SCGotVar = Join(SCGotVarSplit)

					SCGotVar = SCGotVar.Replace("=[", "")
					SCGotVar = SCGotVar.Replace(" ", "")

					Dim VarValue As Integer = Val(SCGotVar)

					Val1 = VarValue * Math.Round(Val1 / VarValue)

					SetVariable(VarName, Val1)

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

					ChangeFlag = ChangeArray(i).Substring(ChangeStart, ChangeArray(i).Length - ChangeStart)
					Dim VarName As String = ChangeFlag.Split("]")(0)
					Dim ArgVal1 As String = ChangeFlag.Split("]")(1)
					Dim ArgVal2 As String = ChangeFlag.Split("]")(2)
					Dim mathOperator As String = ChangeFlag.Split("]")(2).Substring(0, 1)

					ChangeArray(i) = ChangeArray(i).Replace("@ChangeVar[" & VarName & "]" & ArgVal1 & "]" & ArgVal2 & "]", "")

					VarName = VarName.Replace("@ChangeVar[", "")
					ArgVal1 = ArgVal1.Replace("=[", "")
					ArgVal2 = ArgVal2.Replace("+[", "")
					ArgVal2 = ArgVal2.Replace("-[", "")
					ArgVal2 = ArgVal2.Replace("*[", "")
					ArgVal2 = ArgVal2.Replace("/[", "")

					ChangeVariable(VarName, ArgVal1, mathOperator, ArgVal2)

				End If
			Next

			StringClean = Join(ChangeArray)
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

					If IsNumeric(SCGotVar) = False Then
						If VariableExists(SCGotVar) Then
							SCGotVar = GetVariable(SCGotVar)
						Else
							SCGotVar = 0
						End If
					Else
						SCGotVar = Val(SCGotVar)
					End If
					SetVariable(VarName, SCGotVar)
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

					SetVariable(FlagArray(0), FormatDateTime(SetDate, DateFormat.GeneralDate))

					Debug.Print("CheckArray(i) = " & CheckArray(i))

					' CheckArray(i) = CheckArray(i).Replace("@SetDate(" & OriginalCheck, "")

					StringClean = StringClean.Replace("@SetDate(" & OriginalCheck & ")", "")
				End If
			Next
			'StringClean = Join(CheckArray, Nothing)
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
					If UCase(TokenArray(i)).Contains("B") Then ssh.BronzeTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("S") Then ssh.SilverTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("G") Then ssh.GoldTokens += TokenAdd
				Next
			Else
				TokenAdd = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then ssh.BronzeTokens += TokenAdd
				If UCase(TokenFlag).Contains("S") Then ssh.SilverTokens += TokenAdd
				If UCase(TokenFlag).Contains("G") Then ssh.GoldTokens += TokenAdd
			End If

			My.Settings.BronzeTokens = ssh.BronzeTokens
			My.Settings.SilverTokens = ssh.SilverTokens
			My.Settings.GoldTokens = ssh.GoldTokens


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
					If UCase(TokenArray(i)).Contains("B") Then ssh.BronzeTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("S") Then ssh.SilverTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("G") Then ssh.GoldTokens -= TokenRemove
				Next
			Else
				TokenRemove = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then ssh.BronzeTokens -= TokenRemove
				If UCase(TokenFlag).Contains("S") Then ssh.SilverTokens -= TokenRemove
				If UCase(TokenFlag).Contains("G") Then ssh.GoldTokens -= TokenRemove
			End If

			If ssh.BronzeTokens < 0 Then ssh.BronzeTokens = 0
			If ssh.SilverTokens < 0 Then ssh.SilverTokens = 0
			If ssh.GoldTokens < 0 Then ssh.GoldTokens = 0

			My.Settings.BronzeTokens = ssh.BronzeTokens
			My.Settings.SilverTokens = ssh.SilverTokens
			My.Settings.GoldTokens = ssh.GoldTokens


			StringClean = StringClean.Replace("@RemoveTokens(" & TokenFlag & ")", "")
		End If

		If StringClean.Contains("@Add1Token") Then
			ssh.BronzeTokens += 1
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 1 Bronze token!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add1Token", "")
		End If

		If StringClean.Contains("@Add3Tokens") Then
			ssh.BronzeTokens += 3
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 3 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add3Tokens", "")
		End If

		If StringClean.Contains("@Add5Tokens") Then
			ssh.BronzeTokens += 5
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 5 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add5Tokens", "")
		End If

		If StringClean.Contains("@Add10Tokens") Then
			ssh.BronzeTokens += 10
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 10 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add10Tokens", "")
		End If

		If StringClean.Contains("@Add25Tokens") Then
			ssh.BronzeTokens += 25
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 25 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add25Tokens", "")
		End If

		If StringClean.Contains("@Add50Tokens") Then
			ssh.BronzeTokens += 50
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 50 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Add100Tokens") Then
			ssh.BronzeTokens += 100
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has given you 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Remove100Tokens") Then
			ssh.BronzeTokens -= 100
			My.Settings.BronzeTokens = ssh.BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, ssh.tempDomName & " has taken 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Remove100Tokens", "")
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

				Dim TotalSeconds As Integer = ssh.randomizer.Next(Seconds1, Seconds2 + 1)

				Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)

				SetDate = DateAdd(DateInterval.Second, TotalSeconds, SetDate)
				SetVariable("SYS_OrgasmRestricted", FormatDateTime(SetDate, DateFormat.GeneralDate))

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

				SetVariable("SYS_OrgasmRestricted", FormatDateTime(SetDate, DateFormat.GeneralDate))

			End If
			ssh.OrgasmRestricted = True
			StringClean = StringClean.Replace("@RestrictOrgasm(" & GetParentheses(StringClean, "@RestrictOrgasm(") & ")", "")
		End If

		If StringClean.Contains("@RestrictOrgasm") Then
			ssh.OrgasmRestricted = True
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
						ssh.SkipGotoLine = True
						ssh.FileGoto = DateArray(DateArray.Count - 1).Replace(")", "")
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
			If StringClean.Contains("]AND[") Then StringClean = StringClean.Replace("]AND[", "]And[")
			If StringClean.Contains("]OR[") Then StringClean = StringClean.Replace("]OR[", "]Or[")
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
						ssh.FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh.SkipGotoLine = True
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
						ssh.FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh.SkipGotoLine = True
						GetGoto()
					End If

				Else

					If GetIf("[" & GetParentheses(SCGotVar, "@If[", 2) & "]") = True Then
						ssh.FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh.SkipGotoLine = True
						GetGoto()
					End If

				End If

			Loop Until Not StringClean.Contains("If")
		End If

		' The @InputVar[] stops script progression and waits for the user to input his next message. Whatever the user types next will be saved as a Variable named whatever you specify in the brackets.
		' For example, if the script's line was "What's your favorite food? @InputVar[FavoriteFood]", and the user typed "lo mein", then "lo mein" would be saved as the Variable "FavoriteFood". If the
		' user has checked "Show Icon During Input Questions" in the General Settings tab, then the domme's question will be accompanied by a small question mark icon to let the user know that their next
		' response will be saved verbatim. @InputVar[] will pause Linear Scripts, as well as countdowns and taunts for Stroking, Edging and Holding The Edge.

		If StringClean.Contains("@InputVar[") Then

			ssh.InputString = GetParentheses(StringClean, "@InputVar[").Replace("]", "")
			ssh.InputFlag = True
			If FrmSettings.CBInputIcon.Checked = True Then ssh.InputIcon = True

			StringClean = StringClean.Replace("@InputVar[" & ssh.InputString & "]", "")
		End If


		' The @DislikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Disliked" list located in [Tease AI Root Directory]\Images\System\DislikedImageURLS.txt

		If StringClean.Contains("@DislikeBlogImage") Then
			If ssh.ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & ssh.ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", ssh.ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@DislikeBlogImage", "")
			End If
		End If

		' The @LikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Liked" list located in [Tease AI Root Directory]\Images\System\LikedImageURLS.txt

		If StringClean.Contains("@LikeBlogImage") Then
			If ssh.ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & ssh.ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", ssh.ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@LikeBlogImage", "")
			End If
		End If

		Debug.Print("SubStroking = " & ssh.SubStroking)
		Debug.Print("SubEdging = " & ssh.SubEdging)
		Debug.Print("SubHoldingEdge = " & ssh.SubHoldingEdge)

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘┴└─

		If StringClean.Contains("@StrokeFaster") Then
			ssh.StrokeFaster = True
			StringClean = StringClean.Replace("@StrokeFaster", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘┴└─

		If StringClean.Contains("@StrokeSlower") Then
			ssh.StrokeSlower = True
			StringClean = StringClean.Replace("@StrokeSlower", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeFastest") Then
			ssh.StrokeFastest = True
			StringClean = StringClean.Replace("@StrokeFastest", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeSlowest") Then
			ssh.StrokeSlowest = True
			StringClean = StringClean.Replace("@StrokeSlowest", "")
		End If


		If StringClean.Contains("@StartStroking") Then
			If Not VariableExists("SYS_FirstRun") Then
				Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)
				SetVariable("SYS_FirstRun", SetDate)
			End If

			SetVariable("SYS_StrokeRound", Val(GetVariable("SYS_StrokeRound")) + 1)

			If FrmSettings.TBWebStart.Text <> "" Then
				Try
					FrmSettings.WebToy.Navigate(FrmSettings.TBWebStart.Text)
				Catch
				End Try
			End If

			If StringClean.Contains("@Contact1") Then
				ssh.Contact1Stroke = True
			ElseIf StringClean.Contains("@Contact2") Then
				ssh.Contact2Stroke = True
			ElseIf StringClean.Contains("@Contact3") Then
				ssh.Contact3Stroke = True
			ElseIf StringClean.Contains("@RandomContact") Then
				Dim casual As Integer = 0
				casual = ssh.randomizer.Next(0, ssh.currentlyPresentContacts.Count)
				Select Case ssh.currentlyPresentContacts(casual)
					Case ssh.SlideshowContact1.TypeName
						ssh.Contact1Stroke = True
					Case ssh.SlideshowContact2.TypeName
						ssh.Contact2Stroke = True
					Case ssh.SlideshowContact3.TypeName
						ssh.Contact3Stroke = True
					Case Else
				End Select
			End If

			ssh.AskedToGiveUpSection = False
			ssh.AskedToSpeedUp = False
			ssh.AskedToSlowDown = False
			ssh.BeforeTease = False
			ssh.SubStroking = True
			ssh.ShowModule = False
			'StrokeCycle = -1
			If ssh.StartStrokingCount = 0 Then ssh.FirstRound = True
			'If FirstRound = True Then My.Settings.Sys_SubLeftEarly += 1
			If ssh.FirstRound = True Then SetVariable("SYS_SubLeftEarly", Val(GetVariable("SYS_SubLeftEarly")) + 1)
			ssh.StartStrokingCount += 1
			StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)

			If ssh.WorshipMode = True Then
				StrokePace = NBMinPace.Value
				ssh.StrokeSlowest = True
			End If

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then ssh.StrokeTick = ssh.randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh.StrokeTick = ssh.randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh.StrokeTick = ssh.randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh.StrokeTick = ssh.randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh.StrokeTick = ssh.randomizer.Next(5, 11) * 60

				If ssh.WorshipMode = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then ssh.StrokeTick = 180
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh.StrokeTick = 240
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh.StrokeTick = 360
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh.StrokeTick = 480
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh.StrokeTick = 600
				End If

			Else
				ssh.StrokeTick = ssh.randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				If ssh.WorshipMode = True Then ssh.StrokeTick = FrmSettings.NBTauntCycleMax.Value * 60
			End If
			ssh.StrokeTauntTick = ssh.randomizer.Next(11, 21)
			'StrokeThread = New Thread(AddressOf StrokeLoop)
			'StrokeThread.IsBackground = True
			'StrokeThread.SetApartmentState(ApartmentState.STA)
			'StrokeThread.Start()
			StrokeTimer.Start()
			StrokeTauntTimer.Start()
			StringClean = StringClean.Replace("@StartStroking", "")
		End If

		If StringClean.Contains("@StartTaunts") Then
			ssh.AskedToGiveUpSection = False
			ssh.AskedToSpeedUp = False
			ssh.AskedToSlowDown = False
			ssh.BeforeTease = False
			ssh.SubStroking = True
			ssh.ShowModule = False
			'StrokeCycle = -1
			If ssh.StartStrokingCount = 0 Then ssh.FirstRound = True
			ssh.StartStrokingCount += 1
			' github patch StrokePace = 0
			' github patch StrokePaceTimer.Interval = StrokePace

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then ssh.StrokeTick = ssh.randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh.StrokeTick = ssh.randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh.StrokeTick = ssh.randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh.StrokeTick = ssh.randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh.StrokeTick = ssh.randomizer.Next(5, 11) * 60
			Else
				ssh.StrokeTick = ssh.randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
			End If
			ssh.StrokeTauntTick = ssh.randomizer.Next(11, 21)
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
			If ssh.Contact1Stroke = True Then
				StringClean = StringClean & "@Contact1"
				ssh.Contact1Stroke = False
			End If
			If ssh.Contact2Stroke = True Then
				StringClean = StringClean & "@Contact2"
				ssh.Contact2Stroke = False
			End If
			If ssh.Contact3Stroke = True Then
				StringClean = StringClean & "@Contact3"
				ssh.Contact3Stroke = False
			End If
			ssh.AskedToSpeedUp = False
			ssh.AskedToSlowDown = False
			ssh.SubStroking = False
			ssh.SubEdging = False
			ssh.SubHoldingEdge = False
			ssh.WorshipMode = False
			ssh.WorshipTarget = ""
			ssh.LongHold = False
			ssh.ExtremeHold = False
			ssh.HoldTaunts = False
			ssh.LongTaunts = False
			ssh.ExtremeTaunts = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			StrokePace = 0
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopStroking", "")
		End If

		If StringClean.Contains("@StopTaunts") Then
			ssh.AskedToSpeedUp = False
			ssh.AskedToSlowDown = False
			ssh.SubStroking = False
			ssh.SubEdging = False
			ssh.SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopTaunts", "")
		End If


		If StringClean.Contains("@LongHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@LongHold("))
			ssh.TempVal = ssh.randomizer.Next(0, 101)
			If ssh.TempVal <= HoldInt Then ssh.LongHold = True

			StringClean = StringClean.Replace("@LongHold(" & GetParentheses(StringClean, "@LongHold(") & ")", "")
		End If

		If StringClean.Contains("@ExtremeHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@ExtremeHold("))
			ssh.TempVal = ssh.randomizer.Next(0, 101)
			If ssh.TempVal <= HoldInt Then ssh.ExtremeHold = True

			StringClean = StringClean.Replace("@ExtremeHold(" & GetParentheses(StringClean, "@ExtremeHold(") & ")", "")
		End If

		If StringClean.Contains("@LongHold") Then
			ssh.LongHold = True
			StringClean = StringClean.Replace("@LongHold", "")
		End If

		If StringClean.Contains("@ExtremeHold") Then
			ssh.ExtremeHold = True
			StringClean = StringClean.Replace("@ExtremeHold", "")
		End If

		If StringClean.Contains("@MultipleEdges(") Then
			If StringClean.Contains("@Edg") Then

				Dim EdgeFlag As String = GetParentheses(StringClean, "@MultipleEdges(")
				EdgeFlag = FixCommas(EdgeFlag)
				Dim EdgeArray As String() = EdgeFlag.Split(",")

				If EdgeArray.Count = 3 Then

					If ssh.randomizer.Next(1, 101) < Val(EdgeArray(2)) Then
						ssh.MultipleEdges = True
						ssh.MultipleEdgesAmount = Val(EdgeArray(0))
						ssh.MultipleEdgesInterval = Val(EdgeArray(1))
					End If

				Else

					ssh.MultipleEdges = True
					ssh.MultipleEdgesAmount = Val(EdgeArray(0))
					ssh.MultipleEdgesInterval = Val(EdgeArray(1))

				End If

			End If

			StringClean = StringClean.Replace("@MultipleEdges(" & GetParentheses(StringClean, "@MultipleEdges(") & ")", "")
		End If


		If StringClean.Contains("@Edge(") Then
			ContactEdgeCheck(StringClean)

			Edge()

			If GetMatch(StringClean, "@Edge(", "Hold") = True Then ssh.EdgeHold = True
			If GetMatch(StringClean, "@Edge(", "NoHold") = True Then ssh.EdgeNoHold = True
			If ssh.EdgeHold = True And ssh.EdgeNoHold = True Then ssh.EdgeHold = False

			If GetMatch(StringClean, "@Edge(", "Deny") = True Then ssh.OrgasmDenied = True

			If GetMatch(StringClean, "@Edge(", "Orgasm") = True Then ssh.OrgasmAllowed = True

			If GetMatch(StringClean, "@Edge(", "Ruin") = True Then ssh.OrgasmRuined = True

			If ssh.OrgasmAllowed = True And ssh.OrgasmRuined = True Then ssh.OrgasmRuined = False

			If GetMatch(StringClean, "@Edge(", "RuinTaunts") = True Then
				If ssh.EdgeToRuin = True Then ssh.EdgeToRuinSecret = False
			End If

			If GetMatch(StringClean, "@Edge(", "LongHold") = True Then
				ssh.EdgeHold = True
				ssh.LongHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "ExtremeHold") = True Then
				ssh.EdgeHold = True
				ssh.ExtremeHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "HoldTaunts") = True And ssh.EdgeHold = True Then
				If ssh.LongHold = True Then ssh.LongTaunts = True
				If ssh.ExtremeHold = True Then ssh.ExtremeTaunts = True
				If ssh.LongTaunts = False And ssh.ExtremeTaunts = False Then ssh.HoldTaunts = True
			End If
		End If



		If StringClean.Contains("@EdgeMode(") Then
			Dim EdgeFlag As String = GetParentheses(StringClean, "@EdgeMode(")
			EdgeFlag = FixCommas(EdgeFlag)
			Dim EdgeArray As String() = EdgeFlag.Split(",")

			If UCase(EdgeArray(0)).Contains("GOTO") Then
				ssh.edgeMode.GotoMode = True
				ssh.edgeMode.GotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("MESSAGE") Then
				ssh.edgeMode.MessageMode = True
				ssh.edgeMode.MessageText = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("VIDEO") Then
				ssh.edgeMode.VideoMode = True
				ssh.edgeMode.GotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("NORMAL") Then
				ssh.edgeMode.Clear()
			End If

			StringClean = StringClean.Replace("@EdgeMode(" & GetParentheses(StringClean, "@EdgeMode(") & ")", "")
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

				ssh.EdgeHoldSeconds = ssh.randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh.EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("M") Then ssh.EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("H") Then ssh.EdgeHoldSeconds *= 3600

			End If

			ssh.EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			ssh.EdgeToRuin = True
			ssh.EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret(" & GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeToRuin = True
			ssh.EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinNoHoldNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			ssh.EdgeToRuin = True
			ssh.EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeToRuinSecret = False
			ssh.EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeNoHold = True
			ssh.EdgeToRuin = True
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

				ssh.EdgeHoldSeconds = ssh.randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh.EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("M") Then ssh.EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("H") Then ssh.EdgeHoldSeconds *= 3600

			End If

			ssh.EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			ssh.EdgeToRuin = True

			StringClean = StringClean.Replace("@EdgeToRuinHold(" & GetParentheses(StringClean, "@EdgeToRuinHold(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			ssh.EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinHold", "")
		End If

		If StringClean.Contains("@EdgeToRuin") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuin", "")
		End If

		If StringClean.Contains("@EdgeNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeNoHold = True
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

				ssh.EdgeHoldSeconds = ssh.randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh.EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("M") Then ssh.EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("H") Then ssh.EdgeHoldSeconds *= 3600

			End If

			ssh.EdgeHoldFlag = True


			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold(" & GetParentheses(StringClean, "@EdgeHold(") & ")", "")
		End If


		If StringClean.Contains("@EdgeHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh.EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold", "")
		End If

		If StringClean.Contains("@Edge") Then
			ContactEdgeCheck(StringClean)
			Edge()
			StringClean = StringClean.Replace("@Edge", "")
		End If

		If StringClean.Contains("@CBTBalls") Then
			If FrmSettings.CBCBTBalls.Checked = True Then
				ssh.CBTBallsActive = True
				ssh.CBTBallsFlag = True
				ssh.TasksCount = ssh.randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If
			StringClean = StringClean.Replace("@CBTBalls", "")
		End If

		If StringClean.Contains("@CBTCock") Then
			If FrmSettings.CBCBTCock.Checked = True Then
				ssh.CBTCockActive = True
				ssh.CBTCockFlag = True
				ssh.TasksCount = ssh.randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If
			StringClean = StringClean.Replace("@CBTCock", "")
		End If

		If StringClean.Contains("@CBT") And Not StringClean.Contains("@CBTLevel") Then
			If FrmSettings.CBCBTCock.Checked = True And FrmSettings.CBCBTBalls.Checked = True Then
				ssh.CBTBothActive = True
				ssh.CBTBothFlag = True
				ssh.TasksCount = ssh.randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
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
				ssh.CustomTask = True
				ssh.CustomTaskActive = True
				ssh.CustomTaskText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & ".txt"
				ssh.CustomTaskTextFirst = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & "_First.txt"
			End If

			If CustomArray.Count > 1 Then
				ssh.TasksCount = Val(CustomArray(1))
			Else
				ssh.TasksCount = ssh.randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If


			StringClean = StringClean.Replace("@CustomTask(" & GetParentheses(StringClean, "@CustomTask(") & ")", "")
		End If


		If StringClean.Contains("@DecideOrgasm") Then

			ssh.OrgasmDenied = False
			ssh.OrgasmAllowed = False
			ssh.OrgasmRuined = False

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
				ssh.FileGoto = RuinGoto
				ssh.OrgasmRuined = True
				GoTo OrgasmDecided
			End If

			Dim OrgasmInt As Integer = ssh.randomizer.Next(1, 101)
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
				ssh.FileGoto = DenyGoto
				ssh.OrgasmDenied = True
				GoTo OrgasmDecided
			End If

			Dim RuinInt As Integer = ssh.randomizer.Next(1, 101)
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
				ssh.FileGoto = AllowGoto
				ssh.OrgasmAllowed = True
			Else
				ssh.FileGoto = RuinGoto
				ssh.OrgasmRuined = True
			End If

OrgasmDecided:

			ssh.SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@DecideOrgasm", "")
		End If


		If StringClean.Contains("@OrgasmRuin") Then
			ssh.FileGoto = "Orgasm Ruin"
			ssh.OrgasmRuined = True
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmRuin", "")
		End If

		If StringClean.Contains("@OrgasmDeny") Then
			ssh.FileGoto = "Orgasm Deny"
			ssh.OrgasmDenied = True
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmDeny", "")
		End If

		If StringClean.Contains("@OrgasmAllow") Then
			ssh.FileGoto = "Orgasm Allow"
			ssh.OrgasmAllowed = True
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmAllow", "")
		End If



		' The @Glitter Command allows to specify a specfic script from the domme's Apps\Glitter\Script directory, which will then immediately play out in the Glitter app. For example, @Glitter(About to Ruin)
		' would run the Glitter script in Apps\Glitter\Script\About to Ruin.txt.

		If StringClean.Contains("@Glitter(") Then
			Dim GlitterFlag As String = GetParentheses(StringClean, "@Glitter(")

			If My.Settings.CBGlitterFeedOff = False Then
				Dim Folder As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Script"
				Dim FilePath As String = Path.Combine(Folder, GlitterFlag & ".txt")

				If Directory.Exists(Folder) AndAlso File.Exists(FilePath) Then
					ssh.UpdateList.Add(FilePath)
					If ssh.UpdatingPost = False Then
						StatusUpdatePost()
					Else
						ssh.UpdatesTick = 10
					End If

				End If
			End If

			StringClean = StringClean.Replace("@Glitter(" & GlitterFlag & ")", "")
		End If

		If StringClean.Contains("@WritingTask(") Or StringClean.Contains("@WritingTaskRandom(") Then
			If StringClean.Contains("@WritingTask(") Then
				ssh.randomWriteTask = False
				StringClean = StringClean.Replace("@WritingTask(" & GetParentheses(StringClean, "@WritingTask(") & ")", "")
			Else
				ssh.randomWriteTask = True
				StringClean = StringClean.Replace("@WritingTaskRandom(" & GetParentheses(StringClean, "@WritingTaskRandom(") & ")", "")
			End If

			ssh.WritingTaskFlag = True
			setWriteTask()

			Dim WritingTaskVal As Integer = Val(LBLWritingTaskText.Text)

			If WritingTaskVal = 0 Then
				ssh.WritingTaskLinesAmount = ssh.randomizer.Next(FrmSettings.NBWritingTaskMin.Value, FrmSettings.NBWritingTaskMax.Value)
				ssh.WritingTaskLinesAmount = 5 * Math.Round(ssh.WritingTaskLinesAmount / 5)
			Else
				ssh.WritingTaskLinesAmount = WritingTaskVal
				LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace(WritingTaskVal, "")
			End If

			LBLLinesWritten.Text = "0"
			LBLLinesRemaining.Text = ssh.WritingTaskLinesAmount

			If PNLWritingTask.Visible = False Then
				CloseApp(PNLWritingTask)
			End If

			'WritingTaskMistakesAllowed = randomizer.Next(3, 9)

			'determine error numbers based on numbers of lines to write
			ssh.WritingTaskMistakesAllowed = ssh.randomizer.Next(ssh.WritingTaskLinesAmount / 10, ssh.WritingTaskLinesAmount / 3)
			'clamps the value between 2 and 10 errors
			ssh.WritingTaskMistakesAllowed = Math.Max(2, ssh.WritingTaskMistakesAllowed)
			ssh.WritingTaskMistakesAllowed = Math.Min(ssh.WritingTaskMistakesAllowed, 10)

			LBLMistakesAllowed.Text = ssh.WritingTaskMistakesAllowed
			LBLMistakesMade.Text = "0"
			'LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times."
			ssh.WritingTaskLinesRemaining = ssh.WritingTaskLinesAmount
			ssh.WritingTaskLinesWritten = 0
			ssh.WritingTaskMistakesMade = 0
			chatBox.ShortcutsEnabled = False
			ChatBox2.ShortcutsEnabled = False

			If My.Settings.TimedWriting = True Then

				Dim secs As Single

				'determines how many secs are given for writing each line, depending on line length and typespeed value selected by the user in the settings
				'(between 0,54 and 0,75 secs per character in the sentence at slowest typingspeed and between 0.18 and 0.25 at fastest typing speed)
				secs = (ssh.randomizer.Next(15, 25) / My.Settings.TypeSpeed) * (LBLWritingTaskText.Text.Length - 3)
				'determines how much time is given (in seconds) to complete the @WritingTask() depending on how many lines you have to write and a small bonus to give some
				'more time for very short lines
				ssh.WritingTaskCurrentTime = 15 + secs * ssh.WritingTaskLinesAmount

				LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times" & vbCrLf & "In " & ConvertSeconds(ssh.WritingTaskCurrentTime)
				LBLWritingTask.Text = LBLWritingTask.Text.Replace("line 1 times", "line 1 time")
			Else
				LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times"
				LBLWritingTask.Text = LBLWritingTask.Text.Replace("line 1 times", "line 1 time")
			End If
		End If

		If StringClean.Contains("@CheckJOIVideo") Then
			If Directory.Exists(My.Settings.VideoJOI) Or Directory.Exists(My.Settings.VideoJOID) Then
				If FrmSettings.LblVideoJOITotal.Text <> "0" Or FrmSettings.LblVideoJOITotalD.Text <> "0" Then
				Else
					ssh.SkipGotoLine = True
					ssh.FileGoto = "No JOI Found"
					GetGoto()
				End If
			Else
				ssh.SkipGotoLine = True
				ssh.FileGoto = "No JOI Found"
				GetGoto()
			End If

			StringClean = StringClean.Replace("@CheckJOIVideo", "")
		End If

		If StringClean.Contains("@PlayJOIVideo") Then
			If Directory.Exists(My.Settings.VideoJOI) Or Directory.Exists(My.Settings.VideoJOID) Then

				ssh.TeaseVideo = True
				PlayRandomJOI()
			End If

			StringClean = StringClean.Replace("@PlayJOIVideo", "")
		End If

		If StringClean.Contains("@PlayCHVideo") Then
			If Directory.Exists(My.Settings.VideoCH) Or Directory.Exists(My.Settings.VideoCH) Then

				ssh.TeaseVideo = True
				PlayRandomCH()
			End If

			StringClean = StringClean.Replace("@PlayCHVideo", "")
		End If

		If StringClean.Contains("@GiveUpCheck") Then
			If ssh.AskedToGiveUpSection = True Then

				If ssh.SubGaveUp = True Then
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREHASH.txt"
				Else
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREPEAT.txt"
				End If
				'StringClean = ResponseClean(StringClean)

			Else

				ssh.AskedToGiveUpSection = True
				ssh.AskedToGiveUp = True

				Dim GiveUpCheck As Integer

				If FrmSettings.NBEmpathy.Value = 1 Then GiveUpCheck = 0
				If FrmSettings.NBEmpathy.Value = 2 Then GiveUpCheck = 25
				If FrmSettings.NBEmpathy.Value = 3 Then GiveUpCheck = 50
				If FrmSettings.NBEmpathy.Value = 4 Then GiveUpCheck = 75
				If FrmSettings.NBEmpathy.Value = 5 Then GiveUpCheck = 1000

				Dim GiveUpVal As Integer = ssh.randomizer.Next(1, 101)

				'If GiveUpVal > GiveUpCheck Then
				If GiveUpVal > GiveUpCheck And Not ssh.LastScript Then
					' you can give up
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpALLOWED.txt"
					ssh.LockImage = False
					If ssh.SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						PicStripTSMIdommeSlideshow.Enabled = True
					End If
					ssh.SubGaveUp = True
					If ssh.MultipleEdges = True Then
						ssh.MultipleEdgesAmount = 0
						ssh.MultipleEdges = False
					End If
					If ssh.TasksCount >= 1 Then ssh.TasksCount = 0
					'ssh.FirstRound = False
				Else
					' you can't give up
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpDENIED.txt"
				End If
			End If
			StringClean = ResponseClean(StringClean)
		End If


		If StringClean.Contains("@EndTease") Then
			ssh.EndSession = True
			StringClean = StringClean.Replace("@EndTease", "")
		End If

		If StringClean.Contains("@FinishTease") Then
			ssh.TeaseTick = 0
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
			If ssh.TeaseTick > 0 Then
				ssh.isLink = False
				ssh.BeforeTease = False
				Dim EdgeList As New List(Of String)

				For Each EdgeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					'Debug.Print("EdgeFile = " & EdgeFile)
					EdgeList.Add(EdgeFile)
				Next

				'Debug.Print("EdgeList.Count = " & EdgeList.Count)

				If EdgeList.Count > 0 Then

					GotoClear()

					ssh.SubEdging = False
					ssh.SubHoldingEdge = False
					EdgeTauntTimer.Stop()
					StrokeTimer.Stop()
					StrokeTauntTimer.Stop()
					ssh.FileText = EdgeList(ssh.randomizer.Next(0, EdgeList.Count))
					ssh.LockImage = False
					If ssh.SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						PicStripTSMIdommeSlideshow.Enabled = True
					End If
					ssh.StrokeTauntVal = -1
					ssh.ScriptTick = 3
					ScriptTimer.Start()
					ssh.ShowModule = True

				Else
					MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one LongEdge_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				StringClean = StringClean.Replace("@InterruptLongEdge", "")
				ssh.JustShowedBlogImage = True
			End If
		End If

		If StringClean.Contains("@InterruptStartStroking") Then
			ssh.isLink = False
			ssh.BeforeTease = False
			If ssh.CensorshipGame = True Or ssh.AvoidTheEdgeGame = True Or ssh.RLGLGame = True Then
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

				GotoClear()

				ssh.CBTCockFlag = False
				ssh.CBTBallsFlag = False
				ssh.CBTBothFlag = False
				ssh.CustomTask = False
				ssh.SubEdging = False
				ssh.SubHoldingEdge = False
				EdgeTauntTimer.Stop()
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				ssh.FileText = StrokeList(ssh.randomizer.Next(0, StrokeList.Count))
				ssh.LockImage = False
				If ssh.SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					PicStripTSMIdommeSlideshow.Enabled = True
				End If
				ssh.StrokeTauntVal = -1
				ssh.ScriptTick = 3
				ScriptTimer.Start()
				ssh.ShowModule = True

			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Stroking!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one StartStroking_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@InterruptStartStroking", "")
			ssh.JustShowedBlogImage = True
		End If

		If StringClean.Contains("@Interrupt(") Then
			ssh.isLink = False
			ssh.BeforeTease = False
			Dim InterruptClean As String = StringClean
			Dim StartIndex As Integer = InterruptClean.IndexOf("@Interrupt(") + 11
			For i As Integer = 1 To StartIndex
				InterruptClean = InterruptClean.Remove(0, 1)
			Next
			Dim InterruptS As String() = InterruptClean.Split(")")
			InterruptClean = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\" & InterruptS(0) & ".txt"

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\" & InterruptS(0) & ".txt") Then

				GotoClear()

				ssh.FirstRound = False
				ssh.CBTCockFlag = False
				ssh.CBTBallsFlag = False
				ssh.CBTBothFlag = False
				ssh.CustomTask = False
				ssh.SubEdging = False
				ssh.SubHoldingEdge = False
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				ssh.MultiTauntPictureHold = False
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

				'if we use an interrupt we have to clear all the values stored in the @CallReturn array because @Interrupts stop everything
				'and then moves to a link (otherwise we'd have the program going back to these @CallReturn the next time a new @CallReturn is called)
				ssh.CallReturns.Clear()


				ssh.FileText = InterruptClean
				ssh.LockImage = False
				If ssh.SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					PicStripTSMIdommeSlideshow.Enabled = True
				End If
				ssh.StrokeTauntVal = -1
				ssh.ScriptTick = 3
				ScriptTimer.Start()
				ssh.ShowModule = True
			Else
				MessageBox.Show(Me, InterruptS(0) & ".txt was not found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@Interrupt(" & InterruptS(0) & ")", "")
			'Debug.Print("StringClean INterrupt Remove = " & "@Interrupt(" & InterruptS(0) & ")")
			ssh.JustShowedBlogImage = True
		End If

		If StringClean.Contains("@BookmarkModule") Then
			ssh.BookmarkModule = True
			ssh.BookmarkModuleFile = ssh.FileText
			ssh.BookmarkModuleLine = ssh.StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkModule", "")
		End If

		If StringClean.Contains("@BookmarkLink") Then
			ssh.BookmarkLink = True
			ssh.BookmarkLinkFile = ssh.FileText
			ssh.BookmarkLinkLine = ssh.StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkLink", "")
		End If

		If StringClean.Contains("@AFKOn") Then
			ssh.AFK = True
			StringClean = StringClean.Replace("@AFKOn", "")
		End If

		If StringClean.Contains("@AFKOff") Then
			ssh.AFK = False
			StringClean = StringClean.Replace("@AFKOff", "")
		End If

		If StringClean.Contains("@Wait(") Then

			Dim WaitFlag As String = GetParentheses(StringClean, "Wait(")
			Dim WaitSeconds As Integer = Val(WaitFlag)

			If UCase(WaitFlag).Contains("M") Then WaitSeconds *= 60
			If UCase(WaitFlag).Contains("H") Then WaitSeconds *= 3600

			ssh.WaitTick = WaitSeconds
			WaitTimer.Start()

			StringClean = StringClean.Replace("@Wait(" & WaitFlag & ")", "")
		End If



		If StringClean.Contains("@SendDailyTasks") Then
			CreateTaskLetter()
			StringClean = StringClean.Replace("@SendDailyTasks", "")
		End If

		If StringClean.Contains("@EdgingHold") Then

			'ssh.DomTypeCheck = True
			ssh.SubEdging = False
			ssh.SubStroking = False
			ssh.SubHoldingEdge = True
			EdgeTauntTimer.Stop()
			ssh.DomChat = "#HoldTheEdge"
			TypingDelay()

			ssh.HoldEdgeTick = ssh.HoldEdgeChance

			Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
			If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

			Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
			If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

			If ssh.ExtremeHold = True Then
				HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
			End If

			If ssh.LongHold = True Then
				HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
			End If


			If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

			ssh.HoldEdgeTick = ssh.randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
			If ssh.HoldEdgeTick < 10 Then ssh.HoldEdgeTick = 10

			ssh.HoldEdgeTime = 0

			HoldEdgeTimer.Start()
			HoldEdgeTauntTimer.Start()

			'Do
			'Application.DoEvents()
			'Loop Until ssh.DomTypeCheck = False


			StringClean = StringClean.Replace("@EdgingHold", "")
		End If

		If StringClean.Contains("@EdgingStop") Then

			ssh.DomTypeCheck = True
			ssh.SubEdging = False
			ssh.SubStroking = False
			EdgeTauntTimer.Stop()
			ssh.DomChat = "#StopStrokingEdge"
			TypingDelay()

			StringClean = StringClean.Replace("@EdgingStop", "")
		End If

		'Github Patch  If StringClean.Contains("@EdgingDecide") Then
		If StringClean.Contains("@DecideEdge") Then

			ssh.TempVal = ssh.randomizer.Next(0, 101)

			If ssh.TempVal < 51 Then

				ssh.DomTypeCheck = True
				ssh.SubEdging = False
				ssh.SubStroking = False
				ssh.SubHoldingEdge = True
				EdgeTauntTimer.Stop()
				StrokePace = 0
				ssh.DomChat = "#HoldTheEdge"
				If ssh.Contact1Stroke = True Then
					ssh.DomChat = "@Contact1 #HoldTheEdge"
					' Github Patch Contact1Stroke = False
				End If
				If ssh.Contact2Stroke = True Then
					ssh.DomChat = "@Contact2 #HoldTheEdge"
					' Github Patch Contact2Stroke = False
				End If
				If ssh.Contact3Stroke = True Then
					ssh.DomChat = "@Contact3 #HoldTheEdge"
					' Github Patch Contact3Stroke = False
				End If
				TypingDelay()

				ssh.HoldEdgeTick = ssh.HoldEdgeChance

				Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
				If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

				Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
				If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

				If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

				ssh.HoldEdgeTick = ssh.randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If ssh.HoldEdgeTick < 10 Then ssh.HoldEdgeTick = 10

				ssh.HoldEdgeTime = 0

				HoldEdgeTimer.Start()
				HoldEdgeTauntTimer.Start()

			Else

				ssh.DomTypeCheck = True
				ssh.SubEdging = False
				ssh.SubStroking = False
				EdgeTauntTimer.Stop()
				ssh.DomChat = "#StopStrokingEdge"
				If ssh.Contact1Stroke = True Then
					ssh.DomChat = "@Contact1 #StopStrokingEdge"
					ssh.Contact1Stroke = False
				End If
				If ssh.Contact2Stroke = True Then
					ssh.DomChat = "@Contact2 #StopStrokingEdge"
					ssh.Contact2Stroke = False
				End If
				If ssh.Contact3Stroke = True Then
					ssh.DomChat = "@Contact3 #StopStrokingEdge"
					ssh.Contact3Stroke = False
				End If
				TypingDelay()

			End If
			'Do
			'Application.DoEvents()
			'Loop Until ssh.DomTypeCheck = False
			StringClean = StringClean.Replace("@DecideEdge", "")
		End If

		If StringClean.Contains("@CheckVideo") Then
			ssh.VideoCheck = True
			ssh.VideoGenre = "ALL"
			RandomVideo()
			If ssh.NoVideo = True Then
				ssh.FileGoto = "(No Videos Found)"
			Else
				ssh.FileGoto = "(Videos Found)"
			End If
			ssh.VideoCheck = False
			ssh.NoVideo = False
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckVideo", "")
		End If

		If StringClean.Contains("@PlayCensorshipSucks") Then

			If StringClean.Contains("@PlayCensorshipSucks[") Then
				Dim videoFlag As String = GetParentheses(StringClean, "@PlayCensorshipSucks[")
				selectVideo(videoFlag)
				StringClean = StringClean.Replace("@PlayCensorshipSucks[" & videoFlag & "]", "")
			Else
				ssh.VideoGenre = "ALL"
				RandomVideo()
				StringClean = StringClean.Replace("@PlayCensorshipSucks", "")
			End If

			If ssh.NoVideo = False Then
				ssh.ScriptVideoTease = "Censorship Sucks"
				ssh.ScriptVideoTeaseFlag = True
				ssh.ScriptVideoTeaseFlag = False
				ssh.CensorshipGame = True
				ssh.VideoTease = True
				ssh.CensorshipTick = ssh.randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
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
				TempAssign = AssignList(ssh.randomizer.Next(0, AssignList.Count))
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
			If StringClean.Contains("@PlayAvoidTheEdge[") Then
				Dim videoFlag As String = GetParentheses(StringClean, "@PlayAvoidTheEdge[")
				selectVideo(videoFlag)
				StringClean = StringClean.Replace("@PlayAvoidTheEdge[" & videoFlag & "]", "")
			Else
				ssh.VideoGenre = "ALL"
				RandomVideo()
				StringClean = StringClean.Replace("@PlayAvoidTheEdge", "")
			End If

			If ssh.NoVideo = False Then

				ScriptTimer.Stop()
				ssh.SubStroking = True
				ssh.TempStrokeTauntVal = ssh.StrokeTauntVal
				ssh.TempFileText = ssh.FileText
				ssh.ScriptVideoTease = "Avoid The Edge"
				ssh.ScriptVideoTeaseFlag = True
				ssh.AvoidTheEdgeStroking = True
				ssh.AvoidTheEdgeGame = True
				ssh.ScriptVideoTeaseFlag = False
				ssh.VideoTease = True
				ssh.StartStrokingCount += 1
				StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				ssh.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
				AvoidTheEdgeTaunts.Start()
			End If
			StringClean = StringClean.Replace("@PlayAvoidTheEdge", "")
		End If

		If StringClean.Contains("@ResumeAvoidTheEdge") Then
			DomWMP.Ctlcontrols.play()
			ScriptTimer.Stop()
			ssh.AvoidTheEdgeStroking = True
			ssh.SubStroking = True
			ssh.StartStrokingCount += 1
			ssh.VideoTease = True
			StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)
			ssh.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
			AvoidTheEdgeTaunts.Start()
			StringClean = StringClean.Replace("@ResumeAvoidTheEdge", "")
		End If

		If StringClean.Contains("@PlayRedLightGreenLight") Then
			' #### Reboot
			If StringClean.Contains("@PlayRedLightGreenLight[") Then
				Dim videoFlag As String = GetParentheses(StringClean, "@PlayRedLightGreenLight[")
				selectVideo(videoFlag)
				StringClean = StringClean.Replace("@PlayRedLightGreenLight[" & videoFlag & "]", "")
			Else
				ssh.VideoGenre = "ALL"
				RandomVideo()
				StringClean = StringClean.Replace("@PlayRedLightGreenLight", "")
			End If

			If ssh.NoVideo = False Then

				ScriptTimer.Stop()
				ssh.SubStroking = True
				ssh.TempStrokeTauntVal = ssh.StrokeTauntVal
				ssh.TempFileText = ssh.FileText
				ssh.ScriptVideoTease = "RLGL"
				ssh.ScriptVideoTeaseFlag = True
				'AvoidTheEdgeStroking = True
				ssh.RLGLGame = True

				ssh.ScriptVideoTeaseFlag = False
				ssh.VideoTease = True
				ssh.RLGLTick = ssh.randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
				RLGLTimer.Start()
				ssh.StartStrokingCount += 1
				StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				'VideoTauntTick = randomizer.Next(20, 31)
				'VideoTauntTimer.Start()
			End If
			StringClean = StringClean.Replace("@PlayRedLightGreenLight", "")
		End If

		If StringClean.Contains("@PlayVideo[") Then
			Dim videoFlag As String = GetParentheses(StringClean, "@PlayVideo[")
			Dim VidInt As Integer = 0

			If videoFlag.Contains(",") Then videoFlag = FixCommas(videoFlag)
			Dim FlagArray As String() = videoFlag.Split(",")
			selectVideo(FlagArray(0))

			If FlagArray.Count > 1 Then
				If Val(FlagArray(1)) > 0 Then
					VidInt = Val(FlagArray(1))
					If UCase(FlagArray(1)).Contains("M") Then VidInt *= 60
				End If
			End If
			If ssh.NoVideo = False Then
				ssh.TeaseVideo = True
				If VidInt > 0 Then
					ssh.VideoTick = VidInt
					VideoTimer.Start()
				End If
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			StringClean = StringClean.Replace("@PlayVideo[" & videoFlag & "]", "")
		End If

		If StringClean.Contains("@PlayAudio[") Then
			Dim AudioFlag As String = GetParentheses(StringClean, "@PlayAudio[")
			' Github Patch Dim AudioClean As String = Application.StartupPath & "\Video\" & AudioFlag
			Dim AudioClean As String

			If AudioFlag.Contains(":\") Then
				AudioClean = AudioFlag
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
					DomWMP.URL = AudioList(ssh.randomizer.Next(0, AudioList.Count))
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

			ssh.VideoGenre = "ALL"
			Dim VidInt As Integer = 0

			Dim VidFlag As String = GetParentheses(StringClean, "@PlayVideo(")

			If VidFlag.Contains(",") Then VidFlag = FixCommas(VidFlag)
			Dim FlagArray As String() = VidFlag.Split(",")

			For i As Integer = 0 To FlagArray.Count - 1

				If Val(FlagArray(i)) > 0 Then
					VidInt = Val(FlagArray(i))
					If UCase(FlagArray(i)).Contains("M") Then VidInt *= 60
				End If

				If UCase(FlagArray(i)).Contains("HARDCORE") Then ssh.VideoGenre = "HARDCORE"
				If UCase(FlagArray(i)).Contains("SOFTCORE") Then ssh.VideoGenre = "SOFTCORE"
				If UCase(FlagArray(i)).Contains("LESBIAN") Then ssh.VideoGenre = "LESBIAN"
				If UCase(FlagArray(i)).Contains("BLOWJOB") Then ssh.VideoGenre = "BLOWJOB"
				If UCase(FlagArray(i)).Contains("FEMDOM") Then ssh.VideoGenre = "FEMDOM"
				If UCase(FlagArray(i)).Contains("FEMSUB") Then ssh.VideoGenre = "FEMSUB"
				If UCase(FlagArray(i)).Contains("JOI") Then ssh.VideoGenre = "JOI"
				If UCase(FlagArray(i)).Contains("CH") Then ssh.VideoGenre = "CH"
				If UCase(FlagArray(i)).Contains("GENERAL") Then ssh.VideoGenre = "GENERAL"

				If UCase(FlagArray(i)).Contains("HARDCORE DOMME") Then ssh.VideoGenre = "HARDCORE DOMME"
				If UCase(FlagArray(i)).Contains("SOFTCORE DOMME") Then ssh.VideoGenre = "SOFTCORE DOMME"
				If UCase(FlagArray(i)).Contains("LESBIAN DOMME") Then ssh.VideoGenre = "LESBIAN DOMME"
				If UCase(FlagArray(i)).Contains("BLOWJOB DOMME") Then ssh.VideoGenre = "BLOWJOB DOMME"
				If UCase(FlagArray(i)).Contains("FEMDOM DOMME") Then ssh.VideoGenre = "FEMDOM DOMME"
				If UCase(FlagArray(i)).Contains("FEMSUB DOMME") Then ssh.VideoGenre = "FEMSUB DOMME"
				If UCase(FlagArray(i)).Contains("JOI DOMME") Then ssh.VideoGenre = "JOI DOMME"
				If UCase(FlagArray(i)).Contains("CH DOMME") Then ssh.VideoGenre = "CH DOMME"
				If UCase(FlagArray(i)).Contains("GENERAL DOMME") Then ssh.VideoGenre = "GENERAL DOMME"

			Next


			'Dim VidInt As Integer = Val(VidFlag)
			'If UCase(VidFlag).Contains("M") Then VidInt *= 60

			If StringClean.Contains("@JumpVideo") Then
				ssh.JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			ssh.RandomizerVideo = True
			RandomVideo()

			If ssh.NoVideo = False Then
				ssh.TeaseVideo = True
				If VidInt > 0 Then
					ssh.VideoTick = VidInt
					VideoTimer.Start()
				End If
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			ssh.RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If





		If StringClean.Contains("@PlayVideo") Then

			ssh.VideoGenre = "ALL"

			If StringClean.Contains("@JumpVideo") Then
				ssh.JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			ssh.RandomizerVideo = True
			RandomVideo()

			If ssh.NoVideo = False Then
				ssh.TeaseVideo = True
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			ssh.RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If

		If StringClean.Contains("@JumpVideo") Then

			If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VidLow As Integer = VideoLength * 0.4
				Dim VidHigh As Integer = VideoLength * 0.9
				Dim VidPoint As Integer = ssh.randomizer.Next(VidLow, VidHigh)

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
					StrokeSeconds = ssh.randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				ssh.StrokeTick += StrokeSeconds
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
					StrokeSeconds = ssh.randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				ssh.StrokeTick -= StrokeSeconds
				If ssh.StrokeTick < 0 Then ssh.StrokeTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveStrokeTime(" & OriginalFlag & ")", "")
		End If



		If StringClean.Contains("@AddStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				If FrmSettings.CBTauntCycleDD.Checked = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then ssh.StrokeTick += ssh.randomizer.Next(1, 3) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh.StrokeTick += ssh.randomizer.Next(1, 4) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh.StrokeTick += ssh.randomizer.Next(3, 6) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh.StrokeTick += ssh.randomizer.Next(4, 8) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh.StrokeTick += ssh.randomizer.Next(5, 11) * 60
				Else
					ssh.StrokeTick += ssh.randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				End If
			End If
			StringClean = StringClean.Replace("@AddStrokeTime", "")
		End If

		If StringClean.Contains("@RemoveStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				ssh.StrokeTick -= ssh.StrokeTick / 2
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
					HoldEdgeSeconds = ssh.randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				ssh.HoldEdgeTick += HoldEdgeSeconds
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
					HoldEdgeSeconds = ssh.randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				ssh.HoldEdgeTick -= HoldEdgeSeconds
				If ssh.HoldEdgeTick < 5 Then ssh.HoldEdgeTick = 5
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

				ssh.HoldEdgeTick += ssh.randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If ssh.HoldEdgeTick < 10 Then ssh.HoldEdgeTick = 10
			End If
			StringClean = StringClean.Replace("@AddEdgeHoldTime", "")
		End If

		If StringClean.Contains("@RemoveEdgeHoldTime") Then
			If HoldEdgeTimer.Enabled = True Then
				ssh.HoldEdgeTick = ssh.HoldEdgeTick / 2
				If ssh.HoldEdgeTick < 10 Then ssh.HoldEdgeTick = 10
			End If
			StringClean = StringClean.Replace("@RemoveEdgeHoldTime", "")
		End If

		If StringClean.Contains("@AddTeaseTime(") Then

			Dim OriginalFlag As String = ""
			'I dont think this should work only when teaseTimer is enabled...what if i want to addteasetime somehow during an end script? (removing this, will allow for this too) - dariobrun
			'If TeaseTimer.Enabled = True Then

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
				TeaseSeconds = ssh.randomizer.Next(Tease1, Tease2 + 1)
			Else
				TeaseSeconds = Val(TeaseFlag)
				If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
				If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600


			End If
			ssh.TeaseTick += TeaseSeconds
			ssh.LastScript = False
			ssh.EndTease = False
			If Not TeaseTimer.Enabled Then TeaseTimer.Enabled = True
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
					TeaseSeconds = ssh.randomizer.Next(Tease1, Tease2 + 1)
				Else
					TeaseSeconds = Val(TeaseFlag)
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600
				End If
				ssh.TeaseTick -= TeaseSeconds
				If ssh.TeaseTick < 5 Then ssh.TeaseTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@AddTeaseTime") Then
			'same as before about the teasetimer
			'	If TeaseTimer.Enabled = True Then
			If FrmSettings.CBTeaseLengthDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick += ssh.randomizer.Next(10, 16) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick += ssh.randomizer.Next(15, 21) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick += ssh.randomizer.Next(20, 31) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick += ssh.randomizer.Next(30, 46) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick += ssh.randomizer.Next(45, 61) * 60
			Else
				ssh.TeaseTick += ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)

			End If
			If ssh.LastScript Then ssh.LastScript = False
			If Not TeaseTimer.Enabled Then TeaseTimer.Enabled = True
			StringClean = StringClean.Replace("@AddTeaseTime", "")
		End If

		If StringClean.Contains("@RemoveTeaseTime") Then
			If TeaseTimer.Enabled = True Then
				ssh.TeaseTick = ssh.TeaseTick / 2
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime", "")
		End If

		If StringClean.Contains("@PlaylistOff") Then
			ssh.Playlist = False
			StringClean = StringClean.Replace("@PlaylistOff", "")
		End If

		If StringClean.Contains("@RapidTextOn") Or StringClean.Contains("RTOn") Then
			ssh.RapidFire = True
			StringClean = StringClean.Replace("@RapidTextOn", "")
			StringClean = StringClean.Replace("@RTOn", "")
		End If

		If StringClean.Contains("@RapidTextOff") Or StringClean.Contains("RTOff") Then
			ssh.RapidFire = False
			StringClean = StringClean.Replace("@RapidTextOff", "")
			StringClean = StringClean.Replace("@RTOff", "")
		End If

		If StringClean.Contains("@GlitterTease1") Then
			ssh.glitterDommeNumber = 1
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@GlitterTease1", "")
		End If

		If StringClean.Contains("@GlitterTease2") Then
			ssh.glitterDommeNumber = 2
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@GlitterTease2", "")
		End If

		If StringClean.Contains("@GlitterTease3") Then
			ssh.glitterDommeNumber = 3
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@GlitterTease3", "")
		End If

		If StringClean.Contains("@DommeTease") Then
			ssh.glitterDommeNumber = 0
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@DommeTease", "")
		End If

		If StringClean.Contains("@RandomTease") Then
			ssh.glitterDommeNumber = 4
			LoadDommeImageFolder()
			StringClean = StringClean.Replace("@RandomTease", "")
		End If

		If StringClean.Contains("@SetDomme(") Then

			Dim DommeFlag As String = GetParentheses(StringClean, "@SetDomme(")
			ssh.glitterDommeNumber = 0
			If DommeFlag.Contains("1") Then ssh.glitterDommeNumber = 1
			If DommeFlag.Contains("2") Then ssh.glitterDommeNumber = 2
			If DommeFlag.Contains("3") Then ssh.glitterDommeNumber = 3
			If DommeFlag.Contains("0") Or DommeFlag.ToLower.Contains("domme") Then ssh.glitterDommeNumber = 0
			If DommeFlag.Contains("4") Or DommeFlag.ToLower.Contains("random") Then ssh.glitterDommeNumber = 4
			LoadDommeImageFolder()

			StringClean = StringClean.Replace("@SetDomme(" & GetParentheses(StringClean, "@SetDomme(") & ")", "")
		End If

		If StringClean.Contains("@AddContact1") Then
			If Not ssh.contact1Present Then
				ssh.currentlyPresentContacts.Add(ssh.SlideshowContact1.TypeName)
				ssh.contact1Present = True
				updateGroup("1")
			End If
			If My.Settings.AlwaysNewSlideshow Then ssh.SlideshowContact1.LoadNew(False)
			StringClean = StringClean.Replace("@AddContact1", "")
		End If

		If StringClean.Contains("@RemoveContact1") Then
			'security measure: only remove the contact if another contact is already present, to prevent crashes due to no contact being present
			If ssh.contact1Present And ((ssh.dommePresent Or ssh.contact2Present Or ssh.contact3Present) Or (StringClean.Contains("@AddContact") Or StringClean.Contains("@AddDomme"))) Then
				ssh.currentlyPresentContacts.Remove(ssh.SlideshowContact1.TypeName)
				ssh.contact1Present = False
				updateGroup("1")
			End If
			StringClean = StringClean.Replace("@RemoveContact1", "")
		End If

		If StringClean.Contains("@AddContact2") Then
			If Not ssh.contact2Present Then
				ssh.currentlyPresentContacts.Add(ssh.SlideshowContact2.TypeName)
				ssh.contact2Present = True
				updateGroup("2")
			End If
			If My.Settings.AlwaysNewSlideshow Then ssh.SlideshowContact2.LoadNew(False)
			StringClean = StringClean.Replace("@AddContact2", "")
		End If

		If StringClean.Contains("@RemoveContact2") Then
			'security measure: only remove the contact if another contact is already present, to prevent crashes due to no contact being present
			If ssh.contact2Present And ((ssh.dommePresent Or ssh.contact1Present Or ssh.contact3Present) Or (StringClean.Contains("@AddContact") Or StringClean.Contains("@AddDomme"))) Then
				ssh.currentlyPresentContacts.Remove(ssh.SlideshowContact2.TypeName)
				ssh.contact2Present = False
				updateGroup("2")
			End If
			StringClean = StringClean.Replace("@RemoveContact2", "")
		End If

		If StringClean.Contains("@AddContact3") Then
			If Not ssh.contact3Present Then
				ssh.currentlyPresentContacts.Add(ssh.SlideshowContact3.TypeName)
				ssh.contact3Present = True
				updateGroup("3")
			End If
			If My.Settings.AlwaysNewSlideshow Then ssh.SlideshowContact3.LoadNew(False)
			StringClean = StringClean.Replace("@AddContact3", "")
		End If

		If StringClean.Contains("@RemoveContact3") Then
			'security measure: only remove the contact if another contact is already present, to prevent crashes due to no contact being present
			If ssh.contact3Present And ((ssh.dommePresent Or ssh.contact1Present Or ssh.contact2Present) Or (StringClean.Contains("@AddContact") Or StringClean.Contains("@AddDomme"))) Then
				ssh.currentlyPresentContacts.Remove(ssh.SlideshowContact3.TypeName)
				ssh.contact3Present = False
				updateGroup("3")
			End If
			StringClean = StringClean.Replace("@RemoveContact3", "")
		End If

		If StringClean.Contains("@AddDomme") Then
			If Not ssh.dommePresent Then
				ssh.currentlyPresentContacts.Add(ssh.SlideshowMain.TypeName)
				ssh.dommePresent = True
				updateGroup("D")
			End If
			StringClean = StringClean.Replace("@AddDomme", "")
		End If

		If StringClean.Contains("@RemoveDomme") Then
			'security measure: only remove the domme if another contact is already present, to prevent crashes due to no contact being present
			If ssh.dommePresent And ((ssh.contact1Present Or ssh.contact2Present Or ssh.contact3Present) Or (StringClean.Contains("@AddContact") Or StringClean.Contains("@AddDomme"))) Then
				ssh.currentlyPresentContacts.Remove(ssh.SlideshowMain.TypeName)
				ssh.dommePresent = False
				updateGroup("D")
			End If
			StringClean = StringClean.Replace("@RemoveDomme", "")
		End If

		If StringClean.Contains("@ContinueSession") Or StringClean.Contains("@SecondSession") Then
			If FrmSettings.CBDomDenialEnds.Checked = False And FrmSettings.CBDomOrgasmEnds.Checked = False Then
				ssh.SecondSession = True
			End If
			StringClean = StringClean.Replace("@ContinueSession", "")
			StringClean = StringClean.Replace("@SecondSession", "")
		End If

		If StringClean.Contains("@NullResponse") Then
			ssh.NullResponse = True
			StringClean = StringClean.Replace("@NullResponse", "")
			'Debug.Print("NullResponse Called")
		End If

VTSkip:

		If StringClean.Contains("@SpeedUpCheck") Then

			If ssh.AskedToSpeedUp = True Then
				ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace < 201 Then
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpMAX.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = ssh.randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpALLOWED.txt"

					Else

						' you can't speed up
						ssh.AskedToSpeedUp = True
						ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SpeedUpCheck", "")
			GoTo RinseLatherRepeat
		End If


		If StringClean.Contains("@SlowDownCheck") Then
			If ssh.AskedToSpeedUp = True Then
				ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace > 999 Then
					ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownMIN.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = ssh.randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownALLOWED.txt"

					Else

						' you can't speed up
						ssh.AskedToSpeedUp = True
						ssh.ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SlowDownCheck", "")
			GoTo RinseLatherRepeat
		End If

		If StringClean.Contains("@PlayRiskyPick") Then
			ssh.RiskyDeal = True
			'FrmCardList.RiskyRound += 1
			FrmCardList.TCGames.SelectTab(2)
			FrmCardList.Show()
			FrmCardList.Focus()
			FrmCardList.InitializeRiskyDeal()
			StringClean = StringClean.Replace("@PlayRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@ChooseRiskyPick") Then
			ssh.RiskyDelay = True
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
			ssh.BronzeTokens += FrmCardList.TokensPaid
			FrmCardList.LBLRiskTokens.Text = ssh.BronzeTokens
			SetVariable("RP_Edges", FrmCardList.EdgesOwed)
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
				ssh.FileGoto = "(Risky Game)"
			Else
				ssh.FileGoto = "(Risky Tease)"
			End If
			FrmCardList.RiskyState = False
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@RiskyState", "")
		End If

		If StringClean.Contains("@SystemMessage ") Then
			StringClean = StringClean.Replace("@SystemMessage ", "")
		End If

		If StringClean.Contains("@EmoteMessage ") Then
			StringClean = StringClean.Replace("@EmoteMessage ", "")
		End If

		If StringClean.Contains("@MiniScript(") Then

			Dim MiniTemp As String = GetParentheses(StringClean, "@MiniScript(")
			Dim Mini2CR As String = "\Custom\Miniscripts\" & MiniTemp & ".txt"

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & Mini2CR) Then
				StringClean = StringClean.Replace("@MiniScript(" & MiniTemp & ")", "@CallReturn(" & Mini2CR & ")")
			Else
				StringClean = StringClean.Replace("@MiniScript(" & MiniTemp & ")", "")
			End If
		End If

		If StringClean.Contains("@CallReturn(") Then
			Dim CheckFlag As String = GetParentheses(StringClean, "@CallReturn(")
			Dim CallReplace As String = CheckFlag

			If (CheckFlag.StartsWith("/") Or CheckFlag.StartsWith("\")) And Not (CheckFlag.StartsWith("//") Or CheckFlag.StartsWith("\\")) Then CheckFlag = CheckFlag.Remove(0, 1)
			CheckFlag = CheckFlag.Replace("/", "\")

			Select Case CheckFlag
				Case "Clear"
					clearCallReturns()
				Case Else
					GetSubState()
					ssh.CallReturns.Push(New SessionState.StackedCallReturn(ssh))
					ssh.YesOrNo = False
					GotoClear()
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

					ssh.CBTBallsActive = False
					ssh.CBTBallsFlag = False
					ssh.CBTCockActive = False
					ssh.CBTCockFlag = False
					ssh.CBTBothActive = False
					ssh.CBTBothFlag = False
					ssh.CustomTaskActive = False

					ssh.MultiTauntPictureHold = False

					If Not ssh.SubGaveUp Then
						ssh.SubEdging = False
						ssh.SubHoldingEdge = False
					End If

					If CheckFlag.Contains("*") Then
						Dim checkArray() As String = CheckFlag.Split("*")
						CheckFlag = checkArray(0)
						If Not Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag) Then
							MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not exist!" & Environment.NewLine & Environment.NewLine &
							 Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							ssh.MultiTauntPictureHold = False
							Dim RandomFile As New List(Of String)
							RandomFile.Clear()
							For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
								RandomFile.Add(foundFile)
							Next
							If RandomFile.Count < 1 Then
								MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not contain any scripts!" & Environment.NewLine & Environment.NewLine &
								  Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								GotoClear()
								ssh.FileText = RandomFile(ssh.randomizer.Next(0, RandomFile.Count))
								ssh.StrokeTauntVal = -1
							End If
						End If
					Else
						If CheckFlag.Contains(",") Then

							CheckFlag = FixCommas(CheckFlag)

							Dim CallSplit As String() = CheckFlag.Split(",")
							ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
							ssh.FileGoto = CallSplit(1)
							ssh.SkipGotoLine = True
							GetGoto()

						Else

							ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
							ssh.StrokeTauntVal = -1

						End If
					End If
					ssh.ScriptTick = 2
					ScriptTimer.Start()
					ssh.ShowModule = True
					ssh.isLink = False
			End Select

			StringClean = StringClean.Replace("@CallReturn(" & CallReplace & ")", "")
		End If

		If StringClean.Contains("@Call(") Then
			'we have to clear all the values stored in the @CallReturn array because otherwise the normal teaseAI cycle re-starts, but
			'there are still open callreturns that would come back later (whenever you call a new callreturn) and mess things up 
			ssh.CallReturns.Clear()

			Dim CheckFlag As String = GetParentheses(StringClean, "@Call(")
			If (CheckFlag.StartsWith("/") Or CheckFlag.StartsWith("\")) And Not (CheckFlag.StartsWith("//") Or CheckFlag.StartsWith("\\")) Then CheckFlag = CheckFlag.Remove(0, 1)
			CheckFlag = CheckFlag.Replace("/", "\")

			Dim CallReplace As String = CheckFlag

			ssh.MultiTauntPictureHold = False

			If CheckFlag.Contains(",") Then

				CheckFlag = FixCommas(CheckFlag)

				Dim CallSplit As String() = CheckFlag.Split(",")
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
				ssh.FileGoto = CallSplit(1)
				ssh.SkipGotoLine = True
				GetGoto()

			Else

				GotoClear()
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
				ssh.StrokeTauntVal = -1

			End If
			ssh.ShowModule = True
			ssh.isLink = False
			ssh.ScriptTick = 2
			ScriptTimer.Start()
			StringClean = StringClean.Replace("@Call(" & CallReplace & ")", "")
		End If


		If StringClean.Contains("@CallRandom(") Then
			'we have to clear all the values stored in the @CallReturn array because otherwise the normal teaseAI cycle re-starts, but
			'there are still open callreturns that would come back later (whenever you call a new callreturn) and mess things up 
			ssh.CallReturns.Clear()

			Dim CheckFlag As String = GetParentheses(StringClean, "@CallRandom(")
			If (CheckFlag.StartsWith("/") Or CheckFlag.StartsWith("\")) And Not (CheckFlag.StartsWith("//") Or CheckFlag.StartsWith("\\")) Then CheckFlag = CheckFlag.Remove(0, 1)
			CheckFlag = CheckFlag.Replace("/", "\")

			Dim CallReplace As String = CheckFlag

			If Not Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag) Then
				MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not exist!" & Environment.NewLine & Environment.NewLine &
				 Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				ssh.MultiTauntPictureHold = False
				Dim RandomFile As New List(Of String)
				RandomFile.Clear()
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					RandomFile.Add(foundFile)
				Next
				If RandomFile.Count < 1 Then
					MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not contain any scripts!" & Environment.NewLine & Environment.NewLine &
					  Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					GotoClear()
					ssh.FileText = RandomFile(ssh.randomizer.Next(0, RandomFile.Count))
					ssh.StrokeTauntVal = -1
				End If
			End If
			ssh.ShowModule = True
			ssh.isLink = False
			ssh.ScriptTick = 2
			ScriptTimer.Start()
			StringClean = StringClean.Replace("@CallRandom(" & CallReplace & ")", "")
		End If

		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		'			@RandomLink and @RandomModule provided by dariobrun. I want to run different usage scenarios to better understand how to describe them to the users. They'll be in the code
		'           as of 54.7.0, but probably won't be included in the Milovana patch notes until at least 54.8 - 1885
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		If StringClean.Contains("@RandomLink") Then
			'we have to clear all the values stored in the @CallReturn array because otherwise the normal teaseAI cycle re-starts, but
			'there are still open callreturns that would come back later (whenever you call a new callreturn) and mess things up 
			ssh.CallReturns.Clear()

			RunLinkScript()
			StringClean = StringClean.Replace("@RandomLink", "")
		End If

		If StringClean.Contains("@RandomModule") Then
			'we have to clear all the values stored in the @CallReturn array because otherwise the normal teaseAI cycle re-starts, but
			'there are still open callreturns that would come back later (whenever you call a new callreturn) and mess things up 
			ssh.CallReturns.Clear()

			If ssh.SubEdging Or ssh.SubHoldingEdge Then
				RunModuleScript(True)
			Else
				RunModuleScript(False)
			End If
			StringClean = StringClean.Replace("@RandomModule", "")
		End If

		If StringClean.Contains("@RapidCodeOn") Then
			ssh.RapidCode = True
			StringClean = StringClean.Replace("@RapidCodeOn", "")
		End If

		If StringClean.Contains("@RapidCodeOff") Then
			ssh.RapidCode = False
			StringClean = StringClean.Replace("@RapidCodeOff", "")
		End If

		If StringClean.Contains("@InterruptsOff") Then
			ssh.DoNotDisturb = True
			StringClean = StringClean.Replace("@InterruptsOff", "")
		End If

		If StringClean.Contains("@InterruptsOn") Then
			ssh.DoNotDisturb = False
			StringClean = StringClean.Replace("@InterruptsOn", "")
		End If

		If StringClean.Contains("@HonorificOn") Then
			FrmSettings.CBHonorificInclude.Checked = True
			StringClean = StringClean.Replace("@HonorificOn", "")
		End If

		If StringClean.Contains("@HonorificOff") Then
			FrmSettings.CBHonorificInclude.Checked = False
			StringClean = StringClean.Replace("@HonorificOff", "")
		End If

		If StringClean.Contains("@NameOn") Then
			FrmSettings.CBNameInclude.Checked = True
			StringClean = StringClean.Replace("@NameOn", "")
		End If

		If StringClean.Contains("@NameOff") Then
			FrmSettings.CBNameInclude.Checked = False
			StringClean = StringClean.Replace("@NameOff", "")
		End If

		If StringClean.Contains("@NoTypo") Then
			ssh.TypoSwitch = 0
			StringClean = StringClean.Replace("@NoTypo", "")
		End If

		If StringClean.Contains("@ForceTypo") Then
			ssh.TypoSwitch = 2
			StringClean = StringClean.Replace("@ForceTypo", "")
		End If

		If StringClean.Contains("@TyposOff") Then
			ssh.TyposDisabled = True
			StringClean = StringClean.Replace("@TyposOff", "")
		End If

		If StringClean.Contains("@TyposOn") Then
			ssh.TyposDisabled = False
			StringClean = StringClean.Replace("@TyposOn", "")
		End If

		If StringClean.Contains("@GoodMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@GoodMood(")

			If ssh.DommeMood > FrmSettings.NBDomMoodMax.Value Then
				ssh.FileGoto = MoodFlag
				ssh.SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@GoodMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@BadMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@BadMood(")

			If ssh.DommeMood < FrmSettings.NBDomMoodMin.Value Then
				ssh.FileGoto = MoodFlag
				ssh.SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@BadMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@NeutralMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@NeutralMood(")

			If ssh.DommeMood >= FrmSettings.NBDomMoodMin.Value And ssh.DommeMood <= FrmSettings.NBDomMoodMax.Value Then
				ssh.FileGoto = MoodFlag
				ssh.SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@NeutralMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@SetMood(") Then
			Dim MoodFlag As Integer = CInt(GetParentheses(StringClean, "@SetMood("))
			If IsNumeric(MoodFlag) Then
				ssh.DommeMood = MoodFlag
				If ssh.DommeMood > 10 Then ssh.DommeMood = 10
				If ssh.DommeMood < 1 Then ssh.DommeMood = 1
			ElseIf LCase(MoodFlag) = "worst" Then
				ssh.DommeMood = 1
			ElseIf LCase(MoodFlag) = "bad" Then
				ssh.DommeMood = ssh.randomizer.Next(1, FrmSettings.NBDomMoodMin.Value)
			ElseIf LCase(MoodFlag) = "neutral" Then
				ssh.DommeMood = ssh.randomizer.Next(FrmSettings.NBDomMoodMin.Value, FrmSettings.NBDomMoodMax.Value + 1)
			ElseIf LCase(MoodFlag) = "good" Then
				ssh.DommeMood = ssh.randomizer.Next(FrmSettings.NBDomMoodMax.Value + 1, 11)
			ElseIf LCase(MoodFlag) = "best" Then
				ssh.DommeMood = 10
			End If

			StringClean = StringClean.Replace("@SetMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@MoodUp") Then
			ssh.DommeMood += 1
			If ssh.DommeMood > 10 Then ssh.DommeMood = 10
			StringClean = StringClean.Replace("@MoodUp", "")
		End If

		If StringClean.Contains("@MoodDown") Then
			ssh.DommeMood -= 1
			If ssh.DommeMood < 1 Then ssh.DommeMood = 1
			StringClean = StringClean.Replace("@MoodDown", "")
		End If

		If StringClean.Contains("@MoodBest") Then
			ssh.DommeMood = 10
			StringClean = StringClean.Replace("@MoodBest", "")
		End If

		If StringClean.Contains("@MoodWorst") Then
			ssh.DommeMood = 1
			StringClean = StringClean.Replace("@MoodWorst", "")
		End If

		If StringClean.Contains("@Timeout(") Then

			Dim TimeFlag As String = GetParentheses(StringClean, "@Timeout(", StringClean.Split(")").Count - 1)
			'if there is a leftover ) (might happen in very complex followUp) we remove it
			If TimeFlag.EndsWith(")") Then TimeFlag = TimeFlag.Remove(TimeFlag.Length - 1, 1)
			Dim OriginalFlag As String = TimeFlag
			TimeFlag = StripCommands(TimeFlag)


			TimeFlag = FixCommas(TimeFlag)

			Dim TimeArray As String() = TimeFlag.Split(",")

			ssh.FileGoto = TimeArray(1)
			ssh.TimeoutTick = Val(TimeArray(0))
			TimeoutTimer.Start()

			StringClean = StringClean.Replace("@Timeout(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@BallTorture+1") Then
			ssh.CBTBallsCount += 1
			StringClean = StringClean.Replace("@BallTorture+1", "")
		End If

		If StringClean.Contains("@CockTorture+1") Then
			ssh.CBTCockCount += 1
			StringClean = StringClean.Replace("@CockTorture+1", "")
		End If


		If StringClean.Contains("@EndTaunts") Then
			ssh.StrokeTick = 0
			StringClean = StringClean.Replace("@EndTaunts", "")
		End If


		If StringClean.Contains("@ResponseYes(") Then
			ssh.ResponseYes = GetParentheses(StringClean, "@ResponseYes(")
			StringClean = StringClean.Replace("@ResponseYes(" & GetParentheses(StringClean, "@ResponseYes(") & ")", "")
		End If

		If StringClean.Contains("@ResponseNo(") Then
			ssh.ResponseNo = GetParentheses(StringClean, "@ResponseNo(")
			StringClean = StringClean.Replace("@ResponseNo(" & GetParentheses(StringClean, "@ResponseNo(") & ")", "")
		End If


		If StringClean.Contains("@SetModule(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetModule(")

			If TempMod.Contains(",") Then
				TempMod = FixCommas(TempMod)
				Dim TempArray As String() = TempMod.Split(",")
				TempMod = TempArray(0)
				ssh.SetModuleGoto = TempArray(1)

			End If


			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt") Then
				ssh.SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt") Then
				ssh.SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt"
			End If

			If ssh.SetModule = "" Then ssh.SetModuleGoto = ""

			StringClean = StringClean.Replace("@SetModule(" & GetParentheses(StringClean, "@SetModule(") & ")", "")
		End If

		If StringClean.Contains("@SetLink(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetLink(")
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt") Then
				ssh.SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt") Then
				ssh.SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt"
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

		If StringClean.Contains("@Worship(") Then
			Dim WorshipTemp As String = GetParentheses(StringClean, "@Worship(")
			Debug.Print("Worship Paren = " & WorshipTemp)
			If UCase(WorshipTemp) = "ASS" Then ssh.WorshipTarget = "Ass"
			If UCase(WorshipTemp) = "BOOBS" Then ssh.WorshipTarget = "Boobs"
			If UCase(WorshipTemp) = "PUSSY" Then ssh.WorshipTarget = "Pussy"
			ssh.WorshipMode = True
			StringClean = StringClean.Replace("@Worship(" & GetParentheses(StringClean, "@Worship(") & ")", "")
		End If

		If StringClean.Contains("@WorshipOn") Then
			ssh.WorshipMode = True
			StringClean = StringClean.Replace("@WorshipOn", "")
		End If

		If StringClean.Contains("@WorshipOff") Then
			ssh.WorshipMode = False
			ssh.WorshipTarget = ""
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
			ssh.WorshipTarget = ""
			StringClean = StringClean.Replace("@ClearWorship", "")
		End If


		If StringClean.Contains("@CheckFile(") Then

			Dim FileFlag As String = GetParentheses(StringClean, "@CheckFile(")
			FileFlag = FixCommas(FileFlag)

			Dim FileArray As String() = FileFlag.Split(",")

			If FileArray.Count = 2 Or FileArray.Count = 3 Then

				If File.Exists(FileArray(0)) Then
					ssh.SkipGotoLine = True
					ssh.FileGoto = FileArray(1)
					GetGoto()
				End If

				If Not File.Exists(FileArray(0)) And FileArray.Count = 3 Then
					ssh.SkipGotoLine = True
					ssh.FileGoto = FileArray(2)
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
				ssh.yesMode.GotoMode = True
				ssh.yesMode.GotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("VIDEO") Then
				ssh.yesMode.VideoMode = True
				ssh.yesMode.GotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("NORMAL") Then
				ssh.yesMode.Clear()
			End If

			StringClean = StringClean.Replace("@YesMode(" & GetParentheses(StringClean, "@YesMode(") & ")", "")
		End If

		If StringClean.Contains("@NoMode(") Then

			Dim NoFlag As String = GetParentheses(StringClean, "@NoMode(")
			NoFlag = FixCommas(NoFlag)
			Dim NoArray As String() = NoFlag.Split(",")

			If UCase(NoArray(0)).Contains("GOTO") Then
				ssh.noMode.GotoMode = True
				ssh.noMode.GotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("VIDEO") Then
				ssh.noMode.VideoMode = True
				ssh.noMode.GotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("NORMAL") Then
				ssh.noMode.Clear()
			End If

			StringClean = StringClean.Replace("@NoMode(" & GetParentheses(StringClean, "@NoMode(") & ")", "")
		End If

		If StringClean.Contains("@CameMode(") Then

			Dim CameFlag As String = GetParentheses(StringClean, "@CameMode(")
			CameFlag = FixCommas(CameFlag)
			Dim CameArray As String() = CameFlag.Split(",")

			If UCase(CameArray(0)).Contains("GOTO") Then
				ssh.cameMode.GotoMode = True
				ssh.cameMode.GotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("MESSAGE") Then
				ssh.cameMode.MessageMode = True
				ssh.cameMode.MessageText = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("VIDEO") Then
				ssh.cameMode.VideoMode = True
				ssh.cameMode.GotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("NORMAL") Then
				ssh.cameMode.Clear()
			End If

			StringClean = StringClean.Replace("@CameMode(" & GetParentheses(StringClean, "@CameMode(") & ")", "")
		End If

		If StringClean.Contains("@RuinedMode(") Then

			Dim RuinedFlag As String = GetParentheses(StringClean, "@RuinedMode(")
			RuinedFlag = FixCommas(RuinedFlag)
			Dim RuinedArray As String() = RuinedFlag.Split(",")

			If UCase(RuinedArray(0)).Contains("GOTO") Then
				ssh.ruinMode.GotoMode = True
				ssh.ruinMode.GotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("MESSAGE") Then
				ssh.ruinMode.MessageMode = True
				ssh.ruinMode.MessageText = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("VIDEO") Then
				ssh.ruinMode.VideoMode = True
				ssh.ruinMode.GotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("NORMAL") Then
				ssh.ruinMode.Clear()
			End If

			StringClean = StringClean.Replace("@RuinedMode(" & GetParentheses(StringClean, "@RuinedMode(") & ")", "")
		End If

		If StringClean.Contains("@CustomMode(") Then
			updateMode(StringClean, ssh.Modes)
			StringClean = StringClean.Replace("@CustomMode(" & GetParentheses(StringClean, "@CustomMode(") & ")", "")
		End If


		If StringClean.Contains("@ClearModes") Then
			ClearModes()
			StringClean = StringClean.Replace("@ClearModes", "")
		End If


		If StringClean.Contains("@LockVideo") Then
			ssh.LockVideo = True
			StringClean = StringClean.Replace("@LockVideo", "")
		End If

		If StringClean.Contains("@UnlockVideo") Then
			ssh.LockVideo = False
			mainPictureBox.Visible = True
			DomWMP.Visible = False
			StringClean = StringClean.Replace("@UnlockVideo", "")
		End If

		If StringClean.Contains("@ClearChat") Then
			ChatClear()
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

		If StringClean.Contains("@CountVar[") Then

			Dim CountFlag As String = GetParentheses(StringClean, "@CountVar[")

			If CountFlag.Contains(",") Then

				CountFlag = FixCommas(CountFlag)
				Dim CountArray() As String = CountFlag.Split(",")

				If CountArray(1).ToLower.Contains("stop") Then
					If ssh.CountDownList.Count > 0 Then
						For i As Integer = ssh.CountDownList.Count - 1 To 0 Step -1
							If ssh.CountDownList(i).Contains(CountArray(0)) Then ssh.CountDownList.RemoveAt(i)
						Next
					End If
					If ssh.CountUpList.Count > 0 Then
						For i As Integer = ssh.CountUpList.Count - 1 To 0 Step -1
							If ssh.CountUpList(i).Contains(CountArray(0)) Then ssh.CountUpList.RemoveAt(i)
						Next
					End If

				Else

					If CountArray(1).ToLower.Contains("down") Then
						ssh.CountDownList.Add(CountArray(0))
						If ssh.CountUpList.Count > 0 Then
							For i As Integer = ssh.CountUpList.Count - 1 To 0 Step -1
								If ssh.CountUpList(i).Contains(CountArray(0)) Then ssh.CountUpList.RemoveAt(i)
							Next
						End If
					Else
						ssh.CountUpList.Add(CountArray(0))
						If ssh.CountDownList.Count > 0 Then
							For i As Integer = ssh.CountDownList.Count - 1 To 0 Step -1
								If ssh.CountDownList(i).Contains(CountArray(0)) Then ssh.CountDownList.RemoveAt(i)
							Next
						End If
					End If

				End If

			Else

				ssh.CountUpList.Add(CountFlag)
				If ssh.CountDownList.Count > 0 Then
					For i As Integer = ssh.CountDownList.Count - 1 To 0 Step -1
						If ssh.CountDownList(i).Contains(CountFlag) Then ssh.CountDownList.RemoveAt(i)
					Next
				End If

			End If

			StringClean = StringClean.Replace("@CountVar[" & GetParentheses(StringClean, "@CountVar[") & "]", "")
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


			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then ssh.FileGoto = "(Never Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then ssh.FileGoto = "(Rarely Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then ssh.FileGoto = "(Sometimes Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then ssh.FileGoto = "(Often Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then ssh.FileGoto = "(Always Allows)"

			'Debug.Print(FileGoto)

			ssh.SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeOrgasm", "")
		End If

		If StringClean.Contains("@GotoDommeRuin") Then

			Debug.Print("GotoDommeRuinedCalled")


			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then ssh.FileGoto = "(Never Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then ssh.FileGoto = "(Rarely Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then ssh.FileGoto = "(Sometimes Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then ssh.FileGoto = "(Often Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then ssh.FileGoto = "(Always Ruins)"

			'Debug.Print(FileGoto)

			ssh.SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeRuin", "")
		End If

		If StringClean.Contains("@GotoDommeApathy") Then

			'Debug.Print("GotoDommeApathyCalled")


			If FrmSettings.NBEmpathy.Value = 1 Then ssh.FileGoto = "(ApathyLevel1)"
			If FrmSettings.NBEmpathy.Value = 2 Then ssh.FileGoto = "(ApathyLevel2)"
			If FrmSettings.NBEmpathy.Value = 3 Then ssh.FileGoto = "(ApathyLevel3)"
			If FrmSettings.NBEmpathy.Value = 4 Then ssh.FileGoto = "(ApathyLevel4)"
			If FrmSettings.NBEmpathy.Value = 5 Then ssh.FileGoto = "(ApathyLevel5)"

			'Debug.Print(FileGoto)

			ssh.SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeApathy", "")
		End If

		If StringClean.Contains("@GotoDommeLevel") Then

			If FrmSettings.domlevelNumBox.Value = 1 Then ssh.FileGoto = "(DommeLevel1)"
			If FrmSettings.domlevelNumBox.Value = 2 Then ssh.FileGoto = "(DommeLevel2)"
			If FrmSettings.domlevelNumBox.Value = 3 Then ssh.FileGoto = "(DommeLevel3)"
			If FrmSettings.domlevelNumBox.Value = 4 Then ssh.FileGoto = "(DommeLevel4)"
			If FrmSettings.domlevelNumBox.Value = 5 Then ssh.FileGoto = "(DommeLevel5)"

			'Debug.Print(FileGoto)

			ssh.SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeLevel", "")
		End If

		If StringClean.Contains("@CheckBnB") Then
			If Not GetImageData(ImageGenre.Boobs).IsAvailable Or Not GetImageData(ImageGenre.Butt).IsAvailable Then
				ssh.FileGoto = "(No BnB)"
				ssh.SkipGotoLine = True
				GetGoto()
			End If
			StringClean = StringClean.Replace("@CheckBnB", "")
		End If

		If StringClean.Contains("@CheckStrokingState") Then
			'If SubStroking = True Then
			If ssh.SubStroking = True Or ssh.SubEdging = True Or ssh.SubHoldingEdge = True Then
				ssh.FileGoto = "(Sub Stroking)"
			Else
				ssh.FileGoto = "(Sub Not Stroking)"
			End If
			ssh.SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckStrokingState", "")
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

#End Region  ' WebToy

#Region "-------------------------------- Script: Flags/Dates/Variables ---------------------------------"

#Region "---------------------------------------- Script-Flags ------------------------------------------"

	''' <summary>Creates the given flag.</summary>
	''' <param name="FlagName">The flag name to set.</param>
	''' <param name="Temp">If set to true, the flag is temporary set otherwise permanent.</param>
	Friend Sub CreateFlag(ByVal FlagName As String, Optional ByVal Temp As Boolean = False)
		If Temp = False Then
			FlagName = ssh.Folders.Flags & FlagName
		Else
			FlagName = ssh.Folders.TempFlags & FlagName
		End If

		Using fs As New FileStream(FlagName, FileMode.Create) : End Using

	End Sub
	''' <summary>Deletes the given flag. Deletes permanent and temporary flags.</summary>
	''' <param name="FlagName">The name of the flag to delete.</param>
	Friend Sub DeleteFlag(ByVal FlagName As String)

		If File.Exists(ssh.Folders.Flags & FlagName) Then _
		 File.Delete(ssh.Folders.Flags & FlagName)

		If File.Exists(ssh.Folders.TempFlags & FlagName) Then _
		 File.Delete(ssh.Folders.TempFlags & FlagName)

	End Sub
	''' <summary> Checks if the given flag is set, permanent and temporary.</summary>
	''' <param name="FlagName">The flag name to search for.</param>
	''' <returns>Returns true if a permanent or temporary flag with the name is found.</returns>
	Friend Function FlagExists(ByVal FlagName As String) As Boolean

		If File.Exists(ssh.Folders.Flags & FlagName) OrElse
		 File.Exists(ssh.Folders.TempFlags & FlagName) Then
			Return True
		Else
			Return False
		End If

	End Function

#End Region ' Script-Flags

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

	Public Function GetNthIndex(ByVal searchString As String, ByVal charToFind As Char, ByVal startIndex As Integer, ByVal n As Integer) As Integer
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

		If ssh.HoldEdgeTime >= HoldTime * 60 Then HoldEdgeCheck = True

		Return HoldEdgeCheck


	End Function

	Public Function GetLocalImage(Optional ByVal IncludeTags As List(Of String) = Nothing,
	   Optional ByVal ExcludeTags As List(Of String) = Nothing) As String


		If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
			' Read all lines of given file.
			ssh.LocalTagImageList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")


			Dim ValidExt As String() = Split(".jpg|.jpeg|.bmp|.png|.gif", "|")

			ssh.LocalTagImageList.RemoveAll(Function(x)
												' Remove if given include tags are missing
												If IncludeTags IsNot Nothing Then
													For Each tag As String In IncludeTags
														If Not x.Contains(tag.Replace("@", "")) Then Return True
													Next
												End If
												' Remove if given exclude tags are present
												If ExcludeTags IsNot Nothing Then
													For Each tag As String In ExcludeTags
														If x.Contains(tag.Replace("@", "")) Then Return True
													Next
												End If
												' Remove all without valid extension
												Dim Ext As String = Path.GetExtension(Split(x)(0)).ToLower
												If Not ValidExt.Contains(Ext) Then Return True
												'Everything fine keep file
												Return False
											End Function)

			Do While ssh.LocalTagImageList.Count > 0
				Dim rndNumber As Integer = ssh.randomizer.Next(0, ssh.LocalTagImageList.Count)
				' TODO: GetLocalImage: Add space char (0x20) support for filepaths.
				Dim Filepath As String = Split(ssh.LocalTagImageList(rndNumber))(0)

				If Directory.Exists(Path.GetDirectoryName(Filepath)) _
				AndAlso File.Exists(Filepath) Then
					Return Filepath
				Else
					ssh.LocalTagImageList.RemoveAt(rndNumber)
				End If
			Loop
		End If

		Return String.Empty
	End Function

	Public Function GetLocalImage(LocTag As String, Optional isDommeTag As Boolean = False, Optional selectionType As String = "All") As String
		Dim fileToCheck As String = Application.StartupPath & "\Images\System\LocalImageTags.txt"
		If isDommeTag Then
			fileToCheck = Path.GetDirectoryName(ssh.contactToUse.CurrentImage) & Path.DirectorySeparatorChar & "ImageTags.txt"
		End If

		'TODO-Next: @ImageTag() Implement optimized @ShowTaggedImage code.
		If File.Exists(fileToCheck) Then


			Dim TagList As New List(Of String)
			TagList = Txt2List(fileToCheck)

			LocTag = LocTag.Replace(" ,", ",")
			LocTag = LocTag.Replace(", ", ",")

			Dim LocTagArray As String() = LocTag.Split(",")

			Dim TaggedList As New List(Of String)

			Select Case selectionType
				Case "Or"
					For n As Integer = 0 To LocTagArray.Count - 1
						If TaggedList.Count = 0 Then
							For i As Integer = 0 To TagList.Count - 1
								If TagList(i).Contains(LocTagArray(n)) Then
									TaggedList.Add(TagList(i))
								End If
							Next
						End If
					Next
				Case "Any"
					For i As Integer = 0 To TagList.Count - 1
						For n As Integer = 0 To LocTagArray.Count - 1
							If TagList(i).Contains(LocTagArray(n)) Then TaggedList.Add(TagList(i))
						Next
					Next
				Case Else
					Dim addImg As Boolean
					For i As Integer = 0 To TagList.Count - 1
						For n As Integer = 0 To LocTagArray.Count - 1
							If Not TagList(i).Contains(LocTagArray(n)) Then
								addImg = False
								Exit For
							Else
								addImg = True
								Continue For
							End If
						Next
						If addImg Then TaggedList.Add(TagList(i))
					Next
			End Select

			If TaggedList.Count > 0 Then

				Dim PicArray As String() = TaggedList(ssh.randomizer.Next(0, TaggedList.Count)).Split
				Dim PicDir As String = ""

				For p As Integer = 0 To PicArray.Count - 1
					PicDir = PicDir & PicArray(p) & " "
					If UCase(PicDir).Contains(".JPG") Or UCase(PicDir).Contains(".JPEG") Or UCase(PicDir).Contains(".PNG") Or UCase(PicDir).Contains(".BMP") Or UCase(PicDir).Contains(".GIF") Then Exit For
				Next
				If isDommeTag Then PicDir = Path.GetDirectoryName(ssh.contactToUse.CurrentImage) & Path.DirectorySeparatorChar & PicDir
				Return PicDir
			Else
				Return String.Empty
			End If
		Else
			Return String.Empty
		End If
	End Function

	Friend Sub ContactEdgeCheck(EdgeCheck As String)
		If EdgeCheck.Contains("@Contact1") Then
			ssh.Contact1Edge = True
		ElseIf EdgeCheck.Contains("@Contact2") Then
			ssh.Contact2Edge = True
		ElseIf EdgeCheck.Contains("@Contact3") Then
			ssh.Contact3Edge = True
		ElseIf EdgeCheck.Contains("@RandomContact") Then
			Dim casual As Integer = 0
			casual = ssh.randomizer.Next(0, ssh.currentlyPresentContacts.Count)
			Select Case ssh.currentlyPresentContacts(casual)
				Case ssh.SlideshowContact1.TypeName
					ssh.Contact1Edge = True
				Case ssh.SlideshowContact2.TypeName
					ssh.Contact2Edge = True
				Case ssh.SlideshowContact3.TypeName
					ssh.Contact3Edge = True
				Case Else
			End Select
		End If
	End Sub

	Public Sub DisableContactStroke()
		ssh.Contact1Stroke = False
		ssh.Contact2Stroke = False
		ssh.Contact3Stroke = False
	End Sub

	Public Sub GetSubState()

		ssh.ReturnSubState = "Rest"
		If ssh.SubStroking = True Then ssh.ReturnSubState = "Stroking"
		If ssh.SubEdging = True Then ssh.ReturnSubState = "Edging"
		If ssh.SubHoldingEdge = True Then ssh.ReturnSubState = "Holding The Edge"
		If ssh.CBTBallsFlag = True Or ssh.CBTBothFlag = True Then ssh.ReturnSubState = "CBTBalls"
		If ssh.CBTCockFlag = True Then ssh.ReturnSubState = "CBTCock"
		If ssh.CensorshipGame = True Then ssh.ReturnSubState = "Censorship Sucks"
		If ssh.AvoidTheEdgeGame = True Then ssh.ReturnSubState = "Avoid The Edge"
		If ssh.RLGLGame = True Then ssh.ReturnSubState = "RLGL"



	End Sub

	Public Sub EdgePace()

		StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMaxPace.Value + 151)
		If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value
		StrokePace = 50 * Math.Round(StrokePace / 50)

	End Sub



	Public Function FilterList(ByVal ListClean As List(Of String)) As List(Of String)
#If TRACE Then
		Dim sw As New Stopwatch
		sw.Start()

		Trace.WriteLine("FilterList Started")
		Trace.Indent()
#End If

		Dim FilterPass As Boolean
		Dim ListIncrement As Integer = 1
		If ssh.StrokeFilter = True Then ListIncrement = ssh.StrokeTauntCount

		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		'		Check if Grouped-Lines-Files have the right amount of Lines
		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		' No need to go further on an empty file.
		If ListClean.Count <= 0 Then
			Trace.WriteLine("FilterList started with empty List. Skipping filter.")
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

		Dim ControlList As New List(Of String)

		For i As Integer = 0 To ListClean.Count - 1
			If ListClean(i).Contains("@ControlFlag(") Then
				If FlagExists(GetParentheses(ListClean(i), "@ControlFlag(")) = True Then
					ControlList.Add(ListClean(i))
				End If
			End If
		Next

		If ControlList.Count > 0 Then
			ListClean.Clear()
			ListClean = ControlList
		End If


		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' NEW FilterList TEST Begin
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		For i As Integer = ListClean.Count - ListIncrement To 0 Step -ListIncrement
			For x As Integer = ListIncrement - 1 To 0 Step -1
				If GetFilter(ListClean(i + x)) = False Then
					For n As Integer = ListIncrement - 1 To 0 Step -1
						ListClean.RemoveAt(i + n)
					Next
					Exit For
				End If
			Next
		Next

		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' NEW FilterList TEST End
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲


		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' Current FilterList Begin
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		'For i As Integer = 0 To ListClean.Count - 1 Step ListIncrement

		'FilterPass = True

		'For x As Integer = 0 To ListIncrement - 1
		'If GetFilter(ListClean(i + x)) = False Then
		'FilterPass = False
		'Exit For
		'End If
		'Next

		'If FilterPass = False Then
		'For x As Integer = 0 To ListIncrement - 1
		'ListClean(i + x) = ListClean(i + x) & "###-INVALID-###"
		'Next
		'End If

		'Next

		'For i As Integer = ListClean.Count - 1 To 0 Step -1
		'If ListClean(i).Contains("###-INVALID-###") Then ListClean.RemoveAt(i)
		'Next

		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' Current FilterList End
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		'Dim FilteredList As New List(Of String)

		'For i As Integer = 0 To ListClean.Count - 1
		'If Not ListClean(i).Contains("###-INVALID-###") Then FilteredList.Add(ListClean(i))
		'Next

#If TRACE Then
		Trace.Unindent()
		Trace.WriteLine("FilterList finished - Duration: " & sw.ElapsedMilliseconds & "ms")
#End If
		'If ListClean.Count = 0 Then ListClean.Add("test")
		Return ListClean

	End Function


	Public Function GetFilter(ByVal FilterString As String, Optional ByVal Linear As Boolean = False) As Boolean
		Dim OrgFilterString As String = FilterString
		Try
			If Linear = False Then
				If FilterString.Includes("@DommeTag(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DommeTag("), True) = String.Empty Then Return False
					End If
				End If

				If FilterString.Includes("@DommeTagOr(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DommeTagOr("), True, "Or") = String.Empty Then Return False
					End If
				End If

				If FilterString.Includes("@DommeTagAny(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DommeTagAny("), True, "Any") = String.Empty Then Return False
					End If
				End If

				If FilterString.Includes("@DomTag(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DomTag("), True) = String.Empty Then Return False
					End If
				End If

				If FilterString.Includes("@DomTagOr(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DomTagOr("), True, "Or") = String.Empty Then Return False
					End If
				End If

				If FilterString.Includes("@DomTagAny(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@DomTagAny("), True, "Any") = String.Empty Then Return False
					End If
				End If

				If FilterString.Contains("@ImageTag(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@ImageTag(")) = String.Empty Then Return False
					End If
				End If

				If FilterString.Contains("@ImageTagOr(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@ImageTagOr("),, "Or") = String.Empty Then Return False
					End If
				End If

				If FilterString.Contains("@ImageTagAny(") Then
					If ssh.LockImage = True Then
						Return False
					Else
						If GetLocalImage(GetParentheses(FilterString, "@ImageTagAny("),, "Any") = String.Empty Then Return False
					End If
				End If

				' ################## @Show-Category-Image #####################
				If FilterString.Contains("@ShowBlogImage") Or FilterString.Contains("@NewBlogImage") Then
					If Not GetImageData(ImageGenre.Blog).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowBlowjobImage") Then
					If Not GetImageData(ImageGenre.Blowjob).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowBoobsImage") Or FilterString.Contains("@ShowBoobImage") Then
					If Not GetImageData(ImageGenre.Boobs).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowButtImage") Or FilterString.Contains("@ShowButtsImage") Then
					If Not GetImageData(ImageGenre.Butt).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowCaptionsImage") Then
					If Not GetImageData(ImageGenre.Captions).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowDislikedImage") Then
					If Not GetImageData(ImageGenre.Disliked).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowFemdomImage") Then
					If Not GetImageData(ImageGenre.Femdom).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowGayImage") Then
					If Not GetImageData(ImageGenre.Gay).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowGeneralImage") Then
					If Not GetImageData(ImageGenre.General).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowHardcoreImage") Then
					If Not GetImageData(ImageGenre.Hardcore).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowHentaiImage") Then
					If Not GetImageData(ImageGenre.Hentai).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowLesbianImage") Then
					If Not GetImageData(ImageGenre.Lesbian).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowLezdomImage") Then
					If Not GetImageData(ImageGenre.Lezdom).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowLikedImage") Then
					If Not GetImageData(ImageGenre.Liked).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowLocalImage") Then
					If FlagExists("SYS_NoPornAllowed") = True Or ssh.LockImage = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowLocalImage") Or FilterString.Contains("@ShowButtImage") Or FilterString.Contains("@ShowBoobsImage") Or FilterString.Contains("@ShowButtsImage") Or FilterString.Contains("@ShowBoobsImage") Then
					If ssh.CustomSlideEnabled = True Or ssh.LockImage = True Then Return False
				End If
				'TODO: Add ImageDataContainerUsage to filter @ShowLocalImage correct.
				If FilterString.Contains("@ShowLocalImage") And My.Settings.CBIHardcore = False And My.Settings.CBISoftcore = False And My.Settings.CBILesbian = False And
	  My.Settings.CBIBlowjob = False And My.Settings.CBIFemdom = False And My.Settings.CBILezdom = False And My.Settings.CBIHentai = False And
	  My.Settings.CBIGay = False And My.Settings.CBIMaledom = False And My.Settings.CBICaptions = False And My.Settings.CBIGeneral = False Then Return False

				If FilterString.Contains("@ShowTaggedImage") OrElse FilterString.Contains("@Tag") Then
					Dim Tags As List(Of String) = FilterString.Split() _
					 .Select(Function(s) s.Trim()) _
					 .Where(Function(w) CType(w, String).StartsWith("@Tag")).ToList

					If GetLocalImage(Tags, Nothing) = String.Empty Or mainPictureBox.Visible = False Then Return False
				End If

				If FilterString.Contains("@ShowMaledomImage") Then
					If Not GetImageData(ImageGenre.Maledom).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				If FilterString.Contains("@ShowSoftcoreImage") Then
					If Not GetImageData(ImageGenre.Softcore).IsAvailable Or ssh.LockImage = True Or ssh.CustomSlideEnabled = True Or mainPictureBox.Visible = False Then Return False
				End If
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Disqualifying @Commands - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			End If

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Commands to sort out
			' This Section contains @Commands, which are able to disqualify vocabulary lines.
			'
			' Example-line: "Whatever Text to display @DommeTag(Glaring)"
			'
			' This line has to be sorted out, if there are no corresponding images tagged 
			' with "glaring".
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

			If FilterString.Contains("@Flag(") Or FilterString.Contains("@ControlFlag(") Then
				Dim writeFlag As String
				Dim splitFlag As String()
				If FilterString.Contains("@Flag(") Then
					writeFlag = GetParentheses(FilterString, "@Flag(")
				Else
					writeFlag = GetParentheses(FilterString, "@ControlFlag(")
				End If
				writeFlag = FixCommas(writeFlag)
				splitFlag = writeFlag.Split({","}, StringSplitOptions.RemoveEmptyEntries)
				For Each s In splitFlag
					If Not FlagExists(s) Then
						Return False
					End If
				Next
			End If

			If FilterString.Contains("@NotFlag(") Then
				Dim writeFlag As String
				Dim splitFlag As String()
				writeFlag = GetParentheses(FilterString, "@NotFlag(")
				writeFlag = FixCommas(writeFlag)
				splitFlag = writeFlag.Split({","}, StringSplitOptions.RemoveEmptyEntries)
				For Each s In splitFlag
					If FlagExists(s) Then
						Return False
					End If
				Next
			End If

			If FilterString.Contains("@FlagOr(") Then
				Dim writeFlag As String
				Dim splitFlag As String()
				writeFlag = GetParentheses(FilterString, "@FlagOr(")
				writeFlag = FixCommas(writeFlag)
				splitFlag = writeFlag.Split({","}, StringSplitOptions.RemoveEmptyEntries)
				Dim result As Boolean = False
				For Each s In splitFlag
					If FlagExists(s) Then
						result = True
						Exit For
					End If
				Next
				If Not result Then Return False
			End If

			If FilterString.Contains("@Mood(") Then
				Dim moodFlag As String = LCase(GetParentheses(FilterString, "@Mood("))
				If IsNumeric(moodFlag) Then
					If ssh.DommeMood <> CInt(moodFlag) Then Return False
				ElseIf moodFlag = "worst" Then
					If ssh.DommeMood <> 1 Then Return False
				ElseIf moodFlag = "bad" Then
					If ssh.DommeMood >= FrmSettings.NBDomMoodMin.Value Then Return False
				ElseIf moodFlag = "neutral" Then
					If ssh.DommeMood > FrmSettings.NBDomMoodMax.Value Or ssh.DommeMood < FrmSettings.NBDomMoodMin.Value Then Return False
				ElseIf moodFlag = "good" Then
					If ssh.DommeMood <= FrmSettings.NBDomMoodMax.Value Then Return False
				ElseIf moodFlag = "best" Then
					If ssh.DommeMood <> 10 Then Return False
				End If
			End If

			If FilterString.Contains("@GoodMood") And ssh.DommeMood <= FrmSettings.NBDomMoodMax.Value Then Return False
			If FilterString.Contains("@BadMood") And ssh.DommeMood >= FrmSettings.NBDomMoodMin.Value Then Return False
			If FilterString.Contains("@NeutralMood") Then
				If ssh.DommeMood > FrmSettings.NBDomMoodMax.Value Or ssh.DommeMood < FrmSettings.NBDomMoodMin.Value Then Return False
			End If
			If FilterString.Contains("@Variable[") Then
				If CheckVariable(FilterString) = False Then Return False
			End If

			If FilterString.Contains("@Group(") Then
				Dim GroupCheck As String = GetParentheses(FilterString, "@Group(")
				Dim grouparray() As String = GroupCheck.Split(",")
				Dim b As Boolean
				For i As Integer = 0 To grouparray.Length - 1
					b = True
					For Each c As Char In grouparray(i)
						If Not ssh.Group.Contains(c) Then
							b = False
							Exit For
						End If
					Next
				Next
				If b = False Then Return False
				'	If GroupCheck.Contains("D") Then
				'	If ssh.GlitterTease = False Or Not ssh.Group.Contains("D") Then Return False
				'End If
				'	If GroupCheck.Contains("1") Then
				'	If ssh.GlitterTease = False Or Not ssh.Group.Contains("1") Then Return False
				'End If
				'	If GroupCheck.Contains("2") Then
				'	If ssh.GlitterTease = False Or Not ssh.Group.Contains("2") Then Return False
				'	End If
				'	If GroupCheck.Contains("3") Then
				'	If ssh.GlitterTease = False Or Not ssh.Group.Contains("3") Then Return False
				'End If
			End If

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							Possible space Filters
			' This Section Contains @CommandFilters which allow space chars (0x20).
			' 
			' Example: "@Cup(A, B) Whatever Text To display"
			' Mostly all perametrized command filters allow space chars in parameters.
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

			If FilterString.Contains("@AllowsOrgasm(") Then
				If FilterCheck(GetParentheses(FilterString, "@AllowsOrgasm("), FrmSettings.alloworgasmComboBox) = False Then Return False
			End If
			If FilterString.Contains("@ApathyLevel(") Then
				If FilterCheck(GetParentheses(FilterString, "@ApathyLevel("), FrmSettings.NBEmpathy) = False Then Return False
			End If
			If FilterString.Contains("@DommeLevel(") Then
				If FilterCheck(GetParentheses(FilterString, "@DommeLevel("), FrmSettings.domlevelNumBox) = False Then Return False
			End If
			If FilterString.Contains("@Cup(") Then
				If FilterCheck(GetParentheses(FilterString, "@Cup("), FrmSettings.boobComboBox) = False Then Return False
			End If
			If FilterString.Contains("@RuinsOrgasm(") Then
				If FilterCheck(GetParentheses(FilterString, "@RuinsOrgasm("), FrmSettings.ruinorgasmComboBox) = False Then Return False
			End If

			If FilterString.Contains("@CheckDate(") And Linear = False Then
				If CheckDateList(FilterString) = False Then Return False
			End If

			If FilterString.Contains("@Month(") Then
				If GetMatch(FilterString, "@Month(", DateAndTime.Now.Month) = False Then Return False
			End If

			If FilterString.Contains("@Day(") Then
				If GetMatch(FilterString, "@Day(", DateAndTime.Now.Day) = False Then Return False
			End If

			If FilterString.Contains("@DayOfWeek(") Then
				Dim Para As String = GetParentheses(FilterString, "@DayOfWeek(")

				If IsNumeric(Para) Then
					If GetMatch(FilterString, "@DayOfWeek(", Weekday(DateAndTime.Now, FirstDayOfWeek.Monday)) = False Then Return False
				Else
					If GetMatch(FilterString, "@DayOfWeek(", WeekdayName(Weekday(DateAndTime.Now, FirstDayOfWeek.System),, FirstDayOfWeek.System)) = False Then Return False
				End If
			End If
			If FilterString.Contains("@SetModule(") Then
				If ssh.SetModule <> "" Or ssh.BookmarkModule = True Then Return False
			End If
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' Possible space Filters - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'								Single word filters
			' This section contains single word command filters. 
			' Since there are some legacy commands, which are filters and also instructions, 
			' this section will ignore all @Statements after @NullResponse or the first 
			' word not starting with "@" (0x40)
			'
			' Beware: destroys the original FilterString-Value!
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			Dim FilterList As String()

			FilterList = FilterString.Split(" ")
			FilterString = ""

			For f As Integer = 0 To FilterList.Count - 1
				If Not FilterList(f).StartsWith("@") Or FilterList(f).Contains("@NullResponse") Then
					Exit For
				End If
				FilterString = FilterString & FilterList(f) & " "
			Next

			If FilterString = "" Then Return True

			If FilterString.ToLower.Contains("@crazy") And FrmSettings.crazyCheckBox.Checked = False Then Return False
			If FilterString.ToLower.Contains("@vulgar") And FrmSettings.vulgarCheckBox.Checked = False Then Return False
			If FilterString.ToLower.Contains("@supremacist") And FrmSettings.supremacistCheckBox.Checked = False Then Return False
			If FilterString.ToLower.Contains("@sadistic") And FrmSettings.sadisticCheckBox.Checked = False Then Return False
			If FilterString.ToLower.Contains("@degrading") And FrmSettings.degradingCheckBox.Checked = False Then Return False
			If FilterString.ToLower.Contains("@cfnm") And FrmSettings.CFNMCheckBox.Checked = False Then Return False

			If FilterString.ToLower.Contains("@dommelevel1") And FrmSettings.domlevelNumBox.Value <> 1 Then Return False
			If FilterString.ToLower.Contains("@dommelevel2") And FrmSettings.domlevelNumBox.Value <> 2 Then Return False
			If FilterString.ToLower.Contains("@dommelevel3") And FrmSettings.domlevelNumBox.Value <> 3 Then Return False
			If FilterString.ToLower.Contains("@dommelevel4") And FrmSettings.domlevelNumBox.Value <> 4 Then Return False
			If FilterString.ToLower.Contains("@dommelevel5") And FrmSettings.domlevelNumBox.Value <> 5 Then Return False

			If FilterString.ToLower.Contains("@selfyoung") And FrmSettings.domageNumBox.Value > FrmSettings.NBSelfAgeMin.Value - 1 Then Return False
			If FilterString.ToLower.Contains("@selfold") And FrmSettings.domageNumBox.Value < FrmSettings.NBSelfAgeMax.Value + 1 Then Return False
			If FilterString.ToLower.Contains("@selfyoung") Or FilterString.ToLower.Contains("@selfold") Then
				If ssh.VideoTease = True Or ssh.TeaseVideo = True Then Return False
			End If
			If FilterString.ToLower.Contains("@subyoung") And FrmSettings.subAgeNumBox.Value > FrmSettings.NBSubAgeMin.Value - 1 Then Return False
			If FilterString.ToLower.Contains("@subold") And FrmSettings.subAgeNumBox.Value < FrmSettings.NBSubAgeMax.Value + 1 Then Return False

			If FilterString.ToLower.Contains("@acup") Then
				If FrmSettings.boobComboBox.Text <> "A" Or ssh.JustShowedBlogImage = True Then Return False
			End If
			If FilterString.ToLower.Contains("@bcup") Then
				If FrmSettings.boobComboBox.Text <> "B" Or ssh.JustShowedBlogImage = True Then Return False
			End If
			If FilterString.ToLower.Contains("@ccup") Then
				If FrmSettings.boobComboBox.Text <> "C" Or ssh.JustShowedBlogImage = True Then Return False
			End If
			If FilterString.ToLower.Contains("@dcup") Then
				If FrmSettings.boobComboBox.Text <> "D" Or ssh.JustShowedBlogImage = True Then Return False
			End If
			If FilterString.ToLower.Contains("@ddcup") Then
				If FrmSettings.boobComboBox.Text <> "DD" Or ssh.JustShowedBlogImage = True Then Return False
			End If
			If FilterString.ToLower.Contains("@ddd+cup") Then
				If FrmSettings.boobComboBox.Text <> "DDD+" Or ssh.JustShowedBlogImage = True Then Return False
			End If

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

			If FilterString.ToLower.Contains("@firstround") And ssh.FirstRound = False Then Return False
			If FilterString.ToLower.Contains("@notfirstround") And ssh.FirstRound = True Then Return False

			If FilterString.ToLower.Contains("@strokespeedmax") And StrokePace < NBMaxPace.Value Then Return False
			If FilterString.ToLower.Contains("@strokespeedmin") And StrokePace < NBMinPace.Value Then Return False
			If FilterString.ToLower.Contains("@strokefaster") Or FilterString.ToLower.Contains("@strokefastest") Then
				If StrokePace = NBMaxPace.Value Or ssh.WorshipMode = True Then Return False
			End If
			If FilterString.ToLower.Contains("@strokeslower") Or FilterString.ToLower.Contains("@strokeslowest") Then
				If StrokePace = NBMinPace.Value Or ssh.WorshipMode = True Then Return False
			End If

			If FilterString.ToLower.Contains("@alwaysallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Always Allows" Then Return False
			If FilterString.ToLower.Contains("@oftenallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Often Allows" Then Return False
			If FilterString.ToLower.Contains("@sometimesallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Sometimes Allows" Then Return False
			If FilterString.ToLower.Contains("@rarelyallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Rarely Allows" Then Return False
			If FilterString.ToLower.Contains("@neverallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Never Allows" Then Return False

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
				If ssh.LongEdge = False Or FrmSettings.CBLongEdgeTaunts.Checked = False Then Return False
			End If
			If FilterString.Contains("@InterruptLongEdge") Then
				If ssh.LongEdge = False Or FrmSettings.CBLongEdgeInterrupts.Checked = False Or ssh.TeaseTick < 1 Or ssh.RiskyEdges = True Then Return False
			End If

			If FilterString.Contains("@1MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 60 Or ssh.HoldEdgeTime > 119 Then Return False
			End If
			If FilterString.Contains("@2MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 120 Or ssh.HoldEdgeTime > 179 Then Return False
			End If
			If FilterString.Contains("@3MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 180 Or ssh.HoldEdgeTime > 239 Then Return False
			End If
			If FilterString.Contains("@4MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 240 Or ssh.HoldEdgeTime > 299 Then Return False
			End If
			If FilterString.Contains("@5MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 300 Or ssh.HoldEdgeTime > 599 Then Return False
			End If
			If FilterString.Contains("@10MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 600 Or ssh.HoldEdgeTime > 899 Then Return False
			End If
			If FilterString.Contains("@15MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 900 Or ssh.HoldEdgeTime > 1799 Then Return False
			End If
			If FilterString.Contains("@30MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 1800 Or ssh.HoldEdgeTime > 2699 Then Return False
			End If
			If FilterString.Contains("@45MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 2700 Or ssh.HoldEdgeTime > 3599 Then Return False
			End If
			If FilterString.Contains("@60MinuteHold") Then
				If ssh.SubHoldingEdge = False Or ssh.HoldEdgeTime < 3600 Then Return False
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
			If FilterString.Contains("@BeforeTease") And ssh.BeforeTease = False Then Return False
			If FilterString.Contains("@OrgasmDenied") And ssh.OrgasmDenied = False Then Return False
			If FilterString.Contains("@OrgasmAllowed") And ssh.OrgasmAllowed = False Then Return False
			If FilterString.Contains("@OrgasmRuined") And ssh.OrgasmRuined = False Then Return False

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
				If ssh.EdgeToRuin = False Or ssh.EdgeToRuinSecret = True Then Return False
			End If

			If FilterString.Contains("@VideoHardcore") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Hardcore" Then Return False
			End If
			If FilterString.Contains("@VideoSoftcore") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Softcore" Then Return False
			End If
			If FilterString.Contains("@VideoLesbian") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Lesbian" Then Return False
			End If
			If FilterString.Contains("@VideoBlowjob") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Blowjob" Then Return False
			End If
			If FilterString.Contains("@VideoFemdom") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Femdom" Then Return False
			End If
			If FilterString.Contains("@VideoFemsub") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "Femsub" Then Return False
			End If
			If FilterString.Contains("@VideoGeneral") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "General" Then Return False
			End If

			If FilterString.Contains("@VideoHardcoreDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "HardcoreD" Then Return False
			End If
			If FilterString.Contains("@VideoSoftcoreDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "SoftcoreD" Then Return False
			End If
			If FilterString.Contains("@VideoLesbianDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "LesbianD" Then Return False
			End If
			If FilterString.Contains("@VideoBlowjobDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "BlowjobD" Then Return False
			End If
			If FilterString.Contains("@VideoFemdomDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "FemdomD" Then Return False
			End If
			If FilterString.Contains("@VideoFemsubDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "FemsubD" Then Return False
			End If
			If FilterString.Contains("@VideoGeneralDomme") Then
				If ssh.VideoTease = False Or ssh.VideoType <> "GeneralD" Then Return False
			End If

			If FilterString.Contains("@CockTorture") And FrmSettings.CBCBTCock.Checked = False Then Return False
			If FilterString.Contains("@BallTorture") And FrmSettings.CBCBTBalls.Checked = False Then Return False
			If FilterString.Contains("@BallTorture0") And ssh.CBTBallsCount <> 0 Then Return False
			If FilterString.Contains("@BallTorture1") And ssh.CBTBallsCount <> 1 Then Return False
			If FilterString.Contains("@BallTorture2") And ssh.CBTBallsCount <> 2 Then Return False
			If FilterString.Contains("@BallTorture3") And ssh.CBTBallsCount <> 3 Then Return False
			If FilterString.Contains("@BallTorture4+") And ssh.CBTBallsCount < 4 Then Return False
			If FilterString.Contains("@CockTorture0") And ssh.CBTCockCount <> 0 Then Return False
			If FilterString.Contains("@CockTorture1") And ssh.CBTCockCount <> 1 Then Return False
			If FilterString.Contains("@CockTorture2") And ssh.CBTCockCount <> 2 Then Return False
			If FilterString.Contains("@CockTorture3") And ssh.CBTCockCount <> 3 Then Return False
			If FilterString.Contains("@CockTorture4+") And ssh.CBTCockCount < 4 Then Return False

			If FilterString.Contains("@Stroking") Or FilterString.Contains("@SubStroking") Then
				If ssh.SubStroking = False And My.Settings.Chastity = False Then Return False
			End If

			If FilterString.Contains("@NotStroking") Or FilterString.Contains("@SubNotStroking") Then
				If ssh.SubStroking = True Or My.Settings.Chastity = True Then Return False
			End If

			If FilterString.Contains("@Edging") Or FilterString.Contains("@SubEdging") Then
				If ssh.SubEdging = False Then Return False
			End If

			If FilterString.Contains("@NotEdging") Or FilterString.Contains("@SubNotEdging") Then
				If ssh.SubEdging = True Then Return False
			End If

			If FilterString.Contains("@HoldingTheEdge") Or FilterString.Contains("@SubHoldingTheEdge") Then
				If ssh.SubHoldingEdge = False Then Return False
			End If

			If FilterString.Contains("@NotHoldingTheEdge") Or FilterString.Contains("@SubNotHoldingTheEdge") Then
				If ssh.SubHoldingEdge = True Then Return False
			End If

			If FilterString.Contains("@Morning") And ssh.GeneralTime <> "Morning" Then Return False
			If FilterString.Contains("@Afternoon") And ssh.GeneralTime <> "Afternoon" Then Return False
			If FilterString.Contains("@Night") And ssh.GeneralTime <> "Night" Then Return False

			If FilterString.Contains("@OrgasmRestricted") And ssh.OrgasmRestricted = False Then Return False
			If FilterString.Contains("@OrgasmNotRestricted") And ssh.OrgasmRestricted = True Then Return False
			If FilterString.Contains("@SubWorshipping") And ssh.WorshipMode = False Then Return False
			If FilterString.Contains("@SubNotWorshipping") And ssh.WorshipMode = True Then Return False
			If FilterString.Contains("@LongHold") Then
				If ssh.LongHold = False Or ssh.SubHoldingEdge = False Then Return False
			End If

			If FilterString.Contains("@ExtremeHold") Then
				If ssh.ExtremeHold = False Or ssh.SubHoldingEdge = False Then Return False
			End If

			If FilterString.Contains("@HoldTaunt") Then
				If ssh.HoldTaunts = False Then Return False
			End If

			If FilterString.Contains("@LongTaunt") Then
				If ssh.LongTaunts = False Then Return False
			End If

			If FilterString.Contains("@ExtremeTaunt") Then
				If ssh.ExtremeTaunts = False Then Return False
			End If

			If FilterString.Contains("@AssWorship") Then
				If ssh.WorshipTarget <> "Ass" Or ssh.WorshipMode = False Then Return False
			End If

			If FilterString.Contains("@BoobWorship") Then
				If ssh.WorshipTarget <> "Boobs" Or ssh.WorshipMode = False Then Return False
			End If

			If FilterString.Contains("@PussyWorship") Then
				If ssh.WorshipTarget <> "Pussy" Or ssh.WorshipMode = False Then Return False
			End If

			If FilterString.Contains("@Contact1") Then
				If ssh.GlitterTease = False Or Not ssh.Group.Contains("1") Then Return False
			End If

			If FilterString.Contains("@Contact2") Then
				If ssh.GlitterTease = False Or Not ssh.Group.Contains("2") Then Return False
			End If

			If FilterString.Contains("@Contact3") Then
				If ssh.GlitterTease = False Or Not ssh.Group.Contains("3") Then Return False
			End If

			If FilterString.Contains("@Info") Then Return False
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' Single word filters - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			Return True
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(String.Format("Exception occured while checking line ""{0}"".", OrgFilterString),
		   ex, "GetFilter(String, Boolean)")
			Return False
		End Try
	End Function



#Region "---------------------------------------------------- Chatbox ---------------------------------------------------------"


	Private Sub chatBox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles chatBox.DragDrop, ChatBox2.DragDrop
		CType(sender, TextBox).Text = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
		sendButton.PerformClick()
	End Sub

	Private Sub chatBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles chatBox.DragEnter, ChatBox2.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub chatbox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles chatBox.KeyDown, ChatBox2.KeyDown
		If e.KeyCode = Keys.Return Then
			sendButton.PerformClick()
			e.SuppressKeyPress = True
		End If
	End Sub

	Private Sub chatBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chatBox.KeyPress, ChatBox2.KeyPress
		If e.KeyChar = Chr(13) Then
			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)
		End If
	End Sub

#End Region  ' Chatbox

#Region "------------------------------------ Avoid the Edge --------------------------------------------"

	Private Sub AvoidTheEdge_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvoidTheEdge.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And ssh.AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.AvoidTheEdgeTick < 6 Then Return
		If ssh.FollowUp <> "" And ssh.AvoidTheEdgeTick < 6 Then Return

		ssh.AvoidTheEdgeTick -= 1

		If ssh.AvoidTheEdgeTick < 1 Then



			Dim AvoidTheEdgeVideo As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdge.txt"
			If ssh.DommeVideo = True Then AvoidTheEdgeVideo = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdgeD.txt"

			Dim AvoidTheEdgeLineStart As Integer
			Dim AvoidTheEdgeLineEnd As Integer


			If File.Exists(AvoidTheEdgeVideo) Then
			Else
				If ssh.DommeVideo = True Then
					MsgBox("AvoidTheEdgeD.txt is missing!", , "Error!")
				Else
					MsgBox("AvoidTheEdge.txt is missing!", , "Error!")
				End If
				Return
			End If



			If ssh.AvoidTheEdgeStroking = False Then


				'CensorshipTick = randomizer.Next(NBCensorHideMin.Value, NBCensorHideMax.Value + 1)

				ssh.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

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
						If ssh.VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[StrokingEnd]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
					End While

				End Using

			Else






				ssh.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

				Using ioFileB As New StreamReader(AvoidTheEdgeVideo)
					Dim linesB As New List(Of String)
					Dim TempAvoidTheEdgeLine As Integer

					TempAvoidTheEdgeLine = -1
					While ioFileB.Peek <> -1
						TempAvoidTheEdgeLine += 1
						linesB.Add(ioFileB.ReadLine())
						If ssh.VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh.VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh.VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
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

			AvoidTheEdgeLine = ssh.randomizer.Next(AvoidTheEdgeLineStart + 1, AvoidTheEdgeLineEnd)

			ssh.DomTask = lines(AvoidTheEdgeLine)

			TypingDelayGeneric()




		End If

	End Sub

	Private Sub AvoidTheEdgeResume_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvoidTheEdgeResume.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.AtECountdown < 6 Then Return
		If chatBox.Text <> "" And ssh.AtECountdown < 6 Then Return
		If ChatBox2.Text <> "" And ssh.AtECountdown < 6 Then Return

		ssh.AtECountdown -= 1
		'Debug.Print("AtECountdown = " & AtECountdown)

		If ssh.AtECountdown < 1 Then
			AvoidTheEdgeResume.Stop()

			ssh.FileGoto = "NoAvoidTheEdgeInstructions"
			ssh.SkipGotoLine = True
			GetGoto()
			'domVLC.playlist.play()
			DomWMP.Ctlcontrols.play()
			HandleScripts()
			ScriptTimer.Start()


		End If


	End Sub

#End Region  ' Avoid the Edge






	Private Sub BtnToggleImageVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToggleImageVideo.Click


		If mainPictureBox.Visible = True Then
			DomWMP.Visible = True
			mainPictureBox.Visible = False
		Else
			mainPictureBox.Visible = True
			DomWMP.Visible = False
		End If

	End Sub


	Public Sub RunModuleScript(ByVal IsEdging As Boolean)
		If ssh.MultiTauntPictureHold Then ssh.MultiTauntPictureHold = False
		ssh.StrokeTauntVal = -1
		ssh.isLink = False
		ssh.ShowModule = True
		ssh.FirstRound = False
		ssh.TauntEdging = False

		ssh.AskedToGiveUpSection = False
		Dim ModuleList As New List(Of String)
		ModuleList.Clear()

		Dim ChastityModuleCheck As String = "*.txt"
		If My.Settings.Chastity = True And Not IsEdging Then
			ssh.AskedToSpeedUp = False
			ssh.AskedToSlowDown = False
			ssh.SubStroking = False
			ssh.SubEdging = False
			ssh.SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ChastityModuleCheck = "*_CHASTITY.txt"
		End If

		If ssh.PlaylistFile.Count = 0 Then GoTo NoPlaylistModuleFile

		If ssh.Playlist = False Or ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Random Module") Then


NoPlaylistModuleFile:

			If ssh.SetModule <> "" Then

				ssh.FileText = ssh.SetModule
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
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_CHASTITY.txt"
					ElseIf IsEdging Then
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_EDGING.txt"
					Else
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module.txt"
					End If
				Else
					ssh.FileText = ModuleList(ssh.randomizer.Next(0, ModuleList.Count))
				End If
			End If

		Else
			If ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & ssh.PlaylistFile(ssh.PlaylistCurrent)
				ssh.FileText = ssh.FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh.FileText = ssh.FileText & ".txt"
			Else
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Modules\" & ssh.PlaylistFile(ssh.PlaylistCurrent) & ".txt"
			End If

		End If

		ssh.SetModule = ""

		ssh.DomTask = ssh.DomTask.Replace("@Module", "")


		If ssh.SetModuleGoto <> "" Then
			ssh.FileGoto = ssh.SetModuleGoto
			ssh.SkipGotoLine = True
			GetGoto()
			ssh.SetModuleGoto = ""
		Else
			ssh.StrokeTauntVal = -1
		End If

		If ssh.Playlist = True Then ssh.PlaylistCurrent += 1

		If Not IsEdging Then

			If ssh.Playlist = True Then ssh.BookmarkModule = False

			If ssh.BookmarkModule = True Then
				ssh.BookmarkModule = False
				ssh.FileText = ssh.BookmarkModuleFile
				ssh.StrokeTauntVal = ssh.BookmarkModuleLine
			End If

			ssh.ScriptTick = 3

		Else
			ssh.ScriptTick = 4
		End If

		ScriptTimer.Start()
	End Sub



	Public Sub RunLinkScript()
		ssh.StrokeTauntVal = -1
		If ssh.MultiTauntPictureHold Then ssh.MultiTauntPictureHold = False
		ssh.isLink = True
		ssh.ShowModule = True
		Debug.Print("RunLinkScript() Called")
		ssh.FirstRound = False
		ClearModes()

		If ssh.PlaylistFile.Count = 0 Then GoTo NoPlaylistLinkFile

		If ssh.Playlist = False Or ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Random Link") Then


NoPlaylistLinkFile:


			Debug.Print("SetLink = " & ssh.SetLink)


			If ssh.SetLink <> "" Then
				Debug.Print("SetLink Called")
				ssh.FileText = ssh.SetLink
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
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link_CHASTITY.txt"
					Else
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link.txt"
					End If
				Else
					ssh.FileText = LinkList(ssh.randomizer.Next(0, LinkList.Count))
				End If

			End If

		Else
			Debug.Print("Playlist Link Called")
			If ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Link\" & ssh.PlaylistFile(ssh.PlaylistCurrent)
				ssh.FileText = ssh.FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh.FileText = ssh.FileText & ".txt"
			Else
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Link\" & ssh.PlaylistFile(ssh.PlaylistCurrent) & ".txt"
			End If

		End If

		ssh.SetLink = ""
		Debug.Print("SetLink = " & ssh.SetLink)


		If ssh.WorshipMode = False Then
			ssh.LockImage = False
			If ssh.SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
		End If


		If ssh.SetLinkGoto <> "" Then
			ssh.FileGoto = ssh.SetLinkGoto
			ssh.SkipGotoLine = True
			GetGoto()
			ssh.SetLinkGoto = ""
		Else
			ssh.StrokeTauntVal = -1
		End If


		If ssh.Playlist = True Then ssh.PlaylistCurrent += 1
		If ssh.Playlist = True Then ssh.BookmarkLink = False

		If ssh.BookmarkLink = True Then
			ssh.BookmarkLink = False
			ssh.FileText = ssh.BookmarkLinkFile
			ssh.StrokeTauntVal = ssh.BookmarkLinkLine
		End If

		Debug.Print("Link FileText Called")


		ssh.ScriptTick = 3
		ScriptTimer.Start()


	End Sub



	Public Sub RunLastScript()

		ssh.StrokeTauntVal = -1
		ClearModes()
		ssh.ShowModule = True
		ssh.isLink = False
		ssh.FirstRound = False


		SetVariable("SYS_SubLeftEarly", 0)

		SetVariable("SYS_EndTotal", Val(GetVariable("SYS_EndTotal")) + 1)



		If ssh.PlaylistFile.Count = 0 Then GoTo NoPlaylistEndFile

		If ssh.Playlist = False Or ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Random End") Then

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

						If ssh.OrgasmRestricted = True Then
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
					ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_CHASTITY.txt"
				Else
					If ssh.OrgasmRestricted = True Then
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
					Else
						ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End.txt"
					End If
				End If
			Else
				ssh.FileText = EndList(ssh.randomizer.Next(0, EndList.Count))
			End If

		Else
			If ssh.PlaylistFile(ssh.PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\End\" & ssh.PlaylistFile(ssh.PlaylistCurrent)
				ssh.FileText = ssh.FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh.FileText = ssh.FileText & ".txt"
			Else
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\End\" & ssh.PlaylistFile(ssh.PlaylistCurrent) & ".txt"
			End If
		End If

		If ssh.WorshipMode = False Then
			If ssh.SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh.LockImage = False
		End If


		ssh.StrokeTauntVal = -1

		ssh.LastScript = True


		ssh.ScriptTick = 3
		ScriptTimer.Start()

	End Sub

	Public Sub RunLastBegScript()
		ssh.StrokeTauntVal = -1
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

				If ssh.OrgasmRestricted = False Then

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

			If ssh.OrgasmRestricted = False Then
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_BEG.txt"
			Else
				ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
			End If
		Else
			ssh.FileText = EndList(ssh.randomizer.Next(0, EndList.Count))
		End If

		ssh.LockImage = False
		If ssh.SlideshowLoaded = True Then
			nextButton.Enabled = True
			previousButton.Enabled = True
			PicStripTSMIdommeSlideshow.Enabled = True
		End If

		ssh.StrokeTauntVal = -1
		ssh.ScriptTick = 4
		ScriptTimer.Start()
		ssh.LastScript = True

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

		ssh.SubStroking = False
		ssh.SubEdging = False
		ssh.SubHoldingEdge = False
		ssh.MultipleEdges = False
		ssh.AskedToSpeedUp = False
		ssh.AskedToSlowDown = False

		ssh.WorshipMode = False
		ssh.WorshipTarget = ""
		ssh.LongHold = False
		ssh.ExtremeHold = False
		ssh.HoldTaunts = False
		ssh.LongTaunts = False
		ssh.ExtremeTaunts = False


		ssh.CBTBallsActive = False
		ssh.CBTBallsFlag = False
		ssh.CBTCockActive = False
		ssh.CBTCockFlag = False
		ssh.CBTBothActive = False
		ssh.CBTBothFlag = False
		ssh.CustomTaskActive = False

		' Unlock OrgasmChances
		FrmSettings.LockOrgasmChances(False)

		If Not ssh.giveUpReturn Then ClearModes()


		If FrmSettings.TBWebStop.Text <> "" Then
			Try
				FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
			Catch
			End Try
		End If

		StrokePace = 0

	End Sub


	Private Sub EdgeTauntTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdgeTauntTimer.Tick

		If MultipleEdgesTimer.Enabled = True Then Return
		If ssh.InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And ssh.EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And ssh.EdgeTauntInt < 6 Then Return

		FrmSettings.LBLDebugEdgeTauntTime.Text = ssh.EdgeTauntInt

		'Debug.Print("EdgeTauntIn = " & EdgeTauntInt)

		ssh.EdgeTauntInt -= 1

		If ssh.EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If ssh.GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\Edge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\GroupEdge.txt"
			End If

			'Read all lines of the given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				ssh.DomTask = ETLines(ssh.randomizer.Next(0, ETLines.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Edge Taunt from file " &
				File2Read, ex, "EdgeTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Edge Taunt from file:  " & File2Read
			End Try

			TypingDelayGeneric()

			ssh.EdgeTauntInt = ssh.randomizer.Next(30, 46)

		End If

	End Sub

#Region "--------------------------------------- Hold the Edge ------------------------------------------"

	Private Sub HoldEdgeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoldEdgeTimer.Tick

		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		ssh.HoldEdgeTime += 1
		ssh.HoldEdgeTimeTotal += 1

		My.Settings.HoldEdgeTimeTotal = ssh.HoldEdgeTimeTotal

		If ssh.InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return


		'If DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.HoldEdgeTick < 4 Then Return
		If chatBox.Text <> "" And ssh.HoldEdgeTick < 4 Then Return
		If ChatBox2.Text <> "" And ssh.HoldEdgeTick < 4 Then Return
		If ssh.FollowUp <> "" And ssh.HoldEdgeTick < 4 Then Return

		ssh.HoldEdgeTick -= 1

		FrmSettings.LBLDebugHoldEdgeTime.Text = ssh.HoldEdgeTick
		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		If ssh.HoldEdgeTick < 1 Then

			'stop
			ssh.LongHold = False
			ssh.ExtremeHold = False
			ssh.HoldTaunts = False
			ssh.LongTaunts = False
			ssh.ExtremeTaunts = False
			ssh.WorshipMode = False
			ssh.WorshipTarget = ""

			'If OrgasmAllowed = True Then GoTo AllowedOrgasm
			'If EdgeToRuin = True Or OrgasmRuined = True Then GoTo RuinedOrgasm

			If ssh.EdgeToRuin = True Or ssh.OrgasmRuined = True Then
				ssh.LastOrgasmType = "RUINED"
				ssh.OrgasmRuined = False
				GoTo RuinedOrgasm
			End If

			If ssh.OrgasmAllowed = True Then
				ssh.LastOrgasmType = "ALLOWED"
				ssh.OrgasmAllowed = False
				GoTo AllowedOrgasm
			End If

			If ssh.OrgasmDenied = True Then

				ssh.LastOrgasmType = "DENIED"

				If FrmSettings.CBDomDenialEnds.Checked = False And ssh.TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

					If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then
						ssh.SecondSession = False
						ssh.SubEdging = False
						ssh.SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatFiles

						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
						Else
							ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If

						TeaseTimer.Start()

						'ShowModule = True
						ssh.StrokeTauntVal = -1
						ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
						ssh.ScriptTick = 2
						ScriptTimer.Start()
						ssh.OrgasmDenied = False
						ssh.OrgasmYesNo = False
						ssh.EndTease = False
						Return
					Else
						If ssh.LastScript = True Then ssh.EndTease = True
					End If

				End If


			End If

NoRepeatFiles:

			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh.SubHoldingEdge = False
			ssh.SubStroking = False
			ssh.OrgasmYesNo = False
			ssh.DomTask = "#StopStroking"
			If ssh.Contact1Edge = True Then
				ssh.DomTask = "@Contact1 #StopStroking"
				ssh.Contact1Edge = False
			End If
			If ssh.Contact2Edge = True Then
				ssh.DomTask = "@Contact2 #StopStroking"
				ssh.Contact2Edge = False
			End If
			If ssh.Contact3Edge = True Then
				ssh.DomTask = "@Contact3 #StopStroking"
				ssh.Contact3Edge = False
			End If
			TypingDelayGeneric()
			Return

RuinedOrgasm:

			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

			If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh.OrgasmRuined = True And ssh.TeaseTick < 1 Then

				Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

				If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then

					EdgeTauntTimer.Stop()
					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					ssh.SecondSession = False
					ssh.SubHoldingEdge = False
					ssh.SubStroking = False
					ssh.EdgeToRuin = False
					ssh.EdgeToRuinSecret = True

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
					Else
						ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					ssh.StrokeTauntVal = -1
					ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
					ssh.ScriptTick = 2
					ScriptTimer.Start()
					ssh.OrgasmRuined = False
					ssh.OrgasmYesNo = False
					ssh.EndTease = False
					Return
				Else
					If ssh.LastScript = True Then ssh.EndTease = True
				End If

			End If



NoRepeatRFiles:



			ssh.DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh.SubHoldingEdge = False
			ssh.SubStroking = False
			ssh.EdgeToRuin = False
			ssh.EdgeToRuinSecret = True
			ssh.OrgasmYesNo = False
			ssh.DomChat = "#RuinYourOrgasm"
			If ssh.Contact1Edge = True Then
				ssh.DomChat = "@Contact1 #RuinYourOrgasm"
				ssh.Contact1Edge = False
			End If
			If ssh.Contact2Edge = True Then
				ssh.DomChat = "@Contact2 #RuinYourOrgasm"
				ssh.Contact2Edge = False
			End If
			If ssh.Contact3Edge = True Then
				ssh.DomChat = "@Contact3 #RuinYourOrgasm"
				ssh.Contact3Edge = False
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
					ssh.SubHoldingEdge = False
					ssh.SubStroking = False
					ssh.OrgasmYesNo = False
					'ShowModule = True
					ssh.StrokeTauntVal = -1
					ssh.FileText = NoCumList(ssh.randomizer.Next(0, NoCumList.Count))
					ssh.ScriptTick = 2
					ScriptTimer.Start()
					Return
				End If


				My.Settings.OrgasmsRemaining -= 1


			End If

NoNoCumFiles:


			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

			If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh.TeaseTick < 1 Then

				Dim RepeatChance As Integer = ssh.randomizer.Next(0, 101)

				If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Or (ssh.SecondSession And FrmSettings.CBDomDenialEnds.Checked = False) Then

					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					ssh.SecondSession = False
					ssh.SubHoldingEdge = False
					ssh.SubStroking = False
					ssh.EdgeToRuin = False
					ssh.EdgeToRuinSecret = True
					EdgeTauntTimer.Stop()

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then ssh.TeaseTick = ssh.randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then ssh.TeaseTick = ssh.randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then ssh.TeaseTick = ssh.randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then ssh.TeaseTick = ssh.randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then ssh.TeaseTick = ssh.randomizer.Next(45, 61) * 60
					Else
						ssh.TeaseTick = ssh.randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					ssh.StrokeTauntVal = -1
					ssh.FileText = RepeatList(ssh.randomizer.Next(0, RepeatList.Count))
					ssh.ScriptTick = 2
					ScriptTimer.Start()
					ssh.OrgasmAllowed = False
					ssh.OrgasmYesNo = False
					ssh.EndTease = False
					Return
				Else
					If ssh.LastScript = True Then ssh.EndTease = True
				End If

			End If



NoRepeatOFiles:


			ssh.DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh.SubHoldingEdge = False
			ssh.SubStroking = False
			ssh.OrgasmYesNo = False
			'OrgasmAllowed = False
			ssh.DomChat = "#CumForMe"
			If ssh.Contact1Edge = True Then
				ssh.DomChat = "@Contact1 #CumForMe"
				ssh.Contact1Edge = False
			End If
			If ssh.Contact2Edge = True Then
				ssh.DomChat = "@Contact2 #CumForMe"
				ssh.Contact2Edge = False
			End If
			If ssh.Contact3Edge = True Then
				ssh.DomChat = "@Contact3 #CumForMe"
				ssh.Contact3Edge = False
			End If
			TypingDelay()
			Return

		End If

	End Sub

	Private Sub HoldEdgeTauntTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoldEdgeTauntTimer.Tick

		If ssh.InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And ssh.EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And ssh.EdgeTauntInt < 6 Then Return

		ssh.EdgeTauntInt -= 1

		If ssh.EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If ssh.GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\HoldTheEdge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\GroupHoldTheEdge.txt"
			End If

			' Read all lines of given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				ssh.DomTask = ETLines(ssh.randomizer.Next(0, ETLines.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Hold the Edge Taunt from file: " &
			 File2Read, ex, "HoldEdgeTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Hold the Edge Taunt from file:  " & File2Read
			End Try

			TypingDelayGeneric()

			ssh.EdgeTauntInt = ssh.randomizer.Next(15, 31)


		End If

	End Sub

#End Region  ' Hold the Edge

	Public Sub CreateTaskLetter()

		Dim TaskEntry As String

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Greeting.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Intro.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		If ssh.GeneralTime = "Afternoon" Then GoTo Afternoon
		If ssh.GeneralTime = "Night" Then GoTo Night

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_1.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_1-2.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

Afternoon:

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_2.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_2-3.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

Night:

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_3.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Outro.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Signature.txt")
		ssh.TaskText = ssh.TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		If FrmSettings.CBHonorificInclude.Checked = True Then
			ssh.TaskText = ssh.TaskText & ssh.tempHonorific & " " & ssh.tempDomName
		Else
			ssh.TaskText = ssh.TaskText & ssh.tempDomName
		End If

		ssh.TaskText = System.Text.RegularExpressions.Regex.Replace(ssh.TaskText, "[ ]{2,}", " ")

		Dim TempDate As String
		Dim TempDateNow As DateTime = DateTime.Now

		TempDate = TempDateNow.ToString("M dd")

		ssh.TaskTextDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Received Files\Tasks for " & TempDate & ".txt"
		My.Computer.FileSystem.WriteAllText(ssh.TaskTextDir, ssh.TaskText, False)

		ssh.TaskText = ""

		LBLFileTransfer.Text = ssh.tempDomName & " is sending you a file!"
		PNLFileTransfer.Visible = True
		PNLFileTransfer.BringToFront()

		StupidTimer.Start()

		Debug.Print("<><><><><><><><><><><><><><><><><><><><><>")
		Debug.Print("Created " & ssh.GeneralTime & " Task Letter")
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

			TaskEntry = TaskLines(ssh.randomizer.Next(0, TaskLines.Count))


			Dim LoopBuffer As Integer
			Dim int As Integer

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
					TaskList(i) = SysKeywordClean(TaskList(i))
					TaskList(i) = PoundClean(TaskList(i))
					If TaskEntry.Contains("#") And LoopBuffer < 6 Then GoTo PoundLoop

					TaskEntry = TaskEntry & TaskList(i) & " "
				Catch
				End Try
			Next


			If TaskEntry.Contains("#TaskEdges") Then
				Do
					int = ssh.randomizer.Next(FrmSettings.NBTaskEdgesMin.Value, FrmSettings.NBTaskEdgesMax.Value + 1)
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskEdges", int)
				Loop Until Not TaskEntry.Contains("#TaskEdges")
			End If

			If TaskEntry.Contains("#TaskStrokes") Then
				Do
					int = ssh.randomizer.Next(FrmSettings.NBTaskStrokesMin.Value, FrmSettings.NBTaskStrokesMax.Value + 1)
					If int > 10 Then int = 10 * Math.Round(int / 10)
					TaskEntry = TaskEntry.Replace("#TaskStrokes", int)
				Loop Until Not TaskEntry.Contains("#TaskStrokes")
			End If

			If TaskEntry.Contains("#TaskHours") Then
				Do
					int = ssh.randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1) + FrmSettings.domlevelNumBox.Value
					TaskEntry = TaskEntry.Replace("#TaskHours", int)
				Loop Until Not TaskEntry.Contains("#TaskHours")
			End If

			If TaskEntry.Contains("#TaskMinutes") Then
				Do
					int = ssh.randomizer.Next(5, 13) * FrmSettings.domlevelNumBox.Value
					TaskEntry = TaskEntry.Replace("#TaskMinutes", int)
				Loop Until Not TaskEntry.Contains("#TaskMinutes")
			End If

			If TaskEntry.Contains("#TaskSeconds") Then
				Do
					int = ssh.randomizer.Next(10, 30) * FrmSettings.domlevelNumBox.Value * ssh.randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1)
					TaskEntry = TaskEntry.Replace("#TaskSeconds", int)
				Loop Until Not TaskEntry.Contains("#TaskSeconds")
			End If

			If TaskEntry.Contains("#TaskAmountLarge") Then
				Do
					int = (ssh.randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value) * 2
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmountLarge", int)
				Loop Until Not TaskEntry.Contains("#TaskAmountLarge")
			End If

			If TaskEntry.Contains("#TaskAmountSmall") Then
				Do
					int = (ssh.randomizer.Next(5, 11) * FrmSettings.domlevelNumBox.Value) / 2
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmountSmall", int)
				Loop Until Not TaskEntry.Contains("#TaskAmountSmall")
			End If

			If TaskEntry.Contains("#TaskAmount") Then
				Do
					int = ssh.randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmount", int)
				Loop Until Not TaskEntry.Contains("#TaskAmount")
			End If

			If TaskEntry.Contains("#TaskStrokingTime") Then
				Do
					int = ssh.randomizer.Next(FrmSettings.NBTaskStrokingTimeMin.Value, FrmSettings.NBTaskStrokingTimeMax.Value + 1)
					int *= 60
					Dim TConvert As String = ConvertSeconds(int)
					TaskEntry = TaskEntry.Replace("#TaskStrokingTime", TConvert)
				Loop Until Not TaskEntry.Contains("#TaskStrokingTime")
			End If

			If TaskEntry.Contains("#TaskHoldTheEdgeTime") Then
				Do
					int = ssh.randomizer.Next(FrmSettings.NBTaskEdgeHoldTimeMin.Value, FrmSettings.NBTaskEdgeHoldTimeMax.Value + 1)
					int *= 60
					Dim TConvert As String = ConvertSeconds(int)
					TaskEntry = TaskEntry.Replace("#TaskHoldTheEdgeTime", TConvert)
				Loop Until Not TaskEntry.Contains("#TaskHoldTheEdgeTime")
			End If

			If TaskEntry.Contains("#TaskCBTTime") Then
				Do
					int = ssh.randomizer.Next(FrmSettings.NBTaskCBTTimeMin.Value, FrmSettings.NBTaskCBTTimeMax.Value + 1)
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
				TaskEntry = SysKeywordClean(TaskEntry)
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
			Log.WriteError("Error occurred during file processing  """ & dir & """", ex, "CleanTaskLines(String)")
			Return "ERROR: Tease AI did not return a valid Task line"
		End Try
	End Function

	Private Sub BTNFIleTransferDismiss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNFIleTransferDismiss.Click

		PNLFileTransfer.Visible = False
		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False
		LBLFileTransfer.Text = ssh.tempDomName & " is sending you a file!"
		PBFileTransfer.Value = 0

	End Sub

	Public Sub ShellExecute(ByVal File As String)
		Try
			Dim myProcess As New Process
			myProcess.StartInfo.FileName = File
			myProcess.StartInfo.UseShellExecute = True
			myProcess.StartInfo.RedirectStandardOutput = False
			myProcess.Start()
			myProcess.Dispose()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "ShellExecute failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub


	Public Sub BTNFileTransferOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNFileTransferOpen.Click
		'BUG: Clicking this Button after the session has ended, will cause an exception
		ShellExecute(ssh.TaskTextDir)

		PNLFileTransfer.Visible = False
		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False
		LBLFileTransfer.Text = ssh.tempDomName & " is sending you a file!"
		PBFileTransfer.Value = 0

	End Sub



	Private Sub SlideshowTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlideshowTimer.Tick
		'TODO: Remove CrossForm data access
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.SlideshowLoaded = False Or FrmSettings.timedRadio.Checked = False Or ssh.TeaseVideo = True Or ssh.LockImage = True Or ssh.JustShowedBlogImage = True Or ssh.CustomSlideEnabled = True Then Return

		ssh.SlideshowTimerTick -= 1

		If ssh.SlideshowTimerTick < 1 Then

TryNext:
			If My.Settings.CBSlideshowRandom Then
				ssh.SlideshowMain.NavigateNextTease()
			Else
				ssh.SlideshowMain.NavigateForward()
			End If


			If Not (File.Exists(ssh.SlideshowMain.CurrentImage) _
			  Or isURL(ssh.SlideshowMain.CurrentImage)) Then
				ClearMainPictureBox()
				Exit Sub
			End If

			Try
				ShowImage(ssh.SlideshowMain.CurrentImage, True)
				ssh.JustShowedBlogImage = False
				ssh.JustShowedSlideshowImage = True

			Catch
				GoTo TryNext
			End Try


			ssh.SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
		End If

	End Sub

	Public Sub GetEdgeTickCheck()

		If ssh.AlreadyStrokingEdge = True Then

			If ssh.AvgEdgeCount < 5 Then
				ssh.EdgeTickCheck = 60
			Else
				ssh.EdgeTickCheck = ssh.AvgEdgeStroking / ssh.AvgEdgeCount
			End If

		Else

			If ssh.AvgEdgeCountRest < 5 Then
				ssh.EdgeTickCheck = 300
			Else
				ssh.EdgeTickCheck = ssh.AvgEdgeNoTouch / ssh.AvgEdgeCountRest
			End If

		End If

	End Sub



	Private Sub EdgeCountTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdgeCountTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh.EdgeCountTick += 1

		If FrmSettings.CBEdgeUseAvg.Checked = True Then
			If ssh.EdgeCountTick > ssh.EdgeTickCheck Then ssh.LongEdge = True
		Else
			If ssh.EdgeCountTick > FrmSettings.NBLongEdge.Value * 60 Then ssh.LongEdge = True
		End If


		Dim m As Integer = TimeSpan.FromSeconds(ssh.EdgeCountTick).Minutes
		Dim s As Integer = TimeSpan.FromSeconds(ssh.EdgeCountTick).Seconds


		Dim TST As TimeSpan = TimeSpan.FromSeconds(ssh.EdgeCountTick)

		''Debug.Print("{0: c} : {1:c}", TST.Minutes, TST.Seconds)



		'Debug.Print("EdgeCountTick = " & String.Format("{0:00}:{1:00}", TST.Minutes, TST.Seconds))
	End Sub

	Private Sub StrokeTimeTotalTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrokeTimeTotalTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.SubStroking = False Then Return

		ssh.StrokeTimeTotal += 1
		'Debug.Print("StrokeTimeTotal = " & StrokeTimeTotal)

		My.Settings.StrokeTimeTotal = ssh.StrokeTimeTotal

		Dim STT As TimeSpan = TimeSpan.FromSeconds(ssh.StrokeTimeTotal)

		'LBLStrokeTimeTotal.Text = String.Format("{0:000} D {1:00} H {2:00} M {3:00} S", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)
		FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)


	End Sub






	Private Sub TnAFastSlides_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TnASlides.Tick
		Dim tmpSw As New Stopwatch

RestartFunction:
		tmpSw.Restart()
		Try
			If ssh.BoobList.Count < 1 Then Throw New Exception("No Boobs-images loaded.")
			If ssh.AssList.Count < 1 Then Throw New Exception("No Butt-images loaded.")

			Dim tmpImageToShow As String = ""
			Dim tmpLateSet As Boolean

			If New Random().Next(0, 101) < 51 Then
				tmpImageToShow = ssh.BoobList(ssh.randomizer.Next(0, ssh.BoobList.Count))
				tmpLateSet = True
			Else
				tmpImageToShow = ssh.AssList(ssh.randomizer.Next(0, ssh.AssList.Count))
				tmpLateSet = False
			End If

			Try
				ShowImage(tmpImageToShow, True)

				If tmpLateSet Then
					ssh.BoobImage = True
					ssh.AssImage = False
				Else
					ssh.BoobImage = False
					ssh.AssImage = True
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
				ssh.BoobList.RemoveAll(Function(x) x.Contains(tmpImageToShow))
				ssh.AssList.RemoveAll(Function(x) x.Contains(tmpImageToShow))
				GoTo RestartFunction
			End Try
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			TnASlides.Stop()
			Log.WriteError(ex.Message & vbCrLf & "TnA Slideshow will stop.", ex, "Exception in TnASlides.Tick occured")
			If My.Settings.CBOutputErrors = True And ssh.SaidHello = True Then ChatAddSystemMessage("<font color=""red"">ERROR: " & ex.Message & " : Exception in TnASlides.Tick occured</font>", False)
		End Try
	End Sub









#Region "---------------------------------------------------- Domme-WMP -------------------------------------------------------"

	Private Sub DomWMP_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles DomWMP.PlayStateChange


		If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
			If FrmSettings.CBMuteMedia.Checked = True Then
				DomWMP.settings.mute = True
			End If
		End If


		If (DomWMP.playState = WMPLib.WMPPlayState.wmppsStopped) Then
			'Debug.Print("WMP Stopped Called")

			VideoTimer.Stop()

			ssh.edgeMode.VideoMode = False
			ssh.yesMode.VideoMode = False
			ssh.noMode.VideoMode = False
			ssh.cameMode.VideoMode = False
			ssh.ruinMode.VideoMode = False

			DomWMP.currentPlaylist.clear()


			If ssh.CensorshipGame = True Then
				CensorshipTimer.Stop()
				CensorshipBar.Visible = False
				ssh.CensorshipGame = False
				ssh.VideoTease = False

				If ssh.RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh.SaidHello = False
					ssh.RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				RunFileText()
			End If

			If ssh.AvoidTheEdgeGame = True Then

				ssh.TeaseVideo = False
				ssh.AvoidTheEdgeGame = False
				ssh.AvoidTheEdgeStroking = False
				AvoidTheEdgeTaunts.Stop()
				ssh.VideoTease = False
				ssh.SubStroking = False


				Debug.Print("TempStrokeTauntVal = " & ssh.TempStrokeTauntVal)
				Debug.Print("TempFileText = " & ssh.TempFileText)


				If ssh.RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh.SaidHello = False
					ssh.RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				ssh.StrokeTauntVal = ssh.TempStrokeTauntVal
				ssh.FileText = ssh.TempFileText

				ssh.ScriptTick = 2
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

			If ssh.RLGLGame = True Then
				RLGLTimer.Stop()
				RLGLTauntTimer.Stop()
				ssh.RLGLGame = False
				ssh.VideoTease = False
				ssh.SubStroking = False


				If ssh.RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh.SaidHello = False
					ssh.RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				ssh.ScriptTick = 1
				ScriptTimer.Start()

				Return
			End If


			If ssh.TeaseVideo = True Then
				ssh.TeaseVideo = False
				DomWMP.Ctlcontrols.pause()
				RunFileText()
			End If


			If ssh.LockVideo = False Then
				mainPictureBox.Visible = True
				DomWMP.Visible = False
			End If


		End If

	End Sub

	Private Sub WMPTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WMPTimer.Tick


		If DomWMP.currentPlaylist.count <> 0 Then
			Try
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VideoRemaining As Integer = Math.Floor(DomWMP.currentMedia.duration - DomWMP.Ctlcontrols.currentPosition)

				Debug.Print("Video Length = " & VideoLength)
				Debug.Print("Video Remaining = " & VideoRemaining)
			Catch
			End Try
		End If





		If ssh.DomTypeCheck = True Or DomWMP.playState = WMPLib.WMPPlayState.wmppsStopped Or DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused Then Return

		'Debug.Print("New movie loaded: " & DomWMP.URL.ToString)

		ssh.VidFile = Path.GetFileName(DomWMP.URL.ToString)

		Dim VidSplit As String() = ssh.VidFile.Split(".")
		ssh.VidFile = ""
		For i As Integer = 0 To VidSplit.Count - 2
			ssh.VidFile = ssh.VidFile + VidSplit(i)
		Next
		'Debug.Print(VidFile)
		If ssh.VidFile = "" Then Exit Sub
		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & ssh.VidFile & ".txt") Then
			Dim SubCheck As String()
			Dim PlayPos As Integer
			Dim WMPPos As Integer = Math.Ceiling(DomWMP.Ctlcontrols.currentPosition)

			Dim SubList As New List(Of String)
			SubList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & ssh.VidFile & ".txt")

			If Not SubList Is Nothing Then
				For i As Integer = 0 To SubList.Count - 1
					SubCheck = SubList(i).Split("]")
					SubCheck(0) = SubCheck(0).Replace("[", "")
					Dim SubCheck2 As String() = SubCheck(0).Split(":")

					PlayPos = SubCheck2(0) * 3600
					PlayPos += SubCheck2(1) * 60
					PlayPos += SubCheck2(2)

					If WMPPos = PlayPos Then
						If (SubCheck(1).Contains("@Contact1") And ssh.contact1Present = False) Or (SubCheck(1).Contains("@Contact2") And ssh.contact2Present = False) _
						   Or (SubCheck(1).Contains("@Contact3") And ssh.contact3Present = False) Then
							'I'm positive I'm doing this the hard way -.-
						Else
							ssh.DomTask = SubCheck(1)
							TypingDelayGeneric()
							Debug.Print(SubList(i))
						End If
					End If
				Next
			End If
		End If


	End Sub

#End Region  'Domme-WMP

	Private Sub domAvatar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles domAvatar.MouseEnter
		If FrmSettings.Visible = False And FrmCardList.Visible = False Then domAvatar.Focus()
	End Sub

	Private Sub domAvatar_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles domAvatar.MouseWheel



		If domAvatar.SizeMode = PictureBoxSizeMode.StretchImage Then
			domAvatar.SizeMode = PictureBoxSizeMode.Zoom
			My.Settings.DomAVStretch = False
		Else
			domAvatar.SizeMode = PictureBoxSizeMode.StretchImage
			My.Settings.DomAVStretch = True
		End If

	End Sub


	Private Sub WaitTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaitTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTypeCheck = True Or ssh.YesOrNo = True Then Return

		'Debug.Print("WaitTick = " & WaitTick)

		ssh.WaitTick -= 1

		If ssh.WaitTick < 1 Then
			WaitTimer.Stop()
			ssh.ScriptTick = 1
			If ssh.RapidCode = True Then RunFileText()
		End If


	End Sub

	Private Sub StupidTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StupidTimer.Tick

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

		My.Settings.BronzeTokens = ssh.BronzeTokens
		My.Settings.SilverTokens = ssh.SilverTokens
		My.Settings.GoldTokens = ssh.GoldTokens

	End Sub

















	Private Sub VideoTauntTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoTauntTimer.Tick

		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.VideoTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh.VideoTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.VideoTauntTick < 6 Then Return

		ssh.VideoTauntTick -= 1


		If ssh.VideoTauntTick < 1 Then

			Dim FrequencyTemp As Integer = ssh.randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh.VideoTauntTick = ssh.randomizer.Next(20, 31)
				Return
			End If

			Dim VTDir As String

			If ssh.RLGLGame = True Then VTDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Taunts.txt"
			'TODO: Prevent File.Exits() with String.Empty
			If Not File.Exists(VTDir) Then Return

			' Read all lines of the given file.
			Dim VTList As List(Of String) = Txt2List(VTDir)

			Try
				VTList = FilterList(VTList)
				If VTList.Count < 1 Then Return
				ssh.DomTask = VTList(ssh.randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
			 VTDir, ex, "VideoTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Video Taunt from file: " & VTDir
			End Try

			TypingDelayGeneric()



			ssh.VideoTauntTick = ssh.randomizer.Next(20, 31)


		End If









	End Sub

	Private Sub TeaseTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeaseTimer.Tick


		FrmSettings.LBLDebugTeaseTime.Text = ssh.TeaseTick
		'Debug.Print("TeaseTick = " & TeaseTick)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh.TeaseTick -= 1

		If ssh.TeaseTick < 1 Then TeaseTimer.Stop()



	End Sub

	Public Sub RLGLTauntTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RLGLTauntTimer.Tick
		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.RLGLTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh.RLGLTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.RLGLTauntTick < 6 Then Return

		ssh.RLGLTauntTick -= 1


		If ssh.RLGLTauntTick < 1 Then

			Dim FrequencyTemp As Integer = ssh.randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh.RLGLTauntTick = ssh.randomizer.Next(20, 31)
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
				ssh.DomTask = VTList(ssh.randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
			 VTDir, ex, "RLGLTauntTimer.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Video Taunt from file:  " & VTDir
			End Try
			TypingDelayGeneric()



			ssh.RLGLTauntTick = ssh.randomizer.Next(20, 31)


		End If



	End Sub

	Private Sub AvoidTheEdgeTaunts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvoidTheEdgeTaunts.Tick
		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh.DomTyping = True Then Return
		If ssh.DomTypeCheck = True And ssh.AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And ssh.AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh.AvoidTheEdgeTick < 6 Then Return



		ssh.AvoidTheEdgeTick -= 1


		If ssh.AvoidTheEdgeTick < 1 Then

			Dim FrequencyTemp As Integer = ssh.randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh.AvoidTheEdgeTick = ssh.randomizer.Next(20, 31)
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
				ssh.DomTask = VTList(ssh.randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
			 VTDir, ex, "AvoidTheEdgeTaunts.Tick")
				ssh.DomTask = "ERROR: Tease AI did not return a valid Video Taunt from file:  " & VTDir
			End Try
			TypingDelayGeneric()



			ssh.AvoidTheEdgeTick = ssh.randomizer.Next(20, 31)


		End If


	End Sub

#Region "-------------------------------------------------- MainPictureBox ----------------------------------------------------"

	Private Sub mainPictureBox_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles mainPictureBox.LoadCompleted
		ssh.ImageLocation = mainPictureBox.ImageLocation
		CheckDommeTags()
		Debug.Print("ImageLoadCOmpleted")
	End Sub

	Private Sub mainPictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mainPictureBox.MouseDown
		If e.Button = MouseButtons.Right Then
			PictureStrip.Show(CType(sender, Control), e.Location)
		End If
	End Sub



#End Region  ' MainPictureBox

#Region "-------------------------------------------------- PictureStrip ------------------------------------------------------"



	Private Sub PictureStrip_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PictureStrip.Opening

		If mainPictureBox.Image IsNot Nothing Then
			Dim sh As ContactData = ssh.SlideshowMain

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

			If isURL(ssh.ImageLocation) Then

				PicStripTSMIsaveImage.Enabled = True
				PicStripTSMISaveImageTo.Enabled = True
				PicStripTSMIremoveFromURL.Enabled = True

			ElseIf ssh.ImageLocation = "" Or sh.ImageList.Contains(ssh.ImageLocation) Then

				PicStripTSMIcopyImageLocation.Enabled = False
				PicStripTSMIsaveImage.Enabled = False
				PicStripTSMISaveImageTo.Enabled = False
				PicStripTSMIlikeImage.Enabled = False
				PicStripTSMIlikeImage.Checked = False
				PicStripTSMIdislikeImage.Enabled = False
				PicStripTSMIdislikeImage.Checked = False
				PicStripTSMIremoveFromURL.Enabled = False

				If sh.ImageList.Contains(ssh.ImageLocation) Then
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
			If tmp.Contains(ssh.ImageLocation) Then PicStripTSMIlikeImage.Checked = True

			tmp = Txt2List(pathDislikeList)
			If tmp.Contains(ssh.ImageLocation) Then PicStripTSMIdislikeImage.Checked = True

		End If

	End Sub

	Private Sub PictureStripTmsiDisableAnimation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PicStripTmsiDisableAnimation.Click
		If mreImageanimator.WaitOne(0) = True Then
			' Signals the ImageAnimatorThread to pause.
			mreImageanimator.Reset()
		Else
			' Signals the ImageAnimatorThread to resume.
			mreImageanimator.Set()
		End If
	End Sub

	Private Sub PicStripTSMIcopyImageLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIcopyImageLocation.Click

		My.Computer.Clipboard.SetText(ssh.ImageLocation)

	End Sub


	Public Sub PicStripTSMI_SaveImage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIsaveHardcore.Click,
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

	Private Sub PicStripTSMIlikeImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIlikeImage.Click,
							PicStripTSMIdislikeImage.Click
		' Exit if ImageLocation is unkown
		If ssh.ImageLocation = "" Then Exit Sub

		Dim tmpFilePath As String = ""
		Dim lazytext As String = ""
		Try
			Dim tmpTsmi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)


			' Set the filepath to delete from or add to
			If tmpTsmi Is PicStripTSMIlikeImage Then
				tmpFilePath = pathLikeList
			ElseIf tmpTsmi Is PicStripTSMIdislikeImage Then
				tmpFilePath = pathDislikeList
			Else
				Throw New NotImplementedException("This Toolstripmenuitem is not implemented yet")
			End If


			If tmpTsmi.Checked Then
				' Remove from the given file 
				lazytext = "remove path from file: " & tmpFilePath
				TxtRemoveLine(tmpFilePath, ssh.ImageLocation)
				tmpTsmi.Checked = False
			ElseIf File.Exists(tmpFilePath) Then
				lazytext = "append path  to file: " & tmpFilePath
				' Append to existing file 
				My.Computer.FileSystem.WriteAllText(tmpFilePath, Environment.NewLine & ssh.ImageLocation, True)
			Else
				lazytext = "add path to New file: " & tmpFilePath
				' create a new file
				My.Computer.FileSystem.WriteAllText(tmpFilePath, ssh.ImageLocation, True)
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

	Private Sub PicStripTSMIremoveFromURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIremoveFromURL.Click
		Try
			' Lock Control
			PicStripTSMIremoveFromURL.Enabled = False

			' Remove from URL-Files.
			RemoveFromUrlFiles(ssh.ImageLocation)
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

	Private Sub PicStripTSMIdommeSlideshowGoToLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIdommeSlideshowGoToLast.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If ssh.SlideshowLoaded = False Or ssh.TeaseVideo = True Or ssh.LockImage = True Then Return

		Try
			ShowImage(ssh.SlideshowMain.NavigateLast, True)
			ssh.JustShowedBlogImage = False
		Catch

		End Try
	End Sub

	Private Sub PicStripTSMIdommeSlideshow_GoToFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIdommeSlideshow_GoToFirst.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If ssh.SlideshowLoaded = False Or ssh.TeaseVideo = True Or ssh.LockImage = True Then Return

		Try
			ShowImage(ssh.SlideshowMain.NavigateFirst, True)
			ssh.JustShowedBlogImage = False
		Catch

		End Try
	End Sub

	Private Sub PicStripTSMIdommeSlideshowLoadNewSlideshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicStripTSMIdommeSlideshowLoadNewSlideshow.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If ssh.SlideshowLoaded = False Or ssh.TeaseVideo = True Or ssh.LockImage = True Then Return

		Try
			ssh.newSlideshow = True
			LoadDommeImageFolder()
		Catch

		End Try


	End Sub

#End Region  ' DommeSlideshow

#End Region  ' PictureStrip

	Public Sub LoadDommeImageFolder()
		'check which domme should be loaded
		If Not ssh.newSlideshow Then
			If ssh.glitterDommeNumber = 0 Then
				If FrmSettings.CBRandomDomme.Checked = False Then
					ssh.SlideshowMain = New ContactData(ContactType.Domme)
					ssh.tempHonorific = My.Settings.SubHonorific
				Else
					ssh.SlideshowMain = New ContactData(ContactType.Random)
					ssh.tempHonorific = PoundClean(My.Settings.RandomHonorific)
				End If
			ElseIf ssh.glitterDommeNumber = 1 Then
				ssh.SlideshowMain = New ContactData(ContactType.Contact1)
				ssh.tempHonorific = My.Settings.G1Honorific
			ElseIf ssh.glitterDommeNumber = 2 Then
				ssh.SlideshowMain = New ContactData(ContactType.Contact2)
				ssh.tempHonorific = My.Settings.G2Honorific
			ElseIf ssh.glitterDommeNumber = 3 Then
				ssh.SlideshowMain = New ContactData(ContactType.Contact3)
				ssh.tempHonorific = My.Settings.G3Honorific
			ElseIf ssh.glitterDommeNumber = 4 Then
				ssh.SlideshowMain = New ContactData(ContactType.Random)
				ssh.tempHonorific = PoundClean(My.Settings.RandomHonorific)
			End If
			ssh.contactToUse = ssh.SlideshowMain
		End If
		ssh.SlideshowMain.LoadNew(ssh.newSlideshow)
		ssh.tempDomName = ssh.SlideshowMain.TypeName
		ssh.tempDomHonorific = ssh.tempHonorific
		If ssh.tempDomName <> My.Settings.DomName Then
			Dim avatarImage As String = checkForImage("/avatar.*", ssh.SlideshowMain.getCurrentBaseFolder(ssh.SlideshowMain.Contact))
			If avatarImage = "" Then avatarImage = ssh.SlideshowMain.ImageList(ssh.randomizer.Next(0, ssh.SlideshowMain.ImageList().Count - 1))
			domAvatar.Image = Image.FromFile(avatarImage)
			ssh.domAvatarImage = domAvatar.Image
		End If
		ssh.shortName = ssh.SlideshowMain.ShortName
		Me.domName.Text = ssh.tempDomName
		FrmSettings.LBLCurrentDomme.Text = ssh.tempDomName
		ssh.newSlideshow = False

		ShowImage(ssh.SlideshowMain.CurrentImage, False)
		ssh.SlideshowLoaded = True
		ssh.JustShowedBlogImage = False

		nextButton.Enabled = True
		previousButton.Enabled = True
		PicStripTSMIdommeSlideshow.Enabled = True

		If ssh.RiskyDeal = True Then FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh.SlideshowMain.CurrentImage)

		If FrmSettings.timedRadio.Checked = True Then
			ssh.SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
			SlideshowTimer.Start()
		End If


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

		'===============================================================================
		'							Clean leftover @Commands(
		'===============================================================================
		If CFClean.Contains("@Variable[") Then
			CFClean = CFClean.Replace("@Variable[" & GetParentheses(CFClean, "@Variable[", 2) & "]", "")
			If CFClean.Contains("And[") Then CFClean = CFClean.Replace("And[" & GetParentheses(CFClean, "And[", 2) & "]", "")
			If CFClean.Contains("Or[") Then CFClean = CFClean.Replace("Or[" & GetParentheses(CFClean, "Or[", 2) & "]", "")
		End If

		For Each com As String In New List(Of String) From
		  {"@Cup(", "@AllowsOrgasm(", "@RuinsOrgasm(", "@DommeLevel(",
		  "@ApathyLevel(", "@Month(", "@Day(", "@Flag(", "@NotFlag(",
		  "@DayOfWeek(", "@FlagOr(", "@CheckDate(", "@ControlFlag("}
			If CFClean.Contains(com) Then CFClean = CFClean.Replace(com & GetParentheses(CFClean, com) & ")", "")
		Next

		'===============================================================================
		'					  Clean all other remaining @Commands
		'===============================================================================
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
		Return CFClean.Trim

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
		If ssh.KeywordError <> "" Then
			FormatClean = FormatClean.Replace(ssh.KeywordError, "")
			ssh.KeywordError = ""
		End If

		Return FormatClean
	End Function



	Private Sub CustomSlideshowTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomSlideshowTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		Try
			Dim sw As New Stopwatch
restartInstantly:
			sw.Restart()

			' Check if the timer is supposed to be running 
			If ssh.CustomSlideEnabled = False Then
				CustomSlideshowTimer.Stop()
				Exit Sub
			End If

			' Determine if local images are preferred .
			Dim PreferOffline As Boolean = If(CustomSlideshowTimer.Interval < 1000, True, False)

			' Display a random image.
			ShowImage(ssh.CustomSlideshow.GetRandom(PreferOffline), True)

			' If displaying the image took longer as the interval, restart instantly.
			If sw.ElapsedMilliseconds > CustomSlideshowTimer.Interval Then GoTo restartInstantly
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

	Private Sub updateGroup(contact As String)
		Dim name As String
		Select Case contact
			Case 1
				name = My.Settings.Glitter1
			Case 2
				name = My.Settings.Glitter2
			Case 3
				name = My.Settings.Glitter3
			Case Else
				name = ssh.SlideshowMain.TypeName
		End Select

		If Not ssh.Group.Contains(contact) Then
			ssh.Group = ssh.Group & contact
			ssh.GlitterTease = True
			ChatAddSystemMessage(name & " has joined the Chat room", False)
		Else
			ssh.Group = ssh.Group.Replace(contact, "")
			ChatAddSystemMessage(name & " has left the Chat room", False)
		End If

		If ssh.Group = "D" Then
			ssh.GlitterTease = False
		Else
			ssh.GlitterTease = True
		End If
	End Sub




#Region "------------------------------------------------------ MenuStuff -----------------------------------------------------"

	Private Sub MenuStrip2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStrip2.Leave
		If FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
			MainMenuStrip.Visible = False
		End If
	End Sub

#Region "-------------------------------------------------------- File --------------------------------------------------------"

	Private Sub dompersonalitycombobox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dompersonalitycombobox.LostFocus
		My.Settings.DomPersonality = dompersonalitycombobox.Text
	End Sub

	Private Sub dompersonalitycombobox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dompersonalitycombobox.SelectedIndexChanged
		If FormLoading = True Then Exit Sub

		Try
			My.Settings.DomPersonality = dompersonalitycombobox.Text

			FrmSettings.LBLGlitModDomType.Text = dompersonalitycombobox.Text

			ssh.DomPersonality = dompersonalitycombobox.Text

			FrmSettings.LoadStartScripts()
			FrmSettings.LoadModuleScripts()
			FrmSettings.LoadLinkScripts()
			FrmSettings.LoadEndScripts()


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
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error on changing Personality")
			MessageBox.Show(ex.Message, "Error on changing Personality", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub SuspendSessionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuspendSessionToolStripMenuItem.Click
		Try
			Dim filename As String = SavedSessionDefaultPath

			If ssh.SaidHello = False Then
				MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!",
			  MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			End If

			'	 ===============================================================================
			'						 Custom Location if Control-Key pressed
			'	 ===============================================================================
			If My.Computer.Keyboard.CtrlKeyDown Then
				Dim fsd As New SaveFileDialog With {.Filter = "Saved Session|*" & Path.GetExtension(SavedSessionDefaultPath) & "",
						 .InitialDirectory = Path.GetDirectoryName(SavedSessionDefaultPath),
						 .Title = "Select a destination to safe the sessin to.",
						 .FileName = Now.ToString("yy-MM-dd_HH-mm-ss") & "_" & dompersonalitycombobox.Text,
						 .AddExtension = True,
						 .CheckPathExists = True,
						 .OverwritePrompt = True,
						 .ValidateNames = True}
				If fsd.ShowDialog() = DialogResult.Cancel Then Exit Sub

				filename = fsd.FileName
				'===============================================================================
				'						Check if default-File exists
				'===============================================================================
			ElseIf File.Exists(filename) _
			AndAlso MessageBox.Show(Me, "A previous saved state already exists!" &
				  vbCrLf & vbCrLf &
				  "Do you wish to overwrite it?", "Warning!",
				  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
				Exit Sub
			End If

			' Store Session to disk
			ssh.Save(filename)

			MessageBox.Show(Me, "Session state has been saved successfully!", "Success!",
				MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show(Me, "An error occurred and the state did not save correctly!" &
		  vbCrLf & vbCrLf & ex.Message,
		  "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub ResumeSessionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeSessionToolStripMenuItem.Click
		Try
			Dim filename As String = SavedSessionDefaultPath


			'	 ===============================================================================
			'						 Custom Location if Control-Key pressed
			'	 ===============================================================================
			If My.Computer.Keyboard.CtrlKeyDown Then
				Dim fsd As New OpenFileDialog With {.Filter = "Saved Session|*" & Path.GetExtension(SavedSessionDefaultPath) & "",
						 .InitialDirectory = Path.GetDirectoryName(SavedSessionDefaultPath),
						 .Title = "Select a saved session to resume.",
						 .CheckPathExists = True,
						 .CheckFileExists = True,
						 .AddExtension = True,
						 .ValidateNames = True}
				If fsd.ShowDialog() = DialogResult.Cancel Then Exit Sub

				filename = fsd.FileName
				'===============================================================================
				'						Check if default-File exists
				'===============================================================================
			ElseIf Not File.Exists(filename) Then
				MessageBox.Show(Me, Path.GetFileName(SavedSessionDefaultPath) & " could not be found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			End If

			If ssh.SaidHello = True _
			AndAlso MessageBox.Show(Me, "Resuming a previous state will cause you to lose your progress in this session!" &
				  vbCrLf & vbCrLf &
				  "Do you wish to proceed?", "Warning!",
				  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
				Exit Sub
			End If

			ssh.Load(filename, True)
			Me.domName.Text = ssh.tempDomName
			FrmSettings.LBLCurrentDomme.Text = ssh.tempDomName
			If Not IsNothing(ssh.domAvatarImage) Then domAvatar.Image = ssh.domAvatarImage
			If ssh.SaidHello And My.Settings.LockOrgasmChances Then _
			 FrmSettings.LockOrgasmChances(True)
			ScriptTimer.Start()
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show(Me, "An error occurred and the state was not loaded correctly!" &
		  vbCrLf & vbCrLf & ex.Message,
		  "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try
	End Sub

	Private Sub ResetSessionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetSessionToolStripMenuItem.Click

		If ssh.SaidHello = False Then
			MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ssh.Reset()
		FrmSettings.LockOrgasmChances(False)

		If ssh.DomTypeCheck = False Then
			ssh.DomTask = "@SystemMessage Tease AI has been reset"
			TypingDelayGeneric()
		End If
		setStartName()
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click,
							ExitToolStripMenuItem1.Click
		Me.Close()
		Me.Dispose()
	End Sub

#End Region  ' File

#Region "------------------------------------------------------ Settings ------------------------------------------------------"

	Private Sub GeneralSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralSettingsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(0)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub DommeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DommeToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(1)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub SubToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(2)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ScriptsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(3)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(4)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub TaggingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaggingToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(5)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub URLFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles URLFilesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(6)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub VideoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(7)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub AppsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppsToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(8)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub RangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(10)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ModdingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModdingToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(11)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub MiscToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MiscToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(12)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

#End Region  ' Settings

#Region "-------------------------------------------------------- APPs --------------------------------------------------------"

	Private Sub CloseAppPanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAppPanelToolStripMenuItem.Click
		CloseApp(Nothing)
	End Sub

	Private Sub MetronomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetronomeToolStripMenuItem.Click
		CloseApp(PNLMetronome)
	End Sub

	Private Sub GlitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlitterToolStripMenuItem.Click
		CloseApp(PnlGlitter)
	End Sub

	Private Sub DommeTagsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DommeTagsToolStripMenuItem2.Click
		CloseApp(PNLDomTagBTN)
	End Sub

	Private Sub LazySubToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LazySubToolStripMenuItem.Click
		CloseApp(PNLLazySub)
	End Sub

	Private Sub RandomizerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizerToolStripMenuItem.Click
		CloseApp(PNLAppRandomizer)
	End Sub

	Private Sub PlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaylistToolStripMenuItem.Click
		If PNLPlaylist.Visible = False Then
			CloseApp(PNLPlaylist)
			LBPlaylist.Items.Clear()
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				LBPlaylist.Items.Add(Path.GetFileName(foundFile).Replace(".txt", ""))
			Next
		End If
	End Sub

	Private Sub WritingTasksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WritingTasksToolStripMenuItem.Click
		CloseApp(PNLWritingTask)
	End Sub

	Private Sub WishlistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WishlistToolStripMenuItem.Click
		If PNLWishList.Visible = False Then



			If My.Settings.ClearWishlist = True Then

				MessageBox.Show(Me, "You have already purchased " & ssh.tempDomName & "'s Wishlist item for today!" & Environment.NewLine & Environment.NewLine &
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

				LBLWishlistDom.Text = ssh.tempDomName & "'s Wishlist"
				LBLWishlistDate.Text = FormatDateTime(Now, DateFormat.ShortDate).ToString()
				WishlistCostGold.Visible = False
				WishlistCostSilver.Visible = False
				LBLWishlistBronze.Text = ssh.BronzeTokens
				LBLWishlistSilver.Text = ssh.SilverTokens
				LBLWishlistGold.Text = ssh.GoldTokens
				LBLWishListText.Text = ""



				Dim WishDir As String = WishList(ssh.randomizer.Next(0, WishList.Count))

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
					If ssh.GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & ssh.tempDomName
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					If ssh.SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & ssh.tempDomName
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If



				My.Settings.WishlistDate = FormatDateTime(Now, DateFormat.ShortDate)







			Else



				LBLWishlistDom.Text = ssh.tempDomName & "'s Wishlist"
				LBLWishlistDate.Text = FormatDateTime(Now, DateFormat.ShortDate).ToString()
				LBLWishlistBronze.Text = ssh.BronzeTokens
				LBLWishlistSilver.Text = ssh.SilverTokens
				LBLWishlistGold.Text = ssh.GoldTokens


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
					If ssh.GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "????? Gold"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					Debug.Print("Silver Caled PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP")
					If ssh.SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "???? Silver"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

			End If







			LBLWishlistBronze.Text = ssh.BronzeTokens
			LBLWishlistSilver.Text = ssh.SilverTokens
			LBLWishlistGold.Text = ssh.GoldTokens

			If WishlistCostGold.Visible = True Then
				If ssh.GoldTokens >= Val(LBLWishlistCost.Text) Then
					BTNWishlist.Text = "Purchase for " & ssh.tempDomName
					BTNWishlist.Enabled = True
				Else
					BTNWishlist.Text = "Not Enough Tokens!"
					BTNWishlist.Enabled = False
				End If
			End If

			If WishlistCostSilver.Visible = True Then
				Debug.Print("Silver Called")
				If ssh.SilverTokens >= Val(LBLWishlistCost.Text) Then
					BTNWishlist.Text = "Purchase for " & ssh.tempDomName
					BTNWishlist.Enabled = True
				Else
					BTNWishlist.Text = "Not Enough Tokens!"
					BTNWishlist.Enabled = False
				End If
			End If






			CloseApp(PNLWishList)
		End If
	End Sub

	Private Sub HypnoticGuideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HypnoticGuideToolStripMenuItem.Click
		CloseApp(PNLHypnoGen)
		If PNLHypnoGen.Visible = False Then



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

	Private Sub VitalSubToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VitalSubToolStripMenuItem.Click
		CloseApp(AppPanelVitalSub)
		If AppPanelVitalSub.Visible = False Then

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

#End Region  ' APPs

#Region "-------------------------------------------------------- Games -------------------------------------------------------"

	Private Sub SlotsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlotsToolStripMenuItem1.Click,
							SlotsToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(0)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub MatchGameToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatchGameToolStripMenuItem1.Click,
							 MatchGameToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(1)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub RiskyPickToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiskyPickToolStripMenuItem1.Click,
							 RiskyPickToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(2)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub ExchangeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangeToolStripMenuItem1.Click,
							 ExchangeToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(3)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub CollectionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionToolStripMenuItem1.Click,
							 CollectionToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(4)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

#End Region  ' Games

#Region "----------------------------------------------------- Interface ------------------------------------------------------"

	Private Sub SwitchSidesToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchSidesToolStripMenuItem.CheckedChanged
		' Prevent further execution during Form's InitializeComponent()-Method.
		If IsHandleCreated = False Then Exit Sub

		With PnlSidepanelLayout
			If SwitchSidesToolStripMenuItem.Checked Then
				My.Settings.MirrorWindows = True
				PnlSidepanelLayout.Dock = DockStyle.Right
			Else
				My.Settings.MirrorWindows = False
				PnlSidepanelLayout.Dock = DockStyle.Left
			End If

			.Padding = New Padding(.Padding.Right, .Padding.Top, .Padding.Left, .Padding.Bottom)
			PnlLayoutForm.Padding = New Padding(PnlLayoutForm.Padding.Right,
			   PnlLayoutForm.Padding.Top,
			   PnlLayoutForm.Padding.Left,
			   PnlLayoutForm.Padding.Bottom)
		End With
	End Sub

	Private Sub SideChatToolStripMenuItem1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideChatToolStripMenuItem1.CheckedChanged
		' Prevent further execution during Form's InitializeComponent()-Method.
		If IsHandleCreated = False Then Exit Sub

		If SideChatToolStripMenuItem1.Checked = False Then
			My.Settings.SideChat = False
			CloseApp(Nothing)
		Else
			My.Settings.SideChat = True
			CloseApp(PnlSidechat)
		End If
	End Sub

	Private Sub LazySubAVToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LazySubAVToolStripMenuItem.CheckedChanged
		' Prevent further execution during Form's InitializeComponent()-Method.
		If IsHandleCreated = False Then Exit Sub

		If LazySubAVToolStripMenuItem.Checked = True Then
			'#################### Display LazySubAv ###################
			My.Settings.LazySubAV = True
			PNLLazySubAV.BringToFront()
			PnlAvatarInner.SendToBack()
		Else
			'##################### Hide LazySubAv #####################
			My.Settings.LazySubAV = False
			PNLLazySubAV.SendToBack()
			PnlAvatarInner.BringToFront()
		End If
	End Sub

	Private Sub ThemesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThemesToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(9)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub MaximizeImageToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximizeImageToolStripMenuItem.CheckedChanged
		' Prevent further execution during Form's InitializeComponent()-Method.
		If IsHandleCreated = False Then Exit Sub

		If MaximizeImageToolStripMenuItem.Checked = False Then
			'########################## Normal ########################
			My.Settings.MaximizeMediaWindow = False
			SplitContainer1.Panel2Collapsed = False
			PnlChatBoxLayout.Visible = True
			SplitContainer1.SplitterDistance = SplitContainer1.Height * 0.75
		Else
			'######################### Maximize #######################
			My.Settings.MaximizeMediaWindow = True
			SplitContainer1.Panel2Collapsed = True
			If PnlSidechat.Visible AndAlso PnlSidepanelLayout.Visible Then PnlChatBoxLayout.Visible = False
		End If

		'SplitContainer1.SplitterDistance = SplitContainer1.Height
	End Sub

	Private Sub SidepanelToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SidepanelToolStripMenuItem.CheckedChanged
		' Prevent further execution during Form's InitializeComponent()-Method.
		If IsHandleCreated = False Then Exit Sub

		If SidepanelToolStripMenuItem.Checked Then
			'########################## Display #######################
			PnlSidepanelLayout.Visible = True
			My.Settings.DisplaySidePanel = True

			If PnlSidepanelLayout.Dock = DockStyle.Left Then
				PnlLayoutForm.Padding = New Padding(0,
						  PnlLayoutForm.Padding.Top,
						  PnlLayoutForm.Padding.Right,
						  PnlLayoutForm.Padding.Bottom)
			Else
				PnlLayoutForm.Padding = New Padding(PnlLayoutForm.Padding.Left,
						  PnlLayoutForm.Padding.Top,
						 0,
						  PnlLayoutForm.Padding.Bottom)
			End If
		Else
			'########################### Hide #########################
			PnlSidepanelLayout.Visible = False
			My.Settings.DisplaySidePanel = False

			If PnlSidepanelLayout.Dock = DockStyle.Left Then
				PnlLayoutForm.Padding = New Padding(PnlLayoutForm.Padding.Right,
						  PnlLayoutForm.Padding.Top,
						  PnlLayoutForm.Padding.Right,
						  PnlLayoutForm.Padding.Bottom)
			Else
				PnlLayoutForm.Padding = New Padding(PnlLayoutForm.Padding.Left,
						  PnlLayoutForm.Padding.Top,
						 PnlLayoutForm.Padding.Left,
						  PnlLayoutForm.Padding.Bottom)
			End If

			If MaximizeImageToolStripMenuItem.Checked Then PnlChatBoxLayout.Visible = True
		End If
	End Sub

	Private Sub WebteaseModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebteaseModeToolStripMenuItem.Click
		If FrmSettings.CBWebtease.Checked = True Then
			WebteaseModeToolStripMenuItem.Checked = False
			FrmSettings.CBWebtease.Checked = False
		Else
			WebteaseModeToolStripMenuItem.Checked = True
			FrmSettings.CBWebtease.Checked = True
		End If

		My.Settings.CBWebtease = FrmSettings.CBWebtease.Checked

	End Sub

	Private Sub DefaultImageSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultImageSizeToolStripMenuItem.Click
		If SplitContainer1.Height > 430 Then SplitContainer1.SplitterDistance = SplitContainer1.Height - 252
	End Sub

	Private Sub FullscreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullscreenToolStripMenuItem.Click
		If Me.FormBorderStyle <> Windows.Forms.FormBorderStyle.None Then
			Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

			Dim WA As Rectangle = Screen.GetBounds(Me)

			Me.Location = New Point(WA.Location.X, WA.Location.Y)
			Me.Size = New Size(WA.Width, WA.Height)

			Me.WindowState = FormWindowState.Normal
			Me.MainMenuStrip.Visible = False
		Else
			Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
			Me.Location = New Point(0, 0)
			Me.Size = New Size(My.Settings.WindowWidth, My.Settings.WindowHeight)
			Me.MainMenuStrip.Visible = True

			RestoreFormPosition()
		End If
	End Sub

	Private Sub RestoreFormPosition()
		Dim WA As Rectangle = Screen.GetWorkingArea(Cursor.Position)

		If My.Settings.WindowWidth = 0 Or My.Settings.WindowHeight = 0 Then
			Me.WindowState = FormWindowState.Maximized
		Else
			Me.Width = If(WA.Width > Me.Width, My.Settings.WindowWidth, WA.Width)
			Me.Height = If(WA.Height > Me.Height, My.Settings.WindowHeight, WA.Height)
		End If

		Me.Left = WA.Location.X + (WA.Width - Me.Width) / 2
		Me.Top = WA.Location.Y + (WA.Height - Me.Height) / 2
	End Sub

#End Region  ' Interface

#Region "------------------------------------------------------- Tools --------------------------------------------------------"

	Private Sub CommandGuideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandGuideToolStripMenuItem.Click
		If Form10.Visible = False Then Form10.Show()
		Form10.Focus()
	End Sub

	Private Sub AIBoxesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIBoxesToolStripMenuItem.Click
		If Form9.Visible = False Then Form9.Show()
		Form9.Focus()
	End Sub

	Private Sub OldDommeTagsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OldDommeTagsToolStripMenuItem.Click
		Form8.Show()
	End Sub

#End Region  ' Tools

#Region "------------------------------------------------------ Milovana ------------------------------------------------------"

	Private Sub OpenBetaThreadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenBetaThreadToolStripMenuItem.Click,
							  OpenBetaThreadToolStripMenuItem1.Click
		Process.Start("https://milovana.com/forum/viewtopic.php?f=2&t=15776")
	End Sub

	Private Sub BugReportThreadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BugReportThreadToolStripMenuItem.Click,
							  BugReportThreadToolStripMenuItem1.Click
		Process.Start("https://milovana.com/forum/viewtopic.php?f=2&t=16203")
	End Sub

	Private Sub WebteasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebteasesToolStripMenuItem.Click,
							 WebteasesToolStripMenuItem1.Click
		Process.Start("https://milovana.com/webteases/")
	End Sub

	Private Sub AllAndEverythingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllAndEverythingToolStripMenuItem.Click,
							   ForumToolStripMenuItem.Click
		Process.Start("https://milovana.com/forum/")
	End Sub

#End Region  ' Milovana

	Private Sub StartTimer1ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartTimer1ToolStripMenuItem.Click
		Timer1.Start()
	End Sub

	Private Sub RunScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunScriptToolStripMenuItem.Click

		If OpenScriptDialog.ShowDialog() = DialogResult.OK Then

			ssh.StrokeTauntVal = -1

			If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh.FileText = OpenScriptDialog.FileName
			ssh.BeforeTease = False
			ssh.ShowModule = True
			ssh.SaidHello = True
			ssh.ScriptTick = 1
			ScriptTimer.Start()

		End If

	End Sub

	Private Sub DebugSessionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DebugSessionWindowToolStripMenuItem.Click
		dbgSessionForm.Show()
	End Sub

	Private Sub DebugMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugMenuToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(13)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub DebugToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles DebugToolStripMenuItem.DropDownOpening
		StartTimer1ToolStripMenuItem.Enabled = Not Timer1.Enabled
	End Sub

	Private Sub RefreshRandomizerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshRandomizerToolStripMenuItem.Click
		ssh.randomizer = New Random(System.DateTime.Now.Ticks Mod System.Int32.MaxValue)
	End Sub

	Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(14)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub



#End Region  ' Menu





	Private Sub TeaseAIClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeaseAIClock.Tick
		' Reset the WatchdogTimer Clock. 
		WatchDogImageAnimator.Reset(TeaseAIClock.Interval * 3)


		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			LBLTime.Text = Format(Now, "h:mm")
			LBLAMPM.Text = Format(Now, "tt")
			LBLDate.Text = Format(Now, "Long Date")
			Return
		End If

		If ssh.WritingTaskFlag = False Or (ssh.WritingTaskFlag = True And My.Settings.TimedWriting = False) Then
			LBLTime.Text = Format(Now, "h:mm")
			LBLAMPM.Text = Format(Now, "tt")
			LBLDate.Text = Format(Now, "Long Date")
		Else
			If ssh.WritingTaskCurrentTime > 0 Then
				If My.Settings.TimedWriting = True Then
					LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times" & vbCrLf & "You have " & ConvertSeconds(ssh.WritingTaskCurrentTime)
					LBLTime.Text = Convert.ToInt16(ssh.WritingTaskCurrentTime)
				Else
					LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times"
				End If
			Else
				If My.Settings.TimedWriting = True Then
					LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times" & vbCrLf & "YOUR TIME IS UP"
					LBLTime.Text = "Time's Up"
					'immediately ends the writing task if time is up without waiting for next user input
					ChatAddWritingTaskInfo("<span style=""color: red;"">Time Expired</div>")

					ClearWriteTask()
					ssh.SkipGotoLine = True
					ssh.FileGoto = "Failed Writing Task"
					GetGoto()
					ssh.ScriptTick = 4
					ScriptTimer.Start()
				Else
					LBLWritingTask.Text = "Write the following line " & ssh.WritingTaskLinesAmount & " times"
				End If

			End If
			ssh.WritingTaskCurrentTime -= 1

			LBLAMPM.Text = ""
		End If




		If VariableExists("SYS_WakeUp") Then

			Dim DateFromFile As String = FormatDateTime(Now, DateFormat.ShortDate) & " " & GetDate("SYS_WakeUp").ToLongTimeString

			Dim DDiff As Integer
			DDiff = DateDiff(DateInterval.Hour, Date.Parse(DateFromFile), Now)

			ssh.GeneralTime = "Night"
			If DDiff < -20 Then ssh.GeneralTime = "Morning"
			If DDiff > -2 And DDiff < 5 Then ssh.GeneralTime = "Morning"
			If DDiff > 4 And DDiff < 12 Then ssh.GeneralTime = "Afternoon"
			If DDiff > -21 And DDiff < -11 Then ssh.GeneralTime = "Afternoon"

		Else

			Dim SetDate As Date = FormatDateTime(FrmSettings.TimeBoxWakeUp.Value, DateFormat.LongTime)
			SetVariable("SYS_WakeUp", FormatDateTime(SetDate, DateFormat.LongTime))
			My.Settings.WakeUp = FormatDateTime(Now, DateFormat.ShortDate) & " " & GetDate("SYS_WakeUp").ToLongTimeString

			Debug.Assert(SetDate.ToLongTimeString = My.Settings.WakeUp.ToLongTimeString,
						 "Value for SYS_WakeUp is different after loading.")

		End If

		If ssh.CountUpList.Count > 0 Then
			For i As Integer = 0 To ssh.CountUpList.Count - 1
				ChangeVariable(ssh.CountUpList(i), ssh.CountUpList(i), "+", 1)
			Next
		End If

		If ssh.CountDownList.Count > 0 Then
			For i As Integer = 0 To ssh.CountDownList.Count - 1
				ChangeVariable(ssh.CountDownList(i), ssh.CountDownList(i), "-", 1)
			Next
		End If

	End Sub

	Public Sub StrokeSpeedCheck()

		If ssh.StrokeFaster = True Then
			If ssh.SubStroking = True And ssh.SubEdging = False And ssh.SubHoldingEdge = False Then
				Debug.Print("Stroke Faster")
				Dim Stroke123 As Integer = ssh.randomizer.Next(5, 12)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace - Stroke123
				If StrokePace < NBMaxPace.Value Then StrokePace = NBMaxPace.Value

			End If
			ssh.StrokeFaster = False
		End If

		If ssh.StrokeSlower = True Then
			If ssh.SubStroking = True And ssh.SubEdging = False And ssh.SubHoldingEdge = False Then
				Debug.Print("Stroke Slower")
				Dim Stroke123 As Integer = ssh.randomizer.Next(3, 8)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace + Stroke123
				If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value

			End If
			ssh.StrokeSlower = False
		End If

		If ssh.StrokeFastest = True Then
			If ssh.SubStroking = True And ssh.SubEdging = False And ssh.SubHoldingEdge = False Then
				Debug.Print("Stroke Fastest")
				StrokePace = NBMaxPace.Value

			End If
			ssh.StrokeFastest = False
		End If

		If ssh.StrokeSlowest = True Then
			If ssh.SubStroking = True And ssh.SubEdging = False And ssh.SubHoldingEdge = False Then
				Debug.Print("Stroke Slowest")
				StrokePace = NBMinPace.Value

			End If
			ssh.StrokeSlowest = False
		End If

	End Sub














	Public Sub CloseApp(ByVal appToOpen As Panel)
		If appToOpen Is Nothing AndAlso My.Settings.SideChat Then
			appToOpen = PnlSidechat
		End If

		For Each pnl As Control In PNLTabs.Controls
			If appToOpen IsNot Nothing AndAlso pnl Is appToOpen Then
				pnl.Visible = True
			Else
				pnl.Visible = False
			End If
		Next

		If appToOpen Is Nothing Then
			PNLTabs.Visible = False
			PnlTabsLayout.Visible = False
		Else
			PNLTabs.Visible = True
			PnlTabsLayout.Visible = True
		End If

		If MaximizeImageToolStripMenuItem.Checked AndAlso SidepanelToolStripMenuItem.Checked AndAlso PnlSidechat.Visible = True Then
			PnlChatBoxLayout.Visible = False
		Else
			PnlChatBoxLayout.Visible = True
		End If

	End Sub

#Region "------------------------------------------------------- Apps ---------------------------------------------------------"

#Region "--------------------------------------------------- DommeTag APP -----------------------------------------------------"

#Region "------------------------------------------------- Regular Buttons-----------------------------------------------------"

	Private Sub Face_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Face.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Boobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Boobs.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Pussy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pussy.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Ass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ass.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Legs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Legs.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Feet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Feet.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub FullyDressed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullyDressed.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub HalfDressed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalfDressed.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub GarmentCovering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GarmentCovering.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub HandsCovering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HandsCovering.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Naked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Naked.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Masturbating_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Masturbating.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Sucking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sucking.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Smiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Smiling.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub Glaring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Glaring.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub SideView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideView.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub CloseUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseUp.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub SeeThrough_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeeThrough.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub AllFours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllFours.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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


	Private Sub Piercing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Piercing.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh.SlideshowLoaded = False Then Return
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

	Private Sub TBGarment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBGarment.TextChanged
		If ssh.SlideshowLoaded = False Or TBGarment.Focused = False Then Return
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

	Private Sub TBUnderwear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUnderwear.TextChanged
		If ssh.SlideshowLoaded = False Or TBUnderwear.Focused = False Then Return
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

	Private Sub TBTattoo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBTattoo.TextChanged
		If ssh.SlideshowLoaded = False Or TBTattoo.Focused = False Then Return
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

	Private Sub TBSexToy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSexToy.TextChanged
		If ssh.SlideshowLoaded = False Or TBSexToy.Focused = False Then Return
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


	Private Sub TBFurniture_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFurniture.TextChanged
		If ssh.SlideshowLoaded = False Or TBFurniture.Focused = False Then Return
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

#End Region  ' Regular Buttons


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
		Dim TagFile As String = Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt"

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			Dim FoundFile As Boolean = False

			For i As Integer = 0 To TagList.Count - 1
				If TagList(i).Contains(Path.GetFileName(ssh.ImageLocation)) Then
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

			If FoundFile = False Then TagList.Add(Path.GetFileName(ssh.ImageLocation) & " " & DomTag & Custom)

			If TagList.Count > 0 Then
				Dim SettingsString As String = ""
				For i As Integer = 0 To TagList.Count - 1
					SettingsString = SettingsString & TagList(i)
					If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
				Next
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt", SettingsString, False)
			End If

		ElseIf Path.GetDirectoryName(TagFile) = Path.GetDirectoryName(ssh.ImageLocation) Then
			' Only Create new file for the loaded Slidshow. This Prevents URL-Image-Tagging.
			My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt", Path.GetFileName(ssh.ImageLocation) & " " & DomTag & Custom, True)

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
		Dim TagFile As String = Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt"
		Debug.Print("TagFile = " & TagFile)

		Debug.Print("DomTag & Custom = " & DomTag & Custom)

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			For i As Integer = TagList.Count - 1 To 0 Step -1
				If TagList(i).Contains(Path.GetFileName(ssh.ImageLocation)) Then
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
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt", SettingsString, False)
			Else
				If File.Exists(Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt") Then My.Computer.FileSystem.DeleteFile(Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt")
			End If

		End If




	End Function

	Private Sub BtnDommeTagNextImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DommeTagBtnNextImage.Click
		nextButton.PerformClick()
	End Sub

	Private Sub BtnDommeTagLastImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DommeTagBtnLastImage.Click
		previousButton.PerformClick()
	End Sub

	''' <summary>
	''' <para>In Order to Work, this function has to be called AFTER an Image has been loaded into the 
	''' <see cref="Form1.mainPictureBox">PictureBox</see>. Everthing else doesn't work properly.</para>
	''' <para>Right now there are only two working non-UI-Freezing posibilities: The Imagebox 
	''' LoadCompleted-Event and PBImageThread. In PBImageThread an Invoke is required!</para>
	''' This Function uses the <see cref="form1.ssh.ImageLocation">ImageLocation</see> Variable to get the
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

		If ssh.ImageLocation = "" Then Exit Sub

		Dim tmpFileName As String = Path.GetFileName(ssh.ImageLocation)

		Dim TagFile As String = Path.GetDirectoryName(ssh.ImageLocation) & "\ImageTags.txt"

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


#End Region  ' DommeTag APP

#Region "------------------------------------------------- GlitterFeeds APP ---------------------------------------------------"

	Sub GlitterSendPost(contactID As Integer, content As String)
		Dim ConName, ConImgPath As String
		Dim BodyText As String = If(StatusUpdates.Document Is Nothing, "", StatusUpdates.Document.Body.InnerHtml)

		If contactID = 0 Then
			ConName = My.Settings.DomName
			ConImgPath = My.Settings.GlitterAV
		ElseIf contactID = 1 Then
			ConName = My.Settings.Glitter1
			ConImgPath = My.Settings.GlitterAV1
		ElseIf contactID = 2 Then
			ConName = My.Settings.Glitter2
			ConImgPath = My.Settings.GlitterAV2
		ElseIf contactID = 3 Then
			ConName = My.Settings.Glitter3
			ConImgPath = My.Settings.GlitterAV3
		Else
			Throw New ArgumentOutOfRangeException
		End If

		'===============================================================================
		'							Generate stylesheet
		'===============================================================================
		Dim Style As String = CssTryGetFile(Application.StartupPath & "/System/CSS/GlitterApp.css", My.Resources.GlitterFallbackStyle)
		Style = CssReplaceSettings(Style)

		'===============================================================================
		'							Generate body Text
		'===============================================================================
		ConImgPath = "file://" & ConImgPath.Replace("\", "/")

		BodyText &= "<div class=""post"">" & vbCrLf
		BodyText &= "  <img class=""avImg"" src=""" & ConImgPath & """>" & vbCrLf
		BodyText &= "  <span class=""avName_" & contactID & """>" & ConName & "</span>" & vbCrLf
		BodyText &= "  <span class=""timestamp"">" & Now.ToLongTimeString & "</span>" & vbCrLf
		BodyText &= "  <p class=""content"">" & content & "</p>" & vbCrLf
		BodyText &= "</div>" & vbCrLf

		Dim TextToSet As String = HtmlBuildPage("Glitter-App", Style, BodyText)


		'===============================================================================
		'							Page Output
		'===============================================================================
		Try
			StatusUpdates.DocumentText = TextToSet
		Catch ex As COMException When ex.ErrorCode = -2147024726
			MessageBox.Show("Unable to access the Webbrowser.",
						"Update Glitter-App failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try
	End Sub

	Public Sub StatusUpdatePost()
		' Read all lines of given file and remove filepath from stack.
		Dim Lines As List(Of String) = Txt2List(ssh.UpdateList(0))
		ssh.UpdateList.RemoveAt(0)

		If Lines.Count < 1 Then Exit Sub

		' Lambda expression to clean a single glitter line. 
		' Keywords and vocabulary files are processed as in regular scripts.
		' No commands are processed.
		Dim CleanString = Function(RawString As String) As String
							  RawString = PoundClean(RawString)

							  Dim SplitArray() As String = Split(RawString)
							  For i As Integer = SplitArray.Length - 1 To 0 Step -1
								  If SplitArray(i).Contains("@") Then
									  SplitArray(i) = SplitArray(i).Replace(SplitArray(i), "")
								  End If
								  If FrmSettings.CBHimHer.Checked = True Then
									  If SplitArray(i) = "He" Then SplitArray(i) = SplitArray(i).Replace("He", "She")
									  If SplitArray(i) = "he" Then SplitArray(i) = SplitArray(i).Replace("he", "she")
									  If SplitArray(i) = "Him" Then SplitArray(i) = SplitArray(i).Replace("Him", "Her")
									  If SplitArray(i) = "him" Then SplitArray(i) = SplitArray(i).Replace("him", "her")
									  If SplitArray(i) = "His" Then SplitArray(i) = SplitArray(i).Replace("His", "Her")
									  If SplitArray(i) = "his" Then SplitArray(i) = SplitArray(i).Replace("his", "her")
								  End If
							  Next
							  Return Join(SplitArray)
						  End Function


		ssh.StatusText = CleanString(Lines(0))
		Lines.RemoveAt(0)

		' ################## Set Contact updates ######################

		' Lambda expression to get a clean glitter line. 
		Dim GetLine = Function(id As Integer) As String
						  ' Get available lines for given contact
						  Dim Pool As List(Of String) = StatusClean(id, Lines)
TryAgain:
						  Dim RtnVal As String = ">"

						  If Pool.Count > 0 Then
							  ' Get random line, and remove it from orignal list, to avoid duplicates.
							  RtnVal = Pool(New Random().Next(0, Pool.Count))
							  Lines.Remove(RtnVal)
							  Pool.Remove(RtnVal)

							  ' Replace Keywords and Vocabularies.
							  RtnVal = CleanString(RtnVal)

							  ' Check if the result is empty
							  If String.IsNullOrWhiteSpace(RtnVal) Then GoTo TryAgain
						  End If

						  Return RtnVal
					  End Function

		ssh.StatusText1 = GetLine(1)
		ssh.StatusText2 = GetLine(2)
		ssh.StatusText3 = GetLine(3)

		ssh.StatusChance1 = ssh.randomizer.Next(1, 101)
		ssh.StatusChance2 = ssh.randomizer.Next(1, 101)
		ssh.StatusChance3 = ssh.randomizer.Next(1, 101)

		' ################## Begin status update ######################
		GlitterSendPost(0, ssh.StatusText)

		ssh.UpdateStageTick = ssh.randomizer.Next(10, 21)
		ssh.UpdatingPost = True
		UpdateStageTimer.Start()

	End Sub

	Public Function StatusClean(contactNumber As Integer, ByVal ListClean As List(Of String)) As List(Of String)
		Dim Exclude, RtnList As New List(Of String)

		' Create a copy of the initial list. 
		RtnList = ListClean.ConvertAll(Function(x) x)

		If contactNumber = 1 Then
			Exclude.AddRange({"@Contact2", "@Contact3"})
		ElseIf contactNumber = 2 Then
			Exclude.AddRange({"@Contact1", "@Contact3"})
		ElseIf contactNumber = 3 Then
			Exclude.AddRange({"@Contact1", "@Contact2"})
		End If

		RtnList.RemoveAll(Function(x)
							  For Each item In Exclude
								  If x.Contains(item) Then Return True
							  Next
							  Return False
						  End Function)
		Return RtnList
	End Function

	Private Sub UpdatesTimer_Tick(sender As System.Object, e As System.EventArgs) Handles UpdatesTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Exit Sub

		'If ssh.UpdateStageTick > 5 Then ssh.UpdateStageTick = 3
		'If ssh.UpdatesTick > 5 Then ssh.UpdatesTick = 3

		If My.Settings.CBGlitterFeed = False Then Exit Sub
		If ssh.UpdatingPost = True Then Exit Sub

		ssh.UpdatesTick -= 1

		If ssh.UpdatesTick > 0 Then Exit Sub

		ssh.UpdatesTick = 1080 / My.Settings.GlitterDSlider

		If ssh.UpdateList.Count < 1 Then
			Dim Lazytext As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text

			Dim FolderList, FileList As New List(Of String)

			If My.Settings.CBTease Then FolderList.Add(Lazytext & "\Apps\Glitter\Tease\")
			If My.Settings.CBEgotist Then FolderList.Add(Lazytext & "\Apps\Glitter\Egotist\")
			If My.Settings.CBTrivia Then FolderList.Add(Lazytext & "\Apps\Glitter\Trivia\")
			If My.Settings.CBDaily Then FolderList.Add(Lazytext & "\Apps\Glitter\Daily\")
			If My.Settings.CBCustom1 Then FolderList.Add(Lazytext & "\Apps\Glitter\Custom 1\")
			If My.Settings.CBCustom2 Then FolderList.Add(Lazytext & "\Apps\Glitter\Custom 2\")

			For Each Folder As String In FolderList
				For Each FoundFile As String In My.Computer.FileSystem.GetFiles(Folder, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					FileList.Add(FoundFile)
				Next
			Next

			If FileList.Count < 1 Then
				My.Settings.CBGlitterFeed = False
				MessageBox.Show(Me, "Tease AI attempted to create a Glitter update, but no files were found! Please make sure at least one category containing Glitter txt files has been selected." & Environment.NewLine _
					& Environment.NewLine & "Glitter feed has been automatically disabled.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			For i As Integer = 0 To ssh.UpdateList.Count - 1
				Debug.Print(i & ". " & ssh.UpdateList(i))
			Next

			ssh.UpdateList.Add(FileList(ssh.randomizer.Next(0, FileList.Count)))
		End If
		StatusUpdatePost()

	End Sub

	Private Sub UpdateStageTimer_Tick(sender As System.Object, e As System.EventArgs) Handles UpdateStageTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		ssh.UpdateStageTick -= 1

		If ssh.UpdateStageTick < 1 Then

			UpdateStageTimer.Stop()

ReRoll:
			ssh.TempVal = ssh.randomizer.Next(1, 4)


			If ssh.TempVal = 1 And ssh.StatusText1(0) <> ">" Then
				' ##################### Contact1 Post #########################
				If ssh.StatusChance1 < My.Settings.Glitter1Slider * 10 And My.Settings.CBGlitter1 = True Then
					GlitterSendPost(1, ssh.StatusText1)
				End If
				ssh.StatusText1 = ">" & ssh.StatusText1

			ElseIf ssh.TempVal = 2 And ssh.StatusText2(0) <> ">" Then
				' ##################### Contact2 Post #########################
				If ssh.StatusChance2 < My.Settings.Glitter2Slider * 10 And My.Settings.CBGlitter2 = True Then
					GlitterSendPost(2, ssh.StatusText2)
				End If
				ssh.StatusText2 = ">" & ssh.StatusText2

			ElseIf ssh.TempVal = 3 And ssh.StatusText3(0) <> ">" Then
				' ##################### Contact3 Post #########################
				If ssh.StatusChance3 < My.Settings.Glitter3Slider * 10 And My.Settings.CBGlitter3 = True Then
					GlitterSendPost(3, ssh.StatusText3)
				End If
				ssh.StatusText3 = ">" & ssh.StatusText3

			Else
				GoTo ReRoll
			End If


			If ssh.StatusText1(0) = ">" And ssh.StatusText2(0) = ">" And ssh.StatusText3(0) = ">" Then
				ssh.UpdatingPost = False
			Else
				ssh.UpdateStageTick = ssh.randomizer.Next(10, 21)
				UpdateStageTimer.Start()
			End If
		End If
	End Sub

	Private Sub StatusUpdates_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles StatusUpdates.DocumentCompleted
		Try
			StatusUpdates.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try
	End Sub

#End Region ' GlitterFeeds APP

#Region "------------------------------------------------------ Lazy-Sub ------------------------------------------------------"

	Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNStop.Click, Button7.Click
		chatBox.Text = "Let me stop"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNYes.Click, Button2.Click
		Try
			chatBox.Text = "Yes " & ssh.tempHonorific
		Catch
			chatBox.Text = "Yes"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNo.Click, Button3.Click
		Try
			chatBox.Text = "No " & ssh.tempHonorific
		Catch
			chatBox.Text = "No"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNEdge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdge.Click, Button4.Click
		chatBox.Text = "On the edge"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSpeedUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSpeedUp.Click, Button8.Click
		chatBox.Text = "Let me speed up"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSlowDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSlowDown.Click, Button5.Click
		chatBox.Text = "Let me slow down"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNStroke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNStroke.Click, Button6.Click
		chatBox.Text = "May I start stroking?"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNAskToCum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAskToCum.Click, Button9.Click
		chatBox.Text = "Please let me cum " & ssh.tempHonorific
		sendButton.PerformClick()
	End Sub

	Private Sub BTNGreeting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGreeting.Click, Button10.Click

		If ssh.SaidHello = True Then
			ssh.LockImage = False
			If ssh.SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh.RapidFire = False
			Return
		End If

		Try
			chatBox.Text = "Hello " & ssh.tempHonorific
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNSafeword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSafeword.Click, Button11.Click
		Try
			chatBox.Text = FrmSettings.TBSafeword.Text
		Catch
			chatBox.Text = "@Error"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub CBHideShortcuts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBHideShortcuts.CheckedChanged
		If FormLoading = False Then
			GetShortcutChecked()
			My.Settings.ShowShortcuts = CBHideShortcuts.Checked
		End If
	End Sub

	Public Sub GetShortcutChecked()

		TBShortYes.Visible = Not CBHideShortcuts.Checked
		TBShortNo.Visible = Not CBHideShortcuts.Checked
		TBShortEdge.Visible = Not CBHideShortcuts.Checked
		TBShortSpeedUp.Visible = Not CBHideShortcuts.Checked
		TBShortSlowDown.Visible = Not CBHideShortcuts.Checked
		TBShortStop.Visible = Not CBHideShortcuts.Checked
		TBShortStroke.Visible = Not CBHideShortcuts.Checked
		TBShortCum.Visible = Not CBHideShortcuts.Checked
		TBShortGreet.Visible = Not CBHideShortcuts.Checked
		TBShortSafeword.Visible = Not CBHideShortcuts.Checked


		BTNLS1.Width = If(CBHideShortcuts.Checked, 214, 163)
		BTNLS2.Width = If(CBHideShortcuts.Checked, 214, 163)
		BTNLS3.Width = If(CBHideShortcuts.Checked, 214, 163)
		BTNLS4.Width = If(CBHideShortcuts.Checked, 214, 163)
		BTNLS5.Width = If(CBHideShortcuts.Checked, 214, 163)

		BTNLS1Edit.Visible = Not CBHideShortcuts.Checked
		BTNLS2Edit.Visible = Not CBHideShortcuts.Checked
		BTNLS3Edit.Visible = Not CBHideShortcuts.Checked
		BTNLS4Edit.Visible = Not CBHideShortcuts.Checked
		BTNLS5Edit.Visible = Not CBHideShortcuts.Checked

	End Sub

	Private Sub CBShortcuts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShortcuts.CheckedChanged
		If FormLoading = False Then
			My.Settings.Shortcuts = CBShortcuts.Checked
		End If
	End Sub

	Private Sub TBShortYes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortYes.LostFocus
		My.Settings.ShortYes = TBShortYes.Text
	End Sub

	Private Sub TBShortNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortNo.LostFocus
		My.Settings.ShortNo = TBShortNo.Text
	End Sub

	Private Sub TBShortEdge_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortEdge.LostFocus
		My.Settings.ShortEdge = TBShortEdge.Text
	End Sub

	Private Sub TBShortSpeedUp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortSpeedUp.LostFocus
		My.Settings.ShortSpeedUp = TBShortSpeedUp.Text
	End Sub

	Private Sub TBShortSlowDown_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortSlowDown.LostFocus
		My.Settings.ShortSlowDown = TBShortSlowDown.Text
	End Sub

	Private Sub TBShortStop_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortStop.LostFocus
		My.Settings.ShortStop = TBShortStop.Text
	End Sub

	Private Sub TBShortStroke_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortStroke.LostFocus
		My.Settings.ShortStroke = TBShortStroke.Text
	End Sub

	Private Sub TBShortCum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortCum.LostFocus
		My.Settings.ShortCum = TBShortCum.Text
	End Sub

	Private Sub TBShortGreet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortGreet.LostFocus
		My.Settings.ShortGreet = TBShortGreet.Text
	End Sub

	Private Sub TBShortSafeword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBShortSafeword.LostFocus
		My.Settings.ShortSafeword = TBShortSafeword.Text
	End Sub

	Public Sub CheatCheck()

		If chatBox.Text = LBLWritingTaskText.Text Then
			chatBox.Text = "I'm a dirty cheater"
		End If

	End Sub

	Private Sub BTNLS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS1.Click


		If BTNLS1.Text <> "" Then
			chatBox.Text = BTNLS1.Text
			If ssh.WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BtnLsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS1Edit.Click, BTNLS2Edit.Click, BTNLS3Edit.Click, BTNLS4Edit.Click, BTNLS5Edit.Click
		Dim TextToSet As String = ""

		If sender Is BTNLS1Edit Then
			TextToSet = My.Settings.LS1
		ElseIf sender Is BTNLS2Edit Then
			TextToSet = My.Settings.LS2
		ElseIf sender Is BTNLS3Edit Then
			TextToSet = My.Settings.LS3
		ElseIf sender Is BTNLS4Edit Then
			TextToSet = My.Settings.LS4
		ElseIf sender Is BTNLS5Edit Then
			TextToSet = My.Settings.LS5
		Else
			Exit Sub
		End If

		TextToSet = InputBox("Enter a text to set.", "Set custom Lazy Sub Text", TextToSet)

		If TextToSet.Trim = "" Then
			MessageBox.Show("Setting new Lazy Sub text has been aborted.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If

		If sender Is BTNLS1Edit Then
			My.Settings.LS1 = TextToSet
		ElseIf sender Is BTNLS2Edit Then
			My.Settings.LS2 = TextToSet
		ElseIf sender Is BTNLS3Edit Then
			My.Settings.LS3 = TextToSet
		ElseIf sender Is BTNLS4Edit Then
			My.Settings.LS4 = TextToSet
		ElseIf sender Is BTNLS5Edit Then
			My.Settings.LS5 = TextToSet

		End If

	End Sub

	Private Sub BTNLS2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS2.Click


		If BTNLS2.Text <> "" Then
			chatBox.Text = BTNLS2.Text
			If ssh.WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS3.Click


		If BTNLS3.Text <> "" Then
			chatBox.Text = BTNLS3.Text
			If ssh.WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS4.Click


		If BTNLS4.Text <> "" Then
			chatBox.Text = BTNLS4.Text
			If ssh.WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLS5.Click


		If BTNLS5.Text <> "" Then
			chatBox.Text = BTNLS5.Text
			If ssh.WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub


#End Region  ' Lazy-Sub

#Region "-------------------------------------------------- Randomizer-App ----------------------------------------------------"

	Private Sub BTNRandomBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomBlog.Click
		BTNRandomBlog.Enabled = False

		ShowImage(GetRandomImage(ImageGenre.Blog), True)
		ssh.JustShowedBlogImage = True

		BTNRandomBlog.Enabled = True
	End Sub

	Private Sub BTNRandomLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomLocal.Click
		BTNRandomLocal.Enabled = False

		ShowImage(GetRandomImage(ImageSourceType.Local), True)
		ssh.JustShowedBlogImage = True

		BTNRandomLocal.Enabled = True
	End Sub

	Private Sub BTNRandomVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomVideo.Click
		ssh.RandomizerVideo = True
		ssh.VideoGenre = "ALL"
		RandomVideo()
		ssh.RandomizerVideo = False
	End Sub

	Private Sub BTNRandomJOI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomJOI.Click
		PlayRandomJOI()
	End Sub

	Private Sub BTNRandomCS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomCS.Click
		ssh.SaidHello = True
		ssh.RandomizerVideoTease = True

		ssh.ScriptVideoTease = "Censorship Sucks"
		ssh.ScriptVideoTeaseFlag = True
		ssh.VideoGenre = "ALL"
		RandomVideo()
		ssh.ScriptVideoTeaseFlag = False
		ssh.CensorshipGame = True
		ssh.VideoTease = True
		ssh.CensorshipTick = ssh.randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
		CensorshipTimer.Start()
	End Sub

	Private Sub BTNRandomAtE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomAtE.Click

		ssh.SaidHello = True
		ssh.RandomizerVideoTease = True

		ScriptTimer.Stop()
		ssh.SubStroking = True
		ssh.TempStrokeTauntVal = ssh.StrokeTauntVal
		ssh.TempFileText = ssh.FileText
		ssh.ScriptVideoTease = "Avoid The Edge"
		ssh.ScriptVideoTeaseFlag = True
		ssh.AvoidTheEdgeStroking = True
		ssh.AvoidTheEdgeGame = True
		ssh.VideoGenre = "ALL"
		RandomVideo()
		ssh.ScriptVideoTeaseFlag = False
		ssh.VideoTease = True
		ssh.StartStrokingCount += 1
		StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		ssh.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
		AvoidTheEdgeTaunts.Start()

	End Sub

	Private Sub BTNRandomRLGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomRLGL.Click

		ssh.SaidHello = True
		ssh.RandomizerVideoTease = True

		ScriptTimer.Stop()
		ssh.SubStroking = True
		ssh.ScriptVideoTease = "RLGL"
		ssh.ScriptVideoTeaseFlag = True
		'AvoidTheEdgeStroking = True
		ssh.RLGLGame = True
		ssh.VideoGenre = "ALL"
		RandomVideo()
		ssh.ScriptVideoTeaseFlag = False
		ssh.VideoTease = True
		ssh.RLGLTick = ssh.randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
		RLGLTimer.Start()
		ssh.StartStrokingCount += 1
		StrokePace = ssh.randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		'VideoTauntTick = randomizer.Next(20, 31)
		'VideoTauntTimer.Start()

	End Sub

	Private Sub BTNRandomCH_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRandomCH.Click
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
	Private Sub VideoJump2Random(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
		Try
			If DomWMP.currentPlaylist.count = 0 Then Throw New Exception("No Video playing - can't jump.")

			Dim VideoLength As Integer = DomWMP.currentMedia.duration
			Dim VidLow As Integer = VideoLength * 0.4
			Dim VidHigh As Integer = VideoLength * 0.9
			Dim VidPoint As Integer = ssh.randomizer.Next(VidLow, VidHigh)

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

	Private Sub BTNPlaylist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPlaylist.Click
		If LBPlaylist.SelectedItems.Count = 0 Then
			MessageBox.Show(Me, "Please select a Playlist first!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		If ssh.SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to begin a Playlist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		ssh.Playlist = True
		'SaidHello = True

		ssh.PlaylistFile = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\" & LBPlaylist.SelectedItem & ".txt")
		ssh.PlaylistFile = StripBlankLines(ssh.PlaylistFile)
		ssh.PlaylistCurrent = 0
		Try
			chatBox.Text = "Hello " & ssh.tempHonorific
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()

		BTNPlaylist.Enabled = False
	End Sub

	Private Sub BTNWishlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNWishlist.Click

		If ssh.SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with your domme to use this feature!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Debug.Print(WishlistCostSilver.Visible)
		Debug.Print(Val(LBLWishlistCost.Text))

		If WishlistCostSilver.Visible = True And ssh.SilverTokens >= Val(LBLWishlistCost.Text) Then

			ssh.SilverTokens -= Val(LBLWishlistCost.Text)
			My.Settings.SilverTokens = ssh.SilverTokens

			'LBLWishListText.Text = "You purchased this item for " & ssh.tempDomName & " on " & CDate(DateString) & "."
			'My.Settings.WishlistNote = LBLWishListText.Text

			My.Settings.ClearWishlist = True


			WishlistCostGold.Visible = False
			WishlistCostSilver.Visible = False
			LBLWishlistBronze.Text = ssh.BronzeTokens
			LBLWishlistSilver.Text = ssh.SilverTokens
			LBLWishlistGold.Text = ssh.GoldTokens
			LBLWishListName.Text = ""
			WishlistPreview.Visible = False
			LBLWishlistCost.Text = ""
			LBLWishListText.Text = "Thank you for your purchase! " & ssh.tempDomName & " has been notified of your generous gift. Please check back again tomorrow for a new item!"
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

			ssh.SaidHello = True
			ssh.ShowModule = True

			ssh.FileText = SilverList(ssh.randomizer.Next(0, SilverList.Count))

			If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh.StrokeTauntVal = -1
			ssh.ScriptTick = 2
			ScriptTimer.Start()
			Return

		End If


		If WishlistCostGold.Visible = True And ssh.GoldTokens >= Val(LBLWishlistCost.Text) Then

			ssh.GoldTokens -= Val(LBLWishlistCost.Text)
			My.Settings.GoldTokens = ssh.GoldTokens

			My.Settings.ClearWishlist = True


			Dim GoldList As New List(Of String)

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Wishlist\Gold Rewards\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				GoldList.Add(foundFile)
			Next

			If GoldList.Count < 1 Then
				MessageBox.Show(Me, "No Gold Reward scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			ssh.SaidHello = True
			ssh.ShowModule = True

			ssh.FileText = GoldList(ssh.randomizer.Next(0, GoldList.Count))

			If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh.StrokeTauntVal = -1
			ssh.ScriptTick = 2
			ScriptTimer.Start()

		End If


	End Sub

#End Region

#Region "------------------------------------------------- Hypno-Guide App ----------------------------------------------------"

	Private Sub BTNHypnoGenStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNHypnoGenStart.Click



		If ssh.HypnoGen = False Then

			If CBHypnoGenInduction.Checked = True Then
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt") Then
					ssh.Induction = True
					ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt"
				Else
					MessageBox.Show(Me, "Please select a valid Hypno Induction File or deselect the Induction option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
			End If



			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt") Then
				If ssh.Induction = False Then
					ssh.FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				Else
					ssh.TempHypno = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				End If
			Else
				MessageBox.Show(Me, "Please select a valid Hypno File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			ssh.StrokeTauntVal = -1
			ssh.ScriptTick = 1
			ScriptTimer.Start()
			Dim HypnoTrack As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\" & ComboBoxHypnoGenTrack.SelectedItem
			If File.Exists(HypnoTrack) Then DomWMP.URL = HypnoTrack
			ssh.HypnoGen = True
			ssh.AFK = True
			ssh.SaidHello = True

			BTNHypnoGenStart.Text = "End Session"

		Else

			mciSendString("CLOSE Speech1", String.Empty, 0, 0)
			mciSendString("CLOSE Echo1", String.Empty, 0, 0)
			DomWMP.Ctlcontrols.stop()

			ScriptTimer.Stop()
			ssh.StrokeTauntVal = -1
			ssh.HypnoGen = False
			ssh.Induction = False
			ssh.AFK = False
			ssh.SaidHello = False

			BTNHypnoGenStart.Text = "Guide Me!"

		End If





	End Sub

	Private Sub CBHypnoGenSlideshow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBHypnoGenSlideshow.CheckedChanged
		If FormLoading = False Then
			If CBHypnoGenSlideshow.Checked = True Then
				LBHypnoGenSlideshow.Enabled = True
			Else
				LBHypnoGenSlideshow.Enabled = False
			End If
		End If
	End Sub

	Private Sub CBHypnoGenInduction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBHypnoGenInduction.CheckedChanged
		If FormLoading = False Then
			If CBHypnoGenInduction.Checked = True Then
				LBHypnoGenInduction.Enabled = True
			Else
				LBHypnoGenInduction.Enabled = False
			End If
		End If
	End Sub

	Private Sub CBHypnoGenNoText_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBHypnoGenNoText.CheckedChanged

	End Sub

#End Region

#Region "--------------------------------------------------- VitalSub APP -----------------------------------------------------"

	Private Sub BTNExercise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNExercise.Click
		If TBExercise.Text <> "" Then
			CLBExercise.Items.Add(TBExercise.Text)
			TBExercise.Text = ""
			SaveExercise()
		End If
	End Sub

	Private Sub BTNCalorie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCalorie.Click
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
			ssh.CaloriesConsumed += TBCalorieAmount.Text
			LBLCalorie.Text = ssh.CaloriesConsumed
			My.Settings.CaloriesConsumed = ssh.CaloriesConsumed
			TBCalorieItem.Text = ""
			TBCalorieAmount.Text = ""
		End If
	End Sub

	Private Sub ComboBoxCalorie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCalorie.SelectedIndexChanged

	End Sub

	Private Sub ComboBoxCalorie_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCalorie.SelectionChangeCommitted
		If Not ComboBoxCalorie.SelectedItem Is Nothing Then
			Dim CalorieString As String = ComboBoxCalorie.SelectedItem
			LBCalorie.Items.Add(CalorieString)
			CalorieString = CalorieString.Replace(" Calories", "")
			Dim CalorieSplit As String() = Split(CalorieString)
			Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
			ssh.CaloriesConsumed += TempCal
			LBLCalorie.Text = ssh.CaloriesConsumed
			My.Settings.CaloriesConsumed = ssh.CaloriesConsumed
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

	Private Sub CLBExercise_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLBExercise.SelectedIndexChanged, CLBExercise.LostFocus
		SaveExercise()
	End Sub

	Private Sub CBVitalSub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBVitalSub.CheckedChanged
		If CBVitalSub.Checked = True Then
			CBVitalSub.ForeColor = Color.LightGreen
			CBVitalSub.Text = "VitalSub Active"
		Else
			CBVitalSub.ForeColor = Color.Red
			CBVitalSub.Text = "VitalSub Inactive"
		End If
	End Sub

	Private Sub CBVitalSub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBVitalSub.LostFocus
		If CBVitalSub.Checked = True Then
			My.Settings.VitalSub = True
		Else
			My.Settings.VitalSub = False
		End If
	End Sub

	Private Sub LBCalorie_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBCalorie.DoubleClick


		Dim CalorieString As String = LBCalorie.SelectedItem
		CalorieString = CalorieString.Replace(" Calories", "")
		Dim CalorieSplit As String() = Split(CalorieString)
		Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
		ssh.CaloriesConsumed -= TempCal
		LBLCalorie.Text = ssh.CaloriesConsumed
		My.Settings.CaloriesConsumed = ssh.CaloriesConsumed
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

	Private Sub BTNVitalSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVitalSub.Click
		If ssh.SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to make VitalSub reports!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		ssh.SaidHello = True


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
			ssh.CaloriesConsumed = 0
			My.Settings.CaloriesConsumed = 0

			ssh.FileText = VitalList(ssh.randomizer.Next(0, VitalList.Count))

			If Directory.Exists(My.Settings.DomImageDir) And ssh.SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh.StrokeTauntVal = -1
			ssh.ScriptTick = 3
			ScriptTimer.Start()

		Else

			MessageBox.Show(Me, "No " & VitalSubState & " were found! Please make sure you have files in the VitaSub directory for this personality type!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If
	End Sub

	Private Sub CLBExercise_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLBExercise.DragLeave

		CLBExercise.Items.Remove(CLBExercise.SelectedItem)
	End Sub

	Private Sub CBVitalSubDomTask_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBVitalSubDomTask.CheckedChanged
		If FormLoading = False Then
			My.Settings.VitalSubAssignments = CBVitalSubDomTask.Checked
		End If
	End Sub

#End Region  ' Vital Sub

	Public Sub MetronomeTick()
		'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
		'											Metronome-Thread
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
		'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	End Sub

#Region "-------------------------------------------------- Metronome-App -----------------------------------------------------"

	Private Sub BTNMetroPreview1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMetroPreview1.Click
		If ssh.SubStroking = False Then StrokePace = NBMaxPace.Value
	End Sub

	Private Sub BTNMetroPreview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMetroPreview2.Click
		If ssh.SubStroking = False Then StrokePace = NBMinPace.Value
	End Sub

	Private Sub BTNMetroStop1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMetroStop1.Click
		If ssh.SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub BTNMetroStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMetroStop2.Click
		If ssh.SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub NBMaxPace_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NBMaxPace.ValueChanged
		If FormLoading = False Then
			If NBMaxPace.Value > NBMinPace.Value - 50 Then NBMaxPace.Value = NBMinPace.Value - 50
			If ssh.SubStroking = False Then StrokePace = NBMaxPace.Value
			My.Settings.MaxPace = NBMaxPace.Value
		End If
	End Sub

	Private Sub NBMinPace_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NBMinPace.ValueChanged
		If FormLoading = False Then
			If NBMinPace.Value < NBMaxPace.Value + 50 Then NBMinPace.Value = NBMaxPace.Value + 50
			If ssh.SubStroking = False Then StrokePace = NBMinPace.Value
			My.Settings.MinPace = NBMinPace.Value
		End If
	End Sub

	Private Sub TimeoutTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeoutTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		Debug.Print("TimeoutTick = " & ssh.TimeoutTick)

		If chatBox.Text <> "" And ssh.TimeoutTick < 3 Then Return
		If ChatBox2.Text <> "" And ssh.TimeoutTick < 3 Then Return

		ssh.TimeoutTick -= 1

		If ssh.TimeoutTick < 1 Then

			TimeoutTimer.Stop()
			ssh.YesOrNo = False
			ssh.InputFlag = False
			ssh.SkipGotoLine = True
			GetGoto()

			RunFileText()

		End If

	End Sub

	Private Sub CBMetronome_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBMetronome.LostFocus
		My.Settings.MetroOn = CBMetronome.Checked
	End Sub

#End Region  ' Metronome App

#End Region  ' Apps

	Private Sub VideoTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh.VideoTick -= 1

		If ssh.VideoTick < 1 Then
			VideoTimer.Stop()
			DomWMP.Ctlcontrols.stop()
		End If


	End Sub

	Private Sub MultipleEdgesTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultipleEdgesTimer.Tick

		If ssh.DomTypeCheck = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh.MultipleEdgesTick -= 1

		If ssh.MultipleEdgesTick < 1 Then

			ssh.EdgeTauntInt = ssh.randomizer.Next(20, 31)

			MultipleEdgesTimer.Stop()

			ssh.DomChat = "#SYS_MultipleEdgesStart"
			If ssh.Contact1Edge = True Then ssh.DomChat = "@Contact1 #SYS_MultipleEdgesStart"
			If ssh.Contact2Edge = True Then ssh.DomChat = "@Contact2 #SYS_MultipleEdgesStart"
			If ssh.Contact3Edge = True Then ssh.DomChat = "@Contact3 #SYS_MultipleEdgesStart"
			TypingDelay()

			ssh.MultipleEdgesMetronome = "START"

			ssh.EdgeCountTick = 0
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
		ssh.edgeMode.Clear()
		ssh.cameMode.Clear()
		ssh.ruinMode.Clear()
		ssh.yesMode.Clear()
		ssh.noMode.Clear()
		ssh.Modes.Clear()
	End Sub


	Public Function GetMatch(ByVal Line As String, ByVal Command As String, ByVal Match As String) As Boolean

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

		If ssh.SubStroking = True Then ssh.AlreadyStrokingEdge = True
		GetEdgeTickCheck()
		ssh.SubStroking = True
		ssh.LongEdge = False
		ssh.AskedToSpeedUp = False
		ssh.AskedToSlowDown = False
		ssh.EdgeCountTick = 0
		EdgeCountTimer.Start()
		ssh.SubEdging = True
		ssh.EdgeTauntInt = ssh.randomizer.Next(15, 31)
		EdgeTauntTimer.Start()
		If ssh.OrgasmAllowed = True Or ssh.OrgasmDenied = True Or ssh.OrgasmRuined = True Then ssh.OrgasmYesNo = True
		EdgePace()
		ActivateWebToy()
		DisableContactStroke()
		ssh.SessionEdges += 1

	End Sub


	Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
		My.Settings.SideChat = True
		CloseApp(PNLChatBox2)
	End Sub

	Public Sub ClearWriteTask()
		ssh.dontCheck = True
		ssh.WritingTaskCurrentTime = 0
		ssh.WritingTaskFlag = False
		ssh.randomWriteTask = False
		chatBox.ShortcutsEnabled = True
		ChatBox2.ShortcutsEnabled = True
		CloseApp(Nothing)
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

		If Not IsNumeric(Val1) AndAlso VariableExists(Val1) Then
			Val1 = GetVariable(Val1)
		End If

		If Not IsNumeric(Val2) AndAlso VariableExists(Val2) Then
			Val2 = GetVariable(Val2)
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

	Public Function GetSubstringCount(ByVal StringClean As String, ByVal Substring As String) As Integer

		Dim SubstringCount As Integer = 0
		For i As Integer = 0 To StringClean.Length - 1
			If StringClean.Substring(i).StartsWith(Substring) Then
				SubstringCount += 1
			End If
		Next
		Return SubstringCount

	End Function

	Public Function GetLikeValue(s As String, t As String) As Integer

		s = s.ToLower
		t = t.ToLower

		Dim n As Integer = s.Length
		Dim m As Integer = t.Length
		Dim d(n + 1, m + 1) As Integer

		If n = 0 Then
			Return m
		End If
		If m = 0 Then
			Return n
		End If

		Dim i As Integer
		Dim j As Integer

		For i = 0 To n
			d(i, 0) = i
		Next
		For j = 0 To m
			d(0, j) = j
		Next
		For i = 1 To n
			For j = 1 To m
				Dim cost As Integer
				If t(j - 1) = s(i - 1) Then
					cost = 0
				Else
					cost = 1
				End If
				d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
			Next
		Next
		Return d(n, m)
	End Function

	Private Sub GotoClear()
		ssh.GotoFlag = False
		ssh.FileGoto = ""
		ssh.SkipGotoLine = False
	End Sub

	Private Sub handleCallReturn()
		If ssh.MultiTauntPictureHold Then ssh.MultiTauntPictureHold = False
		ssh.CallReturns.Pop().resumeState()
		If ssh.ReturnSubState = "Stroking" Then
			If ssh.SubStroking = False Then
				If ssh.CallReturns.Count() = 0 Then
					If My.Settings.Chastity = True Then
						'DomTask = "Now as I was saying @StartTaunts"
						ssh.DomTask = "#Return_Chastity"
					Else
						'DomTask = "Get back to stroking @StartStroking"
						ssh.DomTask = "#Return_Stroking"
					End If
					If Not ssh.ShowModule Then
						StrokeTimer.Start()
						StrokeTauntTimer.Start()
					End If
				Else
					ssh.DomTask = "@NullResponse"
					ScriptTimer.Start()
					ssh.ScriptTick = 2
				End If
				TypingDelayGeneric()
			Else
				If ssh.CallReturns.Count() = 0 Then
					If Not ssh.ShowModule Then
						StrokeTimer.Start()
						StrokeTauntTimer.Start()
					End If
				Else
					ssh.DomTask = "@NullResponse"
					ssh.ScriptTick = 2
					ScriptTimer.Start()
				End If
			End If
		ElseIf ssh.ReturnSubState = "Edging" Then
			If ssh.SubEdging = False Then
				'DomTask = "Start getting yourself to the edge again @Edge"
				ssh.DomTask = "#Return_Edging"
				'SubStroking = True
				TypingDelayGeneric()
			Else
				EdgeTauntTimer.Start()
				EdgeCountTimer.Start()
			End If
		ElseIf ssh.ReturnSubState = "Holding The Edge" Then
			If ssh.SubEdging = False Then
				'DomTask = "Start getting yourself to the edge again @EdgeHold"
				ssh.DomTask = "#Return_Holding"
				'SubStroking = True
				TypingDelayGeneric()
			Else
				HoldEdgeTimer.Start()
				HoldEdgeTauntTimer.Start()
			End If
		ElseIf ssh.ReturnSubState = "CBTBalls" Then
			'DomTask = "Now let's get back to busting those #Balls @CBTBalls"
			ssh.DomTask = "#Return_CBTBalls"
			ssh.CBTBallsFirst = False
			TypingDelayGeneric()
		ElseIf ssh.ReturnSubState = "CBTCock" Then
			'DomTask = "Now let's get back to abusing that #Cock @CBTCock"
			ssh.DomTask = "#Return_CBTCock"
			ssh.CBTCockFirst = False
			TypingDelayGeneric()
		ElseIf ssh.ReturnSubState = "Rest" Then
			ssh.DomTypeCheck = True
			ssh.ScriptTick = 2
			ScriptTimer.Start()
			If ssh.YesOrNo Then
				ssh.DomTask = "#SYS_ReturnAnswer"
			Else
				ssh.DomTask = "@NullResponse"
			End If
			TypingDelayGeneric()
		End If
	End Sub

	Private Sub clearCallReturns()
		While ssh.CallReturns.Count > 1
			ssh.CallReturns.Pop()
		End While
	End Sub


	Public Sub setStartName()
		Try
			ssh.SlideshowMain = New ContactData(ContactType.Domme)
			ssh.SlideshowMain.LoadNew(False)
			ssh.SlideshowContact1 = New ContactData(ContactType.Contact1)
			ssh.SlideshowContact1.LoadNew(False)
			ssh.SlideshowContact2 = New ContactData(ContactType.Contact2)
			ssh.SlideshowContact2.LoadNew(False)
			ssh.SlideshowContact3 = New ContactData(ContactType.Contact3)
			ssh.SlideshowContact3.LoadNew(False)
			ssh.SlideshowContactRandom = New ContactData(ContactType.Random)
			ssh.SlideshowContactRandom.LoadNew(False)
		Catch ex As Exception
		End Try
		If ssh.currentlyPresentContacts.Count = 0 Then ssh.currentlyPresentContacts.Add(ssh.SlideshowMain.TypeName)

		If File.Exists(My.Settings.DomAvatarSave) Then domAvatar.Image = Image.FromFile(My.Settings.DomAvatarSave)
		customVocabLines = New List(Of String)
		ssh.contactToUse = ssh.SlideshowMain
		If My.Settings.DomName <> "" Then
			ssh.tempDomName = My.Settings.DomName
			domName.Text = ssh.tempDomName
			ssh.tempHonorific = My.Settings.SubHonorific
			ssh.tempDomHonorific = ssh.tempHonorific
			ssh.shortName = My.Settings.GlitterSN
		End If
		If My.Settings.SubName <> "" Then subName.Text = My.Settings.SubName
		FrmSettings.LBLCurrentDomme.Text = ssh.tempDomName
	End Sub


	Private Function updateDommeName(ByVal stringToCheck As String)
		'remove eventual @ContactX present in a @FollowUp() inside the line
		If stringToCheck.Contains("@FollowUp") Then
			Dim remove As String
			stringToCheck = stringToCheck.Trim
			remove = stringToCheck.Substring(stringToCheck.IndexOf("@FollowUp"))
			stringToCheck = stringToCheck.Replace(remove, "")
		End If

		'deals with situation in which the domme is not present
		If Not ssh.Group.Contains("D") And Not stringToCheck.Contains("@Contact1") And Not stringToCheck.Contains("@Contact2") And Not stringToCheck.Contains("@Contact3") And Not stringToCheck.Contains("@RandomContact") Then
			Dim GroupList As New List(Of String)
			GroupList.Clear()
			If ssh.Group.Contains("1") Then GroupList.Add(" @Contact1 ")
			If ssh.Group.Contains("2") Then GroupList.Add(" @Contact2 ")
			If ssh.Group.Contains("3") Then GroupList.Add(" @Contact3 ")
			stringToCheck = stringToCheck & GroupList(ssh.randomizer.Next(0, GroupList.Count))
		End If

		ssh.contactToUse = ssh.SlideshowMain
		ssh.tempDomName = ssh.SlideshowMain.TypeName
		ssh.tempHonorific = ssh.tempDomHonorific
		If stringToCheck.Contains("@Contact1") Then
			ssh.tempDomName = ssh.SlideshowContact1.TypeName
			ssh.tempHonorific = ssh.SlideshowContact1.TypeHonorific
			ssh.contactToUse = ssh.SlideshowContact1
		ElseIf stringToCheck.Contains("@Contact2") Then
			ssh.tempDomName = ssh.SlideshowContact2.TypeName
			ssh.tempHonorific = ssh.SlideshowContact2.TypeHonorific
			ssh.contactToUse = ssh.SlideshowContact2
		ElseIf stringToCheck.Contains("@Contact3") Then
			ssh.tempDomName = ssh.SlideshowContact3.TypeName
			ssh.tempHonorific = ssh.SlideshowContact3.TypeHonorific
			ssh.contactToUse = ssh.SlideshowContact3
		ElseIf stringToCheck.Contains("@RandomContact") Then
			Dim casual As Integer = 0
			casual = ssh.randomizer.Next(0, ssh.currentlyPresentContacts.Count)
			Select Case ssh.currentlyPresentContacts(casual)
				Case ssh.SlideshowContact1.TypeName
					ssh.tempDomName = ssh.SlideshowContact1.TypeName
					ssh.tempHonorific = ssh.SlideshowContact1.TypeHonorific
					ssh.contactToUse = ssh.SlideshowContact1
				Case ssh.SlideshowContact2.TypeName
					ssh.tempDomName = ssh.SlideshowContact2.TypeName
					ssh.tempHonorific = ssh.SlideshowContact2.TypeHonorific
					ssh.contactToUse = ssh.SlideshowContact2
				Case ssh.SlideshowContact3.TypeName
					ssh.tempDomName = ssh.SlideshowContact3.TypeName
					ssh.tempHonorific = ssh.SlideshowContact3.TypeHonorific
					ssh.contactToUse = ssh.SlideshowContact3
				Case Else
			End Select
		End If
		'Return stringToCheck
	End Function

	Private Sub checkForPunish()
		If ssh.nameErrors >= 2 And ssh.wrongAttempt = True Then
			ssh.DomChat = ""
			If ssh.contactToUse.Equals(ssh.SlideshowContact1) Then
				ssh.DomChat = "@Contact1 "
			ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact2) Then
				ssh.DomChat = "@Contact2 "
			ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact3) Then
				ssh.DomChat = "@Contact3 "
			End If
			ssh.DomChat += "#SYS_HonorificPunish"
			ssh.wrongAttempt = False
		End If
		TypingDelay()
	End Sub


	Private Sub selectVideo(ByVal StringClean As String)

		Dim VideoClean As String

		If StringClean.Contains("@JumpVideo") Then
			ssh.JumpVideo = True
			StringClean = StringClean.Replace("@JumpVideo", "")
		End If

		If StringClean.Contains(":\") Then
			VideoClean = StringClean
		Else
			VideoClean = Application.StartupPath & "\Video\" & StringClean
			VideoClean = VideoClean.Replace("\\", "\")
		End If



		Debug.Print("VideoFlag = " & StringClean)

		If VideoClean.Contains("*") Then

			Dim VideoList As New List(Of String)

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(VideoClean), FileIO.SearchOption.SearchTopLevelOnly, Path.GetFileName(VideoClean))
				VideoList.Add(foundFile)
			Next

			If VideoList.Count > 0 Then
				DomWMP.URL = VideoList(ssh.randomizer.Next(0, VideoList.Count))
				DomWMP.Visible = True
				mainPictureBox.Visible = False

				If ssh.JumpVideo = True Then

					Do
						Application.DoEvents()
					Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

					Dim VideoLength As Integer = DomWMP.currentMedia.duration
					Dim VidLow As Integer = VideoLength * 0.4
					Dim VidHigh As Integer = VideoLength * 0.9
					Dim VidPoint As Integer = ssh.randomizer.Next(VidLow, VidHigh)

					DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

				End If

				ssh.JumpVideo = False
			Else
				MessageBox.Show(Me, "No videos matching " & Path.GetFileName(VideoClean) & " were found in " & Path.GetDirectoryName(VideoClean) & "!" & Environment.NewLine & Environment.NewLine &
				 "Please make sure that valid files exist and that the wildcards are applied correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

		Else

			If File.Exists(VideoClean) Then
				DomWMP.URL = VideoClean
				DomWMP.Visible = True
				mainPictureBox.Visible = False

				If ssh.JumpVideo = True Then

					Do
						Application.DoEvents()
					Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

					Dim VideoLength As Integer = DomWMP.currentMedia.duration
					Dim VidLow As Integer = VideoLength * 0.4
					Dim VidHigh As Integer = VideoLength * 0.9
					Dim VidPoint As Integer = ssh.randomizer.Next(VidLow, VidHigh)

					DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

				End If

				ssh.JumpVideo = False

			Else
				MessageBox.Show(Me, Path.GetFileName(VideoClean) & " was not found in " & Application.StartupPath & "\Video!" & Environment.NewLine & Environment.NewLine &
				 "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

		End If
		DomWMP.stretchToFit = True
	End Sub

	'return -1 if word to check was not present, 0 if something in the honorific is wrong, 1 if all is ok
	'we don't reduce errors number when doing the checks for what the sub writes in chat (so we reduce them only when asked a direct question)
	'otherwise it will be nearly impossible to be punished since each phrase not using it would reduce the count
	Private Function checkSubAnswer(Optional caseToCheck As String = "", Optional reduceErrors As Boolean = True) As Integer
		ssh.DomChat = ""
		If Not IsNothing(ssh.contactToUse) Then
			If ssh.contactToUse.Equals(ssh.SlideshowContact1) Then
				ssh.DomChat = "@Contact1 "
			ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact2) Then
				ssh.DomChat = "@Contact2 "
			ElseIf ssh.contactToUse.Equals(ssh.SlideshowContact3) Then
				ssh.DomChat = "@Contact3 "
			End If
		End If
		Dim checkfor As New List(Of String)
		Dim checkForHonorific As Boolean = True
		Dim splitChat As String()
		splitChat = ssh.obtainSplitParts(ssh.ChatString, True)


		'checkanswers is a new class which stores all the saved settings for hi,yes,no,sorry words that the used has chosen
		'if we don't have a specific word to check for, we check for them all (this is used anytime the sub write anything)
		If caseToCheck = "" Then
			checkfor = ssh.checkAnswers.returnAll
			'the next two are used when there is a question from the domme
			'if there is the specific yes/no/hi/sorry answers, we check if the sub uses the honorific as expected
		ElseIf caseToCheck = "yes" Or caseToCheck = "no" Or caseToCheck = "hi" Or caseToCheck = "sorry" Or caseToCheck = "please" Or caseToCheck = "thanks" Then
			checkfor.Add(ssh.checkAnswers.returnWords(caseToCheck))
		Else
			'otherwise we check only to see if he wrote exactly what he was supposed to do
			checkfor.Add(caseToCheck)
			checkForHonorific = False
			'so we don't split the response but check the whole phrase (we "split" for an unused char so it is basically impossible the user will use it)
			splitChat = ssh.ChatString.Split(New Char() {"§"})
		End If

		For i = 0 To checkfor.Count - 1
			Dim SplitParts As String() = ssh.obtainSplitParts(checkfor(i), False)

			For n As Integer = 0 To SplitParts.Length - 1
				For m As Integer = 0 To splitChat.Length - 1
					Dim condition As Boolean
					If checkForHonorific Then
						'this will make so that the #Sys_MissingHonorific will respond using the word that triggered it (i.e. yes what? sure what? etc)
						condition = UCase(splitChat(m)) = UCase(SplitParts(n))
					Else
						'but if we are not checking for honorific (i.e. an answer to a specific question) we just check it the needed words are present
						'in the sub answer
						condition = UCase(ssh.ChatString).Contains(UCase(SplitParts(n)))
					End If

					If condition Then
						If UCase(ssh.ChatString).Contains(UCase(SplitParts(n))) Then
							If checkForHonorific Then
								If FrmSettings.CBHonorificInclude.Checked = True Then
									If WordExists(UCase(ssh.ChatString), UCase(ssh.tempHonorific)) = False Or (FrmSettings.CBNameInclude.Checked = True And WordExists(UCase(ssh.ChatString), UCase(ssh.tempDomName)) = False) Then
										ssh.DomChat += SplitParts(n) & " #SYS_MissingHonorific"
										If FrmSettings.LCaseCheckBox.Checked = False Then
											Dim DomU As String = UCase(ssh.DomChat.Substring(0, 1))
											ssh.DomChat = ssh.DomChat.Remove(0, 1)
											ssh.DomChat = DomU & ssh.DomChat
											ssh.nameErrors += 1
											ssh.wrongAttempt = True
										End If
										ssh.JustShowedBlogImage = True
										TypingDelay()
										Return 0
									End If

									If FrmSettings.CBHonorificCapitalized.Checked = True Then
										If WordExists(ssh.ChatString, Capitalize(ssh.tempHonorific)) = False Then
											'If Not ChatString.Contains(FrmSettings.TBHonorific.Text) Then
											ssh.DomChat += "#SYS_CapitalizeHonorific"
											ssh.nameErrors += 1
											ssh.wrongAttempt = True
											ssh.JustShowedBlogImage = True
											TypingDelay()
											Return 0
										End If
										'we only reduce the errors if we were responding a question, not everytime we write...the sub need to remember to use the honorific :D
										If reduceErrors Then
											If ssh.wrongAttempt Then
												ssh.wrongAttempt = False
											Else
												If (ssh.nameErrors > 0) Then ssh.nameErrors -= 1
											End If
										End If
									End If
								End If
							End If
							Return 1
						End If
					End If
				Next
			Next
		Next
		Return -1
	End Function

	Private Function checkForImage(ByVal ImageToShow As String, Optional ByVal imageDir As String = "") As String
		Dim tmpImgLoc As String = ""
		Dim throwException As Boolean = False
		If imageDir = "" And Not (ImageToShow.Contains(":\") Or ImageToShow.Contains(":/")) Then
			imageDir = Application.StartupPath & "\Images\"
			throwException = True
		End If
		Try

			If isURL(ImageToShow) Then
				'########################## ImageURL was given #########################
				tmpImgLoc = ImageToShow
				GoTo ShowedBlogImage
			End If

			' Change evtl. wrong given Slashes
			ImageToShow = ImageToShow.Replace("/", "\")

			ImageToShow = imageDir & ImageToShow
			ImageToShow = ImageToShow.Replace("\\", "\")

			If ImageToShow.Contains("*") Then
				'######################### Directory was given #########################
				Dim tmpFilter As String = Path.GetFileName(ImageToShow)
				Dim tmpDir As String = Path.GetDirectoryName(ImageToShow)
				Dim ImageList As List(Of String)

				If Directory.Exists(tmpDir) = False Then
					If throwException Then Throw New Exception(
					"The given directory """ & tmpDir & """ does not exist." &
					vbCrLf & vbCrLf &
					"Please make sure the directory exists and it is spelled correctly in the script.")
				End If

				If tmpFilter = "*" Or tmpFilter = "*.*" Then
					ImageList = myDirectory.GetFilesImages(tmpDir)
				Else
					ImageList = Directory.GetFiles(tmpDir, tmpFilter, SearchOption.TopDirectoryOnly).ToList
				End If

				If ImageList.Count = 0 Then
					If throwException Then Throw New FileNotFoundException(
					"No images matching the filter """ & tmpFilter &
					""" were found in """ & tmpDir & """!" &
					vbCrLf & vbCrLf &
					"Please make sure that valid files exist and the wildcards are applied correctly in the script.")
					tmpImgLoc = ""
				Else
					tmpImgLoc = ImageList(New Random().Next(0, ImageList.Count))
				End If
			Else
				'############################# Single Image ############################
				If File.Exists(ImageToShow) Then
					tmpImgLoc = ImageToShow
				Else
					If throwException Then Throw New Exception(
					"""" & Path.GetFileName(ImageToShow) & """ was not found in """ & Path.GetDirectoryName(ImageToShow) & """!" &
					vbCrLf & vbCrLf &
					"Please make sure the file exists and it is spelled correctly in the script.")
				End If
			End If
			'############### Display the Image ##################
ShowedBlogImage:
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                   All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			If throwException Then Log.WriteError("Command @ShowImage[] was unable to display the image.",
			ex, "Error at @ShowImage[]")
		End Try
		Return tmpImgLoc
	End Function

	Private Sub updateMode(ByVal StringClean As String, ByVal modeToUpdate As Dictionary(Of String, Mode))

		Dim CustomFlag As String = GetParentheses(StringClean, "@CustomMode(")
		CustomFlag = FixCommas(CustomFlag)
		Dim CustomArray As String() = CustomFlag.Split(",")

		If customVocabLines.Count = 0 Then
			customVocabLines.Add(CustomArray(0))
		End If

		If CustomArray.Count = 3 Then
			For i As Integer = 0 To customVocabLines.Count - 1
				If modeToUpdate.Keys.Contains(customVocabLines(i)) Then modeToUpdate.Remove(customVocabLines(i))

				Dim NewMode As New Mode
				NewMode.Keyword = customVocabLines(i)
				NewMode.Type = CustomArray(1)
				NewMode.GotoLine = CustomArray(2)
				modeToUpdate.Add(customVocabLines(i), NewMode)
			Next
		End If

		If CustomArray.Count = 2 Then
			If CustomArray(1).ToUpper.Contains("NORMAL") Then
				If modeToUpdate.Keys.Contains(customVocabLines(0)) Then
					modeToUpdate.Remove(customVocabLines(0))
				End If
			End If
		End If
		customVocabLines.Clear()
	End Sub

	Private Sub setWriteTask()
		LBLWritingTaskText.Text = PoundClean(ssh.currentWriteTask)
		LBLWritingTaskText.Text = StripCommands(LBLWritingTaskText.Text)
		LBLWritingTaskText.Text = StripFormat(LBLWritingTaskText.Text)
		LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace("  ", " ")
		LBLWritingTaskText.Text = LBLWritingTaskText.Text.Trim
	End Sub
End Class

