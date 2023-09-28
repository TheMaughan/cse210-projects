public class Resume
{
	private string _name;
	private List<Job> _jobList = new List<Job>();

	public Resume(string name)
	{
		_name = name;
	}

	public void AddJob(Job j)
	{
		_jobList.Add(j);
	}

	public void Display()
	{
		Console.WriteLine();
		Console.WriteLine($"My name is {_name}.");
		Console.WriteLine("My job history is:");
		foreach (Job j in _jobList)
		{
			j.Display();
		}
		Console.WriteLine();

	}

}