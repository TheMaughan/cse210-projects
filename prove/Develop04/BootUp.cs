using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

class BootUp
{
	protected ConsoleKeyInfo _keyInfo;
	public List<string> _spriteScript = new List<string>
	{
		"(-_-)",
		" /(¬_¬)/",
		"  \\(⌐_⌐)\\",
		"   /(¬_¬)/",
		"    \\(⌐_⌐)\\",
		"   \\(-_-)/",
		"   /(-_-)\\",
		"    \\(-_-)/",
		"     /(-_-)\\",
		"      \\(-_-)/",
		"■-■¬  <(⌐_⌐ )",
		"■-■¬ <(⌐_⌐ )",
		"■-■¬<(⌐_⌐ )",
		"(⌐■_■),",
		"(⌐▀_▀)`",
		",(■_■¬)",
		"`(▀_▀¬)",
		"(⌐■_■)*",
		"(⌐■_■)",
		"(⌐■_■)*",
		"( -_-)>⌐■-■",
		"( -_-)> ⌐■-■",
		"( -_-)>  ⌐■-■",
		"( -_-)>   ⌐■-■",
		"( -_-) zZz",
		"( -o-) ZzZ",
		"( -_-) zZz",
		"( -o-) ZzZ",
		"(~¬_¬)~   ⌐■-■",
		" (~¬_¬)~  ⌐■-■",
		"  (~¬_¬)~ ⌐■-■",
		"   (~¬_¬)~⌐■-■",
		"   (■_■¬)",
		"  (■_■¬)",
		" (■_■¬)",
		"(■_■¬)",
		"(⌐■_■)-|)>     0",
		"(⌐■_■)(-))>    0",
		"(⌐■_■)|)->     0",
		"(⌐■_■)|) ->    0",
		"(⌐■_■)|) *->   0",
		"(⌐■_■)|)   ->  0",
		"(⌐■_■)|)   *-> 0",
		"(⌐■_■)       ->0",
		"(⌐■_■)_       *-@",
		"(⌐■_■)-      * *@",
		"(⌐■_■)-} * * * #@",
		"(⌐■_■)-}  * * *#*",
		"(⌐■o■)~}* * *# *",
		"(⌐■o■)}* * * * *"
	};
	
	public int _spriteIndex = 0;

	public void DisplayAnimation()
	{
		//ConsoleKeyInfo keyInfo;
		Console.WriteLine("\nWelcome to the Mindful App!");
		Console.WriteLine("Press 'Enter' to continue\n");

		do
		{
			foreach (string s in _spriteScript)
			{
				Console.Write(s);
				Thread.Sleep(400);

				for (int i = s.Length; i > 0; i--)
				{
					Console.Write("\b \b");
				}

				if (Console.KeyAvailable)
				{
					_keyInfo = Console.ReadKey(true);

					// Check if the pressed key is Enter
					if (_keyInfo.Key == ConsoleKey.Enter)
					{
						// Exit the loop if Enter is pressed
						StartMenu();
						return;
					}
				}
			}

		} while (true); // Loop indefinitely, exit when Enter is pressed
	}

	private void StartMenu()
	{
		Menu menu = new Menu();
		menu.DisplayMenu();
	}


}