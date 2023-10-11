using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class JournalEntry
{
    public DateTime Date { get; private set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public bool Displayed { get; set; }

    public JournalEntry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Displayed = false; // Assuming the default value is false
    }

    public override string ToString()
    {
        return $"Date: {Date}, Prompt: {Prompt}, Response: {Response}";
    }

    public static bool TryParse(string entryString, out JournalEntry? entry)
    {
        entry = null;

        try
        {
            string[] parts = entryString.Split(',');
            if (parts.Length == 3 && DateTime.TryParseExact(parts[0], "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out DateTime date))
            {
                entry = new JournalEntry(date, parts[1], parts[2]);
                return true;
            }

            Console.WriteLine("Failed to parse entry: " + entryString);
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while parsing the entry: " + e.Message);
            return false;
        }
    }
}

public class Journal
{
    private List<JournalEntry> entries;

	public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry()
	{
	    // Original prompts
	    string[] prompts = {
	        "Who was the most interesting person I interacted with today?",
	        "What was the best part of my day?",
	        "How did I see the hand of the Lord in my life today?",
	        "What was the strongest emotion I felt today?",
	        "If I had one thing I could do over today, what would it be?"
	    };
	
	    Random random = new Random();
	    int randomPromptIndex = random.Next(0, prompts.Length);
	
	    Console.WriteLine("Randomly selected prompt: " + prompts[randomPromptIndex]);
	
	    Console.Write("Enter your response: ");
	    string response = Console.ReadLine();
	
	    JournalEntry entry = new JournalEntry(DateTime.Now, prompts[randomPromptIndex], response);
	    entries.Add(entry);
	
	    Console.WriteLine("Entry added successfully.");
	}

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            if (!fileName.EndsWith(".csv"))
                fileName += ".csv";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")},{entry.Prompt},{entry.Response}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while saving the journal: " + e.Message);
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            if (!fileName.EndsWith(".csv"))
                fileName += ".csv";

            if (File.Exists(fileName))
            {
                entries.Clear();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (JournalEntry.TryParse(line, out JournalEntry entry))
                        {
                            entries.Add(entry);
                        }
                    }
                }

                Console.WriteLine("Journal loaded successfully. Loaded entries:");
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("File not found: " + fileName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while loading the journal: " + e.Message);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the file name to save: ");
                    string fileNameToSave = Console.ReadLine();
                    journal.SaveToFile(fileNameToSave);
                    break;
                case "4":
                    Console.Write("Enter the file name to load: ");
                    string fileNameToLoad = Console.ReadLine();
                    journal.LoadFromFile(fileNameToLoad);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // Empty line for separation
        }
    }
}
