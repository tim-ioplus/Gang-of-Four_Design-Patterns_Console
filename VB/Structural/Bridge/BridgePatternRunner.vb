Imports System.Runtime.InteropServices

Public Class BridgePatternRunner
	Public Sub Run()
		'// Create a Printing System which supports
		'// - at least 2 types of Printers: Plotter, Laser
		'// - at least 2 types of output Format: Text, Html
		'// 
		Console.WriteLine("Bridge Pattern..")
		Dim textToPrint = "Franz jagt im komplett verwahrlosten Taxi quer durch München"

		Dim printFormats As New List(Of IPrintFormat) From {
			New HtmlFormat(),
			New TextFormat()
		}
		Dim printerHardware As New List(Of IPrinterHardware) From {
			New PlotterPrinter,
			New LaserPrinter
		}

		For Each printFormat In printFormats
			For Each printer In printerHardware
				printer.Print(printFormat.Print(textToPrint))
			Next
		Next

	End Sub
End Class

Public Interface IPrintFormat
	Function Print(text As String) As String
End Interface

Public Class TextFormat
	Implements IPrintFormat

	Public Function Print(text As String) As String Implements IPrintFormat.Print
		Return text
	End Function
End Class

Public Class HtmlFormat
	Implements IPrintFormat

	Public Function Print(text As String) As String Implements IPrintFormat.Print
		Return "<html><p>" + text + "</p></html>"
	End Function

End Class
Public Interface IPrinterHardware
	Sub Print(text As String)
End Interface

Public Class PlotterPrinter
	Implements IPrinterHardware

	Private _name As String = "PlotterPrinter"
	Public Sub Print(formattedText As String) Implements IPrinterHardware.Print
		Console.WriteLine("{0} - {1}", _name, formattedText)
	End Sub
End Class

Public Class LaserPrinter
	Implements IPrinterHardware

	Private _name As String = "LaserPrinter"
	Public Sub Print(formattedText As String) Implements IPrinterHardware.Print
		Console.WriteLine("{0} - {1}", _name, formattedText)
	End Sub
End Class