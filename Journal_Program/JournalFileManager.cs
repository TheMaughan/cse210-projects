using System.IO;
using System.Globalization;

public class JournalFileManager
{
	//private int _lastSavedIndex;
	private List<Entry> _entries;
	
	public JournalFileManager()
	{
		_entries = new List<Entry>();
		//_lastSavedIndex = -1;
	}

	public void AddEntry(string prompt, string response)
	{

		
		Entry entry = new Entry(DateTime.Now, prompt, response);

		_entries.Add(entry);
	}
	
	
	public void DisplayFile()
	{
		
		if (_entries.Count == 0)
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
		//string name = fileName;
		try
		{
			if (!fileName.EndsWith(".csv"))
				fileName += ".csv"; //Just add the @#$# file extension!

			using (StreamWriter writer = new StreamWriter(fileName))
			{
				
				foreach (var entry in _entries)
				{
					writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")},{entry.Prompt},{entry.Response}");
				}
				
				
				
				
				/*for (int i = _lastSavedIndex + 1; i <_entries.Count; i++)
				{
					if (!_entries[i].Displayed)
					{
						var entry = _entries[i];
						// Format the entry as a CSV line and write it to the file
                        writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}," +
                                         $"{EscapeCsvField(entry.Prompt)},{EscapeCsvField(entry.Response)}");
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
				fileName += ".csv";

			if (File.Exists(fileName))
			{
				_entries.Clear(); //Clear existing entries

				using (StreamReader reader = new StreamReader(fileName))
				{
					string line;
					
					while ((line = reader.ReadLine()) != null)
					{
						if (Entry.TryParse(line, out Entry entry))
						{
							_entries.Add(entry);
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

		catch
        {
            Console.WriteLine("An error occurred while loading the journal: \n"); // Handle any errors
        }
	}
}