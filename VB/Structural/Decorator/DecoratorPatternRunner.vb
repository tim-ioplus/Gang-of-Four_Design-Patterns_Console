Imports System.Threading

Public Class DecoratorPatternRunner
	Public Sub Run()
		Console.WriteLine("Decorator Pattern")
		Dim postService = New PostService
		Dim postServiceLogging = New PostServiceLoggingDecorator(postService)
		Dim postServiceMeasuring = New PostServiceMeasuringDecorator(postService)

		postServiceLogging.GetPost(0)
		postServiceMeasuring.GetPost(1)

	End Sub




	Public Interface IPostService
		Function GetPost(postId As Integer) As String
	End Interface

	Public Class PostService
		Implements IPostService

		Private _posts As New List(Of String) From
		{"Post 1 über Sport", "Post 2 über Politik"}
		Public Function GetPost(postId As Integer) As String Implements IPostService.GetPost
			Dim timeToSleep = Math.Floor(50 * New Random().Next(1, 20))
			Thread.Sleep(Integer.Parse(timeToSleep))

			Dim post = _posts.ElementAt(postId)
			'Console.WriteLine("Getting post {0} : {1} ", postId, post)
			Return post
		End Function
	End Class

	Public Class PostServiceLoggingDecorator
		Implements IPostService

		Private _postService As IPostService
		Public Sub New(postService As PostService)
			_postService = postService
		End Sub

		Public Function GetPost(postId As Integer) As String Implements IPostService.GetPost
			Console.WriteLine("Logging post")
			Dim post = _postService.GetPost(postId)
			Console.WriteLine("Post {0}", post)

		End Function
	End Class

	Friend Class PostServiceMeasuringDecorator
		Implements IPostService
		Private _postService As PostService

		Public Sub New(postService As PostService)
			Me._postService = postService
		End Sub

		Public Function GetPost(postId As Integer) As String Implements IPostService.GetPost
			Dim watch As Stopwatch = Stopwatch.StartNew
			Console.WriteLine("Measuring Post")
			Dim post = _postService.GetPost(postId)
			watch.Stop()

			Dim elapsed = watch.ElapsedMilliseconds / 1000
			Console.WriteLine("Time {0} sec", elapsed)

		End Function
	End Class
	'
End Class