Imports System.ComponentModel
''' <summary>
''' BackgroundWorker-Class to raise the RunWorkerCompleted-Event manually.
''' </summary>
Public Class BackgroundWorkerSyncable
	Inherits BackgroundWorker

	Private _Workerthread As Threading.Thread = Nothing

#Region "-----------------------------------------------  Trigger Required -----------------------------------------------------"

	Private _TriggerRequired As Boolean = True

	Public ReadOnly Property TriggerRequired As Boolean
		Get
			Return _TriggerRequired
		End Get
	End Property

#End Region ' Sync Required

#Region "-------------------------------------------------- Trigger Timer ------------------------------------------------------"

	Private WithEvents TriggerTimer As New Timer With {.Interval = 30000}


	Private Sub TriggerTimer_Tick(sender As Object, e As EventArgs) Handles TriggerTimer.Tick
		TriggerTimer.Stop()
		Debug.Print("@ @ @ @ @ @ @ @ @ @ @ @ @ @ Forced BW Event-Trigger @ @ @ @ @ @ @ @ @ @ @ @ @ @")
		Debug.Print("Make sure to trigger the RunWorkerCompleted-Event when activating manual Trigger!")

		Dim lazytext As String = "A forced Event-Triggering in the BackGroundWorker was accomplished. " &
								"Make sure to trigger the event, when you start the BackgroundWorker, " &
								"with option manual Event-Triggering."
		Log.WriteError(lazytext, New TimeoutException(lazytext), "Forced-RunWorkerCompleted Trigger")

		MyBase.OnRunWorkerCompleted(New RunWorkerCompletedEventArgs(
									Nothing,
									New TimeoutException("This Event has been forced Triggered. Make sure " &
									"to trigger the RunWorkerCompleted-Event when activating manual Trigger!"),
									True))
		Reset()
	End Sub

#End Region

#Region " - ------------------------------------------------MyBaseRelated - ------------------------------------------------------"

	''' =========================================================================================================
	''' <summary>
	''' Gets a value indicating whether the BackgroundWorker is running an asynchronous operation or delaying the
	''' RunWorkerCompleted-Event.
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Shadows ReadOnly Property isBusy As Boolean
		Get
			If MyBase.IsBusy Or _ResultCache IsNot Nothing Then
				Return True
			Else
				Return False
			End If
		End Get
	End Property

	''' =========================================================================================================
	''' <summary>
	''' Starts the Bachgroundworker async.
	''' </summary>
	''' <remarks></remarks>
	''' <exception cref="InvalidOperationException">Occurs if you try to start a new thread, without syncing the 
	''' previous results.</exception>
	Public Shadows Sub RunWorkerAsync(Obj As Object, Optional ByVal SyncRequired As Boolean = True)
		'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
		'											 Calling-Thread
		If _ResultCache IsNot Nothing Then Throw New InvalidOperationException("Starting Is Not allowed while a previous result Is cached.")
		_TriggerRequired = SyncRequired
		MyBase.RunWorkerAsync(Obj)
		'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	End Sub
	''' <summary>
	''' Triggers the <see cref="DoWork"/> Event.
	''' </summary>
	''' <param name="e"></param>
	Protected Overrides Sub OnDoWork(e As DoWorkEventArgs)
		'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
		'											BackgroundWorker-Thread
		_Workerthread = Threading.Thread.CurrentThread
		Try
			MyBase.OnDoWork(e)
		Catch ex As Threading.ThreadAbortException
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'	                                    Thread has been Aborted
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			e.Cancel = True
			'We must set Cancel property to true!
			'Prevents ThreadAbortException propagation
			Threading.Thread.ResetAbort()
		End Try
		_Workerthread = Nothing
		'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	End Sub

	''' <summary>
	''' 
	''' </summary>
	''' <param name="e"></param>
	Protected Overrides Sub OnRunWorkerCompleted(e As RunWorkerCompletedEventArgs)
		'×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
		'											 Calling-Thread
		If TriggerRequired And e.Cancelled = False Then
			' Delay the RunWorkerComplete-Event
			TriggerTimer.Start()
			_ResultCache = e
		Else
			' No delayed EventTriggering
			' Or the work has been cancelled or aborted.
			MyBase.OnRunWorkerCompleted(e)
		End If
		'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Thread °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	End Sub

