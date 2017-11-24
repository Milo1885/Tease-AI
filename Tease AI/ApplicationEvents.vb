Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
	' The following events are available for MyApplication:
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication

		''' <summary>
		''' The currently non syncronized running session.
		''' </summary>
		Shared _Session As SessionState
		Shared _SessionSynclock As New Object

		Friend Property Session As SessionState
			Get
				SyncLock _SessionSynclock
					Return _Session
				End SyncLock
			End Get
			Set(value As SessionState)
				SyncLock _SessionSynclock
					_Session = value
				End SyncLock
			End Set
		End Property

		Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
			Trace.Listeners.Add(New Log.TextTraceListener("log.txt"))
			Trace.WriteLine("Application V" & Application.Info.Version.ToString & " started")

            ' Load or import a specific user.config-file.
            MySettings.StartupCheck()

			Session = New SessionState
		End Sub

		''' =========================================================================================================
		''' <summary>
		''' Prints an Exception entry in the chatwindow if Form1 is available. This function uses INVOKE on Form1.
		''' </summary>
		''' <param name="msg">Represents a clear text message to display.</param>
		''' <param name="ex">The occurred exception.</param>
		Public Sub HandledException(msg As String, ex As Exception)
			If Form1 Is Nothing Then Exit Sub
			If Form1.IsHandleCreated = False Then Exit Sub

			If Form1.InvokeRequired Then
				Form1.Invoke(Sub() HandledException(msg, ex))
				Exit Sub
			End If

			Form1.ChatAddException(msg, ex)

		End Sub


	End Class
End Namespace
