using System.IO;
using System.Collections.Generic;
public class Display
{
	Random _random = new Random();
	JournalFileManager _editFile = new JournalFileManager();

	string[] _prompts = {
		"Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
	};
	

	public void Menu()
	{
		while (true)
		{
			Console.WriteLine("Journal Menu:");
			Console.WriteLine("1 - Write a new entry");
			Console.WriteLine("2 - Display the journal (try loading a journal file)");
			Console.WriteLine("3 - Save the journal");
			Console.WriteLine("4 - Load the journal");
			Console.WriteLine("5 - Exit");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					Console.WriteLine("=============================================\n");
					int randomIndex = _random.Next(_prompts.Length);
					string randomPrompt = _prompts[randomIndex];
					Console.WriteLine($"Prompt: {randomPrompt}");
					Console.Write("Your response: ");
					string response = Console.ReadLine();
					_editFile.AddEntry(randomPrompt, response);
					Console.WriteLine("");
					break;

				case "2":
					Console.WriteLine("=============================================\n");
					_editFile.DisplayFile();
					break;

				case "3":
					Console.WriteLine("=============================================\n");
					Console.Write("Enter the file name to save to: ");
					string saveFileName = Console.ReadLine();
					_editFile.SaveToFile(saveFileName);
					Console.WriteLine("");
					break;

				case "4":
					Console.WriteLine("=============================================\n");
					Console.Write("Enter the file name to load from: ");
					string loadFileName = Console.ReadLine();
					_editFile.LoadFromFile(loadFileName);
					Console.WriteLine("");
					break;

				case "5":
					Console.WriteLine("=============================================\n");
					return;

				default:
					Console.WriteLine("=============================================");
					Console.WriteLine("\nInvalid entry. Please type a number 1 - 5.\n");
					break;
			}
		}
	}
}