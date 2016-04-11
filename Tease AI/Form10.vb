Public Class Form10

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        Dim PoolList As New List(Of String)

        For i As Integer = 0 To RTBFormat.Lines.Count - 1
            PoolList.Add(RTBFormat.Lines(i))
        Next

        Dim Pool As String = ""

        For i As Integer = 0 To PoolList.Count - 1
            Pool = Pool & PoolList(i) & " "
        Next

        My.Computer.Clipboard.SetText(Pool)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        WBDescription.DocumentText = My.Computer.Clipboard.GetText()
    End Sub

    Private Sub comboCommandType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comboCommandType.SelectedIndexChanged

        If comboCommandType.Text = "Commands" Then

            LBCommands.Items.Clear()

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\Commands.txt")

            For i As Integer = 0 To CommandList.Count - 3 Step 4
                LBCommands.Items.Add(CommandList(i))

            Next

        End If

        If comboCommandType.Text = "Command Filters" Then

            LBCommands.Items.Clear()

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\Command Filters.txt")

            For i As Integer = 0 To CommandList.Count - 3 Step 4
                LBCommands.Items.Add(CommandList(i))

            Next

        End If

        If comboCommandType.Text = "System Keywords" Then

            LBCommands.Items.Clear()

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\System Keywords.txt")

            For i As Integer = 0 To CommandList.Count - 3 Step 4
                LBCommands.Items.Add(CommandList(i))

            Next

        End If

    End Sub

    Private Sub LBCommands_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LBCommands.SelectedIndexChanged

        If comboCommandType.Text = "Commands" Then

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\Commands.txt")

            For i As Integer = 0 To CommandList.Count - 1
                If LBCommands.SelectedItem = CommandList(i) Then
                    LBLSyntax.Text = CommandList(i + 1)
                    LBLExample.Text = CommandList(i + 2)
                    WBDescription.DocumentText = CommandList(i + 3)
                    Exit For
                End If
            Next

        End If

        If comboCommandType.Text = "Command Filters" Then

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\Command Filters.txt")

            For i As Integer = 0 To CommandList.Count - 1
                If LBCommands.SelectedItem = CommandList(i) Then
                    LBLSyntax.Text = CommandList(i + 1)
                    LBLExample.Text = CommandList(i + 2)
                    WBDescription.DocumentText = CommandList(i + 3)
                    Exit For
                End If
            Next

        End If

        If comboCommandType.Text = "System Keywords" Then

            Dim CommandList As New List(Of String)
            CommandList = Form1.Txt2List(Application.StartupPath & "\System\System Keywords.txt")

            For i As Integer = 0 To CommandList.Count - 1
                If LBCommands.SelectedItem = CommandList(i) Then
                    LBLSyntax.Text = CommandList(i + 1)
                    LBLExample.Text = CommandList(i + 2)
                    WBDescription.DocumentText = CommandList(i + 3)
                    Exit For
                End If
            Next

        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        RTBFormat.Text = ""
    End Sub
End Class