''' <summary>
''' String comparer to sort of string Lists and Arrays in logical order.
''' </summary>
''' <remarks>
''' This Class needs access to shlwapi.dll and sorts files like the windows file explorer does.
''' </remarks>
Public Class LogicalStringComparer
	Implements System.Collections.Generic.IComparer(Of String)
	Implements System.Collections.IComparer

	Declare Unicode Function StrCmpLogicalW Lib "shlwapi.dll" (
												ByVal s1 As String,
												ByVal s2 As String) As Int32

	Public Function Compare(ByVal x As String, ByVal y As String) As Integer _
	Implements System.Collections.Generic.IComparer(Of String).Compare

		Return StrCmpLogicalW(x, y)

	End Function

	Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
	Implements System.Collections.IComparer.Compare

		Return StrCmpLogicalW(x, y)

	End Function
End Class