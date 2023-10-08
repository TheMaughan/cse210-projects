using System; // Import the System namespace, which provides core functionality
using System.Collections.Generic;
using System.IO;

// Define a class representing a journal entry
public class JournalEntry
{
    public string Prompt { get; set; } // Property for the prompt of the entry
    public string Response { get; set; } // Property for the response to the prompt
    public DateTime Date { get; set; } // Property for the date and time the entry was made

    // Override the ToString() method to customize how an entry is displayed as a string
    public override string ToString()
    {
        return $"{Date} - Prompt: {Prompt}\nResponse: {Response}\n"; // Return a formatted string representing the entry
    }
}

// Define a class representing a journal
public class Journal
{
    private List<JournalEntry> entries; // List to store journal entries

    // Constructor to initialize the journal with an empty list of entries
    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    // Method to add a new journal entry with the provided prompt, response, and current date
    public void AddEntry(string prompt, string response)
    {
        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };
        entries.Add(entry); // Add the new entry to the list of entries
    }

    // Method to display all entries in the journal
    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry); // Print each entry to the console
        }
    }

    // Method to save the journal entries to a specified file
    public void SaveToFile(string fileName)
    {
        try
        {
            // Open a StreamWriter to the specified file
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    // Write the entry details (date, prompt, response) to the file
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully."); // Print success message
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while saving the journal: " + e.Message); // Handle any errors
        }
    }

    // Method to load journal entries from a specified file
    public void LoadFromFile(string fileName)
    {
        try
        {
            entries.Clear(); // Clear existing entries

            // Open a StreamReader to the specified file
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                // Read each line from the file
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into parts based on the '|' character
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        // Create a new journal entry from the file and add it to the list of entries
                        JournalEntry entry = new JournalEntry
                        {
                            Date = DateTime.Parse(parts[0]),
                            Prompt = parts[1],
                            Response = parts[2]
                        };
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully."); // Print success message
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while loading the journal: " + e.Message); // Handle any errors
        }
    }
}

// Define the main program class
public class ProgramA
{
    // Main method, the entry point of the program
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // Create a new journal object

        // Array of prompts for the journal entries
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random(); // Create a random object for generating prompts

        // Loop to display a menu and handle user input
        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an option: ");

            string choice = Console.ReadLine(); // Read user's choice

            // Switch statement to handle user's choice
            switch (choice)
            {
                case "1":
                    int randomIndex = random.Next(prompts.Length);
                    string randomPrompt = prompts[randomIndex];
                    Console.WriteLine("Prompt: " + randomPrompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(randomPrompt, response); // Add a new entry using a random prompt
                    break;

                case "2":
                    journal.DisplayJournal(); // Display the journal
                    break;

                case "3":
                    Console.Write("Enter a file name to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName); // Save the journal to a file
                    break;

                case "4":
                    Console.Write("Enter a file name to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName); // Load the journal from a file
                    break;

                case "5":
                    return; // Exit the program

                default:
                    Console.WriteLine("Invalid choice. Please try again."); // Handle invalid choices
                    break;
            }
        }
    }
}
