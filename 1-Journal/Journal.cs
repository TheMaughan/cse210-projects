public class Journal
{
	private List<Entry> _entries;

	public void Display()
	{
		_entries = new List<Entry>();
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





}