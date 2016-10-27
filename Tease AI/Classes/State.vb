
Namespace My

	Partial Friend Class MyApplication
		Friend Session As New SessionState
	End Class
	''' <summary>
	''' Class to store/serialize and deserialize all nessecary session(!) informations.
	''' </summary>
	<Serializable>
	Public Class SessionState

		Public Property Chat As String

		Public Property SlideshowDomme As Slideshow
		Public Property SlideshowContact1 As Slideshow
		Public Property SlideshowContact2 As Slideshow
		Public Property SlideshowContact3 As Slideshow

		Sub New() : End Sub

	End Class

End Namespace

