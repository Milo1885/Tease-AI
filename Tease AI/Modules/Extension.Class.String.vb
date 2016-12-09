Module Extension

	''' <summary>Returns a value indicating whether a specified substring occurs case insensitive within this string.</summary>
	''' <param name="value">The string to seek.</param>
	''' <returns>Returns true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
	<Runtime.CompilerServices.Extension>
	Public Function Includes(text As String, value As String) As Boolean
		Return text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0
	End Function

End Module
