Imports System.Threading
Imports System.Xml

Public Class TemplatePatternRunner
	Public Sub Run()
		Console.WriteLine("Template Pattern..")

		Dim dataSource As New Dictionary(Of String, String)
		dataSource.Add("csv", "123;45;67;891;0")
		dataSource.Add("xml", "<data><v1>abc</v1><v2>de</v2><v3>fg</v3><v4>hij</v4><v5>k</v5></data>")

		Dim etlCsvToXml As New CsvToSql()
		etlCsvToXml.Import(dataSource)

		Dim etlXmlTofile = New XmlToFile()
		etlXmlTofile.Import(dataSource)

	End Sub

	Friend MustInherit Class ExtractTransformLoad

		Protected Friend Source As String
		Protected Friend Target As String

		Public Sub New(source As String, target As String)
			Me.Source = source.ToLower
			Me.Target = target.ToLower
		End Sub

		Public Sub Import(dataSource As Dictionary(Of String, String))
			Dim rawData = Load(dataSource)
			Dim data = Extract(rawData)
			Dim transformed = Transform(data)
			Transfer(transformed)
		End Sub

		Protected Function Load(dataSource As Dictionary(Of String, String)) As String
			Dim rawData As String = ""
			If dataSource.TryGetValue(Source, rawData) Then
				Return rawData
			Else
				Return Nothing
			End If
		End Function
		Protected MustOverride Function Extract(rawData As String) As String()
		Protected MustOverride Function Transform(data As String()) As List(Of String)
		Protected Sub Transfer(transformed As List(Of String))
			Console.WriteLine($"Connect to {Me.Target}")

			Dim rnd As New Random
			Thread.Sleep(rnd.Next(250, 1000))

			Console.WriteLine("Connected, Transfer into")
			For Each transformedData In transformed
				Console.WriteLine($"Transfer {transformedData}")
				Thread.Sleep(rnd.Next(100, 1000))
			Next

			Console.WriteLine($"Data transferred from {Me.Source} to {Me.Target}")
		End Sub
	End Class

	Friend Class CsvToSql
		Inherits ExtractTransformLoad

		Public Sub New()
			MyBase.New("CSV", "SQL")
		End Sub

		Protected Overrides Function Extract(rawData As String) As String()
			Return rawData.Split(";")
		End Function
		Protected Overrides Function Transform(data As String()) As List(Of String)
			'@todo sql string bauen
			Return data.ToList()
		End Function

	End Class

	Friend Class XmlToFile
		Inherits ExtractTransformLoad

		Public Sub New()
			MyBase.New("XML", "File")
		End Sub
		Protected Overrides Function Extract(rawData As String) As String()
			Dim dataStrings As New List(Of String)
			Dim dataString As String = ""

			Dim xmlData As XElement = XElement.Parse(rawData)
			dataStrings.Add($"BEGINDATASET={xmlData.Name}")

			For Each xmLElement In xmlData.Elements
				dataString = ""

				If xmLElement.Value IsNot Nothing Then
					dataString = $"{xmLElement.Name}={xmLElement.Value}"
				Else
					dataString = $"FirstTag={xmLElement.Name}"
				End If

				dataStrings.Add(dataString)
			Next

			dataStrings.Add("ENDATASET")

			Return dataStrings.ToArray()
		End Function

		Protected Overrides Function Transform(data() As String) As List(Of String)
			Dim dataList = New List(Of String)

			dataList.Add("CMD=BEGINFILE")
			dataList.AddRange(data.ToList)
			dataList.Add("CMD=ENDFILE")

			Return dataList
		End Function

	End Class
End Class
