'===========================================================================================
'
'                                       TeaseAI - Timer
'
'
'      This File contains all Functions regarding the Custom TimerClass for Tease-AI.
'
' This is a Quick and Dirty Fix, to prevent Timers from triggering oneself over and over
' again, if the TickEventHandler is running long procedures.
' Now the Timer remembers, if the Tickeventhadnler has already returned from the EventHandler.
' If it hasn't it will skip this Tick.
' This is no permanent Fix, because multiple Timers ar overwiting each others work.
'===========================================================================================

''' =========================================================================================================
''' <summary>
''' Advanced Timer Class to prevent triggering the Tick-Event, when the last 
''' TickEveventhandler has not yet been completed.
''' </summary>
''' <remarks>
''' Without this functionallity, an StacckoverflowException can occur, when running in 
''' DebugMode or on slow computers.
''' </remarks>
Public Class teaseAI_Timer
	Inherits System.Windows.Forms.Timer

	''' =========================================================================================================
	''' <summary>
	''' Remembers the State if an Tick is still in process.
	''' </summary>
	Private _TickIsRunning As Boolean = False

	''' =========================================================================================================
	''' <summary>
	''' This procedure overrides <see cref="System.Windows.Forms.Timer.OnTick">OnTick(e)</see> of the inherited Class, 
	''' to Stop the Timer before triggering <see cref="System.Windows.Forms.Timer.tick">Tick</see>. After processing 
	''' the Event the timer will start again automatically.
	''' </summary>
	''' <param name="e"></param>
	''' <remarks> Otherwise, it may happen that the event is triggered multiple times and slows down the processing 
	''' of the  preceding. Since then the event is triggered again and again and the preceding slows again, a 
	''' <see cref="StackOverflowException ">StackOverflowException</see> will take place.
	''' </remarks>
	Protected Overrides Sub OnTick(e As EventArgs)
		If Me._TickIsRunning = True Then Exit Sub
		Try
			' Set reminder, to indicate the Eventhandler is running.
			Me._TickIsRunning = True
			' Start the sub, wich is triggering the Tick-Event 
			MyBase.OnTick(e)
		Catch ex As StackOverflowException
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Debug.Print("Error in Timer.Tick: " & ex.Message & vbCrLf & ex.StackTrace)
		Finally
			'⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
			' No matter what happens: We HAVE to reset the Value, otherwise the Timer will never ever "tick" again!
			Me._TickIsRunning = False
		End Try

	End Sub
End Class