public class WritingAssignment : Assignment
{
	private string _title;

	public WritingAssignment(string name, string book, string topic = "WRITING ASSIGNMENT") : base(name, topic)
	{
		_title = book;
	}

	public string GetWritingInformation()
	{
		return $"{GetSummary()}{_title} by {GetName()}.\n";
	}
}