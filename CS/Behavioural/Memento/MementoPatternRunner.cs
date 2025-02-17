using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.Memento
{
	internal static class MementoPatternRunner
	{
		internal static void Run()
		{
			var textEditor = new TextEditor();
			var history = new History();

			textEditor.AddText("Der theoretische Ansatz für Entwurfsmuschter ");
			history.Save(textEditor.Save());
			textEditor.AddText("hat er schon 1964 in Notes on the synthesis of form dargstellt. ");
			history.Save(textEditor.Save());
			textEditor.AddText("Seine beschreibung hat der Idee vom Entwurfsmuschter in der Softwareentwicklig zum Durchbruch het verhoufe");
			history.Save(textEditor.Save());

			textEditor.AddText("Loruem Ipseum");
			Console.WriteLine(textEditor.GetContent());
			if(textEditor.GetContent().Contains("Loruem Ipseum"))
			{
				Console.WriteLine(Environment.NewLine + "Tippfehler");
			}

			textEditor.Restore(history.Undo());
			if(!textEditor.GetContent().Contains("Loruem Ipseum"))
			{
				Console.WriteLine(Environment.NewLine + "Tippfehler gelöscht");
			}

			textEditor.AddText("Lorem Ipsum");
			Console.WriteLine(textEditor.GetContent());
			if(textEditor.GetContent().Contains("Lorem Ipsum"))
			{
				textEditor.Save();
				Console.WriteLine(Environment.NewLine + "tippfehler korrigiert");
			}
			
		}
	}

	class TextEditor()
	{
		private string _text = "";

		public void AddText(string newText)
		{
			_text += $" {newText} ";
			Save();
		}
		public Memento Save()
		{
			return new Memento(_text);
		}

		public void Restore(Memento memento)
		{
			_text = memento.State;
		}

		public string GetContent()
		{
			return _text;
		}
	}

	class Memento
	{
		public string State = "";
		
		public Memento(string state)
		{
			State = state;
		}
	}

	class History
	{
		public Stack<Memento> history;

		public History() 
		{
			history = new Stack<Memento>();
		}

		public void Save(Memento memento) 
		{
			history.Push(memento);
		}

		public Memento Undo()
		{
			if(history.Count > 0)
			{
				return history.Pop();
			}

			return null;
		}
	}
}
