public class Bookcase
{
	public List<Book> _book;

	public Bookcase()
	{
		_book = new List<Book>();
	}

	public void ShowBook()
	{
		Console.WriteLine("\nAll Books in your Bookcase\n-------------------\n");
		foreach (Book book in _book)
		{
			book.Display();
		}
	}

	public void AddBook(Book book)
	{
		_book.Add(book);

	}

	public void FindBookByAuthor(string author)
	{
		Console.WriteLine($"\nAll Books by the author {author}:\n~~~~~~~~~~~~~~~~~~~~~~~~~\n");
		foreach (Book book in _book)
		{
			if(book.HasAuthor(author))
			{
				book.Display();
			}
		}
	}

	public string CountBook()
	{
		return $"There are {_book.Count} available.";

	}

	/*public void AvailableBooks()
	{
		if (_book == true)
		{
			foreach (Book book in _book)
			{
				Console.WriteLine("The available books in the bookcase are:\n========================\n");
				book.Display();
			}
		}
	}*/

	public void ShowPopularBook(int popNum)
	{
		popNum = Math.Min(popNum,_book.Count);
		Console.WriteLine($"\nThe top {popNum} books are:\n===========================\n");
		int shown = 0;
		_book.Sort((x, y) => y.TimesRead().CompareTo(x.TimesRead()));
		foreach (Book book in _book)
		{
			if(shown < popNum)
			{
				book.Display();
			}
			shown++;
		}
	}
}


