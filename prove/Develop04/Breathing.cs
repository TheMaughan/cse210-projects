class Breathing : MindfulFoundation
{

	private bool _breathingIn = true;

	public override void StartActivity()
	{
		base.StartActivity();
		BreathIn();
		BreathOut();
	}

	public void BreathIn()
	{
		Message = new List<string>()
		{
			"( ^_^) < ~  Breath in",
			"( ^_^) <~   Breath in",
			"( ^_^)<~    Breath in"
		};
	}

	public void BreathOut()
	{
		Message = new List<string>()
		{
			"( -o-) ~ >  Breath out",
			"( -o-)  ~>  Breath out",
			"( -o-)   ~> Breath out"
		};

	}

    protected override void PerformActivity()
    {
		Console.Clear();
        Console.WriteLine("\nThis activity will help you relax by walking you through a breathing activity.");
		Console.WriteLine("Clear your mind and focus on your breathing.");
		Console.WriteLine("\nPress 'ESC' anytime to exit");

		DisplayAnimation();
    }

	public override void DisplayAnimation()
	{
		do
		{

			if (_breathingIn)
			{
				BreathIn();
			}
			else
			{
				BreathOut();
			}

			for (int i = 0; i < _secondsDuration; i++)
			{

				foreach (string s in Message)
				{
					Console.Write(s);
					Thread.Sleep(500);

					for (int a = 22; a > 0; a--)
					{
						Console.Write("\b \b");
					}

					if (Console.KeyAvailable)
					{
						_keyInfo = Console.ReadKey(true);

						// Check if the pressed key is Escape
						if (_keyInfo.Key == ConsoleKey.Escape)
						{
							// Exit the loop if Escape is pressed
							Console.Clear();
							StartMenu();
							return;
						}
					}
				}
			}

			_breathingIn = !_breathingIn;
		} while (true);
	}
}