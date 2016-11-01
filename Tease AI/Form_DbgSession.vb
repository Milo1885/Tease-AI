Public Class dbgSessionForm

	Private Sub dbgForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TmrUpdate.Start()
		PropertyGrid1.SelectedObject = My.Application.Session
	End Sub

	Private Sub TmrUpdate_Tick(sender As Object, e As EventArgs) Handles TmrUpdate.Tick
		' Check if Session has been disposed and if so update object reference.
		If PropertyGrid1.SelectedObject IsNot Nothing _
		AndAlso TypeOf (PropertyGrid1.SelectedObject) Is SessionState _
		AndAlso CType(PropertyGrid1.SelectedObject, SessionState).IsDisposed = True Then
			If My.Application.Session IsNot Nothing Then
				PropertyGrid1.SelectedObject = My.Application.Session
			Else
				PropertyGrid1.SelectedObject = Nothing
			End If
		End If

		PropertyGrid1.Refresh()
	End Sub
End Class