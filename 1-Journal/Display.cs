public class Display
{


	string[] prompts = {
		"Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
	};

	Random random = new Random();

	public void Menu()
	{
		while (true)
		{
			Console.WriteLine("Journal Menu:");
			Console.WriteLine("1 - Write a new entry");
			Console.WriteLine("2 - Display the journal");
			Console.WriteLine("3 - Save the journal");
			Console.WriteLine("4 - Load the journal");
			Console.WriteLine("5 - Exit");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					break;

				case "2":
					break;

				case "3":
					break;

				case "4":
					break;

				case "5":
					return;

				default:
					Console.WriteLine("Invalid entry. Please type a number 1 - 5.");
					break;
			}
		}
	}
}