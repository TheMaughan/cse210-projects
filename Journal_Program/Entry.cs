using System.Collections.Generic;
using System.IO;

public class Entry
{
	public string Prompt { get; set; }
	public string Response { get; set; }
	public DateTime Date { get; set; }
	public bool Displayed { get; set; } //Flag an entry if it has been displayed.

	public override string ToString()
	{
		return $"{Date} - Prompt: {Prompt}\nResponse: {Response}\n";
	}
}