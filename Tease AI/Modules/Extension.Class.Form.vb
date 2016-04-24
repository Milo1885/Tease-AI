'===========================================================================================
'
'                                Extensions.Class.Forms
'
'
' This File contains Functions to extend the functionallity of the Windows.Forms.Form-Class.
'
' Implemented this far:
'
' Form.UIThread(Action) + 2 Overloads	
'		This functions are intended to syimplify access to a Control-inheriting-class from
'		within another thread, without any delegates. Beware of the Consequences, if
'		you use this Code in order to prevent deadlocks. This DOES NOT replace Events to 
'		pass Parameters between Threads at all.
'		
'		Simpliest Example?:
'
'		You start a Thread in your Form-UI-Thread and wait for it to complete in a
'		loop. In the started Thread you Invoke(!) a Function to retrieve a Value. But the 
'		UI-Thread is busy waiting for the started Thread to finish. So each one will wait 
'		until the other other is finished - Or the User Ends the deadlocked freezed program.
'		
'		Right now this Is only applied To Class Windows.Forms.Form.
'		
'		Original Code-Source: http://www.codeproject.com/Articles/37642/Avoiding-InvokeRequired
'===========================================================================================

''' <summary>
''' This Module addes Extension Methods and Funtions, to enhance the Class 
''' <see cref="Windows.Forms.Form">Windows.Forms.Form.</see>/>. This will affect 
''' all instances of the current Solution.
''' </summary>
<HideModuleName>
Public Module ExtensionsClassForm

	''' =========================================================================================================
	''' <summary>
	''' This starts a procedure on the thread the Form was created in.
	''' <para>Use this with caution, in order to prevent any Deadlocks or DataCorruption.
	''' This Funtion is using Invoke! This will prevent the calling thread from continuing, 
	''' until the given Code has been executed.</para>
	''' </summary>
	''' <param name="Form"></param>
	''' <param name="code">The Code that has to be invoked.</param>
	<System.Runtime.CompilerServices.Extension>
	Public Sub UIThread(Form As Form, code As Action)
		If Form.InvokeRequired Then
			Form.Invoke(code)
			Return
		End If
		code.Invoke()
	End Sub

	''' =========================================================================================================
	''' <summary>
	''' <para>This starts a Function on the thread the Form was created in.</para>
	''' Use this with caution, in order to prevent any Deadlocks or DataCorruption. 
	''' This Funtion is using Invoke! This will prevent the calling thread from continuing, 
	''' until the given Code has been executed.
	''' </summary>
	''' <param name="Form"></param>
	''' <param name="code">The Code that has to be invoked.</param>
	''' <returns>Returns whatever the Code is returning..</returns>
	''' <remarks>
	''' </remarks>
	<System.Runtime.CompilerServices.Extension>
	Public Function UIThread(Form As Form, code As Func(Of Object)) As Object
		If Form.InvokeRequired Then
			Return Form.Invoke(code)
		End If
		Return code.Invoke()
	End Function

	''' =========================================================================================================
	''' <summary>
	''' This starts a procedure on the thread the Form was created in. 
	''' <para>Use this with caution, in order to prevent any Deadlocks or DataCorruption.</para>
	''' </summary>
	''' 
	''' <param name="Form"></param>
	''' <param name="code">The Code that has to be invoked.</param>
	''' <param name="execAsync">Set this parameter to TRUE, if you want to exceute the Code via BeginInvoke.</param>
	''' <remarks>
	''' BeginInoke is only possible, if the calling thread is another thread than the Form-Owning-Thread.
	''' </remarks>
	<System.Runtime.CompilerServices.Extension>
	Public Function UIThread(Form As Form, code As Func(Of Object), execAsync As Boolean) As Object
		If execAsync = False Then

			If Form.InvokeRequired Then
				Return Form.Invoke(code)
			End If
			Return code.Invoke()
		Else
			If Form.InvokeRequired Then
				Return Form.BeginInvoke(code)
			End If
			Return code.Invoke()
		End If
	End Function
End Module