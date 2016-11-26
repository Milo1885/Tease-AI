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
            ' Load or import a specific user.config-file.
            MySettings.StartupCheck()

			Session = New SessionState
		End Sub

	End Class
End Namespace
