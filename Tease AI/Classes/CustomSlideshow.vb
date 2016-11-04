Imports System.Runtime.Serialization

<Serializable>
Public Class CustomSlideshow
	Inherits Dictionary(Of String, Form1.ImageGenre)
	Implements ISerializable, IDeserializationCallback

	Sub New()
	End Sub

	Sub New(ByVal copy As Dictionary(Of String, Form1.ImageGenre))
		MyBase.New(copy)
	End Sub

	''' <summary>
	''' Constructor needed to deserialize -> inherited from Dictionary.
	''' </summary>
	''' <param name="info"></param>
	''' <param name="context"></param>
	Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
		MyBase.New(info, context)
	End Sub


	Public Sub AddRange(ByVal List As List(Of String), ByVal genre As Form1.ImageGenre)
		For Each str As String In List
			If str IsNot Nothing And str <> "" And Me.ContainsKey(str) = False Then Add(str, genre)
		Next
	End Sub

	''' <summary>
	''' Random Number provider.
	''' </summary>
	<NonSerialized>
	Private Rand As New Security.Cryptography.RNGCryptoServiceProvider()

	''' <summary>
	''' Returns a random integer between a min and max value.
	''' </summary>
	''' <param name="min"></param>
	''' <param name="max"></param>
	''' <returns></returns>
	Private Function RandomInteger(min As Integer, max As Integer) As Integer
		max -= 1
		Dim scale As UInteger = UInteger.MaxValue
		While scale = UInteger.MaxValue
			' Get four random bytes.
			Dim four_bytes As Byte() = New Byte(3) {}
			Rand.GetBytes(four_bytes)

			' Convert that into an uint.
			scale = BitConverter.ToUInt32(four_bytes, 0)
		End While

		' Add min to the scaled difference between max and min.
		Return CInt(min + (max - min) * (scale / CDbl(UInteger.MaxValue)))
	End Function



	<NonSerialized> Dim lastgenre As Form1.ImageGenre
	''' <summary>
	''' Gets or sets the current image index.
	''' </summary>
	''' <returns>Returns the current Image index or Nothing/Null if the Slideshow is empty.</returns>
	''' <remarks>Dictionary-Keys are not(!) always the same. But it seems to work unless 
	''' you modify the dictionary entries. 
	''' For further details goto: https://msdn.microsoft.com/en-us/library/yt2fy5zk.aspx. </remarks>
	Public Property Index As Integer = -1


	Public Function CurrentImage() As String
		If Keys.Count > 0 Then
			Return Keys(Index)
		Else
			Return Nothing
		End If
	End Function

	Public Function FirstImage() As String
		Index = 0
		Return CurrentImage()
	End Function

	Public Function NextImage() As String
		Index += 1
		If Index > Keys.Count - 1 Then Index = Keys.Count - 1
		Return CurrentImage()
	End Function

	Public Function PreviousImage() As String
		Index -= 1
		If Index < 0 Then Index = 0
		Return CurrentImage()
	End Function

	Public Function LastImage() As String
		Index = Keys.Count - 1
		Return CurrentImage()
	End Function


	Public Function GetRandom(ByVal preferOffline As Boolean) As String
		Try
			Dim imagelist As New List(Of String)
			Dim retryCounter As Integer = 3

			'####################### Pick Genre #######################
			' Get a list of all loaded genres.
			Dim Genrelist As List(Of Form1.ImageGenre) = Me.Values.Distinct.ToList

			' Set the maximum retries to get a new new genre
			retryCounter = CInt(Genrelist.Count / 4)
PickNewGenre:
			' Pick a random genre.
			Dim rndGenre As Form1.ImageGenre = Genrelist(RandomInteger(0, Genrelist.Count))

			' Check if picked genre is same as last one, but don't force it.
			If lastgenre = rndGenre And retryCounter > 0 Then
				' try to pick a new genre.
				retryCounter -= 1
				GoTo PickNewGenre
			Else
				' Set current genre for next time.
				lastgenre = rndGenre
			End If

			' Create a list all paths for the picked genre.
			For Each str As String In Keys
				If Me(str) = rndGenre Then imagelist.Add(str)
			Next

			'####################### Pick Image #######################
			' Set maximum retries to get a local image.
			retryCounter = 50
pickNextImage:
			' Pick a random image.
			Dim rndindex As Integer = RandomInteger(0, imagelist.Count)
			Dim rndPick As String = imagelist(rndindex)

			' Check if a local image is prefered. If so pick a new path.
			If preferOffline And isURL(rndPick) And imagelist.Count > 1 And retryCounter > 0 Then
				retryCounter -= 1
				imagelist.RemoveAt(rndindex)
				GoTo pickNextImage
			Else
				' Find index of Key
				For i = 0 To Keys.Count - 1
					If Keys(i) = rndPick Then
						Index = i
						Exit For
					End If
				Next

				Return rndPick
			End If
		Catch ex As Exception
			'@@@@@@@@@@@@@@@@@@@@@@@ Exception @@@@@@@@@@@@@@@@@@@@@@@@
			Throw
		End Try
	End Function

	Sub RemoveGenre(ByVal genre As Form1.ImageGenre)
		For i = Me.Keys.Count - 1 To 0 Step -1
			Dim lazytext As String = Me.Keys(i)
			If Me(lazytext) = genre Then Me.Remove(lazytext)
		Next
	End Sub


End Class
