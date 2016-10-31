Public Class dbgSessionForm
	Private Sub dbgForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TmrUpdate.Start()
	End Sub

	Private Sub TmrUpdate_Tick(sender As Object, e As EventArgs) Handles TmrUpdate.Tick
		PropertyGrid1.SelectedObject = My.Application.Session.Clone()

	End Sub
End Class