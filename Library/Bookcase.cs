public class Bookcase
{
	public List<Book> _book;

	public Bookcase()
	{
		_book = new List<Book>();
	}

	public void ShowBook()
	{

	}

	public void AddBook(Book book)
	{
		_book.Add(book);

	}

	public void FindBookByAuthor()
	{

	}

	public string CountBook()
	{
		return $"We have {_book.Count} available.";

	}

	public void ShowPopularBook()
	{

	}
}


