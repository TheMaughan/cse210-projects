using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class Entry
{
	public string Prompt { get; set; }
	public string Response { get; set; }
	public DateTime Date { get; set; }
	public bool Displayed { get; set; } //Flag an entry if it has been displayed.

	public Entry(DateTime date, string prompt, string response)
	{
		Date = date;
		Prompt = prompt;
		Response = response;
		Displayed = false; //Assuming the default value is false
	}

	public override string ToString()
	{
		return $"{Date} - Prompt: {Prompt}\nResponse: {Response}\n";
	}
	
	public static bool TryParse(string entryString, out Entry entry)
    {
        entry = null;

        try
        {
            string[] parts = entryString.Split(',');
            if (parts.Length == 3 && DateTime.TryParseExact(parts[0], "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out DateTime date))
            {
                entry = new Entry(date, parts[1], parts[2]);
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