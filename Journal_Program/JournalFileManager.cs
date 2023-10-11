using System.IO;
using System.Globalization;
#nullable enable //I'm attempting to get rid of all the warnings about "null" stuff. 
//This is also the explination for the "?" & "??" in the code below:

public class JournalFileManager
{
	//private int _lastSavedIndex;
	private List<Entry?> _entries;
	
	public JournalFileManager()
	{
		_entries = new List<Entry?>();
		//_lastSavedIndex = -1;
	}

	public void AddEntry(string? prompt, string? response)
	{

		
		Entry? entry = new Entry(DateTime.Now, prompt ?? "No prompt selected", response ?? "No response provided");

		_entries?.Add(entry);
	}
	
	
	public void DisplayFile()
	{
		
		if (_entries?.Count == 0)
		{
			Console.WriteLine("No entries to display.\nTry pressing '1' and make an entry.\n");
			return;
		}

		Console.WriteLine("Journal Entries:");
		foreach (var entry in _entries)
		{
			Console.WriteLine(entry);
		}
	}

	/*public void MarkExistingEntries(int startIndex, int endIndex) //Stop Duplicating Stuff!!!
	{
		for (int i = startIndex; i <= endIndex; i++)
		{
			_entries[i].Displayed = true;
		}
	}*/

	public void SaveToFile(string fileName)
	{
		try
		{
			if (!fileName.EndsWith(".csv"))
				fileName += ".csv"; //Add the file extension, simplified

			using (StreamWriter writer = new StreamWriter(fileName))
			{
				
				foreach (var entry in _entries)
				{
					//Write each journal entry to the file in CSV format
					writer.WriteLine($"{entry._date.ToString("yyyy-MM-dd HH:mm:ss") ?? "No date provided"},{entry._prompt ?? string.Empty},{entry._response ?? string.Empty}");
				}

				/*for (int i = _lastSavedIndex + 1; i <_entries.Count; i++)
				{
					if (!_entries[i].Displayed)
					{
						var entry = _entries[i];
						// Format the entry as a CSV line and write it to the file
                        writer.WriteLine($"{entry._date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}," +
                                         $"{EscapeCsvField(entry._prompt)},{EscapeCsvField(entry._response)}");
                    }
					
				}
				_lastSavedIndex = _entries.Count - 1;*/
			}
			Console.WriteLine($"Jounal entry saved successfully to the file '{fileName}'.\n");
		}

		catch (Exception e)
		{
			Console.WriteLine($"An error occurred while saving the journal: {e.Message}");
		}
	}

	/*private string EscapeCsvField(string field)
	{
		return $"\"{field.Replace("\"", "\"\"")}\"";
	}*/

	public void LoadFromFile(string fileName)
	{
		try
		{
			if (!fileName.EndsWith(".csv"))
				fileName += ".csv"; //If the file isn't csv, make it a csv file.

			if (File.Exists(fileName)) // Check if the file exists
			{
				_entries?.Clear(); //Clear existing entries

				using (StreamReader reader = new StreamReader(fileName))
				{
					string? line;
					
					while ((line = reader.ReadLine()) != null)
					{
						if (Entry.TryParse(line, out Entry? entry)) //Try to parse a new string data to the Entry object
						{
							_entries?.Add(entry); //Parse and add each entry to the list of journal entries
						}
					}
				}
				Console.WriteLine($"Journal file named '{fileName}' loaded successfully.\n");
				
			}
			else
			{
				Console.WriteLine($"File not found: {fileName}");
			}
			
		}

		catch (Exception e)
        {
            Console.WriteLine($"An error occurred while loading the journal: {e.Message}"); // Handle any errors
        }
	}
}