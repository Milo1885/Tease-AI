'===========================================================================================
'
'									 Chat.vb
'
' This file contains functions and methods to write and update the Chat.
' 
'===========================================================================================

Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions


Partial Class Form1

	Private Sub SaveChatLog(ByVal IsAutosave As Boolean)
		If ChatText.DocumentText.Length > 300 Then
			Dim SaveDir As String = Application.StartupPath & "\Chatlogs\"


			If (Not IO.Directory.Exists(SaveDir)) Then
				IO.Directory.CreateDirectory(SaveDir)
			End If

			If IsAutosave = True And FrmSettings.CBAutosaveChatlog.Checked = True Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

			ElseIf IsAutosave = False And FrmSettings.CBSaveChatlogExit.Checked = True Then
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\" & DateTime.Now.ToString("MM.dd.yyyy hhmm") & " chatlog.html", ChatText.DocumentText, False)
			End If

		End If
	End Sub

	Private Function ChatGetCssClassFromName(ByVal name As String) As String
		If name = My.Settings.SubName Then
			Return "sub"
		ElseIf name = My.Settings.DomName Then
			Return "domme"
		ElseIf name = My.Settings.Glitter1 Then
			Return "contact1"
		ElseIf name = My.Settings.Glitter2 Then
			Return "contact2"
		ElseIf name = My.Settings.Glitter3 Then
			Return "contact3"
		Else
			Return "random"
		End If
	End Function

	Public Sub ChatAddMessage(ByVal name As String, message As String, Optional ByVal delayOutput As Boolean = False)
		ChatAppend("<div class=""message"">
	<div class=""" & ChatGetCssClassFromName(name) & """>
		<span class=""timestamp"">" & (Date.Now.ToString("hh:mm tt ")) & "</span>
		<span class=""name"">" & name & ": </span>
		<span class=""text"">" & message & "</span>
	</div>
</div>" & vbCrLf, delayOutput)
	End Sub

	Public Sub ChatAddEmoteMessage(ByVal name As String, message As String, Optional ByVal delayOutput As Boolean = False)
		ChatAppend("<div class=""emoteMessage"">
    <div class=""" & ChatGetCssClassFromName(name) & """>
		<span class=""timestamp"">" & (Date.Now.ToString("hh:mm tt ")) & "</span>
		<span class=""name"">" & name & ": </span>
		<span class=""text"">" & message & "</span>
	</div>
</div>" & vbCrLf, delayOutput)
	End Sub

	''' <summary>Appends a system message to chat and prints it if desired. </summary>
	''' <param name="messageText">Messagetext to append to chat.</param>
	''' <param name="delayOutput">If true the chatwindow-content won't change until despired.</param>
	Public Sub ChatAddSystemMessage(ByVal messageText As String, Optional ByVal delayOutput As Boolean = False)
		ChatAppend("<div class=""systemMessage"">
	<span>
		" & messageText & "
	</span>
</div>", delayOutput)
	End Sub

	Public Sub ChatAddWritingTaskInfo(message As String, Optional delayOutput As Boolean = False)
		ChatAppend("<div class=""writingTaskInfo"">
	<span>
		" & message & "
	</span>
</div>", delayOutput, True)
	End Sub

	Public Sub ChatAddScriptPosInfo(descr As String, Optional delayOutput As Boolean = False)
		ChatAppend("<div class=""debugInfo"">
	<span>::: " & If(descr = "@", "TYPO", descr.Replace("@", "")) & " ::: <br>
		::: FileText = " & ssh.FileText & " ::: LineVal = " & ssh.StrokeTauntVal & "<br>
		::: TauntText = " & ssh.TauntText & " ::: LineVal = " & ssh.TauntTextCount & "<br>
		::: ResponseFile = " & ssh.ResponseFile & " ::: LineVal = " & ssh.ResponseLine & "
	</span>
</div>", delayOutput, True)
	End Sub

	Public Sub ChatAddException(msg As String, ex As Exception)
		ChatAppend("<div class=""exception"">
	<span class=""msg"">ERROR: " & msg & "</span>
	<span class=""exMessage"">::: Exception: " & ex.Message & "</span>
</div>", False, True)
	End Sub

	Public Sub ChatAppend(ByVal elementText As String,
					  Optional ByVal delayOutput As Boolean = False,
					  Optional ByVal linkify As Boolean = False)
		If linkify = True Then
			Dim re As New Regex("[a-zA-Z]:\\(((?![<>:""/\\|?*]).)+((?<![ .])\\)?)*")
			Dim ReplacePattern As String = "<a href=""file://$&"">$&</a>"

			elementText = re.Replace(elementText, ReplacePattern)
		End If

		ssh.Chat &= elementText & "" & vbCrLf
		If delayOutput = False Then Me.ChatUpdate()
	End Sub

	Public Sub ChatClear()
		ssh.Chat = ""
		ChatUpdate()
	End Sub

	Friend Sub ChatUpdate()
		If Me.InvokeRequired Then
			Me.Invoke(Sub() ChatUpdate())
			Exit Sub
		End If

		Dim DommeTyping, C1Typing, C2Typing, C3Typing, RndTyping As Boolean

		If ssh.IsTyping Then
			If ssh.tempDomName = My.Settings.DomName Then
				DommeTyping = True
			ElseIf ssh.tempDomName = My.Settings.Glitter1 Then
				C1Typing = True
			ElseIf ssh.tempDomName = My.Settings.Glitter2 Then
				C2Typing = True
			ElseIf ssh.tempDomName = My.Settings.Glitter3 Then
				C3Typing = True
			Else
				RndTyping = True
			End If
		End If

		'===============================================================================
		'							Generate stylesheet
		'===============================================================================
		Dim Style As String = CssTryGetFile(Application.StartupPath & "/System/CSS/ChatWindow.css", My.Resources.ChatFallbackStyle)
		Style = CssReplaceSettings(Style) & vbCrLf

		Style &=
"	/*				--- Visibility Section ---					*/
/* This section is generated by code and added automatically*/

.exception {" & If(My.Settings.CBOutputErrors, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
.writingTaskInfo {" & If(CBWritingProgress.Checked, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}

.timestamp { " & If(My.Settings.CBTimeStamps, "visibility: visible; display:initial;", "visibility:hidden; display:none") & "}
.name {" & If(My.Settings.CBShowNames, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
#DommeIsTyping {" & If(DommeTyping, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
#Contact1IsTyping {" & If(C1Typing, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
#Contact2IsTyping {" & If(C2Typing, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
#Contact3IsTyping {" & If(C3Typing, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}
#RandomIsTyping {" & If(RndTyping, "visibility:visible; display:initial;", "visibility:hidden; display:none") & "}"

		'===============================================================================
		'							Generate body Text
		'===============================================================================
		Dim BodyText As String = "<div id=""Chat"">" & vbCrLf & ssh.Chat & vbCrLf & "</div>" &
"<div id=""DommeIsTyping"">" & My.Settings.DomName & " is typing...</div>
<div id=""Contact1IsTyping"">" & My.Settings.Glitter1 & " is typing...</div>
<div id=""Contact2IsTyping"">" & My.Settings.Glitter2 & " is typing...</div>
<div id=""Contact3IsTyping"">" & My.Settings.Glitter3 & " is typing...</div>
<div id=""RandomIsTyping"">Unkwown user is typing...</div>"

		'===============================================================================
		'							Page Output
		'===============================================================================
		Try
			Dim GetLastMessage = Function(x As WebBrowser) As String
									 If x.Document Is Nothing Then Return ""

									 If x.Document.GetElementById("Chat") IsNot Nothing Then
										 With x.Document.GetElementById("Chat")
											 If .CanHaveChildren AndAlso .Children.Count > 0 Then

												 Return .Children(.Children.Count - 1).OuterHtml
											 End If
										 End With
									 End If
									 Return ""
								 End Function



			Dim TextToSet As String = HtmlBuildPage("Chat", Style, BodyText)

			Try
				If My.Settings.CBWebtease Then
					' ################### Webtease Mode ###########################
					Dim Helper As New WebBrowser
					Helper.DocumentText = TextToSet
					Do Until Helper.ReadyState = WebBrowserReadyState.Complete
						Application.DoEvents()
					Loop

					Dim LP As String = GetLastMessage(Helper)

					TextToSet = TextToSet.Replace(ssh.Chat, LP)
				End If
			Catch ex As Exception
				Log.WriteError("Unable to determine last chat message to create webtease output.", ex, "Output WebTease Chat failed")
			End Try

			ChatText.DocumentText = TextToSet
			ChatText2.DocumentText = TextToSet

			ChatReadyState()
			SaveChatLog(True)

			If ssh.RiskyDeal Then
				FrmCardList.WBRiskyChat.DocumentText = TextToSet.Replace(ssh.Chat, GetLastMessage(ChatText))
			End If

		Catch ex As COMException When ex.ErrorCode = -2147024726
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            Unable to access Webbrowser
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show("Unable to access the Webbrowser.",
					"Update Chat failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try
	End Sub

	Public Sub ScrollChatDown()

		Try
			ChatText.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try

		Try
			ChatText2.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try

	End Sub


	Shared Function HtmlBuildPage(title As String, style As String, bodyText As String) As String
		Return _
"<!doctype html>
<html>
<head>
	<title>" & title & " - Tease AI " & My.Application.Info.Version.ToString & "</title>
	<base href=""file://" & IO.Path.Combine(Application.StartupPath, "images").Replace("\", "/") & "/"">
	<style>
	" & style & "
	</style>
</head>
<body>
" & bodyText & "
</body></html>"
	End Function

	Private Function CssTryGetFile(filePath As String, fallback As String) As String

		If IO.Directory.Exists(IO.Path.GetDirectoryName(filePath)) AndAlso IO.File.Exists(filePath) Then
			Return IO.File.ReadAllText(filePath)
		Else
			Return fallback
		End If

	End Function

	Private Function CssReplaceSettings(ByVal input As String) As String
		Dim HtmlSizeToEm = Function(x As Integer) As String
							   If x <= 1 Then : Return "0.63em"
							   ElseIf x <= 2 Then : Return "0.82em"
							   ElseIf x <= 3 Then : Return "1.00em"
							   ElseIf x <= 4 Then : Return "1.13em"
							   ElseIf x <= 5 Then : Return "1.5em"
							   ElseIf x <= 6 Then : Return "2em"
							   ElseIf x <= 7 Then : Return "3em"
							   Else : Return "4em"
							   End If

						   End Function

		input = input.Replace("/*ChatWindowColor*/", Color2Html(My.Settings.ChatWindowColor))
		input = input.Replace("/*ChatTextColor*/", Color2Html(My.Settings.ChatTextColor))
		input = input.Replace("/*SubNameColor*/", My.Settings.SubColor)
		input = input.Replace("/*DommeNameColor*/", My.Settings.DomColor)
		input = input.Replace("/*Contact1NameColor*/", Color2Html(My.Settings.GlitterNC1Color))
		input = input.Replace("/*Contact2NameColor*/", Color2Html(My.Settings.GlitterNC2Color))
		input = input.Replace("/*Contact3NameColor*/", Color2Html(My.Settings.GlitterNC3Color))

		input = input.Replace("/*DommeFontSize*/", HtmlSizeToEm(My.Settings.DomFontSize))
		input = input.Replace("/*SubFontSize*/", HtmlSizeToEm(My.Settings.SubFontSize))

		input = input.Replace("/*DommeFontName*/", My.Settings.DomFont)
		input = input.Replace("/*SubFontName*/", My.Settings.SubFont)

		Return input
	End Function

#Region "WebBrowser related"

	Private Sub ChatText_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles ChatText.DocumentCompleted, ChatText2.DocumentCompleted
		ScrollChatDown()
	End Sub

	Public Sub ChatReadyState()
		While ChatText.ReadyState <> WebBrowserReadyState.Complete Or ChatText2.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ScrollChatDown()
	End Sub

	Private Sub ChatText_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles ChatText.Navigating, ChatText2.Navigating

		If e.Url.AbsolutePath <> "blank" Then
			If e.Url.IsFile Then
				ShellExecute(e.Url.LocalPath)
			Else
				ShellExecute(e.Url.AbsolutePath)
			End If
			e.Cancel = True
		End If

	End Sub
#End Region
End Class