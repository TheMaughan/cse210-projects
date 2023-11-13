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
		//DisplayAnimation();
		StartMenu();
		EscapeKey();
	}

	protected virtual void SetDuration()
	{
		Console.Write("How long do you want to perform whole activity?\nTime is calculated in seconds: ");
		_activityDuration = Convert.ToInt32(Console.ReadLine());

		Console.Write("Enter the duration of each task in seconds: ");
		_secondsDuration = Convert.ToInt32(Console.ReadLine());
		
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

			// if (Console.KeyAvailable)
			// {
			// 	_keyInfo = Console.ReadKey(true);

			// 	// Check if the pressed key is Enter
			// 	if (_keyInfo.Key == ConsoleKey.Escape)
			// 	{
			// 		// Exit the loop if Enter is pressed
			// 		StartMenu();
			// 		return;
			// 	}
			// }	

		} //hile (true);

	}

	public virtual void EscapeKey()
	{
		do
		{
			if (Console.KeyAvailable)
			{
				_keyInfo = Console.ReadKey(true);

				// Check if the pressed key is Enter
				if (_keyInfo.Key == ConsoleKey.Escape)
				{
					// Exit the loop if Enter is pressed
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