class BreathAnimations
{
	private List<string> _breathIn;
	private List<string> _breathOut;

	public BreathAnimations()
	{
		Messages();
	}

	private void Messages()
	{
		_breathIn = new List<string>()
		{
			"( ^_^) < ~  Breath in",
			"( ^_^) <~   Breath in",
			"( ^_^)<~    Breath in"
		};

		_breathOut = new List<string>()
		{
			"( -o-) ~ >  Breath out",
			"( -o-)  ~>  Breath out",
			"( -o-)   ~> Breath out"
		};
	}

	public void DisplayAnimation(bool breathingIn, int secondsDuration, int activityDuration)
	{
		int time = 0;
		
		while (time < activityDuration)
        {
            List<string> messages = breathingIn ? _breathIn : _breathOut;

			for (int i = 0; i < secondsDuration; i++)
			{

				foreach (string message in messages)
				{
					Console.Write(message);
					Thread.Sleep(500);

					for (int a = message.Length; a > 0; a--)
					{
						Console.Write("\b \b");
					}

					if (Console.KeyAvailable)
					{
						ConsoleKeyInfo keyInfo = Console.ReadKey(true);

						if (keyInfo.Key == ConsoleKey.Escape)
						{
							return;
						}
					}
				}
			}
            breathingIn = !breathingIn;
			time += secondsDuration;
        }
	}
}