#End Region  ' MyBase-Related

#Region "------------------------------------------------- Sync Members --------------------------------------------------------"

	''' <summary>
	''' caches the result of the DoWork.Event, when _SyncReqired = True  
	''' </summary>
	''' <remarks></remarks>
	Private _ResultCache As RunWorkerCompletedEventArgs = Nothing
	''' <summary>
	''' Raises the RunWorkerCompled-Event, when the process in me.DoWork has been
	''' finished. Otherwise this function starts a Application.DoEvents-Loop on 
	''' the calling thread until the BackgroundWorker has finished or the given 
	''' Time has elapsed.
	''' </summary>
	''' <param name="Timeout">Time to wait in seconds, before the timeout occurs. After 
	''' a Timeout the RunWorkerCompleted-Event will will be raised with it's e.Cancelled=true.
	''' If the BackgroundWorker Supports Canceellation the thread is cancceled, otherwise
	''' the backgroundworker is aborted.
	''' </param>
	''' <remarks>If a Timeout occurs, CancelAsnyc() is called.</remarks>
	''' <exception cref="TimeoutException">Occurs if the given time has elapsed.</exception>
	''' <exception cref="Exception">Rethrows all exceptions occured in me.DoWork!</exception>
	Public Sub WaitToFinish(Optional ByVal Timeout As Integer = 20)
		' Declare new Stopwatch Instance for measering time 
		Dim sw As New Stopwatch
		' Start it, when a timeout is set.
		If Timeout > 0 Then sw.Start()

		' Wait until the Background worker has done his work.
		Do While MyBase.IsBusy
			' =============================== Timeout ==================================
			If sw.ElapsedMilliseconds > Timeout * 1000 Then
				'Stop the Watch
				sw.Stop()

				Dim Lazytext As String = "Timeout while waiting for the Backgroundworker to Finish."
				Log.WriteError(Lazytext, New TimeoutException(Lazytext), "WaitToFinish(Intger)")

				' Stop the Backgroundworker.
				StopAsync()
				Exit Do
				'Throw New TimeoutException("Timeout occured during Syncing ThreadResults.")
			End If
			' Don't block the calling thread.
			Application.DoEvents()
		Loop
		If _ResultCache Is Nothing Then Exit Sub
		' if an Error occured in BGW.DoWork the Error is "rethrown" here.
		'QnD-Bugfix: 404 caused scripts to stop
		'If Me._ResultCache.Error IsNot Nothing Then Throw Me._ResultCache.Error
		MyBase.OnRunWorkerCompleted(_ResultCache)
		Reset()
	End Sub

	''' <summary>
	''' Cancels the current Thread, manual Triggering and deletes all fetched data.
	''' </summary>
	''' <remarks></remarks>
	Public Sub StopAsync()
		'TODO: StopAsync() implement wait timeout.
		If WorkerSupportsCancellation _
		Then CancelAsync() _
		Else AbortAsync()

		Do Until MyBase.IsBusy = False 'OrElse (_Workerthread IsNot Nothing AndAlso _Workerthread.ThreadState = Threading.ThreadState.Aborted)
			Application.DoEvents()
		Loop
		Reset()
	End Sub

	''' <summary>
	''' Aborts the BackgroundThread.
	''' </summary>
	Public Sub AbortAsync()
		If _Workerthread IsNot Nothing Then
			_Workerthread.Abort()
		End If
	End Sub

	Private Sub Reset()
		If TriggerTimer.Enabled Then TriggerTimer.Stop()
		_ResultCache = Nothing
		_TriggerRequired = False
	End Sub

#End Region  ' Sync-Members

End Class