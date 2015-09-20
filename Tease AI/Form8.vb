Imports System.IO

Public Class Form8


    Dim SysMessage As String
    Dim InfoTick As Integer
    Dim TagDir As String
    Dim FormLoading As Boolean


    Private Sub Form8_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormLoading = True

        Debug.Print("Last settings = " & My.Settings.LastDomTagURL)

        comboDrive.Items.Clear()

        For Each Drive As DriveInfo In DriveInfo.GetDrives()
            comboDrive.Items.Add(Drive)
        Next

        'comboDrive.Text = comboDrive.Items(0)

        WBDommeTag.Width = Me.Width - 368
        WBDommeTag.Height = Me.Height - 67
        TBURL.Width = Me.Width - 470

        Try
            WBDommeTag.Navigate(My.Settings.LastDomTagURL)
        Catch ex As Exception
            WBDommeTag.Navigate("C:\")
            My.Settings.LastDomTagURL = "C:\"
            My.Settings.Save()
        End Try

        WBDommeTag.Width = Me.Width - 378
        WBDommeTag.Height = Me.Height - 100
        TBURL.Width = Me.Width - 456

        FormLoading = False

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        WBDommeTag.Navigate("R:\Downloads\Mellisa Clarke\mellisa-clarke.com\s87")
        TagDir = "R:\Downloads\Mellisa Clarke\mellisa-clarke.com\s87"
    End Sub

    Private Sub Tag_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Ass.DragEnter, Face.DragEnter, Boobs.DragEnter, Pussy.DragEnter, Legs.DragEnter, _
        Feet.DragEnter, FullyDressed.DragEnter, HalfDressed.DragEnter, GarmentCovering.DragEnter, HandsCovering.DragEnter, Naked.DragEnter, SideView.DragEnter, CloseUp.DragEnter, _
        Masturbating.DragEnter, Sucking.DragEnter, Smiling.DragEnter, Glaring.DragEnter, Garment.DragEnter, Underwear.DragEnter, Tattoo.DragEnter, SexToy.DragEnter, Furniture.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Face_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Face.DragDrop

        If Face.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagFace")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagFace")
            Next
        End If
    End Sub

    Private Sub Boobs_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Boobs.DragDrop

        If Boobs.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagBoobs")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagBoobs")
            Next
        End If
    End Sub

    Private Sub Pussy_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pussy.DragDrop

        If Pussy.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagPussy")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagPussy")
            Next
        End If
    End Sub

    Private Sub Ass_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Ass.DragDrop

        If Ass.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagAss")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagAss")
            Next
        End If
    End Sub

    Private Sub Legs_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Legs.DragDrop

        If Legs.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagLegs")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagLegs")
            Next
        End If
    End Sub

    Private Sub Feet_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Feet.DragDrop

        If Feet.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagFeet")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagFeet")
            Next
        End If
    End Sub

    Private Sub FullyDressed_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FullyDressed.DragDrop

        If FullyDressed.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagFullyDressed")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagFullyDressed")
            Next
        End If
    End Sub

    Private Sub HalfDressed_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles HalfDressed.DragDrop

        If HalfDressed.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagHalfDressed")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagHalfDressed")
            Next
        End If
    End Sub

    Private Sub GarmentCovering_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GarmentCovering.DragDrop

        If GarmentCovering.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagGarmentCovering")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagGarmentCovering")
            Next
        End If
    End Sub

    Private Sub HandsCovering_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles HandsCovering.DragDrop

        If HandsCovering.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagHandsCovering")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagHandsCovering")
            Next
        End If
    End Sub

    Private Sub Naked_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Naked.DragDrop

        If Naked.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagNaked")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagNaked")
            Next
        End If
    End Sub

    Private Sub SideView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SideView.DragDrop

        If SideView.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagSideView")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagSideView")
            Next
        End If
    End Sub

    Private Sub CloseUp_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles CloseUp.DragDrop

        If CloseUp.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagCloseUp")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagCloseUp")
            Next
        End If
    End Sub

    Private Sub Masturbating_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Masturbating.DragDrop

        If Masturbating.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagMasturbating")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagMasturbating")
            Next
        End If
    End Sub

    Private Sub Sucking_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Sucking.DragDrop

        If Sucking.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagSucking")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagSucking")
            Next
        End If
    End Sub

    Private Sub Piercing_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Piercing.DragDrop

        If Piercing.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagPiercing")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagPiercing")
            Next
        End If
    End Sub

    Private Sub Smiling_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Smiling.DragDrop

        If Smiling.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagSmiling")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagSmiling")
            Next
        End If
    End Sub

    Private Sub Glaring_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Glaring.DragDrop

        If Glaring.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteTags(filePath, "TagGlaring")
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteTags(filePath, "TagGlaring")
            Next
        End If
    End Sub


    Private Sub Garment_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Garment.DragDrop
        If TBGarment.Text = "" Then
            MessageBox.Show(Me, "Please enter a description in the Garment field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Dim CustomString As String = TBGarment.Text.Replace(" ", "-")
        If Garment.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteCustomTags(filePath, "TagGarment", CustomString)
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteCustomTags(filePath, "TagGarment", CustomString)
            Next
        End If
    End Sub

    Private Sub Underwear_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Underwear.DragDrop
        If TBUnderwear.Text = "" Then
            MessageBox.Show(Me, "Please enter a description in the Underwear field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Dim CustomString As String = TBUnderwear.Text.Replace(" ", "-")
        If Underwear.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteCustomTags(filePath, "TagUnderwear", CustomString)
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteCustomTags(filePath, "TagUnderwear", CustomString)
            Next
        End If
    End Sub

    Private Sub Tattoo_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Tattoo.DragDrop
        If TBTattoo.Text = "" Then
            MessageBox.Show(Me, "Please enter a description in the Tattoo field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Dim CustomString As String = TBTattoo.Text.Replace(" ", "-")
        If Tattoo.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteCustomTags(filePath, "TagTattoo", CustomString)
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteCustomTags(filePath, "TagTattoo", CustomString)
            Next
        End If
    End Sub

    Private Sub SexToy_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles SexToy.DragDrop
        If TBSexToy.Text = "" Then
            MessageBox.Show(Me, "Please enter a description in the Sex Toy field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Dim CustomString As String = SexToy.Text.Replace(" ", "-")
        If SexToy.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteCustomTags(filePath, "TagSexToy", CustomString)
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteCustomTags(filePath, "TagSexToy", CustomString)
            Next
        End If
    End Sub

    Private Sub Furniture_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Furniture.DragDrop
        If TBFurniture.Text = "" Then
            MessageBox.Show(Me, "Please enter a description in the Furniture field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End If

        Dim CustomString As String = TBFurniture.Text.Replace(" ", "-")
        If Furniture.BackColor = Color.White Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                WriteCustomTags(filePath, "TagFurniture", CustomString)
            Next
        Else
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                DeleteCustomTags(filePath, "TagFurniture", CustomString)
            Next
        End If
    End Sub


    Public Function WriteTags(ByVal TagPath As String, ByVal Tag As String) As String

        Dim SettingsString As String
        Dim TagFile As String = Path.GetDirectoryName(TagPath) & "\ImageTags.txt"
        Debug.Print("TagFile = " & TagFile)

        If File.Exists(TagFile) Then

            Dim TagList As New List(Of String)
            TagList = Form1.Txt2List(TagFile)

            Dim FoundFile As Boolean = False

            For i As Integer = 0 To TagList.Count - 1
                If TagList(i).Contains(Path.GetFileName(TagPath)) Then
                    FoundFile = True
                    If Not TagList(i).Contains(Tag) Then
                        TagList(i) = TagList(i) & " " & Tag
                    End If
                End If
            Next

            If FoundFile = False Then TagList.Add(Path.GetFileName(TagPath) & " " & Tag)

            If TagList.Count > 0 Then
                SettingsString = ""
                For i As Integer = 0 To TagList.Count - 1
                    SettingsString = SettingsString & TagList(i)
                    If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
                Next
                My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", SettingsString, False)
            End If

        Else

            My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", Path.GetFileName(TagPath) & " " & Tag, True)

        End If

        SysMessage = Tag & " tag has been applied!"
        SysMessage = SysMessage.Replace("Tag", "")
        InfoTick = 4
        InfoTimer.Start()

    End Function

    Public Function WriteCustomTags(ByVal TagPath As String, ByVal Tag As String, ByVal Custom As String) As String

        Dim SettingsString As String
        Dim TagFile As String = Path.GetDirectoryName(TagPath) & "\ImageTags.txt"
        Debug.Print("TagFile = " & TagFile)

        If File.Exists(TagFile) Then

            Dim TagList As New List(Of String)
            TagList = Form1.Txt2List(TagFile)

            Dim FoundFile As Boolean = False

            For i As Integer = 0 To TagList.Count - 1
                If TagList(i).Contains(Path.GetFileName(TagPath)) Then
                    FoundFile = True
                    If Not TagList(i).Contains(Tag & Custom) Then
                        TagList(i) = TagList(i) & " " & Tag & Custom
                    End If
                End If
            Next

            If FoundFile = False Then TagList.Add(Path.GetFileName(TagPath) & " " & Tag & Custom)

            If TagList.Count > 0 Then
                SettingsString = ""
                For i As Integer = 0 To TagList.Count - 1
                    SettingsString = SettingsString & TagList(i)
                    If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
                Next
                My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", SettingsString, False)
            End If

        Else

            My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", Path.GetFileName(TagPath) & " " & Tag & Custom, True)

        End If

        SysMessage = Tag & " tag has been applied!"
        SysMessage = SysMessage.Replace("Tag", "")
        InfoTick = 4
        InfoTimer.Start()

    End Function

    Public Function DeleteTags(ByVal TagPath As String, ByVal Tag As String) As String

        Dim SettingsString As String
        Dim TagFile As String = Path.GetDirectoryName(TagPath) & "\ImageTags.txt"
        Debug.Print("TagFile = " & TagFile)

        If File.Exists(TagFile) Then

            Dim TagList As New List(Of String)
            TagList = Form1.Txt2List(TagFile)

            For i As Integer = TagList.Count - 1 To 0 Step -1
                If TagList(i).Contains(Path.GetFileName(TagPath)) Then
                    If TagList(i).Contains(Tag) Then
                        TagList(i) = TagList(i).Replace(Tag, "")
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
                My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", SettingsString, False)
            End If

        End If

        SysMessage = Tag & " tag has been removed!"
        SysMessage = SysMessage.Replace("Tag", "")
        InfoTick = 4
        InfoTimer.Start()

    End Function



   


    Public Function DeleteCustomTags(ByVal TagPath As String, ByVal Tag As String, ByVal Custom As String) As String

        Dim SettingsString As String
        Dim TagFile As String = Path.GetDirectoryName(TagPath) & "\ImageTags.txt"
        Debug.Print("TagFile = " & TagFile)

        If File.Exists(TagFile) Then

            Dim TagList As New List(Of String)
            TagList = Form1.Txt2List(TagFile)

            For i As Integer = TagList.Count - 1 To 0 Step -1
                If TagList(i).Contains(Path.GetFileName(TagPath)) Then
                    If TagList(i).Contains(Tag & Custom) Then
                        TagList(i) = TagList(i).Replace(Tag & Custom, "")
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
                My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(TagPath) & "\ImageTags.txt", SettingsString, False)
            End If

        End If

        SysMessage = Tag & " tag has been removed!"
        SysMessage = SysMessage.Replace("Tag", "")
        InfoTick = 4
        InfoTimer.Start()

    End Function

  


    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        WBDommeTag.Width = Me.Width - 378
        WBDommeTag.Height = Me.Height - 100
        TBURL.Width = Me.Width - 456


    End Sub

    Private Sub Face_Click(sender As System.Object, e As System.EventArgs) Handles Face.Click
        If Face.BackColor = Color.White Then
            Face.BackColor = Color.Red
            Face.ForeColor = Color.White
        Else
            Face.BackColor = Color.White
            Face.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Boobs_Click(sender As System.Object, e As System.EventArgs) Handles Boobs.Click
        If Boobs.BackColor = Color.White Then
            Boobs.BackColor = Color.Red
            Boobs.ForeColor = Color.White
        Else
            Boobs.BackColor = Color.White
            Boobs.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Pussy_Click(sender As System.Object, e As System.EventArgs) Handles Pussy.Click
        If Pussy.BackColor = Color.White Then
            Pussy.BackColor = Color.Red
            Pussy.ForeColor = Color.White
        Else
            Pussy.BackColor = Color.White
            Pussy.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Ass_Click(sender As System.Object, e As System.EventArgs) Handles Ass.Click
        If Ass.BackColor = Color.White Then
            Ass.BackColor = Color.Red
            Ass.ForeColor = Color.White
        Else
            Ass.BackColor = Color.White
            Ass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Legs_Click(sender As System.Object, e As System.EventArgs) Handles Legs.Click
        If Legs.BackColor = Color.White Then
            Legs.BackColor = Color.Red
            Legs.ForeColor = Color.White
        Else
            Legs.BackColor = Color.White
            Legs.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Feet_Click(sender As System.Object, e As System.EventArgs) Handles Feet.Click
        If Feet.BackColor = Color.White Then
            Feet.BackColor = Color.Red
            Feet.ForeColor = Color.White
        Else
            Feet.BackColor = Color.White
            Feet.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Masturbating_Click(sender As System.Object, e As System.EventArgs) Handles Masturbating.Click
        If Masturbating.BackColor = Color.White Then
            Masturbating.BackColor = Color.Red
            Masturbating.ForeColor = Color.White
        Else
            Masturbating.BackColor = Color.White
            Masturbating.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Sucking_Click(sender As System.Object, e As System.EventArgs) Handles Sucking.Click
        If Sucking.BackColor = Color.White Then
            Sucking.BackColor = Color.Red
            Sucking.ForeColor = Color.White
        Else
            Sucking.BackColor = Color.White
            Sucking.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Smiling_Click(sender As System.Object, e As System.EventArgs) Handles Smiling.Click
        If Smiling.BackColor = Color.White Then
            Smiling.BackColor = Color.Red
            Smiling.ForeColor = Color.White
        Else
            Smiling.BackColor = Color.White
            Smiling.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Glaring_Click(sender As System.Object, e As System.EventArgs) Handles Glaring.Click
        If Glaring.BackColor = Color.White Then
            Glaring.BackColor = Color.Red
            Glaring.ForeColor = Color.White
        Else
            Glaring.BackColor = Color.White
            Glaring.ForeColor = Color.Black
        End If
    End Sub

    Private Sub FullyDressed_Click(sender As System.Object, e As System.EventArgs) Handles FullyDressed.Click
        If FullyDressed.BackColor = Color.White Then
            FullyDressed.BackColor = Color.Red
            FullyDressed.ForeColor = Color.White
        Else
            FullyDressed.BackColor = Color.White
            FullyDressed.ForeColor = Color.Black
        End If
    End Sub

    Private Sub HalfDressed_Click(sender As System.Object, e As System.EventArgs) Handles HalfDressed.Click
        If HalfDressed.BackColor = Color.White Then
            HalfDressed.BackColor = Color.Red
            HalfDressed.ForeColor = Color.White
        Else
            HalfDressed.BackColor = Color.White
            HalfDressed.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GarmentCovering_Click(sender As System.Object, e As System.EventArgs) Handles GarmentCovering.Click
        If GarmentCovering.BackColor = Color.White Then
            GarmentCovering.BackColor = Color.Red
            GarmentCovering.ForeColor = Color.White
        Else
            GarmentCovering.BackColor = Color.White
            GarmentCovering.ForeColor = Color.Black
        End If
    End Sub

    Private Sub HandsCovering_Click(sender As System.Object, e As System.EventArgs) Handles HandsCovering.Click
        If HandsCovering.BackColor = Color.White Then
            HandsCovering.BackColor = Color.Red
            HandsCovering.ForeColor = Color.White
        Else
            HandsCovering.BackColor = Color.White
            HandsCovering.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Naked_Click(sender As System.Object, e As System.EventArgs) Handles Naked.Click
        If Naked.BackColor = Color.White Then
            Naked.BackColor = Color.Red
            Naked.ForeColor = Color.White
        Else
            Naked.BackColor = Color.White
            Naked.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SideView_Click(sender As System.Object, e As System.EventArgs) Handles SideView.Click
        If SideView.BackColor = Color.White Then
            SideView.BackColor = Color.Red
            SideView.ForeColor = Color.White
        Else
            SideView.BackColor = Color.White
            SideView.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CloseUp_Click(sender As System.Object, e As System.EventArgs) Handles CloseUp.Click
        If CloseUp.BackColor = Color.White Then
            CloseUp.BackColor = Color.Red
            CloseUp.ForeColor = Color.White
        Else
            CloseUp.BackColor = Color.White
            CloseUp.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Piercing_Click(sender As System.Object, e As System.EventArgs) Handles Piercing.Click
        If Piercing.BackColor = Color.White Then
            Piercing.BackColor = Color.Red
            Piercing.ForeColor = Color.White
        Else
            Piercing.BackColor = Color.White
            Piercing.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Garment_Click(sender As System.Object, e As System.EventArgs) Handles Garment.Click
        If Garment.BackColor = Color.White Then
            Garment.BackColor = Color.Red
            Garment.ForeColor = Color.White
        Else
            Garment.BackColor = Color.White
            Garment.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Underwear_Click(sender As System.Object, e As System.EventArgs) Handles Underwear.Click
        If Underwear.BackColor = Color.White Then
            Underwear.BackColor = Color.Red
            Underwear.ForeColor = Color.White
        Else
            Underwear.BackColor = Color.White
            Underwear.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Tattoo_Click(sender As System.Object, e As System.EventArgs) Handles Tattoo.Click
        If Tattoo.BackColor = Color.White Then
            Tattoo.BackColor = Color.Red
            Tattoo.ForeColor = Color.White
        Else
            Tattoo.BackColor = Color.White
            Tattoo.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SexToy_Click(sender As System.Object, e As System.EventArgs) Handles SexToy.Click
        If SexToy.BackColor = Color.White Then
            SexToy.BackColor = Color.Red
            SexToy.ForeColor = Color.White
        Else
            SexToy.BackColor = Color.White
            SexToy.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Furniture_Click(sender As System.Object, e As System.EventArgs) Handles Furniture.Click
        If Furniture.BackColor = Color.White Then
            Furniture.BackColor = Color.Red
            Furniture.ForeColor = Color.White
        Else
            Furniture.BackColor = Color.White
            Furniture.ForeColor = Color.Black
        End If
    End Sub






    Private Sub InfoTimer_Tick(sender As System.Object, e As System.EventArgs) Handles InfoTimer.Tick

        LblInfo.Text = SysMessage

        InfoTick -= 1

        If InfoTick < 1 Then
            LblInfo.Text = ""
            InfoTimer.Stop()
        End If


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

        Try
            TagDir = Directory.GetParent(TagDir).ToString
            Debug.Print(TagDir)
            WBDommeTag.Navigate(TagDir)
        Catch
            TagDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
            WBDommeTag.Navigate(TagDir)
        End Try


    End Sub

   


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        WBDommeTag.GoBack()
    End Sub

    Private Sub WBDommeTag_Navigated(sender As Object, e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WBDommeTag.Navigated
        Dim URLText As String = WBDommeTag.Url.AbsolutePath
        URLText = URLText.Replace("/", "\")
        URLText = URLText.Replace("%20", " ")
        TBURL.Text = URLText

        My.Settings.LastDomTagURL = URLText
        Debug.Print(My.Settings.LastDomTagURL)
        My.Settings.Save()

        'If WBDommeTag.CanGoBack Then
        'BTNBack.Enabled = True
        'Else
        'BTNBack.Enabled = False
        'End If
        FormLoading = True
        comboDrive.Text = TBURL.Text.Substring(0, 1) & ":\"
        FormLoading = False

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles BTNBack.Click
        'WBDommeTag.GoBack()

        Try
            TagDir = Directory.GetParent(My.Settings.LastDomTagURL).ToString
            Debug.Print(TagDir)
            WBDommeTag.Navigate(TagDir)
        Catch
        End Try

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub comboDrive_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comboDrive.SelectedIndexChanged

        If FormLoading = False Then
            Try
                WBDommeTag.Navigate(comboDrive.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
End Class