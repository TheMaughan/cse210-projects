public class File
{
	public string _filePath = "journal.txt";
	
	
	public void ReadFile()
	{
		try
		{
			// Read the CSV file using StreamReader
			string filename = _filePath;
			string[] lines = System.IO.File.ReadAllLines(filename);

			foreach (string line in lines)
			{
			    string[] parts = line.Split("■");

			    string index = parts[0];
			    string date = parts[1];
				string entry = parts[2];
			}
		}
		catch (Exception e)
		{
		    Console.WriteLine("An error occurred: " + e.Message);
		}
		}
	
}