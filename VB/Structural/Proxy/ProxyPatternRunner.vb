Public Class ProxyPatternRunner
	Public Sub Run()
		Console.WriteLine("")
		Console.WriteLine("Common user via ServerProxy")
		Dim commonUserClient As New ServerProxy
		Console.WriteLine("Show Options:")
		Console.WriteLine(commonUserClient.ShowOptions)
		Console.WriteLine("Show Workloads:")
		Console.WriteLine(commonUserClient.ShowWorkloads)
		Console.WriteLine("Run Workload:")
		Console.WriteLine(commonUserClient.RunWorkload(2))

		Console.WriteLine("")
		Console.WriteLine("Admininistrative user via Server")
		Dim adminUserClient As New Server
		Console.WriteLine("Show Options:")
		Console.WriteLine(adminUserClient.ShowOptions)
		Console.WriteLine("Show Workloads:")
		Console.WriteLine(adminUserClient.ShowWorkloads)
		Console.WriteLine("Run Workload:")
		Console.WriteLine(adminUserClient.RunWorkload(2))
		Console.WriteLine("Show Configurations:")
		Console.WriteLine(adminUserClient.ShowConfigurations)
		Console.WriteLine("Update Configurations:")
		Console.WriteLine(adminUserClient.UpdateConfiguration("c", "5"))

	End Sub

	Friend Class ServerProxy

		Private _server As Server

		Public Sub New()
			_server = New Server
		End Sub

		Friend Function ShowOptions() As String
			Return "ShowOptions, ShowWorkloads, RunWorkload"
		End Function
		Friend Function ShowWorkloads() As String
			Return "Proxy: " & _server.ShowWorkloads
		End Function

		Friend Function RunWorkload(workloadNumber As Integer) As String
			Return "Proxy: " & _server.RunWorkload(workloadNumber)
		End Function

	End Class

	Friend Class Server

		Friend Function ShowOptions() As String
			Return "ShowOptions, ShowWorkloads, RunWorkload, ShowConfigurations, UpdateConfiguration"
		End Function
		Friend Function ShowWorkloads() As String
			Return "Workload 1,2,3.."
		End Function
		Friend Function RunWorkload(workloadNumber As Integer) As String
			Return "Run Workload " & workloadNumber
		End Function
		Friend Function ShowConfigurations() As String
			Return "Configurations a=1, b=2, c=3.."
		End Function
		Friend Function UpdateConfiguration(key As String, value As String) As String
			Return "Configuration set " & key & " to " & value
		End Function
	End Class
End Class


