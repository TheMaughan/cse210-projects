using System;
using System.Collections.Generic;
using System.Text;

public class Hide
{
    private readonly Scripture _scripture;
    private int _revealCount;
    private HashSet<int> _hiddenIndex;
    private string[] _words;

    public Hide(Scripture scripture)
    {
        _scripture = scripture;
        _revealCount = 0;
        _hiddenIndex = new HashSet<int>();
    }

    public void Display()
    {
        Console.Clear();
        string verse = _scripture.Verse();
        Console.WriteLine(verse);

        _words = verse.Split(' ');

		bool wordsHidden = false;

        Console.WriteLine("Press 'Enter' to hide some words, or type 'quit' to exit.");

        while (true)
        {
            string userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "exit":
                case "quit":
                    Environment.Exit(0);
                    break;

                case "":
                    Console.Clear();
                    if (_revealCount < _words.Length)
                    {
                        //HideRandom();
						HiddenDisplay();
						_revealCount += 2;
                        Console.WriteLine("Press 'Enter' to hide more words, or type 'quit' to exit.");
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
					HideRandom();
                    _revealCount += 2;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please press 'ENTER' to hide more words, or type 'quit' to exit.");
                    break;
            }
        }
    }

    public void HideRandom()
    {
        //_hiddenIndex.Clear();

        Random random = new Random();
        
		while (_hiddenIndex.Count < _revealCount && _hiddenIndex.Count < _words.Length)
        {
            int index = random.Next(1, _words.Length);
            if (!_hiddenIndex.Contains(index) && index != 0) // Explude the Reference column
            {
                _hiddenIndex.Add(index);
            }
        }
    }

    public void HiddenDisplay()
	{
	    for (int i = 0; i < _words.Length; i++)
	    {
	        if (i == 0 || i == 1 || i == 2)
	        {
	            // Display the Reference column
	            Console.Write(_words[i] + " ");
	        }
	        else if (_hiddenIndex.Contains(i))
	        {
	            //string hiddenWord = new string('_', _words[i].Length);
				string hiddenWord = HideLetters(_words[i]);
	            Console.Write($" {hiddenWord} ");
	        }
	        else
	        {
	            Console.Write(_words[i] + " ");
	        }
	    }
	    Console.WriteLine();
	}

	public string HideLetters(string word)
	{
		StringBuilder result = new StringBuilder();

		foreach (char c in word)
		{
			if (char.IsLetter(c))
				result.Append('_');
			else
				result.Append(c);
		}

		return result.ToString();
	}

}