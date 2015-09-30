Imports System.IO
Imports System
Imports System.Globalization
Imports System.Net





Public Class FrmCardList

    Dim randomizer As New Random
    Dim TempVal As Integer


    Dim MatchPhase As Integer = 0
    Dim Match1 As String
    Dim Match2 As String
    Dim MatchTemp As String
    Dim MatchChance As Integer
    Dim MatchesMade As Integer
    Dim GameOn As Boolean
    Dim MatchPot As Integer
    Dim ShuffleTick As Integer

    Dim SlotBetTemp As Integer

    Dim MatchList As New List(Of String)
    Dim CompareList As New List(Of String)

    Dim Pair1 As String
    Dim Pair2 As String
    Dim Pair3 As String
    Dim Pair4 As String
    Dim Pair5 As String
    Dim Pair6 As String
    Dim Pair7 As String
    Dim Pair8 As String
    Dim Pair9 As String

    Dim Match1A As String
    Dim Match2A As String
    Dim Match3A As String
    Dim Match4A As String
    Dim Match5A As String
    Dim Match6A As String

    Dim Match1B As String
    Dim Match2B As String
    Dim Match3B As String
    Dim Match4B As String
    Dim Match5B As String
    Dim Match6B As String

    Dim Match1C As String
    Dim Match2C As String
    Dim Match3C As String
    Dim Match4C As String
    Dim Match5C As String
    Dim Match6C As String

    Dim CardTick As Integer
    Dim CardBackImage As String

    Dim RevealCards As Boolean
    Dim RevealTick As Integer

    Dim CardSetup As Boolean

    Dim SlotTick1 As Integer
    Dim SlotTick2 As Integer
    Dim SlotTick3 As Integer

    Dim SlotList As New List(Of String)

    Dim Slot1Val As Integer
    Dim Slot2Val As Integer
    Dim Slot3Val As Integer

    Dim SlotBet As Integer
    Dim Payout As Integer

    Dim BoosterTick As Integer
    Dim BoosterListBronze As New List(Of String)
    Dim BoosterListSilver As New List(Of String)
    Dim BoosterListGold As New List(Of String)

    Public B1 As Integer
    Public B2 As Integer
    Public B3 As Integer
    Public B4 As Integer
    Public B5 As Integer
    Public B6 As Integer

    Public S1 As Integer
    Public S2 As Integer
    Public S3 As Integer
    Public S4 As Integer
    Public S5 As Integer
    Public S6 As Integer

    Public G1 As Integer
    Public G2 As Integer
    Public G3 As Integer
    Public G4 As Integer
    Public G5 As Integer
    Public G6 As Integer

    Dim CardVal As Integer

    Dim fileName1 As String


    Public RiskyState As Boolean

    Public RiskyDeck As New List(Of String)
    Public RiskyShuffled As New List(Of String)
    Public RiskyRound As Integer
    Public RiskyChoiceCount As Integer

    Public RiskyChoices As New List(Of String)

    Public RiskyPick As String
    Public RiskyPickNumber As Integer
    Public RiskyPickCount As Integer
    Public RiskyResponse As String
    Public RiskyInt As Integer
    Public RiskyTick As Integer

    Public RiskyTokenOffer As Integer
    Public RiskyEdgeOffer As Integer
    Public RiskyOfferAvg As Integer
    Public RiskyTokenAvg As Integer


    Public HighestRisk As Integer
    Public LowestRisk As Integer

    Public RiskyCase As String

    Public EdgesOwed As Integer
    Public TokensPaid As Integer

    Public CardImage1 As Image
    Public CardImage2 As Image
    Public CardImage3 As Image
    Public CardImage4 As Image
    Public CardImage5 As Image
    Public CardImage6 As Image
    Public CardImage7 As Image
    Public CardImage8 As Image
    Public CardImage9 As Image


    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
  (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, _
  ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Public Sub DealMatchCards()

        If File.Exists(My.Settings.CardBack) Then
            CardBackImage = My.Settings.CardBack
        Else
            CardBackImage = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\_CardBackPicture.png"
        End If

        ClearMatchCache()

        M1A.Image = Image.FromFile(CardBackImage)
        M2A.Image = Image.FromFile(CardBackImage)
        M3A.Image = Image.FromFile(CardBackImage)
        M4A.Image = Image.FromFile(CardBackImage)
        M5A.Image = Image.FromFile(CardBackImage)
        M6A.Image = Image.FromFile(CardBackImage)

        M1B.Image = Image.FromFile(CardBackImage)
        M2B.Image = Image.FromFile(CardBackImage)
        M3B.Image = Image.FromFile(CardBackImage)
        M4B.Image = Image.FromFile(CardBackImage)
        M5B.Image = Image.FromFile(CardBackImage)
        M6B.Image = Image.FromFile(CardBackImage)

        M1C.Image = Image.FromFile(CardBackImage)
        M2C.Image = Image.FromFile(CardBackImage)
        M3C.Image = Image.FromFile(CardBackImage)
        M4C.Image = Image.FromFile(CardBackImage)
        M5C.Image = Image.FromFile(CardBackImage)
        M6C.Image = Image.FromFile(CardBackImage)

    End Sub

    Public Sub InitializeCards()


        'M1A.Enabled = True
        'M2A.Enabled = True
        'M3A.Enabled = True
        'M4A.Enabled = True
        'M5A.Enabled = True
        'M6A.Enabled = True

        'M1B.Enabled = True
        'M2B.Enabled = True
        'M3B.Enabled = True
        'M4B.Enabled = True
        'M5B.Enabled = True
        'M6B.Enabled = True

        'M1C.Enabled = True
        'M2C.Enabled = True
        'M3C.Enabled = True
        'M4C.Enabled = True
        'M5C.Enabled = True
        'M6C.Enabled = True

        DealMatchCards()

        MatchList.Clear()


        For i As Integer = 0 To FrmSettings.URLFileList.Items.Count - 1


            If File.Exists(Application.StartupPath & "\Images\System\URL Files\" & FrmSettings.URLFileList.Items(i) & ".txt") Then

                If FrmSettings.URLFileList.GetItemCheckState(i) = CheckState.Checked Then

                    Dim URLString As String = Application.StartupPath & "\Images\System\URL Files\" & FrmSettings.URLFileList.Items(i) & ".txt"
                    Dim CardReader As New System.IO.StreamReader(URLString)

                    While CardReader.Peek <> -1
                        MatchList.Add(CardReader.ReadLine())
                    End While


                    CardReader.Close()
                    CardReader.Dispose()

                End If

            End If
        Next

        If FrmSettings.CBIncludeGifs.Checked = False Then
            For i As Integer = MatchList.Count - 1 To 0 Step -1
                If MatchList(i).Contains(".gif") Then MatchList.Remove(MatchList(i))
            Next
        End If


        Dim supportedExtensions As String

        If FrmSettings.CBIncludeGifs.Checked = True Then
            supportedExtensions = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
        Else
            supportedExtensions = "*.png,*.jpg,*.bmp,*.jpeg"
        End If

        Dim files As String()


        If FrmSettings.CBIHardcore.Checked = True And Directory.Exists(FrmSettings.LBLIHardcore.Text) Then
            If FrmSettings.CBIHardcoreSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBISoftcore.Checked = True And Directory.Exists(FrmSettings.LBLISoftcore.Text) Then
            If FrmSettings.CBISoftcoreSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBILesbian.Checked = True And Directory.Exists(FrmSettings.LBLILesbian.Text) Then
            If FrmSettings.CBILesbianSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIBlowjob.Checked = True And Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then
            If FrmSettings.CBIBlowjobSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIFemdom.Checked = True And Directory.Exists(FrmSettings.LBLIFemdom.Text) Then
            If FrmSettings.CBIFemdomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBILezdom.Checked = True And Directory.Exists(FrmSettings.LBLILezdom.Text) Then
            If FrmSettings.CBILezdomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIHentai.Checked = True And Directory.Exists(FrmSettings.LBLIHentai.Text) Then
            If FrmSettings.CBIHentaiSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIGay.Checked = True And Directory.Exists(FrmSettings.LBLIGay.Text) Then
            If FrmSettings.CBIGaySD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIGay.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIGay.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIMaledom.Checked = True And Directory.Exists(FrmSettings.LBLIMaledom.Text) Then
            If FrmSettings.CBIMaledomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBICaptions.Checked = True And Directory.Exists(FrmSettings.LBLICaptions.Text) Then
            If FrmSettings.CBICaptionsSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIGeneral.Checked = True And Directory.Exists(FrmSettings.LBLIGeneral.Text) Then
            If FrmSettings.CBIGeneralSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If





    End Sub

    Public Sub MatchGameStart()

        'M1A.Enabled = True
        'M2A.Enabled = True
        'M3A.Enabled = True
        'M4A.Enabled = True
        'M5A.Enabled = True
        'M6A.Enabled = True

        'M1B.Enabled = True
        'M2B.Enabled = True
        'M3B.Enabled = True
        'M4B.Enabled = True
        'M5B.Enabled = True
        'M6B.Enabled = True

        'M1C.Enabled = True
        'M2C.Enabled = True
        'M3C.Enabled = True
        'M4C.Enabled = True
        'M5C.Enabled = True
        'M6C.Enabled = True




        MatchList.Clear()


        For i As Integer = 0 To FrmSettings.URLFileList.Items.Count - 1


            If File.Exists(Application.StartupPath & "\Images\System\URL Files\" & FrmSettings.URLFileList.Items(i) & ".txt") Then

                If FrmSettings.URLFileList.GetItemCheckState(i) = CheckState.Checked Then

                    Dim URLString As String = Application.StartupPath & "\Images\System\URL Files\" & FrmSettings.URLFileList.Items(i) & ".txt"
                    Dim CardReader As New System.IO.StreamReader(URLString)

                    While CardReader.Peek <> -1
                        MatchList.Add(CardReader.ReadLine())
                    End While


                    CardReader.Close()
                    CardReader.Dispose()

                End If

            End If
        Next

        If FrmSettings.CBIncludeGifs.Checked = False Then
            For i As Integer = MatchList.Count - 1 To 0 Step -1
                If MatchList(i).Contains(".gif") Then MatchList.Remove(MatchList(i))
            Next
        End If


        Dim supportedExtensions As String

        If FrmSettings.CBIncludeGifs.Checked = True Then
            supportedExtensions = "*.png,*.jpg,*.gif,*.bmp,*.jpeg"
        Else
            supportedExtensions = "*.png,*.jpg,*.bmp,*.jpeg"
        End If

        Dim files As String()


        If FrmSettings.CBIHardcore.Checked = True And Directory.Exists(FrmSettings.LBLIHardcore.Text) Then
            If FrmSettings.CBIHardcoreSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIHardcore.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBISoftcore.Checked = True And Directory.Exists(FrmSettings.LBLISoftcore.Text) Then
            If FrmSettings.CBISoftcoreSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLISoftcore.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBILesbian.Checked = True And Directory.Exists(FrmSettings.LBLILesbian.Text) Then
            If FrmSettings.CBILesbianSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLILesbian.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIBlowjob.Checked = True And Directory.Exists(FrmSettings.LBLIBlowjob.Text) Then
            If FrmSettings.CBIBlowjobSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIBlowjob.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIFemdom.Checked = True And Directory.Exists(FrmSettings.LBLIFemdom.Text) Then
            If FrmSettings.CBIFemdomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIFemdom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBILezdom.Checked = True And Directory.Exists(FrmSettings.LBLILezdom.Text) Then
            If FrmSettings.CBILezdomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLILezdom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIHentai.Checked = True And Directory.Exists(FrmSettings.LBLIHentai.Text) Then
            If FrmSettings.CBIHentaiSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIHentai.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIGay.Checked = True And Directory.Exists(FrmSettings.LBLIGay.Text) Then
            If FrmSettings.CBIGaySD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIGay.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIGay.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIMaledom.Checked = True And Directory.Exists(FrmSettings.LBLIMaledom.Text) Then
            If FrmSettings.CBIMaledomSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIMaledom.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBICaptions.Checked = True And Directory.Exists(FrmSettings.LBLICaptions.Text) Then
            If FrmSettings.CBICaptionsSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLICaptions.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If

        If FrmSettings.CBIGeneral.Checked = True And Directory.Exists(FrmSettings.LBLIGeneral.Text) Then
            If FrmSettings.CBIGeneralSD.Checked = True Then
                files = Directory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*", SearchOption.AllDirectories)
            Else
                files = Directory.GetFiles(FrmSettings.LBLIGeneral.Text, "*.*")
            End If
            Array.Sort(files)
            For Each fi As String In files
                If supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then
                    MatchList.Add(fi)
                End If
            Next
        End If




        If MatchList.Count < 1 Then Return


        Debug.Print("Prepare Card1")

        ShowCard1()


    End Sub

    Public Sub ShowCard1()
        Debug.Print("ShowCard1 Called")
Card1:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair1 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try

            CardImage1 = CardImage(Pair1)
            M1A.Image = CardImage1
            If M1A.Image Is Nothing Then GoTo Card1
            M2A.Image = CardImage1
            M2A_LoadCompleted()
        Catch ex As Exception
            Debug.Print("Problems")
            GoTo Card1
        End Try
    End Sub

    Private Sub M2A_LoadCompleted()
        'Private Sub M2A_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles M2A.LoadCompleted
        Debug.Print("M2A Loaded")
        Debug.Print(CardSetup)
        If CardSetup = True Then
            M1A.Visible = True
            M2A.Visible = True
            ShowCard2()
        End If
    End Sub

    Public Sub ShowCard2()
        Debug.Print("ShowCard 2")
Card2:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair2 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M3A.Load(Pair2)
            'M4A.LoadAsync(Pair2)

            CardImage2 = CardImage(Pair2)
            M3A.Image = CardImage2
            If M3A.Image Is Nothing Then GoTo Card2
            M4A.Image = CardImage2
            M4A_LoadCompleted()

        Catch ex As Exception
            GoTo Card2
        End Try

    End Sub

    Private Sub M4A_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M3A.Visible = True
            M4A.Visible = True
            ShowCard3()
        End If
    End Sub

    Public Sub ShowCard3()
Card3:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair3 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M5A.Load(Pair3)
            'M6A.LoadAsync(Pair3)


            CardImage3 = CardImage(Pair3)
            M5A.Image = CardImage3
            If M5A.Image Is Nothing Then GoTo Card3
            M6A.Image = CardImage3
            M6A_LoadCompleted()

        Catch ex As Exception
            GoTo Card3
        End Try

    End Sub

    Private Sub M6A_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M5A.Visible = True
            M6A.Visible = True
            ShowCard4()
        End If
    End Sub


    Public Sub ShowCard4()

Card4:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair4 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M1B.Load(Pair4)
            'M2B.LoadAsync(Pair4)


            CardImage4 = CardImage(Pair4)
            M1B.Image = CardImage4
            If M1B.Image Is Nothing Then GoTo Card4
            M2B.Image = CardImage4
            M2B_LoadCompleted()
        Catch ex As Exception
            GoTo Card4
        End Try


    End Sub


    Private Sub M2B_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M1B.Visible = True
            M2B.Visible = True
            ShowCard5()
        End If
    End Sub


    Public Sub ShowCard5()
Card5:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair5 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M3B.Load(Pair5)
            'M4B.LoadAsync(Pair5)

            CardImage5 = CardImage(Pair5)
            M3B.Image = CardImage5
            If M3B.Image Is Nothing Then GoTo Card5
            M4B.Image = CardImage5
            M4B_LoadCompleted()

        Catch ex As Exception
            GoTo Card5
        End Try

    End Sub

    Private Sub M4B_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M3B.Visible = True
            M4B.Visible = True
            ShowCard6()
        End If
    End Sub


    Public Sub ShowCard6()

Card6:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair6 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M5B.Load(Pair6)
            'M6B.LoadAsync(Pair6)

            CardImage6 = CardImage(Pair6)
            M5B.Image = CardImage6
            If M5B.Image Is Nothing Then GoTo Card6
            M6B.Image = CardImage6
            M6B_LoadCompleted()

        Catch ex As Exception
            GoTo Card6
        End Try

    End Sub


    Private Sub M6B_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M5B.Visible = True
            M6B.Visible = True
            ShowCard7()
        End If
    End Sub

    Public Sub ShowCard7()

Card7:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair7 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M1C.Load(Pair7)
            'M2C.LoadAsync(Pair7)

            CardImage7 = CardImage(Pair7)
            M1C.Image = CardImage7
            If M1C.Image Is Nothing Then GoTo Card7
            M2C.Image = CardImage7
            M2C_LoadCompleted()

        Catch ex As Exception
            GoTo Card7
        End Try


    End Sub

    Private Sub M2C_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M1C.Visible = True
            M2C.Visible = True
            ShowCard8()
        End If
    End Sub

    Public Sub ShowCard8()
Card8:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair8 = MatchList(CardVal)
        MatchList.Remove(MatchList(CardVal))
        Try
            'M3C.Load(Pair8)
            'M4C.LoadAsync(Pair8)

            CardImage8 = CardImage(Pair8)
            M3C.Image = CardImage8
            If M3C.Image Is Nothing Then GoTo Card8
            M4C.Image = CardImage8
            M4C_LoadCompleted()

        Catch ex As Exception
            GoTo Card8
        End Try
    End Sub

    Private Sub M4C_LoadCompleted()
        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False
            M3C.Visible = True
            M4C.Visible = True
            ShowCard9()
        End If
    End Sub

    Public Sub ShowCard9()

Card9:
        CardVal = Form1.randomizer.Next(0, MatchList.Count)
        Pair9 = MatchList(CardVal)
        Try
            'M5C.Load(Pair9)
            'M6C.LoadAsync(Pair9)

            CardImage9 = CardImage(Pair9)
            M5C.Image = CardImage9
            If M5C.Image Is Nothing Then GoTo Card9
            M6C.Image = CardImage9
            M6C_LoadCompleted()

        Catch ex As Exception
            GoTo Card9
        End Try
    End Sub

    Private Sub M6C_LoadCompleted()


        If CardSetup = True Then
            RevealTick = 1
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False

            M5C.Visible = True
            M6C.Visible = True

            CardSetup = False

            'MatchList.Remove(MatchList(CardVal))


            'MatchList.Remove(MatchList(CardVal))

            MatchList.Clear()
            CompareList.Clear()

            MatchList.Add(Pair1)
            MatchList.Add(Pair1)
            MatchList.Add(Pair2)
            MatchList.Add(Pair2)
            MatchList.Add(Pair3)
            MatchList.Add(Pair3)
            MatchList.Add(Pair4)
            MatchList.Add(Pair4)
            MatchList.Add(Pair5)
            MatchList.Add(Pair5)
            MatchList.Add(Pair6)
            MatchList.Add(Pair6)
            MatchList.Add(Pair7)
            MatchList.Add(Pair7)
            MatchList.Add(Pair8)
            MatchList.Add(Pair8)
            MatchList.Add(Pair9)
            MatchList.Add(Pair9)

            CompareList.Add(Pair1)
            CompareList.Add(Pair1)
            CompareList.Add(Pair2)
            CompareList.Add(Pair2)
            CompareList.Add(Pair3)
            CompareList.Add(Pair3)
            CompareList.Add(Pair4)
            CompareList.Add(Pair4)
            CompareList.Add(Pair5)
            CompareList.Add(Pair5)
            CompareList.Add(Pair6)
            CompareList.Add(Pair6)
            CompareList.Add(Pair7)
            CompareList.Add(Pair7)
            CompareList.Add(Pair8)
            CompareList.Add(Pair8)
            CompareList.Add(Pair9)
            CompareList.Add(Pair9)

            'CardImage1 = CardImage(Pair1)
            'CardImage2 = CardImage(Pair2)
            'CardImage3 = CardImage(Pair3)
            'CardImage4 = CardImage(Pair4)
            'CardImage5 = CardImage(Pair5)
            'CardImage6 = CardImage(Pair6)
            'CardImage7 = CardImage(Pair7)
            'CardImage8 = CardImage(Pair8)
            'CardImage9 = CardImage(Pair9)




            For I As Integer = 0 To MatchList.Count - 1
                Debug.Print(MatchList(I))
            Next

            Match1A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match1A)
            Match2A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match2A)
            Match3A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match3A)
            Match4A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match4A)
            Match5A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match5A)
            Match6A = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match6A)

            Match1B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match1B)
            Match2B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match2B)
            Match3B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match3B)
            Match4B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match4B)
            Match5B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match5B)
            Match6B = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match6B)

            Match1C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match1C)
            Match2C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match2C)
            Match3C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match3C)
            Match4C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match4C)
            Match5C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            MatchList.Remove(Match5C)
            Match6C = MatchList(Form1.randomizer.Next(0, MatchList.Count))
            'MatchList.Remove(Match6C)

            RevealTick = 3
            RevealCards = False
            CardRevealTimer.Start()
            Do
                Application.DoEvents()

            Loop Until RevealCards = True
            RevealCards = False

            EraseCards()

            ClearMatchCache()




            M1A.Image = Image.FromFile(CardBackImage)
            M2A.Image = Image.FromFile(CardBackImage)
            M3A.Image = Image.FromFile(CardBackImage)
            M4A.Image = Image.FromFile(CardBackImage)
            M5A.Image = Image.FromFile(CardBackImage)
            M6A.Image = Image.FromFile(CardBackImage)

            M1B.Image = Image.FromFile(CardBackImage)
            M2B.Image = Image.FromFile(CardBackImage)
            M3B.Image = Image.FromFile(CardBackImage)
            M4B.Image = Image.FromFile(CardBackImage)
            M5B.Image = Image.FromFile(CardBackImage)
            M6B.Image = Image.FromFile(CardBackImage)

            M1C.Image = Image.FromFile(CardBackImage)
            M2C.Image = Image.FromFile(CardBackImage)
            M3C.Image = Image.FromFile(CardBackImage)
            M4C.Image = Image.FromFile(CardBackImage)
            M5C.Image = Image.FromFile(CardBackImage)
            M6C.Image = Image.FromFile(CardBackImage)


            LBLMatchChance.Text = MatchChance & " Chances Left"

            BTNMatchEasy.Enabled = False
            BTNMatchNormal.Enabled = False
            BTNMatchHard.Enabled = False

            DealMatchCards()

            If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\CardShuffle.wav") Then
                GameWMP.settings.setMode("loop", False)
                GameWMP.settings.volume = 20
                GameWMP.URL = Application.StartupPath & "\Audio\System\CardShuffle.wav"
            End If
            'My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\CardShuffle.wav")

            ShuffleTick = 19
            ShuffleTimer.Start()


        End If

    End Sub


    Public Sub CheckMatchTemp()

        'If MatchTemp = "M1A" Then M1A.Enabled = False
        'If MatchTemp = "M2A" Then M2A.Enabled = False
        'If MatchTemp = "M3A" Then M3A.Enabled = False
        'If MatchTemp = "M4A" Then M4A.Enabled = False
        'If MatchTemp = "M5A" Then M5A.Enabled = False
        'If MatchTemp = "M6A" Then M6A.Enabled = False

        'If MatchTemp = "M1B" Then M1B.Enabled = False
        'If MatchTemp = "M2B" Then M2B.Enabled = False
        'If MatchTemp = "M3B" Then M3B.Enabled = False
        'If MatchTemp = "M4B" Then M4B.Enabled = False
        'If MatchTemp = "M5B" Then M5B.Enabled = False
        'If MatchTemp = "M6B" Then M6B.Enabled = False

        'If MatchTemp = "M1C" Then M1C.Enabled = False
        'If MatchTemp = "M2C" Then M2C.Enabled = False
        'If MatchTemp = "M3C" Then M3C.Enabled = False
        'If MatchTemp = "M4C" Then M4C.Enabled = False
        'If MatchTemp = "M5C" Then M5C.Enabled = False
        'If MatchTemp = "M6C" Then M6C.Enabled = False

        If Match1 <> Match2 Then

            MatchChance -= 1
            LBLMatchChance.Text = MatchChance & " Chances Left"
            If MatchChance = 1 Then LBLMatchChance.Text = MatchChance & " Chance Left"

            CardTick = 2
            CardTimer.Start()

            Do
                Application.DoEvents()
            Loop Until CardTimer.Enabled = False

        Else

            MatchesMade += 1

        End If


        If M1A.Enabled = True Then
            Try
                ' M1A.Image.Dispose()
            Catch
            End Try
            M1A.Image = Nothing
            M1A.Image = Image.FromFile(CardBackImage)
        End If
        If M2A.Enabled = True Then
            Try
                'M2A.Image.Dispose()
            Catch
            End Try
            M2A.Image = Nothing
            M2A.Image = Image.FromFile(CardBackImage)
        End If
        If M3A.Enabled = True Then
            Try
                'M3A.Image.Dispose()
            Catch
            End Try
            M3A.Image = Nothing
            M3A.Image = Image.FromFile(CardBackImage)
        End If
        If M4A.Enabled = True Then
            Try
                'M4A.Image.Dispose()
            Catch
            End Try
            M4A.Image = Nothing
            M4A.Image = Image.FromFile(CardBackImage)
        End If
        If M5A.Enabled = True Then
            Try
                ' M5A.Image.Dispose()
            Catch
            End Try
            M5A.Image = Nothing
            M5A.Image = Image.FromFile(CardBackImage)
        End If
        If M6A.Enabled = True Then
            Try
                ' M6A.Image.Dispose()
            Catch
            End Try
            M6A.Image = Nothing
            M6A.Image = Image.FromFile(CardBackImage)
        End If

        If M1B.Enabled = True Then
            Try
                ' M1B.Image.Dispose()
            Catch
            End Try
            M1B.Image = Nothing
            M1B.Image = Image.FromFile(CardBackImage)
        End If
        If M2B.Enabled = True Then
            Try
                'M2B.Image.Dispose()
            Catch
            End Try
            M2B.Image = Nothing
            M2B.Image = Image.FromFile(CardBackImage)
        End If
        If M3B.Enabled = True Then
            Try
                'M3B.Image.Dispose()
            Catch
            End Try
            M3B.Image = Nothing
            M3B.Image = Image.FromFile(CardBackImage)
        End If
        If M4B.Enabled = True Then
            Try
                ' M4B.Image.Dispose()
            Catch
            End Try
            M4B.Image = Nothing
            M4B.Image = Image.FromFile(CardBackImage)
        End If
        If M5B.Enabled = True Then
            Try
                'M5B.Image.Dispose()
            Catch
            End Try
            M5B.Image = Nothing
            M5B.Image = Image.FromFile(CardBackImage)
        End If
        If M6B.Enabled = True Then
            Try
                'M6B.Image.Dispose()
            Catch
            End Try
            M6B.Image = Nothing
            M6B.Image = Image.FromFile(CardBackImage)
        End If

        If M1C.Enabled = True Then
            Try
                'M1C.Image.Dispose()
            Catch
            End Try
            M1C.Image = Nothing
            M1C.Image = Image.FromFile(CardBackImage)
        End If
        If M2C.Enabled = True Then
            Try
                ' M2C.Image.Dispose()
            Catch
            End Try
            M2C.Image = Nothing
            M2C.Image = Image.FromFile(CardBackImage)
        End If
        If M3C.Enabled = True Then
            Try
                'M3C.Image.Dispose()
            Catch
            End Try
            M3C.Image = Nothing
            M3C.Image = Image.FromFile(CardBackImage)
        End If
        If M4C.Enabled = True Then
            Try
                ' M4C.Image.Dispose()
            Catch
            End Try
            M4C.Image = Nothing
            M4C.Image = Image.FromFile(CardBackImage)
        End If
        If M5C.Enabled = True Then
            Try
                'M5C.Image.Dispose()
            Catch
            End Try
            M5C.Image = Nothing
            M5C.Image = Image.FromFile(CardBackImage)
        End If
        If M6C.Enabled = True Then
            Try
                'M6C.Image.Dispose()
            Catch
            End Try
            M6C.Image = Nothing
            M6C.Image = Image.FromFile(CardBackImage)
        End If

        'Try
        'GC.Collect()
        'Catch
        'End Try

        If MatchChance = 0 Then

            LBLMatchChance.Text = "Game Over"
            GameOn = False
            BTNMatchEasy.Enabled = True
            BTNMatchNormal.Enabled = True
            BTNMatchHard.Enabled = True

            If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\NoPayout.wav") Then


                GameWMP.settings.setMode("loop", False)
                GameWMP.settings.volume = 20
                GameWMP.URL = Application.StartupPath & "\Audio\System\NoPayout.wav"


            End If
            'My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\NoPayout.wav")



        End If

        If MatchesMade = 9 Then


            LBLMatchChance.Text = "You Win!"
            GameOn = False
            Form1.BronzeTokens = Form1.BronzeTokens + MatchPot
            My.Settings.BronzeTokens = Form1.BronzeTokens
            My.Settings.Save()
            LBLMatchTokens.Text = Form1.BronzeTokens


            If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutSmall.wav") Then


                GameWMP.settings.setMode("loop", False)
                GameWMP.settings.volume = 20
                GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutSmall.wav"


            End If

            'If FrmSettings.CBGameSounds.Checked = True Then My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\PayoutSmall.wav")

            BTNMatchEasy.Enabled = True
            BTNMatchNormal.Enabled = True
            BTNMatchHard.Enabled = True

        End If




    End Sub

    Public Sub FlipCards()

        If MatchTemp = "M1A" Then M1A.Enabled = True
        If MatchTemp = "M2A" Then M2A.Enabled = True
        If MatchTemp = "M3A" Then M3A.Enabled = True
        If MatchTemp = "M4A" Then M4A.Enabled = True
        If MatchTemp = "M5A" Then M5A.Enabled = True
        If MatchTemp = "M6A" Then M6A.Enabled = True

        If MatchTemp = "M1B" Then M1B.Enabled = True
        If MatchTemp = "M2B" Then M2B.Enabled = True
        If MatchTemp = "M3B" Then M3B.Enabled = True
        If MatchTemp = "M4B" Then M4B.Enabled = True
        If MatchTemp = "M5B" Then M5B.Enabled = True
        If MatchTemp = "M6B" Then M6B.Enabled = True

        If MatchTemp = "M1C" Then M1C.Enabled = True
        If MatchTemp = "M2C" Then M2C.Enabled = True
        If MatchTemp = "M3C" Then M3C.Enabled = True
        If MatchTemp = "M4C" Then M4C.Enabled = True
        If MatchTemp = "M5C" Then M5C.Enabled = True
        If MatchTemp = "M6C" Then M6C.Enabled = True






    End Sub

    Public Sub PlayCardFlip()


        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\CardFlip.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\CardFlip.wav"
        End If

    End Sub

    Public Sub RemindCards()

        CardImage1 = CardImage(Pair1)
        CardImage2 = CardImage(Pair2)
        CardImage3 = CardImage(Pair3)
        CardImage4 = CardImage(Pair4)
        CardImage5 = CardImage(Pair5)
        CardImage6 = CardImage(Pair6)
        CardImage7 = CardImage(Pair7)
        CardImage8 = CardImage(Pair8)
        CardImage9 = CardImage(Pair9)

    End Sub

    Private Sub M1A_Click(sender As System.Object, e As System.EventArgs) Handles M1A.Click


        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()

        'RemindCards()

        If CardImage1 Is Nothing Or CardImage2 Is Nothing Or CardImage3 Is Nothing Or CardImage4 Is Nothing Or CardImage5 Is Nothing Or CardImage6 Is Nothing Or CardImage7 Is Nothing Or _
            CardImage8 Is Nothing Or CardImage9 Is Nothing Then
            MsgBox("Nothing here!")
        End If
        If Match1A = CompareList(0) Or Match1A = CompareList(1) Then M1A.Image = CardImage1
        If Match1A = CompareList(2) Or Match1A = CompareList(3) Then M1A.Image = CardImage2
        If Match1A = CompareList(4) Or Match1A = CompareList(5) Then M1A.Image = CardImage3
        If Match1A = CompareList(6) Or Match1A = CompareList(7) Then M1A.Image = CardImage4
        If Match1A = CompareList(8) Or Match1A = CompareList(9) Then M1A.Image = CardImage5
        If Match1A = CompareList(10) Or Match1A = CompareList(11) Then M1A.Image = CardImage6
        If Match1A = CompareList(12) Or Match1A = CompareList(13) Then M1A.Image = CardImage7
        If Match1A = CompareList(14) Or Match1A = CompareList(15) Then M1A.Image = CardImage8
        If Match1A = CompareList(16) Or Match1A = CompareList(17) Then M1A.Image = CardImage9


        If MatchPhase = 0 Then
            MatchPhase = 1
            'M1A.Load(Match1A)
            Match1 = Match1A
            M1A.Enabled = False
            MatchTemp = "M1A"
        Else
            MatchPhase = 0
            'M1A.Load(Match1A)
            Match2 = Match1A
            If Match1 = Match2 Then
                M1A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M2A_Click(sender As System.Object, e As System.EventArgs) Handles M2A.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()

        'RemindCards()


        If Match2A = CompareList(0) Or Match2A = CompareList(1) Then M2A.Image = CardImage1
        If Match2A = CompareList(2) Or Match2A = CompareList(3) Then M2A.Image = CardImage2
        If Match2A = CompareList(4) Or Match2A = CompareList(5) Then M2A.Image = CardImage3
        If Match2A = CompareList(6) Or Match2A = CompareList(7) Then M2A.Image = CardImage4
        If Match2A = CompareList(8) Or Match2A = CompareList(9) Then M2A.Image = CardImage5
        If Match2A = CompareList(10) Or Match2A = CompareList(11) Then M2A.Image = CardImage6
        If Match2A = CompareList(12) Or Match2A = CompareList(13) Then M2A.Image = CardImage7
        If Match2A = CompareList(14) Or Match2A = CompareList(15) Then M2A.Image = CardImage8
        If Match2A = CompareList(16) Or Match2A = CompareList(17) Then M2A.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match2A
            M2A.Enabled = False
            MatchTemp = "M2A"
        Else
            MatchPhase = 0
            Match2 = Match2A
            If Match1 = Match2 Then
                M2A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M3A_Click(sender As System.Object, e As System.EventArgs) Handles M3A.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match3A = CompareList(0) Or Match3A = CompareList(1) Then M3A.Image = CardImage1
        If Match3A = CompareList(2) Or Match3A = CompareList(3) Then M3A.Image = CardImage2
        If Match3A = CompareList(4) Or Match3A = CompareList(5) Then M3A.Image = CardImage3
        If Match3A = CompareList(6) Or Match3A = CompareList(7) Then M3A.Image = CardImage4
        If Match3A = CompareList(8) Or Match3A = CompareList(9) Then M3A.Image = CardImage5
        If Match3A = CompareList(10) Or Match3A = CompareList(11) Then M3A.Image = CardImage6
        If Match3A = CompareList(12) Or Match3A = CompareList(13) Then M3A.Image = CardImage7
        If Match3A = CompareList(14) Or Match3A = CompareList(15) Then M3A.Image = CardImage8
        If Match3A = CompareList(16) Or Match3A = CompareList(17) Then M3A.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match3A
            M3A.Enabled = False
            MatchTemp = "M3A"
        Else
            MatchPhase = 0
            Match2 = Match3A
            If Match1 = Match2 Then
                M3A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M4A_Click(sender As System.Object, e As System.EventArgs) Handles M4A.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match4A = CompareList(0) Or Match4A = CompareList(1) Then M4A.Image = CardImage1
        If Match4A = CompareList(2) Or Match4A = CompareList(3) Then M4A.Image = CardImage2
        If Match4A = CompareList(4) Or Match4A = CompareList(5) Then M4A.Image = CardImage3
        If Match4A = CompareList(6) Or Match4A = CompareList(7) Then M4A.Image = CardImage4
        If Match4A = CompareList(8) Or Match4A = CompareList(9) Then M4A.Image = CardImage5
        If Match4A = CompareList(10) Or Match4A = CompareList(11) Then M4A.Image = CardImage6
        If Match4A = CompareList(12) Or Match4A = CompareList(13) Then M4A.Image = CardImage7
        If Match4A = CompareList(14) Or Match4A = CompareList(15) Then M4A.Image = CardImage8
        If Match4A = CompareList(16) Or Match4A = CompareList(17) Then M4A.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match4A
            M4A.Enabled = False
            MatchTemp = "M4A"
        Else
            MatchPhase = 0
            Match2 = Match4A
            If Match1 = Match2 Then
                M4A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M5A_Click(sender As System.Object, e As System.EventArgs) Handles M5A.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match5A = CompareList(0) Or Match5A = CompareList(1) Then M5A.Image = CardImage1
        If Match5A = CompareList(2) Or Match5A = CompareList(3) Then M5A.Image = CardImage2
        If Match5A = CompareList(4) Or Match5A = CompareList(5) Then M5A.Image = CardImage3
        If Match5A = CompareList(6) Or Match5A = CompareList(7) Then M5A.Image = CardImage4
        If Match5A = CompareList(8) Or Match5A = CompareList(9) Then M5A.Image = CardImage5
        If Match5A = CompareList(10) Or Match5A = CompareList(11) Then M5A.Image = CardImage6
        If Match5A = CompareList(12) Or Match5A = CompareList(13) Then M5A.Image = CardImage7
        If Match5A = CompareList(14) Or Match5A = CompareList(15) Then M5A.Image = CardImage8
        If Match5A = CompareList(16) Or Match5A = CompareList(17) Then M5A.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match5A
            M5A.Enabled = False
            MatchTemp = "M5A"
        Else
            MatchPhase = 0
            Match2 = Match5A
            If Match1 = Match2 Then
                M5A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M6A_Click(sender As System.Object, e As System.EventArgs) Handles M6A.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match6A = CompareList(0) Or Match6A = CompareList(1) Then M6A.Image = CardImage1
        If Match6A = CompareList(2) Or Match6A = CompareList(3) Then M6A.Image = CardImage2
        If Match6A = CompareList(4) Or Match6A = CompareList(5) Then M6A.Image = CardImage3
        If Match6A = CompareList(6) Or Match6A = CompareList(7) Then M6A.Image = CardImage4
        If Match6A = CompareList(8) Or Match6A = CompareList(9) Then M6A.Image = CardImage5
        If Match6A = CompareList(10) Or Match6A = CompareList(11) Then M6A.Image = CardImage6
        If Match6A = CompareList(12) Or Match6A = CompareList(13) Then M6A.Image = CardImage7
        If Match6A = CompareList(14) Or Match6A = CompareList(15) Then M6A.Image = CardImage8
        If Match6A = CompareList(16) Or Match6A = CompareList(17) Then M6A.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match6A
            M6A.Enabled = False
            MatchTemp = "M6A"
        Else
            MatchPhase = 0
            Match2 = Match6A
            If Match1 = Match2 Then
                M6A.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub

    Private Sub M1B_Click(sender As System.Object, e As System.EventArgs) Handles M1B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match1B = CompareList(0) Or Match1B = CompareList(1) Then M1B.Image = CardImage1
        If Match1B = CompareList(2) Or Match1B = CompareList(3) Then M1B.Image = CardImage2
        If Match1B = CompareList(4) Or Match1B = CompareList(5) Then M1B.Image = CardImage3
        If Match1B = CompareList(6) Or Match1B = CompareList(7) Then M1B.Image = CardImage4
        If Match1B = CompareList(8) Or Match1B = CompareList(9) Then M1B.Image = CardImage5
        If Match1B = CompareList(10) Or Match1B = CompareList(11) Then M1B.Image = CardImage6
        If Match1B = CompareList(12) Or Match1B = CompareList(13) Then M1B.Image = CardImage7
        If Match1B = CompareList(14) Or Match1B = CompareList(15) Then M1B.Image = CardImage8
        If Match1B = CompareList(16) Or Match1B = CompareList(17) Then M1B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match1B
            M1B.Enabled = False
            MatchTemp = "M1B"
        Else
            MatchPhase = 0
            Match2 = Match1B
            If Match1 = Match2 Then
                M1B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M2B_Click(sender As System.Object, e As System.EventArgs) Handles M2B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match2B = CompareList(0) Or Match2B = CompareList(1) Then M2B.Image = CardImage1
        If Match2B = CompareList(2) Or Match2B = CompareList(3) Then M2B.Image = CardImage2
        If Match2B = CompareList(4) Or Match2B = CompareList(5) Then M2B.Image = CardImage3
        If Match2B = CompareList(6) Or Match2B = CompareList(7) Then M2B.Image = CardImage4
        If Match2B = CompareList(8) Or Match2B = CompareList(9) Then M2B.Image = CardImage5
        If Match2B = CompareList(10) Or Match2B = CompareList(11) Then M2B.Image = CardImage6
        If Match2B = CompareList(12) Or Match2B = CompareList(13) Then M2B.Image = CardImage7
        If Match2B = CompareList(14) Or Match2B = CompareList(15) Then M2B.Image = CardImage8
        If Match2B = CompareList(16) Or Match2B = CompareList(17) Then M2B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match2B
            M2B.Enabled = False
            MatchTemp = "M2B"
        Else
            MatchPhase = 0
            Match2 = Match2B
            If Match1 = Match2 Then
                M2B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M3B_Click(sender As System.Object, e As System.EventArgs) Handles M3B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match3B = CompareList(0) Or Match3B = CompareList(1) Then M3B.Image = CardImage1
        If Match3B = CompareList(2) Or Match3B = CompareList(3) Then M3B.Image = CardImage2
        If Match3B = CompareList(4) Or Match3B = CompareList(5) Then M3B.Image = CardImage3
        If Match3B = CompareList(6) Or Match3B = CompareList(7) Then M3B.Image = CardImage4
        If Match3B = CompareList(8) Or Match3B = CompareList(9) Then M3B.Image = CardImage5
        If Match3B = CompareList(10) Or Match3B = CompareList(11) Then M3B.Image = CardImage6
        If Match3B = CompareList(12) Or Match3B = CompareList(13) Then M3B.Image = CardImage7
        If Match3B = CompareList(14) Or Match3B = CompareList(15) Then M3B.Image = CardImage8
        If Match3B = CompareList(16) Or Match3B = CompareList(17) Then M3B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match3B
            M3B.Enabled = False
            MatchTemp = "M3B"
        Else
            MatchPhase = 0
            Match2 = Match3B
            If Match1 = Match2 Then
                M3B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M4B_Click(sender As System.Object, e As System.EventArgs) Handles M4B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match4B = CompareList(0) Or Match4B = CompareList(1) Then M4B.Image = CardImage1
        If Match4B = CompareList(2) Or Match4B = CompareList(3) Then M4B.Image = CardImage2
        If Match4B = CompareList(4) Or Match4B = CompareList(5) Then M4B.Image = CardImage3
        If Match4B = CompareList(6) Or Match4B = CompareList(7) Then M4B.Image = CardImage4
        If Match4B = CompareList(8) Or Match4B = CompareList(9) Then M4B.Image = CardImage5
        If Match4B = CompareList(10) Or Match4B = CompareList(11) Then M4B.Image = CardImage6
        If Match4B = CompareList(12) Or Match4B = CompareList(13) Then M4B.Image = CardImage7
        If Match4B = CompareList(14) Or Match4B = CompareList(15) Then M4B.Image = CardImage8
        If Match4B = CompareList(16) Or Match4B = CompareList(17) Then M4B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match4B
            M4B.Enabled = False
            MatchTemp = "M4B"
        Else
            MatchPhase = 0
            Match2 = Match4B
            If Match1 = Match2 Then
                M4B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M5B_Click(sender As System.Object, e As System.EventArgs) Handles M5B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match5B = CompareList(0) Or Match5B = CompareList(1) Then M5B.Image = CardImage1
        If Match5B = CompareList(2) Or Match5B = CompareList(3) Then M5B.Image = CardImage2
        If Match5B = CompareList(4) Or Match5B = CompareList(5) Then M5B.Image = CardImage3
        If Match5B = CompareList(6) Or Match5B = CompareList(7) Then M5B.Image = CardImage4
        If Match5B = CompareList(8) Or Match5B = CompareList(9) Then M5B.Image = CardImage5
        If Match5B = CompareList(10) Or Match5B = CompareList(11) Then M5B.Image = CardImage6
        If Match5B = CompareList(12) Or Match5B = CompareList(13) Then M5B.Image = CardImage7
        If Match5B = CompareList(14) Or Match5B = CompareList(15) Then M5B.Image = CardImage8
        If Match5B = CompareList(16) Or Match5B = CompareList(17) Then M5B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match5B
            M5B.Enabled = False
            MatchTemp = "M5B"
        Else
            MatchPhase = 0
            Match2 = Match5B
            If Match1 = Match2 Then
                M5B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M6B_Click(sender As System.Object, e As System.EventArgs) Handles M6B.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match6B = CompareList(0) Or Match6B = CompareList(1) Then M6B.Image = CardImage1
        If Match6B = CompareList(2) Or Match6B = CompareList(3) Then M6B.Image = CardImage2
        If Match6B = CompareList(4) Or Match6B = CompareList(5) Then M6B.Image = CardImage3
        If Match6B = CompareList(6) Or Match6B = CompareList(7) Then M6B.Image = CardImage4
        If Match6B = CompareList(8) Or Match6B = CompareList(9) Then M6B.Image = CardImage5
        If Match6B = CompareList(10) Or Match6B = CompareList(11) Then M6B.Image = CardImage6
        If Match6B = CompareList(12) Or Match6B = CompareList(13) Then M6B.Image = CardImage7
        If Match6B = CompareList(14) Or Match6B = CompareList(15) Then M6B.Image = CardImage8
        If Match6B = CompareList(16) Or Match6B = CompareList(17) Then M6B.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match6B
            M6B.Enabled = False
            MatchTemp = "M6B"
        Else
            MatchPhase = 0
            Match2 = Match6B
            If Match1 = Match2 Then
                M6B.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub

    Private Sub M1C_Click(sender As System.Object, e As System.EventArgs) Handles M1C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match1C = CompareList(0) Or Match1C = CompareList(1) Then M1C.Image = CardImage1
        If Match1C = CompareList(2) Or Match1C = CompareList(3) Then M1C.Image = CardImage2
        If Match1C = CompareList(4) Or Match1C = CompareList(5) Then M1C.Image = CardImage3
        If Match1C = CompareList(6) Or Match1C = CompareList(7) Then M1C.Image = CardImage4
        If Match1C = CompareList(8) Or Match1C = CompareList(9) Then M1C.Image = CardImage5
        If Match1C = CompareList(10) Or Match1C = CompareList(11) Then M1C.Image = CardImage6
        If Match1C = CompareList(12) Or Match1C = CompareList(13) Then M1C.Image = CardImage7
        If Match1C = CompareList(14) Or Match1C = CompareList(15) Then M1C.Image = CardImage8
        If Match1C = CompareList(16) Or Match1C = CompareList(17) Then M1C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match1C
            M1C.Enabled = False
            MatchTemp = "M1C"
        Else
            MatchPhase = 0
            Match2 = Match1C
            If Match1 = Match2 Then
                M1C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M2C_Click(sender As System.Object, e As System.EventArgs) Handles M2C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match2C = CompareList(0) Or Match2C = CompareList(1) Then M2C.Image = CardImage1
        If Match2C = CompareList(2) Or Match2C = CompareList(3) Then M2C.Image = CardImage2
        If Match2C = CompareList(4) Or Match2C = CompareList(5) Then M2C.Image = CardImage3
        If Match2C = CompareList(6) Or Match2C = CompareList(7) Then M2C.Image = CardImage4
        If Match2C = CompareList(8) Or Match2C = CompareList(9) Then M2C.Image = CardImage5
        If Match2C = CompareList(10) Or Match2C = CompareList(11) Then M2C.Image = CardImage6
        If Match2C = CompareList(12) Or Match2C = CompareList(13) Then M2C.Image = CardImage7
        If Match2C = CompareList(14) Or Match2C = CompareList(15) Then M2C.Image = CardImage8
        If Match2C = CompareList(16) Or Match2C = CompareList(17) Then M2C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match2C
            M2C.Enabled = False
            MatchTemp = "M2C"
        Else
            MatchPhase = 0
            Match2 = Match2C
            If Match1 = Match2 Then
                M2C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M3C_Click(sender As System.Object, e As System.EventArgs) Handles M3C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match3C = CompareList(0) Or Match3C = CompareList(1) Then M3C.Image = CardImage1
        If Match3C = CompareList(2) Or Match3C = CompareList(3) Then M3C.Image = CardImage2
        If Match3C = CompareList(4) Or Match3C = CompareList(5) Then M3C.Image = CardImage3
        If Match3C = CompareList(6) Or Match3C = CompareList(7) Then M3C.Image = CardImage4
        If Match3C = CompareList(8) Or Match3C = CompareList(9) Then M3C.Image = CardImage5
        If Match3C = CompareList(10) Or Match3C = CompareList(11) Then M3C.Image = CardImage6
        If Match3C = CompareList(12) Or Match3C = CompareList(13) Then M3C.Image = CardImage7
        If Match3C = CompareList(14) Or Match3C = CompareList(15) Then M3C.Image = CardImage8
        If Match3C = CompareList(16) Or Match3C = CompareList(17) Then M3C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match3C
            M3C.Enabled = False
            MatchTemp = "M3C"
        Else
            MatchPhase = 0
            Match2 = Match3C
            If Match1 = Match2 Then
                M3C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M4C_Click(sender As System.Object, e As System.EventArgs) Handles M4C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match4C = CompareList(0) Or Match4C = CompareList(1) Then M4C.Image = CardImage1
        If Match4C = CompareList(2) Or Match4C = CompareList(3) Then M4C.Image = CardImage2
        If Match4C = CompareList(4) Or Match4C = CompareList(5) Then M4C.Image = CardImage3
        If Match4C = CompareList(6) Or Match4C = CompareList(7) Then M4C.Image = CardImage4
        If Match4C = CompareList(8) Or Match4C = CompareList(9) Then M4C.Image = CardImage5
        If Match4C = CompareList(10) Or Match4C = CompareList(11) Then M4C.Image = CardImage6
        If Match4C = CompareList(12) Or Match4C = CompareList(13) Then M4C.Image = CardImage7
        If Match4C = CompareList(14) Or Match4C = CompareList(15) Then M4C.Image = CardImage8
        If Match4C = CompareList(16) Or Match4C = CompareList(17) Then M4C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match4C
            M4C.Enabled = False
            MatchTemp = "M4C"
        Else
            MatchPhase = 0
            Match2 = Match4C
            If Match1 = Match2 Then
                M4C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M5C_Click(sender As System.Object, e As System.EventArgs) Handles M5C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match5C = CompareList(0) Or Match5C = CompareList(1) Then M5C.Image = CardImage1
        If Match5C = CompareList(2) Or Match5C = CompareList(3) Then M5C.Image = CardImage2
        If Match5C = CompareList(4) Or Match5C = CompareList(5) Then M5C.Image = CardImage3
        If Match5C = CompareList(6) Or Match5C = CompareList(7) Then M5C.Image = CardImage4
        If Match5C = CompareList(8) Or Match5C = CompareList(9) Then M5C.Image = CardImage5
        If Match5C = CompareList(10) Or Match5C = CompareList(11) Then M5C.Image = CardImage6
        If Match5C = CompareList(12) Or Match5C = CompareList(13) Then M5C.Image = CardImage7
        If Match5C = CompareList(14) Or Match5C = CompareList(15) Then M5C.Image = CardImage8
        If Match5C = CompareList(16) Or Match5C = CompareList(17) Then M5C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match5C
            M5C.Enabled = False
            MatchTemp = "M5C"
        Else
            MatchPhase = 0
            Match2 = Match5C
            If Match1 = Match2 Then
                M5C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub
    Private Sub M6C_Click(sender As System.Object, e As System.EventArgs) Handles M6C.Click

        If CardTimer.Enabled = True Or GameOn = False Then Return

        PlayCardFlip()



        If Match6C = CompareList(0) Or Match6C = CompareList(1) Then M6C.Image = CardImage1
        If Match6C = CompareList(2) Or Match6C = CompareList(3) Then M6C.Image = CardImage2
        If Match6C = CompareList(4) Or Match6C = CompareList(5) Then M6C.Image = CardImage3
        If Match6C = CompareList(6) Or Match6C = CompareList(7) Then M6C.Image = CardImage4
        If Match6C = CompareList(8) Or Match6C = CompareList(9) Then M6C.Image = CardImage5
        If Match6C = CompareList(10) Or Match6C = CompareList(11) Then M6C.Image = CardImage6
        If Match6C = CompareList(12) Or Match6C = CompareList(13) Then M6C.Image = CardImage7
        If Match6C = CompareList(14) Or Match6C = CompareList(15) Then M6C.Image = CardImage8
        If Match6C = CompareList(16) Or Match6C = CompareList(17) Then M6C.Image = CardImage9

        If MatchPhase = 0 Then
            MatchPhase = 1
            Match1 = Match6C
            M6C.Enabled = False
            MatchTemp = "M6C"
        Else
            MatchPhase = 0
            Match2 = Match6C
            If Match1 = Match2 Then
                M6C.Enabled = False
            Else
                FlipCards()
            End If
            CheckMatchTemp()
        End If

    End Sub

    Private Sub CardTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CardTimer.Tick

        CardTick -= 1

        If CardTick < 1 Then
            CardTimer.Stop()
        End If

    End Sub



    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If SlotTimer3.Enabled = True Or LBLSlotBet.Text = 0 Then Return


        SlotTick1 = 4
        SlotTick2 = 12
        SlotTick3 = 36



        SlotList.Clear()

        SlotList.Add(My.Settings.BP1)
        SlotList.Add(My.Settings.BP2)
        SlotList.Add(My.Settings.BP3)
        SlotList.Add(My.Settings.BP4)
        SlotList.Add(My.Settings.BP5)
        SlotList.Add(My.Settings.BP6)

        SlotList.Add(My.Settings.SP1)
        SlotList.Add(My.Settings.SP2)
        SlotList.Add(My.Settings.SP3)
        SlotList.Add(My.Settings.SP4)
        SlotList.Add(My.Settings.SP5)
        SlotList.Add(My.Settings.SP6)

        SlotList.Add(My.Settings.GP1)
        SlotList.Add(My.Settings.GP2)
        SlotList.Add(My.Settings.GP3)
        SlotList.Add(My.Settings.GP4)
        SlotList.Add(My.Settings.GP5)
        SlotList.Add(My.Settings.GP6)

        SlotBack1.BackColor = Color.Gainsboro
        SlotBack2.BackColor = Color.Gainsboro
        SlotBack3.BackColor = Color.Gainsboro

        LBLSlotPayout.Text = "---"

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\Slots.wav") Then
            ' mciSendString("close myWAV", Nothing, 0, 0)

            fileName1 = Application.StartupPath & "\Audio\System\Slots.wav"
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = fileName1


            'fileName1 = Form1.GetShortPathName(fileName1)

            'Dim Volume As Integer = 50
            'mciSendString("setaudio myWAV volume to " & Volume, Nothing, 0, 0)
            'waveoutsetvolume(-1, 5)

            'mciSendString("open " & fileName1 & " type WAVEAUDIO alias myWAV", Nothing, 0, 0)
            'mciSendString("play myWAV", Nothing, 0, 0)
        End If
        'My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\Slots.wav", AudioPlayMode.Background)


        Form1.BronzeTokens -= LBLSlotBet.Text
        LBLSlotTokens.Text = Form1.BronzeTokens

        If Val(LBLSlotBet.Text) > Val(LBLSlotTokens.Text) Then
            LBLSlotBet.Text = LBLSlotTokens.Text
            SlotBet = Val(LBLSlotBet.Text)
            SlotBetTemp = Val(LBLSlotBet.Text)
        End If

        Try
            Slot1.Image.Dispose()
        Catch
        End Try
        Slot1.Image = Nothing

        Try
            Slot2.Image.Dispose()
        Catch
        End Try
        Slot2.Image = Nothing

        Try
            Slot3.Image.Dispose()
        Catch
        End Try
        Slot3.Image = Nothing

        GC.Collect()

        SlotTimer1.Start()
        SlotTImer2.Start()
        SlotTimer3.Start()




    End Sub

    Private Sub SlotTimer_Tick(sender As System.Object, e As System.EventArgs) Handles SlotTimer1.Tick

        SlotTick1 -= 1

        Slot1Val = randomizer.Next(0, 18)
        Try
            Slot1.Image.Dispose()
        Catch
        End Try
        Slot1.Image = Nothing
        GC.Collect()
        Slot1.Image = Image.FromFile(SlotList(Slot1Val))

        If SlotTick1 < 1 Then
            SlotTimer1.Stop()
            SlotBack1.BackColor = Color.Silver
            If Slot1Val < 6 Then SlotBack1.BackColor = Color.Peru
            If Slot1Val > 11 Then SlotBack1.BackColor = Color.Gold
        End If







    End Sub

    Private Sub SlotTImer2_Tick(sender As System.Object, e As System.EventArgs) Handles SlotTImer2.Tick


        SlotTick2 -= 1

        Slot2Val = randomizer.Next(0, 18)
        Try
            Slot2.Image.Dispose()
        Catch
        End Try
        Slot2.Image = Nothing
        GC.Collect()
        Slot2.Image = Image.FromFile(SlotList(Slot2Val))

        If SlotTick2 < 1 Then
            SlotTImer2.Stop()
            SlotBack2.BackColor = Color.Silver
            If Slot2Val < 6 Then SlotBack2.BackColor = Color.Peru
            If Slot2Val > 11 Then SlotBack2.BackColor = Color.Gold
        End If




    End Sub

    Private Sub SlotTimer3_Tick(sender As System.Object, e As System.EventArgs) Handles SlotTimer3.Tick

        SlotTick3 -= 1

        Slot3Val = randomizer.Next(0, 18)
        Try
            Slot3.Image.Dispose()
        Catch
        End Try
        Slot3.Image = Nothing
        GC.Collect()
        Slot3.Image = Image.FromFile(SlotList(Slot3Val))

        If SlotTick3 < 1 Then
            SlotTimer3.Stop()
            SlotBack3.BackColor = Color.Silver
            If Slot3Val < 6 Then SlotBack3.BackColor = Color.Peru
            If Slot3Val > 11 Then SlotBack3.BackColor = Color.Gold


            Payout = 0

            If SlotBack1.BackColor = Color.Gold Then Payout = 1
            If SlotBack1.BackColor = Color.Gold And SlotBack2.BackColor = Color.Gold Then Payout = 2

            If SlotBack1.BackColor = Color.Peru And SlotBack2.BackColor = Color.Peru And SlotBack3.BackColor = Color.Peru Then Payout = 3
            If SlotBack1.BackColor = Color.Silver And SlotBack2.BackColor = Color.Silver And SlotBack3.BackColor = Color.Silver Then Payout = 5
            If SlotBack1.BackColor = Color.Gold And SlotBack2.BackColor = Color.Gold And SlotBack3.BackColor = Color.Gold Then Payout = 7

            If SlotBack1.BackColor = Color.Peru And SlotBack2.BackColor = Color.Peru And Slot1Val = Slot2Val Then Payout = 10
            If SlotBack1.BackColor = Color.Silver And SlotBack2.BackColor = Color.Silver And Slot1Val = Slot2Val Then Payout = 15
            If SlotBack1.BackColor = Color.Gold And SlotBack2.BackColor = Color.Gold And Slot1Val = Slot2Val Then Payout = 20

            If SlotBack1.BackColor = Color.Peru And SlotBack2.BackColor = Color.Peru And SlotBack3.BackColor = Color.Peru And Slot1Val = Slot2Val And Slot2Val = Slot3Val Then Payout = 30
            If SlotBack1.BackColor = Color.Silver And SlotBack2.BackColor = Color.Silver And SlotBack3.BackColor = Color.Silver And Slot1Val = Slot2Val And Slot2Val = Slot3Val Then Payout = 40
            If SlotBack1.BackColor = Color.Gold And SlotBack2.BackColor = Color.Gold And SlotBack3.BackColor = Color.Gold And Slot1Val = Slot2Val And Slot2Val = Slot3Val Then Payout = 50

            Payout *= SlotBet
            LBLSlotPayout.Text = Payout

            If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutOne.wav") Then
                ' Dim SlotSound As String

                'mciSendString("close myWAV", Nothing, 0, 0)


                If Payout < 4 Then
                    'SlotSound = Application.StartupPath & "\Audio\System\PayoutOne.wav"


                    fileName1 = Application.StartupPath & "\Audio\System\PayoutOne.wav"
                    'fileName1 = Form1.GetShortPathName(fileName1)




                    'min Volume is 1, max Volume is 1000



                End If

                If Payout > 3 And Payout < 26 And File.Exists(Application.StartupPath & "\Audio\System\PayoutSmall.wav") Then
                    'SlotSound = Application.StartupPath & "\Audio\System\PayoutSmall.wav"

                    fileName1 = Application.StartupPath & "\Audio\System\PayoutSmall.wav"
                    '   fileName1 = Form1.GetShortPathName(fileName1)
                End If

                If Payout > 25 And File.Exists(Application.StartupPath & "\Audio\System\PayoutBig.wav") Then
                    'SlotSound = Application.StartupPath & "\Audio\System\PayoutBig.wav"

                    fileName1 = Application.StartupPath & "\Audio\System\PayoutBig.wav"
                    '  fileName1 = Form1.GetShortPathName(fileName1)
                End If

                If Payout = 0 And File.Exists(Application.StartupPath & "\Audio\System\NoPayout.wav") Then
                    'SlotSound = Application.StartupPath & "\Audio\System\NoPayout.wav"

                    fileName1 = Application.StartupPath & "\Audio\System\NoPayout.wav"
                    ' fileName1 = Form1.GetShortPathName(fileName1)
                End If

                GameWMP.settings.setMode("loop", False)
                GameWMP.settings.volume = 20
                GameWMP.URL = fileName1


                'Dim Volume As Integer = 50
                'mciSendString("setaudio myWAV volume to " & Volume, Nothing, 0, 0)

                '                mciSendString("open " & fileName1 & " type WAVEAUDIO alias myWAV", Nothing, 0, 0)
                '               mciSendString("play myWAV", Nothing, 0, 0)

                'My.Computer.Audio.Play(SlotSound)
            End If


            Form1.BronzeTokens += Payout

            LBLSlotTokens.Text = Form1.BronzeTokens

            My.Settings.BronzeTokens = Form1.BronzeTokens
            My.Settings.Save()



        End If








    End Sub

    Private Sub Panel5_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub FrmCardList_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        InitializeSlots()

    End Sub

    Public Sub InitializeSlots()

        SlotList.Clear()

        SlotList.Add(My.Settings.BP1)
        SlotList.Add(My.Settings.BP2)
        SlotList.Add(My.Settings.BP3)
        SlotList.Add(My.Settings.BP4)
        SlotList.Add(My.Settings.BP5)
        SlotList.Add(My.Settings.BP6)

        SlotList.Add(My.Settings.SP1)
        SlotList.Add(My.Settings.SP2)
        SlotList.Add(My.Settings.SP3)
        SlotList.Add(My.Settings.SP4)
        SlotList.Add(My.Settings.SP5)
        SlotList.Add(My.Settings.SP6)

        SlotList.Add(My.Settings.GP1)
        SlotList.Add(My.Settings.GP2)
        SlotList.Add(My.Settings.GP3)
        SlotList.Add(My.Settings.GP4)
        SlotList.Add(My.Settings.GP5)
        SlotList.Add(My.Settings.GP6)



        Slot1.Image = Image.FromFile(SlotList(randomizer.Next(0, SlotList.Count)))
        Slot2.Image = Image.FromFile(SlotList(randomizer.Next(0, SlotList.Count)))
        Slot3.Image = Image.FromFile(SlotList(randomizer.Next(0, SlotList.Count)))



        Dim SlotImage As String

        If File.Exists(My.Settings.CardBack) Then
            SlotImage = My.Settings.CardBack
        Else
            SlotImage = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\_CardBackPicture.png"
        End If

        SlotLeft2.Image = Image.FromFile(SlotImage)
        SlotLeft1.Image = Image.FromFile(SlotImage)
        SlotRight1.Image = Image.FromFile(SlotImage)
        SlotRight2.Image = Image.FromFile(SlotImage)

        LBLSlotTokens.Text = Form1.BronzeTokens

    End Sub

    Public Sub ClearSlots()

        Try
            Slot1.Image.Dispose()
        Catch
        End Try
        Slot1.Image = Nothing

        Try
            Slot2.Image.Dispose()
        Catch
        End Try
        Slot2.Image = Nothing

        Try
            Slot3.Image.Dispose()
        Catch
        End Try
        Slot3.Image = Nothing

        Try
            SlotLeft1.Image.Dispose()
        Catch
        End Try
        SlotLeft1.Image = Nothing

        Try
            SlotLeft2.Image.Dispose()
        Catch
        End Try
        SlotLeft2.Image = Nothing

        Try
            SlotRight1.Image.Dispose()
        Catch
        End Try
        SlotRight1.Image = Nothing

        Try
            SlotRight2.Image.Dispose()
        Catch
        End Try
        SlotRight2.Image = Nothing

        Try
            GC.Collect()
        Catch
        End Try

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        If SlotTimer3.Enabled = True Then Return

        If SlotBet < 3 Then
            SlotBet += 1
            If SlotBet > LBLSlotTokens.Text Then SlotBet -= 1
            LBLSlotBet.Text = SlotBet
        End If

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        If SlotTimer3.Enabled = True Then Return

        If SlotBet > 0 Then
            SlotBet -= 1
            LBLSlotBet.Text = SlotBet
        End If


    End Sub



    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)

        Form1.BronzeTokens += 5
        LBLSlotTokens.Text = Form1.BronzeTokens
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles BTNMatchEasy.Click

        If Form1.BronzeTokens < 1 Then Return


        InitializeCards()

        If MatchList.Count < 1 Then
            MessageBox.Show(Me, "You will need to select at least 1 local image folder or URL File before you can play the Match Game!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        BTNMatchEasy.Enabled = False
        BTNMatchNormal.Enabled = False
        BTNMatchHard.Enabled = False

        EraseCards()

        Form1.BronzeTokens -= 1
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.Save()
        LBLMatchTokens.Text = Form1.BronzeTokens

        CardSetup = True

        MatchChance = 15
        MatchesMade = 0
        MatchPot = 3

        MatchGameStart()

    End Sub

    Private Sub BTNMatchNormal_Click(sender As System.Object, e As System.EventArgs) Handles BTNMatchNormal.Click

        If Form1.BronzeTokens < 1 Then Return

        InitializeCards()

        If MatchList.Count < 1 Then
            MessageBox.Show(Me, "You will need to select at least 1 local image folder or URL File before you can play the Match Game!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        BTNMatchEasy.Enabled = False
        BTNMatchNormal.Enabled = False
        BTNMatchHard.Enabled = False

        EraseCards()

        Form1.BronzeTokens -= 1
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.Save()
        LBLMatchTokens.Text = Form1.BronzeTokens

        CardSetup = True

        MatchChance = 10
        MatchesMade = 0
        MatchPot = 10

        MatchGameStart()

    End Sub

    Private Sub BTNMatchHard_Click(sender As System.Object, e As System.EventArgs) Handles BTNMatchHard.Click

        If Form1.BronzeTokens < 1 Then Return

        InitializeCards()

        If MatchList.Count < 1 Then
            MessageBox.Show(Me, "You will need to select at least 1 local image folder or URL File before you can play the Match Game!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        BTNMatchEasy.Enabled = False
        BTNMatchNormal.Enabled = False
        BTNMatchHard.Enabled = False

        EraseCards()

        Form1.BronzeTokens -= 1
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.Save()
        LBLMatchTokens.Text = Form1.BronzeTokens

        CardSetup = True

        MatchChance = 7
        MatchesMade = 0
        MatchPot = 25

        MatchGameStart()


    End Sub

    Public Sub ClearMatchCache()



        Try
            M1A.Image.Dispose()
        Catch
        End Try
        Try
            M2A.Image.Dispose()
        Catch
        End Try
        Try
            M3A.Image.Dispose()
        Catch
        End Try
        Try
            M4A.Image.Dispose()
        Catch
        End Try
        Try
            M5A.Image.Dispose()
        Catch
        End Try
        Try
            M6A.Image.Dispose()
        Catch
        End Try

        Try
            M1B.Image.Dispose()
        Catch
        End Try
        Try
            M2B.Image.Dispose()
        Catch
        End Try
        Try
            M3B.Image.Dispose()
        Catch
        End Try
        Try
            M4B.Image.Dispose()
        Catch
        End Try
        Try
            M5B.Image.Dispose()
        Catch
        End Try
        Try
            M6B.Image.Dispose()
        Catch
        End Try

        Try
            M1C.Image.Dispose()
        Catch
        End Try
        Try
            M2C.Image.Dispose()
        Catch
        End Try
        Try
            M3C.Image.Dispose()
        Catch
        End Try
        Try
            M4C.Image.Dispose()
        Catch
        End Try
        Try
            M5C.Image.Dispose()
        Catch
        End Try
        Try
            M6C.Image.Dispose()
        Catch
        End Try


        M1A.Image = Nothing
        M2A.Image = Nothing
        M3A.Image = Nothing
        M4A.Image = Nothing
        M5A.Image = Nothing
        M6A.Image = Nothing



        M1B.Image = Nothing
        M2B.Image = Nothing
        M3B.Image = Nothing
        M4B.Image = Nothing
        M5B.Image = Nothing
        M6B.Image = Nothing



        M1C.Image = Nothing
        M2C.Image = Nothing
        M3C.Image = Nothing
        M4C.Image = Nothing
        M5C.Image = Nothing
        M6C.Image = Nothing




        Try
            GC.Collect()
        Catch
        End Try

    End Sub

    Public Sub EraseCards()

        M1A.Visible = False
        M2A.Visible = False
        M3A.Visible = False
        M4A.Visible = False
        M5A.Visible = False
        M6A.Visible = False

        M1B.Visible = False
        M2B.Visible = False
        M3B.Visible = False
        M4B.Visible = False
        M5B.Visible = False
        M6B.Visible = False

        M1C.Visible = False
        M2C.Visible = False
        M3C.Visible = False
        M4C.Visible = False
        M5C.Visible = False
        M6C.Visible = False



    End Sub

    Private Sub TCGames_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TCGames.SelectedIndexChanged

        ClearAllCards()

        If TCGames.SelectedIndex <> 0 Then
            ClearSlots()
            SlotBet = 0
            LBLSlotBet.Text = SlotBet
        End If

        If TCGames.SelectedIndex = 0 Then
            InitializeSlots()
            LBLSlotTokens.Text = Form1.BronzeTokens
        End If

        If TCGames.SelectedIndex <> 1 Then
            ClearMatchCache()
        End If

        If TCGames.SelectedIndex = 1 Then
            InitializeCards()
            LBLMatchTokens.Text = Form1.BronzeTokens
        End If

        If TCGames.SelectedIndex = 2 Then

            LBLRiskTokens.Text = Form1.BronzeTokens
        End If

        If TCGames.SelectedIndex = 3 Then

            If Form1.CompareDates(My.Settings.TokenTasks) <> 0 Then
                BTNTokenRequest.Enabled = True
            Else
                BTNTokenRequest.Enabled = False
            End If

            ClearExchange()
            CheckExchange()

            If File.Exists(My.Settings.CardBack) Then
                Try
                    BoosterBack.Image.Dispose()
                Catch
                End Try

                BoosterBack.Image = Nothing
                GC.Collect()

                BoosterBack.Image = Image.FromFile(My.Settings.CardBack)
            Else
                BoosterBack.Image = Image.FromFile(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\_CardBackPicture.png")
            End If
            LBLExchangeBronze.Text = Form1.BronzeTokens
            LBLExchangeSilver.Text = Form1.SilverTokens
            LBLExchangeGold.Text = Form1.GoldTokens
        End If

        If TCGames.SelectedIndex = 4 Then



            BronzeQ1.Text = My.Settings.B1
            BronzeQ2.Text = My.Settings.B2
            BronzeQ3.Text = My.Settings.B3
            BronzeQ4.Text = My.Settings.B4
            BronzeQ5.Text = My.Settings.B5
            BronzeQ6.Text = My.Settings.B6

            SilverQ1.Text = My.Settings.S1
            SilverQ2.Text = My.Settings.S2
            SilverQ3.Text = My.Settings.S3
            SilverQ4.Text = My.Settings.S4
            SilverQ5.Text = My.Settings.S5
            SilverQ6.Text = My.Settings.S6

            GoldQ1.Text = My.Settings.G1
            GoldQ2.Text = My.Settings.G2
            GoldQ3.Text = My.Settings.G3
            GoldQ4.Text = My.Settings.G4
            GoldQ5.Text = My.Settings.G5
            GoldQ6.Text = My.Settings.G6

            If GoldQ1.Text <> 0 Then
                GoldN1.Text = FrmSettings.GN1.Text
                GoldP1.Image = Image.FromFile(My.Settings.GP1)
                GoldP1.Visible = True
            Else
                GoldP1.Visible = False
                GoldN1.Text = ""
            End If

            If GoldQ2.Text <> 0 Then
                GoldN2.Text = FrmSettings.GN2.Text
                GoldP2.Image = Image.FromFile(My.Settings.GP2)
                GoldP2.Visible = True
            Else
                GoldP2.Visible = False
                GoldN2.Text = ""
            End If

            If GoldQ3.Text <> 0 Then
                GoldN3.Text = FrmSettings.GN3.Text
                GoldP3.Image = Image.FromFile(My.Settings.GP3)
                GoldP3.Visible = True
            Else
                GoldP3.Visible = False
                GoldN3.Text = ""
            End If

            If GoldQ4.Text <> 0 Then
                GoldN4.Text = FrmSettings.GN4.Text
                GoldP4.Image = Image.FromFile(My.Settings.GP4)
                GoldP4.Visible = True
            Else
                GoldP4.Visible = False
                GoldN4.Text = ""
            End If

            If GoldQ5.Text <> 0 Then
                GoldN5.Text = FrmSettings.GN5.Text
                GoldP5.Image = Image.FromFile(My.Settings.GP5)
                GoldP5.Visible = True
            Else
                GoldP5.Visible = False
                GoldN5.Text = ""
            End If

            If GoldQ6.Text <> 0 Then
                GoldN6.Text = FrmSettings.GN6.Text
                GoldP6.Image = Image.FromFile(My.Settings.GP6)
                GoldP6.Visible = True
            Else
                GoldP6.Visible = False
                GoldN6.Text = ""
            End If


            If SilverQ1.Text <> 0 Then
                SilverN1.Text = FrmSettings.SN1.Text
                SilverP1.Image = Image.FromFile(My.Settings.SP1)
                SilverP1.Visible = True
            Else
                SilverP1.Visible = False
                SilverN1.Text = ""
            End If

            If SilverQ2.Text <> 0 Then
                SilverN2.Text = FrmSettings.SN2.Text
                SilverP2.Image = Image.FromFile(My.Settings.SP2)
                SilverP2.Visible = True
            Else
                SilverP2.Visible = False
                SilverN2.Text = ""
            End If

            If SilverQ3.Text <> 0 Then
                SilverN3.Text = FrmSettings.SN3.Text
                SilverP3.Image = Image.FromFile(My.Settings.SP3)
                SilverP3.Visible = True
            Else
                SilverP3.Visible = False
                SilverN3.Text = ""
            End If

            If SilverQ4.Text <> 0 Then
                SilverN4.Text = FrmSettings.SN4.Text
                SilverP4.Image = Image.FromFile(My.Settings.SP4)
                SilverP4.Visible = True
            Else
                SilverP4.Visible = False
                SilverN4.Text = ""
            End If

            If SilverQ5.Text <> 0 Then
                SilverN5.Text = FrmSettings.SN5.Text
                SilverP5.Image = Image.FromFile(My.Settings.SP5)
                SilverP5.Visible = True
            Else
                SilverP5.Visible = False
                SilverN5.Text = ""
            End If

            If SilverQ6.Text <> 0 Then
                SilverN6.Text = FrmSettings.SN6.Text
                SilverP6.Image = Image.FromFile(My.Settings.SP6)
                SilverP6.Visible = True
            Else
                SilverP6.Visible = False
                SilverN6.Text = ""
            End If


            If BronzeQ1.Text <> 0 Then
                BronzeN1.Text = FrmSettings.BN1.Text
                BronzeP1.Image = Image.FromFile(My.Settings.BP1)
                BronzeP1.Visible = True
            Else
                BronzeP1.Visible = False
                BronzeN1.Text = ""
            End If

            If BronzeQ2.Text <> 0 Then
                BronzeN2.Text = FrmSettings.BN2.Text
                BronzeP2.Image = Image.FromFile(My.Settings.BP2)
                BronzeP2.Visible = True
            Else
                BronzeP2.Visible = False
                BronzeN2.Text = ""
            End If

            If BronzeQ3.Text <> 0 Then
                BronzeN3.Text = FrmSettings.BN3.Text
                BronzeP3.Image = Image.FromFile(My.Settings.BP3)
                BronzeP3.Visible = True
            Else
                BronzeP3.Visible = False
                BronzeN3.Text = ""
            End If

            If BronzeQ4.Text <> 0 Then
                BronzeN4.Text = FrmSettings.BN4.Text
                BronzeP4.Image = Image.FromFile(My.Settings.BP4)
                BronzeP4.Visible = True
            Else
                BronzeP4.Visible = False
                BronzeN4.Text = ""
            End If

            If BronzeQ5.Text <> 0 Then
                BronzeN5.Text = FrmSettings.BN5.Text
                BronzeP5.Image = Image.FromFile(My.Settings.BP5)
                BronzeP5.Visible = True
            Else
                BronzeP5.Visible = False
                BronzeN5.Text = ""
            End If

            If BronzeQ6.Text <> 0 Then
                BronzeN6.Text = FrmSettings.BN6.Text
                BronzeP6.Image = Image.FromFile(My.Settings.BP6)
                BronzeP6.Visible = True
            Else
                BronzeP6.Visible = False
                BronzeN6.Text = ""
            End If







        End If



    End Sub




    Private Sub ShuffleTimer_Tick(sender As System.Object, e As System.EventArgs) Handles ShuffleTimer.Tick

        ShuffleTick -= 1

        If ShuffleTick = 18 Then M1A.Visible = True
        If ShuffleTick = 17 Then M2A.Visible = True
        If ShuffleTick = 16 Then M3A.Visible = True
        If ShuffleTick = 15 Then M4A.Visible = True
        If ShuffleTick = 14 Then M5A.Visible = True
        If ShuffleTick = 13 Then M6A.Visible = True

        If ShuffleTick = 12 Then M1B.Visible = True
        If ShuffleTick = 11 Then M2B.Visible = True
        If ShuffleTick = 10 Then M3B.Visible = True
        If ShuffleTick = 9 Then M4B.Visible = True
        If ShuffleTick = 8 Then M5B.Visible = True
        If ShuffleTick = 7 Then M6B.Visible = True

        If ShuffleTick = 6 Then M1C.Visible = True
        If ShuffleTick = 5 Then M2C.Visible = True
        If ShuffleTick = 4 Then M3C.Visible = True
        If ShuffleTick = 3 Then M4C.Visible = True
        If ShuffleTick = 2 Then M5C.Visible = True
        If ShuffleTick = 1 Then M6C.Visible = True

        If ShuffleTick = 0 Then
            GameOn = True
            ShuffleTimer.Stop()

            M1A.Enabled = True
            M2A.Enabled = True
            M3A.Enabled = True
            M4A.Enabled = True
            M5A.Enabled = True
            M6A.Enabled = True

            M1B.Enabled = True
            M2B.Enabled = True
            M3B.Enabled = True
            M4B.Enabled = True
            M5B.Enabled = True
            M6B.Enabled = True

            M1C.Enabled = True
            M2C.Enabled = True
            M3C.Enabled = True
            M4C.Enabled = True
            M5C.Enabled = True
            M6C.Enabled = True

            RemindCards()
        End If




    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles BTNBoosterBuy.Click

        If Form1.BronzeTokens < 25 Then Return

        Form1.BronzeTokens -= 25
        LBLExchangeBronze.Text = Form1.BronzeTokens
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.Save()

        BoosterListBronze.Clear()
        BoosterListSilver.Clear()
        BoosterListGold.Clear()

        BoosterListBronze.Add(My.Settings.BP1)
        BoosterListBronze.Add(My.Settings.BP2)
        BoosterListBronze.Add(My.Settings.BP3)
        BoosterListBronze.Add(My.Settings.BP4)
        BoosterListBronze.Add(My.Settings.BP5)
        BoosterListBronze.Add(My.Settings.BP6)

        BoosterListSilver.Add(My.Settings.SP1)
        BoosterListSilver.Add(My.Settings.SP2)
        BoosterListSilver.Add(My.Settings.SP3)
        BoosterListSilver.Add(My.Settings.SP4)
        BoosterListSilver.Add(My.Settings.SP5)
        BoosterListSilver.Add(My.Settings.SP6)

        BoosterListGold.Add(My.Settings.GP1)
        BoosterListGold.Add(My.Settings.GP2)
        BoosterListGold.Add(My.Settings.GP3)
        BoosterListGold.Add(My.Settings.GP4)
        BoosterListGold.Add(My.Settings.GP5)
        BoosterListGold.Add(My.Settings.GP6)

        BoosterTick = 6
        BTNBoosterBuy.Enabled = False

        Booster1.Visible = False
        Booster2.Visible = False
        Booster3.Visible = False
        Booster4.Visible = False
        Booster5.Visible = False



        Try
            Booster1.Image.Dispose()
        Catch
        End Try
        Booster1.Image = Nothing
        Try
            Booster2.Image.Dispose()
        Catch
        End Try
        Booster2.Image = Nothing
        Try
            Booster3.Image.Dispose()
        Catch
        End Try
        Booster3.Image = Nothing
        Try
            Booster4.Image.Dispose()
        Catch
        End Try
        Booster4.Image = Nothing
        Try
            Booster5.Image.Dispose()
        Catch
        End Try
        Booster5.Image = Nothing
        Try
            GC.Collect()
        Catch
        End Try

        Booster1Frame.BackColor = Color.DimGray
        Booster1Plate.BackColor = Color.DimGray
        Booster2Frame.BackColor = Color.DimGray
        Booster2Plate.BackColor = Color.DimGray
        Booster3Frame.BackColor = Color.DimGray
        Booster3Plate.BackColor = Color.DimGray
        Booster4Frame.BackColor = Color.DimGray
        Booster4Plate.BackColor = Color.DimGray
        Booster5Frame.BackColor = Color.DimGray
        Booster5Plate.BackColor = Color.DimGray

        Booster1Name.Text = ""
        Booster2Name.Text = ""
        Booster3Name.Text = ""
        Booster4Name.Text = ""
        Booster5Name.Text = ""



        BoosterTimer.Start()
        CheckExchange()



    End Sub


    Private Sub BoosterTimer_Tick(sender As System.Object, e As System.EventArgs) Handles BoosterTimer.Tick

        BoosterTick -= 1
        Dim ColorVal As Integer



        If BoosterTick = 5 Then

            TempVal = randomizer.Next(1, 101)

            If TempVal > 20 Then
                Booster1Frame.BackColor = Color.Peru
                Booster1Plate.BackColor = Color.Peru
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(0))
                    Booster1Name.Text = FrmSettings.BN1.Text
                    My.Settings.B1 += 1
                End If
                If ColorVal = 2 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(1))
                    Booster1Name.Text = FrmSettings.BN2.Text
                    My.Settings.B2 += 1
                End If
                If ColorVal = 3 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(2))
                    Booster1Name.Text = FrmSettings.BN3.Text
                    My.Settings.B3 += 1
                End If
                If ColorVal = 4 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(3))
                    Booster1Name.Text = FrmSettings.BN4.Text
                    My.Settings.B4 += 1
                End If
                If ColorVal = 5 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(4))
                    Booster1Name.Text = FrmSettings.BN5.Text
                    My.Settings.B5 += 1
                End If
                If ColorVal = 6 Then
                    Booster1.Image = Image.FromFile(BoosterListBronze(5))
                    Booster1Name.Text = FrmSettings.BN6.Text
                    My.Settings.B6 += 1
                End If
            End If

            If TempVal > 5 And TempVal < 21 Then
                Booster1Frame.BackColor = Color.Silver
                Booster1Plate.BackColor = Color.Silver
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(0))
                    Booster1Name.Text = FrmSettings.SN1.Text
                    My.Settings.S1 += 1
                End If
                If ColorVal = 2 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(1))
                    Booster1Name.Text = FrmSettings.SN2.Text
                    My.Settings.S2 += 1
                End If
                If ColorVal = 3 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(2))
                    Booster1Name.Text = FrmSettings.SN3.Text
                    My.Settings.S3 += 1
                End If
                If ColorVal = 4 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(3))
                    Booster1Name.Text = FrmSettings.SN4.Text
                    My.Settings.S4 += 1
                End If
                If ColorVal = 5 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(4))
                    Booster1Name.Text = FrmSettings.SN5.Text
                    My.Settings.S5 += 1
                End If
                If ColorVal = 6 Then
                    Booster1.Image = Image.FromFile(BoosterListSilver(5))
                    Booster1Name.Text = FrmSettings.SN6.Text
                    My.Settings.S6 += 1
                End If
            End If

            If TempVal < 6 Then
                Booster1Frame.BackColor = Color.Gold
                Booster1Plate.BackColor = Color.Gold
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(0))
                    Booster1Name.Text = FrmSettings.GN1.Text
                    My.Settings.G1 += 1
                End If
                If ColorVal = 2 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(1))
                    Booster1Name.Text = FrmSettings.GN2.Text
                    My.Settings.G2 += 1
                End If
                If ColorVal = 3 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(2))
                    Booster1Name.Text = FrmSettings.GN3.Text
                    My.Settings.G3 += 1
                End If
                If ColorVal = 4 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(3))
                    Booster1Name.Text = FrmSettings.GN4.Text
                    My.Settings.G4 += 1
                End If
                If ColorVal = 5 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(4))
                    Booster1Name.Text = FrmSettings.GN5.Text
                    My.Settings.G5 += 1
                End If
                If ColorVal = 6 Then
                    Booster1.Image = Image.FromFile(BoosterListGold(5))
                    Booster1Name.Text = FrmSettings.GN6.Text
                    My.Settings.G6 += 1
                End If
            End If
            Booster1.Visible = True
        End If


        If BoosterTick = 4 Then

            TempVal = randomizer.Next(1, 101)

            If TempVal > 20 Then
                Booster2Frame.BackColor = Color.Peru
                Booster2Plate.BackColor = Color.Peru
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(0))
                    Booster2Name.Text = FrmSettings.BN1.Text
                    My.Settings.B1 += 1
                End If
                If ColorVal = 2 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(1))
                    Booster2Name.Text = FrmSettings.BN2.Text
                    My.Settings.B2 += 1
                End If
                If ColorVal = 3 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(2))
                    Booster2Name.Text = FrmSettings.BN3.Text
                    My.Settings.B3 += 1
                End If
                If ColorVal = 4 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(3))
                    Booster2Name.Text = FrmSettings.BN4.Text
                    My.Settings.B4 += 1
                End If
                If ColorVal = 5 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(4))
                    Booster2Name.Text = FrmSettings.BN5.Text
                    My.Settings.B5 += 1
                End If
                If ColorVal = 6 Then
                    Booster2.Image = Image.FromFile(BoosterListBronze(5))
                    Booster2Name.Text = FrmSettings.BN6.Text
                    My.Settings.B6 += 1
                End If
            End If

            If TempVal > 5 And TempVal < 21 Then
                Booster2Frame.BackColor = Color.Silver
                Booster2Plate.BackColor = Color.Silver
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(0))
                    Booster2Name.Text = FrmSettings.SN1.Text
                    My.Settings.S1 += 1
                End If
                If ColorVal = 2 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(1))
                    Booster2Name.Text = FrmSettings.SN2.Text
                    My.Settings.S2 += 1
                End If
                If ColorVal = 3 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(2))
                    Booster2Name.Text = FrmSettings.SN3.Text
                    My.Settings.S3 += 1
                End If
                If ColorVal = 4 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(3))
                    Booster2Name.Text = FrmSettings.SN4.Text
                    My.Settings.S4 += 1
                End If
                If ColorVal = 5 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(4))
                    Booster2Name.Text = FrmSettings.SN5.Text
                    My.Settings.S5 += 1
                End If
                If ColorVal = 6 Then
                    Booster2.Image = Image.FromFile(BoosterListSilver(5))
                    Booster2Name.Text = FrmSettings.SN6.Text
                    My.Settings.S6 += 1
                End If
            End If

            If TempVal < 6 Then
                Booster2Frame.BackColor = Color.Gold
                Booster2Plate.BackColor = Color.Gold
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(0))
                    Booster2Name.Text = FrmSettings.GN1.Text
                    My.Settings.G1 += 1
                End If
                If ColorVal = 2 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(1))
                    Booster2Name.Text = FrmSettings.GN2.Text
                    My.Settings.G2 += 1
                End If
                If ColorVal = 3 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(2))
                    Booster2Name.Text = FrmSettings.GN3.Text
                    My.Settings.G3 += 1
                End If
                If ColorVal = 4 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(3))
                    Booster2Name.Text = FrmSettings.GN4.Text
                    My.Settings.G4 += 1
                End If
                If ColorVal = 5 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(4))
                    Booster2Name.Text = FrmSettings.GN5.Text
                    My.Settings.G5 += 1
                End If
                If ColorVal = 6 Then
                    Booster2.Image = Image.FromFile(BoosterListGold(5))
                    Booster2Name.Text = FrmSettings.GN6.Text
                    My.Settings.G6 += 1
                End If
            End If
            Booster2.Visible = True
        End If

        If BoosterTick = 3 Then

            TempVal = randomizer.Next(1, 101)

            If TempVal > 20 Then
                Booster3Frame.BackColor = Color.Peru
                Booster3Plate.BackColor = Color.Peru
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(0))
                    Booster3Name.Text = FrmSettings.BN1.Text
                    My.Settings.B1 += 1
                End If
                If ColorVal = 2 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(1))
                    Booster3Name.Text = FrmSettings.BN2.Text
                    My.Settings.B2 += 1
                End If
                If ColorVal = 3 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(2))
                    Booster3Name.Text = FrmSettings.BN3.Text
                    My.Settings.B3 += 1
                End If
                If ColorVal = 4 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(3))
                    Booster3Name.Text = FrmSettings.BN4.Text
                    My.Settings.B4 += 1
                End If
                If ColorVal = 5 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(4))
                    Booster3Name.Text = FrmSettings.BN5.Text
                    My.Settings.B5 += 1
                End If
                If ColorVal = 6 Then
                    Booster3.Image = Image.FromFile(BoosterListBronze(5))
                    Booster3Name.Text = FrmSettings.BN6.Text
                    My.Settings.B6 += 1
                End If
            End If

            If TempVal > 5 And TempVal < 21 Then
                Booster3Frame.BackColor = Color.Silver
                Booster3Plate.BackColor = Color.Silver
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(0))
                    Booster3Name.Text = FrmSettings.SN1.Text
                    My.Settings.S1 += 1
                End If
                If ColorVal = 2 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(1))
                    Booster3Name.Text = FrmSettings.SN2.Text
                    My.Settings.S2 += 1
                End If
                If ColorVal = 3 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(2))
                    Booster3Name.Text = FrmSettings.SN3.Text
                    My.Settings.S3 += 1
                End If
                If ColorVal = 4 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(3))
                    Booster3Name.Text = FrmSettings.SN4.Text
                    My.Settings.S4 += 1
                End If
                If ColorVal = 5 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(4))
                    Booster3Name.Text = FrmSettings.SN5.Text
                    My.Settings.S5 += 1
                End If
                If ColorVal = 6 Then
                    Booster3.Image = Image.FromFile(BoosterListSilver(5))
                    Booster3Name.Text = FrmSettings.SN6.Text
                    My.Settings.S6 += 1
                End If
            End If

            If TempVal < 6 Then
                Booster3Frame.BackColor = Color.Gold
                Booster3Plate.BackColor = Color.Gold
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(0))
                    Booster3Name.Text = FrmSettings.GN1.Text
                    My.Settings.G1 += 1
                End If
                If ColorVal = 2 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(1))
                    Booster3Name.Text = FrmSettings.GN2.Text
                    My.Settings.G2 += 1
                End If
                If ColorVal = 3 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(2))
                    Booster3Name.Text = FrmSettings.GN3.Text
                    My.Settings.G3 += 1
                End If
                If ColorVal = 4 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(3))
                    Booster3Name.Text = FrmSettings.GN4.Text
                    My.Settings.G4 += 1
                End If
                If ColorVal = 5 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(4))
                    Booster3Name.Text = FrmSettings.GN5.Text
                    My.Settings.G5 += 1
                End If
                If ColorVal = 6 Then
                    Booster3.Image = Image.FromFile(BoosterListGold(5))
                    Booster3Name.Text = FrmSettings.GN6.Text
                    My.Settings.G6 += 1
                End If
            End If
            Booster3.Visible = True
        End If

        If BoosterTick = 2 Then

            TempVal = randomizer.Next(1, 101)

            If TempVal > 20 Then
                Booster4Frame.BackColor = Color.Peru
                Booster4Plate.BackColor = Color.Peru
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(0))
                    Booster4Name.Text = FrmSettings.BN1.Text
                    My.Settings.B1 += 1
                End If
                If ColorVal = 2 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(1))
                    Booster4Name.Text = FrmSettings.BN2.Text
                    My.Settings.B2 += 1
                End If
                If ColorVal = 3 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(2))
                    Booster4Name.Text = FrmSettings.BN3.Text
                    My.Settings.B3 += 1
                End If
                If ColorVal = 4 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(3))
                    Booster4Name.Text = FrmSettings.BN4.Text
                    My.Settings.B4 += 1
                End If
                If ColorVal = 5 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(4))
                    Booster4Name.Text = FrmSettings.BN5.Text
                    My.Settings.B5 += 1
                End If
                If ColorVal = 6 Then
                    Booster4.Image = Image.FromFile(BoosterListBronze(5))
                    Booster4Name.Text = FrmSettings.BN6.Text
                    My.Settings.B6 += 1
                End If
            End If

            If TempVal > 5 And TempVal < 21 Then
                Booster4Frame.BackColor = Color.Silver
                Booster4Plate.BackColor = Color.Silver
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(0))
                    Booster4Name.Text = FrmSettings.SN1.Text
                    My.Settings.S1 += 1
                End If
                If ColorVal = 2 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(1))
                    Booster4Name.Text = FrmSettings.SN2.Text
                    My.Settings.S2 += 1
                End If
                If ColorVal = 3 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(2))
                    Booster4Name.Text = FrmSettings.SN3.Text
                    My.Settings.S3 += 1
                End If
                If ColorVal = 4 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(3))
                    Booster4Name.Text = FrmSettings.SN4.Text
                    My.Settings.S4 += 1
                End If
                If ColorVal = 5 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(4))
                    Booster4Name.Text = FrmSettings.SN5.Text
                    My.Settings.S5 += 1
                End If
                If ColorVal = 6 Then
                    Booster4.Image = Image.FromFile(BoosterListSilver(5))
                    Booster4Name.Text = FrmSettings.SN6.Text
                    My.Settings.S6 += 1
                End If
            End If

            If TempVal < 6 Then
                Booster4Frame.BackColor = Color.Gold
                Booster4Plate.BackColor = Color.Gold
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(0))
                    Booster4Name.Text = FrmSettings.GN1.Text
                    My.Settings.G1 += 1
                End If
                If ColorVal = 2 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(1))
                    Booster4Name.Text = FrmSettings.GN2.Text
                    My.Settings.G2 += 1
                End If
                If ColorVal = 3 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(2))
                    Booster4Name.Text = FrmSettings.GN3.Text
                    My.Settings.G3 += 1
                End If
                If ColorVal = 4 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(3))
                    Booster4Name.Text = FrmSettings.GN4.Text
                    My.Settings.G4 += 1
                End If
                If ColorVal = 5 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(4))
                    Booster4Name.Text = FrmSettings.GN5.Text
                    My.Settings.G5 += 1
                End If
                If ColorVal = 6 Then
                    Booster4.Image = Image.FromFile(BoosterListGold(5))
                    Booster4Name.Text = FrmSettings.GN6.Text
                    My.Settings.G6 += 1
                End If
            End If
            Booster4.Visible = True
        End If

        If BoosterTick = 1 Then

            TempVal = randomizer.Next(1, 101)

            If TempVal > 20 Then
                Booster5Frame.BackColor = Color.Peru
                Booster5Plate.BackColor = Color.Peru
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(0))
                    Booster5Name.Text = FrmSettings.BN1.Text
                    My.Settings.B1 += 1
                End If
                If ColorVal = 2 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(1))
                    Booster5Name.Text = FrmSettings.BN2.Text
                    My.Settings.B2 += 1
                End If
                If ColorVal = 3 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(2))
                    Booster5Name.Text = FrmSettings.BN3.Text
                    My.Settings.B3 += 1
                End If
                If ColorVal = 4 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(3))
                    Booster5Name.Text = FrmSettings.BN4.Text
                    My.Settings.B4 += 1
                End If
                If ColorVal = 5 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(4))
                    Booster5Name.Text = FrmSettings.BN5.Text
                    My.Settings.B5 += 1
                End If
                If ColorVal = 6 Then
                    Booster5.Image = Image.FromFile(BoosterListBronze(5))
                    Booster5Name.Text = FrmSettings.BN6.Text
                    My.Settings.B6 += 1
                End If
            End If

            If TempVal > 5 And TempVal < 21 Then
                Booster5Frame.BackColor = Color.Silver
                Booster5Plate.BackColor = Color.Silver
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(0))
                    Booster5Name.Text = FrmSettings.SN1.Text
                    My.Settings.S1 += 1
                End If
                If ColorVal = 2 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(1))
                    Booster5Name.Text = FrmSettings.SN2.Text
                    My.Settings.S2 += 1
                End If
                If ColorVal = 3 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(2))
                    Booster5Name.Text = FrmSettings.SN3.Text
                    My.Settings.S3 += 1
                End If
                If ColorVal = 4 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(3))
                    Booster5Name.Text = FrmSettings.SN4.Text
                    My.Settings.S4 += 1
                End If
                If ColorVal = 5 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(4))
                    Booster5Name.Text = FrmSettings.SN5.Text
                    My.Settings.S5 += 1
                End If
                If ColorVal = 6 Then
                    Booster5.Image = Image.FromFile(BoosterListSilver(5))
                    Booster5Name.Text = FrmSettings.SN6.Text
                    My.Settings.S6 += 1
                End If
            End If

            If TempVal < 6 Then
                Booster5Frame.BackColor = Color.Gold
                Booster5Plate.BackColor = Color.Gold
                ColorVal = randomizer.Next(1, 7)
                If ColorVal = 1 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(0))
                    Booster5Name.Text = FrmSettings.GN1.Text
                    My.Settings.G1 += 1
                End If
                If ColorVal = 2 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(1))
                    Booster5Name.Text = FrmSettings.GN2.Text
                    My.Settings.G2 += 1
                End If
                If ColorVal = 3 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(2))
                    Booster5Name.Text = FrmSettings.GN3.Text
                    My.Settings.G3 += 1
                End If
                If ColorVal = 4 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(3))
                    Booster5Name.Text = FrmSettings.GN4.Text
                    My.Settings.G4 += 1
                End If
                If ColorVal = 5 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(4))
                    Booster5Name.Text = FrmSettings.GN5.Text
                    My.Settings.G5 += 1
                End If
                If ColorVal = 6 Then
                    Booster5.Image = Image.FromFile(BoosterListGold(5))
                    Booster5Name.Text = FrmSettings.GN6.Text
                    My.Settings.G6 += 1
                End If
            End If
            Booster5.Visible = True
        End If





        My.Settings.Save()
        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\CardFlip.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\CardFlip.wav"
        End If
        'My.Computer.Audio.Play(Application.StartupPath & "\Audio\System\CardFlip.wav")

        If BoosterTick = 1 Then
            BoosterTimer.Stop()
            CheckExchange()
        End If


    End Sub

    Public Sub UpdateBronzeTokens()

        LBLSlotTokens.Text = Form1.BronzeTokens
        LBLMatchTokens.Text = Form1.BronzeTokens
        LBLExchangeBronze.Text = Form1.BronzeTokens

    End Sub




    Public Sub CheckExchange()

        If My.Settings.B1 > 0 And My.Settings.B2 > 0 And My.Settings.B3 > 0 And My.Settings.B4 > 0 And My.Settings.B5 > 0 And My.Settings.B6 > 0 Then
            BTNExchange1.Enabled = True
            BTNExchange2.Enabled = True
        Else
            BTNExchange1.Enabled = False
            BTNExchange2.Enabled = False
        End If

        If My.Settings.S1 > 0 And My.Settings.S2 > 0 And My.Settings.S3 > 0 And My.Settings.S4 > 0 And My.Settings.S5 > 0 And My.Settings.S6 > 0 Then
            BTNExchange3.Enabled = True
            BTNExchange4.Enabled = True
        Else
            BTNExchange3.Enabled = False
            BTNExchange4.Enabled = False
        End If

        If My.Settings.G1 > 0 And My.Settings.G2 > 0 And My.Settings.G3 > 0 And My.Settings.G4 > 0 And My.Settings.G5 > 0 And My.Settings.G6 > 0 Then
            BTNExchange5.Enabled = True
        Else
            BTNExchange5.Enabled = False
        End If

        If Form1.SilverTokens > 0 Then
            BTNExchange6.Enabled = True
        Else
            BTNExchange6.Enabled = False
        End If

        If Form1.BronzeTokens > 24 And BoosterTimer.Enabled = False Then
            BTNBoosterBuy.Enabled = True
        Else
            BTNBoosterBuy.Enabled = False
        End If

    End Sub

    Public Sub ClearExchange()

        ExchangeCard.Visible = False
        ExchangeFrame.BackColor = Color.DimGray
        ExchangePlate.BackColor = Color.DimGray
        LBLExchange.Text = ""
        ExchangeName.Text = ""


    End Sub

    Private Sub BTNExchange1_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange1.Click


        My.Settings.B1 -= 1
        My.Settings.B2 -= 1
        My.Settings.B3 -= 1
        My.Settings.B4 -= 1
        My.Settings.B5 -= 1
        My.Settings.B6 -= 1

        Dim SilverDraw As New List(Of String)
        SilverDraw.Clear()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\CardFlip.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\CardFlip.wav"
        End If

        ExchangeCard.Visible = True
        ExchangeFrame.BackColor = Color.Silver
        ExchangePlate.BackColor = Color.Silver
        LBLExchange.Text = "You've received a Silver card!"

        SilverDraw.Add(My.Settings.SP1)
        SilverDraw.Add(My.Settings.SP2)
        SilverDraw.Add(My.Settings.SP3)
        SilverDraw.Add(My.Settings.SP4)
        SilverDraw.Add(My.Settings.SP5)
        SilverDraw.Add(My.Settings.SP6)

        TempVal = randomizer.Next(1, 7)

        If TempVal = 1 Then
            My.Settings.S1 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(0))
            ExchangeName.Text = FrmSettings.SN1.Text
        End If

        If TempVal = 2 Then
            My.Settings.S2 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(1))
            ExchangeName.Text = FrmSettings.SN2.Text
        End If

        If TempVal = 3 Then
            My.Settings.S3 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(2))
            ExchangeName.Text = FrmSettings.SN3.Text
        End If

        If TempVal = 4 Then
            My.Settings.S4 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(3))
            ExchangeName.Text = FrmSettings.SN4.Text
        End If

        If TempVal = 5 Then
            My.Settings.S5 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(4))
            ExchangeName.Text = FrmSettings.SN5.Text
        End If

        If TempVal = 6 Then
            My.Settings.S6 += 1
            ExchangeCard.Image = Image.FromFile(SilverDraw(5))
            ExchangeName.Text = FrmSettings.SN6.Text
        End If

        My.Settings.Save()

        CheckExchange()


    End Sub

    Private Sub BTNExchange2_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange2.Click


        My.Settings.B1 -= 1
        My.Settings.B2 -= 1
        My.Settings.B3 -= 1
        My.Settings.B4 -= 1
        My.Settings.B5 -= 1
        My.Settings.B6 -= 1

        ClearExchange()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutSmall.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutSmall.wav"
        End If

        Form1.BronzeTokens += 12
        My.Settings.BronzeTokens = Form1.BronzeTokens
        LBLExchangeBronze.Text = Form1.BronzeTokens



        My.Settings.Save()

        CheckExchange()


    End Sub

    Private Sub BTNExchange3_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange3.Click

        My.Settings.S1 -= 1
        My.Settings.S2 -= 1
        My.Settings.S3 -= 1
        My.Settings.S4 -= 1
        My.Settings.S5 -= 1
        My.Settings.S6 -= 1

        Dim GoldDraw As New List(Of String)
        GoldDraw.Clear()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\CardFlip.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\CardFlip.wav"
        End If

        ExchangeCard.Visible = True
        ExchangeFrame.BackColor = Color.Gold
        ExchangePlate.BackColor = Color.Gold
        LBLExchange.Text = "You've received a Gold card!"

        GoldDraw.Add(My.Settings.GP1)
        GoldDraw.Add(My.Settings.GP2)
        GoldDraw.Add(My.Settings.GP3)
        GoldDraw.Add(My.Settings.GP4)
        GoldDraw.Add(My.Settings.GP5)
        GoldDraw.Add(My.Settings.GP6)

        TempVal = randomizer.Next(1, 7)

        If TempVal = 1 Then
            My.Settings.G1 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(0))
            ExchangeName.Text = FrmSettings.GN1.Text
        End If

        If TempVal = 2 Then
            My.Settings.G2 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(1))
            ExchangeName.Text = FrmSettings.GN2.Text
        End If

        If TempVal = 3 Then
            My.Settings.G3 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(2))
            ExchangeName.Text = FrmSettings.GN3.Text
        End If

        If TempVal = 4 Then
            My.Settings.G4 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(3))
            ExchangeName.Text = FrmSettings.GN4.Text
        End If

        If TempVal = 5 Then
            My.Settings.G5 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(4))
            ExchangeName.Text = FrmSettings.GN5.Text
        End If

        If TempVal = 6 Then
            My.Settings.G6 += 1
            ExchangeCard.Image = Image.FromFile(GoldDraw(5))
            ExchangeName.Text = FrmSettings.GN6.Text
        End If

        My.Settings.Save()

        CheckExchange()



    End Sub

    Private Sub BTNExchange4_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange4.Click

        My.Settings.S1 -= 1
        My.Settings.S2 -= 1
        My.Settings.S3 -= 1
        My.Settings.S4 -= 1
        My.Settings.S5 -= 1
        My.Settings.S6 -= 1

        ClearExchange()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutOne.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutOne.wav"
        End If

        Form1.SilverTokens += 1
        My.Settings.SilverTokens = Form1.SilverTokens
        LBLExchangeSilver.Text = Form1.SilverTokens



        My.Settings.Save()

        CheckExchange()


    End Sub

    Private Sub BTNExchange5_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange5.Click

        My.Settings.G1 -= 1
        My.Settings.G2 -= 1
        My.Settings.G3 -= 1
        My.Settings.G4 -= 1
        My.Settings.G5 -= 1
        My.Settings.G6 -= 1

        ClearExchange()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutOne.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutOne.wav"
        End If

        Form1.GoldTokens += 1
        My.Settings.GoldTokens = Form1.GoldTokens
        LBLExchangeGold.Text = Form1.GoldTokens



        My.Settings.Save()

        CheckExchange()

    End Sub

    Private Sub BTNExchange6_Click(sender As System.Object, e As System.EventArgs) Handles BTNExchange6.Click

        ClearExchange()

        If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutSmall.wav") Then
            GameWMP.settings.setMode("loop", False)
            GameWMP.settings.volume = 20
            GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutSmall.wav"
        End If

        Form1.SilverTokens -= 1
        Form1.BronzeTokens += 50
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.BronzeTokens = Form1.BronzeTokens

        LBLExchangeBronze.Text = Form1.BronzeTokens
        LBLExchangeSilver.Text = Form1.SilverTokens

        My.Settings.Save()

        CheckExchange()

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNTokenRequest.Click



        Dim TokenList As New List(Of String)
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\Token Tasks\", FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
            TokenList.Add(foundFile)
        Next
        If TokenList.Count > 0 Then

            Form1.SaidHello = True
            Form1.ShowModule = True
            Form1.FileText = TokenList(randomizer.Next(0, TokenList.Count))
            Form1.StrokeTauntVal = -1
            Form1.ScriptTick = 2
            Form1.ScriptTimer.Start()

            My.Settings.TokenTasks = FormatDateTime(Now, DateFormat.ShortDate)
            My.Settings.Save()
            BTNTokenRequest.Enabled = False
        Else
            MessageBox.Show(Me, "No tasks found in Token Tasks folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If


    End Sub




    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs)

        Form1.BronzeTokens += 50
        My.Settings.BronzeTokens = Form1.BronzeTokens

        My.Settings.Save()

        LBLExchangeBronze.Text = Form1.BronzeTokens
        BTNBoosterBuy.Enabled = True

    End Sub

    Private Sub CardRevealTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CardRevealTimer.Tick

        RevealTick -= 1

        If RevealTick < 1 Then
            CardRevealTimer.Stop()
            RevealCards = True
        End If

    End Sub

    Public Function CardImage(ByVal ProtoImage As String) As Image

        Dim original As Image


        If ProtoImage.Contains("\") Then
            original = Image.FromFile(ProtoImage)
        Else
            original = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(ProtoImage)))
        End If

        Dim resized As Image = Form1.ResizeImage(original, New Size(M1A.Width, M1A.Height))
        original.Dispose()

        Return resized

    End Function

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs)

        InitializeRiskyDeal()

    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs)

        Risk1.Text = RiskyShuffled(0)
        Risk2.Text = RiskyShuffled(1)
        Risk3.Text = RiskyShuffled(2)
        Risk4.Text = RiskyShuffled(3)
        Risk5.Text = RiskyShuffled(4)
        Risk6.Text = RiskyShuffled(5)

        Risk7.Text = RiskyShuffled(6)
        Risk8.Text = RiskyShuffled(7)
        Risk9.Text = RiskyShuffled(8)
        Risk10.Text = RiskyShuffled(9)
        Risk11.Text = RiskyShuffled(10)
        Risk12.Text = RiskyShuffled(11)

        Risk13.Text = RiskyShuffled(12)
        Risk14.Text = RiskyShuffled(13)
        Risk15.Text = RiskyShuffled(14)
        Risk16.Text = RiskyShuffled(15)
        Risk17.Text = RiskyShuffled(16)
        Risk18.Text = RiskyShuffled(17)

        Risk19.Text = RiskyShuffled(18)
        Risk20.Text = RiskyShuffled(19)
        Risk21.Text = RiskyShuffled(20)
        Risk22.Text = RiskyShuffled(21)
        Risk23.Text = RiskyShuffled(22)
        Risk24.Text = RiskyShuffled(23)


    End Sub


    Public Sub InitializeRiskyDeal()


        RiskyDeck.Clear()
        RiskyDeck.Add("2 Edges")
        RiskyDeck.Add("4 Edges")
        RiskyDeck.Add("7 Edges")
        RiskyDeck.Add("12 Edges")
        RiskyDeck.Add("55 Edges")
        RiskyDeck.Add("65 Edges")

        RiskyDeck.Add("1 Edge")
        RiskyDeck.Add("3 Edges")
        RiskyDeck.Add("5 Edges")
        RiskyDeck.Add("10 Edges")
        RiskyDeck.Add("15 Edges")
        RiskyDeck.Add("20 Edges")

        RiskyDeck.Add("25 Edges")
        RiskyDeck.Add("30 Edges")
        RiskyDeck.Add("40 Edges")
        RiskyDeck.Add("50 Edges")
        RiskyDeck.Add("60 Edges")
        RiskyDeck.Add("70 Edges")

        RiskyDeck.Add("75 Edges")
        RiskyDeck.Add("80 Edges")
        RiskyDeck.Add("85 Edges")
        RiskyDeck.Add("90 Edges")
        RiskyDeck.Add("95 Edges")
        RiskyDeck.Add("100 Edges")

        LBLPick1.Text = ""
        LBLPick2.Text = ""
        LBLPick3.Text = ""
        LBLPick4.Text = ""
        LBLPick5.Text = ""
        LBLPick6.Text = ""

        RiskyShuffled.Clear()
        Dim RiskVal As Integer

        For i As Integer = RiskyDeck.Count - 1 To 0 Step -1
            RiskVal = randomizer.Next(0, RiskyDeck.Count)
            RiskyShuffled.Add(RiskyDeck(RiskVal))
            RiskyDeck.Remove(RiskyDeck(RiskVal))
        Next

        RiskyRound = -1
        RiskyChoiceCount = 0

    End Sub

    Private Sub BTNRisk1_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk1.Click

        If BTNRisk1.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 1
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(0)

        BTNRisk1.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk1.Text = RiskyShuffled(0)
        RiskyChoices.Add(RiskyShuffled(0))
        RiskyChoiceCount += 1

        RiskyInt = 1

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk2_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk2.Click

        If BTNRisk2.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 2
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(1)

        BTNRisk2.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk2.Text = RiskyShuffled(1)
        RiskyChoices.Add(RiskyShuffled(1))
        RiskyChoiceCount += 1

        RiskyInt = 2

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk3_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk3.Click

        If BTNRisk3.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 3
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(2)

        BTNRisk3.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk3.Text = RiskyShuffled(2)
        RiskyChoices.Add(RiskyShuffled(2))
        RiskyChoiceCount += 1

        RiskyInt = 3

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk4_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk4.Click

        If BTNRisk4.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 4
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(3)

        BTNRisk4.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk4.Text = RiskyShuffled(3)
        RiskyChoices.Add(RiskyShuffled(3))
        RiskyChoiceCount += 1

        RiskyInt = 4

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk5_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk5.Click

        If BTNRisk5.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 5
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(4)

        BTNRisk5.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk5.Text = RiskyShuffled(4)
        RiskyChoices.Add(RiskyShuffled(4))
        RiskyChoiceCount += 1

        RiskyInt = 5

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk6_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk6.Click

        If BTNRisk6.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 6
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(5)

        BTNRisk6.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk6.Text = RiskyShuffled(5)
        RiskyChoices.Add(RiskyShuffled(5))
        RiskyChoiceCount += 1

        RiskyInt = 6

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk7_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk7.Click

        If BTNRisk7.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 7
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(6)

        BTNRisk7.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk7.Text = RiskyShuffled(6)
        RiskyChoices.Add(RiskyShuffled(6))
        RiskyChoiceCount += 1

        RiskyInt = 7

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk8_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk8.Click

        If BTNRisk8.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 8
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(7)

        BTNRisk8.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk8.Text = RiskyShuffled(7)
        RiskyChoices.Add(RiskyShuffled(7))
        RiskyChoiceCount += 1

        RiskyInt = 8

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk9_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk9.Click

        If BTNRisk9.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 9
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(8)

        BTNRisk9.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk9.Text = RiskyShuffled(8)
        RiskyChoices.Add(RiskyShuffled(8))
        RiskyChoiceCount += 1

        RiskyInt = 9

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk10_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk10.Click

        If BTNRisk10.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 10
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(9)

        BTNRisk10.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk10.Text = RiskyShuffled(9)
        RiskyChoices.Add(RiskyShuffled(9))
        RiskyChoiceCount += 1

        RiskyInt = 10

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk11_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk11.Click

        Debug.Print("RiskyRound = " & RiskyRound)

        If BTNRisk11.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 11
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(10)

        BTNRisk11.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk11.Text = RiskyShuffled(10)
        RiskyChoices.Add(RiskyShuffled(10))
        RiskyChoiceCount += 1

        RiskyInt = 11

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk12_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk12.Click

        If BTNRisk12.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 12
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(11)

        BTNRisk12.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk12.Text = RiskyShuffled(11)
        RiskyChoices.Add(RiskyShuffled(11))
        RiskyChoiceCount += 1

        RiskyInt = 12

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk13_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk13.Click

        If BTNRisk13.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 13
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(12)

        BTNRisk13.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk13.Text = RiskyShuffled(12)
        RiskyChoices.Add(RiskyShuffled(12))
        RiskyChoiceCount += 1

        RiskyInt = 13

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk14_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk14.Click

        If BTNRisk14.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 14
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(13)

        BTNRisk14.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk14.Text = RiskyShuffled(13)
        RiskyChoices.Add(RiskyShuffled(13))
        RiskyChoiceCount += 1

        RiskyInt = 14

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk15_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk15.Click

        If BTNRisk15.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 15
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(14)

        BTNRisk15.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk15.Text = RiskyShuffled(14)
        RiskyChoices.Add(RiskyShuffled(14))
        RiskyChoiceCount += 1

        RiskyInt = 15

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk16_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk16.Click

        If BTNRisk16.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 16
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(15)

        BTNRisk16.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk16.Text = RiskyShuffled(15)
        RiskyChoices.Add(RiskyShuffled(15))
        RiskyChoiceCount += 1

        RiskyInt = 16

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk17_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk17.Click

        If BTNRisk17.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 17
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(16)

        BTNRisk17.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk17.Text = RiskyShuffled(16)
        RiskyChoices.Add(RiskyShuffled(16))
        RiskyChoiceCount += 1

        RiskyInt = 17

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk18_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk18.Click

        If BTNRisk18.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 18
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(17)

        BTNRisk18.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk18.Text = RiskyShuffled(17)
        RiskyChoices.Add(RiskyShuffled(17))
        RiskyChoiceCount += 1

        RiskyInt = 18

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk19_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk19.Click

        If BTNRisk19.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 19
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(18)

        BTNRisk19.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk19.Text = RiskyShuffled(18)
        RiskyChoices.Add(RiskyShuffled(18))
        RiskyChoiceCount += 1

        RiskyInt = 19

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk20_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk20.Click

        If BTNRisk20.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 20
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(19)

        BTNRisk20.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk20.Text = RiskyShuffled(19)
        RiskyChoices.Add(RiskyShuffled(19))
        RiskyChoiceCount += 1

        RiskyInt = 20

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk21_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk21.Click

        If BTNRisk21.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 21
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(20)

        BTNRisk21.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk21.Text = RiskyShuffled(20)
        RiskyChoices.Add(RiskyShuffled(20))
        RiskyChoiceCount += 1

        RiskyInt = 21

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk22_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk22.Click

        If BTNRisk22.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 22
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(21)

        BTNRisk22.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk22.Text = RiskyShuffled(21)
        RiskyChoices.Add(RiskyShuffled(21))
        RiskyChoiceCount += 1

        RiskyInt = 22

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk23_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk23.Click

        If BTNRisk23.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 23
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(22)

        BTNRisk23.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk23.Text = RiskyShuffled(22)
        RiskyChoices.Add(RiskyShuffled(22))
        RiskyChoiceCount += 1

        RiskyInt = 23

        CheckRiskyCount()

    End Sub

    Private Sub BTNRisk24_Click(sender As System.Object, e As System.EventArgs) Handles BTNRisk24.Click

        If BTNRisk24.BackColor = Color.Khaki Then Return

        If RiskyRound = 0 Then RiskyPickNumber = 24
        If RiskyRound = 0 Then RiskyCase = RiskyShuffled(23)

        BTNRisk24.BackColor = Color.Khaki
        If RiskyRound > 0 Then Risk24.Text = RiskyShuffled(23)
        RiskyChoices.Add(RiskyShuffled(23))
        RiskyChoiceCount += 1

        RiskyInt = 24

        CheckRiskyCount()

    End Sub





    Public Sub CheckRiskyCount()

        PlayCardFlip()

        If RiskyRound > 0 Then
            If RiskyChoiceCount = 1 Then LBLPick1.Text = RiskyInt
            If RiskyChoiceCount = 2 Then LBLPick2.Text = RiskyInt
            If RiskyChoiceCount = 3 Then LBLPick3.Text = RiskyInt
            If RiskyChoiceCount = 4 Then LBLPick4.Text = RiskyInt
            If RiskyChoiceCount = 5 Then LBLPick5.Text = RiskyInt
            If RiskyChoiceCount = 6 Then LBLPick6.Text = RiskyInt
        End If

        Debug.Print("Risky Round = " & RiskyRound)
        If RiskyRound = 0 Then
            DisableCases()
            RiskyPick = RiskyChoices(0)
            Form1.RiskyDelay = False
        End If

        If RiskyRound = 1 Or RiskyRound = 2 Then
            If RiskyChoiceCount = 6 Then
                DisableCases()
                Form1.RiskyDelay = False
            End If
        End If

        If RiskyRound = 3 Or RiskyRound = 4 Then
            If RiskyChoiceCount = 3 Then
                DisableCases()
                Form1.RiskyDelay = False
            End If
        End If

        If RiskyRound = 5 Or RiskyRound = 6 Then
            If RiskyChoiceCount = 2 Then
                DisableCases()
                Form1.RiskyDelay = False
            End If
        End If

    End Sub

    Public Sub DisableCases()


        BTNRisk1.Enabled = False
        BTNRisk2.Enabled = False
        BTNRisk3.Enabled = False
        BTNRisk4.Enabled = False
        BTNRisk5.Enabled = False
        BTNRisk6.Enabled = False
        BTNRisk7.Enabled = False
        BTNRisk8.Enabled = False
        BTNRisk9.Enabled = False
        BTNRisk10.Enabled = False
        BTNRisk11.Enabled = False
        BTNRisk12.Enabled = False
        BTNRisk13.Enabled = False
        BTNRisk14.Enabled = False
        BTNRisk15.Enabled = False
        BTNRisk16.Enabled = False
        BTNRisk17.Enabled = False
        BTNRisk18.Enabled = False
        BTNRisk19.Enabled = False
        BTNRisk20.Enabled = False
        BTNRisk21.Enabled = False
        BTNRisk22.Enabled = False
        BTNRisk23.Enabled = False
        BTNRisk24.Enabled = False



    End Sub

    Public Sub RevealUserCase()



        BTNRisk1.Text = ""
        BTNRisk2.Text = ""
        BTNRisk3.Text = ""
        BTNRisk4.Text = ""
        BTNRisk5.Text = ""
        BTNRisk6.Text = ""
        BTNRisk7.Text = ""
        BTNRisk8.Text = ""
        BTNRisk9.Text = ""
        BTNRisk10.Text = ""
        BTNRisk11.Text = ""
        BTNRisk12.Text = ""
        BTNRisk13.Text = ""
        BTNRisk14.Text = ""
        BTNRisk15.Text = ""
        BTNRisk16.Text = ""
        BTNRisk17.Text = ""
        BTNRisk18.Text = ""
        BTNRisk19.Text = ""
        BTNRisk20.Text = ""
        BTNRisk21.Text = ""
        BTNRisk22.Text = ""
        BTNRisk23.Text = ""
        BTNRisk24.Text = ""

        If BTNRiskyPlay.Text = "1" Then BTNRisk1.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "2" Then BTNRisk2.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "3" Then BTNRisk3.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "4" Then BTNRisk4.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "5" Then BTNRisk5.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "6" Then BTNRisk6.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "7" Then BTNRisk7.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "8" Then BTNRisk8.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "9" Then BTNRisk9.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "10" Then BTNRisk10.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "11" Then BTNRisk11.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "12" Then BTNRisk12.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "13" Then BTNRisk13.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "14" Then BTNRisk14.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "15" Then BTNRisk15.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "16" Then BTNRisk16.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "17" Then BTNRisk17.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "18" Then BTNRisk18.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "19" Then BTNRisk19.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "20" Then BTNRisk20.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "21" Then BTNRisk21.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "22" Then BTNRisk22.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "23" Then BTNRisk23.Text = BTNRiskyPlay.Text
        If BTNRiskyPlay.Text = "24" Then BTNRisk24.Text = BTNRiskyPlay.Text

        LBLPick1.ForeColor = Color.Black
        LBLPick2.ForeColor = Color.Black
        LBLPick3.ForeColor = Color.Black
        LBLPick4.ForeColor = Color.Black
        LBLPick5.ForeColor = Color.Black
        LBLPick6.ForeColor = Color.Black

        LBLPick1.Text = BTNRiskyPlay.Text
        LBLPick2.Text = BTNRiskyPlay.Text
        LBLPick3.Text = BTNRiskyPlay.Text
        LBLPick4.Text = BTNRiskyPlay.Text
        LBLPick5.Text = BTNRiskyPlay.Text
        LBLPick6.Text = BTNRiskyPlay.Text


        ClearCaseLabelsOffer()

        If BTNRisk1.Text <> "" Then
            Risk1.ForeColor = Color.Black
            Risk1.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If

        If BTNRisk2.Text <> "" Then
            Risk2.ForeColor = Color.Black
            Risk2.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk3.Text <> "" Then
            Risk3.ForeColor = Color.Black
            Risk3.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk4.Text <> "" Then
            Risk4.ForeColor = Color.Black
            Risk4.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk5.Text <> "" Then
            Risk5.ForeColor = Color.Black
            Risk5.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk6.Text <> "" Then
            Risk6.ForeColor = Color.Black
            Risk6.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk7.Text <> "" Then
            Risk7.ForeColor = Color.Black
            Risk7.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk8.Text <> "" Then
            Risk8.ForeColor = Color.Black
            Risk8.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk9.Text <> "" Then
            Risk9.ForeColor = Color.Black
            Risk9.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk10.Text <> "" Then
            Risk10.ForeColor = Color.Black
            Risk10.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk11.Text <> "" Then
            Risk11.ForeColor = Color.Black
            Risk11.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk12.Text <> "" Then
            Risk12.ForeColor = Color.Black
            Risk12.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk13.Text <> "" Then
            Risk13.ForeColor = Color.Black
            Risk13.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk14.Text <> "" Then
            Risk14.ForeColor = Color.Black
            Risk14.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk15.Text <> "" Then
            Risk15.ForeColor = Color.Black
            Risk15.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk16.Text <> "" Then
            Risk16.ForeColor = Color.Black
            Risk16.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk17.Text <> "" Then
            Risk17.ForeColor = Color.Black
            Risk17.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk18.Text <> "" Then
            Risk18.ForeColor = Color.Black
            Risk18.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk19.Text <> "" Then
            Risk19.ForeColor = Color.Black
            Risk19.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk20.Text <> "" Then
            Risk20.ForeColor = Color.Black
            Risk20.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk21.Text <> "" Then
            Risk21.ForeColor = Color.Black
            Risk21.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk22.Text <> "" Then
            Risk22.ForeColor = Color.Black
            Risk22.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk23.Text <> "" Then
            Risk23.ForeColor = Color.Black
            Risk23.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If
        If BTNRisk24.Text <> "" Then
            Risk24.ForeColor = Color.Black
            Risk24.Text = RiskyShuffled(RiskyPickNumber - 1)
        End If

        EdgesOwed = Val(RiskyShuffled(RiskyPickNumber - 1))
        TokensPaid = 1000 / EdgesOwed
        TokensPaid = Math.Ceiling(TokensPaid)



    End Sub

    Public Sub RevealLastCase()


        LBLPick1.ForeColor = Color.Black
        LBLPick2.ForeColor = Color.Black
        LBLPick3.ForeColor = Color.Black
        LBLPick4.ForeColor = Color.Black
        LBLPick5.ForeColor = Color.Black
        LBLPick6.ForeColor = Color.Black

        ClearCaseLabelsOffer()

        If BTNRisk1.Text <> "" Then
            Risk1.ForeColor = Color.Black
            Risk1.Text = RiskyShuffled(0)
            EdgesOwed = Val(RiskyShuffled(0))
        End If

        If BTNRisk2.Text <> "" Then
            Risk2.ForeColor = Color.Black
            Risk2.Text = RiskyShuffled(1)
            EdgesOwed = Val(RiskyShuffled(1))
        End If
        If BTNRisk3.Text <> "" Then
            Risk3.ForeColor = Color.Black
            Risk3.Text = RiskyShuffled(2)
            EdgesOwed = Val(RiskyShuffled(2))
        End If
        If BTNRisk4.Text <> "" Then
            Risk4.ForeColor = Color.Black
            Risk4.Text = RiskyShuffled(3)
            EdgesOwed = Val(RiskyShuffled(3))
        End If
        If BTNRisk5.Text <> "" Then
            Risk5.ForeColor = Color.Black
            Risk5.Text = RiskyShuffled(4)
            EdgesOwed = Val(RiskyShuffled(4))
        End If
        If BTNRisk6.Text <> "" Then
            Risk6.ForeColor = Color.Black
            Risk6.Text = RiskyShuffled(5)
            EdgesOwed = Val(RiskyShuffled(5))
        End If
        If BTNRisk7.Text <> "" Then
            Risk7.ForeColor = Color.Black
            Risk7.Text = RiskyShuffled(6)
            EdgesOwed = Val(RiskyShuffled(6))
        End If
        If BTNRisk8.Text <> "" Then
            Risk8.ForeColor = Color.Black
            Risk8.Text = RiskyShuffled(7)
            EdgesOwed = Val(RiskyShuffled(7))
        End If
        If BTNRisk9.Text <> "" Then
            Risk9.ForeColor = Color.Black
            Risk9.Text = RiskyShuffled(8)
            EdgesOwed = Val(RiskyShuffled(8))
        End If
        If BTNRisk10.Text <> "" Then
            Risk10.ForeColor = Color.Black
            Risk10.Text = RiskyShuffled(9)
            EdgesOwed = Val(RiskyShuffled(9))
        End If
        If BTNRisk11.Text <> "" Then
            Risk11.ForeColor = Color.Black
            Risk11.Text = RiskyShuffled(10)
            EdgesOwed = Val(RiskyShuffled(10))
        End If
        If BTNRisk12.Text <> "" Then
            Risk12.ForeColor = Color.Black
            Risk12.Text = RiskyShuffled(11)
            EdgesOwed = Val(RiskyShuffled(11))
        End If
        If BTNRisk13.Text <> "" Then
            Risk13.ForeColor = Color.Black
            Risk13.Text = RiskyShuffled(12)
            EdgesOwed = Val(RiskyShuffled(12))
        End If
        If BTNRisk14.Text <> "" Then
            Risk14.ForeColor = Color.Black
            Risk14.Text = RiskyShuffled(13)
            EdgesOwed = Val(Risk14.Text)
        End If
        If BTNRisk15.Text <> "" Then
            Risk15.ForeColor = Color.Black
            Risk15.Text = RiskyShuffled(14)
            EdgesOwed = Val(RiskyShuffled(14))
        End If
        If BTNRisk16.Text <> "" Then
            Risk16.ForeColor = Color.Black
            Risk16.Text = RiskyShuffled(15)
            EdgesOwed = Val(RiskyShuffled(15))
        End If
        If BTNRisk17.Text <> "" Then
            Risk17.ForeColor = Color.Black
            Risk17.Text = RiskyShuffled(16)
            EdgesOwed = Val(RiskyShuffled(16))
        End If
        If BTNRisk18.Text <> "" Then
            Risk18.ForeColor = Color.Black
            Risk18.Text = RiskyShuffled(17)
            EdgesOwed = Val(RiskyShuffled(17))
        End If
        If BTNRisk19.Text <> "" Then
            Risk19.ForeColor = Color.Black
            Risk19.Text = RiskyShuffled(18)
            EdgesOwed = Val(RiskyShuffled(18))
        End If
        If BTNRisk20.Text <> "" Then
            Risk20.ForeColor = Color.Black
            Risk20.Text = RiskyShuffled(19)
            EdgesOwed = Val(RiskyShuffled(19))
        End If
        If BTNRisk21.Text <> "" Then
            Risk21.ForeColor = Color.Black
            Risk21.Text = RiskyShuffled(20)
            EdgesOwed = Val(RiskyShuffled(20))
        End If
        If BTNRisk22.Text <> "" Then
            Risk22.ForeColor = Color.Black
            Risk22.Text = RiskyShuffled(21)
            EdgesOwed = Val(RiskyShuffled(21))
        End If
        If BTNRisk23.Text <> "" Then
            Risk23.ForeColor = Color.Black
            Risk23.Text = RiskyShuffled(22)
            EdgesOwed = Val(RiskyShuffled(22))
        End If
        If BTNRisk24.Text <> "" Then
            Risk24.ForeColor = Color.Black
            Risk24.Text = RiskyShuffled(23)
            EdgesOwed = Val(RiskyShuffled(23))
        End If

        Debug.Print("EDGES OWED = " & EdgesOwed)

        'If LBLRisk100.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 100 Then EdgesOwed = 100
        'If LBLRisk95.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 95 Then EdgesOwed = 95
        'If LBLRisk90.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 90 Then EdgesOwed = 90
        'If LBLRisk85.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 85 Then EdgesOwed = 85
        'If LBLRisk80.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 80 Then EdgesOwed = 80
        'If LBLRisk75.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 75 Then EdgesOwed = 75

        'If LBLRisk70.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 70 Then EdgesOwed = 70
        'If LBLRisk65.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 65 Then EdgesOwed = 65
        'If LBLRisk60.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 60 Then EdgesOwed = 60
        'If LBLRisk55.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 55 Then EdgesOwed = 55
        'If LBLRisk50.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 50 Then EdgesOwed = 50
        'If LBLRisk40.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 40 Then EdgesOwed = 40

        'If LBLRisk30.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 30 Then EdgesOwed = 30
        'If LBLRisk25.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 25 Then EdgesOwed = 25
        'If LBLRisk20.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 20 Then EdgesOwed = 20
        'If LBLRisk15.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 15 Then EdgesOwed = 15
        'If LBLRisk12.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 12 Then EdgesOwed = 12
        'If LBLRisk10.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 10 Then EdgesOwed = 10

        'If LBLRisk7.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 7 Then EdgesOwed = 7
        'If LBLRisk5.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 5 Then EdgesOwed = 5
        'If LBLRisk4.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 4 Then EdgesOwed = 4
        'If LBLRisk3.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 3 Then EdgesOwed = 3
        'If LBLRisk2.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 2 Then EdgesOwed = 2
        'If LBLRisk1.ForeColor = Color.White And Val(RiskyShuffled(RiskyPickNumber - 1)) <> 1 Then EdgesOwed = 1


        TokensPaid = 1000 / EdgesOwed
        TokensPaid = Math.Ceiling(TokensPaid)



    End Sub


    Private Sub Button1_Click_3(sender As System.Object, e As System.EventArgs) Handles BTNRiskyPlay.Click

        If Form1.SaidHello = True Then
            MessageBox.Show(Me, "Risky Pick cannot be started from the Games window when there is a session in progress!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        If Form1.RiskyDeal = True Then
            MessageBox.Show(Me, "A new Risky Pick game cannot be started until the current game is finished!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        If Form1.RiskyEdges = True Then
            MessageBox.Show(Me, "You still owe edges from your previous game!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        If Form1.BronzeTokens < 100 Then
            MessageBox.Show(Me, "It costs 100 Bronze Tokens to play Risky Pick!", "Not enough Tokens!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        If Not File.Exists(Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\Risky Pick\Risky Pick.txt") Then
            MessageBox.Show(Me, "Risky Pick.txt was not found in \Games\Risky Pick!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Form1.BronzeTokens -= 100
        My.Settings.BronzeTokens = Form1.BronzeTokens
        My.Settings.Save()

        RiskyState = True
        Form1.RiskyDeal = True

        BTNRiskyPlay.Text = ""
        BTNRiskyPlay.Enabled = False

        Form1.StrokeTauntVal = -1

        If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And Form1.SlideshowLoaded = False Then
            Form1.LoadDommeImageFolder()
        End If

        Form1.FileText = Application.StartupPath & "\Scripts\" & Form1.dompersonalitycombobox.Text & "\Apps\Games\Risky Pick\Risky Pick.txt"
        Form1.BeforeTease = False
        Form1.ShowModule = True
        Form1.SaidHello = True
        Form1.ScriptTick = 1
        Form1.ScriptTimer.Start()

    End Sub

    Public Sub CheckRiskyPick()

        If RiskyRound = 0 Then
            BTNRiskyPlay.Text = RiskyInt
            If BTNRisk1.BackColor = Color.Khaki Then
                BTNRisk1.BackColor = Color.Transparent
                BTNRisk1.Text = ""
            End If
            If BTNRisk2.BackColor = Color.Khaki Then
                BTNRisk2.BackColor = Color.Transparent
                BTNRisk2.Text = ""
            End If
            If BTNRisk3.BackColor = Color.Khaki Then
                BTNRisk3.BackColor = Color.Transparent
                BTNRisk3.Text = ""
            End If
            If BTNRisk4.BackColor = Color.Khaki Then
                BTNRisk4.BackColor = Color.Transparent
                BTNRisk4.Text = ""
            End If
            If BTNRisk5.BackColor = Color.Khaki Then
                BTNRisk5.BackColor = Color.Transparent
                BTNRisk5.Text = ""
            End If
            If BTNRisk6.BackColor = Color.Khaki Then
                BTNRisk6.BackColor = Color.Transparent
                BTNRisk6.Text = ""
            End If
            If BTNRisk7.BackColor = Color.Khaki Then
                BTNRisk7.BackColor = Color.Transparent
                BTNRisk7.Text = ""
            End If
            If BTNRisk8.BackColor = Color.Khaki Then
                BTNRisk8.BackColor = Color.Transparent
                BTNRisk8.Text = ""
            End If
            If BTNRisk9.BackColor = Color.Khaki Then
                BTNRisk9.BackColor = Color.Transparent
                BTNRisk9.Text = ""
            End If
            If BTNRisk10.BackColor = Color.Khaki Then
                BTNRisk10.BackColor = Color.Transparent
                BTNRisk10.Text = ""
            End If
            If BTNRisk11.BackColor = Color.Khaki Then
                BTNRisk11.BackColor = Color.Transparent
                BTNRisk11.Text = ""
            End If
            If BTNRisk12.BackColor = Color.Khaki Then
                BTNRisk12.BackColor = Color.Transparent
                BTNRisk12.Text = ""
            End If
            If BTNRisk13.BackColor = Color.Khaki Then
                BTNRisk13.BackColor = Color.Transparent
                BTNRisk13.Text = ""
            End If
            If BTNRisk14.BackColor = Color.Khaki Then
                BTNRisk14.BackColor = Color.Transparent
                BTNRisk14.Text = ""
            End If
            If BTNRisk15.BackColor = Color.Khaki Then
                BTNRisk15.BackColor = Color.Transparent
                BTNRisk15.Text = ""
            End If
            If BTNRisk16.BackColor = Color.Khaki Then
                BTNRisk16.BackColor = Color.Transparent
                BTNRisk16.Text = ""
            End If
            If BTNRisk17.BackColor = Color.Khaki Then
                BTNRisk17.BackColor = Color.Transparent
                BTNRisk17.Text = ""
            End If
            If BTNRisk18.BackColor = Color.Khaki Then
                BTNRisk18.BackColor = Color.Transparent
                BTNRisk18.Text = ""
            End If
            If BTNRisk19.BackColor = Color.Khaki Then
                BTNRisk19.BackColor = Color.Transparent
                BTNRisk19.Text = ""
            End If
            If BTNRisk20.BackColor = Color.Khaki Then
                BTNRisk20.BackColor = Color.Transparent
                BTNRisk20.Text = ""
            End If
            If BTNRisk21.BackColor = Color.Khaki Then
                BTNRisk21.BackColor = Color.Transparent
                BTNRisk21.Text = ""
            End If
            If BTNRisk22.BackColor = Color.Khaki Then
                BTNRisk22.BackColor = Color.Transparent
                BTNRisk22.Text = ""
            End If
            If BTNRisk23.BackColor = Color.Khaki Then
                BTNRisk23.BackColor = Color.Transparent
                BTNRisk23.Text = ""
            End If
            If BTNRisk24.BackColor = Color.Khaki Then
                BTNRisk24.BackColor = Color.Transparent
                BTNRisk24.Text = ""
            End If
            Return
        End If


        If RiskyPickCount = 0 Then LBLPick1.Text = ""
        If RiskyPickCount = 1 Then LBLPick2.Text = ""
        If RiskyPickCount = 2 Then LBLPick3.Text = ""
        If RiskyPickCount = 3 Then LBLPick4.Text = ""
        If RiskyPickCount = 4 Then LBLPick5.Text = ""
        If RiskyPickCount = 5 Then LBLPick6.Text = ""



        If RiskyRound > 0 Then

            RiskyPickCount += 1

        



            Risk1.ForeColor = Color.DarkGray
            Risk2.ForeColor = Color.DarkGray
            Risk3.ForeColor = Color.DarkGray
            Risk4.ForeColor = Color.DarkGray
            Risk5.ForeColor = Color.DarkGray
            Risk6.ForeColor = Color.DarkGray
            Risk7.ForeColor = Color.DarkGray
            Risk8.ForeColor = Color.DarkGray
            Risk9.ForeColor = Color.DarkGray
            Risk10.ForeColor = Color.DarkGray
            Risk11.ForeColor = Color.DarkGray
            Risk12.ForeColor = Color.DarkGray
            Risk13.ForeColor = Color.DarkGray
            Risk14.ForeColor = Color.DarkGray
            Risk15.ForeColor = Color.DarkGray
            Risk16.ForeColor = Color.DarkGray
            Risk17.ForeColor = Color.DarkGray
            Risk18.ForeColor = Color.DarkGray
            Risk19.ForeColor = Color.DarkGray
            Risk20.ForeColor = Color.DarkGray
            Risk21.ForeColor = Color.DarkGray
            Risk22.ForeColor = Color.DarkGray
            Risk23.ForeColor = Color.DarkGray
            Risk24.ForeColor = Color.DarkGray

            If RiskyChoices(RiskyPickCount - 1) = Risk1.Text Then Risk1.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk2.Text Then Risk2.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk3.Text Then Risk3.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk4.Text Then Risk4.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk5.Text Then Risk5.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk6.Text Then Risk6.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk7.Text Then Risk7.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk8.Text Then Risk8.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk9.Text Then Risk9.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk10.Text Then Risk10.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk11.Text Then Risk11.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk12.Text Then Risk12.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk13.Text Then Risk13.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk14.Text Then Risk14.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk15.Text Then Risk15.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk16.Text Then Risk16.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk17.Text Then Risk17.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk18.Text Then Risk18.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk19.Text Then Risk19.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk20.Text Then Risk20.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk21.Text Then Risk21.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk22.Text Then Risk22.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk23.Text Then Risk23.ForeColor = Color.Black
            If RiskyChoices(RiskyPickCount - 1) = Risk24.Text Then Risk24.ForeColor = Color.Black

            If RiskyChoices(RiskyPickCount - 1) = Risk1.Text Then BTNRisk1.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk2.Text Then BTNRisk2.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk3.Text Then BTNRisk3.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk4.Text Then BTNRisk4.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk5.Text Then BTNRisk5.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk6.Text Then BTNRisk6.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk7.Text Then BTNRisk7.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk8.Text Then BTNRisk8.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk9.Text Then BTNRisk9.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk10.Text Then BTNRisk10.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk11.Text Then BTNRisk11.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk12.Text Then BTNRisk12.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk13.Text Then BTNRisk13.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk14.Text Then BTNRisk14.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk15.Text Then BTNRisk15.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk16.Text Then BTNRisk16.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk17.Text Then BTNRisk17.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk18.Text Then BTNRisk18.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk19.Text Then BTNRisk19.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk20.Text Then BTNRisk20.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk21.Text Then BTNRisk21.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk22.Text Then BTNRisk22.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk23.Text Then BTNRisk23.BackColor = Color.Yellow
            If RiskyChoices(RiskyPickCount - 1) = Risk24.Text Then BTNRisk24.BackColor = Color.Yellow

            RiskyTick = 3
            TimerRiskyFlash.Start()

            If RiskyChoices(RiskyPickCount - 1) = Risk1.Text Then BTNRisk1.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk2.Text Then BTNRisk2.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk3.Text Then BTNRisk3.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk4.Text Then BTNRisk4.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk5.Text Then BTNRisk5.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk6.Text Then BTNRisk6.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk7.Text Then BTNRisk7.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk8.Text Then BTNRisk8.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk9.Text Then BTNRisk9.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk10.Text Then BTNRisk10.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk11.Text Then BTNRisk11.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk12.Text Then BTNRisk12.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk13.Text Then BTNRisk13.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk14.Text Then BTNRisk14.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk15.Text Then BTNRisk15.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk16.Text Then BTNRisk16.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk17.Text Then BTNRisk17.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk18.Text Then BTNRisk18.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk19.Text Then BTNRisk19.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk20.Text Then BTNRisk20.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk21.Text Then BTNRisk21.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk22.Text Then BTNRisk22.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk23.Text Then BTNRisk23.Text = ""
            If RiskyChoices(RiskyPickCount - 1) = Risk24.Text Then BTNRisk24.Text = ""


            ClearCaseLabels()

           

            If RiskyChoices(RiskyPickCount - 1) = LBLRisk100.Text Then RiskyResponse = "#RP_100Edge"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk95.Text Then RiskyResponse = "#RP_FirstRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk90.Text Then RiskyResponse = "#RP_FirstRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk85.Text Then RiskyResponse = "#RP_FirstRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk80.Text Then RiskyResponse = "#RP_FirstRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk75.Text Then RiskyResponse = "#RP_FirstRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk70.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk60.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk50.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk40.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk30.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk25.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk20.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk15.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk10.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk5.Text Then RiskyResponse = "#RP_FourthRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk3.Text Then RiskyResponse = "#RP_FourthRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk1.Text Then RiskyResponse = "#RP_1Edge"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk12.Text Then RiskyResponse = "#RP_ThirdRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk55.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk65.Text Then RiskyResponse = "#RP_SecondRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk4.Text Then RiskyResponse = "#RP_FourthRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk2.Text Then RiskyResponse = "#RP_FourthRow"
            If RiskyChoices(RiskyPickCount - 1) = LBLRisk7.Text Then RiskyResponse = "#RP_FourthRow"


            If RiskyRound = 1 Or RiskyRound = 2 Then
                If RiskyPickCount = 6 Then GetRiskyOffer()
            End If

            If RiskyRound = 3 Or RiskyRound = 4 Then
                If RiskyPickCount = 3 Then GetRiskyOffer()
            End If

            If RiskyRound = 5 Or RiskyRound = 6 Then
                If RiskyPickCount = 2 Then GetRiskyOffer()
            End If




        End If


    End Sub


    Private Sub TimerRiskyFlash_Tick(sender As System.Object, e As System.EventArgs) Handles TimerRiskyFlash.Tick

        RiskyTick -= 1

        If RiskyTick = 2 Then


            If BTNRisk1.BackColor = Color.Yellow Then BTNRisk1.BackColor = Color.AliceBlue
            If BTNRisk2.BackColor = Color.Yellow Then BTNRisk2.BackColor = Color.AliceBlue
            If BTNRisk3.BackColor = Color.Yellow Then BTNRisk3.BackColor = Color.AliceBlue
            If BTNRisk4.BackColor = Color.Yellow Then BTNRisk4.BackColor = Color.AliceBlue
            If BTNRisk5.BackColor = Color.Yellow Then BTNRisk5.BackColor = Color.AliceBlue
            If BTNRisk6.BackColor = Color.Yellow Then BTNRisk6.BackColor = Color.AliceBlue
            If BTNRisk7.BackColor = Color.Yellow Then BTNRisk7.BackColor = Color.AliceBlue
            If BTNRisk8.BackColor = Color.Yellow Then BTNRisk8.BackColor = Color.AliceBlue
            If BTNRisk9.BackColor = Color.Yellow Then BTNRisk9.BackColor = Color.AliceBlue
            If BTNRisk10.BackColor = Color.Yellow Then BTNRisk10.BackColor = Color.AliceBlue
            If BTNRisk11.BackColor = Color.Yellow Then BTNRisk11.BackColor = Color.AliceBlue
            If BTNRisk12.BackColor = Color.Yellow Then BTNRisk12.BackColor = Color.AliceBlue
            If BTNRisk13.BackColor = Color.Yellow Then BTNRisk13.BackColor = Color.AliceBlue
            If BTNRisk14.BackColor = Color.Yellow Then BTNRisk14.BackColor = Color.AliceBlue
            If BTNRisk15.BackColor = Color.Yellow Then BTNRisk15.BackColor = Color.AliceBlue
            If BTNRisk16.BackColor = Color.Yellow Then BTNRisk16.BackColor = Color.AliceBlue
            If BTNRisk17.BackColor = Color.Yellow Then BTNRisk17.BackColor = Color.AliceBlue
            If BTNRisk18.BackColor = Color.Yellow Then BTNRisk18.BackColor = Color.AliceBlue
            If BTNRisk19.BackColor = Color.Yellow Then BTNRisk19.BackColor = Color.AliceBlue
            If BTNRisk20.BackColor = Color.Yellow Then BTNRisk20.BackColor = Color.AliceBlue
            If BTNRisk21.BackColor = Color.Yellow Then BTNRisk21.BackColor = Color.AliceBlue
            If BTNRisk22.BackColor = Color.Yellow Then BTNRisk22.BackColor = Color.AliceBlue
            If BTNRisk23.BackColor = Color.Yellow Then BTNRisk23.BackColor = Color.AliceBlue
            If BTNRisk24.BackColor = Color.Yellow Then BTNRisk24.BackColor = Color.AliceBlue
        End If

        If RiskyTick = 1 Then
            If BTNRisk1.BackColor = Color.AliceBlue Then BTNRisk1.BackColor = Color.Yellow
            If BTNRisk2.BackColor = Color.AliceBlue Then BTNRisk2.BackColor = Color.Yellow
            If BTNRisk3.BackColor = Color.AliceBlue Then BTNRisk3.BackColor = Color.Yellow
            If BTNRisk4.BackColor = Color.AliceBlue Then BTNRisk4.BackColor = Color.Yellow
            If BTNRisk5.BackColor = Color.AliceBlue Then BTNRisk5.BackColor = Color.Yellow
            If BTNRisk6.BackColor = Color.AliceBlue Then BTNRisk6.BackColor = Color.Yellow
            If BTNRisk7.BackColor = Color.AliceBlue Then BTNRisk7.BackColor = Color.Yellow
            If BTNRisk8.BackColor = Color.AliceBlue Then BTNRisk8.BackColor = Color.Yellow
            If BTNRisk9.BackColor = Color.AliceBlue Then BTNRisk9.BackColor = Color.Yellow
            If BTNRisk10.BackColor = Color.AliceBlue Then BTNRisk10.BackColor = Color.Yellow
            If BTNRisk11.BackColor = Color.AliceBlue Then BTNRisk11.BackColor = Color.Yellow
            If BTNRisk12.BackColor = Color.AliceBlue Then BTNRisk12.BackColor = Color.Yellow
            If BTNRisk13.BackColor = Color.AliceBlue Then BTNRisk13.BackColor = Color.Yellow
            If BTNRisk14.BackColor = Color.AliceBlue Then BTNRisk14.BackColor = Color.Yellow
            If BTNRisk15.BackColor = Color.AliceBlue Then BTNRisk15.BackColor = Color.Yellow
            If BTNRisk16.BackColor = Color.AliceBlue Then BTNRisk16.BackColor = Color.Yellow
            If BTNRisk17.BackColor = Color.AliceBlue Then BTNRisk17.BackColor = Color.Yellow
            If BTNRisk18.BackColor = Color.AliceBlue Then BTNRisk18.BackColor = Color.Yellow
            If BTNRisk19.BackColor = Color.AliceBlue Then BTNRisk19.BackColor = Color.Yellow
            If BTNRisk20.BackColor = Color.AliceBlue Then BTNRisk20.BackColor = Color.Yellow
            If BTNRisk21.BackColor = Color.AliceBlue Then BTNRisk21.BackColor = Color.Yellow
            If BTNRisk22.BackColor = Color.AliceBlue Then BTNRisk22.BackColor = Color.Yellow
            If BTNRisk23.BackColor = Color.AliceBlue Then BTNRisk23.BackColor = Color.Yellow
            If BTNRisk24.BackColor = Color.AliceBlue Then BTNRisk24.BackColor = Color.Yellow
        End If

        If RiskyTick = 0 Then
            If BTNRisk1.BackColor = Color.Yellow Then BTNRisk1.BackColor = Color.Transparent
            If BTNRisk2.BackColor = Color.Yellow Then BTNRisk2.BackColor = Color.Transparent
            If BTNRisk3.BackColor = Color.Yellow Then BTNRisk3.BackColor = Color.Transparent
            If BTNRisk4.BackColor = Color.Yellow Then BTNRisk4.BackColor = Color.Transparent
            If BTNRisk5.BackColor = Color.Yellow Then BTNRisk5.BackColor = Color.Transparent
            If BTNRisk6.BackColor = Color.Yellow Then BTNRisk6.BackColor = Color.Transparent
            If BTNRisk7.BackColor = Color.Yellow Then BTNRisk7.BackColor = Color.Transparent
            If BTNRisk8.BackColor = Color.Yellow Then BTNRisk8.BackColor = Color.Transparent
            If BTNRisk9.BackColor = Color.Yellow Then BTNRisk9.BackColor = Color.Transparent
            If BTNRisk10.BackColor = Color.Yellow Then BTNRisk10.BackColor = Color.Transparent
            If BTNRisk11.BackColor = Color.Yellow Then BTNRisk11.BackColor = Color.Transparent
            If BTNRisk12.BackColor = Color.Yellow Then BTNRisk12.BackColor = Color.Transparent
            If BTNRisk13.BackColor = Color.Yellow Then BTNRisk13.BackColor = Color.Transparent
            If BTNRisk14.BackColor = Color.Yellow Then BTNRisk14.BackColor = Color.Transparent
            If BTNRisk15.BackColor = Color.Yellow Then BTNRisk15.BackColor = Color.Transparent
            If BTNRisk16.BackColor = Color.Yellow Then BTNRisk16.BackColor = Color.Transparent
            If BTNRisk17.BackColor = Color.Yellow Then BTNRisk17.BackColor = Color.Transparent
            If BTNRisk18.BackColor = Color.Yellow Then BTNRisk18.BackColor = Color.Transparent
            If BTNRisk19.BackColor = Color.Yellow Then BTNRisk19.BackColor = Color.Transparent
            If BTNRisk20.BackColor = Color.Yellow Then BTNRisk20.BackColor = Color.Transparent
            If BTNRisk21.BackColor = Color.Yellow Then BTNRisk21.BackColor = Color.Transparent
            If BTNRisk22.BackColor = Color.Yellow Then BTNRisk22.BackColor = Color.Transparent
            If BTNRisk23.BackColor = Color.Yellow Then BTNRisk23.BackColor = Color.Transparent
            If BTNRisk24.BackColor = Color.Yellow Then BTNRisk24.BackColor = Color.Transparent
            TimerRiskyFlash.Stop()
            GetRiskyOffer()
            LBLRiskMaxPot.Text = Math.Ceiling(1000 / LowestRisk)
            LblRiskMinPot.Text = Math.Ceiling(1000 / HighestRisk)
        End If



    End Sub

    Public Sub GetRiskyOffer()

        RiskyEdgeOffer = 0
        RiskyTokenOffer = 0
        RiskyOfferAvg = 0
        RiskyTokenAvg = 0

        If LBLRisk1.ForeColor = Color.White Then
            RiskyEdgeOffer += 1
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 1
            RiskyTokenAvg += 1
        End If

        If LBLRisk2.ForeColor = Color.White Then
            RiskyEdgeOffer += 2
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 2
            RiskyTokenAvg += 1
        End If

        If LBLRisk3.ForeColor = Color.White Then
            RiskyEdgeOffer += 3
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 3
            RiskyTokenAvg += 1
        End If

        If LBLRisk4.ForeColor = Color.White Then
            RiskyEdgeOffer += 4
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 4
            RiskyTokenAvg += 1
        End If

        If LBLRisk5.ForeColor = Color.White Then
            RiskyEdgeOffer += 5
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 5
            RiskyTokenAvg += 1
        End If

        If LBLRisk7.ForeColor = Color.White Then
            RiskyEdgeOffer += 7
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 7
            RiskyTokenAvg += 1
        End If

        If LBLRisk10.ForeColor = Color.White Then
            RiskyEdgeOffer += 10
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 10
            RiskyTokenAvg += 1
        End If

        If LBLRisk12.ForeColor = Color.White Then
            RiskyEdgeOffer += 12
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 12
            RiskyTokenAvg += 1
        End If

        If LBLRisk15.ForeColor = Color.White Then
            RiskyEdgeOffer += 15
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 15
            RiskyTokenAvg += 1
        End If

        If LBLRisk20.ForeColor = Color.White Then
            RiskyEdgeOffer += 20
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 20
            RiskyTokenAvg += 1
        End If

        If LBLRisk25.ForeColor = Color.White Then
            RiskyEdgeOffer += 25
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 25
            RiskyTokenAvg += 1
        End If

        If LBLRisk30.ForeColor = Color.White Then
            RiskyEdgeOffer += 30
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 30
            RiskyTokenAvg += 1
        End If

        If LBLRisk40.ForeColor = Color.White Then
            RiskyEdgeOffer += 40
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 40
            RiskyTokenAvg += 1
        End If

        If LBLRisk50.ForeColor = Color.White Then
            RiskyEdgeOffer += 50
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 50
            RiskyTokenAvg += 1
        End If

        If LBLRisk55.ForeColor = Color.White Then
            RiskyEdgeOffer += 55
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 55
            RiskyTokenAvg += 1
        End If

        If LBLRisk60.ForeColor = Color.White Then
            RiskyEdgeOffer += 60
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 60
            RiskyTokenAvg += 1
        End If

        If LBLRisk65.ForeColor = Color.White Then
            RiskyEdgeOffer += 65
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 65
            RiskyTokenAvg += 1
        End If

        If LBLRisk70.ForeColor = Color.White Then
            RiskyEdgeOffer += 70
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 70
            RiskyTokenAvg += 1
        End If

        If LBLRisk75.ForeColor = Color.White Then
            RiskyEdgeOffer += 75
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 75
            RiskyTokenAvg += 1
        End If

        If LBLRisk80.ForeColor = Color.White Then
            RiskyEdgeOffer += 80
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 80
            RiskyTokenAvg += 1
        End If

        If LBLRisk85.ForeColor = Color.White Then
            RiskyEdgeOffer += 85
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 85
            RiskyTokenAvg += 1
        End If

        If LBLRisk90.ForeColor = Color.White Then
            RiskyEdgeOffer += 90
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 90
            RiskyTokenAvg += 1
        End If

        If LBLRisk95.ForeColor = Color.White Then
            RiskyEdgeOffer += 95
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 95
            RiskyTokenAvg += 1
        End If

        If LBLRisk100.ForeColor = Color.White Then
            RiskyEdgeOffer += 100
            RiskyOfferAvg += 1
            RiskyTokenOffer += 1000 / 100
            RiskyTokenAvg += 1
        End If

        RiskyEdgeOffer /= RiskyOfferAvg
        'RiskyEdgeOffer += randomizer.Next(4, 9)
        RiskyEdgeOffer = Math.Ceiling(RiskyEdgeOffer)
        'RiskyEdgeOffer = 5 * Math.Round(RiskyEdgeOffer / 5)

      

        If LBLRisk1.ForeColor = Color.White Then HighestRisk = 1
        If LBLRisk2.ForeColor = Color.White Then HighestRisk = 2
        If LBLRisk3.ForeColor = Color.White Then HighestRisk = 3
        If LBLRisk4.ForeColor = Color.White Then HighestRisk = 4
        If LBLRisk5.ForeColor = Color.White Then HighestRisk = 5
        If LBLRisk7.ForeColor = Color.White Then HighestRisk = 7
        If LBLRisk10.ForeColor = Color.White Then HighestRisk = 10
        If LBLRisk12.ForeColor = Color.White Then HighestRisk = 12
        If LBLRisk15.ForeColor = Color.White Then HighestRisk = 15
        If LBLRisk20.ForeColor = Color.White Then HighestRisk = 20
        If LBLRisk25.ForeColor = Color.White Then HighestRisk = 25
        If LBLRisk30.ForeColor = Color.White Then HighestRisk = 30
        If LBLRisk40.ForeColor = Color.White Then HighestRisk = 40
        If LBLRisk50.ForeColor = Color.White Then HighestRisk = 50
        If LBLRisk55.ForeColor = Color.White Then HighestRisk = 55
        If LBLRisk60.ForeColor = Color.White Then HighestRisk = 60
        If LBLRisk65.ForeColor = Color.White Then HighestRisk = 65
        If LBLRisk70.ForeColor = Color.White Then HighestRisk = 70
        If LBLRisk75.ForeColor = Color.White Then HighestRisk = 75
        If LBLRisk80.ForeColor = Color.White Then HighestRisk = 80
        If LBLRisk85.ForeColor = Color.White Then HighestRisk = 85
        If LBLRisk90.ForeColor = Color.White Then HighestRisk = 90
        If LBLRisk95.ForeColor = Color.White Then HighestRisk = 95
        If LBLRisk100.ForeColor = Color.White Then HighestRisk = 100



        If LBLRisk100.ForeColor = Color.White Then LowestRisk = 100
        If LBLRisk95.ForeColor = Color.White Then LowestRisk = 95
        If LBLRisk90.ForeColor = Color.White Then LowestRisk = 90
        If LBLRisk85.ForeColor = Color.White Then LowestRisk = 85
        If LBLRisk80.ForeColor = Color.White Then LowestRisk = 80
        If LBLRisk75.ForeColor = Color.White Then LowestRisk = 75
        If LBLRisk70.ForeColor = Color.White Then LowestRisk = 70
        If LBLRisk65.ForeColor = Color.White Then LowestRisk = 65
        If LBLRisk60.ForeColor = Color.White Then LowestRisk = 60
        If LBLRisk55.ForeColor = Color.White Then LowestRisk = 55
        If LBLRisk50.ForeColor = Color.White Then LowestRisk = 50
        If LBLRisk40.ForeColor = Color.White Then LowestRisk = 40
        If LBLRisk30.ForeColor = Color.White Then LowestRisk = 30
        If LBLRisk25.ForeColor = Color.White Then LowestRisk = 25
        If LBLRisk20.ForeColor = Color.White Then LowestRisk = 20
        If LBLRisk15.ForeColor = Color.White Then LowestRisk = 15
        If LBLRisk12.ForeColor = Color.White Then LowestRisk = 12
        If LBLRisk10.ForeColor = Color.White Then LowestRisk = 10
        If LBLRisk7.ForeColor = Color.White Then LowestRisk = 7
        If LBLRisk5.ForeColor = Color.White Then LowestRisk = 5
        If LBLRisk4.ForeColor = Color.White Then LowestRisk = 4
        If LBLRisk3.ForeColor = Color.White Then LowestRisk = 3
        If LBLRisk2.ForeColor = Color.White Then LowestRisk = 2
        If LBLRisk1.ForeColor = Color.White Then LowestRisk = 1


        RiskyTokenOffer /= RiskyTokenAvg
        'RiskyEdgeOffer += randomizer.Next(4, 9)
        RiskyTokenOffer = Math.Ceiling(RiskyTokenOffer)

        'RiskyTokenOffer = 1000 / ((HighestRisk + LowestRisk) / 2)
        'RiskyTokenOffer -= (RiskyTokenOffer / 20)
        'If RiskyTokenOffer > 10 Then RiskyTokenOffer = 10 * Math.Round(RiskyTokenOffer / 10)


    End Sub


    Private Sub BTNRiskIt_Click(sender As System.Object, e As System.EventArgs) Handles BTNRiskIt.Click
        Form1.chatBox.Text = "Risk it"
        Form1.sendButton.PerformClick()
        If BTNRiskIt.Text = "LAST CASE" Then
            BTNRiskIt.Visible = True
            BTNPickIt.Visible = False
        Else
            BTNRiskIt.Visible = False
            BTNPickIt.Visible = False
        End If
      
    End Sub

    Private Sub BTNPickIt_Click(sender As System.Object, e As System.EventArgs) Handles BTNPickIt.Click
        Form1.chatBox.Text = "Pick it"
        Form1.sendButton.PerformClick()
        If BTNPickIt.Text = "MY CASE" Then
            BTNRiskIt.Visible = False
            BTNPickIt.Visible = True
        Else
            BTNRiskIt.Visible = False
            BTNPickIt.Visible = False
            EdgesOwed = RiskyEdgeOffer
            TokensPaid = RiskyTokenOffer
        End If
    End Sub

    Public Sub ClearCaseLabels()

        If RiskyChoices(RiskyPickCount - 1) = LBLRisk100.Text Then LBLRisk100.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk95.Text Then LBLRisk95.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk90.Text Then LBLRisk90.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk85.Text Then LBLRisk85.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk80.Text Then LBLRisk80.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk75.Text Then LBLRisk75.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk70.Text Then LBLRisk70.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk60.Text Then LBLRisk60.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk50.Text Then LBLRisk50.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk40.Text Then LBLRisk40.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk30.Text Then LBLRisk30.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk25.Text Then LBLRisk25.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk20.Text Then LBLRisk20.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk15.Text Then LBLRisk15.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk10.Text Then LBLRisk10.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk5.Text Then LBLRisk5.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk3.Text Then LBLRisk3.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk1.Text Then LBLRisk1.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk12.Text Then LBLRisk12.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk55.Text Then LBLRisk55.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk65.Text Then LBLRisk65.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk4.Text Then LBLRisk4.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk2.Text Then LBLRisk2.ForeColor = Color.DimGray
        If RiskyChoices(RiskyPickCount - 1) = LBLRisk7.Text Then LBLRisk7.ForeColor = Color.DimGray

    End Sub

    Public Sub HighlightCaseLabelsOffer()

        Risk1.ForeColor = Color.DimGray
        Risk2.ForeColor = Color.DimGray
        Risk3.ForeColor = Color.DimGray
        Risk4.ForeColor = Color.DimGray
        Risk5.ForeColor = Color.DimGray
        Risk6.ForeColor = Color.DimGray
        Risk7.ForeColor = Color.DimGray
        Risk8.ForeColor = Color.DimGray
        Risk9.ForeColor = Color.DimGray
        Risk10.ForeColor = Color.DimGray
        Risk11.ForeColor = Color.DimGray
        Risk12.ForeColor = Color.DimGray
        Risk13.ForeColor = Color.DimGray
        Risk14.ForeColor = Color.DimGray
        Risk15.ForeColor = Color.DimGray
        Risk16.ForeColor = Color.DimGray
        Risk17.ForeColor = Color.DimGray
        Risk18.ForeColor = Color.DimGray
        Risk19.ForeColor = Color.DimGray
        Risk20.ForeColor = Color.DimGray
        Risk21.ForeColor = Color.DimGray
        Risk22.ForeColor = Color.DimGray
        Risk23.ForeColor = Color.DimGray
        Risk24.ForeColor = Color.DimGray


    End Sub

    Public Sub ClearCaseLabelsOffer()

        Risk1.ForeColor = Color.DarkGray
        Risk2.ForeColor = Color.DarkGray
        Risk3.ForeColor = Color.DarkGray
        Risk4.ForeColor = Color.DarkGray
        Risk5.ForeColor = Color.DarkGray
        Risk6.ForeColor = Color.DarkGray
        Risk7.ForeColor = Color.DarkGray
        Risk8.ForeColor = Color.DarkGray
        Risk9.ForeColor = Color.DarkGray
        Risk10.ForeColor = Color.DarkGray
        Risk11.ForeColor = Color.DarkGray
        Risk12.ForeColor = Color.DarkGray
        Risk13.ForeColor = Color.DarkGray
        Risk14.ForeColor = Color.DarkGray
        Risk15.ForeColor = Color.DarkGray
        Risk16.ForeColor = Color.DarkGray
        Risk17.ForeColor = Color.DarkGray
        Risk18.ForeColor = Color.DarkGray
        Risk19.ForeColor = Color.DarkGray
        Risk20.ForeColor = Color.DarkGray
        Risk21.ForeColor = Color.DarkGray
        Risk22.ForeColor = Color.DarkGray
        Risk23.ForeColor = Color.DarkGray
        Risk24.ForeColor = Color.DarkGray

    End Sub

    Public Sub ClearAllCards()

        Try
            Slot1.Image.Dispose()
        Catch
        End Try
        Slot1.Image = Nothing

        Try
            Slot2.Image.Dispose()
        Catch
        End Try
        Slot2.Image = Nothing

        Try
            Slot3.Image.Dispose()
        Catch
        End Try
        Slot3.Image = Nothing

        Try
            BronzeP1.Image.Dispose()
        Catch
        End Try
        BronzeP1.Image = Nothing

        Try
            BronzeP2.Image.Dispose()
        Catch
        End Try
        BronzeP2.Image = Nothing

        Try
            BronzeP3.Image.Dispose()
        Catch
        End Try
        BronzeP3.Image = Nothing

        Try
            BronzeP4.Image.Dispose()
        Catch
        End Try
        BronzeP4.Image = Nothing

        Try
            BronzeP5.Image.Dispose()
        Catch
        End Try
        BronzeP5.Image = Nothing

        Try
            BronzeP6.Image.Dispose()
        Catch
        End Try
        BronzeP6.Image = Nothing

        Try
            SilverP1.Image.Dispose()
        Catch
        End Try
        SilverP1.Image = Nothing

        Try
            SilverP2.Image.Dispose()
        Catch
        End Try
        SilverP2.Image = Nothing

        Try
            SilverP3.Image.Dispose()
        Catch
        End Try
        SilverP3.Image = Nothing

        Try
            SilverP4.Image.Dispose()
        Catch
        End Try
        SilverP4.Image = Nothing

        Try
            SilverP5.Image.Dispose()
        Catch
        End Try
        SilverP5.Image = Nothing

        Try
            SilverP6.Image.Dispose()
        Catch
        End Try
        SilverP6.Image = Nothing

        Try
            GoldP1.Image.Dispose()
        Catch
        End Try
        GoldP1.Image = Nothing

        Try
            GoldP2.Image.Dispose()
        Catch
        End Try
        GoldP2.Image = Nothing

        Try
            GoldP3.Image.Dispose()
        Catch
        End Try
        GoldP3.Image = Nothing

        Try
            GoldP4.Image.Dispose()
        Catch
        End Try
        GoldP4.Image = Nothing

        Try
            GoldP5.Image.Dispose()
        Catch
        End Try
        GoldP5.Image = Nothing

        Try
            GoldP6.Image.Dispose()
        Catch
        End Try
        GoldP6.Image = Nothing


    End Sub


    Public Sub CloseRiskyPick()

        ClearCaseLabelsOffer()

        BTNRisk1.Enabled = False
        BTNRisk2.Enabled = False
        BTNRisk3.Enabled = False
        BTNRisk4.Enabled = False
        BTNRisk5.Enabled = False
        BTNRisk6.Enabled = False
        BTNRisk7.Enabled = False
        BTNRisk8.Enabled = False
        BTNRisk9.Enabled = False
        BTNRisk10.Enabled = False
        BTNRisk11.Enabled = False
        BTNRisk12.Enabled = False
        BTNRisk13.Enabled = False
        BTNRisk14.Enabled = False
        BTNRisk15.Enabled = False
        BTNRisk16.Enabled = False
        BTNRisk17.Enabled = False
        BTNRisk18.Enabled = False
        BTNRisk19.Enabled = False
        BTNRisk20.Enabled = False
        BTNRisk21.Enabled = False
        BTNRisk22.Enabled = False
        BTNRisk23.Enabled = False
        BTNRisk24.Enabled = False

        BTNRisk1.Text = "1"
        BTNRisk2.Text = "2"
        BTNRisk3.Text = "3"
        BTNRisk4.Text = "4"
        BTNRisk5.Text = "5"
        BTNRisk6.Text = "6"
        BTNRisk7.Text = "7"
        BTNRisk8.Text = "8"
        BTNRisk9.Text = "9"
        BTNRisk10.Text = "10"
        BTNRisk11.Text = "11"
        BTNRisk12.Text = "12"
        BTNRisk13.Text = "13"
        BTNRisk14.Text = "14"
        BTNRisk15.Text = "15"
        BTNRisk16.Text = "16"
        BTNRisk17.Text = "17"
        BTNRisk18.Text = "18"
        BTNRisk19.Text = "19"
        BTNRisk20.Text = "20"
        BTNRisk21.Text = "21"
        BTNRisk22.Text = "22"
        BTNRisk23.Text = "23"
        BTNRisk24.Text = "24"

        LBLRisk100.ForeColor = Color.White
        LBLRisk95.ForeColor = Color.White
        LBLRisk90.ForeColor = Color.White
        LBLRisk85.ForeColor = Color.White
        LBLRisk80.ForeColor = Color.White
        LBLRisk75.ForeColor = Color.White
        LBLRisk70.ForeColor = Color.White
        LBLRisk65.ForeColor = Color.White
        LBLRisk60.ForeColor = Color.White
        LBLRisk55.ForeColor = Color.White
        LBLRisk50.ForeColor = Color.White
        LBLRisk40.ForeColor = Color.White
        LBLRisk30.ForeColor = Color.White
        LBLRisk25.ForeColor = Color.White
        LBLRisk20.ForeColor = Color.White
        LBLRisk15.ForeColor = Color.White
        LBLRisk12.ForeColor = Color.White
        LBLRisk10.ForeColor = Color.White
        LBLRisk7.ForeColor = Color.White
        LBLRisk5.ForeColor = Color.White
        LBLRisk4.ForeColor = Color.White
        LBLRisk3.ForeColor = Color.White
        LBLRisk2.ForeColor = Color.White
        LBLRisk1.ForeColor = Color.White

        WBRiskyChat.DocumentText = ""
        LBLRiskMaxPot.Text = "N/A"
        LblRiskMinPot.Text = "N/A"
        BTNRiskIt.Visible = False
        BTNPickIt.Visible = False
        BTNRiskIt.Text = "DECLINE OFFER"
        BTNPickIt.Text = "ACCEPT OFFER"

        Form1.RiskyDeal = False
        Form1.RiskyEdges = True

        Me.Close()






    End Sub

    'Public Sub PickedMyCase()

    'EdgesOwed = Val(RiskyCase)
    'TokensPaid = 1000 / EdgesOwed
    'TokensPaid = Math.Ceiling(TokensPaid)



    'End Sub

    'Public Sub PickedLastCase()



    'EdgesOwed = Val(RiskyCase)
    'TokensPaid = 1000 / EdgesOwed
    'TokensPaid = Math.Ceiling(TokensPaid)



    'End Sub




End Class