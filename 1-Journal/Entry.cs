public class Entry
{
	public string Prompt { get; set; }
	public string Response { get; set; }
	public DateTime Date { get; set; }

	public override string ToString()
	{
		return $"{Date} - Prompt: {Prompt}\nResponse: {Response}\n";
	}
}