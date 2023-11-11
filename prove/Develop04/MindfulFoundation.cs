using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

abstract class MindfulFoundation
{
	public int _delayTimer;
	public List<string> Message { get; set; }
	public int _iterateIndex = 0;

	public MindfulFoundation(int time)
	{
		_delayTimer = time;
	}

	
	public void Animate(List<string> _spriteScript, ref int currentIndex)
	{
		Console.Clear();

		Console.WriteLine(_spriteScript[currentIndex]);

		currentIndex = (currentIndex + 1) % _spriteScript.Count;
	}

	public void DisplayAnimation()
	{
		ConsoleKeyInfo keyInfo;
		bool shouldContinue = true;

		do
		{
			
			Animate(Message, ref _iterateIndex);

			if (Console.KeyAvailable)
			{
				keyInfo = Console.ReadKey(true);
			}
			else
			{
				keyInfo = new ConsoleKeyInfo();
			}

			Thread.Sleep(_delayTimer);
			shouldContinue = false;

		} while (shouldContinue);

	}

}