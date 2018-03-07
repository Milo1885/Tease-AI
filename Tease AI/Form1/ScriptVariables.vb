'===========================================================================================
'
'									 ScriptVariables.vb.vb
'
' This file contains functions and methods to handle script Variables.
' 
'===========================================================================================
Imports System.IO

Partial Public Class Form1

	Public Function VariableFolder() As String
		VariableFolder = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\"
		Directory.CreateDirectory(VariableFolder)
	End Function

	Public Function VariableExists(varName As String)

		Return File.Exists(Path.Combine(VariableFolder, varName))

	End Function


	Public Sub SetVariable(ByVal varName As String, ByVal value As String)

		My.Computer.FileSystem.WriteAllText(Path.Combine(VariableFolder, varName), value, False)

	End Sub

	Public Function GetVariable(ByVal varName As String) As String

		If VariableExists(varName) Then
			Return TxtReadLine(Path.Combine(VariableFolder, varName))
		Else
			Return 0
		End If

	End Function

	Public Sub DeleteVariable(ByVal varName As String)

		File.Delete(Path.Combine(VariableFolder, varName))

	End Sub

	Public Function ChangeVariable(ByVal varName As String, ByVal operand1 As String, ByVal mathOperator As String, ByVal operand2 As String)
		Dim Val1, Val2, Result As Integer

		' Integer.TryParse will return 0 if conversion failed.
		If Integer.TryParse(operand1, Val1) = False Then
			If VariableExists(operand1) Then
				Integer.TryParse(GetVariable(operand1), Val1)
			End If
		End If

		If Integer.TryParse(operand2, Val2) = False Then
			If VariableExists(operand2) Then
				Integer.TryParse(GetVariable(operand2), Val2)
			End If
		End If

		If mathOperator.Contains("+") Then
			Result = Val1 + Val2
		ElseIf mathOperator.Contains("-") Then
			Result = Val1 - Val2
		ElseIf mathOperator.Contains("*") Then
			Result = Val1 * Val2
		ElseIf mathOperator.Contains("/") Then
			If Val2 = 0 Then
				Val2 = 1
				ChatAddWarning("""" & operand2 & """ has returned zero. Modified to ""1"" to avoid an DivideByZeroException.")
			End If
			Result = Val1 / Val2
		Else
			Result = 0
		End If

		SetVariable(varName, Result)

		Return Result
	End Function



	Public Function CheckVariable(ByVal StringCLean As String) As Boolean
		If StringCLean.Contains("]AND[") Then StringCLean = StringCLean.Replace("]AND[", "]And[")
		If StringCLean.Contains("]OR[") Then StringCLean = StringCLean.Replace("]OR[", "]Or[")
		Do

			Dim SCIfVar As String() = Split(StringCLean)
			Dim SCGotVar As String = "Null"

			For i As Integer = 0 To SCIfVar.Length - 1
				If SCIfVar(i).Contains("@Variable[") Then
					Dim IFJoin As Integer = 0
					If Not SCIfVar(i).Contains("] ") Then
						Do
							IFJoin += 1
							SCIfVar(i) = SCIfVar(i) & " " & SCIfVar(i + IFJoin)
							SCIfVar(i + IFJoin) = ""
						Loop Until SCIfVar(i).Contains("] ") Or SCIfVar(i).EndsWith("]")
					End If
					SCGotVar = SCIfVar(i).Trim
					SCIfVar(i) = ""
					StringCLean = Join(SCIfVar)
					Do
						StringCLean = StringCLean.Replace("  ", " ")
					Loop Until Not StringCLean.Contains("  ")
					Exit For
				End If
			Next

			If SCGotVar.Contains("]And[") Then

				Dim AndCheck As Boolean = True

				For x As Integer = 0 To SCGotVar.Replace("]And[", "").Count - 1
					If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = False Then
						AndCheck = False
						Exit For
					End If
					SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]And", "")
				Next

				Return AndCheck

			ElseIf SCGotVar.Contains("]Or[") Then

				Dim OrCheck As Boolean = False

				For x As Integer = 0 To SCGotVar.Replace("]Or[", "").Count - 1
					If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = True Then
						OrCheck = True
						Exit For
					End If
					SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]Or", "")
				Next

				Return OrCheck

			Else

				If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = True Then

					Return True

				Else

					Return False

				End If

			End If

		Loop Until Not StringCLean.Contains("@Variable")


	End Function

