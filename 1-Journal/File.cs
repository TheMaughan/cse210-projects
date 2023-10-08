using System.IO; 

public class File
{
	private List<Entry> _entries;

	public File()
	{
		_entries = new List<Entry>();
	}
	
	
	public void DisplayFile(string filename)
	{
		try
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
		}

	}


	
}