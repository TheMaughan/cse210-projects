// // This will start by displaying "AAA" and waiting for the user to press the enter key
// Console.WriteLine("AAA");
// Console.ReadLine();

// // This will clear the console
// Console.Clear();

// // This will show "BBB" in the console where "AAA" used to be
// Console.WriteLine("BBB");



Scripture scripture = new("scripture_list.csv");

//s.Verse();
//Console.WriteLine(s.Verse());

Hide hide = new Hide(scripture);
//hide.HideRandom();
hide.Display();