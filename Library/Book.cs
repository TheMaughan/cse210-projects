

public class Book
{
	public string _author;
	public string _name;
	public int _timesRead;
	public bool _available;

	public Book(string author, string name)
	{
		_author = author;
		_name = name;
		//_timesRead = timesRead;
		//_available = available;
	}

	public bool HasAuthor()
	{
		return true;
	}

	public void Display()
	{
		Console.WriteLine($"The book's author is: {_author}\nThe book's title is: {_name}");
	}

	public bool IsAvailable()
	{
		return true;
	}

	public int TimesRead()
	{
		return 3;
	}

	public void CheckOut()
	{

	}

	public void CheckIn()
	{

	}

}