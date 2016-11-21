Public Class FrmSplash
	Private Sub LBLSplash_TextChanged(sender As Object, e As EventArgs) Handles LBLSplash.TextChanged
#If TRACE Then
		Trace.WriteLine(LBLSplash.Text)
#End If
	End Sub
End Class