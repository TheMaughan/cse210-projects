using System.Security.Cryptography.X509Certificates;

public class Assignment
{
	private string _studentName;
	private string _topic;

	public Assignment(string n, string t)
	{
		_studentName = n;
		_topic = t;
	}

	public string GetSummary()
	{
		return $"\nThe student is {_studentName} and the topic is {_topic}.\n";
	}

	public string GetName()
	{
		return _studentName;
	}
}