using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

class BootUp
{
	public List<string> _spriteScript = new List<string>
	{
		"(-_-)",
		" /(¬_¬)/",
		"  \\(⌐_⌐)\\",
		"   /(¬_¬)/",
		"    \\(⌐_⌐)\\",
		"   \\(-_-)/",
		"   ~(o_o)",
		"    `(-_-)",
		"     ~(o_o)",
		"      `(-_-)",
		"■-■¬  <(⌐_⌐ )",
		"■-■¬ <(⌐_⌐ )",
		"■-■¬<(⌐_⌐ )",
		"(⌐■_■)",
		"(⌐▀_▀)",
		"(■_■¬)",
		"(▀_▀¬)",
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
		"   (⌐■_■)*",
		"  (⌐■_■)**",
		" (⌐■_■)***",
		"(⌐■_■)****",
		"(⌐■_■)-|)>     0",
		"(⌐■_■)(-))>    0",
		"(⌐■_■)|)->     0",
		"(⌐■_■)|) ->    0",
		"(⌐■_■)|)  ->   0",
		"(⌐■_■)|)   ->  0",
		"(⌐■_■)|)    -> 0",
		"(⌐■_■)       ->0",
		"(⌐■_■)        -@",
		"(⌐■_■)        *@",
		"(⌐■_■)        #@",
		"(⌐■_■)       *#*",
		"(⌐■_■)       * *",
		"(⌐■_■)         *",
	};
	
	public int _spriteIndex = 0;

	
	public void Animate(List<string> _spriteScript, ref int currentIndex)
	{
		//Console.Clear();
		

		Console.Write(_spriteScript[currentIndex]);

		currentIndex = (currentIndex + 1) % _spriteScript.Count;
	}

	public void DisplayAnimation()
	{
		ConsoleKeyInfo keyInfo;
		Console.WriteLine("Welcome to the Mindful App!");
		Console.WriteLine("Press 'Enter' to continue");
		do
		{
			
			Animate(_spriteScript, ref _spriteIndex);

			if (Console.KeyAvailable)
			{
				keyInfo = Console.ReadKey(true);
			}
			else
			{
				keyInfo = new ConsoleKeyInfo();
			}

			Thread.Sleep(500);
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");
			Console.Write("\b \b");

			
			int newTop = Console.CursorTop - _spriteScript.Count - 1;

			if (newTop >= 0)
			{
				Console.SetCursorPosition(0, newTop);
			}

			//Console.SetCursorPosition(0, Console.CursorTop - _spriteScript.Count - 1);
					
		} while (keyInfo.Key != ConsoleKey.Escape);
		

	}

}