// See https://aka.ms/new-console-template for more information
Console.WriteLine();

Book hp = new Book("JK Rowling", "Harry Potter");
Book wok = new Book("Brandon Sanderson", "Way of Kings");
hp.CheckOut();
hp.CheckIn();
wok.CheckOut();
wok.CheckIn();
hp.Display();
Console.WriteLine();
wok.Display();

Console.WriteLine("===========================================\n");

Bookcase bookcase = new Bookcase();
bookcase.AddBook(hp);
bookcase.AddBook(wok);

bookcase.ShowBook();
bookcase.FindBookByAuthor("JK");

bookcase.CountBook();

bookcase.ShowPopularBook(2);