class Menu
{
	GoalManager _goalManager = new();

	public void DisplayMainMenu()
	{
		while (true)
        {
            Console.Clear();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Goals");
            Console.WriteLine("6. ESC");

            Console.Write("\nEnter your choice (1-6): ");
            //string choice = Console.ReadLine();

			// Read a key directly without waiting for Enter
			ConsoleKeyInfo key = Console.ReadKey(true);

            string fileName = "goal";

            switch (key.KeyChar)
            {
                case '1':
                    _goalManager.AddGoal();
                    break;

                case '2':
                    _goalManager.DisplayGoals();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case '3':
                    //Console.Write("What is the file name? ");
                     //Console.ReadLine();
                    _goalManager.SaveToFile(fileName);
                    Thread.Sleep(2000);
                    
                    break;

                case '4':
                    //Console.Write("What is the file name? ");
                    //string _fileName = Console.ReadLine();
                    _goalManager.LoadFromFile(fileName);
                    Thread.Sleep(2000);
                    break;

                case '5':
                    _goalManager.RecordEvent();
                    Thread.Sleep(2000);
                    break;

                case '6':
                    Console.WriteLine("Exiting Program...");
                    Environment.Exit(0);
                    break;

                default:
					if (key.Key == ConsoleKey.Escape)
					{
						Console.WriteLine("Exiting Program...");
						Thread.Sleep(1000);
						Environment.Exit(0);
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice, please press the number keys '1 - 6' for menu options.");
					Console.ResetColor(); // Restore the default text color
					}
					Thread.Sleep(2000);
                    break;
            }
        }
	}
        
}