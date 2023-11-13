using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

abstract class MindfulFoundation
{
	protected ConsoleKeyInfo _keyInfo;
	protected int _activityDuration;
	protected int _secondsDuration;
	protected List<string> Message { get; set; }
	protected List<string> _spinner = new List<string>(){"-","\\","|","/"};
	protected int _iterateIndex = 0;

	public virtual void StartActivity()
	{
		SetDuration();
		DisplayStartingMessage();
		PrepareForActivity();
		PerformActivity();
		DisplayEndingMessage();
		StartMenu();
		EscapeKey();
	}

	protected virtual void SetDuration()
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

		validInput = false;

		do
		{
			Console.Write("Enter the duration of each task in seconds: ");

			// Read the user input
			string userInput = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(userInput))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid input. Please enter a valid integer.\n");
				Console.ResetColor(); // Restore the default text color
			}
			else if (int.TryParse(userInput, out _secondsDuration))
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
	}



	protected virtual void DisplayStartingMessage()
	{
		Console.WriteLine("Starting the activity...");
	}

	protected virtual void PrepareForActivity()
	{
		// Add common preparation steps
		Thread.Sleep(2000);
	}

	protected virtual void PerformActivity()
	{
		// Add activity specific logic
	}

	protected virtual void DisplayEndingMessage()
	{
		Console.WriteLine("Great Job! You have completed the activity!");
		Console.WriteLine($"Activity duration: {_activityDuration} seconds");
		Thread.Sleep(2000);

	}

	public virtual void DisplayAnimation()
	{
		if (_secondsDuration <= 0)
		{
			Console.WriteLine("Invalid duration for animation. Exiting...");
			StartMenu();
			return;
		}

		DateTime startTime = DateTime.Now;
		DateTime endTime = startTime.AddSeconds(_secondsDuration);

		//do
		while (DateTime.Now < endTime)
		{

			string s = _spinner[_iterateIndex];
			Console.Write(s);
			Thread.Sleep(500);
			for (int i = s.Length; i > 0; i--)
			{
				Console.Write("\b \b");
			}

			_iterateIndex++;

			if (_iterateIndex >= _spinner.Count)
			{
				_iterateIndex = 0;
			}

			if (Console.KeyAvailable)
			{
				_keyInfo = Console.ReadKey(true);

				// Check if the pressed key is Escape
				if (_keyInfo.Key == ConsoleKey.Escape)
				{
					// Exit the loop if Exit is pressed
					StartMenu();
					return;
				}
			}

		}

	}

	public virtual void EscapeKey()
	{
		do
		{
			if (Console.KeyAvailable)
			{
				_keyInfo = Console.ReadKey(true);

				// Check if the pressed key is Escape
				if (_keyInfo.Key == ConsoleKey.Escape)
				{
					// Exit the loop if Exit is pressed
					StartMenu();
					return;
				}
			}
		} while (true);
	}

	protected virtual void StartMenu()
	{
		Menu menu = new Menu();
		menu.DisplayMenu();
	}

}