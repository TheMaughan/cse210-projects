using System.IO; 

public class File
{
	private int _lastSavedIndex;
	private List<Entry> _entries;

	public File()
	{
		_entries = new List<Entry>();
		_lastSavedIndex = -1;
	}
	
	
	public void DisplayFile()
	{
		
		foreach (var entry in _entries)
		{
			Console.WriteLine(entry);
		}


		/*try
		{
			// Read the CSV file using StreamReader
			string filename = ;
			string[] lines = System.IO.File.ReadAllLines(filename);

			foreach (string line in lines)
			{
			    string[] parts = line.Split("■");

			    string index = parts[0];
			    string date = parts[1];
				string entry = parts[2];
				
				Console.WriteLine($"{index} | {date} | {entry} ");
			}
		}
		catch (Exception e)
		{
		    Console.WriteLine("An error occurred: " + e.Message);
		}*/
	}

	public void SaveToFile(string fileName)
	{
		try
		{
			using (StreamWriter writer = new StreamWriter(fileName, true))
			{
				for (int i = _lastSavedIndex + 1; i <_entries.Count; i++)
				{
					var entry = _entries[i];
					writer.WriteLine($"{entry.Date} | {entry.Prompt} | {entry.Response}");
				}
				_lastSavedIndex = _entries.Count - 1;
			}
			Console.WriteLine("Jounal entry saved successfully.");
		}

		catch
		{
			Console.WriteLine($"An error occurred while saving the journal: {e.Message}");
		}
	}

	public void LoadFromFile(string filename);
	{
		try
		{
			_entries.Clear(); //Clear existing entries

			using (StreamReader reader = new StreamReader(filename))
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
			Console.WriteLine("Journal loaded successfully.");
			}

			catch (Exception e)
			{
				Console.WriteLine($"An error occured while loading the journal {e.Message}");
			}
		}
	}

	
}