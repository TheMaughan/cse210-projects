// public class Hide_backup
// {
// 	private readonly Scripture _scripture;
// 	private int _hideCount;
// 	private string[] _words;

// 	public Hide(Scripture scripture)
// 	{
// 		_scripture = scripture;
// 		_hideCount = 0;
// 	}

// 	public void Display()
// 	{
// 		Console.Clear();

// 		string verse = _scripture.Verse();
// 		Console.WriteLine(verse);

// 		Console.WriteLine("Press 'Enter' to to challenge your memory, or type 'quit' to exit.");
		

		
// 		while (true)
// 		{
// 			string userInput = Console.ReadLine();

// 			switch (userInput.ToLower())
// 			{
// 				case "exit":
// 					Environment.Exit(0);
// 					break;

// 				case "quit":
// 					Environment.Exit(0);
// 					break;

// 				case "":
// 					_hideCount += 2;
// 					VisibleWord();
// 					break;

// 				default:
// 					Console.WriteLine("Invalid input. Please press 'ENTER' or type 'quit' or exit'.");
// 					break;
// 			}	
// 		}
// 	}

// 	public void VisibleWord()
// 	{
// 		int displayWordCount = Math.Min(_hideCount, _words.Length);
// 		Random random = new Random();

// 		for (int i = 0; i < displayWordCount; i++)
// 		{
// 			if (i <= _hideCount)
// 			{
// 				Console.Write(" " + _words[i]); //Display visible words.
// 			}
// 			else
// 			{
// 				string hiddenWord = new string('_', _words[i].Length);
// 				Console.Write(" " + hiddenWord);
// 			}
// 		}
// 		Console.WriteLine();
// 	}
// }