

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
		_timesRead = 0;
		_available = true;
	}

	public bool HasAuthor(string author)
	{
		return _author.Contains(author);
	}

	public void Display()
	{
		Console.WriteLine($"The book's author is: {_author}\nThe book's title is: {_name}\nYou have read this book {_timesRead} times.\n");

		if (!_available)
		{
			Console.WriteLine("[Checked Out]");
		}
	}

	public bool IsAvailable()
	{
		return _available;
	}

	public int TimesRead()
	{
		return _timesRead;
	}

	public void CheckOut()
	{
		_timesRead += 1;
		_available = false;

	}

	public void CheckIn()
	{
		_available = true;
	}

}