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
		Console.Write("How long do you want to perform whole activity?\nTime is calculated in seconds: ");
		_activityDuration = Convert.ToInt32(Console.ReadLine());

		Console.Write("");
		_secondsDuration = Convert.ToInt32(10);
		
	}

	protected override void PerformActivity()
   	{
		Console.WriteLine("\nPress 'ESC' anytime to exit the activiy.\n==============================================");
        Console.WriteLine("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");

		Random random = new Random();
		string prompt = _prompts[random.Next(_prompts.Length)];
		Console.WriteLine(prompt);
		DisplayAnimation();

		Console.WriteLine("Get ready to list items...");
		DisplayAnimation();

		Console.WriteLine("Begin listing items!");

		int itemCount = 0;

		
		for (int i = _activityDuration; i > 0; i--)
		{
			
			Console.WriteLine($"Time remaining: {i} seconds");
			Thread.Sleep(1000);

			Console.Write($"{itemCount + 1}. ");
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }

            itemCount++;
		}
		Console.WriteLine("Time's up!");
		Console.WriteLine($"You listed a total of {itemCount} items.");
		Thread.Sleep(30000);
		Console.WriteLine("\nPress 'Esc' to exit.\n");
    }
}