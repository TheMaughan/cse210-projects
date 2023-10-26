public class MathAssignment : Assignment
{
	private string _textbookSection;
	private string _problems;

    public MathAssignment(string name, string book, string problems, string topic = "MATH ASSIGNMENT") : base(name, topic)
	{
		_textbookSection = book;
		_problems = problems;
	}

	public string GetHomeworkList()
	{
		return $"{GetSummary()}The math homework is in {_textbookSection}, do problems {_problems}.\n";
	}
}