#Region "---------------------------------------- Script-Dates ------------------------------------------"

	Public Function GetDate(ByVal VarName As String) As Date

		If VariableExists(VarName) Then
			Date.TryParse(GetVariable(VarName), GetDate)
		Else
			Return FormatDateTime(Now, DateFormat.GeneralDate)
		End If

	End Function

	Public Function GetTime(ByVal VarName As String) As String

		Return GetDate(VarName).ToLongTimeString

	End Function

	Public Function CheckDateList(ByVal DateString As String, Optional ByVal Linear As Boolean = False) As Boolean

		Dim DateFlag As String = GetParentheses(DateString, "@CheckDate(")

		If DateFlag.Contains(",") Then

			DateFlag = FixCommas(DateFlag)

			Dim DateArray() As String = DateFlag.Split(",")
			Dim DDiff As Long = 18855881
			Dim DDiff2 As Long = 18855881

			Dim DCompare As Long
			Dim DCompare2 As Long

			If Linear = False Then

				If DateArray.Count = 2 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					If DDiff >= DCompare Then Return True
					Return False
				End If

				If DateArray.Count = 3 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					DDiff2 = GetDateDifference(DateArray(0), DateArray(2))
					DCompare2 = GetDateCompare(DateArray(0), DateArray(2))
					If DDiff >= DCompare And DDiff2 <= DCompare2 Then Return True
					Return False
				End If

			Else

				If DateArray.Count = 2 Then
					If CompareDatesWithTime(GetDate(DateArray(0))) <> 1 Then Return True
					Return False
				End If

				If DateArray.Count = 3 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					If DDiff >= DCompare Then Return True
					Return False
				End If

				If DateArray.Count = 4 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					DDiff2 = GetDateDifference(DateArray(0), DateArray(2))
					DCompare2 = GetDateCompare(DateArray(0), DateArray(2))
					If DDiff >= DCompare And DDiff2 <= DCompare2 Then Return True
					Return False
				End If

			End If

		Else
			If CompareDatesWithTime(GetDate(DateFlag)) <> 1 Then Return True
			Return False
		End If

		Return False

	End Function

	Public Function GetDateDifference(ByVal DateVar As String, ByVal DateString As String) As Long

		Dim DDiff As Long = 0

		If UCase(DateString).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateVar), Now)
		If UCase(DateString).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateVar), Now) * 60
		If UCase(DateString).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateVar), Now) * 3600
		If UCase(DateString).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateVar), Now) * 86400
		If UCase(DateString).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateVar), Now) * 604800
		If UCase(DateString).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateVar), Now) * 2629746
		If UCase(DateString).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateVar), Now) * 31536000

		Return DDiff

	End Function

	Public Function GetDateCompare(ByVal DateVar As String, ByVal DateString As String) As Long

		Dim DDiff As Long = 0
		Dim Amount As Long = Val(DateString)

		If UCase(DateString).Contains("SECOND") Then DDiff = Amount
		If UCase(DateString).Contains("MINUTE") Then DDiff = Amount * 60
		If UCase(DateString).Contains("HOUR") Then DDiff = Amount * 3600
		If UCase(DateString).Contains("DAY") Then DDiff = Amount * 86400
		If UCase(DateString).Contains("WEEK") Then DDiff = Amount * 604800
		If UCase(DateString).Contains("MONTH") Then DDiff = Amount * 2629746
		If UCase(DateString).Contains("YEAR") Then DDiff = Amount * 31536000

		Return DDiff

	End Function

#End Region ' Script-Dates




End Class
