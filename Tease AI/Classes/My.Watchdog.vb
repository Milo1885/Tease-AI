Imports System
Imports System.Threading
Imports System.ComponentModel


Namespace My

	''' <summary>
	''' This Class is a simple Time-Out-Watchdog-Timer to monitor if a thread is responding.
	''' </summary>
	Friend Class WatchDog
		Implements IDisposable

		''' <summary>
		''' Aborts the Monitoring and closes the Watchdog-thread.
		''' </summary>
		<DebuggerStepThrough>
		Public Sub Dispose() Implements IDisposable.Dispose
			If _WatchDogThread IsNot Nothing Then
				_WatchDogThread.Abort()
				_WatchDogThread = Nothing
			End If
		End Sub

		''' <summary>
		''' Delegat for the <see cref="WatchDogReset"/>-Event.
		''' </summary>
		''' <param name="sender">The instance which requested the reset.</param>
		''' <param name="e"></param>
		Public Delegate Sub WatchDogResetDel(sender As Object, e As EventArgs)
		''' <summary>
		''' Occurs when the watchdog is not reset within a certain time.
		''' </summary>
		Public Event WatchDogReset As WatchDogResetDel
		''' <summary>
		''' This Method triggers the <see cref="WatchDogReset"/>-Event.
		''' </summary>
		''' <param name="e"></param>
		<DebuggerStepThrough>
		Private Sub onWatchDogReset(e As EventArgs)
			RaiseEvent WatchDogReset(Me, e)
		End Sub


		Private asyncOp As AsyncOperation
		''' <summary>
		''' Stores the ThreadObject the Watchdogloop is running on.
		''' </summary>
		Private _WatchDogThread As Threading.Thread
		''' <summary>
		''' Stores teh Name assigned to the Thread
		''' </summary>
		Private _ThreadName As String = ""
		''' <summary>
		''' Stores the Timeoutvalue für the current cycle.
		''' </summary>
		Private _Timeout As Integer
		''' <summary>
		''' This Reset Evetn is used, to detect a not responding reaction.
		''' </summary>
		Private _mreWatchDog As New ManualResetEvent(True)

		''' <summary>
		''' Initializes the Watchdog Class. To start monitoring call Reset(integer). 
		''' </summary>
		''' <param name="threadName">This Name will be assigned to the BackgroundThread.</param>
		<DebuggerStepThrough>
		Sub New(ByVal Optional threadName As String = "WatchDog-Thread")
			_ThreadName = threadName

			' Create a new thread to monitro the calling thread.
			_WatchDogThread = New Thread(AddressOf WatchDogDoWork) With
				{
					.IsBackground = True,
					.Priority = ThreadPriority.BelowNormal,
					.Name = _ThreadName
				}

			asyncOp = AsyncOperationManager.CreateOperation(Nothing)
		End Sub

		''' <summary>
		''' Resets the current Watchdog cycle. 
		''' the 
		''' </summary>
		''' <param name="timeout">The time in ms to wait before triggering the <see cref="WatchDogReset"/></param>
		<DebuggerStepThrough>
		Friend Overridable Sub Reset(timeout As Integer)
			'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
			'											Thread to monitor
			' Check if the timout is valid. to avoid an endless-lopp on the WatchDogThread.
			If timeout < 1 Then Throw New Exception("Values below 1 microsecond are not allowed")
			_Timeout = timeout

			' Start the Monitoring-Thread
			If _WatchDogThread IsNot Nothing AndAlso _WatchDogThread.IsAlive = False Then
				_WatchDogThread.Start()
			End If

			' Signal the Monitoring Thread: All fine, i'm still here.
			_mreWatchDog.Set()
			'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
		End Sub

		<DebuggerStepThrough>
		Private Sub WatchDogDoWork()
			'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
			'											WatchDog-Thread
			Try
DoWorkLoop:
				If _mreWatchDog.WaitOne(New TimeSpan(0, 0, 0, 0, _Timeout)) = False Then
					' Timeout on waiting... Raise the Event to force an action
					asyncOp.Post(New SendOrPostCallback(AddressOf onWatchDogReset), New EventArgs)
				Else
					' Received signal from other Thread. Everything is fine. 
					_mreWatchDog.Reset()
				End If

				GoTo DoWorkLoop
			Catch ex As ThreadAbortException
				Thread.ResetAbort()
			End Try
			'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
		End Sub

	End Class


End Namespace
