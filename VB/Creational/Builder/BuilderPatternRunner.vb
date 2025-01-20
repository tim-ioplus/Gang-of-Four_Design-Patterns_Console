Public Class BuilderPatternRunner

	Public Sub New()
	End Sub

	Public Function Run()
		Console.WriteLine("Builder Pattern..")

		Dim maxBuilders As Int16
		maxBuilders = 10

		Dim builders As New List(Of IPageBuilder)()
		For i As Integer = 0 To maxBuilders - 1
			If i Mod 2 = 0 Then
				builders.Add(New SportsPageBuilder())
			Else
				builders.Add(New SciencePageBuilder())
			End If
		Next

		Dim pageDirector As New PageDirector()
		pageDirector.Build(builders)
		pageDirector.Show(builders)


		Console.WriteLine("Builder />")
	End Function

End Class

Public Class Page
	Public Property Header As String
	Public Property Content As String
	Public Property Footer As String

	Public Sub New()
		Header = ""
		Content = ""
		Footer = ""
	End Sub

	Public Overrides Function ToString() As String
		Return Header + " - " + Content + " - " + Footer
	End Function

End Class

Public Class PageDirector

	Public Sub New()
	End Sub

	Public Function Build(builders As List(Of IPageBuilder))
		For Each builder As IPageBuilder In builders
			Me._build(builder)
		Next
	End Function

	Private Function _build(builder As IPageBuilder)
		builder.BuildHeader()
		builder.BuildContent()
		builder.BuildFooter()
	End Function

	Public Function Show(builders As List(Of IPageBuilder))
		For Each builder As IPageBuilder In builders
			show(builder)
		Next
	End Function

	Private Function show(builder As IPageBuilder)
		Dim pageText = builder.GetResult()
		If pageText IsNot Nothing Then
			Console.WriteLine(pageText)
		Else
			Console.WriteLine("No page text")
		End If
	End Function


End Class
Public Interface IPageBuilder
	Function BuildHeader()
	Function BuildContent()
	Function BuildFooter()
	Function GetResult() As String
End Interface

Public Class SportsPageBuilder
	Implements IPageBuilder

	Private _header As String
	Private _content As String
	Private _footer As String

	Public Sub New()
		_header = ""
		_content = ""
		_footer = ""
	End Sub

	Public Function BuildHeader() As Object Implements IPageBuilder.BuildHeader
		_header = "Sport Message Header!"
		Return Me
	End Function

	Public Function BuildContent() As Object Implements IPageBuilder.BuildContent
		_content = "Wow super golazo"
		Return Me
	End Function

	Public Function BuildFooter() As Object Implements IPageBuilder.BuildFooter
		_footer = "mucha buena footy"
		Return Me
	End Function

	Public Function GetResult() As String Implements IPageBuilder.GetResult
		Return _header + " " + _content + " " + _footer
	End Function
End Class

Public Class SciencePageBuilder
	Implements IPageBuilder

	Private _header As String
	Private _content As String
	Private _footer As String

	Public Sub New()
		_header = ""
		_content = ""
		_footer = ""
	End Sub

	Public Function BuildHeader() As Object Implements IPageBuilder.BuildHeader
		_header = "Science. Today."
		Return Me
	End Function

	Public Function BuildContent() As Object Implements IPageBuilder.BuildContent
		_content = "Remarkable wonders of nature preserved."
		Return Me
	End Function

	Public Function BuildFooter() As Object Implements IPageBuilder.BuildFooter
		_footer = "More intriguing Anthologies of Interests."
		Return Me
	End Function

	Public Function GetResult() As String Implements IPageBuilder.GetResult
		Return _header + " " + _content + " " + _footer
	End Function
End Class



