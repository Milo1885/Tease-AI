Public Class FrmSplash

	Dim ProgressSteps As Integer = 0

	Public Sub UpdateText(displayText As String)
		If InvokeRequired Then
			Me.BeginInvoke(Sub() UpdateText(displayText))
			Exit Sub
		End If

		LBLSplash.Text = displayText
		ProgressSteps += 1
		If PBSplash.Value < PBSplash.Maximum Then PBSplash.Value += 1

		Refresh()

	End Sub

	Private Sub FrmSplash_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		If Debugger.IsAttached AndAlso PBSplash.Value <> PBSplash.Maximum Then
			MessageBox.Show(Me, "Progressbar maximum value needs to be readjusted. " & ProgressSteps & " steps have been executed.")
		End If
	End Sub

	Private Sub LBLSplash_TextChanged(sender As Object, e As EventArgs) Handles LBLSplash.TextChanged
#If TRACE Then
		Trace.WriteLine(LBLSplash.Text)
#End If
	End Sub
End Class