using System.Diagnostics;

class Lisening : MindfulFoundation
{

	private readonly string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

	protected override void SetDuration()
	{
		bool validInput = false;

		do
		{
			Console.Write("How long do you want to perform the whole activity?\nTime is calculated in seconds: ");

			// Read the user input
			string userInput = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(userInput))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid input. Please enter a valid integer.\n");
				Console.ResetColor(); // Restore the default text color
			}
			else if (int.TryParse(userInput, out _activityDuration))
			{
				validInput = true;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid input. Please enter a valid integer.\n");
				Console.ResetColor(); // Restore the default text color
			}
		} while (!validInput);

		//Console.Write("");
		_secondsDuration = Convert.ToInt32(2.5);
		
	}

	protected override void PerformActivity()
   	{
		Console.Clear();
		Console.WriteLine("\nPress 'ESC' anytime to exit the activiy.\n==============================================");
        Console.WriteLine("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");

		Random random = new Random();
		string prompt = _prompts[random.Next(_prompts.Length)];
		Console.WriteLine(prompt);
		DisplayAnimation();

		int itemCount = 0;
		Stopwatch stopwatch = new Stopwatch();

		Console.WriteLine("Get ready to list items in...");
		DisplayAnimation();
		Console.Write($"Starting in...");

		for (int i = 5; i > 0; i--)
		{
			Console.Write($"{i}");
			Thread.Sleep(1000);
			Console.Write("\b \b");
		}
		

		Console.WriteLine("Begin listing items!");
		stopwatch.Start();

		while (stopwatch.Elapsed.TotalSeconds < _activityDuration)
		{
			Console.Write($"{itemCount + 1}. ");
			string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }

			itemCount++;
		}

		stopwatch.Stop();
		Console.WriteLine("Time's up!");
		Console.WriteLine($"You listed a total of {itemCount} items.");
		DisplayAnimation();
		
		Console.WriteLine("\nPress 'Esc' to exit.\n");
		DisplayAnimation();
    }
}