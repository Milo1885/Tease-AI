Imports System.ComponentModel
''' <summary>
''' BackgroundWorker-Class to raise the RunWorkerCompleted-Event manually.
''' </summary>
Public Class BackgroundWorkerSyncable
	Inherits System.ComponentModel.BackgroundWorker


#Region "-----------------------------------------------  Trigger Required -----------------------------------------------------"

	Private _TriggerRequired As Boolean = True

	Public ReadOnly Property TriggerRequired As Boolean
		Get
			Return _TriggerRequired
		End Get
	End Property

#End Region ' Sync Required

#Region "-------------------------------------------------- Trigger Timer ------------------------------------------------------"

	Private WithEvents TriggerTimer As New Timer With {.Interval = 10000}


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
		If _ResultCache IsNot Nothing Then Throw New InvalidOperationException("Starting Is Not allowed while a previous result Is cached.")
		_TriggerRequired = SyncRequired
		_SyncTimeOut = False
		MyBase.RunWorkerAsync(Obj)
	End Sub

	Protected Overrides Sub OnRunWorkerCompleted(e As System.ComponentModel.RunWorkerCompletedEventArgs)
		If _SyncTimeOut Then
			' The BackgroundThread has taken too long. The waiting Thread has aborted.
			' ReWrtite the Result Argument and trigger the Event.
			_ResultCache = New RunWorkerCompletedEventArgs(_ResultCache.Result, _ResultCache.Error, True)
			MyBase.OnRunWorkerCompleted(_ResultCache)
		End If

		If TriggerRequired Then
			TriggerTimer.Start()
			_ResultCache = e
		Else
			MyBase.OnRunWorkerCompleted(e)
		End If
	End Sub

#End Region  ' MyBase-Related

#Region "------------------------------------------------- Sync Members --------------------------------------------------------"

	''' <summary>
	''' caches the result of the DoWork.Event, when _SyncReqired = True  
	''' </summary>
	''' <remarks></remarks>
	Private _ResultCache As System.ComponentModel.RunWorkerCompletedEventArgs = Nothing

	Private _SyncTimeOut As Boolean

	''' <summary>
	''' Raises the RunWorkerCompled-Event, when the process in me.DoWork has been
	''' finished. Otherwise this function starts a Application.DoEvents-Loop on 
	''' the calling thread until the BackgroundWorker has finished or an the given 
	''' Time has elapsed.
	''' </summary>
	''' <param name="Timeout">Time to wait in seconds, before the timeout occurs. After 
	''' a Timeout the RunWorkerCompleted-Event will not trigger and the Data processed 
	''' by the Backgroundthread is lost!</param>
	''' <remarks>If a Timeout occurs, CancelAsnyc() is called.</remarks>
	''' <exception cref="TimeoutException">Occurs if the given time has elapsed.</exception>
	''' <exception cref="Exception">Rethrows all exceptions occured in me.DoWork!</exception>
	Public Sub WaitToFinish(Optional ByVal Timeout As Integer = 0)
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
				' Set marker -> This will prevent triggering the RunWorkerCompleted
				' For this Current process.
				_SyncTimeOut = True
				' Cancel the Backgroundwork
				If Me.WorkerSupportsCancellation Then Me.CancelAsync()
				' Throw an Exception
				Throw New TimeoutException("Timeout occured during Syncing ThreadResults.")
			End If
			' Don't block the calling thread.
			Application.DoEvents()
		Loop
		If _ResultCache Is Nothing Then Exit Sub
		' if an Error occured in BGW.DoWork the Error is "rethrown" here.
		If Me._ResultCache.Error IsNot Nothing Then Throw Me._ResultCache.Error

		MyBase.OnRunWorkerCompleted(_ResultCache)
		Reset()
	End Sub

	''' <summary>
	''' Cancels the current Thread, manual Triggering and deletes all fetched data.
	''' </summary>
	''' <remarks></remarks>
	Public Sub CancelTrigger()
		If Me.WorkerSupportsCancellation = False Then Me.WorkerSupportsCancellation = True
		Me.CancelAsync()

		Do Until MyBase.IsBusy = False
			Application.DoEvents()
		Loop
		Reset()
		If MyBase.IsBusy = False Then MyBase.OnRunWorkerCompleted(New RunWorkerCompletedEventArgs(Nothing, Nothing, True))
	End Sub

	Private Sub Reset()
		If TriggerTimer.Enabled Then TriggerTimer.Stop()
		_ResultCache = Nothing
		_TriggerRequired = False
	End Sub

#End Region  ' Sync-Members

End Class