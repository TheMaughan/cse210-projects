class Menu : BootUp
{
	public List<string> _menuString = new List<string>();

	public void DisplayMenu()
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("\nChoose an activity:");
			Console.WriteLine("1. Breathing Activity");
			Console.WriteLine("2. Reflection Activity");
			Console.WriteLine("3. Listing Activity");
			Console.WriteLine("4. Press '4' to Exit");

			Console.Write("\nEnter your choice (1-4): ");
			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					Breathing breath = new();
					breath.StartActivity();
					break;

				case "2":
					Reflection reflect = new();
					reflect.StartActivity();
					break;
				
				case "3":
					Lisening listen = new();
					listen.StartActivity();
					break;
				
				case "4":
					Environment.Exit(0);
					break;

				
				default:
					Console.WriteLine("Invalid choice, please press the number keys '1 - 4' for menu options.");
					break;
			}

			

		}

	}
}