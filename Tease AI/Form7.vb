Public Class Form7

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        My.Settings.TC2Agreed = True
        My.Settings.Save()

        Me.Close()
        Me.Dispose()


        'ClearAgree()


    End Sub


  


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
        FrmSplash.LBLSplash.Text = "Closing program..."
        FrmSplash.Refresh()
        Application.Exit()
        End


    End Sub
End Class