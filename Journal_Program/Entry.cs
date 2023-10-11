using System.Collections.Generic;
using System.IO;
using System.Globalization;
#nullable enable //I'm attempting to get rid of all the warnings about "null" stuff. 
//This is also the explination for the "?" & "??" in the code below:

public class Entry
{
	public string? _prompt { get; set; }
	public string? _response { get; set; }
	public DateTime _date { get; set; }
	//public bool Displayed { get; set; } //Flag an entry if it has been displayed.

	public Entry(DateTime date, string? prompt, string? response)
	{
		
		_date = date;
		_prompt = prompt;
		_response = response;
		//Displayed = false; //default value is false
	}


	public override string ToString()// provide a string representation of the entry
	{
		string promptString = _prompt ?? "No Prompt";
		string responseString = _response ?? "No Response";

		return $"{_date} - Prompt: {_prompt}\nResponse: {_response}\n";
	}

	public static bool TryParse(string? entryString, out Entry? entry) //Try to parse a string to an Entry object
    {
        entry = null;

        try
        {
            string[]? parts = entryString.Split(',');

			//Check if the entry string has valid parts and parse the date
            if (parts.Length == 3 && DateTime.TryParseExact(parts[0], "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out DateTime date))
            {
				//Create a new Entry with parsed data
                entry = new Entry(date, parts[1] ?? "No prompt selected", parts[2] ?? "No response provided");
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