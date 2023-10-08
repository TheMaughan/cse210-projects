using System.IO;
using System.Globalization;

public class JournalFileManager
{
	private int _lastSavedIndex;
	private List<Entry> _entries;
	
	public JournalFileManager()
	{
		_entries = new List<Entry>();
		_lastSavedIndex = -1;
	}

	public void AddEntry(string prompt, string response)
	{

		
		Entry entry = new Entry
		{
			Prompt = prompt,
			Response = response,
			Date = DateTime.Now
		};

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
			Console.WriteLine($"{entry} \n");
		}
	}

	public void MarkExistingEntries(int startIndex, int endIndex) //Stop Duplicating Stuff!!!
	{
		for (int i = startIndex; i <= endIndex; i++)
		{
			_entries[i].Displayed = true;
		}
	}

	public void SaveToFile(string fileName)
	{
		//string name = fileName;
		try
		{
			if (Path.GetExtension(fileName) != ".csv")
				fileName = Path.ChangeExtension(fileName, ".csv"); //Just add the @#$# file extension!

			using (StreamWriter writer = new StreamWriter(fileName, true))
			{
				for (int i = _lastSavedIndex + 1; i <_entries.Count; i++)
				{
					if (!_entries[i].Displayed)
					{
						var entry = _entries[i];
						// Format the entry as a CSV line and write it to the file
                        writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}," +
                                         $"{EscapeCsvField(entry.Prompt)},{EscapeCsvField(entry.Response)}");
                    }
					
				}
				_lastSavedIndex = _entries.Count - 1;
			}
			Console.WriteLine($"Jounal entry saved successfully to the file '{fileName}'.\n");
		}

		catch
		{
			Console.WriteLine($"An error occurred while saving the journal: \n");
		}
	}

	private string EscapeCsvField(string field)
	{
		return $"\"{field.Replace("\"", "\"\"")}\"";
	}

	public void LoadFromFile(string fileName)
	{
		try
		{
			if (Path.GetExtension(fileName) != ".csv")
				fileName = Path.ChangeExtension(fileName, ".csv");

			if (File.Exists(fileName))
			{
				_entries.Clear(); //Clear existing entries

				using (StreamReader reader = new StreamReader(fileName))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						string[] parts = line.Split('|');
						if (parts.Length == 3)
						{
							Entry entry = new Entry
							{
								Date = DateTime.Parse(parts[0]),
								Prompt = parts[1],
								Response = parts[2]
							};
							_entries.Add(entry);
						}
					}
				}
			}
			Console.WriteLine($"Journal file named '{fileName}' loaded successfully.\n");
		}

		catch
        {
            Console.WriteLine("An error occurred while loading the journal: \n"); // Handle any errors
        }
	}
}