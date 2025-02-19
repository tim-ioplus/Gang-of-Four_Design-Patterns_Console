Imports System.Security
Imports System.Threading

Module Module1

	Sub Main()

		' Erzeugungsmuster
		'GoTo _11singleton
		'GoTo _12factory
		'GoTo _13prototype
		'GoTo _14builder

		' Strukturmuster
		'GoTo _21adapter
		'GoTo _22bridge
		'GoTo _23composite
		'GoTo _24decorator
		'GoTo _25facade
		'GoTo _26flyweight
		'GoTo _27proxy

		'Verhaltensmuster
		'GoTo _31chainOfResponsibility
		'GoTo _32command
		'GoTo _33iterator
		'GoTo _34mediator
		'GoTo _35memento
		'GoTo _36observer
		'GoTo _37state
		'GoTo _38strategy
		'GoTo _39template
		GoTo _310visitor

		'
		'1. Erzeugungsmuster
		'

_11singleton:
		Dim singletonPatternRunner As New SingletonPatternRunner()
		singletonPatternRunner.Run()
		GoTo endoffile

_12factory:
		Dim factoryPatternRunner As New FactoryPatternRunner()
		factoryPatternRunner.Run()
		GoTo endoffile

_13prototype:
		Dim prototypePatternRunner As New PrototypePatternRunner()
		prototypePatternRunner.Run()
		GoTo endoffile

_14builder:
		Dim builderPatternRunner As New BuilderPatternRunner()
		builderPatternRunner.Run()
		GoTo endoffile

		'
		'2. Strukturmuster
		'

_21adapter:
		Dim adapterPatternRunner = New AdapterPatternRunner
		adapterPatternRunner.Run()
		GoTo endoffile

_22bridge:
		Dim bridgePatternRunner = New BridgePatternRunner
		bridgePatternRunner.Run()
		GoTo endoffile

_23composite:
		Dim compositePatternRunner = New CompositePatternRunner
		compositePatternRunner.Run()
		GoTo endoffile

_24decorator:
		Dim decoratorpatternRunner = New DecoratorPatternRunner
		decoratorpatternRunner.Run()
		GoTo endoffile

_25facade:
		Dim facadePatternRunner = New FacadePatternRunner
		facadePatternRunner.Run()
		GoTo endoffile

_26flyweight:
		Dim flyweightPatternRunner = New FlyweightPatternRunner
		flyweightPatternRunner.Run()
		GoTo endoffile

_27proxy:
		Dim proxyPatternRunner = New ProxyPatternRunner
		proxyPatternRunner.Run()
		GoTo endoffile

		'
		' 3. Verhaltensmuster 
		'

_31chainOfResponsibility:
		Dim chainOfResponsibilityPatternRunner As New ChainOfResponsibilityPatternRunner()
		chainOfResponsibilityPatternRunner.Run()
		GoTo endoffile

_32command:
		Dim commandPatternRunner As New CommandPatternRunner()
		commandPatternRunner.Run()
		GoTo endoffile

_33iterator:
		Dim iteratorPatternRunner As New IteratorPatternRunner()
		iteratorPatternRunner.Run()
		GoTo endoffile

_34mediator:
		Dim mediatorPatternRunner = New MediatorPatternRunner()
		mediatorPatternRunner.Run()
		GoTo endoffile

_35memento:
		Dim mementoPatternRunner = New MementoPatternRunner()
		mementoPatternRunner.Run()
		GoTo endoffile

_36observer:
		Dim observerPatternRunner = New ObserverPatternRunner()
		observerPatternRunner.Run()
		GoTo endoffile

_37state:
		Dim statePatternRunner As New StatePatternRunner()
		statePatternRunner.Run()
		GoTo endoffile

_38strategy:
		Dim strategyPatternRunner As New StrategyPatternRunner()
		strategyPatternRunner.Run()
		GoTo endoffile

_39template:
		Dim templatePatternRunner As New TemplatePatternRunner()
		templatePatternRunner.Run()
		GoTo endoffile

_310visitor:
		Dim visitorPatternRunner As New VisitorPatternRunner()
		visitorPatternRunner.Run()
		GoTo endoffile

		'
		' End oF File
		'

endoffile:
		Dim secs As Integer = 20000
		Console.WriteLine($"exit in {secs / 1000} secs")
		Thread.Sleep(secs)

	End Sub

End Module
