using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

abstract class MindfulFoundation
{
	protected ConsoleKeyInfo _keyInfo;
	public int _secondsDuration = 1;
	public List<string> Message { get; set; }
	public int _iterateIndex = 0;

	public virtual void StartActivity()
	{
		SetDuration();
		DisplayStartingMessage();
		PrepareForActivity();
		PerformActivity();
		DisplayEndingMessage();
		DisplayAnimation();
		StartMenu();
	}

	protected virtual void SetDuration()
	{
		Console.Write("Enter the duration of the activity in seconds: ");
		
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
		Console.WriteLine($"Activity duration: {_secondsDuration} seconds");
		Thread.Sleep(2000);

	}

	public virtual void DisplayAnimation()
	{

		do
		{

			if (Console.KeyAvailable)
			{
				_keyInfo = Console.ReadKey(true);
			}
			else
			{
				_keyInfo = new ConsoleKeyInfo();
			}

			Thread.Sleep(_secondsDuration);

		} while (true);

	}

	protected virtual void StartMenu()
	{
		Menu menu = new Menu();
		menu.DisplayMenu();
	}

}