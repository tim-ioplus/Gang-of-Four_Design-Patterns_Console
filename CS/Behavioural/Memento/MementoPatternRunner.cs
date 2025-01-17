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

			textEditor.AddText("Der theoretisch Asatz für Entwurfsmuschter ");
			history.Save(textEditor.Save());
			textEditor.AddText("het er scho 1964 i Notes on the synthesis of form dargsteut. ");
			history.Save(textEditor.Save());
			textEditor.AddText("23 Entwurfsmuschter beschribt u der Idee vom Entwurfsmuschter i der Softwareentwicklig zum Durchbruch het verhoufe");
			history.Save(textEditor.Save());

			textEditor.AddText("Loruem Ipseum");
			Console.WriteLine(textEditor.GetContent());
			if(textEditor.GetContent().Contains("Loruem Ipseum"))
			{
				Console.WriteLine(Environment.NewLine + "Tippfehler");
			}

			textEditor.Restore(history.Restore());
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

		public Memento Restore()
		{
			if(history.Count > 0)
			{
				return history.Pop();
			}

			return null;
		}
	}
}
