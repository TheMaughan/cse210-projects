public class Journal
{
	private List<Entry> entries;

	public void Display()
	{
		entries = new List<Entry>();
	}

	public void AddEntry(string prompt, string response)
	{
		Entry entry = new Entry
		{
			Prompt = prompt,
			Response = response,
			Date = DateTime.Now
		};

		entries.Add(entry);
	}

	



}