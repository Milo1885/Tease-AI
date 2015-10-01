
Imports System
Imports System.IO

Public Class frmApps



    Private Sub CLBExercise_DragLeave(sender As Object, e As System.EventArgs) Handles CLBExercise.DoubleClick
        CLBExercise.Items.Remove(CLBExercise.SelectedItem)
    End Sub

    Private Sub CBVitalSubDomTask_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVitalSubDomTask.CheckedChanged
        If Form1.FormLoading = False Then
            My.Settings.VitalSubAssignments = CBVitalSubDomTask.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub BTNVitalSub_Click(sender As System.Object, e As System.EventArgs) Handles BTNVitalSub.Click

        If Form1.SaidHello = True Then
            MessageBox.Show(Me, "Please wait until you are not engaged with the domme to make VitalSub reports!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Form1.SaidHello = True
        Form1.TeaseOver = False


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

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\VitalSub\" & VitalSubState & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
            VitalList.Add(foundFile)
        Next

        If VitalList.Count > 0 Then

            For i As Integer = 0 To CLBExercise.Items.Count - 1
                CLBExercise.SetItemChecked(i, False)
            Next
            Form1.SaveExercise()

            LBCalorie.Items.Clear()
            If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
            LBLCalorie.Text = 0
            Form1.CaloriesConsumed = 0
            My.Settings.CaloriesConsumed = 0
            My.Settings.Save()

            Form1.FileText = VitalList(Form1.randomizer.Next(0, VitalList.Count))

            If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And Form1.SlideshowLoaded = False Then
                Form1.LoadDommeImageFolder()
            End If

            Form1.StrokeTauntVal = -1
            Form1.ScriptTick = 3
            Form1.ScriptTimer.Start()

        Else

            MessageBox.Show(Me, "No " & VitalSubState & " were found! Please make sure you have files in the VitaSub directory for this personality type!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


    End Sub


    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click





    End Sub

    Private Sub BTNWishlist_Click(sender As System.Object, e As System.EventArgs)

       


    End Sub


    'Private Sub Button29_Click_1(sender As System.Object, e As System.EventArgs) Handles button29.click
    ' If frmApps.AppPanelGlitter.Visible = True Then
    ' frmApps.AppPanelGlitter.Visible = False
    'AppSelectLeft.Visible = False
    ' Me.ActiveControl = Me.chatBox
    ' Return
    ' End If

    ' If frmApps.AppPanelVitalSub.Visible = True Then
    ' frmApps.AppPanelVitalSub.Visible = False
    ' frmApps.AppPanelGlitter.Visible = True
    'AppSelectRight.Visible = True
    ' Return
    'End If
    ' End Sub





    Private Sub Button23_Click_1(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        '  If Form1.PNLGlitter.Visible = True Then
        'Form1.PNLGlitter.Visible = False
        ' LBLGlitter.Text = "Show Glitter"
        ' Else
        'Form1.PNLGlitter.Visible = True
        'LBLGlitter.Text = "Hide Glitter"
        'End If
    End Sub

    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'PNLScriptGuide.Visible = False
        AppPanelGlitter.Visible = False
        AppPanelVitalSub.Visible = False
        'PNLAppRandomizer.Visible = False
        PNLHypnoGen.Visible = False
        'PNLWishList.Visible = False
        PNLAppHome.Visible = True
        'PNLLazySub.Visible = False
        'PNLPlaylist.Visible = False

    End Sub

    Private Sub Button30_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNHomeVitalSub.Click
        PNLAppHome.Visible = False
        AppPanelVitalSub.Visible = True

        If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieList.txt") And ComboBoxCalorie.Items.Count = 0 Then
            Debug.Print("called itttttttt")
            Dim CalReader As New StreamReader(Application.StartupPath & "\System\VitalSub\CalorieList.txt")
            Dim CalList As New List(Of String)
            While CalReader.Peek <> -1
                CalList.Add(CalReader.ReadLine())
            End While
            CalReader.Close()
            CalReader.Dispose()
            For i As Integer = 0 To CalList.Count - 1
                ComboBoxCalorie.Items.Add(CalList(i))
            Next
        End If





    End Sub




    Private Sub Button47_Click(sender As System.Object, e As System.EventArgs) Handles BTNRun.Click

        If Form1.OpenScriptDialog.ShowDialog() = DialogResult.OK Then

            Form1.StrokeTauntVal = -1

            If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And Form1.SlideshowLoaded = False Then
                Form1.LoadDommeImageFolder()
            End If

            Form1.FileText = Form1.OpenScriptDialog.FileName
            Form1.BeforeTease = False
            Form1.ShowModule = True
            Form1.SaidHello = True
            Form1.ScriptTick = 1
            Form1.ScriptTimer.Start()


        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles BTNHypnoGenStart.Click


        If Form1.HypnoGen = False Then

            If CBHypnoGenInduction.Checked = True Then
                If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt") Then
                    Form1.Induction = True
                    Form1.FileText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt"
                Else
                    MessageBox.Show(Me, "Please select a valid Hypno Induction File or deselect the Induction option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Return
                End If
            End If



            If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt") Then
                If Form1.Induction = False Then
                    Form1.FileText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
                Else
                    Form1.TempHypno = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
                End If
            Else
                MessageBox.Show(Me, "Please select a valid Hypno File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            End If

            Form1.StrokeTauntVal = -1
            Form1.ScriptTick = 1
            Form1.ScriptTimer.Start()
            Dim HypnoTrack As String = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\" & ComboBoxHypnoGenTrack.SelectedItem
            If File.Exists(HypnoTrack) Then Form1.DomWMP.URL = HypnoTrack
            Form1.HypnoGen = True
            Form1.AFK = True
            Form1.SaidHello = True

            BTNHypnoGenStart.Text = "End Session"

        Else

            Form1.mciSendString("CLOSE Speech1", String.Empty, 0, 0)
            Form1.mciSendString("CLOSE Echo1", String.Empty, 0, 0)
            Form1.DomWMP.Ctlcontrols.stop()

            Form1.ScriptTimer.Stop()
            Form1.StrokeTauntVal = -1
            Form1.HypnoGen = False
            Form1.Induction = False
            Form1.AFK = False
            Form1.SaidHello = False

            BTNHypnoGenStart.Text = "Guide Me!"

        End If





    End Sub


    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs) Handles BTNHomeHypnoGen.Click


        LBHypnoGenInduction.Items.Clear()

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

            Dim TempUrl As String = foundFile
            TempUrl = TempUrl.Replace(".txt", "")
            Do Until Not TempUrl.Contains("\")
                TempUrl = TempUrl.Remove(0, 1)
            Loop
            LBHypnoGenInduction.Items.Add(TempUrl)

        Next

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\", FileIO.SearchOption.SearchTopLevelOnly, "*.mp3")
            Dim TempUrl As String = foundFile
            Do Until Not TempUrl.Contains("\")
                TempUrl = TempUrl.Remove(0, 1)
            Loop
            ComboBoxHypnoGenTrack.Items.Add(TempUrl)
        Next



        LBHypnoGen.Items.Clear()

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

            Dim TempUrl As String = foundFile
            TempUrl = TempUrl.Replace(".txt", "")
            Do Until Not TempUrl.Contains("\")
                TempUrl = TempUrl.Remove(0, 1)
            Loop
            LBHypnoGen.Items.Add(TempUrl)

        Next

        PNLAppHome.Visible = False
        PNLHypnoGen.Visible = True
    End Sub

    Private Sub CBHypnoGenSlideshow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHypnoGenSlideshow.CheckedChanged
        If Form1.FormLoading = False Then
            If CBHypnoGenSlideshow.Checked = True Then
                LBHypnoGenSlideshow.Enabled = True
            Else
                LBHypnoGenSlideshow.Enabled = False
            End If
        End If
    End Sub

    Private Sub CBHypnoGenInduction_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHypnoGenInduction.CheckedChanged
        If Form1.FormLoading = False Then
            If CBHypnoGenInduction.Checked = True Then
                LBHypnoGenInduction.Enabled = True
            Else
                LBHypnoGenInduction.Enabled = False
            End If
        End If
    End Sub

    Private Sub BTNExercise_Click(sender As System.Object, e As System.EventArgs) Handles BTNExercise.Click
        If TBExercise.Text <> "" Then
            CLBExercise.Items.Add(TBExercise.Text)
            TBExercise.Text = ""
            Form1.SaveExercise()
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
            Form1.CaloriesConsumed += TBCalorieAmount.Text
            LBLCalorie.Text = Form1.CaloriesConsumed
            My.Settings.CaloriesConsumed = Form1.CaloriesConsumed
            TBCalorieItem.Text = ""
            TBCalorieAmount.Text = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub ComboBoxCalorie_Click(sender As Object, e As System.EventArgs) Handles ComboBoxCalorie.SelectionChangeCommitted

        If Not ComboBoxCalorie.SelectedItem Is Nothing Then
            Dim CalorieString As String = ComboBoxCalorie.SelectedItem
            LBCalorie.Items.Add(CalorieString)
            CalorieString = CalorieString.Replace(" Calories", "")
            Dim CalorieSplit As String() = Split(CalorieString)
            Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
            Form1.CaloriesConsumed += TempCal
            LBLCalorie.Text = Form1.CaloriesConsumed
            My.Settings.CaloriesConsumed = Form1.CaloriesConsumed
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

        Form1.SaveExercise()

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
        Form1.CaloriesConsumed -= TempCal
        LBLCalorie.Text = Form1.CaloriesConsumed
        My.Settings.CaloriesConsumed = Form1.CaloriesConsumed
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

    Private Sub Button1_Click_3(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If FrmSettings.BP1.Image Is Nothing Or FrmSettings.BP2.Image Is Nothing Or FrmSettings.BP3.Image Is Nothing Or FrmSettings.BP4.Image Is Nothing Or FrmSettings.BP5.Image Is Nothing Or FrmSettings.BP6.Image Is Nothing Or _
            FrmSettings.SP1.Image Is Nothing Or FrmSettings.SP2.Image Is Nothing Or FrmSettings.SP3.Image Is Nothing Or FrmSettings.SP4.Image Is Nothing Or FrmSettings.SP5.Image Is Nothing Or FrmSettings.SP6.Image Is Nothing Or _
            FrmSettings.GP1.Image Is Nothing Or FrmSettings.GP2.Image Is Nothing Or FrmSettings.GP3.Image Is Nothing Or FrmSettings.GP4.Image Is Nothing Or FrmSettings.GP5.Image Is Nothing Or FrmSettings.GP6.Image Is Nothing Or _
            FrmSettings.CardBack.Image Is Nothing Then
            MessageBox.Show(Me, "Please set all of the pictures in the Apps\Games tab before launching this app!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If


        FrmCardList.Show()
        Form1.RefreshCards()
        FrmCardList.InitializeCards()
    End Sub



    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs)
        Form1.GetBlogImage()
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs)
        Form1.GetLocalImage()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs)
        Form1.RandomizerVideo = True
        Form1.RandomVideo()
        Form1.RandomizerVideo = False
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
        Form1.PlayRandomJOI()
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs)
        Form1.SaidHello = True
        Form1.RandomizerVideoTease = True

        Form1.ScriptVideoTease = "Censorship Sucks"
        Form1.ScriptVideoTeaseFlag = True
        Form1.RandomVideo()
        Form1.ScriptVideoTeaseFlag = False
        Form1.CensorshipGame = True
        Form1.VideoTease = True
        Form1.CensorshipTick = Form1.randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
        Form1.CensorshipTimer.Start()
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs)

        Form1.SaidHello = True
        Form1.RandomizerVideoTease = True

        Form1.ScriptTimer.Stop()
        Form1.SubStroking = True
        Form1.TempStrokeTauntVal = Form1.StrokeTauntVal
        Form1.TempFileText = Form1.FileText
        Form1.ScriptVideoTease = "Avoid The Edge"
        Form1.ScriptVideoTeaseFlag = True
        Form1.AvoidTheEdgeStroking = True
        Form1.AvoidTheEdgeGame = True
        Form1.RandomVideo()
        Form1.ScriptVideoTeaseFlag = False
        Form1.VideoTease = True
        Form1.StartStrokingCount += 1
        Form1.StopMetronome = False
        Form1.StrokePace = Form1.randomizer.Next(3, 8) * 10
        Form1.StrokePaceTimer.Interval = Form1.StrokePace
        Form1.StrokePaceTimer.Start()
        Form1.AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
        Form1.AvoidTheEdgeTaunts.Start()

    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs)

        Form1.SaidHello = True
        Form1.RandomizerVideoTease = True

        Form1.ScriptTimer.Stop()
        Form1.SubStroking = True
        Form1.ScriptVideoTease = "RLGL"
        Form1.ScriptVideoTeaseFlag = True
        'AvoidTheEdgeStroking = True
        Form1.RLGLGame = True
        Form1.RandomVideo()
        Form1.ScriptVideoTeaseFlag = False
        Form1.VideoTease = True
        Form1.RLGLTick = Form1.randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
        Form1.RLGLTimer.Start()
        Form1.StartStrokingCount += 1
        Form1.StopMetronome = False
        Form1.StrokePace = Form1.randomizer.Next(3, 8) * 10
        Form1.StrokePaceTimer.Interval = Form1.StrokePace
        Form1.StrokePaceTimer.Start()
        'VideoTauntTick = randomizer.Next(20, 31)
        'VideoTauntTimer.Start()

    End Sub

    Private Sub Button12_Click_1(sender As System.Object, e As System.EventArgs)
        Form1.PlayRandomCH()
    End Sub






    Private Sub frmApps_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.SaveExercise()
        'Form1.BTNShowHideApps.Text = "Show Apps"
    End Sub

    Private Sub frmApps_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        LBLCalorie.Text = My.Settings.CaloriesConsumed
        Debug.Print("HOW MANY FUCKING CALORIES!!!! " & My.Settings.CaloriesConsumed)

        If File.Exists(Application.StartupPath & "\System\VitalSub\ExerciseList.cld") Then
            Form1.LoadExercise()
        End If

        Form1.CaloriesConsumed = My.Settings.CaloriesConsumed

        If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
            Dim CalReader As New StreamReader(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
            While CalReader.Peek <> -1
                LBCalorie.Items.Add(CalReader.ReadLine())
            End While
            CalReader.Close()
            CalReader.Dispose()
            LBLCalorie.Text = Form1.CaloriesConsumed
        Else
            Form1.CaloriesConsumed = 0
            My.Settings.CaloriesConsumed = 0
            My.Settings.Save()
            LBLCalorie.Text = Form1.CaloriesConsumed
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

    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Try
            If Not Process.GetProcessesByName("Tease AI Metronome").Count > 0 Then Process.Start(Application.StartupPath & "\Tease AI Metronome.exe")
        Catch
            MessageBox.Show(Me, "Tease AI Metronome.exe was not found in the Tease AI folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        PNLAppHome.Visible = False
        'PNLLazySub.Visible = True
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs)
        Try
            Form1.chatBox.Text = "Yes " & FrmSettings.TBHonorific.Text
        Catch
            Form1.chatBox.Text = "Yes"
        End Try

        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)
        Try
            Form1.chatBox.Text = "No " & FrmSettings.TBHonorific.Text
        Catch
            Form1.chatBox.Text = "No"
        End Try

        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs)


        Form1.chatBox.Text = "On the edge"
        Form1.sendButton.PerformClick()

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs)
        Try
            Form1.chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
        Catch
            Form1.chatBox.Text = "Hello"
        End Try

        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs)
        Form1.chatBox.Text = "Let me speed up"
        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs)
        Form1.chatBox.Text = "Let me slow down"
        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs)
        Form1.chatBox.Text = "Let me stop"
        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs)
        Form1.chatBox.Text = "May I start stroking?"
        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs)
        Form1.chatBox.Text = "Please let me cum!"
        Form1.sendButton.PerformClick()
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs)
        Form1.CreateTaskLetter()
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs)

        Try
            Form1.chatBox.Text = FrmSettings.TBSafeword.Text
        Catch
            Form1.chatBox.Text = "@Error"
        End Try

        Form1.sendButton.PerformClick()

    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles BTNReset.Click

        If Form1.SaidHello = False Then
            MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Form1.StopEverything()
        Form1.ResetButton()

        'ForesetFlag = True
        Form1.ResumeSession()

        If Form1.DomTypeCheck = False Then
            Form1.DomTask = "<b>Tease AI has been reset</b>"
            Form1.TypingDelayGeneric()
        End If




    End Sub

    Private Sub Button29_Click_1(sender As System.Object, e As System.EventArgs) Handles Button29.Click


        Form1.BronzeTokens += 100

        ' Form1.TeaseAINotify.BalloonTipText = "Daily login bonus: You've received 100 tokens!"
        'Form1.TeaseAINotify.Text = "Tease AI"
        'Form1.TeaseAINotify.ShowBalloonTip(5000)

        'Form1.GetBlogImageTest()




        '###ParseList

        'Dim ParseList As New List(Of String)
        'Dim NewLine As String
        'Dim NewLine2 As String
        'Dim SettingsString As String = ""
        'ParseList = Form1.Txt2List("G:\Temp\vars.txt")

        'For i As Integer = 0 To ParseList.Count - 1
        'Dim ParseSplit As String() = ParseList(i).Split(":")
        'Dim dafuq As String = ParseSplit(1)
        'Dim ParseSplit2 As String() = ParseSplit(1).Split
        'For j As Integer = 0 To ParseSplit2.Count - 1
        'Debug.Print(j & " " & ParseSplit2(j))
        'Next
        'Dim CurVar As String = ParseSplit2(1).Replace(" ", "")
        'NewLine = CurVar & " = SettingsList("
        'NewLine2 = ").Replace(""" & CurVar & ": "", """")"
        'ParseList(i) = NewLine
        'SettingsString = SettingsString & NewLine & i & NewLine2
        'If i <> ParseList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
        'Next
        'My.Computer.FileSystem.WriteAllText("G:\Temp\NewVars.txt", SettingsString, False)
        '### ParseList


    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles BTNSuspend.Click

        If Form1.SaidHello = False Then
            MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If


        If File.Exists(Application.StartupPath & "\System\SavedState.txt") Then
            Dim Result As Integer = MessageBox.Show(Me, "A previous saved state already exists!" & Environment.NewLine & Environment.NewLine & _
                                                   "Do you wish to overwrite it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If Result = DialogResult.No Then
                Return
            End If
        End If

        Try
            Form1.SuspendSession()
        Catch
            MessageBox.Show(Me, "An error occurred and the state did not save correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

        MessageBox.Show(Me, "Session state has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles BTNResume.Click

        If Not File.Exists(Application.StartupPath & "\System\" & "SavedState.txt") Then
            MessageBox.Show(Me, "SavedState.txt could not be found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        If Form1.SaidHello = True Then
            Dim Result As Integer = MessageBox.Show(Me, "Resuming a previous state will cause you to lose your progress in this session!" & Environment.NewLine & Environment.NewLine & _
                                                   "Do you wish to proceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If Result = DialogResult.No Then
                Return
            End If
        End If

        Form1.ResumeSession()

    End Sub




    Private Sub Button31_Click_1(sender As System.Object, e As System.EventArgs) Handles Button31.Click

        ColorBlue()

    End Sub

    Public Sub ColorBlue()
        Try
            Form1.BackgroundImage.Dispose()
        Catch
        End Try
        Form1.BackgroundImage = Nothing
        Form1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\System\TAIBack.png")

        Form1.subName.BackColor = Color.SteelBlue
        'Form1.BTNShowHideApps.BackColor = Color.SteelBlue
        Form1.domName.BackColor = Color.SteelBlue

        Form1.browsefolderButton.BackColor = Color.SteelBlue
        Form1.PNLMediaBar.BackColor = Color.SteelBlue
        Form1.PNLHope.BackColor = Color.SteelBlue
        Form1.PNLChatBox.BackColor = Color.SteelBlue

        Form1.previousButton.BackColor = Color.SteelBlue
        Form1.nextButton.BackColor = Color.SteelBlue
        Form1.BTNLoadVideo.BackColor = Color.SteelBlue
        Form1.BTNVideoControls.BackColor = Color.SteelBlue

        Form1.MediaButton.BackColor = Color.SteelBlue
        Form1.SaveBlogImage.BackColor = Color.SteelBlue
        Form1.SettingsButton.BackColor = Color.SteelBlue

        Me.BackColor = Color.SteelBlue
        PNLAppHome.BackColor = Color.SteelBlue
        Button5.BackColor = Color.SteelBlue

        BTNRun.BackColor = Color.SteelBlue
        BTNSuspend.BackColor = Color.SteelBlue
        BTNResume.BackColor = Color.SteelBlue
        BTNReset.BackColor = Color.SteelBlue


        Form1.SplitContainer1.Panel2.BackColor = Color.SteelBlue

        'PNLLazySub.BackColor = Color.SteelBlue
        'Label27.ForeColor = Color.SteelBlue
        'Panel1.BackColor = Color.SteelBlue
        'LBLWishListName.ForeColor = Color.SteelBlue
        'Panel2.BackColor = Color.SteelBlue
        'PNLPlaylist.BackColor = Color.SteelBlue
        'PNLAppRandomizer.BackColor = Color.SteelBlue
        PictureBox3.BackColor = Color.SteelBlue


        Form1.PNLDomTagBTN.BackColor = Color.SteelBlue






        My.Settings.UIColor = ""
        My.Settings.Save()
    End Sub

    Private Sub Button32_Click_1(sender As System.Object, e As System.EventArgs) Handles Button32.Click

        ColorPurple()

    End Sub

    Public Sub ColorPurple()

        Try
            Form1.BackgroundImage.Dispose()
        Catch
        End Try
        Form1.BackgroundImage = Nothing
        Form1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\System\TAIBackPurple.png")

        Form1.subName.BackColor = Color.DarkMagenta
        ' Form1.BTNShowHideApps.BackColor = Color.DarkMagenta
        Form1.domName.BackColor = Color.DarkMagenta

        Form1.browsefolderButton.BackColor = Color.DarkMagenta
        Form1.PNLMediaBar.BackColor = Color.DarkMagenta
        Form1.PNLHope.BackColor = Color.DarkMagenta
        Form1.PNLChatBox.BackColor = Color.DarkMagenta

        Form1.previousButton.BackColor = Color.DarkMagenta
        Form1.nextButton.BackColor = Color.DarkMagenta
        Form1.BTNLoadVideo.BackColor = Color.DarkMagenta
        Form1.BTNVideoControls.BackColor = Color.DarkMagenta

        Form1.MediaButton.BackColor = Color.DarkMagenta
        Form1.SaveBlogImage.BackColor = Color.DarkMagenta
        Form1.SettingsButton.BackColor = Color.DarkMagenta

        Me.BackColor = Color.DarkMagenta
        PNLAppHome.BackColor = Color.DarkMagenta
        Button5.BackColor = Color.DarkMagenta

        Form1.SplitContainer1.Panel2.BackColor = Color.DarkMagenta

        BTNRun.BackColor = Color.DarkMagenta
        BTNSuspend.BackColor = Color.DarkMagenta
        BTNResume.BackColor = Color.DarkMagenta
        BTNReset.BackColor = Color.DarkMagenta




        'PNLLazySub.BackColor = Color.DarkMagenta
        'Label27.ForeColor = Color.DarkMagenta
        'Panel1.BackColor = Color.DarkMagenta
        'LBLWishListName.ForeColor = Color.DarkMagenta
        'Panel2.BackColor = Color.DarkMagenta
        'PNLPlaylist.BackColor = Color.DarkMagenta
        ' PNLAppRandomizer.BackColor = Color.DarkMagenta
        PictureBox3.BackColor = Color.DarkMagenta


        Form1.PNLDomTagBTN.BackColor = Color.DarkMagenta


        My.Settings.UIColor = "Purple"
        My.Settings.Save()

    End Sub

    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click

        ColorBlack()

    End Sub

    Public Sub ColorBlack()

        Try
            Form1.BackgroundImage.Dispose()
        Catch
        End Try
        Form1.BackgroundImage = Nothing
        Form1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\System\TAIBackGray.png")

        Form1.subName.BackColor = Color.Black
        'Form1.BTNShowHideApps.BackColor = Color.Black
        Form1.domName.BackColor = Color.Black

        Form1.browsefolderButton.BackColor = Color.Black
        Form1.PNLMediaBar.BackColor = Color.Black
        Form1.PNLHope.BackColor = Color.Black
        Form1.PNLChatBox.BackColor = Color.Black

        Form1.previousButton.BackColor = Color.Black
        Form1.nextButton.BackColor = Color.Black
        Form1.BTNLoadVideo.BackColor = Color.Black
        Form1.BTNVideoControls.BackColor = Color.Black

        Form1.MediaButton.BackColor = Color.Black
        Form1.SaveBlogImage.BackColor = Color.Black
        Form1.SettingsButton.BackColor = Color.Black

        Me.BackColor = Color.Black
        PNLAppHome.BackColor = Color.Black
        Button5.BackColor = Color.Black

        Form1.SplitContainer1.Panel2.BackColor = Color.Black

        BTNRun.BackColor = Color.Black
        BTNSuspend.BackColor = Color.Black
        BTNResume.BackColor = Color.Black
        BTNReset.BackColor = Color.Black



        'PNLLazySub.BackColor = Color.Black
        'Label27.ForeColor = Color.Black
        'Panel1.BackColor = Color.Black
        'LBLWishListName.ForeColor = Color.Black
        'Panel2.BackColor = Color.Black
        'PNLPlaylist.BackColor = Color.Black
        'PNLAppRandomizer.BackColor = Color.Black
        PictureBox3.BackColor = Color.Black


        Form1.PNLDomTagBTN.BackColor = Color.Black

        My.Settings.UIColor = "Black"
        My.Settings.Save()

    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click

        ColorRed()

    End Sub


    Public Sub ColorRed()

        Try
            Form1.BackgroundImage.Dispose()
        Catch
        End Try
        Form1.BackgroundImage = Nothing
        Form1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\System\TAIBackRed.png")

        Form1.subName.BackColor = Color.Firebrick
        'Form1.BTNShowHideApps.BackColor = Color.Firebrick
        Form1.domName.BackColor = Color.Firebrick

        Form1.browsefolderButton.BackColor = Color.Firebrick
        Form1.PNLMediaBar.BackColor = Color.Firebrick
        Form1.PNLHope.BackColor = Color.Firebrick
        Form1.PNLChatBox.BackColor = Color.Firebrick

        Form1.previousButton.BackColor = Color.Firebrick
        Form1.nextButton.BackColor = Color.Firebrick
        Form1.BTNLoadVideo.BackColor = Color.Firebrick
        Form1.BTNVideoControls.BackColor = Color.Firebrick

        Form1.MediaButton.BackColor = Color.Firebrick
        Form1.SaveBlogImage.BackColor = Color.Firebrick
        Form1.SettingsButton.BackColor = Color.Firebrick

        Me.BackColor = Color.Firebrick
        PNLAppHome.BackColor = Color.Firebrick
        Button5.BackColor = Color.Firebrick

        Form1.SplitContainer1.Panel2.BackColor = Color.Firebrick

        BTNRun.BackColor = Color.Firebrick
        BTNSuspend.BackColor = Color.Firebrick
        BTNResume.BackColor = Color.Firebrick
        BTNReset.BackColor = Color.Firebrick



        'PNLLazySub.BackColor = Color.Firebrick
        ' Label27.ForeColor = Color.Firebrick
        'Panel1.BackColor = Color.Firebrick
        'LBLWishListName.ForeColor = Color.Firebrick
        'Panel2.BackColor = Color.Firebrick
        ' PNLPlaylist.BackColor = Color.Firebrick
        'PNLAppRandomizer.BackColor = Color.Firebrick
        PictureBox3.BackColor = Color.Firebrick


        Form1.PNLDomTagBTN.BackColor = Color.Firebrick


        My.Settings.UIColor = "Red"
        My.Settings.Save()

    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        Form8.Show()
        LBLGlitter.Text = LBLGlitter.Text
    End Sub

    Private Sub Button18_Click_1(sender As System.Object, e As System.EventArgs) Handles Button18.Click

        Dim AIBoxList As New List(Of String)
        Dim AIBoxCurrent As New List(Of String)
        Dim AIBoxContents As New List(Of String)


        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
            AIBoxList.Add(foundFile)
        Next

        For i As Integer = 0 To AIBoxList.Count - 1
            AIBoxContents.Add("[aiBox File Begin] " & AIBoxList(i).Replace(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\", ""))
            AIBoxCurrent = Form1.Txt2List(AIBoxList(i))
            For j As Integer = 0 To AIBoxCurrent.Count - 1
                AIBoxContents.Add(AIBoxCurrent(j))
            Next
            AIBoxContents.Add("[aiBox File End] " & AIBoxList(i).Replace(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\", ""))
        Next


        If AIBoxContents.Count > 0 Then

            If File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\" & Form1.dompersonalitycombobox.Text & ".aiBox") Then _
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\" & Form1.dompersonalitycombobox.Text & ".aiBox")

            For i As Integer = 0 To AIBoxContents.Count - 1
                If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\" & Form1.dompersonalitycombobox.Text & ".aiBox") Then
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\" & Form1.dompersonalitycombobox.Text & ".aiBox", AIBoxContents(i), False)
                Else
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\System\" & Form1.dompersonalitycombobox.Text & ".aiBox", Environment.NewLine & AIBoxContents(i), True)
                End If
            Next
        End If

        MsgBox("done")

    End Sub

    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles Button37.Click
        Form9.Show()
    End Sub

End Class