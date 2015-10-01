Imports System.IO


Public Class Form9

    Dim AIBoxList As New List(Of String)
    Dim AIBoxCurrent As New List(Of String)
    Dim AIBoxContents As New List(Of String)


    Dim GetaiBoxList As New List(Of String)
    Dim aiCheckList As New List(Of String)
    Dim aiFile As String
    Dim aiFileType As String
    Dim aiScriptType As String

    Dim NextCycle As Integer


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles BTNOpenAIBox.Click

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            GetaiBoxList.Clear()


            GetaiBoxList = Form1.Txt2List(OpenFileDialog1.FileName)

            NextCycle = 0

            ShowNextAIBoxItem()

        End If


    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles BTNOpenAIBoxText.Click

        RTBAIBox.Clear()
        RTBAIBox.Text = My.Computer.Clipboard.GetText()

        Try
            If Not RTBAIBox.Lines(0).Contains("[aiBox File Begin]") Then
                MessageBox.Show(Me, "This does not appear to be a valid AI Box!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            End If
        Catch
            MessageBox.Show(Me, "Nothing to read in the first line of the text field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End Try

        If Not GetaiBoxList Is Nothing Then GetaiBoxList.Clear()



        For i As Integer = 0 To RTBAIBox.Lines.Count - 1
            GetaiBoxList.Add(RTBAIBox.Lines(i))
        Next


        NextCycle = 0

        ShowNextAIBoxItem()


    End Sub



    Public Sub ShowNextAIBoxItem()


        CLBAIBox.Visible = True
        RTBAIBox.Visible = False

        aiCheckList.Clear()

        Try

            For i As Integer = NextCycle To GetaiBoxList.Count - 1

                If GetaiBoxList(i).Contains("[aiBox File Begin]") Then aiFile = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\" & GetaiBoxList(i).Replace("[aiBox File Begin] ", "")

                If GetaiBoxList(i).Contains("[aiBox File Begin]") Then aiFileType = "Linear"
                If GetaiBoxList(i).Contains("[aiBox File Begin]") Then aiScriptType = "Linear"

                If GetaiBoxList(i).Contains("[aiBox File Begin] Vocabulary\#") Then aiFileType = "Vocabulary"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\Edge\Edge.txt") Then aiFileType = "Edge Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\Edge\GroupEdge.txt") Then aiFileType = "Glitter Edge Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\HoldTheEdge\HoldTheEdge.txt") Then aiFileType = "Hold The Edge Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\HoldTheEdge\GroupHoldTheEdge.txt") Then aiFileType = "Glitter Hold The Edge Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] CBT\CBTBalls.txt") Then aiFileType = "CBT Balls"
                If GetaiBoxList(i).Contains("[aiBox File Begin] CBT\CBTBalls_First.txt") Then aiFileType = "CBT Balls_First"
                If GetaiBoxList(i).Contains("[aiBox File Begin] CBT\CBTCock.txt") Then aiFileType = "CBT Cock"
                If GetaiBoxList(i).Contains("[aiBox File Begin] CBT\CBTCock_First.txt") Then aiFileType = "CBT Cock_First"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Custom\Tasks") Then aiFileType = "Custom Task"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\StrokeTaunts_1.txt") Then aiFileType = "Stroke Taunts 1"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\StrokeTaunts_2.txt") Then aiFileType = "Stroke Taunts 2"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\StrokeTaunts_3.txt") Then aiFileType = "Stroke Taunts 3"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\ChastityTaunts_1.txt") Then aiFileType = "Chastity Taunts 1"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\ChastityTaunts_2.txt") Then aiFileType = "Chastity Taunts 2"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\ChastityTaunts_3.txt") Then aiFileType = "Chastity Taunts 3"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\GlitterTaunts_1.txt") Then aiFileType = "Glitter Taunts 1"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\GlitterTaunts_2.txt") Then aiFileType = "Glitter Taunts 2"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\GlitterTaunts_3.txt") Then aiFileType = "Glitter Taunts 3"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Tasks") Then aiFileType = "Tasks"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Avoid The Edge\Taunts.txt") Then aiFileType = "Avoid The Edge Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Censorship Sucks\CensorBarOff.txt") Then aiFileType = "Censorship Sucks Censor Bar Off Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Censorship Sucks\CensorBarOn.txt") Then aiFileType = "Censorship Sucks Censor Bar On Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Red Light Green Light\Taunts.txt") Then aiFileType = "Red Light Green Light Game Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Red Light Green Light\Green Light.txt") Then aiFileType = "Green Light Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Red Light Green Light\Red Light.txt") Then aiFileType = "Red Light Taunts"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Vocabulary\Responses\System") And GetaiBoxList(i).Contains("KEY") Then aiFileType = "System Response Key File"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Apps\Glitter") Then aiFileType = "Glitter"

                If GetaiBoxList(i).Contains("[aiBox File Begin]") And aiFileType <> "Linear" Then aiScriptType = "List"



                Debug.Print(GetaiBoxList(i))
                If GetaiBoxList(i).Contains("[aiBox File Begin] Vocabulary\Responses") And Not GetaiBoxList(i).Contains("Vocabulary\Responses\System\") Then
                    aiFileType = "Response"
                    aiScriptType = "Response"
                End If

                If GetaiBoxList(i).Contains("[aiBox File Begin] Vocabulary\Responses\System\") And Not GetaiBoxList(i).Contains("KEY") Then
                    aiFileType = "System Response"
                    aiScriptType = "Response"
                End If

                If GetaiBoxList(i).Contains("[aiBox File Begin]") And aiScriptType <> "Linear" And aiScriptType <> "List" Then aiScriptType = "Response"

                If GetaiBoxList(i).Contains("[aiBox File Begin] Interrupt\") Then aiFileType = "Interrupt"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Modules\") Then aiFileType = "Module"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\End\") Then aiFileType = "End"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\Link\") Then aiFileType = "Link"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Stroke\Start\") Then aiFileType = "Start"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Playlist\") Then aiFileType = "Playlist File"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Playlist\Modules\") Then aiFileType = "Playlist Module"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Playlist\End\") Then aiFileType = "Playlist End"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Playlist\Link\") Then aiFileType = "Playlist Link"
                If GetaiBoxList(i).Contains("[aiBox File Begin] Playlist\Start\") Then aiFileType = "Playlist Start"

                If GetaiBoxList(i).Contains("[aiBox File Begin] Video\Avoid The Edge\Scripts") Then aiFileType = "Avoid The Edge Script"




FoundScriptType:




                LBLFileName.Text = Path.GetFileName(aiFile)
                LBLFileType.Text = aiFileType

                If Not GetaiBoxList(i).Contains("[aiBox File Begin]") And Not GetaiBoxList(i).Contains("[aiBox File End]") Then
                    aiCheckList.Add(GetaiBoxList(i))
                End If


                If GetaiBoxList(i).Contains("[aiBox File End]") Then

                    NextCycle = i + 1


                    CLBAIBox.Items.Clear()
                    RTBAIBox.Text = ""


                    If File.Exists(aiFile) Then

                        Debug.Print("aiscriptetype = " & aiScriptType)

                        If aiScriptType = "Linear" Then

                            For j As Integer = 0 To aiCheckList.Count - 1
                                CLBAIBox.Items.Add(aiCheckList(j))
                                CLBAIBox.SetItemChecked(j, True)
                            Next

                        Else


                            For j As Integer = 0 To aiCheckList.Count - 1
                                CLBAIBox.Items.Add(aiCheckList(j))
                            Next

                            Dim CompareList As New List(Of String)
                            CompareList = Form1.Txt2List(aiFile)

                            For x As Integer = 0 To CLBAIBox.Items.Count - 1
                                If CompareList.Contains(CLBAIBox.Items(x)) Then
                                    CLBAIBox.SetItemChecked(x, False)
                                Else
                                    CLBAIBox.SetItemChecked(x, True)
                                End If

                            Next

                        End If



                    Else




                        'If aiScriptType = "List" Then

                        For j As Integer = 0 To aiCheckList.Count - 1
                            CLBAIBox.Items.Add(aiCheckList(j))
                            CLBAIBox.SetItemChecked(j, True)
                        Next
                        'End If




                    End If

                    Exit For


                End If

            Next


            BTNSaveFile.Enabled = True
            BTNSkipFile.Enabled = True

        Catch
            MessageBox.Show(Me, "Something went wrong! The current AI Box may not be formatted correctly or a path may be inaccessible!" & Environment.NewLine & Environment.NewLine & _
                            "The box-opening process has been terminated.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            BTNSaveFile.Enabled = False
            BTNSkipFile.Enabled = False
            CLBAIBox.Items.Clear()
            RTBAIBox.Text = ""
            RTBAIBox.Visible = True
            CLBAIBox.Visible = False
            NextCycle = 0
        End Try



    End Sub











    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles BTNSaveFile.Click


        If File.Exists(aiFile) Then



            If aiScriptType = "List" Then
                For i As Integer = 0 To CLBAIBox.Items.Count - 1
                    If CLBAIBox.GetItemChecked(i) = True Then My.Computer.FileSystem.WriteAllText(aiFile, Environment.NewLine & CLBAIBox.Items(i), True)
                Next
            End If

            If aiScriptType = "Response" Then

                Dim Cycle As String = "All"

                Dim GetResponse As New List(Of String)
                GetResponse = Form1.Txt2List(aiFile)

                Dim ResponseKeywords As String = GetResponse(0)

                Dim BeforeTease As New List(Of String)
                Dim FirstRound As New List(Of String)
                Dim Stroking As New List(Of String)
                Dim NotStroking As New List(Of String)
                Dim Edging As New List(Of String)
                Dim HoldingTheEdge As New List(Of String)
                Dim CBTCock As New List(Of String)
                Dim CBTBalls As New List(Of String)
                Dim Chastity As New List(Of String)
                Dim AfterTease As New List(Of String)
                Dim All As New List(Of String)

                For i As Integer = 0 To GetResponse.Count - 1
                    If GetResponse(i).Contains("[Before Tease]") Then Cycle = "Before Tease"
                    If GetResponse(i).Contains("[First Round]") Then Cycle = "First Round"
                    If GetResponse(i).Contains("[Stroking]") Then Cycle = "Stroking"
                    If GetResponse(i).Contains("[Not Stroking]") Then Cycle = "Not Stroking"
                    If GetResponse(i).Contains("[Edging]") Then Cycle = "Edging"
                    If GetResponse(i).Contains("[Holding The Edge]") Then Cycle = "Holding The Edge"
                    If GetResponse(i).Contains("[CBT Cock]") Then Cycle = "CBT Cock"
                    If GetResponse(i).Contains("[CBT Balls]") Then Cycle = "CBT Balls"
                    If GetResponse(i).Contains("[Chastity]") Then Cycle = "Chastity"
                    If GetResponse(i).Contains("[After Tease]") Then Cycle = "After Tease"
                    If GetResponse(i).Contains("[All]") Then Cycle = "All"

                    Debug.Print("GetResponse(i) = " & GetResponse(i))
                    Debug.Print("Cycle = " & Cycle)

                    If Not GetResponse(i).Substring(0, 1) = "[" Then

                        If Cycle = "Before Tease" Then BeforeTease.Add(GetResponse(i))
                        If Cycle = "First Round" Then FirstRound.Add(GetResponse(i))
                        If Cycle = "Stroking" Then Stroking.Add(GetResponse(i))
                        If Cycle = "Not Stroking" Then NotStroking.Add(GetResponse(i))
                        If Cycle = "Edging" Then Edging.Add(GetResponse(i))
                        If Cycle = "Holding The Edge" Then HoldingTheEdge.Add(GetResponse(i))
                        If Cycle = "CBT Cock" Then CBTCock.Add(GetResponse(i))
                        If Cycle = "CBT Balls" Then CBTBalls.Add(GetResponse(i))
                        If Cycle = "Chastity" Then Chastity.Add(GetResponse(i))
                        If Cycle = "After Tease" Then AfterTease.Add(GetResponse(i))
                        If Cycle = "All" Then All.Add(GetResponse(i))

                    End If

                Next

                GetResponse.Clear()

                For i As Integer = 0 To CLBAIBox.Items.Count - 1
                    If CLBAIBox.GetItemChecked(i) = True Then GetResponse.Add(CLBAIBox.Items(i))
                Next

                Cycle = "All"

                For i As Integer = 0 To CLBAIBox.Items.Count - 1
                    If CLBAIBox.Items(i).Contains("[Before Tease]") Then Cycle = "Before Tease"
                    If CLBAIBox.Items(i).Contains("[First Round]") Then Cycle = "First Round"
                    If CLBAIBox.Items(i).Contains("[Stroking]") Then Cycle = "Stroking"
                    If CLBAIBox.Items(i).Contains("[Not Stroking]") Then Cycle = "Not Stroking"
                    If CLBAIBox.Items(i).Contains("[Edging]") Then Cycle = "Edging"
                    If CLBAIBox.Items(i).Contains("[Holding The Edge]") Then Cycle = "Holding The Edge"
                    If CLBAIBox.Items(i).Contains("[CBT Cock]") Then Cycle = "CBT Cock"
                    If CLBAIBox.Items(i).Contains("[CBT Balls]") Then Cycle = "CBT Balls"
                    If CLBAIBox.Items(i).Contains("[Chastity]") Then Cycle = "Chastity"
                    If CLBAIBox.Items(i).Contains("[After Tease]") Then Cycle = "After Tease"
                    If CLBAIBox.Items(i).Contains("[All]") Then Cycle = "All"

                    Debug.Print("CLBAIBox.Items222(i) = " & CLBAIBox.Items(i))
                    Debug.Print("Cycle222 = " & Cycle)

                    If Not CLBAIBox.Items(i).Substring(0, 1) = "[" Then

                        If Cycle = "Before Tease" And CLBAIBox.GetItemChecked(i) = True Then BeforeTease.Add(CLBAIBox.Items(i))
                        If Cycle = "First Round" And CLBAIBox.GetItemChecked(i) = True Then FirstRound.Add(CLBAIBox.Items(i))
                        If Cycle = "Stroking" And CLBAIBox.GetItemChecked(i) = True Then Stroking.Add(CLBAIBox.Items(i))
                        If Cycle = "Not Stroking" And CLBAIBox.GetItemChecked(i) = True Then NotStroking.Add(CLBAIBox.Items(i))
                        If Cycle = "Edging" And CLBAIBox.GetItemChecked(i) = True Then Edging.Add(CLBAIBox.Items(i))
                        If Cycle = "Holding The Edge" And CLBAIBox.GetItemChecked(i) = True Then HoldingTheEdge.Add(CLBAIBox.Items(i))
                        If Cycle = "CBT Cock" And CLBAIBox.GetItemChecked(i) = True Then CBTCock.Add(CLBAIBox.Items(i))
                        If Cycle = "CBT Balls" And CLBAIBox.GetItemChecked(i) = True Then CBTBalls.Add(CLBAIBox.Items(i))
                        If Cycle = "Chastity" And CLBAIBox.GetItemChecked(i) = True Then Chastity.Add(CLBAIBox.Items(i))
                        If Cycle = "After Tease" And CLBAIBox.GetItemChecked(i) = True Then AfterTease.Add(CLBAIBox.Items(i))
                        If Cycle = "All" And CLBAIBox.GetItemChecked(i) = True Then All.Add(CLBAIBox.Items(i))

                    End If

                Next

                Dim ResponseString As String = ""
                Dim ResponseList As New List(Of String)


                ResponseList.Add(ResponseKeywords)

                If BeforeTease.Count > 0 Then
                    ResponseList.Add("[Before Tease]")
                    For i As Integer = 0 To BeforeTease.Count - 1
                        ResponseList.Add(BeforeTease(i))
                    Next
                    ResponseList.Add("[Before Tease End]")
                End If

                If FirstRound.Count > 0 Then
                    ResponseList.Add("[First Round]")
                    For i As Integer = 0 To FirstRound.Count - 1
                        ResponseList.Add(FirstRound(i))
                    Next
                    ResponseList.Add("[First Round End]")
                End If

                If Stroking.Count > 0 Then
                    ResponseList.Add("[Stroking]")
                    For i As Integer = 0 To Stroking.Count - 1
                        ResponseList.Add(Stroking(i))
                    Next
                    ResponseList.Add("[Stroking End]")
                End If

                If NotStroking.Count > 0 Then
                    ResponseList.Add("[Not Stroking]")
                    For i As Integer = 0 To NotStroking.Count - 1
                        ResponseList.Add(NotStroking(i))
                    Next
                    ResponseList.Add("[Not Stroking End]")
                End If

                If Edging.Count > 0 Then
                    ResponseList.Add("[Edging]")
                    For i As Integer = 0 To Edging.Count - 1
                        ResponseList.Add(Edging(i))
                    Next
                    ResponseList.Add("[Edging End]")
                End If

                If HoldingTheEdge.Count > 0 Then
                    ResponseList.Add("[Holding The Edge]")
                    For i As Integer = 0 To HoldingTheEdge.Count - 1
                        ResponseList.Add(HoldingTheEdge(i))
                    Next
                    ResponseList.Add("[Holding The Edge End]")
                End If

                If CBTCock.Count > 0 Then
                    ResponseList.Add("[CBT Cock]")
                    For i As Integer = 0 To CBTCock.Count - 1
                        ResponseList.Add(CBTCock(i))
                    Next
                    ResponseList.Add("[CBT Cock End]")
                End If

                If CBTBalls.Count > 0 Then
                    ResponseList.Add("[CBT Balls]")
                    For i As Integer = 0 To CBTBalls.Count - 1
                        ResponseList.Add(CBTBalls(i))
                    Next
                    ResponseList.Add("[CBT Balls End]")
                End If

                If Chastity.Count > 0 Then
                    ResponseList.Add("[Chastity]")
                    For i As Integer = 0 To Chastity.Count - 1
                        ResponseList.Add(Chastity(i))
                    Next
                    ResponseList.Add("[Chastity End]")
                End If

                If AfterTease.Count > 0 Then
                    ResponseList.Add("[After Tease]")
                    For i As Integer = 0 To AfterTease.Count - 1
                        ResponseList.Add(AfterTease(i))
                    Next
                    ResponseList.Add("[After Tease End]")
                End If

                If All.Count > 0 Then
                    ResponseList.Add("[All]")
                    For i As Integer = 0 To All.Count - 1
                        Debug.Print("All(i) = " & All(i))
                        ResponseList.Add(All(i))
                    Next
                    ResponseList.Add("[All End]")
                End If

                If ResponseList(0) = ResponseList(1) Then ResponseList.Remove(ResponseList(0))

                For i As Integer = 0 To ResponseList.Count - 1
                    If i = ResponseList.Count - 1 Then
                        ResponseString = ResponseString & ResponseList(i)
                    Else
                        ResponseString = ResponseString & ResponseList(i) & Environment.NewLine
                    End If
                Next

                If File.Exists(aiFile) Then My.Computer.FileSystem.DeleteFile(aiFile)

                My.Computer.FileSystem.WriteAllText(aiFile.Replace(".TXT", ".txt"), ResponseString, False)

            End If

            If aiScriptType <> "Response" And aiScriptType <> "List" Then


                Dim Result As Integer = MessageBox.Show(Me, Path.GetFileName(aiFile) & " already exists! Do you wish to overwrite?" & Environment.NewLine & Environment.NewLine & _
                                                        "If you choose ""No"", then " & Path.GetFileName(aiFile).Replace(".txt", "") & "_2.txt will be created instead.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If Result = DialogResult.Yes Then
                    My.Computer.FileSystem.DeleteFile(aiFile)

                    For i As Integer = 0 To CLBAIBox.Items.Count - 1
                        If Not File.Exists(aiFile) Then
                            My.Computer.FileSystem.WriteAllText(aiFile, CLBAIBox.Items(i), False)
                        Else
                            My.Computer.FileSystem.WriteAllText(aiFile, Environment.NewLine & CLBAIBox.Items(i), True)
                        End If
                    Next
                End If
                If Result = DialogResult.No Then

                    If File.Exists(File.Exists(aiFile.Replace(".txt", "") & "_2.txt")) Then My.Computer.FileSystem.DeleteFile(aiFile.Replace(".txt", "") & "_2.txt")

                    For i As Integer = 0 To CLBAIBox.Items.Count - 1
                        If Not File.Exists(aiFile.Replace(".txt", "") & "_2.txt") Then
                            My.Computer.FileSystem.WriteAllText(aiFile.Replace(".txt", "") & "_2.txt", CLBAIBox.Items(i), False)
                        Else
                            My.Computer.FileSystem.WriteAllText(aiFile.Replace(".txt", "") & "_2.txt", Environment.NewLine & CLBAIBox.Items(i), True)
                        End If
                    Next
                End If

            End If

        Else

            For i As Integer = 0 To CLBAIBox.Items.Count - 1
                If Not File.Exists(aiFile) Then
                    If Not Directory.Exists(Path.GetDirectoryName(aiFile)) Then My.Computer.FileSystem.CreateDirectory(Path.GetDirectoryName(aiFile))
                    My.Computer.FileSystem.WriteAllText(aiFile, CLBAIBox.Items(i), False)
                Else
                    My.Computer.FileSystem.WriteAllText(aiFile, Environment.NewLine & CLBAIBox.Items(i), True)
                End If
            Next

        End If




        CLBAIBox.Items.Clear()
        RTBAIBox.Text = ""
        aiScriptType = ""


        Try
            If GetaiBoxList(NextCycle) = "[aiBox Empty]" Then
                MessageBox.Show(Me, "The domme's consciousness has escaped this AI Box!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BTNSaveFile.Enabled = False
                BTNSkipFile.Enabled = False
                LBLFileName.Text = ""
                LBLFileType.Text = ""
                RTBAIBox.Visible = True
                CLBAIBox.Visible = False
                NextCycle = 0
                Return
            End If
        Catch
            MessageBox.Show(Me, "The domme's consciousness has escaped this AI Box!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BTNSaveFile.Enabled = False
            BTNSkipFile.Enabled = False
            LBLFileName.Text = ""
            LBLFileType.Text = ""
            RTBAIBox.Visible = True
            CLBAIBox.Visible = False
            NextCycle = 0
            Return
        End Try



        ShowNextAIBoxItem()














    End Sub

    Private Sub Form9_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LBLPersonality.Text = Form1.dompersonalitycombobox.Text

        CBOpenText.Checked = My.Settings.AIBoxOpen
        CBSubDir.Checked = My.Settings.AIBoxDir

    End Sub

    Private Sub BTNSkipFile_Click(sender As System.Object, e As System.EventArgs) Handles BTNSkipFile.Click

        CLBAIBox.Items.Clear()
        RTBAIBox.Text = ""

        Try
            If GetaiBoxList(NextCycle) = "[aiBox Empty]" Then
                MessageBox.Show(Me, "The domme's consciousness has escaped this AI Box!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BTNSaveFile.Enabled = False
                BTNSkipFile.Enabled = False
                LBLFileName.Text = ""
                LBLFileType.Text = ""
                RTBAIBox.Visible = True
                CLBAIBox.Visible = False
                NextCycle = 0
                Return
            End If
        Catch
            MessageBox.Show(Me, "The domme's consciousness has escaped this AI Box!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BTNSaveFile.Enabled = False
            BTNSkipFile.Enabled = False
            LBLFileName.Text = ""
            LBLFileType.Text = ""
            RTBAIBox.Visible = True
            CLBAIBox.Visible = False
            NextCycle = 0
            Return
        End Try




        ShowNextAIBoxItem()


    End Sub



    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles BTNAddFromFolder.Click

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            If Not FolderBrowserDialog1.SelectedPath.Contains("\" & Form1.dompersonalitycombobox.Text & "\") Then
                MessageBox.Show(Me, "You can only add items to an AI Box that exist in your currently selected Personality's directory!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            End If

            AIBoxList.Clear()


            If CBSubDir.Checked = True Then
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderBrowserDialog1.SelectedPath, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
                    AIBoxList.Add(foundFile)
                Next
            Else
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderBrowserDialog1.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
                    AIBoxList.Add(foundFile)
                Next
            End If


            AddFromFolder()

        End If

    End Sub

    Private Sub Face_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BTNAddFromFolder.DragDrop


        Dim FolderList As New List(Of String)

        For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
            If Directory.Exists(filePath) Then FolderList.Add(filePath)
        Next

        If FolderList.Count < 1 Then
            MessageBox.Show(Me, "No folders detected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        For i As Integer = 0 To FolderList.Count - 1

            AIBoxList.Clear()

            If CBSubDir.Checked = True Then
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderList(i), FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
                    AIBoxList.Add(foundFile)
                Next
            Else
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderList(i), FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
                    AIBoxList.Add(foundFile)
                Next
            End If

            If Not AIBoxList(0).Contains("\" & Form1.dompersonalitycombobox.Text & "\") Then
                MessageBox.Show(Me, "You can only add items to an AI Box that exist in your currently selected Personality's directory!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            End If


            If AIBoxList.Count > 0 Then
                AddFromFolder()
            End If

        Next

    End Sub

    Public Sub AddFromFolder()

        RTBAIBox.Visible = False
        CLBAIBox.Visible = True
        AIBoxContents.Clear()

        For i As Integer = 0 To AIBoxList.Count - 1
            AIBoxContents.Add("[aiBox File Begin] " & AIBoxList(i).Replace(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\", ""))
            AIBoxCurrent = Form1.Txt2List(AIBoxList(i))
            For j As Integer = 0 To AIBoxCurrent.Count - 1
                AIBoxContents.Add(AIBoxCurrent(j))
            Next
            AIBoxContents.Add("[aiBox File End] " & AIBoxList(i).Replace(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\", ""))
        Next

        Dim CheckNumber As Integer = CLBAIBox.Items.Count

        For i As Integer = 0 To AIBoxContents.Count - 1
            CLBAIBox.Items.Add(AIBoxContents(i))
            CLBAIBox.SetItemChecked(CheckNumber, True)
            CheckNumber += 1
        Next


    End Sub

    Private Sub BTNAddFromFile_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles BTNAddFromFile.DragDrop


        Dim DropPath As String = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString


        RTBAIBox.Visible = False
        CLBAIBox.Visible = True
        AIBoxList.Clear()
        AIBoxContents.Clear()


        Dim HopeDir As String = DropPath
        Dim HopeIndex As Integer = HopeDir.IndexOf("\Scripts\") + 9
        HopeDir = HopeDir.Substring(HopeIndex, HopeDir.Length - HopeIndex)
        HopeDir = HopeDir.Replace("\Scripts\", "")
        Do
            Application.DoEvents()
            HopeDir = HopeDir.Remove(0, 1)
        Loop Until HopeDir.Substring(0, 1) = "\"
        HopeDir = HopeDir.Remove(0, 1)
        Debug.Print("Hopedir = " & HopeDir)

        AIBoxContents.Add("[aiBox File Begin] " & HopeDir)
        AIBoxList = Form1.Txt2List(DropPath)

        For i As Integer = 0 To AIBoxList.Count - 1
            AIBoxContents.Add(AIBoxList(i))
        Next

        AIBoxContents.Add("[aiBox File End] " & HopeDir)

        Dim CheckNumber As Integer = CLBAIBox.Items.Count

        For i As Integer = 0 To AIBoxContents.Count - 1
            CLBAIBox.Items.Add(AIBoxContents(i))
            CLBAIBox.SetItemChecked(CheckNumber, True)
            CheckNumber += 1
        Next

    End Sub

    Private Sub BTNOpenAIBox_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles BTNOpenAIBox.DragDrop

        Dim DropPath As String = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString


        GetaiBoxList.Clear()


        GetaiBoxList = Form1.Txt2List(DropPath)

        NextCycle = 0

        ShowNextAIBoxItem()

    End Sub


    Private Sub Tag_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BTNAddFromFile.DragEnter, BTNAddFromFolder.DragEnter, BTNOpenAIBox.DragEnter, BTNOpenAIBoxText.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        CLBAIBox.Items.Clear()
        RTBAIBox.Visible = True
        CLBAIBox.Visible = False
        NextCycle = 0
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        SaveFileDialog1.Filter = "txt|*.txt"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True



        SaveFileDialog1.FileName = "My " & Form1.dompersonalitycombobox.Text & " AI Box.txt"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim SaveAiBox As String = ""
            For i As Integer = 0 To CLBAIBox.Items.Count - 1

                If CLBAIBox.GetItemChecked(i) = True Then SaveAiBox = SaveAiBox & CLBAIBox.Items(i) & Environment.NewLine


            Next

            SaveAiBox = SaveAiBox & "[aiBox Empty]"

            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, SaveAiBox, False)

            RTBAIBox.Visible = True
            CLBAIBox.Visible = False
            RTBAIBox.Text = ""
            CLBAIBox.Items.Clear()

            If CBOpenText.Checked = True Then Form1.ShellExecute(SaveFileDialog1.FileName)

        End If


    End Sub

    Private Sub BTNAddFromFile_Click(sender As System.Object, e As System.EventArgs) Handles BTNAddFromFile.Click


        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            RTBAIBox.Visible = False
            CLBAIBox.Visible = True
            AIBoxList.Clear()
            AIBoxContents.Clear()

            Dim HopeDir As String = OpenFileDialog1.FileName
            Dim HopeIndex As Integer = HopeDir.IndexOf("\Scripts\") + 9
            HopeDir = HopeDir.Substring(HopeIndex, HopeDir.Length - HopeIndex)
            HopeDir = HopeDir.Replace("\Scripts\", "")
            Do
                Application.DoEvents()
                HopeDir = HopeDir.Remove(0, 1)
            Loop Until HopeDir.Substring(0, 1) = "\"
            HopeDir = HopeDir.Remove(0, 1)
            Debug.Print("Hopedir = " & HopeDir)



            AIBoxContents.Add("[aiBox File Begin] " & HopeDir)
            AIBoxList = Form1.Txt2List(OpenFileDialog1.FileName)

            For i As Integer = 0 To AIBoxList.Count - 1
                AIBoxContents.Add(AIBoxList(i))
            Next

            AIBoxContents.Add("[aiBox File End] " & HopeDir)

            Dim CheckNumber As Integer = CLBAIBox.Items.Count

            For i As Integer = 0 To AIBoxContents.Count - 1
                CLBAIBox.Items.Add(AIBoxContents(i))
                CLBAIBox.SetItemChecked(CheckNumber, True)
                CheckNumber += 1
            Next

        End If




    End Sub



    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        For j As Integer = 0 To aiCheckList.Count - 1
            CLBAIBox.SetItemChecked(j, False)
        Next

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        For j As Integer = 0 To aiCheckList.Count - 1
            CLBAIBox.SetItemChecked(j, True)
        Next

    End Sub


    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        CLBAIBox.Width = Me.Width - 304
        CLBAIBox.Height = Me.Height - 101
        RTBAIBox.Width = Me.Width - 304
        RTBAIBox.Height = Me.Height - 101
        LBLFileName.Width = Me.Width - 631

        LBLFileType.Location = New Point(Me.Width - 206, 20)
        LBLFT.Location = New Point(Me.Width - 282, 21)

        If Me.Width < 1090 Then Me.Width = 1090
        If Me.Height < 690 Then Me.Height = 690


    End Sub




    Private Sub CBOpenText_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBOpenText.CheckedChanged

    End Sub

    Private Sub CBOpenText_LostFocus(sender As Object, e As System.EventArgs) Handles CBOpenText.LostFocus
        My.Settings.AIBoxOpen = CBOpenText.Checked
        My.Settings.Save()
    End Sub

    Private Sub CBSubDir_LostFocus(sender As Object, e As System.EventArgs) Handles CBSubDir.LostFocus
        My.Settings.AIBoxDir = CBSubDir.Checked
        My.Settings.Save()
    End Sub

End Class