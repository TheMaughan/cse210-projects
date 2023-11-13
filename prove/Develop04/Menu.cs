class Menu : BootUp
{
    //public List<string> _menuString = new List<string>();

    public void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Press '4' or 'ESC' key to Exit");

            Console.Write("\nEnter your choice (1-4): ");
            //string choice = Console.ReadLine();

			// Read a key directly without waiting for Enter
			ConsoleKeyInfo key = Console.ReadKey(true);

            

            switch (key.KeyChar)
            {
                case '1':
                    Breathing breath = new();
                    breath.StartActivity();
                    break;

                case '2':
                    Reflection reflect = new();
                    reflect.StartActivity();
                    break;

                case '3':
                    Lisening listen = new();
                    listen.StartActivity();
                    break;

                case '4':
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
                    Console.WriteLine("\nInvalid choice, please press the number keys '1 - 4' for menu options.");
					Console.ResetColor(); // Restore the default text color
					}
					Thread.Sleep(2000);
                    break;
            }
        }
    }
}
